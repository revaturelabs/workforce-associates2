using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Associates2.Domain.DomainModels
{
   public class AssociateDto
   {
      public int? AssociateID { get; set; }
      [StringLength(50), Required, DataType(DataType.Text) ]
      public string FirstName { get; set; }
      [StringLength(50), Required, DataType(DataType.Text)]
      public string LastName { get; set; }
      [DataType(DataType.Text)]
      public string Gender { get; set; }  //set to string to hold Gender.Name
      [Required]
      public string Batch { get; set; }
      public string PhoneNumber { get; set; }
      [StringLength(500), Required]
      public string Email { get; set; }
      public DateTime? DateOfBirth { get; set; }
      public bool HasCar { get; set; }
      public bool HasKeys { get; set; }
      public bool? IsComing { get; set; }
   }
}
