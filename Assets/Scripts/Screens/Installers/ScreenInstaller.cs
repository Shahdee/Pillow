using Chapters;
using UnityEngine;
using Zenject;

namespace Screens
{
    
    public class ScreenInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesTo<ScreenController>().AsSingle();
        }
    }
}