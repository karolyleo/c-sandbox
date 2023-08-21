﻿// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
//int age = 50;
Console.WriteLine($"int: {int.MaxValue},{int.MinValue}");
Console.WriteLine($"ushort: {ushort.MaxValue},{ushort.MinValue}");

Console.WriteLine($"float: {float.MaxValue},{float.MinValue}");
Console.WriteLine($"double: {double.MaxValue},{double.MinValue}");

Console.WriteLine($"decimal: {decimal.MaxValue},{decimal.MinValue}");

string s1 = "Hello \"World\"";
string s2 = "Hello \"World\"";
Demo d1 = new Demo() { x=10 };
Demo d2 = new Demo() { x=10 };

d1.A();
Console.WriteLine(s1==s2);
Console.WriteLine(d1==d2);

class Demo {
    public int x { get; set; }
    internal void A() {
        int i = 0;
        Console.WriteLine("This is A before calling B");
        B();
        Console.WriteLine("This is A after calling B");
    }

    internal void B()
    {
        int j = 0;
        Console.WriteLine("This is B before calling C");
        C();
        Console.WriteLine("This is B after calling C");
    }
    internal void C()
    {
        int k = 0;
        Console.WriteLine("This is C");
    }
}