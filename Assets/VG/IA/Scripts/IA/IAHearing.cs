using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA
{
	public class IAHearing : MonoBehaviour
	{
		[Header("Hear settings")]
		[SerializeField] float hearRadius = 10f;
		[SerializeField] LayerMask layerMasks;
		Collider[] targetsHearingRadius;

		[Header("Current Objetive")]
		[SerializeField] private GameObject objetive;
		public GameObject Objetive { get { return objetive; } }

		// Start is called before the first frame update
		void Start()
		{

		}

		public void UpdateHearing()
		{
			targetsHearingRadius = Physics.OverlapSphere(transform.position, hearRadius, layerMasks);

			for (int i = 0; i < targetsHearingRadius.Length; i++)
			{
				objetive = targetsHearingRadius[0].gameObject;
			}
		}

		void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.blue;
			Gizmos.DrawWireSphere(transform.position, hearRadius);
		}
	}
}