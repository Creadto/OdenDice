using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButtonControl : MonoBehaviour
{
    public Animator CapAnimator;
    private bool _isOn = false;
    public void OnClickStartButton()
    {
        _isOn ^= true;
        if (_isOn)
        {
            CapAnimator.SetTrigger("OnClickPush");
            DiceManager.Instance.OnClickStart();
        }
        else
        {
            CapAnimator.SetTrigger("Rollback");
        }
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
