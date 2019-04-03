using System;
using UnityEngine;

namespace HumanScripts
{
	public class BodyParts : object
	{
		private Animator _attachedHuman;
		private IntPtr _humanRef;

		public Int64 Id { get; set; }

		public HumanBodyBones Bone { get; set; }

		public BodyParts(Animator attachedHuman, IntPtr humanRef)
		{
			if (attachedHuman == null) throw new ArgumentNullException(nameof(attachedHuman));
			_attachedHuman = attachedHuman;
			_humanRef = humanRef;
		}

		public BodyParts(HumanBodyBones bone, Animator attachedHuman, Int64 id, IntPtr humanRef)
		{
			if (attachedHuman == null) throw new ArgumentNullException(nameof(attachedHuman));
			this.Bone = bone;
			this._attachedHuman = attachedHuman;
			this.Id = id;
			this._humanRef = humanRef;
		}

		public void Update()
		{
			var position = HumanDLLInterface.getBodyPartPos(this._humanRef, this.Id);
			var rotation = HumanDLLInterface.getBodyPartQuat(this._humanRef, this.Id);
			var boneTransform = this._attachedHuman.GetBoneTransform(this.Bone);

			boneTransform.rotation = new Quaternion((float) rotation[0], (float) rotation[1], (float) rotation[2], (float) rotation[4]);
			boneTransform.position = new Vector3((float) position[0], (float) position[1], (float) position[2]);
		}
	}
}