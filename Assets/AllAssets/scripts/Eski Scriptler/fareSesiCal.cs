using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fareSesiCal : MonoBehaviour {


	public AudioClip ratSqueeze;
	//public AudioClip ratSquezee;


	void OnTriggerEnter(Collider playerGeldiMi){



		if (playerGeldiMi.gameObject.tag == "Player") {


			GetComponent<AudioSource> ().clip = ratSqueeze;
			GetComponent<AudioSource> ().Play ();
			//GetComponent<AudioSource> ().PlayDelayed (2f);
			//float timeDelay = Mathf.Lerp (0, 20f, 4f);
			//GetComponent<AudioSource> ().PlayOneShot(ratSquezee);

		}

	}


}
