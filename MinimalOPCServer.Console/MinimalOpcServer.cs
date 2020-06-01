#define APPSETTINGS

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Opc.Ua;
using Opc.Ua.Configuration;

namespace MinimalOPCServer
{
    public class MinimalOpcServer
    {
        OpcServer server;
        Task status;
        static bool autoAccept = false;


        public async Task Run()
        {
            try
            {
                ExitCode = ExitCode.ErrorServerNotStarted;
                await Initialize();
                Console.WriteLine("Server started. Press Ctrl-C to exit...");
                ExitCode = ExitCode.ErrorServerRunning;
            }
            catch (Exception ex)
            {
                Utils.Trace("ServiceResultException:" + ex.Message);
                Console.WriteLine("Exception: {0}", ex.Message);
                ExitCode = ExitCode.ErrorServerException;
                return;
            }

            //manually keeps thread in running state 
            ManualResetEvent quitEvent = new ManualResetEvent(false);
            try
            {
                Console.CancelKeyPress += (sender, eArgs) => {
                    quitEvent.Set();
                    eArgs.Cancel = true;
                };
            }
            catch
            {
            }

            // wait for timeout or Ctrl-C
            quitEvent.WaitOne();

            if (server != null)
            {
                Console.WriteLine("Server stopped. Waiting for exit...");

                using (var _server = server)
                {
                    // Stop status thread
                    server = null;
                    // Stop server and dispose
                    _server.Stop();
                }
            }

            ExitCode = ExitCode.Ok;
        }


        public static ExitCode ExitCode { get; private set; }


        private static void CertificateValidator_CertificateValidation(CertificateValidator validator,
            CertificateValidationEventArgs e)
        {
            if (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted)
            {
                e.Accept = autoAccept;
                if (autoAccept)
                {
                    Console.WriteLine("Accepted Certificate: {0}", e.Certificate.Subject);
                }
                else
                {
                    Console.WriteLine("Rejected Certificate: {0}", e.Certificate.Subject);
                    Console.Write("Accept this certificate? (y/n, default: n): ");
                    var key = Console.ReadKey();
                    if (key.KeyChar == 'y')
                        e.Accept = true;
                    Console.WriteLine();
                }
            }
        }


        private async Task Initialize()
        {
            string configFileName;
            ApplicationConfiguration config;
#if APPSETTINGS
            configFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "appsettings.json");
            var json = File.ReadAllText(configFileName);
            var appConfig = JsonConvert.DeserializeObject<ApplicationConfiguration>(json);
            await appConfig.Validate(ApplicationType.Server);
            config = ApplicationInstance.FixupAppConfig(appConfig);

            ApplicationInstance application = new ApplicationInstance {
                ApplicationName = "Minimal.OpcServer",
                ApplicationType = ApplicationType.Server,
                ApplicationConfiguration = appConfig,
            };
#else
            ApplicationInstance application = new ApplicationInstance {
                ApplicationName = "Minimal.OpcServer",
                ApplicationType = ApplicationType.Server,
                ConfigSectionName = "Minimal.OpcServer",
            };
            configFileName = ApplicationConfiguration.GetFilePathFromAppConfig(application.ConfigSectionName);
            config = application.LoadApplicationConfiguration(false).Result;
#endif
            Console.WriteLine($"Config: {configFileName}");

            bool certOk = application.CheckApplicationInstanceCertificate(false, 0).Result;
            if (!certOk)
            {
                throw new Exception("Application instance certificate invalid!");
            }

            if (!config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation +=
                    new CertificateValidationEventHandler(CertificateValidator_CertificateValidation);
            }

            server = new OpcServer();
            await application.Start(server);

            //print endpoint info
            var endpoints = application.Server.GetEndpoints().Select(e => e.EndpointUrl).Distinct();
            foreach (var endpoint in endpoints)
            {
                Console.WriteLine(endpoint);
            }

            var firstEndpoint = endpoints.FirstOrDefault();
            Console.Title = firstEndpoint;
        }
    }
}
