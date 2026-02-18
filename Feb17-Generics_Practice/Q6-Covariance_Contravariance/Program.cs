using System;

public class Animal { public string Name = "Animal"; }
public class Dog : Animal { public Dog() { Name = "Dog"; } }

// ✅ Covariant (produces T)
public interface IProducer<out T>
{
    T Produce();
}

// ✅ Contravariant (consumes T)
public interface IConsumer<in T>
{
    void Consume(T item);
}

public class DogProducer : IProducer<Dog>
{
    public Dog Produce() => new Dog();
}

public class AnimalConsumer : IConsumer<Animal>
{
    public void Consume(Animal item)
    {
        Console.WriteLine($"Consumed: {item.Name}");
    }
}

public class Program
{
    public static void Main()
    {
        // Works because of variance
        IProducer<Animal> p = new DogProducer();     
        IConsumer<Dog> c = new AnimalConsumer();     

        Use(p, c);
    }

    public static void Use(IProducer<Animal> producer, IConsumer<Dog> consumer)
    {
        Animal animal = producer.Produce();

        if (animal is Dog dog)
        {
            consumer.Consume(dog);
        }
    }
}
