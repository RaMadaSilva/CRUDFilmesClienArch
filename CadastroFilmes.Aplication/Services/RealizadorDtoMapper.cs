using CadastroFilmes.Aplication.DTOs;
using CadastroFilmes.Domain.Commands;
using CadastroFilmes.Domain.Entities;

namespace CadastroFilmes.Aplication.Services
{
    public static  class RealizadorDtoMapper
    {
        public static RealizadorDTO ToRealizadorDto(Realizador realizador)
        {
            if (realizador == null)
                throw new ArgumentException(nameof(realizador));

            return new RealizadorDTO
            {
                Id = realizador.Id,
                Name = realizador.Name,
                Age = realizador.Age
            }; 
        }

        public static IEnumerable<RealizadorDTO> ToRealizadorDtoList(IEnumerable<Realizador> realizadores)
        {
            if (realizadores == null)
                throw new ArgumentNullException(nameof(realizadores));

            List<RealizadorDTO> realizadoresDto = new();

            foreach (var realizador in realizadores)
            {
                RealizadorDTO realizadorDto = ToRealizadorDto(realizador);
                realizadoresDto.Add(realizadorDto);

                //yield return ToRealizadorDto(realizador);
            }

            return realizadoresDto;
        }
        public static UpdateRealizadorCommand ToUpdateCommand(RealizadorDTO realizadorDto)
        {
            return new UpdateRealizadorCommand
            {
                Id = realizadorDto.Id,
                Name = realizadorDto.Name,
                Age = realizadorDto.Age,
            }; 
        }
    }
}
