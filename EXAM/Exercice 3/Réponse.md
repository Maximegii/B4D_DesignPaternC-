Exercice 3 : Correction de Pattern (4 points)
Le code suivant tente d'implémenter le pattern Decorator pour un système de calcul de prix de café, mais contient plusieurs erreurs conceptuelles et techniques.

```csharp

public class Coffee
{
    public virtual string GetDescription() => "Café simple";
    public virtual double GetCost() => 2.0;
}

public class MilkDecorator : Coffee
{
    public override string GetDescription() => "Café simple, Lait";
    public override double GetCost() => 2.5;
}

public class SugarDecorator : Coffee
{
    public override string GetDescription() => "Café simple, Sucre";
    public override double GetCost() => 2.2;
}

public class CaramelDecorator : Coffee
{
    public override string GetDescription() => "Café simple, Caramel";
    public override double GetCost() => 2.8;
}

// Utilisation
class Program
{
    static void Main()
    {
        var coffee = new CaramelDecorator();
        Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}€");
        // Affiche: "Café simple, Caramel : 2.8€"
        // Attendu: possibilité de combiner plusieurs décorations
    }
}
```

Questions
3.1 Identifiez au moins 3 erreurs ou problèmes dans cette implémentation. (1.5 points)

**Réponses:**
- Le pattern Decorator n'est pas correctement implémenté , chaque décorateur hérite directement de la classe Coffee au lieu de contenir une instance de Coffee.
- Les décorateurs ne permettent pas de combiner plusieurs ajouts (lait, sucre, caramel) car ils remplacent la description.
- une mauvaise gestion de l'addition des couts (ils remplacent le cout au lieu de l'additionner aussi).


3.2 Réécrivez le code en respectant correctement le pattern Decorator. Votre solution doit permettre de créer un café avec lait, sucre ET caramel. (2.5 points)

**Réponses:** 
```cssharp
public abstract class Coffee
{
    public abstract string GetDescription();
    public abstract double GetCost();
}   
public class SimpleCoffee : Coffee
{
    public override string GetDescription() => "Café simple";
    public override double GetCost() => 2.0;
}
public abstract class CoffeeDecorator : Coffee
{
    protected Coffee _coffee;

    public CoffeeDecorator(Coffee coffee)
    {
        _coffee = coffee;
    }
}
public class MilkDecorator : CoffeeDecorator
{
    public MilkDecorator(Coffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Lait";
    public override double GetCost() => _coffee.GetCost() + 0.5;
}
public class SugarDecorator : CoffeeDecorator
{
    public SugarDecorator(Coffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Sucre";
    public override double GetCost() => _coffee.GetCost() + 0.2;
}
public class CaramelDecorator : CoffeeDecorator
{
    public CaramelDecorator(Coffee coffee) : base(coffee) { }

    public override string GetDescription() => _coffee.GetDescription() + ", Caramel";
    public override double GetCost() => _coffee.GetCost() + 0.8;
}
// Utilisation
class Program
{
    static void Main()
    {
        Coffee coffee = new SimpleCoffee();
        coffee = new MilkDecorator(coffee);
        coffee = new SugarDecorator(coffee);
        coffee = new CaramelDecorator(coffee);

        Console.WriteLine($"{coffee.GetDescription()} : {coffee.GetCost()}€");
        // Affiche: "Café simple, Lait, Sucre, Caramel : 3.5€"
    }
}
```

