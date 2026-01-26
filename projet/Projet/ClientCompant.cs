public abstract class ClientComptant : Client
{
    public override void passeCommande(Commande commande)
    {
        Console.WriteLine("Le client comptant passe une commande.");
        commande.valider();
    }
}