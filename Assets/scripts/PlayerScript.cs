using UnityEngine;

/// <summary>
/// Player controller and behavior
/// </summary>
public class PlayerScript : MonoBehaviour
{
	/// <summary>
	/// 1 - The speed of the ship
	/// </summary>
	public Vector2 speed = new Vector2(50, 50);
	public AudioClip otherclip;
	public GameObject Foreground;
	AudioSource audio;
	// 2 - Store the movement and the component
	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Start() {
		audio = GetComponent<AudioSource>();
	}

	void Update()
	{
		// 3 - Retrieve axis information
		float inputY = Input.GetAxis("Horizontal");
		float inputX = Input.GetAxis("Vertical");

		// 4 - Movement per direction
		movement = new Vector2(
			speed.y * inputY,
			speed.x * inputX);

		bool shoot = Input.GetButton("Fire1");
		shoot |= Input.GetButton("Fire2");

		if (shoot)
		{
			WeaponScript weapon = GetComponent<WeaponScript>();
			if (weapon != null)
			{
				// false because the player is not an enemy
				weapon.Attack(false);
				if (!audio.isPlaying) {
					audio.clip = otherclip;
					audio.Play ();
				}
			}
		}
		var dist = (transform.position - Camera.main.transform.position).z;

		var leftBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).x;

		var rightBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(1, 0, dist)
		).x;

		var topBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 0, dist)
		).y;

		var bottomBorder = Camera.main.ViewportToWorldPoint(
			new Vector3(0, 1, dist)
		).y;

		transform.position = new Vector3(
			Mathf.Clamp(transform.position.x, leftBorder, rightBorder),
			Mathf.Clamp(transform.position.y, topBorder, bottomBorder),
			transform.position.z
		);

	}

	void OnDestroy()
	{
		// Game Over.
		var gameOver = FindObjectOfType<GameOverScript>();
		gameOver.ShowButtons();
		Time.timeScale = 0;
	}

	void FixedUpdate()
	{
		// 5 - Get the component and store the reference
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		// 6 - Move the game object
		rigidbodyComponent.velocity = movement;
	}
}