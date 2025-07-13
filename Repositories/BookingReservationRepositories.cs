using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingReservationRepositories : IBookingReservationRepositories
    {
        private readonly IBookingReservationDAO _bookingReservationDAO;

        public BookingReservationRepositories()
        {
            _bookingReservationDAO = new BookingReservationDAO();
        }

        public void CreateBookingReservation(BookingReservation reservation)
        {
            _bookingReservationDAO.CreateBookingReservation(reservation);
        }

        public void DeleteBookingReservation(int id)
        {
            _bookingReservationDAO.DeleteBookingReservation(id);
        }

        public List<BookingReservation> GetAvailableBookingReservation()
        {
            return _bookingReservationDAO.GetAvailableBookingReservation();
        }

        public BookingReservation GetBookingReservation(int id)
        {
            return _bookingReservationDAO.GetBookingReservation(id);
        }

        public List<BookingReservation> GetBookingReservationList()
        {
            return _bookingReservationDAO.GetBookingReservationList();
        }

        public int GetMaxBookingReservationId()
        {
            return _bookingReservationDAO.GetMaxBookingReservationId();
        }

        public List<BookingReservation> GetReservationsByCustomerId(int customerId)
        {
            return _bookingReservationDAO.GetReservationsByCustomerId(customerId);
        }

        public void UpdateBookingReservation(BookingReservation reservation)
        {
            _bookingReservationDAO.UpdateBookingReservation(reservation);
        }
    }
}
