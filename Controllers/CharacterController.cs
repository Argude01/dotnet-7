using Microsoft.AspNetCore.Mvc;

namespace dotnet_7.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CharacterController : ControllerBase
{
    private static Character knight = new Character();

}