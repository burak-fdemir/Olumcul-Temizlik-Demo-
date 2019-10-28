using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;
public class postProcessController : MonoBehaviour {


	public float postProcessControl = 3;
	// benim atayacağım değerler
	private float vignette_vignetting ;
	private float vignette_blurredCorners;
	private float vignette_blurDistance;

	private float bloom_threshold;
	private float bloom_intensity;

	private float noiseGrain_intensityMultplier;

	private float lerpTimeController;

	// objenin hali hazırda bulunan değerleri
//	private float _vignette_vignetting ;
//	private float _vignette_blurredCorners;
//	private float _vignette_blurDistance;
//	private bool _vignette_isEnabled;
//
//	private float _bloom_threshold;
//	private float _bloom_intensity;
//	private bool _bloom_isEnabled;
//
//	private float _noiseGrain_intensityMultplier;
//	private bool _noiseGrain_isEnabled;


	void Start(){
//		_vignette_isEnabled = GetComponent<VignetteAndChromaticAberration> ().enabled;
//		_vignette_vignetting = GetComponent<VignetteAndChromaticAberration> ().intensity;
//		_vignette_blurredCorners = GetComponent<VignetteAndChromaticAberration> ().blur;
//		_vignette_blurDistance = GetComponent<VignetteAndChromaticAberration> ().blurDistance;
//
//		_bloom_isEnabled = GetComponent<BloomOptimized> ().enabled;
//		_bloom_threshold = GetComponent<BloomOptimized> ().threshold;
//		_bloom_intensity = GetComponent<BloomOptimized> ().intensity;
//
//		_noiseGrain_isEnabled = GetComponent<NoiseAndGrain> ().enabled;
//		_noiseGrain_intensityMultplier = GetComponent<NoiseAndGrain> ().intensityMultiplier;


		vignette_vignetting = 0.265f;
		vignette_blurredCorners = 0.675f;
		vignette_blurDistance = 0.403f;

		bloom_threshold = 0.214f;
		bloom_intensity =0.99f;

		noiseGrain_intensityMultplier = 1.3f;
	
		lerpTimeController = 0.05f;
	}

	
	// Update is called once per frame
	void Update () {

		postProcess ();


	}


	void postProcess(){
	
		if (postProcessControl == 0) {
		
			postProcessToZero ();
		
		}


		if (postProcessControl == 1) {

			postProcessPlus ();

		}

		else if (postProcessControl == -1) {

		

			postProcessMinus ();



		
		}





	
	
	}

	public float arttır(float baslangıc, float bitis, float artıs){


		
		if (baslangıc < bitis) {
		
			return bitis * artıs;
			
		}

		return 0;
	
	}

	public float azalt(float azalacak, float bitis, float azalis){
	
		if (azalacak > bitis) {
		
			return azalacak * azalis ;
		
		}

		return 0;
	
	}


	public void toFalse( ){
	

		
			GetComponent<NoiseAndGrain> ().enabled = false;
			GetComponent<VignetteAndChromaticAberration> ().enabled = false;
			GetComponent<BloomOptimized> ().enabled = false;


	
	}

	public void postProcessToZero(){
	
		GetComponent<NoiseAndGrain> ().intensityMultiplier = 0;
		GetComponent<VignetteAndChromaticAberration> ().intensity = 0;
		GetComponent<VignetteAndChromaticAberration> ().blur = 0;
		GetComponent<VignetteAndChromaticAberration> ().blurDistance = 0;
		GetComponent<BloomOptimized> ().threshold = 0;
		GetComponent<BloomOptimized> ().intensity = 0;

		//Invoke ("toFalse",1f);
	
	}

