using QLDA.Persistence;

namespace QLDA.Migrator.ConfigurationOptions;

public class AppSettings {
    public ConnectionStrings ConnectionStrings { get; set; } = new ConnectionStrings();
    public string AllowedHosts { get; set; } = string.Empty;
}