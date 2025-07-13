using BusinessObjects;
using DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class BookingDetailRepositories : IBookingDetailRepositories
    {
        private readonly IBookingDetailDAO _bookingDetailDAO;

        public BookingDetailRepositories()
        {
            _bookingDetailDAO = new BookingDetailDAO();
        }

        public void CreateBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailDAO.CreateBookingDetail(bookingDetail);
        }

        public void DeleteBookingDetail(int id)
        {
            _bookingDetailDAO.DeleteBookingDetail(id);
        }

        public List<BookingDetail> GetAllBookingDetail()
        {
            return _bookingDetailDAO.GetAllBookingDetail();
        }

        public BookingDetail GetBookingDetailById(int id)
        {
            return _bookingDetailDAO.GetBookingDetailById(id);
        }

        public void UpdateBookingDetail(BookingDetail bookingDetail)
        {
            _bookingDetailDAO.UpdateBookingDetail(bookingDetail);
        }
    }
}
