namespace TP1.Documents
{
    public class RIBProfessionnel : IReleveIdentiteBancaire
    {
        public string GenererDocument()
        {
            return "[LOGO BANQUE]\n" +
                   "=== RELEVÉ D'IDENTITÉ BANCAIRE DÉTAILLÉ ===\n" +
                   "Type: Professionnel\n" +
                   "IBAN: FR76 XXXX XXXX XXXX XXXX XXXX XXX\n" +
                   "BIC: XXXXXXXX\n" +
                   "SIRET: XXX XXX XXX XXXXX\n";
        }
    }
}
