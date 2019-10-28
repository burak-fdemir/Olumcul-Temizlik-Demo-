using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class HealthScript : MonoBehaviour {

    private EnemyAnimator enemyAnimator;
    private EnemyController enemyController;
    private NavMeshAgent agent;

    public float health = 100f;

    public bool isPlayer, isMouse;

    public bool isDead;

    private EnemyAudio enemyAudio;

    private PlayerStats playerStats;
	void Awake () {

        

		if(isMouse) {
            enemyAnimator = GetComponent<EnemyAnimator>();
            enemyController = GetComponent<EnemyController>();
            agent = GetComponent<NavMeshAgent>();

            // play enemy audio
            enemyAudio = GetComponentInChildren<EnemyAudio>();
        }

        if (isPlayer) {
            playerStats = GetComponent<PlayerStats>();
        
        }

	}

    public void ApplyDamage(float damage) {

        if (isDead)
            return;

        health -= damage;

        if (isPlayer) {
            playerStats.DisplayHealtStats(health);
        }

        if(isMouse) { 
            if(enemyController.EnemyState == EnemyState.PATROL) {

                enemyController.chaseDistance = 50;

            }
        }

        if(health <= 0) {
            PlayerDied();

            isDead = true;
        }

    }// apply damage

    private void PlayerDied() {

        if (isMouse) {

            GetComponent<Animator>().enabled = false;
            GetComponent<BoxCollider>().isTrigger = false;
            GetComponent<Rigidbody>().AddTorque(-transform.forward * 100f);

            enemyController.enabled = false;
            agent.enabled = false;
            enemyAnimator.enabled = false;

            //start coroutine
            StartCoroutine(DeadSound());

            //enemy manager spawn more enemyies
           // EnemyManager.instance.EnemyDied(true);

        }

        //if (isBoar) {
        //    agent.velocity = Vector3.zero;
        //    agent.isStopped = true;
        //    enemyController.enabled = false;

            
        //    enemyAnimator.Dead();

        //    //start coroutine

        //    StartCoroutine(DeadSound());
        //    //enemy manager spawn more enemyies

        //    EnemyManager.instance.EnemyDied(false);

        //}

        if (isPlayer) {

            GameObject[] enemies = GameObject.FindGameObjectsWithTag(Tags.ENEMY_TAG);

            for(int i = 0;i < enemies.Length; i++) {

                enemies[i].GetComponent<EnemyController>().enabled = false;
            }

            //call enemy manager to stop the spawning enemies
            //EnemyManager.instance.StopSpawning();


            GetComponent<PlayerMovement>().enabled = false;
            GetComponent<PlayerAttack>().enabled = false;
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
            GetComponent<WeaponManager>().GetCurrentSelectedWeapon().gameObject.SetActive(false);
        }

        if(tag == Tags.PLAYER_TAG) {

            Invoke("RestartGame", 3f);
        }
        else {

            Invoke("TurnOffGameObject", 3f);
        
        }
    }// Player died

    private void RestartGame() {

        UnityEngine.SceneManagement.SceneManager.LoadScene("SurvivalGame");
    
    }//restartGame

    private void TurnOffGameObject() {

        gameObject.SetActive(false);
    
    }

    IEnumerator DeadSound() {

        yield return new WaitForSeconds(0.3f);

        enemyAudio.PlayDeadSound();
    }


}//class

