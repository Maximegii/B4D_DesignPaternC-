// Approche problématique avec explosion de classes
public class Message
{
    public string Content { get; set; }

    public string Process()
    {
        return Content;
    }
}

public class CompressedMessage
{
    public string Content { get; set; }

    public string Process()
    {
        return $"[COMPRESSED: {Content}]";
    }
}

public class EncryptedMessage
{
    public string Content { get; set; }

    public string Process()
    {
        return $"[ENCRYPTED: {Content}]";
    }
}

public class CompressedAndEncryptedMessage
{
    public string Content { get; set; }

    public string Process()
    {
        return $"[ENCRYPTED: [COMPRESSED: {Content}]]";
    }
}

public class SignedMessage
{
    public string Content { get; set; }

    public string Process()
    {
        return $"[SIGNED: {Content}]";
    }
}

public class CompressedAndSignedMessage
{
    public string Content { get; set; }

    public string Process()
    {
        return $"[SIGNED: [COMPRESSED: {Content}]]";
    }
}

// Et ainsi de suite... Il faudrait créer :
// - EncryptedAndSignedMessage
// - CompressedEncryptedAndSignedMessage
// - LoggedMessage
// - CompressedAndLoggedMessage
// - EncryptedAndLoggedMessage
// - ... (15 combinaisons au total pour 4 traitements!)

class Program
{
    static void Main(string[] args)
    {
        // Utilisation rigide et peu flexible
        var msg1 = new Message { Content = "Hello World" };
        Console.WriteLine(msg1.Process());

        var msg2 = new CompressedAndEncryptedMessage { Content = "Secret data" };
        Console.WriteLine(msg2.Process());

        // Comment ajouter un traitement à runtime ?
        // Comment changer l'ordre des traitements facilement ?
    }
}

