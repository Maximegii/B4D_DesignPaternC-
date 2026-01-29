Exercice 5 : Analyse UML (3 points)
Observez le diagramme de classes suivant :

┌─────────────────────────────┐
│      «interface»            │
│        IComponent           │
├─────────────────────────────┤
│ + Operation(): void         │
│ + Add(c: IComponent): void  │
│ + Remove(c: IComponent): void│
│ + GetChild(i: int): IComponent│
└──────────────┬──────────────┘
               │
       ┌───────┴───────┐
       │               │
       ▼               ▼
┌──────────────┐ ┌──────────────────┐
│    Leaf      │ │    Composite     │
├──────────────┤ ├──────────────────┤
│              │ │ -children: List  │
├──────────────┤ ├──────────────────┤
│ +Operation() │ │ +Operation()     │
│ +Add()       │ │ +Add()           │
│ +Remove()    │ │ +Remove()        │
│ +GetChild()  │ │ +GetChild()      │
└──────────────┘ └──────────────────┘
Questions
5.1 Identifiez le pattern représenté. (0.5 point)

**Réponse :**
Le Pattern utilisez dans cet exemple est le pattern Composite.

5.2 Expliquez le rôle de chaque participant (IComponent, Leaf, Composite). (1 point)

**Réponse :**
- IComponent : C'est une interface qui déclare les opérations communes pour les objets Leaf et Composite.
- Leaf :  Elle implémente l'interface IComponent et fournit une implémentation concrète de la méthode Operation().
- Composite : C'est une classe qui représente les objets qui peuvent contenir d'autres composants (Leaf ou Composite).

5.3 Donnez un exemple concret d'utilisation de ce pattern (domaine métier + cas d'usage). (0.5 point)

**Réponse :**
Un exemple concret est l'organisation d'un système de fichiers.

5.4 La classe Leaf implémente Add(), Remove() et GetChild() qui n'ont pas de sens pour elle. Proposez deux approches pour gérer ce problème et expliquez leurs compromis. (1 point)
