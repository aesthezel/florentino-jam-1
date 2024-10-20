using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class ChaseState : State
	{
		public ChaseState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
			base.EnterState();

			iA.ChaseTargetStart();
			iA.ChaseTarget();
		}

		public override void ExitState()
		{
			base.ExitState();

			iA.ChaseTargetStopped();
		}

		public override void FrameUpdate()
		{
			Debug.Log("CHASE STATE");
			
			base.FrameUpdate();
			
			if (iA.HaveVisionTarget())
				iA.ChaseTarget();

			if (iA.HaveAttackTarget())
			{
				Debug.Log("Consiguio objetivo");
				iA.StateMachine.ChangeState(iA.AttackState);
			}

				
			else 
			{
				iA.MoveToLastSeenPoint();
				iA.StateMachine.ChangeState(iA.ExploringPointState);
			}
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}