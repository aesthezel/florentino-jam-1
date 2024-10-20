using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace GamePlay.Audio
{
    [CreateAssetMenu(fileName = "Bullet Hit Event", menuName = "Game/Audio/BulletHitEvent", order = 0)]
    public class BulletHitEventScriptable : ScriptableObject, IFMODEvent
    {
        [field: SerializeField] public EventReference Reference { get; private set; }
        [field: SerializeField] public string Parameter { get; private set; }
        
        public void Play()
        {
            ReproduceEvent.Play(Reference);
        }
        
        public void Stop(STOP_MODE mode)
        {
            ReproduceEvent.Stop(Reference, mode);
        }
    }
}