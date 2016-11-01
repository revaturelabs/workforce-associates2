using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Workforce.Data.Associates2.Domain;

namespace Workforce.Data.Associates2.Soap.ServiceMapper
{

    public class EfMapper
    {
      private readonly MapperConfiguration AssociateMapper = new MapperConfiguration(t => t.CreateMap<Associate, AssociateDao>().ReverseMap());
      private readonly MapperConfiguration InstructorMapper = new MapperConfiguration(i => i.CreateMap<Instructor, InstructorDao>().ReverseMap());
      private readonly MapperConfiguration BatchMapper = new MapperConfiguration(b => b.CreateMap<Batch, BatchDao>().ReverseMap());
      private readonly MapperConfiguration GenderMapper = new MapperConfiguration(g => g.CreateMap<Gender, GenderDao>().ReverseMap());
      private readonly MapperConfiguration AddressMapper = new MapperConfiguration(a => a.CreateMap<Address, AddressDao>().ReverseMap());
      private readonly MapperConfiguration AssocAddressMapper = new MapperConfiguration(a => a.CreateMap<AssociateAddress, AssociateAddressDao>().ReverseMap());


      public AssociateDao MapToService(Associate associate)
      {
        var mapper = AssociateMapper.CreateMapper();
        return mapper.Map<AssociateDao>(associate);
      }

      public Associate MapToData(AssociateDao associate)
      {
        var mapper = AssociateMapper.CreateMapper();
        return mapper.Map<Associate>(associate);
      }



      public InstructorDao MapToService(Instructor instuctor)
      {
        var mapper = InstructorMapper.CreateMapper();
        return mapper.Map<InstructorDao>(instuctor);
      }

      public Instructor MapToData(InstructorDao instuctor)
      {
        var mapper = InstructorMapper.CreateMapper();
        return mapper.Map<Instructor>(instuctor);
      }




      public GenderDao MapToService(Gender gender)
      {
        var mapper = GenderMapper.CreateMapper();
        return mapper.Map<GenderDao>(gender);
      }

      public Gender MapToData(GenderDao gender)
      {
        var mapper = GenderMapper.CreateMapper();
        return mapper.Map<Gender>(gender);
      }



      public BatchDao MapToService(Batch batch)
      {
        var mapper = BatchMapper.CreateMapper();
        return mapper.Map<BatchDao>(batch);
      }

      public Batch MapToData(BatchDao batch)
      {
        var mapper = BatchMapper.CreateMapper();
        return mapper.Map<Batch>(batch);
      }



      public AddressDao MapToService(Address address)
      {
        var mapper = AddressMapper.CreateMapper();
        return mapper.Map<AddressDao>(address);
      }

      public Address MapToData(AddressDao address)
      {
        var mapper = AddressMapper.CreateMapper();
        return mapper.Map<Address>(address);
      }



      public AssociateAddressDao MapToService(AssociateAddress assocaddress)
      {
        var mapper = AssocAddressMapper.CreateMapper();
        return mapper.Map<AssociateAddressDao>(assocaddress);
      }

      public AssociateAddress MapToData(AssociateAddressDao assocaddress)
      {
        var mapper = AssocAddressMapper.CreateMapper();
        return mapper.Map<AssociateAddress>(assocaddress);
      }
    }
  }