using FMODUnity;
using UnityEngine;

namespace GamePlay.Audio
{
    public interface IFMODEvent
    {
        public EventReference Reference { get; }
        public string Parameter { get; }
        public void Stop(FMOD.Studio.STOP_MODE mode);
    }
}
