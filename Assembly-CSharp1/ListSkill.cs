using System;

// Token: 0x020000CD RID: 205
public class ListSkill : MainListSkill
{
	// Token: 0x060009A9 RID: 2473 RVA: 0x000A35F0 File Offset: 0x000A17F0
	public void setFireSkill(MainObject obj, mVector vec, int IndexSkill, sbyte classBuff)
	{
		if (vec == null || vec.size() <= 0)
		{
			return;
		}
		if (IndexSkill > MainListSkill.mSkillAllClasses[(int)obj.clazz].Length - 1)
		{
			return;
		}
		this.classbuff = classBuff;
		this.obj = obj;
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(0);
		this.objBeKill = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
		this.vecObjBeKill = vec;
		if (this.obj == null || this.obj.Action == 4 || this.objBeKill == null || this.objBeKill.Action == 4)
		{
			obj.KillFire = -1;
			obj.IDAttack = -1;
			obj.vecObjFocusSkill = null;
			return;
		}
		if ((int)obj.typeObject == 9)
		{
			this.skill = MainListSkill.mSkillAllClasses[6][IndexSkill];
		}
		else
		{
			this.skill = MainListSkill.mSkillAllClasses[(int)obj.clazz][IndexSkill];
		}
		this.index = IndexSkill;
		obj.KillFire = IndexSkill;
		this.plash = MainListSkill.mPlash[this.skill];
		this.frame = MainListSkill.mFramePlash[this.skill];
		if ((int)obj.clazz == 3)
		{
			this.plash /= 2;
			this.frame /= 2;
		}
		if (obj == GameScreen.player)
		{
			this.FireSkill(MainListSkill.getRange(IndexSkill));
		}
		else
		{
			this.FireSkill(MainListSkill.mRange[this.skill]);
		}
	}

	// Token: 0x060009AA RID: 2474 RVA: 0x000A3770 File Offset: 0x000A1970
	public void setVecBeKill(mVector vec)
	{
		this.vecObjBeKill = vec;
	}

	// Token: 0x060009AB RID: 2475 RVA: 0x000A377C File Offset: 0x000A197C
	public void FireSkill(int range)
	{
		int distance = MainObject.getDistance(this.obj.x, this.obj.y, this.objBeKill.x, this.objBeKill.y - this.objBeKill.hOne / 4);
		if (distance <= range || (int)this.obj.typeObject == 9)
		{
			if (this.obj != GameScreen.player || this.setMove_Skill())
			{
				this.obj.toX = this.obj.x;
				this.obj.toY = this.obj.y;
				this.obj.vx = 0;
				this.obj.vy = 0;
				if ((int)this.obj.typeObject != 9)
				{
					this.obj.beginFire();
					this.obj.PlashNow.setPlash(this.plash);
					this.obj.KillFire = -1;
					if (this.skill == 53)
					{
						this.obj.Direction = 1;
					}
					else
					{
						this.obj.Direction = base.setDirection(this.obj, this.objBeKill);
					}
					this.setEff_More();
				}
			}
		}
		else
		{
			int num = CRes.angle(this.obj.x - this.objBeKill.x, this.obj.y - this.objBeKill.y);
			int num2 = 0;
			for (;;)
			{
				int num3 = this.objBeKill.x + CRes.cos(CRes.fixangle(num % 360)) * (range - 5) / 1000;
				int num4 = this.objBeKill.y + CRes.sin(CRes.fixangle(num % 360)) * (range - 5) / 1000;
				int tile = GameCanvas.loadmap.getTile(num3, num4);
				num += CRes.random_Am_0(90);
				num2++;
				if (num2 > 12)
				{
					break;
				}
				if (tile != -1 && tile != 1)
				{
					goto Block_7;
				}
			}
			this.obj.posTransRoad = null;
			GameCanvas.addInfoChar(T.farfocus);
			this.obj.KillFire = -1;
			this.obj.IDAttack = -1;
			this.obj.vecObjFocusSkill = null;
			this.setGoBack();
			return;
			Block_7:
			if (this.obj == GameScreen.player)
			{
				this.obj.toX = this.obj.x;
				this.obj.toY = this.obj.y;
				GameScreen.player.xStopMove = 0;
				GameScreen.player.yStopMove = 0;
				int num3;
				int num4;
				this.obj.posTransRoad = GameCanvas.game.updateFindRoad(num3 / LoadMap.wTile, num4 / LoadMap.wTile, this.obj.x / LoadMap.wTile, this.obj.y / LoadMap.wTile, 12);
				Player.xFocus = -1;
				Player.yFocus = -1;
				if (this.obj.posTransRoad == null)
				{
					this.obj.toX = num3;
					this.obj.toY = num4;
					this.obj.xFire = num3;
					this.obj.yFire = num4;
					this.obj.posTransRoad = null;
				}
				else if (this.obj.posTransRoad.Length > 12)
				{
					this.obj.posTransRoad = null;
					GameCanvas.addInfoChar(T.farfocus);
					this.setGoBack();
					this.obj.KillFire = -1;
					this.obj.IDAttack = -1;
					this.obj.vecObjFocusSkill = null;
				}
				else
				{
					this.obj.xFire = num3;
					this.obj.yFire = num4;
					GameScreen.player.xStopMove = this.obj.xFire;
					GameScreen.player.yStopMove = this.obj.yFire;
				}
				this.obj.countAutoMove = 0;
			}
			else
			{
				int num3;
				this.obj.toX = num3;
				this.obj.xFire = num3;
				int num4;
				this.obj.toY = num4;
				this.obj.yFire = num4;
			}
			if ((int)this.obj.typeObject == 1)
			{
				this.obj.IDAttack = this.objBeKill.ID;
			}
			else
			{
				this.obj.vecObjFocusSkill = this.vecObjBeKill;
			}
		}
	}

