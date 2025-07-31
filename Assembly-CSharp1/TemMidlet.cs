using System;

// Token: 0x02000003 RID: 3
public class TemMidlet
{
	// Token: 0x06000010 RID: 16 RVA: 0x0000232C File Offset: 0x0000052C
	public TemMidlet()
	{
		TemMidlet.temCanvas = new TemCanvas();
		TemMidlet.instance = this;
		Session_ME.gI().setHandler(GlobalMessageHandler.gI());
		TemMidlet.temCanvas.start();
		CRes.load.isInitGame = true;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x000023B4 File Offset: 0x000005B4
	protected void destroyApp(bool arg0)
	{
		TemMidlet.instance.notifyDestroyed();
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000023C0 File Offset: 0x000005C0
	protected void pauseApp()
	{
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000023C4 File Offset: 0x000005C4
	protected void startApp()
	{
	}

	// Token: 0x06000015 RID: 21 RVA: 0x000023C8 File Offset: 0x000005C8
	public void notifyDestroyed()
	{
	}

	// Token: 0x06000016 RID: 22 RVA: 0x000023CC File Offset: 0x000005CC
	public void destroy()
	{
		Main.exit();
	}

	// Token: 0x06000017 RID: 23 RVA: 0x000023D4 File Offset: 0x000005D4
	public static sbyte[] encoding(sbyte[] array)
	{
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (sbyte)(~(sbyte)((int)array[i]));
			}
		}
		return array;
	}

	// Token: 0x06000018 RID: 24 RVA: 0x00002408 File Offset: 0x00000608
	public static void saveRMS(string filename, sbyte[] data)
	{
		Rms.saveRMS(filename, data);
	}

	// Token: 0x06000019 RID: 25 RVA: 0x00002414 File Offset: 0x00000614
	public static sbyte[] loadRMS(string filename)
	{
		return Rms.loadRMS(filename);
	}

	// Token: 0x0600001A RID: 26 RVA: 0x0000241C File Offset: 0x0000061C
	public static void openUrl(string url)
	{
		try
		{
			Main.main.platformRequest(url);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600001B RID: 27 RVA: 0x0000245C File Offset: 0x0000065C
	public static void delRMS()
	{
		Rms.deleteRecordCompareToName();
	}

	// Token: 0x0600001C RID: 28 RVA: 0x00002464 File Offset: 0x00000664
	public static string connectHTTP(string link)
	{
		string strServerInfo = string.Empty;
		iCommand iCommand = new iCommand();
		ActionChat actionChat = delegate(string str)
		{
			if (str == null)
			{
				return;
			}
			strServerInfo = str;
			LogoScreen.saveListServer(strServerInfo);
		};
		iCommand.actionChat = actionChat;
		Net.connectHTTP(link, iCommand);
		return strServerInfo;
	}

	// Token: 0x0600001D RID: 29 RVA: 0x000024AC File Offset: 0x000006AC
	public static void submitPurchase()
	{
	}

	// Token: 0x0600001E RID: 30 RVA: 0x000024B0 File Offset: 0x000006B0
	public void call(string num)
	{
	}

	// Token: 0x0600001F RID: 31 RVA: 0x000024B4 File Offset: 0x000006B4
	public static void handleMessage(Message msg)
	{
	}

	// Token: 0x04000007 RID: 7
	public static TemCanvas temCanvas;

	// Token: 0x04000008 RID: 8
	public static TemMidlet instance;

	// Token: 0x04000009 RID: 9
	public static sbyte DIVICE = 4;

	// Token: 0x0400000A RID: 10
	public static sbyte NONE = 0;

	// Token: 0x0400000B RID: 11
	public static sbyte NOKIA_STORE = 1;

	// Token: 0x0400000C RID: 12
	public static sbyte currentIAPStore = TemMidlet.NONE;

	// Token: 0x0400000D RID: 13
	public static bool isBlockNOKIAStore = true;

	// Token: 0x0400000E RID: 14
	public static sbyte langServer = 0;

	// Token: 0x0400000F RID: 15
	public static string[] listGems = new string[]
	{
		"24 Gems"
	};
}
