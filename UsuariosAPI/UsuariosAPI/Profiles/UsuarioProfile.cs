using AutoMapper;
using UsuariosAPI.Models;
using UsuariosAPI.Data.DTOs.Usuario;

namespace UsuariosAPI.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioDTO, Usuario>();
    }
}
