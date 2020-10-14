using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float PlayerSpeed;

    private Rigidbody2D body;
    private Vector2 moveDirection;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
    }
    void FixedUpdate()
    {
        body.MovePosition((Vector2)gameObject.transform.position + moveDirection * PlayerSpeed * Time.deltaTime);
    }
}
