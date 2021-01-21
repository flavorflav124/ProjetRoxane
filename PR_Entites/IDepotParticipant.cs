using System;
using System.Collections.Generic;
using System.Text;

namespace PR_Entites
{
    public interface IDepotParticipant
    {
        public void AjouterParticipant(Participants p_participant);
        public Participants ModifierParticipant();
        public List<Participants> ObtenirTousLesParticipants();
        public List<Participants> RechercherParticipantParEmploi();
        public Participants RechercherParticipantParNom();
    }
}
