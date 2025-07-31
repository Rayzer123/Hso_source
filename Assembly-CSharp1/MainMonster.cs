using System;

// Token: 0x02000054 RID: 84
public class MainMonster : MainObject
{
	// Token: 0x060003B3 RID: 947 RVA: 0x00033AD0 File Offset: 0x00031CD0
	public virtual void setIDeffect(sbyte id)
	{
	}

	// Token: 0x060003B4 RID: 948 RVA: 0x00033AD4 File Offset: 0x00031CD4
	public virtual void setLvmonster(int lv)
	{
	}

	// Token: 0x060003B5 RID: 949 RVA: 0x00033AD8 File Offset: 0x00031CD8
	public virtual void setPaintCicle(bool b)
	{
	}

	// Token: 0x060003B6 RID: 950 RVA: 0x00033ADC File Offset: 0x00031CDC
	public bool isBossNew()
	{
		for (int i = 0; i < MainMonster.idBossNew.Length; i++)
		{
			if (this.catalogyMonster == (int)MainMonster.idBossNew[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060003B7 RID: 951 RVA: 0x00033B18 File Offset: 0x00031D18
	public virtual void setTimelive(long time)
	{
	}

	// Token: 0x060003B8 RID: 952 RVA: 0x00033B1C File Offset: 0x00031D1C
	public static void createMonster(int ID, int x, int y, int typeMonster)
	{
		CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster(typeMonster);
		switch (catalogyMonster.typeMove)
		{
		case 0:
		case 1:
		case 2:
		case 4:
		case 6:
		case 9:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 3:
		case 5:
		case 8:
		case 10:
			GameScreen.addPlayer(new MonsterFly(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 7:
			GameScreen.addPlayer(new MonsterQuest(ID, catalogyMonster.id, catalogyMonster.typeMove, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 12:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 12, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 13:
			if (catalogyMonster.id == 110)
			{
				GameScreen.addPlayer(new Monsterplus(ID, catalogyMonster.id, 13, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			}
			else
			{
				GameScreen.addPlayer(new MonsterBox(ID, catalogyMonster.id, 13, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			}
			return;
		case 14:
			GameScreen.addPlayer(new Monstervantieu(ID, catalogyMonster.id, 14, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 15:
			Cout.println("tao mi nuong");
			GameScreen.addPlayer(new Minuong(ID, catalogyMonster.id, 14, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 16:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 16, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 17:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 17, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 18:
			GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 18, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		case 19:
			GameScreen.addPlayer(new MonsterFly(ID, catalogyMonster.id, 19, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
			return;
		}
		GameScreen.addPlayer(new MonsterWalk(ID, catalogyMonster.id, 0, catalogyMonster.name, x, y, catalogyMonster.maxHp, catalogyMonster.lv));
	}

	// Token: 0x060003B9 RID: 953 RVA: 0x00033DF0 File Offset: 0x00031FF0
	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
		if (imagePartMonster.img != null)
		{
			if (this.wAvatar <= 0)
			{
				if (this.wOne < 0)
				{
					this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imagePartMonster.img.image);
				}
				this.wAvatar = this.wOne;
				this.hAvatar = this.hOne;
				if (this.wAvatar > 26)
				{
					this.wAvatar = 26;
				}
				if (this.hAvatar > 26)
				{
					this.hAvatar = 26;
				}
			}
			g.drawRegion(imagePartMonster.img, this.wOne / 2 - this.wAvatar / 2, 0, this.wAvatar, this.hAvatar, 0, x, y, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060003BA RID: 954 RVA: 0x00033ED8 File Offset: 0x000320D8
	public override void update()
	{
		if (this.isDie && this.Action != 4)
		{
			this.Action = 4;
			this.timedie = GameCanvas.timeNow;
		}
		if (this.isServerControl && this.isMove)
		{
			this.move_to_XY();
		}
		base.update();
	}

	// Token: 0x060003BB RID: 955 RVA: 0x00033F30 File Offset: 0x00032130
	public override void paint(mGraphics g)
	{
		base.paintEffauto(g, this.x, this.y);
		base.paintEffauto(g, this.x, this.y);
	}

	// Token: 0x060003BC RID: 956 RVA: 0x00033F64 File Offset: 0x00032164
	public virtual void updateAction()
	{
		if (this.isMoveOut)
		{
			return;
		}
		this.f++;
		if (this.f > this.mAction[this.Action][(this.Direction <= 2) ? this.Direction : 2].Length - 1)
		{
			this.f = 0;
			if (this.Action == 3)
			{
				this.Action = 0;
				this.vx = 0;
				this.vy = 0;
			}
			if (this.Action == 2)
			{
				if (!this.isBossNew())
				{
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
				}
				else
				{
					if ((int)this.loopAtack >= 0)
					{
						this.loopAtack -= 1;
					}
					if ((int)this.loopAtack <= 0)
					{
						this.Action = 0;
						this.vx = 0;
						this.vy = 0;
					}
				}
			}
		}
		if (this.Action == 1 && this.vx == 0 && this.vy == 0)
		{
			this.Action = 0;
			this.f = 0;
		}
		if (this.timeFreeFire > 0)
		{
			this.timeFreeFire--;
		}
		if ((this.isDie || this.Action == 4) && ((int)this.typeBoss == 3 || (int)this.typeBoss == 4))
		{
			this.timeRemove++;
			if (this.timeRemove > 600)
			{
				this.isRemove = true;
			}
		}
	}

	// Token: 0x060003BD RID: 957 RVA: 0x000340F8 File Offset: 0x000322F8
	public static CatalogyMonster getCatalogyMonster(int id)
	{
		for (int i = 0; i < MainMonster.VecCatalogyMonSter.size(); i++)
		{
			CatalogyMonster catalogyMonster = (CatalogyMonster)MainMonster.VecCatalogyMonSter.elementAt(i);
			if (catalogyMonster.id == id)
			{
				return catalogyMonster;
			}
		}
		return null;
	}

	// Token: 0x060003BE RID: 958 RVA: 0x00034140 File Offset: 0x00032340
	public void auto_Move()
	{
		if ((int)this.typeBoss == 5)
		{
			return;
		}
		if (this.isMonsterHouse() || this.isItemBox())
		{
			return;
		}
		if (this.isStun || this.isBinded || this.isDongBang || this.isSleep || this.isno || this.isMoveOut)
		{
			return;
		}
		if ((int)this.typeBoss == 3 || (int)this.typeBoss == 4)
		{
			this.toX = this.xPhoBang;
			this.toY = this.yPhoBang;
			this.move_to_XY();
			if (MainObject.getDistance(this.x, this.y, this.toX, this.toY) <= LoadMap.wTile / 2 && this.isMonPhoBangDie)
			{
				if ((int)this.typeBoss == 3)
				{
					GameScreen.addEffectEndKill(36, this.x, this.y - this.hOne / 2);
					LoadMap.timeVibrateScreen = 103;
				}
				else if ((int)this.typeBoss == 4)
				{
					for (int i = 0; i < 3; i++)
					{
						int num = this.hOne;
						int num2 = this.wOne;
						if (this.hOne <= 1)
						{
							num = 40;
						}
						if (num2 <= 1)
						{
							num2 = 40;
						}
						GameScreen.addEffectEndKill(36, this.x + CRes.random_Am_0(num2 / 2), this.y - this.hOne / 2 + CRes.random_Am_0(num / 2));
					}
					LoadMap.timeVibrateScreen = 110;
				}
				this.isRemove = true;
				this.isMonPhoBangDie = false;
			}
		}
		else if (MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) > this.limitMove + this.limitMove / 2)
		{
			if (!MainObject.isInScreen(this) && !base.setIsInScreen(this.xAnchor, this.yAnchor, this.wOne, this.hOne))
			{
				this.x = this.xAnchor;
				this.y = this.yAnchor;
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
			}
			else
			{
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
				this.move_to_XY();
			}
		}
		else
		{
			if (!MainObject.isInScreen(this) && !base.setIsInScreen(this.xAnchor, this.yAnchor, this.wOne, this.hOne))
			{
				this.x = this.xAnchor;
				this.y = this.yAnchor;
				this.toX = this.xAnchor;
				this.toY = this.yAnchor;
				return;
			}
			this.time++;
			if (this.Action != 4)
			{
				if (this.timeStand > 0)
				{
					this.time = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					this.timeStand--;
				}
				else if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, GameScreen.player.x, GameScreen.player.y) < 50)
				{
					if (this.Action == 1)
					{
						if (this.time > this.timeAutoAction / 2 || CRes.random(12) == 0 || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove - this.vMax)
						{
							this.time = 0;
							this.Action = 0;
							this.vx = 0;
							this.vy = 0;
							if (this.x > GameScreen.player.x)
							{
								this.Direction = 2;
							}
							else
							{
								this.Direction = 3;
							}
						}
					}
					else if (this.Action == 0 || CRes.random(30) == 0)
					{
						this.vx = 0;
						this.vy = 0;
						if (this.time > this.timeAutoAction)
						{
							this.time = 0;
							this.Action = 1;
							this.Direction = CRes.random(4);
							base.setSpeedInDirection(this.vMax - 2);
						}
						if (this.x > GameScreen.player.x)
						{
							this.Direction = 2;
						}
						else
						{
							this.Direction = 3;
						}
					}
				}
				else if (this.Action == 1)
				{
					if (this.time > this.timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove - this.vMax)
					{
						this.time = 0;
						this.Action = 0;
						this.vx = 0;
						this.vy = 0;
					}
				}
				else if (this.Action == 0)
				{
					this.vx = 0;
					this.vy = 0;
					if (this.time > this.timeAutoAction / 2 || CRes.random(12) == 0)
					{
						this.time = 0;
						this.Action = 1;
						this.Direction = CRes.random(4);
						base.setSpeedInDirection(this.vMax);
					}
				}
				if (MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) > this.limitMove)
				{
					int num3 = CRes.abs(this.x - this.xAnchor);
					int num4 = CRes.abs(this.y - this.yAnchor);
					if (num3 > num4)
					{
						if (this.x > this.xAnchor)
						{
							this.Direction = 2;
						}
						else
						{
							this.Direction = 3;
						}
					}
					else if (this.y > this.yAnchor)
					{
						this.Direction = 1;
					}
					else
					{
						this.Direction = 0;
					}
					base.setSpeedInDirection(this.vMax);
				}
			}
		}
	}

	// Token: 0x060003BF RID: 959 RVA: 0x0003475C File Offset: 0x0003295C
	public void autoMoveFire()
	{
		if ((int)this.typeBoss == 5)
		{
			return;
		}
		this.time++;
		if (this.Action != 4)
		{
			if (this.Action == 1)
			{
				if (this.time > this.timeAutoAction || CRes.random(16) == 0)
				{
					this.time = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
					MainObject mainObject = MainObject.get_Object(this.IDAttack, 0);
					if (mainObject != null)
					{
						if (this.x > mainObject.x)
						{
							this.Direction = 2;
						}
						else
						{
							this.Direction = 3;
						}
					}
				}
			}
			else if (this.Action == 0)
			{
				this.vx = 0;
				this.vy = 0;
				if (this.time > this.timeAutoAction / 2 || CRes.random(12) == 0)
				{
					this.time = 0;
					this.Action = 1;
					this.Direction = CRes.random(4);
					base.setSpeed(this.vMax);
				}
			}
		}
	}

	// Token: 0x060003C0 RID: 960 RVA: 0x00034870 File Offset: 0x00032A70
	public virtual void Move_to_Focus()
	{
		if ((int)this.typeBoss == 5)
		{
			return;
		}
		if (this.isBinded)
		{
			return;
		}
		if (this.isDongBang)
		{
			return;
		}
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
			if (GameCanvas.timeNow - this.timeBeginMoveAttack > (long)this.timeMaxMoveAttack)
			{
				this.IDAttack = (int)object_Effect_Skill.ID;
				object_Effect_Skill.skillMonster = this.skillDefault;
				this.beginFire();
				this.beginSkill();
			}
			else
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				if (mainObject == null)
				{
					this.isRunAttack = false;
					return;
				}
				this.toX = mainObject.x;
				this.toY = mainObject.y;
				int range = object_Effect_Skill.skillMonster.range;
				if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) <= range)
				{
					this.IDAttack = (int)object_Effect_Skill.ID;
					this.beginFire();
					this.beginSkill();
				}
				else if (CRes.abs(this.x - this.toX) >= 4 || CRes.abs(this.y - this.toY) >= 4)
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

	// Token: 0x060003C1 RID: 961 RVA: 0x00034AE8 File Offset: 0x00032CE8
	public void Move_To_Player_Skill()
	{
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
			if (GameCanvas.timeNow - this.timeBeginMoveAttack > (long)this.timeMaxMoveAttack)
			{
				this.IDAttack = (int)object_Effect_Skill.ID;
				object_Effect_Skill.skillMonster = this.skillDefault;
				this.beginFire();
				this.beginSkill();
			}
			else
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				if (mainObject == null)
				{
					this.isRunAttack = false;
					return;
				}
				this.toX = mainObject.x;
				this.toY = mainObject.y;
				if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) <= object_Effect_Skill.skillMonster.range)
				{
					this.IDAttack = (int)object_Effect_Skill.ID;
					this.beginFire();
					this.beginSkill();
				}
				else if (CRes.abs(this.x - this.toX) >= 4 || CRes.abs(this.y - this.toY) >= 4)
				{
					this.move_to_XY_Normal();
				}
			}
		}
	}

	// Token: 0x060003C2 RID: 962 RVA: 0x00034C2C File Offset: 0x00032E2C
	public void Reveive()
	{
		this.ReveiceMonster();
		this.isRunAttack = false;
		base.resetXY();
		this.frameDie = 0;
		this.timeFreeFire = 0;
		this.timeBienmat = 5;
		this.f = 0;
		this.Action = 0;
		this.time = 0;
		this.isDie = false;
		this.vxDie = 0;
		this.vyDie = 0;
		this.hp = this.maxHp;
		this.vecBuff.removeAllElements();
		this.vyStyleDie = (this.vyStyleStand = 0);
	}

	// Token: 0x060003C3 RID: 963 RVA: 0x00034CB4 File Offset: 0x00032EB4
	public void setDie()
	{
		if (this.Action == 4)
		{
			this.frameDie++;
			if (GameCanvas.gameTick % 10 == 0)
			{
				if (this.timeReveice >= 0)
				{
					if (this.isDie && (GameCanvas.timeNow - this.timedie) / 1000L > (long)this.timeReveice)
					{
						this.Reveive();
					}
				}
			}
			if (!this.isDie)
			{
				this.x += this.vxDie;
				this.y += this.vyDie;
				if (this.vyStyleDie > 0)
				{
					this.vyStyleDie -= 3;
					if (this.vyStyleDie <= 0 && this.vyStyleStand > 2)
					{
						this.vyStyleStand -= 2;
						this.vyStyleDie = this.vyStyleStand;
						if (CRes.abs(this.vxDie) > 1)
						{
							this.vxDie -= this.vxDie / CRes.abs(this.vxDie);
						}
						if (CRes.abs(this.vyDie) > 1)
						{
							this.vyDie -= this.vyDie / CRes.abs(this.vyDie);
						}
					}
				}
				else
				{
					this.vxDie >>= 1;
					this.vyDie >>= 1;
				}
				if (this.frameDie >= this.timeBienmat)
				{
					GameScreen.addEffectEndKill(11, this.x, this.y - this.hOne / 4);
					if (!this.isMonsterHouse() || !this.isItemBox())
					{
						this.isDie = true;
					}
					else if (this.coutEff < -10)
					{
						this.isDie = true;
					}
				}
			}
			if (this.isMonsterHouse() || this.isItemBox() || this.typeMonster == 16)
			{
				this.coutEff--;
				if (this.coutEff > 0 && this.timeFreeMove < 70)
				{
					this.timeFreeMove++;
					if (CRes.random(3) == 1)
					{
						if (CRes.random(2) == 1)
						{
							LoadMap.timeVibrateScreen = 103;
						}
						int num = CRes.random(1, 3);
						for (int i = 0; i < num; i++)
						{
							int num2 = CRes.random_Am_0(25);
							int num3 = CRes.random_Am_0(30);
							GameScreen.addEffectEndKill(36, this.x + num2, this.y + num3 - this.hOne / 3 + 10);
							if (CRes.random(3) == 1)
							{
								GameScreen.addEffectEndKill(9, this.x + num2, this.y + num3 - this.hOne / 3 + 10);
							}
						}
					}
					if (this.timeFreeMove >= 70)
					{
						for (int j = 0; j < 6; j++)
						{
							int num4 = CRes.random_Am_0(25);
							int num5 = CRes.random_Am_0(30);
							GameScreen.addEffectEndKill(36, this.x + num4, this.y + num5 - this.hOne / 3 + 10);
							if (CRes.random(3) == 1)
							{
								GameScreen.addEffectEndKill(9, this.x + num4, this.y + num5 - this.hOne / 2 + 10);
							}
						}
						this.isRemove = true;
					}
				}
			}
		}
		else if (this.hp <= 0)
		{
			this.hp = 0;
			this.Action = 4;
			this.timedie = GameCanvas.timeNow;
			base.resetXY();
		}
	}

	// Token: 0x060003C4 RID: 964 RVA: 0x00035040 File Offset: 0x00033240
	public void ReveiceMonster()
	{
		int num = 0;
		if (this.typeMonster == 7)
		{
			this.x = this.xAnchor;
			this.y = this.yAnchor;
			return;
		}
		bool flag;
		do
		{
			this.x = this.xAnchor + CRes.random_Am_0(48);
			this.y = this.yAnchor + CRes.random_Am_0(48);
			int tile = GameCanvas.loadmap.getTile(this.x, this.y);
			flag = (tile != 1 && tile != -1);
			num++;
			if (num > 15)
			{
				flag = true;
				this.x = this.xAnchor;
				this.y = this.yAnchor;
			}
		}
		while (!flag);
	}

	// Token: 0x060003C5 RID: 965 RVA: 0x000350F4 File Offset: 0x000332F4
	public void startDeadFly(int dx, int dy, int time, int vyStyle)
	{
		this.timedie = GameCanvas.timeNow;
		this.Action = 4;
		this.vx = 0;
		this.vy = 0;
		this.vxDie = dx;
		this.vyDie = dy;
		this.vyStyleDie = vyStyle;
		this.vyStyleStand = vyStyle;
		this.timeBienmat = time;
		this.isDie = false;
		if (this.isMonsterHouse() || this.isItemBox() || this.typeMonster == 16)
		{
			this.vxDie = 0;
			this.vyDie = 0;
			this.vyStyleDie = 0;
			this.vyStyleStand = 0;
		}
	}

	// Token: 0x060003C6 RID: 966 RVA: 0x0003518C File Offset: 0x0003338C
	public void resetV()
	{
		this.vx = 0;
		this.vy = 0;
		this.toX = this.x;
		this.toY = this.y;
	}

	// Token: 0x060003C7 RID: 967 RVA: 0x000351C0 File Offset: 0x000333C0
	public new void startDie()
	{
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
			object_Effect_Skill.skillMonster = this.skillDefault;
		}
		this.beginSkill();
	}

	// Token: 0x060003C8 RID: 968 RVA: 0x00035210 File Offset: 0x00033410
	public void beginSkill()
	{
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
			if (object_Effect_Skill != null && object_Effect_Skill.skillMonster != null)
			{
				if ((int)object_Effect_Skill.skillMonster.typeSkill == 124)
				{
					GameScreen.StartEffect_Chiemthanh((int)object_Effect_Skill.skillMonster.typeSkill, this.ID, 1, this.vecObjskill, object_Effect_Skill.skillMonster.typeSub);
				}
				else
				{
					GameScreen.addEffectKill((int)object_Effect_Skill.skillMonster.typeSkill, this.ID, 1, this.vecObjskill, object_Effect_Skill.skillMonster.typeSub);
				}
			}
			this.vecObjskill = null;
		}
	}

	// Token: 0x060003C9 RID: 969 RVA: 0x000352D0 File Offset: 0x000334D0
	public override void beginFire()
	{
		this.Action = 2;
		this.loopAtack = (sbyte)CRes.random(3, 5);
		base.resetAction();
		this.f = 0;
	}

	// Token: 0x060003CA RID: 970 RVA: 0x00035300 File Offset: 0x00033500
	public new void addiconClan()
	{
	}

	// Token: 0x060003CB RID: 971 RVA: 0x00035304 File Offset: 0x00033504
	public new bool canNotMove()
	{
		return this.typeMonster == 17 || this.typeMonster == 19 || this.typeMonster == 18;
	}

	// Token: 0x040004F6 RID: 1270
	public const int MONSTER_MOVE_012 = 0;

	// Token: 0x040004F7 RID: 1271
	public const int MONSTER_MOVE_01 = 1;

	// Token: 0x040004F8 RID: 1272
	public const int MONSTER_MOVE_0102 = 2;

	// Token: 0x040004F9 RID: 1273
	public const int MONSTER_MOVE_FLY_012 = 3;

	// Token: 0x040004FA RID: 1274
	public const int MONSTER_MOVE_WATER = 4;

	// Token: 0x040004FB RID: 1275
	public const int MONSTER_MOVE_FLY_0102 = 5;

	// Token: 0x040004FC RID: 1276
	public const int MONSTER_SEN_CHUA = 6;

	// Token: 0x040004FD RID: 1277
	public const int MONSTER_QUEST = 7;

	// Token: 0x040004FE RID: 1278
	public const int MONSTER_BO_CHUA = 8;

	// Token: 0x040004FF RID: 1279
	public const int MONSTER_BACH_TUOC_TRANG = 9;

	// Token: 0x04000500 RID: 1280
	public const int MONSTER_MOVE_FLY_012_SLOW = 10;

	// Token: 0x04000501 RID: 1281
	public const int MONSTER_HOUSE = 12;

	// Token: 0x04000502 RID: 1282
	public const int MONSTER_BOX = 13;

	// Token: 0x04000503 RID: 1283
	public const int MONSTER_VANTIEU = 14;

	// Token: 0x04000504 RID: 1284
	public const int MONSTER_MI_NUONG = 15;

	// Token: 0x04000505 RID: 1285
	public const int MONSTER_GATE = 16;

	// Token: 0x04000506 RID: 1286
	public const int MONSTER_WALK_CAN_NOT_MOVE = 17;

	// Token: 0x04000507 RID: 1287
	public const int MONSTER_PAINT_BY_EFFECT_AUTO = 18;

	// Token: 0x04000508 RID: 1288
	public const int MONSTER_FLY_CAN_NOT_MOVE = 19;

	// Token: 0x04000509 RID: 1289
	public const int MONSTER_Boss_Medusa = 101;

	// Token: 0x0400050A RID: 1290
	public const int MONSTER_Boss_DeVang = 83;

	// Token: 0x0400050B RID: 1291
	public const int MONSTER_Boss_DeBac = 84;

	// Token: 0x0400050C RID: 1292
	public sbyte[][][] mAction;

	// Token: 0x0400050D RID: 1293
	public int timeAutoAction;

	// Token: 0x0400050E RID: 1294
	public int catalogyMonster;

	// Token: 0x0400050F RID: 1295
	public int timeRemove;

	// Token: 0x04000510 RID: 1296
	public int limitMove;

	// Token: 0x04000511 RID: 1297
	public int limitAttack;

	// Token: 0x04000512 RID: 1298
	public int timeFreeFire;

	// Token: 0x04000513 RID: 1299
	public int xAnchor;

	// Token: 0x04000514 RID: 1300
	public int yAnchor;

	// Token: 0x04000515 RID: 1301
	public int xPhoBang;

	// Token: 0x04000516 RID: 1302
	public int yPhoBang;

	// Token: 0x04000517 RID: 1303
	public int vxDie;

	// Token: 0x04000518 RID: 1304
	public int vyDie;

	// Token: 0x04000519 RID: 1305
	public int vyStyleDie;

	// Token: 0x0400051A RID: 1306
	public int vyStyleStand;

	// Token: 0x0400051B RID: 1307
	public new int imageId;

	// Token: 0x0400051C RID: 1308
	public static mHashTable HashImageMonster = new mHashTable();

	// Token: 0x0400051D RID: 1309
	public static mVector VecCatalogyMonSter = new mVector("MainMonster VecCatalogyMonSter");

	// Token: 0x0400051E RID: 1310
	public int MonWater;

	// Token: 0x0400051F RID: 1311
	public int frameDie;

	// Token: 0x04000520 RID: 1312
	public int timeBienmat;

	// Token: 0x04000521 RID: 1313
	public int wAvatar;

	// Token: 0x04000522 RID: 1314
	public int hAvatar;

	// Token: 0x04000523 RID: 1315
	public int nFrame;

	// Token: 0x04000524 RID: 1316
	public int hRegion;

	// Token: 0x04000525 RID: 1317
	public int timeMaxMoveAttack;

	// Token: 0x04000526 RID: 1318
	public int timeRemoveGhost;

	// Token: 0x04000527 RID: 1319
	public long timeBeginMoveAttack;

	// Token: 0x04000528 RID: 1320
	public mVector vecObjskill;

	// Token: 0x04000529 RID: 1321
	public sbyte loopAtack;

	// Token: 0x0400052A RID: 1322
	public string nameowner = string.Empty;

	// Token: 0x0400052B RID: 1323
	public static short[] idBossNew = new short[]
	{
		104,
		103,
		105,
		106,
		135
	};

	// Token: 0x0400052C RID: 1324
	public int count;
}
