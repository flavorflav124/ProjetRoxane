using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Entites
{
    public interface IDepotParticipant
    {
        public void AjouterParticipant(Participants p_participant);
        public void ModifierParticipant(Participants p_participant);
        public List<Participants> ObtenirTousLesParticipants();
        public List<Participants> RechercherParticipantParEmploi(string p_emploi);
        public Participants RechercherParticipantParNom(string nom);
    }
}
