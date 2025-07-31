using System;

// Token: 0x020000C4 RID: 196
public class Position
{
	// Token: 0x06000989 RID: 2441 RVA: 0x0009B584 File Offset: 0x00099784
	public Position()
	{
		this.x = 0;
		this.y = 0;
	}

	// Token: 0x0600098A RID: 2442 RVA: 0x0009B5A4 File Offset: 0x000997A4
	public Position(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x0600098B RID: 2443 RVA: 0x0009B5C4 File Offset: 0x000997C4
	public Position(int x, int y, int anchor)
	{
		this.x = x;
		this.y = y;
		this.anchor = anchor;
	}

	// Token: 0x0600098C RID: 2444 RVA: 0x0009B5F4 File Offset: 0x000997F4
	public bool setDetectX(int xx, int num)
	{
		return CRes.abs(xx - this.x) <= num;
	}

	// Token: 0x0600098D RID: 2445 RVA: 0x0009B60C File Offset: 0x0009980C
	public bool setDetectY(int yy, int num)
	{
		return CRes.abs(yy - this.y) <= num;
	}

	// Token: 0x04000EF2 RID: 3826
	public int x;

	// Token: 0x04000EF3 RID: 3827
	public int y;

	// Token: 0x04000EF4 RID: 3828
	public int anchor;

	// Token: 0x04000EF5 RID: 3829
	public sbyte depth;

	// Token: 0x04000EF6 RID: 3830
	public short index = -1;
}
