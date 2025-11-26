// See https://aka.ms/new-console-template for more information
using Service;
using static Service.LockManager;

Console.WriteLine("Hello, World!");

LockManager lockManager = new();

{
    using LockObject l = lockManager.CreateLockObject();

    Console.WriteLine(l.Try());
    Console.WriteLine(l.Try());
    Console.WriteLine(l.Try());
}

Console.WriteLine("FIN");

