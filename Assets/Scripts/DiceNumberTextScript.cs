using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceNumberTextScript : MonoBehaviour
{
    public TMP_Text text;

    public int diceNumber;

    private void Start()
    {

    }

    private void Update()
    {
        text.text = diceNumber.ToString();
    }
}
