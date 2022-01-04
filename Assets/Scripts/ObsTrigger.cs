using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObsTrigger : MonoBehaviour
{
    private PlayerMover mover;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.inst.setInjured();

            Destroy(this.gameObject);
        }

        

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
