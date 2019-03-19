using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumanScripts
{
	public class HumanScript : MonoBehaviour
	{
		private IntPtr _humanInstance;
		private List<BodyParts> _bodyPartses;

		// Start is called before the first frame update
		void Start()
		{
			this._humanInstance = HumanDLLInterface.Human_create("config.json");

			//Debug.Log("yes");
		}

		// Update is called once per frame
		void Update()
		{
			HumanDLLInterface.update(this._humanInstance);
		}

		void OnApplicationQuit()
		{
			HumanDLLInterface.Human_destroy(this._humanInstance);
			HumanDLLInterface.DTrack_destroy();
		}
	}
}