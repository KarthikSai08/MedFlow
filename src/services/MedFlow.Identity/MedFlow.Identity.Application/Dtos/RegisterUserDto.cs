using System;
using System.Collections.Generic;
using System.Text;

namespace MedFlow.Identity.Application.Dtos
{
    public record RegisterUserDto(string userName, string email, string passwordHash, string role);
}
