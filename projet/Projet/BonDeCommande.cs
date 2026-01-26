public class BonDeCommande : Document
{
    public override void imprime()
    {
        Console.WriteLine("Impression du Bon de Commande:");
        Console.WriteLine(contenu);
    }

    public override void affiche()
    {
        Console.WriteLine("Affichage du Bon de Commande:");
        Console.WriteLine(contenu);
    }
}