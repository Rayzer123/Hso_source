using System;

// Token: 0x020000C3 RID: 195
public class Point_Focus
{
	// Token: 0x06000984 RID: 2436 RVA: 0x0009B3D4 File Offset: 0x000995D4
	public Point_Focus(int x, int y, int toX, int toY, int maxdis)
	{
		this.x = x;
		this.y = y;
		this.toX = toX;
		this.toY = toY;
		this.maxdis = maxdis;
	}

	// Token: 0x06000985 RID: 2437 RVA: 0x0009B404 File Offset: 0x00099604
	public Point_Focus()
	{
	}

	// Token: 0x06000986 RID: 2438 RVA: 0x0009B40C File Offset: 0x0009960C
	public void createNormal()
	{
		this.vx = CRes.random_Am(0, 5);
		this.vy = CRes.random_Am(0, 5);
	}

	// Token: 0x06000987 RID: 2439 RVA: 0x0009B428 File Offset: 0x00099628
	public bool update()
	{
		if (this.x < this.toX)
		{
			if (this.vx < 4)
			{
				this.vx++;
			}
		}
		else if (this.vx > -4)
		{
			this.vx--;
		}
		if (this.y < this.toY)
		{
			if (this.vy < 4)
			{
				this.vy++;
			}
		}
		else if (this.vy > -4)
		{
			this.vy--;
		}
		int a = this.toX - this.x;
		int a2 = this.toY - this.y;
		if (CRes.abs(a) < this.maxdis && CRes.abs(a2) < this.maxdis)
		{
			this.vx = 0;
			this.vy = 0;
			return true;
		}
		this.x += this.vx;
		this.y += this.vy;
		return false;
	}

	// Token: 0x06000988 RID: 2440 RVA: 0x0009B540 File Offset: 0x00099740
	public void update_Vx_Vy()
	{
		this.f++;
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x04000EE5 RID: 3813
	public bool isSpeedUp;

	// Token: 0x04000EE6 RID: 3814
	public int x;

	// Token: 0x04000EE7 RID: 3815
	public int y;

	// Token: 0x04000EE8 RID: 3816
	public int dis;

	// Token: 0x04000EE9 RID: 3817
	public int fRe;

	// Token: 0x04000EEA RID: 3818
	public int f;

	// Token: 0x04000EEB RID: 3819
	public int frame;

	// Token: 0x04000EEC RID: 3820
	public int vx;

	// Token: 0x04000EED RID: 3821
	public int vy;

	// Token: 0x04000EEE RID: 3822
	public int toX;

	// Token: 0x04000EEF RID: 3823
	public int toY;

	// Token: 0x04000EF0 RID: 3824
	public int maxdis;

	// Token: 0x04000EF1 RID: 3825
	private int goc;
}
