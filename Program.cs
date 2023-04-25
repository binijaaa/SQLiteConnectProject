using Microsoft.Data.Sqlite;

namespace SQLiteConnectProject
{
    internal class Program
    {
        static void Main(string[] args)
        {
  
            using (var connection = new SqliteConnection("Data Source=C:\\SQL Lite\\gui\\SQLiteStudio\\bookstores.db")) //give path to where the db is
            {
                Console.WriteLine("Please type bookid: ");
                var id = Console.ReadLine();

                //getting var 'reader'to get the data
                connection.Open();

                //now we need command to send from C# to our database
                var command = connection.CreateCommand();
                command.CommandText =
                    @"SELECT * FROM book WHERE bookid =$id;"; //this syntax is to ignore all escape characters (verbatim literal - @)

               

                command.Parameters.AddWithValue("id", id); //takes value and searches for a match in database

                using (var reader = command.ExecuteReader()) //getting var 'reader'to get the data
                {
                    while (reader.Read())
                    {
                        var bookid = reader.GetString(0);
                        var title = reader.GetString(1);
                        var year = reader.GetString(2);
                        var publisher = reader.GetString(3);


                        Console.WriteLine($"Book id: {bookid}");
                        Console.WriteLine($"Title: {title}");
                        Console.WriteLine($"Year published: {year}");
                        Console.WriteLine($"Publisher: {publisher}");
                    }
                }
            }
        }
    }
}