using System;
using System.Collections.Generic;
using System.Text;

namespace MedFlow.Identity.Application.Dtos
{
    public record LoginRequestDto(string email, string password);
}
