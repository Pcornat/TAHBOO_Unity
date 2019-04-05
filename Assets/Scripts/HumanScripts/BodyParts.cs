using System;
using UnityEngine;
using System.Runtime.InteropServices;

namespace HumanScripts
{
	public class BodyParts : object
	{
		private HumanBodyBones _bone;
		private readonly Animator _attachedHuman;
		private Int64 _id;
		private readonly IntPtr _humanRef;
		
		public Int64 Id
		{
			get { return _id; }
			set { _id = value; }
		}

		public HumanBodyBones Bone
		{
			get { return _bone; }
			set { _bone = value; }
		}

		public BodyParts(Animator attachedHuman, IntPtr humanRef)
		{
            _attachedHuman = attachedHuman ?? throw new ArgumentNullException(nameof(attachedHuman));
			_humanRef = humanRef;
		}

		public BodyParts(HumanBodyBones bone, Animator attachedHuman, Int64 id, IntPtr humanRef)
		{
            this._bone = bone;
			this._attachedHuman = attachedHuman ?? throw new ArgumentNullException(nameof(attachedHuman));
			this._id = id;
			this._humanRef = humanRef;
		}

		public void Update()
		{
            IntPtr position = HumanDLLInterface.getBodyPartPos(this._humanRef, this._id);
            int arrayLength = 3;
            Double[] resultPosition = new Double[arrayLength];
            Marshal.Copy(position, resultPosition, 0, arrayLength);

            /*Debug.Log("resultPosition 0 "+ resultPosition[0]);
            Debug.Log("resultPosition 1 " + resultPosition[1]);
            Debug.Log("resultPosition 2 " + resultPosition[2]);*/
            resultPosition[0] = resultPosition[0] / 1000;
            resultPosition[1] = resultPosition[1] / 1000;
            resultPosition[2] = resultPosition[2] / 1000;

            IntPtr rotation = HumanDLLInterface.getBodyPartQuat(this._humanRef, this._id);
            arrayLength = 4;
            Double[] resultRotation = new Double[arrayLength];
            Marshal.Copy(rotation, resultRotation, 0, arrayLength);


            /*Debug.Log("resultRotation 0 " + resultRotation[0]);
            Debug.Log("resultRotation 1 " + resultRotation[1]);
            Debug.Log("resultRotation 2 " + resultRotation[2]);
            Debug.Log("resultRotation 3 " + resultRotation[3]);*/

            var boneTransform = this._attachedHuman.GetBoneTransform(this._bone);
            Quaternion test = new Quaternion((float)resultRotation[0], (float)resultRotation[1], (float)resultRotation[2], (float)resultRotation[3]);
            boneTransform.rotation = test;
            Vector3 test2 = new Vector3((float)resultPosition[0], (float)resultPosition[1], (float)resultPosition[2]);
            boneTransform.position = test2;
        }
	}
}