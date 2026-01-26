public abstract class ClientCredit : Client
{
    public override void passeCommande(Commande commande)
    {
        Console.WriteLine("Le client crédit passe une commande.");
        commande.valider();
    }
}