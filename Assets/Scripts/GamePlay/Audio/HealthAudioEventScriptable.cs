using FMODUnity;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Audio
{
    [CreateAssetMenu(fileName = "Health Audio Event", menuName = "Game/Audio/HealthAudioEvent", order = 0)]
    public class HealthAudioEventScriptable : ScriptableObject, IFMODEvent
    {
        [field: SerializeField] public EventReference Reference { get; private set; }
        [field: SerializeField] public string Parameter { get; private set; }
        public float HealthValue = 1000;
        public float MaxHealthValue = 1000;

        public float TestingHealthToSend = 10;

        [Button("Test Health")]
        public void TestHealth()
        {
            ChangeHealth(TestingHealthToSend);
        }
        
        public void ChangeHealth(float value)
        {
            HealthValue += value;
            
            var healthPercent = HealthValue / MaxHealthValue;
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