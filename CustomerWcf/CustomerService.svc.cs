using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace CustomerWcf
{
    public class CustomerService : ICustomerService
    {
        SqlConnection conn = new SqlConnection("Data Source=LPTP387;Initial Catalog=Customer;Integrated Security=True");
        SqlCommand cmd;

        public object JsonConvert { get; private set; }

        public List<Customer> GetAllCustomer()
        {
            List<Customer> customers = new List<Customer>();

            cmd = new SqlCommand("select * from customer_data", conn);
            conn.Open();

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Customer c = new Customer();

                c.id = int.Parse(sdr["id"].ToString());
                c.name = sdr["name"].ToString();
                c.accountNo = sdr["accountNo"].ToString();
                c.activeData = sdr["activeData"].ToString();
                c.customerRank = sdr["customerRank"].ToString();
                c.customerType = sdr["customerType"].ToString();
                c.customerStatus = sdr["customerStatus"].ToString();
                c.gender = sdr["gender"].ToString();
                c.DOB = sdr["DOB"].ToString();
                c.ntn = sdr["ntn"].ToString();

                customers.Add(c);

            }
            sdr.Close();
            conn.Close();


            return customers;
        }

        public Customer InsertCustomer(Customer c)
        {
            cmd = new SqlCommand("insert into customer_data values ( @name, @accountNo, @activeData, @customerRank, @customerType, @customerStatus, @gender, @DOB, @ntn) ", conn);
           // cmd.Parameters.AddWithValue("@id", (c.id));
            cmd.Parameters.AddWithValue("@name", c.name);
            cmd.Parameters.AddWithValue("@accountNo", c.accountNo);
            cmd.Parameters.AddWithValue("@activeData", c.activeData);
            cmd.Parameters.AddWithValue("@customerRank", c.customerRank);
            cmd.Parameters.AddWithValue("@customerType", c.customerType);
            cmd.Parameters.AddWithValue("@customerStatus", c.customerStatus);
            cmd.Parameters.AddWithValue("@gender", c.gender);
            cmd.Parameters.AddWithValue("@DOB", c.DOB);
            cmd.Parameters.AddWithValue("@ntn", c.ntn);

            conn.Open();

            cmd.ExecuteNonQuery();

            conn.Close();

            return c;
        }


        public string DeleteCustomer(string id)
        {
            int ID = int.Parse(id);

            cmd = new SqlCommand("delete customer_data where id=@id", conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", ID);

            int status = cmd.ExecuteNonQuery();
            conn.Close();
            if (status == 1)
            {
                return "success";
            }

            else
            {
                return "failed";
            }
        }

        public Customer UpdateCustomer(Customer c)
        {
            

            cmd = new SqlCommand("update customer_data set name=@name, accountNo=@accountNo, activeData=@activeData, customerRank=@customerRank, customerType=@customerType, customerStatus=@customerStatus, gender=@gender, DOB=@DOB, ntn=@ntn where id=@id", conn);
           
            conn.Open();

            cmd.Parameters.AddWithValue("@id", (c.id));
            cmd.Parameters.AddWithValue("@name", c.name);
            cmd.Parameters.AddWithValue("@accountNo", c.accountNo);
            cmd.Parameters.AddWithValue("@activeData", c.activeData);
            cmd.Parameters.AddWithValue("@customerRank", c.customerRank);
            cmd.Parameters.AddWithValue("@customerType", c.customerType);
            cmd.Parameters.AddWithValue("@customerStatus", c.customerStatus);
            cmd.Parameters.AddWithValue("@gender", c.gender);
            cmd.Parameters.AddWithValue("@DOB", c.DOB);
            cmd.Parameters.AddWithValue("@ntn", c.ntn);


            int status = cmd.ExecuteNonQuery();
            conn.Close();
            if (status == 1)
            {

                return c;

            }
            else
            {
                return null;
            }
        }

        public List<Customer> GetCustomerById(string id)
        {
            int ID = int.Parse(id);

            List<Customer> customers = new List<Customer>();

            cmd = new SqlCommand("select * from customer_data where id=@id", conn);
            conn.Open();

            cmd.Parameters.AddWithValue("@id", ID);

            SqlDataReader sdr = cmd.ExecuteReader();

            while (sdr.Read())
            {
                Customer c = new Customer();

                c.id = int.Parse(sdr["id"].ToString());
                c.name = sdr["name"].ToString();
                c.accountNo = sdr["accountNo"].ToString();
                c.activeData = sdr["activeData"].ToString();
                c.customerRank = sdr["customerRank"].ToString();
                c.customerType = sdr["customerType"].ToString();
                c.customerStatus = sdr["customerStatus"].ToString();
                c.gender = sdr["gender"].ToString();
                c.DOB = sdr["DOB"].ToString();
                c.ntn = sdr["ntn"].ToString();

                customers.Add(c);

            }
            sdr.Close();
            conn.Close();

            return customers;
        }
    }
}
