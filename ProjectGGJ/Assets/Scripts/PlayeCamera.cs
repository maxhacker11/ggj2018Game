using UnityEngine;

public class PlayeCamera : MonoBehaviour {

	[HideInInspector]
	public bool activeOne;

	public GameObject player1;
	public GameObject player2;

	public float smoothSpeed = 0.1f;
	public float particleMoveSpeed;
	public Vector3 offset;

	Transform target;
	bool playerReached;

	void Start()
	{
		//The first player is active by default
		activeOne = true;
		target = player1.transform;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E)) 
		{ 
			//If the first player is active set the second on as target
			if (activeOne) {
				target = player2.transform;
				player1.GetComponent<PlayerMovement> ().enabled = false;
				player2.GetComponent<PlayerMovement> ().enabled = true;
				activeOne = false;

				//If we reached THIS player set the particles pos to his pos and disable them
				if (playerReached) {
					soulParticle.transform.position = player1.transform.position;
					soulParticle.Play(false);
				}
			} else {
				target = player1.transform;
				player1.GetComponent<PlayerMovement> ().enabled = true;
				player2.GetComponent<PlayerMovement> ().enabled = false;
				activeOne = true;

				//If we reached THIS player set the particles pos to his pos and disable them
				if (playerReached) {
					soulParticle.transform.position = player2.transform.position;
					soulParticle.Play(false);
				}
			}

			soulParticle.Play(true);
			//Move the particles to the new active player
			MoveParticles(target);
		}
	}

	void FixedUpdate()
	{
		Vector3 desiredPos = target.position + offset;
		Vector3 smoothPos = Vector3.Lerp (transform.position, desiredPos, smoothSpeed);
		transform.position = smoothPos;
	}

	void MoveParticles(Transform targetPlayer)
	{
		playerReached = false;
		soulParticle.transform.position = Vector3.Lerp (player2.transform.position, targetPlayer.position, particleMoveSpeed);
		//If we have reached the player
		if (transform.position == targetPlayer.position) {
			playerReached = true;
		}
	}
}