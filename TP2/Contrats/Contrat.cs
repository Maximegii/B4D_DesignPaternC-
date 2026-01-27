    public abstract class Contrat : ICloneable
    {
        public string NumeroContrat { get; set; }
        public string NomClient { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public decimal MontantPrime { get; set; }
        public string ClausesStandard { get; set; }
        public string Annexes { get; set; }

        protected Contrat()
        {
            NumeroContrat = Guid.NewGuid().ToString();
            DateDebut = DateTime.Now;
            DateFin = DateTime.Now.AddYears(1);
        }

        
        public abstract Contrat Clone();

        
        object ICloneable.Clone()
        {
            return this.Clone();
        }

        
        public virtual void AfficherDetails()
        {
            Console.WriteLine($"=== {this.GetType().Name} ===");
            Console.WriteLine($"Numéro: {NumeroContrat}");
            Console.WriteLine($"Client: {NomClient}");
            Console.WriteLine($"Période: {DateDebut.ToShortDateString()} - {DateFin.ToShortDateString()}");
            Console.WriteLine($"Prime: {MontantPrime:C}");
            Console.WriteLine($"Clauses: {ClausesStandard}");
            if (!string.IsNullOrEmpty(Annexes))
            {
                Console.WriteLine($"Annexes: {Annexes}");
            }
            Console.WriteLine();
        }
    }

