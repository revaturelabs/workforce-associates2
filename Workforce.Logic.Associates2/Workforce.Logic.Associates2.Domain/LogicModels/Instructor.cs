﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Workforce.Logic.Associates2.Domain.AssociateService;
using Workforce.Logic.Associates2.Domain.DomainModels;


namespace Workforce.Logic.Associates2.Domain
{
   public class Instructor
   {
      private readonly MapperConfiguration instructorMapper = new MapperConfiguration(i => i.CreateMap<InstructorDao, InstructorDto>().ForMember(i1 => i1.InstructorID, m => m.MapFrom(i2 => i2.InstructorId)));
      private readonly MapperConfiguration instructorReverseMapper = new MapperConfiguration(i => i.CreateMap<InstructorDto, InstructorDao>().ForMember(i1 => i1.InstructorId, m => m.MapFrom(i2 => i2.InstructorID)));
      private CoreValidator val = new CoreValidator();

      /// <summary>
      /// Validates the data coming in from the data layer
      /// </summary>
      public bool ValidateSoapData(InstructorDao instructor)
      {
         int maxName = 50;

         if (val.ValidateInt(instructor.InstructorId)
            && val.ValidateRequiredString(instructor.FirstName, maxName)
            && val.ValidateRequiredString(instructor.LastName, maxName))
         {
            return true;
         }
         else
         {
            return false;
         }
      }

      /// <summary>
      /// After successful validation, this method will map the data from the Data Layer to the Dto
      /// </summary>
      public InstructorDto MapToRest(InstructorDao i)
      {
         var mapper = instructorMapper.CreateMapper();
         return mapper.Map<InstructorDto>(i);
      }

      /// <summary>
      /// Validates the data stored in the Dto being passed through from the Client side
      /// </summary>
      public bool ValidateRestData(InstructorDto instructor)
      {
         var context = new ValidationContext(instructor);
         var results = new List<ValidationResult>();

         return Validator.TryValidateObject(instructor, context, results);
      }
      
      /// <summary>
      /// After validation, this method will Map the data within the Dto to the Data Layer
      /// </summary>
      public InstructorDao MapToSoap(InstructorDto i)
      {
         var mapper = instructorReverseMapper.CreateMapper();
         return mapper.Map<InstructorDao>(i);
      }
   }
}
