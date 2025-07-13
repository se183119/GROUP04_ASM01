using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingReservationRepositories
    {
        BookingReservation GetBookingReservation(int id);

        public List<BookingReservation> GetBookingReservationList();

        public void CreateBookingReservation(BookingReservation reservation);

        public void UpdateBookingReservation(BookingReservation reservation);

        public void DeleteBookingReservation(int id);

        public List<BookingReservation> GetAvailableBookingReservation();

        public List<BookingReservation> GetReservationsByCustomerId(int customerId);

        public int GetMaxBookingReservationId();
    }
}
