using System;

// Token: 0x020000AA RID: 170
public class GameMidlet
{
	// Token: 0x06000893 RID: 2195 RVA: 0x00091B34 File Offset: 0x0008FD34
	public static void destroy()
	{
		TemMidlet.instance.destroy();
	}

	// Token: 0x04000D6B RID: 3435
	public static string version = "3.0.2";

	// Token: 0x04000D6C RID: 3436
	public static string[] idGame = new string[]
	{
		"com.silvershield.knight.1",
		"com.silvershield.knight.2"
	};
}
