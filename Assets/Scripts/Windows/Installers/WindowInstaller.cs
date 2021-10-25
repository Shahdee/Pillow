using UnityEngine;
using Zenject;

namespace Windows
{
    [CreateAssetMenu(fileName = "WindowInstaller",  menuName = "SO/Installers/WindowInstaller")]
    public class WindowInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private MainWindowView _mainView;
        [SerializeField] private StoryWindowView _storyWindowView;
        [SerializeField] private WorkspaceWindowView _workspaceWindowView;
        [SerializeField] private ScreenWindowView _screenWindowView;
        
        public override void InstallBindings()
        {
            Container.Bind<MainWindowView>().FromComponentInNewPrefab(_mainView).AsSingle();
            Container.Bind<StoryWindowView>().FromComponentInNewPrefab(_storyWindowView).AsSingle();
            Container.Bind<WorkspaceWindowView>().FromComponentInNewPrefab(_workspaceWindowView).AsSingle();
            Container.Bind<ScreenWindowView>().FromComponentInNewPrefab(_screenWindowView).AsSingle();
            
            Container.BindInterfacesTo<WindowManager>().AsSingle();
            Container.BindInterfacesTo<UIController>().AsSingle();
            
            Container.BindInterfacesTo<MainWindow>().AsSingle();
            Container.BindInterfacesTo<StoryWindow>().AsSingle();
            Container.BindInterfacesTo<ScreenWindow>().AsSingle();
            Container.BindInterfacesTo<WorkspaceWindow>().AsSingle();
        }
    }
}