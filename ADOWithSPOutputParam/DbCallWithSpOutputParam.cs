using Microsoft.Data.SqlClient;

namespace ADOWithSPOutputParam;

internal static class DbCallWithSpOutputParam
{
    public static (int age, string name, string status) CallStoredProcWithOutputParam(int id)
    {
        using SqlConnection conn = new SqlConnection("Server=DESKTOP-0F0IUO7;Database=FirstAdoDemo;Trusted_Connection=True; TrustServerCertificate=True");
        SqlCommand command = new SqlCommand("CheckEmployeeAgeWithOutput", conn);
        command.CommandType = System.Data.CommandType.StoredProcedure;
        
        command.Parameters.AddWithValue("@EmployeeId", id);

        // Output Parameter
        SqlParameter ageparameter = new SqlParameter("@Age", System.Data.SqlDbType.Int)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        command.Parameters.Add(ageparameter);

        SqlParameter nameparameter = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 100)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        command.Parameters.Add(nameparameter);

        SqlParameter statusparameter = new SqlParameter("@Status", System.Data.SqlDbType.VarChar, 100)
        {
            Direction = System.Data.ParameterDirection.Output
        };
        command.Parameters.Add(statusparameter);

        conn.Open();

        command.ExecuteNonQuery();

        int age = (int)ageparameter.Value;
        string name = nameparameter.Value.ToString() ?? "";
        string status = statusparameter.Value.ToString() ?? "";

        return (age, name, status);
    }
}
