using System;
using System.Runtime.InteropServices;

namespace HumanScripts
{
	public class HumanDLLInterface
	{
		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern Int32 update(IntPtr human);

		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern IntPtr Human_create([MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern void Human_destroy(IntPtr human);

		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern void DTrack_destroy();

		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern double* getBodyPartPos(IntPtr ptr, long id);

		[DllImport("libhumanAnimation.dll", CharSet = CharSet.Unicode)]
		public static extern double* getBodyPartQuat(IntPtr ptr, long id);
	}
}