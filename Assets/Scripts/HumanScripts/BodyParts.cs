using System;
using UnityEngine;

namespace HumanScripts
{
	public class BodyParts : object
	{
		private HumanBodyBones _bone;
		private Animator _attachedHuman;
		private long _id;
		private IntPtr _humanRef;
		
		public long Id
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
			if (attachedHuman == null) throw new ArgumentNullException(nameof(attachedHuman));
			_attachedHuman = attachedHuman;
			_humanRef = humanRef;
		}

		public BodyParts(HumanBodyBones bone, Animator attachedHuman, long id, IntPtr humanRef)
		{
			if (attachedHuman == null) throw new ArgumentNullException(nameof(attachedHuman));
			this._bone = bone;
			this._attachedHuman = attachedHuman;
			this._id = id;
			this._humanRef = humanRef;
		}

		public void Update()
		{
			var position = HumanDLLInterface.getBodyPartPos(this._humanRef, this._id);
			var rotation = HumanDLLInterface.getBodyPartQuat(this._humanRef, this._id);
			var boneTransform = this._attachedHuman.GetBoneTransform(this._bone);

			boneTransform.rotation = new Quaternion((float) rotation[0], (float) rotation[1], (float) rotation[2], (float) rotation[4]);
			boneTransform.position = new Vector3((float) position[0], (float) position[1], (float) position[2]);
		}
	}
}