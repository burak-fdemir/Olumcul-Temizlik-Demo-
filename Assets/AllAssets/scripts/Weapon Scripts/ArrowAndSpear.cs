using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowAndSpear : MonoBehaviour {


    private Rigidbody weaponBody;

    public float speed = 30;
    public float deactiveTimer = 3f;
    public float damage = 15f;
	
    void Awake() {

        weaponBody = GetComponent<Rigidbody>();
    
    }

	void Start () {


        Invoke("DeactiveGameObject",deactiveTimer);

	}
	
	public void Launch(Camera mainCamera) {

        weaponBody.velocity = mainCamera.transform.forward * speed;

        transform.LookAt(transform.position + weaponBody.velocity);
    
    }

	void Update () {
		
	}

    void DeactiveGameObject() {

        if (gameObject.activeInHierarchy) {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider other) { 
    
        
    
    }
















}//class
