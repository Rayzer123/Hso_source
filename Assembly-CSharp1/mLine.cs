using System;

// Token: 0x020000C9 RID: 201
public class mLine
{
	// Token: 0x06000992 RID: 2450 RVA: 0x000A322C File Offset: 0x000A142C
	public mLine(int x1, int y1, int x2, int y2, float r, float b, float g, float a)
	{
		this.x1 = x1;
		this.y1 = y1;
		this.x2 = x2;
		this.y2 = y2;
		this.r = r;
		this.b = b;
		this.g = g;
		this.a = a;
	}

	// Token: 0x06000993 RID: 2451 RVA: 0x000A327C File Offset: 0x000A147C
	public mLine(int x1, int y1, int x2, int y2, int cl)
	{
		this.x1 = x1;
		this.y1 = y1;
		this.x2 = x2;
		this.y2 = y2;
		this.setColor(cl);
	}

	// Token: 0x06000994 RID: 2452 RVA: 0x000A32AC File Offset: 0x000A14AC
	public void setColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = 255f;
	}

	// Token: 0x040010BE RID: 4286
	public int x1;

	// Token: 0x040010BF RID: 4287
	public int x2;

	// Token: 0x040010C0 RID: 4288
	public int y1;

	// Token: 0x040010C1 RID: 4289
	public int y2;

	// Token: 0x040010C2 RID: 4290
	public float r;

	// Token: 0x040010C3 RID: 4291
	public float b;

	// Token: 0x040010C4 RID: 4292
	public float g;

	// Token: 0x040010C5 RID: 4293
	public float a;
}
