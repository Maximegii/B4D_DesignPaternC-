# Réponse TP4 - Pattern Adapter

## Question 1 : Quel pattern utiliser ?

**Réponse : Le pattern Adapter**

on doit faire communiquer deux interfaces incompatibles sans modifier le code client ni le service externe. L'Adapter est fait pour ça. On crée une classe qui prend PaymentPro en interne et qui expose l'interface IPaymentService au code client. Comme ça, le code client voit que de l'IPaymentService et ne sait pas que derrière c'est du PaymentPro.

---

## Question 2 : Diagramme UML

```
┌──────────────────┐
│ IPaymentService  │
│  (interface)     │
├──────────────────┤
│ + ProcessPayment │
│ + RefundPayment  │
│ +GetTransStatus  │
└────────┬─────────┘
         △
         │ implements
         │
┌────────────────────────┐
│ PaymentProAdapter      │
├────────────────────────┤
│ - paymentPro: PayPro   │
├────────────────────────┤
│ + ProcessPayment()     │
│ + RefundPayment()      │
│ + GetTransactionStatus │
└────────────────────────┘
         │
         │ uses
         ▼
┌──────────────────┐
│  PaymentPro      │
│ (service externe)│
├──────────────────┤
│ + ExecuterTrans()│
│ + AnnulerTrans() │
│ + ObtenirEtat()  │
└──────────────────┘
```

L'Adapter implémente IPaymentService et utilise PaymentPro en interne. Il convertit les appels entre les deux interfaces.

---

## Question 3 : Implémentation en C#

```csharp
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
        Console.WriteLine($"PaymentPro: Transaction de {montant} avec devise code {codeDevise}");
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

// ========== ADAPTER (C'EST ICI QU'ON FAIT LA MAGIE) ==========

public class PaymentProAdapter : IPaymentService
{
    private PaymentPro _paymentPro = new PaymentPro();
    
    // On stocke les références de transactions pour pouvoir les retrouver après
    private Dictionary<string, string> _transactionMap = new Dictionary<string, string>();

    public bool ProcessPayment(decimal amount, string currency)
    {
        // Convertir devise string en code numérique
        int deviseCode = ConvertirDeviseEnCode(currency);
        
        // Appeler PaymentPro
        string referencePaymentPro = _paymentPro.ExecuterTransaction((double)amount, deviseCode);
        
        // Stocker la ref pour plus tard
        _transactionMap[referencePaymentPro] = referencePaymentPro;
        
        Console.WriteLine($"Adapter: Paiement {amount} {currency} traité via PaymentPro");
        return true;
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        // Annuler la transaction
        return _paymentPro.AnnulerTransaction(transactionId);
    }

    public string GetTransactionStatus(string transactionId)
    {
        int codeEtat = _paymentPro.ObtenirEtat(transactionId);
        
        // Convertir code numérique en statut descriptif
        return codeEtat switch
        {
            0 => "Pending",
            1 => "Completed",
            2 => "Failed",
            _ => "Unknown"
        };
    }

    // Méthode helper pour convertir devise
    private int ConvertirDeviseEnCode(string devise)
    {
        return devise.ToUpper() switch
        {
            "EUR" => 1,
            "USD" => 2,
            "GBP" => 3,
            _ => 1 // Par défaut EUR
        };
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
            Console.WriteLine("Commande traitée avec succès\n");
        }
    }

    static void Main(string[] args)
    {
        Console.WriteLine("=== Avec le service interne ===");
        IPaymentService service1 = new InternalPaymentService();
        ProcessOrder(service1, 99.99m);

        Console.WriteLine("=== Avec PaymentPro via Adapter ===");
        IPaymentService service2 = new PaymentProAdapter();
        ProcessOrder(service2, 149.99m);

        Console.WriteLine("=== Test status ===");
        string status = service2.GetTransactionStatus("ref123");
        Console.WriteLine($"Statut: {status}");
    }
}
```

**Résultat attendu :**
```
Avec le service interne 
Paiement interne: 99.99 EUR
Commande traitée avec succès

 Avec PaymentPro via Adapter 
PaymentPro: Transaction de 149.99 avec devise code 1
Adapter: Paiement 149.99 EUR traité via PaymentPro
Commande traitée avec succès

 Test status 
PaymentPro: Etat de ref123
Statut: Completed
```

---

## Question 4 : Intégrer un autre service (QuickPay)

C'est très facile grâce au pattern Adapter. Si on doit ajouter "QuickPay" qui a une interface différente :

1. **On crée QuickPayAdapter** qui implémente aussi **IPaymentService**
2. **Il utilise QuickPay en interne** et convertit les appels
3. **Le code client ne change pas du tout** - il continue à utiliser IPaymentService

Exemple rapide :

```csharp
public class QuickPayAdapter : IPaymentService
{
    private QuickPay _quickPay = new QuickPay();

    public bool ProcessPayment(decimal amount, string currency)
    {
        _quickPay.Pay(amount, currency); // QuickPay a peut-être une interface plus simple
        return true;
    }

    public bool RefundPayment(string transactionId, decimal amount)
    {
        _quickPay.Refund(transactionId);
        return true;
    }

    public string GetTransactionStatus(string transactionId)
    {
        bool isOk = _quickPay.IsValid(transactionId);
        return isOk ? "Completed" : "Failed";
    }
}

// Et dans Main:
IPaymentService service3 = new QuickPayAdapter();
ProcessOrder(service3, 199.99m); // Ça marche pareil!
```

**Avantages du pattern Adapter :**
-  Code client inchangé
-  Service externe inchangé
-  Facile d'ajouter de nouveaux services
-  Chaque Adapter gère sa propre conversion

c'est extensible et ça respecte le Liskov Substitution Principle. 

---

**Conclusion :** L'Adapter c'est juste une classe qui traduit entre deux langages incompatibles. Rien de magique, mais c'est utile pour intégrer des trucs externes sans casser le code existant.
