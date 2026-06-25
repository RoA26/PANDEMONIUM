//Character.cs
//Un Personaje Tiene Identidad Fija Y Puede Equipar Un Rol Intercambiable
//La identidad Nunca Cambia. El Rol Puede Cambiar Entre Runs

public abstract class Character
{
    public string Name;
    public int BaseHp;
    public int BaseEnergy;
    public Role? CurrentRole;

    protected Character(string name, int baseHp, int baseEnergy)
    {
         Name = name;
        BaseHp = baseHp;
        BaseEnergy = baseEnergy;
        CurrentRole = null;
    }

    public void EquipRole(Role role)
    {
        CurrentRole = role;
        Console.WriteLine($"{Name} Equipó El Rol: {role.Name}");
    }

    //Devuelve Las Acciones Del Rol Activo
    //Si No Tiene Rol Equipado, Devuelve La Lista Vacia.
    public List<BattleAction> GetActions()
    {
        if (CurrentRole == null)
        {
            Console.WriteLine($"{Name} no tiene rol equipado.");
            return new List<BattleAction>();
        }
        return CurrentRole.Actions;
    }
}