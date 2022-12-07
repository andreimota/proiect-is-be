using ProiectIS_BE.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Service.Interfaces
{
    public interface IUserService
    {
        string RegisterUser(User user);
    }
}
