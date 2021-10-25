namespace Targets
{
    public interface ITargetFactory
    {
        ITarget CreateTarget(ETargetType targetType);
    }
}