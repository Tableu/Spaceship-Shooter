using UnityEngine;

/// <summary>
/// Simply moves the current game object
/// </summary>
public class EnemyMoveScript : MonoBehaviour
{
	public Transform[] waypointArray;
	private SpriteRenderer rendererComponent;
	float percentsPerSecond = 0.5f; // %2 of the path moved per second
	float currentPathPercent = 0.0f; //min 0, max 1

	void Update () 
	{
		currentPathPercent += percentsPerSecond * Time.deltaTime;
		iTween.PutOnPath(gameObject, waypointArray, currentPathPercent);
	}

	void OnDrawGizmos()
	{
		//Visual. Not used in movement
		iTween.DrawPath(waypointArray);
	}
}