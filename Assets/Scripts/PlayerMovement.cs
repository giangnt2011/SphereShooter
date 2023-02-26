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
        Debug.Log("FixedUpdate");
        if (GetInput("Horizontal", "Vertical"))
        {
            Debug.Log("start2");

            MovePlayer();
        }
        if (GetInput("MouseX", "MouseY"))
        {
            Debug.Log("start3");

            RotateTurret();
        }
    }

    bool GetInput(string horizontal, string vertical)
    {
        Debug.Log("getinput");
        input.x = SimpleInput.GetAxis(horizontal) * speed;
        input.y = SimpleInput.GetAxis(vertical) * speed;

        Debug.Log(Mathf.Abs(input.x));
        Debug.Log(Mathf.Abs(input.y));

        return (Mathf.Abs(input.x) > 0.01f) || (Mathf.Abs(input.y) > 0.01f);
    }

    void MovePlayer()
    {
        Debug.Log("moving");
        cubeRb.velocity = Vector3.Normalize(new Vector3(input.x, 0,input.y)) * speed;
    }

    void RotateTurret()
    {
        rotator.eulerAngles = new Vector3(0, Mathf.Atan2(input.x, input.y) * 180 / Mathf.PI, 0);
    }

  

}
