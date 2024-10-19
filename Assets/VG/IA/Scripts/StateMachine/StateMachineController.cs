using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA.StateMachine
{
	public class StateMachineController
	{
		public State CurrentState { get; set; }

		public void Initialize(State startState) 
		{
			CurrentState = startState;
			CurrentState.EnterState();
		}

		public void ChangeState(State newState)
		{
			CurrentState.ExitState();
			CurrentState = newState;
			CurrentState.EnterState();
		}
	}
}