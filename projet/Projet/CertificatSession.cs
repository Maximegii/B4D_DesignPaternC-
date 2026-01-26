public class CertificatSession : Document
{
    public override void imprime()
    {
        Console.WriteLine("Impression du Certificat de Session:");
        Console.WriteLine(contenu);
    }

    public override void affiche()
    {
        Console.WriteLine("Affichage du Certificat de Session:");
        Console.WriteLine(contenu);
    }
}