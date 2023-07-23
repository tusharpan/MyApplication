using System.Data;
using System.Data.SqlClient;

namespace MyApplication.Models
{
    public class Employee
    {

        public int Id { get; set; } 
        public string Name { get; set; }

        public decimal Basic { get; set; }

       

            //stored procedure
            public static void Insert(Employee obj)
            {
            Console.WriteLine("okay1");
            SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                cn.Open();
            Console.WriteLine("okay2");

            try
                {
                    //SqlCommand cmd = cn.CreateCommand();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = "InsertEmployee";
                 
                    cmd.Parameters.AddWithValue("@Id", obj.Id);
                    cmd.Parameters.AddWithValue("@Name", obj.Name);
                    cmd.Parameters.AddWithValue("@Basic", obj.Basic);
                Console.WriteLine(123);

                    cmd.ExecuteNonQuery();

                    Console.WriteLine("okay");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }

        public static List<Employee> GetEmployee()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetAllEmployee";

                SqlDataReader dr = cmd.ExecuteReader();
                List<Employee> list = new List<Employee>();
                Employee obj;
                while (dr.Read())
                {
                    obj = new Employee();
                    obj.Id = dr.GetInt32("Id");
                    obj.Name = dr.GetString("Name");
                    obj.Basic = dr.GetDecimal("Basic");
                    list.Add(obj);

                }

                dr.Close();
                //cmd.ExecuteNonQuery();

                Console.WriteLine("okay");
                return list;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }

        public static List<Employee> DeleteEmp(int Id)
        {
          
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
          

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "DeleteEmployee";

                cmd.Parameters.AddWithValue("@Id", Id);
               
              
                List<Employee> list = new List<Employee>();
                list = Employee.GetEmployee();
                cmd.ExecuteNonQuery();
                return list;

          
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }


        public static List<Employee> UpdateEmp(Employee obj)
        {

            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();
            Console.WriteLine("update hua executte");

            try
            {
                //SqlCommand cmd = cn.CreateCommand();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "UpdateEmployee";

                cmd.Parameters.AddWithValue("@Id", obj.Id);
                cmd.Parameters.AddWithValue("@Name", obj.Name);
                cmd.Parameters.AddWithValue("@Basic",obj.Basic);
               


                List<Employee> list = new List<Employee>();
                list = Employee.GetEmployee();
                cmd.ExecuteNonQuery();
                Console.WriteLine(list);
                return list;


            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }
            finally
            {
                cn.Close();
            }
        }


        public static Employee GetEmployeeById(int Id)
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=MyDataBase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            cn.Open();

            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetEmployeeById";
                cmd.Parameters.AddWithValue("@Id", Id);

                SqlDataReader dr = cmd.ExecuteReader();
                
                Employee obj;
                if (dr.Read())
                {
                    obj = new Employee();
                    obj.Id = dr.GetInt32("Id");
                    obj.Name = dr.GetString("Name");
                    obj.Basic = dr.GetDecimal("Basic");
                    return obj;
                    dr.Close();
                }

                return null;
               

                Console.WriteLine("okay");
               
            }
            catch (Exception ex)
            {
                Employee obj= new Employee();
                Console.WriteLine(ex.Message);
                return obj;
            }
            finally
            {
                cn.Close();
            }
        }


    }

}

