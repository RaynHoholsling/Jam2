using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ChangePostProcessing : MonoBehaviour
{
    [SerializeField] private PostProcessVolume postProcessVolume;
    private Vector3 _colorFilter = new Vector3(100, 100, 100);

    private void Update()
    {
        ColorGrading colorGrading = null;

        if (postProcessVolume.profile.TryGetSettings(out colorGrading))
        {
            colorGrading.mixerRedOutRedIn.value = _colorFilter.x;
            colorGrading.mixerGreenOutGreenIn.value = _colorFilter.y;
            colorGrading.mixerBlueOutBlueIn.value = _colorFilter.z; 
        }
    }

    public Vector3 colorFilter
    {
        get
        {
            return _colorFilter;
        }
        set
        {
            _colorFilter = value;
        }
    }
}
