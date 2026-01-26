using TP1.Factories;

namespace TP1.Clients
{
    public class ClientParticulier : Client
    {
        public string Prenom { get; set; }

        public ClientParticulier(string nom, string prenom, string numeroCompte) 
            : base(nom, numeroCompte)
        {
            Prenom = prenom;
            _factory = new DocumentParticulierFactory();
        }

        public override string ToString()
        {
            return $"Client Particulier: {Prenom} {Nom}";
        }
    }
}
