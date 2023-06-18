using System.ComponentModel.DataAnnotations;

namespace UsuariosAPI.Data.DTOs.Usuario;

public class CreateUsuarioDTO
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    [Compare("Password")]
    public string RePassword { get; set; }
    [Required]
    [DataType(DataType.Password)]
    public DateTime DataNascimento { get; set; }
}
