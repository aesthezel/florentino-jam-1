using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class State
	{
		public IA iA;
		public StateMachineController stateMachine;

		public State(IA iA, StateMachineController stateMachine) 
		{
			this.iA = iA;
			this.stateMachine = stateMachine;
		}

		public virtual void EnterState() { }
		public virtual void ExitState() { }
		public virtual void FrameUpdate() { }
		public virtual void PhysicUpdate() { }
	}
}