using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingDetailDAO : IBookingDetailDAO
    {
        public void CreateBookingDetail(BookingDetail bookingDetail)
        {
            using var context = new SmokingCessationContext();
            context.BookingDetails.Add(bookingDetail);
            context.SaveChanges();
        }

        public void DeleteBookingDetail(int id)
        {
            using var context = new SmokingCessationContext();
            var bookingDetail = context.BookingDetails.FirstOrDefault(bd => bd.RoomId == id);
            context.BookingDetails.Remove(bookingDetail);
            context.SaveChanges();
        }

        public List<BookingDetail> GetAllBookingDetail()
        {
            using var context = new SmokingCessationContext();
            List<BookingDetail> detailList = context.BookingDetails
                .Include(bd => bd.BookingReservation)
                .Include(bd => bd.Room)
                .ToList();
            return detailList;
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            using var context = new SmokingCessationContext();
            return context.BookingDetails.Include(bd => bd.Room)
                .FirstOrDefault(bd => bd.BookingReservationId == id);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            using var context = new SmokingCessationContext();
            context.BookingDetails.Update(bookingDetail);
            context.SaveChanges();
        }
    }
}
