using FMODUnity;
using Obvious.Soap.Example;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio
{
    [CreateAssetMenu(fileName = "Health Audio Event", menuName = "Game/Audio/HealthAudioEvent", order = 0)]
    public class HealthAudioEventScriptable : ScriptableObject, IFMODEvent
    {
        [field: SerializeField] public EventReference Reference { get; private set; }
        [field: SerializeField] public string Parameter { get; private set; }
        public Health CurrentHealth;

        public float TestingHealthToSend = 10;

        // [Button("Test Health")]
        // public void TestHealth()
        // {
        //     ChangeHealth(TestingHealthToSend);
        // }
        
        public void CheckHealth()
        {
            var healthPercent = CurrentHealth.Value / CurrentHealth.MaxHealth;
            var healthSoundValue = Mathf.Clamp(healthPercent, 0, 1);
            Play(healthSoundValue);
        }

        private void Play(float currentHealth)
        {
            ReproduceEvent.Play(Reference, Parameter, currentHealth);
        }

        public void Stop(FMOD.Studio.STOP_MODE mode)
        {
            ReproduceEvent.Stop(Reference, mode);
        }
    }
}