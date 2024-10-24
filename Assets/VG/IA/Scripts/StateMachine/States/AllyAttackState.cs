
using Gameplay.IA;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class AllyAttackState : State
	{
		public AllyAttackState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
			base.EnterState();

			iA.ChaseTarget();

			iA.attackTime = 0;
		}

		public override void ExitState()
		{
			base.ExitState();

			iA.attackTime = 0;
		}

		public override void FrameUpdate()
		{
			base.FrameUpdate();

			if (iA.HaveVisionTarget())
			{
				iA.attackTime += Time.deltaTime;

                if (iA.attackTime>=0.5f)
                {
					(iA as AllyIA)?.AttackEnemy();
					iA.attackTime = 0;
				}
            }
			else
				iA.StateMachine.ChangeState(iA.FollowPlayerState);
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}