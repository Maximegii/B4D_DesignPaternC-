// Interface existante utilisée par le système
public interface IPaymentService
{
    bool ProcessPayment(decimal amount, string currency);
    bool RefundPayment(string transactionId, decimal amount);
    string GetTransactionStatus(string transactionId);
}

// Service de paiement actuel (fonctionne correctement)
public class InternalPaymentService : IPaymentService
{
    public bool ProcessPayment(decimal amount, string currency)
    {
        Console.WriteLine($"Paiement interne: {amount} {currency}");
        return true;
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        Console.WriteLine($"Remboursement interne: {transactionId} - {amount}");
        return true;
    }

    public string GetTransactionStatus(string transactionId)
    {
        return "Completed";
    }
}

// Nouveau service externe à intégrer (NE PAS MODIFIER)
public class PaymentPro
{
    public string ExecuterTransaction(double montant, int codeDevise)
    {
        Console.WriteLine($"PaymentPro: T)ransaction de {montant} avec devise code {codeDevise}");
        return Guid.NewGuid().ToString();
    }

    public bool AnnulerTransaction(string reference)
    {
        Console.WriteLine($"PaymentPro: Annulation de {reference}");
        return true;
    }

    public int ObtenirEtat(string reference)
    {
        // 0=En cours, 1=Validé, 2=Échoué
        return 1;
    }
}

// Code client existant (NE PAS MODIFIER)
class Program
{
    static void ProcessOrder(IPaymentService paymentService, decimal total)
    {
        bool success = paymentService.ProcessPayment(total, "EUR");
        if (success)
        {
            Console.WriteLine("Commande traitée avec succès");
        }
    }

    static void Main(string[] args)
    {
        IPaymentService service = new InternalPaymentService();
        ProcessOrder(service, 99.99m);

        // TODO: Comment utiliser PaymentPro ici sans modifier ProcessOrder ?
        // PaymentPro paymentPro = new PaymentPro();
        // ProcessOrder(paymentPro, 149.99m); // Erreur de compilation !
    }
}
