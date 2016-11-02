﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Felice.Domain.DomainModels
{
   public class AssociateDto
   {
      public int? AssociateID { get; set; }
      [StringLength(50), Required, RegularExpression("/^[A-Za-Z]+$/")]
      public string FirstName { get; set; }
      [StringLength(50), Required, RegularExpression("/^[A-Za-Z]+$/")]
      public string LastName { get; set; }
      [RegularExpression("/^[A-Za-Z0-9]+$/")]
      public string Gender { get; set; }  //set to string to hold Gender.Name
      [Required]
      public int BatchID { get; set; }
      public string PhoneNumber { get; set; }
      [StringLength(500), Required]
      public string Email { get; set; }
      public DateTime? DateOfBirth { get; set; }
      public bool HasCar { get; set; }
      public bool HasKeys { get; set; }
      public bool? IsComing { get; set; }
   }
}