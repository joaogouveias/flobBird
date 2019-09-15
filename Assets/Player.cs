using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float force;
    public float rotationOffset;

    private Rigidbody2D rigid;
    // Start is called before the first frame update
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space)) //TODO change for tap
        {
            rigid.velocity += Vector2.up * force * Time.deltaTime;
            print(rigid.velocity);
        }
    }
}
