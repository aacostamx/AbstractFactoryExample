//------------------------------------------------------------------------
// <copyright file="AbstractFactoryExample" company="Volaris">
//     Copyright (c) AACOSTA All rights reserved.
//     Website: http://aacosta.com.mx/
// </copyright>
//------------------------------------------------------------------------

namespace AbstractFactoryExample
{
    using System;

    /// <summary>
    /// Main class
    /// </summary>
    public class Program
    {
        /// <summary>
        /// The Abstract Factory pattern provides an interface for creating related families of objects
        /// without needing to specify the concrete implementations.  This pattern is critical for ideas
        /// like Dependency Injection.
        /// </summary>
        /// <param name="args">The arguments.</param>
        public static void Main(string[] args)
        {
            Console.WriteLine("Who are you? (A)Adult or (C)Child? (by defualt adult)");
            char input = Console.ReadKey().KeyChar;
            RecipeFactory factory;
            switch (input)
            {
                case 'C':
                    factory = new KidCuisineFactory();
                    break;

                case 'A':
                default:
                    factory = new AdultCuisineFactory();
                    break;

            }

            var sandwich = factory.CreateSandwich();
            var dessert = factory.CreateDessert();

            Console.WriteLine("\nSandwich: " + sandwich.GetType().Name);
            Console.WriteLine("Dessert: " + dessert.GetType().Name);

            Console.ReadKey();
        }
    }

    /// <summary>
    /// An abstract product
    /// </summary>
    abstract class Sandwich { }

    /// <summary>
    /// An abstract product 
    /// </summary>
    abstract class Dessert { }

    /// <summary>
    /// The Abstract Factory class, which defines methods for creating abstract objects.
    /// </summary>
    abstract class RecipeFactory
    {
        public abstract Sandwich CreateSandwich();
        public abstract Dessert CreateDessert();
    }

    /// <summary>
    /// A concrete product
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.Sandwich" />
    class Bacon : Sandwich { }

    /// <summary>
    /// A concrete product
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.Dessert" />
    class CremeBrulee : Dessert { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.RecipeFactory" />
    class AdultCuisineFactory : RecipeFactory
    {
        /// <summary>
        /// Creates the sandwich.
        /// </summary>
        /// <returns></returns>
        public override Sandwich CreateSandwich()
        {
            return new Bacon();
        }

        /// <summary>
        /// Creates the dessert.
        /// </summary>
        /// <returns></returns>
        public override Dessert CreateDessert()
        {
            return new CremeBrulee();

        }
    }

    /// <summary>
    /// A concrete product
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.Sandwich" />
    class Peanut : Sandwich { }

    /// <summary>
    /// A concrete product
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.Dessert" />
    class IceCreamSundae : Dessert { }

    /// <summary>
    /// A concrete factory which creates concrete objects by implementing the abstract factory's methods.
    /// </summary>
    /// <seealso cref="AbstractFactoryExample.RecipeFactory" />
    class KidCuisineFactory : RecipeFactory
    {
        /// <summary>
        /// Creates the sandwich.
        /// </summary>
        /// <returns></returns>
        public override Sandwich CreateSandwich()
        {
            return new Peanut();
        }

        /// <summary>
        /// Creates the dessert.
        /// </summary>
        /// <returns></returns>
        public override Dessert CreateDessert()
        {
            return new IceCreamSundae();
        }
    }
}
