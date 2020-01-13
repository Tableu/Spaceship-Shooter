using UnityEngine.UI;
using UnityEngine;

public class ScoreBoardHelper : MonoBehaviour {
	public int points = 0;
	public Text score;
	public static ScoreBoardHelper Instance;
	void Awake()
	{
		// Register the singleton
		if (Instance != null)
		{
			Debug.LogError("Multiple instances of SpecialEffectsHelper!");
		}

		Instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		score.text = points.ToString();
	}

	public void UpdateScore(int pointvalue)
	{
		points += pointvalue;
	}
}
