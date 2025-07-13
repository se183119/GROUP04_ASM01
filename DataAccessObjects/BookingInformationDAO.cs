using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessObjects
{
    public class BookingInformationDAO : IBookingInformationDAO
    {
        public void CreateRoomInformation(RoomInformation roomInformation)
        {
            using var context = new FuminiHotelManagementContext();
            context.RoomInformations.Add(roomInformation);
            context.SaveChanges();
        }

        public void DeleteRoomInformation(int id)
        {
            using var context = new FuminiHotelManagementContext();
            var infor = context.RoomInformations.FirstOrDefault(ri => ri.RoomId == id);
            infor.RoomStatus = 0;
            context.RoomInformations.Update(infor);
            context.SaveChanges();
        }

        public List<RoomInformation> GetAvailableRoom()
        {
            using var context = new FuminiHotelManagementContext();
            List<RoomInformation> list = context.RoomInformations
                .Where(ri => ri.RoomStatus == 1)
                .Include(ri => ri.RoomType)
                .ToList();
            return list;
        }

        public RoomInformation GetRoomInformation(int id)
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.FirstOrDefault(r => r.RoomId == id);
        }

        public RoomInformation GetRoomInformationByRoomNumber(string roomNumber)
        {
            using var context = new FuminiHotelManagementContext();
            return context.RoomInformations.FirstOrDefault(r => r.RoomNumber == roomNumber);
        }

        public List<RoomInformation> GetRoomInformationList()
        {
            using var context = new FuminiHotelManagementContext();
            List<RoomInformation> list = context.RoomInformations
                .Include(ri => ri.RoomType)
                .ToList();
            return list;
        }

        public List<RoomInformation> GetRoomMaxCapacities(int maxCapaciti)
        {
            using var context = new FuminiHotelManagementContext();
            List<RoomInformation> list = context.RoomInformations
                .Where(r => r.RoomMaxCapacity == maxCapaciti)
                .ToList();
            return list;
        }

        public List<RoomInformation> GetRoomPricePerDay(int pricePerDay)
        {
            using var context = new FuminiHotelManagementContext();
            List<RoomInformation> list = context.RoomInformations
                .OrderByDescending(r => r.RoomPricePerDay == pricePerDay)
                .ToList();
            return list;
        }

        public void UpdateRoomInformation(RoomInformation roomInformation)
        {
            using var context = new FuminiHotelManagementContext();
            context.RoomInformations.Update(roomInformation);
            context.SaveChanges();
        }

        public void UpdateExpiredReservations()
        {
            using var context = new FuminiHotelManagementContext();
            var expiredReservations = context.BookingDetails
                .Where(bd => bd.EndDate < DateOnly.FromDateTime(DateTime.Now))
                .ToList();

            foreach (var detail in expiredReservations)
            {
                var room = context.RoomInformations.Find(detail.RoomId);
                if (room != null)
                {
                    room.RoomStatus = 1;
                }
            }
            context.SaveChanges();
        }
    }
}
