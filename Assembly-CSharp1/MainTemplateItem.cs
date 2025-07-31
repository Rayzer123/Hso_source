using System;

// Token: 0x020000C0 RID: 192
public class MainTemplateItem
{
	// Token: 0x06000962 RID: 2402 RVA: 0x00097B0C File Offset: 0x00095D0C
	public MainTemplateItem()
	{
	}

	// Token: 0x06000963 RID: 2403 RVA: 0x00097B14 File Offset: 0x00095D14
	public MainTemplateItem(short ID, string name, sbyte typeItem, sbyte idPartItem, sbyte classitem, short iconId, int[] mvalue, sbyte[] mvaluename)
	{
		this.ID = (int)ID;
		this.IconId = (int)iconId;
		this.name = name;
		this.typeItem = (int)typeItem;
		this.idPartItem = (int)idPartItem;
		this.classItem = (int)classitem;
		this.mValueItem = mvalue;
		this.mValueName = mvaluename;
	}

	// Token: 0x06000964 RID: 2404 RVA: 0x00097B68 File Offset: 0x00095D68
	public MainTemplateItem(short ID, short IconId, long price, string name, string content, sbyte typepotion, sbyte moneytype, sbyte sell, short value, bool canTrade)
	{
		this.ID = (int)ID;
		this.IconId = (int)IconId;
		this.PricePoition = price;
		this.name = name;
		this.contentPotion = content;
		this.typePotion = typepotion;
		this.moneyType = moneytype;
		this.sellPotion = (int)sell;
		this.valuePotion = (int)value;
		this.canTrade = canTrade;
	}

