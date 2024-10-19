using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class IdleState : State
	{
		public IdleState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
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
				iA.StateMachine.ChangeState(iA.ExploringPointState);

			iA.IdleTimming += Time.deltaTime;

            if (iA.IdleTimming >= iA.IdleTime)
            {
				iA.StateMachine.ChangeState(iA.PatrolPointState);
				iA.IdleTimming = 0;
			}
        }

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}