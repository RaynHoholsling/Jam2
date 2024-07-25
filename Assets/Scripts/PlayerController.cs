using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private Rigidbody2D _body;
    private bool _isOnGround;
    Animator animator;
    private bool _facingRight = true;
    [SerializeField] private GameObject _camera;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private int _decayProgressFillOnDoubleJump;
    private bool _candoubleJump = false;
    [SerializeField] private AudioSource _jumpSound;
    [SerializeField] private AudioSource _doubleJumpSound;

    private void Awake()
    {
       _body = GetComponent<Rigidbody2D>();
       animator = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        float _horizontalInput = Input.GetAxis("Horizontal");
        _body.velocity = new Vector2(_horizontalInput * _speed, _body.velocity.y);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
        if(Input.GetKeyDown(KeyCode.Space) && _isOnGround)
        {
            _candoubleJump = true;
            _body.velocity = new Vector2(_body.velocity.x, _speed);
            animator.SetBool("Is Jumping", true);
            _jumpSound.Play();
        }
        if (!_isOnGround && _candoubleJump && Input.GetKeyDown(KeyCode.Space)) 
        {
            gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Jumping");
            _candoubleJump = false;
            _body.velocity = new Vector2(_body.velocity.x, _speed);
            _camera.GetComponent<ChangePostProcessing>().colorFilter -= new Vector3(0, 3, 0);
            _gameManager.GetComponent<GameManager>().decayProgress += _decayProgressFillOnDoubleJump;
            _doubleJumpSound.Play();
        }


        if (_horizontalInput > 0.01f)
        {
            animator.SetBool("Is running", Mathf.Abs(_horizontalInput) >= 0.1f);
        }
        else if (_horizontalInput < -0.01f)
        {
            animator.SetBool("Is running", Mathf.Abs(_horizontalInput) >= 0.1f);
        }


        if (!_facingRight && mousePosition.x > transform.position.x)
        {
            Flip();
        }
        else if (_facingRight && mousePosition.x < transform.position.x)
        {
            Flip();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isOnGround = true;
            _candoubleJump = false;
            animator.SetBool("Is Jumping", false); 
            //gameObject.transform.GetChild(0).GetComponent<Animator>().SetTrigger("Jumping");
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            _isOnGround = false;          
        }
    }

    private void Flip()
    {
        _facingRight = !_facingRight;
        Vector3 Scaler = transform.localScale;
        Vector3 WeaponScaler = GameObject.FindGameObjectWithTag("Wand").GetComponent<Transform>().localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        WeaponScaler.x *= -1;
        WeaponScaler.y *= -1;
        GameObject.FindGameObjectWithTag("Wand").GetComponent<Transform>().localScale = WeaponScaler;
    }

}
