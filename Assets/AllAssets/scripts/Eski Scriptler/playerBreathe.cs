using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerBreathe : MonoBehaviour {

	public AudioClip breathe ;

	//public int breatheController = 0;


	//void start(){

 //       GetComponent<AudioSource>().clip = breathe;

 //   }

	// Update is called once per frame
	//void Update () {
 //       sesCalinsinMi();

 //   }

    public void KorkmaSesiCal() {

      

            GetComponent<AudioSource>().PlayOneShot(breathe);

       


    }
}
