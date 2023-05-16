namespace dotnet_7.Services.CharacterService;

public interface ICharacterService
{
    Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters();
    Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id);
    Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter);
}