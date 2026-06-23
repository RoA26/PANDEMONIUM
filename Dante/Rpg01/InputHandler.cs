//InputHandler.cs
// Para Un jugador Y Su Lista De Acciones Disponible

using System;
using System.Collections.Generic;

public class InputHandler
{
    
    //Muestra Las Opciones Disponibles Al Jugador
    private void PrintMenu(Unit player, List<BattleAction>  availableActions)
    {
        Console.WriteLine("\n=============================");
        Console.WriteLine($"  Turno de {player.Name}");
        Console.WriteLine("=============================");
        player.PrintStatus();
        Console.WriteLine("\n--- Acciones disponibles ---");

        //Recorremos La Lista y Mostramos Cada Acción Numerada
        for (int i = 0; i <availableActions.Count; i++)
        {
            //El Jugador Ve [1],[2],[3]...No [0],[1],[2]
            Console.Write($"[{i + 1}] ");
            availableActions[i].PrintInfo();
        }

        Console.WriteLine("------------------------");
        Console.WriteLine("Elige Una Acción");
    }

    //El Metodo Principal-- ESpera El Input Válido y Devuelve La Acción Elegida
    public  BattleAction GetPlayerAction(Unit player, List<BattleAction> availableActions)
    {
        while(true)// Bucle Hasta Que El Jugador Elija Algo Valido
        {
            PrintMenu(player, availableActions);

            string input = Console.ReadLine();

            //Intentamos Convertir Texto a Número
            // int.TryParse Devuelve True Si Lo Logró, false Si No
            bool isNumber = int.TryParse(input, out int choice);
            
            if (!isNumber)
            {
                Console.WriteLine("⚠ Escribe un número, no texto.");
                continue;// Vuelve Al Inicio Del Bucle
            }

            //El Jugador Escribe 1, 2, 3... Pero La Lista usa 0, 1, 2...
            int index = choice -1;

            bool inRange = index >= 0 && index < availableActions.Count;

            if (!inRange)
            {
                Console.WriteLine($"⚠ Elige entre 1 y {availableActions.Count}.");
                continue;
            }

            //Input Válido - Devolvemos La Acción Elegida
            return availableActions[index];
        }
    }
}