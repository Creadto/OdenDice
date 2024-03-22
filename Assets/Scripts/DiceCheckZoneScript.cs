using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceCheckZoneScript : MonoBehaviour
{
    public List<MeshCollider> DiceColliders = new();
    public DiceNumberTextScript DiceNumber;

    private Vector3 diceVelocity;
    private Dictionary<string, int> DiceNumbers = new Dictionary<string, int>();

    private bool _isSent = false;

    private void Start()
    {
        foreach (var col in DiceColliders)
        {
            DiceNumbers.Add(col.gameObject.name, 0);
        }
    }

    private void FixedUpdate()
    {
        diceVelocity = DiceScript.diceVelovity;
    }

    private void OnTriggerStay(Collider col)
    {
        if (Math.Abs(diceVelocity.x) < 0.05f && Math.Abs(diceVelocity.y) < 0.05f && Math.Abs(diceVelocity.z) < 0.05f)
        {
            int diceSum = 0;
            int diceNum = 0;
            
            switch (col.gameObject.name)
            {
                case "Side 1":
                    diceNum = 1;
                    break;
                case "Side 2":
                    diceNum = 2;
                    break;
                case "Side 3":
                    diceNum = 3;
                    break;
                case "Side 4":
                    diceNum = 4;
                    break;
                case "Side 5":
                    diceNum = 5;
                    break;
                case "Side 6":
                    diceNum = 6;
                    break;
            }
            string diceName = col.transform.parent.gameObject.name;
            DiceNumbers[diceName] = diceNum;

            foreach(KeyValuePair<string, int> dice in DiceNumbers)
            {
                diceSum += dice.Value;
            }
            DiceNumber.diceNumber = diceSum;
            if(!_isSent)
            {
                ChartManager.Instance.SetResult(0, diceSum);
            }
        }
    }
}
