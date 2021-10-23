using Zenject;

namespace Input
{
    public class InputInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
#if UNITY_STANDALONE || UNITY_EDITOR || UNITY_WEBGL
            Container.BindInterfacesTo<MobileInputController>().AsSingle();
#else
            Container.BindInterfacesTo<PCInputController>().AsSingle();
#endif
        }
    }
}