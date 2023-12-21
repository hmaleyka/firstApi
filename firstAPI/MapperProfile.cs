using AutoMapper;

namespace firstAPI
{
    public class MapperProfile : Profile
    {

        public MapperProfile()
        {
            CreateMap<Car, CreateCarDto>();
            CreateMap<CreateCarDto, Car>() 
                .ForMember(destination=>destination.Name , opr=>opr.MapFrom(src=>src.CarName));
            CreateMap<Brand, CreateBrandDto>();
            CreateMap<CreateBrandDto, Brand>();
        }
    }
}
