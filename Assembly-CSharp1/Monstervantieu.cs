using System;

// Token: 0x02000061 RID: 97
public class Monstervantieu : MainMonster
{
	// Token: 0x060004B7 RID: 1207 RVA: 0x000429EC File Offset: 0x00040BEC
	public Monstervantieu(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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

	// Token: 0x060004B8 RID: 1208 RVA: 0x00042C38 File Offset: 0x00040E38
	public override bool isMonsterVantieuTrang()
	{
		return this.catalogyMonster == 129 || this.catalogyMonster == 131 || this.catalogyMonster == 127 || this.catalogyMonster == 177;
	}

	// Token: 0x060004B9 RID: 1209 RVA: 0x00042C78 File Offset: 0x00040E78
	public override bool isMonsterVantieuDen()
	{
		return this.catalogyMonster == 128 || this.catalogyMonster == 130 || this.catalogyMonster == 132 || this.catalogyMonster == 176;
	}

	// Token: 0x060004BA RID: 1210 RVA: 0x00042CC8 File Offset: 0x00040EC8
	public override bool isMonstervantieu()
	{
		return true;
	}

	// Token: 0x060004BB RID: 1211 RVA: 0x00042CCC File Offset: 0x00040ECC
	public override void setspeedVantieu(int vmax)
	{
		this.vMax = vmax;
		this.Maxspeed = (sbyte)vmax;
		this.vTam = (sbyte)(vmax + 1);
	}

	// Token: 0x060004BC RID: 1212 RVA: 0x00042CE8 File Offset: 0x00040EE8
	public override string getnameOwner()
	{
		return this.nameowner;
	}

	// Token: 0x060004BD RID: 1213 RVA: 0x00042CF0 File Offset: 0x00040EF0
	protected sbyte getTypemove()
	{
		int catalogyMonster = this.catalogyMonster;
		switch (catalogyMonster)
		{
		case 127:
		case 128:
			return 0;
		case 129:
		case 130:
			return 1;
		case 131:
		case 132:
			break;
		default:
			if (catalogyMonster != 176 && catalogyMonster != 177)
			{
				return 0;
			}
			break;
		}
		return 2;
	}

	// Token: 0x060004BE RID: 1214 RVA: 0x00042D48 File Offset: 0x00040F48
	public override void paint(mGraphics g)
	{
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
		if (imagePartMonster != null && !this.isDongBang && imagePartMonster.img != null)
		{
			if (this.Direction == 3)
			{
				this.xwater = -2;
			}
			else if (this.Direction == 2)
			{
				this.xwater = 2;
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
			base.paintDataEff_Top(g, this.x, this.y);
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
		base.paintDataEff_Bot(g, this.x, this.y);
		mFont.tahoma_7_white.drawString(g, this.nameowner, this.x, this.y - this.hOne - 3 - ((!this.isDongBang) ? 0 : 5), 2, mGraphics.isFalse);
		base.paint(g);
	}

	// Token: 0x060004BF RID: 1215 RVA: 0x00043024 File Offset: 0x00041224
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

	// Token: 0x060004C0 RID: 1216 RVA: 0x000430EC File Offset: 0x000412EC
	public override void update()
	{
		base.update();
		this.updateMonsterAction();
		base.updateDataEffect();
		base.updateDataEffect();
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

	// Token: 0x040006A1 RID: 1697
	public const int ID_TEMPLATE_LUA_TRANG = 127;

	// Token: 0x040006A2 RID: 1698
	public const int ID_TEMPLATE_LUA_DEN = 128;

	// Token: 0x040006A3 RID: 1699
	public const int ID_TEMPLATE_LAC_DA_TRANG = 129;

	// Token: 0x040006A4 RID: 1700
	public const int ID_TEMPLATE_LAC_DA_DEN = 130;

	// Token: 0x040006A5 RID: 1701
	public const int ID_TEMPLATE_BO_TRANG = 131;

	// Token: 0x040006A6 RID: 1702
	public const int ID_TEMPLATE_BO_DEN = 132;

	// Token: 0x040006A7 RID: 1703
	public const int ID_TEMPLATE_VOI_TRANG = 177;

	// Token: 0x040006A8 RID: 1704
	public const int ID_TEMPLATE_VOI_DEN = 176;

	// Token: 0x040006A9 RID: 1705
	public sbyte Maxspeed;

	// Token: 0x040006AA RID: 1706
	private sbyte typemove;

	// Token: 0x040006AB RID: 1707
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

	// Token: 0x040006AC RID: 1708
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

	// Token: 0x040006AD RID: 1709
	public sbyte[] dysai = new sbyte[]
	{
		-11,
		-7,
		-7
	};

	// Token: 0x040006AE RID: 1710
	private sbyte numW;

	// Token: 0x040006AF RID: 1711
	private sbyte numH;

	// Token: 0x040006B0 RID: 1712
	private sbyte vTam;

	// Token: 0x040006B1 RID: 1713
	private sbyte xwater;
}
