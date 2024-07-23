using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wand : MonoBehaviour
{
    [SerializeField] private bool isReloading = false;
    [SerializeField] private GameObject projectile;
    [SerializeField] private Transform shotPoint;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
        projectile.transform.rotation = transform.rotation;

        if (Input.GetMouseButtonDown(0) && isReloading == false)
        {
            GameObject pellet = Instantiate(projectile, shotPoint.position, transform.rotation);
            StartCoroutine(Reloading());
        }
    }
    IEnumerator Reloading()
    {
        isReloading = true;
        yield return new WaitForSeconds(5);
        isReloading = false;
    }
}
