using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NSE.Identidade.API.Models;

namespace NSE.Identidade.API.Controllers;

[ApiController]
[Route("api/identidade")]
public class AuthController : ControllerBase
{

    private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public AuthController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    [HttpPost("nova-conta")]
    public async Task<ActionResult> Registrar(UsuarioRegistro usuarioRegistro)
    {
        var user = new IdentityUser
        {
            UserName = usuarioRegistro.Email,
            Email = usuarioRegistro.Email,
            EmailConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, usuarioRegistro.Senha);

        if (result.Succeeded)
        {
            await _signInManager.SignInAsync(user, false);
            return Ok();
        }

        return BadRequest();
    }

    [HttpPost("autenticar")]
    public async Task<ActionResult> Login(UsuarioLogin usuarioLogin)
    {
        var result = await _signInManager.PasswordSignInAsync(usuarioLogin.Email, usuarioLogin.Senha, false, true);
        
        if (result.Succeeded)
        {
            return Ok();
        }

        return BadRequest();
    }
}