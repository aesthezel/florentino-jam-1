using GamePlay.Audio;
using GamePlay.Player.SO;
using GamePlay.Teams;
using GamePlay.World;
using Sirenix.OdinInspector;
using UnityEngine;

namespace GamePlay.Player
{
	public class PlayerIdentity : MonoBehaviour, ITeam, IDamageable
	{
		[field: SerializeField]
		public ScriptableEnumTeam Team { get; private set; }
		[SerializeField]
		private PlayerIdentityVariable playerIdentityVariable = null;
    
		[Title("Audio")]
		[SerializeField] private SingleSoundEventScriptable footStepAudio;
		[SerializeField] private SingleSoundEventScriptable hurtAudio;
		[SerializeField] private HealthAudioEventScriptable healthAudio;

		[SerializeField]
		Health playerHealth;

		private Vector3 lastPosition = Vector3.zero;

		private void Awake()
		{
			playerIdentityVariable.Value = this;
			playerHealth.SetHealth(0, 100);

		}

		private void Update()
		{
			CalculateLastPosition();
		}

		private void CalculateLastPosition()
		{
			if (!(Vector3.Distance(lastPosition, transform.position) > 2f)) return;
			footStepAudio.Play(0.25f);
			lastPosition = transform.position;
		}

		public void Damage(float value)
		{
			playerHealth.ChangeHealth(-value);

			hurtAudio.Play();
			healthAudio.CheckHealth();
		
			if (playerHealth.Value <= 0)
			{
				GameController.EndGame();
				Destroy(gameObject);
			}
		}
	}
}
