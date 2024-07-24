using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private float _decayProcess;
    [SerializeField] private float _maxDecayProcess;

    void Update()
    {
        if (_decayProcess >= _maxDecayProcess)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
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
