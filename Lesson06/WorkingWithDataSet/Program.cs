using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorkingWithDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            WorkingWithDataSet();
        }

        private static void WorkingWithDataSet()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\Database\NORTHWND.MDF;Integrated Security=True;Connect Timeout=30";
            SqlConnection connection = new SqlConnection(connectionString);
            string customerCommandText = "select * from customers";
            SqlDataAdapter customerAdapter = new SqlDataAdapter(customerCommandText, connection);
            string ordersCommandText = "select * from Orders";
            SqlDataAdapter ordersAdapter = new SqlDataAdapter(ordersCommandText, connection);
            DataSet customerOrders = new DataSet();
            customerAdapter.Fill(customerOrders, "Customers");
            ordersAdapter.Fill(customerOrders, "Orders");
            DataRelation relation = customerOrders.Relations.Add("CustomerOrders",
                customerOrders.Tables["Customers"].Columns["CustomerID"],
                customerOrders.Tables["Orders"].Columns["CustomerID"]);
            foreach(DataRow customerRow in customerOrders.Tables["Customers"].Rows)
            {
                Console.WriteLine(customerRow["CustomerID"]);
                foreach (DataRow orderRow in customerRow.GetChildRows(relation))
                {
                    Console.WriteLine($"\t{orderRow["OrderID"]}");
                }
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadLine();
        }
    }
}