	public void postProcessPlus(){
	
		GetComponent<NoiseAndGrain> ().enabled = true;
		GetComponent<NoiseAndGrain> ().intensityMultiplier += arttır (GetComponent<NoiseAndGrain> ().intensityMultiplier, noiseGrain_intensityMultplier,lerpTimeController);
			//noiseGrain_intensityMultplier;
			//arttır (GetComponent<NoiseAndGrain> ().intensityMultiplier, noiseGrain_intensityMultplier,lerpTimeController);
		//Mathf.Lerp(0, noiseGrain_intensityMultplier,0.13f);

		GetComponent<VignetteAndChromaticAberration> ().enabled = true;
		GetComponent<VignetteAndChromaticAberration> ().intensity += arttır (GetComponent<VignetteAndChromaticAberration> ().intensity, vignette_vignetting,lerpTimeController);  
			//vignette_vignetting;
			// arttır (GetComponent<VignetteAndChromaticAberration> ().intensity, vignette_vignetting,lerpTimeController);  
		//Mathf.Lerp(0, vignette_vignetting,0.026f);
		GetComponent<VignetteAndChromaticAberration> ().blur += arttır(GetComponent<VignetteAndChromaticAberration> ().blur, vignette_blurredCorners,lerpTimeController);
			//vignette_blurredCorners;
			//arttır(GetComponent<VignetteAndChromaticAberration> ().blur, vignette_blurredCorners,lerpTimeController);
		//Mathf.Lerp(0, vignette_blurredCorners,0.067f);
		GetComponent<VignetteAndChromaticAberration> ().blurDistance += arttır(GetComponent<VignetteAndChromaticAberration> ().blurDistance, vignette_blurDistance,lerpTimeController);
			//vignette_blurDistance;
			//arttır(GetComponent<VignetteAndChromaticAberration> ().blurDistance, vignette_blurDistance,lerpTimeController);
		//Mathf.Lerp(0, vignette_blurDistance,0.04f);

		GetComponent<BloomOptimized> ().enabled = true;
		GetComponent<BloomOptimized> ().threshold += arttır (GetComponent<BloomOptimized> ().threshold, bloom_threshold, lerpTimeController);
			//bloom_threshold;
			//arttır (GetComponent<BloomOptimized> ().threshold, bloom_threshold, lerpTimeController);
		// Mathf.Lerp(0,bloom_threshold,0.02f);
		GetComponent<BloomOptimized> ().intensity += arttır(GetComponent<BloomOptimized> ().intensity,bloom_intensity,lerpTimeController);
			//bloom_intensity;
			//arttır(GetComponent<BloomOptimized> ().intensity,bloom_intensity,lerpTimeController);
		//Mathf.Lerp(0,bloom_intensity,0.1f);
	
	
	}

	public void postProcessMinus(){


		GetComponent<NoiseAndGrain> ().intensityMultiplier -= azalt (GetComponent<NoiseAndGrain> ().intensityMultiplier, 0,lerpTimeController);
		//noiseGrain_intensityMultplier;
		//arttır (GetComponent<NoiseAndGrain> ().intensityMultiplier, noiseGrain_intensityMultplier,lerpTimeController);
		//Mathf.Lerp(0, noiseGrain_intensityMultplier,0.13f);


		GetComponent<VignetteAndChromaticAberration> ().intensity -= azalt (GetComponent<VignetteAndChromaticAberration> ().intensity, 0,lerpTimeController);  
		//vignette_vignetting;
		// arttır (GetComponent<VignetteAndChromaticAberration> ().intensity, vignette_vignetting,lerpTimeController);  
		//Mathf.Lerp(0, vignette_vignetting,0.026f);
		GetComponent<VignetteAndChromaticAberration> ().blur -= azalt(GetComponent<VignetteAndChromaticAberration> ().blur, 0,lerpTimeController);
		//vignette_blurredCorners;
		//arttır(GetComponent<VignetteAndChromaticAberration> ().blur, vignette_blurredCorners,lerpTimeController);
		//Mathf.Lerp(0, vignette_blurredCorners,0.067f);
		GetComponent<VignetteAndChromaticAberration> ().blurDistance -= azalt(GetComponent<VignetteAndChromaticAberration> ().blurDistance, 0,lerpTimeController);
		//vignette_blurDistance;
		//arttır(GetComponent<VignetteAndChromaticAberration> ().blurDistance, vignette_blurDistance,lerpTimeController);
		//Mathf.Lerp(0, vignette_blurDistance,0.04f);


		GetComponent<BloomOptimized> ().threshold -= azalt (GetComponent<BloomOptimized> ().threshold, 0, lerpTimeController);
		//bloom_threshold;
		//arttır (GetComponent<BloomOptimized> ().threshold, bloom_threshold, lerpTimeController);
		// Mathf.Lerp(0,bloom_threshold,0.02f);
		GetComponent<BloomOptimized> ().intensity -= azalt(GetComponent<BloomOptimized> ().intensity,0,lerpTimeController);
		//bloom_intensity;
		//arttır(GetComponent<BloomOptimized> ().intensity,bloom_intensity,lerpTimeController);
		//Mathf.Lerp(0,bloom_intensity,0.1f);


	}




}
