using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.InteropServices;




public class testcv : MonoBehaviour
{
    Texture2D tex;
    //Lets make our calls from the Plugin
    [DllImport("opencvunity", EntryPoint = "?Initialize@Functions@BackgroundSubtraction@@SAXXZ")]
    private static extern void Initialize();

    [DllImport("opencvunity", EntryPoint = "?ProcessFrame@Functions@BackgroundSubtraction@@SAPEAEXZ")]
    private static extern byte[] ProcessFrame();

    [DllImport("opencvunity", EntryPoint = "?freepointer@Functions@BackgroundSubtraction@@SAXXZ")]
    private static extern void freepointer();
    Material m;
    void Start()
    {
        Initialize();
        Debug.Log("done");
        m = new Material(Shader.Find("Diffuse"));
       tex = new Texture2D(640, 480, TextureFormat.BGRA32, false);
    }

    void Update()
    {
        byte[] imgData = ProcessFrame();
        tex.LoadRawTextureData(imgData);
        tex.Apply();
        m.mainTexture = tex;
        this.GetComponent<Renderer>().material = m;
        imgData = null;
        freepointer();
        GC.Collect();
    }
}
