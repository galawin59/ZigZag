using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBox : MonoBehaviour
{
    [SerializeField] Material skybox;
   


 
    void Start()
    {
        RenderSettings.skybox = skybox;
        
    }


    void Update()
    {

    }
}
