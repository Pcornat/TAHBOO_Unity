using System;
using System.Runtime.InteropServices;

namespace HumanScripts
{
	public class HumanDLLInterface
	{
		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode)]
		public static extern Int32 update(IntPtr human);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode)]
		public static extern IntPtr Human_create([MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode)]
		public static extern void Human_destroy(IntPtr human);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode)]
		public static extern void DTrack_destroy();

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode)]
		public static extern long getNumBodyParts(IntPtr human);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
		public static extern double[] getBodyPartPos(IntPtr human, long id);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
		public static extern double[] getBodyPartQuat(IntPtr human, long id);

		[DllImport("libhumanAnimation", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.Cdecl)]
		public static extern int[] getIds(IntPtr human);
	}
}