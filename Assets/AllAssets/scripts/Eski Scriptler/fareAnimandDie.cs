using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fareAnimandDie : MonoBehaviour {

	void OnTriggerEnter(Collider playerObjects){

//		if (playerObjects.CompareTag ("Player")) {
//
//			gameObject.GetComponentInChildren<Animator> ().SetBool ("yakınMı", true);
//		
//		}


		if (playerObjects.CompareTag ("mermi")) {

            GameObject.Find("FPSController").GetComponentInChildren<postProcessController>().postProcessControl = -1;

            GameObject.Find("FPSController").GetComponentInChildren<postProcessController>().postProcessControl = 0;


            Destroy (gameObject);
			Destroy (playerObjects);
		}




	}
}
//	void OnTriggerExit(Collider playerObjects){
//	
//		gameObject.GetComponentInChildren<Animator> ().SetBool ("yakınMı", false);
//	
//	}






