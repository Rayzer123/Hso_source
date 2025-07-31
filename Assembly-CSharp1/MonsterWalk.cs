using System;
using UnityEngine;

// Token: 0x0200005F RID: 95
public class MonsterWalk : MainMonster
{
	// Token: 0x0600049F RID: 1183 RVA: 0x00040DDC File Offset: 0x0003EFDC
	public MonsterWalk(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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
		this.nFrame = 5;
		this.wOne = (this.hOne = -1);
		this.vMax = 3;
		this.limitMove = 60;
		this.timeAutoAction = CRes.random(50, 70);
		this.limitAttack = 50;
		this.xsai = 0;
		this.ysai = -2;
		switch (typeMonster)
		{
		case 0:
			if (!this.isMoveSlow(this.catalogyMonster))
			{
				this.mAction = MonsterWalk.mMon012;
			}
			else
			{
				this.mAction = MonsterWalk.mMonBossMesdusa;
			}
			break;
		case 1:
			this.mAction = MonsterWalk.mMon01;
			break;
		case 2:
			this.mAction = MonsterWalk.mMon0102;
			break;
		case 4:
			this.MonWater = 0;
			this.mAction = MonsterWalk.mMon012;
			break;
		case 6:
			this.limitAttack = 80;
			this.mAction = MonsterWalk.mMon012;
			break;
		case 9:
			this.MonWater = 0;
			this.mAction = MonsterWalk.mMon012;
			this.limitAttack = 80;
			break;
		case 12:
		case 16:
		case 18:
			this.mAction = new sbyte[][][]
			{
				new sbyte[][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				},
				new sbyte[][]
				{
					new sbyte[6],
					new sbyte[6],
					new sbyte[6]
				}
			};
			this.nFrame = 1;
			break;
		case 17:
			this.mAction = MonsterWalk.mMonschiemthanh;
			break;
		}
		this.timeLoadInfo = mSystem.currentTimeMillis();
	}

