using System;

// Token: 0x02000076 RID: 118
public class TimecountDown
{
	// Token: 0x06000585 RID: 1413 RVA: 0x0004FB44 File Offset: 0x0004DD44
	public TimecountDown(int second, string tile, int x, int y)
	{
		this.mysecond = (short)second;
		this.tile = tile;
		this.x = x;
		this.y = y;
		this.currT = mSystem.currentTimeMillis();
		this.lastT = mSystem.currentTimeMillis();
	}

	// Token: 0x06000586 RID: 1414 RVA: 0x0004FB8C File Offset: 0x0004DD8C
	public void paint(mGraphics g)
	{
		g.drawImage(AvMain.imgBackInfo, this.x, this.y + GameCanvas.hText / 2, 3, mGraphics.isFalse);
		mFont.tahoma_7b_white.drawString(g, this.tile + " : " + LoadMap.converSecon2hours((int)this.mysecond), this.x, this.y, 2, mGraphics.isFalse);
	}

	// Token: 0x06000587 RID: 1415 RVA: 0x0004FBF8 File Offset: 0x0004DDF8
	public void update()
	{
		this.currT = mSystem.currentTimeMillis();
		if (this.currT - this.lastT >= 1000L)
		{
			this.lastT = mSystem.currentTimeMillis();
			this.mysecond -= 1;
		}
		if (this.mysecond <= 0)
		{
			this.wantdestroy = true;
		}
	}

	// Token: 0x040007C2 RID: 1986
	private short mysecond;

	// Token: 0x040007C3 RID: 1987
	private string tile;

	// Token: 0x040007C4 RID: 1988
	private long currT;

	// Token: 0x040007C5 RID: 1989
	private long lastT;

	// Token: 0x040007C6 RID: 1990
	public bool wantdestroy;

	// Token: 0x040007C7 RID: 1991
	private int x;

	// Token: 0x040007C8 RID: 1992
	private int y;
}
