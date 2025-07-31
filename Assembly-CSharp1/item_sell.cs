using System;

// Token: 0x0200007A RID: 122
public class item_sell
{
	// Token: 0x0600058B RID: 1419 RVA: 0x0004FCF8 File Offset: 0x0004DEF8
	public item_sell(short id, int price)
	{
		this.id = id;
		this.price = price;
	}

	// Token: 0x0600058C RID: 1420 RVA: 0x0004FD10 File Offset: 0x0004DF10
	public item_sell()
	{
	}

	// Token: 0x0600058D RID: 1421 RVA: 0x0004FD18 File Offset: 0x0004DF18
	public item_sell(short id, int price, int soluong)
	{
		this.id = id;
		this.price = price;
		this.soluuong = (short)soluong;
	}

	// Token: 0x0600058E RID: 1422 RVA: 0x0004FD38 File Offset: 0x0004DF38
	public item_sell(short id, int price, int soluong, int cat)
	{
		this.id = id;
		this.price = price;
		this.soluuong = (short)soluong;
		this.cat = (sbyte)cat;
	}

	// Token: 0x040007D6 RID: 2006
	public int price;

	// Token: 0x040007D7 RID: 2007
	public short id;

	// Token: 0x040007D8 RID: 2008
	public short soluuong;

	// Token: 0x040007D9 RID: 2009
	public sbyte cat;
}
