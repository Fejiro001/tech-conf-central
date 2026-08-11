using Microsoft.EntityFrameworkCore;
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
        // Get all rooms that have talks by conference
        public async Task<List<Room>> GetRoomsByConferenceAsync(int conferenceId)
        {
            return await _repository.GetRoomsByConferenceAsync(conferenceId);
        }
        // Get room by id
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _repository.GetRoomByIdAsync(id);
        }
        // Create room
        public async Task AddRoomAsync(Room room)
        {
            await ValidateRoomAsync(room);

            await _repository.AddRoomAsync(room);
            await _repository.SaveChangesAsync();
        }
        // Update room
        public async Task UpdateRoomAsync(Room room)
        {
            await ValidateRoomAsync(room);

            _repository.UpdateRoom(room);
            await _repository.SaveChangesAsync();
        }
        // Delete room
        public async Task DeleteRoomAsync(int id)
        {
            await _repository.DeleteRoomAsync(id);
            await _repository.SaveChangesAsync();
        }
        private async Task ValidateRoomAsync(Room room)
        {
            bool nameExists = await _repository.RoomNameExistsAsync(room.Name, room.Id);

            if (room.Capacity < 1)
            {
                throw new ArgumentException("A room's capacity must be at least 1.");
            }

            if (nameExists)
            {
                throw new ArgumentException($"A room with the name '{room.Name}' already exists.");
            }
        }
    }
}
