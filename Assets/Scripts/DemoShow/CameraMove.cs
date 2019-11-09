using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {

    private GameObject player;
    private Vector3 offset;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    // Update is called once per frame
    void Update () {
        transform.position = player.transform.position + offset;
	}
}
