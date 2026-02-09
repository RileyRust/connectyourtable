using ClassLibrary.DTOs;

namespace Back_EndAPI.Services
{
    public interface ICharacterService
    {
        Task<List<CharacterDTO>> GetAll();
        Task<CharacterDTO?> Get(int id);
        Task<CharacterDTO> Create(NewCharacterDTO dto);
        Task<bool> Update(int id, NewCharacterDTO dto);
        Task<bool> Delete(int id);
    }
}
