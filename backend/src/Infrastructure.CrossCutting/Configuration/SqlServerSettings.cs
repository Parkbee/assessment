namespace Infrastructure.CrossCutting.Configuration;

public record SqlServerSettings
{
    public string Host { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Database { get; set; }

    public string ConnectionString => $"Server={Host};Database={Database};User Id={UserName};Password={Password};";
}