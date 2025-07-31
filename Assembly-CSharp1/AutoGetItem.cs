using System;

// Token: 0x0200003F RID: 63
public class AutoGetItem
{
	// Token: 0x060002E2 RID: 738 RVA: 0x00026ED4 File Offset: 0x000250D4
	public AutoGetItem(sbyte valuecolor, sbyte potion, sbyte money)
	{
		this.valueColorItem = valuecolor;
		this.isGetMoney = money;
		this.isGetPotion = potion;
	}

	// Token: 0x040003AD RID: 941
	public sbyte valueColorItem;

	// Token: 0x040003AE RID: 942
	public sbyte isGetMoney;

	// Token: 0x040003AF RID: 943
	public sbyte isGetPotion;

	// Token: 0x040003B0 RID: 944
	public static sbyte POI_NHAT_HET;

	// Token: 0x040003B1 RID: 945
	public static sbyte POI_NHAT_MAU = 1;

	// Token: 0x040003B2 RID: 946
	public static sbyte POI_NHAT_NANG_LUONG = 2;

	// Token: 0x040003B3 RID: 947
	public static sbyte POI_KHONG_NHAT = 3;

	// Token: 0x040003B4 RID: 948
	public bool isremove;
}
