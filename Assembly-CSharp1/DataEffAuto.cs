using System;

// Token: 0x02000031 RID: 49
public class DataEffAuto
{
	// Token: 0x06000248 RID: 584 RVA: 0x0000E3F8 File Offset: 0x0000C5F8
	public DataEffAuto(int id)
	{
		this.id = (short)id;
	}

	// Token: 0x06000249 RID: 585 RVA: 0x0000E408 File Offset: 0x0000C608
	public void setdata(sbyte[] mdata)
	{
		this.data = mdata;
	}

	// Token: 0x04000214 RID: 532
	public sbyte[] data;

	// Token: 0x04000215 RID: 533
	public short id;

	// Token: 0x04000216 RID: 534
	public long timeremove;
}
