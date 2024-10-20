using System.Collections.Generic;
using FMOD.Studio;
using FMODUnity;
using STOP_MODE = FMOD.Studio.STOP_MODE;

namespace GamePlay.Audio
{
    public static class ReproduceEvent
    {
        private static readonly Dictionary<EventReference, EventInstance> EventsInstantiated = new();

        public static void Play(EventReference reference)
        {
            if (EventsInstantiated.TryGetValue(reference, out var instance))
            {
                instance.start();
            }
            else
            {
                var instancedReference = RuntimeManager.CreateInstance(reference.Guid);
                EventsInstantiated.Add(reference, instancedReference);
                instancedReference.start();
            }
        }
        
        public static void Play(EventReference reference, string parameter, int value)
        {
            if (EventsInstantiated.TryGetValue(reference, out var instance)) // SI YA EXISTE
            {
                // YA ESTA EN PLAY
                instance.setParameterByName(parameter, value); // CAMBIO DE PARAMETROS
                //instancedReference.start();
            }
            else
            {
                // SE CREA UNO NUEVO
                var instancedReference = RuntimeManager.CreateInstance(reference.Guid);
                instancedReference.setParameterByName(parameter, value);
                EventsInstantiated.Add(reference, instancedReference);
                instancedReference.start();
            }
        }
        
        public static void Play(EventReference reference, string parameter, float value)
        {
            if (EventsInstantiated.TryGetValue(reference, out var instance)) // SI YA EXISTE
            {
                // YA ESTA EN PLAY
                instance.setParameterByName(parameter, value); // CAMBIO DE PARAMETROS
                //instancedReference.start();
            }
            else
            {
                // SE CREA UNO NUEVO
                var instancedReference = RuntimeManager.CreateInstance(reference.Guid);
                instancedReference.setParameterByName(parameter, value);
                EventsInstantiated.Add(reference, instancedReference);
                instancedReference.start();
            }
        }

        public static void Stop(EventReference reference, STOP_MODE mode)
        {
            if (!EventsInstantiated.TryGetValue(reference, out var instance)) return;
            instance.stop(mode);
            instance.release();
        }
    }
}