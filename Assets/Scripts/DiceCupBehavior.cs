using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCupBehavior : MonoBehaviour
{

    public static Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
}
