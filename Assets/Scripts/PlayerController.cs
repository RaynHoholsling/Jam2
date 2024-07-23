using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _body;
    private bool _isOnGround;

    private void Awake()
    {
       _body = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float _horizontalInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(_horizontalInput * _speed, _body.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
            _body.velocity = new Vector2(_body.velocity.x, _speed);

        if (_horizontalInput > 0.01f)
        {
            transform.localScale = Vector3.one;
        }
        else if (_horizontalInput < -0.01f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isOnGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isOnGround = false;
        }
    }
}
