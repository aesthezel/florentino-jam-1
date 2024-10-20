using System;
using UnityEngine;
using VG.Inputs;

namespace Gameplay.Controllers
{
	public class RaycastInputController : MonoBehaviour
	{
		public static RaycastInputController Instance { get; private set; }

		[Header("Move layer")]
		[SerializeField] LayerMask moveLayer;

		public Action<Vector3> OnMoveInput;

		//Cache
		Camera mainCamera;

		//Physics
		Ray ray;
		RaycastHit hit;

		void Awake()
		{
			Instance = this;

			mainCamera = Camera.main;
		}

		private void Start()
		{
			InputController.Instance.Fire0Pressed += UpdateMoveInput;
		}

		private void UpdateMoveInput() 
		{
			if (Input.GetButtonDown("Fire1"))
				CastMoveInput();
		}

		private void CastMoveInput() 
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100, moveLayer))
				OnMoveInput?.Invoke(hit.point);
		}
	}
}