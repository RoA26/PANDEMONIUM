// See https://aka.ms/new-console-template for more information
// Program.cs

// --- Creamos las unidades ---
Unit atenea = new Unit("Atenea", maxHp: 400, baseAtk: 40);
Unit goblin  = new Unit("Goblin",  maxHp: 40,  baseAtk: 8);

// --- Creamos dos acciones de combate ---

List<BattleAction> playerActions = new List<BattleAction>
{
    new BattleAction("Ataque Básico",  baseDmg: 10, ECost: 0,  desc: "Un golpe simple."),
    new BattleAction("Golpe Fuerte",   baseDmg: 20, ECost: 2,  desc: "Más daño, más riesgo."),
    new BattleAction("Embestida",      baseDmg: 15, ECost: 1,  desc: "Golpe directo al pecho.")
};

// --- Handler ---
InputHandler inputHandler = new InputHandler();



// --- Mostramos el estado inicial ---
Console.WriteLine("=== UNIDADES ===");
atenea.PrintStatus();
goblin.PrintStatus();

TurnManager combat = new TurnManager(atenea, goblin);
Console.WriteLine("=== INICIO DEL COMBATE ===");
atenea.PrintStatus();
goblin.PrintStatus();

while (TurnManager.CombatActive())
{
    BattleAction chosen = 
        inputHandler.GetPlayerAction(atenea, playerActions);

    ActionResult result =
        TurnManager.ExecuteTurn(chosen);

    result.PrintResult();


    if (!TurnManager.CombatActive())
        break;


    BattleAction enemyAction =
        new BattleAction(
            "Ataque básico",
            goblin.BaseAtk,
            0,
            "El goblin ataca."
        );


    ActionResult enemyResult =
        TurnManager.ExecuteTurn(enemyAction);

    enemyResult.PrintResult();
}




Console.WriteLine("\n=== FIN DEL COMBATE ===");
combat.PrintOutcome();