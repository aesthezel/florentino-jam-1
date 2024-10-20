using Pathfinding;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace VG.IA
{
	public class AstarIA : IA
	{
		protected AIDestinationSetter destinationSetter;
		protected AIPath aiPath;

		private Vector2 movePosPoint;

		public override void Awake()
		{
			base.Awake();

			destinationSetter = GetComponent<AIDestinationSetter>();
			aiPath = GetComponent<AIPath>();
		}

		public override void FixedUpdate()
		{
			base.FixedUpdate();
		}

		public override void ChaseTargetStart()
		{
			aiPath.maxSpeed = chasingSpeed;

			if (iaVision.Objetive)
			{
				destinationSetter.target = iaVision.Objetive.transform;
				lastTargetSeenPos = iaVision.Objetive.transform.position;
			}
		}

		public override void ChaseTargetStopped()
		{

			destinationSetter.target = null;

			aiPath.maxSpeed = normalSpeed;
		}

		public override void ChaseTarget()
		{
			if (iaVision.Objetive)
				lastTargetSeenPos = iaVision.Objetive.transform.position;
		}

		public override void MoveToHearPoint()
		{
			base.MoveToHearPoint();
		}

		public override void MoveToPoint(Vector3 point)
		{
			aiPath.destination = point;

			movePosPoint = point;
		}

		public override void MoveToLastSeenPoint()
		{
			aiPath.destination = lastTargetSeenPos;
		}

		public override void StopChase()
		{
			base.StopChase();
		}

		public override bool ReachedPoint()
		{
			if (iaVision.Objetive)//Comprobate reach point objetive
			{
				targetDistance = Vector3.Distance(iaVision.Objetive.transform.position, transform.position);
				if (targetDistance <= iaVision.TargetCatchDistance)
					return true;
				else
					return false;
			}
			else
				return aiPath.reachedDestination;
		}
	}
}