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
        mover = GameObject.FindObjectOfType<PlayerMover>();
    }

/*    void OnCollisionEnter(Collision collision)
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }*/



    // Update is called once per frame
    void Update()
    {
        
    }
}
