using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace VG.LevelLoadManager
{
	public class LevelLoadManager : MonoBehaviour
	{
		public static LevelLoadManager instance;

		[Header("Bar settings")]
		public Slider loadingBar;
		public Text loadingText;

		[Header("Canvas group fade")]
		public float fadeSpeed;
		private CanvasGroup canvasGroup;

		private bool levelLoading = false;
		private bool loaded = false;
		private string loadingLevel;

		private void Awake()
		{
			canvasGroup = GetComponent<CanvasGroup>();

			if (!instance)
			{
				instance = this;

				DontDestroyOnLoad(gameObject);

				ResetLoadValues();
			}
			else
			{
				Destroy(gameObject);
			}
		}

		public void LoadLevel(string levelName)
		{
			loadingLevel = levelName;

			levelLoading = true;

			StartCoroutine(FadeEffect(false));
			StartCoroutine(LoadSceneAsync(levelName));
		}

		IEnumerator LoadSceneAsync(string levelName)
		{
			yield return new WaitForSeconds(1f);
			AsyncOperation op = SceneManager.LoadSceneAsync(levelName);

			while (!op.isDone)
			{
				float progress = op.progress;

				loadingBar.value = Mathf.Round(progress * 100f);
				loadingText.text = Mathf.Round(progress * 100f) + " %";

				yield return null;
			}

			if (op.isDone)
			{
				loadingBar.value = 100;
				loadingText.text = 100 + " %";
				loaded = true;

				DissableLoadPanel();
			}
		}

		void DissableLoadPanel()
		{
			StartCoroutine(FadeEffect(true));

			loaded = false;
			levelLoading = false;

			Invoke("ResetLoadValues", 0.5f);
		}

		IEnumerator FadeEffect(bool negative)
		{
			yield return new WaitForSeconds(fadeSpeed);

			if (negative)
			{
				if (canvasGroup.alpha > 0)
				{
					canvasGroup.alpha -= 0.1f;

					StartCoroutine(FadeEffect(negative));
				}
			}
			else
			{
				if (canvasGroup.alpha < 1)
				{
					canvasGroup.alpha += 0.1f;

					StartCoroutine(FadeEffect(negative));
				}
			}
		}

		void ResetLoadValues()
		{
			loadingBar.value = 0;
			loadingText.text = 0 + " %";
		}
	}
}