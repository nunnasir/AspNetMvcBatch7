namespace FirstAdoDemoApp;

public static class ConnectionString
{
    private static string _connectionString = "Server=DESKTOP-0F0IUO7;Database=FirstAdoDemo;Trusted_Connection=True; TrustServerCertificate=True";

    public static string GetConnectionString()
    {
        return _connectionString;
    }
}
