using System;

// Token: 0x02000034 RID: 52
public class EffectEnd : MainEffect
{
	// Token: 0x06000263 RID: 611 RVA: 0x0000FF1C File Offset: 0x0000E11C
	public EffectEnd(int type, int id, int x, int y)
	{
		this.f = -1;
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		this.fraImgEff = new FrameImage(id);
		this.fRemove = this.fraImgEff.getNFrame();
	}

	// Token: 0x06000264 RID: 612 RVA: 0x0000FF94 File Offset: 0x0000E194
	public EffectEnd(int type, int x, int y)
	{
		this.f = -1;
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		switch (type)
		{
		case 0:
			this.fraImgEff = new FrameImage(53);
			this.fRemove = 6;
			break;
		case 1:
			this.fraImgEff = new FrameImage(29);
			this.fRemove = 3;
			break;
		case 2:
			this.fraImgEff = new FrameImage(18);
			this.fRemove = 4;
			break;
		case 3:
			this.fraImgEff = new FrameImage(27);
			this.fRemove = 15;
			for (int i = 0; i < 7; i++)
			{
				Point point = new Point();
				point.x = x + CRes.random_Am_0(22);
				point.y = y + CRes.random_Am_0(8);
				point.dis = CRes.random(this.fraImgEff.nFrame);
				this.VecEffEnd.addElement(point);
			}
			break;
		case 4:
			this.fraImgEff = new FrameImage(4);
			this.fRemove = 5;
			break;
		case 5:
			this.fraImgEff = new FrameImage(51);
			this.fRemove = 6;
			break;
		case 6:
			this.fraImgEff = new FrameImage(52);
			this.fRemove = 4;
			break;
		case 7:
			this.fraImgEff = new FrameImage(54);
			this.fRemove = 4;
			break;
		case 9:
		{
			if (GameCanvas.lowGraphic)
			{
				this.removeEff();
				return;
			}
			this.fraImgEff = new FrameImage(56);
			this.fRemove = CRes.random(11, 15);
			int num = CRes.random(3, 7);
			for (int j = 0; j < num; j++)
			{
				Point point2 = new Point();
				point2.x = x + CRes.random_Am_0(5);
				point2.y = y + CRes.random_Am_0(7);
				point2.frame = CRes.random(this.fraImgEff.nFrame);
				point2.dis = CRes.random(2);
				point2.vy = -CRes.random(6, 9);
				point2.vx = CRes.random(1, 4);
				if (j % 2 == 0)
				{
					point2.vx = -point2.vx;
				}
				this.VecEffEnd.addElement(point2);
			}
			break;
		}
		case 10:
			this.fraImgEff = new FrameImage(58);
			this.fRemove = 4;
			break;
		case 11:
			this.fraImgEff = new FrameImage(42);
			this.fRemove = 9;
			break;
		case 12:
			this.fraImgEff = new FrameImage(60);
			this.fRemove = 4;
			break;
		case 13:
			this.fraImgEff = new FrameImage(9);
			this.fRemove = 4;
			break;
		case 14:
		case 15:
		{
			if (GameCanvas.lowGraphic)
			{
				this.removeEff();
				return;
			}
			int num2;
			if (type == 14)
			{
				this.fraImgEff = new FrameImage(1);
				num2 = CRes.random(7, 12);
			}
			else
			{
				this.fraImgEff = new FrameImage(5);
				num2 = CRes.random(7, 12);
			}
			this.fRemove = 12;
			for (int k = 0; k < num2; k++)
			{
				Point point3 = new Point();
				point3.x = x + CRes.random_Am_0(4);
				point3.y = y + CRes.random_Am_0(5);
				point3.frame = CRes.random(this.fraImgEff.nFrame);
				point3.vy = -CRes.random(5, 9);
				point3.vx = CRes.random(0, 3);
				if (k % 2 == 0)
				{
					point3.vx = -point3.vx;
				}
				this.VecEffEnd.addElement(point3);
			}
			break;
		}
		case 19:
			if (GameCanvas.lowGraphic)
			{
				this.removeEff();
				return;
			}
			this.fraImgEff = new FrameImage(28);
			this.frame = ((CRes.random(2) != 0) ? 2 : 0);
			this.fRemove = 2;
			break;
		case 21:
		case 33:
		{
			int num2;
			if (this.typeEffect == 33)
			{
				this.fraImgEff = new FrameImage(2);
				num2 = 30;
				this.fRemove = 30;
			}
			else
			{
				this.fraImgEff = new FrameImage(66);
				num2 = 40;
				this.fRemove = 12;
			}
			for (int l = 0; l < num2; l++)
			{
				Point point4 = new Point();
				point4.x = x + CRes.random_Am_0(10);
				point4.y = y - CRes.random_Am_0(8);
				point4.frame = CRes.random(this.fraImgEff.nFrame);
				point4.vy = -CRes.random(3, 11);
				if (this.typeEffect == 33)
				{
					point4.vx = CRes.random(0, 4);
				}
				else
				{
					point4.vx = CRes.random(0, 3);
				}
				if (l % 2 == 0)
				{
					point4.vx = -point4.vx;
				}
				this.VecEffEnd.addElement(point4);
			}
			break;
		}
		case 24:
			this.fraImgEff = new FrameImage(12);
			this.fRemove = CRes.random(18, 23);
			this.levelPaint = -1;
			break;
		case 25:
		case 28:
		case 40:
			if (this.typeEffect == 25)
			{
				this.fraImgEff = new FrameImage(86);
			}
			else if (this.typeEffect == 28)
			{
				this.fraImgEff = new FrameImage(96);
			}
			else if (this.typeEffect == 40)
			{
				int tile = GameCanvas.loadmap.getTile(x, y);
				if (tile == 2 || tile == -1)
				{
					return;
				}
				this.fraImgEff = new FrameImage(19);
			}
			this.levelPaint = -1;
			this.fRemove = CRes.random(74, 85);
			this.fRemove_Low(20);
			break;
		case 26:
			this.levelPaint = -1;
			if (CRes.random(2) == 0)
			{
				this.fraImgEff = new FrameImage(90);
			}
			else
			{
				this.fraImgEff = new FrameImage(13);
			}
			this.fRemove = CRes.random(74, 85);
			this.fRemove_Low(20);
			break;
		case 27:
		case 30:
			this.fRemove = 20;
			this.levelPaint = -1;
			if (this.typeEffect == 27)
			{
				this.fraImgEff = new FrameImage(92);
			}
			else if (this.typeEffect == 30)
			{
				this.fraImgEff = new FrameImage(115);
			}
			for (int m = 0; m < 3; m++)
			{
				Point point5 = new Point();
				point5.x = x + CRes.random_Am_0(3);
				point5.y = y + CRes.random_Am_0(3);
				if (CRes.random(2) == 0)
				{
					if (m % 2 == 0)
					{
						point5.vx = CRes.random(3);
					}
					else
					{
						point5.vx = -CRes.random(3);
					}
				}
				else
				{
					point5.vx = CRes.random_Am_0(3);
				}
				point5.vy = -5;
				point5.fRe = CRes.random(6, 12);
				point5.frame = m;
				this.VecEffEnd.addElement(point5);
			}
			break;
		case 29:
		{
			this.fraImgEff = new FrameImage(105);
			this.fRemove = CRes.random(11, 15);
			int num3 = CRes.random(3, 6);
			for (int n = 0; n < num3; n++)
			{
				Point point6 = new Point();
				point6.x = x + CRes.random_Am_0(5);
				point6.y = y + CRes.random_Am_0(7);
				point6.frame = CRes.random(this.fraImgEff.nFrame);
				point6.dis = CRes.random(2);
				point6.vy = -CRes.random(6, 9);
				point6.vx = CRes.random(1, 4);
				if (n % 2 == 0)
				{
					point6.vx = -point6.vx;
				}
				this.VecEffEnd.addElement(point6);
			}
			break;
		}
		case 32:
			this.create_Level_up();
			break;
		case 34:
			this.fraImgEff = new FrameImage(14);
			this.fRemove = 18;
			break;
		case 35:
			this.fraImgEff = new FrameImage(122);
			this.fRemove = 6;
			break;
		case 36:
			this.fraImgEff = new FrameImage(4);
			this.fRemove = 10;
			break;
		case 38:
			this.fraImgEff = new FrameImage(65);
			this.fraImgSubEff = new FrameImage(122);
			this.fraImgSub2Eff = new FrameImage(14);
			this.fRemove = 12;
			break;
		case 39:
			this.fRemove = 55;
			break;
		case 42:
			this.fraImgEff = new FrameImage(7);
			this.fraImgSubEff = new FrameImage(2);
			this.fRemove = 20;
			this.gocT_Arc = 0;
			for (int num4 = 0; num4 < 8; num4++)
			{
				int num5 = CRes.random(4, 6);
				Point point7 = new Point();
				point7.x = x * 1000;
				point7.y = y * 1000;
				point7.vx = CRes.cos(CRes.fixangle(this.gocT_Arc)) * num5;
				point7.vy = CRes.sin(CRes.fixangle(this.gocT_Arc)) * num5;
				this.gocT_Arc += 45;
				this.VecEffEnd.addElement(point7);
			}
			break;
		case 43:
			this.fraImgEff = new FrameImage(124);
			this.fRemove = 10;
			break;
		case 44:
			this.fraImgEff = new FrameImage(70);
			this.fRemove = 4;
			break;
		case 45:
			this.fraImgEff = new FrameImage(63);
			this.fRemove = 8;
			break;
		case 46:
			this.fraImgEff = new FrameImage(86);
			this.levelPaint = -1;
			this.fRemove = 6;
			break;
		case 48:
			this.fraImgEff = new FrameImage(134);
			this.fRemove = 8;
			break;
		case 51:
			this.fraImgEff = new FrameImage(140);
			this.fRemove = 6;
			break;
		case 54:
			this.fraImgEff = new FrameImage(144);
			this.fRemove = 10;
			break;
		}
	}

