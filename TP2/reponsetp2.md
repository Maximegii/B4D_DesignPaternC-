# TP2 - Système de Génération de Contrats d'Assurance
## Réponses aux questions

---

## Question 1 : Quel pattern de conception permettrait de créer efficacement de nouveaux contrats en évitant de recréer entièrement chaque contrat à partir de zéro ?

### Réponse :

Le **pattern Prototype** est le design pattern le plus approprié pour ce problème.

### Justification :

Le pattern Prototype permet de créer de nouveaux objets en **clonant des instances existantes** plutôt qu'en les construisant à partir de zéro. Ce pattern est particulièrement adapté dans notre contexte pour les raisons suivantes :

1. **Performance** : La création d'un contrat d'assurance nécessite de charger toutes les clauses standard et de formater le document, ce qui est coûteux. Le clonage est beaucoup plus rapide.

2. **Réutilisation** : Les contrats partagent beaucoup de clauses standard et de structure commune. Plutôt que de recréer cette structure à chaque fois, on clone un modèle existant.

3. **Variations mineures** : Les clients souhaitent avoir plusieurs versions d'un même contrat avec des variations mineures (différentes franchises, différentes options). Le pattern Prototype permet de créer facilement ces variations en clonant et en modifiant légèrement.

4. **Flexibilité** : On peut maintenir un registre de contrats "prototypes" pour chaque type de base (habitation, automobile, vie) et créer de nouveaux contrats en les clonant et en les personnalisant.

### Alternatives considérées (et pourquoi elles sont moins adaptées) :

- **Factory Method** : Aurait nécessité de recréer chaque contrat à partir de zéro à chaque appel, ce qui est coûteux.
- **Builder** : Plus adapté pour construire des objets complexes étape par étape, mais ne résout pas le problème de performance de chargement des clauses standard.
- **Singleton** : Ne permet pas d'avoir plusieurs instances différentes.

---

## Question 2 : Modélisez la solution à l'aide d'un diagramme de classes UML

### Diagramme de classes UML :

```
┌─────────────────────────────────────┐
│       <<interface>>                 │
│        ICloneable                   │
├─────────────────────────────────────┤
│ + Clone() : object                  │
└─────────────────────────────────────┘
                  △
                  │ implements
                  │
┌─────────────────────────────────────┐
│       <<abstract>>                  │
│         Contrat                     │
├─────────────────────────────────────┤
│ - NumeroContrat : string            │
│ - NomClient : string                │
│ - DateDebut : DateTime              │
│ - DateFin : DateTime                │
│ - MontantPrime : decimal            │
│ - ClausesStandard : string          │
│ - Annexes : string                  │
├─────────────────────────────────────┤
│ + Clone() : Contrat                 │
│ + AfficherDetails() : void          │
└─────────────────────────────────────┘
                  △
                  │ hérite
         ┌────────┼────────┐
         │        │        │
         │        │        │
┌────────┴──────┐ │ ┌──────┴──────────┐
│ ContratHabit. │ │ │ ContratVie      │
├───────────────┤ │ ├─────────────────┤
│ + AdresseLoge.│ │ │ + CapitalGarant.│
│ + SurfaceM2   │ │ │ + Beneficiaire  │
│ + TypeLogement│ │ │ + AgeAssure     │
│ + Franchise   │ │ │ + TypeContrat   │
│ + Options...  │ │ │ + Options...    │
├───────────────┤ │ ├─────────────────┤
│ + Clone()     │ │ │ + Clone()       │
└───────────────┘ │ └─────────────────┘
                  │
         ┌────────┴────────┐
         │ ContratAuto.    │
         ├─────────────────┤
         │ + Immatricul.   │
         │ + Marque        │
         │ + Modele        │
         │ + Annee         │
         │ + NiveauCouvert.│
         │ + Franchise     │
         │ + Options...    │
         ├─────────────────┤
         │ + Clone()       │
         └─────────────────┘

┌─────────────────────────────────────┐
│   GestionnaireContrats              │
├─────────────────────────────────────┤
│ - _prototypes : Dictionary<str,     │
│                 Contrat>            │
├─────────────────────────────────────┤
│ + CreerContrat(type) : Contrat      │
│ + AjouterPrototype(nom, proto)      │
│ + ListerPrototypes() : void         │
│ - InitialiserPrototypes() : void    │
└─────────────────────────────────────┘
         │
         │ gère
         ▼
    [Prototypes]
```

### Explication du diagramme :

1. **Contrat (classe abstraite)** : Classe de base contenant les propriétés communes à tous les contrats et la méthode abstraite `Clone()`.

2. **Classes concrètes** (ContratHabitation, ContratAutomobile, ContratVie) : Implémentent la méthode `Clone()` en utilisant `MemberwiseClone()` pour créer une copie superficielle.

3. **GestionnaireContrats** : Maintient un registre de prototypes et fournit des méthodes pour créer de nouveaux contrats par clonage.

