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
        
        public override void InstallBindings()
        {
            Container.Bind<MainWindowView>().FromComponentInNewPrefab(_mainView).AsSingle();
            Container.Bind<StoryWindowView>().FromComponentInNewPrefab(_storyWindowView).AsSingle();
            Container.Bind<WorkspaceWindowView>().FromComponentInNewPrefab(_workspaceWindowView).AsSingle();
            
            Container.BindInterfacesTo<WindowManager>().AsSingle();
            Container.BindInterfacesTo<UIController>().AsSingle();
            
            Container.BindInterfacesTo<MainWindow>().AsSingle();
            Container.BindInterfacesTo<StoryWindow>().AsSingle();
            Container.BindInterfacesTo<WorkspaceWindow>().AsSingle();
        }
    }
}