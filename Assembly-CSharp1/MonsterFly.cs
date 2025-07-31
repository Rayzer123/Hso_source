using System;

// Token: 0x0200005D RID: 93
public class MonsterFly : MainMonster
{
	// Token: 0x06000495 RID: 1173 RVA: 0x0003FD5C File Offset: 0x0003DF5C
	public MonsterFly(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		this.coutEff = 0;
		this.typeMonster = typeMonster;
		this.typeObject = 1;
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
		this.Direction = 0;
		this.MonWater = 0;
		this.wOne = (this.hOne = -1);
		this.nFrame = 5;
		this.vMax = 3;
		this.limitMove = 70;
		this.xsai = 0;
		this.ysai = -2;
		this.timeAutoAction = CRes.random(60, 85);
		this.limitAttack = 50;
		switch (typeMonster)
		{
		case 3:
			this.mAction = MonsterFly.mMonFly_012;
			goto IL_143;
		default:
			if (typeMonster != 19)
			{
				goto IL_143;
			}
			break;
		case 5:
			break;
		case 8:
			this.mAction = MonsterFly.mMonFly_012;
			this.limitAttack = 80;
			goto IL_143;
		case 10:
			this.mAction = MonsterFly.mMonFly_012_slow;
			goto IL_143;
		}
		this.mAction = MonsterFly.mMonFly_0102;
		IL_143:
		this.timeLoadInfo = mSystem.currentTimeMillis();
	}

	// Token: 0x06000497 RID: 1175 RVA: 0x000402F4 File Offset: 0x0003E4F4
	public override void paint(mGraphics g)
	{
		if (!this.isDie)
		{
			if ((int)this.typeBoss == 2 && MainObject.imgCapchar != null)
			{
				AvMain.Font3dWhite(g, MainObject.strCapchar, this.x, this.y - this.dy - this.ydieFly - this.hOne - 20 - 30, 2);
				g.drawImage(MainObject.imgCapchar, this.x, this.y - this.dy - this.vyStyleDie - this.hOne - 20, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			}
			base.paintDataEff_Top(g, this.x, this.y);
			base.paintBuffFirst(g);
			base.paintEffauto_Low(g, this.x, this.y);
			MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
			int num = this.Action;
			if (num > this.mAction.Length - 1)
			{
				num = 0;
			}
			if (this.f > this.mAction[num][(this.Direction <= 2) ? this.Direction : 2].Length - 1)
			{
				this.f = 0;
			}
			g.drawImage(MainObject.shadow, this.x, this.y - this.dy - this.ydieFly, 3, mGraphics.isFalse);
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
				int y = (int)this.mAction[num][(this.Direction <= 2) ? this.Direction : 2][this.f] * this.hOne;
				if (this.catalogyMonster > 92)
				{
					x = (int)this.mAction[num][(this.Direction <= 2) ? this.Direction : 2][this.f] / 3 * this.wOne;
					y = (int)this.mAction[num][(this.Direction <= 2) ? this.Direction : 2][this.f] % 3 * this.hOne;
				}
				g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - 8 - this.dy - this.vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				this.canFocusMon = true;
			}
			else
			{
				this.canFocusMon = false;
			}
			base.paintDataEff_Bot(g, this.x, this.y);
			base.paintBuffLast(g);
			base.paintIconClan(g, this.x - 1, this.y - this.ysai - this.dy + this.dyWater - this.hOne - 20, 2);
			base.paint(g);
		}
	}

	// Token: 0x06000498 RID: 1176 RVA: 0x00040640 File Offset: 0x0003E840
	public override void update()
	{
		base.update();
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
		base.updateDataEffect();
		base.updateDataEffect();
		base.setDie();
		if (this.Action == 4)
		{
			this.ydieFly += 3;
			if (this.ydieFly > 11)
			{
				this.ydieFly = 11;
			}
		}
		else
		{
			this.ydieFly = 0;
		}
		if (!base.Canmove() || this.isBinded)
		{
			return;
		}
		this.updateAction();
		if (this.Action != 4)
		{
			if (this.Action != 3 && this.Action != 2)
			{
				if (this.isRunAttack && !this.isMonPhoBangDie)
				{
					if (this.timeFreeFire > 0)
					{
						if (!this.isServerControl)
						{
							base.autoMoveFire();
						}
					}
					else if (!base.canNotMove())
					{
						this.Move_to_Focus();
					}
				}
				else if (!this.isServerControl)
				{
					base.auto_Move();
				}
			}
		}
		int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
		if (!this.isServerControl)
		{
			base.setMove(this.MonWater, tile);
		}
		if ((int)this.typeBoss == 2)
		{
			this.updateImgCapchar();
			if (this.timeRemoveGhost > 0)
			{
				this.timeRemoveGhost--;
				if (this.timeRemoveGhost == 0)
				{
					this.Action = 4;
					this.hp = 0;
					GameScreen.addEffectEndKill(11, this.x, this.y);
				}
			}
		}
	}

	// Token: 0x06000499 RID: 1177 RVA: 0x0004081C File Offset: 0x0003EA1C
	public void updateImgCapchar()
	{
		if (MainObject.imgCapchar == null)
		{
			if (this.timeCapchar > 0)
			{
				this.timeCapchar--;
			}
			if (this.timeCapchar <= 0)
			{
				mSystem.outz("lay hinh capchar");
				GlobalService.gI().load_image(9999);
				this.timeCapchar = 120;
			}
		}
	}

	// Token: 0x0400068A RID: 1674
	private mImage img;

	// Token: 0x0400068B RID: 1675
	private int ydieFly;

	// Token: 0x0400068C RID: 1676
	private static sbyte[][][] mMonFly_012 = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			}
		}
	};

	// Token: 0x0400068D RID: 1677
	private static sbyte[][][] mMonFly_0102 = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2,
				0,
				0
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1,
				0,
				0
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2,
				0,
				0
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1,
				0,
				0
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3
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
				3
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
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			}
		}
	};

	// Token: 0x0400068E RID: 1678
	private static sbyte[][][] mMonFly_012_slow = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				1,
				1,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				0,
				0,
				2,
				2
			},
			new sbyte[]
			{
				2,
				2,
				0,
				0,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				4,
				4
			}
		}
	};
}
