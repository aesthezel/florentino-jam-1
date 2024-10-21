using Gameplay.Controllers;
using Pathfinding;
using UnityEngine;
using VG.Inputs;
using VG.LevelLoadManager;

namespace Gameplay.Player
{
	public class PlayerMovement : MonoBehaviour
	{		
		[Header("Speed settings")]
		[SerializeField] private float playerSpeed = 5.0f;
		[SerializeField] private float gravityValue = -9.81f;

		private Vector3 playerVelocity;
		private bool groundedPlayer;
		
		private CharacterController characterController;

		//Cache
		Vector2 moveInput;
		Vector3 move;

		// Start is called once before the first execution of Update after the MonoBehaviour is created
		void Start()
		{
			//Get References
			characterController = GetComponent<CharacterController>();
		}

		void Update()
		{
			moveInput = InputController.Instance.MoveInput;

            UpdateMovement();
		}

		private void UpdateMovement() 
		{
			move = new Vector3(moveInput.x, 0, moveInput.y);

			groundedPlayer = characterController.isGrounded;

			if (groundedPlayer && playerVelocity.y < 0)
			{
				playerVelocity.y = 0f;
			}

			characterController.Move(move * Time.deltaTime * playerSpeed);

			// Cambiar la dirección del jugador hacia el movimiento
			if (move != Vector3.zero)
			{
				gameObject.transform.forward = move;
			}

			// Aplicar gravedad
			playerVelocity.y += gravityValue * Time.deltaTime;
			characterController.Move(playerVelocity * Time.deltaTime);
		}
	}
}