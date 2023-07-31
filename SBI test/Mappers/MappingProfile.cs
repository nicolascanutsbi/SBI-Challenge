namespace SBI_test.Models
{
    using AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ServerPost, Salida>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.Titulo, opt => opt.MapFrom(src => src.title));
        }
    }

}
