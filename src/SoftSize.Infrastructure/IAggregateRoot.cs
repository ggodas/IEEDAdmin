namespace SoftSize.Infrastructure
{
    /// <summary>
    /// The only existence reason for this interface is to prevent the creation a Repository for
    /// entities that are not a aggregation.
    /// </summary>
    public interface IAggregateRoot{}
}
