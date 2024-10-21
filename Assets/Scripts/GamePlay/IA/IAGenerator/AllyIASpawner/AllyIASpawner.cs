using System;
using System.Collections;
using GamePlay.Audio;
using UnityEngine;
using Random = UnityEngine.Random;

namespace VG.IA
{
	public class AllyIASpawner : IAGenerator
	{
		[SerializeField] private float minCooldown = 1;
		[SerializeField] private float maxCooldown = 10;

		public Action OnActivateSpawner;
		public Action OnDisableSpawner;
		public Action OnSpawnIA;

		private bool spawnerEnabled;

		[SerializeField] private SingleSoundEventScriptable spawnSound;
		[SerializeField] private SingleSoundEventScriptable cantSpawnSound;

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
				spawnSound.Play();
				for (int i = 0; i < spawnCount; i++)
				{
					GenerateIA();
					OnSpawnIA?.Invoke();
					StartCoroutine(SpawnerCooldown());
				}
			}
			else
			{
				cantSpawnSound.Play();
			}
		}

		IEnumerator SpawnerCooldown()
		{
			OnDisableSpawner?.Invoke();

			spawnerEnabled = false;

			yield return new WaitForSeconds(Random.Range(minCooldown, maxCooldown));

			OnActivateSpawner?.Invoke();

			spawnerEnabled = true;
		}
	}
}