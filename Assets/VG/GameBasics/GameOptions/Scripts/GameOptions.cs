using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

namespace VG.GameOption
{
	public class GameOptions : MonoBehaviour
	{
		public static GameOptions instance;

		[Header("GameOptions Menu")]
		[SerializeField] GameObject gameOptionsScreen;

		[Header("Resolution settings")]
		[SerializeField] Resolutions[] screenResolutions;
		[SerializeField] TMP_Dropdown resolutionDropdown;

		List<TMP_Dropdown.OptionData> dropdownDataList = new List<TMP_Dropdown.OptionData>();
		TMP_Dropdown.OptionData dropdownData;

		[Header("FullScreen Mode")]
		[SerializeField] Toggle fullScreenToggle;

		[Header("Vsync")]
		[SerializeField] Toggle vsyncToggle;

		[Header("FrameRate")]
		[SerializeField] TextMeshProUGUI framerateText;
		[SerializeField] Slider framerateSlider;

		[Header("Master Volume")]
		[SerializeField] TextMeshProUGUI volumeText;
		[SerializeField] Slider volumeSlider;

		[Header("Subtitles")]
		[SerializeField] Toggle subtitlesToggle;

		[Header("Mouse Sensitivity")]
		[SerializeField] TextMeshProUGUI mouseSensitivityText;
		[SerializeField] Slider mouseSensitivitySlider;
		public float MouseSensitivity { get { return mouseSensitivitySlider.value; } }

		//[HideInInspector]
		public GameOptionData GameOptionData = new GameOptionData();

		private void Awake()
		{
			instance = this;
		}

		// Start is called before the first frame update
		void Start()
		{
			BuildResolucionDropdown();

			if (PlayerPrefs.HasKey("GameOption"))
				LoadGameOptionData();
			else
				LoadInitialSettings();
		}

		//Setteds on Player HUD values
		void LoadInitialSettings()
		{
			Application.targetFrameRate = Mathf.RoundToInt(framerateSlider.value);

			GameOptionData.Resolution = 0;
			GameOptionData.Fullscreen = fullScreenToggle.isOn;
			GameOptionData.Vsync = vsyncToggle.isOn;
			GameOptionData.Framerate = Mathf.RoundToInt(framerateSlider.value);
			GameOptionData.Volume = volumeSlider.value;
			GameOptionData.Subtitles = subtitlesToggle.isOn;

			//Save Initial data
			SaveGameOptionData();
		}

		void BuildResolucionDropdown()
		{
			for (int i = 0; i < screenResolutions.Length; i++)
			{
				dropdownData = new TMP_Dropdown.OptionData();
				dropdownData.text = screenResolutions[i].hRes + " X " + screenResolutions[i].vRes;
				dropdownDataList.Add(dropdownData);
			}

			resolutionDropdown.AddOptions(dropdownDataList);
		}

		public void SelectResolution(int value)
		{
			Resolutions resolutions = screenResolutions[value];
			Screen.SetResolution(resolutions.hRes, resolutions.vRes, fullScreenToggle.isOn);

			//Set value on Option Data
			GameOptionData.Resolution = value;
		}

		public void ToggleFullscreen(bool value)
		{
			Screen.fullScreen = value;

			//Set value on Option Data
			GameOptionData.Fullscreen = value;
		}

		public void ToggleVsync(bool value)
		{
			if (value)
			{
				QualitySettings.vSyncCount = 1;
			}
			else
			{
				QualitySettings.vSyncCount = 0;

				//Set max framerate
				if (Application.targetFrameRate >= 120)
					Application.targetFrameRate = 120;
			}

			//Set value on Option Data
			GameOptionData.Vsync = value;
		}

		public void SetFrameRate()
		{
			framerateText.text = framerateSlider.value + " Fps";

			int framerate = Mathf.RoundToInt(framerateSlider.value);

			Application.targetFrameRate = framerate;

			//Set value on Option Data
			GameOptionData.Framerate = framerate;
		}

		public void SetVolume()
		{
			volumeText.text = Mathf.Round(volumeSlider.value * 100) + " %";
			AudioListener.volume = volumeSlider.value;

			//Set value on Option Data
			GameOptionData.Volume = volumeSlider.value;
		}

		public void ToggleSubtitles(bool value)
		{
			//Set value on Option Data
			GameOptionData.Subtitles = value;
		}

		public void SetMouseSensitivity()
		{
			mouseSensitivityText.text = mouseSensitivitySlider.value.ToString("F2");

			//Set value on Option Data
			GameOptionData.MouseSensitivity = mouseSensitivitySlider.value;
		}

		public void SetQuality(int value)
		{
			QualitySettings.SetQualityLevel(value);
		}

		public void EnableGameOptionsScreen(bool value)
		{
			gameOptionsScreen.SetActive(value);
		}

		//Game option save and load
		public void SaveGameOptionData()
		{
			string data = JsonUtility.ToJson(GameOptionData);

			PlayerPrefs.SetString("GameOption", data);
		}

		void LoadGameOptionData()
		{
			//Get gameoption data
			string data = PlayerPrefs.GetString("GameOption");
			GameOptionData = JsonUtility.FromJson<GameOptionData>(data);

			//Resolution
			resolutionDropdown.SetValueWithoutNotify(GameOptionData.Resolution);

			//FullScreen
			fullScreenToggle.isOn = GameOptionData.Fullscreen;

			//Vsync
			ToggleVsync(GameOptionData.Vsync);
			vsyncToggle.isOn = GameOptionData.Vsync;

			//Target framerate
			Application.targetFrameRate = GameOptionData.Framerate;
			framerateText.text = GameOptionData.Framerate + " Fps";
			framerateSlider.value = GameOptionData.Framerate;

			//Volume
			volumeSlider.SetValueWithoutNotify(GameOptionData.Volume);
			SetVolume();

			//Subtitles
			subtitlesToggle.isOn = GameOptionData.Subtitles;

			mouseSensitivitySlider.value = GameOptionData.MouseSensitivity;
		}
	}

	[System.Serializable]
	public class Resolutions
	{
		public int hRes;
		public int vRes;
	}

	[System.Serializable]
	public class GameOptionData
	{
		public int Resolution;
		public bool Fullscreen;
		public bool Vsync;
		public int Framerate;
		public float Volume = 1;
		public float MusicVolume;
		public float VoicesVolume;
		public bool Subtitles = true;
		public float MouseSensitivity;
	}
}