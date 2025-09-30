using FirstAdoDemoApp.Models;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;
using Microsoft.Data.SqlClient;

namespace FirstAdoDemoApp;

public class EmployeeDataAccessLayerWithSp
{
    string connString = ConnectionString.GetConnectionString();

    public List<Employee> GetEmployees()
    {
        List<Employee> lstEmployees = new List<Employee> ();

        using SqlConnection conn = new SqlConnection(connString);
        string query = "SpGetEmployees";
        SqlCommand command = new SqlCommand(query, conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;

        conn.Open();
        SqlDataReader reader = command.ExecuteReader();

        while (reader.Read()) 
        {
            Employee employee = new Employee();
            employee.Id = Convert.ToInt32(reader["id"]);
            employee.Name = reader["name"].ToString() ?? string.Empty;
            employee.Gender = reader["gender"].ToString() ?? string.Empty;
            employee.Age = Convert.ToInt32(reader["age"]);
            employee.City = reader["city"].ToString() ?? string.Empty;
            employee.Designation = reader["designation"].ToString() ?? string.Empty;

            lstEmployees.Add(employee);
        }

        return lstEmployees;
    }

    public void AddEmployee(Employee employee)
    {
        using SqlConnection conn = new SqlConnection(connString);
        //string query = $"INSERT INTO Employees(name, gender, age, city, designation) " +
        //    $"VALUES('{employee.Name}', '{employee.Gender}', {employee.Age}, '{employee.City}', '{employee.Designation}')";

        SqlCommand command = new SqlCommand("SPCreateEmployee", conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        command.Parameters.AddWithValue("name", employee.Name);
        command.Parameters.AddWithValue("gender", employee.Gender);
        command.Parameters.AddWithValue("age", employee.Age);
        command.Parameters.AddWithValue("city", employee.City);
        command.Parameters.AddWithValue("designation", employee.Designation);

        conn.Open();
        command.ExecuteNonQuery();
    }

    public Employee GetEmployee(int id)
    {
        Employee employee = new Employee();

        using SqlConnection conn = new SqlConnection(connString);

        string query = $"SELECT * FROM Employees where id = @id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("id", id);

        conn.Open();
        SqlDataReader reader = command.ExecuteReader();
        
        while (reader.Read())
        {
            employee.Id = Convert.ToInt32(reader["id"]);
            employee.Name = reader["name"].ToString() ?? string.Empty;
            employee.Gender = reader["gender"].ToString() ?? string.Empty;
            employee.Age = Convert.ToInt32(reader["age"]);
            employee.City = reader["city"].ToString() ?? string.Empty;
            employee.Designation = reader["designation"].ToString() ?? string.Empty;
        }

        return employee;
    }

    public void UpdateEmployee(Employee employee)
    {
        using SqlConnection conn = new SqlConnection(connString);
        
        string query = "Update Employees set name = @name, gender = @gender, age = @age, designation = @designation, city = @city where id = @Id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("name", employee.Name);
        command.Parameters.AddWithValue("gender", employee.Gender);
        command.Parameters.AddWithValue("age", employee.Age);
        command.Parameters.AddWithValue("city", employee.City);
        command.Parameters.AddWithValue("designation", employee.Designation);
        command.Parameters.AddWithValue("id", employee.Id);

        conn.Open();
        command.ExecuteNonQuery();
    }

    public void DeleteEmployee(int id)
    {
        using SqlConnection conn = new SqlConnection(connString);

        string query = "DELETE FROM Employees where id = @Id";
        SqlCommand command = new SqlCommand(query, conn);
        command.Parameters.AddWithValue("id", id);

        conn.Open();
        command.ExecuteNonQuery();
    }
}
