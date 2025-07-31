using System;

// Token: 0x020000BD RID: 189
public class MainImage
{
	// Token: 0x0600095B RID: 2395 RVA: 0x00097978 File Offset: 0x00095B78
	public MainImage()
	{
	}

	// Token: 0x0600095C RID: 2396 RVA: 0x00097988 File Offset: 0x00095B88
	public MainImage(mImage im)
	{
		this.img = im;
		this.count = 0;
		this.w = (short)mImage.getImageWidth(im.image);
		this.h = (short)mImage.getImageWidth(im.image);
	}

	// Token: 0x04000E4B RID: 3659
	public mImage img;

	// Token: 0x04000E4C RID: 3660
	public short w;

	// Token: 0x04000E4D RID: 3661
	public short h;

	// Token: 0x04000E4E RID: 3662
	public int count = -1;

	// Token: 0x04000E4F RID: 3663
	public int timeImageNull;
}
