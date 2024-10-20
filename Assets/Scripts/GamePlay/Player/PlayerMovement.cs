using Gameplay.Controllers;
using Pathfinding;
using UnityEngine;

namespace Gameplay.Player
{
	public class PlayerMovement : MonoBehaviour
	{
		private AIPath aiPath;

		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			//Register inputs actions
			RaycastInputController.Instance.OnMoveInput += OnMovedInput;

			//Get References
			aiPath = GetComponent<AIPath>();
		}

		private void OnMovedInput(Vector3 pos)
		{
			aiPath.destination = pos;
		}
	}
}