﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAndObjects
{
    class Color
    {
        public float r,g, b;
    }

    class Dog
    {
        public string name;
        public int age;
        public string breed;
        public Color color;

        public void speak()
        {
            Console.WriteLine(name + "is barking");
        }
        public void sit()
        {
            Console.WriteLine(name + "is sitting");
        }
        public void walk()
        {
            Console.WriteLine(name + "is walking");
        }
        public void WagTail()
        {
            Console.WriteLine(name + "is wagging it's tail");
        }

        public void GetInfo()
        {
            Console.WriteLine("Name;" + name);
            Console.WriteLine("Age:" + age);
            Console.WriteLine("Breed:" + breed);
            Console.WriteLine("Color: r-" + color.r +
                                     "g-" + color.g +
                                     "b-" + color.b);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Color red = new Color();
            red.r = 1;
            red.g = 0;
            red.b = 0;

            Dog dog1 = new Dog();
            dog1.name = "Lassle";
            dog1.breed = "Poodle";
            dog1.age = 1;
            dog1.color = red ;

            dog1.speak();
            dog1.walk();

        }
    }
}
