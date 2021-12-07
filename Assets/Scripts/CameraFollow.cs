using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform Player;
    [SerializeField] Vector3 offSet;


    // Start is called before the first frame update
    void Start()
    {
        offSet = transform.position - Player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 temp = Player.position + offSet;
        temp.x = 0;
        transform.position = temp;
    }
}
