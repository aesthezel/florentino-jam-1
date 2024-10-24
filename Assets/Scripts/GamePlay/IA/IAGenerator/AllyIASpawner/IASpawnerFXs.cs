using System;
using UnityEngine;
using VG.IA;

public class IASpawnerFXs : MonoBehaviour
{
	[Header("FXs Particles")]
	[SerializeField] private ParticleSystem activateParticles;
	[SerializeField] private ParticleSystem deactivateParticles;
	[SerializeField] private ParticleSystem spawnsParticles;

	private AllyIASpawner allyIASpawner;

	// Start is called once before the first execution of Update after the MonoBehaviour is created
	void Start()
    {
		allyIASpawner = GetComponent<AllyIASpawner>();

		allyIASpawner.OnActivateSpawner += OnActivateSpawner;
		allyIASpawner.OnDisableSpawner += OnDisableSpawner;
		allyIASpawner.OnSpawnIA += OnSpawnIA;
	}

	private void OnActivateSpawner()
	{
		activateParticles.Play();
		deactivateParticles.Stop();
	}

	private void OnDisableSpawner()
	{
		activateParticles.Stop();
		deactivateParticles.Play();
	}

	private void OnSpawnIA()
	{
		spawnsParticles.Play();
	}
}
