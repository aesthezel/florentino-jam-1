using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.HUD
{
	public class HUDMainMenu : MonoBehaviour
	{
		[SerializeField] private Button startBtn;

		[SerializeField] private CanvasGroup canvasGroup;

		private void Start()
		{
			startBtn.onClick.AddListener(delegate { GameController.StartGame(); });
			startBtn.onClick.AddListener(delegate { HideViews(); });
		}

		private void HideViews() 
		{
			canvasGroup.interactable = false;
			canvasGroup.alpha = 0;
			canvasGroup.blocksRaycasts = false;
		}
	}
}