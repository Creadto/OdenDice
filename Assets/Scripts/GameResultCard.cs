using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultCard : MonoBehaviour
{
    public TextMeshProUGUI Round;
    public TextMeshProUGUI DiceNumber;
    public TextMeshProUGUI OddEven;
    public TextMeshProUGUI Result;

    public void SetDisplay(int round, int dice_number, bool is_odd, bool is_win)
    {
        Round.text = (round+1).ToString();
        DiceNumber.text = dice_number.ToString();
        OddEven.text = is_odd ? "Odd" : "Even";
        Result.text = is_win ? "Win" : "Lose";
    }
    public void SetDisplay(int round)
    {
        Round.text = (round + 1).ToString();
        DiceNumber.text = "";
        OddEven.text = "";
        Result.text = "";
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