	// Token: 0x06000265 RID: 613 RVA: 0x00010A58 File Offset: 0x0000EC58
	public EffectEnd(int type, int x, int y, int direction, sbyte levelPaint)
	{
		this.f = -1;
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		this.Direction = direction;
		switch (type)
		{
		case 55:
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
				2
			};
			int tile = GameCanvas.loadmap.getTile(x, y);
			if (tile == 2 || tile == -1)
			{
				return;
			}
			this.fraImgEff = new FrameImage(145);
			this.levelPaint = (int)levelPaint;
			break;
		}
		case 56:
			this.fraImgEff = new FrameImage(152);
			this.levelPaint = (int)levelPaint;
			this.fRemove = CRes.random(20, 30);
			this.fRemove_Low(20);
			break;
		case 58:
			this.fraImgEff = new FrameImage(164);
			this.levelPaint = (int)levelPaint;
			this.fRemove = CRes.random(20, 30);
			this.fRemove_Low(20);
			break;
		}
	}

	// Token: 0x06000266 RID: 614 RVA: 0x00010B98 File Offset: 0x0000ED98
	public EffectEnd(int type, int x, int y, long timeRemove)
	{
		this.f = -1;
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		switch (type)
		{
		case 47:
			this.timeRemove = timeRemove + (long)this.timeDeley;
			this.fraImgEff = new FrameImage(86);
			this.levelPaint = -1;
			this.fRemove = CRes.random(74, 85);
			this.fRemove_Low(20);
			break;
		case 49:
			this.timeRemove = timeRemove;
			this.effAuto = new EffectAuto(51, x, y, 0, 0, 0, 0);
			this.levelPaint = -1;
			this.fRemove = 6;
			break;
		case 50:
			this.timeRemove = timeRemove;
			this.fraImgEff = new FrameImage(137);
			this.levelPaint = -1;
			this.fRemove = 12;
			break;
		}
	}

	// Token: 0x06000267 RID: 615 RVA: 0x00010CAC File Offset: 0x0000EEAC
	public EffectEnd(int type, int x, int y, sbyte typeSub)
	{
		this.f = -1;
		this.typeEffect = type;
		this.typeSub = typeSub;
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000268 RID: 616 RVA: 0x00010D10 File Offset: 0x0000EF10
	public EffectEnd(int type, int x, int y, int xTo, int yTo, int num)
	{
		this.typeEffect = type;
		this.x = x;
		this.y = y;
		this.toX = xTo;
		this.toY = yTo;
		if (type != 31)
		{
			if (type != 37)
			{
				if (type == 41)
				{
					this.fraImgEff = new FrameImage(7);
					this.fraImgSubEff = new FrameImage(2);
					this.fRemove = 18;
				}
			}
			else
			{
				this.fraImgEff = new FrameImage(7);
				this.fraImgSubEff = new FrameImage(2);
				this.fRemove = 100;
				this.lT_Arc = 40;
				this.gocT_Arc = 0;
				this.numEffReplace = num;
				this.plusGoc = 360 / num;
			}
		}
		else
		{
			this.create_Arc_Big_Small();
		}
	}

	// Token: 0x06000269 RID: 617 RVA: 0x00010E0C File Offset: 0x0000F00C
	public override void paint(mGraphics g)
	{
		try
		{
			switch (this.typeEffect)
			{
			case 0:
			case 2:
			case 5:
			case 11:
			case 35:
			case 36:
			case 51:
			case 54:
			case 57:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				break;
			case 1:
			case 4:
			case 6:
			case 7:
			case 10:
			case 12:
			case 13:
			case 44:
			case 45:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				break;
			case 3:
				for (int i = 0; i < this.VecEffEnd.size(); i++)
				{
					Point point = (Point)this.VecEffEnd.elementAt(i);
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill((point.f + this.f) / 2 % this.fraImgEff.nFrame, point.x, point.y, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
					}
				}
				break;
			case 9:
			case 27:
			case 29:
			case 30:
				for (int j = 0; j < this.VecEffEnd.size(); j++)
				{
					Point point2 = (Point)this.VecEffEnd.elementAt(j);
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(point2.frame, point2.x, point2.y, 0, 3, g);
					}
				}
				break;
			case 14:
			case 15:
			case 21:
				for (int k = 0; k < this.VecEffEnd.size(); k++)
				{
					Point point3 = (Point)this.VecEffEnd.elementAt(k);
					if (this.f < this.fRemove / 3 * 2)
					{
						if (this.fraImgEff != null)
						{
							this.fraImgEff.drawFrameEffectSkill(point3.frame, point3.x, point3.y, 0, 3, g);
						}
					}
					else if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill((point3.frame != 0) ? point3.frame : 3, point3.x, point3.y, 0, 3, g);
					}
				}
				break;
			case 19:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.frame + this.f % this.fraImgEff.nFrame, this.x - this.fraImgEff.frameWidth / 2, this.y - this.fraImgEff.frameHeight / 2, 0, 0, g);
				}
				break;
			case 24:
			{
				int num = 0;
				if (this.f > this.fRemove - 5)
				{
					num = (this.f - (this.fRemove - 4)) / 2;
				}
				if (num < 3 && this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(num, this.x, this.y, 0, 3, g);
				}
				break;
			}
			case 25:
			case 28:
			case 40:
			case 46:
				if (this.f <= this.fRemove)
				{
					int idx;
					if (this.f < 2)
					{
						idx = this.f;
					}
					if (this.f > this.fRemove - 5)
					{
						idx = (this.fRemove - 1 - this.f) / 2;
					}
					else
					{
						idx = 2;
					}
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(idx, this.x, this.y, 0, 3, g);
					}
				}
				break;
			case 26:
				if (this.f < 2)
				{
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(this.f, this.x, this.y, 0, 3, g);
					}
				}
				else if (this.f < this.fRemove - 4)
				{
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(2, this.x, this.y, 0, 3, g);
					}
				}
				else if (this.f < this.fRemove && this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill((this.fRemove - 1 - this.f) / 2, this.x, this.y, 0, 3, g);
				}
				break;
			case 31:
				for (int l = 0; l < this.VecEffEnd.size(); l++)
				{
					Point point4 = (Point)this.VecEffEnd.elementAt(l);
					if (this.fraImgSubEff != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point4.f / 2, point4.x, point4.y, 0, 3, g);
					}
				}
				if (this.lT_Arc > 5 && this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.pRebuild.v, (this.pRebuild.x2 + this.pRebuild.vx) / 1000, (this.pRebuild.y2 + this.pRebuild.vy) / 1000, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
				}
				break;
			case 32:
				if (this.fraImgSubEff != null)
				{
					this.fraImgSubEff.drawFrameEffectSkill(0, this.x, this.y - (this.f - this.fRemove / 2) * 2, 0, 3, g);
				}
				break;
			case 33:
				for (int m = 0; m < this.VecEffEnd.size(); m++)
				{
					Point point5 = (Point)this.VecEffEnd.elementAt(m);
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill((point5.frame + point5.f / 2) % this.fraImgEff.nFrame, point5.x, point5.y, 0, 3, g);
					}
				}
				break;
			case 34:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 3 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				break;
			case 37:
			case 41:
			case 42:
				for (int n = 0; n < this.VecEffEnd.size(); n++)
				{
					Point point6 = (Point)this.VecEffEnd.elementAt(n);
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(point6.f / 2 % this.fraImgEff.nFrame, point6.x / 1000, point6.y / 1000, 0, 3, g);
					}
				}
				for (int num2 = 0; num2 < this.VecSubEffEnd.size(); num2++)
				{
					Point point7 = (Point)this.VecSubEffEnd.elementAt(num2);
					if (this.fraImgSubEff != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(point7.f / 2, point7.x, point7.y, 0, 3, g);
					}
				}
				break;
			case 38:
				if (this.f < 6)
				{
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(this.f, this.x, this.y, 0, 3, g);
					}
					if (this.fraImgSubEff != null)
					{
						this.fraImgSubEff.drawFrameEffectSkill(2 - this.f / 2, this.x, this.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					}
				}
				else if (this.fraImgSub2Eff != null)
				{
					this.fraImgSub2Eff.drawFrameEffectSkill(this.f - 6, this.x, this.y - 20, 0, 3, g);
				}
				break;
			case 43:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				break;
			case 47:
				if (this.timeRemove - mSystem.currentTimeMillis() >= 0L)
				{
					long num3 = (this.timeRemove - mSystem.currentTimeMillis()) / 1000L;
					int idx2;
					if (num3 >= 2L)
					{
						idx2 = 2;
					}
					else if (num3 >= 1L)
					{
						idx2 = 1;
					}
					else
					{
						idx2 = 0;
					}
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(idx2, this.x, this.y, 0, 3, g);
					}
				}
				break;
			case 48:
			case 50:
				if (this.fraImgEff != null)
				{
					this.fraImgEff.drawFrameEffectSkill(this.f / 2 % this.fraImgEff.nFrame, this.x, this.y, 0, 3, g);
				}
				break;
			case 49:
				if (this.effAuto != null)
				{
					this.effAuto.paint(g);
				}
				break;
			case 55:
				try
				{
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill((int)this.nFrame[this.f], this.x, this.y, this.trans, 3, g);
					}
				}
				catch (Exception ex)
				{
					mSystem.println(string.Concat(new object[]
					{
						"err mountdust f:",
						this.nFrame.Length,
						"  ",
						this.f
					}));
				}
				break;
			case 56:
				if (this.f <= this.fRemove)
				{
					int idx3;
					if (this.f < 2)
					{
						idx3 = this.f;
					}
					if (this.f > this.fRemove - 5)
					{
						idx3 = (this.fRemove - 1 - this.f) / 2;
					}
					else
					{
						idx3 = 2;
					}
					if (this.Direction != 3 || mSystem.isWinphone)
					{
					}
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(idx3, this.x, this.y, this.trans, 3, g);
					}
				}
				break;
			case 58:
				if (this.f <= this.fRemove)
				{
					if (this.f < 2)
					{
						int num4 = this.f;
					}
					if (this.f > this.fRemove - 5)
					{
						int num4 = (this.fRemove - 1 - this.f) / 2;
					}
					if (this.fraImgEff != null)
					{
						this.fraImgEff.drawFrameEffectSkill(0, this.x, this.y, this.trans, 3, g);
					}
				}
				break;
			}
		}
		catch (Exception ex2)
		{
			mSystem.println("/ " + this.typeEffect + ex2.ToString());
		}
	}

	// Token: 0x0600026A RID: 618 RVA: 0x000119C4 File Offset: 0x0000FBC4
	public override void update()
	{
		this.f++;
		this.subf++;
		switch (this.typeEffect)
		{
		case 0:
		case 1:
		case 2:
		case 4:
		case 5:
		case 6:
		case 7:
		case 10:
		case 11:
		case 12:
		case 13:
		case 19:
		case 24:
		case 25:
		case 26:
		case 28:
		case 34:
		case 35:
		case 40:
		case 44:
		case 46:
		case 51:
		case 54:
		case 57:
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 3:
			for (int i = 0; i < this.VecEffEnd.size(); i++)
			{
				Point point = (Point)this.VecEffEnd.elementAt(i);
				if (CRes.random(3) == 0)
				{
					point.x = this.x + CRes.random_Am_0(22);
					point.y = this.y + CRes.random_Am_0(8);
					point.f = CRes.random(this.fraImgEff.nFrame);
				}
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 9:
		case 14:
		case 15:
		case 29:
			for (int j = 0; j < this.VecEffEnd.size(); j++)
			{
				Point point2 = (Point)this.VecEffEnd.elementAt(j);
				point2.update();
				point2.vy++;
				if (this.f == this.fRemove && GameScreen.isWater(point2.x, point2.y))
				{
					GameScreen.addEffectEndKill(19, point2.x, point2.y);
				}
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 21:
			for (int k = 0; k < this.VecEffEnd.size(); k++)
			{
				Point point3 = (Point)this.VecEffEnd.elementAt(k);
				point3.update();
				if (point3.vy < 0)
				{
					point3.vy++;
				}
				else
				{
					point3.vy = 0;
					point3.vx = 0;
				}
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 27:
		case 30:
			for (int l = 0; l < this.VecEffEnd.size(); l++)
			{
				Point point4 = (Point)this.VecEffEnd.elementAt(l);
				point4.f++;
				if (point4.f < point4.fRe)
				{
					point4.x += point4.vx;
					point4.y += point4.vy;
				}
				point4.vy++;
			}
			if (this.f > this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 31:
			for (int m = 0; m < this.VecEffEnd.size(); m++)
			{
				Point point5 = (Point)this.VecEffEnd.elementAt(m);
				point5.f++;
				if (point5.f / 2 >= 4)
				{
					this.VecEffEnd.removeElement(point5);
					m--;
				}
			}
			this.pRebuild.v = this.f / 2 % 2;
			if (this.f > 4)
			{
				if (this.lT_Arc > 5)
				{
					this.pRebuild.f += 14;
					this.pRebuild.vy = CRes.sin(CRes.fixangle(this.pRebuild.f % 360)) * this.lT_Arc;
					this.pRebuild.vx = CRes.cos(CRes.fixangle(this.pRebuild.f % 360)) * this.lT_Arc;
					if (this.f % 2 == 0)
					{
						this.lT_Arc--;
						this.pRebuild.f += 14;
					}
					Point point6 = new Point();
					point6.x = (this.pRebuild.x2 + this.pRebuild.vx) / 1000 + CRes.random_Am(-1, 2);
					point6.y = (this.pRebuild.y2 + this.pRebuild.vy) / 1000 + CRes.random_Am(-1, 2);
					this.VecEffEnd.addElement(point6);
				}
				else if (this.VecEffEnd.size() == 0)
				{
					this.removeEff();
				}
			}
			break;
		case 32:
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			if (this.f < this.fRemove / 2)
			{
				for (int n = 0; n < this.VecEffEnd.size(); n++)
				{
					Point point7 = (Point)this.VecEffEnd.elementAt(n);
					if (CRes.random(3) == 0)
					{
						if (point7.fRe == 1)
						{
							point7.fRe = 0;
						}
						else
						{
							point7.fRe = 1;
							point7.frame = CRes.random(4);
						}
					}
				}
			}
			break;
		case 33:
			for (int num = 0; num < this.VecEffEnd.size(); num++)
			{
				Point point8 = (Point)this.VecEffEnd.elementAt(num);
				point8.update();
				point8.vy++;
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 36:
			if (this.f == 1)
			{
				GameScreen.addEffectEndKill(14, this.x, this.y);
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 37:
			if (this.f % 3 == 0 && this.VecEffEnd.size() < this.numEffReplace && this.f < 50)
			{
				Point point9 = new Point();
				point9.x = this.x * 1000;
				point9.y = this.y * 1000;
				point9.vx = CRes.cos(CRes.fixangle(this.gocT_Arc)) * 4;
				point9.vy = CRes.sin(CRes.fixangle(this.gocT_Arc)) * 4;
				point9.x2 = this.toX * 1000;
				point9.y2 = this.toY * 1000;
				this.gocT_Arc += this.plusGoc;
				this.VecEffEnd.addElement(point9);
				if (this.VecEffEnd.size() == this.numEffReplace)
				{
					this.f = 50;
				}
			}
			if (this.f == 80)
			{
				for (int num2 = 0; num2 < this.VecEffEnd.size(); num2++)
				{
					Point point10 = (Point)this.VecEffEnd.elementAt(num2);
					point10.vx = (point10.x2 - point10.x) / 8;
					point10.vy = (point10.y2 - point10.y) / 8;
					point10.f = 100;
				}
			}
			for (int num3 = 0; num3 < this.VecEffEnd.size(); num3++)
			{
				Point point11 = (Point)this.VecEffEnd.elementAt(num3);
				point11.update();
				if (point11.f % 3 == 0)
				{
					Point point12 = new Point();
					point12.x = point11.x / 1000 + CRes.random_Am(5, 12);
					point12.y = point11.y / 1000 + CRes.random_Am(5, 12);
					this.VecSubEffEnd.addElement(point12);
				}
				if (point11.f == 10)
				{
					point11.vx = 0;
					point11.vy = 0;
				}
				if (point11.f > 108)
				{
					this.VecEffEnd.removeElement(point11);
					num3--;
				}
			}
			for (int num4 = 0; num4 < this.VecSubEffEnd.size(); num4++)
			{
				Point point13 = (Point)this.VecSubEffEnd.elementAt(num4);
				point13.f++;
				if (point13.f / 2 >= 4)
				{
					this.VecSubEffEnd.removeElement(point13);
					num4--;
				}
			}
			if (this.f > 80 && this.VecEffEnd.size() == 0)
			{
				TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.toX, this.toY - 11);
				TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.toX, this.toY);
				TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.toX, this.toY);
				this.removeEff();
			}
			break;
		case 38:
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 39:
			if (CRes.random(2) == 0)
			{
				GameScreen.addEffectKill(83, this.x, this.y, 400, -1, 0);
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 41:
			if (this.f == 1)
			{
				Point point14 = new Point();
				point14.x = this.x * 1000;
				point14.y = this.y * 1000;
				point14.x2 = this.toX * 1000;
				point14.y2 = this.toY * 1000;
				point14.vx = 0;
				point14.vy = 0;
				this.VecEffEnd.addElement(point14);
			}
			for (int num5 = 0; num5 < this.VecEffEnd.size(); num5++)
			{
				Point point15 = (Point)this.VecEffEnd.elementAt(num5);
				point15.update();
				if (point15.f == 4)
				{
					point15.vx = (point15.x2 - point15.x) / 12;
					point15.vy = (point15.y2 - point15.y) / 12;
				}
				if (point15.f % 3 == 0)
				{
					Point point16 = new Point();
					point16.x = point15.x / 1000 + CRes.random_Am(5, 12);
					point16.y = point15.y / 1000 + CRes.random_Am(5, 12);
					this.VecSubEffEnd.addElement(point16);
				}
				if (point15.f == 16)
				{
					point15.vx = 0;
					point15.vy = 0;
					this.VecEffEnd.removeElement(point15);
					num5--;
				}
			}
			for (int num6 = 0; num6 < this.VecSubEffEnd.size(); num6++)
			{
				Point point17 = (Point)this.VecSubEffEnd.elementAt(num6);
				point17.f++;
				if (point17.f / 2 >= 4)
				{
					this.VecSubEffEnd.removeElement(point17);
					num6--;
				}
			}
			if (this.f >= this.fRemove && this.VecSubEffEnd.size() == 0 && this.VecEffEnd.size() == 0)
			{
				this.removeEff();
			}
			break;
		case 42:
			for (int num7 = 0; num7 < this.VecEffEnd.size(); num7++)
			{
				Point point18 = (Point)this.VecEffEnd.elementAt(num7);
				point18.update();
				if (point18.f % 3 == 0)
				{
					Point point19 = new Point();
					point19.x = point18.x / 1000 + CRes.random_Am(5, 12);
					point19.y = point18.y / 1000 + CRes.random_Am(5, 12);
					this.VecSubEffEnd.addElement(point19);
				}
				if (point18.f == this.fRemove)
				{
					point18.vx = 0;
					point18.vy = 0;
					this.VecEffEnd.removeElement(point18);
					num7--;
				}
			}
			for (int num8 = 0; num8 < this.VecSubEffEnd.size(); num8++)
			{
				Point point20 = (Point)this.VecSubEffEnd.elementAt(num8);
				point20.f++;
				if (point20.f / 2 >= 4)
				{
					this.VecSubEffEnd.removeElement(point20);
					num8--;
				}
			}
			if (this.f >= this.fRemove && this.VecEffEnd.size() == 0 && this.VecSubEffEnd.size() == 0)
			{
				this.removeEff();
			}
			break;
		case 43:
			if (this.f == 1)
			{
				GameScreen.addEffectEndKill(14, this.x, this.y);
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 45:
			if (this.f == 1)
			{
				GameScreen.addEffectEndKill(9, this.x, this.y + 20);
				GameScreen.addEffectEndKill(46, this.x, this.y + 20);
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 47:
		case 50:
			if (this.timeRemove - mSystem.currentTimeMillis() < 0L)
			{
				this.removeEff();
			}
			break;
		case 48:
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 49:
			if (this.effAuto != null)
			{
				this.effAuto.update();
			}
			if (this.timeRemove - mSystem.currentTimeMillis() < 0L)
			{
				this.removeEff();
				GameScreen.addEffectEndKill(15, this.x, this.y);
			}
			break;
		case 55:
			if (this.f < 0)
			{
				this.f = 0;
			}
			if (this.Direction == 2)
			{
				this.trans = 0;
			}
			else if (this.Direction == 3)
			{
				this.trans = 2;
			}
			if (this.Direction == 1)
			{
				this.trans = 3;
			}
			if (this.Direction == 0)
			{
				this.trans = 0;
			}
			if (this.f > this.nFrame.Length - 1)
			{
				this.f = 0;
				this.removeEff();
			}
			break;
		case 56:
			if (this.Direction == 2)
			{
				this.trans = 4;
			}
			else if (this.Direction == 3)
			{
				this.trans = 7;
			}
			if (this.Direction == 1)
			{
				this.trans = 0;
			}
			if (this.Direction == 0)
			{
				this.trans = 3;
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		case 58:
			if (this.Direction == 2)
			{
				this.trans = 4;
			}
			else if (this.Direction == 3)
			{
				this.trans = 7;
			}
			if (this.Direction == 1)
			{
				this.trans = 0;
			}
			if (this.Direction == 0)
			{
				this.trans = 3;
			}
			if (this.f >= this.fRemove)
			{
				this.removeEff();
			}
			break;
		}
	}

	// Token: 0x0600026B RID: 619 RVA: 0x000129CC File Offset: 0x00010BCC
	public void removeEff()
	{
		this.isStop = true;
		this.isRemove = true;
	}

	// Token: 0x0600026C RID: 620 RVA: 0x000129DC File Offset: 0x00010BDC
	private void create_Arc_Big_Small()
	{
		this.fraImgEff = new FrameImage(7);
		this.fraImgSubEff = new FrameImage(2);
		this.x1000 = this.x * 1000;
		this.y1000 = this.y * 1000;
		this.fRemove = 15;
		this.lT_Arc = MainObject.getDistance(this.toX, this.toY, this.x, this.y);
		this.gocT_Arc = CRes.angle(this.x - this.toX, this.y - this.toY);
		this.pRebuild = new Point(this.toX * 1000, this.toY * 1000);
		this.pRebuild.x2 = this.toX * 1000;
		this.pRebuild.y2 = this.toY * 1000;
		this.pRebuild.f = this.gocT_Arc;
		this.pRebuild.vy = CRes.sin(CRes.fixangle(this.pRebuild.f % 360)) * this.lT_Arc;
		this.pRebuild.vx = CRes.cos(CRes.fixangle(this.pRebuild.f % 360)) * this.lT_Arc;
		this.pRebuild.v = 0;
	}

	// Token: 0x0600026D RID: 621 RVA: 0x00012B40 File Offset: 0x00010D40
	private void create_Level_up()
	{
		this.fraImgSubEff = new FrameImage(67);
		this.fRemove = 23;
	}

	// Token: 0x0600026E RID: 622 RVA: 0x00012B58 File Offset: 0x00010D58
	public void fRemove_Low(int t)
	{
		if (GameCanvas.lowGraphic)
		{
			this.fRemove = CRes.random(t - 4, t + 5);
		}
	}

	// Token: 0x0400023F RID: 575
	public const sbyte END_NUC_DAT = 0;

	// Token: 0x04000240 RID: 576
	public const sbyte END_EFF_WATER_BIG = 1;

	// Token: 0x04000241 RID: 577
	public const sbyte END_FAR_NEAR = 2;

	// Token: 0x04000242 RID: 578
	public const sbyte END_THIEN_THACH = 3;

	// Token: 0x04000243 RID: 579
	public const sbyte END_KILL_PS_LV2 = 4;

	// Token: 0x04000244 RID: 580
	public const sbyte END_KILL_2KIEM_LV2 = 5;

	// Token: 0x04000245 RID: 581
	public const sbyte END_KILL_2KIEM_LV2_BEGIN = 6;

	// Token: 0x04000246 RID: 582
	public const sbyte END_KILL_SUNG_LV1 = 7;

	// Token: 0x04000247 RID: 583
	public const sbyte END_ROCK = 9;

	// Token: 0x04000248 RID: 584
	public const sbyte END_KILL_PS_LV1 = 10;

	// Token: 0x04000249 RID: 585
	public const sbyte END_DIE_MONSTER = 11;

	// Token: 0x0400024A RID: 586
	public const sbyte END_KILL_SUNG_LV2 = 12;

	// Token: 0x0400024B RID: 587
	public const sbyte END_KILL_SUNG_LV2_BEGIN = 13;

	// Token: 0x0400024C RID: 588
	public const sbyte END_PHAO_HOA = 14;

	// Token: 0x0400024D RID: 589
	public const sbyte END_PHAO_BANG = 15;

	// Token: 0x0400024E RID: 590
	public const sbyte END_WATER_ROCK = 19;

	// Token: 0x0400024F RID: 591
	public const sbyte END_EFF_LV_UP = 21;

	// Token: 0x04000250 RID: 592
	public const sbyte END_EFF_2KIEM_DOC = 24;

	// Token: 0x04000251 RID: 593
	public const sbyte END_EFF_KIEM_LV6 = 25;

	// Token: 0x04000252 RID: 594
	public const sbyte END_KIEM_NUC_DAT_2 = 26;

	// Token: 0x04000253 RID: 595
	public const sbyte END_ICE_BIG = 27;

	// Token: 0x04000254 RID: 596
	public const sbyte END_ICE_UP = 28;

	// Token: 0x04000255 RID: 597
	public const sbyte END_XUYEN_GIAP = 29;

	// Token: 0x04000256 RID: 598
	public const sbyte END_ROCK_FIRE_BIG = 30;

	// Token: 0x04000257 RID: 599
	public const sbyte END_REBUILD = 31;

	// Token: 0x04000258 RID: 600
	public const sbyte END_LEVEL_UP_REBUILD = 32;

	// Token: 0x04000259 RID: 601
	public const sbyte END_EFF_LV_UP_REBUILD = 33;

	// Token: 0x0400025A RID: 602
	public const sbyte END_EFF_FINISH_REBUILD = 34;

	// Token: 0x0400025B RID: 603
	public const sbyte END_EFF_REMOVE_OBJ = 35;

	// Token: 0x0400025C RID: 604
	public const sbyte END_EFF_REMOVE_MON_PHO_BANG = 36;

	// Token: 0x0400025D RID: 605
	public const sbyte END_REPLACE_PLUS = 37;

	// Token: 0x0400025E RID: 606
	public const sbyte END_NHANBAN_REVEICE = 38;

	// Token: 0x0400025F RID: 607
	public const sbyte END_HUT_HP_MON_PHO_BANG = 39;

	// Token: 0x04000260 RID: 608
	public const sbyte END_EFF_NAM_DAT = 40;

	// Token: 0x04000261 RID: 609
	public const sbyte END_EFF_A_DEN_B = 41;

	// Token: 0x04000262 RID: 610
	public const sbyte END_EFF_OPEN_BOX = 42;

	// Token: 0x04000263 RID: 611
	public const sbyte END_EFF_DETONATE = 43;

	// Token: 0x04000264 RID: 612
	public const sbyte END_EFF_POISON_NOVA = 44;

	// Token: 0x04000265 RID: 613
	public const sbyte END_EFF_TORNADO = 45;

	// Token: 0x04000266 RID: 614
	public const sbyte END_EFF_CAY_DAT = 46;

	// Token: 0x04000267 RID: 615
	public const sbyte END_EFF_NUT_DAT_BIND = 47;

	// Token: 0x04000268 RID: 616
	public const sbyte END_EFF_Medusa_ATK = 48;

	// Token: 0x04000269 RID: 617
	public const sbyte END_EFF_DONG_BANG = 49;

	// Token: 0x0400026A RID: 618
	public const sbyte END_EFF_Medusa_VongTron = 50;

	// Token: 0x0400026B RID: 619
	public const sbyte END_PET_BAT = 51;

	// Token: 0x0400026C RID: 620
	public const sbyte END_PET_EAGLE = 52;

	// Token: 0x0400026D RID: 621
	public const sbyte END_PET_OWL = 53;

	// Token: 0x0400026E RID: 622
	public const sbyte END_EFF_MOVE_BOSS = 54;

	// Token: 0x0400026F RID: 623
	public const sbyte END_MOUNT_DUST = 55;

	// Token: 0x04000270 RID: 624
	public const sbyte END_FOOT_SNOW = 56;

	// Token: 0x04000271 RID: 625
	public const sbyte END_ENY = 57;

	// Token: 0x04000272 RID: 626
	public const sbyte END_MO_TO = 58;

	// Token: 0x04000273 RID: 627
	private mVector VecEffEnd = new mVector("EffectEnd VecEffEnd");

	// Token: 0x04000274 RID: 628
	private mVector VecSubEffEnd = new mVector("EffectEnd VecSubEffEnd");

	// Token: 0x04000275 RID: 629
	private int x1000;

	// Token: 0x04000276 RID: 630
	private int y1000;

	// Token: 0x04000277 RID: 631
	private int lT_Arc;

	// Token: 0x04000278 RID: 632
	private int gocT_Arc;

	// Token: 0x04000279 RID: 633
	private Point pRebuild;

	// Token: 0x0400027A RID: 634
	public new sbyte[] nFrame;

	// Token: 0x0400027B RID: 635
	private int trans;

	// Token: 0x0400027C RID: 636
	public new long timeRemove;

	// Token: 0x0400027D RID: 637
	public int timeDeley = 2000;

	// Token: 0x0400027E RID: 638
	public EffectAuto effAuto;

	// Token: 0x0400027F RID: 639
	private sbyte typeSub;

	// Token: 0x04000280 RID: 640
	private int numEffReplace;

	// Token: 0x04000281 RID: 641
	private int plusGoc;
}
