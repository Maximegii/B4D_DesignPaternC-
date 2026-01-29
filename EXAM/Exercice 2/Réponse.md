Exercice 2 : Identification de Pattern (4 points)
Analysez le code suivant et répondez aux questions.

````csharp
public interface IVehicle
{
    void Assemble();
}

public class Car : IVehicle
{
    public void Assemble() => Console.WriteLine("Assemblage voiture: châssis, moteur, roues, carrosserie");
}

public class Motorcycle : IVehicle
{
    public void Assemble() => Console.WriteLine("Assemblage moto: cadre, moteur, 2 roues");
}

public class Truck : IVehicle
{
    public void Assemble() => Console.WriteLine("Assemblage camion: châssis renforcé, moteur diesel, 6 roues, remorque");
}

public abstract class VehicleFactory
{
    public abstract IVehicle CreateVehicle();

    public void OrderVehicle()
    {
        var vehicle = CreateVehicle();
        Console.WriteLine("Commande enregistrée");
        vehicle.Assemble();
        Console.WriteLine("Véhicule prêt pour livraison");
    }
}

public class CarFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Car();
}

public class MotorcycleFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Motorcycle();
}

public class TruckFactory : VehicleFactory
{
    public override IVehicle CreateVehicle() => new Truck();
}
````

Questions
2.1 Identifiez le pattern utilisé. (0.5 point)

**Réponse:**
Le pattern utilisé ici c'est le Factory Method

2.2 Listez les participants du pattern et associez-les aux classes du code. (1.5 points)

**Réponse:**
- Product: IVehicle
- ConcreteProduct: Car, Motorcycle, Truck
- Creator: VehicleFactory
- ConcreteCreator: CarFactory, MotorcycleFactory, Truckfactory

2.3 Expliquez le rôle de la méthode OrderVehicle() dans ce pattern. Comment s'appelle ce type de méthode ? (1 point)

**Réponse:**
La méthode OrderVehicle() est une méthode qui définit le processus de commande d'un véhicule. C'est une template method.

2.4 Quelle différence fondamentale y a-t-il entre ce pattern et Abstract Factory ? Dans quel cas préféreriez-vous l'un à l'autre ? (1 point)

**Réponse:**
La différence entre le Factory Method et l'Abstract Factory est que le Factory Method crée un seul produit, l'Abstract Factory crée des familles de produit.
On préfere utiliser le Factory Method lorsque l'on souhaite créer des objets d'un seul type, et l'Abstract Factory lorsque l'on a besoin de créer des objets de plusieurs familles.