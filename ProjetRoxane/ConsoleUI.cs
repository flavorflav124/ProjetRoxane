using System;
using System.Collections.Generic;
using System.Text;
using PR_Entites;

namespace ProjetRoxane
{
    public class ConsoleUI
    {
        private IDepotParticipant m_depotParticipant;


        public void AfficherMenu()
        {
            Console.Out.WriteLine("MENU PRINCIPAL");
            Console.Out.WriteLine("[1] Ajouter un participant");
            Console.Out.WriteLine("[2] Afficher la liste de tous les participants");
            Console.Out.WriteLine("[3] Rechercher un participant par nom");
            Console.Out.WriteLine("[4] Rechercher un participant par emploi");
            Console.Out.WriteLine("[5] Modifier un participant");
            Console.Out.WriteLine("[0] Quitter");
        }

        public int SaisirChoixMenu()
        {
            int choix = -1;
            while (choix < 0 || choix > 5)
            {
                Console.Out.WriteLine("Entrez votre choix, de 0 a 5:");
                choix = Convert.ToInt32(Console.In.ReadLine());
            }
            return choix;
        }

        public void ExecuterUI()
        {
            bool programmeEnExecution = true;

            while (programmeEnExecution)
            {
                AfficherMenu();
                int choixMenu = SaisirChoixMenu();

                switch (choixMenu)
                {
                    case 1:
                        this.m_depotParticipant.AjouterParticipant(SaisirInformation());
                        break;
                    case 2:
                        AfficherTousLesParticipants();
                        break;
                    case 3:
                        RechercherParticipantParNom();
                        break;
                    case 4:
                        RechercherParticipantParEmploi();
                        break;
                    case 5:
                        this.m_depotParticipant.ModifierParticipant(ModifierInformation());
                        break;
                    case 0:
                        programmeEnExecution = false;
                        break;
                    default:
                        break;
                }
            }






        }


        private Participants SaisirInformation()
        {
            Console.Out.WriteLine("Entrez le prenom :");
            string prenom = Console.In.ReadLine();
            Console.Out.WriteLine("Entrez le nom :");
            string nom = Console.In.ReadLine();
            Console.Out.WriteLine("Ville :");
            string ville = Console.In.ReadLine();
            Console.Out.WriteLine("Numero de telephone :");
            string tel = Console.In.ReadLine();
            Console.Out.WriteLine("Emploi :");
            string emploi = Console.In.ReadLine();

            Participants participant = new Participants(Guid.NewGuid(), nom, prenom, ville, tel, emploi);
            return participant;
        }

        private Participants ModifierInformation()
        {
            Console.Out.WriteLine("Entrez le id du participant");
            string id = Console.In.ReadLine();
            Guid input = Guid.Parse(id);
            
            Console.Out.WriteLine("Entrez le prenom :");
            string prenom = Console.In.ReadLine();
            Console.Out.WriteLine("Entrez le nom :");
            string nom = Console.In.ReadLine();
            Console.Out.WriteLine("Ville :");
            string ville = Console.In.ReadLine();
            Console.Out.WriteLine("Numero de telephone :");
            string tel = Console.In.ReadLine();
            Console.Out.WriteLine("Emploi :");
            string emploi = Console.In.ReadLine();

            Participants participant = new Participants(input, nom, prenom, ville, tel, emploi);
            return participant;
        }

        public void AfficherTousLesParticipants()
        {
            List<Participants> listeParticipant = this.m_depotParticipant.ObtenirTousLesParticipants();
            listeParticipant.ForEach(p => p.ToString());
        }

        public List<Participants> RechercherParticipantParNom()
        {
            Console.Out.WriteLine("Entrez le nom que vous rechercher, ou prenom");
            string nom = Console.In.ReadLine();

            return this.m_depotParticipant.RechercherParticipantParNom(nom);
        }

        public List<Participants> RechercherParticipantParEmploi()
        {
            Console.Out.WriteLine("Entrez lemploi que vous rechercher");
            string emploi = Console.In.ReadLine();

            return this.m_depotParticipant.RechercherParticipantParEmploi(emploi);
        }
    }
}
