﻿using AdminEmpleadoEntidades;
using System.Data.SqlClient;
namespace AdminEmpleadosDatos
{
    public class EmpleadosDatos
    {
        public static List<Empleado> Get(Empleado e)
        {
            List<Empleado> list = new List<Empleado>();
            string conString = System.Configuration.ConfigurationManager.
            ConnectionStrings["conexionDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(conString))
            {
                // Create the Command and Parameter objects.
                SqlCommand command = new SqlCommand("empleadosGet", connection);
                command.CommandType = System.Data.CommandType.StoredProcedure;
                if (e.id != null)
                    command.Parameters.AddWithValue("@id", e.id);
                if (e.nombre != null)
                    command.Parameters.AddWithValue("@nombre_apellido", e.nombre);
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Empleado emp = new Empleado();
                        emp.id = Convert.ToInt32(reader["id"]);
                        emp.nombre = Convert.ToString(reader["nombre_apellido"]);
                        emp.dni = Convert.ToString(reader["dni"]);
                        if (reader["direccion"].GetType() != typeof(DBNull))
                            emp.direccion = Convert.ToString(reader["direccion"]);
                        if (reader["fecha_ingreso"].GetType() != typeof(DBNull))
                            emp.fechaIngreso = Convert.ToDateTime(reader["fecha_ingreso"]);
                        if (reader["salario"].GetType() != typeof(DBNull))
                            emp.salario = Convert.ToDecimal(reader["salario"]);
                        if (reader["nombre_dpto"].GetType() != typeof(DBNull))
                        {
                            Departamento dep = new Departamento();
                            dep.id = 0;
                            dep.Nombre = Convert.ToString(reader["nombre_dpto"]);
                            emp.Departamento = dep;
                        }
                        list.Add(emp);
                    }
                    reader.Close();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return list;
        }
    }
}