using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Model;
using DesignPatterns.Patterns;

namespace DesignPatterns.Patterns
{
    public enum TypesofToys
    {
        ToyTrain,
        ToyCar
    }

    public class SimpleToyFactory
    {

        public Toy CreateToy(TypesofToys choice)
        {
            switch (choice)
            {
                case TypesofToys.ToyTrain:
                {
                    return new ToyTrain();
                }
                case TypesofToys.ToyCar:
                {
                    return new ToyCar();
                }
                default:
                {
                    return new ToyCar();
                }
            }
        }
    }

    public class ToyFactory
    {
        readonly SimpleToyFactory _factory;

        public ToyFactory(SimpleToyFactory simpleFactory)
        {
            _factory = simpleFactory;
        }

        public Toy ProduceToy(TypesofToys toyType, string toyPrice, string toyColor, string toyMake, string toyModel)
        {
            Toy newToy = _factory.CreateToy(toyType);

            newToy.Create(toyColor, Convert.ToInt32(toyPrice));
            newToy.Customize(toyMake, toyModel);

            return newToy;
        }
    }

    public abstract class AbstractToyFactory
    {

        public Toy ProduceToy(TypesofToys toyType, string toyPrice, string toyColor, string toyMake, string toyModel)
        {
            Toy newToy = CreateToy(toyType);

            newToy.Create(toyColor, Convert.ToInt32(toyPrice));
            newToy.Customize(toyMake, toyModel);

            return newToy;
        }

        public abstract Toy CreateToy(TypesofToys toyType);
    }

    public class IpswichToyFactory : AbstractToyFactory
    {
        public override Toy CreateToy(TypesofToys toyType)
        {
            switch(toyType)
            {
                case TypesofToys.ToyTrain:
                {
                    return new IpswichToyTrain();
                }

                case TypesofToys.ToyCar:
                {
                    return new IpswichToyCar();
                }
                default:
                {
                    return new ToyCar();
                }
            }
        }
    }

    public sealed class Singleton
    {
        private static Singleton instance;
        private static readonly object padlock = new object();

        public string Name { get; protected set; }

        private Singleton()
        {
            Name = "I'm a Singleton!";
        }

        public static Singleton Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Singleton();
                    }
                    return instance;
                }
            }
        }

        public void Execute()
        {
            Console.WriteLine("Single");
        }
    }
}

