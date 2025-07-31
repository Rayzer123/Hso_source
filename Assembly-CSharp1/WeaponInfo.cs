using System;

// Token: 0x02000078 RID: 120
public class WeaponInfo
{
	// Token: 0x06000589 RID: 1417 RVA: 0x0004FCBC File Offset: 0x0004DEBC
	public WeaponInfo()
	{
		this.mPos = mSystem.new_M_Byte(4, 3, 2);
		this.mRegion = mSystem.new_M_Byte(4, 2);
	}

	// Token: 0x040007D0 RID: 2000
	public mImage img;

	// Token: 0x040007D1 RID: 2001
	public sbyte[][][] mPos;

	// Token: 0x040007D2 RID: 2002
	public sbyte[][] mRegion;

	// Token: 0x040007D3 RID: 2003
	public int himg;
}
