namespace TP1.Documents
{
    public class AttestationProfessionnel : IAttestationCompte
    {
        public string GenererDocument()
        {
            return "[LOGO BANQUE]\n" +
                   "=== ATTESTATION DE COMPTE PROFESSIONNELLE ===\n" +
                   "Type: Professionnel\n" +
                   "Le présent document atteste que la société est titulaire d'un compte.\n" +
                   "*** MENTIONS LÉGALES SPÉCIFIQUES ***\n";
        }
    }
}
