using TP1.Documents;

namespace TP1.Factories
{
    public class DocumentParticulierFactory : IDocumentBancaireFactory
    {
        public IReleveIdentiteBancaire CreerRIB()
        {
            return new RIBParticulier();
        }

        public IAttestationCompte CreerAttestation()
        {
            return new AttestationParticulier();
        }
    }
}
