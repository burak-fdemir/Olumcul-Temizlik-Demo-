using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintandCrouch : MonoBehaviour {

    private PlayerMovement playerMovement;

    private CharacterController characterController;

    public float sprintSpeed = 10f;
    public float moveSpeed = 5;
    public float crouchSpeed = 2;

    private Transform lookRoot;
    private float standHeight = 1.6f;
    private float crouchHeight = 1f;

    private bool isCrouching;

    private PlayerFootSteps playerFootSteps;

    private float sprintVolume = 1f;
    private float crouchVolume = .1f;
    private float walkVolumeMin = .2f, walkVolumeMax = .6f;

    private float walkStepDistance = 0.4f;
    private float sprintStepDistance = 0.25f;
    private float crouchStepDistance = 0.5f;

    private PlayerStats playerStats;
    private float sprintValue = 100f;
    public float sprintTreshold = 10f;
	void Awake(){

        playerMovement = GetComponent<PlayerMovement>();

        characterController = GetComponent<CharacterController>();

        lookRoot = transform.GetChild(0);

        playerFootSteps = GetComponentInChildren<PlayerFootSteps>();

        playerStats = GetComponent<PlayerStats>();
    }

    void Start()
    {
        playerFootSteps.stepDistance = walkStepDistance;
        playerFootSteps.volMin = walkVolumeMin;
        playerFootSteps.volMax = walkVolumeMax;
        

    }

	void Update () {
        Sprint();
        Crouch();
	}

    private void Sprint() { 
        if(sprintValue > 0) {
            if (Input.GetKeyDown(KeyCode.LeftShift) && !isCrouching 
                && characterController.velocity.sqrMagnitude > 0)
            {
                playerMovement.speed = sprintSpeed;

                playerFootSteps.stepDistance = sprintStepDistance;
                playerFootSteps.volMin = sprintVolume;
                playerFootSteps.volMax = sprintVolume;
            }

        }

        if(Input.GetKeyUp(KeyCode.LeftShift) && !isCrouching) {
            playerMovement.speed = moveSpeed;

            playerFootSteps.stepDistance = walkStepDistance;
            playerFootSteps.volMin = walkVolumeMin;
            playerFootSteps.volMax = walkVolumeMax;
        }

        if(Input.GetKey(KeyCode.LeftShift) && !isCrouching && characterController.velocity.sqrMagnitude > 0) {

            sprintValue -= sprintTreshold * Time.deltaTime;

            if(sprintValue <= 0) {
                sprintValue = 0;

                playerMovement.speed = moveSpeed;

                playerFootSteps.stepDistance = walkStepDistance;
                playerFootSteps.volMin = walkVolumeMin;
                playerFootSteps.volMax = walkVolumeMax;


            }

            playerStats.DisplayStaminaStats(sprintValue);

        }
        else { 
            if(sprintValue != 100) {
                sprintValue += (sprintTreshold / 2) * Time.deltaTime;
                playerStats.DisplayStaminaStats(sprintValue);

                if (sprintValue > 100)
                    sprintValue = 100;
            }
        
        }
    
    }

    private void Crouch() {
        if (Input.GetKeyDown(KeyCode.C)) {
            if (isCrouching) {

                lookRoot.localPosition = new Vector3(0f, standHeight, 0f);
                playerMovement.speed = moveSpeed;

                playerFootSteps.stepDistance = walkStepDistance;
                playerFootSteps.volMin = walkVolumeMin;
                playerFootSteps.volMax = walkVolumeMax;

                isCrouching = false;
            }
            else {
                lookRoot.localPosition = new Vector3(0f, crouchHeight, 0f);
                playerMovement.speed = crouchSpeed;

                playerFootSteps.stepDistance = crouchStepDistance;
                playerFootSteps.volMin = crouchVolume;
                playerFootSteps.volMax = crouchVolume;

                isCrouching = true;

            }

        }
    
    }
}
