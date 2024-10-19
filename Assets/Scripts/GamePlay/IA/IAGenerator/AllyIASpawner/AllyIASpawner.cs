using UnityEngine;
using VG.IA;

public class AllyIASpawner : IAGenerator
{
    public override void Start()
    {
        
    }

	public override void GenerateIA()
	{
		base.GenerateIA();
	}

	public void OnMouseDown()
	{
		GenerateIA();
	}
}
