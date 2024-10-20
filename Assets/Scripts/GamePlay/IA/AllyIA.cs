using Gameplay.Controllers;
using System;
using GamePlay.Player.SO;
using GamePlay.Teams;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class AllyIA : AstarIA, ITeam
	{
		public PlayerIdentityVariable player;

		public override void Awake()
		{
			base.Awake();

			StateMachine.Initialize(FollowPlayerState);

			//RaycastInputController.Instance.OnMoveInput += OnMoveInput;
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

		private void OnMoveInput(Vector3 vector)
		{
			aiPath.destination = vector;
		}

		public void MoveToPlayer() 
		{
			destinationSetter.target = player.Value.transform;
		}
	}
}