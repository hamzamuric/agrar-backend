using AgrarIS.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AgrarIS.Models;
using Microsoft.EntityFrameworkCore;
using AgrarIS.Dtos;
using AgrarIS.Data;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AgrarIS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        UserManager<Korisnik> _userManager;
        SignInManager<Korisnik> _signInManager;
        ITokenService _tokenService;
        RoleManager<IdentityRole> _roleManager;
        IConfiguration _config;
        private readonly AgrarISContext context;

        public AuthController(AgrarISContext context)
        {
            this.context = context;
        }

        //public AuthController(UserManager<Korisnik> userManager, SignInManager<Korisnik> signInManager,
        //    ITokenService tokenService, RoleManager<IdentityRole> roleManager, IConfiguration config)
        //{
        //    //_userManager = userManager;
        //    //_signInManager = signInManager;
        //    //_tokenService = tokenService;
        //    //_roleManager = roleManager;
        //    _config = config;
        //}

        [HttpPost("signup")]
        public async Task<ActionResult> SignUp(KorisnikSignupDto dto)
        {
            //if (await _roleManager.Roles.AnyAsync() == false)
            //{
            //    var roles = new List<KorisnikRole>
            //    {
            //        new KorisnikRole{Name="Korisnik"},
            //        new KorisnikRole{Name="Sluzbenik"},
            //    };

            //    foreach (var role in roles)
            //    {
            //        await _roleManager.CreateAsync(role);
            //    }
            //}

            // TODO: check if user exists

            var korisnik = new Korisnik
            {
                Ime = dto.Ime,
                Prezime = dto.Prezime,
                Email = dto.Email,
                Pol = dto.Pol,
                KorisnickoIme = dto.KorisnickoIme,
                Lozinka = dto.Lozinka,
                BrojTelefona = dto.BrojTelefona,
                DatumRodjenja = dto.DatumRodjenja,
            };

            //var userResult = await _userManager.CreateAsync(korisnik, dto.Lozinka);
            var userResult = context.Korisnik.Add(korisnik);
            context.SaveChanges();

            //if (!userResult.Succeeded)
            //{
            //    return BadRequest(userResult.Errors);
            //}

            //var roleResult = await _userManager.AddToRoleAsync(korisnik, "Korisnik");
            //if (!roleResult.Succeeded)
            //{
            //    return BadRequest(roleResult.Errors);
            //}

            return Ok(new
            {
                dto.Ime,
                dto.Prezime,
                dto.Email,
                dto.Pol,
                dto.KorisnickoIme,
                dto.BrojTelefona,
                dto.DatumRodjenja,
            });
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> login(LoginModel login)
        {
            var korisnik = context.Korisnik.FirstOrDefault(x => x.KorisnickoIme == login.Username && login.Password == x.Lozinka);
            if (korisnik != null)
                return Ok(korisnik);
            return NotFound();
        }
    }
}
