using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponAim { 
    NONE,
    SELF_AIM,
    AIM
}
public enum WeaponFireType { 
    SINGLE,
    MULTIPLE
    
}
public enum WeaponBulletType { 
    BULLET,
    ARROW,
    SPEAR,
    NONE

}



public class WeaponHandler : MonoBehaviour {

    private Animator anim;

    public WeaponAim weaponAim;

    [SerializeField]
    private GameObject muzzleFlash;

    [SerializeField]
    private AudioSource shootSound, reloadSound;

    public WeaponFireType fireType;

    public WeaponBulletType bulletType;

    public GameObject attackPoint;

    void Awake()
    {
        anim = GetComponent<Animator>();


    }

    public void ShootAnimation() {

        anim.SetTrigger("Shoot");  
    }

    public void Aim(bool canAim) {

        anim.SetBool(AnimationTags.AIM_PARAMETER, canAim);
    }

    void TurnOnMuzzle() {

        muzzleFlash.SetActive(true);
    }

    void TurnOffMuzzle()
    {
        muzzleFlash.SetActive(false);
    }

    public void PlayShootSound() {
        shootSound.Play();
    }

    void PlayReloadSound() {
        reloadSound.Play();
    }

    void TurnOAttackPoint() {
        
        attackPoint.SetActive(true);
      
    
    }

    private void TurnOffAttackPoint() {

        if (attackPoint.activeInHierarchy)
            attackPoint.SetActive(false);
    
    }


}
