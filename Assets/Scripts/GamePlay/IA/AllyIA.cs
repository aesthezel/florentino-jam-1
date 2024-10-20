using GamePlay.Teams;
using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class AllyIA : AstarIA, ITeam
	{
		[field: SerializeField]
		public ScriptableEnumTeam Team { get; private set; }
		
		public override void Start()
		{
			base.Start();

			destinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
}