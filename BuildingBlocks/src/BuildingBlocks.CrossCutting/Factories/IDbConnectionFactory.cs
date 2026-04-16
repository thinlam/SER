using System.Data;

namespace BuildingBlocks.CrossCutting.Factories;

public interface IDbConnectionFactory
{
    IDbConnection CreateConnection(string name = "DefaultConnection");
}