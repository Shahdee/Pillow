using System;

namespace Targets
{
    public abstract class AbstractTarget : ITarget
    {
        public event Action<ITarget> OnComplete;
        public abstract ETargetType TargetType { get; }

        public float Completion => _completion; 

        protected float _completion;
    }
}