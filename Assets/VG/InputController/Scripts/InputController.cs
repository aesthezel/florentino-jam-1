using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
//using InControl;

namespace VG.Inputs
{
	public class InputController : MonoBehaviour
	{
		public static InputController Instance { get; private set; }

		[SerializeField] private Vector2 moveInput;
		public Vector2 MoveInput { get { return moveInput; } }

		[SerializeField] private Vector2 upsideInput;
		public Vector2 UpsideInput { get { return upsideInput; } }

		[SerializeField] private Vector2 aimInput;
		public Vector2 AimInput { get { return aimInput; } }

		[SerializeField] private bool fire0;
		public bool Fire0 { get { return fire0; } }
		public Action Fire0Pressed;
		public Action Fire0Released;

		[SerializeField] private bool fire1;
		public bool Fire1 { get { return fire1; } }
		public Action Fire1Pressed;
		public Action Fire1Released;

		[SerializeField] private bool interaction;
		public bool Interaction { get { return interaction; } }
		public Action InteractionPressed;
		public Action InteractionReleased;

		[SerializeField] private bool reload;
		public bool Reload { get { return reload; } }
		public Action ReloadPressed;
		public Action ReloadReleased;

		[SerializeField] private bool run;
		public bool Run { get { return run; } }
		public Action RunPressed;
		public Action RunReleased;

		[SerializeField] private bool jump;
		public bool Jump { get { return jump; } }
		public Action JumpPressed;
		public Action JumpReleased;

		[SerializeField] private bool inventory;
		public bool Inventory { get { return inventory; } }
		public Action InventoryPressed;
		public Action InventoryReleased;

		[SerializeField] private bool pause;
		public bool Pause { get { return pause; } }
		public Action PausePressed;
		public Action PauseReleased;

		[SerializeField] private bool oneButton;
		public bool OneButton { get { return oneButton; } }
		public Action oneButtonPressed;
		public Action oneButtonReleased;

		public Action ChangeCamera;

		[Header("InControlSettings")]
		[SerializeField] bool useInControl;
		public bool UseInControl { get { return useInControl; } }

		//[SerializeField] TouchManager touchManager;

		//InControl.InputDevice inputDevice;

		// Start is called before the first frame update
		void Awake()
		{
			Instance = this;
		}

		// Update is called once per frame
		void Update()
		{
			////Get active device
			//inputDevice = InputManager.ActiveDevice;

			////Input Press on InControl SDK
			//if (inputDevice.AnyButtonIsPressed)
			//	if (!useInControl)//Using InControl Systems
			//		useInControl = true;

			////Touch controls systems
			//if (Input.touches.Length > 0 && !touchManager.controlsEnabled)
			//	useInControl = true;

			if (useInControl)//Using InControl Systems
				InControlInputs();
		}

		void InControlInputs()
		{
			//moveInput = inputDevice.LeftStick.Value;
			//roll = inputDevice.DPad.Value;
			//upsideInput = inputDevice.DPad.Value;
			//aimInput = inputDevice.RightStick.Value;

			//fire0 = inputDevice.RightTrigger;
			//fire1 = inputDevice.LeftTrigger;

			//boost = inputDevice.Action3;

			//rollBoost = inputDevice.Action4;

			//if (inputDevice.Action2.WasPressed)
			//	ChangeCamera?.Invoke();

			//Check touch controls swicht
			CheckTouchControls();
		}

		void CheckTouchControls()
		{
			////Touch controls systems
			//if (Input.touches.Length > 0 && !touchManager.controlsEnabled)
			//	touchManager.controlsEnabled = true;

			//if (inputDevice.AnyButtonIsPressed)
			//	if (Input.touches.Length == 0 && touchManager.controlsEnabled)
			//		touchManager.controlsEnabled = false;
		}

		void DisableInControl()
		{
			useInControl = false;
			//touchManager.controlsEnabled = false;
		}

		//PC Controls
		public void MovementInput(InputAction.CallbackContext input)
		{
			moveInput = input.ReadValue<Vector2>();

			if (input.canceled)
				moveInput = Vector2.zero;

			DisableInControl();
		}

		public void AimLookInput(InputAction.CallbackContext input)
		{
			aimInput = input.ReadValue<Vector2>();

			if (input.canceled)
				aimInput = Vector2.zero;

			DisableInControl();
		}


		public void UpsideMovementInput(InputAction.CallbackContext input)
		{
			upsideInput = input.ReadValue<Vector2>();

			if (input.canceled)
				upsideInput = Vector2.zero;

			DisableInControl();
		}

		public void Fire0Input(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				fire0 = true;
				Fire0Pressed?.Invoke();
			}

			if (input.canceled)
			{
				fire0 = false;
				Fire0Released?.Invoke();
			}

			DisableInControl();
		}

		public void Fire1Input(InputAction.CallbackContext input)
		{

			if (input.performed)
			{
				fire1 = true;
				Fire1Pressed?.Invoke();
			}

			if (input.canceled)
			{
				fire1 = false;
				Fire1Released?.Invoke();
			}

			DisableInControl();
		}

		public void InteractionInput(InputAction.CallbackContext input)
		{

			if (input.performed)
			{
				interaction = true;
				InteractionPressed?.Invoke();
			}

			if (input.canceled)
			{
				interaction = false;
				InteractionReleased?.Invoke();
			}

			DisableInControl();
		}

		public void ReloadInput(InputAction.CallbackContext input)
		{

			if (input.performed)
			{
				reload = true;
				ReloadPressed?.Invoke();
			}

			if (input.canceled)
			{
				reload = false;
				ReloadReleased?.Invoke();
			}

			DisableInControl();
		}

		public void RunInput(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				run = true;
				RunPressed?.Invoke();
			}

			if (input.canceled)
			{
				run = false;
				RunReleased?.Invoke();
			}

			DisableInControl();
		}

		public void InventoryInput(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				inventory = true;
				InventoryPressed?.Invoke();
			}

			if (input.canceled)
			{
				inventory = false;
				InventoryReleased?.Invoke();
			}

			DisableInControl();
		}

		public void JumpInput(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				jump = true;
				JumpPressed?.Invoke();
			}

			if (input.canceled)
			{
				jump = false;
				JumpReleased?.Invoke();
			}

			DisableInControl();
		}

		public void PauseInput(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				pause = true;
				PausePressed?.Invoke();
			}

			if (input.canceled)
			{
				pause = false;
				PauseReleased?.Invoke();
			}

			DisableInControl();
		}

		public void OneInput(InputAction.CallbackContext input)
		{
			if (input.performed)
			{
				oneButton = true;
				oneButtonPressed?.Invoke();
			}

			if (input.canceled)
			{
				oneButton = false;
				oneButtonReleased?.Invoke();
			}

			DisableInControl();
		}

		public void ChangeCameraInput(InputAction.CallbackContext input)
		{
			if (input.performed)
				ChangeCamera?.Invoke();
		}
	}
}