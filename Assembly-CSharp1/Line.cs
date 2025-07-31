using System;

// Token: 0x020000BB RID: 187
public class Line
{
	// Token: 0x06000954 RID: 2388 RVA: 0x00097588 File Offset: 0x00095788
	public void setLine(int x0, int y0, int x1, int y1, int vx, int vy, bool is2Line)
	{
		this.x0 = x0;
		this.y0 = y0;
		this.x1 = x1;
		this.y1 = y1;
		this.vx = vx;
		this.vy = vy;
		this.is2Line = is2Line;
	}

	// Token: 0x06000955 RID: 2389 RVA: 0x000975C0 File Offset: 0x000957C0
	public void update()
	{
		this.x0 += this.vx;
		this.x1 += this.vx;
		this.y0 += this.vy;
		this.y1 += this.vy;
		this.f++;
	}

	// Token: 0x04000E31 RID: 3633
	public int x0;

	// Token: 0x04000E32 RID: 3634
	public int y0;

	// Token: 0x04000E33 RID: 3635
	public int x1;

	// Token: 0x04000E34 RID: 3636
	public int y1;

	// Token: 0x04000E35 RID: 3637
	public int vx;

	// Token: 0x04000E36 RID: 3638
	public int vy;

	// Token: 0x04000E37 RID: 3639
	public int f;

	// Token: 0x04000E38 RID: 3640
	public int fRe;

	// Token: 0x04000E39 RID: 3641
	public int idColor;

	// Token: 0x04000E3A RID: 3642
	public int Rec_h;

	// Token: 0x04000E3B RID: 3643
	public bool is2Line;
}
