//BattleAction.cs
//Describe Una Accion De Combate
//No Ejecuta Nada, Solo Contiene Los Datos De La Accion

public class BattleAction
{
    //---- DATOS ---

    //El Nombre Que Vera El Jugador. "Ataque Basico" y Tal.
    public string Name;

    //Cuanto Daño Base Hace La Acción
    // Base Por Ahora Ya Que Los Stats del Usuario Lo Modificaran Mas Adelante
    public int BaseDamage;

    //Cuánta Energía cuesta Ejecutar Esta Acción.
    // 0 = gratis. Así El Ataque Básico No Consume Nada.
    public int EnergyCost;

    //Texto Descriptivo. Util Para Mostrar Al Jugador Que Hace La Acción.
    public string Description;

    

    //--- CONSTRUCTOR ---
    // Mismo Patrón Que Unit - Pasamos  Todos Los Datos De Una Vez.
    public BattleAction(string name, int baseDmg, int ECost, string desc)
    {
        Name = name;
        BaseDamage = baseDmg;
        EnergyCost = ECost;
        Description = desc;;
    }
    

    // --- MÉTODO ---

    //Muestra En Consola La ifo De La Acción

    public void PrintInfo()
    {
        Console.WriteLine($"[{Name}] Daño: {BaseDamage} | Energía: {EnergyCost} |  {Description}" );
        
    }
}