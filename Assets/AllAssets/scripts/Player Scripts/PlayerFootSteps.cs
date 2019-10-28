using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootSteps : MonoBehaviour {

    private AudioSource footStepSound;
    
    [SerializeField]
    private AudioClip[] footStepClip;

    private CharacterController characterController;

    [HideInInspector]
    public float volMin, volMax;

    private float accumulatedDistance;

    [HideInInspector]
    public float stepDistance;
	void Awake () {

        footStepSound = GetComponent<AudioSource>();
        characterController = GetComponentInParent<CharacterController>();
	}
	void Update () {
        ChecktoPlayFootStepSound();

    }

    void ChecktoPlayFootStepSound() {

        if (!characterController.isGrounded)
            return;

        if(characterController.velocity.sqrMagnitude > 0) {

            accumulatedDistance += Time.deltaTime;

            if(accumulatedDistance > stepDistance) {
                footStepSound.volume = Random.Range(volMin,volMax);
                footStepSound.clip = footStepClip[Random.Range(0, footStepClip.Length)];
                footStepSound.Play();

                accumulatedDistance = 0f;
            }
        
        }
        else {
            accumulatedDistance = 0f;
        }
    }
}
