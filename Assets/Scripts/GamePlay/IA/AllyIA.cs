using UnityEngine;
using VG.IA;

namespace Gameplay.IA
{
	public class AllyIA : AstarIA
	{
		public override void Start()
		{
			base.Start();

			destinationSetter.target = GameObject.FindGameObjectWithTag("Player").transform;
		}
	}
}