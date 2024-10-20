using System;
using GamePlay.Patterns;
using GamePlay.VFX;
using UnityEngine;
using VG.Inputs;

namespace Gameplay.Controllers
{
	public class RaycastInputController : MonoBehaviour
	{
		public static RaycastInputController Instance { get; private set; }

		[Header("Move layer")]
		[SerializeField] LayerMask moveLayer;

		[SerializeField]
		private MovePointerParticle movePointerParticlePrefab;
		
		private FlexibleMonoBehaviorPool<MovePointerParticle> _movePointerParticlePool;
		
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
			InputController.Instance.Fire0Pressed += CastMoveInput;
			_movePointerParticlePool = new FlexibleMonoBehaviorPool<MovePointerParticle>(movePointerParticlePrefab, 1, 100);
		}

		private void CastMoveInput() 
		{
			ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			if (Physics.Raycast(ray, out hit, 100, moveLayer))
			{
				if (hit.collider.gameObject.tag == "Interactable")
					return;

                OnMoveInput?.Invoke(hit.point);
				_movePointerParticlePool.GetObject(hit.point);
			}
		}
	}
}