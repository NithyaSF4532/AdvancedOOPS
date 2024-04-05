using System;
namespace OnlineGroceryStore;
class Program
{
    public static void Main(string[] args)
    {
       FileHandling.Create();
       Operations.AddDefaultDetails();
       
       Operations.MainMenu(); 
       FileHandling.WriteToCSV();
    }
}
