

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
        characters.Add(_mapper.Map<Character>(newCharacter));
        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterResponseDto>(c)).ToList();
        return serviceResponse;
    }
}