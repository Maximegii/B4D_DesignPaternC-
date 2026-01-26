using TP1.Documents;

namespace TP1.Factories
{
    public class DocumentProfessionnelFactory : IDocumentBancaireFactory
    {
        public IReleveIdentiteBancaire CreerRIB()
        {
            return new RIBProfessionnel();
        }

        public IAttestationCompte CreerAttestation()
        {
            return new AttestationProfessionnel();
        }
    }
}