	// Token: 0x060004A0 RID: 1184 RVA: 0x00041088 File Offset: 0x0003F288
	// Note: this type is marked as 'beforefieldinit'.
	static MonsterWalk()
	{
		sbyte[][][] array = new sbyte[5][][];
		array[0] = new sbyte[][]
		{
			new sbyte[6],
			new sbyte[6],
			new sbyte[6]
		};
		int num = 1;
		sbyte[][] array2 = new sbyte[3][];
		int num2 = 0;
		sbyte[] array3 = new sbyte[6];
		array3[0] = 1;
		array3[1] = 1;
		array3[2] = 1;
		array2[num2] = array3;
		int num3 = 1;
		sbyte[] array4 = new sbyte[6];
		array4[0] = 1;
		array4[1] = 1;
		array4[2] = 1;
		array2[num3] = array4;
		int num4 = 2;
		sbyte[] array5 = new sbyte[6];
		array5[0] = 1;
		array5[1] = 1;
		array5[2] = 1;
		array2[num4] = array5;
		array[num] = array2;
		array[2] = new sbyte[][]
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
		};
		array[3] = new sbyte[][]
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
		};
		array[4] = new sbyte[][]
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
		};
		MonsterWalk.mMon01 = array;
		MonsterWalk.mMonBossMesdusa = new sbyte[][][]
		{
			new sbyte[][]
			{
				new sbyte[12],
				new sbyte[12],
				new sbyte[12]
			},
			new sbyte[][]
			{
				new sbyte[]
				{
					0,
					0,
					0,
					0,
					1,
					1,
					1,
					1,
					2,
					2,
					2,
					2
				},
				new sbyte[]
				{
					1,
					1,
					1,
					1,
					0,
					0,
					0,
					0,
					2,
					2,
					2,
					2
				},
				new sbyte[]
				{
					2,
					2,
					2,
					2,
					0,
					0,
					0,
					0,
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
					2,
					2,
					2,
					2,
					2,
					2,
					3,
					3,
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
					2,
					2,
					3,
					3,
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
					2,
					2,
					3,
					3,
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
					4,
					4,
					4,
					4,
					4
				}
			}
		};
		MonsterWalk.mMonschiemthanh = new sbyte[][][]
		{
			new sbyte[][]
			{
				new sbyte[]
				{
					4,
					4,
					4,
					4,
					5,
					5,
					5,
					5,
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
					5,
					5,
					5,
					5,
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
					5,
					5,
					5,
					5,
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
					0,
					0,
					0,
					1,
					1,
					1,
					2,
					2,
					2,
					3,
					3,
					3
				},
				new sbyte[]
				{
					0,
					0,
					0,
					1,
					1,
					1,
					2,
					2,
					2,
					3,
					3,
					3
				},
				new sbyte[]
				{
					0,
					0,
					0,
					1,
					1,
					1,
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
					5,
					5,
					5,
					5,
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
					5,
					5,
					5,
					5,
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
					5,
					5,
					5,
					5,
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
					4,
					4,
					4,
					4,
					4
				}
			}
		};
	}

	// Token: 0x060004A1 RID: 1185 RVA: 0x00041728 File Offset: 0x0003F928
	public override bool isMonsterHouse()
	{
		return this.typeMonster == 12;
	}

	// Token: 0x060004A2 RID: 1186 RVA: 0x00041734 File Offset: 0x0003F934
	public bool isMonsterGate()
	{
		return this.typeMonster == 16;
	}

	// Token: 0x060004A3 RID: 1187 RVA: 0x00041740 File Offset: 0x0003F940
	public override bool isItemBox()
	{
		return this.typeMonster == 13;
	}

	// Token: 0x060004A4 RID: 1188 RVA: 0x0004174C File Offset: 0x0003F94C
	public override void paint(mGraphics g)
	{
		try
		{
			if ((int)this.StepMovebocap != 1 || this.catalogyMonster != 103)
			{
				if (this.typeMonster != 18)
				{
					if (!this.isDie)
					{
						base.paintBuffFirst(g);
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
						if (imagePartMonster.img != null)
						{
							if (this.wOne < 0)
							{
								if (this.catalogyMonster <= 92 || this.typeMonster == 16)
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
							base.paintDataEff_Top(g, this.x, this.y);
							base.paintEffauto_Low(g, this.x, this.y);
							if (this.isMonsterHouse())
							{
								this.Direction = 0;
								g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.dy + this.dyWater - this.vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
							}
							else
							{
								g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.dy + this.dyWater - this.vyStyleDie, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
							}
							if (this.isWater && this.dy == 0)
							{
								int num2 = 1;
								g.drawRegion(MainObject.water, 0, ((num == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + num2, this.y + this.dyWater - 4, 3, mGraphics.isFalse);
							}
							this.canFocusMon = true;
						}
						else
						{
							this.canFocusMon = false;
						}
						base.paintIconClan(g, this.x - 1, this.y - this.ysai - this.dy + this.dyWater - this.hOne - 20, 2);
						base.paintBuffLast(g);
						base.paintDataEff_Bot(g, this.x, this.y);
						base.paint(g);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Debug.LogWarning("loi ham paint monster " + ex.ToString());
		}
	}

	// Token: 0x060004A5 RID: 1189 RVA: 0x00041B40 File Offset: 0x0003FD40
	public void checkcollide()
	{
		if (!base.isBossNew() || (GameScreen.player.vx == 0 && GameScreen.player.vy == 0) || GameScreen.player.moveToBoss)
		{
			GameScreen.player.moveToBoss = false;
			return;
		}
		if (CRes.ktvc(this.x - this.wOne / 3, this.x + this.wOne / 3, GameScreen.player.x - GameScreen.player.wOne / 3, GameScreen.player.x + GameScreen.player.wOne / 3, this.y - this.hOne, this.y - this.hOne / 3, GameScreen.player.y - GameScreen.player.hOne, GameScreen.player.y - GameScreen.player.hOne / 3))
		{
			if (GameScreen.player.Action == 1 && !GameScreen.player.moveToBoss)
			{
				GameScreen.player.moveToBoss = true;
			}
		}
		else
		{
			GameScreen.player.moveToBoss = false;
		}
	}

	// Token: 0x060004A6 RID: 1190 RVA: 0x00041C6C File Offset: 0x0003FE6C
	public override void Move_to_Focus()
	{
		if (this.isMove && this.catalogyMonster == 103)
		{
			return;
		}
		if ((int)this.typeBoss == 5)
		{
			return;
		}
		if (this.isBinded || this.isDongBang)
		{
			return;
		}
		if (!this.isServerControl)
		{
			if (this.vecObjskill != null && this.vecObjskill.size() > 0 && !this.isServerControl)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
				if (GameCanvas.timeNow - this.timeBeginMoveAttack > (long)this.timeMaxMoveAttack)
				{
					this.IDAttack = (int)object_Effect_Skill.ID;
					object_Effect_Skill.skillMonster = this.skillDefault;
					this.beginFire();
					base.beginSkill();
				}
				else
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					if (mainObject == null)
					{
						this.isRunAttack = false;
						return;
					}
					if (mainObject.Action != 4)
					{
						this.toX = mainObject.x;
						this.toY = mainObject.y;
						int range = object_Effect_Skill.skillMonster.range;
						if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) <= range)
						{
							this.IDAttack = (int)object_Effect_Skill.ID;
							this.beginFire();
							base.beginSkill();
						}
						else if (CRes.abs(this.x - this.toX) >= 4 || CRes.abs(this.y - this.toY) >= 4)
						{
							this.move_to_XY_Normal();
						}
					}
					else
					{
						this.move_to_XY_Normal();
					}
				}
			}
			else
			{
				MainObject mainObject2 = MainObject.get_Object(this.IDAttack, 0);
				if (mainObject2 == null)
				{
					this.isRunAttack = false;
					return;
				}
				if (mainObject2.Action != 4)
				{
					this.toX = mainObject2.x;
					this.toY = mainObject2.y;
					if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject2.x, mainObject2.y) <= this.limitAttack)
					{
						this.vx = 0;
						this.vy = 0;
						this.Action = 0;
						this.toX = this.x;
						this.toY = this.y;
						if (CRes.random(30) == 0)
						{
							this.timeFreeFire = 20;
						}
						if (this.x > mainObject2.x)
						{
							this.Direction = 2;
						}
						else
						{
							this.Direction = 3;
						}
					}
					else if (CRes.abs(this.x - this.toX) >= 4 || CRes.abs(this.y - this.toY) >= 4)
					{
						this.move_to_XY_Normal();
					}
				}
			}
			return;
		}
		MainObject mainObject3 = MainObject.get_Object(this.IDAttack, 0);
		if (mainObject3 == null)
		{
			this.isRunAttack = false;
			return;
		}
		if (mainObject3.Action != 4)
		{
			this.toX = mainObject3.x;
			this.toY = mainObject3.y;
			this.vx = 0;
			this.vy = 0;
			this.Action = 0;
			this.toX = this.x;
			this.toY = this.y;
			if (CRes.random(30) == 0)
			{
				this.timeFreeFire = 20;
			}
			if (this.x > mainObject3.x)
			{
				this.Direction = 2;
			}
			else
			{
				this.Direction = 3;
			}
		}
	}

	// Token: 0x060004A7 RID: 1191 RVA: 0x00041FE4 File Offset: 0x000401E4
	public override void move_to_XY()
	{
		if (!base.Canmove() || this.isBinded)
		{
			this.toX = this.x;
			this.toY = this.y;
			return;
		}
		if (this.isMoveOut)
		{
			return;
		}
		if (CRes.abs(this.x - this.toX) > this.vMax + base.getVmount())
		{
			this.vy = 0;
			this.Action = 1;
			if (CRes.abs(this.x - this.toX) > this.vMax + base.getVmount())
			{
				if (this.x > this.toX)
				{
					this.vx = -(this.vMax + base.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 2;
				}
				else
				{
					this.vx = this.vMax + base.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 3;
				}
			}
			else
			{
				this.vx = this.toX - this.x;
			}
		}
		else if (CRes.abs(this.y - this.toY) > this.vMax + base.getVmount())
		{
			this.vx = 0;
			this.Action = 1;
			if (CRes.abs(this.y - this.toY) > this.vMax + base.getVmount())
			{
				if (this.y > this.toY)
				{
					this.vy = -(this.vMax + base.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 1;
				}
				else
				{
					this.vy = this.vMax + base.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 0;
				}
			}
			else
			{
				this.vy = this.toY - this.y;
			}
		}
		else
		{
			if (this.isDetonateInDest)
			{
				GameScreen.addEffectEndKill(43, this.x, this.y);
				LoadMap.timeVibrateScreen = 10;
				this.isStop = true;
			}
			this.vx = 0;
			this.vy = 0;
			if (this.catalogyMonster == 103 && (int)this.StepMovebocap == 0)
			{
				GameScreen.addEffectEndKill(54, this.x, this.y - 20);
				this.StepMovebocap = 1;
			}
		}
	}

	// Token: 0x060004A8 RID: 1192 RVA: 0x00042248 File Offset: 0x00040448
	public override void update()
	{
		base.update();
		base.updateDataEffect();
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
		base.setDie();
		if (!base.Canmove())
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
						if (!this.isServerControl && (!this.isMonsterHouse() || !this.isItemBox() || !this.isMonsterGate()))
						{
							base.autoMoveFire();
						}
					}
					else if (!this.isMonsterHouse() && !this.isItemBox() && !base.canNotMove() && !this.isMonsterGate())
					{
						this.Move_to_Focus();
					}
				}
				else if (!this.isServerControl && !this.isMonsterHouse() && !this.isItemBox() && !base.canNotMove() && !this.isMonsterGate())
				{
					base.auto_Move();
				}
			}
		}
		int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
		if (!this.isServerControl && !this.isMonsterHouse() && !this.isItemBox() && !base.canNotMove())
		{
			base.setMove(this.MonWater, tile);
		}
	}

	// Token: 0x060004A9 RID: 1193 RVA: 0x0004240C File Offset: 0x0004060C
	public bool isMoveSlow(int catalogyMonster)
	{
		return catalogyMonster == 101 || catalogyMonster == 83 || catalogyMonster == 84;
	}

	// Token: 0x04000695 RID: 1685
	private static sbyte[][][] mMon0102 = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[8],
			new sbyte[8],
			new sbyte[8]
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

	// Token: 0x04000696 RID: 1686
	private static sbyte[][][] mMon012 = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[6],
			new sbyte[6],
			new sbyte[6]
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

	// Token: 0x04000697 RID: 1687
	private static sbyte[][][] mMon01;

	// Token: 0x04000698 RID: 1688
	private static sbyte[][][] mMonBossMesdusa;

	// Token: 0x04000699 RID: 1689
	private static sbyte[][][] mMonschiemthanh;
}
