using System;

// Token: 0x02000095 RID: 149
public class MainDialog : AvMain
{
	// Token: 0x0600071C RID: 1820 RVA: 0x0006C1FC File Offset: 0x0006A3FC
	public override void keypress(int keyCode)
	{
		base.keypress(keyCode);
	}

	// Token: 0x0600071D RID: 1821 RVA: 0x0006C208 File Offset: 0x0006A408
	public virtual void DoneChat()
	{
	}

	// Token: 0x04000A74 RID: 2676
	public int wDia;

	// Token: 0x04000A75 RID: 2677
	public int hDia;

	// Token: 0x04000A76 RID: 2678
	public int xDia;

	// Token: 0x04000A77 RID: 2679
	public int yDia;

	// Token: 0x04000A78 RID: 2680
	public int numw;

	// Token: 0x04000A79 RID: 2681
	public int numh;

	// Token: 0x04000A7A RID: 2682
	public int type;

	// Token: 0x04000A7B RID: 2683
	public string[] strinfo;
}
