using System;
using HumanScripts;
using UnityEngine;

public class HumanScript : MonoBehaviour
{
	private GameObject Human { get; set; } = null;

	private IntPtr humanInstance;


	// Start is called before the first frame update
	void Start()
	{
		this.Human = GameObject.Find("human");
		this.humanInstance = HumanDLLInterface.Human_create("config.json");

		//Debug.Log("yes");
	}

	// Update is called once per frame
	void Update()
	{
		HumanDLLInterface.update(this.humanInstance);
	}

	void OnApplicationQuit()
	{
		HumanDLLInterface.Human_destroy(this.humanInstance);
		HumanDLLInterface.DTrack_destroy();
	}
}