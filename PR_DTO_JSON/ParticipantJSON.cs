using System;
using PR_Entites;

namespace PR_DTO_JSON
{
    public class ParticipantJSON
    {
        public Guid id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string ville { get; set; }
        public string noTel { get; set; }
        public string emploi { get; set; }


        // es ce que cest mieux de mettre les precondition dans la declarations des donnes ou dans le constructeur
        // dans ce cas si je ne peux pas faire de constructeur sans emploi

        public ParticipantJSON() {; }

        public ParticipantJSON(Participants p_participant)
        {
            this.id = p_participant.id;
            this.nom = p_participant.nom;
            this.prenom = p_participant.prenom;
            this.ville = p_participant.ville;
            this.noTel = p_participant.noTel;
            this.emploi = p_participant.emploi;
        }

        //public participantjson(participants p_participant)
        //{
        //    this.id = p_participant.id;
        //    this.nom = p_participant.nom;
        //    this.prenom = p_participant.prenom;
        //    this.ville = p_participant.ville;
        //    this.notel = p_participant.notel;
        //}


        public Participants VersEntite()
        {
            return new Participants(this.id, this.nom, this.prenom, this.ville, this.noTel, this.emploi);
        }
    }
}
