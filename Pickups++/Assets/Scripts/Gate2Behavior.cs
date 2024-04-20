using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gate2Behavior : MonoBehaviour
{
    private Animator _anim;
    public void OpenGate()
    {
        _anim = GetComponent<Animator>();
        _anim.Play("GateOpen");
    }
}
