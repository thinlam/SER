namespace BuildingBlocks.Domain.Interfaces;

public interface ITrackable
{
    byte[] RowVersion { get; set; }
}
