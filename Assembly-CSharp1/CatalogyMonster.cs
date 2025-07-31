using System;

// Token: 0x02000040 RID: 64
public class CatalogyMonster
{
	// Token: 0x060002E4 RID: 740 RVA: 0x00026F08 File Offset: 0x00025108
	public CatalogyMonster(int id, int lv, int maxHp, int typeMove, string name)
	{
		this.id = id;
		this.lv = lv;
		this.maxHp = maxHp;
		this.typeMove = typeMove;
		this.name = name;
	}

	// Token: 0x040003B5 RID: 949
	public int id;

	// Token: 0x040003B6 RID: 950
	public int lv;

	// Token: 0x040003B7 RID: 951
	public int maxHp;

	// Token: 0x040003B8 RID: 952
	public int typeMove;

	// Token: 0x040003B9 RID: 953
	public string name;
}
