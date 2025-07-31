using System;

// Token: 0x0200004D RID: 77
public class MainBuff
{
	// Token: 0x06000360 RID: 864 RVA: 0x0002D90C File Offset: 0x0002BB0C
	public MainBuff(int type, int time)
	{
		this.typeBuff = type;
		this.timebuff = mSystem.currentTimeMillis() + (long)(time * 1000);
		switch (this.typeBuff)
		{
		case 11:
			this.fraImage = new FrameImage(149);
			break;
		case 12:
			this.fraImage = new FrameImage(147);
			break;
		case 13:
			this.fraImage = new FrameImage(146);
			break;
		case 14:
			this.fraImage = new FrameImage(148);
			break;
		}
	}

	// Token: 0x06000361 RID: 865 RVA: 0x0002D9E0 File Offset: 0x0002BBE0
	public MainBuff(int type, int time, int typeSub)
	{
		this.typeBuff = type;
		this.typeSub = typeSub;
		this.timeBegin = GameCanvas.timeNow;
		this.timeOff = time;
		this.x0 = 0;
		this.y0 = 0;
		this.framebegin = CRes.random(9);
		switch (type)
		{
		case 0:
		case 2:
		case 5:
		case 7:
			this.fraImage = new FrameImage(88);
			break;
		case 1:
		case 3:
		case 6:
		case 8:
			this.fraImage = new FrameImage(89);
			break;
		case 4:
			this.isPaintLast = true;
			if (typeSub == 3)
			{
				this.fraImage = new FrameImage(81);
				this.framebegin = 0;
			}
			else
			{
				this.fraImage = new FrameImage(80);
				this.framebegin = typeSub;
				if (typeSub > 3)
				{
					this.framebegin--;
				}
			}
			for (int i = 0; i < 3; i++)
			{
				Point point = new Point();
				point.x = CRes.random_Am_0(16);
				point.y = CRes.random_Am_0(10);
				if (typeSub == 3)
				{
					point.vx = CRes.random_Am_0(3);
					point.vy = CRes.random_Am_0(2);
				}
				this.vecEff.addElement(point);
			}
			break;
		case 9:
			this.isPaintLast = true;
			break;
		default:
			this.isRemove = true;
			break;
		}
	}

	// Token: 0x06000362 RID: 866 RVA: 0x0002DB7C File Offset: 0x0002BD7C
	public void settimebuff(long time)
	{
		this.timebuff = mSystem.currentTimeMillis() + time * 1000L;
	}

	// Token: 0x06000363 RID: 867 RVA: 0x0002DB94 File Offset: 0x0002BD94
	public void paint(mGraphics g, int x, int y)
	{
		if (this.isRemove)
		{
			return;
		}
		switch (this.typeBuff)
		{
		case 0:
		case 1:
		case 5:
		case 6:
		case 10:
			if (this.fraImage == null)
			{
				return;
			}
			this.fraImage.drawFrameEffectSkill(2 - (GameCanvas.gameTick + this.framebegin) / 3 % this.fraImage.nFrame, x + this.x0, y + this.y0, 0, 3, g);
			break;
		case 2:
		case 3:
		case 7:
		case 8:
			if (this.fraImage == null)
			{
				return;
			}
			this.fraImage.drawFrameEffectSkill((GameCanvas.gameTick + this.framebegin) / 3 % this.fraImage.nFrame, x + this.x0, y + this.y0, 0, 3, g);
			break;
		case 4:
			if (this.fraImage == null || this.vecEff == null)
			{
				return;
			}
			for (int i = 0; i < this.vecEff.size(); i++)
			{
				Point point = (Point)this.vecEff.elementAt(i);
				if (point != null)
				{
					this.fraImage.drawFrameEffectSkill(this.framebegin * 3 + point.f % this.fraImage.nFrame, x + point.x, y + point.y, 0, 3, g);
				}
			}
			break;
		case 9:
			for (int j = this.vecEff.size() - 1; j >= 0; j--)
			{
				Line line = (Line)this.vecEff.elementAt(j);
				if (line != null)
				{
					int color = EffectSkill.colorStar[0][line.idColor];
					g.setColor(color);
					g.fillRect(line.x0, line.y0, 1, line.Rec_h, false);
					if (line.is2Line)
					{
						g.fillRect(line.x0 + 2, line.y0 + 1, 1, line.Rec_h, mGraphics.isFalse);
					}
				}
			}
			this.x1000 = x;
			this.y1000 = y;
			break;
		case 11:
		case 12:
		case 13:
		case 14:
			if (this.fraImage != null)
			{
				this.fraImage.drawFrameEffectSkill((int)this.frame_Buff[(int)this.frBuff], x, y - 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			break;
		}
	}

	// Token: 0x06000364 RID: 868 RVA: 0x0002DE14 File Offset: 0x0002C014
	public void update()
	{
		if (!this.isRemove)
		{
			if (!this.isForEver)
			{
				if (this.typeBuff == 4)
				{
					if (CRes.random(2) == 0)
					{
						Point point = new Point();
						point.x = CRes.random_Am_0(16);
						point.y = CRes.random_Am_0(10);
						if (this.typeSub == 3)
						{
							point.vx = CRes.random_Am_0(3);
							point.vy = CRes.random_Am_0(2);
						}
						this.vecEff.addElement(point);
					}
					for (int i = 0; i < this.vecEff.size(); i++)
					{
						Point point2 = (Point)this.vecEff.elementAt(i);
						point2.update();
						if (point2.f >= 3)
						{
							this.vecEff.removeElement(point2);
							i--;
						}
					}
				}
				else if (this.typeBuff == 9)
				{
					if (GameCanvas.gameTick % 2 == 0)
					{
						this.create_Line_NHANBAN_LV2();
					}
					for (int j = 0; j < this.vecEff.size(); j++)
					{
						Line line = (Line)this.vecEff.elementAt(j);
						line.update();
						if (line.f >= line.fRe)
						{
							this.vecEff.removeElement(line);
							j--;
						}
					}
				}
				else if (this.typeBuff > 10 && this.typeBuff < 15)
				{
					this.frBuff += 1;
					if ((int)this.frBuff > this.frame_Buff.Length - 1)
					{
						this.frBuff = 0;
					}
					if (this.timebuff - mSystem.currentTimeMillis() < 0L)
					{
						this.isRemove = true;
					}
				}
				if (GameCanvas.gameTick % 10 == 0 && this.typeBuff < 11 && GameCanvas.timeNow - this.timeBegin > (long)this.timeOff)
				{
					this.isRemove = true;
				}
			}
			if (this.minfotam != null)
			{
				this.minfo = this.minfotam;
				this.minfotam = null;
			}
		}
	}

	// Token: 0x06000365 RID: 869 RVA: 0x0002E028 File Offset: 0x0002C228
	public static void setEffHead(int sub, int time, MainObject obj)
	{
		for (int i = 0; i < obj.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)obj.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == 4 && mainBuff.typeSub == sub)
			{
				mainBuff.timeBegin = GameCanvas.timeNow;
				mainBuff.timeOff = time * 1000;
				return;
			}
		}
		obj.addBuff(4, time * 1000, sub);
	}

