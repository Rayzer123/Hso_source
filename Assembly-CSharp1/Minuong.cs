using System;

// Token: 0x0200005B RID: 91
public class Minuong : MainMonster
{
	// Token: 0x06000483 RID: 1155 RVA: 0x0003F3E4 File Offset: 0x0003D5E4
	public Minuong(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		this.typeMonster = typeMonster;
		this.ID = ID;
		this.catalogyMonster = Monster;
		this.typeObject = 1;
		this.name = name;
		this.x = x;
		this.y = y;
		this.hOne = -1;
		this.wOne = -1;
		this.maxHp = maxHP;
		this.Lv = (short)lv;
		this.typemove = this.getTypemove();
		this.Action = 0;
		this.MonWater = 0;
		this.numW = 3;
		this.numH = 5;
		this.nFrame = (int)this.numW * (int)this.numH;
		this.timeLoadInfo = mSystem.currentTimeMillis();
	}

	// Token: 0x06000484 RID: 1156 RVA: 0x0003F630 File Offset: 0x0003D830
	public override bool isMiNuong()
	{
		return true;
	}

	// Token: 0x06000485 RID: 1157 RVA: 0x0003F634 File Offset: 0x0003D834
	public override void setspeedVantieu(int vmax)
	{
		this.vMax = vmax;
		this.Maxspeed = (sbyte)vmax;
		this.vTam = (sbyte)(vmax + 1);
	}

	// Token: 0x06000486 RID: 1158 RVA: 0x0003F650 File Offset: 0x0003D850
	public new string getnameOwner()
	{
		return this.nameowner;
	}

	// Token: 0x06000487 RID: 1159 RVA: 0x0003F658 File Offset: 0x0003D858
	protected sbyte getTypemove()
	{
		return 2;
	}

	// Token: 0x06000488 RID: 1160 RVA: 0x0003F65C File Offset: 0x0003D85C
	public override void paint(mGraphics g)
	{
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
		if (imagePartMonster != null && !this.isDongBang && imagePartMonster.img != null)
		{
			if (this.Direction == 3)
			{
				this.xwater = 2;
			}
			else if (this.Direction == 2)
			{
				this.xwater = -2;
			}
			else
			{
				this.xwater = 0;
			}
			if (this.wOne < 0)
			{
				this.wOne = mImage.getImageWidth(imagePartMonster.img.image) / (int)this.numW;
				this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / (int)this.numH;
				this.yEffAuto = this.hOne / 2;
			}
			if ((int)this.frameMount >= 0 && (int)this.frameMount < this.nFrame)
			{
				int x = (int)this.frameMount / (int)this.numH * this.wOne;
				int y = (int)this.frameMount % (int)this.numH * this.hOne;
				if (this.isWater)
				{
					g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.ysai - this.dy + this.dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isTrue);
					g.drawRegion(MainObject.water, 0, ((this.Action == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + (int)this.xwater, this.y + this.dyWater - 8, 3, mGraphics.isFalse);
				}
				else
				{
					MainObject.paintShadow(g, this.Direction, this.x + (int)this.xwater, this.y - this.ysai + (int)this.dysai[(int)this.typemove]);
					g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.ysai - this.dy + this.dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isTrue);
				}
			}
		}
		mFont.tahoma_7_white.drawString(g, (!this.nameowner.Equals(string.Empty)) ? this.nameowner : this.name, this.x, this.y - this.hOne - 8 - ((!this.isDongBang) ? 0 : 5), 2, mGraphics.isFalse);
		base.paint(g);
	}

	// Token: 0x06000489 RID: 1161 RVA: 0x0003F930 File Offset: 0x0003DB30
	public void updateMonsterAction()
	{
		this.fMount += 1;
		if (this.Action == 0)
		{
			if ((int)this.fMount > this.FRAMESTAND[this.Direction].Length - 1)
			{
				this.fMount = 0;
			}
			this.frameMount = this.FRAMESTAND[this.Direction][(int)this.fMount];
		}
		else if (this.Action == 1)
		{
			if ((int)this.fMount > this.FRAMEMOVE[(int)this.typemove][this.Direction].Length - 1)
			{
				this.fMount = 0;
			}
			this.frameMount = this.FRAMEMOVE[(int)this.typemove][this.Direction][(int)this.fMount];
		}
	}

