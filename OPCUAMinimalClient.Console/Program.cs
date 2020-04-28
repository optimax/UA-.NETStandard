using System.Collections.Generic;
using System.Net;
using Opc.Ua;
using Opc.Ua.Client;
using Opc.Ua.Configuration;

namespace OPCUAConnect.Client.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var appName = "GBPTest";

            //var uri = "opc.tcp://D51WS08510X:4990/FactoryTalkLinxGateway";
            var uri = "opc.tcp://" + Dns.GetHostName() + ":62548/Quickstarts/DataAccessServer";

            var config = CreateOpcConfig(appName, "Step 1 - Create OPC configuration and certificate.");
            var selectedEndpoint = ConfigureEndpoint(config, uri, "Step 2 - Create endpoint.");

            using (var session = CreateSession(selectedEndpoint, config, $"Step 3 - Create a session with the server."))
            {
                BrowseServer(session, "Step 4 - Browse the server namespace.");

                var subscription = CreateSubscription(session, "Step 5 - Create a subscription.");
                CreateItemsToMonitor(subscription, "Step 6 - Add a list of items to monitor to the subscription.");
                Subscribe(session, subscription, "Step 7 - Add the subscription to the session.");

                RunClient("Step 8 - Running the client application.");

                Unsubscribe(subscription, "Step 9 - Unsubscribing.");
                CloseSession(session, "Step 10 - Closing session.");
            }

            Pause("Press any key to exit...");
        }


        private static void CloseSession(Session session, string text)
        {
            System.Console.WriteLine(text);
            session.Close();
        }


        private static void Pause(string text)
        {
            System.Console.WriteLine(text);
            System.Console.ReadKey(true);
        }


        private static void RunClient(string text)
        {
            System.Console.WriteLine(text);
            System.Console.WriteLine("Press any key to end subscription...");
            System.Console.ReadKey(true);
        }


        private static ApplicationConfiguration CreateOpcConfig(string appName, string text)
        {
            System.Console.WriteLine(text);

            var config = new ApplicationConfiguration() {
                ApplicationName = "GBPTest",
                ApplicationUri = Utils.Format(@$"urn:{0}:{appName}", System.Net.Dns.GetHostName()),
                ApplicationType = ApplicationType.Client,
                SecurityConfiguration = new SecurityConfiguration {
                    ApplicationCertificate =
                        new CertificateIdentifier {
                            StoreType = @"Directory",
                            StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\MachineDefault",
                            SubjectName = @$"CN={appName}, DC={System.Net.Dns.GetHostName()}"
                        },
                    TrustedIssuerCertificates =
                        new CertificateTrustList {
                            StoreType = @"Directory",
                            StorePath =
                                @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Certificate Authorities"
                        },
                    TrustedPeerCertificates =
                        new CertificateTrustList {
                            StoreType = @"Directory",
                            StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\UA Applications"
                        },
                    RejectedCertificateStore =
                        new CertificateTrustList {
                            StoreType = @"Directory",
                            StorePath = @"%CommonApplicationData%\OPC Foundation\CertificateStores\RejectedCertificates"
                        },
                    AutoAcceptUntrustedCertificates = true,
                    AddAppCertToTrustedStore = true
                },
                TransportConfigurations = new TransportConfigurationCollection(),
                TransportQuotas = new TransportQuotas {OperationTimeout = 10000},
                ClientConfiguration = new ClientConfiguration {DefaultSessionTimeout = 50000},
                TraceConfiguration = new TraceConfiguration()
            };

            config.Validate(ApplicationType.Client).GetAwaiter().GetResult();
            if (config.SecurityConfiguration.AutoAcceptUntrustedCertificates)
            {
                config.CertificateValidator.CertificateValidation += (s, e) => {
                    e.Accept = (e.Error.StatusCode == StatusCodes.BadCertificateUntrusted);
                };
            }

            var application = new ApplicationInstance {
                ApplicationName = appName, ApplicationType = ApplicationType.Client, ApplicationConfiguration = config
            };
            application.CheckApplicationInstanceCertificate(false, 2048).GetAwaiter().GetResult();

            return config;
        }


        private static EndpointDescription ConfigureEndpoint(ApplicationConfiguration config, string uri, string text)
        {
            System.Console.WriteLine(text);

            var selectedEndpoint = CoreClientUtils.SelectEndpoint(uri, useSecurity: true, operationTimeout: 15000);
            return selectedEndpoint;
        }


        private static Session CreateSession(EndpointDescription selectedEndpoint, ApplicationConfiguration config,
            string text)
        {
            System.Console.WriteLine(text);

            var session = Session.Create(config,
                new ConfiguredEndpoint(null, selectedEndpoint, EndpointConfiguration.Create(config)),
                false, "", 60000, null, null).GetAwaiter().GetResult();

            System.Console.WriteLine($"Configured server: {selectedEndpoint.EndpointUrl}");

            return session;
        }


        private static void BrowseServer(Session session, string text)
        {
            System.Console.WriteLine(text);

            ReferenceDescriptionCollection refs;
            byte[] cp;
            session.Browse(null, null, ObjectIds.ObjectsFolder, 0u, BrowseDirection.Forward,
                ReferenceTypeIds.HierarchicalReferences, true,
                (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out cp, out refs);

            System.Console.WriteLine("DisplayName: BrowseName, NodeClass");
            foreach (var rd in refs)
            {
                System.Console.WriteLine($"{rd.DisplayName}: {rd.BrowseName}, {rd.NodeClass}");
                ReferenceDescriptionCollection nextRefs;
                byte[] nextCp;

                session.Browse(null, null, ExpandedNodeId.ToNodeId(rd.NodeId, session.NamespaceUris), 0u,
                    BrowseDirection.Forward, ReferenceTypeIds.HierarchicalReferences, true,
                    (uint)NodeClass.Variable | (uint)NodeClass.Object | (uint)NodeClass.Method, out nextCp,
                    out nextRefs);

                foreach (var nextRd in nextRefs)
                {
                    System.Console.WriteLine($"+ {nextRd.DisplayName}: {nextRd.BrowseName}, {nextRd.NodeClass}");
                }
            }
        }


        private static Subscription CreateSubscription(Session session, string text)
        {
            System.Console.WriteLine(text);
            var subscription = new Subscription(session.DefaultSubscription) {PublishingInterval = 1000};
            return subscription;
        }


        private static void CreateItemsToMonitor(Subscription subscription, string text)
        {
            System.Console.WriteLine(text);
            var list = new List<MonitoredItem> {
                new MonitoredItem(subscription.DefaultItem) {
                    DisplayName = "ServerStatusCurrentTime", StartNodeId = "i=2258"
                }
            };
            list.ForEach(i => i.Notification += OnTickNotification);
            subscription.AddItems(list);
        }


        private static void Subscribe(Session session, Subscription subscription, string text)
        {
            System.Console.WriteLine(text);
            session.AddSubscription(subscription);
            subscription.Create();
        }


        private static void Unsubscribe(Subscription subscription, string text)
        {
            System.Console.WriteLine(text);
            subscription.Delete(false);
        }


        private static void OnTickNotification(MonitoredItem item, MonitoredItemNotificationEventArgs e)
        {
            foreach (var value in item.DequeueValues())
            {
                System.Console.WriteLine(
                    $"TICK: {item.DisplayName}: {value.Value}, {value.SourceTimestamp}, {value.StatusCode}");
            }
        }
    }
}
