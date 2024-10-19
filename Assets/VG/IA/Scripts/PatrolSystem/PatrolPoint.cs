using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA
{
	public class PatrolPoint : MonoBehaviour
	{
		[SerializeField] private float weight = 1f; // Peso o probabilidad del punto de patrulla

		public float Weight { get { return weight; } }
	}
}