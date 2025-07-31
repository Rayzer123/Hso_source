using System;

// Token: 0x02000085 RID: 133
public class LogoScreen : MainScreen
{
	// Token: 0x06000661 RID: 1633 RVA: 0x0005FCD4 File Offset: 0x0005DED4
	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
	}

	// Token: 0x06000662 RID: 1634 RVA: 0x0005FD00 File Offset: 0x0005DF00
	public override void update()
	{
		this.dem++;
		if (this.dem > 60)
		{
			this.dem = 0;
			GameCanvas.login.Show();
		}
	}

	// Token: 0x06000663 RID: 1635 RVA: 0x0005FD3C File Offset: 0x0005DF3C
	public static void getServerList(string str, bool isFrist)
	{
		if ((int)GameCanvas.IndexServer == 0 || (int)GameCanvas.IndexServer == 1 || (int)GameCanvas.IndexServer == 3 || (int)GameCanvas.IndexServer == 4 || (int)GameCanvas.IndexServer == 5)
		{
			return;
		}
		if ((int)GameCanvas.IndexServer == 2)
		{
			LogoScreen.setChangeLang();
			GameCanvas.t = new TE();
			return;
		}
		if ((int)GameCanvas.IndexServer == 2)
		{
			LogoScreen.setChangeLang();
			GameCanvas.t = new TE();
			return;
		}
		if (str == null || str.Length == 0)
		{
			return;
		}
		LogoScreen.saveListServer(str);
		string[] array = mFont.split(str.Trim(), ",");
		bool isVN_Eng = GameCanvas.isVN_Eng;
		GameCanvas.listServer = new string[array.Length - 1, 2];
		GameCanvas.portServer = new int[array.Length - 1];
		GameCanvas.langServer = new int[array.Length - 1];
		if (isFrist)
		{
			GameCanvas.IndexServer = (sbyte)(array.Length - 1);
		}
		for (int i = 0; i < array.Length - 1; i++)
		{
			string[] array2 = mFont.split(array[i].Trim(), ":");
			GameCanvas.listServer[i, 0] = array2[0];
			GameCanvas.listServer[i, 1] = array2[1];
			GameCanvas.portServer[i] = (int)short.Parse(array2[2]);
			GameCanvas.langServer[i] = (int)sbyte.Parse(array2[3].Trim());
			if (isFrist && GameCanvas.langServer[i] == (int)TemMidlet.langServer && GameCanvas.isVN_Eng)
			{
				GameCanvas.IndexServer = (sbyte)i;
			}
		}
		GameCanvas.isVN_Eng = (GameCanvas.langServer[(int)GameCanvas.IndexServer] == 0);
		LogoScreen.setChangeLang();
	}

	// Token: 0x06000664 RID: 1636 RVA: 0x0005FED8 File Offset: 0x0005E0D8
	public static void setChangeLang()
	{
		MainRMS.showAuto = string.Empty;
		LoginScreen.indexInfoLogin = 1;
		if (GameCanvas.w < 200 || GameCanvas.h < 200)
		{
			LoginScreen.indexInfoLogin = 2;
		}
		else if (GameCanvas.isTouch)
		{
			if (GameCanvas.w < 380)
			{
				if (GameCanvas.w > 315 && GameCanvas.w < 380)
				{
					LoginScreen.indexInfoLogin = 2;
				}
			}
		}
		GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
		if (!GameCanvas.isVN_Eng)
		{
			GameCanvas.t = new TE();
			if (mSystem.isIP_TrucTiep)
			{
				LoginScreen.logo = mImage.createImage("/interface/logoeip.png");
			}
			else
			{
				LoginScreen.logo = mImage.createImage("/interface/logoe.png");
			}
		}
		else
		{
			GameCanvas.t = new T();
			if (mSystem.isIP_TrucTiep)
			{
				LoginScreen.logo = mImage.createImage("/interface/logoip.png");
			}
			else
			{
				LoginScreen.logo = mImage.createImage("/interface/logo.png");
			}
		}
		List_Server.gI().doSetCaption();
		Usa_Server.setLinkIp();
		IndoServer.setLinkIp();
		GameCanvas.loadCaptionCmd();
		WorldMapScreen.namePos = null;
		GameCanvas.end_Dialog();
	}

	// Token: 0x06000665 RID: 1637 RVA: 0x0006000C File Offset: 0x0005E20C
	public static void saveListServer(string str)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(str);
			CRes.saveRMS("listServer", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000938 RID: 2360
	private int dem;

	// Token: 0x04000939 RID: 2361
	public static string strListserver = string.Empty;

	// Token: 0x0400093A RID: 2362
	public static bool isLoadServer;
}
