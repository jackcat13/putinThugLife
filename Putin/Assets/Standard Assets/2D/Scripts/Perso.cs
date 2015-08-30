using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityStandardAssets.CrossPlatformInput;

namespace UnityStandardAssets._2D
{

	public class Perso : MonoBehaviour {
		protected int m_Vie;
		protected const int VIEMAX=10;
		protected bool invulnerable;
		//private List<Arme> m_Armes;

		// Use this for initialization
		void Start () {
		
		}
		
		// Update is called once per frame
		void Update () {
			GestionVie ();
		}

		public void Touche(int Degat){
			m_Vie -= Degat;
		}

		protected void GestionVie(){
			if (m_Vie > VIEMAX) {
				m_Vie = VIEMAX;
			}
			else if (m_Vie <= 0){
				Destroy(this.gameObject);
			}
		}
	}
}