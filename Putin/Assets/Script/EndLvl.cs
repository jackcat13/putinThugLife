using UnityEngine;
using System.Collections;

public class EndLvl : MonoBehaviour {
	private bool jetpackPlaced;
	// Use this for initialization
	void Start () {
		jetpackPlaced = false;

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Player" && !jetpackPlaced )
		{
			GameObject jetpack= Instantiate(Resources.Load("Jetpack"), new Vector3(0,0,0), new Quaternion(0,0,0,0)) as GameObject;
			jetpack.transform.parent = other.transform;
			jetpack.transform.localPosition = new Vector2(0,0);
			other.GetComponent<UnityStandardAssets._2D.Platformer2DUserControl>().enabled = false;
			jetpackPlaced = true;
			other.GetComponent<Rigidbody2D>().gravityScale = 0;
			other.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 500));	

		}
	}
}
