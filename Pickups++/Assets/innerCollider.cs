using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class innerCollider : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            if(this.GetComponentInParent<HideEnemy>() != null)
            this.GetComponentInParent<HideEnemy>().EnemyShow();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if(this.GetComponentInParent<HideEnemy>() != null)
            this.GetComponentInParent<HideEnemy>().EnemyHide();
        }
    }
}
