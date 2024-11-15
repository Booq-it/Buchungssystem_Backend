namespace Buchungssystem_Backend.Scripts;
using System.Data.SQLite;

public class DB_Connect
{
    private string DB_File_Name = "JucktDochKeineSau.sqlite";
    private string DB_File_Path;

    private SQLiteConnection Database;

    public DB_Connect()
    {
        DB_File_Path = getProjectPath();
        Database = new SQLiteConnection($"Data Source={DB_File_Path}\\{DB_File_Name};Version=3;");
    }

    public void NewHighscore(string name, int score)
    {
        Database.Open();

        string sql = $"INSERT INTO highscores (name, score) values ('{name}', {score})";

        SQLiteCommand command = new SQLiteCommand(sql, Database);
        command.ExecuteNonQuery();

        Database.Close();
    }
    
    
    private static string getProjectPath()
    {
        var baseDir = new DirectoryInfo(AppContext.BaseDirectory);

        // Traverse up to the project root (assumes typical project structure)
        var projectRoot = baseDir.Parent?.Parent?.Parent;

        if (projectRoot == null)
        {
            Console.WriteLine("Project root could not be determined.");
            return "";
        }
        return Path.Combine(projectRoot.FullName, "Data");
    }

}