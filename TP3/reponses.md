# TP3 - Système de Notification Multi-plateforme
## Réponses

---

## Question 1 : Problèmes identifiés dans le code existant

### Duplication de code
- Chaque classe de notification (`NotificationCommande`, `NotificationLivraison`, `NotificationSupport`) contient les mêmes 3 méthodes : `EnvoyerParEmail`, `EnvoyerParSMS`, `EnvoyerParPush`
- Le code d'envoi est répété 9 fois au total (3 types × 3 méthodes)

### Extensibilité
- Pour ajouter une nouvelle plateforme (ex: Discord), il faut modifier les 3 classes existantes
- Pour ajouter un nouveau type de notification (ex: Promotion), il faut créer une nouvelle classe avec les 3 méthodes d'envoi
- **Explosion combinatoire** : avec N types de notifications et M plateformes, on se retrouve avec N×M méthodes au total

### Maintenance
- Si on veut changer la façon d'envoyer un SMS, il faut modifier le code dans 3 endroits différents
- Risque d'oublier de mettre à jour certaines méthodes

### Couplage
- Les types de notifications sont étroitement couplés aux méthodes d'envoi
- Impossible de changer la plateforme d'envoi sans toucher à la classe de notification

---

## Question 2 : Pattern de conception approprié

Le pattern **Bridge** (Pont) est le plus adapté car il permet de :

- **Séparer l'abstraction (types de notifications) de l'implémentation (plateformes d'envoi)**
- Les deux dimensions peuvent évoluer indépendamment
- Éviter l'explosion combinatoire : au lieu de N×M classes, on a seulement N+M classes

**Principe du pattern Bridge** :
- Créer une hiérarchie pour les notifications (abstraction)
- Créer une hiérarchie pour les méthodes d'envoi (implémentation)
- Les relier par composition plutôt que par héritage

---

## Question 3 : Diagramme de classes UML

```
┌─────────────────────┐
│   Notification      │ (Abstraction)
│  (abstract)         │
├─────────────────────┤
│ - envoyeur          │◇────────┐
│ - message           │         │
├─────────────────────┤         │
│ + Envoyer()         │         │
└─────────────────────┘         │
         △                      │
         │                      │
    ┌────┴────┬─────────────┐  │
    │         │             │  │
┌───┴───────┐ │      ┌──────┴──┴──┐
│Notification│ │      │Notification│
│Commande    │ │      │Support     │
└────────────┘ │      └────────────┘
         ┌─────┴──────┐
         │Notification│
         │Livraison   │
         └────────────┘

                               ┌──────────────────┐
                               │   IEnvoyeur      │ (Implementor)
                               │  (interface)     │
                               ├──────────────────┤
                               │ + Envoyer(msg)   │
                               └──────────────────┘
                                        △
                    ┌───────────────────┼───────────────────┐
                    │                   │                   │
            ┌───────┴────────┐  ┌───────┴────────┐  ┌──────┴──────┐
            │ EnvoyeurEmail  │  │ EnvoyeurSMS    │  │ EnvoyeurPush│
            ├────────────────┤  ├────────────────┤  ├─────────────┤
            │+ Envoyer(msg)  │  │+ Envoyer(msg)  │  │+Envoyer(msg)│
            └────────────────┘  └────────────────┘  └─────────────┘
```

---

## Question 4 : Facilitation des évolutions

### Ajout d'un nouveau type de notification (ex: "Promotion")
- Créer une nouvelle classe `NotificationPromotion` qui hérite de `Notification`
- Pas besoin de toucher aux classes d'envoi
- **1 seule classe à créer**

### Ajout d'une nouvelle plateforme (ex: "Discord")
- Créer une nouvelle classe `EnvoyeurDiscord` qui implémente `IEnvoyeur`
- Pas besoin de toucher aux classes de notification
- **1 seule classe à créer**

### Modification du comportement d'envoi
- Modifier uniquement la classe `EnvoyeurEmail` (par exemple)
- Toutes les notifications qui utilisent Email bénéficient automatiquement du changement
- **1 seul endroit à modifier**

---

## Question 5 : Implémentation en C#

Voici le code refactoré avec le pattern Bridge :

```csharp
// IMPLEMENTATION (Envoyeurs)
public interface IEnvoyeur
{
    void Envoyer(string message);
}

public class EnvoyeurEmail : IEnvoyeur
{
    public void Envoyer(string message)
    {
        Console.WriteLine($"📧 Email: {message}");
    }
}

public class EnvoyeurSMS : IEnvoyeur
{
    public void Envoyer(string message)
    {
        Console.WriteLine($"📱 SMS: {message}");
    }
}

public class EnvoyeurPush : IEnvoyeur
{
    public void Envoyer(string message)
    {
        Console.WriteLine($"🔔 Push: {message}");
    }
}

// ABSTRACTION (Notifications)
public abstract class Notification
{
    protected IEnvoyeur envoyeur;
    protected string typeNotification;

    protected Notification(IEnvoyeur envoyeur, string type)
    {
        this.envoyeur = envoyeur;
        this.typeNotification = type;
    }

    public abstract void Envoyer(string message);
}

public class NotificationCommande : Notification
{
    public NotificationCommande(IEnvoyeur envoyeur) 
        : base(envoyeur, "Commande")
    {
    }

    public override void Envoyer(string message)
    {
        string messageFormate = $"[{typeNotification}] {message}";
        envoyeur.Envoyer(messageFormate);
    }
}

public class NotificationLivraison : Notification
{
    public NotificationLivraison(IEnvoyeur envoyeur) 
        : base(envoyeur, "Livraison")
    {
    }

    public override void Envoyer(string message)
    {
        string messageFormate = $"[{typeNotification}] {message}";
        envoyeur.Envoyer(messageFormate);
    }
}

public class NotificationSupport : Notification
{
    public NotificationSupport(IEnvoyeur envoyeur) 
        : base(envoyeur, "Support")
    {
    }

    public override void Envoyer(string message)
    {
        string messageFormate = $"[{typeNotification}] {message}";
        envoyeur.Envoyer(messageFormate);
    }
}

// UTILISATION
class Program
{
    static void Main(string[] args)
    {
        // Créer les envoyeurs
        IEnvoyeur email = new EnvoyeurEmail();
        IEnvoyeur sms = new EnvoyeurSMS();
        IEnvoyeur push = new EnvoyeurPush();

        // Utilisation flexible
        Notification notifCommande = new NotificationCommande(email);
        notifCommande.Envoyer("Votre commande est confirmée");

        Notification notifLivraison = new NotificationLivraison(sms);
        notifLivraison.Envoyer("Votre colis est en route");

        Notification notifSupport = new NotificationSupport(push);
        notifSupport.Envoyer("Un agent va vous contacter");

        // On peut facilement changer la plateforme d'envoi
        Notification notifCommandeSMS = new NotificationCommande(sms);
        notifCommandeSMS.Envoyer("Commande expédiée");
    }
}
```

### Avantages de cette solution :

**Plus de duplication**
**Extensibilité** 
**Maintenance facilitée** 
**Découplage** 
**Flexibilité** 

---

## Conclusion

Le pattern Bridge résout tous les problèmes du code initial en séparant clairement les responsabilités. Au lieu d'avoir du code dupliqué partout, on a une architecture propre et facile à faire évoluer.
