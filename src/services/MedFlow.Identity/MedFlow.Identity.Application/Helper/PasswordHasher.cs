using MedFlow.Identity.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedFlow.Identity.Application.Helper
{
    public class PasswordHasher : IPasswordHasher
    {

        public string Hash(string password)
        {
            var hashedPass = BCrypt.Net.BCrypt.HashPassword(password);

            return hashedPass;
        }

        public bool Verify(string password, string hashPassword)
        {
            var success = BCrypt.Net.BCrypt.Verify(password, hashPassword);
            return success;
        }
        
    }
}
