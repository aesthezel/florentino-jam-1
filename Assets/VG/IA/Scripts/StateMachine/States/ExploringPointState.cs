namespace VG.IA.StateMachine
{
	public class ExploringPointState : State
	{
		public ExploringPointState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine)
		{

		}

		public override void EnterState()
		{
			base.EnterState();

			iA.MoveToLastSeenPoint();
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

			if (iA.ReachedPoint())
				iA.StateMachine.ChangeState(iA.PatrolPointState);
		}

		public override void PhysicUpdate()
		{
			base.PhysicUpdate();
		}
	}
}