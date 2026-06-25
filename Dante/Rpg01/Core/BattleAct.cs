//BattleAction.cs
//Describe Una Accion De Combate
//No Ejecuta Nada, Solo Contiene Los Datos De La Accion



public class BattleAction
{
    public List<StatusEffect> Effects = new List<StatusEffect>();
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

    //CoolDOwns
    public int CoolDownMax;
    public int CoolDownCurrent;
    

    

    //--- CONSTRUCTOR ---
    // Mismo Patrón Que Unit - Pasamos  Todos Los Datos De Una Vez.
    public BattleAction(string name, int baseDmg, int ECost, string desc, List<StatusEffect>? effects = null, int cooldown = 0) // Osea Sin Cooldown
    {
        Name = name;
        BaseDamage = baseDmg;
        EnergyCost = ECost;
        Description = desc;;
       Effects = effects ?? new List<StatusEffect>(); // Si no Pasa Nada Queda Null
       CoolDownMax = cooldown;
       CoolDownCurrent = 0;


    }
    
     public bool IsReady() => CoolDownCurrent <= 0;

     public void TriggerCooldown()
    {
        CoolDownCurrent = CoolDownMax;
    }
    // Reduce el cooldown un turno. Llamar al inicio de cada turno del jugador.
    public void TickCooldown()
    {
        if (CoolDownCurrent > 0)
            CoolDownCurrent--;
    }
    

    // --- MÉTODO ---

    //Muestra En Consola La ifo De La Acción

    public void PrintInfo()
    {
       string cdText = CoolDownMax > 0 ? $" | CD: {CoolDownCurrent}/{CoolDownMax}" : "";
    Console.WriteLine($"[{Name}] Daño: {BaseDamage} | Energía: {EnergyCost}{cdText} | {Description}");
}
}