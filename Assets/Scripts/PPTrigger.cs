using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PPTrigger : MonoBehaviour
{

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.inst.addScore(this.gameObject.GetComponent<Collider>());
            Destroy(this.transform.parent.gameObject);

        }
        if (other.tag == "Rock")
        {
            Destroy(this.transform.parent.gameObject);
        }

        

    }

}
