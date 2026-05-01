using Dapper;
using MedFlow.Identity.Application.Interfaces.Repositories;
using MedFlow.Identity.Domain.Entities;
using MedFlow.Identity.Infrastructure.Persistence.Data;

namespace MedFlow.Identity.Infrastructure.Repositories
{
    public class UserRepository(DapperContext context) : IUserRepository
    {
        public async Task<bool> EmailExistsAsync(string email, CancellationToken ct)
        {
            using var con = context.CreateConnection();
            var sql = @"SELECT EXISTS (
								SELECT 1
								FROM users 
								WHERE email = @Email AND is_active = TRUE);";

            var result = await con.ExecuteScalarAsync<bool>(new CommandDefinition(sql, new { Email = email }, cancellationToken: ct));

            return result;
        }

        public async Task<User?> GetUserByEmailAsync(string email, CancellationToken ct)
        {
            using var con = context.CreateConnection();

            var sql = @"SELECT user_id AS UserId, username AS UserName,
							   email, password_hash AS PasswordHash,
							   role, is_active AS IsActive 
						FROM users
						WHERE email = @Email AND is_active = TRUE
                        LIMIT 1;";

            var result = await con.QueryFirstOrDefaultAsync<User>(
                new CommandDefinition(sql, new { Email = email }, cancellationToken: ct));

            return result;
        }

        public async Task<User?> GetUserByIdAsync(int userId, CancellationToken ct)
        {
            using var con = context.CreateConnection();
            var sql = @"SELECT user_id as UserId, username AS UserName,
							   email, role, is_active AS IsActive
						FROM users
						WHERE user_id = @Id AND is_active = TRUE";

            var result = await con.QueryFirstOrDefaultAsync<User?>(new CommandDefinition(sql, new { Id = userId }, cancellationToken: ct));

            return result;
        }

        public async Task<int> RegisterUserAsync(User user, CancellationToken ct)
        {
            using var con =await context.CreateOpenConnection();

            var sql = @"INSERT INTO users (username, email, password_hash, role)
						VALUES (@UserName, @Email, @PasswordHash, @Role)
						RETURNING user_id;";

            var result = await con.ExecuteScalarAsync<int>(
                new CommandDefinition(
                    sql, new
                    {
                        user.UserName,
                        user.Email,
                        user.PasswordHash,
                        Role = (int)user.Role
                    }, cancellationToken: ct));

            return result;
        }

        public async Task UpdateLastLoginAsync(int userId, CancellationToken ct)
        {
            using var con =await context.CreateOpenConnection();
            var sql = @"UPDATE users
						SET last_login_at = NOW()
						WHERE user_id = @Id;";

             await con.ExecuteAsync(new CommandDefinition(sql, new { Id = userId }, cancellationToken: ct));
        }
    }
}
