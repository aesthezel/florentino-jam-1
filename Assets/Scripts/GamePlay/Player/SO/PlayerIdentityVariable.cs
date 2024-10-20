using Obvious.Soap;
using UnityEngine;

namespace GamePlay.Player.SO
{
    [CreateAssetMenu(fileName = "Scriptable_" + nameof(PlayerIdentity), menuName = "Game/ScriptableVariables/"+ nameof(PlayerIdentity))]
    public class PlayerIdentityVariable : ScriptableVariable<PlayerIdentity> { }
}
