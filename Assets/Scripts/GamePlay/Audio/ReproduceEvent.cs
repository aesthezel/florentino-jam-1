using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using UnityEngine;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace GamePlay.Audio
{
    public static class ReproduceEvent
    {
        private static readonly Dictionary<EventReference, List<EventInstance>> EventsInstantiated = new();

        public static void Play(EventReference reference, string parameter, int value)
        {
            var instancedReference = RuntimeManager.CreateInstance(reference.Guid);
            instancedReference.setParameterByName(parameter, value);
            //instancedReference.set3DAttributes(model.To3DAttributes());
            instancedReference.start();

            if (EventsInstantiated.TryGetValue(reference, out var instances))
            {
                instances.Add(instancedReference); 
            }
            else
            {
                EventsInstantiated.Add(reference, new List<EventInstance> { instancedReference });
            }
        }
        
        public static void Play(EventReference reference, string parameter, float value)
        {
            var instancedReference = RuntimeManager.CreateInstance(reference.Guid);
            instancedReference.setParameterByName(parameter, value);
            //instancedReference.set3DAttributes(model.To3DAttributes());
            instancedReference.start();

            if (EventsInstantiated.TryGetValue(reference, out var instances))
            {
                instances.Add(instancedReference); 
            }
            else
            {
                EventsInstantiated.Add(reference, new List<EventInstance> { instancedReference });
            }
        }

        public static void Stop(EventReference reference, STOP_MODE mode)
        {
            if (!EventsInstantiated.TryGetValue(reference, out var instances)) return;
            foreach (var instance in instances)
            {
                instance.stop(mode);
                instance.release();
            }
        }
    }
}