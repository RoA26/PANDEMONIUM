using System;
using System.Collections.Generic;



public class InputHandler
{


    private void PrintMenu(Unit player,List<BattleAction> allActions)
    {

        Console.WriteLine("\n================");
        Console.WriteLine($"Turno de {player.Name}");
        Console.WriteLine("================");

        player.PrintStatus();


        for(int i = 0; i < allActions.Count; i++)
        {
            BattleAction action = allActions[i];
           bool sinEnergia = !player.CanAfford(action);
            bool enCooldown = !action.IsReady();
            bool bloqueada  = sinEnergia || enCooldown;

            if (bloqueada)
            {
                //Motivo Del Bloqueo
                string motivo = enCooldown
                ? $"CD: {action.CoolDownCurrent} Turnos"
                : "Sin Energía";

                 Console.WriteLine($"[{i+1}] [BLOQUEADA — {motivo}] {action.Name}");
            }
            else
            {
             Console.Write($"[{i+1}]");
             action.PrintInfo();
              
            }

        }


        Console.Write("Selecciona: ");

    }




   public BattleAction GetPlayerAction(Unit player, List<BattleAction> allActions)
{
    while (true)
    {
        PrintMenu(player, allActions);

        string input = Console.ReadLine() ?? "";

        if (int.TryParse(input, out int choice))
        {
            int index = choice - 1;

            if (index >= 0 && index < allActions.Count)
            {
                BattleAction seleccionada = allActions[index];

                if (!player.CanAfford(seleccionada) || !seleccionada.IsReady())
                {
                    Console.WriteLine("Esa habilidad no está disponible ahora.");
                    continue;
                }

                return seleccionada;
            }
        }

        Console.WriteLine("Opción inválida.");
    }
}

}