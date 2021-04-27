using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandActions : MonoBehaviour
{
    private bool isGrabbing;
    private GameObject grabbedObject;
    
    [SerializeField] private InputAction grab;
    [SerializeField] private InputActionAsset handControls;
    [SerializeField] private string currentHand;

    private void Awake()
    {
        var handActionMap = handControls.FindActionMap("XR " + currentHand + "Hand");

        grab = handActionMap.FindAction("Grab");

        grab.performed += OnGrabChanged;
    }

    private void Start()
    {
        isGrabbing = false;
    }

    private void OnGrabChanged(InputAction.CallbackContext context)
    {
        var grabbed = context.ReadValue<int>();
        
        ChangeGrab(grabbed == 1);
    }
    
    public void ChangeGrab(bool grabbing)
    {
        isGrabbing = grabbing;
        if (!grabbing)
        {
            grabbedObject.transform.parent = grabbedObject.transform;
            grabbedObject = null;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isGrabbing)
        {
            grabbedObject = other.gameObject;
            grabbedObject.transform.parent = gameObject.transform;
        }
    }
}
