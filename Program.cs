// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

Service.Lock.Flag f = new();
{
    using Service.Lock l = new(f);

    Console.WriteLine(l.Try());
    Console.WriteLine(l.Try());
    Console.WriteLine(l.Try());
}

Console.WriteLine("FIN");