	// Token: 0x06000366 RID: 870 RVA: 0x0002E0A4 File Offset: 0x0002C2A4
	public static MainBuff getBuff(int index, int sub)
	{
		for (int i = 0; i < GameScreen.player.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(i);
			if (mainBuff.typeBuff == index && mainBuff.typeSub == sub)
			{
				return mainBuff;
			}
		}
		return null;
	}

	// Token: 0x06000367 RID: 871 RVA: 0x0002E104 File Offset: 0x0002C304
	public void create_Line_NHANBAN_LV2()
	{
		int num = CRes.random(1, 4);
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
			line.is2Line = (CRes.random(5) == 0);
			int x = this.x1000 + CRes.random_Am_0(15);
			int num4 = this.y1000 - CRes.random_Am_0(10);
			line.setLine(x, num4, x, num4 - num2, 0, -num3, line.is2Line);
			line.idColor = CRes.random(3);
			line.Rec_h = CRes.random(4, 7);
			this.vecEff.addElement(line);
		}
	}

	// Token: 0x04000475 RID: 1141
	public const int BUFF_KIEM_1 = 0;

	// Token: 0x04000476 RID: 1142
	public const int BUFF_2KIEM_1 = 1;

	// Token: 0x04000477 RID: 1143
	public const int BUFF_PS_1 = 2;

	// Token: 0x04000478 RID: 1144
	public const int BUFF_SUNG_1 = 3;

	// Token: 0x04000479 RID: 1145
	public const int BUFF_HEAD = 4;

	// Token: 0x0400047A RID: 1146
	public const int BUFF_KIEM_2 = 5;

	// Token: 0x0400047B RID: 1147
	public const int BUFF_2KIEM_2 = 6;

	// Token: 0x0400047C RID: 1148
	public const int BUFF_PS_2 = 7;

	// Token: 0x0400047D RID: 1149
	public const int BUFF_SUNG_2 = 8;

	// Token: 0x0400047E RID: 1150
	public const int BUFF_CRAZY = 9;

	// Token: 0x0400047F RID: 1151
	public const int BUFF_PET = 10;

	// Token: 0x04000480 RID: 1152
	public const sbyte EFF_BUFF_GOLD = 11;

	// Token: 0x04000481 RID: 1153
	public const sbyte EFF_BUFF_AMOR = 12;

	// Token: 0x04000482 RID: 1154
	public const sbyte EFF_BUFF_DAME = 13;

	// Token: 0x04000483 RID: 1155
	public const sbyte EFF_BUFF_HUTHP = 14;

	// Token: 0x04000484 RID: 1156
	public long timeBegin;

	// Token: 0x04000485 RID: 1157
	public bool isPaintLast;

	// Token: 0x04000486 RID: 1158
	private bool isForEver;

	// Token: 0x04000487 RID: 1159
	private int x0;

	// Token: 0x04000488 RID: 1160
	private int y0;

	// Token: 0x04000489 RID: 1161
	private int x1000;

	// Token: 0x0400048A RID: 1162
	private int y1000;

	// Token: 0x0400048B RID: 1163
	public int timeOff;

	// Token: 0x0400048C RID: 1164
	private int indexPaint;

	// Token: 0x0400048D RID: 1165
	private int framebegin;

	// Token: 0x0400048E RID: 1166
	private long timebuff;

	// Token: 0x0400048F RID: 1167
	public bool isRemove;

	// Token: 0x04000490 RID: 1168
	public int typeBuff;

	// Token: 0x04000491 RID: 1169
	public int typeSub;

	// Token: 0x04000492 RID: 1170
	public short idIcon;

	// Token: 0x04000493 RID: 1171
	public sbyte[] frame_Buff = new sbyte[]
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

	// Token: 0x04000494 RID: 1172
	public sbyte frBuff;

	// Token: 0x04000495 RID: 1173
	public MainInfoItem[] minfo;

	// Token: 0x04000496 RID: 1174
	public MainInfoItem[] minfotam;

	// Token: 0x04000497 RID: 1175
	private FrameImage fraImage;

	// Token: 0x04000498 RID: 1176
	private mVector vecEff = new mVector("MainBuff VecEff");
}
