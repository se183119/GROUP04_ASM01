using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingInformationRepositories : IBookingInformationRepositories
    {
        private readonly IBookingInformationDAO _bookingInformationDAO;

        public BookingInformationRepositories()
        {
            _bookingInformationDAO = new BookingInformationDAO();
        }

        public void CreateRoomInformation(RoomInformation roomInformation)
        {
            _bookingInformationDAO.CreateRoomInformation(roomInformation);
        }

        public void DeleteRoomInformation(int id)
        {
            _bookingInformationDAO.DeleteRoomInformation(id);
        }

        public List<RoomInformation> GetAvailableRoom()
        {
            return _bookingInformationDAO.GetAvailableRoom();
        }

        public RoomInformation GetRoomInformation(int id)
        {
            return _bookingInformationDAO.GetRoomInformation(id);
        }

        public RoomInformation GetRoomInformationByRoomNumber(string roomNumber)
        {
            return _bookingInformationDAO.GetRoomInformationByRoomNumber(roomNumber);
        }

        public List<RoomInformation> GetRoomInformationList()
        {
            return _bookingInformationDAO.GetRoomInformationList();
        }

        public List<RoomInformation> GetRoomMaxCapacities(int maxCapaciti)
        {
            return _bookingInformationDAO.GetRoomMaxCapacities(maxCapaciti);
        }

        public List<RoomInformation> GetRoomPricePerDay(int pricePerDay)
        {
            return _bookingInformationDAO.GetRoomPricePerDay(pricePerDay);
        }

        public void UpdateExpiredReservations()
        {
            _bookingInformationDAO.UpdateExpiredReservations();
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            _bookingInformationDAO.UpdateRoomInformation(roomInformation);
        }
    }
}
