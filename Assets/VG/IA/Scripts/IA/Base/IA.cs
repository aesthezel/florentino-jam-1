using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using VG.IA.StateMachine;

namespace VG.IA
{
	[RequireComponent(typeof(IAHearing))]
	[RequireComponent(typeof(IAVision))]
	public class IA : MonoBehaviour
	{
		[Header("IA Settings")]
		[SerializeField] protected float idleTime;
		public float IdleTime { get { return idleTime; } }

		public float IdleTimming { get; set; }

		public float attackTime;
		public float AttackTime { get { return attackTime; } }

		[Header("Speed settings")]
		[SerializeField] protected float normalSpeed;
		[SerializeField] protected float chasingSpeed;

		protected NavMeshAgent agent;
		protected IAVision iaVision;
		protected IAHearing iaHearing;

		#region State Machine
		public StateMachineController StateMachine { get; set; }

		//States
		public IdleState IdleState { get; set; }
		public ChaseState ChaseState { get; set; }
		public ExploringPointState ExploringPointState { get; set; }
		public PatrolPointState PatrolPointState { get; set; }
		public AttackState AttackState { get; set; }
		public MovingToPosState MovingToPosState { get; set; }
		public FollowPlayerState FollowPlayerState { get; set; }
		public AllyAttackState AllyAttackState { get; set; }

		protected Vector3 lastTargetSeenPos;
		protected float targetDistance;
		#endregion

		public virtual void Awake()
		{
			agent = GetComponent<NavMeshAgent>();
			iaVision = GetComponent<IAVision>();
			iaHearing = GetComponent<IAHearing>();

			//Init State Machine
			StateMachine = new StateMachineController();

			IdleState = new IdleState(this, StateMachine);
			ChaseState = new ChaseState(this, StateMachine);
			ExploringPointState = new ExploringPointState(this, StateMachine);
			PatrolPointState = new PatrolPointState(this, StateMachine);
			AttackState = new AttackState(this, StateMachine);
			MovingToPosState = new MovingToPosState(this, StateMachine);
			FollowPlayerState = new FollowPlayerState(this, StateMachine);
			AllyAttackState = new AllyAttackState(this, StateMachine);

			StateMachine.Initialize(IdleState);
		}

		public virtual void Start()
		{

		}

		public virtual void Update()
		{
			//Update components
			iaVision.UpdateVision();
			iaHearing.UpdateHearing();

			StateMachine.CurrentState.FrameUpdate();
		}

		public virtual void FixedUpdate()
		{
			StateMachine.CurrentState.PhysicUpdate();
		}

		public virtual void ChaseTargetStart() 
		{
			agent.speed = chasingSpeed;
		}

		public virtual void ChaseTargetStopped()
		{
			agent.speed = normalSpeed;
		}


		public virtual void ChaseTarget()
		{
			if (iaVision.Objetive)
			{
				agent.SetDestination(iaVision.Objetive.transform.position);
				lastTargetSeenPos = iaVision.Objetive.transform.position;
			}
		}

		public virtual void MoveToHearPoint()
		{
			if (iaHearing.Objetive)
				agent.SetDestination(iaHearing.Objetive.transform.position);
		}

		public virtual void MoveToPoint(Vector3 point)
		{
			agent.SetDestination(point);
		}

		public virtual void MoveToLastSeenPoint() 
		{
			agent.SetDestination(lastTargetSeenPos);
		}

		public virtual void StopChase()
		{
			agent.SetDestination(transform.position);
		}

		public virtual bool HaveVisionTarget()
		{
			if (iaVision.Objetive)
				return true;

			return false;
		}

		public virtual bool HaveHearingTarget()
		{
			if (iaVision.Objetive)
				return true;

			return false;
		}

		public virtual bool ReachedPoint()
		{
			if (iaVision.Objetive)//Comprobate reach point objetive
			{
				targetDistance = Vector3.Distance(iaVision.Objetive.transform.position, transform.position);
				if (targetDistance <= iaVision.TargetCatchDistance)
					return true;
				else
					return false;
			}
			else if ((agent.remainingDistance - agent.stoppingDistance) <= 0.1f)//Comprobate movement point objetive
				return true;

			return false;
		}

		public virtual bool HaveAttackTarget() => false;
	}
}