//ActionResult.cs
//Resultado De BattleAction.
//Reporte De Lo Que Va Pasando

public class ActionResult
{
    //---- DATOS ---

    //Nombre De Acción Ejecutada Para mostrar En Consola o En Ui.
    public string ActionName;

    //Cuanto Daño Hizo Realmente
    public int DamageDealt;

    //Verifica Si El Objetivo Murio Con La Accion
    public bool TargetDied;

    //Mensaje Descriptivo De Lo Que Pasó.
    public string Message;

    //----CONSTRUCTOR----
    public ActionResult(string ActName, int DmgDealt, bool  targetDied, string msg)
    {
        ActionName = ActName;
        DamageDealt = DmgDealt;
        TargetDied = targetDied;
        Message = msg;
    }

    //--- MÉTODO ---

    //Muestra el Resultado En Consola
    public void PrintResult()
    {
        Console.WriteLine($">>{Message}");
        Console.WriteLine($"    Daño: {DamageDealt} | Objetivo Eliminado: {TargetDied}");
    }

}