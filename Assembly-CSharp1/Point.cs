using System;

// Token: 0x020000C2 RID: 194
public class Point
{
	// Token: 0x0600097F RID: 2431 RVA: 0x0009B278 File Offset: 0x00099478
	public Point()
	{
	}

	// Token: 0x06000980 RID: 2432 RVA: 0x0009B280 File Offset: 0x00099480
	public Point(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000981 RID: 2433 RVA: 0x0009B298 File Offset: 0x00099498
	public void update()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x06000982 RID: 2434 RVA: 0x0009B2DC File Offset: 0x000994DC
	public void paint(mGraphics g)
	{
		if (!this.isRemove)
		{
			int num = 0;
			if (this.isSmall && this.f >= this.fSmall)
			{
				num = 1;
			}
			Point.FraEffInMap[this.color].drawFrame(this.frame / 2 + num, this.x, this.y, this.dis, 3, g);
		}
	}

	// Token: 0x06000983 RID: 2435 RVA: 0x0009B344 File Offset: 0x00099544
	public void updateInMap()
	{
		bool flag = true;
		if (this.color == 0 && GameScreen.vecStep.size() < 10)
		{
			flag = false;
		}
		if (!flag)
		{
			return;
		}
		this.f++;
		if (this.maxframe > 1)
		{
			this.frame++;
			if (this.frame / 2 >= this.maxframe)
			{
				this.frame = 0;
			}
		}
		if (this.f >= this.fRe)
		{
			this.isRemove = true;
		}
	}

	// Token: 0x04000ECC RID: 3788
	public const sbyte DAU_CHAN = 0;

	// Token: 0x04000ECD RID: 3789
	public const sbyte DONG_NUOC = 1;

	// Token: 0x04000ECE RID: 3790
	public int x;

	// Token: 0x04000ECF RID: 3791
	public int y;

	// Token: 0x04000ED0 RID: 3792
	public int g;

	// Token: 0x04000ED1 RID: 3793
	public int v;

	// Token: 0x04000ED2 RID: 3794
	public int w;

	// Token: 0x04000ED3 RID: 3795
	public int h;

	// Token: 0x04000ED4 RID: 3796
	public int color;

	// Token: 0x04000ED5 RID: 3797
	public int limitY;

	// Token: 0x04000ED6 RID: 3798
	public int vx;

	// Token: 0x04000ED7 RID: 3799
	public int vy;

	// Token: 0x04000ED8 RID: 3800
	public int x2;

	// Token: 0x04000ED9 RID: 3801
	public int y2;

	// Token: 0x04000EDA RID: 3802
	public int dis;

	// Token: 0x04000EDB RID: 3803
	public int f;

	// Token: 0x04000EDC RID: 3804
	public int fRe;

	// Token: 0x04000EDD RID: 3805
	public int frame;

	// Token: 0x04000EDE RID: 3806
	public int maxframe;

	// Token: 0x04000EDF RID: 3807
	public int fSmall;

	// Token: 0x04000EE0 RID: 3808
	public mVector vecEffPoint;

	// Token: 0x04000EE1 RID: 3809
	public string name;

	// Token: 0x04000EE2 RID: 3810
	public bool isRemove;

	// Token: 0x04000EE3 RID: 3811
	public bool isSmall;

	// Token: 0x04000EE4 RID: 3812
	public static FrameImage[] FraEffInMap;
}
