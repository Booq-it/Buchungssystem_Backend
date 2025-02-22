
namespace Buchungssystem_Backend.Scripts;
public class Backend_Main
{
    public static void Main(string[] args)
    {
        DB_Connect db = new DB_Connect();

        db.NewHighscore("Ben", -99);

    }
    

    
}
