using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float speed = 2f;
    public int playerBoundRange = 40;

    void Update () {

        float vertical= Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");
        
        transform.Translate(new Vector3(horizontal, 2, vertical) *speed);

        float x = Mathf.Clamp(transform.position.x, -QuadTree.MAX_RANGE/2, QuadTree.MAX_RANGE/2);
        float z = Mathf.Clamp(transform.position.z, -QuadTree.MAX_RANGE/2, QuadTree.MAX_RANGE/2);

        transform.position = new Vector3(x, 2, z);
    }
}
