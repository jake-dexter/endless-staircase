using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{
    [SerializeField] private Material darkSkybox;

    private void Start()
    {
        RenderSettings.skybox = darkSkybox;   
    }
}
