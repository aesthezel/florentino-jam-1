using Obvious.Soap;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerHealth", menuName = "Scriptable Objects/PlayerHealth")]
public class PlayerHealth : FloatVariable
{
    [SerializeField] float minHealth, maxHealth;

    public float MaxHealth => maxHealth;

    public void ChangeHealth(float value)
    {
        Value = Mathf.Clamp(Value + value, minHealth, maxHealth);
    }
}
