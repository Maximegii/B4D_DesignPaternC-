// Code existant problématique
public class NotificationCommande
{
    public void EnvoyerParEmail(string message)
    {
        Console.WriteLine($"Email - Commande: {message}");
    }

    public void EnvoyerParSMS(string message)
    {
        Console.WriteLine($"SMS - Commande: {message}");
    }

    public void EnvoyerParPush(string message)
    {
        Console.WriteLine($"Push - Commande: {message}");
    }
}

public class NotificationLivraison
{
    public void EnvoyerParEmail(string message)
    {
        Console.WriteLine($"Email - Livraison: {message}");
    }

    public void EnvoyerParSMS(string message)
    {
        Console.WriteLine($"SMS - Livraison: {message}");
    }

    public void EnvoyerParPush(string message)
    {
        Console.WriteLine($"Push - Livraison: {message}");
    }
}

public class NotificationSupport
{
    public void EnvoyerParEmail(string message)
    {
        Console.WriteLine($"Email - Support: {message}");
    }

    public void EnvoyerParSMS(string message)
    {
        Console.WriteLine($"SMS - Support: {message}");
    }

    public void EnvoyerParPush(string message)
    {
        Console.WriteLine($"Push - Support: {message}");
    }
}

// Utilisation
class Program
{
    static void Main(string[] args)
    {
        var notifCommande = new NotificationCommande();
        notifCommande.EnvoyerParEmail("Votre commande est confirmée");
        
        var notifLivraison = new NotificationLivraison();
        notifLivraison.EnvoyerParSMS("Votre colis est en route");
        
        var notifSupport = new NotificationSupport();
        notifSupport.EnvoyerParPush("Un agent va vous contacter");
    }
}
