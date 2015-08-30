using UnityEngine;
using System.Collections;

public class BeginScene : MonoBehaviour 
{
	public GameObject player;
	public GameObject tardis;
	public bool endDebut;

	// Use this for initialization
	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(!endDebut)
		{
			if(tardis.GetComponent<ArriveTardis>().playerOK)
			{
				player = Instantiate (Resources.Load ("Player"), new Vector2 (0, 0), new Quaternion (0, 0, 0, 0)) as GameObject;
				player.transform.parent = tardis.transform;
				player.transform.localPosition = new Vector2(0, 0);
				player.transform.parent = null;

				player.AddComponent<AudioSource>().clip = Resources.Load("Sound/Surprise") as AudioClip;
				player.GetComponent<AudioSource>().Play();
					//player.GetComponent<AudioClip>()
				//Suivi de la caméra
				Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().enabled = true;
				Camera.main.GetComponent<UnityStandardAssets._2D.Camera2DFollow>().target = player.transform;
				tardis.GetComponent<ArriveTardis>().playerOK = false;	
				endDebut = true;
			}
		}
	}
}
