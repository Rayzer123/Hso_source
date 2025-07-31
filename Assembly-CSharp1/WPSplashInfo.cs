using System;

// Token: 0x02000077 RID: 119
public class WPSplashInfo
{
	// Token: 0x06000588 RID: 1416 RVA: 0x0004FC58 File Offset: 0x0004DE58
	public WPSplashInfo()
	{
		this.P0_X = mSystem.new_M_Int(4, 8);
		this.P0_Y = mSystem.new_M_Int(4, 8);
		this.PF_X = mSystem.new_M_Int(4, 8);
		this.PF_Y = mSystem.new_M_Int(4, 8);
		this.PF_W = mSystem.new_M_Int(4, 8);
		this.PF_H = mSystem.new_M_Int(4, 8);
	}

	// Token: 0x040007C9 RID: 1993
	public int[][] P0_X;

	// Token: 0x040007CA RID: 1994
	public int[][] P0_Y;

	// Token: 0x040007CB RID: 1995
	public int[][] PF_X;

	// Token: 0x040007CC RID: 1996
	public int[][] PF_Y;

	// Token: 0x040007CD RID: 1997
	public int[][] PF_W;

	// Token: 0x040007CE RID: 1998
	public int[][] PF_H;

	// Token: 0x040007CF RID: 1999
	public mImage image;
}
