using TP1.Factories;

namespace TP1.Clients
{
    public class ClientProfessionnel : Client
    {
        public string RaisonSociale { get; set; }
        public string Siret { get; set; }

        public ClientProfessionnel(string raisonSociale, string siret, string numeroCompte) 
            : base(raisonSociale, numeroCompte)
        {
            RaisonSociale = raisonSociale;
            Siret = siret;
            _factory = new DocumentProfessionnelFactory();
        }

        public override string ToString()
        {
            return $"Client Professionnel: {RaisonSociale} (SIRET: {Siret})";
        }
    }
}
