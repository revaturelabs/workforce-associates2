﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Associates2.Rest.Models;

namespace Workforce.Logic.Associates2.Rest.Controllers
{
  /// <summary>
  /// This entire controller is strictly
  /// for the admin users in this app
  /// </summary>
  [Authorize(Roles="Admin")]
  [RoutePrefix("api/roles")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class RolesController : BaseApiController
  {
    /// <summary>
    /// This will get the role by its id
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [Route("{id:guid}", Name="GetRoleById")]
    public async Task<IHttpActionResult> GetRole(string Id)
    {
      var role = await this.AppRoleManager.FindByIdAsync(Id);

      if(role != null)
      {
        return Ok(TheModelFactory.Create(role));
      }

      return NotFound();
    }

    /// <summary>
    /// This will get all roles so you know
    /// which roles are existing
    /// </summary>
    /// <returns></returns>
    [Route("", Name="GetAllRoles")]
    public IHttpActionResult GetAllRoles()
    {
      var roles = this.AppRoleManager.Roles;

      return Ok(roles);
    }

    /// <summary>
    /// This will be to help create a role
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [Route("create")]
    public async Task<IHttpActionResult> Create(CreateRoleBindingModel model)
    {
      if(!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      var role = new IdentityRole { Name = model.Name };
      var result = await this.AppRoleManager.CreateAsync(role);

      if(!result.Succeeded)
      {
        return GetErrorResult(result);
      }

      Uri locationHeader = new Uri(Url.Link("GetRoleById", new { id = role.Id}));

      return Created(locationHeader, TheModelFactory.Create(role));
    }


    /// <summary>
    /// This will be used to help delete a role
    /// </summary>
    /// <param name="Id"></param>
    /// <returns></returns>
    [Route("{id:guid}")]
    public async Task<IHttpActionResult> DeleteRole(string Id)
    {

      var role = await this.AppRoleManager.FindByIdAsync(Id);

      if (role != null)
      {
        IdentityResult result = await this.AppRoleManager.DeleteAsync(role);

        if (!result.Succeeded)
        {
          return GetErrorResult(result);
        }

        return Ok();
      }

      return NotFound();

    }

    /// <summary>
    /// This will find a user in a given role
    /// </summary>
    /// <IMPORTANT NOTE>
    /// This method must be modified so that it talks to a method inside of a class instead of computing
    /// the method inside itself as this is suppose to be a simple API call to an internal method
    /// </IMPORTANT>
    /// <param name="model"></param>
    /// <returns></returns>
    [Route("ManageUsersInRole")]
    public async Task<IHttpActionResult> ManageUsersInRole(UsersInRoleModel model)
    {
      var role = await this.AppRoleManager.FindByIdAsync(model.Id);

      if (role == null)
      {
        ModelState.AddModelError("", "Role does not exist");
        return BadRequest(ModelState);
      }

      //will provide all the users in the role
      foreach (string user in model.ActiveUsers)
      {
        var appUser = await this.AppUserManager.FindByIdAsync(user);

        if (appUser == null)
        {
          ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
          continue;
        }

        if (!this.AppUserManager.IsInRole(user, role.Name))
        {
          IdentityResult result = await this.AppUserManager.AddToRoleAsync(user, role.Name);

          if (!result.Succeeded)
          {
            ModelState.AddModelError("", String.Format("User: {0} could not be added to role", user));
          }

        }
      }

      //This will give all the users
      //who were once in that role but
      //are not removed from that role
      foreach (string user in model.RemovedUsers)
      {
        var appUser = await this.AppUserManager.FindByIdAsync(user);

        if (appUser == null)
        {
          ModelState.AddModelError("", String.Format("User: {0} does not exists", user));
          continue;
        }

        IdentityResult result = await this.AppUserManager.RemoveFromRoleAsync(user, role.Name);

        if (!result.Succeeded)
        {
          ModelState.AddModelError("", String.Format("User: {0} could not be removed from role", user));
        }
      }

      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      return Ok();
    }
  }
}
