using UnityEngine;

namespace Gameplay.HUD
{
	public class HUDController : MonoBehaviour
	{
		public static HUDController Instance;

		[SerializeField] HUDPlayerHealth hudplayerHealth;
		public HUDPlayerHealth HUDplayerHealth { get { return hudplayerHealth; } }

		void Awake()
		{
			Instance = this;
		}
	}
}