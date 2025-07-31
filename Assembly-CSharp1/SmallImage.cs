using System;

// Token: 0x02000074 RID: 116
public class SmallImage
{
	// Token: 0x0600057D RID: 1405 RVA: 0x0004F9D4 File Offset: 0x0004DBD4
	public SmallImage(int id, int x, int y, int w, int h)
	{
		this.id = (short)id;
		this.x = (short)x;
		this.y = (short)y;
		this.w = (short)w;
		this.h = (short)h;
	}

	// Token: 0x0600057E RID: 1406 RVA: 0x0004FA14 File Offset: 0x0004DC14
	public void paint(mGraphics g, mImage img, int x, int y)
	{
	}

	// Token: 0x040007B8 RID: 1976
	public short id;

	// Token: 0x040007B9 RID: 1977
	public short x;

	// Token: 0x040007BA RID: 1978
	public short y;

	// Token: 0x040007BB RID: 1979
	public short w;

	// Token: 0x040007BC RID: 1980
	public short h;
}
