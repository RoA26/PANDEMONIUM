// Program.cs
// Punto de entrada del programa.
// Crea personajes, equipa roles e inicia el combate.
using System;
using System.Collections.Generic;

// --- PERSONAJES ---
Akeneo akeneo = new Akeneo();
akeneo.EquipRole(new AkeneoSupp());
Atenea atenea = new Atenea();
atenea.EquipRole(new AteneaTank());
// --- UNIDAD DE COMBATE ---
// Unit es el motor. Character es la identidad.
Unit jugador = new Unit(
    akeneo.Name,
    maxHp: akeneo.BaseHp,
    baseAtk: 22,
    maxEnergy: akeneo.BaseEnergy
);

// --- ACCIONES DESDE EL ROL ---
List<BattleAction> playerActions = akeneo.GetActions();

// --- ENEMIGO ---
Unit goblin = new Unit(
    "Duende Verde",
    maxHp: 350,
    baseAtk: 18,
    maxEnergy: 2
);

// --- COMBATE ---
TurnManager combat = new TurnManager(jugador, goblin, playerActions);

Console.WriteLine("=== COMBATE ===");
jugador.PrintStatus();
goblin.PrintStatus();

while (combat.CombatActive())
{
    combat.ProcessTurn();
}

Console.WriteLine("\n=== FIN DEL COMBATE ===");
combat.PrintOutcome();