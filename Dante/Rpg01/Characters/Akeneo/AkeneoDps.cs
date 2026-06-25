//AkeneoDps.cs
//Akeneo Modo Destrucción
//Taladro, Cañon, Corrosión Mech

public class AkeneoDps : Role
{
    public AkeneoDps() : base(
        name: "DPS",
        actions: new List<BattleAction>
        {
            new BattleAction(
                name: "Puño Mécanico",
                baseDmg: 14,
                ECost: 0,
                desc: "Metal Con Hueso Duele"
            ),

            new BattleAction(
                name: "Cañon De Iones Alvg",
                baseDmg: 33,
                ECost: 2,
                desc: "Plomo Rapatumadre",
                effects: new List<StatusEffect>
            {
             new StatusEffect("Veneno", DoT: 5, duration: 3),
             new StatusEffect("Sangrado", DoT: 5 , duration:3),
             new StatusEffect("Electrificado", DoT: 14 , duration:3)
            }
            ),
            new BattleAction(
                name: "Taladro Perforador",
                baseDmg: 25*2,
                ECost: 3,
                desc: "Si existe una defensa, la atravieso.",
                effects: new List<StatusEffect>
                {
                    new StatusEffect("Corrosión", DoT: 4, duration: 3)
                },
                cooldown: 3
            )

        }
    ){}
}