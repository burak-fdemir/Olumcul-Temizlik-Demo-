using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class loadScene : MonoBehaviour {

    public VideoPlayer vp = new VideoPlayer();

	void Start () {
        
	}
	
	
	void Update () {
        Invoke("videoControl",2f);
	}


    public void videoControl() {
        if (!vp.isPlaying)
        {
            SceneManager.LoadScene("HaseratTemizlik");

        }


    }
}
