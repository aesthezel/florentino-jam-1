namespace VG.IA.StateMachine
{
	public class MovingToPosState : State
	{
		public MovingToPosState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
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
				iA.StateMachine.ChangeState(iA.AttackState);

			if (iA.ReachedPoint())
				iA.StateMachine.ChangeState(iA.FollowPlayerState);
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}