using DTO;

namespace Services
{
    public interface IUserService
    {
        public Task<bool> RegisterUser(DTOUserRegister user);
        public Task<bool> Login(string username, string password);
    }
}