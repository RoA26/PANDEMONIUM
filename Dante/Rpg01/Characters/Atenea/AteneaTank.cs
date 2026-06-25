// AteneaTank.cs
// Atenea en modo Guardiana Divina.
// "Cada golpe que me das te cuesta más a ti."
// Escudos de luz estelar — protege y castiga.
public class AteneaTank : Role
{
    public AteneaTank() : base(
        name: "Tank",
        actions: new List<BattleAction>
        {
            new BattleAction(
                name: "Golpe Celestial",
                baseDmg: 14,
                ECost: 0,
                desc: "Impacto divino. Simple. Inevitable."
            ),
            new BattleAction(
                name: "Escudo Estelar",
                baseDmg: 0,
                ECost: 2,
                desc: "Espejito Rebotin.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Escudo", DoT: -8, duration: 3)
                },
                cooldown: 3
            ),
            new BattleAction(
                name: "Light That Burns The Sky",
                baseDmg: 60,
                ECost: 5,
                desc: "Ribombee pls survive.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Quemadura Estelar", DoT: 10, duration: 4),
                    new StatusEffect("Fracturado",        DoT:  6, duration: 3),
                    new StatusEffect("Fulminado",         DoT:  8, duration: 3)
                },
                cooldown: 5
            )
        }
    ) { }
}