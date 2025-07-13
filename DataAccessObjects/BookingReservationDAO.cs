using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingReservationDAO : IBookingReservationDAO
    {

        public void CreateBookingReservation(BookingReservation reservation)
        {
            using var context = new FuminiHotelManagementContext();
            context.BookingReservations.Add(reservation);
            context.SaveChanges();
        }

        public void DeleteBookingReservation(int id)
        {
            using var context = new FuminiHotelManagementContext();
            var history = context.BookingReservations.FirstOrDefault(br => br.BookingReservationId == id);
            history.BookingStatus = 0;
            context.BookingReservations.Update(history);
            context.SaveChanges();
        }

        public List<BookingReservation> GetAvailableBookingReservation()
        {
            using var context = new FuminiHotelManagementContext();
            List<BookingReservation> list = context.BookingReservations
                .Where(br => br.BookingStatus == 1)
                .Include(br => br.Customer)
                .ToList();
            return list;
        }

        public BookingReservation GetBookingReservation(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingReservations.Include(br => br.Customer).Include(br => br.BookingDetails).FirstOrDefault(br => br.BookingReservationId == id);
        }

        public List<BookingReservation> GetBookingReservationList()
        {
            using var context = new FuminiHotelManagementContext();
            List<BookingReservation> bookingsList = context.BookingReservations
                .Include(br => br.Customer)
                .ToList();
            return bookingsList;
        }

        public int GetMaxBookingReservationId()
        {
            using var context = new FuminiHotelManagementContext();
            return context.BookingReservations.Max(br => br.BookingReservationId);
        }

        public List<BookingReservation> GetReservationsByCustomerId(int customerId)
        {
            using var context = new FuminiHotelManagementContext();
            List<BookingReservation> list = context.BookingReservations
                .Include(br => br.Customer)
                .Where(br => br.CustomerId == customerId && br.BookingStatus == 1)
                .ToList();
            return list;
        }

        public void UpdateBookingReservation(BookingReservation reservation)
        {
            using var context = new FuminiHotelManagementContext();
            context.BookingReservations.Update(reservation);
            context.SaveChanges();
        }
    }
}
