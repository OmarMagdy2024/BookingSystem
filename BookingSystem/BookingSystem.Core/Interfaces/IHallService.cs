using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingSystem.Core.Models;

namespace BookingSystem.Core.Interfaces
{
    public interface IHallService
    {
        IEnumerable<Hall> GetAllHalls();
        void AddHall(Hall hall);
         Hall GetHallById(int id);
    }
}
