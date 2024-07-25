using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Camera1 : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private float followSpeed;
    private void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player") == null)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
        if(GameObject.FindGameObjectWithTag("Player") != null)
        {
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -20);
        }
               
    }
}
