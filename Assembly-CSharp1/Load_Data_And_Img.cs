using System;

// Token: 0x020000D4 RID: 212
public class Load_Data_And_Img
{
	// Token: 0x040011AE RID: 4526
	public static Load_Data_And_Img.LoadData load = new Load_Data_And_Img.LoadData();

	// Token: 0x020000D5 RID: 213
	public class LoadData
	{
		// Token: 0x060009F0 RID: 2544 RVA: 0x000A7B94 File Offset: 0x000A5D94
		public void loadWpsPlash(int i, int j)
		{
			if (this.iWpsPlash == -1 && this.jWpsPlash == -1)
			{
				this.iWpsPlash = i;
				this.jWpsPlash = j;
			}
		}

		// Token: 0x060009F1 RID: 2545 RVA: 0x000A7BC8 File Offset: 0x000A5DC8
		public void loadImgWeaPone(int i, int j, int index)
		{
			if (this.iImgWeaPone == -1 && this.jImgWeaPone == -1)
			{
				this.iImgWeaPone = i;
				this.jImgWeaPone = j;
				this.indexWeapone = index;
			}
		}

		// Token: 0x060009F2 RID: 2546 RVA: 0x000A7BF8 File Offset: 0x000A5DF8
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

		// Token: 0x040011AF RID: 4527
		private int iWpsPlash = -1;

		// Token: 0x040011B0 RID: 4528
		private int jWpsPlash = -1;

		// Token: 0x040011B1 RID: 4529
		private int iImgWeaPone = -1;

		// Token: 0x040011B2 RID: 4530
		private int jImgWeaPone = -1;

		// Token: 0x040011B3 RID: 4531
		private int indexWeapone = -1;

		// Token: 0x040011B4 RID: 4532
		private int indexImgEffect = -1;

		// Token: 0x040011B5 RID: 4533
		private int indexTreeImg = -1;

		// Token: 0x040011B6 RID: 4534
		private int indexMap = -1;

		// Token: 0x040011B7 RID: 4535
		private int indexArrow = -1;

		// Token: 0x040011B8 RID: 4536
		private IAction iaLoadMap;

		// Token: 0x040011B9 RID: 4537
		public bool isInitGame;

		// Token: 0x040011BA RID: 4538
		public byte[] byteMap;
	}
}
