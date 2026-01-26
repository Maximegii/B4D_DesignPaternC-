namespace TP1.Documents
{
    public class AttestationParticulier : IAttestationCompte
    {
        public string GenererDocument()
        {
            return "[LOGO BANQUE]\n" +
                   "=== ATTESTATION DE COMPTE STANDARDISÉE ===\n" +
                   "Type: Particulier\n" +
                   "Le présent document atteste que M./Mme. est titulaire d'un compte.\n";
        }
    }
}
