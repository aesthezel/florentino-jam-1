using UnityEngine;

namespace VG.IA.StateMachine
{
    public class AttackState : State
    {
        public AttackState(IA iA, StateMachineController stateMachine) : base(iA, stateMachine) { }
        
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
            
            if (iA.HaveAttackTarget())
            {
                Debug.Log("Disparando");
            }
            else
            {
                iA.StateMachine.ChangeState(iA.IdleState);
            }
        }

        public override void PhysicUpdate()
        {
            base.PhysicUpdate();
        }
    }
}