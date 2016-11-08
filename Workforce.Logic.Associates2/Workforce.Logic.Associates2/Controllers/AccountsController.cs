﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using Workforce.Logic.Associates2.Domain;
using Workforce.Logic.Associates2.Domain.DomainModels;
using Workforce.Logic.Associates2.Infrastructure;
using Workforce.Logic.Associates2.Rest.Models;

namespace Workforce.Logic.Associates2.Rest.Controllers
{
  [RoutePrefix("api/accounts")]
  [EnableCors(origins: "*", headers: "*", methods: "*")]
  public class AccountsController : BaseApiController
  {
    /// <summary>
    /// return all registered users in our
    /// system by calling the ApplicationUserManager Class
    /// </summary>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [Route("user")]
    public IHttpActionResult GetUsers()
    {
      return Ok(this.AppUserManager.Users.ToList().Select(u => this.TheModelFactory.Create(u)));
    }

    /// <summary>
    /// Return just a single user by getting its
    /// ID and calling the FindByIdAsync to do it
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [Route("user/{id:guid}", Name = "GetUserById")]
    public async Task<IHttpActionResult> GetUser(string Id)
    {
      var user = await this.AppUserManager.FindByIdAsync(Id);

      if (user != null)
      {
        return Ok(this.TheModelFactory.Create(user));
      }

      return NotFound();
    }


    /// <summary>
    /// Return just a single user by getting its
    /// username coming from the AppUserManager
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [Route("user/{username}")]
    public async Task<IHttpActionResult> GetUserByName(string username)
    {
      var user = await this.AppUserManager.FindByNameAsync(username);

      if (user != null)
      {
        return Ok(this.TheModelFactory.Create(user));
      }

      return NotFound();
    }

    /// <summary>
    /// Creates the new user
    /// </summary>
    /// <param name="createUserModel"></param>
    /// <returns></returns>
    [AllowAnonymous]
    [Route("create")]
    public async Task<IHttpActionResult> CreateUser(CreateUserBindingModel createUserModel)
    {
      //If the model is valid,
      //We will use it to create
      //a new instance of ApplicationUser
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      //The user's credentials
      //By default, the user
      //will always be level 3
      var user = new ApplicationUser
      {
        UserName = createUserModel.Username,
        Email = createUserModel.Email,
        FirstName = createUserModel.FirstName,
        LastName = createUserModel.LastName,
        Level = 3,
        JoinDate = DateTime.Now.Date
      };

      AssociateDto associate = new AssociateDto()
      {
        FirstName = createUserModel.FirstName,
        LastName = createUserModel.LastName,
        Email = createUserModel.Email,
        Gender = createUserModel.Gender,
        BatchID = createUserModel.Batch
      };

      LogicHelper help = new LogicHelper();
      await help.AddNewAssociate(associate);

      //This will do the work for us to create the user
      //It will validate if the username or email has been used before
      //and will let us know if the password matches the policy we have set forth
      //If the request is valid, the user will be added to our table in
      //the database and return a successful result
      IdentityResult addUserResult = await this.AppUserManager.CreateAsync(user, createUserModel.Password);


      //If the creation failed
      if (!addUserResult.Succeeded)
      {
        return GetErrorResult(addUserResult);
      }

      //This will have the token that is valid for 6 hours only when we call this method
      string code = await this.AppUserManager.GenerateEmailConfirmationTokenAsync(user.Id);

      var callbackUrl = new Uri(Url.Link("ConfirmEmailRoute", new { userId = user.Id, code = code }));

      await this.AppUserManager.SendEmailAsync(user.Id, "Confirm Your Account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a> <br/> Your password is: " + createUserModel.Password);

      Uri locationHeader = new Uri(Url.Link("GetUserById", new { id = user.Id }));

      //returns the created user
      return Created(locationHeader, TheModelFactory.Create(user));
    }

