using System;

namespace PR_Entites
{
    public class Participants
    {
        public Guid id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string ville { get; set; }
        public string noTel { get; set; }
        public string emploi { get; set; }

        public Participants() {; }

        public Participants(Guid p_id, string p_nom, string p_prenom, string p_ville, string p_noTel, string p_emploi)
        {
            this.id = p_id;
            this.nom = p_nom;
            this.prenom = p_prenom;
            this.ville = p_ville;
            this.noTel = p_noTel;
            this.emploi = p_emploi;
        }

        public Participants(Guid p_id, string p_nom, string p_prenom, string p_ville, string p_noTel)
        {
            this.id = p_id; 
            this.nom = p_nom;
            this.prenom = p_prenom;
            this.ville = p_ville;
            this.noTel = p_noTel;
        }

        public override string ToString()
        {
            return $"{this.id} : {this.prenom} {this.nom} {this.ville} {this.noTel} {this.emploi}";
        }
    }
}
