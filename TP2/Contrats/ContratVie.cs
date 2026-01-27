
    public class ContratVie : Contrat
    {
        public decimal CapitalGaranti { get; set; }
        public string Beneficiaire { get; set; }
        public int AgeAssure { get; set; }
        public string TypeContrat { get; set; } // Temporaire, Vie entière, Mixte
        public bool OptionDecesAccidentel { get; set; }
        public bool OptionInvalidite { get; set; }
        public bool OptionMaladiesGraves { get; set; }

        public ContratVie()
        {
            ClausesStandard = "Versement du capital en cas de décès. " +
                             "Garantie du capital à échéance si vie entière. " +
                             "Possibilité de rachat partiel ou total.";
            TypeContrat = "Temporaire";
        }

        
        public override Contrat Clone()
        {
            ContratVie clone = (ContratVie)this.MemberwiseClone();
            clone.NumeroContrat = Guid.NewGuid().ToString();
            return clone;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Type de contrat: {TypeContrat}");
            Console.WriteLine($"Capital garanti: {CapitalGaranti:C}");
            Console.WriteLine($"Bénéficiaire: {Beneficiaire}");
            Console.WriteLine($"Âge de l'assuré: {AgeAssure} ans");
            Console.WriteLine($"Option décès accidentel: {(OptionDecesAccidentel ? "Oui" : "Non")}");
            Console.WriteLine($"Option invalidité: {(OptionInvalidite ? "Oui" : "Non")}");
            Console.WriteLine($"Option maladies graves: {(OptionMaladiesGraves ? "Oui" : "Non")}");
            Console.WriteLine();
        }
    }

