using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroler : MonoBehaviour
{

    public Transform player;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.position;
        
    }


    private void LateUpdate()
    {
        transform.position = player.position + offset;
    }

}