	// Token: 0x0600048A RID: 1162 RVA: 0x0003F9F8 File Offset: 0x0003DBF8
	public override void update()
	{
		base.update();
		this.updateMonsterAction();
		int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
		base.setMove(this.MonWater, tile);
		if (!base.Canmove() || this.isBinded)
		{
			return;
		}
		if (!this.isInfo)
		{
			long num = mSystem.currentTimeMillis();
			long num2 = num - this.timeLoadInfo;
			if (num2 >= 5000L)
			{
				this.timeLoadInfo = num;
				GlobalService.gI().monster_info((short)this.ID);
			}
		}
		if (this.vx == 0 && this.vy == 0)
		{
			this.Action = 0;
		}
		if (MainObject.getDistance(this.x, this.y, this.toX, this.toY) >= LoadMap.wTile * 3 && MainObject.getDistance(this.x, this.y, this.toX, this.toY) <= LoadMap.wTile * 4)
		{
			this.Maxspeed = this.vTam;
		}
		if (MainObject.getDistance(this.x, this.y, this.toX, this.toY) < LoadMap.wTile * 3)
		{
			this.vMax = (int)((byte)((int)this.vTam - 1));
		}
		if ((int)this.Maxspeed > 1)
		{
			if ((int)this.frameMount == 3 || (int)this.frameMount == 8 || (int)this.frameMount == 13)
			{
				this.vMax = (int)this.Maxspeed - 1;
			}
			else
			{
				this.vMax = (int)this.Maxspeed;
			}
		}
	}

	// Token: 0x0600048B RID: 1163 RVA: 0x0003FBA4 File Offset: 0x0003DDA4
	public override void SetnameOwner(string name)
	{
		this.nameowner = name;
	}

	// Token: 0x04000681 RID: 1665
	public sbyte Maxspeed;

	// Token: 0x04000682 RID: 1666
	private sbyte typemove;

	// Token: 0x04000683 RID: 1667
	public sbyte[][][] FRAMEMOVE = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				7,
				7,
				7,
				8,
				8,
				8,
				9,
				9,
				9,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				12,
				12,
				12,
				13,
				13,
				13,
				14,
				14,
				14,
				11,
				11,
				11,
				11
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				7,
				7,
				7,
				7,
				8,
				8,
				8,
				8,
				9,
				9,
				9,
				9,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				12,
				12,
				12,
				12,
				13,
				13,
				13,
				13,
				14,
				14,
				14,
				14,
				11,
				11,
				11,
				11
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				7,
				7,
				7,
				7,
				8,
				8,
				8,
				8,
				9,
				9,
				9,
				9,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				12,
				12,
				12,
				12,
				13,
				13,
				13,
				13,
				14,
				14,
				14,
				14,
				11,
				11,
				11,
				11
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3,
				4,
				4,
				4,
				4,
				1,
				1,
				1,
				1
			}
		}
	};

	// Token: 0x04000684 RID: 1668
	public sbyte[][] FRAMESTAND = new sbyte[][]
	{
		new sbyte[]
		{
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			6,
			6,
			6,
			6,
			6,
			6,
			6,
			6,
			6,
			6
		},
		new sbyte[]
		{
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11,
			11
		},
		new sbyte[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		}
	};

	// Token: 0x04000685 RID: 1669
	public sbyte[] dysai = new sbyte[]
	{
		-11,
		-7,
		-7
	};

	// Token: 0x04000686 RID: 1670
	private sbyte numW;

	// Token: 0x04000687 RID: 1671
	private sbyte numH;

	// Token: 0x04000688 RID: 1672
	private sbyte vTam;

	// Token: 0x04000689 RID: 1673
	private sbyte xwater;
}
