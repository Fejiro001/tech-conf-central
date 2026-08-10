using TechConfCentral.DAL;
using TechConfCentral.Models;

namespace TechConfCentral.BLL
{
    public class RoomService
    {
        private readonly RoomRepository _repository;
        public RoomService(RoomRepository repository)
        {
            _repository = repository;
        }
        // Get all rooms
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _repository.GetRoomsAsync();
        }
        // Get room by id
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _repository.GetRoomByIdAsync(id);
        }
        // Create room
        public async Task AddRoomAsync(Room room)
        {
            bool nameExists = await _repository.RoomNameExistsAsync(room.Name, room.Id);

            if (nameExists)
            {
                throw new ArgumentException($"A room with the name '{room.Name}' already exists.");
            }

            await _repository.AddRoomAsync(room);
            await _repository.SaveChangesAsync();
        }
        // Update room
        public async Task UpdateRoomAsync(Room room)
        {
            bool nameExists = await _repository.RoomNameExistsAsync(room.Name, room.Id);

            if (nameExists)
            {
                throw new ArgumentException($"A room with the name '{room.Name}' already exists.");
            }

            _repository.UpdateRoom(room);
            await _repository.SaveChangesAsync();
        }
        // Delete room
        public async Task DeleteRoomAsync(int id)
        {
            await _repository.DeleteRoomAsync(id);
            await _repository.SaveChangesAsync();
        }
    }
}
