using Microsoft.EntityFrameworkCore;
using TechConfCentral.Models;

namespace TechConfCentral.DAL
{
    public class RoomRepository
    {
        private readonly TechConfCentralContext _context;
        public RoomRepository(TechConfCentralContext context)
        {
            _context = context;
        }
        // Get all rooms
        public async Task<List<Room>> GetRoomsAsync()
        {
            return await _context.Rooms
                .AsNoTracking()
                .ToListAsync();
        }
        // Get room by id
        public async Task<Room?> GetRoomByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }
        // Create room
        public async Task AddRoomAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }
        // Update room
        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
        }
        // Delete room
        public async Task DeleteRoomAsync(int id)
        {
            Room? room = await _context.Rooms.FindAsync(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
            }
        }
        // Check if a track name already exists when creating and updating
        public async Task<bool> RoomNameExistsAsync(string roomName, int roomId)
        {
            return await _context.Rooms
                .AnyAsync(r =>
                r.Name.ToLower() == roomName.ToLower() &&
                r.Id != roomId);
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
