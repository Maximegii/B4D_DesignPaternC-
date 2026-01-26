using TP1.Factories;
using TP1.Documents;

namespace TP1.Clients
{
    public abstract class Client
    {
        public string Nom { get; set; }
        public string NumeroCompte { get; set; }
        protected IDocumentBancaireFactory _factory;

        public Client(string nom, string numeroCompte)
        {
            Nom = nom;
            NumeroCompte = numeroCompte;
        }

        public void DemanderDocuments()
        {
            Console.WriteLine($"\n=== Documents pour {Nom} (Compte: {NumeroCompte}) ===");
            
            IReleveIdentiteBancaire rib = _factory.CreerRIB();
            Console.WriteLine(rib.GenererDocument());

            IAttestationCompte attestation = _factory.CreerAttestation();
            Console.WriteLine(attestation.GenererDocument());
        }
    }
}
