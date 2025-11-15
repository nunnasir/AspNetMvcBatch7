
namespace DependencyLifetime;

public class TransiantOperation : IOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}

public class ScopedOperation : IOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}

public class SingleTonOperation : IOperation
{
    public Guid OperationId { get; } = Guid.NewGuid();
}
