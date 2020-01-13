using UnityEngine;
using System.Collections;

public class BulletDespawnScript : MonoBehaviour {

	// Use this for initialization
	private SpriteRenderer rendererComponent;
	void Start () {
		rendererComponent = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		if (rendererComponent.IsVisibleFrom(Camera.main) == false)
		{
			Destroy(gameObject);
		}
	}
}
