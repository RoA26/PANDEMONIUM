// TurnManager.cs
// Coordinada El Flujo Del Combate, Sabe Quien Actua Y Cuando Termina.

public class TurnManager
{
    //---DATOS---

    //Las Unidades Del Combate
    public Unit Player;
    public Unit Enemy;

    //De quien es el turno? true = jugador, false = enemigo
    public bool IsPlayerTurn;

    //Termino el combate?
    public bool CombatOver;

    //--CONSTRUCTOR---

    public TurnManager(Unit player, Unit enemy)
    {
        Player     = player;
        Enemy      = enemy;
        IsPlayerTurn = true;
        CombatOver = false;
    }

    public bool CombatActive()
    {
        return !CombatOver;
    }
    public void EnemyTurn()
{
    BattleAction attack = new BattleAction(
        "Ataque Goblin",
        Enemy.BaseAtk,
        0,
        "El goblin golpea."
    );

    ActionResult result = ExecuteTurn(attack);

    result.PrintResult();
}

    //Ejecuta Accion En El Turno Actual y Avanza Al Siguente Turno.
    //Recibe la acción del jugador o la Ia
    public ActionResult ExecuteTurn(BattleAction action)
    {
        ActionResult result;
        
        if (IsPlayerTurn)
        {
           //Turno del Jugador: Ataca Al Enemigo
        result = Player.ExecuteAction(action, Enemy);  
        }
        else
        {
            //Turno Del Enemigo: Ataca Al Jugador
            result = Enemy.ExecuteAction(action, Player);
        }

        // Verificamos si el combate terminó
        CheckCombatOver();
         // Alternamos el turno solo si el combate sigue
        if (!CombatOver)
            IsPlayerTurn = !IsPlayerTurn;

        return result;
    }

    // Verifica si alguna unidad murió y marca el combate como terminado.
    private void CheckCombatOver()
    {
        if (!Player.IsAlive() || !Enemy.IsAlive())
            CombatOver = true;
    }

    // Muestra quién ganó.
    public void PrintOutcome()
    {
        if (Player.IsAlive())
            Console.WriteLine($"¡{Player.Name} ganó el combate!");
        else
            Console.WriteLine($"¡{Enemy.Name} ganó el combate!");
    }

       
    
}