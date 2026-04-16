namespace BuildingBlocks.Domain.Interfaces;

public interface IMayHaveMa
{
    string? Ma { get; set; }
}
public interface IMustHaveMa
{
    string Ma { get; set; }
}
