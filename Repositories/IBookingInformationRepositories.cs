using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingInformationRepositories
    {
        RoomInformation GetRoomInformation(int id);

        public List<RoomInformation> GetRoomInformationList();

        public void CreateRoomInformation(RoomInformation roomInformation);

        public void UpdateRoomInformation(RoomInformation roomInformation);

        public void DeleteRoomInformation(int id);

        RoomInformation GetRoomInformationByRoomNumber(string roomNumber);

        public List<RoomInformation> GetRoomMaxCapacities(int maxCapaciti);

        public List<RoomInformation> GetAvailableRoom();

        public List<RoomInformation> GetRoomPricePerDay(int pricePerDay);

        public void UpdateExpiredReservations();
    }
}
