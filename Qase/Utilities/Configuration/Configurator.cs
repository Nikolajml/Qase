using Microsoft.Extensions.Configuration;
using System.Reflection;


namespace Core.Utilities.Configuration
{
    public class Configurator
    {
        private readonly Lazy<IConfiguration> s_configuration;
        public  IConfiguration Configuration => s_configuration.Value;

        public Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath ?? throw new InvalidOperationException())
                .AddJsonFile("appsettings.json")
                .AddEnvironmentVariables("Bearer");
                        
            var appSettingFiles = Directory.EnumerateFiles(basePath ?? string.Empty, "appsettings.*.json");
                       
            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
                //что-то должно приходить из AppSetting file что-то должно приходить из enviroments variables
            }

            return builder.Build();
        }

        public AppSettings AppSettings
        {            
            get
            {                
                var appSettings = new AppSettings();
                var child = Configuration.GetSection("AppSettings");

                appSettings.URL = child["URL"];
                appSettings.ApiURL = child["apiUrl"];

                return appSettings;
            }
        }

        public List<User?> Users
        {
            get
            {
                List<User?> users = new List<User?>();
                var child = Configuration.GetSection("Users");
                foreach (var section in child.GetChildren())
                {
                    var user = new User
                    {
                        Password = section["Password"],
                        Username = section["Username"],
                        Token = section["Token"]
                    };
                    user.UserType = section["UserType"]?.ToLower() switch
                    {
                        "admin" => UserType.Admin,
                        "user" => UserType.User,
                        _ => user.UserType
                    };

                    users.Add(user);
                }

                return users;
            }
        }

        public  User? Admin => Users.Find(x => x?.UserType == UserType.Admin);

        public  User? UserByUsername(string username) => Users.Find(x => x?.Username == username);
        public string? Bearer => Configuration[nameof(Bearer)];
        public  string? BrowserType => Configuration[nameof(BrowserType)];        
    }
}
