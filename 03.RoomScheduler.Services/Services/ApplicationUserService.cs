using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using RoomScheduler.Data;
using RoomScheduler.Data.Models;
using RoomScheduler.Services.DataTransferObjects;
using RoomScheduler.Services.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace RoomScheduler.Services.Services
{
    public class ApplicationUserService : IApplicationUserService
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IHttpContextAccessor httpContext;

        public ApplicationUserService(ApplicationDbContext context, IMapper mapper, UserManager<ApplicationUser> userManager, IHttpContextAccessor httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.httpContext = httpContext;
        }

        public async Task<ApplicationUserDto> GetCurrentUser()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);
            ApplicationUserDto userDto = mapper.Map<ApplicationUserDto>(user);
            return userDto;
        }

        public async Task<string> GetCurrentId()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);
            return user.Id;
        }

        public async Task<string> GetCurrentUsername()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);
            return user.UserName;
        }

        public async Task<string> GetCurrentEmail()
        {
            ApplicationUser user = await userManager.GetUserAsync(httpContext.HttpContext.User);
            return user.Email;
        }

        public bool DoesUserExistByUsername(string username)
        {
            ApplicationUserDto user = context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            switch (user)
            {
                case null: return false;
                default: return true;
            }
        }

        public bool DoesUserExistByEmail(string email)
        {
            ApplicationUserDto user = context.Users
                .Where(x => x.Email == email)
                .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            switch (user)
            {
                case null: return false;
                default: return true;
            }
        }

        public ApplicationUserDto GetUserById(string id)
        {
            ApplicationUserDto user = context.Users
                .Where(x => x.Id == id)
                .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }

        public ApplicationUserDto GetUserByUsername(string username)
        {
            ApplicationUserDto user = context.Users
                .Where(x => x.UserName == username)
                .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }

        public ApplicationUserDto GetUserByEmail(string email)
        {
            ApplicationUserDto user = context.Users
                .Where(x => x.Email == email)
                .ProjectTo<ApplicationUserDto>(mapper.ConfigurationProvider)
                .FirstOrDefault();

            return user;
        }
    }
}
