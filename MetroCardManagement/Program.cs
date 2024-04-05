using System;
namespace MetroCardManagement;
class Program
{
    public static void Main(string[] args)
    {
       FileHandling.create();
       Operations.AddDefaultDetails(); 
       Operations.MainMenu();
       
    }
}
