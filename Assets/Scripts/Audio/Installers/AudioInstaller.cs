using Zenject;
using UnityEngine;

namespace Audio
{
    [CreateAssetMenu(menuName = "SO/Installers/AudioInstaller", fileName = "AudioInstaller")]
    public class AudioInstaller : ScriptableObjectInstaller
    {
        [SerializeField] private AudioDatabaseAsset _audioDatabaseAsset;
        
        public override void InstallBindings()
        {
            Container.BindInstance(_audioDatabaseAsset);
            
            Container.BindInterfacesTo<AudioController>().AsSingle();
        }
    }
}

