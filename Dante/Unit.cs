//Unit.cs
//Esta Clase Representa Cualquier Entidad Que Participa En Combate.
// Puede Ser Un Jugador, Un Enemigo o Cualquier Cosa En El Futuro.


public class Unit
{
    //--- DATOS BÁSICOS ---

    //El Nombre De La Unidad. (Para Identificar Por Consola Por Ahora)
    public string Name;

    //HP Actual. Empieza Como El Maximo, Baja Al Recibir Daño
    public int CurrentHp;

    //HP Maximo.
    public int MaxHp;

    //Daño De Ataque  Basico De Esta Unidad.
    public int BaseAtk;


    // --- CONSTRUCTOR ---
    // Un constructor es el "molde" que usamos para crear una Unit.
    // En lugar de escribir los valores uno por uno después de crear el objeto,
    // los pasamos todos de una vez aquí.

    public Unit(string name, int maxHp, int baseAtk)
    {
        Name = name;
        MaxHp = maxHp;
        CurrentHp = maxHp;
        BaseAtk = baseAtk;
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
        Console.WriteLine($"{Name} - HP: {CurrentHp}/{MaxHp} | ATK: {BaseAtk}");
    }
}

