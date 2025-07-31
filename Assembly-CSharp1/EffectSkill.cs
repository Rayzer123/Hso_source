using System;

// Token: 0x02000037 RID: 55
public class EffectSkill : MainEffect
{
	// Token: 0x0600027A RID: 634 RVA: 0x000134B4 File Offset: 0x000116B4
	public EffectSkill(int x, int y, int xto, int yto, sbyte indexpos)
	{
		GameScreen.addEffectEndKill(14, x, y);
		GameScreen.addEffectEndKill(14, x + 24, y);
		GameScreen.addEffectEndKill(14, x - 24, y);
		GameScreen.addEffectEndKill(57, x, y);
		this.fraImgEff = new FrameImage(162);
		this.indexpost = indexpos;
		this.x = x;
		this.y = y;
		this.xto = xto;
		this.yto = yto;
		if (this.xto == x)
		{
			this.vx = 0;
		}
		else if (this.xto > x)
		{
			this.vx = 1;
		}
		else
		{
			this.vx = -1;
		}
		this.vy = -5;
		this.typeEffect = 124;
	}

	// Token: 0x0600027B RID: 635 RVA: 0x00013654 File Offset: 0x00011854
	public EffectSkill(int typeKill, Object_Effect_Skill objkill, mVector vec, int subtype)
	{
		if (!LoadMapScreen.isNextMap)
		{
			return;
		}
		this.subType = subtype;
		this.isStop = false;
		this.isRemove = false;
		this.set_New_Effect(typeKill, objkill, vec);
	}

	// Token: 0x0600027C RID: 636 RVA: 0x00013778 File Offset: 0x00011978
	public EffectSkill(int typeKill, Object_Effect_Skill objkill, mVector vec, int subtype, bool ispaintarena)
	{
		if (!LoadMapScreen.isNextMap)
		{
			return;
		}
		this.subType = subtype;
		this.ispaintArena = ispaintarena;
		this.isStop = false;
		this.isRemove = false;
		this.set_New_Effect(typeKill, objkill, vec);
	}

