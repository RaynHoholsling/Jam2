using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followSpeed;
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
    }
}
