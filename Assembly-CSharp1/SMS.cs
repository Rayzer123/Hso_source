using System;
using System.Threading;
using UnityEngine;

// Token: 0x02000018 RID: 24
public class SMS
{
	// Token: 0x060000B0 RID: 176 RVA: 0x0000471C File Offset: 0x0000291C
	public static int send(string content, string to)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			return SMS.__send(content, to);
		}
		return SMS._send(content, to);
	}

	// Token: 0x060000B1 RID: 177 RVA: 0x00004754 File Offset: 0x00002954
	private static int _send(string content, string to)
	{
		if (SMS.status != 0)
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				if (SMS.status == 0)
				{
					break;
				}
			}
			if (SMS.status != 0)
			{
				Cout.LogError("CANNOT SEND SMS " + content + " WHEN SENDING " + SMS._content);
				return -1;
			}
		}
		SMS._content = content;
		SMS._to = to;
		SMS._result = -1;
		SMS.status = 2;
		int j;
		for (j = 0; j < 500; j++)
		{
			Thread.Sleep(5);
			if (SMS.status == 0)
			{
				break;
			}
		}
		if (j == 500)
		{
			Debug.LogError("TOO LONG FOR SEND SMS " + content);
			SMS.status = 0;
		}
		else
		{
			Debug.Log(string.Concat(new object[]
			{
				"Send SMS ",
				content,
				" done in ",
				j * 5,
				"ms"
			}));
		}
		return SMS._result;
	}

	// Token: 0x060000B2 RID: 178 RVA: 0x00004864 File Offset: 0x00002A64
	private static int __send(string content, string to)
	{
		int num = iOSPlugins.Check();
		Cout.println("vao sms ko " + num);
		if (num >= 0)
		{
			SMS.f = true;
			SMS.sendEnable = true;
			iOSPlugins.SMSsend(to, content, num);
			Screen.orientation = ScreenOrientation.AutoRotation;
		}
		return num;
	}

	// Token: 0x060000B3 RID: 179 RVA: 0x000048B0 File Offset: 0x00002AB0
	public static void update()
	{
		float num = Time.time;
		if (num - (float)SMS.time > 1f)
		{
			SMS.time++;
		}
		if (SMS.f)
		{
			SMS.OnSMS();
		}
		if (SMS.status == 2)
		{
			SMS.status = 1;
			try
			{
				SMS._result = SMS.__send(SMS._content, SMS._to);
			}
			catch (Exception ex)
			{
				Debug.Log("CANNOT SEND SMS");
			}
			SMS.status = 0;
		}
	}

	// Token: 0x060000B4 RID: 180 RVA: 0x0000494C File Offset: 0x00002B4C
	private static void OnSMS()
	{
		if (SMS.sendEnable)
		{
			if (iOSPlugins.checkRotation() == 1)
			{
				Screen.orientation = ScreenOrientation.LandscapeLeft;
			}
			else if (iOSPlugins.checkRotation() == -1)
			{
				Screen.orientation = ScreenOrientation.Portrait;
			}
			else if (iOSPlugins.checkRotation() == 0)
			{
				Screen.orientation = ScreenOrientation.AutoRotation;
			}
			else if (iOSPlugins.checkRotation() == 2)
			{
				Screen.orientation = ScreenOrientation.LandscapeRight;
			}
			else if (iOSPlugins.checkRotation() == 3)
			{
				Screen.orientation = ScreenOrientation.PortraitUpsideDown;
			}
			if (SMS.time0 < 5)
			{
				SMS.time0++;
			}
			else
			{
				iOSPlugins.Send();
				SMS.sendEnable = false;
				SMS.time0 = 0;
			}
		}
		if (iOSPlugins.unpause() == 1)
		{
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			if (SMS.time0 < 5)
			{
				SMS.time0++;
			}
			else
			{
				SMS.f = false;
				iOSPlugins.back();
				SMS.time0 = 0;
			}
		}
	}

	// Token: 0x0400007A RID: 122
	private const int INTERVAL = 5;

	// Token: 0x0400007B RID: 123
	private const int MAXTIME = 500;

	// Token: 0x0400007C RID: 124
	private static int status;

	// Token: 0x0400007D RID: 125
	private static int _result;

	// Token: 0x0400007E RID: 126
	private static string _to;

	// Token: 0x0400007F RID: 127
	private static string _content;

	// Token: 0x04000080 RID: 128
	private static bool f;

	// Token: 0x04000081 RID: 129
	private static int time;

	// Token: 0x04000082 RID: 130
	public static bool sendEnable;

	// Token: 0x04000083 RID: 131
	private static int time0;
}
