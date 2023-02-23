using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float height = 12.5f;

    // Start is called before the first frame update
    void LateUpdate()
    {
        this.transform.position = new Vector3(player.position.x, height, player.position.z);
    }
}
