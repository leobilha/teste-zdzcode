using API.Data.Dtos;
using API.Models;
using AutoMapper;

namespace API.Profiles
{
    public class EstudanteProfile: Profile
    {
        public EstudanteProfile()
        {
            CreateMap<CreateEstudanteDto, Estudante>();
        }
    }
}
