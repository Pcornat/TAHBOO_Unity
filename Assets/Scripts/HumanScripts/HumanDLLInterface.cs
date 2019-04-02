using System;
using System.Runtime.InteropServices;

namespace HumanScripts
{
	internal static class HumanDLLInterface
	{
		private const string Dllname = "humanAnimation";

		[DllImport(Dllname, CallingConvention =CallingConvention.Cdecl)]
        public static extern Int32 update(IntPtr human);

		[DllImport(Dllname, CallingConvention = CallingConvention.Cdecl)]

        public static extern IntPtr Human_create([MarshalAs(UnmanagedType.LPStr)] string filename);

		[DllImport(Dllname, CallingConvention = CallingConvention.Cdecl)]
		public static extern void Human_destroy(IntPtr human);

		[DllImport(Dllname,CallingConvention = CallingConvention.Cdecl)]
		public static extern void DTrack_destroy();

		[DllImport(Dllname,CallingConvention = CallingConvention.Cdecl)]
		public static extern long getNumBodyParts(IntPtr human);

		[DllImport(Dllname,CallingConvention = CallingConvention.Cdecl)]
		public static extern double[] getBodyPartPos(IntPtr human, long id);

		[DllImport(Dllname,CallingConvention = CallingConvention.Cdecl)]
		public static extern double[] getBodyPartQuat(IntPtr human, long id);

		[DllImport(Dllname, CallingConvention = CallingConvention.Cdecl)]
		public static extern IntPtr getIds(IntPtr human);
	}
}