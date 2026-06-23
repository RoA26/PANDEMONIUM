//Program.cs
//Punto De Entrada Al Programa
//Aqui Purebo Que Unit Funciona Correctamente.

// Program.cs
Unit atenea = new Unit("Atenea", maxHp: 400, baseAtk: 40);
Unit goblin  = new Unit("Goblin",  maxHp: 40,  baseAtk: 8);

atenea.PrintStatus();
goblin.PrintStatus();

goblin.TakeDamage(25);
Console.WriteLine("--- Goblin recibe 25 de daño ---");
goblin.PrintStatus(); 