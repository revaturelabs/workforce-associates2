using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Workforce.Logic.Associates2.Domain.DomainModels
{
   public class GenderDto
   {
      public int GenderID { get; set; }
      [Required, DataType(DataType.Text)]
      public string Name { get; set; }
   }
}
