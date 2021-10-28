using UnityEngine;
using System.Linq;

namespace Audio
{
    public class AudioController : IAudioController
    {
        private readonly AudioDatabaseAsset _audioDatabaseAsset;
        private readonly AudioSource _sound;

        public AudioController(AudioDatabaseAsset audioDatabaseAsset)
        {
            _audioDatabaseAsset = audioDatabaseAsset;
            _sound = new GameObject("_Sound").AddComponent<AudioSource>();
            _sound.playOnAwake = false;
        }

        public void PlaySound(ESoundType soundType)
        {
            var audio = _audioDatabaseAsset.AudioDatas.FirstOrDefault(x => x.SoundType == soundType);
            if (audio == null)
                return;
            
            _sound.PlayOneShot(audio.Clip);
        }
    }
}