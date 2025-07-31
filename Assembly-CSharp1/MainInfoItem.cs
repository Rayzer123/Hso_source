using System;

// Token: 0x02000052 RID: 82
public class MainInfoItem
{
	// Token: 0x06000391 RID: 913 RVA: 0x00032BE0 File Offset: 0x00030DE0
	public MainInfoItem(int id, int value)
	{
		this.id = id;
		this.value = value;
	}

	// Token: 0x06000392 RID: 914 RVA: 0x00032BF8 File Offset: 0x00030DF8
	public MainInfoItem(int id, int value, int maxDam)
	{
		this.id = id;
		this.value = value;
		this.maxDam = maxDam;
	}

	// Token: 0x040004F1 RID: 1265
	public int id;

	// Token: 0x040004F2 RID: 1266
	public int value;

	// Token: 0x040004F3 RID: 1267
	public int maxDam;
}
