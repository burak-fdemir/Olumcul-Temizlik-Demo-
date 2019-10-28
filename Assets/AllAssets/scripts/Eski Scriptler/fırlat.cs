using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fırlat : MonoBehaviour {

	public Rigidbody mermi;



	void Update () {
		firlat ();
	}

	public void firlat(){
	
		if (Input.GetMouseButtonDown (0)) {

			Rigidbody firlatilan;
			firlatilan = Instantiate (mermi, gameObject.transform.position, Quaternion.identity) as Rigidbody;
			firlatilan.velocity = transform.TransformDirection (Vector3.forward * 20);

		}	
	
	}
}
