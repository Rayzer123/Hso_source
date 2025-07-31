using System;

// Token: 0x02000045 RID: 69
public class EffectData
{
	// Token: 0x0600031B RID: 795 RVA: 0x0002B164 File Offset: 0x00029364
	public EffectData()
	{
	}

	// Token: 0x0600031C RID: 796 RVA: 0x0002B16C File Offset: 0x0002936C
	public EffectData(short idImg)
	{
		this.id = idImg;
	}

	// Token: 0x0600031D RID: 797 RVA: 0x0002B17C File Offset: 0x0002937C
	public void setdata(sbyte[] data)
	{
		this.data = data;
	}

	// Token: 0x040003FF RID: 1023
	public sbyte[] data;

	// Token: 0x04000400 RID: 1024
	public long timeRemove;

	// Token: 0x04000401 RID: 1025
	public short id;
}
