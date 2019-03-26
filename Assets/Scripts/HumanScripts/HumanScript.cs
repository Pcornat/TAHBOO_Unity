using System;
using System.Collections.Generic;
using UnityEngine;

namespace HumanScripts
{
	public class HumanScript : MonoBehaviour
	{
		private IntPtr _humanInstance;
		private List<BodyParts> _body;

		// Called before everything, used to initialise the object.
		void Awake()
		{
			this._body = new List<BodyParts>();
			this._humanInstance = HumanDLLInterface.Human_create("config.json");
			var tabIds = HumanDLLInterface.getIds(this._humanInstance); 
			for (long i = 0; i < HumanDLLInterface.getNumBodyParts(this._humanInstance); ++i)
			{
				this._body.Add(new BodyParts(this.GetComponent<Animator>(), this._humanInstance));
			}

			//Init of all the bones.
			this._body[0].Bone = HumanBodyBones.Head;
			this._body[0].Id = tabIds[0];
			
			this._body[1].Bone = HumanBodyBones.LeftFoot;
			this._body[1].Id = tabIds[1];

			this._body[2].Bone = HumanBodyBones.RightFoot;
			this._body[2].Id = tabIds[2];

			this._body[3].Bone = HumanBodyBones.RightUpperLeg;
			this._body[3].Id = tabIds[3];

			this._body[4].Bone = HumanBodyBones.LeftHand;
			this._body[4].Id = tabIds[4];

			this._body[5].Bone = HumanBodyBones.LeftLowerArm;
			this._body[5].Id = tabIds[5];

			this._body[6].Bone = HumanBodyBones.LeftUpperLeg;
			this._body[6].Id = tabIds[6];

			this._body[7].Bone = HumanBodyBones.RightLowerArm;
			this._body[7].Id = tabIds[7];

			this._body[8].Bone = HumanBodyBones.LeftShoulder;
			this._body[8].Id = tabIds[8];

			this._body[9].Bone = HumanBodyBones.RightShoulder;
			this._body[9].Id = tabIds[9];

			this._body[10].Bone = HumanBodyBones.RightHand;
			this._body[10].Id = tabIds[10];

			this._body[11].Bone = HumanBodyBones.Hips;
			this._body[11].Id = tabIds[11];
		}

		// Start is called before the first frame update
		void Start()
		{
		}

		// Update is called once per frame
		void Update()
		{
			HumanDLLInterface.update(this._humanInstance);
			foreach (var parts in this._body)
			{
				parts.Update();//Update des bodyParts : mise à jour dans la scène, « normalement » ça marche.
			}
		}

		void OnApplicationQuit()
		{
			HumanDLLInterface.Human_destroy(this._humanInstance);
			HumanDLLInterface.DTrack_destroy();
		}
	}
}