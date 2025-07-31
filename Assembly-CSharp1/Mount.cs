using System;

// Token: 0x02000062 RID: 98
public class Mount : MainObject
{
	// Token: 0x060004C1 RID: 1217 RVA: 0x000432A4 File Offset: 0x000414A4
	public Mount(sbyte type, sbyte dir, int x, int y)
	{
		this.typeMount = type;
		this.x = x;
		this.y = y;
		this.Direction = (int)dir;
		this.Action = 0;
		this.typeObject = 10;
	}

	// Token: 0x060004C3 RID: 1219 RVA: 0x00043348 File Offset: 0x00041548
	public new void updateMount()
	{
		this.frameMount += 1;
		if ((int)this.frameMount > Mount.Dir[this.Direction].Length - 1)
		{
			this.frameMount = 0;
		}
	}

	// Token: 0x060004C4 RID: 1220 RVA: 0x00043388 File Offset: 0x00041588
	public override void paint(mGraphics g)
	{
		if ((int)this.typeMount == -1)
		{
			return;
		}
		FrameImage frameImageMount = FrameImage.getFrameImageMount((short)this.typeMount, 3, 5, 0);
		if (frameImageMount != null)
		{
			g.drawImage(MainObject.shadow, this.x, this.y - 8, 3, mGraphics.isFalse);
			frameImageMount.drawFrameNew((int)Mount.Dir[this.Direction][(int)this.frameMount], this.x + this.xMount, this.y - this.ysai - this.dy + this.yMount, (this.Direction <= 2) ? 0 : 2, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x040006B2 RID: 1714
	public static sbyte[][] Dir = new sbyte[][]
	{
		new sbyte[]
		{
			5,
			5,
			5,
			5,
			5,
			5,
			6,
			6,
			6,
			6,
			6,
			6
		},
		new sbyte[]
		{
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
		},
		new sbyte[]
		{
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
		},
		new sbyte[]
		{
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
		}
	};
}
