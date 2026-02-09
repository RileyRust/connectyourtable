using Back_EndAPI.Data;
using ClassLibrary.DTOs;
using ClassLibrary.Entities;
using Microsoft.EntityFrameworkCore;

namespace Back_EndAPI.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly AppDbContext _context;

        public CharacterService(AppDbContext context)
        {
            _context = context;
        }

        // GET ALL
        public async Task<List<CharacterDTO>> GetAll()
        {
            return await _context.Characters
                .Select(c => new CharacterDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    Class = c.Class,
                    Level = c.Level,
                    Health = c.Health,
                    Mana = c.Mana
                }).ToListAsync();
        }

        // GET ONE
        public async Task<CharacterDTO?> Get(int id)
        {
            var c = await _context.Characters.FindAsync(id);
            if (c == null) return null;

            return new CharacterDTO
            {
                Id = c.Id,
                Name = c.Name,
                Class = c.Class,
                Level = c.Level,
                Health = c.Health,
                Mana = c.Mana
            };
        }

        // CREATE
        public async Task<CharacterDTO> Create(NewCharacterDTO dto)
        {
            var entity = new CharacterEntity
            {
                Name = dto.Name,
                Class = dto.Class,
                Level = dto.Level,
                Health = dto.Health,
                Mana = dto.Mana
            };

            _context.Characters.Add(entity);
            await _context.SaveChangesAsync();

            return new CharacterDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Class = entity.Class,
                Level = entity.Level,
                Health = entity.Health,
                Mana = entity.Mana
            };
        }

        // UPDATE
        public async Task<bool> Update(int id, NewCharacterDTO dto)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            character.Name = dto.Name;
            character.Class = dto.Class;
            character.Level = dto.Level;
            character.Health = dto.Health;
            character.Mana = dto.Mana;

            await _context.SaveChangesAsync();
            return true;
        }

        // DELETE
        public async Task<bool> Delete(int id)
        {
            var character = await _context.Characters.FindAsync(id);
            if (character == null) return false;

            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
