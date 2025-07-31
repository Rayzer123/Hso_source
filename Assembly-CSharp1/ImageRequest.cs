using System;

// Token: 0x020000B9 RID: 185
public class ImageRequest
{
	// Token: 0x06000950 RID: 2384 RVA: 0x00097538 File Offset: 0x00095738
	public ImageRequest(int id)
	{
		this.idRequest = id;
		this.timeRequest = GameCanvas.timeNow;
	}

	// Token: 0x04000E2C RID: 3628
	public static mVector vecImageRequest = new mVector("ImageRequest vecImageRequest");

	// Token: 0x04000E2D RID: 3629
	public long timeRequest;

	// Token: 0x04000E2E RID: 3630
	public int idRequest;
}
