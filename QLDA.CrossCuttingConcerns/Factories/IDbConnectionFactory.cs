using System.Data;

namespace SharedKernel.CrossCuttingConcerns.Factories;

public interface IDbConnectionFactory {
    IDbConnection CreateConnection(string name = "DefaultConnection");
}