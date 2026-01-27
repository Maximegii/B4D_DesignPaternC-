using System;
using TP2.Contrats;

namespace TP2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== Système de Génération de Contrats d'Assurance ===");
            Console.WriteLine("=== Pattern Prototype ===\n");

            // Créer le gestionnaire de contrats avec les prototypes
            GestionnaireContrats gestionnaire = new GestionnaireContrats();

            // Lister les prototypes disponibles
            gestionnaire.ListerPrototypes();

            // ===========================================
            // Exemple 1 : Créer plusieurs contrats habitation avec variations
            // ===========================================
            Console.WriteLine("=== Exemple 1 : Contrats Habitation ===\n");

            // Créer un contrat habitation pour Jean Dupont
            ContratHabitation contratJean = (ContratHabitation)gestionnaire.CreerContrat("HabitationStandard");
            contratJean.NomClient = "Jean Dupont";
            contratJean.AdresseLogement = "12 Rue de la Paix, Paris";
            contratJean.SurfaceM2 = 75;

            contratJean.AfficherDetails();

            // Créer un contrat similaire pour son voisin (clone et personnalise)
            ContratHabitation contratMarie = (ContratHabitation)contratJean.Clone();
            contratMarie.NomClient = "Marie Martin";
            contratMarie.AdresseLogement = "14 Rue de la Paix, Paris";
            contratMarie.SurfaceM2 = 70;
            contratMarie.Franchise = 100m; // Option différente

            contratMarie.AfficherDetails();

            // ===========================================
            // Exemple 2 : Créer plusieurs contrats automobile
            // ===========================================
            Console.WriteLine("=== Exemple 2 : Contrats Automobile ===\n");

            // Contrat tous risques pour Pierre
            ContratAutomobile contratPierre = (ContratAutomobile)gestionnaire.CreerContrat("AutomobileTousRisques");
            contratPierre.NomClient = "Pierre Durand";
            contratPierre.Immatriculation = "AB-123-CD";
            contratPierre.Marque = "Renault";
            contratPierre.Modele = "Clio";
            contratPierre.Annee = 2023;

            contratPierre.AfficherDetails();

            // Version avec franchise réduite pour la même personne (autre véhicule)
            ContratAutomobile contratPierre2 = (ContratAutomobile)contratPierre.Clone();
            contratPierre2.Immatriculation = "EF-456-GH";
            contratPierre2.Marque = "Peugeot";
            contratPierre2.Modele = "208";
            contratPierre2.Annee = 2022;
            contratPierre2.Franchise = 100m;

            contratPierre2.AfficherDetails();

            // ===========================================
            // Exemple 3 : Créer des contrats vie
            // ===========================================
            Console.WriteLine("=== Exemple 3 : Contrats Vie ===\n");

            // Contrat vie temporaire
            ContratVie contratSophie = (ContratVie)gestionnaire.CreerContrat("VieTemporaire");
            contratSophie.NomClient = "Sophie Legrand";
            contratSophie.AgeAssure = 35;
            contratSophie.Beneficiaire = "Paul Legrand (conjoint)";
            contratSophie.CapitalGaranti = 250000m;

            contratSophie.AfficherDetails();

            // Version avec options supplémentaires
            ContratVie contratSophie2 = (ContratVie)contratSophie.Clone();
            contratSophie2.OptionInvalidite = true;
            contratSophie2.OptionMaladiesGraves = true;
            contratSophie2.MontantPrime = 450m; // Prime ajustée avec options

            contratSophie2.AfficherDetails();

            // ===========================================
            // Exemple 4 : Ajouter un nouveau prototype personnalisé
            // ===========================================
            Console.WriteLine("=== Exemple 4 : Ajout d'un nouveau prototype ===\n");

            ContratHabitation habitationEtudiant = new ContratHabitation
            {
                NomClient = "Client à définir",
                MontantPrime = 180m,
                TypeLogement = "Studio",
                SurfaceM2 = 25,
                Franchise = 200m,
                OptionDegatsDesEaux = true,
                OptionVolCambriolage = false
            };

            gestionnaire.AjouterPrototype("HabitationEtudiant", habitationEtudiant);

            // Créer un contrat à partir du nouveau prototype
            ContratHabitation contratLuc = (ContratHabitation)gestionnaire.CreerContrat("HabitationEtudiant");
            contratLuc.NomClient = "Luc Bernard";
            contratLuc.AdresseLogement = "5 Rue des Étudiants, Lyon";

            contratLuc.AfficherDetails();

            Console.WriteLine("\n=== Démonstration terminée ===");
            Console.WriteLine("Le pattern Prototype a permis de :");
            Console.WriteLine("- Créer rapidement de nouveaux contrats à partir de modèles");
            Console.WriteLine("- Personnaliser facilement chaque contrat");
            Console.WriteLine("- Gérer plusieurs variations d'un même type de contrat");
            Console.WriteLine("- Ajouter dynamiquement de nouveaux prototypes");
        }
    }
}
