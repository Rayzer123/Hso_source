using System;

// Token: 0x0200006C RID: 108
public class PartFrame
{
	// Token: 0x06000510 RID: 1296 RVA: 0x00046C58 File Offset: 0x00044E58
	public PartFrame(short dx, short dy, sbyte idSmall)
	{
		this.idSmallImg = idSmall;
		this.dx = dx;
		this.dy = dy;
	}

	// Token: 0x04000710 RID: 1808
	public short dx;

	// Token: 0x04000711 RID: 1809
	public short dy;

	// Token: 0x04000712 RID: 1810
	public sbyte flip;

	// Token: 0x04000713 RID: 1811
	public sbyte onTop;

	// Token: 0x04000714 RID: 1812
	public sbyte idSmallImg;
}
