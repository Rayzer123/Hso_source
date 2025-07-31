using System;

// Token: 0x020000BF RID: 191
public class MainPartImage
{
	// Token: 0x06000961 RID: 2401 RVA: 0x00097ACC File Offset: 0x00095CCC
	public MainPartImage(int ID, int x, int y, int w, int h)
	{
		this.ID = (short)ID;
		this.x = (short)x;
		this.y = (short)y;
		this.w = (short)w;
		this.h = (short)h;
	}

	// Token: 0x04000E58 RID: 3672
	public short x;

	// Token: 0x04000E59 RID: 3673
	public short y;

	// Token: 0x04000E5A RID: 3674
	public short w;

	// Token: 0x04000E5B RID: 3675
	public short h;

	// Token: 0x04000E5C RID: 3676
	public short ID;
}
