using System;
using System.Runtime.InteropServices;
using UnityEngine;

// Token: 0x0200001B RID: 27
public class iOSPlugins
{
	// Token: 0x060000EC RID: 236
	[DllImport("__Internal")]
	private static extern void _SMSsend(string tophone, string withtext, int n);

	// Token: 0x060000ED RID: 237
	[DllImport("__Internal")]
	private static extern int _unpause();

	// Token: 0x060000EE RID: 238
	[DllImport("__Internal")]
	private static extern int _checkRotation();

	// Token: 0x060000EF RID: 239
	[DllImport("__Internal")]
	private static extern int _back();

	// Token: 0x060000F0 RID: 240
	[DllImport("__Internal")]
	private static extern int _Send();

	// Token: 0x060000F1 RID: 241
	[DllImport("__Internal")]
	private static extern void _purchaseItem(string itemID, string userName, string gameID);

	// Token: 0x060000F2 RID: 242 RVA: 0x00006F5C File Offset: 0x0000515C
	public static int Check()
	{
		if (Application.platform == RuntimePlatform.IPhonePlayer)
		{
			return iOSPlugins.checkCanSendSMS();
		}
		iOSPlugins.devide = iPhoneSettings.generation.ToString();
		string a = string.Empty + iOSPlugins.devide[2];
		if (a == "h" && iOSPlugins.devide.Length > 6)
		{
			iOSPlugins.Myname = SystemInfo.operatingSystem.ToString();
			string a2 = string.Empty + iOSPlugins.Myname[10];
			if (a2 != "2" && a2 != "3")
			{
				return 0;
			}
			return 1;
		}
		else
		{
			Cout.println(iOSPlugins.devide + "  loai");
			if (iOSPlugins.devide == "Unknown" && ScaleGUI.WIDTH * ScaleGUI.HEIGHT < 786432f)
			{
				return 0;
			}
			return -1;
		}
	}

	// Token: 0x060000F3 RID: 243 RVA: 0x00007058 File Offset: 0x00005258
	public static int checkCanSendSMS()
	{
		if (iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation == iPhoneGeneration.iPhone4S || iPhoneSettings.generation == iPhoneGeneration.iPhone5)
		{
			return 0;
		}
		return -1;
	}

	// Token: 0x060000F4 RID: 244 RVA: 0x0000708C File Offset: 0x0000528C
	public static void SMSsend(string phonenumber, string bodytext, int n)
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			iOSPlugins._SMSsend(phonenumber, bodytext, n);
		}
	}

	// Token: 0x060000F5 RID: 245 RVA: 0x000070A0 File Offset: 0x000052A0
	public static void back()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			iOSPlugins._back();
		}
	}

	// Token: 0x060000F6 RID: 246 RVA: 0x000070B4 File Offset: 0x000052B4
	public static void Send()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			iOSPlugins._Send();
		}
	}

	// Token: 0x060000F7 RID: 247 RVA: 0x000070C8 File Offset: 0x000052C8
	public static int unpause()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			return iOSPlugins._unpause();
		}
		return 0;
	}

	// Token: 0x060000F8 RID: 248 RVA: 0x000070DC File Offset: 0x000052DC
	public static int checkRotation()
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			return iOSPlugins._checkRotation();
		}
		return 0;
	}

	// Token: 0x060000F9 RID: 249 RVA: 0x000070F0 File Offset: 0x000052F0
	public static void purchaseItem(string itemID, string userName, string gameID)
	{
		if (Application.platform != RuntimePlatform.OSXEditor)
		{
			iOSPlugins._purchaseItem(itemID, userName, gameID);
		}
	}

	// Token: 0x040000DF RID: 223
	public static string devide;

	// Token: 0x040000E0 RID: 224
	public static string Myname;
}
