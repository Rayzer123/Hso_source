using System;

// Token: 0x0200005E RID: 94
public class MonsterQuest : MainMonster
{
	// Token: 0x0600049A RID: 1178 RVA: 0x0004087C File Offset: 0x0003EA7C
	public MonsterQuest(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		this.typeObject = 1;
		this.typeMonster = typeMonster;
		this.ID = ID;
		this.catalogyMonster = Monster;
		this.xAnchor = x;
		this.yAnchor = y;
		this.x = x;
		this.y = y;
		this.name = name;
		this.maxHp = maxHP;
		this.hp = maxHP;
		this.Lv = (short)lv;
		this.MonWater = 1;
		this.Direction = 0;
		this.nFrame = 6;
		this.wOne = (this.hOne = -1);
		this.ysai = -2;
	}

	// Token: 0x0600049C RID: 1180 RVA: 0x00040968 File Offset: 0x0003EB68
	public override void paint(mGraphics g)
	{
		if (!this.isDie)
		{
			MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
			if (imagePartMonster.img != null)
			{
				if (this.wOne < 0)
				{
					if (this.catalogyMonster <= 92)
					{
						this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / this.nFrame;
						this.wOne = mImage.getImageWidth(imagePartMonster.img.image);
					}
					else
					{
						this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
						this.wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
					}
				}
				int x = 0;
				int num = (int)MonsterQuest.mFrameImg[this.f / 3] * this.hOne;
				if (this.catalogyMonster > 92)
				{
					x = (int)MonsterQuest.mFrameImg[this.f / 3] / 3 * this.wOne;
					num = (int)MonsterQuest.mFrameImg[this.f / 3] % 3 * this.hOne;
				}
				if (this.isReveiceQuest)
				{
					if (this.timeTanHinh > this.test)
					{
						g.drawRegion(imagePartMonster.img, x, num, this.wOne, this.hRe, 0, this.x, this.y - this.hOne / 2, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
						g.drawRegion(imagePartMonster.img, x, num + this.hOne - this.hRe, this.wOne, this.hRe, 0, this.x, this.y - this.hOne / 2 + this.hRe, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					}
				}
				else
				{
					g.drawRegion(imagePartMonster.img, x, num, this.wOne, this.hOne, 0, this.x + (int)MonsterQuest.mPosImg[0][this.fpos / 3], this.y + (int)MonsterQuest.mPosImg[1][this.fpos / 3], mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			if (this.Action != 4 && !this.isReveiceQuest)
			{
				this.paintName(g, 0);
			}
		}
	}

	// Token: 0x0600049D RID: 1181 RVA: 0x00040BA4 File Offset: 0x0003EDA4
	public override void update()
	{
		this.setDie();
		if (this.Action != 4)
		{
			if (this.isReveiceQuest)
			{
				this.timeTanHinh++;
				this.hRe += 2;
				if (this.hRe >= (this.hOne - 1) / 2)
				{
					this.isReveiceQuest = false;
					this.timeTanHinh = 0;
					this.hRe = 10;
				}
			}
			this.f++;
			if (this.f / 3 > MonsterQuest.mFrameImg.Length - 1)
			{
				this.f = 0;
			}
			this.fpos++;
			if (this.fpos / 3 > MonsterQuest.mPosImg[0].Length - 1)
			{
				this.fpos = 0;
			}
		}
		base.update();
	}

	// Token: 0x0600049E RID: 1182 RVA: 0x00040C74 File Offset: 0x0003EE74
	public new void setDie()
	{
		if (this.Action == 4)
		{
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(20);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, this.x + num2, this.y + num3 - this.hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, this.x + num2, this.y + num3 - this.hOne / 2);
					}
				}
			}
			if (this.timeReveice >= 0)
			{
				if ((GameCanvas.timeNow - this.timedie) / 1000L > (long)(this.timeReveice - 1))
				{
					base.Reveive();
					this.isReveiceQuest = true;
					this.timeTanHinh = 0;
					this.hRe = 10;
					GameScreen.addEffectKill(81, this.x, this.y - 20, 200, 0, 0);
					GameScreen.addEffectEndKill(39, this.x, this.y - this.hOne / 2);
				}
			}
		}
		else if (this.hp <= 0)
		{
			this.hp = 0;
			this.Action = 4;
			base.resetXY();
			this.timedie = GameCanvas.timeNow;
		}
	}

	// Token: 0x0400068F RID: 1679
	private int fpos;

	// Token: 0x04000690 RID: 1680
	private bool isReveiceQuest;

	// Token: 0x04000691 RID: 1681
	private static sbyte[] mFrameImg = new sbyte[]
	{
		0,
		1,
		2,
		3,
		4,
		5,
		5,
		5,
		5,
		4,
		3,
		2,
		1,
		0
	};

	// Token: 0x04000692 RID: 1682
	private static sbyte[][] mPosImg = new sbyte[][]
	{
		new sbyte[8],
		new sbyte[]
		{
			0,
			0,
			-1,
			-1,
			0,
			0,
			1,
			1
		}
	};

	// Token: 0x04000693 RID: 1683
	private int test;

	// Token: 0x04000694 RID: 1684
	private int hRe;
}