	// Token: 0x060009AC RID: 2476 RVA: 0x000A3BE0 File Offset: 0x000A1DE0
	public void setGoBack()
	{
		if (this.obj == GameScreen.player && (int)Player.isAutoFire == 1 && Player.isCurAutoFire)
		{
			this.objBeKill.isSend = true;
			this.obj.toX = this.obj.x;
			this.obj.toY = this.obj.y;
			this.obj.xStopMove = Player.xBeginAutoFire;
			this.obj.yStopMove = Player.yBeginAutofire;
			this.obj.posTransRoad = GameCanvas.game.updateFindRoad(this.obj.xStopMove / LoadMap.wTile, this.obj.yStopMove / LoadMap.wTile, this.obj.x / LoadMap.wTile, this.obj.y / LoadMap.wTile, 20);
			Player.xFocus = -1;
			Player.yFocus = -1;
			if (this.obj.posTransRoad != null && this.obj.posTransRoad.Length > 20)
			{
				this.obj.posTransRoad = null;
			}
		}
	}

	// Token: 0x060009AD RID: 2477 RVA: 0x000A3D04 File Offset: 0x000A1F04
	public void fireSkillFree()
	{
		if (this.obj == null || this.objBeKill == null)
		{
			this.obj.KillFire = -1;
			this.obj.IDAttack = -1;
			this.obj.vecObjFocusSkill = null;
			return;
		}
		if (this.obj != GameScreen.player || this.setMove_Skill())
		{
			this.obj.toX = this.obj.x;
			this.obj.toY = this.obj.y;
			this.obj.vx = 0;
			this.obj.vy = 0;
			this.obj.beginFire();
			this.obj.PlashNow.setPlash(this.plash);
			this.obj.KillFire = -1;
			if (this.skill == 53)
			{
				this.obj.Direction = 1;
			}
			else
			{
				this.obj.Direction = base.setDirection(this.obj, this.objBeKill);
			}
			this.setEff_More();
		}
	}

