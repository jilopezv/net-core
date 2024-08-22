using AutoMapper;

namespace Lab2.Dtos.Profiles;

public class LibroProfile : Profile
{
    public LibroProfile()
    {
        CreateMap<Libro, LibroDetalladoDto>()
            .ForMember(dest => dest.AutorId, opt => opt.MapFrom(src => src.AutorId))
            .ForMember(dest => dest.NombresAutor, opt => opt.MapFrom(src => src.Autor.Nombres))
            .ForMember(dest => dest.ApellidosAutor, opt => opt.MapFrom(src => src.Autor.Apellidos));
        
        CreateMap<Libro, LibroDto>();
        CreateMap<LibroDto, Libro>();
    }
}