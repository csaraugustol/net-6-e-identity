using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UsuariosAPI.Authorization;

public class IdadeAuthorization : AuthorizationHandler<IdadeMinima>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, IdadeMinima requirement)
    {
        var dataNascClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

        if(dataNascClaim is null) return Task.CompletedTask;

        var dataNasc = Convert.ToDateTime(dataNascClaim.Value);

        var idadeUsuario = DateTime.Today.Year - dataNasc.Year;

        if (dataNasc > DateTime.Today.AddYears(-idadeUsuario)) idadeUsuario--;

        if (idadeUsuario >= requirement.Idade) context.Succeed(requirement);

        return Task.CompletedTask;
    }
}
