using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Back_Employees.Models
{
    public class gestoEmployees
    {
        public List<Employees> getEmployees()
        {
            List<Employees> employeesList = new List<Employees>();
        string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ConnectionString;

        using (SqlConnection conn = new SqlConnection(strConn))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = "EmployeesAll";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int Id = reader.GetInt32(0);
                    string Nombre = reader.GetString(1);
                    string FechaNacimiento = reader.GetString(2);
                    int Edad = reader.GetInt32(3);
                    string Posicion = reader.GetString(4);
                    bool Estatus = Convert.ToBoolean(reader["Estatus"]);

                    Employees employees = new Employees(Id,Nombre,FechaNacimiento,Edad,Posicion,Estatus);
                    employeesList.Add(employees);
                }
                reader.Close();
                conn.Close();
            
            }return employeesList;
        }
        public bool insertEmployees(Employees employees)
        {
            bool resp = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "EmployeesInsert";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Nombre", employees.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", employees.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", employees.Edad);
                cmd.Parameters.AddWithValue("@Posicion", employees.Posicion);
                cmd.Parameters.AddWithValue("@Estatus", employees.Estatus);

                try 
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;
                 } catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally 
                {
                    cmd.Parameters.Clear(); 
                    conn.Close();
                }

            }
            return resp;
        }
        public bool updateEmployees(int id, Employees employees)
        {
            bool resp = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "EmployeesUpdate";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue ("@Id", id);
                cmd.Parameters.AddWithValue("@Nombre", employees.Nombre);
                cmd.Parameters.AddWithValue("@FechaNacimiento", employees.FechaNacimiento);
                cmd.Parameters.AddWithValue("@Edad", employees.Edad);
                cmd.Parameters.AddWithValue("@Posicion", employees.Posicion);
                cmd.Parameters.AddWithValue("@Estatus", employees.Estatus);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

            }
            return resp;
        }
        public bool deleteEmployees(int id)
        {
            bool resp = false;

            string strConn = ConfigurationManager.ConnectionStrings["BDLocal"].ToString();

            using (SqlConnection conn = new SqlConnection(strConn))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                cmd.CommandText = "EmployeesDelete";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Id", id);

                try
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    resp = true;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    resp = false;
                    throw;
                }
                finally
                {
                    cmd.Parameters.Clear();
                    conn.Close();
                }

            }
            return resp;
        }


    }
}