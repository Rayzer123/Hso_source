using System;

// Token: 0x0200003D RID: 61
public class Arrow : IArrow
{
	// Token: 0x060002D6 RID: 726 RVA: 0x00026C0C File Offset: 0x00024E0C
	public Arrow(int imgIndex)
	{
	}

	// Token: 0x060002D7 RID: 727 RVA: 0x00026C1C File Offset: 0x00024E1C
	public Arrow()
	{
	}

	// Token: 0x060002D9 RID: 729 RVA: 0x00026C80 File Offset: 0x00024E80
	public override void setAngle(int angle)
	{
	}

	// Token: 0x060002DA RID: 730 RVA: 0x00026C84 File Offset: 0x00024E84
	public override void onArrowTouchTarget()
	{
		this.wantDestroy = true;
	}

	// Token: 0x060002DB RID: 731 RVA: 0x00026C90 File Offset: 0x00024E90
	public override void paint(mGraphics g)
	{
		if (this.img != null)
		{
			this.img.drawFrameEffectSkill(this.frame, this.xw[this.pos], this.yw[this.pos], this.transform, 3, g);
		}
	}

	// Token: 0x060002DC RID: 732 RVA: 0x00026CDC File Offset: 0x00024EDC
	public override void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
	}

	// Token: 0x060002DD RID: 733 RVA: 0x00026CE0 File Offset: 0x00024EE0
	public void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target, int idend)
	{
		this.effect = idend;
		this.effect = (int)effect;
		this.target = target;
		this.power = power;
		int num = target.x - x;
		int num2 = target.y + target.getDy() - y;
		if (type == 7)
		{
			num = target.x + 10 - x;
			num2 = target.y + target.getDy() - y;
		}
		else if (type == 8)
		{
			num = target.x - 10 - x;
			num2 = target.y - 10 + target.getDy() - y;
		}
		int num3 = (global::Math.abs(num) + global::Math.abs(num2)) / 20;
		if (num3 < 2)
		{
			num3 = 2;
		}
		this.xw = new int[num3];
		this.yw = new int[num3];
		for (int i = 1; i < num3; i++)
		{
			this.xw[i] = x + i * num / num3;
			this.yw[i] = y + i * num2 / num3;
		}
		int num4 = Arrow.findDirIndexFromAngle(CRes.angle(num, -num2));
		this.frame = (int)Arrow.FRAME[num4];
		this.transform = Arrow.TRANSFORM[num4];
	}

	// Token: 0x060002DE RID: 734 RVA: 0x00026E10 File Offset: 0x00025010
	public static int findDirIndexFromAngle(int angle)
	{
		int i = 0;
		while (i < Arrow.ARROWINDEX.Length - 1)
		{
			if (angle >= Arrow.ARROWINDEX[i] && angle <= Arrow.ARROWINDEX[i + 1])
			{
				if (i >= 16)
				{
					return 0;
				}
				return i;
			}
			else
			{
				i++;
			}
		}
		return 0;
	}

	// Token: 0x060002DF RID: 735 RVA: 0x00026E60 File Offset: 0x00025060
	public override void update()
	{
		this.pos++;
		if (this.pos >= this.xw.Length)
		{
			this.pos = this.xw.Length;
		}
		if (this.pos == this.xw.Length)
		{
			this.onArrowTouchTarget();
			return;
		}
	}

	// Token: 0x060002E0 RID: 736 RVA: 0x00026EB8 File Offset: 0x000250B8
	public override void SetEffFollow(int id)
	{
	}

	// Token: 0x0400039D RID: 925
	public static int[] ARROWINDEX = new int[]
	{
		0,
		15,
		37,
		52,
		75,
		105,
		127,
		142,
		165,
		195,
		217,
		232,
		255,
		285,
		307,
		322,
		345,
		370
	};

	// Token: 0x0400039E RID: 926
	public int power;

	// Token: 0x0400039F RID: 927
	public int effect;

	// Token: 0x040003A0 RID: 928
	public int typeEffEnd = -1;

	// Token: 0x040003A1 RID: 929
	private MainObject target;

	// Token: 0x040003A2 RID: 930
	private int[] xw;

	// Token: 0x040003A3 RID: 931
	private int[] yw;

	// Token: 0x040003A4 RID: 932
	private int frame;

	// Token: 0x040003A5 RID: 933
	private int transform;

	// Token: 0x040003A6 RID: 934
	private int pos;

	// Token: 0x040003A7 RID: 935
	private FrameImage img;

	// Token: 0x040003A8 RID: 936
	public static int[] TRANSFORM = new int[]
	{
		0,
		0,
		0,
		7,
		6,
		6,
		6,
		2,
		2,
		3,
		3,
		4,
		5,
		5,
		5,
		1
	};

	// Token: 0x040003A9 RID: 937
	public static sbyte[] FRAME = new sbyte[]
	{
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0,
		1,
		2,
		1,
		0
	};

	// Token: 0x040003AA RID: 938
	private short endeff;
}
