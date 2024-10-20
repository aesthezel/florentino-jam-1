using Gameplay.Controllers;
using System;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class AllyIA : AstarIA
	{
		private GameObject playerRef;

		public override void Awake()
		{
			base.Awake();

			StateMachine.Initialize(FollowPlayerState);

			//RaycastInputController.Instance.OnMoveInput += OnMoveInput;
		}

		public override void Start()
		{
			base.Start();

			playerRef = GameObject.FindGameObjectWithTag("Player");

			//destinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
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
			destinationSetter.target = playerRef.transform;
		}
	}
}