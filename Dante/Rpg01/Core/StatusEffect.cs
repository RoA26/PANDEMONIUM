//StatusEffect.cs
//Representa Los Dots
public class StatusEffect
{
    public string Name;         //Nombre Del Dot
    public int DOT;             //Daño Over Time (Negativo = Curacion)
    public int TurnsRemaining;  //Turnos Que Le Quedan Al Dot

    public StatusEffect(string name, int DoT, int duration)
    {
        Name = name;
        DOT = DoT;
        TurnsRemaining = duration;
    }
}