using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using PR_Entites;

namespace PR_DTO_JSON
{
    public class DepotParticipantJSON : IDepotParticipant
    {

        public string cheminAcces { get; set; }
        public DepotParticipantJSON(string p_chemin)
        {
            this.cheminAcces = p_chemin;
        }

        public void AjouterParticipant(Participants p_participant)
        { 
            List <ParticipantJSON> partcicipantsFichier = LireFichierSiExiste();

            if (partcicipantsFichier.Any(p => p.id == p_participant.id))
            {
                throw new Exception("Le client est deja enregistree" + p_participant.id);
            }
            else
            {
                ParticipantJSON convertion = new ParticipantJSON(p_participant);
                partcicipantsFichier.Add(convertion);
            }

            SauvegarderDepot(partcicipantsFichier);
          
        }

        public Participants ModifierParticipant()
        {
            throw new NotImplementedException();
        }

        public List<Participants> ObtenirTousLesParticipants()
        {
            throw new NotImplementedException();
        }

        public List<Participants> RechercherParticipantParEmploi()
        {
            throw new NotImplementedException();
        }

        public Participants RechercherParticipantParNom()
        {
            throw new NotImplementedException();
        }


        private List<ParticipantJSON> LireFichierSiExiste()
        {
            List<ParticipantJSON> participants = null;

            if (File.Exists(this.cheminAcces))
            {
                string json = File.ReadAllText(cheminAcces);

                JsonSerializerSettings settings = new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.Auto,
                    Formatting = Formatting.Indented

                };
                participants = JsonConvert.DeserializeObject<List<ParticipantJSON>>(json, settings);
            }
            else
            {
                participants = new List<ParticipantJSON>();
            }
            return participants;
        }

        private void SauvegarderDepot(List<ParticipantJSON> p_participants)
        {
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Auto,
                Formatting = Formatting.Indented

            };

            string json = JsonConvert.SerializeObject(p_participants, settings);
            File.WriteAllText(this.cheminAcces, json);
        }
    }
}
