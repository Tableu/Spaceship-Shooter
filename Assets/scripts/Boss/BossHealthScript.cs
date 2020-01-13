using UnityEngine;

public class BossHealthScript : MonoBehaviour
{
	public int hp = 1;
	public int pointvalue;
	public bool isEnemy = true;

	public void Damage(int damageCount)
	{
		hp -= damageCount;

		if(hp <= 0)
		{
			ScoreBoardHelper.Instance.UpdateScore(pointvalue);
			Destroy(gameObject);
			SpecialEffectsHelper.Instance.Explosion(transform.position);
			SoundEffectsHelper.Instance.MakeExplosionSound();
		}
	}

	void OnTriggerEnter2D(Collider2D otherCollider)
	{
		ShotScript shot = otherCollider.gameObject.GetComponent<ShotScript> ();
		if(shot != null)
		{
			if(shot.isEnemyShot != isEnemy)
			{
				Damage(shot.damage);

				Destroy(shot.gameObject);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		bool damagePlayer = false;

		// Collision with enemy
		EnemyScript enemy = collision.gameObject.GetComponent<EnemyScript>();
		if (enemy != null)
		{
			// Kill the enemy
			HealthScript enemyHealth = enemy.GetComponent<HealthScript>();
			if (enemyHealth != null) enemyHealth.Damage(enemyHealth.hp);

			damagePlayer = true;
		}

		// Damage the player
		if (damagePlayer)
		{
			HealthScript playerHealth = this.GetComponent<HealthScript>();
			if (playerHealth != null) playerHealth.Damage(1);
		}
	}
}