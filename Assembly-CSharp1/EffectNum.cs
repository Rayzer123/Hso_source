using System;

// Token: 0x02000036 RID: 54
public class EffectNum : MainEffect
{
	// Token: 0x06000276 RID: 630 RVA: 0x00013110 File Offset: 0x00011310
	public EffectNum(string strContent, int x, int y, int typeColor)
	{
		this.isGravity = false;
		this.strContent = strContent;
		this.x = x;
		this.y = y + CRes.random_Am_0(5);
		this.typeNum = typeColor;
		this.fontPaint = mFont.tahoma_7b_white;
		if (this.typeNum < 0)
		{
			this.fontPaint = MainTabNew.setTextColorName(-typeColor);
		}
		else
		{
			switch (typeColor)
			{
			case 1:
				this.fontPaint = mFont.tahoma_7_green;
				break;
			case 2:
			case 6:
			case 7:
			case 9:
				this.isGravity = true;
				break;
			case 5:
				this.fontPaint = mFont.tahoma_7_white;
				break;
			case 8:
				this.fontPaint = MainTabNew.setTextColor(typeColor);
				break;
			case 10:
				this.fontPaint = mFont.tahoma_7b_yellow;
				break;
			case 11:
				this.fontPaint = mFont.tahoma_7b_violet;
				break;
			}
		}
		if (this.isGravity)
		{
			this.vy = -CRes.random(11, 14);
			this.fRemove = CRes.random(20, 25);
		}
		else
		{
			this.vy = -CRes.random(2, 4);
			this.fRemove = CRes.random(24, 32);
		}
	}

	// Token: 0x06000277 RID: 631 RVA: 0x00013268 File Offset: 0x00011468
	public EffectNum(string strContent, int x, int y, int typeColor, int sub)
	{
		this.strContent = strContent;
		this.x = x;
		this.y = y + CRes.random_Am_0(5);
		this.typeNum = typeColor;
		this.fontPaint = mFont.tahoma_7b_white;
		this.vy = -CRes.random(11, 14);
		this.isGravity = true;
		this.fRemove = CRes.random(20, 25);
		if (this.typeNum < 0)
		{
			this.fontPaint = MainTabNew.setTextColorName(-sub);
		}
		else if (typeColor == 8)
		{
			this.fontPaint = MainTabNew.setTextColor(sub);
		}
	}

	// Token: 0x06000278 RID: 632 RVA: 0x00013310 File Offset: 0x00011510
	public override void paint(mGraphics g)
	{
		switch (this.typeNum)
		{
		case 1:
		case 5:
			this.fontPaint.drawString(g, this.strContent, this.x, this.y, 2, mGraphics.isFalse);
			return;
		case 2:
			AvMain.Font3dWhite(g, this.strContent, this.x, this.y, 2);
			return;
		case 3:
			AvMain.Font3dColor(g, this.strContent, this.x, this.y, 2, 5);
			return;
		case 4:
			AvMain.Font3dColor(g, this.strContent, this.x, this.y, 2, 1);
			return;
		case 6:
			AvMain.Font3dColor(g, this.strContent, this.x, this.y, 2, 4);
			return;
		case 7:
			AvMain.Font3dColor(g, this.strContent, this.x, this.y, 2, 2);
			return;
		case 9:
			AvMain.Font3dColor(g, this.strContent, this.x, this.y, 2, 6);
			return;
		}
		this.fontPaint.drawString(g, this.strContent, this.x, this.y, 2, mGraphics.isFalse);
	}

	// Token: 0x06000279 RID: 633 RVA: 0x00013460 File Offset: 0x00011660
	public override void update()
	{
		this.f++;
		if (this.isGravity)
		{
			this.vy++;
		}
		base.update();
		if (this.f >= this.fRemove)
		{
			this.isStop = true;
		}
	}

	// Token: 0x0400029E RID: 670
	public const sbyte COLOR_NORMAL = 0;

	// Token: 0x0400029F RID: 671
	public const sbyte COLOR_XP = 1;

	// Token: 0x040002A0 RID: 672
	public const sbyte COLOR_FIRE = 2;

	// Token: 0x040002A1 RID: 673
	public const sbyte COLOR_PLUS_HP = 3;

	// Token: 0x040002A2 RID: 674
	public const sbyte COLOR_PLUS_MP = 4;

	// Token: 0x040002A3 RID: 675
	public const sbyte COLOR_PUT_ITEM = 5;

	// Token: 0x040002A4 RID: 676
	public const sbyte COLOR_FIRE_PERSON = 6;

	// Token: 0x040002A5 RID: 677
	public const sbyte COLOR_EFF_CRI = 7;

	// Token: 0x040002A6 RID: 678
	public const sbyte COLOR_OPTION = 8;

	// Token: 0x040002A7 RID: 679
	public const sbyte COLOR_EFF_MON_FIRE = 9;

	// Token: 0x040002A8 RID: 680
	public const sbyte COLOR_DAME_LIGHT = 10;

	// Token: 0x040002A9 RID: 681
	public const sbyte COLOR_DAME_DRAK = 11;

	// Token: 0x040002AA RID: 682
	private string strContent;

	// Token: 0x040002AB RID: 683
	private int typeNum;

	// Token: 0x040002AC RID: 684
	private new int fRemove;

	// Token: 0x040002AD RID: 685
	private mFont fontPaint;

	// Token: 0x040002AE RID: 686
	private bool isGravity;
}
