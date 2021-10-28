using UnityEngine;
using System.Collections.Generic;

namespace Audio
{
    [CreateAssetMenu(fileName = "AudioDatabase" , menuName =  "SO/AudioDatabase")]
    public class AudioDatabaseAsset : ScriptableObject
    {
        public IReadOnlyList<AudioData> AudioDatas => _audioDatas;

        [SerializeField] private List<AudioData> _audioDatas;
    }
}