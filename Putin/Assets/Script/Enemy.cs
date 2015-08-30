using UnityEngine;
using System.Collections;


public class Enemy : UnityStandardAssets._2D.Perso 
{

	private UnityStandardAssets._2D.PlatformerCharacter2D m_Character;
	// Use this for initialization
	void Start () 
	{
	
	}

	private void Awake()
	{
		m_Character = GetComponent<UnityStandardAssets._2D.PlatformerCharacter2D>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate () 
	{
		//Si le player existe
		if(GameObject.FindWithTag("Player") != null)
		{
			float dist = transform.position.x- GameObject.FindWithTag("Player").transform.position.x;

			if(Mathf.Abs(dist) < 	15 && Mathf.Abs(dist) > 5)
			{
				m_Character.Move (-0.5f*(dist/Mathf.Abs(dist)),false,false);
			}
		}
	}
}
