using System;
using GamePlay.Audio;
using UnityEngine;

namespace GamePlay
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private SingleSoundEventScriptable singleSound;
        [SerializeField] private GameplayAudioEventScriptable gameSoundState;

        private void Start()
        {
            singleSound.Play(0.25f);
            gameSoundState.Play(GameplaySoundStates.Menu);
            GameController.OnStartedGame += () => gameSoundState.Play(GameplaySoundStates.GamePlay);
            GameController.OnFinishedGame += () => gameSoundState.Play(GameplaySoundStates.GameOver);
        }
    }
}