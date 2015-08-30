using UnityEngine;
using System.Collections;

public class SmirnoffManagement : MonoBehaviour {

	private int p_direction;

	public int direction
	{
		get { return p_direction; }
		set { p_direction = value; }
	}

	// Use this for initialization
	void Start () {
	
		this.GetComponent<Rigidbody2D> ().AddForce(new Vector2(500*p_direction,300));
	}
	
	// Update is called once per frame
	void Update () {
	
		this.transform.Rotate (new Vector3(0, 0, 300*Time.deltaTime*-p_direction));
	}

	void OnTriggerEnter2D (Collider2D other){

		//If the bottle hits something else than the player and another Smirnoff bottle
		if (other.tag != "Player" && other.tag != "Smirnoff") {

			Destroy (this.gameObject);
		}
	}

}
