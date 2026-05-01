using MedFlow.Identity.Domain.Entities;
using MedFlow.Shared.Contracts.Common;
using Microsoft.AspNetCore.Identity.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedFlow.Identity.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        Task<int> RegisterUserAsync(User user, CancellationToken ct);
        Task<User?> GetUserByEmailAsync(string email, CancellationToken ct);
        Task<User?> GetUserByIdAsync(int userId, CancellationToken ct);
        Task UpdateLastLoginAsync(int userId, CancellationToken ct);
        Task<bool> EmailExistsAsync(string email, CancellationToken ct);
    }
}
