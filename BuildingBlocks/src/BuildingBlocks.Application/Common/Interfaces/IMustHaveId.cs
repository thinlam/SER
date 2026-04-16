namespace BuildingBlocks.Application.Common.Interfaces;

public interface IMustHaveId<TKey>
{
    TKey GetId();
}
