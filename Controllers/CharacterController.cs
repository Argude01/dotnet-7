using Microsoft.AspNetCore.Mvc;

namespace dotnet_7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character
        {
            Name = "Ana"
        }
    };

    [HttpGet("GetAll")]
    public ActionResult<List<Character>> Get()
    {
        return Ok(characters);
    }

    [HttpGet]
    public ActionResult<Character> GetSingle()
    {
        return Ok(characters[0]);
    }

}