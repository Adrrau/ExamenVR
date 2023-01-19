using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(XRGrabInteractable))]
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float shootingForce;
    [SerializeField] protected Transform bulletSpawn;
    [SerializeField] private float recoilForce;
    [SerializeField] private float damage;

    private Rigidbody rb;
    private XRGrabInteractable interactableWeapon;
    public GameObject bullet;

    float m_TriggerHeldTime;
    bool m_TriggerDown;
    protected void Start()
    {
        interactableWeapon = GetComponent<XRGrabInteractable>();
        rb = GetComponent<Rigidbody>();
        SetupInteractableWeaponEvents();
    }

    private void SetupInteractableWeaponEvents()
    {
        interactableWeapon.selectExited.AddListener(DroppedGun);
        interactableWeapon.activated.AddListener(TriggerPulled);
        interactableWeapon.deactivated.AddListener(TriggerReleased);;
    }

    void DroppedGun(SelectExitEventArgs args)
    {
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }

    void TriggerReleased(DeactivateEventArgs args)
    {
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }

    void TriggerPulled(ActivateEventArgs args)
    {
        m_TriggerDown = true;
        InvokeRepeating ("Shoot", 0.5f, 0.5f);
    }

    private void ApplyRecoil()
    {
        rb.AddRelativeForce(Vector3.back * recoilForce, ForceMode.Impulse);
    }

    private void Shoot()
    {
       GameObject projectileInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }



/*
    protected override void StartShooting(XRBaseInteractor interactor)
    {
        StartShooting(interactor);
        Shoot();
    }

    protected override void Shoot()
    {
        Shoot();
        GameObject projectileInstance = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
    }
    protected override void StopShoot(XRBaseInteractor interactor)
    {
        base.StopShoot(interactor);
    }
*/
}
