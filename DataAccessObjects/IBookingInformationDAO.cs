using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public interface IBookingInformationDAO
    {
        RoomInformation GetRoomInformation(int id);
        //admin view
        public List<RoomInformation> GetRoomInformationList();

        public void CreateRoomInformation(RoomInformation roomInformation);

        public void UpdateRoomInformation(RoomInformation roomInformation);

        public void DeleteRoomInformation(int id);

        RoomInformation GetRoomInformationByRoomNumber(string roomNumber);

        public List<RoomInformation> GetRoomMaxCapacities(int maxCapaciti);
        //customer and admin view
        public List<RoomInformation> GetAvailableRoom();
        //ko nen sai float
        public List<RoomInformation> GetRoomPricePerDay(int pricePerDay);

        public void UpdateExpiredReservations();
    }
}
