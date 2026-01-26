public abstract class Document
{
    protected string contenu = string.Empty;
    public Document duplique()
    {
        Document resultat;
        resultat = (Document)this.MemberwiseClone();
        return resultat;
    }

    public void remplit(string information)
    {
        contenu = information;
    }

    public abstract void imprime();
    public abstract void affiche();
}