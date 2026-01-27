
    public class ContratHabitation : Contrat
    {
        public string AdresseLogement { get; set; }
        public int SurfaceM2 { get; set; }
        public string TypeLogement { get; set; } // Maison, Appartement
        public decimal Franchise { get; set; }
        public bool OptionDegatsDesEaux { get; set; }
        public bool OptionVolCambriolage { get; set; }

        public ContratHabitation()
        {
            ClausesStandard = "Couverture des dommages au bâtiment et aux biens. " +
                             "Responsabilité civile incluse. " +
                             "Assistance 24h/24 en cas de sinistre.";
            Franchise = 150m;
        }

        
        public override Contrat Clone()
        {
            ContratHabitation clone = (ContratHabitation)this.MemberwiseClone();
            
            clone.NumeroContrat = Guid.NewGuid().ToString();
            return clone;
        }

        public override void AfficherDetails()
        {
            base.AfficherDetails();
            Console.WriteLine($"Adresse: {AdresseLogement}");
            Console.WriteLine($"Type: {TypeLogement}, Surface: {SurfaceM2} m²");
            Console.WriteLine($"Franchise: {Franchise:C}");
            Console.WriteLine($"Option dégâts des eaux: {(OptionDegatsDesEaux ? "Oui" : "Non")}");
            Console.WriteLine($"Option vol/cambriolage: {(OptionVolCambriolage ? "Oui" : "Non")}");
            Console.WriteLine();
        }
    }

