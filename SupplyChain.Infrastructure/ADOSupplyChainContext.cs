using SupplyChain.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupplyChain.Infrastructure
{
    public class ADOSupplyChainContext
    {
        SqlConnection connection;
        SqlDataAdapter adapter;
        DataTable dt;
        //SqlCommand command;
        private readonly string connectionString;

        public IEnumerable<Customer> Customers { get { return this.GetCustomers(); } }

        public IEnumerable<Supplier> Suppliers { get { return this.GetSuppliers(); } }

        public IEnumerable<SalesOrderHeader> Orders;

        public IEnumerable<SalesOrderDetail> OrdersDetails;

        public ADOSupplyChainContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        private void InitializeDatabaseConnection()
        {
            this.connection = new SqlConnection(this.connectionString);
            //new SqlDataAdapter adapter;
            //new DataTable dt;
            //new SqlCommand command;
        }

        //public List<OrderHeader> Orders()
        //{
        //    var result = new List<OrderHeader>();
        //    return result;
        //}

        public List<SalesOrderDetail> OrderDetails()
        {
            var result = new List<SalesOrderDetail>();
            return result;
        }

        #region Customers
        private List<Customer> GetCustomers()
        {
            string select = "Select Id, Name, Address_Street, Address_ZipCode, Address_State From Customers";
            var result = new List<Customer>();
            adapter = new SqlDataAdapter(select, this.connectionString);
            dt = new DataTable();
            adapter.Fill(dt);
            result.AddRange(this.ConvertToListOfCustomers(dt));
            return result;
        }

        private List<Customer> ConvertToListOfCustomers(DataTable dt)
        {
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = int.Parse(dt.Rows[i][0].ToString());
                string name = dt.Rows[i][1].ToString();
                string street = dt.Rows[i][2].ToString();
                string zipcode = dt.Rows[i][3].ToString();
                string state = dt.Rows[i][4].ToString();
                var customerAddress = new Address { Street = street, ZipCode = zipcode, State = state };
                var customer = new Customer { Id = id, Name = name, Address = customerAddress };
                customers.Add(customer);
            } 
            return customers;
        }

        #endregion

        #region Suppliers
        private List<Supplier> GetSuppliers()
        {
            string select = "Select Id, Name, Address_Street, Address_ZipCode, Address_State From Customers";
            var result = new List<Supplier>();
            adapter = new SqlDataAdapter(select, this.connectionString);
            dt = new DataTable();
            adapter.Fill(dt);
            result.AddRange(this.ConvertToListOfSuppliers(dt));
            return result;
        }

        private List<Supplier> ConvertToListOfSuppliers(DataTable dt)
        {
            List<Supplier> suppliers = new List<Supplier>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                int id = int.Parse(dt.Rows[i][0].ToString());
                string name = dt.Rows[i][1].ToString();
                string street = dt.Rows[i][2].ToString();
                string zipcode = dt.Rows[i][3].ToString();
                string state = dt.Rows[i][4].ToString();
                var supplierAddress = new Address { Street = street, ZipCode = zipcode, State = state };
                var supplier = new Supplier { Id = id, Name = name, Address = supplierAddress };
                suppliers.Add(supplier);
            }
            return suppliers;
        }
        #endregion

    }
}
