using Gameplay.Controllers;
using Gameplay.IA;
using System;
using System.Drawing;
using Unity.VisualScripting;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class FollowPlayerState : State
	{
		public FollowPlayerState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
			base.EnterState();
			iA.MoveToLastSeenPoint();

			RaycastInputController.Instance.OnMoveInput += OnMoveInput;
		}

		public override void ExitState()
		{
			base.ExitState();

			RaycastInputController.Instance.OnMoveInput -= OnMoveInput;
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (iA.HaveVisionTarget())
				iA.StateMachine.ChangeState(iA.AllyAttackState);
            else
            {
				(iA as AllyIA)?.MoveToPlayer();
			}
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}

		private void OnMoveInput(Vector3 vector)
		{
			iA.MoveToPoint(vector);
			iA.StateMachine.ChangeState(iA.MovingToPosState);
		}
	}
}