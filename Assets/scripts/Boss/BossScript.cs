using UnityEngine;
using System.Collections;

public class BossScript : MonoBehaviour
{
	private bool hasSpawn;
	private ScrollingScript scrollingScript;
	private WeaponScript[] weapons;
	private Collider2D coliderComponent;
	private SpriteRenderer rendererComponent;
	private BossMoveScript moveScript;

	void Awake()
	{
		weapons = GetComponentsInChildren<WeaponScript>();

		scrollingScript = GetComponent<ScrollingScript>();

		coliderComponent = GetComponent<Collider2D>();

		rendererComponent = GetComponent<SpriteRenderer>();

		moveScript = GetComponent<BossMoveScript> ();
	}
		
	void Start()
	{
		hasSpawn = false;
		coliderComponent.enabled = false;
		scrollingScript.enabled = false;
		moveScript.enabled = false;
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = false;
		}
	}

	void Update()
	{
		if (hasSpawn == false)
		{
			if (rendererComponent.IsVisibleFrom(Camera.main))
			{
				StartCoroutine (SpawnCall ());
			}
		}
		else
		{

			// 4 - Out of the camera ? Destroy the game object.
			if (rendererComponent.IsVisibleFrom(Camera.main) == false)
			{
				Destroy(gameObject);
			}
		}
		foreach (WeaponScript weapon in weapons)
		{
			// Auto-fire
			if (weapon != null && weapon.CanAttack)
			{
				weapon.Attack(true);
			}
		}
	}

	void OnDestroy()
	{
		// Game Over.
		var gameOver = FindObjectOfType<GameOverScript>();
		gameOver.ShowButtons();
	}

	IEnumerator SpawnCall()
	{
		yield return new WaitForSeconds (2);
		Spawn ();
	}

	// 3 - Activate itself.
	private void Spawn()
	{
		hasSpawn = true;
		coliderComponent.enabled = true;
		scrollingScript.enabled = true;
		moveScript.enabled = true;
		foreach (WeaponScript weapon in weapons)
		{
			weapon.enabled = true;
		}
	}
}