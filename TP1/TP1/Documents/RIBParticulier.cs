namespace TP1.Documents
{
    public class RIBParticulier : IReleveIdentiteBancaire
    {
        public string GenererDocument()
        {
            return "[LOGO BANQUE]\n" +
                   "=== RELEVÉ D'IDENTITÉ BANCAIRE SIMPLIFIÉ ===\n" +
                   "Type: Particulier\n" +
                   "IBAN: FR76 XXXX XXXX XXXX XXXX XXXX XXX\n" +
                   "BIC: XXXXXXXX\n";
        }
    }
}
