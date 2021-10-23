using Zenject;

namespace Helpers
{
    public class HelperInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<MonoMediator>().AsSingle();
            Container.BindInterfacesTo<CoroutineManager>().AsSingle();
        }
    }
}