using System;

// Token: 0x02000046 RID: 70
public class FrameEff
{
	// Token: 0x0600031E RID: 798 RVA: 0x0002B188 File Offset: 0x00029388
	public FrameEff(mVector list)
	{
		this.listPart = list;
	}

	// Token: 0x0600031F RID: 799 RVA: 0x0002B1C4 File Offset: 0x000293C4
	public FrameEff(mVector listtop, mVector listbottom)
	{
		this.listPartTop = listtop;
		this.listPartBottom = listbottom;
	}

	// Token: 0x04000402 RID: 1026
	public mVector listPart = new mVector();

	// Token: 0x04000403 RID: 1027
	public mVector listPartTop = new mVector();

	// Token: 0x04000404 RID: 1028
	public mVector listPartBottom = new mVector();

	// Token: 0x04000405 RID: 1029
	public sbyte xShadow;

	// Token: 0x04000406 RID: 1030
	public int yShadow;
}