	// Token: 0x0600027D RID: 637 RVA: 0x000138A4 File Offset: 0x00011AA4
	public EffectSkill(int type, int x, int y, int timeRe, short idGhost, sbyte tem)
	{
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		this.timeRemove = timeRe;
		this.time = GameCanvas.timeNow;
		switch (type)
		{
		case 80:
			this.fRemove = 16;
			this.isEff = true;
			this.fraImgEff = new FrameImage(16);
			this.objBeKillMain = MainObject.get_Object((int)idGhost, 1);
			if (this.objBeKillMain == null)
			{
				return;
			}
			break;
		case 81:
			this.fRemove = 30;
			this.isEff = true;
			this.create_Fire_Arc();
			break;
		default:
			switch (type)
			{
			case 100:
				mSound.playSound(32, mSound.volumeSound);
				this.fRemove = 60;
				this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
				if (this.objBeKillMain == null)
				{
					return;
				}
				x = this.objBeKillMain.x;
				y = this.objBeKillMain.y;
				this.objBeKillMain.vx = 0;
				this.objBeKillMain.vy = 0;
				this.objBeKillMain.toX = x;
				this.objBeKillMain.toY = y;
				this.objBeKillMain.isDongBang = true;
				this.objBeKillMain.timeDongBang = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
				GameScreen.addEffectEndKill_Time(49, this.objBeKillMain.x, this.objBeKillMain.y, this.objBeKillMain.timeDongBang);
				this.levelPaint = -1;
				this.fRemove = 6;
				break;
			case 101:
				this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
				if (this.objBeKillMain == null)
				{
					return;
				}
				this.ispaintsleep = false;
				this.delay = 10;
				x = this.objBeKillMain.x;
				y = this.objBeKillMain.y;
				this.objBeKillMain.vx = 0;
				this.objBeKillMain.vy = 0;
				this.objBeKillMain.toX = x;
				this.objBeKillMain.toY = y;
				this.objBeKillMain.isSleep = true;
				this.objBeKillMain.timeSleep = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
				break;
			case 102:
				this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
				if (this.objBeKillMain == null)
				{
					return;
				}
				x = this.objBeKillMain.x;
				y = this.objBeKillMain.y - 25;
				this.objBeKillMain.vx = 0;
				this.objBeKillMain.vy = 0;
				this.objBeKillMain.toX = x;
				this.objBeKillMain.toY = y;
				this.objBeKillMain.isStun = true;
				this.objBeKillMain.timeStun = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
				if ((int)this.objBeKillMain.typeObject == 1)
				{
					this.ystun = 0;
				}
				else
				{
					this.ystun = 17;
				}
				break;
			case 103:
				this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
				if (this.objBeKillMain == null)
				{
					return;
				}
				this.fraImgEff = new FrameImage(27);
				this.r = 72;
				this.timedelay = 20;
				this.ysai = 40;
				this.objBeKillMain.isnoBoss84 = true;
				this.objBeKillMain.timenoBoss84 = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
				break;
			default:
				if (type != 29)
				{
					if (type == 69)
					{
						this.fRemove = 16;
						this.isEff = true;
						this.fraImgEff = new FrameImage(9);
						this.vx = CRes.random_Am_0(2);
						this.vy = -2;
					}
				}
				else
				{
					this.isEff = true;
					this.indexColorStar = CRes.random(2);
					this.x1000 = x * 1000;
					this.y1000 = y * 1000;
					this.fRemove = CRes.random(4, 6);
					this.vMax = 5;
					this.xline = 10;
					this.yline = 20;
					this.create_Star_Line_In(this.vMax, this.xline, this.yline);
				}
				break;
			case 107:
				this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
				if (this.objBeKillMain == null)
				{
					return;
				}
				this.isEff = true;
				this.indexColorStar = CRes.random(2);
				x = this.objBeKillMain.x;
				y = this.objBeKillMain.y - 15;
				this.x1000 = x * 1000;
				this.y1000 = y * 1000;
				this.objBeKillMain.toX = x;
				this.objBeKillMain.toY = y;
				this.fRemove = CRes.random(4, 6);
				this.vMax = 5;
				this.xline = 10;
				this.yline = 20;
				this.create_Star_Line_In(this.vMax, this.xline, this.yline);
				this.objBeKillMain.isno = true;
				this.objBeKillMain.timeno = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
				break;
			}
			break;
		case 83:
		{
			this.isEff = true;
			this.fRemove = 60;
			int num = CRes.random(3);
			if (num == 0)
			{
				this.fraImgEff = new FrameImage(103);
			}
			else if (num == 1)
			{
				this.fraImgEff = new FrameImage(104);
			}
			else if (num == 2)
			{
				this.fraImgEff = new FrameImage(23);
			}
			this.toX = this.x;
			this.toY = this.y;
			this.x += CRes.random_Am(24, 48);
			this.y += CRes.random_Am(24, 48);
			this.createHut_Mp_Hp();
			break;
		}
		case 84:
			this.isEff = true;
			this.indexColorStar = CRes.random(2);
			this.x1000 = x * 1000;
			this.y1000 = y * 1000;
			this.fRemove = CRes.random(6, 8);
			this.vMax = 2;
			this.xline = 10;
			this.yline = 20;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline);
			break;
		case 85:
			this.timeRemove = timeRe * 1000;
			this.isEff = true;
			this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
			if (this.objBeKillMain == null || this.objBeKillMain.isRemove || this.objBeKillMain.isStop)
			{
				this.removeEff();
				return;
			}
			this.indexColorStar = CRes.random(2);
			this.x1000 = x;
			this.y1000 = y;
			this.fRemove = 5;
			break;
		case 86:
			this.fraImgEff = new FrameImage(30);
			this.fraImgSubEff = new FrameImage(31);
			this.fraImgSub2Eff = new FrameImage(40);
			this.isEff = true;
			for (int i = 0; i < (int)tem; i++)
			{
				this.vMax = CRes.random(5, 10);
				this.vx = this.vMax;
				Point o = this.create_Stone_Drop(MainScreen.cameraMain.xCam + 20 + CRes.random(GameCanvas.w * 5 / 4), MainScreen.cameraMain.yCam + 20 + CRes.random(GameCanvas.h * 5 / 4));
				this.VecEff.addElement(o);
			}
			break;
		case 87:
			this.fraImgEff = new FrameImage(11);
			this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
			if (this.objBeKillMain == null || this.objBeKillMain.isRemove || this.objBeKillMain.isStop)
			{
				this.removeEff();
				return;
			}
			x = this.objBeKillMain.x;
			y = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			this.isEff = true;
			this.fRemove = 10;
			break;
		case 94:
			this.nFrame = new sbyte[]
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
			};
			mSound.playSound(32, mSound.volumeSound);
			this.fraImgEff = new FrameImage(127);
			this.fraImgSubEff = new FrameImage(53);
			this.fRemove = 60;
			this.objBeKillMain = MainObject.get_Object((int)idGhost, tem);
			if (this.objBeKillMain == null)
			{
				return;
			}
			x = this.objBeKillMain.x;
			y = this.objBeKillMain.y;
			this.objBeKillMain.vx = 0;
			this.objBeKillMain.vy = 0;
			this.objBeKillMain.toX = x;
			this.objBeKillMain.toY = y;
			this.objBeKillMain.isBinded = true;
			if (timeRe == 0)
			{
				this.objBeKillMain.isBinded = false;
			}
			this.objBeKillMain.timeBind = mSystem.currentTimeMillis() + (long)(timeRe * 1000);
			LoadMap.timeVibrateScreen = 103;
			break;
		}
	}

	// Token: 0x0600027E RID: 638 RVA: 0x00014280 File Offset: 0x00012480
	public EffectSkill(MainObject obj, int type)
	{
		this.typeEffect = type;
		this.x = obj.x;
		this.y = obj.y;
		if (type == 14)
		{
			this.isEff = true;
			this.create_Fire_Arc();
		}
	}

	// Token: 0x06000280 RID: 640 RVA: 0x000153FC File Offset: 0x000135FC
	private void set_New_Effect(int typeKill, Object_Effect_Skill Okill, mVector vec)
	{
		if (vec == null || vec.size() == 0)
		{
			return;
		}
		this.vecObjBeKill = vec;
		this.indexSound = -1;
		this.f = -1;
		this.isPaint = true;
		this.ysai = 0;
		this.typeEffect = typeKill;
		this.time = GameCanvas.timeNow;
		this.objKill = MainObject.get_Object((int)Okill.ID, Okill.tem);
		Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjBeKill.elementAt(0);
		this.objBeKillMain = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
		this.isEff = false;
		if (this.objKill == null || this.objBeKillMain == null)
		{
			return;
		}
		if (this.typeEffect == 92 || this.typeEffect == 89)
		{
			this.x = this.objBeKillMain.x;
			this.y = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			this.toX = this.objKill.x;
			this.toY = this.objKill.y - this.objKill.hOne / 2;
		}
		else
		{
			this.x = this.objKill.x;
			this.y = this.objKill.y - this.objKill.hOne / 2;
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		if (this.typeEffect != 10 && this.typeEffect != 66 && this.typeEffect != 30 && this.typeEffect != 29 && this.typeEffect != 107)
		{
			this.Direction = EffectSkill.setDirection(this.objKill, this.objBeKillMain);
			this.objKill.Direction = this.Direction;
		}
		else
		{
			this.Direction = this.objKill.Direction;
		}
		this.timeAddNum = -1;
		if (this.typeEffect != 41 && this.objKill == GameScreen.player)
		{
			this.isEff = true;
		}
		if (!MainObject.isInScreen(this.objBeKillMain) && !MainObject.isInScreen(this.objKill))
		{
			this.isStop = true;
			return;
		}
		switch (typeKill)
		{
		case 0:
			this.fRemove = 60;
			switch (this.subType)
			{
			case 0:
				this.fraImgEff = new FrameImage(101);
				break;
			case 1:
				this.fraImgEff = new FrameImage(98);
				break;
			case 2:
				this.fraImgEff = new FrameImage(100);
				break;
			case 3:
				this.fraImgEff = new FrameImage(99);
				break;
			case 4:
				this.fraImgEff = new FrameImage(32);
				break;
			case 5:
				this.fraImgEff = new FrameImage(102);
				break;
			default:
				this.fraImgEff = new FrameImage(32);
				break;
			}
			this.vMax = 8000;
			this.createNormal();
			break;
		case 1:
		case 38:
		case 59:
		{
			this.vMax = 14;
			if (typeKill == 38)
			{
				if ((int)this.objKill.clazz == 2)
				{
					this.indexSound = 2;
				}
				else
				{
					this.indexSound = 1;
				}
			}
			if (typeKill == 1)
			{
				this.fraImgEff = new FrameImage(32);
			}
			if (typeKill == 59)
			{
				this.indexSound = 13;
				this.y += 10;
				this.fraImgEff = new FrameImage(17);
				this.fraImgSubEff = new FrameImage(24);
			}
			int xdich = this.toX - this.x;
			int ydich = this.toY - this.y;
			this.create_Speed(xdich, ydich, null);
			if (typeKill == 59)
			{
				this.timeAddNum = (sbyte)this.fRemove;
			}
			break;
		}
		case 6:
			this.isEff = true;
			this.create_Star();
			break;
		case 10:
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y;
			}
			this.fRemove = 10;
			this.timeAddNum = 7;
			this.createLighting(this.toX + CRes.random_Am_0(20), MainScreen.cameraMain.yCam - 5, this.toX, this.toY, true);
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(32);
			}
			GameScreen.addEffectEndKill(40, this.toX, this.toY + 10);
			break;
		case 11:
		case 108:
		case 114:
			this.indexSound = 5;
			if (this.typeEffect == 114)
			{
				this.fraImgEff = new FrameImage(24);
				this.fraImgSubEff = new FrameImage(7);
				this.fraImgSub2Eff = new FrameImage(9);
			}
			else
			{
				this.fraImgEff = new FrameImage(30);
				this.fraImgSubEff = new FrameImage(31);
				this.fraImgSub2Eff = new FrameImage(40);
			}
			this.vMax = 14;
			this.vx = this.vMax;
			for (int i = 0; i < this.vecObjBeKill.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(i);
				if (object_Effect_Skill2 != null)
				{
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					if (mainObject != null)
					{
						Point o = this.create_Stone_Drop(mainObject.x, mainObject.y);
						this.VecEff.addElement(o);
					}
				}
			}
			break;
		case 12:
			mSound.playSound(32, mSound.volumeSound);
			this.indexSound = 15;
			this.create_Crack_Earth();
			break;
		case 14:
		case 115:
			mSound.playSound(37, mSound.volumeSound);
			this.timeAddNum = 18;
			if (this.typeEffect == 14)
			{
				this.create_Fire_Arc();
			}
			else
			{
				this.create_Ice_Arc();
			}
			break;
		case 20:
		case 113:
			this.indexSound = 11;
			this.fraImgEff = new FrameImage(91);
			this.setBeginKill(5);
			if (this.objBeKillMain != null)
			{
				this.x1000 = this.objBeKillMain.x - 70;
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y;
			}
			else
			{
				this.x1000 = this.toX - 70;
			}
			this.y1000 = MainScreen.cameraMain.yCam - CRes.random(10, 20);
			this.vMax = 18;
			this.fRemove = 20;
			this.timeAddNum = 11;
			this.create_Arrow_Rain();
			break;
		case 21:
			if ((int)this.objKill.clazz == 0)
			{
				this.indexSound = 3;
			}
			else
			{
				this.indexSound = 0;
			}
			if (this.objBeKillMain != null)
			{
				this.x = this.objBeKillMain.x;
				this.y = this.objBeKillMain.y - this.objKill.hOne / 2;
			}
			else
			{
				this.x = this.toX;
				this.y = this.toY;
			}
			this.frame = CRes.random(4);
			do
			{
				this.frameArrow = CRes.random(4);
			}
			while (this.frame == this.frameArrow);
			this.fraImgEff = new FrameImage(118 + this.frame);
			this.fraImgSubEff = new FrameImage(118 + this.frameArrow);
			this.fRemove = 6;
			break;
		case 22:
		case 31:
			this.create_Sung_LV2_LV4();
			break;
		case 23:
			this.indexSound = 12;
			this.create_Sung_Lv3();
			break;
		case 25:
			this.indexSound = 13;
			this.create_PS_LV2_3_5();
			break;
		case 26:
			this.indexSound = 5;
			this.create_Kiem_Lv3();
			break;
		case 27:
			this.create_Kill_2Kiem_Lv2();
			break;
		case 28:
			this.indexSound = 4;
			this.create_Kiem_Lv2();
			break;
		case 29:
			this.isEff = true;
			if (this.objKill != null)
			{
				this.indexColorStar = (((int)this.objKill.clazz != 1) ? 0 : 1);
			}
			else
			{
				this.indexColorStar = 0;
			}
			this.setPosLineIn(this.subType);
			this.x1000 = this.x * 1000;
			if (this.objKill != null)
			{
				this.y1000 = (this.y - this.objKill.hOne / 2) * 1000;
			}
			else
			{
				this.y1000 = this.toY * 1000;
			}
			this.fRemove = 2;
			this.vMax = 5;
			this.xline = 10;
			this.yline = 20;
			this.create_Star_Line_In(this.vMax, this.xline, this.yline);
			break;
		case 30:
			this.isEff = true;
			this.setPosLineIn(this.subType);
			this.x1000 = this.x * 1000;
			this.y1000 = (this.y - this.objKill.hOne / 2) * 1000;
			if ((int)this.objKill.clazz == 3)
			{
				this.fraImgEff = new FrameImage(6);
			}
			else
			{
				this.fraImgEff = new FrameImage(10);
			}
			this.fRemove = 5;
			this.create_Star_Point_In();
			break;
		case 34:
			this.fraImgEff = new FrameImage(33);
			this.fraImgSubEff = new FrameImage(18);
			this.fRemove = 57;
			if (this.objKill == null || this.objBeKillMain == null)
			{
				this.isRemove = true;
				return;
			}
			this.objKill.isTanHinh = true;
			this.objKill.timeTanHinh = 0;
			if (this.objKill.isMainChar())
			{
				GameScreen.player.lastX = GameScreen.player.x;
				GameScreen.player.lastY = GameScreen.player.y;
			}
			this.create_2Kiem_Lv4(0, this.objBeKillMain);
			this.indexLan = 1;
			break;
		case 40:
			this.indexSound = 10;
			this.create_2Kiem_Lv5();
			break;
		case 41:
			this.fRemove = 60;
			if (this.subType == 0)
			{
				this.fraImgEff = new FrameImage(103);
			}
			else
			{
				this.fraImgEff = new FrameImage(104);
			}
			this.vMax = 12000;
			this.createXP();
			break;
		case 42:
			this.isEff = true;
			this.indexSound = 26;
			this.create_Level_up();
			break;
		case 43:
			this.isEff = true;
			this.fraImgEff = new FrameImage(50);
			this.fRemove = 11;
			this.y += this.objKill.hOne / 2;
			for (int j = 0; j < 10; j++)
			{
				Point point = new Point();
				int a = CRes.random(0, 180);
				point.x = 17 * CRes.cos(a) / 1000;
				point.y = 15 * CRes.sin(a) / 1000 - 5;
				point.fRe = CRes.random(2);
				point.frame = CRes.random(4);
				point.limitY = 60;
				this.VecEff.addElement(point);
			}
			break;
		case 46:
			this.indexSound = 7;
			this.fraImgEff = new FrameImage(70);
			this.fraImgSubEff = new FrameImage(72);
			this.fRemove = 15;
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y;
			}
			break;
		case 47:
		case 112:
			this.indexSound = 8;
			this.create_2Kiem_GaiDoc();
			break;
		case 49:
			this.indexSound = 14;
			this.fraImgEff = new FrameImage(23);
			this.fraImgSubEff = new FrameImage(24);
			this.create_PS_Xungkich();
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			}
			break;
		case 50:
			this.create_Monster();
			if (this.objBeKillMain != null && (int)this.objBeKillMain.typeObject == 9)
			{
				this.indexSound = 25;
			}
			break;
		case 51:
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(59);
			this.fRemove = 16;
			this.y += 7;
			this.setBeginKill(10);
			break;
		case 52:
		case 54:
			if (typeKill == 52)
			{
				this.indexSound = 4;
			}
			else if (typeKill == 54)
			{
				this.indexSound = 5;
			}
			this.fraImgEff = new FrameImage(83);
			this.fraImgSubEff = new FrameImage(68);
			this.fRemove = 15;
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y;
			}
			break;
		case 53:
		case 78:
		case 104:
			if (typeKill == 53)
			{
				this.indexSound = 6;
				this.fraImgEff = new FrameImage(85);
			}
			else if (typeKill == 78 || typeKill == 104)
			{
				mSound.playSound(32, mSound.volumeSound);
				this.fraImgEff = new FrameImage(117);
				if (typeKill == 104)
				{
					this.objBeKillMain.jum();
				}
			}
			this.fraImgSubEff = new FrameImage(53);
			this.fRemove = 20;
			for (int k = 0; k < this.vecObjBeKill.size(); k++)
			{
				Point point2 = new Point();
				Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(k);
				if (object_Effect_Skill3 != null)
				{
					MainObject mainObject2 = MainObject.get_Item_Object((int)object_Effect_Skill3.ID, (int)object_Effect_Skill3.tem);
					if (mainObject2 != null)
					{
						point2.x = mainObject2.x;
						point2.y = mainObject2.y + mainObject2.ysai;
						this.VecEff.addElement(point2);
					}
				}
			}
			break;
		case 55:
			this.indexSound = 7;
			this.fraImgEff = new FrameImage(51);
			this.fRemove = 12;
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			}
			this.timeAddNum = 5;
			break;
		case 56:
			if (this.subType == 10)
			{
				this.fraImgEff = new FrameImage(29);
			}
			else
			{
				this.fraImgEff = new FrameImage(22);
			}
			this.y = this.objKill.y;
			this.fRemove = 6;
			this.isEff = true;
			break;
		case 57:
			if ((int)this.objKill.clazz == 2 || (int)this.objKill.clazz == 3)
			{
				this.indexSound = 30;
			}
			else
			{
				this.indexSound = 31;
			}
			this.isEff = true;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			this.create_Buff_Point_In();
			break;
		case 58:
			mSound.playSound(45, mSound.volumeSound);
			this.isEff = true;
			this.y = this.objKill.y + this.objKill.ysai;
			this.fraImgEff = new FrameImage(65);
			this.fraImgSubEff = new FrameImage(94);
			this.fRemove = 8;
			break;
		case 60:
			this.indexSound = 16;
			LoadMap.timeVibrateScreen = 16;
			for (int l = 0; l < this.vecObjBeKill.size(); l++)
			{
				Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(l);
				if (object_Effect_Skill4 != null)
				{
					MainObject mainObject3 = MainObject.get_Object((int)object_Effect_Skill4.ID, object_Effect_Skill4.tem);
					if (mainObject3 != null)
					{
						Point point3 = new Point();
						point3.x = mainObject3.x;
						point3.y = mainObject3.y + mainObject3.ysai;
						this.VecEff.addElement(point3);
					}
				}
			}
			this.fRemove = 20;
			break;
		case 61:
		case 77:
			if (typeKill == 61)
			{
				if (this.vecObjBeKill.size() > 1)
				{
					this.indexSound = 16;
				}
				else
				{
					this.indexSound = 15;
				}
				this.fraImgEff = new FrameImage(71);
				this.fraImgSubEff = new FrameImage(5);
				this.fraImgSub2Eff = new FrameImage(92);
			}
			else if (typeKill == 77)
			{
				this.fraImgEff = new FrameImage(114);
				this.fraImgSubEff = new FrameImage(116);
				this.fraImgSub2Eff = new FrameImage(115);
			}
			this.vMax = 22;
			this.vx = this.vMax;
			for (int m = 0; m < this.vecObjBeKill.size(); m++)
			{
				Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(m);
				if (object_Effect_Skill5 != null)
				{
					MainObject mainObject4 = MainObject.get_Object((int)object_Effect_Skill5.ID, object_Effect_Skill5.tem);
					if (mainObject4 != null)
					{
						Point point4 = this.create_ICE_Drop(mainObject4.x, mainObject4.y);
						point4.dis = CRes.random(2);
						point4.vecEffPoint = new mVector("EffectSkill vecEffPoint");
						int num = CRes.random(3, 7);
						for (int n = 0; n < num; n++)
						{
							Point point5 = new Point();
							point5.x = point4.x + CRes.random_Am_0(20);
							point5.y = point4.y - 10 - CRes.random(35);
							point5.dis = 0;
							if (CRes.random(6) == 0)
							{
								point5.dis = 1;
							}
							else
							{
								point5.frame = CRes.random(4);
							}
							point4.vecEffPoint.addElement(point5);
						}
						this.VecEff.addElement(point4);
					}
				}
			}
			break;
		case 62:
			this.indexSound = 20;
			this.y += 5;
			this.fRemove = 20;
			this.timeAddNum = 10;
			this.fraImgEff = new FrameImage(47);
			this.vMax = 22;
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			}
			break;
		case 63:
			this.y += 8;
			this.fraImgEff = new FrameImage(74);
			if (this.objBeKillMain != null)
			{
				this.toX = this.objBeKillMain.x;
				this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			}
			this.fRemove = 20;
			this.timeAddNum = 10;
			this.vMax = 16;
			break;
		case 64:
			this.indexSound = 14;
			this.f = -1;
			this.fraImgEff = new FrameImage(95);
			this.fraImgSubEff = new FrameImage(53);
			this.fRemove = 20;
			for (int num2 = 0; num2 < this.vecObjBeKill.size(); num2++)
			{
				Point point6 = new Point();
				Object_Effect_Skill object_Effect_Skill6 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num2);
				if (object_Effect_Skill6 != null)
				{
					MainObject mainObject5 = MainObject.get_Item_Object((int)object_Effect_Skill6.ID, (int)object_Effect_Skill6.tem);
					if (mainObject5 != null)
					{
						point6.x = mainObject5.x;
						point6.y = mainObject5.y + mainObject5.ysai;
						this.VecEff.addElement(point6);
					}
				}
			}
			break;
		case 65:
			this.indexSound = 23;
			this.fRemove = 2;
			this.isEff = true;
			break;
		case 66:
			this.indexSound = 22;
			this.objKill.Direction = 1;
			this.fRemove = 2;
			this.isEff = true;
			break;
		case 67:
		{
			this.isEff = false;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(6);
			this.x1000 = this.x;
			this.y1000 = this.y;
			this.vMax = 18;
			int xdich;
			int ydich;
			if (this.objBeKillMain != null)
			{
				xdich = this.objBeKillMain.x - this.x;
				ydich = this.objBeKillMain.y - this.objBeKillMain.hOne / 2 - this.y;
			}
			else
			{
				xdich = this.toX - this.x;
				ydich = this.toY - this.y;
			}
			this.create_Speed(xdich, ydich, null);
			break;
		}
		case 68:
			this.timeAddNum = 20;
			this.isEff = true;
			if (this.subType == 0)
			{
				this.fraImgEff = new FrameImage(111);
				this.fRemove = 6;
			}
			else if (this.subType == 1)
			{
				this.fraImgEff = new FrameImage(112);
				this.fRemove = 8;
			}
			break;
		case 69:
			this.fRemove = 16;
			this.isEff = true;
			this.fraImgEff = new FrameImage(9);
			this.vx = CRes.random_Am_0(2);
			this.vy = -2;
			this.y -= CRes.random(this.objKill.hOne / 2);
			break;
		case 70:
			this.isEff = true;
			this.x1000 = this.x * 1000;
			this.y1000 = this.y * 1000;
			if (this.subType >= 28)
			{
				this.subType -= 28;
			}
			this.create_Mon_Buff();
			break;
		case 71:
		case 75:
			if (typeKill == 71)
			{
				mSound.playSound(32, mSound.volumeSound);
				this.fraImgEff = new FrameImage(36);
				this.fraImgSubEff = new FrameImage(53);
			}
			else
			{
				mSound.playSound(35, mSound.volumeSound);
				this.fraImgEff = new FrameImage(61);
			}
			this.fRemove = 16;
			for (int num3 = 0; num3 < this.vecObjBeKill.size(); num3++)
			{
				Point point7 = new Point();
				Object_Effect_Skill object_Effect_Skill7 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num3);
				if (object_Effect_Skill7 != null)
				{
					MainObject mainObject6 = MainObject.get_Item_Object((int)object_Effect_Skill7.ID, (int)object_Effect_Skill7.tem);
					if (mainObject6 != null)
					{
						point7.x = mainObject6.x;
						point7.y = mainObject6.y + mainObject6.ysai;
						this.VecEff.addElement(point7);
					}
				}
			}
			break;
		case 72:
		case 74:
			this.vMax = 14;
			if (typeKill == 72)
			{
				mSound.playSound(34, mSound.volumeSound);
				this.fraImgEff = new FrameImage(45);
				this.fraImgSubEff = new FrameImage(37);
			}
			else if (typeKill == 74)
			{
				mSound.playSound(34, mSound.volumeSound);
				this.fraImgEff = new FrameImage(63);
			}
			for (int num4 = 0; num4 < this.vecObjBeKill.size(); num4++)
			{
				Object_Effect_Skill object_Effect_Skill8 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num4);
				if (object_Effect_Skill8 != null)
				{
					MainObject mainObject7 = MainObject.get_Item_Object((int)object_Effect_Skill8.ID, (int)object_Effect_Skill8.tem);
					if (mainObject7 != null)
					{
						int xdich = mainObject7.x - this.x;
						int ydich = mainObject7.y - mainObject7.hOne / 2 - this.y;
						Point_Focus point_Focus = new Point_Focus();
						point_Focus = this.create_Speed_More(xdich, ydich, point_Focus, mainObject7);
						point_Focus.x = this.x;
						point_Focus.y = this.y;
						int frameAngle = CRes.angle(xdich, ydich);
						point_Focus.frame = this.setFrameAngle(frameAngle);
						this.VecEff.addElement(point_Focus);
					}
				}
			}
			this.fRemove = 10;
			break;
		case 73:
			this.y += 8;
			if (typeKill == 73)
			{
				mSound.playSound(34, mSound.volumeSound);
				this.fraImgEff = new FrameImage(48);
				this.fraImgSubEff = new FrameImage(38);
			}
			this.vMax = 20;
			this.fRemove = 40;
			break;
		case 76:
			mSound.playSound(36, mSound.volumeSound);
			this.levelPaint = -1;
			this.fraImgSubEff = new FrameImage(113);
			this.fraImgEff = new FrameImage(81);
			this.fRemove = 20;
			this.timeAddNum = 13;
			this.vMax = 8;
			for (int num5 = 0; num5 < 16; num5++)
			{
				Point point8 = new Point();
				point8.x = this.x * 1000;
				point8.y = this.y * 1000;
				point8.vx = CRes.cos(225 * num5 / 10) * this.vMax;
				point8.vy = CRes.sin(225 * num5 / 10) * this.vMax;
				point8.f = 0;
				this.VecEff.addElement(point8);
			}
			break;
		case 79:
			this.fRemove = 1;
			this.isEff = true;
			break;
		case 82:
		case 111:
		{
			this.indexSound = 21;
			int a2 = CRes.angle(this.toX - this.x, this.toY - this.y);
			int num6 = CRes.abs(MainObject.getDistance(this.x, this.y, this.toX, this.toY)) + 30;
			this.x1000 = this.x + CRes.cos(a2) * num6 / 1000;
			this.y1000 = this.y + CRes.sin(a2) * num6 / 1000;
			this.fRemove = 10;
			this.timeAddNum = 7;
			this.setBeginKill(0);
			this.createLighting(this.x, this.y - this.hOne / 2, this.x1000, this.y1000, true);
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			GameScreen.addEffectEndKill(40, this.x1000, this.y1000 + 10);
			break;
		}
		case 88:
			this.fRemove = 60;
			this.fraImgEff = new FrameImage(97);
			this.fraImgSubEff = new FrameImage(9);
			this.vMax = 8000;
			this.createDanFocus();
			this.frame = this.setFrameAngle(this.gocT_Arc);
			break;
		case 89:
			this.fRemove = 60;
			this.fraImgEff = new FrameImage(10);
			this.fraImgSubEff = new FrameImage(10);
			this.vMax = 8000;
			this.createDanFocus();
			this.frame = this.setFrameAngle(this.gocT_Arc);
			break;
		case 90:
			this.timeAddNum = 18;
			this.create_Nova();
			if (this.objBeKillMain != null && (int)this.objBeKillMain.typeObject == 9)
			{
				this.indexSound = 36;
			}
			break;
		case 91:
			this.timeAddNum = 18;
			this.create_Poison_Nova();
			if (this.objBeKillMain != null && (int)this.objBeKillMain.typeObject == 9)
			{
				this.indexSound = 36;
			}
			break;
		case 92:
			this.fRemove = 60;
			this.fraImgEff = new FrameImage(141);
			this.fraImgSubEff = new FrameImage(141);
			this.vMax = 8000;
			this.createDanFocus();
			this.frame = this.setFrameAngle(this.gocT_Arc);
			break;
		case 93:
			mSound.playSound(34, mSound.volumeSound);
			this.fraImgEff = new FrameImage(63);
			this.fraImgSubEff = new FrameImage(107);
			this.fRemove = 60;
			for (int num7 = 0; num7 < this.vecObjBeKill.size(); num7++)
			{
				Point point9 = new Point();
				Object_Effect_Skill object_Effect_Skill9 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num7);
				if (object_Effect_Skill9 != null)
				{
					MainObject mainObject8 = MainObject.get_Item_Object((int)object_Effect_Skill9.ID, (int)object_Effect_Skill9.tem);
					if (mainObject8 != null)
					{
						point9.x = this.x;
						point9.y = this.y + this.ysai;
						this.VecEff.addElement(point9);
					}
				}
			}
			break;
		case 95:
		{
			this.indexSound = 21;
			int a3 = CRes.angle(this.toX - this.x, this.toY - this.y);
			int num8 = CRes.abs(MainObject.getDistance(this.x, this.y, this.toX, this.toY));
			this.x1000 = this.x + CRes.cos(a3) * num8 / 1000;
			this.y1000 = this.y + CRes.sin(a3) * num8 / 1000;
			this.fRemove = 10;
			this.timeAddNum = 7;
			this.setBeginKill(0);
			this.dxTower = 0;
			this.dyTower = 50;
			this.createLighting(this.x - this.dxTower, this.y - this.hOne / 2 - this.dyTower, this.x1000, this.y1000, true);
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(32, mSound.volumeSound);
			}
			GameScreen.addEffectEndKill(40, this.x1000, this.y1000 + 20);
			break;
		}
		case 96:
			this.fRemove = 60;
			this.fraImgEff = new FrameImage(132);
			this.fraImgSubEff = new FrameImage(9);
			this.vMax = 8000;
			this.createDanFocus();
			this.frame = this.setFrameAngle(this.gocT_Arc);
			mSound.playSound(57, mSound.volumeSound);
			this.dxTower = 4;
			this.dyTower = -50;
			this.x += this.dxTower;
			this.y += this.dyTower;
			break;
		case 97:
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(59);
			this.fRemove = 16;
			this.dxTower = 0;
			this.dyTower = -86;
			this.x += this.dxTower;
			this.y += this.dyTower;
			break;
		case 98:
			this.create_FireBall_Tower();
			break;
		case 99:
			if (this.objKill.Direction == 3)
			{
				this.dxTower = -10;
				this.dyTower = -20;
			}
			else
			{
				this.dxTower = 10;
				this.dyTower = -20;
			}
			this.create_Sung_Medusa();
			GameScreen.addEffectEndKill(48, this.objKill.x + this.dxTower, this.objKill.y + this.dyTower);
			break;
		case 105:
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(60);
			this.fRemove = 16;
			this.y -= 12;
			this.setBeginKill(10);
			break;
		case 106:
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(59);
			this.fRemove = 16;
			this.R = 240;
			this.y -= 15;
			this.x -= 6;
			this.angle = 0;
			this.size1 = 4;
			this.setBeginKill(10);
			break;
		case 109:
		case 110:
		{
			this.indexSound = 16;
			this.indexSound = 14;
			this.f = 0;
			if (this.typeEffect == 109)
			{
				this.fraImgEff = new FrameImage(92);
			}
			else
			{
				this.fraImgEff = new FrameImage(115);
			}
			int num9 = (int)((short)(this.toX - this.x));
			int num10 = (int)((short)(this.toY - this.y));
			this.angle = (int)((short)CRes.angle(num9, num10));
			int num11 = (global::Math.abs(num9) + global::Math.abs(num10)) / 20;
			if (num11 < 2)
			{
				num11 = 2;
			}
			for (int num12 = 0; num12 < num11; num12++)
			{
				Point point10 = new Point();
				point10.x = this.x + num12 * num9 / num11;
				point10.y = this.y + num12 * num10 / num11;
				this.VecEff.addElement(point10);
			}
			break;
		}
		case 125:
			this.y = this.objKill.y - 100;
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(59);
			this.fRemove = 16;
			this.R = 240;
			this.angle = 0;
			this.size1 = 4;
			break;
		case 126:
			this.y = this.objKill.y - 120;
			this.x -= 12;
			this.timeAddNum = 3;
			this.fraImgEff = new FrameImage(21);
			this.fraImgSubEff = new FrameImage(59);
			this.fRemove = 16;
			this.R = 240;
			this.angle = 0;
			this.size1 = 4;
			break;
		}
		if (!this.isEff && this.objKill != null && (int)this.objKill.typeObject != 1)
		{
			for (int num13 = 0; num13 < this.vecObjBeKill.size(); num13++)
			{
				Object_Effect_Skill object_Effect_Skill10 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num13);
				if (object_Effect_Skill10 == null)
				{
					this.vecObjBeKill.removeElement(object_Effect_Skill10);
					num13--;
				}
				else
				{
					MainObject mainObject9 = MainObject.get_Object((int)object_Effect_Skill10.ID, object_Effect_Skill10.tem);
					if (mainObject9 == null)
					{
						this.vecObjBeKill.removeElement(object_Effect_Skill10);
						num13--;
					}
					else if (mainObject9.Action != 4)
					{
						mainObject9.hp = object_Effect_Skill10.hpLast;
						if (mainObject9.hp <= 0 && mainObject9 != GameScreen.player)
						{
							mainObject9.resetAction();
							mainObject9.Action = 4;
							mainObject9.timedie = GameCanvas.timeNow;
							GameScreen.addEffectEndKill(11, mainObject9.x, mainObject9.y);
						}
					}
					if (this.vecObjBeKill.size() == 0)
					{
						this.isStop = true;
					}
				}
			}
		}
		if (this.indexSound >= 0)
		{
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(this.indexSound);
			}
		}
	}

	// Token: 0x06000281 RID: 641 RVA: 0x00017870 File Offset: 0x00015A70
	public override void paint(mGraphics g)
	{
		if (mSystem.isj2me && !this.ispaintArena)
		{
			return;
		}
		try
		{
			this.test = 10;
			if (this.isRemove)
			{
				return;
			}
			switch (this.typeEffect)
			{
			case 0:
			case 1:
			case 59:
			case 80:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < this.fRemove)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				else
				{
					this.fraImgSubEff.drawFrameEffectSkill((this.f - this.fRemove) / 2 % this.fraImgSubEff.nFrame, this.toX, this.toY, 0, 3, g);
				}
				break;
			case 6:
				if (GameCanvas.gameTick % 2 == 0 && this.mTamgiac != null && this.mTamgiac.Length > 0)
				{
					for (int i = 0; i < this.mTamgiac.Length; i++)
					{
						g.setColor(this.colorpaint[i / 2]);
						g.fillTriangle(this.x1000 / 1000, this.y1000 / 1000, this.mTamgiac[i][0] / 1000, this.mTamgiac[i][1] / 1000, this.mTamgiac[i][2] / 1000, this.mTamgiac[i][3] / 1000, mGraphics.isFalse);
					}
				}
				break;
			case 10:
			case 82:
			{
				mVector mVector = new mVector();
				if (this.f % 5 < 2 || this.f % 5 == 3)
				{
					for (int j = 1; j < this.VecEff.size(); j++)
					{
						Point point = (Point)this.VecEff.elementAt(j - 1);
						Point point2 = (Point)this.VecEff.elementAt(j);
						mVector.addElement(new mLine(point.x / 1000, point.y / 1000 - 1, point2.x / 1000, point2.y / 1000 - 1, 15791864));
						mVector.addElement(new mLine(point.x / 1000, point.y / 1000 + 1, point2.x / 1000, point2.y / 1000 + 1, 15791864));
						mVector.addElement(new mLine(point.x / 1000, point.y / 1000 + 2, point2.x / 1000, point2.y / 1000 + 2, 15791864));
						mVector.addElement(new mLine(point.x / 1000, point.y / 1000, point2.x / 1000, point2.y / 1000, 11068406));
					}
					for (int k = 1; k < this.VecSubEff.size(); k++)
					{
						Point point3 = (Point)this.VecSubEff.elementAt(k - 1);
						Point point4 = (Point)this.VecSubEff.elementAt(k);
						if (point4.x != -1 && point3.x != -1)
						{
							mVector.addElement(new mLine(point3.x / 1000, point3.y / 1000, point4.x / 1000, point4.y / 1000, 15791864));
							mVector.addElement(new mLine(point3.x / 1000, point3.y / 1000 + 1, point4.x / 1000, point4.y / 1000 + 1, 15791864));
						}
					}
				}
				g.totalLine = mVector;
				g.drawlineGL();
				break;
			}
			case 11:
			case 86:
			case 108:
			case 114:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int l = 0; l < this.VecSubEff.size(); l++)
				{
					Point point5 = (Point)this.VecSubEff.elementAt(l);
					if (point5.f / 2 <= 3)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point5.f / 2, point5.x, point5.y, 0, 3, g);
					}
				}
				for (int m = 0; m < this.VecEff.size(); m++)
				{
					Point point6 = (Point)this.VecEff.elementAt(m);
					if (this.f < point6.f)
					{
						this.fraImgSub2Eff.drawFrameEffectSkill(CRes.random(2), point6.x - 10, point6.y + point6.vy * this.f / 1000 - 13, 0, 3, g);
						this.fraImgEff.drawFrameEffectSkill(point6.v / 2 % this.fraImgEff.nFrame, point6.x, point6.y + point6.vy * this.f / 1000, 0, 3, g);
					}
				}
				break;
			case 12:
				if (this.fRemove < -1)
				{
					this.fRemove = -1;
				}
				if (this.fRemove != 0)
				{
					mVector mVector2 = new mVector();
					int num = this.VecEff.size() / this.fRemove + 2;
					int num2 = num * this.f;
					if (num2 > this.VecEff.size())
					{
						num2 = this.VecEff.size();
					}
					for (int n = 1; n < num2; n++)
					{
						Point point7 = (Point)this.VecEff.elementAt(n - 1);
						Point point8 = (Point)this.VecEff.elementAt(n);
						if (this.f <= this.fRemove - 1)
						{
							mVector2.addElement(new mLine(point7.x / 1000 - this.xline, point7.y / 1000 - this.yline, point8.x / 1000 - this.xline, point8.y / 1000 - this.yline, 0));
							mVector2.addElement(new mLine(point7.x / 1000 + this.xline, point7.y / 1000 + this.yline, point8.x / 1000 + this.xline, point8.y / 1000 + this.yline, 0));
						}
						if (this.f <= this.fRemove - 2)
						{
							mVector2.addElement(new mLine(point7.x / 1000 + 2 * this.xline, point7.y / 1000 + 2 * this.yline, point8.x / 1000 + 2 * this.xline, point8.y / 1000 + 2 * this.yline, 0));
						}
						mVector2.addElement(new mLine(point7.x / 1000, point7.y / 1000, point8.x / 1000, point8.y / 1000, 4140567));
					}
					if (this.f <= this.fRemove - 2)
					{
						num = this.VecSubEff.size() / this.fRemove + 2;
						num2 = num * this.f;
						if (num2 > this.VecSubEff.size())
						{
							num2 = this.VecSubEff.size();
						}
						for (int num3 = 1; num3 < num2; num3++)
						{
							Point point9 = (Point)this.VecSubEff.elementAt(num3 - 1);
							Point point10 = (Point)this.VecSubEff.elementAt(num3);
							if (point10.x != -1 && point9.x != -1)
							{
								mVector2.addElement(new mLine(point9.x / 1000, point9.y / 1000, point10.x / 1000, point10.y / 1000, 0));
								mVector2.addElement(new mLine(point9.x / 1000 + this.xline, point9.y / 1000 + this.yline, point10.x / 1000 + this.xline, point10.y / 1000 + this.yline, 0));
							}
						}
					}
					g.totalLine = mVector2;
					g.drawlineGL();
				}
				break;
			case 14:
			case 81:
			case 115:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num4 = 0; num4 < this.VecEff.size(); num4++)
				{
					Point point11 = (Point)this.VecEff.elementAt(num4);
					if (point11.f == 0)
					{
						this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, point11.x / 1000, point11.y / 1000, 0, 3, g);
					}
					else if (point11.f > 0)
					{
						this.fraImgSubEff.drawFrameEffectSkill((point11.f - 1) / 2 % this.fraImgSubEff.nFrame, point11.x / 1000, point11.y / 1000 - 4 - point11.f, 0, 3, g);
					}
				}
				break;
			case 20:
			case 113:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				mVector mVector3 = new mVector();
				for (int num5 = 0; num5 < this.VecEff.size(); num5++)
				{
					Point point12 = (Point)this.VecEff.elementAt(num5);
					if (point12 != null && !point12.isRemove)
					{
						if (point12.dis == 0)
						{
							if (this.typeEffect == 20)
							{
								mVector3.addElement(new mLine(point12.x, point12.y, point12.x + 6, point12.y + 8, 11453204));
								mVector3.addElement(new mLine(point12.x, point12.y, point12.x + 5, point12.y + 8, 11453204));
							}
							else
							{
								mVector3.addElement(new mLine(point12.x, point12.y, point12.x + 6, point12.y + 8, 10549488));
								mVector3.addElement(new mLine(point12.x, point12.y, point12.x + 5, point12.y + 8, 10549488));
							}
						}
						else if (point12.dis == 1 && point12.f < 2 && this.typeEffect != 113)
						{
							this.fraImgEff.drawFrameEffectSkill1(point12.f, point12.x, point12.y - point12.vy / 2, 0, g);
						}
					}
				}
				g.totalLine = mVector3;
				g.drawlineGL();
				break;
			}
			case 21:
				if (this.fraImgEff == null)
				{
					return;
				}
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % 3, this.x, this.y, 0, 3, g);
				this.fraImgSubEff.drawFrameEffectSkill(this.f / 2 % 3, this.x, this.y, 0, 3, g);
				break;
			case 22:
			case 31:
			case 88:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.typeEffect == 31 || this.typeEffect == 88)
				{
					for (int num6 = 0; num6 < this.VecEff.size(); num6++)
					{
						Point point13 = (Point)this.VecEff.elementAt(num6);
						this.fraImgSubEff.drawFrameEffectSkill(point13.f / 2 % this.fraImgSubEff.nFrame, point13.x, point13.y, this.frameArrow, 3, g);
					}
				}
				if (this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 23:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num7 = 0; num7 < this.VecEff.size(); num7++)
				{
					Point point14 = (Point)this.VecEff.elementAt(num7);
					this.paint_Bullet(g, this.fraImgEff, this.frame, point14.x, point14.y, false);
				}
				break;
			case 25:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num8 = 0; num8 < this.VecEff.size(); num8++)
				{
					Point point15 = (Point)this.VecEff.elementAt(num8);
					if (point15 != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point15.f % this.fraImgSubEff.nFrame, point15.x, point15.y, this.frameArrow, 3, g);
					}
				}
				if (this.typeEffect == 25 && this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 26:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num9 = 0; num9 < this.VecEff.size(); num9++)
				{
					Point point16 = (Point)this.VecEff.elementAt(num9);
					if (point16.f < 7)
					{
						this.fraImgEff.drawFrameEffectSkill(point16.f / 2 % this.fraImgEff.nFrame, point16.x, point16.y, 0, 3, g);
					}
				}
				if (this.f >= this.fRemove && this.f <= this.fRemove + 5)
				{
					this.fraImgSubEff.drawFrameEffectSkill((this.f - this.fRemove) / 2 % this.fraImgSubEff.nFrame, this.toX, this.toY - 5, 0, 3, g);
				}
				break;
			case 27:
				for (int num10 = 0; num10 < this.VecEff.size(); num10++)
				{
					Point point17 = (Point)this.VecEff.elementAt(num10);
					if (point17.f < 3)
					{
						this.fraImgEff.drawFrameEffectSkill(point17.f % this.fraImgEff.nFrame, point17.x, point17.y, 0, 3, g);
					}
				}
				break;
			case 28:
				if (this.fraImgEff == null)
				{
					return;
				}
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y - this.fraImgEff.frameHeight, 0, mGraphics.TOP | mGraphics.HCENTER, g);
				break;
			case 29:
			case 84:
			case 107:
			{
				mVector mVector4 = new mVector();
				for (int num11 = 0; num11 < this.VecEff.size(); num11++)
				{
					Line line = (Line)this.VecEff.elementAt(num11);
					if (line != null)
					{
						int cl = 0;
						if (num11 / 2 < this.colorpaint.Length)
						{
							cl = this.colorpaint[num11 / 2];
						}
						mVector4.addElement(new mLine(line.x0 / 1000, line.y0 / 1000, line.x1 / 1000, line.y1 / 1000, cl));
						if (line.is2Line)
						{
							mVector4.addElement(new mLine(line.x0 / 1000 + 1, line.y0 / 1000, line.x1 / 1000 + 1, line.y1 / 1000, cl));
						}
					}
				}
				g.totalLine = mVector4;
				g.drawlineGL();
				break;
			}
			case 30:
				for (int num12 = 0; num12 < this.VecEff.size(); num12++)
				{
					Point point18 = (Point)this.VecEff.elementAt(num12);
					if (point18 != null)
					{
						if (point18.f < 5)
						{
							if (point18.f < 4)
							{
								this.fraImgEff.drawFrameEffectSkill(point18.f % this.fraImgEff.nFrame, point18.x / 1000, point18.y / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
							}
							else
							{
								this.fraImgEff.drawFrameEffectSkill(3, point18.x / 1000, point18.y / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
							}
						}
					}
				}
				break;
			case 34:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num13 = 0; num13 < this.VecEff.size(); num13++)
				{
					Point point19 = (Point)this.VecEff.elementAt(num13);
					int trans = 0;
					if (point19.vx < 0)
					{
						trans = 2;
					}
					this.fraImgEff.drawFrameEffectSkill(point19.f % this.fraImgEff.nFrame, point19.x, point19.y, trans, 3, g);
					if (point19.f % 3 != 2 && this.objBeKillMain != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point19.f % this.fraImgSubEff.nFrame, this.objBeKillMain.x, this.objBeKillMain.y - this.objBeKillMain.hOne / 2, 0, 3, g);
					}
				}
				break;
			case 40:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num14 = 0; num14 < this.VecEff.size(); num14++)
				{
					Point point20 = (Point)this.VecEff.elementAt(num14);
					if (point20 != null)
					{
						int x = (point20.x + point20.vx) / 1000;
						int y = (point20.y + point20.vy) / 1000;
						if (this.f / 2 % 2 == 0)
						{
							this.paint_Bullet(g, this.fraImgEff, point20.frame, x, y, false);
						}
						else
						{
							this.paint_Bullet(g, this.fraImgSub2Eff, point20.frame, x, y, false);
						}
					}
				}
				for (int num15 = 0; num15 < this.VecSubEff.size(); num15++)
				{
					Point point21 = (Point)this.VecSubEff.elementAt(num15);
					this.fraImgSubEff.drawFrameEffectSkill(this.f % this.fraImgSubEff.nFrame, point21.x / 1000, point21.y / 1000, 0, 3, g);
				}
				break;
			case 41:
			case 83:
				for (int num16 = 0; num16 < this.VecEff.size(); num16++)
				{
					Point point22 = (Point)this.VecEff.elementAt(num16);
					this.fraImgEff.drawFrameEffectSkill(point22.f % this.fraImgEff.nFrame, point22.x, point22.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			case 42:
			{
				mVector mVector5 = new mVector();
				this.fraImgEff.drawFrameEffectSkill(this.f / 4 % this.fraImgEff.nFrame, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				if (this.f < this.fRemove / 2)
				{
					for (int num17 = 0; num17 < this.VecEff.size(); num17++)
					{
						Point point23 = (Point)this.VecEff.elementAt(num17);
						int cl2 = 16777215;
						if (point23.frame == 1)
						{
							cl2 = 9468112;
						}
						if (point23.fRe == 1)
						{
							mVector5.addElement(new mLine(this.x + point23.x, this.y + point23.y, this.x + point23.x, this.y + point23.y - point23.limitY, cl2));
						}
						if (point23.frame == 2)
						{
							mVector5.addElement(new mLine(this.x + point23.x + 1, this.y + point23.y, this.x + point23.x + 1, this.y + point23.y - point23.limitY, 9468112));
						}
					}
				}
				else
				{
					this.fraImgSubEff.drawFrameEffectSkill(0, this.x, this.y - 50 - (this.f - this.fRemove / 2) * 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				g.totalLine = mVector5;
				g.drawlineGL();
				break;
			}
			case 43:
			{
				mVector mVector6 = new mVector();
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y - 10, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				for (int num18 = 0; num18 < this.VecEff.size(); num18++)
				{
					Point point24 = (Point)this.VecEff.elementAt(num18);
					int cl3 = 16777215;
					if (point24.frame == 1)
					{
						cl3 = 9468112;
					}
					if (point24.fRe == 1)
					{
						mVector6.addElement(new mLine(this.x + point24.x, this.y + point24.y, this.x + point24.x, this.y + point24.y - point24.limitY, cl3));
					}
					if (point24.frame == 2)
					{
						mVector6.addElement(new mLine(this.x + point24.x + 1, this.y + point24.y, this.x + point24.x + 1, this.y + point24.y - point24.limitY, 9468112));
					}
				}
				g.totalLine = mVector6;
				g.drawlineGL();
				break;
			}
			case 46:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < 3)
				{
					if (this.objBeKillMain != null)
					{
						this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.toX, this.toY - this.objBeKillMain.hOne / 2, 0, 3, g);
					}
				}
				else
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2 % this.fraImgSubEff.nFrame, this.toX, this.toY + 5, (CRes.random(2) != 0) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 47:
				for (int num19 = 0; num19 < this.VecEff.size(); num19++)
				{
					Point point25 = (Point)this.VecEff.elementAt(num19);
					if (point25 != null)
					{
						if (this.f >= point25.fRe && this.f <= this.fRemove - 3 + point25.fRe)
						{
							this.fraImgEff.drawFrameEffectSkill(point25.frame, point25.x / 1000, point25.y / 1000, point25.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
							this.fraImgSubEff.drawFrameEffectSkill((this.f / 3 + point25.fRe) % this.fraImgSubEff.nFrame, point25.x / 1000, point25.y / 1000 + 4, point25.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			case 49:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < 6)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2, this.x1000, this.y1000, 0, 3, g);
				}
				for (int num20 = 0; num20 < this.VecEff.size(); num20++)
				{
					Point point26 = (Point)this.VecEff.elementAt(num20);
					this.fraImgEff.drawFrameEffectSkill(point26.f % this.fraImgEff.nFrame, point26.x, point26.y, 0, 3, g);
				}
				if (this.f >= this.fRemove && this.f < this.fRemove + 6)
				{
					this.fraImgSubEff.drawFrameEffectSkill((this.f - this.fRemove) / 2, this.toX, this.toY, 0, 3, g);
				}
				break;
			case 50:
				if (this.f < 3 && this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, this.frameArrow, this.frame, g);
				}
				break;
			case 51:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				mVector mVector7 = new mVector();
				if (this.f < this.fRemove)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
					if (this.f > 8)
					{
						int num21 = this.fRemove - this.f;
						if (num21 < 1)
						{
							num21 = 1;
						}
						for (int num22 = 0; num22 < num21; num22++)
						{
							int cl4;
							if (num22 == num21 - 1)
							{
								cl4 = 16711680;
							}
							else
							{
								cl4 = 16777215;
							}
							mVector7.addElement(new mLine(this.x + num22 * this.vX1000, this.y + num22 * this.vY1000, this.x1000 + num22 * this.vX1000, this.y1000 + num22 * this.vY1000, cl4));
							mVector7.addElement(new mLine(this.x - num22 * this.vX1000, this.y - num22 * this.vY1000, this.x1000 - num22 * this.vX1000, this.y1000 - num22 * this.vY1000, cl4));
						}
					}
				}
				for (int num23 = 0; num23 < this.VecEff.size(); num23++)
				{
					Point point27 = (Point)this.VecEff.elementAt(num23);
					if (point27 != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point27.f % this.fraImgSubEff.nFrame, point27.x, point27.y, 0, 3, g);
					}
				}
				g.totalLine = mVector7;
				g.drawlineGL();
				break;
			}
			case 52:
			case 54:
				if (this.fraImgEff == null)
				{
					return;
				}
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.toX, this.toY, (CRes.random(2) != 0) ? 2 : 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				for (int num24 = 0; num24 < this.VecEff.size(); num24++)
				{
					Point point28 = (Point)this.VecEff.elementAt(num24);
					this.fraImgSubEff.drawFrameEffectSkill(point28.f / 2 % this.fraImgSubEff.nFrame, point28.x, point28.y, 0, 3, g);
				}
				break;
			case 53:
			case 64:
			case 78:
			case 104:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num25 = 0; num25 < this.VecEff.size(); num25++)
				{
					Point point29 = (Point)this.VecEff.elementAt(num25);
					if (this.f <= this.fRemove)
					{
						int num26 = 3;
						int num27;
						if (this.f < 2)
						{
							num27 = this.f;
						}
						if (this.f > this.fRemove - 5)
						{
							num27 = this.fRemove - this.f;
							num26 = 5;
						}
						else
						{
							num27 = 2;
						}
						g.drawRegion(this.fraImgEff.imgFrame, 0, 0, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight / num26 * (num27 + 1), 0, point29.x, point29.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
						if (this.f < 3)
						{
							this.fraImgSubEff.drawFrameEffectSkill(this.f, point29.x, point29.y + 10, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			case 55:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < 6)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2, this.toX, this.toY, 0, 3, g);
				}
				mVector mVector8 = new mVector();
				for (int num28 = 0; num28 < this.VecEff.size(); num28++)
				{
					if (num28 < this.VecEff.size())
					{
						Line line2 = (Line)this.VecEff.elementAt(num28);
						int cl5 = 16777209;
						if (line2.idColor == 1)
						{
							cl5 = 16314560;
						}
						mVector8.addElement(new mLine(line2.x0, line2.y0, line2.x1, line2.y1, cl5));
						if (line2.is2Line)
						{
							mVector8.addElement(new mLine(line2.x0 + 1, line2.y0 - 1, line2.x1 + 1, line2.y1 - 1, 16310352));
						}
					}
				}
				g.totalLine = mVector8;
				g.drawlineGL();
				break;
			}
			case 56:
				if (this.subType == 10)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				else if (this.subType == 11)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 57:
			case 70:
			{
				mVector mVector9 = new mVector();
				for (int num29 = this.VecEff.size() - 1; num29 >= 0; num29--)
				{
					Line line3 = (Line)this.VecEff.elementAt(num29);
					if (line3 != null && line3.f < 6)
					{
						mVector9.addElement(new mLine(line3.x0 / 1000, line3.y0 / 1000, line3.x1 / 1000, line3.y1 / 1000, this.colorpaint[num29]));
						if (line3.is2Line)
						{
							mVector9.addElement(new mLine(line3.x0 / 1000 + 1, line3.y0 / 1000 + 1, line3.x1 / 1000 + 1, line3.y1 / 1000, this.colorpaint[num29]));
						}
					}
				}
				g.totalLine = mVector9;
				g.drawlineGL();
				break;
			}
			case 58:
				if (this.f < 2)
				{
					g.setColor(16777215);
					g.fillRect(this.x - 9, MainScreen.cameraMain.yCam, 18, (this.y - MainScreen.cameraMain.yCam) / 2 * (this.f + 1), mGraphics.isFalse);
					g.setColor(9468112);
					g.fillRect(this.x - 10, MainScreen.cameraMain.yCam, 2, (this.y - MainScreen.cameraMain.yCam) / 2 * (this.f + 1), mGraphics.isFalse);
					g.fillRect(this.x + 9, MainScreen.cameraMain.yCam, 2, (this.y - MainScreen.cameraMain.yCam) / 2 * (this.f + 1), mGraphics.isFalse);
				}
				else if (this.f < 8)
				{
					g.setColor(16777215);
					g.fillRect(this.x - 9 + (this.f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 18 - (this.f - 2) / 2 * 6, this.y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
					g.setColor(9468112);
					g.fillRect(this.x - 10 + (this.f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 2, this.y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
					g.fillRect(this.x + 9 - (this.f - 2) / 2 * 3, MainScreen.cameraMain.yCam, 2, this.y - MainScreen.cameraMain.yCam, mGraphics.isFalse);
				}
				if (this.f > 1 && this.f < 11)
				{
					this.fraImgEff.drawFrameEffectSkill(3 + (this.f - 2) / 3, this.x, this.y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num30 = 0; num30 < this.VecEff.size(); num30++)
				{
					Point point30 = (Point)this.VecEff.elementAt(num30);
					this.fraImgSubEff.drawFrameEffectSkill((this.f >= 8) ? 1 : 0, point30.x, point30.y + 4, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 61:
			case 77:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num31 = 0; num31 < this.VecEff.size(); num31++)
				{
					Point point31 = (Point)this.VecEff.elementAt(num31);
					if (this.f < point31.f)
					{
						for (int num32 = 0; num32 < point31.vecEffPoint.size(); num32++)
						{
							Point point32 = (Point)point31.vecEffPoint.elementAt(num32);
							if (point32.dis == 1)
							{
								this.fraImgSub2Eff.drawFrameEffectSkill(0, point32.x, point32.y + point31.vy * this.f / 1000, 0, 3, g);
							}
							else
							{
								this.fraImgSubEff.drawFrameEffectSkill(point32.frame, point32.x, point32.y + point31.vy * this.f / 1000, 0, 3, g);
							}
						}
						this.fraImgEff.drawFrameEffectSkill(point31.dis, point31.x, point31.y + point31.vy * this.f / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
				}
				break;
			case 62:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num33 = 0; num33 < this.VecEff.size(); num33++)
				{
					Point point33 = (Point)this.VecEff.elementAt(num33);
					if (point33.f > 0)
					{
						this.paint_Bullet(g, this.fraImgEff, point33.frame, point33.x, point33.y, false);
					}
				}
				break;
			case 63:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num34 = 0; num34 < this.VecEff.size(); num34++)
				{
					Point point34 = (Point)this.VecEff.elementAt(num34);
					if (point34.f > 0)
					{
						this.paint_Bullet(g, this.fraImgEff, point34.frame, point34.x, point34.y, false);
					}
				}
				break;
			case 67:
				if (this.fraImgEff == null)
				{
					return;
				}
				this.fraImgEff.drawFrameEffectSkill(this.f / 2, this.x1000, this.y1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				if (this.f < this.fRemove && this.fraImgSubEff != null)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f % this.fraImgSubEff.nFrame, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			case 68:
				if (this.f < this.fRemove)
				{
					if (this.subType == 0)
					{
						this.fraImgEff.drawFrameEffectSkill(this.f, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
					else
					{
						this.fraImgEff.drawFrameEffectSkill(this.f / 2, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
				}
				break;
			case 69:
				this.fraImgEff.drawFrameEffectSkill(this.f / 4 % this.fraImgEff.nFrame, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 71:
				if (this.f < 6)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2, this.x, this.y + this.objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num35 = 0; num35 < this.VecEff.size(); num35++)
				{
					Point point35 = (Point)this.VecEff.elementAt(num35);
					if (this.f <= this.fRemove)
					{
						int idx;
						if (this.f < 3)
						{
							idx = this.f;
						}
						else if (this.f > this.fRemove - 3)
						{
							idx = this.fRemove - this.f;
						}
						else
						{
							idx = CRes.random(2, 4);
						}
						this.fraImgEff.drawFrameEffectSkill(idx, point35.x, point35.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						if (this.f < 6)
						{
							this.fraImgSubEff.drawFrameEffectSkill(this.f / 2, point35.x, point35.y + 10, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			case 72:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < this.fRemove)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2 % this.fraImgSubEff.nFrame, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num36 = 0; num36 < this.VecEff.size(); num36++)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(num36);
					this.paint_Bullet(g, this.fraImgEff, point_Focus.frame, point_Focus.x, point_Focus.y, false);
				}
				break;
			case 73:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num37 = 0; num37 < this.VecSubEff.size(); num37++)
				{
					Point point36 = (Point)this.VecSubEff.elementAt(num37);
					this.fraImgSubEff.drawFrameEffectSkill(point36.f / 2 % this.fraImgSubEff.nFrame, point36.x, point36.y, this.frameArrow, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num38 = 0; num38 < this.VecEff.size(); num38++)
				{
					Point point37 = (Point)this.VecEff.elementAt(num38);
					if (point37.f > 0)
					{
						this.paint_Bullet(g, this.fraImgEff, point37.frame, point37.x, point37.y, false);
					}
				}
				break;
			case 74:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < this.fRemove)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y + this.objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num39 = 0; num39 < this.VecEff.size(); num39++)
				{
					Point_Focus point_Focus2 = (Point_Focus)this.VecEff.elementAt(num39);
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, point_Focus2.x, point_Focus2.y, this.frameArrow, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 75:
				if (this.fraImgEff == null)
				{
					return;
				}
				for (int num40 = 0; num40 < this.VecEff.size(); num40++)
				{
					Point point38 = (Point)this.VecEff.elementAt(num40);
					if (this.f <= this.fRemove)
					{
						int num41 = 0;
						if (this.f < 5)
						{
							num41 = this.f / 2;
						}
						else if (num41 > this.fRemove - 5)
						{
							num41 = (this.fRemove - this.f) / 2;
						}
						else
						{
							num41 = CRes.random(2, 4);
						}
						this.fraImgEff.drawFrameEffectSkill(num41, point38.x, point38.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			case 76:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < 6)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2 % this.fraImgSubEff.nFrame, this.x, this.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				for (int num42 = 0; num42 < this.VecEff.size(); num42++)
				{
					Point point39 = (Point)this.VecEff.elementAt(num42);
					this.fraImgEff.drawFrameEffectSkill(CRes.random(3), point39.x / 1000 + CRes.random_Am_0(5), point39.y / 1000 + CRes.random_Am_0(5), 0, 3, g);
				}
				break;
			case 85:
				if (this.objBeKillMain != null && !this.objBeKillMain.isRemove && !this.objBeKillMain.isTanHinh && !this.objBeKillMain.isStop)
				{
					for (int num43 = this.VecEff.size() - 1; num43 >= 0; num43--)
					{
						Line line4 = (Line)this.VecEff.elementAt(num43);
						if (line4 != null)
						{
							int color = EffectSkill.colorStar[0][line4.idColor];
							g.setColor(color);
							g.drawLine(line4.x0, line4.y0, line4.x1, line4.y1, mGraphics.isFalse);
							if (line4.is2Line)
							{
								g.drawLine(line4.x0 + 1, line4.y0, line4.x1 + 1, line4.y1, mGraphics.isFalse);
							}
						}
					}
				}
				break;
			case 87:
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				break;
			case 89:
			case 92:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.typeEffect == 89 || this.typeEffect == 92)
				{
					for (int num44 = 0; num44 < this.VecEff.size(); num44++)
					{
						Point point40 = (Point)this.VecEff.elementAt(num44);
						this.fraImgSubEff.drawFrameEffectSkill(point40.f / 2 % this.fraImgSubEff.nFrame, point40.x, point40.y, this.frameArrow, 3, g);
					}
				}
				if (this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 90:
				this.paint_Ice_Nova_Effect(g);
				break;
			case 91:
				this.paint_Poison_Nova_Effect(g);
				break;
			case 93:
				if (this.f < 6)
				{
					this.fraImgSubEff.drawFrameEffectSkill(this.f / 2, this.x, this.y + this.objKill.hOne / 2, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				for (int num45 = 0; num45 < this.VecEff.size(); num45++)
				{
					Point point41 = (Point)this.VecEff.elementAt(num45);
					if (this.f <= this.fRemove)
					{
						int idx2;
						if (this.f < 3)
						{
							idx2 = this.f;
						}
						else if (this.f > this.fRemove - 3)
						{
							idx2 = this.fRemove - this.f;
						}
						else
						{
							idx2 = CRes.random(2, 4);
						}
						this.fraImgEff.drawFrameEffectSkill(idx2, point41.x, point41.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				break;
			case 94:
				if (this.f < 0)
				{
					return;
				}
				if (this.fraImgEff != null && this.objBeKillMain != null)
				{
					this.fraImgEff.drawFrameEffectSkill((int)this.nFrame[this.f], this.objBeKillMain.x + 2, this.objBeKillMain.y + 8, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 95:
			{
				mVector mVector10 = new mVector();
				int cl6 = 11278783;
				int cl7 = 15116264;
				if (this.f % 5 < 2 || this.f % 5 == 3)
				{
					for (int num46 = 1; num46 < this.VecEff.size(); num46++)
					{
						Point point42 = (Point)this.VecEff.elementAt(num46 - 1);
						Point point43 = (Point)this.VecEff.elementAt(num46);
						mVector10.addElement(new mLine(point42.x / 1000, point42.y / 1000 - 1, point43.x / 1000, point43.y / 1000 - 1, cl6));
						mVector10.addElement(new mLine(point42.x / 1000, point42.y / 1000 + 1, point43.x / 1000, point43.y / 1000 + 1, cl6));
						mVector10.addElement(new mLine(point42.x / 1000, point42.y / 1000 + 2, point43.x / 1000, point43.y / 1000 + 2, cl6));
						mVector10.addElement(new mLine(point42.x / 1000, point42.y / 1000, point43.x / 1000, point43.y / 1000, cl7));
					}
					for (int num47 = 1; num47 < this.VecSubEff.size(); num47++)
					{
						Point point44 = (Point)this.VecSubEff.elementAt(num47 - 1);
						Point point45 = (Point)this.VecSubEff.elementAt(num47);
						if (point45.x != -1 && point44.x != -1)
						{
							mVector10.addElement(new mLine(point44.x / 1000, point44.y / 1000, point45.x / 1000, point45.y / 1000, cl6));
							mVector10.addElement(new mLine(point44.x / 1000, point44.y / 1000 + 1, point45.x / 1000, point45.y / 1000 + 1, cl6));
						}
					}
				}
				g.totalLine = mVector10;
				g.drawlineGL();
				break;
			}
			case 96:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.typeEffect == 96)
				{
					for (int num48 = 0; num48 < this.VecEff.size(); num48++)
					{
						Point point46 = (Point)this.VecEff.elementAt(num48);
						this.fraImgSubEff.drawFrameEffectSkill(point46.f / 2 % this.fraImgSubEff.nFrame, point46.x, point46.y, this.frameArrow, 3, g);
					}
				}
				if (this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 97:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				mVector mVector11 = new mVector();
				if (this.f < this.fRemove)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
					if (this.f > 8)
					{
						int num49 = this.fRemove - this.f;
						if (num49 < 1)
						{
							num49 = 1;
						}
						for (int num50 = 0; num50 < num49; num50++)
						{
							int cl8;
							if (num50 == num49 - 1)
							{
								cl8 = 16774656;
							}
							else
							{
								cl8 = 16777215;
							}
							mVector11.addElement(new mLine(this.x + num50 * this.vX1000, this.y + num50 * this.vY1000, this.xdichTower + num50 * this.vX1000, this.ydichTower + num50 * this.vY1000, cl8));
							mVector11.addElement(new mLine(this.x - num50 * this.vX1000, this.y - num50 * this.vY1000, this.xdichTower - num50 * this.vX1000, this.ydichTower - num50 * this.vY1000, cl8));
						}
					}
				}
				for (int num51 = 0; num51 < this.VecEff.size(); num51++)
				{
					Point point47 = (Point)this.VecEff.elementAt(num51);
					if (point47 != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point47.f % this.fraImgSubEff.nFrame, point47.x, point47.y, 0, 3, g);
					}
				}
				g.totalLine = mVector11;
				g.drawlineGL();
				break;
			}
			case 98:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.typeEffect == 98)
				{
					for (int num52 = 0; num52 < this.VecEff.size(); num52++)
					{
						Point point48 = (Point)this.VecEff.elementAt(num52);
						this.fraImgSubEff.drawFrameEffectSkill(point48.f / 2 % this.fraImgSubEff.nFrame, point48.x, point48.y, this.frameArrow, 3, g);
					}
				}
				if (this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 99:
				if (this.fraImgEff == null)
				{
					return;
				}
				if (this.f < this.fRemove)
				{
					this.paint_Bullet(g, this.fraImgEff, this.frame, this.x, this.y, false);
				}
				break;
			case 101:
				if (this.ispaintsleep)
				{
					AvMain.imgSleep.drawFrameEffectSkill(this.frameSleep[this.frSleep], this.x - 8, this.y - (17 + (((int)this.objBeKillMain.typeMount == -1) ? 0 : this.objBeKillMain.dyMount)), 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				break;
			case 102:
				AvMain.imgStun.drawFrameEffectSkill(this.frameStun[(int)this.frStun], this.x, this.y - (this.ystun + (((int)this.objBeKillMain.typeMount == -1) ? 0 : this.objBeKillMain.dyMount)), 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				break;
			case 103:
				for (int num53 = 0; num53 < this.arr_R.Length; num53++)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, CRes.cos(this.arr_radian[num53]) * (int)this.arr_R[num53] / 1024 + this.x + 2, CRes.sin(this.arr_radian[num53]) * (int)this.arr_R[num53] / 1024 + this.y - this.ysai - 20, 0, 3, g);
					if (this.timedelay <= 0)
					{
						g.drawImage(MainObject.shadow, CRes.cos(this.arr_radian[num53]) * (int)this.arr_R[num53] / 1024 + this.x + 2, CRes.sin(this.arr_radian[num53]) * (int)this.arr_R[num53] / 1024 + this.y - 10, 3, mGraphics.isFalse);
					}
				}
				break;
			case 105:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				mVector mVector12 = new mVector();
				if (this.f < this.fRemove)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
					if (this.f > 8)
					{
						int num54 = this.fRemove - this.f;
						if (num54 < 1)
						{
							num54 = 1;
						}
						for (int num55 = 0; num55 < num54; num55++)
						{
							int cl9;
							if (num55 == num54 - 1)
							{
								cl9 = 720469;
							}
							else
							{
								cl9 = 16777215;
							}
							mVector12.addElement(new mLine(this.x + num55 * this.vX1000, this.y + num55 * this.vY1000, this.x1000 + num55 * this.vX1000, this.y1000 + num55 * this.vY1000, cl9));
							mVector12.addElement(new mLine(this.x - num55 * this.vX1000, this.y - num55 * this.vY1000, this.x1000 - num55 * this.vX1000, this.y1000 - num55 * this.vY1000, cl9));
						}
					}
				}
				for (int num56 = 0; num56 < this.VecEff.size(); num56++)
				{
					Point point49 = (Point)this.VecEff.elementAt(num56);
					if (point49 != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point49.f % this.fraImgSubEff.nFrame, point49.x, point49.y, 0, 3, g);
					}
				}
				break;
			}
			case 106:
			{
				if (this.fraImgEff == null)
				{
					return;
				}
				mVector mVector13 = new mVector();
				this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				for (int num57 = 0; num57 < this.size1; num57++)
				{
					int cl10;
					if (num57 == this.size1 - 1)
					{
						cl10 = 720469;
					}
					else
					{
						cl10 = 16777215;
					}
					mVector13.addElement(new mLine(this.x + num57 * this.vX1000, this.y + num57 * this.vY1000, this.x1000 + num57 * this.vX1000, this.y1000 + num57 * this.vY1000, cl10));
					mVector13.addElement(new mLine(this.x - num57 * this.vX1000, this.y - num57 * this.vY1000, this.x1000 - num57 * this.vX1000, this.y1000 - num57 * this.vY1000, cl10));
				}
				for (int num58 = 0; num58 < this.VecEff.size(); num58++)
				{
					Point point50 = (Point)this.VecEff.elementAt(num58);
					if (point50 != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point50.f % this.fraImgSubEff.nFrame, point50.x, point50.y, 0, 3, g);
					}
				}
				break;
			}
			case 109:
			case 110:
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				break;
			case 111:
				if (this.f % 5 < 2 || this.f % 5 == 3)
				{
					mVector mVector14 = new mVector();
					for (int num59 = 1; num59 < this.VecEff.size(); num59++)
					{
						Point point51 = (Point)this.VecEff.elementAt(num59 - 1);
						Point point52 = (Point)this.VecEff.elementAt(num59);
						g.setColor(16514254);
						mVector14.addElement(new mLine(point51.x / 1000, point51.y / 1000 - 1, point52.x / 1000, point52.y / 1000 - 1, 16514254));
						mVector14.addElement(new mLine(point51.x / 1000, point51.y / 1000 + 1, point52.x / 1000, point52.y / 1000 + 1, 16514254));
						mVector14.addElement(new mLine(point51.x / 1000, point51.y / 1000 + 2, point52.x / 1000, point52.y / 1000 + 2, 16514254));
						mVector14.addElement(new mLine(point51.x / 1000, point51.y / 1000, point52.x / 1000, point52.y / 1000, 16514254));
					}
					for (int num60 = 1; num60 < this.VecSubEff.size(); num60++)
					{
						Point point53 = (Point)this.VecSubEff.elementAt(num60 - 1);
						Point point54 = (Point)this.VecSubEff.elementAt(num60);
						if (point54.x != -1 && point53.x != -1)
						{
							g.setColor(16514254);
							mVector14.addElement(new mLine(point53.x / 1000, point53.y / 1000, point54.x / 1000, point54.y / 1000, 16514254));
							mVector14.addElement(new mLine(point53.x / 1000, point53.y / 1000 + 1, point54.x / 1000, point54.y / 1000 + 1, 16514254));
						}
					}
				}
				break;
			case 112:
				for (int num61 = 0; num61 < this.VecEff.size(); num61++)
				{
					Point point55 = (Point)this.VecEff.elementAt(num61);
					if (point55 != null)
					{
						if (this.f >= point55.fRe && this.f <= this.fRemove - 3 + point55.fRe)
						{
							this.fraImgSubEff.drawFrameEffectSkill((this.f / 3 + point55.fRe) % this.fraImgSubEff.nFrame, point55.x / 1000, point55.y / 1000 + 4, point55.dis, mGraphics.BOTTOM | mGraphics.HCENTER, g);
						}
					}
				}
				break;
			case 124:
				if (this.fraImgEff == null)
				{
					return;
				}
				this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				break;
			case 125:
			{
				mVector mVector15 = new mVector();
				for (int num62 = 0; num62 < this.size1; num62++)
				{
					int cl11;
					if (num62 == this.size1 - 1)
					{
						cl11 = 720469;
					}
					else
					{
						cl11 = 16777215;
					}
					mVector15.addElement(new mLine(this.x + num62 * this.vX1000, this.y + num62 * this.vY1000, this.x1000 + num62 * this.vX1000, this.y1000 + num62 * this.vY1000, cl11));
					mVector15.addElement(new mLine(this.x - num62 * this.vX1000, this.y - num62 * this.vY1000, this.x1000 - num62 * this.vX1000, this.y1000 - num62 * this.vY1000, cl11));
				}
				break;
			}
			case 126:
			{
				mVector mVector16 = new mVector();
				for (int num63 = 0; num63 < this.size1; num63++)
				{
					int cl12;
					if (num63 == this.size1 - 1)
					{
						cl12 = 15771896;
					}
					else
					{
						cl12 = 16777215;
					}
					mVector16.addElement(new mLine(this.x + num63 * this.vX1000, this.y + num63 * this.vY1000, this.x1000 + num63 * this.vX1000, this.y1000 + num63 * this.vY1000, cl12));
					mVector16.addElement(new mLine(this.x - num63 * this.vX1000, this.y - num63 * this.vY1000, this.x1000 - num63 * this.vX1000, this.y1000 - num63 * this.vY1000, cl12));
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			this.removeEff();
		}
		this.test = 0;
	}

	// Token: 0x06000282 RID: 642 RVA: 0x0001BB20 File Offset: 0x00019D20
	public override void update()
	{
		this.f++;
		this.subf++;
		try
		{
			if (this.objBeKillMain != null)
			{
				this.xEff = this.objBeKillMain.x;
				this.yEff = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
			}
			if (this.f == (int)this.timeAddNum && (int)this.timeAddNum > 0)
			{
				bool flag = true;
				if (mSystem.isj2me && GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
				{
					flag = false;
				}
				if (!this.isEff && flag)
				{
					this.addNum();
				}
				this.SetAddSoundTimeAdd();
			}
			bool flag2 = true;
			switch (this.typeEffect)
			{
			case 0:
				this.updateAngleNormal();
				break;
			case 1:
			case 22:
			case 38:
				if (MainObject.getDistance(this.x, this.toX, this.y, this.toY) <= 8 || this.f >= this.fRemove)
				{
					if (this.typeEffect == 22)
					{
						if (this.objBeKillMain != null)
						{
							GameScreen.addEffectEndKill(7, this.toX, this.toY + this.objBeKillMain.hOne / 4);
						}
					}
					else if (this.typeEffect == 38)
					{
						GameScreen.addEffectEndKill(2, this.toX, this.toY);
					}
					this.removeEff();
				}
				break;
			case 6:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 10:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 11:
			case 86:
			case 108:
			case 114:
				for (int i = 0; i < this.VecEff.size(); i++)
				{
					Point point = (Point)this.VecEff.elementAt(i);
					if (this.f == point.f)
					{
						if (this.typeEffect == 11)
						{
							LoadMap.timeVibrateScreen = 103;
						}
						if (this.typeEffect != 114)
						{
							GameScreen.addEffectEndKill(0, point.x, point.y + point.vy * this.f / 1000 - 5);
							GameScreen.addEffectEndKill(9, point.x, point.y + point.vy * this.f / 1000 + 5);
							GameScreen.addEffectEndKill(26, point.x, point.y + point.vy * this.f / 1000 + 10);
						}
						else
						{
							GameScreen.addEffectEndKill(49, point.x, point.y + point.vy * this.f / 1000 + 10);
							GameScreen.addEffectEndKill(28, point.x, point.y + point.vy * this.f / 1000 + 10);
						}
					}
					else if (this.f < point.f)
					{
						point.x += point.vx;
						flag2 = false;
						if (CRes.random(2) == 0)
						{
							Point point2 = new Point();
							point2.x = point.x - point.vx;
							point2.y = point.y + point.vy * (this.f - 1) / 1000;
							this.VecSubEff.addElement(point2);
						}
					}
				}
				for (int j = 0; j < this.VecSubEff.size(); j++)
				{
					Point point3 = (Point)this.VecSubEff.elementAt(j);
					point3.f++;
					if (point3.f / 2 > 3 && this.test == 0)
					{
						this.VecSubEff.removeElement(point3);
						j--;
					}
				}
				if (flag2)
				{
					this.removeEff();
				}
				break;
			case 12:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 14:
			case 81:
			case 115:
				for (int k = 0; k < this.VecEff.size(); k++)
				{
					Point point4 = (Point)this.VecEff.elementAt(k);
					if (point4.f == 0)
					{
						flag2 = false;
						if (this.f >= this.fRemove)
						{
							point4.f = 1;
						}
						else
						{
							point4.x += point4.vx;
							point4.y += point4.vy;
							if (this.typeEffect == 14 || this.typeEffect == 115 || this.f > 6)
							{
								int tile = GameCanvas.loadmap.getTile(point4.x / 1000, point4.y / 1000);
								if (tile == -1 || tile == 1 || !MainEffect.isInScreen(point4.x / 1000, point4.y / 1000, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight))
								{
									point4.f = 1;
								}
							}
						}
					}
					else if (point4.f > 0)
					{
						point4.f++;
						if ((point4.f - 1) / 2 >= this.fraImgSubEff.nFrame)
						{
							point4.f = -1;
							this.VecEff.removeElement(point4);
						}
						flag2 = false;
					}
				}
				if (flag2)
				{
					this.removeEff();
				}
				break;
			case 20:
			case 113:
				for (int l = 0; l < this.VecEff.size(); l++)
				{
					Point point5 = (Point)this.VecEff.elementAt(l);
					if (point5.dis == 0)
					{
						point5.update();
						if (point5.f >= point5.fRe)
						{
							point5.dis = 1;
							point5.f = 0;
							if (!GameCanvas.lowGraphic && CRes.random(4) == 0)
							{
								GameScreen.addEffectEndKill((this.typeEffect != 20) ? 10 : 24, point5.x, point5.y);
							}
						}
					}
					else if (point5.dis == 1)
					{
						point5.f++;
						if (point5.f >= 2 && this.test == 0)
						{
							this.VecEff.removeElement(point5);
							l--;
						}
					}
				}
				if (this.f < this.fRemove)
				{
					if (!GameCanvas.lowGraphic || GameCanvas.gameTick % 2 == 0)
					{
						this.y1000 = MainScreen.cameraMain.yCam - CRes.random(10, 20);
						this.create_Arrow_Rain();
					}
				}
				else if (this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				break;
			case 21:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 23:
				for (int m = 0; m < this.VecEff.size(); m++)
				{
					Point point6 = (Point)this.VecEff.elementAt(m);
					point6.update();
					if (point6.f >= point6.fRe)
					{
						this.VecEff.removeElement(point6);
						m--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					if (this.objBeKillMain != null)
					{
						GameScreen.addEffectEndKill(12, this.toX, this.toY + this.objBeKillMain.hOne / 4);
					}
					this.removeEff();
				}
				if (this.f == 0)
				{
					int num = this.x;
					int num2 = this.y;
					switch (this.Direction)
					{
					case 0:
						num2 += 20;
						break;
					case 1:
						num2 -= 20;
						break;
					case 2:
						num -= 20;
						break;
					case 3:
						num += 20;
						break;
					}
					GameScreen.addEffectEndKill(13, num, num2);
				}
				break;
			case 25:
				if (this.f == this.fRemove && this.objBeKillMain != null)
				{
					if (this.typeEffect == 25)
					{
						GameScreen.addEffectEndKill(10, this.toX, this.toY);
						GameScreen.addEffectEndKill(15, this.toX, this.toY + this.objBeKillMain.hOne / 4);
					}
					else
					{
						GameScreen.addEffectEndKill(4, this.toX, this.toY);
						GameScreen.addEffectEndKill(14, this.toX, this.toY + this.objBeKillMain.hOne / 4);
					}
				}
				if (this.f < this.fRemove)
				{
					Point point7 = new Point();
					point7.x = this.x;
					point7.y = this.y;
					this.VecEff.addElement(point7);
				}
				else if (this.VecEff.size() == 0 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				for (int n = 0; n < this.VecEff.size(); n++)
				{
					Point point8 = (Point)this.VecEff.elementAt(n);
					point8.f++;
					if (point8.f > 3)
					{
						this.VecEff.removeElement(point8);
						point8.f++;
						n--;
					}
				}
				break;
			case 26:
				for (int num3 = 0; num3 < this.VecEff.size(); num3++)
				{
					Point point9 = (Point)this.VecEff.elementAt(num3);
					point9.f++;
					if (point9.f >= 7)
					{
						this.VecEff.removeElement(point9);
						num3--;
					}
				}
				if (this.f <= this.fRemove)
				{
					Point point10 = new Point();
					point10.x = this.x;
					point10.y = this.y;
					this.VecEff.addElement(point10);
				}
				else
				{
					if (this.f == this.fRemove + 1 && this.typeEffect == 26)
					{
						LoadMap.timeVibrateScreen = 103;
					}
					if (this.VecEff.size() == 0 && this.f > this.fRemove + 5)
					{
						this.removeEff();
					}
				}
				break;
			case 27:
				for (int num4 = 0; num4 < this.VecEff.size(); num4++)
				{
					Point point11 = (Point)this.VecEff.elementAt(num4);
					point11.f++;
					if (point11.f >= 3)
					{
						this.VecEff.removeElement(point11);
						num4--;
					}
				}
				if (this.f < this.fRemove)
				{
					if (this.f == 0)
					{
						GameScreen.addEffectEndKill(6, this.x, this.y);
						this.setSendMove(this.x, this.toX, this.y, this.toY);
					}
					Point point12 = new Point();
					point12.x = this.x;
					point12.y = this.y - 10;
					this.VecEff.addElement(point12);
				}
				else if (this.objKill != null)
				{
					if (this.f == this.fRemove)
					{
						if (this.objKill.Action != 4 && this.objKill.Action != 3)
						{
							this.objKill.Action = 2;
							this.objKill.fplash = 6;
							this.objKill.frame = 5;
						}
					}
					else if (this.f == this.fRemove + 5 && this.objKill.Action == 2)
					{
						this.f = 0;
						this.objKill.Action = 0;
					}
					if (this.objKill.isTanHinh)
					{
						this.objKill.isTanHinh = false;
					}
					if (this.VecEff.size() == 0)
					{
						if (this.objKill.Action == 2)
						{
							this.f = 0;
							this.objKill.Action = 0;
						}
						this.removeEff();
						int tile2 = GameCanvas.loadmap.getTile(this.objKill.x, this.objKill.y);
						if (tile2 == 2)
						{
							this.objKill.isWater = true;
						}
						else
						{
							this.objKill.isWater = false;
						}
					}
				}
				if (this.f == (int)this.timeAddNum && this.objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(5, this.objBeKillMain.x, this.objBeKillMain.y - this.objBeKillMain.hOne / 2);
				}
				break;
			case 28:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				if (this.f == 0)
				{
					GameScreen.addEffectEndKill(9, this.toX, this.toY);
					if (GameScreen.isWater(this.toX, this.toY))
					{
						GameScreen.addEffectEndKill(1, this.toX, this.toY);
					}
				}
				break;
			case 29:
			case 84:
				for (int num5 = 0; num5 < this.VecEff.size(); num5++)
				{
					Line line = (Line)this.VecEff.elementAt(num5);
					line.update();
					if (this.f >= this.fRemove && this.test == 0)
					{
						this.VecEff.removeElement(line);
						num5--;
					}
				}
				if (this.f >= this.fRemove && this.test == 0)
				{
					if (GameCanvas.timeNow - this.time >= (long)this.timeRemove)
					{
						if (this.test == 0)
						{
							this.VecEff.removeAllElements();
						}
						this.removeEff();
					}
					else
					{
						this.fRemove = CRes.random(4, 6);
						this.f = 0;
						this.create_Star_Line_In(this.vMax, this.xline, this.yline);
					}
				}
				break;
			case 30:
				for (int num6 = 0; num6 < this.VecEff.size(); num6++)
				{
					Point point13 = (Point)this.VecEff.elementAt(num6);
					if (point13.f < 5)
					{
						point13.update();
						point13.vx += point13.vx / 5;
						point13.vy += point13.vy / 5;
					}
					else if (this.test == 0)
					{
						this.VecEff.removeElement(point13);
						num6--;
					}
				}
				if (this.VecEff.size() == 0)
				{
					if (GameCanvas.timeNow - this.time > (long)this.timeRemove)
					{
						this.removeEff();
					}
					else
					{
						this.create_Star_Point_In();
					}
				}
				break;
			case 31:
				if (this.f < this.fRemove && this.f > 1)
				{
					Point point14 = new Point();
					point14.x = this.x - this.vx;
					point14.y = this.y - this.vy;
					this.VecEff.addElement(point14);
				}
				else if (this.VecEff.size() == 0 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				if (this.f == this.fRemove && this.objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(36, this.toX, this.toY + this.objBeKillMain.hOne / 4);
					GameScreen.addEffectEndKill(14, this.toX, this.toY + this.objBeKillMain.hOne / 4);
				}
				for (int num7 = 0; num7 < this.VecEff.size(); num7++)
				{
					Point point15 = (Point)this.VecEff.elementAt(num7);
					point15.f++;
					if (point15.f / 2 > 3)
					{
						this.VecEff.removeElement(point15);
						num7--;
					}
				}
				break;
			case 34:
				for (int num8 = 0; num8 < this.VecEff.size(); num8++)
				{
					Point point16 = (Point)this.VecEff.elementAt(num8);
					point16.update();
					if (point16.f >= 3)
					{
						this.VecEff.removeElement(point16);
						num8--;
					}
				}
				if (this.f == 3 && this.objBeKillMain != null)
				{
					this.create_2Kiem_Lv4(180, this.objBeKillMain);
				}
				if (this.f == 6)
				{
					if (this.objKill != null)
					{
						this.indexSound = 9;
						if (this.objKill == GameScreen.player)
						{
							mSound.playSound(this.indexSound, mSound.volumeSound);
						}
						else
						{
							GameScreen.addSoundEff(this.indexSound);
						}
					}
					if (this.indexLan >= this.vecObjBeKill.size())
					{
						this.f = 56;
					}
					else
					{
						MainObject mainObject = null;
						if (this.indexLan < this.vecObjBeKill.size())
						{
							this.f = 0;
							do
							{
								Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjBeKill.elementAt(this.indexLan);
								mainObject = MainObject.get_Item_Object((int)object_Effect_Skill.ID, (int)object_Effect_Skill.tem);
								if (mainObject != null)
								{
									if (mainObject.Action == 4)
									{
										mainObject = null;
									}
									else
									{
										this.objBeKillMain = mainObject;
										if (this.objBeKillMain != null)
										{
											this.create_2Kiem_Lv4(0, this.objBeKillMain);
										}
									}
								}
								this.indexLan++;
							}
							while (mainObject == null && this.indexLan < this.vecObjBeKill.size());
						}
						if (this.indexLan >= this.vecObjBeKill.size() && mainObject == null)
						{
							this.f = 56;
						}
					}
				}
				if (this.f == this.fRemove - 1 && this.objKill != null)
				{
					switch (this.objKill.Direction)
					{
					case 0:
						this.objKill.Direction = 1;
						break;
					case 1:
						this.objKill.Direction = 0;
						break;
					case 2:
						this.objKill.Direction = 3;
						break;
					case 3:
						this.objKill.Direction = 2;
						break;
					}
					if (this.objKill.Action != 4 && this.objKill.Action != 3)
					{
						this.objKill.Action = 2;
						this.objKill.fplash = 6;
						this.objKill.frame = 5;
						this.objKill.weapon_frame = 6;
					}
					this.objKill.isTanHinh = false;
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
					if (this.objKill != null && this.objKill.Action == 2)
					{
						this.f = 0;
						this.objKill.Action = 0;
						if (this.objKill.isMainChar())
						{
							GameScreen.player.x = GameScreen.player.lastX;
							GameScreen.player.y = GameScreen.player.lastY;
							GameScreen.player.doResetLastXY();
							GameScreen.player.resetAction();
							GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
						}
					}
				}
				break;
			case 40:
				if (this.f <= 4)
				{
					if (this.objBeKillMain != null && (this.toX != this.objBeKillMain.x || this.toY != this.objBeKillMain.y - this.objBeKillMain.hOne / 2) && this.objBeKillMain.Action != 4)
					{
						for (int num9 = 0; num9 < this.VecEff.size(); num9++)
						{
							Point point17 = (Point)this.VecEff.elementAt(num9);
							this.toX = this.objBeKillMain.x;
							this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
							point17.x = this.toX * 1000;
							point17.y = this.toY * 1000;
							point17.g = CRes.fixangle(point17.g + 5);
							point17.vx = CRes.sin(CRes.fixangle(point17.g)) * this.lT_Arc;
							point17.vy = CRes.cos(CRes.fixangle(point17.g)) * this.lT_Arc;
							int frameAngle = CRes.angle(-point17.vx, -point17.vy);
							point17.frame = this.setFrameAngle(frameAngle);
						}
					}
				}
				else
				{
					for (int num10 = 0; num10 < this.VecEff.size(); num10++)
					{
						Point point18 = (Point)this.VecEff.elementAt(num10);
						if (this.f % 3 == 0)
						{
							point18.vx /= 2;
							point18.vy /= 2;
						}
						if (this.f > 7)
						{
							this.VecEff.removeAllElements();
							GameScreen.addEffectEndKill(6, this.toX, this.toY);
						}
					}
				}
				for (int num11 = 0; num11 < this.VecSubEff.size(); num11++)
				{
					Point point19 = (Point)this.VecSubEff.elementAt(num11);
					point19.update();
					if (this.f > 16)
					{
						this.VecSubEff.removeAllElements();
						this.removeEff();
					}
				}
				break;
			case 41:
				this.updateAngleXP();
				for (int num12 = 0; num12 < this.VecEff.size(); num12++)
				{
					Point point20 = (Point)this.VecEff.elementAt(num12);
					point20.f++;
					if (point20.f > 4)
					{
						this.VecEff.removeElement(point20);
						num12--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				break;
			case 42:
				if (this.objKill != null)
				{
					this.x = this.objKill.x;
					this.y = this.objKill.y;
				}
				if (this.f == 0 && this.objKill != null)
				{
					GameScreen.addEffectKill(43, this.objKill.ID, this.objKill.typeObject, this.vecObjBeKill);
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				if (this.f == this.fRemove / 2)
				{
					GameScreen.addEffectEndKill(21, this.x, this.y);
				}
				if (this.f < this.fRemove / 2)
				{
					for (int num13 = 0; num13 < this.VecEff.size(); num13++)
					{
						Point point21 = (Point)this.VecEff.elementAt(num13);
						if (CRes.random(3) == 0)
						{
							if (point21.fRe == 1)
							{
								point21.fRe = 0;
							}
							else
							{
								point21.fRe = 1;
								point21.frame = CRes.random(4);
							}
						}
					}
				}
				break;
			case 43:
				if (this.objKill != null)
				{
					this.x = this.objKill.x;
					this.y = this.objKill.y;
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				for (int num14 = 0; num14 < this.VecEff.size(); num14++)
				{
					Point point22 = (Point)this.VecEff.elementAt(num14);
					if (CRes.random(3) == 0)
					{
						if (point22.fRe == 1)
						{
							point22.fRe = 0;
						}
						else
						{
							point22.fRe = 1;
							point22.frame = CRes.random(4);
						}
					}
				}
				break;
			case 46:
				if (this.objBeKillMain != null)
				{
					if ((CRes.abs(this.toX - this.objBeKillMain.x) > 2 || CRes.abs(this.toY - this.objBeKillMain.y) > 2) && CRes.random(3) == 0)
					{
						GameScreen.addEffectEndKill(24, this.toX, this.toY - 5);
					}
					this.toX = this.objBeKillMain.x;
					this.toY = this.objBeKillMain.y;
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 47:
			case 112:
				for (int num15 = 0; num15 < this.VecEff.size(); num15++)
				{
					Point point23 = (Point)this.VecEff.elementAt(num15);
					if (this.f == point23.fRe)
					{
						GameScreen.addEffectEndKill(26, point23.x / 1000, point23.y / 1000 - 5);
					}
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 49:
				for (int num16 = 0; num16 < this.VecEff.size(); num16++)
				{
					Point point24 = (Point)this.VecEff.elementAt(num16);
					point24.f++;
					if (point24.f >= 5)
					{
						this.VecEff.removeElement(point24);
						num16--;
					}
				}
				if (this.f < this.fRemove)
				{
					Point point25 = new Point();
					point25.x = this.x;
					point25.y = this.y;
					this.VecEff.addElement(point25);
				}
				else if (this.VecEff.size() == 0 && this.f >= this.fRemove + 6)
				{
					this.removeEff();
				}
				break;
			case 50:
				if (this.f >= 6)
				{
					this.removeEff();
				}
				if (this.f == -1 || this.f >= 6)
				{
					return;
				}
				if (this.objKill != null)
				{
					if (this.f < 3)
					{
						this.objKill.x += this.x1000;
						this.objKill.y += this.y1000;
					}
					else if (this.f < 6)
					{
						this.objKill.x -= this.x1000;
						this.objKill.y -= this.y1000;
					}
				}
				break;
			case 51:
			case 105:
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				if (this.f < this.fRemove)
				{
					if (this.f == 8)
					{
						int num17 = 2;
						if (this.objBeKillMain != null && this.objKill != null)
						{
							this.objKill.Direction = EffectSkill.setDirection(this.objKill, this.objBeKillMain);
							num17 = this.objKill.Direction;
						}
						if (num17 == 2 || num17 == 3)
						{
							this.vY1000 = 1;
							this.vX1000 = 0;
						}
						else
						{
							this.vY1000 = 0;
							this.vX1000 = 1;
						}
						if (this.objBeKillMain != null && this.objKill != null)
						{
							int a = CRes.angle(this.objBeKillMain.x - this.objKill.x, this.objBeKillMain.y - this.objKill.y);
							int num18 = 320;
							if (num18 < GameCanvas.h)
							{
								num18 = GameCanvas.h;
							}
							if (num18 < GameCanvas.w)
							{
								num18 = GameCanvas.w;
							}
							this.x1000 = this.x + CRes.cos(a) * num18 / 1000;
							this.y1000 = this.y + CRes.sin(a) * num18 / 1000;
							this.toX = this.objBeKillMain.x;
							this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
						}
					}
					if (this.f > 8 && this.f % 3 == 2)
					{
						Point point26 = new Point();
						point26.x = this.toX + CRes.random_Am_0(5);
						point26.y = this.toY + CRes.random_Am_0(5);
						this.VecEff.addElement(point26);
					}
				}
				for (int num19 = 0; num19 < this.VecEff.size(); num19++)
				{
					Point point27 = (Point)this.VecEff.elementAt(num19);
					point27.f++;
					if (point27.f >= 4)
					{
						this.VecEff.removeElement(point27);
						num19--;
					}
				}
				break;
			case 52:
			case 54:
				if (this.typeEffect == 54)
				{
					if (this.f == 0)
					{
						GameScreen.addEffectEndKill(3, this.toX, this.toY - 10);
					}
				}
				else if (this.typeEffect == 52 && this.f == 0)
				{
					GameScreen.addEffectEndKill(14, this.toX, this.toY);
				}
				if (this.f < this.fRemove && this.objBeKillMain != null)
				{
					if ((CRes.abs(this.toX - this.objBeKillMain.x) > 2 || CRes.abs(this.toY - this.objBeKillMain.y) > 2) && CRes.random(3) == 0)
					{
						Point point28 = new Point();
						point28.x = this.toX;
						point28.y = this.toY - 5;
						this.VecEff.addElement(point28);
					}
					this.toX = this.objBeKillMain.x;
					this.toY = this.objBeKillMain.y;
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				for (int num20 = 0; num20 < this.VecEff.size(); num20++)
				{
					Point point29 = (Point)this.VecEff.elementAt(num20);
					point29.f++;
					if (point29.f / 2 >= 4)
					{
						this.VecEff.removeElement(point29);
						num20--;
					}
				}
				break;
			case 53:
			case 64:
			case 71:
			case 75:
			case 78:
			case 104:
				for (int num21 = 0; num21 < this.VecEff.size(); num21++)
				{
					Point point30 = (Point)this.VecEff.elementAt(num21);
					if (this.f == 1)
					{
						LoadMap.timeVibrateScreen = 103;
						if (this.typeEffect == 75)
						{
							GameScreen.addEffectEndKill(15, point30.x, point30.y);
						}
						else
						{
							GameScreen.addEffectEndKill(9, point30.x, point30.y);
						}
						if (this.typeEffect == 64)
						{
							GameScreen.addEffectEndKill(15, point30.x, point30.y);
							GameScreen.addEffectEndKill(28, point30.x, point30.y - 2);
						}
						else if (this.typeEffect == 53 || this.typeEffect == 78 || this.typeEffect == 104)
						{
							GameScreen.addEffectEndKill(25, point30.x, point30.y - 2);
						}
					}
					point30.f++;
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 55:
				for (int num22 = 0; num22 < this.VecEff.size(); num22++)
				{
					Line line2 = (Line)this.VecEff.elementAt(num22);
					line2.update();
					if (line2.f > line2.fRe)
					{
						this.VecEff.removeElement(line2);
						num22--;
					}
				}
				if (this.f >= this.fRemove)
				{
					if (this.VecEff.size() == 0)
					{
						this.removeEff();
					}
				}
				else
				{
					int num23 = 20;
					if (this.objBeKillMain != null && !this.objBeKillMain.isRemove && !this.objBeKillMain.isStop && this.objBeKillMain.Action != 4)
					{
						this.toX = this.objBeKillMain.x;
						this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
						num23 = this.objBeKillMain.hOne / 2;
					}
					int num24 = CRes.random(2, 4);
					for (int num25 = 0; num25 < num24; num25++)
					{
						int num26 = CRes.random(10, 24);
						int num27 = CRes.random_Am_0(15);
						int num28 = CRes.random_Am(6, 12);
						Line line3 = new Line();
						if (this.Direction == 2 || this.Direction == 3)
						{
							line3.x0 = this.toX + num27;
							line3.x1 = line3.x0 + ((num27 <= 0) ? (-num26) : num26);
							line3.y0 = (line3.y1 = this.toY + CRes.random_Am_0(num23 + 10));
							line3.vx = num28;
						}
						else
						{
							line3.y0 = this.toY + num27;
							line3.y1 = line3.y0 + ((num27 <= 0) ? (-num26) : num26);
							line3.x0 = (line3.x1 = this.toX + CRes.random_Am_0(num23 + 10));
							line3.vy = num28;
						}
						line3.fRe = CRes.random(2, 5);
						line3.is2Line = (CRes.random(5) == 0);
						line3.idColor = CRes.random(3);
						this.VecEff.addElement(line3);
					}
				}
				break;
			case 56:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 57:
			case 70:
				if (this.objKill != null && this.objKill.Action != 4)
				{
					this.objKill.Action = 2;
					this.objKill.vx = 0;
					this.objKill.vy = 0;
				}
				for (int num29 = 0; num29 < this.VecEff.size(); num29++)
				{
					Line line4 = (Line)this.VecEff.elementAt(num29);
					line4.update();
					line4.update();
					line4.vx += line4.vx / 5;
					line4.vy += line4.vy / 5;
					if (line4.f >= 6 && this.test == 0)
					{
						this.VecEff.removeAllElements();
						num29--;
					}
				}
				if (this.VecEff.size() == 0)
				{
					if (GameCanvas.timeNow - this.time > (long)this.timeRemove)
					{
						this.removeEff();
					}
					else if (this.typeEffect == 57)
					{
						this.create_Buff_Point_In();
					}
					else if (this.typeEffect == 70)
					{
						this.create_Mon_Buff();
					}
				}
				break;
			case 58:
				if (this.f < this.fRemove)
				{
					if (this.f % 3 == 1)
					{
						int num30 = MainScreen.cameraMain.yCam + (this.y - MainScreen.cameraMain.yCam) % 30 - 30;
						for (int num31 = 0; num31 < 2; num31++)
						{
							Point point31 = new Point();
							point31.x = this.x;
							point31.y = num30 + num31 * 3;
							point31.vy = 30;
							this.VecEff.addElement(point31);
						}
					}
					if (this.f >= this.fRemove - 3 && this.objKill != null)
					{
						this.objKill.isTanHinh = !this.objKill.isTanHinh;
					}
				}
				else if (this.objKill != null && this.objKill.isTanHinh)
				{
					this.objKill.isTanHinh = false;
				}
				for (int num32 = 0; num32 < this.VecEff.size(); num32++)
				{
					Point point32 = (Point)this.VecEff.elementAt(num32);
					point32.update();
					if (point32.y > this.y)
					{
						this.VecEff.removeElement(point32);
						num32--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					if (this.objKill != null)
					{
						this.objKill.isTanHinh = false;
					}
					this.removeEff();
				}
				break;
			case 59:
				if (this.f >= this.fRemove + 6)
				{
					this.removeEff();
				}
				break;
			case 60:
				if (this.f == 0)
				{
					for (int num33 = 0; num33 < this.VecEff.size(); num33++)
					{
						Point point33 = (Point)this.VecEff.elementAt(num33);
						GameScreen.addEffectEndKill(9, point33.x, point33.y);
						GameScreen.addEffectEndKill(25, point33.x, point33.y - 2);
					}
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 61:
			case 77:
				for (int num34 = 0; num34 < this.VecEff.size(); num34++)
				{
					Point point34 = (Point)this.VecEff.elementAt(num34);
					for (int num35 = 0; num35 < point34.vecEffPoint.size(); num35++)
					{
						Point point35 = (Point)point34.vecEffPoint.elementAt(num35);
						point35.x += point34.vx;
					}
					if (this.f == point34.f)
					{
						LoadMap.timeVibrateScreen = 105;
						if (this.objKill != null)
						{
							if (this.objKill == GameScreen.player)
							{
								mSound.playSound(32, mSound.volumeSound);
							}
							else
							{
								GameScreen.addSoundEff(32);
							}
						}
						GameScreen.addEffectEndKill(40, point34.x, point34.y + point34.vy * this.f / 1000 - 4 + 10);
						if (this.typeEffect == 61)
						{
							GameScreen.addEffectEndKill(27, point34.x + 3, point34.y + point34.vy * this.f / 1000 + 10);
							GameScreen.addEffectEndKill(15, point34.x, point34.y + point34.vy * this.f / 1000);
							GameScreen.addEffectEndKill(0, point34.x, point34.y + point34.vy * this.f / 1000);
						}
						else if (this.typeEffect == 77)
						{
							mSound.playSound(32, mSound.volumeSound);
							GameScreen.addEffectEndKill(30, point34.x + 3, point34.y + point34.vy * this.f / 1000 + 10);
							GameScreen.addEffectEndKill(14, point34.x, point34.y + point34.vy * this.f / 1000);
							GameScreen.addEffectEndKill(0, point34.x, point34.y + point34.vy * this.f / 1000);
						}
					}
					else if (this.f < point34.f)
					{
						point34.x += point34.vx;
						flag2 = false;
					}
				}
				if (flag2)
				{
					this.removeEff();
				}
				break;
			case 62:
				for (int num36 = 0; num36 < this.VecEff.size(); num36++)
				{
					Point point36 = (Point)this.VecEff.elementAt(num36);
					point36.update();
					if (point36.f >= point36.fRe)
					{
						this.VecEff.removeElement(point36);
						num36--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				if (this.f % 3 == 0 && this.f < this.fRemove)
				{
					int num37 = this.x;
					int num38 = this.y;
					switch (this.Direction)
					{
					case 0:
						num38 += 20;
						break;
					case 1:
						num38 -= 20;
						break;
					case 2:
						num37 -= 20;
						break;
					case 3:
						num37 += 20;
						break;
					}
					GameScreen.addEffectEndKill(13, num37, num38);
					this.create_Sung_BaoDan();
				}
				if (this.f % 5 == 4 && this.f < this.fRemove && this.objBeKillMain != null && !this.objBeKillMain.isStop && !this.objBeKillMain.isRemove && MainObject.getDistance(this.objBeKillMain.x, this.objBeKillMain.y - this.objBeKillMain.hOne / 2, this.toX, this.toY) <= 30)
				{
					GameScreen.addEffectEndKill(12, this.xEff, this.yEff + this.objBeKillMain.hOne / 4);
				}
				break;
			case 63:
				for (int num39 = 0; num39 < this.VecEff.size(); num39++)
				{
					Point point37 = (Point)this.VecEff.elementAt(num39);
					point37.update();
					if (point37.f >= point37.fRe)
					{
						this.VecEff.removeElement(point37);
						num39--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				if (this.f < this.fRemove)
				{
					if (this.objBeKillMain == null)
					{
						if (this.f < this.fRemove)
						{
							this.f = this.fRemove;
						}
					}
					else
					{
						int num40 = this.x;
						int num41 = this.y;
						switch (this.Direction)
						{
						case 0:
							num41 += 20;
							break;
						case 1:
							num41 -= 20;
							break;
						case 2:
							num40 -= 20;
							break;
						case 3:
							num40 += 20;
							break;
						}
						if (this.f % 3 == 0)
						{
							GameScreen.addEffectEndKill(13, num40, num41);
						}
						this.create_Sung_DAY_DAN(this.toX, this.toY);
					}
				}
				if (this.f % 5 == 4 && this.f < this.fRemove && this.objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(7, this.toX, this.toY + this.objBeKillMain.hOne / 4);
				}
				break;
			case 65:
				for (int num42 = 0; num42 < this.vecObjBeKill.size(); num42++)
				{
					Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num42);
					MainObject mainObject2 = MainObject.get_Item_Object((int)object_Effect_Skill2.ID, (int)object_Effect_Skill2.tem);
					if (mainObject2 != null && this.objKill != null)
					{
						GameScreen.addEffectKill(88, this.objKill.ID, this.objKill.typeObject, (int)object_Effect_Skill2.ID, object_Effect_Skill2.tem, object_Effect_Skill2.hpShow, object_Effect_Skill2.hpLast);
					}
				}
				this.removeEff();
				break;
			case 66:
				for (int num43 = 0; num43 < this.vecObjBeKill.size(); num43++)
				{
					Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num43);
					MainObject mainObject3 = MainObject.get_Item_Object((int)object_Effect_Skill3.ID, (int)object_Effect_Skill3.tem);
					if (mainObject3 != null)
					{
						if (this.objKill != null)
						{
							GameScreen.addEffectKill(10, this.objKill.ID, this.objKill.typeObject, (int)object_Effect_Skill3.ID, object_Effect_Skill3.tem, object_Effect_Skill3.hpShow, object_Effect_Skill3.hpLast);
						}
						GameScreen.addEffectEndKill(0, mainObject3.x, mainObject3.y + 5);
					}
				}
				this.removeEff();
				break;
			case 67:
				if (this.f > 7 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 68:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				else if (this.objBeKillMain != null && !this.objBeKillMain.isStop && !this.objBeKillMain.isRemove)
				{
					if (this.objBeKillMain.Action == 4)
					{
						this.f = this.fRemove;
					}
					else
					{
						this.x = this.objBeKillMain.x;
						if (this.subType == 0)
						{
							this.y = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
						}
						else
						{
							this.y = this.objBeKillMain.y - this.objBeKillMain.hOne - 8;
						}
					}
				}
				break;
			case 69:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 72:
			case 74:
				for (int num44 = 0; num44 < this.VecEff.size(); num44++)
				{
					Point_Focus point_Focus = (Point_Focus)this.VecEff.elementAt(num44);
					point_Focus.update_Vx_Vy();
					if (point_Focus.f >= point_Focus.fRe)
					{
						GameScreen.addEffectEndKill(12, point_Focus.x, point_Focus.y + 10);
						this.VecEff.removeElement(point_Focus);
						num44--;
					}
				}
				if (this.VecEff.size() == 0 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 73:
				for (int num45 = 0; num45 < this.VecSubEff.size(); num45++)
				{
					Point point38 = (Point)this.VecSubEff.elementAt(num45);
					point38.f++;
					if (point38.f / 2 > 3)
					{
						this.VecSubEff.removeElement(point38);
						num45--;
					}
				}
				for (int num46 = 0; num46 < this.VecEff.size(); num46++)
				{
					Point point39 = (Point)this.VecEff.elementAt(num46);
					point39.update();
					if (point39.f >= point39.fRe)
					{
						GameScreen.addEffectEndKill(12, point39.x, point39.y + 10);
						this.VecEff.removeElement(point39);
						num46--;
					}
					else if (point39.f > 1)
					{
						Point point40 = new Point();
						point40.x = point39.x - point39.vx;
						point40.y = point39.y - point39.vy;
						this.VecSubEff.addElement(point40);
					}
				}
				if (this.f >= this.fRemove)
				{
					if (this.VecEff.size() == 0 && this.VecSubEff.size() == 0)
					{
						this.removeEff();
					}
				}
				else if (this.f % 4 == 0 && this.indexLan < this.vecObjBeKill.size())
				{
					if (this.indexLan >= this.vecObjBeKill.size())
					{
						this.f = this.fRemove;
					}
					else
					{
						MainObject mainObject4 = null;
						if (this.indexLan < this.vecObjBeKill.size())
						{
							this.f = 0;
							do
							{
								Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(this.indexLan);
								if (object_Effect_Skill4 != null)
								{
									mainObject4 = MainObject.get_Item_Object((int)object_Effect_Skill4.ID, (int)object_Effect_Skill4.tem);
									if (mainObject4 != null)
									{
										if (mainObject4.Action == 4)
										{
											mainObject4 = null;
										}
										else
										{
											if (this.objKill != null)
											{
												this.Direction = EffectSkill.setDirection(this.objKill, mainObject4);
												this.objKill.Direction = this.Direction;
												this.create_Sung_DAY_DAN(mainObject4.x, mainObject4.y - mainObject4.hOne / 2);
												this.objKill.fplash = 11;
											}
											int num47 = this.x;
											int num48 = this.y;
											switch (this.Direction)
											{
											case 0:
												num48 += 20;
												break;
											case 1:
												num48 -= 20;
												break;
											case 2:
												num47 -= 20;
												break;
											case 3:
												num47 += 20;
												break;
											}
											GameScreen.addEffectEndKill(13, num47, num48);
										}
									}
								}
								this.indexLan++;
							}
							while (mainObject4 == null && this.indexLan < this.vecObjBeKill.size());
						}
						if (this.indexLan >= this.vecObjBeKill.size() && mainObject4 == null)
						{
							this.f = this.fRemove;
						}
					}
				}
				break;
			case 76:
				for (int num49 = 0; num49 < this.VecEff.size(); num49++)
				{
					Point point41 = (Point)this.VecEff.elementAt(num49);
					point41.x += point41.vx;
					point41.y += point41.vy;
					int tile3 = GameCanvas.loadmap.getTile(point41.x / 1000, point41.y / 1000);
					if (tile3 == -1 || tile3 == 1 || !MainEffect.isInScreen(point41.x / 1000, point41.y / 1000, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight))
					{
						this.VecEff.removeElement(point41);
						num49--;
					}
				}
				if (this.VecEff.size() == 0 || this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 79:
				if (this.f == 0)
				{
					for (int num50 = 0; num50 < this.vecObjBeKill.size(); num50++)
					{
						Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num50);
						if (object_Effect_Skill5 == null)
						{
							this.vecObjBeKill.removeElement(object_Effect_Skill5);
							num50--;
						}
						else
						{
							GameScreen.addEffectKill(12, this.objKill.ID, this.objKill.typeObject, (int)object_Effect_Skill5.ID, object_Effect_Skill5.tem, object_Effect_Skill5.hpShow, object_Effect_Skill5.hpLast);
						}
					}
				}
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 80:
				if (this.objBeKillMain != null && !this.objBeKillMain.isStop && !this.objBeKillMain.isRemove)
				{
					if (this.f < this.fRemove)
					{
						if (this.f < 10)
						{
							this.x = this.objBeKillMain.x;
							this.y = this.objBeKillMain.y - 70;
						}
						else
						{
							this.vy += 2;
							if (this.f > 12)
							{
								this.objBeKillMain.Action = 3;
							}
							this.objBeKillMain.vx = 0;
							this.objBeKillMain.vy = 0;
						}
					}
					else
					{
						this.objBeKillMain.Action = 4;
						this.objBeKillMain.hp = 0;
						GameScreen.addEffectEndKill(11, this.objBeKillMain.x, this.objBeKillMain.y);
						this.removeEff();
					}
				}
				else
				{
					this.removeEff();
				}
				break;
			case 82:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 83:
				this.updateAngleHut_Mp_Hp();
				for (int num51 = 0; num51 < this.VecEff.size(); num51++)
				{
					Point point42 = (Point)this.VecEff.elementAt(num51);
					point42.f++;
					if (point42.f > 4)
					{
						this.VecEff.removeElement(point42);
						num51--;
					}
				}
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				break;
			case 85:
				for (int num52 = 0; num52 < this.VecEff.size(); num52++)
				{
					Line line5 = (Line)this.VecEff.elementAt(num52);
					line5.update();
					if (line5.f >= line5.fRe)
					{
						this.VecEff.removeElement(line5);
						num52--;
					}
				}
				if (this.objBeKillMain != null && !this.objBeKillMain.isRemove && this.objBeKillMain.Action != 4 && !this.objBeKillMain.isStop)
				{
					this.x1000 = this.objBeKillMain.x;
					this.y1000 = this.objBeKillMain.y;
					if (this.timeRemove > 0 && GameCanvas.timeNow - this.time >= (long)this.timeRemove)
					{
						this.removeEff();
					}
					else if (GameCanvas.gameTick % 2 == 0)
					{
						this.create_Line_NHANBAN_LV2();
					}
				}
				else if (this.f > 20)
				{
					this.removeEff();
				}
				break;
			case 87:
				if (this.objBeKillMain != null && !this.objBeKillMain.isRemove && this.objBeKillMain.Action != 4 && !this.objBeKillMain.isStop)
				{
					this.x = this.objBeKillMain.x;
					this.y = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
					if (this.timeRemove > 0 && GameCanvas.timeNow - this.time >= (long)this.timeRemove)
					{
						this.removeEff();
					}
				}
				else if (this.f > 20)
				{
					this.removeEff();
				}
				break;
			case 88:
				if (this.f < this.fRemove)
				{
					this.updateAngleXP();
					this.frame = this.setFrameAngle(this.gocT_Arc);
				}
				if (this.VecEff.size() == 0 && this.f > this.fRemove)
				{
					this.removeEff();
				}
				for (int num53 = 0; num53 < this.VecEff.size(); num53++)
				{
					Point point43 = (Point)this.VecEff.elementAt(num53);
					point43.f++;
					if (point43.f / 2 > 3)
					{
						this.VecEff.removeElement(point43);
						num53--;
					}
				}
				if (this.f == this.fRemove)
				{
					GameScreen.addEffectEndKill(36, this.x, this.y - 15);
					GameScreen.addEffectEndKill(14, this.x, this.y - 15);
				}
				break;
			case 89:
				if (this.f < this.fRemove)
				{
					this.updateAngleXP();
					this.frame = this.setFrameAngle(this.gocT_Arc);
				}
				if (this.VecEff.size() == 0 && this.f > this.fRemove)
				{
					this.isStop = true;
					this.isRemove = true;
				}
				for (int num54 = 0; num54 < this.VecEff.size(); num54++)
				{
					Point point44 = (Point)this.VecEff.elementAt(num54);
					point44.f++;
					if (point44.f / 2 > 3)
					{
						this.VecEff.removeElement(point44);
						num54--;
					}
				}
				break;
			case 90:
				this.update_Nova_Effect();
				break;
			case 91:
				this.update_Nova_Effect();
				break;
			case 92:
				if (this.f < this.fRemove)
				{
					this.updateAngleXP();
					this.frame = this.setFrameAngle(this.gocT_Arc);
				}
				if (this.VecEff.size() == 0 && this.f > this.fRemove)
				{
					this.isStop = true;
					this.isRemove = true;
				}
				for (int num55 = 0; num55 < this.VecEff.size(); num55++)
				{
					Point point45 = (Point)this.VecEff.elementAt(num55);
					point45.f++;
					if (point45.f / 2 > 3)
					{
						this.VecEff.removeElement(point45);
						num55--;
					}
				}
				break;
			case 93:
				this.update_Boss_De1();
				break;
			case 94:
				if (this.nFrame == null)
				{
					this.nFrame = new sbyte[]
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
					};
				}
				if (this.f > this.nFrame.Length - 1)
				{
					this.f = this.nFrame.Length - 6;
				}
				this.update_Boss_De2();
				break;
			case 95:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 96:
				if (this.f < this.fRemove)
				{
					this.updateAngleXP();
					this.frame = this.setFrameAngle(this.gocT_Arc);
				}
				if (this.VecEff.size() == 0 && this.f > this.fRemove)
				{
					this.removeEff();
				}
				for (int num56 = 0; num56 < this.VecEff.size(); num56++)
				{
					Point point46 = (Point)this.VecEff.elementAt(num56);
					point46.f++;
					if (point46.f / 2 > 3)
					{
						this.VecEff.removeElement(point46);
						num56--;
					}
				}
				if (this.f == this.fRemove)
				{
					GameScreen.addEffectEndKill(45, this.objBeKillMain.x, this.objBeKillMain.y - 20);
				}
				break;
			case 97:
				if (this.f >= this.fRemove && this.VecEff.size() == 0)
				{
					this.removeEff();
				}
				if (this.f < this.fRemove)
				{
					if (this.f == 8)
					{
						int num57 = 2;
						if (this.objBeKillMain != null && this.objKill != null)
						{
							this.objKill.Direction = EffectSkill.setDirection(this.objKill, this.objBeKillMain);
							num57 = this.objKill.Direction;
						}
						if (num57 == 2 || num57 == 3)
						{
							this.vY1000 = 1;
							this.vX1000 = 0;
						}
						else
						{
							this.vY1000 = 0;
							this.vX1000 = 1;
						}
						if (this.objBeKillMain != null && this.objKill != null)
						{
							int a2 = CRes.angle(this.objBeKillMain.x - this.objKill.x, this.objBeKillMain.y - (this.objKill.y - this.objKill.hOne / 2 + 10));
							int num58 = 320;
							if (num58 < GameCanvas.h)
							{
								num58 = GameCanvas.h;
							}
							if (num58 < GameCanvas.w)
							{
								num58 = GameCanvas.w;
							}
							this.x1000 = this.x + CRes.cos(a2) * num58 / 1000;
							this.y1000 = this.y + CRes.sin(a2) * num58 / 1000;
							this.toX = this.objBeKillMain.x;
							this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
							this.xdichTower = this.objBeKillMain.x;
							this.ydichTower = this.objBeKillMain.y;
							GameScreen.addEffectEndKill(0, this.xdichTower, this.ydichTower - this.objBeKillMain.hOne / 2);
							GameScreen.addEffectEndKill(26, this.xdichTower, this.ydichTower);
						}
					}
					if (this.f > 8 && this.f % 3 == 2)
					{
						Point point47 = new Point();
						point47.x = this.toX + CRes.random_Am_0(5);
						point47.y = this.toY + CRes.random_Am_0(5);
						this.VecEff.addElement(point47);
					}
				}
				for (int num59 = 0; num59 < this.VecEff.size(); num59++)
				{
					Point point48 = (Point)this.VecEff.elementAt(num59);
					point48.f++;
					if (point48.f >= 4)
					{
						this.VecEff.removeElement(point48);
						num59--;
					}
				}
				break;
			case 98:
				if (this.f < this.fRemove && this.f > 1)
				{
					Point point49 = new Point();
					point49.x = this.x - this.vx;
					point49.y = this.y - this.vy;
					this.VecEff.addElement(point49);
				}
				else if (this.VecEff.size() == 0 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				if (this.f == this.fRemove && this.objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(26, this.toX, this.toY + this.objBeKillMain.hOne / 2);
					GameScreen.addEffectEndKill(14, this.toX, this.toY + this.objBeKillMain.hOne / 2);
					GameScreen.addEffectEndKill(30, this.toX, this.toY + this.objBeKillMain.hOne / 2 + 10);
				}
				for (int num60 = 0; num60 < this.VecEff.size(); num60++)
				{
					Point point50 = (Point)this.VecEff.elementAt(num60);
					point50.f++;
					if (point50.f / 2 > 3)
					{
						this.VecEff.removeElement(point50);
						num60--;
					}
				}
				break;
			case 99:
				if (this.f < this.fRemove && this.f > 1)
				{
					Point point51 = new Point();
					point51.x = this.x - this.vx;
					point51.y = this.y - this.vy;
					this.VecEff.addElement(point51);
				}
				else if (this.VecEff.size() == 0 && this.f >= this.fRemove)
				{
					this.removeEff();
				}
				if (this.f == this.fRemove && this.objBeKillMain != null)
				{
					GameScreen.addEffectEndKill(48, this.toX, this.toY + this.objBeKillMain.hOne / 4);
				}
				for (int num61 = 0; num61 < this.VecEff.size(); num61++)
				{
					Point point52 = (Point)this.VecEff.elementAt(num61);
					point52.f++;
					if (point52.f / 2 > 3)
					{
						this.VecEff.removeElement(point52);
						num61--;
					}
				}
				break;
			case 100:
				this.update_Boss_Medusa2();
				break;
			case 101:
				this.frSleep++;
				if (this.frSleep > this.frameSleep.Length - 1)
				{
					this.frSleep = 0;
				}
				if (this.delay >= 0)
				{
					this.delay--;
				}
				if (this.delay < 0)
				{
					this.ispaintsleep = true;
				}
				if (!this.objBeKillMain.isSleep || this.objBeKillMain == null || this.objBeKillMain.hp <= 0 || (this.objBeKillMain != null && this.objBeKillMain.isRemove))
				{
					this.isRemove = true;
				}
				break;
			case 102:
				if (this.objBeKillMain != null)
				{
					this.x = this.objBeKillMain.x;
					this.y = this.objBeKillMain.y - 25;
				}
				this.frStun += 1;
				if ((int)this.frStun > this.frameStun.Length - 1)
				{
					this.frStun = 0;
				}
				if (!this.objBeKillMain.isStun || this.objBeKillMain == null || (this.objBeKillMain != null && this.objBeKillMain.isRemove))
				{
					this.isRemove = true;
				}
				break;
			case 103:
				if (this.objBeKillMain != null)
				{
					this.x = this.objBeKillMain.x;
					this.y = this.objBeKillMain.y;
				}
				if (this.timedelay >= 0)
				{
					this.timedelay--;
				}
				if (this.timedelay <= 0)
				{
					this.ysai = 10;
					for (int num62 = 0; num62 < this.arr_R.Length; num62++)
					{
						sbyte[] array = this.arr_R;
						int num63 = num62;
						array[num63] = (sbyte)((int)array[num63] + (int)((sbyte)(this.r / 2)));
						this.arr_radian[num62] += 5;
						if (this.arr_radian[num62] >= 360)
						{
							this.arr_radian[num62] = 0;
						}
					}
					this.r /= 2;
					if (this.r <= 0)
					{
						this.r = 0;
					}
				}
				if (!this.objBeKillMain.isnoBoss84 || this.objBeKillMain == null || this.objBeKillMain.hp <= 0 || (this.objBeKillMain != null && this.objBeKillMain.isRemove))
				{
					this.isRemove = true;
				}
				break;
			case 106:
			{
				this.x1000 = CRes.cos(this.angle) * this.R / 1024 + this.x;
				this.y1000 = CRes.sin(this.angle) * this.R / 1024 + this.y;
				Point point53 = new Point();
				point53.x = this.x1000;
				point53.y = this.y1000;
				this.VecEff.addElement(point53);
				this.angle += 20;
				if (this.angle >= 180)
				{
					this.size1--;
					this.angle = 180;
				}
				if (this.size1 <= 0)
				{
					this.removeEff();
				}
				int num64 = 2;
				if (this.objBeKillMain != null && this.objKill != null)
				{
					this.objKill.Direction = EffectSkill.setDirection(this.objKill, this.objBeKillMain);
					num64 = this.objKill.Direction;
				}
				if (num64 == 2 || num64 == 3)
				{
					this.vY1000 = 1;
					this.vX1000 = 0;
				}
				else
				{
					this.vY1000 = 0;
					this.vX1000 = 1;
				}
				int num65 = 320;
				if (num65 < GameCanvas.h)
				{
					num65 = GameCanvas.h;
				}
				if (num65 < GameCanvas.w)
				{
					num65 = GameCanvas.w;
				}
				if (this.angle > 60 && this.angle < 120)
				{
					this.R = this.y + CRes.sin(60) * num65 / 1000;
				}
				else
				{
					this.R = this.x + CRes.cos(0) * num65 / 1000;
				}
				for (int num66 = 0; num66 < this.VecEff.size(); num66++)
				{
					Point point54 = (Point)this.VecEff.elementAt(num66);
					point54.f++;
					if (point54.f >= 4)
					{
						this.VecEff.removeElement(point54);
						num66--;
					}
				}
				if (this.angle > 0 && this.angle < 90)
				{
					this.objKill.Direction = 3;
				}
				else
				{
					this.objKill.Direction = 2;
				}
				break;
			}
			case 107:
				for (int num67 = 0; num67 < this.VecEff.size(); num67++)
				{
					Line line6 = (Line)this.VecEff.elementAt(num67);
					line6.update();
					if (this.f >= this.fRemove && this.test == 0)
					{
						this.VecEff.removeElement(line6);
						num67--;
					}
				}
				this.create_Star_Line_In(this.vMax, this.xline, this.yline);
				if (MainObject.getDistance(this.objBeKillMain.x, this.objBeKillMain.y, GameScreen.player.x, GameScreen.player.y) <= 240)
				{
					LoadMap.timeVibrateScreen = 3;
				}
				if (!this.objBeKillMain.isno || this.objBeKillMain == null || this.objBeKillMain.hp <= 0 || (this.objBeKillMain != null && this.objBeKillMain.isRemove))
				{
					this.isRemove = true;
				}
				break;
			case 109:
			case 110:
				if (this.VecEff.size() > 0)
				{
					Point point55 = (Point)this.VecEff.elementAt(0);
					if (point55 != null)
					{
						this.x = point55.x;
						this.y = point55.y;
						this.VecEff.removeElement(point55);
					}
				}
				if (this.VecEff.size() <= 0)
				{
					this.removeEff();
					if (this.typeEffect == 109)
					{
						GameScreen.addEffectEndKill(15, this.toX, this.toY + this.objBeKillMain.hOne / 4);
					}
					else
					{
						GameScreen.addEffectEndKill(29, this.x + 3, this.y + this.vy * this.f / 1000 + 10);
					}
				}
				break;
			case 111:
				if (this.f >= this.fRemove)
				{
					this.removeEff();
				}
				break;
			case 124:
				this.x += this.vx;
				this.y += this.vy;
				if (this.vy <= 5)
				{
					this.vy++;
				}
				if (this.y + this.vy > this.yto)
				{
					this.isRemove = true;
					LoadMap.timeVibrateScreen = 103;
					int num68 = 16;
					this.removeEff();
					for (int num69 = 0; num69 < num68; num69++)
					{
						int x = 24 * EffectSkill.posx[(int)this.indexpost][num69] + CRes.random(10, 100);
						int y = 24 * EffectSkill.posy[(int)this.indexpost][num69] + CRes.random(10, 100);
						GameScreen.addEffectEndKill(36, x, y);
						GameScreen.addEffectEndKill(9, x, y);
					}
				}
				break;
			case 125:
			case 126:
			{
				this.x1000 = CRes.cos(this.angle) * this.R / 1024 + this.x;
				this.y1000 = CRes.sin(this.angle) * this.R / 1024 + this.y;
				Point point56 = new Point();
				point56.x = this.x1000;
				point56.y = this.y1000;
				this.VecEff.addElement(point56);
				this.angle += 20;
				if (this.angle >= 359)
				{
					this.size1--;
					this.angle = 359;
				}
				if (this.size1 <= 0)
				{
					this.removeEff();
					for (int num70 = 0; num70 < this.vecObjBeKill.size(); num70++)
					{
						Object_Effect_Skill object_Effect_Skill6 = (Object_Effect_Skill)this.vecObjBeKill.elementAt(num70);
						if (object_Effect_Skill6 != null)
						{
							MainObject mainObject5 = MainObject.get_Item_Object((int)object_Effect_Skill6.ID, (int)object_Effect_Skill6.tem);
							GameScreen.addEffectEndKill(36, mainObject5.x, mainObject5.y);
							GameScreen.addEffectEndKill(9, mainObject5.x, mainObject5.y);
						}
					}
				}
				int num71 = 2;
				if (this.objBeKillMain != null && this.objKill != null)
				{
					this.objKill.Direction = EffectSkill.setDirection(this.objKill, this.objBeKillMain);
					num71 = this.objKill.Direction;
				}
				if (num71 == 2 || num71 == 3)
				{
					this.vY1000 = 1;
					this.vX1000 = 0;
				}
				else
				{
					this.vY1000 = 0;
					this.vX1000 = 1;
				}
				int num72 = 320;
				if (num72 < GameCanvas.h)
				{
					num72 = GameCanvas.h;
				}
				if (num72 < GameCanvas.w)
				{
					num72 = GameCanvas.w;
				}
				if (this.angle > 60 && this.angle < 120)
				{
					this.R = this.y + CRes.sin(60) * num72 / 1000;
				}
				else
				{
					this.R = this.x + CRes.cos(0) * num72 / 1000;
				}
				for (int num73 = 0; num73 < this.VecEff.size(); num73++)
				{
					Point point57 = (Point)this.VecEff.elementAt(num73);
					point57.f++;
					if (point57.f >= 4)
					{
						this.VecEff.removeElement(point57);
						num73--;
					}
				}
				if (this.angle > 0 && this.angle < 90)
				{
					this.objKill.Direction = 3;
				}
				else
				{
					this.objKill.Direction = 2;
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi(string.Concat(new object[]
			{
				"Loi update Eff ",
				this.typeEffect,
				"  f=",
				this.f
			}));
			this.removeEff();
		}
		base.update();
		if (this.f > 200 && this.timeRemove == 0)
		{
			this.removeEff();
		}
	}

	// Token: 0x06000283 RID: 643 RVA: 0x000209D8 File Offset: 0x0001EBD8
	private void SetAddSoundTimeAdd()
	{
		if (this.objKill == null)
		{
			return;
		}
		if (this.typeEffect == 27)
		{
			this.indexSound = 9;
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(this.indexSound);
			}
		}
		else if (this.typeEffect == 51)
		{
			this.indexSound = 19;
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(this.indexSound);
			}
		}
		else if (this.typeEffect == 125 || this.typeEffect == 126 || this.typeEffect == 97 || this.typeEffect == 106 || this.typeEffect == 105)
		{
			this.indexSound = 13;
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(this.indexSound);
			}
		}
		else if (this.typeEffect == 62)
		{
			this.indexSound = 20;
			if (this.objKill == GameScreen.player)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
			else
			{
				GameScreen.addSoundEff(this.indexSound);
			}
		}
	}

	// Token: 0x06000284 RID: 644 RVA: 0x00020B48 File Offset: 0x0001ED48
	public void endUpdate()
	{
	}

	// Token: 0x06000285 RID: 645 RVA: 0x00020B4C File Offset: 0x0001ED4C
	public static int setDirection(MainObject idFrom, MainObject idTo)
	{
		int num = idFrom.x - idTo.x;
		int num2 = idFrom.y - idTo.y;
		int result;
		if (CRes.abs(num) > CRes.abs(num2))
		{
			if (num > 0)
			{
				result = 2;
			}
			else
			{
				result = 3;
			}
		}
		else if (num2 > 0)
		{
			result = 1;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000286 RID: 646 RVA: 0x00020BAC File Offset: 0x0001EDAC
	public int setDirection(int dx, int dy)
	{
		int result;
		if (CRes.abs(dx) > CRes.abs(dy))
		{
			if (dx > 0)
			{
				result = 2;
			}
			else
			{
				result = 3;
			}
		}
		else if (dy > 0)
		{
			result = 1;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x06000287 RID: 647 RVA: 0x00020BF0 File Offset: 0x0001EDF0
	public void setBeginKill(int more)
	{
		switch (this.Direction)
		{
		case 0:
			this.y += 10 + more;
			break;
		case 1:
			this.y -= 10 + more;
			break;
		case 2:
			this.x -= 10 + more;
			break;
		case 3:
			this.x += 10 + more;
			break;
		}
	}

	// Token: 0x06000288 RID: 648 RVA: 0x00020C7C File Offset: 0x0001EE7C
	private void setBeginKillXY1000(int more)
	{
		switch (this.Direction)
		{
		case 0:
			this.y1000 += 10 + more;
			break;
		case 1:
			this.y1000 -= 10 + more;
			break;
		case 2:
			this.x1000 -= 10 + more;
			break;
		case 3:
			this.x1000 += 10 + more;
			break;
		}
	}

	// Token: 0x06000289 RID: 649 RVA: 0x00020D08 File Offset: 0x0001EF08
	public int setFrameAngle(int goc)
	{
		int result;
		if (goc <= 15 || goc > 345)
		{
			result = 12;
		}
		else
		{
			int num = (goc - 15) / 15 + 1;
			if (num > 24)
			{
				num = 24;
			}
			result = (int)this.mpaintone_Bullet[num];
		}
		return result;
	}

	// Token: 0x0600028A RID: 650 RVA: 0x00020D50 File Offset: 0x0001EF50
	public void setPosLineIn(int sub)
	{
		switch (sub)
		{
		case 0:
			switch (this.Direction)
			{
			case 0:
				this.x -= 8;
				this.y += 20;
				break;
			case 1:
				this.x += 8;
				this.y += 40;
				break;
			case 2:
				this.x += 15;
				this.y += 20;
				break;
			case 3:
				this.x -= 15;
				this.y += 20;
				break;
			}
			break;
		case 1:
			switch (this.Direction)
			{
			case 0:
				this.y += 45;
				break;
			case 1:
				this.y += 10;
				break;
			case 2:
				this.x -= 16;
				this.y += 30;
				break;
			case 3:
				this.x += 18;
				this.y += 30;
				break;
			}
			break;
		case 3:
			switch (this.Direction)
			{
			case 0:
				this.x += 8;
				this.y += 25;
				break;
			case 1:
				this.x += 5;
				this.y += 45;
				break;
			case 2:
				this.x += 13;
				this.y += 35;
				break;
			case 3:
				this.x -= 13;
				this.y += 35;
				break;
			}
			break;
		case 4:
			switch (this.Direction)
			{
			case 0:
				this.x -= 15;
				this.y += 17;
				break;
			case 1:
				this.x += 15;
				this.y += 33;
				break;
			case 2:
				this.x += 3;
				this.y += 11;
				break;
			case 3:
				this.x -= 3;
				this.y += 11;
				break;
			}
			break;
		}
	}

	// Token: 0x0600028B RID: 651 RVA: 0x00021028 File Offset: 0x0001F228
	public void removeEff()
	{
		if (this.typeEffect == 103)
		{
			return;
		}
		if (this.ispaintArena && mSystem.isj2me)
		{
			EffectSkill.countSkillArena -= 1;
		}
		if (this.VecEff.size() > 0)
		{
			this.VecEff.removeAllElements();
		}
		if (this.VecSubEff.size() > 0)
		{
			this.VecSubEff.removeAllElements();
		}
		bool flag = true;
		if (mSystem.isj2me && GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
		{
			flag = false;
		}
		if ((int)this.timeAddNum == -1 && flag)
		{
			this.addNum();
		}
		this.isStop = true;
		this.isRemove = true;
		this.f = -1;
	}

	// Token: 0x0600028C RID: 652 RVA: 0x000210F4 File Offset: 0x0001F2F4
	public void addNum()
	{
		if (this.objKill != null && this.objKill.ID != GameScreen.player.ID && GameScreen.infoGame.isMapchienthanh())
		{
			return;
		}
		for (int i = 0; i < this.vecObjBeKill.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjBeKill.elementAt(i);
			if (object_Effect_Skill != null)
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				if (mainObject != null)
				{
					if (mainObject != null)
					{
						if (!this.isEff)
						{
							int typeColor = 6;
							if (object_Effect_Skill.hpShow == 0)
							{
								if (mainObject == GameScreen.player)
								{
									typeColor = 7;
								}
								GameScreen.addEffectNum(T.hut, mainObject.x, mainObject.y - mainObject.hOne, typeColor, (int)object_Effect_Skill.ID);
							}
							else
							{
								if (this.objKill != null)
								{
									int num = EffectSkill.setAddEffKillPlus(object_Effect_Skill.mEffTypePlus, this.objKill, mainObject, object_Effect_Skill.mEff_HP_Plus);
									if (num != -1)
									{
										typeColor = num;
									}
								}
								if (this.typeEffect == 41)
								{
									GameScreen.addEffectNum("+" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, (this.subType != 0) ? 4 : 3, (int)object_Effect_Skill.ID);
								}
								else
								{
									GameScreen.addEffectNum("-" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, typeColor, (int)object_Effect_Skill.ID);
								}
							}
							if ((int)mainObject.typeObject == 1)
							{
								mainObject.hp = object_Effect_Skill.hpLast;
								if (mainObject.hp <= 0)
								{
									if (this.objKill != null)
									{
										MainObject.startDeadFly((MainMonster)mainObject, this.objKill.ID, CRes.random(3));
									}
									mainObject.resetAction();
									mainObject.Action = 4;
									mainObject.timedie = GameCanvas.timeNow;
									GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
								}
							}
						}
						if (this.typeEffect != 41 && this.typeEffect != 58 && this.typeEffect != 42 && (object_Effect_Skill.hpShow > 0 || (this.objKill != null && this.objKill == GameScreen.player)))
						{
							if ((int)mainObject.typeObject == 1)
							{
								if (mainObject.Action != 3)
								{
									if (!mainObject.isServerControl)
									{
										mainObject.resetAction();
									}
									mainObject.Action = 3;
									mainObject.f = 0;
								}
							}
							else if ((int)mainObject.typeObject == 0)
							{
								if (mainObject.eye != 3)
								{
									if (this.objKill != null && (int)this.objKill.typeObject == 0 && mainObject.hp > mainObject.maxHp / 2 && object_Effect_Skill.hpShow <= mainObject.maxHp / 20)
									{
										mainObject.eye = 4;
										mainObject.timeEye = -6;
									}
									else
									{
										mainObject.eye = 2;
										mainObject.timeEye = 0;
									}
								}
								if (CRes.random(5) == 0)
								{
									mainObject.dy = -CRes.random(2, 5);
								}
								if (mainObject == GameScreen.player && CRes.random(3) == 0)
								{
									mSound.playSound(38, mSound.volumeSound);
								}
							}
						}
					}
				}
			}
		}
		if (!this.isEff && this.objKill != null && (int)this.objKill.typeObject != 9 && this.objKill.hp <= 0 && this.objKill.Action != 4)
		{
			this.objKill.resetAction();
			this.objKill.Action = 4;
			GameScreen.addEffectEndKill(11, this.objKill.x, this.objKill.y);
		}
	}

	// Token: 0x0600028D RID: 653 RVA: 0x000214D8 File Offset: 0x0001F6D8
	private void createXP()
	{
		if (this.objKill == null)
		{
			this.gocT_Arc = 0;
		}
		else
		{
			switch (this.objKill.Direction)
			{
			case 0:
				this.gocT_Arc = 0;
				break;
			case 1:
				this.gocT_Arc = 180;
				break;
			case 2:
				this.gocT_Arc = 90;
				break;
			case 3:
				this.gocT_Arc = 270;
				break;
			}
		}
		this.va = 6144;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
	}

	// Token: 0x0600028E RID: 654 RVA: 0x000215B4 File Offset: 0x0001F7B4
	private void createHut_Mp_Hp()
	{
		switch (CRes.random(4))
		{
		case 0:
			this.gocT_Arc = 0;
			break;
		case 1:
			this.gocT_Arc = 180;
			break;
		case 2:
			this.gocT_Arc = 90;
			break;
		case 3:
			this.gocT_Arc = 270;
			break;
		}
		this.va = 6144;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
	}

	// Token: 0x0600028F RID: 655 RVA: 0x00021674 File Offset: 0x0001F874
	public void createNormal()
	{
		if (this.objKill == null)
		{
			this.gocT_Arc = 0;
		}
		else
		{
			switch (this.objKill.Direction)
			{
			case 0:
				this.gocT_Arc = 90;
				break;
			case 1:
				this.gocT_Arc = 270;
				break;
			case 2:
				this.gocT_Arc = 180;
				break;
			case 3:
				this.gocT_Arc = 0;
				break;
			}
		}
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
	}

	// Token: 0x06000290 RID: 656 RVA: 0x00021750 File Offset: 0x0001F950
	public void createDanFocus()
	{
		switch (CRes.random(4))
		{
		case 0:
			this.gocT_Arc = 90;
			break;
		case 1:
			this.gocT_Arc = 270;
			break;
		case 2:
			this.gocT_Arc = 180;
			break;
		case 3:
			this.gocT_Arc = 0;
			break;
		}
		this.va = 4096;
		this.vx = 0;
		this.vy = 0;
		this.life = 0;
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
	}

	// Token: 0x06000291 RID: 657 RVA: 0x00021810 File Offset: 0x0001FA10
	public Point_Focus create_Speed(int xdich, int ydich, Point_Focus p)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		if (num == 0)
		{
			num = 1;
		}
		int num2 = xdich / num;
		int num3 = ydich / num;
		if (CRes.abs(num2) > CRes.abs(xdich))
		{
			num2 = xdich;
		}
		if (CRes.abs(num3) > CRes.abs(ydich))
		{
			num3 = ydich;
		}
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		if (p != null)
		{
			p.vx = num2;
			p.vy = num3;
			p.toX = this.toX;
			p.toY = this.toY;
			p.fRe = num;
		}
		else
		{
			this.fRemove = num;
			this.vx = num2;
			this.vy = num3;
		}
		return p;
	}

	// Token: 0x06000292 RID: 658 RVA: 0x00021904 File Offset: 0x0001FB04
	public Point_Focus create_Speed_More(int xdich, int ydich, Point_Focus p, MainObject objSet)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		if (num == 0)
		{
			num = 1;
		}
		int num2 = xdich / num;
		int num3 = ydich / num;
		if (CRes.abs(num2) > CRes.abs(xdich))
		{
			num2 = xdich;
		}
		if (CRes.abs(num3) > CRes.abs(ydich))
		{
			num3 = ydich;
		}
		this.toX = objSet.x;
		this.toY = objSet.y - objSet.hOne / 2;
		if (p != null)
		{
			p.vx = num2;
			p.vy = num3;
			p.toX = this.toX;
			p.toY = this.toY;
			p.fRe = num;
		}
		else
		{
			this.fRemove = num;
			this.vx = num2;
			this.vy = num3;
		}
		return p;
	}

	// Token: 0x06000293 RID: 659 RVA: 0x000219E0 File Offset: 0x0001FBE0
	public Point_Focus create_Speed_noToXY(int xdich, int ydich, Point_Focus p)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		if (num == 0)
		{
			num = 1;
		}
		int num2 = xdich / num;
		int num3 = ydich / num;
		if (CRes.abs(num2) > CRes.abs(xdich))
		{
			num2 = xdich;
		}
		if (CRes.abs(num3) > CRes.abs(ydich))
		{
			num3 = ydich;
		}
		if (p != null)
		{
			p.vx = num2;
			p.vy = num3;
			p.toX = this.toX;
			p.toY = this.toY;
			p.fRe = num;
		}
		else
		{
			this.fRemove = num;
			this.vx = num2;
			this.vy = num3;
		}
		return p;
	}

	// Token: 0x06000294 RID: 660 RVA: 0x00021A98 File Offset: 0x0001FC98
	public void create_Speed_Kiem_LV5(int xdich, int ydich)
	{
		if (ydich == 0)
		{
			ydich = 1;
		}
		if (xdich == 0)
		{
			xdich = 1;
		}
		int num = MainObject.getDistance(xdich, ydich) / this.vMax;
		if (num == 0)
		{
			num = 1;
		}
		int num2 = xdich / num;
		int num3 = ydich / num;
		if (CRes.abs(num2) > CRes.abs(xdich))
		{
			num2 = xdich;
		}
		if (CRes.abs(num3) > CRes.abs(ydich))
		{
			num3 = ydich;
		}
		this.fRemove = num;
		this.vx = num2;
		this.vy = num3;
	}

	// Token: 0x06000295 RID: 661 RVA: 0x00021B18 File Offset: 0x0001FD18
	private void create_Star()
	{
		this.x1000 = this.objBeKillMain.x * 1000;
		this.y1000 = this.objBeKillMain.y * 1000 - this.objBeKillMain.hOne / 2 * 1000;
		this.colorpaint = new int[3];
		for (int i = 0; i < 3; i++)
		{
			this.colorpaint[i] = EffectSkill.colorStar[0][CRes.random(3)];
		}
		this.fRemove = CRes.random(5, 9);
		this.mTamgiac = mSystem.new_M_Int(6, 4);
		for (int j = 0; j < 3; j++)
		{
			int num = CRes.random(5 + 60 * j, 55 + 60 * j);
			int num2 = CRes.random(20, 30);
			this.mTamgiac[j * 2][0] = CRes.sin(CRes.fixangle(num)) * num2 + this.x1000;
			this.mTamgiac[j * 2][1] = CRes.cos(CRes.fixangle(num)) * num2 + this.y1000;
			int num3 = num + CRes.random_Am(4, 12);
			int num4 = num2 + CRes.random_Am(3, 10);
			this.mTamgiac[j * 2][2] = CRes.sin(CRes.fixangle(num3)) * num4 + this.x1000;
			this.mTamgiac[j * 2][3] = CRes.cos(CRes.fixangle(num3)) * num4 + this.y1000;
			num += 180;
			num2 += CRes.random_Am(3, 10);
			this.mTamgiac[j * 2 + 1][0] = CRes.sin(CRes.fixangle(num)) * num2 + this.x1000;
			this.mTamgiac[j * 2 + 1][1] = CRes.cos(CRes.fixangle(num)) * num2 + this.y1000;
			num3 += 180;
			num4 = num2 + CRes.random_Am(3, 10);
			this.mTamgiac[j * 2 + 1][2] = CRes.sin(CRes.fixangle(num3)) * num4 + this.x1000;
			this.mTamgiac[j * 2 + 1][3] = CRes.cos(CRes.fixangle(num3)) * num4 + this.y1000;
		}
	}

	// Token: 0x06000296 RID: 662 RVA: 0x00021D38 File Offset: 0x0001FF38
	private void createLighting(int xFrom, int yFrom, int xTo, int yTo, bool isEnd)
	{
		int num = 0;
		int num2 = MainObject.getDistance(xFrom, yFrom, xTo, yTo) / 15 + CRes.random(3);
		int num3 = CRes.random(2);
		int num4 = CRes.angle(xTo - xFrom, yTo - yFrom);
		for (int i = 0; i < num2; i++)
		{
			Point point = new Point();
			if (i == 0)
			{
				point.x = xFrom * 1000;
				point.y = yFrom * 1000;
			}
			else
			{
				Point point2 = (Point)this.VecEff.elementAt(i - 1);
				int num5 = 20 + CRes.random_Am_0(10);
				int distance = MainObject.getDistance(point2.x / 1000, point2.y / 1000, xTo, yTo);
				if ((distance < 25 || i == num2 - 1) && isEnd)
				{
					point.x = xTo * 1000;
					point.y = yTo * 1000;
					this.VecEff.addElement(point);
					break;
				}
				int num6 = num4;
				if (isEnd)
				{
					if (CRes.abs(num) > 50)
					{
						if (num > 0)
						{
							num6 -= CRes.random(5, 50);
						}
						else
						{
							num6 += CRes.random(5, 50);
						}
					}
					else if (i % 2 == num3)
					{
						num6 -= CRes.random(5, 50);
					}
					else
					{
						num6 += CRes.random(5, 50);
					}
				}
				else if (CRes.abs(num) > 50)
				{
					if (num > 0)
					{
						num6 -= CRes.random(5, 50);
					}
					else
					{
						num6 += CRes.random(5, 50);
					}
				}
				else if (i % 2 == num3)
				{
					num6 -= CRes.random(10, 40);
				}
				else
				{
					num6 += CRes.random(10, 40);
				}
				num += num6 - num4;
				num6 = CRes.fixangle(num6);
				point.x = point2.x + CRes.cos(num6) * num5;
				point.y = point2.y + CRes.sin(num6) * num5;
				if (CRes.random(6) < 5)
				{
					this.VecSubEff.addElement(point);
					Point point3 = new Point();
					point3 = point;
					int num7 = CRes.random(3, 7);
					for (int j = 0; j < num7; j++)
					{
						int num8 = 5 + CRes.random_Am_0(3);
						int num9 = num6;
						if (j % 2 == num3)
						{
							num9 -= CRes.random(10, 40);
						}
						else
						{
							num9 += CRes.random(10, 40);
						}
						num9 = CRes.fixangle(num9);
						Point point4 = new Point();
						point4.x = point3.x + CRes.cos(num9) * num8;
						point4.y = point3.y + CRes.sin(num9) * num8;
						this.VecSubEff.addElement(point4);
						point3 = point4;
					}
					point3.x = -1;
					this.VecSubEff.addElement(point3);
				}
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x06000297 RID: 663 RVA: 0x00022048 File Offset: 0x00020248
	public Point create_Stone_Drop(int xTo, int yTo)
	{
		Point point = new Point();
		int num = CRes.random(0, 40);
		int a = CRes.random(20, 50);
		this.x = MainScreen.cameraMain.xCam - num;
		int num2 = CRes.abs(this.x - xTo);
		this.fRemove = CRes.abs(num2 / this.vx);
		if (this.fRemove == 0)
		{
			this.fRemove = 1;
		}
		this.y = yTo - num2 * 1000 / CRes.tan(a);
		int num3 = CRes.abs(this.y - yTo);
		this.vY1000 = num3 * 1000 / this.fRemove;
		point.y = this.y;
		point.x = this.x;
		point.vx = this.vx;
		point.vy = this.vY1000;
		point.f = this.fRemove;
		return point;
	}

	// Token: 0x06000298 RID: 664 RVA: 0x0002212C File Offset: 0x0002032C
	public Point create_ICE_Drop(int xTo, int yTo)
	{
		Point point = new Point();
		this.x = xTo;
		this.y = MainScreen.cameraMain.yCam;
		int num = CRes.abs(this.y - yTo);
		this.fRemove = num / this.vMax;
		if (this.fRemove == 0)
		{
			this.fRemove = 1;
		}
		this.vY1000 = num * 1000 / this.fRemove;
		point.y = this.y;
		point.x = this.x;
		point.vx = 0;
		point.vy = this.vY1000;
		point.f = this.fRemove;
		return point;
	}

	// Token: 0x06000299 RID: 665 RVA: 0x000221D0 File Offset: 0x000203D0
	private void create_Crack_Earth()
	{
		LoadMap.timeVibrateScreen = CRes.random(6, 12);
		this.levelPaint = -1;
		this.fRemove = 20;
		this.timeAddNum = 8;
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		if (CRes.abs(this.x - this.toX) > CRes.abs(this.y - this.toY))
		{
			this.xline = 0;
			this.yline = 1;
		}
		else
		{
			this.xline = 1;
			this.yline = 0;
		}
		int num = MainObject.getDistance(this.x, this.y, this.toX, this.toY);
		num += 24;
		int a = CRes.angle(this.toX - this.x, this.toY - this.y);
		int xTo = this.x + CRes.cos(a) * num / 1000;
		int yTo = this.y + CRes.sin(a) * num / 1000;
		this.createLighting(this.x, this.y, xTo, yTo, false);
	}

	// Token: 0x0600029A RID: 666 RVA: 0x0002230C File Offset: 0x0002050C
	private void create_Nova()
	{
		this.fraImgEff = new FrameImage(57);
		this.fraImgSubEff = new FrameImage(3);
		this.fRemove = 14;
		this.vMax = 6;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * this.vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
			int num = (this.x + point.vx) * 100 - this.x;
			int num2 = (this.y + point.vy) * 100 - this.y;
			int frameAngle = CRes.angle(num, num2);
			point.frame = this.setFrameAngle(frameAngle);
		}
	}

	// Token: 0x0600029B RID: 667 RVA: 0x00022414 File Offset: 0x00020614
	private void create_Poison_Nova()
	{
		this.fraImgEff = new FrameImage(125);
		this.fraImgSubEff = new FrameImage(3);
		this.fRemove = 14;
		this.vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * this.vMax;
			point.vy = CRes.sin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
			int num = (this.x + point.vx) * 100 - this.x;
			int num2 = (this.y + point.vy) * 100 - this.y;
			int frameAngle = CRes.angle(num, num2);
			point.frame = this.setFrameAngle(frameAngle);
		}
	}

	// Token: 0x0600029C RID: 668 RVA: 0x0002251C File Offset: 0x0002071C
	private void create_Ice_Arc()
	{
		this.fraImgEff = new FrameImage(29);
		this.fraImgSubEff = new FrameImage(42);
		this.fRemove = 25;
		this.vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * this.vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x0600029D RID: 669 RVA: 0x000225E0 File Offset: 0x000207E0
	private void create_Fire_Arc()
	{
		this.fraImgEff = new FrameImage(41);
		this.fraImgSubEff = new FrameImage(42);
		this.fRemove = 25;
		this.vMax = 5;
		for (int i = 0; i < 16; i++)
		{
			Point point = new Point();
			point.x = this.x * 1000;
			point.y = this.y * 1000;
			point.vx = 2 * CRes.cos(225 * i / 10) * this.vMax;
			point.vy = 1 * CRes.sin(225 * i / 10) * this.vMax;
			point.f = 0;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x0600029E RID: 670 RVA: 0x000226A4 File Offset: 0x000208A4
	private void create_Arrow_Rain()
	{
		if (this.f == -1)
		{
			this.VecEff.removeAllElements();
		}
		for (int i = 0; i < this.vecObjBeKill.size(); i++)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjBeKill.elementAt(i);
			if (object_Effect_Skill != null)
			{
				MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
				if (mainObject != null)
				{
					int num = CRes.random(1, 4);
					if (GameCanvas.lowGraphic)
					{
						num = CRes.random(1, 3);
					}
					for (int j = 0; j < num; j++)
					{
						this.vMax = CRes.random(14, 18);
						Point point = new Point();
						point.x = mainObject.x - 70 + CRes.random_Am_0(15);
						point.y = this.y1000;
						int xdich = mainObject.x - point.x + CRes.random_Am_0(30);
						int num2 = mainObject.y - point.y + 8 + CRes.random_Am_0(10);
						if (num2 / this.vMax > 8)
						{
							this.vMax = num2 / 8;
						}
						Point_Focus point_Focus = new Point_Focus();
						point_Focus = this.create_Speed(xdich, num2, point_Focus);
						point.vx = point_Focus.vx;
						point.vy = point_Focus.vy;
						point.fRe = point_Focus.fRe;
						point.f = 0;
						this.VecEff.addElement(point);
					}
				}
			}
		}
	}

	// Token: 0x0600029F RID: 671 RVA: 0x00022824 File Offset: 0x00020A24
	public void create_Kill_2Kiem_Lv2()
	{
		this.savex = this.objKill.x;
		this.savey = this.objKill.y;
		if (this.objKill != null)
		{
			this.y += this.objKill.hOne / 2;
			this.objKill.isTanHinh = true;
			this.objKill.timeTanHinh = 0;
		}
		this.fraImgEff = new FrameImage(50);
		this.vMax = 20;
		int num;
		int num2;
		if (this.objBeKillMain != null)
		{
			num = this.objBeKillMain.x - this.x;
			num2 = this.objBeKillMain.y - this.y;
		}
		else
		{
			num = this.toX - this.x;
			num2 = this.toY - this.y;
		}
		int distance = MainObject.getDistance(num, num2);
		int a = CRes.angle(num, num2);
		int num3 = distance;
		this.toX = this.x + num3 * CRes.cos(a) / 1000;
		this.toY = this.y + num3 * CRes.sin(a) / 1000;
		int toX = this.toX;
		int toY = this.toY;
		int num4;
		do
		{
			this.toX = toX;
			this.toY = toY;
			if (num3 > 120)
			{
				num4 = -1;
			}
			else
			{
				num3 += 10;
				toX = this.x + num3 * CRes.cos(a) / 1000;
				toY = this.y + num3 * CRes.sin(a) / 1000;
				num4 = GameCanvas.loadmap.getTile(this.toX, this.toY);
			}
		}
		while (num4 != -1 && num4 != 1);
		num = this.toX - this.x;
		num2 = this.toY - this.y;
		if (num2 == 0)
		{
			num2 = 1;
		}
		if (num == 0)
		{
			num = 1;
		}
		int num5 = MainObject.getDistance(num, num2) / this.vMax;
		if (num5 == 0)
		{
			num5 = 1;
		}
		int num6 = num / num5;
		int num7 = num2 / num5;
		if (CRes.abs(num6) > CRes.abs(num))
		{
			num6 = num;
		}
		if (CRes.abs(num7) > CRes.abs(num2))
		{
			num7 = num2;
		}
		this.vx = num6;
		this.vy = num7;
		this.fRemove = num5;
		if (this.fRemove > 0)
		{
			this.timeAddNum = (sbyte)(this.fRemove / 2);
		}
		if (this.objKill != null && this.objBeKillMain != null)
		{
			this.toX = this.objKill.x + (this.fRemove - 1) * num6;
			if (this.objBeKillMain != null)
			{
				this.toY = this.objKill.y + this.objBeKillMain.hOne / 4 + (this.fRemove - 1) * num7;
			}
			else
			{
				this.toY = this.objKill.y + (this.fRemove - 1) * num7;
			}
		}
	}

	// Token: 0x060002A0 RID: 672 RVA: 0x00022B18 File Offset: 0x00020D18
	private void create_Star_Line_In(int vline, int minline, int maxline)
	{
		if (this.f == -1)
		{
			this.VecEff.removeAllElements();
		}
		int num = 4;
		this.colorpaint = new int[num];
		if (maxline <= minline)
		{
			maxline = minline + 1;
		}
		for (int i = 0; i < num; i++)
		{
			if (CRes.random(2) == 0)
			{
				this.colorpaint[i] = EffectSkill.colorStar[this.indexColorStar][CRes.random(3)];
			}
			else
			{
				this.colorpaint[i] = EffectSkill.colorStar[this.indexColorStar][2];
			}
		}
		for (int j = 0; j < num; j++)
		{
			Line line = new Line();
			int num2 = 5 + 180 / num * j;
			int num3 = 180 / num + 180 / num * j - 5;
			if (num3 <= num2)
			{
				num3 = num2 + 1;
			}
			int num4 = CRes.random(minline, maxline);
			int num5 = CRes.random(vline, vline + 3);
			int num6 = CRes.random(num2, num3);
			int num7 = CRes.random(13, 23);
			bool is2Line = CRes.random(4) == 0;
			num6 = CRes.fixangle(num6);
			line.setLine(this.x1000 - CRes.sin(num6) * (num4 + num7), this.y1000 - CRes.cos(num6) * (num4 + num7), this.x1000 - CRes.sin(num6) * num7, this.y1000 - CRes.cos(num6) * num7, CRes.sin(num6) * num5, CRes.cos(num6) * num5, is2Line);
			this.VecEff.addElement(line);
			line = new Line();
			num6 += 180 + CRes.random_Am(2, 5);
			num6 = CRes.fixangle(num6);
			line.setLine(this.x1000 - CRes.sin(num6) * (num4 + num7), this.y1000 - CRes.cos(num6) * (num4 + num7), this.x1000 - CRes.sin(num6) * num7, this.y1000 - CRes.cos(num6) * num7, CRes.sin(num6) * num5, CRes.cos(num6) * num5, is2Line);
			this.VecEff.addElement(line);
		}
	}

	// Token: 0x060002A1 RID: 673 RVA: 0x00022D40 File Offset: 0x00020F40
	private void create_Line_NHANBAN_LV2()
	{
		int num = CRes.random(1, 3);
		for (int i = 0; i < num; i++)
		{
			Line line = new Line();
			int num2 = CRes.random(3, 12);
			int num3;
			if (num2 <= 5)
			{
				line.fRe = 16;
				num3 = 2;
			}
			else if (num2 <= 8)
			{
				num3 = 4;
				line.fRe = 12;
			}
			else
			{
				num3 = 5;
				line.fRe = 9;
			}
			int num4 = this.x1000 + CRes.random_Am_0(15);
			int num5 = this.y1000 - CRes.random_Am_0(10);
			line.setLine(num4, num5, num4, num5 - num2, 0, -num3, false);
			line.idColor = CRes.random(3);
			this.VecEff.addElement(line);
		}
	}

	// Token: 0x060002A2 RID: 674 RVA: 0x00022E00 File Offset: 0x00021000
	private void create_Star_Point_In()
	{
		int num = CRes.random(0, 45);
		for (int i = 0; i < 8; i++)
		{
			Point point = new Point();
			int num2 = 4;
			int num3 = num + 360 * i / 8;
			int num4 = 30;
			point.x = this.x1000 - CRes.sin(CRes.fixangle(num3)) * num4;
			point.y = this.y1000 - CRes.cos(CRes.fixangle(num3)) * num4;
			point.vx = CRes.sin(CRes.fixangle(num3)) * num2;
			point.vy = CRes.cos(CRes.fixangle(num3)) * num2;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002A3 RID: 675 RVA: 0x00022EB0 File Offset: 0x000210B0
	private void create_Buff_Point_In()
	{
		int num = this.subType;
		if (num >= 9)
		{
			num = 4;
		}
		else if (num > 3 && num > 4 && num < 9)
		{
			num -= 5;
		}
		this.colorBuff = EffectSkill.colorBuffMain[num][CRes.random(4)];
		this.colorpaint = new int[12];
		int num2 = CRes.random(0, 30);
		for (int i = 0; i < 12; i++)
		{
			this.colorpaint[i] = EffectSkill.colorBuffMain[num][CRes.random(3)];
			Line line = new Line();
			int num3 = 5;
			int num4 = num2 + 360 * i / 12;
			int num5 = CRes.random(20, 40);
			if (CRes.random(3) == 0)
			{
				num3 = 8;
				num5 = CRes.random(40, 55);
			}
			line.vx = CRes.sin(CRes.fixangle(num4)) * num3;
			line.vy = CRes.cos(CRes.fixangle(num4)) * num3;
			line.x0 = this.x1000 - CRes.sin(CRes.fixangle(num4)) * num5;
			line.y0 = this.y1000 - CRes.cos(CRes.fixangle(num4)) * num5;
			line.y1 = this.y1000 - CRes.cos(CRes.fixangle(num4)) * (num5 + 6);
			line.x1 = this.x1000 - CRes.sin(CRes.fixangle(num4)) * (num5 + 6);
			line.is2Line = (CRes.random(3) == 0);
			this.VecEff.addElement(line);
		}
	}

	// Token: 0x060002A4 RID: 676 RVA: 0x00023040 File Offset: 0x00021240
	private void create_Mon_Buff()
	{
		int num = this.subType;
		if (num > 3 && num > 4 && num < 9)
		{
			num -= 5;
		}
		this.colorBuff = EffectSkill.colorBuffMain[num][CRes.random(4)];
		this.colorpaint = new int[12];
		int num2 = CRes.random(0, 30);
		for (int i = 0; i < 12; i++)
		{
			this.colorpaint[i] = EffectSkill.colorBuffMain[num][CRes.random(3)];
			Line line = new Line();
			int num3 = 4;
			int num4 = num2 + 360 * i / 12;
			int num5 = CRes.random(10, 25);
			if (CRes.random(3) == 0)
			{
				num3 = 6;
				num5 = CRes.random(20, 40);
			}
			line.vx = CRes.sin(CRes.fixangle(num4)) * num3;
			line.vy = CRes.cos(CRes.fixangle(num4)) * num3;
			line.x0 = this.x1000 - CRes.sin(CRes.fixangle(num4)) * num5;
			line.y0 = this.y1000 - CRes.cos(CRes.fixangle(num4)) * num5;
			line.y1 = this.y1000 - CRes.cos(CRes.fixangle(num4)) * (num5 + 6);
			line.x1 = this.x1000 - CRes.sin(CRes.fixangle(num4)) * (num5 + 6);
			line.is2Line = (CRes.random(3) == 0);
			this.VecEff.addElement(line);
		}
	}

	// Token: 0x060002A5 RID: 677 RVA: 0x000231C0 File Offset: 0x000213C0
	public void create_2Kiem_Lv4(int goc, MainObject objBeKill)
	{
		int num;
		int num2;
		if (objBeKill != null)
		{
			num = this.x - objBeKill.x;
			num2 = this.y - (objBeKill.y - objBeKill.hOne / 2);
		}
		else
		{
			num = this.x - this.toX;
			num2 = this.y - this.toY;
		}
		int a = CRes.fixangle(CRes.angle(num, num2) + goc);
		int a2 = CRes.fixangle(CRes.angle(-num, -num2) + goc);
		int num3 = 50;
		int num4 = 30;
		Point point = new Point();
		if (objBeKill != null)
		{
			point.x = objBeKill.x + num3 * CRes.cos(a) / 1000;
			point.y = objBeKill.y - objBeKill.hOne / 2 + num3 * CRes.sin(a) / 1000;
		}
		else
		{
			point.x = this.toX + num3 * CRes.cos(a) / 1000;
			point.y = this.toY + num3 * CRes.sin(a) / 1000;
		}
		point.vx = num4 * CRes.cos(a2) / 1000;
		point.vy = num4 * CRes.sin(a2) / 1000;
		this.VecEff.addElement(point);
	}

	// Token: 0x060002A6 RID: 678 RVA: 0x00023310 File Offset: 0x00021510
	public void create_2Kiem_Lv3()
	{
		this.fraImgEff = new FrameImage(15);
		this.fraImgSubEff = new FrameImage(24);
		this.fraImgSub2Eff = new FrameImage(26);
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		this.vMax = 16;
		this.fRemove = 6;
		switch (this.Direction)
		{
		case 0:
			this.frame = 6;
			break;
		case 1:
			this.frame = 18;
			break;
		case 2:
			this.frame = 0;
			break;
		case 3:
			this.frame = 12;
			break;
		}
		int num = 0;
		int num2 = 14;
		int num3 = 18;
		for (int i = 0; i < 3; i++)
		{
			Point point = new Point();
			switch (this.Direction)
			{
			case 0:
				if (i == 0)
				{
					point.y = this.y + 25;
					point.x = this.x;
				}
				else if (i == 1)
				{
					point.y = this.y + 25 - num3;
					point.x = this.x + num2;
				}
				else if (i == 2)
				{
					point.y = this.y + 25 - num3;
					point.x = this.x - num2;
				}
				break;
			case 1:
				if (i == 0)
				{
					point.y = this.y - 25;
					point.x = this.x;
				}
				else if (i == 1)
				{
					point.y = this.y - 25 + num3;
					point.x = this.x + num2;
				}
				else if (i == 2)
				{
					point.y = this.y - 25 + num3;
					point.x = this.x - num2;
				}
				break;
			case 2:
				if (i == 0)
				{
					point.y = this.y;
					point.x = this.x - 25;
				}
				else if (i == 1)
				{
					point.y = this.y + num2;
					point.x = this.x - 25 + num3;
				}
				else if (i == 2)
				{
					point.y = this.y - num2;
					point.x = this.x - 25 + num3;
				}
				break;
			case 3:
				if (i == 0)
				{
					point.y = this.y;
					point.x = this.x + 25;
				}
				else if (i == 1)
				{
					point.y = this.y + num2;
					point.x = this.x + 25 - num3;
				}
				else if (i == 2)
				{
					point.y = this.y - num2;
					point.x = this.x + 25 - num3;
				}
				break;
			}
			Point_Focus point_Focus = new Point_Focus();
			this.create_Speed(this.toX - point.x, this.toY - point.y, point_Focus);
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe;
			if (i == 0)
			{
				num = this.setFrameAngle(CRes.angle(this.toX - point.x, this.toY - point.y));
			}
			point.frame = num;
			point.dis = CRes.random(4);
			this.VecEff.addElement(point);
		}
		this.setBeginKill(5);
		this.y += 10;
	}

	// Token: 0x060002A7 RID: 679 RVA: 0x000236F0 File Offset: 0x000218F0
	private void create_2Kiem_Lv5()
	{
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		this.fRemove = 20;
		this.vMax = 20;
		this.fraImgEff = new FrameImage(15);
		this.fraImgSubEff = new FrameImage(17);
		this.fraImgSub2Eff = new FrameImage(26);
		this.lT_Arc = 32;
		int num = CRes.random(360);
		for (int i = 0; i < 5; i++)
		{
			Point point = new Point();
			point.x = this.toX * 1000;
			point.y = this.toY * 1000;
			point.g = CRes.fixangle(num + i * 72);
			point.vx = CRes.sin(CRes.fixangle(point.g)) * this.lT_Arc;
			point.vy = CRes.cos(CRes.fixangle(point.g)) * this.lT_Arc;
			int frameAngle = CRes.angle(-point.vx, -point.vy);
			point.frame = this.setFrameAngle(frameAngle);
			this.VecEff.addElement(point);
			Point point2 = new Point();
			point2.x = point.x + point.vx;
			point2.y = point.y + point.vy;
			point2.vx = CRes.sin(CRes.fixangle(point.g + 180)) * 5;
			point2.vy = CRes.cos(CRes.fixangle(point.g + 180)) * 5;
			this.VecSubEff.addElement(point2);
		}
	}

	// Token: 0x060002A8 RID: 680 RVA: 0x000238B0 File Offset: 0x00021AB0
	private void create_Kiem_Lv2()
	{
		LoadMap.timeVibrateScreen = 103;
		if (this.objBeKillMain != null)
		{
			this.x = this.objBeKillMain.x;
			this.y = this.objBeKillMain.y + this.objBeKillMain.hOne / 4;
		}
		else
		{
			this.x = this.toX;
			this.y = this.toY;
		}
		this.fraImgEff = new FrameImage(53);
		this.vMax = 4;
		this.fRemove = 6;
		if (this.fRemove > 0)
		{
			this.timeAddNum = (sbyte)(this.fRemove / 2);
		}
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 4;
		}
	}

	// Token: 0x060002A9 RID: 681 RVA: 0x00023990 File Offset: 0x00021B90
	private void create_Kiem_Lv3()
	{
		this.y += 10;
		if (this.Direction == 1)
		{
			this.y -= 5;
		}
		this.fraImgEff = new FrameImage(8);
		this.fraImgSubEff = new FrameImage(53);
		this.vMax = 14;
		this.setBeginKill(10);
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.create_Speed(xdich, ydich, null);
		if (this.Direction != 1)
		{
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			this.VecEff.addElement(point);
		}
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 4;
		}
	}

	// Token: 0x060002AA RID: 682 RVA: 0x00023AC0 File Offset: 0x00021CC0
	private void create_PS_LV2_3_5()
	{
		this.y += 8;
		this.vMax = 12;
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.objBeKillMain.hOne / 2 - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.y += 6;
		this.vMax = 16;
		this.fraImgEff = new FrameImage(57);
		this.fraImgSubEff = new FrameImage(3);
		int frameAngle = CRes.angle(xdich, ydich);
		this.frame = this.setFrameAngle(frameAngle);
		this.create_Speed(xdich, ydich, null);
		if (this.vx >= 0)
		{
			this.frameArrow = 0;
		}
		else
		{
			this.frameArrow = 2;
		}
	}

	// Token: 0x060002AB RID: 683 RVA: 0x00023BB4 File Offset: 0x00021DB4
	private void createArrowProjectile(int imageId)
	{
		this.vMax = 12;
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.objBeKillMain.hOne / 2 - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.fraImgEff = new FrameImage(imageId);
		int frameAngle = CRes.angle(xdich, ydich);
		this.frame = this.setFrameAngle(frameAngle);
		this.create_Speed(xdich, ydich, null);
		if (this.vx >= 0)
		{
			this.frameArrow = 0;
		}
		else
		{
			this.frameArrow = 2;
		}
	}

	// Token: 0x060002AC RID: 684 RVA: 0x00023C78 File Offset: 0x00021E78
	private void create_Sung_LV2_LV4()
	{
		this.y += 5;
		if (this.typeEffect == 22)
		{
			this.indexSound = 17;
			this.fraImgEff = new FrameImage(74);
			this.vMax = 22;
		}
		else if (this.typeEffect == 31)
		{
			this.indexSound = 18;
			this.y += 3;
			this.fraImgEff = new FrameImage(97);
			this.fraImgSubEff = new FrameImage(31);
			this.vMax = 16;
		}
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.objBeKillMain.hOne / 2 - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.create_Speed(xdich, ydich, null);
		int frameAngle = CRes.angle(xdich, ydich);
		this.frame = this.setFrameAngle(frameAngle);
	}

	// Token: 0x060002AD RID: 685 RVA: 0x00023D8C File Offset: 0x00021F8C
	private void create_Sung_Medusa()
	{
		this.y += 5;
		if (this.typeEffect == 99)
		{
			this.indexSound = 34;
			this.y += 3;
			this.fraImgEff = new FrameImage(135);
			this.vMax = 16;
		}
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.objBeKillMain.hOne / 2 - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.create_Speed(xdich, ydich, null);
		int frameAngle = CRes.angle(xdich, ydich);
		this.frame = this.setFrameAngle(frameAngle);
	}

	// Token: 0x060002AE RID: 686 RVA: 0x00023E68 File Offset: 0x00022068
	private void create_FireBall_Tower()
	{
		this.dxTower = 20;
		this.dyTower = -50;
		this.y += this.dyTower;
		this.x += this.dxTower;
		this.indexSound = 32;
		this.fraImgEff = new FrameImage(133);
		this.fraImgSubEff = new FrameImage(31);
		this.vMax = 16;
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.create_Speed(xdich, ydich, null);
		int frameAngle = CRes.angle(xdich, ydich);
		this.frame = this.setFrameAngle(frameAngle);
	}

	// Token: 0x060002AF RID: 687 RVA: 0x00023F50 File Offset: 0x00022150
	private void create_Sung_DAY_DAN(int xto, int yto)
	{
		int xdich = xto - this.x;
		int ydich = yto - this.y;
		Point_Focus point_Focus = new Point_Focus();
		this.create_Speed_noToXY(xdich, ydich, point_Focus);
		Point point = new Point();
		point.x = this.x;
		point.y = this.y;
		point.vx = point_Focus.vx;
		point.vy = point_Focus.vy;
		point.fRe = point_Focus.fRe;
		int frameAngle = CRes.angle(xdich, ydich);
		point.frame = this.setFrameAngle(frameAngle);
		this.VecEff.addElement(point);
	}

	// Token: 0x060002B0 RID: 688 RVA: 0x00023FE4 File Offset: 0x000221E4
	private void create_Sung_Lv3()
	{
		this.y += 5;
		this.fRemove = 5;
		this.fraImgEff = new FrameImage(47);
		this.vMax = 22;
		int num;
		int num2;
		if (this.objBeKillMain != null)
		{
			num = this.objBeKillMain.x;
			num2 = this.objBeKillMain.y - this.objBeKillMain.hOne / 2;
		}
		else
		{
			num = this.toX;
			num2 = this.toY;
		}
		int frameAngle = CRes.angle(num - this.x, num2 - this.y);
		this.frame = this.setFrameAngle(frameAngle);
		for (int i = 0; i < 4; i++)
		{
			int xdich = num + CRes.random_Am(0, 13) - this.x;
			int ydich = num2 + CRes.random_Am(0, 13) - this.y;
			Point_Focus point_Focus = new Point_Focus();
			this.create_Speed(xdich, ydich, point_Focus);
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002B1 RID: 689 RVA: 0x00024128 File Offset: 0x00022328
	private void create_Sung_BaoDan()
	{
		if (this.objBeKillMain == null)
		{
			if (this.f < this.fRemove)
			{
				this.f = this.fRemove;
			}
			return;
		}
		int frameAngle = CRes.angle(this.toX - this.x, this.toY - this.y);
		this.frame = this.setFrameAngle(frameAngle);
		for (int i = 0; i < 6; i++)
		{
			int xdich = this.toX + CRes.random_Am(0, 35) - this.x;
			int ydich = this.toY + CRes.random_Am(0, 35) - this.y;
			Point_Focus point_Focus = new Point_Focus();
			this.create_Speed_noToXY(xdich, ydich, point_Focus);
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			point.vx = point_Focus.vx;
			point.vy = point_Focus.vy;
			point.fRe = point_Focus.fRe + CRes.random(2);
			point.frame = this.frame;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002B2 RID: 690 RVA: 0x0002424C File Offset: 0x0002244C
	private void create_Level_up()
	{
		this.levelPaint = -1;
		if (this.objKill != null)
		{
			this.y += this.objKill.hOne / 2;
		}
		this.fraImgEff = new FrameImage(65);
		this.fraImgSubEff = new FrameImage(67);
		this.fRemove = 23;
		for (int i = 0; i < 10; i++)
		{
			Point point = new Point();
			int a = CRes.random(180, 360);
			point.x = 17 * CRes.cos(a) / 1000;
			point.y = 15 * CRes.sin(a) / 1000 - 5;
			point.fRe = CRes.random(2);
			point.frame = CRes.random(4);
			point.limitY = 50;
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002B3 RID: 691 RVA: 0x00024328 File Offset: 0x00022528
	private void create_2Kiem_GaiDoc()
	{
		this.timeAddNum = 4;
		if (this.typeEffect == 47)
		{
			this.fraImgEff = new FrameImage(87);
		}
		else
		{
			this.fraImgEff = new FrameImage(127);
		}
		this.fraImgSubEff = new FrameImage(75);
		if (this.objKill != null)
		{
			this.y = this.objKill.y;
		}
		if (this.objBeKillMain != null)
		{
			this.toX = this.objBeKillMain.x;
			this.toY = this.objBeKillMain.y - this.objBeKillMain.hOne / 4;
		}
		this.fRemove = 20;
		int num = this.x * 1000;
		int num2 = this.y * 1000;
		int num3 = 18;
		int num4 = 0;
		int num5 = 0;
		int num6 = CRes.angle(this.toX - this.x, this.toY - this.y);
		int distance = MainObject.getDistance(this.toX - this.x, this.toY - this.y);
		if (distance > 60)
		{
			num = this.x * 1000 + (distance - 50) * CRes.cos(num6);
			num2 = this.y * 1000 + (distance - 50) * CRes.sin(num6);
		}
		int num7 = num3 * CRes.cos(num6);
		int num8 = num3 * CRes.sin(num6);
		Point point = new Point();
		point.fRe = 0;
		point.x = num + num7;
		point.y = num2 + num8;
		point.frame = CRes.random(5);
		if (this.Direction == 2)
		{
			point.dis = 2;
		}
		this.VecEff.addElement(point);
		for (int i = 1; i < 6; i++)
		{
			point = new Point();
			point.fRe = i / 2;
			Point point2 = (Point)this.VecEff.elementAt(i - 1);
			point.x = point2.x + num7 + ((i % 2 != 0) ? num4 : (-num4));
			if (num6 > 1575 && num6 <= 3375)
			{
				point.y = point2.y + num8 + ((i % 2 != 0) ? num5 : (-num5));
			}
			else
			{
				point.y = point2.y + num8 + ((i % 2 != 0) ? (-num5) : num5);
			}
			point.dis = 0;
			point.frame = CRes.random(5);
			if (this.Direction == 2)
			{
				point.dis = 2;
			}
			this.VecEff.addElement(point);
		}
	}

	// Token: 0x060002B4 RID: 692 RVA: 0x000245E4 File Offset: 0x000227E4
	private void create_Monster()
	{
		this.vMax = 5;
		if (this.objKill != null && this.objBeKillMain != null && MainObject.getDistance(this.objKill.x, this.objBeKillMain.y, this.objKill.y, this.objBeKillMain.y) < 15)
		{
			this.vMax = 2;
		}
		switch (this.Direction)
		{
		case 0:
			this.y += this.vMax;
			this.y1000 = this.vMax;
			this.frame = 17;
			this.frameArrow = 5;
			break;
		case 1:
			this.y -= this.vMax;
			this.y1000 = -this.vMax;
			this.frame = 33;
			this.frameArrow = 6;
			break;
		case 2:
			this.x -= this.vMax;
			this.x1000 = -this.vMax;
			this.frame = 10;
			this.frameArrow = 2;
			break;
		case 3:
			this.x += this.vMax;
			this.x1000 = this.vMax;
			this.frame = 6;
			this.frameArrow = 0;
			break;
		}
		switch (this.subType)
		{
		case 0:
			this.fraImgEff = new FrameImage(106);
			break;
		case 1:
			this.fraImgEff = new FrameImage(107);
			break;
		case 2:
			this.fraImgEff = new FrameImage(108);
			break;
		case 3:
			this.fraImgEff = new FrameImage(109);
			break;
		case 4:
			this.fraImgEff = new FrameImage(110);
			break;
		default:
			this.fraImgEff = new FrameImage(106);
			break;
		}
		this.fRemove = 8;
	}

	// Token: 0x060002B5 RID: 693 RVA: 0x000247D8 File Offset: 0x000229D8
	private void create_PS_Xungkich()
	{
		this.vMax = 12;
		int xdich;
		int ydich;
		if (this.objBeKillMain != null)
		{
			xdich = this.objBeKillMain.x - this.x;
			ydich = this.objBeKillMain.y - this.y;
		}
		else
		{
			xdich = this.toX - this.x;
			ydich = this.toY - this.y;
		}
		this.create_Speed(xdich, ydich, null);
		this.x1000 = this.x;
		this.y1000 = this.y;
		this.y1000 += 10;
		if (this.Direction == 1)
		{
			this.y1000 -= 5;
		}
		this.setBeginKillXY1000(10);
	}

	// Token: 0x060002B6 RID: 694 RVA: 0x00024898 File Offset: 0x00022A98
	public void updateAngleNormal()
	{
		if (this.objBeKillMain == null)
		{
			this.removeEff();
			return;
		}
		int num = this.objBeKillMain.x - this.x;
		int num2 = this.objBeKillMain.y - (this.objBeKillMain.hOne >> 1) - this.y;
		this.life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > this.fRemove)
		{
			this.removeEff();
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (global::Math.abs(num3 - this.gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (global::Math.abs(num3 - this.gocT_Arc) < 15)
			{
				this.gocT_Arc = num3;
			}
			else if ((num3 - this.gocT_Arc >= 0 && num3 - this.gocT_Arc < 180) || num3 - this.gocT_Arc < -180)
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc + 15);
			}
			else
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc - 15);
			}
		}
		if (!this.isSpeedUp && this.va < 8192)
		{
			this.va += 2048;
		}
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
		num += this.vX1000;
		int num4 = num >> 10;
		this.x += num4;
		num &= 1023;
		num2 += this.vY1000;
		int num5 = num2 >> 10;
		this.y += num5;
		num2 &= 1023;
	}

	// Token: 0x060002B7 RID: 695 RVA: 0x00024A84 File Offset: 0x00022C84
	public void updateAngleXP()
	{
		if (this.typeEffect == 96)
		{
			Point point = new Point();
			point.x = this.x;
			point.y = this.y;
			this.VecEff.addElement(point);
		}
		if (this.typeEffect == 88)
		{
			Point point2 = new Point();
			point2.x = this.x;
			point2.y = this.y;
			this.VecEff.addElement(point2);
		}
		if (this.objBeKillMain == null || this.objBeKillMain.isRemove || this.f >= this.fRemove || this.objBeKillMain.isStop)
		{
			this.f = this.fRemove;
			return;
		}
		int num;
		int num2;
		if (this.typeEffect == 92 || this.typeEffect == 89)
		{
			num = this.objKill.x - this.x;
			num2 = this.objKill.y - (this.objKill.hOne >> 1) - this.y;
		}
		else
		{
			num = this.objBeKillMain.x - this.x;
			num2 = this.objBeKillMain.y - (this.objBeKillMain.hOne >> 1) - this.y;
		}
		this.life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > this.fRemove)
		{
			this.f = this.fRemove;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (global::Math.abs(num3 - this.gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (global::Math.abs(num3 - this.gocT_Arc) < 15)
			{
				this.gocT_Arc = num3;
			}
			else if ((num3 - this.gocT_Arc >= 0 && num3 - this.gocT_Arc < 180) || num3 - this.gocT_Arc < -180)
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc + 15);
			}
			else
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc - 15);
			}
		}
		if (!this.isSpeedUp && this.va < 8192)
		{
			this.va += 3096;
		}
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
		num += this.vX1000;
		int num4 = num >> 10;
		this.x += num4;
		num &= 1023;
		num2 += this.vY1000;
		int num5 = num2 >> 10;
		this.y += num5;
		num2 &= 1023;
		if (this.typeEffect != 88)
		{
			Point point3 = new Point();
			point3.x = this.x;
			point3.y = this.y;
			this.VecEff.addElement(point3);
		}
	}

	// Token: 0x060002B8 RID: 696 RVA: 0x00024DB4 File Offset: 0x00022FB4
	public void updateAngleHut_Mp_Hp()
	{
		if (this.f >= this.fRemove)
		{
			this.f = this.fRemove;
			return;
		}
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		this.life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > this.fRemove)
		{
			this.f = this.fRemove;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (global::Math.abs(num3 - this.gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
		{
			if (global::Math.abs(num3 - this.gocT_Arc) < 15)
			{
				this.gocT_Arc = num3;
			}
			else if ((num3 - this.gocT_Arc >= 0 && num3 - this.gocT_Arc < 180) || num3 - this.gocT_Arc < -180)
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc + 15);
			}
			else
			{
				this.gocT_Arc = CRes.fixangle(this.gocT_Arc - 15);
			}
		}
		if (!this.isSpeedUp && this.va < 8192)
		{
			this.va += 3096;
		}
		this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
		this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
		num += this.vX1000;
		int num4 = num >> 10;
		this.x += num4;
		num &= 1023;
		num2 += this.vY1000;
		int num5 = num2 >> 10;
		this.y += num5;
		num2 &= 1023;
		Point point = new Point();
		point.x = this.x;
		point.y = this.y;
		this.VecEff.addElement(point);
	}

	// Token: 0x060002B9 RID: 697 RVA: 0x00024FC8 File Offset: 0x000231C8
	public void paint_phuong_hoang(mGraphics g, FrameImage frm, int index, int x, int y)
	{
		int num = frm.nFrame / 3;
		switch (index)
		{
		case 0:
			frm.drawFrame(this.f % num, x, y, 2, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 1:
			frm.drawFrame(num * 2 + this.f % num, x, y, 4, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 2:
			frm.drawFrame(num + this.f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 3:
			frm.drawFrame(num * 2 + this.f % num, x, y, 5, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 4:
			frm.drawFrame(this.f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 5:
			frm.drawFrame(num * 2 + this.f % num, x, y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 6:
			frm.drawFrame(num + this.f % num, x, y, 1, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		case 7:
			frm.drawFrame(num * 2 + this.f % num, x, y, 2, mGraphics.VCENTER | mGraphics.HCENTER, g);
			break;
		}
	}

	// Token: 0x060002BA RID: 698 RVA: 0x00025144 File Offset: 0x00023344
	private void paint_Ice_Nova_Effect(mGraphics g)
	{
		if (this.fraImgEff == null)
		{
			return;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			if (point.f < this.fRemove)
			{
				this.paint_Bullet(g, this.fraImgEff, point.frame, point.x / 1000, point.y / 1000, false);
			}
		}
	}

	// Token: 0x060002BB RID: 699 RVA: 0x000251C8 File Offset: 0x000233C8
	private void paint_Poison_Nova_Effect(mGraphics g)
	{
		if (this.fraImgEff == null)
		{
			return;
		}
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			if (point.f < this.fRemove)
			{
				this.paint_Bullet(g, this.fraImgEff, point.frame, point.x / 1000, point.y / 1000, false);
			}
		}
	}

	// Token: 0x060002BC RID: 700 RVA: 0x0002524C File Offset: 0x0002344C
	private void update_Nova_Effect()
	{
		if (this.f >= this.fRemove)
		{
			for (int i = 0; i < this.VecEff.size(); i++)
			{
				Point point = (Point)this.VecEff.elementAt(i);
				if (this.typeEffect == 90)
				{
					GameScreen.addEffectEndKill(10, point.x / 1000, point.y / 1000);
					GameScreen.addEffectEndKill(15, point.x / 1000, point.y / 1000 + this.objBeKillMain.hOne / 4);
				}
				else if (this.typeEffect == 91)
				{
					GameScreen.addEffectEndKill(44, point.x / 1000, point.y / 1000);
				}
			}
			this.removeEff();
			return;
		}
		for (int j = 0; j < this.VecEff.size(); j++)
		{
			Point point2 = (Point)this.VecEff.elementAt(j);
			point2.x += point2.vx;
			point2.y += point2.vy;
			int tile = GameCanvas.loadmap.getTile(point2.x / 1000, point2.y / 1000);
			if (tile == -1 || tile == 1 || !MainEffect.isInScreen(point2.x / 1000, point2.y / 1000, this.fraImgEff.frameWidth, this.fraImgEff.frameHeight))
			{
				if (this.typeEffect == 90)
				{
					GameScreen.addEffectEndKill(10, point2.x / 1000, point2.y / 1000);
					GameScreen.addEffectEndKill(15, point2.x / 1000, point2.y / 1000 + this.objBeKillMain.hOne / 4);
				}
				else if (this.typeEffect == 91)
				{
					GameScreen.addEffectEndKill(44, point2.x / 1000, point2.y / 1000);
				}
				this.VecEff.removeElement(point2);
			}
		}
	}

	// Token: 0x060002BD RID: 701 RVA: 0x00025480 File Offset: 0x00023680
	public void paint_Bullet(mGraphics g, FrameImage frm, int index, int x, int y, bool isMore)
	{
		int num = frm.nFrame / 3;
		int num2 = 3;
		frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
		if (isMore)
		{
			switch (index)
			{
			case 0:
			case 1:
			case 2:
			case 23:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + 2 * num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 3:
			case 4:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 5:
			case 6:
			case 7:
			case 8:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y - 2 * num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 9:
			case 10:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 11:
			case 12:
			case 13:
			case 14:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y - num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - 2 * num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 15:
			case 16:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 17:
			case 18:
			case 19:
			case 20:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x - num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y + 2 * num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			case 21:
			case 22:
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				frm.drawFrameEffectSkill(num * (int)this.mImageBullet[index] + this.f % num, x + num2, y + num2, (int)this.mXoayBullet[index], mGraphics.VCENTER | mGraphics.HCENTER, g);
				break;
			}
		}
	}

	// Token: 0x060002BE RID: 702 RVA: 0x00025A84 File Offset: 0x00023C84
	public void setSendMove(int x, int xend, int y, int yend)
	{
		int tile = GameCanvas.loadmap.getTile(xend, yend);
		if (tile == 1 || tile == -1)
		{
			this.objKill.toX = xend;
			this.objKill.toY = yend;
			this.objKill.x = xend;
			this.objKill.y = yend;
			this.removeEff();
			return;
		}
		if (this.objKill == null || this.objKill != GameScreen.player)
		{
			this.objKill.toX = xend;
			this.objKill.toY = yend;
			this.objKill.x = xend;
			this.objKill.y = yend;
			return;
		}
		int num = 0;
		int num2 = 0;
		int num3 = CRes.abs(x - xend);
		int num4 = CRes.abs(y - yend);
		if (num3 >= 4)
		{
			if (x > xend)
			{
				num = -4;
			}
			else
			{
				num = 4;
			}
		}
		if (num4 >= 4)
		{
			if (y > yend)
			{
				num2 = -4;
			}
			else
			{
				num2 = 4;
			}
		}
		int num5 = num3 / 4;
		int num6 = num4 / 4;
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
		}
		this.objKill.toX = xend;
		this.objKill.toY = yend;
		this.objKill.x = this.savex;
		this.objKill.y = this.savey;
		this.objKill.xStand = xend;
		this.objKill.yStand = yend;
		this.objKill.xFire = xend;
		this.objKill.yFire = yend;
	}

	// Token: 0x060002BF RID: 703 RVA: 0x00025C44 File Offset: 0x00023E44
	public static int setAddEffKillPlus(int[] mtype, MainObject objFrom, MainObject objTo, int[] mplus)
	{
		int result = -1;
		for (int i = 0; i < mtype.Length; i++)
		{
			switch (mtype[i])
			{
			case 1:
				GameScreen.addEffectEndKill(29, objTo.x, objTo.y - objTo.hOne / 2);
				if (objFrom == GameScreen.player)
				{
					GameScreen.addEffectNum(T.dcxuyengiap, objTo.x, objTo.y - objTo.hOne / 2, 7);
					result = 7;
				}
				else
				{
					GameScreen.addEffectNum(T.dcxuyengiap, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				break;
			case 2:
			case 3:
				GameScreen.addEffectKillSubTime(41, objTo.ID, objTo.typeObject, objFrom.ID, objFrom.typeObject, mplus[i], objFrom.hp, (sbyte)(mtype[i] - 2), 3000);
				GameScreen.addEffectNum("-" + mplus[i], objTo.x, objTo.y - objTo.hOne / 2, (mtype[i] != 2) ? 4 : 3);
				break;
			case 4:
				GameScreen.addEffectKill(6, objTo.ID, objTo.typeObject, objTo.ID, objTo.typeObject, mplus[i], objFrom.hp);
				if (objFrom == GameScreen.player)
				{
					GameScreen.addEffectNum(T.dcchimang, objTo.x, objTo.y - objTo.hOne / 2, 7);
					result = 7;
				}
				else
				{
					GameScreen.addEffectNum(T.dcchimang, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				break;
			case 5:
				GameScreen.addEffectKill(67, objTo.ID, objTo.typeObject, objFrom.ID, objFrom.typeObject, mplus[i], objFrom.hp);
				if (objTo == GameScreen.player)
				{
					GameScreen.addEffectNum(T.phandon, objTo.x, objTo.y - objTo.hOne / 2, 7);
				}
				else
				{
					GameScreen.addEffectNum(T.phandon, objTo.x, objTo.y - objTo.hOne / 2, 6);
				}
				if (objFrom.hp <= 0 && objFrom.Action != 4)
				{
					objFrom.resetAction();
					objFrom.Action = 4;
					objFrom.timedie = GameCanvas.timeNow;
					GameScreen.addEffectEndKill(11, objFrom.x, objFrom.y);
				}
				break;
			}
		}
		return result;
	}

	// Token: 0x060002C0 RID: 704 RVA: 0x00025EB4 File Offset: 0x000240B4
	public static bool isMultiTarget(int type)
	{
		return type == 93 || type == 99 || type == 95 || type == 96 || type == 97 || type == 98 || type == 108 || type == 113 || type == 104 || type == 114 || type == 115;
	}

	// Token: 0x060002C1 RID: 705 RVA: 0x00025F1C File Offset: 0x0002411C
	private void update_Boss_De2()
	{
		if (this.objBeKillMain != null)
		{
			if (this.f == 1)
			{
				LoadMap.timeVibrateScreen = 103;
				GameScreen.addEffectEndKill(9, this.objBeKillMain.x, this.objBeKillMain.y - 2);
				GameScreen.addEffectEndKill_Time(47, this.objBeKillMain.x, this.objBeKillMain.y, this.objBeKillMain.timeBind);
			}
			if (!this.objBeKillMain.isBinded || (this.objBeKillMain != null && this.objBeKillMain.isRemove))
			{
				this.isRemove = true;
			}
		}
	}

	// Token: 0x060002C2 RID: 706 RVA: 0x00025FC0 File Offset: 0x000241C0
	private void update_Boss_Medusa2()
	{
		if (this.objBeKillMain != null && (this.objBeKillMain.Action == 4 || !this.objBeKillMain.isDongBang || this.objBeKillMain == null || (this.objBeKillMain != null && this.objBeKillMain.isRemove)))
		{
			this.isRemove = true;
		}
	}

	// Token: 0x060002C3 RID: 707 RVA: 0x00026028 File Offset: 0x00024228
	private void update_Boss_De1()
	{
		for (int i = 0; i < this.VecEff.size(); i++)
		{
			Point point = (Point)this.VecEff.elementAt(i);
			if (this.objBeKillMain == null)
			{
				this.removeEff();
				return;
			}
			int num = this.objBeKillMain.x - point.x;
			int num2 = this.objBeKillMain.y - (this.objBeKillMain.hOne >> 1) - point.y;
			this.life++;
			if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > this.fRemove)
			{
				this.removeEff();
				GameScreen.addEffectEndKill(45, this.objBeKillMain.x, this.objBeKillMain.y - 20);
				return;
			}
			int num3 = CRes.angle(num, num2);
			if (global::Math.abs(num3 - this.gocT_Arc) < 90 || num * num + num2 * num2 > 4096)
			{
				if (global::Math.abs(num3 - this.gocT_Arc) < 15)
				{
					this.gocT_Arc = num3;
				}
				else if ((num3 - this.gocT_Arc >= 0 && num3 - this.gocT_Arc < 180) || num3 - this.gocT_Arc < -180)
				{
					this.gocT_Arc = CRes.fixangle(this.gocT_Arc + 15);
				}
				else
				{
					this.gocT_Arc = CRes.fixangle(this.gocT_Arc - 15);
				}
			}
			if (!this.isSpeedUp && this.va < 8192)
			{
				this.va += 2048;
			}
			this.vX1000 = this.va * CRes.cos(this.gocT_Arc) >> 10;
			this.vY1000 = this.va * CRes.sin(this.gocT_Arc) >> 10;
			num += this.vX1000;
			int num4 = num >> 10;
			point.x += num4;
			num &= 1023;
			num2 += this.vY1000;
			int num5 = num2 >> 10;
			point.y += num5;
			num2 &= 1023;
			if (this.f % 2 == 0)
			{
				GameScreen.addEffectEndKill(9, point.x, point.y);
				GameScreen.addEffectEndKill(46, point.x, point.y - 2);
			}
			point.f++;
		}
		if (this.f >= this.fRemove)
		{
			this.removeEff();
		}
	}

	// Token: 0x060002C4 RID: 708 RVA: 0x000262C8 File Offset: 0x000244C8
	public override void setTimeRemove(short time)
	{
		this.timeRemove = (int)time;
		this.x = this.objBeKillMain.x;
		this.y = this.objBeKillMain.y;
		this.objBeKillMain.vx = 0;
		this.objBeKillMain.vy = 0;
		this.objBeKillMain.toX = this.x;
		this.objBeKillMain.toY = this.y;
		if (this.typeEffect == 101)
		{
			this.objBeKillMain.isSleep = true;
			this.objBeKillMain.timeSleep = mSystem.currentTimeMillis() + (long)(time * 1000);
		}
		else if (this.typeEffect == 102)
		{
			this.objBeKillMain.isStun = true;
			this.objBeKillMain.timeStun = mSystem.currentTimeMillis() + (long)(time * 1000);
		}
		else if (this.typeEffect == 107)
		{
			this.objBeKillMain.timeno = mSystem.currentTimeMillis() + (long)(time * 1000);
			this.objBeKillMain.isno = true;
		}
		else if (this.typeEffect == 103)
		{
			this.objBeKillMain.isnoBoss84 = true;
			this.objBeKillMain.timenoBoss84 = mSystem.currentTimeMillis() + (long)(time * 1000);
		}
		else if (this.typeEffect == 100)
		{
			this.objBeKillMain.isDongBang = true;
			this.objBeKillMain.timeDongBang = mSystem.currentTimeMillis() + (long)(time * 1000);
		}
		else
		{
			this.objBeKillMain.isBinded = true;
			this.objBeKillMain.timeBind = mSystem.currentTimeMillis() + (long)(time * 1000);
		}
	}

	// Token: 0x060002C5 RID: 709 RVA: 0x00026470 File Offset: 0x00024670
	public override void setObjFrom(short id, sbyte tem)
	{
		this.objKill = MainObject.get_Object((int)id, tem);
	}

	// Token: 0x040002AF RID: 687
	public const sbyte EFF_NORMAL = 0;

	// Token: 0x040002B0 RID: 688
	public const sbyte EFF_SPEED = 1;

	// Token: 0x040002B1 RID: 689
	public const sbyte EFF_STAR = 6;

	// Token: 0x040002B2 RID: 690
	public const sbyte EFF_LIGHTING = 10;

	// Token: 0x040002B3 RID: 691
	public const sbyte EFF_STONE_DROP_MORE = 11;

	// Token: 0x040002B4 RID: 692
	public const sbyte EFF_CRACK_EARTH = 12;

	// Token: 0x040002B5 RID: 693
	public const sbyte EFF_ARROW_RAIN = 20;

	// Token: 0x040002B6 RID: 694
	public const sbyte EFF_KIEM_AND_2KIEM_LV1 = 21;

	// Token: 0x040002B7 RID: 695
	public const sbyte EFF_SUNG_LV2 = 22;

	// Token: 0x040002B8 RID: 696
	public const sbyte EFF_SUNG_LV3 = 23;

	// Token: 0x040002B9 RID: 697
	public const sbyte EFF_PS_LV2 = 25;

	// Token: 0x040002BA RID: 698
	public const sbyte EFF_KIEM_LV3 = 26;

	// Token: 0x040002BB RID: 699
	public const sbyte EFF_2KIEM_LV2 = 27;

	// Token: 0x040002BC RID: 700
	public const sbyte EFF_KIEM_LV2 = 28;

	// Token: 0x040002BD RID: 701
	public const sbyte EFF_STAR_LINE_IN = 29;

	// Token: 0x040002BE RID: 702
	public const sbyte EFF_STAR_POINT_IN = 30;

	// Token: 0x040002BF RID: 703
	public const sbyte EFF_SUNG_LV4 = 31;

	// Token: 0x040002C0 RID: 704
	public const sbyte EFF_2KIEM_LV4 = 34;

	// Token: 0x040002C1 RID: 705
	public const sbyte EFF_PS_AND_SUNG_LV1 = 38;

	// Token: 0x040002C2 RID: 706
	public const sbyte EFF_2KIEM_LV5 = 40;

	// Token: 0x040002C3 RID: 707
	public const sbyte EFF_XP = 41;

	// Token: 0x040002C4 RID: 708
	public const sbyte EFF_LEVEL_UP = 42;

	// Token: 0x040002C5 RID: 709
	public const sbyte EFF_LINE_LEVEL_UP = 43;

	// Token: 0x040002C6 RID: 710
	public const sbyte EFF_2KIEM_TRUNG_DOC = 46;

	// Token: 0x040002C7 RID: 711
	public const sbyte EFF_2KIEM_GAI_DOC = 47;

	// Token: 0x040002C8 RID: 712
	public const sbyte EFF_PS_XUNGKICH = 49;

	// Token: 0x040002C9 RID: 713
	public const sbyte EFF_MONSTER_NEAR = 50;

	// Token: 0x040002CA RID: 714
	public const sbyte EFF_SUNG_LASER = 51;

	// Token: 0x040002CB RID: 715
	public const sbyte EFF_KIEM_FIRE = 52;

	// Token: 0x040002CC RID: 716
	public const sbyte EFF_KIEM_LV6 = 53;

	// Token: 0x040002CD RID: 717
	public const sbyte EFF_KIEM_LV7 = 54;

	// Token: 0x040002CE RID: 718
	public const sbyte EFF_2KIEM_CRI = 55;

	// Token: 0x040002CF RID: 719
	public const sbyte EFF_BUFF = 56;

	// Token: 0x040002D0 RID: 720
	public const sbyte EFF_BUFF_POINT_IN = 57;

	// Token: 0x040002D1 RID: 721
	public const sbyte EFF_TELEPORT = 58;

	// Token: 0x040002D2 RID: 722
	public const sbyte EFF_PS_CAU_NOILUC = 59;

	// Token: 0x040002D3 RID: 723
	public const sbyte EFF_PS_DONGDAT = 60;

	// Token: 0x040002D4 RID: 724
	public const sbyte EFF_PS_ICE_RAIN = 61;

	// Token: 0x040002D5 RID: 725
	public const sbyte EFF_SUNG_BAO_DAN = 62;

	// Token: 0x040002D6 RID: 726
	public const sbyte EFF_SUNG_DAY_DAN = 63;

	// Token: 0x040002D7 RID: 727
	public const sbyte EFF_PS_ICE_UP = 64;

	// Token: 0x040002D8 RID: 728
	public const sbyte EFF_SUNG_RAIN_ROCKET = 65;

	// Token: 0x040002D9 RID: 729
	public const sbyte EFF_SUNG_RAIN_LIGHTNING = 66;

	// Token: 0x040002DA RID: 730
	public const sbyte EFF_PHAN_DAMAGE = 67;

	// Token: 0x040002DB RID: 731
	public const sbyte EFF_FOCUS = 68;

	// Token: 0x040002DC RID: 732
	public const sbyte EFF_SMALL_SMOKE = 69;

	// Token: 0x040002DD RID: 733
	public const sbyte EFF_MON_BUFF = 70;

	// Token: 0x040002DE RID: 734
	public const sbyte EFF_BOSS_CAY_1 = 71;

	// Token: 0x040002DF RID: 735
	public const sbyte EFF_BOSS_CAY_2 = 72;

	// Token: 0x040002E0 RID: 736
	public const sbyte EFF_BOSS_ONG_1 = 73;

	// Token: 0x040002E1 RID: 737
	public const sbyte EFF_BOSS_ONG_2 = 74;

	// Token: 0x040002E2 RID: 738
	public const sbyte EFF_BOSS_CUA_1 = 75;

	// Token: 0x040002E3 RID: 739
	public const sbyte EFF_BOSS_CUA_2 = 76;

	// Token: 0x040002E4 RID: 740
	public const sbyte EFF_BOSS_SOI_1 = 77;

	// Token: 0x040002E5 RID: 741
	public const sbyte EFF_BOSS_SOI_2 = 14;

	// Token: 0x040002E6 RID: 742
	public const sbyte EFF_BOSS_DA_1 = 78;

	// Token: 0x040002E7 RID: 743
	public const sbyte EFF_BOSS_DA_2 = 79;

	// Token: 0x040002E8 RID: 744
	public const sbyte EFF_KILL_GHOST = 80;

	// Token: 0x040002E9 RID: 745
	public const sbyte EFF_PHO_BANG = 81;

	// Token: 0x040002EA RID: 746
	public const sbyte EFF_SUNG_SET_NEW = 82;

	// Token: 0x040002EB RID: 747
	public const sbyte EFF_HUT_MP_HP = 83;

	// Token: 0x040002EC RID: 748
	public const sbyte EFF_STAR_LINE_IN_SLOW = 84;

	// Token: 0x040002ED RID: 749
	public const sbyte EFF_NHANBAN_LV2 = 85;

	// Token: 0x040002EE RID: 750
	public const sbyte EFF_SERVER_THIEN_THACH = 86;

	// Token: 0x040002EF RID: 751
	public const sbyte EFF_BUFF_MO_BANGHOI = 87;

	// Token: 0x040002F0 RID: 752
	public const sbyte EFF_DAN_FOCUS = 88;

	// Token: 0x040002F1 RID: 753
	public const sbyte EFF_HUT_MP = 89;

	// Token: 0x040002F2 RID: 754
	public const sbyte EFF_ICE_NOVA = 90;

	// Token: 0x040002F3 RID: 755
	public const sbyte EFF_POISON_NOVA = 91;

	// Token: 0x040002F4 RID: 756
	public const sbyte EFF_HUT_HP = 92;

	// Token: 0x040002F5 RID: 757
	public const sbyte EFF_BOSS_DE_1 = 93;

	// Token: 0x040002F6 RID: 758
	public const sbyte EFF_BOSS_DE_2 = 94;

	// Token: 0x040002F7 RID: 759
	public const sbyte EFF_Tower_1 = 95;

	// Token: 0x040002F8 RID: 760
	public const sbyte EFF_Tower_2 = 96;

	// Token: 0x040002F9 RID: 761
	public const sbyte EFF_Tower_3 = 97;

	// Token: 0x040002FA RID: 762
	public const sbyte EFF_Tower_4 = 98;

	// Token: 0x040002FB RID: 763
	public const sbyte EFF_BOSS_Medusa1 = 99;

	// Token: 0x040002FC RID: 764
	public const sbyte EFF_BOSS_Medusa2 = 100;

	// Token: 0x040002FD RID: 765
	public const sbyte EFF_PET_OWL = 101;

	// Token: 0x040002FE RID: 766
	public const sbyte EFF_PET_EAGLE = 102;

	// Token: 0x040002FF RID: 767
	public const sbyte EFF_BOSS_84_NO = 103;

	// Token: 0x04000300 RID: 768
	public const sbyte EFF_BOSS_34_DAM_TUNG = 104;

	// Token: 0x04000301 RID: 769
	public const sbyte EFF_BOSS_34_LASER = 105;

	// Token: 0x04000302 RID: 770
	public const sbyte EFF_BOSS_34_LASERLAN = 106;

	// Token: 0x04000303 RID: 771
	public const sbyte EFF_BOSS_NO = 107;

	// Token: 0x04000304 RID: 772
	public const sbyte EFF_BOSS_84_MUNTI = 108;

	// Token: 0x04000305 RID: 773
	public const sbyte EFF_PHAPSU_BANG = 109;

	// Token: 0x04000306 RID: 774
	public const sbyte EFF_KIEM_LON_NGU = 110;

	// Token: 0x04000307 RID: 775
	public const sbyte EFF_SUNG_NGU = 111;

	// Token: 0x04000308 RID: 776
	public const sbyte EFF_KIEM_NHO_TROI = 112;

	// Token: 0x04000309 RID: 777
	public const sbyte EFF_BOSS_NOEL_1 = 113;

	// Token: 0x0400030A RID: 778
	public const sbyte EFF_BOSS_NOEL_2 = 114;

	// Token: 0x0400030B RID: 779
	public const sbyte EFF_BOSS_NOEL_3 = 115;

	// Token: 0x0400030C RID: 780
	public const int EFF_BIG_SWORD_115 = 116;

	// Token: 0x0400030D RID: 781
	public const int EFF_SMALL_SWORD_115 = 117;

	// Token: 0x0400030E RID: 782
	public const int EFF_SUNG_115 = 118;

	// Token: 0x0400030F RID: 783
	public const int EFF_PHAPSU_115 = 119;

	// Token: 0x04000310 RID: 784
	public const int EFF_BIG_SWORD_115_2 = 120;

	// Token: 0x04000311 RID: 785
	public const int EFF_SMALL_SWORD_115_2 = 121;

	// Token: 0x04000312 RID: 786
	public const int EFF_SUNG_115_2 = 122;

	// Token: 0x04000313 RID: 787
	public const int EFF_PHAPSU_115_2 = 123;

	// Token: 0x04000314 RID: 788
	public const int EFF_PHAO_THANH = 124;

	// Token: 0x04000315 RID: 789
	public const int EFF_TRU_THANH_1 = 125;

	// Token: 0x04000316 RID: 790
	public const int EFF_TRU_THANH_2 = 126;

	// Token: 0x04000317 RID: 791
	public const sbyte SUB_STAR_LINE_IN_KIEM = 0;

	// Token: 0x04000318 RID: 792
	public const sbyte SUB_STAR_LINE_IN_SUNG = 1;

	// Token: 0x04000319 RID: 793
	public const sbyte SUB_STAR_LINE_IN_BUFF_0 = 2;

	// Token: 0x0400031A RID: 794
	public const sbyte SUB_STAR_LINE_IN_2KIEM = 3;

	// Token: 0x0400031B RID: 795
	public const sbyte SUB_STAR_LINE_IN_PS = 4;

	// Token: 0x0400031C RID: 796
	public const sbyte SUB_BUFF_LUA_1 = 0;

	// Token: 0x0400031D RID: 797
	public const sbyte SUB_BUFF_DOC_1 = 1;

	// Token: 0x0400031E RID: 798
	public const sbyte SUB_BUFF_BANG_1 = 2;

	// Token: 0x0400031F RID: 799
	public const sbyte SUB_BUFF_DIEN_1 = 3;

	// Token: 0x04000320 RID: 800
	public const sbyte SUB_BUFF_OTHER_MAIN = 10;

	// Token: 0x04000321 RID: 801
	public const sbyte SUB_BUFF_OTHER_SUB = 11;

	// Token: 0x04000322 RID: 802
	public static sbyte[][] frameBuff = new sbyte[][]
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
			2
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
			2
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
			2
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
			2
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
			2
		}
	};

	// Token: 0x04000323 RID: 803
	public static sbyte[][] arrInfoEff = new sbyte[][]
	{
		new sbyte[0],
		new sbyte[]
		{
			5,
			5,
			4
		},
		new sbyte[]
		{
			9,
			9,
			4
		},
		new sbyte[]
		{
			20,
			20,
			4
		},
		new sbyte[]
		{
			32,
			32,
			5
		},
		new sbyte[]
		{
			7,
			7,
			4
		},
		new sbyte[]
		{
			8,
			8,
			4
		},
		new sbyte[]
		{
			25,
			25,
			2
		},
		new sbyte[]
		{
			22,
			30,
			4
		},
		new sbyte[]
		{
			14,
			15,
			4
		},
		new sbyte[]
		{
			8,
			8,
			4
		},
		new sbyte[]
		{
			24,
			19,
			3
		},
		new sbyte[]
		{
			19,
			13,
			3
		},
		new sbyte[]
		{
			24,
			24,
			3
		},
		new sbyte[]
		{
			32,
			32,
			6
		},
		new sbyte[]
		{
			36,
			30,
			3
		},
		new sbyte[]
		{
			23,
			32,
			8
		},
		new sbyte[]
		{
			20,
			20,
			4
		},
		new sbyte[]
		{
			32,
			32,
			2
		},
		new sbyte[]
		{
			41,
			17,
			3
		},
		new sbyte[]
		{
			32,
			14,
			3
		},
		new sbyte[]
		{
			48,
			48,
			3
		},
		new sbyte[]
		{
			21,
			34,
			3
		},
		new sbyte[]
		{
			12,
			12,
			5
		},
		new sbyte[]
		{
			38,
			38,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			36,
			30,
			3
		},
		new sbyte[]
		{
			32,
			31,
			3
		},
		new sbyte[]
		{
			12,
			12,
			4
		},
		new sbyte[]
		{
			40,
			31,
			3
		},
		new sbyte[]
		{
			20,
			18,
			3
		},
		new sbyte[]
		{
			12,
			13,
			4
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			30,
			37,
			3
		},
		new sbyte[0],
		new sbyte[0],
		new sbyte[]
		{
			37,
			40,
			4
		},
		new sbyte[]
		{
			50,
			24,
			4
		},
		new sbyte[]
		{
			9,
			12,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			23,
			33,
			2
		},
		new sbyte[]
		{
			32,
			32,
			3
		},
		new sbyte[]
		{
			24,
			24,
			5
		},
		new sbyte[0],
		new sbyte[0],
		new sbyte[]
		{
			14,
			11,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			15,
			15,
			3
		},
		new sbyte[]
		{
			14,
			11,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			24,
			35,
			3
		},
		new sbyte[]
		{
			70,
			70,
			3
		},
		new sbyte[]
		{
			50,
			46,
			4
		},
		new sbyte[]
		{
			62,
			64,
			3
		},
		new sbyte[]
		{
			38,
			38,
			4
		},
		new sbyte[0],
		new sbyte[]
		{
			10,
			10,
			2
		},
		new sbyte[]
		{
			25,
			25,
			3
		},
		new sbyte[]
		{
			32,
			32,
			4
		},
		new sbyte[]
		{
			32,
			32,
			4
		},
		new sbyte[]
		{
			30,
			32,
			4
		},
		new sbyte[]
		{
			50,
			50,
			4
		},
		new sbyte[0],
		new sbyte[]
		{
			46,
			50,
			4
		},
		new sbyte[0],
		new sbyte[]
		{
			42,
			27,
			6
		},
		new sbyte[]
		{
			5,
			5,
			4
		},
		new sbyte[]
		{
			59,
			17,
			1
		},
		new sbyte[]
		{
			17,
			23,
			4
		},
		new sbyte[0],
		new sbyte[]
		{
			50,
			50,
			4
		},
		new sbyte[]
		{
			31,
			31,
			2
		},
		new sbyte[]
		{
			34,
			38,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			21,
			17,
			9
		},
		new sbyte[]
		{
			32,
			22,
			3
		},
		new sbyte[0],
		new sbyte[0],
		new sbyte[0],
		new sbyte[0],
		new sbyte[]
		{
			10,
			10,
			18
		},
		new sbyte[]
		{
			17,
			10,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			27,
			32,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			19,
			45,
			1
		},
		new sbyte[]
		{
			50,
			26,
			3
		},
		new sbyte[]
		{
			24,
			30,
			5
		},
		new sbyte[]
		{
			32,
			14,
			3
		},
		new sbyte[]
		{
			32,
			14,
			3
		},
		new sbyte[]
		{
			24,
			14,
			3
		},
		new sbyte[]
		{
			8,
			5,
			2
		},
		new sbyte[]
		{
			16,
			16,
			3
		},
		new sbyte[0],
		new sbyte[]
		{
			30,
			14,
			2
		},
		new sbyte[]
		{
			25,
			45,
			1
		},
		new sbyte[]
		{
			53,
			28,
			3
		},
		new sbyte[]
		{
			12,
			12,
			3
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			14,
			14,
			4
		},
		new sbyte[]
		{
			12,
			12,
			5
		},
		new sbyte[]
		{
			12,
			12,
			5
		},
		new sbyte[]
		{
			12,
			11,
			4
		},
		new sbyte[]
		{
			50,
			25,
			4
		},
		new sbyte[]
		{
			50,
			25,
			4
		},
		new sbyte[]
		{
			50,
			25,
			4
		},
		new sbyte[]
		{
			50,
			25,
			4
		},
		new sbyte[]
		{
			50,
			25,
			4
		},
		new sbyte[]
		{
			32,
			30,
			6
		},
		new sbyte[]
		{
			28,
			15,
			4
		},
		new sbyte[]
		{
			88,
			60,
			3
		},
		new sbyte[]
		{
			31,
			31,
			2
		},
		new sbyte[]
		{
			16,
			16,
			3
		},
		new sbyte[]
		{
			7,
			7,
			4
		},
		new sbyte[]
		{
			19,
			45,
			1
		},
		new sbyte[]
		{
			55,
			55,
			3
		},
		new sbyte[]
		{
			55,
			55,
			3
		},
		new sbyte[]
		{
			55,
			55,
			3
		},
		new sbyte[]
		{
			55,
			55,
			3
		},
		new sbyte[]
		{
			24,
			40,
			3
		},
		new sbyte[]
		{
			13,
			13,
			3
		},
		new sbyte[]
		{
			59,
			64,
			4
		},
		new sbyte[]
		{
			25,
			25,
			3
		},
		new sbyte[]
		{
			13,
			13,
			3
		},
		new sbyte[]
		{
			36,
			30,
			4
		},
		new sbyte[]
		{
			53,
			24,
			4
		},
		new sbyte[]
		{
			44,
			44,
			4
		},
		new sbyte[]
		{
			50,
			51,
			4
		},
		new sbyte[]
		{
			40,
			40,
			4
		},
		new sbyte[]
		{
			31,
			23,
			3
		},
		new sbyte[]
		{
			26,
			24,
			3
		},
		new sbyte[]
		{
			32,
			32,
			4
		},
		new sbyte[]
		{
			32,
			24,
			3
		},
		new sbyte[]
		{
			29,
			20,
			3
		},
		new sbyte[]
		{
			32,
			32,
			6
		},
		new sbyte[]
		{
			22,
			19,
			8
		},
		new sbyte[]
		{
			23,
			25,
			3
		},
		new sbyte[]
		{
			16,
			21,
			3
		},
		new sbyte[]
		{
			8,
			8,
			4
		},
		new sbyte[]
		{
			20,
			15,
			2
		},
		new sbyte[]
		{
			30,
			20,
			3
		},
		new sbyte[]
		{
			64,
			57,
			4
		},
		new sbyte[]
		{
			20,
			20,
			3
		},
		new sbyte[]
		{
			24,
			16,
			3
		},
		new sbyte[]
		{
			30,
			20,
			3
		},
		new sbyte[]
		{
			22,
			16,
			3
		},
		new sbyte[]
		{
			25,
			17,
			3
		},
		new sbyte[]
		{
			30,
			30,
			4
		},
		new sbyte[]
		{
			30,
			30,
			4
		},
		new sbyte[]
		{
			16,
			16,
			2
		},
		new sbyte[]
		{
			7,
			7,
			4
		},
		new sbyte[]
		{
			9,
			9,
			4
		},
		new sbyte[]
		{
			13,
			13,
			5
		},
		new sbyte[]
		{
			7,
			7,
			4
		},
		new sbyte[]
		{
			9,
			9,
			4
		},
		new sbyte[]
		{
			13,
			13,
			5
		},
		new sbyte[]
		{
			7,
			7,
			4
		},
		new sbyte[]
		{
			9,
			9,
			4
		},
		new sbyte[]
		{
			13,
			13,
			5
		},
		new sbyte[]
		{
			16,
			16,
			4
		},
		new sbyte[]
		{
			13,
			22,
			1
		}
	};

	// Token: 0x04000324 RID: 804
	private long time;

	// Token: 0x04000325 RID: 805
	public int subType;

	// Token: 0x04000326 RID: 806
	public int indexSound;

	// Token: 0x04000327 RID: 807
	public bool ispaintArena = true;

	// Token: 0x04000328 RID: 808
	private int vXTam;

	// Token: 0x04000329 RID: 809
	private int vYTam;

	// Token: 0x0400032A RID: 810
	private int x1000;

	// Token: 0x0400032B RID: 811
	private int y1000;

	// Token: 0x0400032C RID: 812
	private int vX1000;

	// Token: 0x0400032D RID: 813
	private int vY1000;

	// Token: 0x0400032E RID: 814
	private int xEff;

	// Token: 0x0400032F RID: 815
	private int yEff;

	// Token: 0x04000330 RID: 816
	private int angle;

	// Token: 0x04000331 RID: 817
	private int R;

	// Token: 0x04000332 RID: 818
	private int size1;

	// Token: 0x04000333 RID: 819
	public int[][] mTamgiac;

	// Token: 0x04000334 RID: 820
	private int lT_Arc;

	// Token: 0x04000335 RID: 821
	private int gocT_Arc;

	// Token: 0x04000336 RID: 822
	private int r;

	// Token: 0x04000337 RID: 823
	public static sbyte countSkillArena;

	// Token: 0x04000338 RID: 824
	public static int[][] colorStar = new int[][]
	{
		new int[]
		{
			16310304,
			16298056,
			16777215
		},
		new int[]
		{
			7045120,
			12643960,
			16777215
		}
	};

	// Token: 0x04000339 RID: 825
	private int[] colorpaint;

	// Token: 0x0400033A RID: 826
	private static int[][] colorBuffMain = new int[][]
	{
		new int[]
		{
			11878912,
			16298056,
			16777215,
			16777215
		},
		new int[]
		{
			16244265,
			16298056,
			16777215,
			16777215
		},
		new int[]
		{
			9482488,
			16298056,
			16777215,
			16777215
		},
		new int[]
		{
			11569320,
			16298056,
			16777215,
			16777215
		},
		new int[]
		{
			16646016,
			13357112,
			16777215,
			16777215
		}
	};

	// Token: 0x0400033B RID: 827
	private int colorBuff;

	// Token: 0x0400033C RID: 828
	private int indexColorStar;

	// Token: 0x0400033D RID: 829
	private int timedelay;

	// Token: 0x0400033E RID: 830
	private new int ysai;

	// Token: 0x0400033F RID: 831
	private sbyte timeAddNum;

	// Token: 0x04000340 RID: 832
	private mVector VecEff = new mVector("EffectSkill VecEff");

	// Token: 0x04000341 RID: 833
	private mVector VecSubEff = new mVector("EffectSkill VecSubEff");

	// Token: 0x04000342 RID: 834
	private sbyte[] mpaintone_three = new sbyte[]
	{
		4,
		3,
		2,
		1,
		0,
		7,
		6,
		5
	};

	// Token: 0x04000343 RID: 835
	private sbyte[] mpaintone_Bullet = new sbyte[]
	{
		12,
		11,
		10,
		9,
		8,
		7,
		6,
		5,
		4,
		3,
		2,
		1,
		0,
		23,
		22,
		21,
		20,
		19,
		18,
		17,
		16,
		15,
		14,
		13
	};

	// Token: 0x04000344 RID: 836
	private sbyte[] mImageBullet = new sbyte[]
	{
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2,
		0,
		0,
		2,
		1,
		1,
		2
	};

	// Token: 0x04000345 RID: 837
	private sbyte[] mXoayBullet = new sbyte[]
	{
		2,
		2,
		3,
		3,
		3,
		4,
		5,
		5,
		5,
		5,
		5,
		1,
		0,
		0,
		0,
		0,
		0,
		7,
		6,
		6,
		6,
		6,
		6,
		2
	};

	// Token: 0x04000346 RID: 838
	private int gocArrow;

	// Token: 0x04000347 RID: 839
	private int frameArrow;

	// Token: 0x04000348 RID: 840
	private int xline;

	// Token: 0x04000349 RID: 841
	private int yline;

	// Token: 0x0400034A RID: 842
	private int yFly;

	// Token: 0x0400034B RID: 843
	private int ydArchor;

	// Token: 0x0400034C RID: 844
	private int yArchor;

	// Token: 0x0400034D RID: 845
	private int indexLan;

	// Token: 0x0400034E RID: 846
	private MainObject objKill;

	// Token: 0x0400034F RID: 847
	public mVector vecObjBeKill;

	// Token: 0x04000350 RID: 848
	private bool isEff;

	// Token: 0x04000351 RID: 849
	private bool ispaintsleep;

	// Token: 0x04000352 RID: 850
	private int indexAdd;

	// Token: 0x04000353 RID: 851
	private int dxTower;

	// Token: 0x04000354 RID: 852
	private int dyTower;

	// Token: 0x04000355 RID: 853
	private int xdichTower;

	// Token: 0x04000356 RID: 854
	private int ydichTower;

	// Token: 0x04000357 RID: 855
	private int delay;

	// Token: 0x04000358 RID: 856
	public sbyte[] arr_R = new sbyte[]
	{
		40,
		40,
		40,
		40,
		40,
		40,
		40,
		40,
		40,
		40,
		40,
		40
	};

	// Token: 0x04000359 RID: 857
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

	// Token: 0x0400035A RID: 858
	public int xto;

	// Token: 0x0400035B RID: 859
	public int yto;

	// Token: 0x0400035C RID: 860
	public int dx;

	// Token: 0x0400035D RID: 861
	public int dy;

	// Token: 0x0400035E RID: 862
	public int nPosition;

	// Token: 0x0400035F RID: 863
	public int xO;

	// Token: 0x04000360 RID: 864
	public int yO;

	// Token: 0x04000361 RID: 865
	public int dem;

	// Token: 0x04000362 RID: 866
	public int radian;

	// Token: 0x04000363 RID: 867
	public new int frame;

	// Token: 0x04000364 RID: 868
	public int effect;

	// Token: 0x04000365 RID: 869
	public static int[][] posx = new int[][]
	{
		new int[]
		{
			4,
			11,
			11,
			15,
			10,
			7,
			5,
			6,
			4,
			3,
			11,
			13,
			13,
			13,
			12,
			15
		},
		new int[]
		{
			14,
			14,
			16,
			15,
			18,
			20,
			22,
			22,
			23,
			21,
			9,
			11,
			9,
			10,
			9,
			9
		}
	};

	// Token: 0x04000366 RID: 870
	public static int[][] posy = new int[][]
	{
		new int[]
		{
			11,
			9,
			11,
			11,
			13,
			14,
			13,
			14,
			11,
			13,
			15,
			14,
			13,
			13,
			12,
			15
		},
		new int[]
		{
			9,
			12,
			12,
			14,
			14,
			15,
			13,
			11,
			13,
			14,
			9,
			11,
			9,
			10,
			9,
			9
		}
	};

	// Token: 0x04000367 RID: 871
	private sbyte indexpost;

	// Token: 0x04000368 RID: 872
	public int Xsleep;

	// Token: 0x04000369 RID: 873
	public int vxSleep;

	// Token: 0x0400036A RID: 874
	public int Ysleep;

	// Token: 0x0400036B RID: 875
	public int ystun;

	// Token: 0x0400036C RID: 876
	private int test;

	// Token: 0x0400036D RID: 877
	public int frSleep;

	// Token: 0x0400036E RID: 878
	public int[] frameSleep = new int[]
	{
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
		1
	};

	// Token: 0x0400036F RID: 879
	public sbyte frStun;

	// Token: 0x04000370 RID: 880
	public int[] frameStun = new int[]
	{
		0,
		0,
		0,
		1,
		1,
		1,
		2,
		2,
		2
	};

	// Token: 0x04000371 RID: 881
	private mVector vectam;

	// Token: 0x04000372 RID: 882
	private int life;

	// Token: 0x04000373 RID: 883
	private int va;

	// Token: 0x04000374 RID: 884
	public bool isSpeedUp;

	// Token: 0x04000375 RID: 885
	private int savex;

	// Token: 0x04000376 RID: 886
	private int savey;
}
