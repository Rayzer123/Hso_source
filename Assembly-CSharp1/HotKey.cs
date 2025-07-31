using System;

// Token: 0x020000CC RID: 204
public class HotKey
{
	// Token: 0x060009A5 RID: 2469 RVA: 0x000A35AC File Offset: 0x000A17AC
	public void setHotKey(int id, int type, sbyte typePotion)
	{
		this.id = (short)id;
		this.type = (sbyte)type;
		this.typePotion = typePotion;
	}

	// Token: 0x060009A6 RID: 2470 RVA: 0x000A35C8 File Offset: 0x000A17C8
	public void setIdIcon(short id)
	{
		this.idIconPotion = id;
	}

	// Token: 0x040010CA RID: 4298
	public short id;

	// Token: 0x040010CB RID: 4299
	public short idIconPotion;

	// Token: 0x040010CC RID: 4300
	public sbyte type;

	// Token: 0x040010CD RID: 4301
	public sbyte typePotion;

	// Token: 0x040010CE RID: 4302
	public static sbyte NULL = -1;

	// Token: 0x040010CF RID: 4303
	public static sbyte SKILL;

	// Token: 0x040010D0 RID: 4304
	public static sbyte POTION = 1;
}
