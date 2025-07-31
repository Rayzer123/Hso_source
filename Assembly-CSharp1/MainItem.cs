using System;

// Token: 0x02000053 RID: 83
public class MainItem : Item
{
	// Token: 0x06000393 RID: 915 RVA: 0x00032C18 File Offset: 0x00030E18
	public MainItem(int ID, int IconId, string name, string content, int numPotion, int typeMainItem, long price, sbyte typePotion, sbyte moneytype, sbyte issell, sbyte istrade)
	{
		this.Id = ID;
		this.imageId = IconId;
		this.itemName = name;
		this.typePotion = typePotion;
		this.numPotion = numPotion;
		this.ItemCatagory = typeMainItem;
		this.priceItem = price;
		this.priceType = moneytype;
		this.canSell = issell;
		this.canTrade = istrade;
		this.mMoreContent(content);
		this.IndexSort = 0;
	}

	// Token: 0x06000394 RID: 916 RVA: 0x00032C88 File Offset: 0x00030E88
	public MainItem()
	{
	}

	// Token: 0x06000395 RID: 917 RVA: 0x00032C90 File Offset: 0x00030E90
	public MainItem(int ID, string itemName, int imageId, sbyte tier, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short level, sbyte canSell, sbyte canTrade, int timeUse, sbyte priceType, sbyte isLock, int timeDefault, long currentTime)
	{
		this.itemNameExcludeLv = itemName;
		this.itemName = itemName;
		this.imageId = imageId;
		this.Id = ID;
		this.tier = tier;
		if ((int)this.tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
		this.colorNameItem = colorNameItem;
		this.classcharItem = charclass;
		this.ItemCatagory = typeMain;
		this.mInfo = minfo;
		this.type_Only_Item = typeOnly;
		this.IdTem = idTem;
		this.priceItem = price;
		this.LvItem = (int)level;
		this.canSell = canSell;
		this.canTrade = canTrade;
		this.timeUse = timeUse;
		this.isLock = isLock;
		this.timeDefaultItemFashion = timeDefault;
		this.currentTimeItemFashion = currentTime;
		if (timeUse > 0)
		{
			this.timeDem = GameCanvas.timeNow;
		}
		else
		{
			this.timeDem = 0L;
		}
		this.priceType = priceType;
		if ((this.mInfo != null && this.mInfo.Length > 0) || this.priceItem > 0L || this.timeDem > 0L)
		{
			if (this.mInfo != null && this.mInfo.Length > 0)
			{
				minfo = CRes.selectionSort(minfo);
			}
			if (!isTem)
			{
				base.setContentItem();
			}
			else
			{
				base.setContentTem();
			}
		}
		this.IndexSort = 10;
	}

	// Token: 0x06000396 RID: 918 RVA: 0x00032E04 File Offset: 0x00031004
	public MainItem(int ID, string itemName, int imageId, sbyte tier, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short level, sbyte canSell, sbyte canTrade, int timeUse, sbyte typeMoney, sbyte isLock)
	{
		this.itemNameExcludeLv = itemName;
		this.itemName = itemName;
		this.imageId = imageId;
		this.Id = ID;
		this.tier = tier;
		if ((int)tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
		this.colorNameItem = colorNameItem;
		this.classcharItem = charclass;
		this.ItemCatagory = typeMain;
		this.mInfo = minfo;
		this.type_Only_Item = typeOnly;
		this.IdTem = idTem;
		this.priceItem = price;
		this.LvItem = (int)level;
		this.canSell = canSell;
		this.canTrade = canTrade;
		this.timeUse = timeUse;
		this.isLock = isLock;
		if (timeUse > 0)
		{
			this.timeDem = GameCanvas.timeNow;
		}
		else
		{
			this.timeDem = 0L;
		}
		this.priceType = typeMoney;
		if ((this.mInfo != null && this.mInfo.Length > 0) || this.priceItem > 0L || this.timeDem > 0L)
		{
			if (this.mInfo != null && this.mInfo.Length > 0)
			{
				minfo = CRes.selectionSort(minfo);
			}
			if (!isTem)
			{
				base.setContentItem();
			}
			else
			{
				base.setContentTem();
			}
		}
		this.IndexSort = 10;
		this.infoHop = new string[]
		{
			string.Empty,
			string.Empty
		};
	}

	// Token: 0x06000397 RID: 919 RVA: 0x00032F80 File Offset: 0x00031180
	public MainItem(int ID, string itemName, int imageId, sbyte plusItem, int typeMain, MainInfoItem[] minfo, bool isTem, short idTem, long price, sbyte priceType, sbyte issell, sbyte istrade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		this.Id = ID;
		this.tier = plusItem;
		this.ItemCatagory = typeMain;
		this.mInfo = minfo;
		this.IdTem = idTem;
		this.priceItem = price;
		this.priceType = priceType;
		this.canSell = issell;
		this.canTrade = istrade;
		if (this.mInfo != null)
		{
			minfo = CRes.selectionSort(minfo);
			this.setContentHair();
		}
		this.IndexSort = 1;
	}

	// Token: 0x06000398 RID: 920 RVA: 0x0003300C File Offset: 0x0003120C
	public MainItem(int ID, long price)
	{
		this.Id = ID;
		this.priceItem = price;
		this.priceType = 1;
		this.ItemCatagory = 8;
		this.itemName = T.iconclan;
		this.mMoreContent(T.contentclan);
		this.IndexSort = 1;
	}

	// Token: 0x06000399 RID: 921 RVA: 0x00033058 File Offset: 0x00031258
	public MainItem(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeItem, short num, sbyte sell, sbyte trade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		this.Id = ID;
		this.ItemCatagory = typeMain;
		this.priceItem = price;
		this.priceType = priceType;
		this.value = value;
		this.numPotion = (int)num;
		this.canSell = sell;
		this.canTrade = trade;
		this.content = content;
		this.typeMaterial = typeItem;
		if (content != null)
		{
			this.mMoreContent(content);
		}
		this.IndexSort = 2;
	}

	// Token: 0x0600039A RID: 922 RVA: 0x000330E0 File Offset: 0x000312E0
	public MainItem(int ID, string name, int numQItem, string content, sbyte issell, sbyte istrade)
	{
		this.Id = ID;
		this.imageId = ID;
		this.itemName = name;
		this.numPotion = numQItem;
		this.ItemCatagory = 5;
		this.canSell = issell;
		this.canTrade = istrade;
		this.mMoreContent(content);
		this.IndexSort = 3;
	}

	// Token: 0x0600039B RID: 923 RVA: 0x00033138 File Offset: 0x00031338
	public MainItem(int ID, string name, int numPo, int idIcon, sbyte item_potion, string contentPotion, MainInfoItem[] minfo, sbyte colorname, sbyte charclass, short lvMin, sbyte lvup, sbyte issell, sbyte istrade)
	{
		this.Id = ID;
		this.itemName = name;
		this.numPotion = numPo;
		this.imageId = idIcon;
		this.ItemCatagory = (int)item_potion;
		this.colorNameItem = (int)colorname;
		this.mInfo = minfo;
		this.classcharItem = (int)charclass;
		this.LvItem = (int)lvMin;
		this.canSell = issell;
		this.canTrade = istrade;
		this.tier = lvup;
		if ((int)this.tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
		if (contentPotion != null)
		{
			this.mMoreContent(contentPotion);
		}
		else
		{
			base.setContentItem();
		}
		this.IndexSort = 4;
	}

	// Token: 0x0600039C RID: 924 RVA: 0x000331FC File Offset: 0x000313FC
	public MainItem(string name, int idIcon, int numPo, sbyte item_potion, sbyte lvup, sbyte color)
	{
		this.colorNameItem = (int)color;
		this.itemName = name;
		this.numPotion = numPo;
		this.imageId = idIcon;
		this.ItemCatagory = (int)item_potion;
		this.tier = lvup;
		if ((int)this.tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
	}

	// Token: 0x0600039D RID: 925 RVA: 0x0003326C File Offset: 0x0003146C
	public MainItem clonePotion()
	{
		MainItem mainItem = new MainItem();
		mainItem.Id = this.Id;
		mainItem.imageId = this.imageId;
		mainItem.itemName = this.itemName;
		mainItem.typePotion = this.typePotion;
		mainItem.numPotion = this.numPotion;
		mainItem.ItemCatagory = this.ItemCatagory;
		mainItem.priceItem = this.priceItem;
		mainItem.priceType = this.priceType;
		mainItem.canSell = this.priceType;
		mainItem.canTrade = this.priceType;
		if (this.content != null)
		{
			mainItem.mMoreContent(this.content);
		}
		mainItem.mcontent = this.mcontent;
		this.IndexSort = 0;
		return mainItem;
	}

	// Token: 0x0600039E RID: 926 RVA: 0x00033324 File Offset: 0x00031524
	public override void mMoreContent(string str)
	{
		base.mMoreContent(str);
	}

	// Token: 0x0600039F RID: 927 RVA: 0x00033330 File Offset: 0x00031530
	public static MainItem MainItem_Item(int ID, string itemName, int imageId, sbyte plusItem, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short LvItem, sbyte issell, sbyte istrade, int timeUse, sbyte typeMoney, sbyte isLock)
	{
		return new MainItem(ID, itemName, imageId, plusItem, colorNameItem, charclass, typeMain, minfo, typeOnly, isTem, idTem, price, LvItem, issell, istrade, timeUse, typeMoney, isLock);
	}

	// Token: 0x060003A0 RID: 928 RVA: 0x00033364 File Offset: 0x00031564
	public MainItem clone()
	{
		return new MainItem
		{
			itemNameExcludeLv = this.itemNameExcludeLv,
			itemName = this.itemName,
			imageId = this.imageId,
			Id = this.Id,
			tier = this.tier,
			colorNameItem = this.colorNameItem,
			classcharItem = this.classcharItem,
			ItemCatagory = this.ItemCatagory,
			mInfo = this.mInfo,
			type_Only_Item = this.type_Only_Item,
			IdTem = this.IdTem,
			priceItem = this.priceItem,
			LvItem = this.LvItem,
			canSell = this.canSell,
			canTrade = this.canTrade,
			timeUse = this.timeUse,
			isLock = this.isLock,
			timeDem = this.timeDem,
			numPotion = this.numPotion,
			priceType = this.priceType,
			mInfo = this.mInfo,
			IndexSort = this.IndexSort,
			infoHop = new string[]
			{
				string.Empty,
				string.Empty
			}
		};
	}

	// Token: 0x060003A1 RID: 929 RVA: 0x0003349C File Offset: 0x0003169C
	public static MainItem MainItem_Item(int ID, string itemName, int imageId, sbyte plusItem, int colorNameItem, int charclass, int typeMain, MainInfoItem[] minfo, int typeOnly, bool isTem, short idTem, long price, short LvItem, sbyte issell, sbyte istrade, int timeUse, sbyte priceType, sbyte isLock, int timeDefault, long currentTime)
	{
		return new MainItem(ID, itemName, imageId, plusItem, colorNameItem, charclass, typeMain, minfo, typeOnly, isTem, idTem, price, LvItem, issell, istrade, timeUse, priceType, isLock, timeDefault, currentTime);
	}

	// Token: 0x060003A2 RID: 930 RVA: 0x000334D4 File Offset: 0x000316D4
	public static MainItem MainItem_Toc(int ID, string itemName, int imageId, sbyte plusItem, int typeMain, MainInfoItem[] minfo, bool isTem, short idTem, long price, sbyte priceType, sbyte issell, sbyte istrade)
	{
		return new MainItem(ID, itemName, imageId, plusItem, typeMain, minfo, isTem, idTem, price, priceType, issell, istrade);
	}

	// Token: 0x060003A3 RID: 931 RVA: 0x000334FC File Offset: 0x000316FC
	public static MainItem MainItem_Material(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		return new MainItem(ID, itemName, imageId, typeMain, price, priceType, content, value, typeitem, num, Sell, Trade);
	}

	// Token: 0x060003A4 RID: 932 RVA: 0x00033524 File Offset: 0x00031724
	public MainItem cloneNguyenLieu()
	{
		MainItem mainItem = new MainItem();
		mainItem.itemName = this.itemName;
		mainItem.imageId = this.imageId;
		mainItem.Id = this.Id;
		mainItem.ItemCatagory = this.ItemCatagory;
		mainItem.priceItem = this.priceItem;
		mainItem.priceType = this.priceType;
		mainItem.value = this.value;
		mainItem.canSell = this.canSell;
		mainItem.canTrade = this.canTrade;
		mainItem.content = this.content;
		mainItem.typeMaterial = this.typeMaterial;
		if (this.content != null)
		{
			mainItem.mMoreContent(this.content);
		}
		mainItem.IndexSort = 2;
		return mainItem;
	}

	// Token: 0x060003A5 RID: 933 RVA: 0x000335DC File Offset: 0x000317DC
	public override void paintItem_notnum(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem_notnum(g, x, y, w, lech, numlech);
	}

	// Token: 0x060003A6 RID: 934 RVA: 0x000335F0 File Offset: 0x000317F0
	public void setContentHair()
	{
		if (this.itemName == null)
		{
			this.itemName = null;
			return;
		}
		int num = this.mInfo.Length;
		this.mcontent = new string[num];
		this.mColor = new int[num];
		int width = mFont.tahoma_7b_white.getWidth(this.itemName);
		if (width > this.sizeW - 10)
		{
			this.sizeW = width + 10;
		}
		for (int i = 0; i < num; i++)
		{
			MainInfoItem mainInfoItem = this.mInfo[i];
			this.mcontent[i] = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
			this.mColor[i] = (int)Item.colorInfoItem[mainInfoItem.id];
			width = mFont.tahoma_7_black.getWidth(this.mcontent[i]);
			if (width > this.sizeW - 10)
			{
				this.sizeW = width + 10;
			}
		}
		int num2 = 0;
		num2++;
		if (num2 > 0)
		{
			this.mPlusContent = new string[num2];
			this.mPlusColor = new int[num2];
			num2 = 0;
			if (this.priceItem > 0L)
			{
				this.mPlusContent[num2] = string.Concat(new object[]
				{
					T.price,
					": ",
					this.priceItem,
					base.getPriceType()
				});
				this.mPlusColor[num2] = 2;
				num2++;
			}
			else
			{
				this.mPlusContent[num2] = T.dasohuu;
				this.mPlusColor[num2] = 2;
				num2++;
			}
		}
		else
		{
			this.mPlusContent = null;
			this.mPlusColor = null;
		}
	}

	// Token: 0x060003A7 RID: 935 RVA: 0x000337AC File Offset: 0x000319AC
	public static string getDotNumber(long m)
	{
		string text = string.Empty;
		long num = m / 1000L + 1L;
		int num2 = 0;
		while ((long)num2 < num)
		{
			if (m < 1000L)
			{
				text = m + text;
				break;
			}
			long num3 = m % 1000L;
			if (num3 == 0L)
			{
				text = ".000" + text;
			}
			else if (num3 < 10L)
			{
				text = ".00" + num3 + text;
			}
			else if (num3 < 100L)
			{
				text = ".0" + num3 + text;
			}
			else
			{
				text = "." + num3 + text;
			}
			m /= 1000L;
			num2++;
		}
		return text;
	}

	// Token: 0x060003A8 RID: 936 RVA: 0x00033880 File Offset: 0x00031A80
	public static string getNopercent(int value)
	{
		if (value % 100 == 0)
		{
			return value / 100 + string.Empty;
		}
		if (value % 10 == 0)
		{
			return value / 100 + "." + value % 100 / 10;
		}
		return string.Concat(new object[]
		{
			value / 100,
			".",
			value % 100 / 10,
			string.Empty,
			value % 10
		});
	}

	// Token: 0x060003A9 RID: 937 RVA: 0x00033918 File Offset: 0x00031B18
	public void paint(mGraphics g)
	{
	}

	// Token: 0x060003AA RID: 938 RVA: 0x0003391C File Offset: 0x00031B1C
	public void paintColorItem(mGraphics g, int x, int y, int w)
	{
	}

	// Token: 0x060003AB RID: 939 RVA: 0x00033920 File Offset: 0x00031B20
	public new void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem(g, x, y, w, lech, numlech);
	}

	// Token: 0x060003AC RID: 940 RVA: 0x00033934 File Offset: 0x00031B34
	public new void paintItemNew(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItemNew(g, x, y, w, lech, numlech);
	}

	// Token: 0x060003AD RID: 941 RVA: 0x00033948 File Offset: 0x00031B48
	public static void setAddHotKey(sbyte typePo, bool isStop)
	{
		HotKey hotKey = null;
		if ((int)typePo == 0)
		{
			hotKey = Player.mhotkey[Player.levelTab][4];
		}
		else if ((int)typePo == 1)
		{
			hotKey = Player.mhotkey[Player.levelTab][3];
		}
		if (hotKey == null || (int)hotKey.type != (int)HotKey.NULL)
		{
			hotKey = new HotKey();
			hotKey.type = HotKey.NULL;
		}
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
			if (mainItem.ItemCatagory == 4 && (int)mainItem.typePotion == (int)typePo && (((int)hotKey.id < mainItem.Id && isStop) || ((int)hotKey.id > mainItem.Id && !isStop) || (int)hotKey.type == (int)HotKey.NULL))
			{
				hotKey.setHotKey(mainItem.Id, (int)HotKey.POTION, typePo);
			}
		}
	}

	// Token: 0x060003AE RID: 942 RVA: 0x00033A4C File Offset: 0x00031C4C
	public void set_can_Sell(sbyte can_sell_for_other_player)
	{
		this.can_sell_for_other_player = can_sell_for_other_player;
	}

	// Token: 0x060003AF RID: 943 RVA: 0x00033A58 File Offset: 0x00031C58
	public void setCanShell_notCanTrade(sbyte type)
	{
		this.CanShell_CanNotTrade = type;
	}

	// Token: 0x060003B0 RID: 944 RVA: 0x00033A64 File Offset: 0x00031C64
	public override bool isMaterialHopNguyenLieu()
	{
		return this.ItemCatagory == 7 && MainObject.isMaHopNguyenLieu(this.Id);
	}

	// Token: 0x040004F4 RID: 1268
	public const int FOOT = 8;

	// Token: 0x040004F5 RID: 1269
	public const int ATB_FOOT_SNOW = 67;
}
