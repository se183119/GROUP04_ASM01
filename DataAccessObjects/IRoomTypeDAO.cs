using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IRoomTypeDAO
    {
        RoomType GetRoomTypeById(int id);

        public List<RoomType> GetAllRoomTypes();

        public void CreateRoomType(RoomType roomType);

        public void UpdateRoomType(RoomType roomType);

        public void DeleteRoomType(int roomTypeId);

        RoomType GetRoomTypeByName(string name);
    }
}
