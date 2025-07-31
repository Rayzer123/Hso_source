using System;

// Token: 0x020000B0 RID: 176
public class ItemMap : MainItemMap
{
	// Token: 0x060008C1 RID: 2241 RVA: 0x000929F8 File Offset: 0x00090BF8
	public ItemMap(short IDItem, short IDImage, int dx, int dy, int[][] Block) : base(IDItem, IDImage, dx, dy, Block)
	{
		this.TypeItem = 0;
	}

	// Token: 0x060008C3 RID: 2243 RVA: 0x00092A50 File Offset: 0x00090C50
	public void setInfoItem(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x060008C4 RID: 2244 RVA: 0x00092A60 File Offset: 0x00090C60
	public override void paint(mGraphics g)
	{
		MainImage imagePartItemMap = ObjectData.getImagePartItemMap(this.IDImage);
		if (imagePartItemMap.img != null)
		{
			g.drawImage(imagePartItemMap.img, this.x + this.dx, this.y + this.dy, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008C5 RID: 2245 RVA: 0x00092AB0 File Offset: 0x00090CB0
	public static void paintDieHouseArena(mGraphics g)
	{
		if (ItemMap.isPaintDieHouseArena)
		{
			if (GameCanvas.loadmap.idMap == 58)
			{
				ItemMap.img_HouseArena_Die[0].drawFrame(0, ItemMap.dx_imgDie[0], ItemMap.dy_imgDie[0], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 56)
			{
				ItemMap.img_HouseArena_Die[1].drawFrame(0, ItemMap.dx_imgDie[1], ItemMap.dy_imgDie[1], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 54)
			{
				ItemMap.img_HouseArena_Die[2].drawFrame(0, ItemMap.dx_imgDie[2], ItemMap.dy_imgDie[2], 0, g);
			}
			else if (GameCanvas.loadmap.idMap == 60)
			{
				ItemMap.img_HouseArena_Die[3].drawFrame(0, ItemMap.dx_imgDie[3], ItemMap.dy_imgDie[3], 0, g);
			}
		}
	}

	// Token: 0x04000D9D RID: 3485
	public static bool isPaintDieHouseArena = false;

	// Token: 0x04000D9E RID: 3486
	public static FrameImage[] img_HouseArena_Die;

	// Token: 0x04000D9F RID: 3487
	public static int[] dx_imgDie = new int[]
	{
		420,
		376,
		290,
		310
	};

	// Token: 0x04000DA0 RID: 3488
	public static int[] dy_imgDie = new int[]
	{
		188,
		447,
		426,
		105
	};
}
