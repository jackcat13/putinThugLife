using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ArriveTardis : MonoBehaviour 
{
	private float alpha;
	public bool playerOK;
	public bool disappear;
	private int phase;

	private bool rightOpened;
	private bool leftOpened;

	public List<GameObject> tardisPart;

	// Use this for initialization
	void Start () 
	{
		playerOK = false;
		disappear = false;
		phase = 1;
		for(int i =0; i<tardisPart.Count; i++)
		{
			Color oldColor = tardisPart[i].GetComponent<SpriteRenderer> ().color;
			tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, 0);
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		//IT WORKS
		for(int i =0; i<tardisPart.Count; i++)
		{
			//Phase 1 -> 5 : apparition du Tardis
			//Phase 5 	   : apparition du perso
			//Phase 6      : ouverture des portes puis suppression de ce script
			Color oldColor = tardisPart[i].GetComponent<SpriteRenderer> ().color;
			switch(phase)
			{
			case 1:
				if(tardisPart[i].GetComponent<SpriteRenderer>().color.a < 0.3f)	
				{
					tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + 0.3f	 * Time.deltaTime);
				}
				else
				{
					phase = 2;
				}
				break;
			case 2:
				if(tardisPart[i].GetComponent<SpriteRenderer>().color.a > 0.1f)
				{
					tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a - 0.3f	 * Time.deltaTime);
				}
				else
				{
					phase = 3;
				}
				break;
			case 3:
				if(tardisPart[i].GetComponent<SpriteRenderer>().color.a < 0.5f)
				{
					tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + 0.3f	 * Time.deltaTime);
				}
				else
				{
					phase = 4;
				}
				break;
			case 4:
				if(tardisPart[i].GetComponent<SpriteRenderer>().color.a > 0.2f)
				{
					tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a - 0.3f	 * Time.deltaTime);
				}
				else
				{
					phase = 5;
				}
				break;
			case 5:
				if(tardisPart[i].GetComponent<SpriteRenderer>().color.a < 1)
				{
					tardisPart[i].GetComponent<SpriteRenderer> ().color = new Color(oldColor.r, oldColor.g, oldColor.b, oldColor.a + 0.7f	 * Time.deltaTime);
				}
				else
				{
					phase = 6;
					playerOK = true;
				}
				break;
			case 6:
				if(!rightOpened && !leftOpened)
				{
					//PorteGauche
					if(tardisPart[0].transform.localScale.x > 0.3f)
					{
						tardisPart[0].transform.localScale -= new Vector3(0.2f*Time.deltaTime, 0, 0);
						tardisPart[0].transform.localPosition -= new Vector3(0.02f*Time.deltaTime, 0, 0);
					}
					else
					{
						leftOpened = true;
					}
					//PorteDroite
					if(tardisPart[1].transform.localScale.x > 0.3f)
					{
						tardisPart[1].transform.localScale -= new Vector3(0.2f*Time.deltaTime, 0, 0);
						tardisPart[1].transform.localPosition += new Vector3(0.02f*Time.deltaTime, 0, 0);
					}
					else
					{
						rightOpened = true;
					}
				}
				else
				{
					tardisPart[0].GetComponent<SpriteRenderer>().sortingOrder = 0;
					tardisPart[1].GetComponent<SpriteRenderer>().sortingOrder = 0;
					Destroy(this.GetComponent<ArriveTardis>());
				}
				break;
			default:
				break;
			}
		}
	}
}
