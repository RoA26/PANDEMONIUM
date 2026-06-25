// TurnManager.cs
//
// Coordina el flujo completo del combate.
//
// Sabe:
// - Quién tiene el turno.
// - Qué acción ejecutar.
// - Cuándo termina la batalla.
// - Cuándo cambiar de turno.
//
// No calcula daño directamente.
// Esa responsabilidad pertenece a Unit.



using System.Collections.Generic;



public class TurnManager
{


    // -------------------
    // DATOS
    // -------------------


    // Unidad controlada por el jugador.

    public Unit Player;



    // Unidad controlada por la IA.

    public Unit Enemy;



    // Indica si el combate terminó.

    private bool CombatOver;



    // Indica quién juega actualmente.
    //
    // true  = jugador
    // false = enemigo

    private bool IsPlayerTurn;



    // Acciones disponibles del jugador.

    private List<BattleAction> playerActions;



    // Encargado de recibir decisiones del jugador.

    private InputHandler inputHandler;



    // -------------------
    // CONSTRUCTOR
    // -------------------


    public TurnManager(
        Unit player,
        Unit enemy,
        List<BattleAction> actions
    )
    {

        Player = player;

        Enemy = enemy;


        playerActions = actions;


        IsPlayerTurn = true;


        CombatOver = false;


        inputHandler = new InputHandler();

    }



    // -------------------
    // MÉTODOS
    // -------------------



    // Devuelve si el combate todavía continúa.

    public bool CombatActive()
    {

        return !CombatOver;

    }





    // Controla un turno completo.
    //
    // Decide:
    // - Si juega el jugador.
    // - Si juega el enemigo.
    // - Ejecuta la acción.
    // - Muestra el resultado.

    public void ProcessTurn()
    {

        ActionResult result;



        if(IsPlayerTurn)
        {
            //Procesar Dots
            Player.ProcessEffects();
            
            //Verificar Si El Jugador Murio Por Un Efecto
            CheckCombatOver();
            if(CombatOver) return;

            //Reducir CoolDowns Al Inicio Del Turno
            foreach (BattleAction Action in playerActions)
                Action.TickCooldown();
            //Restaurar Energia
            Player.RestoreEnergy();

            //
            ;


            // Pedimos al jugador elegir una acción.

            BattleAction chosen =
                inputHandler.GetPlayerAction(
                    Player,
                    playerActions // <-- antes Pasabas PlayerActions, Ahora Pasas Affordable
                );
            
            //Activa El Cooldown
            chosen.TriggerCooldown();
            
            //Consumimos Energia
            Player.ConsumeEnergy(chosen);

           
            result =
                ExecuteTurn(chosen);

        }

        else
        {

            Enemy.ProcessEffects();
            CheckCombatOver();
        if(CombatOver) return;

            // La IA selecciona una acción.

            BattleAction action =
                GetEnemyAction();



            result =
                ExecuteTurn(action);

        }



        result.PrintResult();

    }





    // Ejecuta la acción del turno actual.
    //
    // Este método no decide qué acción usar.
    // Solo ejecuta la acción recibida.

    private ActionResult ExecuteTurn(
        BattleAction action
    )
    {


        ActionResult result;



        if(IsPlayerTurn)
        {

            result =
                Player.ExecuteAction(
                    action,
                    Enemy
                );

        }

        else
        {

            result =
                Enemy.ExecuteAction(
                    action,
                    Player
                );

        }



        // Revisamos si alguien murió.

        CheckCombatOver();



        // Solo cambia turno si nadie murió.

        if(!CombatOver)
        {

            IsPlayerTurn =
                !IsPlayerTurn;

        }



        return result;

    }





    // Genera la acción del enemigo.
    //
    // Actualmente es una IA simple.
    // Más adelante aquí podría existir:
    // - patrones de jefe
    // - decisiones inteligentes
    // - prioridades

    private BattleAction GetEnemyAction()
    {

        return new BattleAction(
            "Ataque Goblin",
            Enemy.BaseAtk,
            0,
            "El goblin golpea."
        );

    }


   

    // Comprueba si alguna unidad murió.

    private void CheckCombatOver()
    {

        if(!Player.IsAlive() ||
           !Enemy.IsAlive())
        {

            CombatOver = true;

        }

    }





    // Muestra el resultado final.

    public void PrintOutcome()
    {

        if(Player.IsAlive())
        {

            Console.WriteLine(
                $"¡{Player.Name} ganó el combate!"
            );

        }

        else
        {

            Console.WriteLine(
                $"¡{Enemy.Name} ganó el combate!"
            );

        }

    }


}