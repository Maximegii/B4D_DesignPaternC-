using TP1.Clients;

namespace TP1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SYSTÈME DE PRODUCTION DE DOCUMENTS BANCAIRES ===\n");

            // Création des clients
            ClientParticulier clientParticulier = new ClientParticulier(
                "Dupont", 
                "Jean", 
                "FR76 1234 5678 9012 3456 7890 123"
            );

            ClientProfessionnel clientProfessionnel = new ClientProfessionnel(
                "TechCorp SARL",
                "123 456 789 00012",
                "FR76 9876 5432 1098 7654 3210 987"
            );

            // Génération des documents pour chaque client
            Console.WriteLine(clientParticulier.ToString());
            clientParticulier.DemanderDocuments();

            Console.WriteLine("\n" + clientProfessionnel.ToString());
            clientProfessionnel.DemanderDocuments();

            Console.WriteLine("\n=== FIN ===");
            Console.ReadKey();
        }
    }
}
