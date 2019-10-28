using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class gecis : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Invoke("sceneLoad",3 );
	}

    void sceneLoad() {

        SceneManager.LoadScene("HaseratTemizlik");


    }
	
}
