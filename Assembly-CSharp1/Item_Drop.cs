using System;

// Token: 0x0200004B RID: 75
public class Item_Drop : MainObject
{
	// Token: 0x06000354 RID: 852 RVA: 0x0002D210 File Offset: 0x0002B410
	public Item_Drop(int ID, sbyte type, string name, int x, int y, short IdIcon, sbyte color)
	{
		this.ID = ID;
		this.typeObject = type;
		this.name = name;
		if (x < 48)
		{
			x = 48;
		}
		if (x > GameCanvas.loadmap.maxWMap - 48)
		{
			x = GameCanvas.loadmap.maxWMap - 48;
		}
		if (y < 48)
		{
			y = 48;
		}
		if (y > GameCanvas.loadmap.maxHMap - 48)
		{
			y = GameCanvas.loadmap.maxHMap - 48;
		}
		this.x = x;
		this.y = y;
		this.imageId = (int)IdIcon;
		this.colorName = color;
		this.vx = CRes.random_Am(1, 5);
		this.vy = -CRes.random(3, 10);
		this.vMax = 16;
		this.time = CRes.random(3, 9);
		this.timeAp = GameCanvas.timeNow;
		this.timeRemove = 60;
		this.isSend = false;
	}

	// Token: 0x06000355 RID: 853 RVA: 0x0002D304 File Offset: 0x0002B504
	public override void paint(mGraphics g)
	{
		MainImage mainImage = null;
		switch (this.typeObject)
		{
		case 3:
			mainImage = ObjectData.getImageItem((short)this.imageId);
			break;
		case 4:
			mainImage = ObjectData.getImagePotion((short)this.imageId);
			break;
		case 5:
			mainImage = ObjectData.getImageQuestItem((short)this.imageId);
			break;
		case 7:
			mainImage = ObjectData.getImageMaterial((short)this.imageId);
			break;
		}
		if (mainImage.img != null)
		{
			if (this.hOne == 0)
			{
				this.hOne = mImage.getImageHeight(mainImage.img.image);
			}
			g.drawImage(mainImage.img, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			if ((int)this.typeObject == 3 && (int)this.colorName > 1)
			{
				Item.fraeffitemdrop.drawFrame(((int)this.colorName - 1) * 3 + GameCanvas.gameTick / 3 % 3, this.x + 6, this.y - 14, 0, 3, g);
			}
		}
		if (this.isWater)
		{
			g.drawRegion(MainObject.water, 0, GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x, this.y - 2 + this.dyWater, 3, mGraphics.isFalse);
		}
		if (PaintInfoGameScreen.isLevelPoint)
		{
			int id = 0;
			if ((int)this.typeObject == 3)
			{
				id = (int)this.colorName;
			}
			this.paintName(g, id);
		}
	}

	// Token: 0x06000356 RID: 854 RVA: 0x0002D490 File Offset: 0x0002B690
	public override void paintAvatarFocus(mGraphics g, int xp, int yp)
	{
		MainImage mainImage = null;
		switch (this.typeObject)
		{
		case 3:
			mainImage = ObjectData.getImageItem((short)this.imageId);
			break;
		case 4:
			mainImage = ObjectData.getImagePotion((short)this.imageId);
			break;
		case 5:
			mainImage = ObjectData.getImageQuestItem((short)this.imageId);
			break;
		case 7:
			mainImage = ObjectData.getImageMaterial((short)this.imageId);
			break;
		}
		if (mainImage.img != null)
		{
			if (this.hOne == 0)
			{
				this.hOne = mImage.getImageHeight(mainImage.img.image);
			}
			g.drawImage(mainImage.img, xp - 1, yp, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x06000357 RID: 855 RVA: 0x0002D554 File Offset: 0x0002B754
	public override void update()
	{
		if (this.time > 0)
		{
			this.x += this.vx;
			this.y += this.vy;
			this.vy += 2;
			this.time--;
		}
		if (this.time == 0)
		{
			int tile = GameCanvas.loadmap.getTile(this.x, this.y);
			if (tile == 2)
			{
				this.isWater = true;
			}
			this.isRunAttack = false;
			this.time = -1;
		}
		if (this.isRunAttack)
		{
			this.timefly++;
			this.x += this.vx;
			this.y += this.vy;
			if (this.timefly >= this.timeHuyKill)
			{
				this.isRemove = true;
				this.isRunAttack = false;
			}
		}
		if (this.isSend)
		{
			this.timeGet++;
			if (this.timeGet > 40)
			{
				this.isSend = false;
				this.timeGet = 0;
			}
		}
		if ((GameCanvas.timeNow - this.timeAp) / 1000L >= (long)this.timeRemove)
		{
			this.isRemove = true;
		}
	}

	// Token: 0x04000460 RID: 1120
	private long timeAp;

	// Token: 0x04000461 RID: 1121
	private int timeRemove;

	// Token: 0x04000462 RID: 1122
	private int timefly;
}
