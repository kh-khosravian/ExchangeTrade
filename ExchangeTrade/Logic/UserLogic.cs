using ExchangeTrade.Database.DBConnection;
using ExchangeTrade.Logic.Model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExchangeTrade.Logic
{
    public interface IUserLogic
    {
        Task<UserModel> GetUser(string username);
    }
    public class UserLogic : IUserLogic
    {
        private readonly DUser _UserDB;

        public UserLogic(DUser user)
        {
            _UserDB = user;
        }
        public async Task<UserModel> GetUser(string username)
        {
            var user = await _UserDB.User(username);
            if (user == null)
                return null;

            return new UserModel
            {
                Email = user.Email,
                FullName = user.FullName,
                Id = user.Id,
            };
        }
    }
}
