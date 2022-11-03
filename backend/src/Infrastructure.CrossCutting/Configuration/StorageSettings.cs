namespace Infrastructure.CrossCutting.Configuration;

public record StorageSettings
{
    public SqlServerSettings SqlServer { get; set; }
}