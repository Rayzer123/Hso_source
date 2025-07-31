using System;

// Token: 0x02000068 RID: 104
public class ObjectParty
{
	// Token: 0x060004F9 RID: 1273 RVA: 0x00045A8C File Offset: 0x00043C8C
	public ObjectParty(string name, short Lv, int idMap, sbyte idarea)
	{
		this.idArea = idarea;
		this.idMap = idMap;
		this.name = name;
		this.Lv = Lv;
	}

	// Token: 0x040006F9 RID: 1785
	public short Lv;

	// Token: 0x040006FA RID: 1786
	public string name;

	// Token: 0x040006FB RID: 1787
	public sbyte idArea;

	// Token: 0x040006FC RID: 1788
	public int x;

	// Token: 0x040006FD RID: 1789
	public int y;

	// Token: 0x040006FE RID: 1790
	public int idMap;

	// Token: 0x040006FF RID: 1791
	public int hp;

	// Token: 0x04000700 RID: 1792
	public int maxhp;

	// Token: 0x04000701 RID: 1793
	public bool isRemove;

	// Token: 0x04000702 RID: 1794
	public bool ischeck = true;
}
