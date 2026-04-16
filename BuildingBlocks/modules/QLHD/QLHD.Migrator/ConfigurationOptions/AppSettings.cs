using QLHD.Persistence;

namespace QLHD.Migrator.ConfigurationOptions;

public class AppSettings
{
    public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
}