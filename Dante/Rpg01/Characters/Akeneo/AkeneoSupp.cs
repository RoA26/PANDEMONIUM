//AkeneoSupp.cs
//Rockero Inmortal
//Daño sonico + buffs de equipo + debuffs al enemigo.

public class AkeneoSupp : Role
{
    public AkeneoSupp() : base(
        name : "Support",
        actions: new List<BattleAction>
        {
            new BattleAction(
                name: "Guitarrazo",
                baseDmg:  12,
                ECost: 0,
                desc: "Toma Tu Guitarrazo"

            ),
             new BattleAction(
                name: "Switch All Of Mine",
                baseDmg: 15,
                ECost: 3,
                desc: "El amplificador explota. Todo arde.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Quemadura", DoT: 6, duration: 3),
                    new StatusEffect("Aturdido",  DoT: 3, duration: 2)
                },
                cooldown: 4
            ),
             new BattleAction(
                name: "La Noche Brillara",
                baseDmg: 20,
                ECost: 2,
                desc: "Descarga sónica y eléctrica.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Electrificado", DoT: 8, duration: 3)
                },
                cooldown: 2
             )
            
        }
    ){}
}