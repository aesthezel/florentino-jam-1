using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace GamePlay.Audio
{
    [CreateAssetMenu(fileName = "Single Sound Event", menuName = "Game/Audio/SingleSoundEvent", order = 0)]
    public class SingleSoundEventScriptable : ScriptableObject, IFMODEvent
    {
        [field: SerializeField] public EventReference Reference { get; private set; }
        [field: SerializeField] public string Parameter { get; private set; }

        public void Play(float volume = 1.0f)
        {
            ReproduceEvent.Play(Reference, volume);
        }
        
        public void Stop(STOP_MODE mode)
        {
            throw new System.NotImplementedException();
        }
    }
}