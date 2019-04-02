using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
            this._humanInstance = HumanDLLInterface.Human_create("D:\\MASTER\\M1_CHPS\\TER\\TER\\test\\Assets\\Plugin\\config.json");
            if (this._humanInstance == null)
            {
                Debug.Log("Error Human instance null");

            }
            else
            {
                Debug.Log("Human instance create");
            }

            IntPtr tabIds = HumanDLLInterface.getIds(this._humanInstance);
            int arrayLength = (int)Marshal.ReadInt64(tabIds);
            IntPtr start = IntPtr.Add(tabIds, 8);
            Int64[] result = new Int64[arrayLength];
            Marshal.Copy(start, result, 0, arrayLength);

            Debug.Log("Getid ok");
			for (long i = 0; i < result.Length ; ++i)
			{
				this._body.Add(new BodyParts(this.GetComponent<Animator>(), this._humanInstance));
			}

			//Init of all the bones.
			this._body[0].Bone = HumanBodyBones.Head;
			this._body[0].Id = result[0];

            this._body[1].Bone = HumanBodyBones.LeftFoot;
			this._body[1].Id = result[1];

            this._body[2].Bone = HumanBodyBones.RightFoot;
			this._body[2].Id = result[2];

            this._body[3].Bone = HumanBodyBones.RightUpperLeg;
			this._body[3].Id = result[3];

            this._body[4].Bone = HumanBodyBones.LeftHand;
			this._body[4].Id = result[4];

            this._body[5].Bone = HumanBodyBones.LeftLowerArm;
			this._body[5].Id = result[5];

            this._body[6].Bone = HumanBodyBones.LeftUpperLeg;
			this._body[6].Id = result[6];

			this._body[7].Bone = HumanBodyBones.RightLowerArm;
			this._body[7].Id = result[7];

			this._body[8].Bone = HumanBodyBones.LeftShoulder;
			this._body[8].Id = result[8];

			this._body[9].Bone = HumanBodyBones.RightShoulder;
			this._body[9].Id = result[9];

			this._body[10].Bone = HumanBodyBones.RightHand;
			this._body[10].Id = result[10];

			this._body[11].Bone = HumanBodyBones.Hips;
			this._body[11].Id = result[11];
		}

		// Start is called before the first frame update
		void Start()
		{
        }

		// Update is called once per frame
		void Update()
		{
            if (HumanDLLInterface.update(this._humanInstance) == 0)
            {
                foreach (var parts in this._body)
                {
                    parts.Update();//Update des bodyParts : mise à jour dans la scène, « normalement » ça marche.*/
                }
            }
            else
            {
                Debug.Log("DTRACK C D LA MERT");
            }
		}

		void OnApplicationQuit()
		{
			HumanDLLInterface.Human_destroy(this._humanInstance);
			HumanDLLInterface.DTrack_destroy();
		}
	}
}