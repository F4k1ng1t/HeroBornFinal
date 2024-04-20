using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateAnimConfig : MonoBehaviour
{
    public void StopAnim()
    {
        this.GetComponent<Animator>().speed = 0f;
    }
    public void removeCollider()
    {
        GameObject _collider = GameObject.Find("Collider");
        GameObject.Destroy( _collider );
    }
}
