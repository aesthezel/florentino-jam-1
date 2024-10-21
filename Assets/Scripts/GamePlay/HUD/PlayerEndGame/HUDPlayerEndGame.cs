using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VG.LevelLoadManager;

namespace Gameplay.HUD
{
	public class HUDPlayerEndGame : MonoBehaviour
	{
		[SerializeField] private TextMeshProUGUI finalPoints;
		[SerializeField] private PlayerPoints playerPoints;

		[SerializeField] private Button restartBtn;
		[SerializeField] private Button exitBtn;

		[SerializeField] private CanvasGroup canvasGroup;

		void Start()
		{
			playerPoints.OnValueChanged += UpdatePoints;

			restartBtn.onClick.AddListener(delegate { RestartGame(); });
			exitBtn.onClick.AddListener(delegate { Application.Quit(); });

			GameController.OnFinishedGame += ShowViews;
		}

		public void UpdatePoints(float value)
		{
			finalPoints.text = value.ToString();
		}

		public void RestartGame() 
		{
			LevelLoadManager.instance.LoadLevel("Gameplay");
		}

		private void ShowViews()
		{
			canvasGroup.interactable = true;
			canvasGroup.alpha = 1;
			canvasGroup.blocksRaycasts = true;
		}
	}
}