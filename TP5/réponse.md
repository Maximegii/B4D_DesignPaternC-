# Système de Traitement de Messages

---

Une entreprise développe un système de messagerie qui doit traiter des messages avant leur envoi. Les traitements possibles incluent :

- **Compression** : Compresse le contenu du message pour réduire sa taille
- **Chiffrement** : Chiffre le contenu pour assurer la confidentialité
- **Signature** : Ajoute une signature numérique pour garantir l'authenticité
- **Logging** : Enregistre le message dans un journal pour audit

Le problème est que ces traitements doivent pouvoir être combinés de manière flexible :
- Un message peut être uniquement compressé
- Un message peut être compressé ET chiffré
- Un message peut être chiffré, signé ET loggé
- Toute autre combinaison doit être possible

L'équipe a commencé à créer des classes pour chaque combinaison mais s'est vite rendu compte que cela mènerait à une explosion combinatoire (avec 4 traitements, il faudrait potentiellement 15 classes différentes !).

De plus, l'ordre des traitements peut être important : on veut généralement compresser avant de chiffrer pour optimiser la taille du message chiffré.

## Questions :

1. Quel pattern de conception permettrait d'ajouter dynamiquement des responsabilités à un objet sans modifier sa classe et sans créer une explosion de sous-classes ?
Le pattern de conception qui permettrait d'ajouter dynamiquement des responsabilités à un objet sans modifier sa classe et sans créer une explosion de sous-classes est le **Pattern Décorateur (Decorator Pattern)**.


2. Modélisez la solution à l'aide d'un diagramme de classes UML qui devra inclure :
   - L'interface ou classe de base des messages
   - Le décorateur abstrait
   - Les décorateurs concrets pour chaque traitement
   - Les relations entre les différentes classes

   ```   
   +---------------------+
   |      IMessage       |
   +---------------------+
   | + Process(): string |
   +---------------------+
             ^
             |
   +---------------------+
   |     Message         |
   +---------------------+
   | - content: string   |
   +---------------------+
   | + Process(): string |
   +---------------------+
             ^
             |
   +---------------------+
   |   MessageDecorator  |
   +---------------------+
   | - wrappedMessage:   |
   |   IMessage          |
   +---------------------+
   | + Process(): string |
   +---------------------+
             ^
   +---------------------+---------------------+---------------------+---------------------+
   |                     |                     |                     |                     |
+-----------------+ +-----------------+ +-----------------+ +-----------------+
| CompressedMessage| | EncryptedMessage | | SignedMessage   | | LoggedMessage   |
+-----------------+ +-----------------+ +-----------------+ +-----------------+
| + Process():    | | + Process():    | | + Process():    | | + Process():    |
+-----------------+ +-----------------+ +-----------------+ +-----------------+
   ```      

3. Proposez une implémentation en C# du diagramme de classes qui devra :
   - Permettre de créer un message simple
   - Permettre d'ajouter dynamiquement des traitements
   - Permettre de combiner plusieurs traitements dans n'importe quel ordre
   - Démontrer différentes combinaisons dans une méthode Main()
```csharpcsharp
using System;
// Interface de base pour les messages
public interface IMessage
{
    string Process();
}
// Classe de base pour les messages simples
public class Message : IMessage
{
    public string Content { get; set; }
    public string Process()
    {
        return Content;
    }
}
// Décorateur abstrait
public abstract class MessageDecorator : IMessage
{
    protected IMessage wrappedMessage;
    public MessageDecorator(IMessage message)
    {
        wrappedMessage = message;
    }
    public abstract string Process();
}
// Décorateur concret pour la compression
public class CompressedMessage : MessageDecorator
{
    public CompressedMessage(IMessage message) : base(message) { }
    public override string Process()
    {
        return $"[COMPRESSED: {wrappedMessage.Process()}]";
    }
}
// Décorateur concret pour le chiffrement
public class EncryptedMessage : MessageDecorator
{
    public EncryptedMessage(IMessage message) : base(message) { }
    public override string Process()
    {
        return $"[ENCRYPTED: {wrappedMessage.Process()}]";
    }
}
// Décorateur concret pour la signature
public class SignedMessage : MessageDecorator
{
    public SignedMessage(IMessage message) : base(message) { }
    public override string Process()
    {
        return $"[SIGNED: {wrappedMessage.Process()}]";
    } 
}
// Décorateur concret pour le logging
public class LoggedMessage : MessageDecorator
{
    public LoggedMessage(IMessage message) : base(message) { }
    public override string Process()
    {
        return $"[LOGGED: {wrappedMessage.Process()}]";
    }
}
class Program
{
    static void Main(string[] args)
    {
        IMessage msg = new Message { Content = "Hello World" };
        Console.WriteLine(msg.Process());

        // Ajouter dynamiquement des traitements
        msg = new CompressedMessage(msg);
        Console.WriteLine(msg.Process());

        msg = new EncryptedMessage(msg);
        Console.WriteLine(msg.Process());

        msg = new SignedMessage(msg);
        Console.WriteLine(msg.Process());

        msg = new LoggedMessage(msg);
        Console.WriteLine(msg.Process());

        // Combinaison différente
        IMessage anotherMsg = new Message { Content = "Secret Data" };
        anotherMsg = new EncryptedMessage(anotherMsg);
        anotherMsg = new CompressedMessage(anotherMsg);
        Console.WriteLine(anotherMsg.Process());
    }
}
```

4. Comment votre solution permettrait-elle d'ajouter facilement un nouveau type de traitement (par exemple "Watermarking") tout en respectant le principe Open/Closed ?
