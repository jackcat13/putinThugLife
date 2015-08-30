using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Poutine : UnityStandardAssets._2D.Perso {
	//private List<Monture> Monture;


	// Use this for initialization
	void Start () {
		m_Vie = 3;
	}

	// Update is called once per frame
	void Update () {
		GestionVie ();
	}

	void OnCollisionEnter2D( Collision2D other){
		Debug.Log ("blbl");
		if (other.gameObject.tag == "Enemy") {
			Debug.Log ("enemy" );
			Touche (1);
		}

	//	if (other.gameObject.tag == "Enemy") {
	//		float dist = transform.position.x- GameObject.FindWithTag("Player").transform.position.x;
			//other.gameObject.GetComponent<Rigidbody2D>().AddForce( new Vector2(200 * dist/Mathf.Abs(dist),100));

		//}
	}
}
