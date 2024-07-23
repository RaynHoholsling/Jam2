using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.Animations;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool facingRight = true;
    [SerializeField] private GameObject player;
    [SerializeField] private Rigidbody2D body;
    public float jump;
    Vector2 movement;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.up * jump;
        }  
    }
    private void FixedUpdate()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        if(movement.x != 0)
        {
            body.AddForce(new Vector2(movement.x * moveSpeed, 0f));
        }
        if (movement.x > 0)
        {
            gameObject.transform.localScale = new Vector3(1, 1, 1);
        }
        if (movement.x < 0)
        {
            gameObject.transform.localScale = new Vector3(-1, 1, 1);
        }
    }


    private void OnDestroy()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        //Vector3 WeaponScaler = GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        //WeaponScaler.x *= -1;
        //WeaponScaler.y *= -1;
        //GameObject.FindGameObjectWithTag("Weapon").GetComponent<Transform>().localScale = WeaponScaler;
    }

}
