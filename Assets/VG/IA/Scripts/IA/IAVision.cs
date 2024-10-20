using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA
{
	public class IAVision : MonoBehaviour
	{
		[Header("View settings")]
		[SerializeField] float viewRadius = 10f;
		[Range(0, 360)][SerializeField] float viewAngle = 90f;
		[SerializeField] LayerMask layerMasks;
		[SerializeField] string targetTag = "Player";
		[SerializeField] Collider[] targetsInViewRadius;

		[Header("Current Objetive")]
		[SerializeField] private GameObject objetive;
		public GameObject Objetive { get { return objetive; } }

		[SerializeField] private float targetCatchDistance;
		public float TargetCatchDistance { get { return targetCatchDistance; } }

		//Cache
		Transform target;
		Vector3 dirToTarget;
		float dstToTarget;

		Ray ray;
		RaycastHit hit;

		public void UpdateVision()
		{
			targetsInViewRadius = Physics.OverlapSphere(transform.position, viewRadius, layerMasks);

			for (int i = 0; i < targetsInViewRadius.Length; i++)
			{
				target = targetsInViewRadius[i].transform;
				dirToTarget = (target.position - transform.position).normalized;

				if (Vector3.Angle(transform.forward, dirToTarget) < viewAngle / 2)
				{
					dstToTarget = Vector3.Distance(transform.position, target.position);

					ray.origin = transform.position;
					ray.direction = dirToTarget;

					if (Physics.Raycast(ray, out hit, dstToTarget, layerMasks))
					{
						if (hit.collider.gameObject.tag == targetTag)
						{
							objetive = hit.collider.gameObject;

							return;
						}
					}
				}
			}

			objetive = null;
		}

		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.yellow;
			Gizmos.DrawWireSphere(transform.position, viewRadius);

			Vector3 viewAngleA = DirFromAngle(-viewAngle / 2, false);
			Vector3 viewAngleB = DirFromAngle(viewAngle / 2, false);

			Gizmos.color = Color.red;
			Gizmos.DrawLine(transform.position, transform.position + viewAngleA * viewRadius);
			Gizmos.DrawLine(transform.position, transform.position + viewAngleB * viewRadius);
		}

		Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal)
		{
			if (!angleIsGlobal)
			{
				angleInDegrees += transform.eulerAngles.y;
			}
			return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
		}
	}
}