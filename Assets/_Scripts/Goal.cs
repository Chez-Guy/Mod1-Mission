using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Renderer))]
public class Goal : MonoBehaviour{
	static public bool 	goalMet = false;
	ScoreManager sm;
	SceneLoader loader;
	public int nextScene;
    void Start()
    {
        sm = GameObject.Find("GameController").GetComponent<ScoreManager>();
		loader = GameObject.Find("SceneLoader").GetComponent<SceneLoader>();
    }

    void OnTriggerEnter(Collider other) {
		// when the trigger is hit by something
		// check to see if it's a Projectile 
		Projectile proj = other.GetComponent<Projectile>();
		if (proj != null) {
			// if so, set goalMet = true
			Goal.goalMet = true;

			// also set the alpha of the color of higher opacity
			Material mat = GetComponent<Renderer>().material;
			Color c = mat.color;
			c.a = 0.75f;
			mat.color = c;

			StartCoroutine(LoadNextScene());			
		}
	}

	IEnumerator LoadNextScene()
	{
		yield return new WaitForSeconds(3);
		loader.LoadScene(nextScene);
	}
}
