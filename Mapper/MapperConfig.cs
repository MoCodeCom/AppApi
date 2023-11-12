using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appapi.DtoEntity;
using appapi.Entity;
using AutoMapper;

namespace appapi.Mapper
{
    public class MapperConfig:Profile
    {
        public MapperConfig()
        {
            CreateMap<UserEntity, UserDto>()
   
            .ReverseMap();
            CreateMap<AddressEntity, AddressDto>().ReverseMap();

            CreateMap<UserEntity,PostUserDto>()
            //.ForMember(d => d.address, o => o.MapFrom( s=> s.address.id))
            .ReverseMap();

            CreateMap<AddressEntity, PostAddressDto>().ReverseMap();
        }
    }
}