    [AllowAnonymous]
    [HttpGet]
    [Route("ConfirmEmail", Name = "ConfirmEmailRoute")]
    public async Task<IHttpActionResult> ConfirmEmail(string userId = "", string code = "")
    {
      if (string.IsNullOrWhiteSpace(userId) || string.IsNullOrWhiteSpace(code))
      {
        ModelState.AddModelError("", "User Id and Code are required");
        return BadRequest(ModelState);
      }

      //If email is opened and user clicks the link
      //as long as the token is still active 
      //the result will have a successful value.
      IdentityResult result = await this.AppUserManager.ConfirmEmailAsync(userId, code);

      if (result.Succeeded)
      {
        return Redirect("http://ec2-54-173-46-251.compute-1.amazonaws.com/workforce-Associates2/login/index");
      }

      else
      {
        return GetErrorResult(result);
      }
    }

    /// <summary>
    /// This will be used to help the user change their password
    /// if they ever decide that they want to change it.
    /// This will check their id so that the correct person is 
    /// changing his/her password. If the user ID cannot be found,
    /// They will be notified that they have made a possible mistake
    /// </summary>
    /// <param name="model"></param>
    /// <returns></returns>
    [Authorize]
    [Route("ChangePassword")]
    public async Task<IHttpActionResult> ChangePassword(ChangePasswordBindingModel model)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest(ModelState);
      }

      IdentityResult result = await this.AppUserManager.ChangePasswordAsync(User.Identity.GetUserId(), model.OldPassword, model.NewPassword); //test to see

      if (!result.Succeeded)
      {
        return GetErrorResult(result);
      }

      return Ok();
    }

    /// <summary>
    /// This method will Delete a user by 
    /// using the HTTP DELETE request
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [Route("user/{id:guid}")]
    public async Task<IHttpActionResult> DeleteUser(string id)
    {
      //Only admin can delete users

      var appUser = await this.AppUserManager.FindByIdAsync(id);

      //If user is found, the user will be deleted
      if (appUser != null)
      {
        IdentityResult result = await this.AppUserManager.DeleteAsync(appUser);

        if (!result.Succeeded)
        {
          return GetErrorResult(result);
        }

        return Ok();
      }

      //If user is not found,
      //client will be notified
      //that they are not found
      return NotFound();
    }

    /// <summary>
    /// This method can only be accessed by Admin accounts only.
    /// This method will accept the UserId in its URI and array of the roles
    /// this userId should be enrolled in. This method will validate that this
    /// array of roles exist in the system. If it doesn't an HTTP Bad response
    /// will be sent letting you know that which roles do not exist. The system
    /// will delete all the roles assigned for the user then will assign only the
    /// roles sent in the request.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="rolesToAssign"></param>
    /// <returns></returns>
    [Authorize(Roles = "Admin")]
    [Route("user/{id:guid}/roles")]
    [HttpPut]
    public async Task<IHttpActionResult> AssignRolesToUser([FromUri] string id, [FromBody] string[] rolesToAssign)
    {
      var appUser = await this.AppUserManager.FindByIdAsync(id);

      if (appUser == null)
      {
        return NotFound();
      }

      var currentRoles = await this.AppUserManager.GetRolesAsync(appUser.Id);
      var rolesNotExists = rolesToAssign.Except(this.AppRoleManager.Roles.Select(x => x.Name)).ToArray();
      if (rolesNotExists.Count() > 0)
      {
        ModelState.AddModelError("", string.Format("Roles '{0}' does not exist", string.Join(",", rolesNotExists)));
      }

      IdentityResult removeResult = await this.AppUserManager.RemoveFromRolesAsync(appUser.Id, currentRoles.ToArray());
      if (!removeResult.Succeeded)
      {
        ModelState.AddModelError("", "Failed to remove user roles");
        return BadRequest(ModelState);
      }

      IdentityResult addResult = await this.AppUserManager.AddToRolesAsync(appUser.Id, rolesToAssign);
      if (!addResult.Succeeded)
      {
        ModelState.AddModelError("", "Failed to add user roles");
        return BadRequest(ModelState);
      }

      return Ok();
    }
  }
}