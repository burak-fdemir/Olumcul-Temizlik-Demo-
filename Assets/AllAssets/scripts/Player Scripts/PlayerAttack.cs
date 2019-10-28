using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

    private WeaponManager weaponManager;
    private float nextTimeToFire;
    private Animator zoomCameraAnim;
    private bool isZoomed;
    private Camera mainCam;
    public GameObject crossHair;
    private bool isAiming;

    [SerializeField]
    private GameObject arrowPrefab, spearPrefab;

    [SerializeField]
    private Transform arrowBowStartPosition;



    public float damage;
    public float fireRate = 15;

    void Awake() {
        weaponManager = GetComponent<WeaponManager>();

        //zoomCameraAnim = transform.Find(Tags.LOOK_ROOT).transform.
        //Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();

        zoomCameraAnim = GameObject.Find(Tags.ZOOM_CAMERA).GetComponent<Animator>();


        

        mainCam = Camera.main;
    }
	
	void Start () {
		
	}
	
	
	void Update () {
        WeaponShoot();
        ZoomInOut();

    }

    private void WeaponShoot() { 
        //assault rifle
        //if(weaponManager.GetCurrentSelectedWeapon().fireType == WeaponFireType.MULTIPLE) { 
        
        //    if(Input.GetMouseButton(0) && Time.time > nextTimeToFire) {

        //        nextTimeToFire = Time.time + 1f / fireRate;

        //        weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

        //        BulletFired();
            
        //    }
        
        //}
        //else {

            if (Input.GetMouseButtonDown(0))
            {
                //axe
                if (weaponManager.GetCurrentSelectedWeapon().tag == Tags.AXE_TAG)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                }

                // rifle shotgun what weapons firing bullet with single fire type
                if (weaponManager.GetCurrentSelectedWeapon().bulletType == WeaponBulletType.BULLET)
                {
                    weaponManager.GetCurrentSelectedWeapon().ShootAnimation();
                    //weaponManager.GetCurrentSelectedWeapon().PlayShootSound();
                    BulletFired();
                }
                //else {
                //    //we have arrow or spear

                //    if (isAiming) {

                //        weaponManager.GetCurrentSelectedWeapon().ShootAnimation();

                //        if (weaponManager.GetCurrentSelectedWeapon().bulletType ==
                //            WeaponBulletType.ARROW) {

                //            //throw arrow
                //            ThrowArrowOrSpear(true);
                        
                //        }

                //        if (weaponManager.GetCurrentSelectedWeapon().bulletType ==
                //           WeaponBulletType.SPEAR)
                //        {

                //            //throw spear
                //            ThrowArrowOrSpear(false);
                //        }


                //    }


                //}
            }
        
    
    
    }//Weapon Shoot

    private void ZoomInOut() { 
        if(weaponManager.GetCurrentSelectedWeapon().weaponAim == WeaponAim.AIM) {
            if (Input.GetMouseButtonDown(1)) {

                zoomCameraAnim.Play(AnimationTags.ZOOM_IN_ANIM);

                crossHair.SetActive(false);
            }

            if (Input.GetMouseButtonUp(1))
            {

                zoomCameraAnim.Play(AnimationTags.ZOOM_OUT_ANIM);

                crossHair.SetActive(true);
            }

        }

        //if(weaponManager.GetCurrentSelectedWeapon().weaponAim == WeaponAim.SELF_AIM) {

        //    if (Input.GetMouseButtonDown(1)) {

        //        weaponManager.GetCurrentSelectedWeapon().Aim(true);
        //        isAiming = true;
            
        //    }

        //    if (Input.GetMouseButtonUp(1))
        //    {

        //        weaponManager.GetCurrentSelectedWeapon().Aim(false);
        //        isAiming = false;

        //    }


        //}


    
    }// zoom in out

    //void ThrowArrowOrSpear(bool throwArrow) {
    //    if (throwArrow) {
    //        GameObject arrow = Instantiate(arrowPrefab);
    //        arrow.transform.position = arrowBowStartPosition.position;

    //        arrow.GetComponent<ArrowAndSpear>().Launch(mainCam);
        
    //    }// ok firlat
    //    else {
    //        GameObject spear = Instantiate(spearPrefab);
    //        spear.transform.position = arrowBowStartPosition.position;

    //        spear.GetComponent<ArrowAndSpear>().Launch(mainCam);


    //    }// mızrak firlat
        
    
     //mızrak veya ok firlat

    private void BulletFired() {

        RaycastHit hit;

        if(Physics.Raycast(mainCam.transform.position,mainCam.transform.forward,out hit)) {
           // print(" WE HİT:" + hit.transform.gameObject.name);

            if(hit.transform.tag == Tags.ENEMY_TAG) {

                print("We hit" + hit.transform.gameObject.tag);

                hit.transform.GetComponent<HealthScript>().ApplyDamage(damage);
            
            }


        
        }
    
    }

}
//class
