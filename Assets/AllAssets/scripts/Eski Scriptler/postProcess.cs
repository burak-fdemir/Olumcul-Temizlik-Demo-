//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.PostProcessing;
//
//
//public class postProcess : MonoBehaviour {
//
//	private PostProcessingBehaviour ppBehaviour= null;
//	private PostProcessingProfile ppp = null;
//
//	public int postProcessBehaviourController = 0;
//
//	private Color vignetteColor;
//	private float vignetteSmoothness = 0f;
//	private float bloomIntensity = 0f;
//	private float bloomthreshold = 0f;
//
//
//
//
//	// Use this for initialization
//	void Start () {
//		
//		ppBehaviour = GetComponent<PostProcessingBehaviour> ();
//
//		ppp = ppBehaviour.profile;
//
//		vignetteColor = Color.red;
//		vignetteSmoothness = 0.331f;
//		bloomIntensity = 0.66f;
//		bloomthreshold =  0.17f;
//
//
//	}
//	
//	// Update is called once per frame
//	void Update () {
//		if (postProcessBehaviourController == 1) {
//			ppp.vignette.enabled = true;
////			ppp.vignette.settings.color = Color.red;
////			ppp.vignette.settings.smoothness = vignetteSmoothness;
//
//
//
//			ppp.bloom.enabled = true;
////			ppp.bloom.settings.bloom.intensity = bloomIntensity;
////			ppp.bloom.settings.bloom.threshold = bloomthreshold;
//		} 
//		else {
//	
//			ppp.vignette.enabled = false;
//			ppp.bloom.enabled = false;
//		
//		}
//	}
//}
