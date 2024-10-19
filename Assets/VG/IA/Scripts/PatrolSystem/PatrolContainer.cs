using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VG.IA
{
	public class PatrolContainer : MonoBehaviour
	{
		public static PatrolContainer Instance;

		[SerializeField] List<PatrolPoint> patrolPoints = new List<PatrolPoint>();

		private void Awake()
		{
			Instance = this;
		}

		public PatrolPoint ChoosePatrolPoint()
		{
			// Suma de todos los pesos de los puntos de patrulla disponibles
			float totalWeight = 0f;
			foreach (PatrolPoint point in patrolPoints)
			{
				totalWeight += point.Weight;
			}

			// Genera un número aleatorio entre 0 y la suma total de pesos
			float randomWeight = Random.Range(0f, totalWeight);

			// Recorre los puntos de patrulla y elige el punto basado en los pesos acumulados
			float weightSum = 0f;
			foreach (PatrolPoint point in patrolPoints)
			{
				weightSum += point.Weight;
				if (randomWeight <= weightSum)
				{
					return point;
				}
			}

			// En caso de que algo salga mal, devuelve el primer punto de patrulla
			return patrolPoints[0];
		}
	}
}