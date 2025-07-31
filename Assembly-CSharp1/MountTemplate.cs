using System;

// Token: 0x02000063 RID: 99
public class MountTemplate
{
	// Token: 0x060004C6 RID: 1222 RVA: 0x00043450 File Offset: 0x00041650
	public static MountTemplate gI()
	{
		return (MountTemplate.me != null) ? MountTemplate.me : (MountTemplate.me = new MountTemplate());
	}

	// Token: 0x040006B3 RID: 1715
	public const sbyte NGUA_NAU = 0;

	// Token: 0x040006B4 RID: 1716
	public const sbyte NGUA_TRANG = 1;

	// Token: 0x040006B5 RID: 1717
	public const sbyte NGUA_CHIENGIAP = 2;

	// Token: 0x040006B6 RID: 1718
	public const sbyte NGUA_DO = 3;

	// Token: 0x040006B7 RID: 1719
	public const sbyte NGUA_DEN = 4;

	// Token: 0x040006B8 RID: 1720
	public short idTemplate;

	// Token: 0x040006B9 RID: 1721
	public short idImage;

	// Token: 0x040006BA RID: 1722
	public short lv;

	// Token: 0x040006BB RID: 1723
	public sbyte typemove;

	// Token: 0x040006BC RID: 1724
	public string name = string.Empty;

	// Token: 0x040006BD RID: 1725
	public static MountTemplate me;

	// Token: 0x040006BE RID: 1726
	public static sbyte[] Arr_Fly;

	// Token: 0x040006BF RID: 1727
	public static sbyte[] speed;

	// Token: 0x040006C0 RID: 1728
	public static sbyte[][] FRAME_VE_TRUOC;

	// Token: 0x040006C1 RID: 1729
	public static sbyte[][] DY_CHAR_STAND;

	// Token: 0x040006C2 RID: 1730
	public static sbyte[][] DY_CHAR_MOVE;

	// Token: 0x040006C3 RID: 1731
	public static sbyte[][] dx;

	// Token: 0x040006C4 RID: 1732
	public static sbyte[][] dy;

	// Token: 0x040006C5 RID: 1733
	public static sbyte[][] FRAME_MOVE_LR;

	// Token: 0x040006C6 RID: 1734
	public static sbyte[][] FRAME_MOVE_DOWN;

	// Token: 0x040006C7 RID: 1735
	public static sbyte[][] FRAME_MOVE_UP;
}
