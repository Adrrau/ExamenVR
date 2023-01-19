using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

[RequireComponent(typeof(XRGrabInteractable))]
public class CubeColorGrab : MonoBehaviour
{
    XRGrabInteractable m_InteractableBase;
    XRBaseInteractable m_Interactable;
    Renderer base_color;
    Renderer m_color;

    const string k_AnimTriggerDown = "TriggerDown";
    const string k_AnimTriggerUp = "TriggerUp";
    const float k_HeldThreshold = 0.1f;

    float m_TriggerHeldTime;
    bool m_TriggerDown;

    protected void Start()
    {
        m_color = GetComponent<Renderer>();
        base_color = m_color;
        m_InteractableBase = GetComponent<XRGrabInteractable>();
        m_InteractableBase.selectExited.AddListener(DroppedGun);
        m_InteractableBase.activated.AddListener(TriggerPulled);
        m_InteractableBase.deactivated.AddListener(TriggerReleased);
    }

    protected void Update()
    {
        if (m_TriggerDown)
        {
            m_TriggerHeldTime += Time.deltaTime;

            if (m_TriggerHeldTime >= k_HeldThreshold)
            {
                m_color.material.color = Color.white;
            }
        }
    }

    void TriggerReleased(DeactivateEventArgs args)
    {
        m_color.material.color = base_color.material.color;
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }

    void TriggerPulled(ActivateEventArgs args)
    {
        m_color.material.color = Color.white;
        m_TriggerDown = true;
    }

    void DroppedGun(SelectExitEventArgs args)
    {
        m_color.material.color = base_color.material.color;
        m_TriggerDown = false;
        m_TriggerHeldTime = 0f;
    }

    public void ShootEvent()
    {
        m_color.material.color = Color.white;
    }


    protected void OnEnable()
    {
        m_Interactable = GetComponent<XRBaseInteractable>();
        m_Interactable.firstSelectEntered.AddListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.AddListener(OnLastSelectExited);
    }

        protected void OnDisable()
    {
        m_Interactable.firstSelectEntered.RemoveListener(OnFirstSelectEntered);
        m_Interactable.lastSelectExited.RemoveListener(OnLastSelectExited);
    }

    protected virtual void OnFirstSelectEntered(SelectEnterEventArgs args)
    {
        m_color.material.color = Color.white;
    }

    protected virtual void OnLastSelectExited(SelectExitEventArgs args)
    {
        m_color.material.color = Color.white;
    }

}
