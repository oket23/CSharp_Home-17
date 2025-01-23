using Serilog;
using Serilog.Core;

namespace Home_17
{
    public class UserService
    {
        private readonly Logger _logger;
        private List<User> _users = new List<User>();
        public UserService(Logger logger)
        {
            _logger = logger;
            _users.Capacity = 10;
        }

        public void AddUser(User user)
        {
            try
            {
                _users.Add(user);
                _logger.Information($"User successfully added! Name:{user.FirstName} Surname:{user.LastName} Age:{user.Age}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"{ex.Message}");
            }
        }

        public void DeleteUser(User user)
        {
            try
            {
                _users.Remove(user);
                _logger.Information($"User successfully remove! Name:{user.FirstName} Surname:{user.LastName} Age:{user.Age}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"{ex.Message}");
            }
        }
        public void UpdateUser(User user,string newName,string newSurname,int newAge)
        {
            try
            {
                user.FirstName = newName;
                user.LastName = newSurname;
                user.Age = newAge;
                _logger.Information($"User successfully updated! New name:{user.FirstName} New surname:{user.LastName} New age:{user.Age}");
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"{ex.Message}");
            }
            
        }

    }
}
