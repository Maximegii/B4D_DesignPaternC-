public class DemandeImmatriculation : Document
{
    public override void imprime()
    {
        Console.WriteLine("Impression de la Demande d'Immatriculation:");
        Console.WriteLine(contenu);
    }

    public override void affiche()
    {
        Console.WriteLine("Affichage de la Demande d'Immatriculation:");
        Console.WriteLine(contenu);
    }
}