using UnityEngine;

public class PlayeCamera : MonoBehaviour {

	[HideInInspector]
	public bool activeOne;

	public GameObject player1;
	public GameObject player2;

	public float smoothSpeed = 0.1f;
	public Vector3 offset;

	Transform target;
	[SerializeField]
	GameObject particlePrefab;
	GameObject soulParticleInstance;

	[SerializeField]
	float transmissionDelay = 3.0f;
	float lastTransmission;

	void Start()
	{
		//The first player is active by default
		activeOne = true;
		target = player1.transform;
		lastTransmission = -transmissionDelay;
	}

	void Update()
	{
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothPos = Vector3.Lerp (desiredPos, transform.position, smoothSpeed);
		transform.position = smoothPos;

		if (Input.GetKeyDown (KeyCode.E) && Time.time - lastTransmission > transmissionDelay) 
		{ 
			lastTransmission = Time.time;
			//If the first player is active set the second on as target
			if (activeOne) {
				soulParticleInstance = Instantiate (particlePrefab, player1.transform.position, transform.rotation) as GameObject;
				target = player2.transform;
				player1.GetComponent<PlayerMovement> ().animator.SetFloat ("Move", 0.0f);
				player1.GetComponent<PlayerMovement> ().enabled = false;
				player2.GetComponent<PlayerMovement> ().enabled = true;
				activeOne = false;
			} else {
				soulParticleInstance = Instantiate (particlePrefab, player2.transform.position, transform.rotation) as GameObject;
				target = player1.transform;
				player2.GetComponent<PlayerMovement> ().animator.SetFloat ("Move", 0.0f);
				player1.GetComponent<PlayerMovement> ().enabled = true;
				player2.GetComponent<PlayerMovement> ().enabled = false;
				activeOne = true;
			}
			soulParticleInstance.GetComponent<ParticleMovement> ().target = target;
		}
	}
}