	// Token: 0x060009AE RID: 2478 RVA: 0x000A3E1C File Offset: 0x000A201C
	public void updateEffSkill()
	{
		if (this.obj == null || this.objBeKill == null)
		{
			this.obj.KillFire = -1;
			this.obj.IDAttack = -1;
			this.obj.vecObjFocusSkill = null;
			return;
		}
		if ((int)this.obj.typeObject == 9)
		{
			if ((int)this.classbuff > -1)
			{
				GameScreen.addEffectKillSubTime(MainListSkill.mEffectKill[this.skill], this.obj.ID, this.obj.typeObject, this.vecObjBeKill, (sbyte)MainListSkill.mBuffAllClasses[(int)this.classbuff][this.index], 500);
				Pet pet = (Pet)this.obj;
				pet.setState(4);
			}
		}
		else if (this.obj.fplash == this.frame)
		{
			if (this.obj == GameScreen.player)
			{
				Skill skillFormId = MainListSkill.getSkillFormId(this.index);
				long num = GameCanvas.timeNow - ListSkill.lastTime;
				if (num > (long)ListSkill.GlobalCountdown)
				{
					ListSkill.GlobalCountdown = skillFormId.performDur;
					ListSkill.lastTime = GameCanvas.timeNow;
					this.sendSkill();
				}
			}
			if ((int)this.classbuff > -1)
			{
				GameScreen.addEffectKillSubTime(MainListSkill.mEffectKill[this.skill], this.obj.ID, this.obj.typeObject, this.vecObjBeKill, (sbyte)MainListSkill.mBuffAllClasses[(int)this.classbuff][this.index], 1250);
			}
			else
			{
				GameScreen.addEffectKill(MainListSkill.mEffectKill[this.skill], this.obj.ID, this.obj.typeObject, this.vecObjBeKill);
			}
		}
	}

