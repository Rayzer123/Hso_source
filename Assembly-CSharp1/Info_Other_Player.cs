using System;

// Token: 0x02000080 RID: 128
public class Info_Other_Player : MainScreen
{
	// Token: 0x06000610 RID: 1552 RVA: 0x0005A148 File Offset: 0x00058348
	public Info_Other_Player()
	{
		this.maintab = new MainTabNew();
		this.wScreen = 180;
		this.wsize = (int)MainTabNew.wOneItem;
		if (GameCanvas.isSmallScreen)
		{
			this.wScreen = 160;
		}
		this.hitem = 12;
		this.numW = 6;
		this.numH = 2;
		this.xbegin = GameCanvas.hw - this.wScreen / 2;
		this.ybegin = GameCanvas.hh - this.wScreen / 2;
		if (!GameCanvas.isTouch)
		{
			this.ybegin -= iCommand.hButtonCmd / 2;
		}
		this.xEquip = this.xbegin + this.wScreen / 2 - this.numW * this.wsize / 2;
		this.yEquip = this.ybegin + this.wScreen / 3 * 2;
		this.cmdClose = new iCommand(T.close, -1);
		this.cmdMenu = new iCommand(T.menu, 0);
		this.cmdChat = new iCommand(T.trochuyen, 0);
		this.cmdAddF = new iCommand(T.addFriend, 1);
		this.cmdParty = new iCommand(T.moiParty, 2);
		this.cmdBuy_Sell = new iCommand(T.buySell, 3);
		this.cmdThachDau = new iCommand(T.thachdau, 4);
		this.cmdOkThachDau = new iCommand(T.chapnhan, 1);
		if (GameCanvas.isTouch)
		{
			this.cmdOkThachDau.setPos(this.xbegin + this.wScreen / 2, this.ybegin + this.wScreen + iCommand.hButtonCmd / 2, null, this.cmdOkThachDau.caption);
			this.cmdClose.setPos(this.xbegin + this.wScreen - 12, this.ybegin + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		this.cmdBuyFastionItem = new iCommand(T.buy, 0, this);
		this.cmdnext = new iCommand(T.trangbi2, 1, this);
		this.cmdback = new iCommand(T.trangbi1, 2, this);
		if (GameCanvas.isTouch)
		{
			this.cmdnext.setPos(this.xbegin + iCommand.wButtonCmd / 2, this.yEquip - iCommand.hButtonCmd / 2, PaintInfoGameScreen.fraButton2, this.cmdnext.caption);
			this.cmdback.setPos(this.xbegin + iCommand.wButtonCmd / 2, this.yEquip - iCommand.hButtonCmd / 2, PaintInfoGameScreen.fraButton2, this.cmdback.caption);
		}
		if (!GameCanvas.isTouch)
		{
			this.center = this.cmdnext;
		}
	}

	// Token: 0x06000612 RID: 1554 RVA: 0x0005A420 File Offset: 0x00058620
	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		if (!GameCanvas.isTouch)
		{
			this.idSelect = 0;
			this.itemSelect = (Item)Info_Other_Player.vecEquipShow.get(string.Empty + (this.idSelect + this.indexTab));
		}
		else
		{
			this.idSelect = -1;
		}
		this.maintab.listContent = null;
		this.itemSelect = null;
	}

	// Token: 0x06000613 RID: 1555 RVA: 0x0005A498 File Offset: 0x00058698
	public override void commandPointer(int index, int subIndex)
	{
		Item item = (Item)Info_Other_Player.vecEquipShow.get(string.Empty + this.idSelect);
		switch (index)
		{
		case 0:
			if (item != null)
			{
				GlobalService.gI().do_Buy_Sell_Item(5, null, string.Empty, (short)Info_Other_Player.showObject.ID, item.Id, 0);
			}
			break;
		case 1:
			this.indexTab = 12;
			if (!GameCanvas.isTouch)
			{
				this.center = this.cmdback;
			}
			break;
		case 2:
			this.indexTab = 0;
			if (!GameCanvas.isTouch)
			{
				this.center = this.cmdnext;
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000614 RID: 1556 RVA: 0x0005A560 File Offset: 0x00058760
	public override void commandTab(int index, int sub)
	{
		switch (index + 1)
		{
		case 0:
			if (this.lastScreen.lastScreen != null)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				this.lastScreen.Show();
			}
			break;
		case 1:
			this.doMenu();
			break;
		case 2:
			GlobalService.gI().Thach_Dau(1, Info_Other_Player.showObject.name);
			break;
		}
		base.commandTab(index, sub);
	}

	// Token: 0x06000615 RID: 1557 RVA: 0x0005A5F0 File Offset: 0x000587F0
	public override void commandMenu(int index, int sub)
	{
		switch (index)
		{
		case 0:
			GameCanvas.msgchat.addNewChat(Info_Other_Player.showObject.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 1:
			GlobalService.gI().Friend(0, Info_Other_Player.showObject.name);
			break;
		case 2:
			GlobalService.gI().Party(1, Info_Other_Player.showObject.name);
			break;
		case 3:
			GlobalService.gI().Buy_Sell(0, Info_Other_Player.showObject.name, 0, 0, 0);
			break;
		case 4:
			GlobalService.gI().Thach_Dau(0, Info_Other_Player.showObject.name);
			break;
		}
		base.commandMenu(index, sub);
	}

	// Token: 0x06000616 RID: 1558 RVA: 0x0005A6C0 File Offset: 0x000588C0
	public void init(sbyte type)
	{
		this.center = null;
		this.type = type;
		if ((int)type == (int)Info_Other_Player.THACH_DAU)
		{
			if (!GameCanvas.isTouch)
			{
				this.right = this.cmdClose;
				this.center = this.cmdOkThachDau;
				this.left = this.cmdMenu;
			}
			else
			{
				this.center = this.cmdOkThachDau;
				this.right = this.cmdClose;
			}
		}
		else
		{
			this.type = Info_Other_Player.VIEW;
			if (!GameCanvas.isTouch)
			{
				this.right = this.cmdClose;
				this.left = this.cmdMenu;
			}
			else
			{
				this.right = this.cmdClose;
			}
		}
	}

	// Token: 0x06000617 RID: 1559 RVA: 0x0005A778 File Offset: 0x00058978
	private void doMenu()
	{
		mVector mVector = new mVector("Info_Other_Player menu");
		mVector.addElement(this.cmdChat);
		mVector.addElement(this.cmdAddF);
		if (Player.party == null || Player.party.vecPartys.size() < 5)
		{
			mVector.addElement(this.cmdParty);
		}
		mVector.addElement(this.cmdBuy_Sell);
		if ((int)this.type == (int)Info_Other_Player.VIEW && (int)LoadMap.typeMap != LoadMap.MAP_THACH_DAU)
		{
			mVector.addElement(this.cmdThachDau);
		}
		GameCanvas.menu2.startAt(mVector, 2, T.giaotiep, false, null);
	}

	// Token: 0x06000618 RID: 1560 RVA: 0x0005A820 File Offset: 0x00058A20
	public override void paint(mGraphics g)
	{
		this.lastScreen.paint(g);
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = this.ybegin;
		int num2 = this.xbegin;
		base.paintFormList(g, num2, num, this.wScreen, this.wScreen, Info_Other_Player.showObject.name);
		num2 += 10;
		num += GameCanvas.hCommand + 2;
		if (Info_Other_Player.showObject.myClan != null)
		{
			Info_Other_Player.showObject.paintIconClan(g, num2 - 10 + this.wScreen / 2, num + 7, -2);
			num += this.hitem;
		}
		mFont.tahoma_7_white.drawString(g, T.level + Info_Other_Player.showObject.Lv, num2, num, 0, mGraphics.isFalse);
		num += this.hitem;
		mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
		{
			"HP: ",
			Info_Other_Player.showObject.hp,
			"/",
			Info_Other_Player.showObject.maxHp
		}), num2, num, 0, mGraphics.isFalse);
		num += this.hitem;
		if (Info_Other_Player.showPet != null)
		{
			Info_Other_Player.showPet.paintShowPet(g, this.xbegin + this.wScreen / 2 + 30, this.ybegin + 90 - (int)MainTabNew.wOneItem / 2 + 5, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem / 2, 0, 0);
		}
		Info_Other_Player.showObject.paintShowPlayer(g, this.xbegin + this.wScreen / 2, this.ybegin + 90, 0);
		sbyte b = 0;
		while ((int)b < TabMySeftNew.maxSize)
		{
			int num3 = this.xEquip + (int)b % this.numW * this.wsize;
			int num4 = this.yEquip + (int)b / this.numW * this.wsize;
			Item item = (Item)Info_Other_Player.vecEquipShow.get(string.Empty + ((int)b + this.indexTab));
			if (item != null)
			{
				if (item.Id > -1)
				{
					item.paintItem(g, num3 + (int)MainTabNew.wOneItem / 2, num4 + (int)MainTabNew.wOneItem / 2, (int)MainTabNew.wOneItem, 0, 0);
				}
				else if (this.indexTab < 12)
				{
					g.drawRegion(MainTabNew.imgTab[6], 0, (int)b * 20, 20, 20, 0, num3 + (int)MainTabNew.wOneItem / 2, num4 + (int)MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			else if (this.indexTab < 12)
			{
				g.drawRegion(MainTabNew.imgTab[6], 0, (int)b * 20, 20, 20, 0, num3 + (int)MainTabNew.wOneItem / 2, num4 + (int)MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			}
			if (GameCanvas.isTouch)
			{
				if (this.indexTab < 12)
				{
					this.cmdnext.paint(g, this.xbegin + iCommand.wButtonCmd / 2, this.yEquip - iCommand.hButtonCmd / 2);
				}
				else
				{
					this.cmdback.paint(g, this.xbegin + iCommand.wButtonCmd / 2, this.yEquip - iCommand.hButtonCmd / 2);
				}
			}
			g.setColor(MainTabNew.color[4]);
			g.drawRect(num3, num4, this.wsize, this.wsize, mGraphics.isFalse);
			b += 1;
		}
		g.setColor(MainTabNew.color[3]);
		if (this.idSelect >= 0)
		{
			int num5 = this.xEquip + this.idSelect % this.numW * this.wsize;
			int num6 = this.yEquip + this.idSelect / this.numW * this.wsize;
			g.drawRect(num5, num6, this.wsize, this.wsize, mGraphics.isFalse);
			g.setColor(MainTabNew.color[2]);
			g.drawRect(num5 + 1, num6 + 1, this.wsize - 2, this.wsize - 2, mGraphics.isFalse);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			this.maintab.paintContent(g, false);
		}
		base.paint(g);
	}

	// Token: 0x06000619 RID: 1561 RVA: 0x0005AC74 File Offset: 0x00058E74
	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			if (this.indexTab < 12)
			{
				this.cmdnext.updatePointer();
			}
			else
			{
				this.cmdback.updatePointer();
			}
		}
		if (Info_Other_Player.showObject == null)
		{
			this.cmdClose.perform();
		}
		this.lastScreen.update();
		if (this.maintab.listContent != null)
		{
			this.maintab.listContent.moveCamera();
		}
		if (this.itemSelect != null)
		{
			this.updateContent(this.itemSelect);
		}
		if (this.maintab != null)
		{
			this.maintab.update();
		}
	}

	// Token: 0x0600061A RID: 1562 RVA: 0x0005AD20 File Offset: 0x00058F20
	public void updateContent(Item item)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				this.setPaintInfo(item);
			}
		}
		if (this.maintab.mContent == null && item != null && item.ItemCatagory != 5)
		{
			if (item.mcontent == null)
			{
				if (item.timeupdateMore % 100 == 3)
				{
					if ((int)this.maintab.typeTab == (int)MainTabNew.INVENTORY)
					{
						GlobalService.gI().Item_More_Info(0, (sbyte)item.Id);
					}
					item.timeupdateMore++;
				}
				else
				{
					item.timeupdateMore++;
				}
			}
			else
			{
				this.maintab.moreInfoconten = item.moreContenGem;
				this.maintab.mContent = item.mcontent;
				this.maintab.mcolor = item.mColor;
				this.setYCon(item);
			}
		}
	}

	// Token: 0x0600061B RID: 1563 RVA: 0x0005AE28 File Offset: 0x00059028
	public override void updatekey()
	{
		int num = this.idSelect;
		if (this.maintab.listContent != null)
		{
			if (GameCanvas.keyMyHold[2])
			{
				if (this.maintab.listContent.cmtoX > 0)
				{
					this.maintab.listContent.cmtoX -= GameCanvas.hText;
				}
				else
				{
					this.maintab.listContent.cmtoX = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				if (this.maintab.listContent.cmtoX < this.maintab.listContent.cmxLim)
				{
					this.maintab.listContent.cmtoX += GameCanvas.hText;
				}
				else
				{
					this.maintab.listContent.cmtoX = this.maintab.listContent.cmxLim;
				}
				GameCanvas.clearKeyHold(8);
			}
		}
		else if (GameCanvas.keyMyHold[2])
		{
			if (this.idSelect >= this.numW)
			{
				this.idSelect -= this.numW;
			}
			GameCanvas.clearKeyHold(2);
		}
		else if (GameCanvas.keyMyHold[8])
		{
			if (this.idSelect < TabMySeftNew.maxSize - this.numW)
			{
				this.idSelect += this.numW;
			}
			GameCanvas.clearKeyHold(8);
		}
		if (GameCanvas.keyMyHold[4])
		{
			this.idSelect--;
			GameCanvas.clearKeyHold(4);
		}
		else if (GameCanvas.keyMyHold[6])
		{
			this.idSelect++;
			GameCanvas.clearKeyHold(6);
		}
		if (num != this.idSelect)
		{
			if (this.idSelect >= 0)
			{
				this.idSelect = (int)((sbyte)base.resetSelect(this.idSelect, TabMySeftNew.maxSize - 1, false));
				MainTabNew.timePaintInfo = 0;
				this.itemSelect = (Item)Info_Other_Player.vecEquipShow.get(string.Empty + (this.idSelect + this.indexTab));
			}
			else
			{
				this.idSelect = -1;
			}
			this.maintab.listContent = null;
		}
		base.updatekey();
	}

	// Token: 0x0600061C RID: 1564 RVA: 0x0005B070 File Offset: 0x00059270
	public void setPaintInfo(Item item)
	{
		if (this.idSelect < 0)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		this.maintab.mContent = null;
		this.maintab.mSubContent = null;
		this.maintab.mPlusContent = null;
		int num = this.idSelect;
		if (item == null)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		this.maintab.wContent = item.sizeW;
		this.maintab.xCon = this.xEquip + num % this.numW * this.wsize + (int)MainTabNew.wOneItem / 2 - this.maintab.wContent / 2;
		if (this.maintab.xCon < 0)
		{
			this.maintab.xCon = 0;
		}
		if (this.maintab.xCon + this.maintab.wContent > GameCanvas.w)
		{
			this.maintab.xCon = GameCanvas.w - this.maintab.wContent;
		}
		this.setYCon(item);
		this.maintab.name = item.itemName;
		this.maintab.mPlusContent = item.mPlusContent;
		this.maintab.mPlusColor = item.mPlusColor;
		this.maintab.colorName = item.colorNameItem;
		this.maintab.moreInfoconten = item.moreContenGem;
	}

	// Token: 0x0600061D RID: 1565 RVA: 0x0005B1DC File Offset: 0x000593DC
	public void setYCon(Item item)
	{
		int num = 2;
		this.maintab.mContent = item.mcontent;
		this.maintab.moreInfoconten = item.moreContenGem;
		this.maintab.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num += item.mcontent.Length;
		}
		if (item.mPlusContent != null)
		{
			num += item.mPlusContent.Length;
		}
		int num2 = this.idSelect;
		this.maintab.yCon = this.yEquip + (num2 / this.numW + 1) * this.wsize;
		if (GameCanvas.isTouch)
		{
			if (this.maintab.yCon + num * GameCanvas.hText > GameCanvas.h)
			{
				this.maintab.yCon = GameCanvas.h - num * GameCanvas.hText;
			}
		}
		else if (this.maintab.yCon + num * GameCanvas.hText > GameCanvas.h - iCommand.hButtonCmd)
		{
			this.maintab.yCon = GameCanvas.h - iCommand.hButtonCmd - num * GameCanvas.hText;
		}
		if ((int)this.type == (int)Info_Other_Player.THACH_DAU && GameCanvas.isTouch && this.maintab.yCon + num * GameCanvas.hText > this.ybegin + this.wScreen)
		{
			this.maintab.yCon = this.ybegin + this.wScreen - num * GameCanvas.hText;
		}
		this.maintab.listContent = null;
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			this.maintab.listContent = new ListNew(this.maintab.xCon, this.maintab.yCon, this.maintab.wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
		if ((int)item.can_sell_for_other_player == 1)
		{
			this.maintab.wContent += iCommand.wButtonCmd / 2;
			this.maintab.cmd = this.cmdBuyFastionItem;
		}
		else
		{
			this.maintab.cmd = null;
			this.maintab.xpos_cmd = 0;
			this.maintab.ypos_cmd = 0;
		}
	}

	// Token: 0x0600061E RID: 1566 RVA: 0x0005B420 File Offset: 0x00059620
	public override void updatePointer()
	{
		bool flag = false;
		if (this.maintab.listContent != null && GameCanvas.isPoint(this.maintab.listContent.x, this.maintab.listContent.y, this.maintab.listContent.maxW, this.maintab.listContent.maxH))
		{
			this.maintab.listContent.update_Pos_UP_DOWN();
		}
		if (!flag)
		{
			if (GameCanvas.isPointSelect(this.xEquip, this.yEquip, this.wsize * this.numW, this.wsize * this.numH))
			{
				GameCanvas.isPointerSelect = false;
				sbyte b = (sbyte)((GameCanvas.px - this.xEquip) / this.wsize + (GameCanvas.py - this.yEquip) / this.wsize * this.numW);
				if ((int)b >= 0 && (int)b < TabMySeftNew.maxSize)
				{
					if ((int)b != this.idSelect)
					{
						this.idSelect = (int)b;
						MainTabNew.timePaintInfo = 0;
						this.itemSelect = (Item)Info_Other_Player.vecEquipShow.get(string.Empty + (this.idSelect + this.indexTab));
						this.maintab.listContent = null;
					}
				}
			}
			if (GameCanvas.isPointerSelect && GameCanvas.isPoint(this.xbegin + this.wScreen / 2 - 25, this.ybegin + 90 - 60, 50, 70))
			{
				this.cmdMenu.perform();
				GameCanvas.isPointerSelect = false;
			}
		}
		base.updatePointer();
	}

	// Token: 0x040008A9 RID: 2217
	public static PetItem showPet = new PetItem();

	// Token: 0x040008AA RID: 2218
	public static MainObject showObject = new MainObject();

	// Token: 0x040008AB RID: 2219
	public static mHashTable vecEquipShow = new mHashTable();

	// Token: 0x040008AC RID: 2220
	private int xbegin;

	// Token: 0x040008AD RID: 2221
	private int ybegin;

	// Token: 0x040008AE RID: 2222
	private int wScreen;

	// Token: 0x040008AF RID: 2223
	private int numW;

	// Token: 0x040008B0 RID: 2224
	private int numH;

	// Token: 0x040008B1 RID: 2225
	private int hitem;

	// Token: 0x040008B2 RID: 2226
	private int idSelect;

	// Token: 0x040008B3 RID: 2227
	private int xEquip;

	// Token: 0x040008B4 RID: 2228
	private int yEquip;

	// Token: 0x040008B5 RID: 2229
	private iCommand cmdClose;

	// Token: 0x040008B6 RID: 2230
	private iCommand cmdMenu;

	// Token: 0x040008B7 RID: 2231
	private iCommand cmdChat;

	// Token: 0x040008B8 RID: 2232
	private iCommand cmdAddF;

	// Token: 0x040008B9 RID: 2233
	private iCommand cmdParty;

	// Token: 0x040008BA RID: 2234
	private iCommand cmdBuy_Sell;

	// Token: 0x040008BB RID: 2235
	private iCommand cmdOkThachDau;

	// Token: 0x040008BC RID: 2236
	private iCommand cmdThachDau;

	// Token: 0x040008BD RID: 2237
	private iCommand cmdBuyFastionItem;

	// Token: 0x040008BE RID: 2238
	private iCommand cmdback;

	// Token: 0x040008BF RID: 2239
	private iCommand cmdnext;

	// Token: 0x040008C0 RID: 2240
	private MainTabNew maintab;

	// Token: 0x040008C1 RID: 2241
	public static sbyte VIEW = 0;

	// Token: 0x040008C2 RID: 2242
	public static sbyte THACH_DAU = 1;

	// Token: 0x040008C3 RID: 2243
	public static sbyte THACH_DAU_INFO = 100;

	// Token: 0x040008C4 RID: 2244
	private sbyte type;

	// Token: 0x040008C5 RID: 2245
	private int wsize;

	// Token: 0x040008C6 RID: 2246
	private int indexTab;

	// Token: 0x040008C7 RID: 2247
	private Item itemSelect;
}
