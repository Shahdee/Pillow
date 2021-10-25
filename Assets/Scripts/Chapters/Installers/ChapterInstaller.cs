using Zenject;
using UnityEngine;

namespace Chapters
{
    [CreateAssetMenu(menuName = "SO/Installers/ChapterInstaller", fileName = "ChapterInstaller")]
    public class ChapterInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private ChapterDatabaseAsset chapterDatabaseAsset;
        
        public override void InstallBindings()
        {
            Container.BindInstance(chapterDatabaseAsset);
            
            Container.BindInterfacesTo<ChapterController>().AsSingle();
            Container.BindInterfacesTo<ChapterDataProvider>().AsSingle();
        }
    }
}