using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class BossMoveScript : MonoBehaviour
{
	public Vector2 speed = new Vector2(10, 10);
	private SpriteRenderer rendererComponent;
	public Vector2 direction = new Vector2(-1, 0);

	private Vector2 movement;
	private Rigidbody2D rigidbodyComponent;

	void Start()
	{
		movement = new Vector2(
			speed.x * direction.x,
			speed.y * direction.y);
	}

	void Update()
	{

		if (GameObject.Find("Boss").transform.position.x > 2.5){
			movement = new Vector2(
				speed.x * -direction.x,
				speed.y * direction.y);
		}
		if (GameObject.Find("Boss").transform.position.x < -7) {
			movement = new Vector2(
				speed.x * direction.x,
				speed.y * direction.y);
		}
	}

	void FixedUpdate()
	{
		if (rigidbodyComponent == null) rigidbodyComponent = GetComponent<Rigidbody2D>();

		rigidbodyComponent.velocity = movement;
	}
}