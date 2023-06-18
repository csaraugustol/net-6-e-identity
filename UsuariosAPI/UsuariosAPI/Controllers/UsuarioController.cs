using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UsuariosAPI.Data.DTOs.Usuario;
using UsuariosAPI.Models;
using UsuariosAPI.Services;

namespace UsuariosAPI.Controllers;

[ApiController]
[Route("[Controller]")]
public class UsuarioController: ControllerBase
{
    private UsuarioService _usuarioService;

    public UsuarioController(UsuarioService cadastroService)
    {
        _usuarioService = cadastroService;
    }

    [HttpPost("cadastro")]
    public async Task<IActionResult> CadastraUsuario(CreateUsuarioDTO usuarioDTO)
    {
        await _usuarioService.Cadastra(usuarioDTO);
        return Ok("Usuário cadastrado com sucesso!");
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginUsuarioDTO dto)
    {
        var token =  await _usuarioService.Login(dto);
        return Ok(token);
    }
}
