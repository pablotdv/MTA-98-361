using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithTextFiles
{
    class Program
    {
        static void Main(string[] args)
        {
            string myDocumentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            CopyDataToTextFile($@"{myDocumentsPath}\CustomerList.txt");
            DisplayTextFile($@"{myDocumentsPath}\CustomerList.txt");
        }

        private static void DisplayTextFile(string fileName)
        {
            try
            {
                using(StreamReader sr = new StreamReader(fileName))
                {
                    string line;
                    while((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        private static void CopyDataToTextFile(string fileName)
        {
            try
            {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = connection.CreateCommand();
                command.CommandText = "select CustomerId, CompanyName, ContactName, Phone from Customers";
                using (connection)
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    using (StreamWriter sw = new StreamWriter(fileName))
                    {
                        while (reader.Read())
                        {
                            sw.WriteLine($"{reader.GetValue(0)},{reader.GetValue(1)},{reader.GetValue(2)},{reader.GetValue(3)}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
