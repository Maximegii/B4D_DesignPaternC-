public class LiasseVierge : Liasse
{
    private static LiasseVierge instance = null;
    private LiasseVierge()
    {
        documents = new List<Document>();
    }
    public static LiasseVierge Instance()
    {
        if (instance == null)
        {
            instance = new LiasseVierge();
        }
        return instance;
    }
}