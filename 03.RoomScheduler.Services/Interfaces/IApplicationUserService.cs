using RoomScheduler.Services.DataTransferObjects;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Interfaces
{
    public interface IApplicationUserService
    {
        Task<ApplicationUserDto> GetCurrentUser();

        Task<string> GetCurrentId();

        Task<string> GetCurrentUsername();

        Task<string> GetCurrentEmail();

        bool DoesUserExistByUsername(string username);

        bool DoesUserExistByEmail(string email);

        ApplicationUserDto GetUserById(string id);

        ApplicationUserDto GetUserByUsername(string username);

        ApplicationUserDto GetUserByEmail(string email);
    }
}
