﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Workforce.Logic.Felice.Rest.Infrastructure
{

  /// <summary>
  /// 
  /// </summary>
  public class ApplicationUserManager : UserManager<ApplicationUser>
  {
    /// <summary>
    /// Expects to see an instance  from the UserStore
    /// UserStore expects to receive an instance from the ApplicationDbContext
    /// </summary>
    /// <param name="store"></param>
    public ApplicationUserManager(IUserStore<ApplicationUser> store)
      : base (store)
    {

    }

    /// <summary>
    /// Will return an instance of the ApplicationUserManager class
    /// named appUserManager
    /// </summary>
    /// <param name="options"></param>
    /// <param name="context"></param>
    /// <returns></returns>
    public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    {
      var appDbContext = context.Get<ApplicationDbContext>();
      var appUserManager = new ApplicationUserManager(new UserStore<ApplicationUser>(appDbContext));

      appUserManager.EmailService = new Workforce.Logic.Felice.Domain.EmailService();
      var dataProtectionProvider = options.DataProtectionProvider;
      if(dataProtectionProvider != null)
      {
        appUserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"))
        {
          //Code for email confirmation and reset password lifetime
          TokenLifespan = TimeSpan.FromHours(6)
        };
      }

      //configure validation logic so that emails are unqiue
      appUserManager.UserValidator = new UserValidator<ApplicationUser>(appUserManager)
      {
        RequireUniqueEmail = true
      };

      //password requirements, can change later for more security purposes
      appUserManager.PasswordValidator = new PasswordValidator
      {
        RequiredLength = 6,
        RequireLowercase = false,
        RequireUppercase = false,
        RequireNonLetterOrDigit = false,
        RequireDigit = false
      };

      return appUserManager;
    }
  }
}