using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace GamePlay.Audio
{
    [CreateAssetMenu(fileName = "Gameplay Audio Event", menuName = "Game/Audio/GameplayAudioEvent", order = 0)]
    public class GameplayAudioEventScriptable : ScriptableObject, IFMODEvent
    {
        [field: SerializeField] public EventReference Reference { get; private set; }
        [field: SerializeField] public string Parameter { get; private set; }

        public void Play(GameplaySoundStates state)
        {
            ReproduceEvent.Play(Reference, Parameter, (int)state);
        }
        
        public void Stop(STOP_MODE mode)
        {
            ReproduceEvent.Stop(Reference, mode);
        }
    }

    public enum GameplaySoundStates
    {
        Menu,
        GamePlay,
        GameOver
    }
}