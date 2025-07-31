using System;

// Token: 0x020000E2 RID: 226
public class LoadData
{
	// Token: 0x06000AFA RID: 2810 RVA: 0x000BDFD8 File Offset: 0x000BC1D8
	public void loadWpsPlash(int i, int j)
	{
		if (this.iWpsPlash == -1 && this.jWpsPlash == -1)
		{
			this.iWpsPlash = i;
			this.jWpsPlash = j;
		}
	}

	// Token: 0x06000AFB RID: 2811 RVA: 0x000BE00C File Offset: 0x000BC20C
	public void loadImgWeaPone(int i, int j, int index)
	{
		if (this.iImgWeaPone == -1 && this.jImgWeaPone == -1)
		{
			this.iImgWeaPone = i;
			this.jImgWeaPone = j;
			this.indexWeapone = index;
		}
	}

	// Token: 0x06000AFC RID: 2812 RVA: 0x000BE03C File Offset: 0x000BC23C
	public void run()
	{
		if (this.iWpsPlash != -1 && this.jWpsPlash != -1)
		{
			CRes.GetWPSplashInfo(0, this.iWpsPlash, this.jWpsPlash);
			this.iWpsPlash = -1;
			this.jWpsPlash = -1;
		}
		if (this.iImgWeaPone != -1 && this.jImgWeaPone != -1)
		{
			CRes.getImgWeaPone(this.iImgWeaPone, this.jImgWeaPone, this.indexWeapone);
			this.iImgWeaPone = -1;
			this.jImgWeaPone = -1;
		}
	}

	// Token: 0x0400127D RID: 4733
	public int iWpsPlash = -1;

	// Token: 0x0400127E RID: 4734
	public int jWpsPlash = -1;

	// Token: 0x0400127F RID: 4735
	public int iImgWeaPone = -1;

	// Token: 0x04001280 RID: 4736
	public int jImgWeaPone = -1;

	// Token: 0x04001281 RID: 4737
	public int indexWeapone = -1;

	// Token: 0x04001282 RID: 4738
	public int indexImgEffect = -1;

	// Token: 0x04001283 RID: 4739
	public int indexTreeImg = -1;

	// Token: 0x04001284 RID: 4740
	public int indexMap = -1;

	// Token: 0x04001285 RID: 4741
	public int indexArrow = -1;

	// Token: 0x04001286 RID: 4742
	private IAction iaLoadMap;

	// Token: 0x04001287 RID: 4743
	public bool isInitGame;

	// Token: 0x04001288 RID: 4744
	public sbyte[] byteMap;
}
