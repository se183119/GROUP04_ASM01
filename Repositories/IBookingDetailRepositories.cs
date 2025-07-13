using BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IBookingDetailRepositories
    {
        BookingDetail GetBookingDetailById(int id);

        public List<BookingDetail> GetAllBookingDetail();

        public void CreateBookingDetail(BookingDetail bookingDetail);

        public void UpdateBookingDetail(BookingDetail bookingDetail);

        public void DeleteBookingDetail(int id);
    }
}
