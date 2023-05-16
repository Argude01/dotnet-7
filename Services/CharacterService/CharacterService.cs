

using System.Runtime.CompilerServices;

namespace dotnet_7.Services.CharacterService;

public class CharacterService : ICharacterService
{
    private static List<Character> characters = new List<Character>
    {
        new Character(),
        new Character
        {
            Id = 1,
            Name = "Ana"
        }
    };

    private readonly IMapper _mapper;
    public CharacterService(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        serviceResponse.Data = characters.Select( c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();
        var character = characters.FirstOrDefault(c => c.Id == id);
        serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
        return serviceResponse;
    }                                        

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> AddCharacter(AddCharacterRequestDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();
        var character = _mapper.Map<Character>(newCharacter);
        character.Id = characters.Max(c => c.Id) + 1;
        characters.Add(character);
        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterResponseDto>> UpdateCharacter(UpdateCharacterRequestDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterResponseDto>();

        try
        {
            var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

            if (character is null)
                throw new Exception($"Character with id {updatedCharacter.Id} not found");

            _mapper.Map(updatedCharacter, character);

            // character.Name = updatedCharacter.Name;
            // character.HitPoints = updatedCharacter.HitPoints;
            // character.Strength = updatedCharacter.Strength;
            // character.Defense = updatedCharacter.Defense;
            // character.Intelligence = updatedCharacter.Intelligence;
            // character.Class = updatedCharacter.Class;

            serviceResponse.Data = _mapper.Map<GetCharacterResponseDto>(character);
        }
        catch (Exception ex)
        {
             serviceResponse.Success = false;
             serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterResponseDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterResponseDto>>();

        try
        {
            var character = characters.FirstOrDefault(c => c.Id == id);

            if (character is null)
                throw new Exception($"Character with id {id} not found");

            characters.Remove(character);

            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        }
        catch (Exception ex)
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }

        return serviceResponse;
    }
}