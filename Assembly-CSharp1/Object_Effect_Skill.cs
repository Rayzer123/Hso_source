using System;

// Token: 0x02000069 RID: 105
public class Object_Effect_Skill
{
	// Token: 0x060004FA RID: 1274 RVA: 0x00045AC4 File Offset: 0x00043CC4
	public Object_Effect_Skill(short Id, sbyte tem)
	{
		this.ID = Id;
		this.tem = tem;
	}

	// Token: 0x060004FB RID: 1275 RVA: 0x00045B00 File Offset: 0x00043D00
	public Object_Effect_Skill(short Id, sbyte tem, Monster_Skill skill)
	{
		this.ID = Id;
		this.tem = tem;
		this.skillMonster = skill;
	}

	// Token: 0x060004FC RID: 1276 RVA: 0x00045B38 File Offset: 0x00043D38
	public void setHP(int hpShow, int hpLast)
	{
		this.hpShow = hpShow;
		this.hpLast = hpLast;
	}

	// Token: 0x04000703 RID: 1795
	public short ID;

	// Token: 0x04000704 RID: 1796
	public sbyte tem;

	// Token: 0x04000705 RID: 1797
	public int hpShow;

	// Token: 0x04000706 RID: 1798
	public int hpLast;

	// Token: 0x04000707 RID: 1799
	public int hpPlus;

	// Token: 0x04000708 RID: 1800
	public int[] mEffTypePlus = new int[0];

	// Token: 0x04000709 RID: 1801
	public int[] mEff_HP_Plus = new int[0];

	// Token: 0x0400070A RID: 1802
	public Monster_Skill skillMonster;
}
