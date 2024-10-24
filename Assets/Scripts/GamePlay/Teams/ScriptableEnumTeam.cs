using Obvious.Soap;
using UnityEngine;

namespace GamePlay.Teams
{
    [CreateAssetMenu(fileName = "Scriptable_" + nameof(ScriptableEnumTeam), menuName = "Game/ScriptableVariables/" + nameof(ScriptableEnumTeam), order = 0)]
    public class ScriptableEnumTeam : ScriptableEnumBase
    {
        public string Name;
    }
}