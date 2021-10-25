namespace Targets
{
    public class TargetFactory : ITargetFactory
    {
        public TargetFactory()
        {
            
        }
        
        public ITarget CreateTarget(ETargetType targetType)
        {
            switch (targetType)
            {
                case ETargetType.TapToEnd:
                    return  new TapTarget();
                
                default:
                    return null;
            }

            return null;
        }
    }
}