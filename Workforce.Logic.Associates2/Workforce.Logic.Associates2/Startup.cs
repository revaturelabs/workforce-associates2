﻿using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataHandler.Encoder;
using Microsoft.Owin.Security.Jwt;
using Microsoft.Owin.Security.OAuth;
using Newtonsoft.Json.Serialization;
using Owin;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;
using System.Web.Http;
using Workforce.Logic.Associates2.Infrastructure;
using Workforce.Logic.Associates2.Rest.Providers;

namespace Workforce.Logic.Associates2.Rest
{

  /// <summary>
  /// Will create a fresh instance from the ApplicationDbContext
  /// and ApplicationUserManager for each request and set it in
  /// the Owin context using the extension method CreatePerOwinContext
  /// </summary>
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      HttpConfiguration httpConfig = new HttpConfiguration();

      ConfigureOAuthTokenGeneration(app);

      ConfigureOAuthTokenConsumption(app);

      ConfigureWebApi(httpConfig);

      app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

      app.UseWebApi(httpConfig);
    }

    /// <summary>
    /// //Configure the db context and user manager to use a single instance per request
    /// </summary>
    /// <param name="app"></param>
    private void ConfigureOAuthTokenGeneration(IAppBuilder app)
    {
      
      app.CreatePerOwinContext(ApplicationDbContext.Create);
      app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
      app.CreatePerOwinContext<ApplicationRoleManager>(ApplicationRoleManager.Create);

      //Plug in the OAuth bearer JSON web token
      OAuthAuthorizationServerOptions OAuthServerOptions = new OAuthAuthorizationServerOptions()
      {
        //development purposes only. Set to false for production
        AllowInsecureHttp = true,
        TokenEndpointPath = new PathString("/oauth/token"),
        AccessTokenExpireTimeSpan = TimeSpan.FromDays(1),
        Provider = new CustomOAuthProvider(),
        AccessTokenFormat = new CustomJwtFormat(ConfigurationManager.AppSettings["Issuer"])
      };

      app.UseOAuthAuthorizationServer(OAuthServerOptions);
    }

    private void ConfigureWebApi(HttpConfiguration config)
    {
      config.MapHttpAttributeRoutes();

      var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
      jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
    }

    private void ConfigureOAuthTokenConsumption(IAppBuilder app)
    {
      var issuer = ConfigurationManager.AppSettings["Issuer"];
      string audienceId = ConfigurationManager.AppSettings["AudienceID"];
      byte[] audienceSecret = TextEncodings.Base64Url.Decode(ConfigurationManager.AppSettings["AudienceSecret"]);

      //Api controllers with an [Authorize] attribute will be validated with JWT
      app.UseJwtBearerAuthentication(
        new JwtBearerAuthenticationOptions
        {
          AuthenticationMode = AuthenticationMode.Active,
          AllowedAudiences = new[] { audienceId },
          IssuerSecurityTokenProviders = new IIssuerSecurityTokenProvider[]
          {
            new SymmetricKeyIssuerSecurityTokenProvider(issuer, audienceSecret)
          }
        });
    }
  }
}