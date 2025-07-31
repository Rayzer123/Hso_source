using System;

// Token: 0x020000B1 RID: 177
public class MainItemMap
{
	// Token: 0x060008C6 RID: 2246 RVA: 0x00092B90 File Offset: 0x00090D90
	public MainItemMap()
	{
	}

	// Token: 0x060008C7 RID: 2247 RVA: 0x00092B98 File Offset: 0x00090D98
	public MainItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block)
	{
		this.IDItem = IDItem;
		this.IDImage = IDImage;
		this.dx = dx;
		this.dy = dy;
		this.Block = Block;
	}

	// Token: 0x060008C8 RID: 2248 RVA: 0x00092BC8 File Offset: 0x00090DC8
	public virtual void setDataEff(sbyte[] datasv)
	{
	}

	// Token: 0x060008C9 RID: 2249 RVA: 0x00092BCC File Offset: 0x00090DCC
	public virtual void paint(mGraphics g)
	{
	}

	// Token: 0x060008CA RID: 2250 RVA: 0x00092BD0 File Offset: 0x00090DD0
	public virtual void update()
	{
	}

	// Token: 0x060008CB RID: 2251 RVA: 0x00092BD4 File Offset: 0x00090DD4
	public bool isInScreen()
	{
		if (this.hOne == 0 || this.wOne == 0)
		{
			MainImage imagePartItemMap = ObjectData.getImagePartItemMap(this.IDItem);
			if (imagePartItemMap.img != null)
			{
				this.wOne = mImage.getImageWidth(imagePartItemMap.img.image);
				this.hOne = mImage.getImageHeight(imagePartItemMap.img.image);
			}
		}
		return this.x + this.dx + this.wOne >= MainScreen.cameraMain.xCam && this.x + this.dx - this.wOne <= MainScreen.cameraMain.xCam + GameCanvas.w && this.y + this.dy + this.hOne >= MainScreen.cameraMain.yCam && this.y + this.dy - this.hOne <= MainScreen.cameraMain.yCam + GameCanvas.h;
	}

	// Token: 0x04000DA1 RID: 3489
	public const sbyte ITEM_MAP = 0;

	// Token: 0x04000DA2 RID: 3490
	public const sbyte EFF_MAP = 1;

	// Token: 0x04000DA3 RID: 3491
	public const sbyte EFF_FROM_SV = 2;

	// Token: 0x04000DA4 RID: 3492
	public const sbyte EFF_SKILL_FROM_SV = 3;

	// Token: 0x04000DA5 RID: 3493
	public const sbyte EFF_MAT_NA = 4;

	// Token: 0x04000DA6 RID: 3494
	public sbyte TypeItem;

	// Token: 0x04000DA7 RID: 3495
	public short IDItem;

	// Token: 0x04000DA8 RID: 3496
	public short IDImage;

	// Token: 0x04000DA9 RID: 3497
	public int dx;

	// Token: 0x04000DAA RID: 3498
	public int dy;

	// Token: 0x04000DAB RID: 3499
	public int x;

	// Token: 0x04000DAC RID: 3500
	public int y;

	// Token: 0x04000DAD RID: 3501
	public int wOne;

	// Token: 0x04000DAE RID: 3502
	public int hOne;

	// Token: 0x04000DAF RID: 3503
	public int[][] Block;

	// Token: 0x04000DB0 RID: 3504
	public short idActor;

	// Token: 0x04000DB1 RID: 3505
	private mImage img;
}
