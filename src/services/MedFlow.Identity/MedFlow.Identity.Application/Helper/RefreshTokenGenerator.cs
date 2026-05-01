using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace MedFlow.Identity.Application.Helper
{
    public class RefreshTokenGenerator()
    {
        public string GenerateRefreshToken()
        {
            var bytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(bytes);

            return Convert.ToBase64String(bytes);
        }
    }
}
