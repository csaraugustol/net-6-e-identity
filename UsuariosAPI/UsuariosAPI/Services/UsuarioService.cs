using AutoMapper;
using Microsoft.AspNetCore.Identity;
using UsuariosAPI.Data.DTOs.Usuario;
using UsuariosAPI.Models;

namespace UsuariosAPI.Services
{
    public class UsuarioService
    {
        private IMapper _mapper;
        private UserManager<Usuario> _userManager;
        private SignInManager<Usuario> _signInManager;
        private TokenService _tokenService;

        public UsuarioService(UserManager<Usuario> userManager, IMapper mapper, SignInManager<Usuario> signInManager, TokenService tokenService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Cadastra(CreateUsuarioDTO usuarioDTO)
        {
            Usuario usuario = _mapper.Map<Usuario>(usuarioDTO);

            IdentityResult result = await _userManager.CreateAsync(usuario, usuarioDTO.Password);

            if (!result.Succeeded) throw new ApplicationException("Falha ao cadastrar usuário!");
        }

        public async Task<string> Login(LoginUsuarioDTO dto)
        {
           var result = await _signInManager.PasswordSignInAsync(dto.Username, dto.Password, false, false);

            if (!result.Succeeded) throw new ApplicationException("Usuário não autenticado!");

            var usuario = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.Username.ToUpper());

            var token = _tokenService.GenerateToken(usuario);

            return token;
        }
    }
}
