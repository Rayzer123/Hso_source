using System;

// Token: 0x02000033 RID: 51
public class EffectCharWearing
{
	// Token: 0x0600025F RID: 607 RVA: 0x0000F9C8 File Offset: 0x0000DBC8
	public EffectCharWearing(sbyte type, int idimage)
	{
		this.type = type;
		this.idImage = idimage;
		this.timepaint = mSystem.currentTimeMillis();
		switch (this.type)
		{
		case 0:
			this.dx = 5;
			this.dy = -25;
			this.timerepaint = 1;
			break;
		case 1:
			this.dx = 0;
			this.dy = -12;
			this.timerepaint = 2;
			break;
		case 2:
			this.dx = 5;
			this.dy = 0;
			this.timerepaint = 3;
			break;
		}
	}

	// Token: 0x06000261 RID: 609 RVA: 0x0000FAC0 File Offset: 0x0000DCC0
	public void paint(mGraphics g, int x, int y)
	{
		mImage mImage = ImageEffect.setImage(this.idImage);
		if (mImage != null && mImage.image != null)
		{
			if (this.frameWidth == 0 || this.frameHeight == 0)
			{
				this.frameWidth = (int)EffectSkill.arrInfoEff[this.idImage][0];
				this.frameHeight = (int)EffectSkill.arrInfoEff[this.idImage][1];
			}
			if (this.timepaint - mSystem.currentTimeMillis() < 0L)
			{
				switch (this.type)
				{
				case 0:
					if (this.pospaint == 0)
					{
						g.drawRegion(mImage, 0, (int)this.FrameEffect * this.frameHeight, this.frameWidth, this.frameHeight, 0, x + this.dx, y + this.dy, 3, false);
					}
					else
					{
						g.drawRegion(mImage, 0, (int)this.FrameEffect1 * this.frameHeight, this.frameWidth, this.frameHeight, 0, x - this.dx, y + this.dy, 3, false);
					}
					break;
				case 1:
					g.drawRegion(mImage, 0, (int)this.FrameEffect * this.frameHeight, this.frameWidth, this.frameHeight, 0, x + this.dx, y + this.dy, 3, false);
					break;
				case 2:
					g.drawRegion(mImage, 0, (int)this.FrameEffect * this.frameHeight, this.frameWidth, this.frameHeight, 0, x + this.dx, y + this.dy, 3, false);
					g.drawRegion(mImage, 0, (int)this.FrameEffect1 * this.frameHeight, this.frameWidth, this.frameHeight, 0, x - this.dx, y + this.dy, 3, false);
					break;
				}
			}
		}
	}

	// Token: 0x06000262 RID: 610 RVA: 0x0000FC84 File Offset: 0x0000DE84
	public void update()
	{
		if (this.timepaint - mSystem.currentTimeMillis() < 0L)
		{
			switch (this.type)
			{
			case 0:
				if (GameCanvas.gameTick % 2 == 0)
				{
					this.f += 1;
				}
				if ((int)this.f > EffectCharWearing.Frame[(int)this.type].Length - 1)
				{
					this.f = 0;
					this.timerepaint = CRes.random(10);
					this.timepaint = (long)(this.timerepaint * 1000) + mSystem.currentTimeMillis();
					if (this.timerepaint % 2 == 0)
					{
						this.pospaint = 0;
					}
					else
					{
						this.pospaint = 1;
					}
				}
				this.FrameEffect = EffectCharWearing.Frame[(int)this.type][(int)this.f];
				if (GameCanvas.gameTick % 4 == 0)
				{
					this.f1 += 1;
				}
				if ((int)this.f1 > EffectCharWearing.Frame[(int)this.type].Length - 1)
				{
					this.f1 = 0;
				}
				this.FrameEffect1 = EffectCharWearing.Frame[(int)this.type][(int)this.f1];
				break;
			case 1:
				this.f += 1;
				if ((int)this.f > EffectCharWearing.Frame[(int)this.type].Length - 1)
				{
					this.f = 0;
					this.timerepaint = CRes.random(10);
					this.timepaint = (long)(this.timerepaint * 1000) + mSystem.currentTimeMillis();
				}
				this.FrameEffect = EffectCharWearing.Frame[(int)this.type][(int)this.f];
				break;
			case 2:
				if (GameCanvas.gameTick % 2 == 0)
				{
					this.f += 1;
				}
				if ((int)this.f > EffectCharWearing.Frame[(int)this.type].Length - 1)
				{
					this.f = 0;
					this.timerepaint = CRes.random(10);
					this.timepaint = (long)(this.timerepaint * 1000) + mSystem.currentTimeMillis();
				}
				this.FrameEffect = EffectCharWearing.Frame[(int)this.type][(int)this.f];
				if (GameCanvas.gameTick % 3 == 0)
				{
					this.f1 += 1;
				}
				if ((int)this.f1 > EffectCharWearing.Frame[(int)this.type].Length - 1)
				{
					this.f1 = 0;
				}
				this.FrameEffect1 = EffectCharWearing.Frame[(int)this.type][(int)this.f1];
				break;
			}
		}
	}

	// Token: 0x0400022E RID: 558
	public const sbyte TYPE_HAT_WEARING = 0;

	// Token: 0x0400022F RID: 559
	public const sbyte TYPE_ARMOR_WEARING = 1;

	// Token: 0x04000230 RID: 560
	public const sbyte TYPE_TROUSERS_WEARING = 2;

	// Token: 0x04000231 RID: 561
	private sbyte f;

	// Token: 0x04000232 RID: 562
	private sbyte f1;

	// Token: 0x04000233 RID: 563
	private sbyte FrameEffect;

	// Token: 0x04000234 RID: 564
	private sbyte FrameEffect1;

	// Token: 0x04000235 RID: 565
	public int idImage;

	// Token: 0x04000236 RID: 566
	public sbyte type;

	// Token: 0x04000237 RID: 567
	private int frameWidth;

	// Token: 0x04000238 RID: 568
	private int frameHeight;

	// Token: 0x04000239 RID: 569
	private long timepaint;

	// Token: 0x0400023A RID: 570
	private int timerepaint;

	// Token: 0x0400023B RID: 571
	private int dx;

	// Token: 0x0400023C RID: 572
	private int dy;

	// Token: 0x0400023D RID: 573
	public static sbyte[][] Frame = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			1,
			2,
			3,
			4,
			3,
			2,
			1,
			0,
			1,
			2,
			3,
			4,
			3,
			2,
			1,
			0,
			1,
			2,
			3,
			4,
			3,
			2,
			1,
			0,
			1,
			2,
			3,
			4
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
			3,
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
			1,
			1,
			2,
			2,
			1,
			3,
			3,
			3,
			0,
			0,
			1,
			1,
			2,
			2,
			1,
			3,
			3,
			3
		}
	};

	// Token: 0x0400023E RID: 574
	private int pospaint;
}
