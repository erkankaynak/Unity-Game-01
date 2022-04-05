using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{

    public Transform heroPosition;
    private float  cameraOffset =0f;

    // Start is called before the first frame update
    void Start()
    {
        cameraOffset = heroPosition.position.z - transform.position.z;
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, heroPosition.position.z - cameraOffset);
    }
}
