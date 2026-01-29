Exercice 4 : Résolution de Problème (4 points)
Le code suivant présente un problème de conception. Analysez-le et proposez une solution.

```csharp

public class NotificationService
{
    public void SendNotification(string message, string type, string recipient)
    {
        if (type == "email")
        {
            Console.WriteLine($"Connexion au serveur SMTP...");
            Console.WriteLine($"Envoi email à {recipient}: {message}");
            Console.WriteLine($"Déconnexion SMTP");
        }
        else if (type == "sms")
        {
            Console.WriteLine($"Connexion API SMS...");
            Console.WriteLine($"Envoi SMS à {recipient}: {message}");
            Console.WriteLine($"Déconnexion API");
        }
        else if (type == "push")
        {
            Console.WriteLine($"Connexion Firebase...");
            Console.WriteLine($"Envoi push à {recipient}: {message}");
            Console.WriteLine($"Déconnexion Firebase");
        }
        else if (type == "slack")
        {
            Console.WriteLine($"Connexion Slack API...");
            Console.WriteLine($"Envoi Slack à {recipient}: {message}");
            Console.WriteLine($"Déconnexion Slack");
        }
        // ... et si on doit ajouter WhatsApp, Telegram, Discord ?
    }
}

// Utilisation
class Program
{
    static void Main()
    {
        var service = new NotificationService();
        service.SendNotification("Votre commande est prête", "email", "client@example.com");
        service.SendNotification("Code: 1234", "sms", "+33612345678");
    }
}
```
Questions
4.1 Identifiez les violations des principes SOLID dans ce code. (1 point)

**Réponse :**
Le code viole plusieurs principes SOLID, notamment :
- Le principe SRP : La classe NotificationService gère plusieurs types de notifications.
- Le principe OCP : Pour ajouter un nouveau type de notification il faut modifier la méthode SendNotification. Ce qui ne respecte pas ce principe.

4.2 Quel pattern de conception permettrait de résoudre ces problèmes ? Justifiez. (1 point)

**Réponse :**
Le pattern Strategy permettrait de résoudre ces problèmes. En utilisant ce pattern, chaque type de notification peut être encapsulé dans une classe distincte qui utilise une interface commune. 
Cela permet d'ajouter de nouveaux types de notifications sans modifier la classe NotificationService.

4.3 Proposez une implémentation corrigée avec le pattern identifié. Incluez au moins 2 types de notifications. (2 points)
**Réponse :**
```csharp
public interface INotification
{
    void Send(string message, string recipient);
}
public class EmailNotification : INotification
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Connexion au serveur SMTP...");
        Console.WriteLine($"Envoi email à {recipient}: {message}");
        Console.WriteLine($"Déconnexion SMTP");
    }
}
public class SmsNotification : INotification
{
    public void Send(string message, string recipient)
    {
        Console.WriteLine($"Connexion API SMS...");
        Console.WriteLine($"Envoi SMS à {recipient}: {message}");
        Console.WriteLine($"Déconnexion API");
    }
}
public class NotificationService
{
    private readonly INotification _notification;

    public NotificationService(INotification notification)
    {
        _notification = notification;
    }

    public void SendNotification(string message, string recipient)
    {
        _notification.Send(message, recipient);
    }
}
// Utilisation
class Program
{
    static void Main()
    {
        var emailService = new NotificationService(new EmailNotification());
        emailService.SendNotification("Votre commande est prête", "client@example.com");
        var smsService = new NotificationService(new SmsNotification());
        smsService.SendNotification("Code: 1234", "+33612345678");
    }
}
```
