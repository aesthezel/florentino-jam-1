using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.HUD
{
	public class HUDPlayerHealth : MonoBehaviour
	{
		[SerializeField] private Slider healthBar;

		[SerializeField] private Health playerHealth;

		void Start() 
		{
			playerHealth.OnValueChanged += UpdateHealth;
		}

		public void UpdateHealth(float health) 
		{
			healthBar.maxValue = playerHealth.MaxHealth;
			healthBar.value = health;
		}
	}
}