	// Token: 0x060009AF RID: 2479 RVA: 0x000A3FD0 File Offset: 0x000A21D0
	public void setEff_More()
	{
		if (this.obj == GameScreen.player)
		{
			GameScreen.player.setAddDelaySkill(this.skill, this.index);
		}
		switch (this.skill)
		{
		case 5:
		case 21:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 0);
			break;
		case 6:
		case 47:
		case 48:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 4);
			break;
		case 14:
		case 34:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 3);
			break;
		case 18:
		case 19:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 300, 1);
			break;
		case 20:
		case 46:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 300, 4);
			break;
		case 22:
		case 36:
		case 44:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 300, 3);
			break;
		case 23:
		case 41:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 300, 0);
			break;
		case 24:
		case 40:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 1);
			break;
		case 27:
		case 37:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 3);
			break;
		case 39:
		case 51:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 4);
			break;
		case 42:
		case 43:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 0);
			break;
		case 49:
		case 50:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 1);
			break;
		case 52:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 1);
			break;
		case 53:
			GameScreen.addEffectKillTime(30, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 1);
			break;
		case 54:
		case 58:
		case 64:
		case 68:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 0);
			break;
		case 55:
		case 59:
		case 65:
		case 69:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 600, 3);
			break;
		case 56:
		case 61:
		case 62:
		case 66:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 300, 4);
			break;
		case 57:
		case 60:
		case 63:
		case 67:
			GameScreen.addEffectKillTime(29, this.obj.ID, this.obj.typeObject, this.vecObjBeKill, 400, 1);
			break;
		}
	}

	// Token: 0x060009B0 RID: 2480 RVA: 0x000A445C File Offset: 0x000A265C
	public bool setMove_Skill()
	{
		int num = this.skill;
		return true;
	}

	// Token: 0x060009B1 RID: 2481 RVA: 0x000A4474 File Offset: 0x000A2674
	public bool setMove(int x, int xend, int y, int yend)
	{
		short[] array = GameScreen.gI().updateFindRoad(xend / LoadMap.wTile, yend / LoadMap.wTile, x / LoadMap.wTile, y / LoadMap.wTile, 12);
		if (array == null)
		{
			int tile = GameCanvas.loadmap.getTile(xend, yend);
			if (tile != -1 && tile != 1)
			{
				return this.setSendMove(x, xend, y, yend);
			}
			GameCanvas.addInfoChar(T.farfocus);
			this.setGoBack();
			this.obj.KillFire = -1;
			this.obj.IDAttack = -1;
			this.obj.vecObjFocusSkill = null;
			return false;
		}
		else
		{
			if (array.Length > 12)
			{
				GameCanvas.addInfoChar(T.farfocus);
				this.setGoBack();
				this.obj.KillFire = -1;
				this.obj.IDAttack = -1;
				this.obj.vecObjFocusSkill = null;
				return false;
			}
			return true;
		}
	}

	// Token: 0x060009B2 RID: 2482 RVA: 0x000A4550 File Offset: 0x000A2750
	public bool setSendMove(int x, int xend, int y, int yend)
	{
		int num = 0;
		int num2 = 0;
		int num3 = CRes.abs(x - xend);
		int num4 = CRes.abs(y - yend);
		if (num3 >= 4)
		{
			if (x > xend)
			{
				num = -6;
			}
			else
			{
				num = 6;
			}
		}
		if (num4 >= 4)
		{
			if (y > yend)
			{
				num2 = -6;
			}
			else
			{
				num2 = 6;
			}
		}
		int num5 = num3 / 6;
		int num6 = num4 / 6;
		int num7;
		if (num3 > num4)
		{
			num7 = num5;
		}
		else
		{
			num7 = num6;
		}
		for (int i = 0; i < num7; i++)
		{
			if (i < num5)
			{
				x += num;
			}
			if (i < num6)
			{
				y += num2;
			}
			int tile = GameCanvas.loadmap.getTile(x, y);
			if (tile == 1 || tile == -1)
			{
				GameCanvas.addInfoChar(T.farfocus);
				this.setGoBack();
				this.obj.KillFire = -1;
				this.obj.IDAttack = -1;
				return false;
			}
		}
		return true;
	}

	// Token: 0x060009B3 RID: 2483 RVA: 0x000A4648 File Offset: 0x000A2848
	public static void doSetTimeAtt()
	{
		ListSkill.lastTimeAttack = mSystem.currentTimeMillis();
	}

	// Token: 0x060009B4 RID: 2484 RVA: 0x000A4654 File Offset: 0x000A2854
	public static bool canAttack()
	{
		long num = mSystem.currentTimeMillis();
		long num2 = num - ListSkill.lastTimeAttack;
		return num2 > (long)ListSkill.limitTimeAtt;
	}

	// Token: 0x060009B5 RID: 2485 RVA: 0x000A4678 File Offset: 0x000A2878
	public void sendSkill()
	{
		mVector mVector = GameScreen.player.setSkillLan(this.index, this.objBeKill);
		this.vecObjBeKill = mVector;
		if ((int)this.classbuff > -1)
		{
			this.setSendBuff(mVector);
		}
		else if ((int)this.objBeKill.typeObject == 1)
		{
			GlobalService.gI().fire_monster(mVector, (sbyte)this.index);
		}
		else if ((int)this.objBeKill.typeObject == 0)
		{
			GlobalService.gI().fire_Pk(mVector, (sbyte)this.index);
		}
	}

	// Token: 0x060009B6 RID: 2486 RVA: 0x000A4708 File Offset: 0x000A2908
	public void setSendBuff(mVector vec)
	{
		GlobalService.gI().BuffMore((sbyte)this.index, this.objBeKill.typeObject, vec);
	}

	// Token: 0x060009B7 RID: 2487 RVA: 0x000A4728 File Offset: 0x000A2928
	public bool setBuff(int type)
	{
		for (int i = 0; i < this.obj.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.obj.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == type)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x040010D1 RID: 4305
	private MainObject obj;

	// Token: 0x040010D2 RID: 4306
	private MainObject objBeKill;

	// Token: 0x040010D3 RID: 4307
	private int skill;

	// Token: 0x040010D4 RID: 4308
	private int plash;

	// Token: 0x040010D5 RID: 4309
	private int frame;

	// Token: 0x040010D6 RID: 4310
	private int index;

	// Token: 0x040010D7 RID: 4311
	private mVector vecObjBeKill;

	// Token: 0x040010D8 RID: 4312
	public sbyte classbuff = -1;

	// Token: 0x040010D9 RID: 4313
	public sbyte typebuff;

	// Token: 0x040010DA RID: 4314
	public static short GlobalCountdown;

	// Token: 0x040010DB RID: 4315
	public static long lastTime;

	// Token: 0x040010DC RID: 4316
	public static long lastTimeAttack;

	// Token: 0x040010DD RID: 4317
	public static int limitTimeAtt = 600;
}
