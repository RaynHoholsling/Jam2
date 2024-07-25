using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _decayProcess;
    [SerializeField] private float _maxDecayProcess;
    [SerializeField] private Image bar;
    [SerializeField] private Sprite sprite1;
    [SerializeField] private GameObject frame;
    [SerializeField] private AudioSource deathSound;
    private bool dead = false;
    void Update()
    {
        if (_decayProcess >= _maxDecayProcess)
        {
            if(dead == false)
            {
                StartCoroutine(Death());
            }                  
        }
        GameObject.FindGameObjectWithTag("HP").GetComponent<Image>().fillAmount = _decayProcess / 100f;
    }

    public float decayProgress
    {
        get
        {
            return _decayProcess;
        }
        set
        {
            _decayProcess = value;           
        }
    }
    IEnumerator Death()
    {
        dead = true;       
        deathSound.Play();                      
        frame.GetComponent<SpriteRenderer>().sprite = sprite1;       
        yield return new WaitForSeconds(3);
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }
}
