using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitTrriger : MonoBehaviour
{
    private float turnSpeed = 90;
    // Start is called before the first frame update
    void Start()
    {
        
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameManager.inst.addScore(this.gameObject.GetComponent<Collider>());
        }
        
        Destroy(this.gameObject);

    }

/*    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }*/
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, turnSpeed * Time.deltaTime, 0);
    }
}
