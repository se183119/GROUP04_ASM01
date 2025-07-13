using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class RoomTypeDAO : IRoomTypeDAO
    {
        public void CreateRoomType(RoomType roomType)
        {
            using var context = new SmokingCessationContext();
            context.RoomTypes.Add(roomType);
            context.SaveChanges();
        }

        public void DeleteRoomType(int roomTypeId)
        {
            using var context = new SmokingCessationContext();
            var roomType = context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == roomTypeId);
            context.RoomTypes.Remove(roomType);
            context.SaveChanges();
        }

        public List<RoomType> GetAllRoomTypes()
        {
            using var context = new SmokingCessationContext();
            List<RoomType> roomTypesList = context.RoomTypes.ToList();
            return roomTypesList;
        }

        public RoomType GetRoomTypeById(int id)
        {
            using var context = new SmokingCessationContext();
            return context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeId == id);
        }

        public RoomType GetRoomTypeByName(string name)
        {
            using var context = new SmokingCessationContext();
            return context.RoomTypes.FirstOrDefault(rt => rt.RoomTypeName == name);
        }

        public void UpdateRoomType(RoomType roomType)
        {
            using var context = new SmokingCessationContext();
            context.RoomTypes.Update(roomType);
            context.SaveChanges();
        }
    }
}
