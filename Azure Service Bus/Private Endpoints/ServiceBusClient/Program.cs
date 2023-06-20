using Client;
using Microsoft.Azure.Amqp;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using System.Collections;

namespace Client
{

public class Program
    { 
    
        public static async Task Main(string[] args) {

            string environment = String.Empty;
            if (args.Length != 0) environment = args[0];
            environment = Validate(ref environment);

            string appConfigFileName = String.Empty;
            do
            {
                appConfigFileName = GetAppConfigFileName(environment);
            } while (string.IsNullOrEmpty(appConfigFileName));

            // Build a config object, using env vars and JSON providers.
            IConfiguration config = new ConfigurationBuilder()
            .AddJsonFile(appConfigFileName)
            .AddEnvironmentVariables()
            .Build();

            var settings = new ConfigurationBuilder()
                       .AddAzureAppConfiguration(config["ConnectionStrings:AzureAppConfig"])
                       .Build();

            var connectionString = settings["ServiceBusConnectionString"];
            var queueName = settings["ServiceBusQueueName"];

            MessageBroker msgBroker = new MessageBroker(connectionString, queueName);
            try
            {
                await msgBroker.SendMessageAsync("This is a simple message");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static string GetAppConfigFileName(string environment)
        {
            switch (environment)
            {
                case "development":
                    return "appsettings.development.json";
                case "qa":
                    return "appsettings.qa.json";
                case "production":
                    return "appsettings.json";
                default:
                    return String.Empty;
            }
        }

        private static string Validate(ref string environment)
        {
            if (string.IsNullOrEmpty(environment))
            {
                Console.WriteLine("Please Enter environment value possible values:\n\t 1. Development\n\t 2. Qa\n\t 3. Production \n");
                bool isValidEnvironment = false;
                environment = Console.ReadLine();
                do
                {
                    if ((environment?.ToLower() == "development") || (environment?.ToLower() == "qa") || (environment?.ToLower() == "production"))
                    {
                        environment = environment.ToLower();
                        isValidEnvironment = true;
                    }
                    else
                    {
                        Console.WriteLine("Please Enter environment value possible values:\n\t 1. Development\n\t 2. Qa\n\t 3. Production \n");
                        environment = Console.ReadLine();
                    }
                }
                while (!isValidEnvironment);
            }

            return environment;
        }
    }
}





