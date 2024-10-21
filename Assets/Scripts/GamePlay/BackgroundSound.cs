using System;
using GamePlay.Audio;
using UnityEngine;

namespace GamePlay
{
    public class BackgroundSound : MonoBehaviour
    {
        [SerializeField] private SingleSoundEventScriptable singleSound;

        private void Start()
        {
            singleSound.Play(0.25f);
        }
    }
}