
// AteneaDpsRole.cs
// Atenea en modo destrucción estelar.
// "No necesito moverme para destruirte."
// Cristales de luz estelar — elegante y letal.
public class AteneaDps : Role
{
    public AteneaDps() : base(
        name: "DPS",
        actions: new List<BattleAction>
        {
            new BattleAction(
                name: "Destello Estelar",
                baseDmg: 18,
                ECost: 0,
                desc: "Luz que corta sin esfuerzo."
            ),
            new BattleAction(
                name: "Lluvia de Meteoros",
                baseDmg: 28,
                ECost: 2,
                desc: "Fragmentos de luz estelar.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Desgarrado", DoT: 6, duration: 3)
                },
                cooldown: 2
            ),
            new BattleAction(
                name: "Nova Estelar",
                baseDmg: 45,
                ECost: 4,
                desc: "Una estrella colapsa sobre el enemigo.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Quemadura Estelar", DoT: 8, duration: 3),
                    new StatusEffect("Fracturado",        DoT: 5, duration: 2)
                },
                cooldown: 4
            )
        }
    ) { }
}