using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.Rendering.PostProcessing;

public class Wand : MonoBehaviour
{
    [SerializeField] private bool isReloading = false;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;
    [SerializeField] private float _decayProgressFill;
    [SerializeField] private GameObject _gameManager;
    [SerializeField] private GameObject _camera;
    [SerializeField] private Vector3 _colorFilter;
    [SerializeField] private AudioSource _shotSound;
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        projectile.transform.rotation = transform.rotation;

        if (Input.GetMouseButtonDown(0) && isReloading == false)
        {
            _colorFilter.y -= 8;
            _camera.GetComponent<ChangePostProcessing>().colorFilter += _colorFilter;
            _gameManager.GetComponent<GameManager>().decayProgress += _decayProgressFill;
            GameObject pellet = Instantiate(projectile, shotPoint.position, transform.rotation);
            _shotSound.Play();
            StartCoroutine(Reloading());
            StartCoroutine(Shooting());

        }
    }
    IEnumerator Shooting()
    {
        animator.SetBool("Shooting", true);
        yield return new WaitForSeconds(0.5f);
        animator.SetBool("Shooting", false);
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(3.5f);
        isReloading = false;
    }
}
