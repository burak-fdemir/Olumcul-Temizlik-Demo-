using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AINAV : MonoBehaviour {

	private NavMeshAgent myAgent = null;
	private Animator anim = null;
	private float chaseDistance = 10;
	private float attackDistance = 1;

    public AudioClip breathe;

    //public int breatheController = 0;

    public Transform Player= null;

	public enum STATES{IDLE = 0, RUN = 1, ATTACK =2};

	[SerializeField]
	private STATES currentState = STATES.IDLE;

	public STATES myState{

		get{return currentState; }
		set{

			StopAllCoroutines ();
			currentState = value;


			//GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<postProcessController> ().enabled = false;



			switch (currentState) {
			case STATES.IDLE:
				StartCoroutine (StateIdle ());
				break;

			case STATES.RUN:
				StartCoroutine (StateRun ());
				break;

			case STATES.ATTACK:
				StartCoroutine (StateAttack ());
				break;



			}

		}
	}


	void Awake () {
		myAgent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
	}

	void Start(){
	
		myState = currentState;
	
	}
	
	public IEnumerator StateIdle(){
		while (myState == STATES.IDLE) {
			anim.SetInteger ("animState", 0);

            




            if (Vector3.Distance (Player.position, transform.position) <= chaseDistance) {

                Player.GetComponentInChildren<playerBreathe>().KorkmaSesiCal();
				myState = STATES.RUN;
				yield break;
			
			}


			yield return null;
		}
	

	}

	public IEnumerator StateRun(){
		while (myState == STATES.RUN) {


			anim.SetInteger ("animState", 1);
			myAgent.SetDestination (Player.position);



	//		GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<postProcessController> ().enabled = true;
			GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<postProcessController> ().postProcessControl = 1;
            

            //  GameObject.Find("oyunSesleri").GetComponent<AudioSource>().PlayOneShot(breathe);
            //sesCalinsinMi();



            if (Vector3.Distance (Player.position, transform.position) <= attackDistance) {

				myState = STATES.ATTACK;
				yield break;

			}

			if (Vector3.Distance (Player.position, transform.position) > chaseDistance) {

				GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<postProcessController> ().postProcessControl = -1;
                GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<postProcessController>().postProcessControl = 0;

                myState = STATES.IDLE;
				yield break;

			}


			yield return null;
		}


	}

	public IEnumerator StateAttack(){

		while (myState == STATES.ATTACK) {

			anim.SetInteger ("animState", 2);
			myAgent.SetDestination (Player.position);

	//		GameObject.FindGameObjectWithTag ("Player").GetComponentInChildren<postProcessController> ().postProcessControl = 1;

			if ((Vector3.Distance (Player.position, transform.position) > attackDistance) ) {

				myState = STATES.RUN;
				yield break;

			}

//			if (Vector3.Distance (Player.position, transform.position) > chaseDistance) {
//
//				myState = STATES.IDLE;
//				yield break;
//
//			}


			yield return null;
		
		}






	}


    //private void sesCalinsinMi()
    //{

    //    if (breatheController == 1)
    //    {

    //        GetComponent<AudioSource>().PlayOneShot(breathe);

    //    }


    //}


}
