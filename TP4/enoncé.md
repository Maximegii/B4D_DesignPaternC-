# Système d'Intégration de Services de Paiement

---

Une plateforme de e-commerce souhaite intégrer un nouveau service de paiement externe (PaymentPro) à son système existant. Le problème est que l'interface de ce service tiers est incompatible avec l'interface de paiement actuellement utilisée dans l'application.

Le système existant utilise une interface `IPaymentService` avec les méthodes suivantes :
- `ProcessPayment(decimal amount, string currency)` : traite un paiement
- `RefundPayment(string transactionId, decimal amount)` : rembourse un paiement
- `GetTransactionStatus(string transactionId)` : récupère le statut d'une transaction

Le nouveau service PaymentPro propose une API complètement différente :
- `ExecuterTransaction(double montant, int codeDevise)` : exécute une transaction (codes devise : 1=EUR, 2=USD, 3=GBP)
- `AnnulerTransaction(string reference)` : annule complètement une transaction
- `ObtenirEtat(string reference)` : retourne un code numérique (0=En cours, 1=Validé, 2=Échoué)

L'équipe de développement ne peut pas modifier le code de PaymentPro car c'est une bibliothèque externe. De plus, le code client existant ne doit pas être modifié car il utilise déjà `IPaymentService` dans de nombreux endroits.

## Questions :

1. Quel pattern de conception permettrait d'intégrer PaymentPro au système existant sans modifier ni le code client ni le service externe ?

2. Modélisez la solution à l'aide d'un diagramme de classes UML qui devra inclure :
   - L'interface cible (`IPaymentService`)
   - La classe adaptée (`PaymentPro`)
   - L'adaptateur
   - Les relations entre les différentes classes

3. Proposez une implémentation en C# du diagramme de classes qui devra :
   - Convertir les appels de méthodes entre les deux interfaces
   - Gérer la conversion des devises (string vers code numérique)
   - Adapter les retours de statut (code numérique vers chaîne descriptive)
   - Démontrer l'utilisation dans une méthode Main()

4. Comment votre solution permettrait-elle d'intégrer facilement un autre service de paiement (par exemple "QuickPay") qui aurait encore une autre interface différente ?
