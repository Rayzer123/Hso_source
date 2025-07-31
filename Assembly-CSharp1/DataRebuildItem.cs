using System;

// Token: 0x02000091 RID: 145
public class DataRebuildItem
{
	// Token: 0x06000701 RID: 1793 RVA: 0x00069E8C File Offset: 0x0006808C
	public DataRebuildItem()
	{
	}

	// Token: 0x06000702 RID: 1794 RVA: 0x00069E94 File Offset: 0x00068094
	public DataRebuildItem(sbyte lv, int coin, int gold, sbyte[] mvalue)
	{
		this.lv = lv;
		this.priceCoin = coin;
		this.priceGold = gold;
		this.mValue = mvalue;
	}

	// Token: 0x06000703 RID: 1795 RVA: 0x00069EBC File Offset: 0x000680BC
	public DataRebuildItem(short id, short valueWing)
	{
		this.id = id;
		this.valueWing = valueWing;
	}

	// Token: 0x06000704 RID: 1796 RVA: 0x00069ED4 File Offset: 0x000680D4
	public DataRebuildItem(short id, sbyte cat)
	{
		this.id = id;
		this.cat = cat;
	}

	// Token: 0x04000A40 RID: 2624
	public short id;

	// Token: 0x04000A41 RID: 2625
	public short valueWing;

	// Token: 0x04000A42 RID: 2626
	public sbyte lv;

	// Token: 0x04000A43 RID: 2627
	public sbyte cat;

	// Token: 0x04000A44 RID: 2628
	public int priceCoin;

	// Token: 0x04000A45 RID: 2629
	public int priceGold;

	// Token: 0x04000A46 RID: 2630
	public sbyte[] mValue;
}
