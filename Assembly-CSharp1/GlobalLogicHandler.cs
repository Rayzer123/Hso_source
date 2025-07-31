using System;

// Token: 0x020000DB RID: 219
public class GlobalLogicHandler
{
	// Token: 0x06000A1E RID: 2590 RVA: 0x000AA2A8 File Offset: 0x000A84A8
	public static GlobalLogicHandler gI()
	{
		if (GlobalLogicHandler.instance == null)
		{
			GlobalLogicHandler.instance = new GlobalLogicHandler();
		}
		return GlobalLogicHandler.instance;
	}

	// Token: 0x06000A1F RID: 2591 RVA: 0x000AA2C4 File Offset: 0x000A84C4
	public void onConnectFail()
	{
	}

	// Token: 0x06000A20 RID: 2592 RVA: 0x000AA2C8 File Offset: 0x000A84C8
	public void onConnectOK()
	{
	}

	// Token: 0x06000A21 RID: 2593 RVA: 0x000AA2CC File Offset: 0x000A84CC
	public static void onDisconnect()
	{
		GlobalLogicHandler.isDisconnect = true;
		if (!GlobalLogicHandler.isMelogin)
		{
			GlobalLogicHandler.isDisConect = true;
			GlobalLogicHandler.timeReconnect = mSystem.currentTimeMillis() + 30000L;
		}
		else
		{
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.timeReconnect = 0L;
		}
		if (GameScreen.isMapLang)
		{
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.timeReconnect = 0L;
		}
	}

	// Token: 0x040011DC RID: 4572
	public static GlobalLogicHandler instance;

	// Token: 0x040011DD RID: 4573
	public static bool isDisConect = false;

	// Token: 0x040011DE RID: 4574
	public static long timeReconnect = mSystem.currentTimeMillis();

	// Token: 0x040011DF RID: 4575
	public static bool isDisconnect;

	// Token: 0x040011E0 RID: 4576
	public static bool isMelogin;
}
