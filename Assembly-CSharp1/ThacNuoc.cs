using System;

// Token: 0x02000075 RID: 117
public class ThacNuoc
{
	// Token: 0x0600057F RID: 1407 RVA: 0x0004FA18 File Offset: 0x0004DC18
	public ThacNuoc()
	{
	}

	// Token: 0x06000580 RID: 1408 RVA: 0x0004FA20 File Offset: 0x0004DC20
	public ThacNuoc(int idtile, int x, int y)
	{
		this.x = x;
		this.y = y;
		this.idImgThac = (sbyte)idtile;
		if (ThacNuoc.allImgThac == null)
		{
			ThacNuoc.allImgThac = new mImage[9];
			for (int i = 0; i < ThacNuoc.allImgThac.Length; i++)
			{
				ThacNuoc.allImgThac[i] = mImage.createImage("/tilethac" + i + ".png");
			}
		}
	}

	// Token: 0x06000582 RID: 1410 RVA: 0x0004FA9C File Offset: 0x0004DC9C
	public void paint(mGraphics g)
	{
		if (ThacNuoc.allImgThac != null && (int)this.idImgThac < ThacNuoc.allImgThac.Length && ThacNuoc.allImgThac[(int)this.idImgThac] != null)
		{
			g.drawRegion(ThacNuoc.allImgThac[(int)this.idImgThac], 0, this.indexTile * 24, 24, 24, ((int)this.idImgThac <= 4) ? 0 : 0, this.x, this.y, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x06000583 RID: 1411 RVA: 0x0004FB20 File Offset: 0x0004DD20
	public void update()
	{
		if (GameCanvas.gameTick % 4 == 0)
		{
			this.indexTile = (this.indexTile + 1) % 4;
		}
	}

	// Token: 0x06000584 RID: 1412 RVA: 0x0004FB40 File Offset: 0x0004DD40
	public bool isThacNuoc()
	{
		return true;
	}

	// Token: 0x040007BD RID: 1981
	public sbyte idImgThac;

	// Token: 0x040007BE RID: 1982
	private int x;

	// Token: 0x040007BF RID: 1983
	private int y;

	// Token: 0x040007C0 RID: 1984
	public static mImage[] allImgThac;

	// Token: 0x040007C1 RID: 1985
	private int indexTile;
}
