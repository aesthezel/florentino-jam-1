using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.HUD
{
	public class HUDPlayerPoints : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI points;
		[SerializeField] private PlayerPoints playerPoints;

		[SerializeField] private Button exitBtn;

		void Start()
		{
			playerPoints.OnValueChanged += UpdatePoints;

			exitBtn.onClick.AddListener(delegate { Application.Quit(); });
		}

		public void UpdatePoints(float value) 
		{
			points.text = value.ToString();
		}
	}
}