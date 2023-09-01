using AutoMapper;
using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Domain.Commands;
using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Aplication.AMapper
{
    public  class MapperDTOProfile : Profile
    {
        public MapperDTOProfile()
        {
            CreateMap<Filme, FilmeDTO>().
                ForMember(dest => dest.Realizadores, op=>op.MapFrom(src=>src.Realizadors))
                .ReverseMap();
            CreateMap<Realizador, RealizadorDTO>().ReverseMap();
            CreateMap<FilmeDTO, InserirFilmeCommand>().ReverseMap(); 
            CreateMap<FilmeDTO, UpdateFilmeCommand>().ReverseMap();
            CreateMap<RealizadorDTO, InsertRealizadorCommand>().ReverseMap(); 
            CreateMap<RealizadorDTO, UpdateRealizadorCommand>().ReverseMap();
        }
    }
}
