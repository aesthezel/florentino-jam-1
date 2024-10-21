using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class PatrolPointState : State
	{
		public PatrolPointState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
			iA.MoveToPoint(PatrolContainer.Instance.ChoosePatrolPoint().transform.position);
			base.EnterState();
		}

		public override void ExitState()
		{
			base.ExitState();
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();
			if (iA.HaveVisionTarget())
				iA.StateMachine.ChangeState(iA.ChaseState);

			if (iA.HaveHearingTarget())
			{
				iA.MoveToHearPoint();
				iA.StateMachine.ChangeState(iA.ExploringPointState);
			}

			if (iA.ReachedPoint())
				iA.StateMachine.ChangeState(iA.IdleState);
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}