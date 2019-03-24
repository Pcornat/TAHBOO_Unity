using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Runtime.InteropServices;




public class testcv : MonoBehaviour
{
    //Lets make our calls from the Plugin
    [DllImport("opencvunity", EntryPoint = "?Initialize@Functions@BackgroundSubtraction@@SAXXZ")]
    private static extern void Initialize();

    [DllImport("opencvunity", EntryPoint = "?ProcessFrame@Functions@BackgroundSubtraction@@SAPEAEXZ")]
    private static extern byte[] ProcessFrame();

    [DllImport("opencvunity", EntryPoint = "?freepointer@Functions@BackgroundSubtraction@@SAXXZ")]
    private static extern void freepointer();
    
    private Texture2D _tex;
    private Material _m;
    private Renderer _renderer;

    void Start()
    {
        _renderer = this.GetComponent<Renderer>();
        Initialize();
        Debug.Log("done");
        _m = new Material(Shader.Find("Diffuse"));
       _tex = new Texture2D(640, 480, TextureFormat.BGRA32, false);
    }

    void Update()
    {
        _tex.LoadRawTextureData(ProcessFrame());
        _tex.Apply();
        _m.mainTexture = _tex;
        _renderer.material = _m;
        freepointer();
        GC.Collect();
    }
}
