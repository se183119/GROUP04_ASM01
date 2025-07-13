using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RoomTypeRepositories : IRoomTypeRepositories
    {
        private readonly IRoomTypeDAO _roomTypeDAO;

        public RoomTypeRepositories()
        {
            _roomTypeDAO = new RoomTypeDAO();
        }

        public void CreateRoomType(RoomType roomType)
        {
            _roomTypeDAO.CreateRoomType(roomType);
        }

        public void DeleteRoomType(int roomTypeId)
        {
            _roomTypeDAO.DeleteRoomType(roomTypeId);
        }

        public List<RoomType> GetAllRoomTypes()
        {
            return _roomTypeDAO.GetAllRoomTypes();
        }

        public RoomType GetRoomTypeById(int id)
        {
            return _roomTypeDAO.GetRoomTypeById(id);
        }

        public RoomType GetRoomTypeByName(string name)
        {
            return _roomTypeDAO.GetRoomTypeByName(name);
        }

        public void UpdateRoomType(RoomType roomType)
        {
            _roomTypeDAO.UpdateRoomType(roomType);
        }
    }
}
