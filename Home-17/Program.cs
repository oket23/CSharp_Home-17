using Serilog;
using Serilog.Core;

namespace Home_17
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Users generation
            Random random = new Random();
            string[] firstNames = { "John", "Jane", "Emily", "Michael", "Sarah", "David", "Anna", "James", "Laura" };
            string[] lastNames = { "Smith", "Brown", "Taylor", "Thomas", "Moore", "White", "Clark", "Harris" };

            User[] users = Enumerable.Range(1, 100).Select(i => new User
            {
                FirstName = firstNames[random.Next(firstNames.Length)],
                LastName = lastNames[random.Next(lastNames.Length)],
                Age =  random.Next(10,100)
            }).ToArray();
            #endregion

            var logger = new LoggerConfiguration()
                .WriteTo.File("logs.txt",outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss} [{Level:u3}]: {Message:lj} {NewLine}{Exception}")
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .CreateLogger();
            try
            {
                var userServies = new UserService(logger);

                for (int i = 0; i < users.Length; i++)
                {
                    userServies.AddUser(users[i]);
                }

                for (int i = 0; i < users.Length; i++)
                {
                    userServies.DeleteUser(users[i]);
                }

                userServies.UpdateUser(users[99], "Oleh", "Holub", 52);
                userServies.UpdateUser(users[100], "Oleh", "Holub", 18);
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
            }
            
        }
    }
}
