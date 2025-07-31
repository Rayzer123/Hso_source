using System;

// Token: 0x0200002C RID: 44
public class Usa_Server
{
	// Token: 0x06000214 RID: 532 RVA: 0x0000CA90 File Offset: 0x0000AC90
	public static void setLinkIp()
	{
		if (Usa_Server.isUsa_server)
		{
			GameCanvas.t = new TE();
			GameCanvas.linkIP = "http://knightageonline.com/srvip/";
			string[,] array = new string[1, 2];
			array[0, 0] = "Global Server";
			array[0, 1] = "54.255.77.17";
			GameCanvas.listServer = array;
		}
	}

	// Token: 0x040001CF RID: 463
	public static bool isUsa_server;
}
