using UnityEngine;

namespace Gameplay.Controllers
{
	public class CameraController : MonoBehaviour
	{
		[Header("Camera Target")]
		[SerializeField] private Transform target;
		[SerializeField][Range(1, 15)] private float followSpeed = 5;

		// Start is called before the first frame update
		void Start()
		{

		}

		// Update is called once per frame
		void LateUpdate()
		{
			CameraFollow();
		}

		void CameraFollow()
		{
			if (target)
			{
				transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * followSpeed);
			}
		}
	}
}