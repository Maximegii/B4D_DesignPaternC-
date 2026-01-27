using System;

namespace TP2.Contrats
{
    
    public class ContratAutomobile : Contrat
    {
        public string Immatriculation { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public int Annee { get; set; }
        public string NiveauCouverture { get; set; } 
        public decimal Franchise { get; set; }
        public bool OptionConducteurSecondaire { get; set; }
        public bool OptionAssistance0Km { get; set; }

        public ContratAutomobile()
        {
            ClausesStandard = "Responsabilité civile obligatoire. " +
                             "Protection juridique incluse. " +
                             "Assistance dépannage/remorquage.";
            NiveauCouverture = "Tiers";
            Franchise = 200m;
        }

       
        public override Contrat Clone()
        {
            ContratAutomobile clone = (ContratAutomobile)this.MemberwiseClone();
            
            clone.NumeroContrat = Guid.NewGuid().ToString();
            return clone;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Véhicule: {Marque} {Modele} ({Annee})");
            Console.WriteLine($"Immatriculation: {Immatriculation}");
            Console.WriteLine($"Niveau de couverture: {NiveauCouverture}");
            Console.WriteLine($"Franchise: {Franchise:C}");
            Console.WriteLine($"Conducteur secondaire: {(OptionConducteurSecondaire ? "Oui" : "Non")}");
            Console.WriteLine($"Assistance 0 km: {(OptionAssistance0Km ? "Oui" : "Non")}");
            Console.WriteLine();
        }
    }
}
