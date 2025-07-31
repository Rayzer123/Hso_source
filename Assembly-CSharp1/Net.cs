using System;
using UnityEngine;

// Token: 0x02000012 RID: 18
internal class Net
{
	// Token: 0x06000095 RID: 149 RVA: 0x00004070 File Offset: 0x00002270
	public static void update()
	{
		if (Net.www != null && Net.www.isDone)
		{
			string str = string.Empty;
			if (Net.www.error == null || Net.www.error.Equals(string.Empty))
			{
				str = Net.www.text;
			}
			Net.www = null;
			if (Net.h != null)
			{
				Net.h.perform(str);
			}
		}
	}

	// Token: 0x06000096 RID: 150 RVA: 0x000040EC File Offset: 0x000022EC
	public static void connectHTTP(string link, iCommand h)
	{
		if (Net.www != null)
		{
			Cout.LogError("GET HTTP BUSY");
		}
		Cout.LogWarning("REQUEST " + link);
		Net.www = new WWW(link);
		Net.h = h;
	}

	// Token: 0x04000050 RID: 80
	public static WWW www;

	// Token: 0x04000051 RID: 81
	public static iCommand h;
}