4. **ICloneable** : Interface standard .NET implémentée pour respecter les conventions.

---

## Question 3 : Proposez une implémentation en C# du diagramme de classes

### Architecture de l'implémentation :

L'implémentation est organisée en plusieurs fichiers dans le dossier `Contrats/` :

1. **Contrat.cs** : Classe abstraite de base
   - Propriétés communes (NumeroContrat, NomClient, DateDebut, DateFin, MontantPrime, etc.)
   - Méthode abstraite `Clone()` pour le pattern Prototype
   - Implémentation de l'interface `ICloneable`
   - Méthode `AfficherDetails()` pour afficher les informations du contrat

2. **ContratHabitation.cs** : Contrat d'assurance habitation
   - Propriétés spécifiques : AdresseLogement, SurfaceM2, TypeLogement, Franchise, Options
   - Implémentation de `Clone()` avec `MemberwiseClone()`
   - Génération d'un nouveau numéro de contrat pour chaque clone

3. **ContratAutomobile.cs** : Contrat d'assurance automobile
   - Propriétés spécifiques : Immatriculation, Marque, Modele, NiveauCouverture, Options
   - Implémentation de `Clone()` avec `MemberwiseClone()`

4. **ContratVie.cs** : Contrat d'assurance vie
   - Propriétés spécifiques : CapitalGaranti, Beneficiaire, AgeAssure, TypeContrat, Options
   - Implémentation de `Clone()` avec `MemberwiseClone()`

5. **GestionnaireContrats.cs** : Gestionnaire de prototypes
   - Dictionnaire de prototypes (`Dictionary<string, Contrat>`)
   - Méthode `CreerContrat(type)` pour créer un contrat par clonage
   - Méthode `AjouterPrototype()` pour ajouter de nouveaux prototypes
   - Initialisation de prototypes prédéfinis (Standard, Premium, etc.)

6. **Program.cs** : Démonstration
   - Exemples d'utilisation du pattern Prototype
   - Création de contrats à partir de prototypes
   - Personnalisation des contrats clonés
   - Ajout dynamique de nouveaux prototypes

### Points clés de l'implémentation :

```csharp
// Méthode de clonage dans les classes concrètes
public override Contrat Clone()
{
    ContratHabitation clone = (ContratHabitation)this.MemberwiseClone();
    // Génère un nouveau numéro de contrat unique
    clone.NumeroContrat = Guid.NewGuid().ToString();
    return clone;
}
```

**Avantages de cette approche** :
- `MemberwiseClone()` crée une copie superficielle rapide
- Chaque clone reçoit un nouveau numéro de contrat unique
- Les propriétés simples (string, decimal, int, bool) sont copiées par valeur
- Les clauses standard sont partagées (chaînes de caractères immuables)

---

## Question 4 : Comment votre solution permettrait-elle de gérer efficacement :

### A) La création de multiples versions d'un même contrat

**Solution implémentée** :

Le pattern Prototype permet de créer facilement plusieurs versions d'un contrat en utilisant le clonage successif :

```csharp
// Créer un contrat de base
ContratHabitation contratBase = gestionnaire.CreerContrat("HabitationStandard");
contratBase.NomClient = "Jean Dupont";
contratBase.AdresseLogement = "12 Rue de la Paix";
contratBase.Franchise = 150m;

// Version 1 avec franchise standard
ContratHabitation version1 = contratBase;

// Version 2 avec franchise réduite (clone et modifie)
ContratHabitation version2 = (ContratHabitation)contratBase.Clone();
version2.Franchise = 100m;

// Version 3 avec options supplémentaires (clone et modifie)
ContratHabitation version3 = (ContratHabitation)contratBase.Clone();
version3.Franchise = 50m;
version3.OptionVolCambriolage = true;
```

**Avantages** :
- ✅ Création rapide de variations sans recharger les clauses standard
- ✅ Modification uniquement des propriétés qui diffèrent
- ✅ Chaque version a un numéro de contrat unique
- ✅ Possibilité de comparer facilement les différentes versions

**Cas d'usage réel** : Un client veut comparer 3 offres avec différentes franchises et options pour choisir la meilleure.

---

### B) L'ajout d'un nouveau type de contrat

**Solution implémentée** :

Pour ajouter un nouveau type de contrat, il suffit de :

1. **Créer une nouvelle classe** héritant de `Contrat` :

```csharp
// Nouveau type : Assurance Professionnelle
public class ContratProfessionnel : Contrat
{
    public string RaisonSociale { get; set; }
    public string SIRET { get; set; }
    public string SecteurActivite { get; set; }
    public decimal PlafondGarantie { get; set; }
    
    public override Contrat Clone()
    {
        ContratProfessionnel clone = (ContratProfessionnel)this.MemberwiseClone();
        clone.NumeroContrat = Guid.NewGuid().ToString();
        return clone;
    }
}
```

2. **Ajouter un prototype** dans le gestionnaire :

