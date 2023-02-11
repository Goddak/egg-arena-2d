using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollow : MonoBehaviour
{
    private Transform player;
    private Vector3 tempPos;
    // Start is called before the first frame update
    private Vector3 startPos;
    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        startPos = transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        tempPos = transform.position;
        tempPos.x = player.position.x;

        if (startPos.y < player.position.y) {
            tempPos.y = player.position.y;
        } else {
            tempPos.y = startPos.y;
        }

        transform.position = tempPos;
    }
}
