using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectIS_BE.Common.Interfaces
{
    public interface IAuthService
    {
        string GenerateJwtToken(int id);
        string Encrypt(string password);
        string GetSalt(int length);
    }
}