```csharp
var protoProfessionnel = new ContratProfessionnel
{
    ClausesStandard = "RC Professionnelle, Protection juridique...",
    MontantPrime = 1200m,
    PlafondGarantie = 1000000m
};
gestionnaire.AjouterPrototype("ProfessionnelStandard", protoProfessionnel);
```

**Avantages** :
- ✅ **Principe Ouvert/Fermé** : On étend le système sans modifier le code existant
- ✅ Pas de modification du `GestionnaireContrats`
- ✅ Pas d'impact sur les autres types de contrats
- ✅ Le nouveau type bénéficie immédiatement du mécanisme de clonage

**Impact minimal** : Seulement 1 nouvelle classe à créer et 1 ligne pour ajouter le prototype.

---

### C) La modification des clauses standard

**Solution implémentée** :

La modification des clauses standard peut se faire à trois niveaux :

#### 1. **Au niveau du prototype** (modifie tous les futurs contrats de ce type) :

```csharp
// Mettre à jour un prototype existant
var nouveauPrototype = new ContratHabitation
{
    ClausesStandard = "NOUVELLES CLAUSES : Couverture étendue aux catastrophes naturelles...",
    MontantPrime = 400m,
    // ... autres propriétés
};
gestionnaire.AjouterPrototype("HabitationStandard", nouveauPrototype);
```

#### 2. **Au niveau de la classe de base** (modifie tous les types) :

```csharp
// Dans le constructeur de ContratHabitation
public ContratHabitation()
{
    ClausesStandard = "Clauses mises à jour au 01/2026 : " +
                     "Couverture des dommages au bâtiment et aux biens. " +
                     "Responsabilité civile incluse. " +
                     "Nouvelle clause : Protection juridique étendue.";
    Franchise = 150m;
}
```

#### 3. **Au niveau d'une instance spécifique** (modifie un seul contrat) :

```csharp
ContratHabitation contrat = gestionnaire.CreerContrat("HabitationStandard");
contrat.ClausesStandard += "\nClause particulière : Garantie vol étendue.";
contrat.Annexes = "Annexe spéciale négociée avec le client.";
```

**Avantages de cette approche** :

- ✅ **Flexibilité multi-niveaux** : Modifications globales, par type, ou individuelles
- ✅ **Traçabilité** : Chaque modification peut être datée et documentée
- ✅ **Rétrocompatibilité** : Les contrats existants conservent leurs clauses
- ✅ **Versioning** : Possibilité de maintenir plusieurs versions de prototypes
  ```csharp
  gestionnaire.AjouterPrototype("HabitationStandard_2025", ancienPrototype);
  gestionnaire.AjouterPrototype("HabitationStandard_2026", nouveauPrototype);
  ```

**Cas d'usage réel** :
- Nouvelle réglementation → Modification au niveau de la classe
- Changement de tarif → Modification du prototype
- Négociation client → Modification d'une instance

---

## Conclusion

Le pattern Prototype offre une solution élégante et performante pour le système de génération de contrats d'assurance :

### Points forts de la solution :

1. **Performance** ⚡
   - Clonage rapide vs création complète
   - Pas de rechargement des clauses standard

2. **Flexibilité** 🔧
   - Création facile de variations
   - Personnalisation individuelle simple

3. **Maintenabilité** 🛠️
   - Code organisé et extensible
   - Ajout de nouveaux types sans modification du code existant

4. **Réutilisabilité** ♻️
   - Bibliothèque de prototypes réutilisables
   - Gestion centralisée des modèles

### Bénéfices métier :

- ✅ Gain de temps pour les agents d'assurance
- ✅ Cohérence des clauses standard
- ✅ Facilité de comparaison des offres pour les clients
- ✅ Évolutivité pour de nouveaux produits d'assurance

### Limitations et améliorations possibles :

**Limitation actuelle** : `MemberwiseClone()` fait un clonage superficiel. Si les contrats contenaient des objets complexes (listes, objets imbriqués), il faudrait implémenter un clonage profond.

**Amélioration possible** :
```csharp
public override Contrat Clone()
{
    ContratHabitation clone = (ContratHabitation)this.MemberwiseClone();
    // Clonage profond si nécessaire
    if (this.ListeOptions != null)
    {
        clone.ListeOptions = new List<Option>(this.ListeOptions);
    }
    clone.NumeroContrat = Guid.NewGuid().ToString();
    return clone;
}
```

---

**Fichiers du projet** :
- 📄 `Contrats/Contrat.cs` - Classe abstraite de base
- 📄 `Contrats/ContratHabitation.cs` - Assurance habitation
- 📄 `Contrats/ContratAutomobile.cs` - Assurance automobile
- 📄 `Contrats/ContratVie.cs` - Assurance vie
- 📄 `Contrats/GestionnaireContrats.cs` - Registre de prototypes
- 📄 `Program.cs` - Démonstration et exemples
- 📄 `reponse.md` - Ce document de réponses
