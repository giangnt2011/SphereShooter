using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Transform rotator;

    private Rigidbody cubeRb;
    public float speed = 5.0f;

    private Vector2 input;
    // Start is called before the first frame update
    void Start()
    {
        cubeRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (GetInput("Horizontal", "Vertical"))
        {
            MovePlayer();
        }
        if (GetInput("MouseX", "MouseY"))
        {
            RotateTurret();
        }
    }

    bool GetInput(string horizontal, string vertical)
    {
        input.x = SimpleInput.GetAxis(horizontal) * speed;
        input.y = SimpleInput.GetAxis(vertical) * speed;
        return (Mathf.Abs(input.x) > 0.01f) || (Mathf.Abs(input.y) > 0.01f);
    }

    void MovePlayer()
    {
        cubeRb.velocity = Vector3.Normalize(new Vector3(input.x, 0,input.y)) * speed;
    }

    void RotateTurret()
    {
        rotator.eulerAngles = new Vector3(0, Mathf.Atan2(input.x, input.y) * 180 / Mathf.PI, 0);
    }

  

}
