using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerSpeed;
    private PlayerAnimation anim;
    private Rigidbody2D body;
    private Vector2 moveDirection;

    void Start()
    {
        body = gameObject.GetComponent<Rigidbody2D>();
        anim = GetComponentInChildren<PlayerAnimation>();
    }

    void Update()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

        if (moveDirection.x > 0)
            anim.ChangeAnimationState(Directions.Right);
        else if (moveDirection.x < 0)
            anim.ChangeAnimationState(Directions.Left);
        else if (moveDirection.x == 0 && moveDirection.y > 0)
            anim.ChangeAnimationState(Directions.Up);
        else if (moveDirection.x == 0 && moveDirection.y < 0)
            anim.ChangeAnimationState(Directions.Down);
        else
            anim.ChangeAnimationState(Directions.None);
    }
    void FixedUpdate()
    {
        body.MovePosition((Vector2)gameObject.transform.position + moveDirection * PlayerSpeed * Time.deltaTime);
    }
}
