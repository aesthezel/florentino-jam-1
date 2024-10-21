using Gameplay.Controllers;
using System;
using GamePlay.Player.SO;
using GamePlay.Teams;
using GamePlay.World;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class AllyIA : AstarIA, ITeam, IDamageable
	{
		public PlayerIdentityVariable player;
		private float _health;

		[Header("Death particles")]
		[SerializeField] ParticleSystem deathParticles;

		private bool iaDeath = false;

		public override void Awake()
		{
			base.Awake();

			StateMachine.Initialize(FollowPlayerState);
		}

		[field: SerializeField]
		public ScriptableEnumTeam Team { get; private set; }

		public override void Start()
		{
			base.Start();

			destinationSetter.target = player.Value.transform;
		}

		public override void MoveToPoint(Vector3 point)
		{
			destinationSetter.target = null;
			base.MoveToPoint(point);
		}

		public void MoveToPlayer()
		{
			destinationSetter.target = player.Value.transform;
		}

		public void Damage(float value)
		{
			_health -= value;
			if (_health <= 0)
			{
				Instantiate(deathParticles, transform.position, transform.rotation);
				iaDeath = true;

				Destroy(gameObject);
			}
		}

		public void AttackEnemy()
		{
			if (iaVision.Objetive)
			{
				if (iaVision.Objetive.GetComponent<IDamageable>() != null)
				{
					iaVision.Objetive.GetComponent<IDamageable>().Damage(1);
				}
			}
		}
	}
}