using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Player player;

    Vector3 distance;

    // Start is called before the first frame update
    void Start()
    {

        player = FindObjectOfType<Player>();

        distance = transform.position - player.transform.position;

    }

    // Update is called once per frame
    void LateUpdate()
    {

        transform.position = player.transform.position + distance;

    }
}
