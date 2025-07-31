using System;

// Token: 0x0200002B RID: 43
public class IndoServer
{
	// Token: 0x06000211 RID: 529 RVA: 0x0000CA30 File Offset: 0x0000AC30
	public static void setLinkIp()
	{
		if (IndoServer.isIndoSv)
		{
			GameCanvas.t = new TIndo();
			GameCanvas.linkIP = "http://knightageonline.com/srvip/indo.php";
			string[,] array = new string[1, 2];
			array[0, 0] = "Indo Naga";
			array[0, 1] = "54.151.177.35";
			GameCanvas.listServer = array;
		}
	}

	// Token: 0x040001CE RID: 462
	public static bool isIndoSv;
}
