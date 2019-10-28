using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boruFareSesiCal : MonoBehaviour {

	public AudioClip waterPipe;
	//public AudioClip ratSquezee;


	void OnTriggerEnter(Collider playerGeldiMi){



		if (playerGeldiMi.gameObject.tag == "Player") {
			

			GetComponent<AudioSource> ().clip = waterPipe;
			GetComponent<AudioSource> ().Play ();
			//GetComponent<AudioSource> ().maxDistance = 5f;
			//float timeDelay = Mathf.Lerp (0, 20f, 4f);
			//GetComponent<AudioSource> ().PlayOneShot(ratSquezee);

		}
			
	}


}
