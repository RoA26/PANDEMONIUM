//Role.cs
//El Rol Es Un Paquete De Combate Intercambiable
//Define Las Acciones Que Tiene Disponible Un Personaje En Combate
//El Personaje Define Quien Es, El Rol COmo Pelea

public abstract class Role
{
    public string Name;
    public List<BattleAction> Actions;

    protected Role(string name, List<BattleAction> actions)
    {
        Name = name;
        Actions = actions;
    }
}