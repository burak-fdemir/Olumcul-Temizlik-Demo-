using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class silahAlma : MonoBehaviour {

    private GameObject player;
    public GameObject crossHair;

    //void Awake() {

    //    crossHair = GameObject.Find("Crosshair");


    //}



    void OnTriggerEnter(Collider col) {


        if (gameObject.tag == "Silah"){
            if (col.gameObject.tag == "Player")
            {

                col.gameObject.GetComponent<WeaponManager>().TurnOnSelectedWeapon(1);
                crossHair.SetActive(true);
                gameObject.SetActive(false);


            }
        }
        else if(gameObject.tag == "Balta") {
            col.gameObject.GetComponent<WeaponManager>().TurnOnSelectedWeapon(0);
            gameObject.SetActive(false);
        }
    }


    

}
