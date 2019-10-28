using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsInsanController : MonoBehaviour {



	private Transform fpsPosition = null;

	public float moveSpeed= 2f;
	public float RotationSpeed = 45f;


	private void Awake(){
	
		fpsPosition = GetComponent<Transform> ();
	
	}

	private void Update(){
	
		float horizontalMovement = Input.GetAxis ("Horizontal");
		float verticalMovement = Input.GetAxis ("Vertical");

		fpsPosition.Rotate (0f, horizontalMovement * Time.deltaTime * RotationSpeed, 0f);
		fpsPosition.position += fpsPosition.forward * moveSpeed * Time.deltaTime * verticalMovement;
	
	}




}
