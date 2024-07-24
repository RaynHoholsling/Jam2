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

    void Update()
    {
        if (_decayProcess >= _maxDecayProcess)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
}
