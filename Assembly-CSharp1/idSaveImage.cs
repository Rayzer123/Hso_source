using System;

// Token: 0x02000079 RID: 121
public class idSaveImage
{
	// Token: 0x0600058A RID: 1418 RVA: 0x0004FCE0 File Offset: 0x0004DEE0
	public idSaveImage(short id, sbyte[] mbyte)
	{
		this.id = id;
		this.mbytImage = mbyte;
	}

	// Token: 0x040007D4 RID: 2004
	public short id;

	// Token: 0x040007D5 RID: 2005
	public sbyte[] mbytImage;
}