	// Token: 0x06000966 RID: 2406 RVA: 0x00097C40 File Offset: 0x00095E40
	public static void removeUpdateItemInventory(int type)
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item.ItemCatagory == type)
			{
				Item.VecInvetoryPlayer.removeElement(item);
				i--;
			}
		}
	}

	// Token: 0x06000967 RID: 2407 RVA: 0x00097C94 File Offset: 0x00095E94
	public static void removeUpdateItemChest(int type)
	{
		for (int i = 0; i < Item.VecChestPlayer.size(); i++)
		{
			Item item = (Item)Item.VecChestPlayer.elementAt(i);
			if (item.ItemCatagory == type)
			{
				Item.VecInvetoryPlayer.removeElement(item);
				i--;
			}
		}
	}

	// Token: 0x06000968 RID: 2408 RVA: 0x00097CE8 File Offset: 0x00095EE8
	public static void removeUpdateItemVec(int type, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			Item item = (Item)vec.elementAt(i);
			if (item.ItemCatagory == type)
			{
				vec.removeElement(item);
				i--;
			}
		}
	}

	// Token: 0x06000969 RID: 2409 RVA: 0x00097D30 File Offset: 0x00095F30
	public static MainTemplateItem getItemTem(short id)
	{
		MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashItemTem.get(string.Empty + id);
		if (mainTemplateItem == null)
		{
			mainTemplateItem = new MainTemplateItem();
			MainTemplateItem.hashItemTem.put(string.Empty + id, mainTemplateItem);
			GlobalService.gI().getItemTem(id);
		}
		if (mainTemplateItem.name == null)
		{
			mainTemplateItem.timenull++;
			if (mainTemplateItem.timenull >= 200)
			{
				GlobalService.gI().getItemTem(id);
				mainTemplateItem.timenull = 0;
			}
		}
		return mainTemplateItem;
	}

	// Token: 0x0600096A RID: 2410 RVA: 0x00097DCC File Offset: 0x00095FCC
	public static MainTemplateItem getPotionTem(short id)
	{
		return (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + id);
	}

	// Token: 0x04000E5D RID: 3677
	public const sbyte TYPE_AO = 0;

	// Token: 0x04000E5E RID: 3678
	public const sbyte TYPE_QUAN = 1;

	// Token: 0x04000E5F RID: 3679
	public const sbyte TYPE_NON = 2;

	// Token: 0x04000E60 RID: 3680
	public const sbyte TYPE_GANGTAY = 3;

	// Token: 0x04000E61 RID: 3681
	public const sbyte TYPE_NHAN = 4;

	// Token: 0x04000E62 RID: 3682
	public const sbyte TYPE_DAYCHUYEN = 5;

	// Token: 0x04000E63 RID: 3683
	public const sbyte TYPE_GIAY = 6;

	// Token: 0x04000E64 RID: 3684
	public const sbyte TYPE_CANH = 7;

	// Token: 0x04000E65 RID: 3685
	public const sbyte TYPE_VUKHI1 = 8;

	// Token: 0x04000E66 RID: 3686
	public const sbyte TYPE_VUKHI2 = 9;

	// Token: 0x04000E67 RID: 3687
	public const sbyte TYPE_VUKHI3 = 10;

	// Token: 0x04000E68 RID: 3688
	public const sbyte TYPE_VUKHI4 = 11;

	// Token: 0x04000E69 RID: 3689
	public const sbyte TYPE_PET = 14;

	// Token: 0x04000E6A RID: 3690
	public const sbyte I_VUKHI = 0;

	// Token: 0x04000E6B RID: 3691
	public const sbyte I_AO = 1;

	// Token: 0x04000E6C RID: 3692
	public const sbyte I_GANGTAY = 2;

	// Token: 0x04000E6D RID: 3693
	public const sbyte I_NHAN1 = 3;

	// Token: 0x04000E6E RID: 3694
	public const sbyte I_DAYCHUYEN = 4;

	// Token: 0x04000E6F RID: 3695
	public const sbyte I_PET = 5;

	// Token: 0x04000E70 RID: 3696
	public const sbyte I_NON = 6;

	// Token: 0x04000E71 RID: 3697
	public const sbyte I_QUAN = 7;

	// Token: 0x04000E72 RID: 3698
	public const sbyte I_GIAY = 8;

	// Token: 0x04000E73 RID: 3699
	public const sbyte I_NHAN2 = 9;

	// Token: 0x04000E74 RID: 3700
	public const sbyte I_CANH = 10;

	// Token: 0x04000E75 RID: 3701
	public const sbyte I_HEAD = 12;

	// Token: 0x04000E76 RID: 3702
	public const sbyte I_EYE = 13;

	// Token: 0x04000E77 RID: 3703
	public const sbyte I_HAIR = 14;

	// Token: 0x04000E78 RID: 3704
	public int ID;

	// Token: 0x04000E79 RID: 3705
	public int IconId;

	// Token: 0x04000E7A RID: 3706
	public string name;

	// Token: 0x04000E7B RID: 3707
	private int timenull;

	// Token: 0x04000E7C RID: 3708
	public static bool isload = true;

	// Token: 0x04000E7D RID: 3709
	public int typeItem;

	// Token: 0x04000E7E RID: 3710
	public int idPartItem;

	// Token: 0x04000E7F RID: 3711
	public int classItem;

	// Token: 0x04000E80 RID: 3712
	public int[] mValueItem;

	// Token: 0x04000E81 RID: 3713
	public sbyte[] mValueName;

	// Token: 0x04000E82 RID: 3714
	public int sellPotion;

	// Token: 0x04000E83 RID: 3715
	public int valuePotion;

	// Token: 0x04000E84 RID: 3716
	public long PricePoition;

	// Token: 0x04000E85 RID: 3717
	public sbyte moneyType;

	// Token: 0x04000E86 RID: 3718
	public sbyte typePotion;

	// Token: 0x04000E87 RID: 3719
	public string contentPotion;

	// Token: 0x04000E88 RID: 3720
	public sbyte typeSell;

	// Token: 0x04000E89 RID: 3721
	public sbyte typeTrade;

	// Token: 0x04000E8A RID: 3722
	private bool canTrade;

	// Token: 0x04000E8B RID: 3723
	public static int[] mItem_Equip_Tem = new int[]
	{
		-1,
		0,
		3,
		4,
		5,
		12,
		2,
		1,
		6,
		4,
		7,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2,
		-2
	};

	// Token: 0x04000E8C RID: 3724
	public static int[] mItem_Rotate_Tem_Equip = new int[]
	{
		1,
		7,
		6,
		2,
		-1,
		4,
		8,
		10,
		0,
		0,
		0,
		0,
		5
	};

	// Token: 0x04000E8D RID: 3725
	public static mHashTable hashPotionTem = new mHashTable();

	// Token: 0x04000E8E RID: 3726
	public static mHashTable hashMaterialTem = new mHashTable();

	// Token: 0x04000E8F RID: 3727
	public static mHashTable hashMaterialTem2 = new mHashTable();

	// Token: 0x04000E90 RID: 3728
	public static mHashTable hashItemTem = new mHashTable();

	// Token: 0x04000E91 RID: 3729
	public static mHashTable hashPetTem = new mHashTable();
}
