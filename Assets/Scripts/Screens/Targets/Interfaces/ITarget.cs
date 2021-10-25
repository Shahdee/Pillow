using System;

namespace Targets
{
    public interface ITarget 
    {
        event Action<ITarget> OnComplete;
        ETargetType TargetType { get; }

        float Completion { get; }
    }
}

