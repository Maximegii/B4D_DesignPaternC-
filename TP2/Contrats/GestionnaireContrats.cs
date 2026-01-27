
    public class GestionnaireContrats
    {
        private Dictionary<string, Contrat> _prototypes;

        public GestionnaireContrats()
        {
            _prototypes = new Dictionary<string, Contrat>();
            InitialiserPrototypes();
        }

        
        private void InitialiserPrototypes()
        {
            
            var habitationStandard = new ContratHabitation
            {
                NomClient = "Client à définir",
                MontantPrime = 350m,
                TypeLogement = "Appartement",
                SurfaceM2 = 70,
                Franchise = 150m,
                OptionDegatsDesEaux = true,
                OptionVolCambriolage = false
            };
            _prototypes.Add("HabitationStandard", habitationStandard);

           
            var habitationPremium = new ContratHabitation
            {
                NomClient = "Client à définir",
                MontantPrime = 650m,
                TypeLogement = "Maison",
                SurfaceM2 = 150,
                Franchise = 100m,
                OptionDegatsDesEaux = true,
                OptionVolCambriolage = true
            };
            _prototypes.Add("HabitationPremium", habitationPremium);

            
            var autoTiers = new ContratAutomobile
            {
                NomClient = "Client à définir",
                MontantPrime = 450m,
                NiveauCouverture = "Tiers",
                Franchise = 200m,
                OptionConducteurSecondaire = false,
                OptionAssistance0Km = false
            };
            _prototypes.Add("AutomobileTiers", autoTiers);

            
            var autoTousRisques = new ContratAutomobile
            {
                NomClient = "Client à définir",
                MontantPrime = 850m,
                NiveauCouverture = "Tous risques",
                Franchise = 150m,
                OptionConducteurSecondaire = true,
                OptionAssistance0Km = true
            };
            _prototypes.Add("AutomobileTousRisques", autoTousRisques);

        
            var vieTemporaire = new ContratVie
            {
                NomClient = "Client à définir",
                MontantPrime = 300m,
                TypeContrat = "Temporaire",
                CapitalGaranti = 200000m,
                OptionDecesAccidentel = true,
                OptionInvalidite = false,
                OptionMaladiesGraves = false
            };
            _prototypes.Add("VieTemporaire", vieTemporaire);

           
            var vieEntiere = new ContratVie
            {
                NomClient = "Client à définir",
                MontantPrime = 500m,
                TypeContrat = "Vie entière",
                CapitalGaranti = 300000m,
                OptionDecesAccidentel = true,
                OptionInvalidite = true,
                OptionMaladiesGraves = true
            };
            _prototypes.Add("VieEntiere", vieEntiere);
        }

       
        public Contrat CreerContrat(string typePrototype)
        {
            if (!_prototypes.ContainsKey(typePrototype))
            {
                throw new ArgumentException($"Le prototype '{typePrototype}' n'existe pas.");
            }

            return _prototypes[typePrototype].Clone();
        }

                public void AjouterPrototype(string nom, Contrat prototype)
        {
            _prototypes[nom] = prototype;
        }

        
        public void ListerPrototypes()
        {
            Console.WriteLine("=== Prototypes disponibles ===");
            foreach (var kvp in _prototypes)
            {
                Console.WriteLine($"- {kvp.Key}: {kvp.Value.GetType().Name}");
            }
            Console.WriteLine();
        }
    }
