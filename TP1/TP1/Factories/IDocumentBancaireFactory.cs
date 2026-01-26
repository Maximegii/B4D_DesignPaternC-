using TP1.Documents;

namespace TP1.Factories
{
    public interface IDocumentBancaireFactory
    {
        IReleveIdentiteBancaire CreerRIB();
        IAttestationCompte CreerAttestation();
    }
}
