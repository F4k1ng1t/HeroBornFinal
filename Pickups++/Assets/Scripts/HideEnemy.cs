using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HideEnemy : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        EnemyHide();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void EnemyHide()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if(this.gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>() != null)
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = false;
            for (int j = 0; j < this.gameObject.transform.GetChild(i).gameObject.transform.childCount; j++)
            {
                if(this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j) != null)
                {
                    if (this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.GetComponent<MeshRenderer>() != null)
                        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.GetComponent<MeshRenderer>().enabled = false;
                }
                    
            }
        }
    }
    public void EnemyShow()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; i++)
        {
            if (this.gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>() != null)
                this.gameObject.transform.GetChild(i).gameObject.GetComponent<MeshRenderer>().enabled = true;
            for (int j = 0; j < this.gameObject.transform.GetChild(i).gameObject.transform.childCount; j++)
            {
                if (this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j) != null)
                {
                    if (this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.GetComponent<MeshRenderer>() != null)
                        this.gameObject.transform.GetChild(i).gameObject.transform.GetChild(j).gameObject.GetComponent<MeshRenderer>().enabled = true;
                }

            }
        }
    }
}
