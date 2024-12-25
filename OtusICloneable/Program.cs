using System;

// 1. Определение интерфейса IMyCloneable
public interface IMyCloneable<T>
{
    T MyClone();
}

// 2. Базовый класс Animal
public class Animal : ICloneable, IMyCloneable<Animal>
{
    public string Name { get; set; }
    public int Age { get; set; }

    public Animal(string name, int age)
    {
        Name = name;
        Age = age;
    }

    // Реализация клонирования
    public virtual Animal MyClone()
    {
        return new Animal(Name, Age);
    }

    object ICloneable.Clone()
    {
        return MyClone();
    }
}

// 3. Производный класс Mammal
public class Mammal : Animal
{
    public string FurColor { get; set; }

    public Mammal(string name, int age, string furColor) : base(name, age)
    {
        FurColor = furColor;
    }

    public override Animal MyClone()
    {
        return new Mammal(Name, Age, FurColor);
    }
}

// 4. Класс Dog
public class Dog : Mammal
{
    public string Breed { get; set; }

    public Dog(string name, int age, string furColor, string breed) : base(name, age, furColor)
    {
        Breed = breed;
    }

    public override Animal MyClone()
    {
        return new Dog(Name, Age, FurColor, Breed);
    }
}

// 5. Демонстрация
class Program
{
    static void Main(string[] args)
    {
        // Создание объектов
        Dog originalDog = new Dog("Buddy", 3, "Brown", "Golden Retriever");
        Dog clonedDog = (Dog)originalDog.MyClone();

        // Вывод информации
        Console.WriteLine("Original Dog:");
        Console.WriteLine($"Name: {originalDog.Name}, Age: {originalDog.Age}, FurColor: {originalDog.FurColor}, Breed: {originalDog.Breed}");

        Console.WriteLine("\nCloned Dog:");
        Console.WriteLine($"Name: {clonedDog.Name}, Age: {clonedDog.Age}, FurColor: {clonedDog.FurColor}, Breed: {clonedDog.Breed}");

        // Изменение клона для проверки независимости объектов
        clonedDog.Name = "Max";
        Console.WriteLine("\nAfter modifying cloned dog:");
        Console.WriteLine($"Original Name: {originalDog.Name}");
        Console.WriteLine($"Cloned Name: {clonedDog.Name}");
    }
}

// 6. Вывод о преимуществах и недостатках:
/*
 * Преимущества IMyCloneable:
 * 1. Универсальность: позволяет типобезопасное клонирование.
 * 2. Четкость: предназначен исключительно для клонирования.
 * 3. Гибкость: можно реализовать метод MyClone() по-своему.
 *
 * Недостатки IMyCloneable:
 * 1. Требует реализации для каждого класса.
 * 2. Дополнительное время на разработку и поддержку интерфейса.
 *
 * Преимущества ICloneable:
 * 1. Стандартный интерфейс, знакомый большинству разработчиков.
 * 2. Совместимость с другими библиотеками .NET.
 *
 * Недостатки ICloneable:
 * 1. Возвращает object, требуя приведения типа.
 * 2. Неявное поведение: непонятно, глубокое или поверхностное клонирование.
 */
