using System;
using System.Xml.Schema;

class Program
{
    static void Main(string[] args)
    {
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.Getfractionstring());
        Console.WriteLine(f1.GetDecimalvalue());

        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.Getfractionstring());
        Console.WriteLine(f2.GetDecimalvalue());

        Fraction f3 = new Fraction(3,4);
        Console.WriteLine(f3.Getfractionstring());
        Console.WriteLine(f3.GetDecimalvalue());

        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.Getfractionstring());
        Console.WriteLine(f4.GetDecimalvalue());
    }
}