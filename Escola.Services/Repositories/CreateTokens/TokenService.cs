using Escola.Models.Entities;
using Escola.Services.ViewModels;
using Microsoft.EntityFrameworkCore;
using SecureIdentity.Password;

namespace Escola.Services.Repositories.CreateTokens
{
    public class TokenService(CreateToken createToken, DatabaseContext context)
    {
        public async Task<string> Login(LoginViewModel model)
        {
            var user = await context.Users
                .AsNoTracking()
                .Include(x => x.Roles)
                .FirstOrDefaultAsync(x => x.Email == model.Email) 
                ?? throw new Exception("Email não encontrado");

            if (!PasswordHasher.Verify(user.Password, model.Password))
                throw new Exception("Senha invalida");

            var token = createToken.GenerateToken(user);

            return token;
        }
    }
}
