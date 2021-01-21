using Microsoft.Extensions.Configuration;
using PR_DTO_JSON;
using PR_Entites;
using System;
using System.IO;
using Unity;

namespace ProjetRoxane
{
    class Program
    {

        private static string _ficheirDepotJSON = "participant.json";
        private static string _ficheirDepotXML = "participant.xml";

        static void Main(string[] args)
        {
          
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
            .AddJsonFile("appsettings.json", false)
            .Build();

            string repertoireDepotClient = configuration["RepertoireDepotsClients"];
            string nomFichierDepotClient = configuration["NomFichierDepotClients"];
            string cheminComplet = Path.Combine(repertoireDepotClient, nomFichierDepotClient);

            if (!File.Exists(cheminComplet))
            {
                throw new InvalidOperationException($"Le fichier {cheminComplet} n'existe pas ou est inaccessible");
            }

            string typeDepot = configuration["TypeDepot"];

            IUnityContainer conteneur = new UnityContainer();
            conteneur.RegisterInstance(configuration, InstanceLifetime.Singleton);

            Console.Out.WriteLine("Voulez vous ecrire en json ou xml");

            switch (typeDepot.ToLower())
            {
                case "json":
                    conteneur.RegisterType<IDepotParticipant, DepotParticipantJSON>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { cheminComplet }));
                    break;
                //case "xml":
                //    conteneur.RegisterType<IDepotParticipant, DepotClientsXML>(TypeLifetime.Singleton, new Unity.Injection.InjectionConstructor(new object[] { cheminComplet }));
                //    break;
                default:
                    throw new InvalidOperationException("le type de dépot n'est pas valide, mettre json ou xml");
            }

            ConsoleUI participantConsole = conteneur.Resolve<ConsoleUI>();
            participantConsole.ExecuterUI();
        }
    }
}
