//Unit.cs
//Esta Clase Representa Cualquier Entidad Que Participa En Combate.
// Puede Ser Un Jugador, Un Enemigo o Cualquier Cosa En El Futuro.


public class Unit
{   
    
    // Se crea UNA vez cuando nace la Unit, y se reutiliza siempre
    private readonly Random _random = new Random();

    

    //--- DATOS BÁSICOS ---


  

    //El Nombre De La Unidad. (Para Identificar Por Consola Por Ahora)
    public string Name;

    //HP Actual. Empieza Como El Maximo, Baja Al Recibir Daño
    public int CurrentHp;

    //HP Maximo.
    public int MaxHp;

    //Daño De Ataque  Basico De Esta Unidad.
    public int BaseAtk;
     
     //---ENERGÍA----

     //Energia De La Entidad Disponible Durante El Turno
     public int CurrentEnergy;

     //Maximo De Energia Por Turno
     public int MaxEnergy;

     //-- EFECTOS --

    //Lista De Efectos Activos SObre La Entidad
    public List<StatusEffect> ActiveEffects = new List<StatusEffect>();
     

    // --- CONSTRUCTOR ---
    // Un constructor es el "molde" que usamos para crear una Unit.
    // En lugar de escribir los valores uno por uno después de crear el objeto,
    // los pasamos todos de una vez aquí.

    public bool IsAlive()
    {
    return CurrentHp > 0;
    }

    public Unit(string name, int maxHp, int baseAtk, int maxEnergy = 3 )
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        BaseAtk = baseAtk;
        MaxEnergy = maxEnergy;
        CurrentEnergy = 0;
         
    }

    //---- MÉTODOS ----

    //Recibir Daño Nunca Baja a 0 (No tiene Sentido Tener HP Negativo)
    public void TakeDamage(int amount)
    {
        CurrentHp -= amount;


        //Math.Max Devuelve El Mayor De Dos Números.
        //Esto Hace Que Current HP Nunca Sea Negativo
        CurrentHp = System.Math.Max(0, CurrentHp);
    }

    //Para Mostrar La Consola
    public void PrintStatus()
    {
        Console.WriteLine($"{Name} - HP: {CurrentHp}/{MaxHp} | ATK: {BaseAtk} | ENERGY: {CurrentEnergy}/{MaxEnergy}" );
    }
    
    public ActionResult ExecuteAction(BattleAction action, Unit target)
{
    // Rango de daño ±30%
    int minDmg = (int)(action.BaseDamage * 0.7f);
    int maxDmg = (int)(action.BaseDamage * 1.3f);
    int finalDmg = _random.Next(minDmg, maxDmg + 1);

    // Aplicamos daño al objetivo
    target.TakeDamage(finalDmg);

    // Aplicamos efectos de estado al objetivo
    foreach(StatusEffect effect in action.Effects)
    {
        target.ActiveEffects.Add(
            new StatusEffect(effect.Name, effect.DOT, effect.TurnsRemaining)
        );
        Console.WriteLine($"  [{effect.Name}] aplicado a {target.Name} por {effect.TurnsRemaining} turnos.");
    }

    // Devolvemos el resultado — UN SOLO return al final
    return new ActionResult(
        ActName: action.Name,
        DmgDealt: finalDmg,
        targetDied: !target.IsAlive(),
        msg: $"{Name} usa {action.Name} e inflige {finalDmg} de daño a {target.Name}."
    );
}
    //----MÉTODOS DOT ---
     //Procesa Todos Los Efectos Sobre La Unidad
    public void ProcessEffects()
    {
        //Iteramos Al Reves
        //Conteo Pa Atras

        for (int i = ActiveEffects.Count - 1; i >= 0; i--)
        {
            StatusEffect effect = ActiveEffects[i];

            //Aplicamos El Daño Del Efecto
            TakeDamage(effect.DOT);
            Console.WriteLine($"  [{effect.Name}] hace {effect.DOT} de daño a {Name}. ({effect.TurnsRemaining - 1} turnos restantes)");
        
            //Reducimos Un Turno
            effect.TurnsRemaining--;

            //Si ya No Quedan Turnos Se Eliminan
            if (effect.TurnsRemaining <= 0)
            {
                Console.WriteLine($"[{effect.Name}] sobre {Name} Llegó A Su Fin");
                ActiveEffects.RemoveAt(i);
            }
        }
    }


    // --- MÉTODOS DE ENERGÍA ---

    // ¿Puede esta unidad pagar el costo de una acción?
    public bool CanAfford(BattleAction action)
    {
        return CurrentEnergy >= action.EnergyCost;
    }

    // Descuenta la energía. Solo llamar después de verificar CanAfford.
    public void ConsumeEnergy(BattleAction action)
    {
        CurrentEnergy -= action.EnergyCost;
        CurrentEnergy = System.Math.Max(0, CurrentEnergy);
    }

    // Recarga la energía al inicio del turno.
    public void RestoreEnergy()
    {
        CurrentEnergy = CurrentEnergy + 1;
        
        //Para Que No Se Pase
        CurrentEnergy = System.Math.Min(CurrentEnergy, MaxEnergy);
    }

}


   
   


