﻿using UnityEngine;
using System.Collections;


public class Enemy : UnityStandardAssets._2D.Perso 
{
	
	private UnityStandardAssets._2D.PlatformerEnemy2D m_Character;
	// Use this for initialization
	void Start () 
	{
		m_Vie = 10;
	}

	private void Awake()
	{
		m_Character = GetComponent<UnityStandardAssets._2D.PlatformerEnemy2D>();
	}
	
	// Update is called once per frame
	/*void Update () {
		GestionVie ();
	}*/

	void FixedUpdate () 
	{
		//Si le player existe
		if(GameObject.FindWithTag("Player") != null)
		{
			float dist = transform.position.x- GameObject.FindWithTag("Player").transform.position.x;
			if(Mathf.Abs(dist) < 15)
			{
				m_Character.Move (-1*(dist/Mathf.Abs(dist)),false,false);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Debug.Log ("LOL");
	}
}
