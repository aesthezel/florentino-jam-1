using GamePlay.Audio;
using GamePlay.Player;
using GamePlay.Player.SO;
using GamePlay.Teams;
using GamePlay.Weapons;
using GamePlay.World;
using Obvious.Soap;
using Sirenix.OdinInspector;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class EnemyAI : AstarIA, ITeam, IDamageable
	{
		[field: SerializeField]
		public ScriptableEnumTeam Team { get; private set; }
		public PlayerIdentityVariable player;
		public IAVision attackVision;
		public Weapon enemyWeapon;
		public float attackSpeed = 3;
		[SerializeField] private float initialHealth;

		[SerializeField] Health enemyHealth;
		[SerializeField] PlayerPoints playerPoints;

		[Header("Death particles")]
		[SerializeField] ParticleSystem deathParticles;

		private bool iaDeath = false;

		private void OnEnable()
		{
			enemyHealth = SoapUtils.CreateRuntimeInstance<Health>();
			enemyHealth.SetHealth(0, initialHealth);

			player.OnValueChanged += AddPlayer;
		}

		private void OnDisable()
		{
			player.OnValueChanged -= AddPlayer;
		}

		private void AddPlayer(PlayerIdentity playerIdentity)
		{
			destinationSetter.target = playerIdentity.transform;
		}

		public override void Start()
		{
			base.Start();
			if (player.Value == null)
			{
				StateMachine.ChangeState(PatrolPointState);
			}
			else
			{
				destinationSetter.target = player.Value.transform;
			}
		}

		public override bool HaveAttackTarget()
		{
			return attackVision.Objetive;
		}

		public override void Update()
		{
			base.Update();
			attackVision.UpdateVision();
		}

		public void TryShoot()
		{
			enemyWeapon.Shoot();
		}

		public void RotateToTarget(Transform target)
		{
			transform.LookAt(target.position);
		}

		public void Damage(float value)
		{
			if (iaDeath)
				return;

            enemyHealth.Value -= value;

			if (enemyHealth.Value <= 0)
			{
				playerPoints.Value++;

				Instantiate(deathParticles, transform.position, transform.rotation);
				iaDeath = true;

				Destroy(gameObject);
			}
		}
	}
}