using System;
using System.Collections;
using UnityEngine;

namespace VG.IA
{
	public class AllyIASpawner : IAGenerator
	{
		[SerializeField] private float cooldown = 10;

		public Action OnActivateSpawner;
		public Action OnDisableSpawner;
		public Action OnSpawnIA;

		private bool spawnerEnabled;

		public override void Start()
		{
			OnDisableSpawner?.Invoke();

			StartCoroutine(SpawnerCooldown());
		}

		public override void GenerateIA()
		{
			base.GenerateIA();
		}

		public void OnMouseDown()
		{
			if (spawnerEnabled)
			{
				for (int i = 0; i < spawnCount; i++)
				{
					GenerateIA();

					OnSpawnIA?.Invoke();

					StartCoroutine(SpawnerCooldown());
				}
			}
		}

		IEnumerator SpawnerCooldown()
		{
			OnDisableSpawner?.Invoke();

			spawnerEnabled = false;

			yield return new WaitForSeconds(cooldown);

			OnActivateSpawner?.Invoke();

			spawnerEnabled = true;
		}
	}
}