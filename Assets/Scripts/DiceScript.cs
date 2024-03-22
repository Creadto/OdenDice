using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DiceScript : MonoBehaviour
{
    static Rigidbody rb;

    public static Vector3 diceVelovity;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        diceVelovity = rb.velocity;
    }
}
