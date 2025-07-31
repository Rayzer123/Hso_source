using System;

// Token: 0x02000060 RID: 96
public class Monsterplus : MainMonster
{
	// Token: 0x060004AA RID: 1194 RVA: 0x0004242C File Offset: 0x0004062C
	public Monsterplus(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
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
		this.fraImgEff = new FrameImage(1);
		this.r = 120;
		this.limitMove = 60;
		this.timeAutoAction = CRes.random(50, 70);
		this.limitAttack = 50;
		this.xsai = 0;
		this.ysai = -2;
		this.timeLoadInfo = mSystem.currentTimeMillis();
		if (this.catalogyMonster == 110)
		{
			this.ideffect = 52;
			this.r = 120;
			this.eff = new EffectAuto((int)this.ideffect, x, y, 0, 0, 1, 0);
		}
	}

	// Token: 0x060004AB RID: 1195 RVA: 0x0004256C File Offset: 0x0004076C
	public override void setEffectauto(int id, int r, short lv)
	{
		this.ideffect = (sbyte)id;
		this.eff = new EffectAuto((int)this.ideffect, this.x, this.y, 0, 0, 1, 0);
		this.r = r;
		this.Lv = lv;
	}

	// Token: 0x060004AC RID: 1196 RVA: 0x000425B4 File Offset: 0x000407B4
	public override void setTimelive(long time)
	{
		this.timeLive = time;
	}

	// Token: 0x060004AD RID: 1197 RVA: 0x000425C0 File Offset: 0x000407C0
	public override bool isLuaThieng()
	{
		return true;
	}

	// Token: 0x060004AE RID: 1198 RVA: 0x000425C4 File Offset: 0x000407C4
	public override void setLvmonster(int lv)
	{
		this.Lv = (short)((sbyte)lv);
		if (this.catalogyMonster == 110)
		{
			if (this.Lv == 1)
			{
				this.ideffect = 52;
				this.r = 120;
			}
			if (this.Lv == 2)
			{
				this.ideffect = 53;
				this.r = 130;
			}
			else if (this.Lv == 3)
			{
				this.ideffect = 54;
				this.r = 140;
			}
			else if (this.Lv == 4)
			{
				this.ideffect = 55;
				this.r = 150;
			}
			this.eff = new EffectAuto((int)this.ideffect, this.x, this.y, 0, 0, 1, 0);
		}
	}

	// Token: 0x060004AF RID: 1199 RVA: 0x0004268C File Offset: 0x0004088C
	public void setIdeffect(sbyte ideffect)
	{
		this.ideffect = ideffect;
	}

	// Token: 0x060004B0 RID: 1200 RVA: 0x00042698 File Offset: 0x00040898
	public override void updateAction()
	{
	}

	// Token: 0x060004B1 RID: 1201 RVA: 0x0004269C File Offset: 0x0004089C
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
		base.setDie();
		this.updateAction();
		this.fireFrame += 1;
		if ((int)this.fireFrame > 10)
		{
			this.fireFrame = 0;
		}
		if (this.eff != null)
		{
			this.eff.update();
		}
		bool flag = false;
		if (this.myClan != null)
		{
			if (GameScreen.player.myClan != null && this.myClan.IdClan == GameScreen.player.myClan.IdClan)
			{
				flag = true;
			}
		}
		else if (this.nameowner.Equals(GameScreen.player.name))
		{
			flag = true;
		}
		if (flag)
		{
			this.ysai = 10;
			for (int i = 0; i < this.arr_radian.Length; i++)
			{
				this.arr_radian[i]++;
				if (this.arr_radian[i] >= 360)
				{
					this.arr_radian[i] = 0;
				}
			}
		}
	}

	// Token: 0x060004B2 RID: 1202 RVA: 0x000427E4 File Offset: 0x000409E4
	public override void paint(mGraphics g)
	{
		if (this.eff != null)
		{
			this.eff.paint(g);
		}
		bool flag = false;
		if (this.myClan != null)
		{
			if (GameScreen.player.myClan != null && this.myClan.IdClan == GameScreen.player.myClan.IdClan)
			{
				flag = true;
			}
		}
		else if (this.nameowner.Equals(GameScreen.player.name))
		{
			flag = true;
		}
		if (flag)
		{
			base.paintIconClan(g, this.x - 1, this.y - this.ysai - this.dy + this.dyWater - this.hOne - 20, 2);
			string text = string.Empty;
			long now = this.timeLive - mSystem.currentTimeMillis();
			text = LoadMap.convertSecondsToHMmSs(now);
			if (!text.Equals(string.Empty))
			{
				mFont.tahoma_7_yellow.drawString(g, text, this.x, this.y - this.ysai - this.dy + this.dyWater - this.hOne - 40, 3, false);
			}
			mFont.tahoma_7_yellow.drawString(g, T.level + this.Lv, this.x, this.y - this.ysai - this.dy + this.dyWater - this.hOne - 55, 3, false);
			for (int i = 0; i < this.arr_radian.Length; i++)
			{
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill((int)this.fireFrame / 2 % this.fraImgEff.nFrame, CRes.cos(this.arr_radian[i]) * this.r / 1024 + this.x + 2, CRes.sin(this.arr_radian[i]) * this.r / 1024 + this.y, 0, 3, g);
				}
			}
		}
	}

	// Token: 0x060004B3 RID: 1203 RVA: 0x000429DC File Offset: 0x00040BDC
	public override void move_to_XY()
	{
	}

	// Token: 0x060004B4 RID: 1204 RVA: 0x000429E0 File Offset: 0x00040BE0
	public override void move_to_XY_Normal()
	{
	}

	// Token: 0x060004B5 RID: 1205 RVA: 0x000429E4 File Offset: 0x00040BE4
	public override void moveX()
	{
	}

	// Token: 0x060004B6 RID: 1206 RVA: 0x000429E8 File Offset: 0x00040BE8
	public override void moveY()
	{
	}

	// Token: 0x0400069A RID: 1690
	public sbyte ideffect = -1;

	// Token: 0x0400069B RID: 1691
	public sbyte fireFrame;

	// Token: 0x0400069C RID: 1692
	public EffectAuto eff;

	// Token: 0x0400069D RID: 1693
	public int r;

	// Token: 0x0400069E RID: 1694
	public FrameImage fraImgEff;

	// Token: 0x0400069F RID: 1695
	public int[] arr_radian = new int[]
	{
		0,
		30,
		60,
		90,
		120,
		150,
		180,
		210,
		240,
		270,
		300,
		330
	};

	// Token: 0x040006A0 RID: 1696
	public long timeLive;
}
