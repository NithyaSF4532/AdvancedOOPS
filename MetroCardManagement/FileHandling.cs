using System;
using System.IO;
namespace MetroCardManagement;
public class FileHandling
{
    public static void create()
    {
        if(!Directory.Exists("MetroCardManagement"))
            {
                Console.WriteLine("Creating Folder");
                Directory.CreateDirectory("MetroCardManagement");
            }
            //file for user info
            if(!File.Exists("MetroCardManagement/UserDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("MetroCardManagement/UserDetails.csv").Close();
            }
            //file for travel info
             if(!File.Exists("MetroCardManagement/TravelDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("MetroCardManagement/TravelDetails.csv").Close();
            }
            //file for Ticket info
             if(!File.Exists("MetroCardManagement/TicketFairDetails.csv"))
            {
                Console.WriteLine("Craeting file....");
                File.Create("MetroCardManagement/TicketFairDetails.csv").Close();
            }
    }
}