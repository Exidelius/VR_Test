using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabbableObject : MonoBehaviour
{

    public void Grabe()
    {
        GetComponent<MeshRenderer>().material.color = Color.red;
    }

    public void Drop()
    {
        GetComponent<MeshRenderer>().material.color = Color.blue;
    }
}
