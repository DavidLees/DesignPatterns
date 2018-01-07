using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Model
{
    interface IToy
    {
        void Create(string color, int price);
        void Customize(string make, string model);
    }

    public abstract class Toy:IToy
    {
        public string Color { get; protected set; }
        public int Price { get; protected set; }
        public string ToyType { get; protected set; }
        public string Make { get; protected set; }
        public string Model { get; protected set; }

        public abstract void Create(string color, int price);
        public abstract void Customize(string make, string model);
    }

    public class ToyCar : Toy
    {
        public ToyCar()
        {
            ToyType = "Toy Car";
        }

        public override void Create(string color, int price)
        {
            Color = color;
            Price = price;
        }

        public override void Customize(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public override string ToString() => $"This is a {Make} {Model} {ToyType} with color {Color} and price {Price}";
    }   

    public class ToyTrain : Toy
    {

        public ToyTrain()
        {
            ToyType = "Toy Train";
        }

        public override void Create(string color, int price)
        {
            Color = color;
            Price = price;
        }

        public override void Customize(string make, string model)
        {
            Make = make + " Train";
            Model = model + " Train";
        }

        public override string ToString() => $"This is a {Make} {Model} {ToyType} with color {Color} and price {Price}";
    }

    public class IpswichToyCar : Toy
    {

        public IpswichToyCar()
        {
            ToyType = "Ipswich Toy Car";
        }

        public override void Create(string color, int price)
        {
            Color = color;
            Price = price;
        }

        public override void Customize(string make, string model)
        {
            Make = make;
            Model = model;
        }

        public override string ToString() => $"This is a {Make} {Model} {ToyType} with color {Color} and price {Price}";

    }

    public class IpswichToyTrain : Toy
    {

        public IpswichToyTrain()
        {
            ToyType = "Toy Train";
        }

        public override void Create(string color, int price)
        {
            Color = color;
            Price = price;
        }

        public override void Customize(string make, string model)
        {
            Make = make + " Train";
            Model = model + " Train";
        }

        public override string ToString() => $"This is a {Make} {Model} {ToyType} with color {Color} and price {Price}";
    }
}


    