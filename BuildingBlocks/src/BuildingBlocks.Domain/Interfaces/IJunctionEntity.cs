namespace BuildingBlocks.Domain.Interfaces {
    public interface IJunctionEntity<LeftIdType, RightIdType>
    where LeftIdType : notnull
    where RightIdType : notnull {
        public LeftIdType LeftId { get; set; }
        public RightIdType RightId { get; set; }

    }
}