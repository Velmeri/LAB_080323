using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_080323
{
    internal class Program
    {
        public class Device
        {
            public string Name { get; set; }
            public string Manufacturer { get; set; }
            public double Value { get; set; }

            public Device (string name, string manufacturer, double value)
            {
                Name = name;
                Manufacturer = manufacturer;
                Value = value;
            }

            public override string ToString()
            {
                return $"Name: {Name}\tManufacturer: {Manufacturer}\tValue: {Value}";
            }

            public override bool Equals(object obj)
            {
                if (obj == null || GetType() != obj.GetType())
                {
                    return false;
                }

                Device other = (Device)obj;
                return Name == other.Name && Manufacturer == other.Manufacturer && Value == other.Value;
            }

            public override int GetHashCode()
            {
                return Name.GetHashCode() ^ Manufacturer.GetHashCode() ^ Value.GetHashCode();
            }
        }

        static void Main(string[] args)
        {
            Device[] devices1 = new Device[]
            {
                new Device("Device1", "Manufacturer1", 10.5),
                new Device("Device2", "Manufacturer2", 20.7),
                new Device("Device3", "Manufacturer1", 15.0),
            };

            Device[] devices2 = new Device[]
            {
                new Device("Device2", "Manufacturer2", 20.7),
                new Device("Device4", "Manufacturer3", 12.3),
                new Device("Device5", "Manufacturer3", 18.6),
            };

            var difference = devices1.Except(devices2);
            var coincidences = devices1.Intersect(devices2);
            var all = devices1.Union(devices2);

            Console.WriteLine("Except");
            foreach (Device device in difference) Console.WriteLine(device);

            Console.WriteLine("\nIntersect:");
            foreach (Device device in coincidences) Console.WriteLine(device);

            Console.WriteLine("\nUnion:");
            foreach (Device device in all) Console.WriteLine(device);

            Console.ReadKey(true);
        }
    }
}
