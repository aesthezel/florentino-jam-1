using Obvious.Soap;
using UnityEngine;

[CreateAssetMenu(fileName = "Health", menuName = "Scriptable Objects/Health")]
public class Health : FloatVariable
{
    [SerializeField] float minHealth, maxHealth;

    public float MaxHealth => maxHealth;

    public void SetHealth(float min, float max) 
    {
		minHealth = min;
        maxHealth = max;

        Value = max;
	}

    public void ChangeHealth(float value)
    {
        Value = Mathf.Clamp(Value + value, minHealth, maxHealth);
    }
}
