using System;

// Token: 0x020000C1 RID: 193
public class Menu2 : AvMain
{
	// Token: 0x0600096D RID: 2413 RVA: 0x00097E2C File Offset: 0x0009602C
	public bool isNgua(short id)
	{
		return id == 62 || id == 63 || id == 64 || id == 65 || id == 66;
	}

	// Token: 0x0600096E RID: 2414 RVA: 0x00097E64 File Offset: 0x00096064
	public void startAt(mVector menuItems, int pos, string name, bool isFocus, mVector mfocus)
	{
		Menu2.isLoadData = false;
		this.waitToPerform = 0;
		this.runText = null;
		this.right = null;
		Menu2.isNPCMenu = 0;
		Menu2.isGiaotiep = isFocus;
		this.vecFocus = mfocus;
		this.SelectFocus = 0;
		if (Menu2.isGiaotiep && (this.vecFocus == null || this.vecFocus.size() == 0))
		{
			return;
		}
		this.nameMenu = name;
		Menu2.isHelp = false;
		this.disableClose = false;
		this.menuSelectedItem = 0;
		this.pos = pos;
		if (menuItems == null || menuItems.size() == 0)
		{
			return;
		}
		this.menuItems = menuItems;
		this.isShowMenu = true;
		if (pos == -1)
		{
			this.menuItems.addElement(new iCommand(T.close, 1, this));
			this.hPlus = 0;
			this.menuW = 60;
			this.menuH = 60;
			for (int i = 0; i < menuItems.size(); i++)
			{
				iCommand iCommand = (iCommand)menuItems.elementAt(i);
				int width = mFont.tahoma_7_yellow.getWidth(iCommand.caption);
				if (width > this.menuW - 8)
				{
					iCommand.subCaption = mFont.tahoma_7b_yellow.splitFontArray(iCommand.caption, this.menuW - 8);
				}
			}
			this.w = menuItems.size() * this.menuW - 1;
			if (this.w > GameCanvas.w - 2)
			{
				this.w = GameCanvas.w - 2;
			}
			this.menuX = GameCanvas.hw - this.w / 2;
			if (this.menuX < 1)
			{
				this.menuX = 1;
			}
			this.menuY = GameCanvas.h - this.menuH - (GameCanvas.hCommand + 1);
			if (GameCanvas.isTouch)
			{
				this.menuY -= 3;
			}
			this.menuY += 27;
			this.menuTemY = this.menuY;
			Menu2.cmxLim = this.menuItems.size() * this.menuW - GameCanvas.w;
			if (Menu2.cmxLim < 0)
			{
				Menu2.cmxLim = 0;
			}
			Menu2.cmtoX = 0;
			Menu2.cmx = 0;
			Menu2.xc = 50;
		}
		else
		{
			if (Menu2.isGiaotiep)
			{
				Menu2.objSelect = (MainObject)this.vecFocus.elementAt(0);
			}
			this.menuW = GameCanvas.hCommand;
			if (GameCanvas.isTouch)
			{
				this.menuW = 32;
			}
			this.sizeMenu = GameCanvas.h / 4 * 3 / this.menuW - ((!isFocus) ? 1 : 2);
			if (GameCanvas.isTouch)
			{
				this.sizeMenu++;
			}
			this.w = GameCanvas.w / 3;
			if (this.w < mFont.tahoma_7b_white.getWidth(name) + 30)
			{
				this.w = mFont.tahoma_7b_white.getWidth(name) + 30;
			}
			this.hPlus = GameCanvas.hCommand;
			if (isFocus)
			{
				this.hPlus += this.menuW;
			}
			int num = 120;
			int num2 = 30;
			if (isFocus)
			{
				num2 = 50;
			}
			for (int j = 0; j < menuItems.size(); j++)
			{
				iCommand iCommand2 = (iCommand)menuItems.elementAt(j);
				int num3 = mFont.tahoma_7b_white.getWidth(iCommand2.caption) + num2;
				if (num3 > num)
				{
					num = num3;
				}
			}
			if (this.w < num)
			{
				this.w = num;
			}
			if (this.w > GameCanvas.w)
			{
				this.w = GameCanvas.w;
			}
			Menu2.cmtoX = 0;
			Menu2.cmx = 0;
			iCommand iCommand3 = null;
			if (GameCanvas.isTouch)
			{
				iCommand3 = new iCommand(T.close, 1, this);
			}
			else
			{
				this.menuItems.addElement(new iCommand(T.close, 1, this));
			}
			if (menuItems.size() > this.sizeMenu)
			{
				this.menuH = this.sizeMenu * this.menuW + 8;
				Menu2.cmxLim = (menuItems.size() - this.sizeMenu) * this.menuW;
			}
			else
			{
				this.menuH = menuItems.size() * this.menuW + 8;
				Menu2.cmxLim = 0;
			}
			this.setPos();
			this.menuTemY = this.menuY;
			if (iCommand3 != null)
			{
				iCommand3.setPos(this.menuX + this.w - 11, this.menuY - this.hPlus + GameCanvas.hCommand / 2 - 2, PaintInfoGameScreen.fraCloseMenu, string.Empty);
				this.right = iCommand3;
			}
		}
		if (GameCanvas.isTouch)
		{
			this.menuSelectedItem = -1;
		}
		Menu2.isLoadData = true;
		this.resetBegin();
	}

	// Token: 0x0600096F RID: 2415 RVA: 0x00098310 File Offset: 0x00096510
	public void setinfoDynamic(mVector menulist, int pos, int idmenu, int idnpc, string name)
	{
		Menu2.isLoadData = false;
		this.waitToPerform = 0;
		this.right = null;
		this.runText = null;
		Menu2.isGiaotiep = false;
		this.vecFocus = null;
		if (menulist == null)
		{
			return;
		}
		this.nameMenu = name;
		Menu2.isHelp = false;
		Menu2.isNPCMenu = 0;
		this.menuSelectedItem = 0;
		this.IdMenu = idmenu;
		this.IdNpc = idnpc;
		this.pos = pos;
		this.disableClose = false;
		this.isShowMenu = true;
		this.menuItems = new mVector("Menu2 menuItem2");
		this.menuW = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			this.menuW = 32;
		}
		this.sizeMenu = GameCanvas.h / 4 * 3 / this.menuW - 1;
		if (GameCanvas.isTouch)
		{
			this.sizeMenu++;
		}
		this.w = GameCanvas.w / 3;
		this.hPlus = this.menuW;
		int num = 120;
		if (num < mFont.tahoma_7b_white.getWidth(name) + 30)
		{
			num = mFont.tahoma_7b_white.getWidth(name) + 30;
		}
		for (int i = 0; i < menulist.size(); i++)
		{
			iCommand iCommand = (iCommand)menulist.elementAt(i);
			iCommand o = new iCommand(iCommand.caption, 2, this);
			int num2 = mFont.tahoma_7b_white.getWidth(iCommand.caption) + 20;
			if (num2 > num)
			{
				num = num2;
			}
			this.menuItems.addElement(o);
		}
		iCommand iCommand2 = null;
		if (GameCanvas.isTouch)
		{
			iCommand2 = new iCommand(T.close, 1, this);
		}
		else
		{
			this.menuItems.addElement(new iCommand(T.close, 1, this));
		}
		this.w = num;
		if (this.w > GameCanvas.w)
		{
			this.w = GameCanvas.w;
		}
		if (this.menuItems.size() > this.sizeMenu)
		{
			this.menuH = this.sizeMenu * this.menuW + 8;
			Menu2.cmxLim = (this.menuItems.size() - this.sizeMenu) * this.menuW;
		}
		else
		{
			this.menuH = this.menuItems.size() * this.menuW + 8;
			Menu2.cmxLim = 0;
		}
		Menu2.cmtoX = 0;
		Menu2.cmx = 0;
		this.setPos();
		this.menuTemY = this.menuY;
		if (iCommand2 != null)
		{
			iCommand2.setPos(this.menuX + this.w - 11, this.menuY - this.hPlus + GameCanvas.hCommand / 2 - 2, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.right = iCommand2;
		}
		if (GameCanvas.isTouch)
		{
			this.menuSelectedItem = -1;
		}
		Menu2.isLoadData = true;
		this.resetBegin();
	}

	// Token: 0x06000970 RID: 2416 RVA: 0x000985D0 File Offset: 0x000967D0
	public void startAt_NPC(mVector menuItems, string name, int idNPC, sbyte typeO, bool isQuest, int archor)
	{
		Menu2.isLoadData = false;
		this.waitToPerform = 0;
		this.right = null;
		Menu2.isNPCMenu = 1;
		this.SelectFocus = 0;
		this.nameMenu = name;
		Menu2.isHelp = false;
		this.disableClose = false;
		Menu2.isGiaotiep = false;
		this.IdNpc = idNPC;
		Menu2.IdNPCLast = idNPC;
		this.typeO = typeO;
		this.archorRunText = archor;
		this.menuSelectedItem = 0;
		if (menuItems == null || menuItems.size() == 0)
		{
			this.menuItems = new mVector("Menu2 menuItem3");
		}
		else
		{
			this.menuItems = menuItems;
		}
		this.isShowMenu = true;
		this.menuW = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			this.menuW = 32;
		}
		this.sizeMenu = 0;
		this.w = GameCanvas.w - 10;
		if (this.w > 300)
		{
			this.w = 300;
		}
		this.mStrTalk = mFont.tahoma_7_black.splitFontArray(name, this.w - 20);
		this.hPlus = GameCanvas.hCommand;
		Menu2.cmtoX = 0;
		Menu2.cmx = 0;
		int num = this.mStrTalk.Length;
		if (!isQuest)
		{
			this.menuItems.addElement(new iCommand(T.close, 1, this));
		}
		else if (num == 1)
		{
			num = 2;
		}
		this.menuH = (num + 2) * GameCanvas.hText + ((this.menuItems.size() - 1) / 2 + 1) * (iCommand.hButtonCmd + 5) + 5;
		Menu2.cmxLim = 0;
		this.menuX = GameCanvas.hw - this.w / 2;
		this.menuY = GameCanvas.h - this.menuH - 10;
		this.menuTemY = this.menuY;
		this.runText = new RunWord();
		this.runText.startDialogChain(name, 0, this.menuX + 10, this.menuY + 10 + GameCanvas.hText, this.w - 20, mFont.tahoma_7_white);
		this.setPosNPC();
		if (GameCanvas.isTouch)
		{
			this.menuSelectedItem = -1;
		}
		Menu2.isLoadData = true;
		this.resetBegin();
	}

	// Token: 0x06000971 RID: 2417 RVA: 0x000987EC File Offset: 0x000969EC
	public void setAt_Quick()
	{
		this.isPosPoint = PaintInfoGameScreen.isLevelPoint;
		this.timeShow = 1;
		Menu2.isLoadData = false;
		this.waitToPerform = 0;
		this.right = null;
		Menu2.isNPCMenu = 2;
		this.SelectFocus = 0;
		this.nameMenu = string.Empty;
		Menu2.isHelp = false;
		this.disableClose = false;
		Menu2.isGiaotiep = false;
		this.menuSelectedItem = 0;
		this.w = GameCanvas.w - 40;
		this.isShowMenu = true;
		this.menuW = 40;
		Menu2.cmtoX = 0;
		Menu2.cmx = 0;
		this.hShow = 0;
		this.menuH = 40;
		this.maxShow = (int)((sbyte)(this.w / this.menuH));
		this.menuItems = new mVector("Menu2 menuItems");
		iCommand o = new iCommand(T.auto, 3, 2, this);
		iCommand o2 = new iCommand(T.dosat, 4, 4, this);
		iCommand o3 = new iCommand(T.setPk, 5, 3, this);
		iCommand o4 = new iCommand(T.mevent, 6, 0, this);
		iCommand o5 = new iCommand(T.listFriend, 7, 1, this);
		this.cmdNgua = new iCommand(T.TuseNgua, 14, 10, this);
		if (Main.isPC)
		{
			this.cmdChangeScreen = new iCommand(T.changeScrennSmall, 8, 5, this);
			if (Main.level == 1)
			{
				this.cmdChangeScreen.caption = T.normalScreen;
			}
			else
			{
				this.cmdChangeScreen.caption = ((mGraphics.zoomLevel != 1) ? T.changeScrennSmall : T.normalScreen);
			}
		}
		else
		{
			this.cmdTouch = new iCommand(T.touch + "/" + T.keypad, 8, 5, this);
		}
		iCommand o6 = new iCommand(T.naptien, 11, 9, this);
		iCommand o7 = new iCommand(T.logout, 12, 8, this);
		this.menuItems.addElement(this.cmdNgua);
		this.menuItems.addElement(o4);
		this.menuItems.addElement(o5);
		if (GameScreen.player.myClan != null)
		{
			iCommand o8 = new iCommand(T.clan, 9, 6, this);
			this.menuItems.addElement(o8);
		}
		if (Player.party != null)
		{
			iCommand o9 = new iCommand(T.party, 10, 7, this);
			this.menuItems.addElement(o9);
		}
		this.menuItems.addElement(o);
		this.menuItems.addElement(o3);
		if (!mSystem.isHideNaptien())
		{
			this.menuItems.addElement(o6);
		}
		this.menuItems.addElement(o2);
		if (Main.isPC)
		{
			this.menuItems.addElement(this.cmdChangeScreen);
		}
		else
		{
			this.menuItems.addElement(this.cmdTouch);
		}
		this.menuItems.addElement(o7);
		if (this.maxShow > this.menuItems.size())
		{
			this.maxShow = this.menuItems.size();
		}
		this.w = this.maxShow * this.menuH;
		Menu2.cmxLim = 0;
		if (!this.isPosPoint)
		{
			this.menuX = GameCanvas.hw - this.w / 2;
		}
		else
		{
			this.menuX = 20;
		}
		this.menuY = GameCanvas.h - 40;
		this.menuTemY = this.menuY;
		if (GameCanvas.isTouch)
		{
			this.menuSelectedItem = -1;
		}
		Menu2.isLoadData = true;
		for (int i = 0; i < this.menuItems.size(); i++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
			iCommand.setPos_ShowName(this.menuX + this.menuH / 2 + i * this.menuH, this.menuY + this.menuH / 2, PaintInfoGameScreen.mfraIconQuick[(int)iCommand.subIndex], iCommand.caption, 0, -32);
		}
		Menu2.cmxLim = (this.menuItems.size() - this.maxShow) * this.menuH;
		this.menuSelectedItem = -1;
		this.resetBegin();
	}

	// Token: 0x06000972 RID: 2418 RVA: 0x00098BF0 File Offset: 0x00096DF0
	public void resetBegin()
	{
		for (int i = 0; i < this.pointerDownLastX.Length; i++)
		{
			this.pointerDownLastX[i] = 0;
		}
		this.pointerDownTime = 0;
		this.pointerDownFirstX = 0;
		this.pointerIsDowning = false;
		this.isDownWhenRunning = false;
		this.waitToPerform = 0;
		this.cmRun = 0;
	}

	// Token: 0x06000973 RID: 2419 RVA: 0x00098C4C File Offset: 0x00096E4C
	public void setPosNPC()
	{
		int num = this.menuItems.size();
		if (num == 1)
		{
			this.xBegin = this.menuX + this.w / 2;
			this.w2cmd = 0;
		}
		else if (num == 2)
		{
			this.w2cmd = 20;
			this.xBegin = this.menuX + this.w / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
		}
		else
		{
			this.w2cmd = 20;
			this.xBegin = this.menuX + this.w / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
		}
		for (int i = 0; i < num; i++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
			if (num == 3 && i == 2)
			{
				iCommand.setPos(this.menuX + this.w / 2, this.menuY + this.menuH - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5), null, iCommand.caption);
			}
			else
			{
				iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), this.menuY + this.menuH - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5), null, iCommand.caption);
			}
			if (i == 0)
			{
				iCommand.isSelect = true;
			}
		}
	}

	// Token: 0x06000974 RID: 2420 RVA: 0x00098DD8 File Offset: 0x00096FD8
	public void setPos()
	{
		switch (this.pos)
		{
		case 0:
			this.menuX = 2;
			this.menuY = GameCanvas.h - GameCanvas.hCommand - this.menuH - 2;
			if (GameCanvas.isTouch)
			{
				this.menuY += GameCanvas.hCommand;
			}
			break;
		case 1:
			this.menuX = GameCanvas.w - this.w - 2;
			this.menuY = GameCanvas.h - GameCanvas.hCommand - this.menuH - 2;
			if (GameCanvas.isTouch)
			{
				this.menuY += GameCanvas.hCommand;
			}
			break;
		case 2:
		case 4:
			this.menuX = GameCanvas.hw - this.w / 2;
			this.menuY = GameCanvas.h / 2 - this.menuH / 2 - 2 + this.menuW / 2 + 6;
			break;
		case 3:
			this.menuX = 2;
			this.menuY = 2;
			break;
		}
	}

	// Token: 0x06000975 RID: 2421 RVA: 0x00098EEC File Offset: 0x000970EC
	public override void commandPointer(int index, int subIndex)
	{
		mVector vecInvetoryPlayer = Item.VecInvetoryPlayer;
		switch (index)
		{
		case 0:
		{
			this.isShowMenu = false;
			iCommand cmd = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
			this.perform(cmd);
			break;
		}
		case 1:
			this.doCloseMenu();
			break;
		case 2:
			GlobalService.gI().Dynamic_Menu((short)this.IdNpc, (sbyte)this.IdMenu, (sbyte)this.menuSelectedItem);
			this.isShowMenu = false;
			GameCanvas.isPointerSelect = false;
			break;
		case 3:
			this.isShowMenu = false;
			GameScreen.gI().doMenuAuto();
			break;
		case 4:
			this.isShowMenu = false;
			GameScreen.gI().cmdSetDoSat.perform();
			break;
		case 5:
			this.isShowMenu = false;
			GameScreen.gI().cmdSetPk.perform();
			break;
		case 6:
			this.isShowMenu = false;
			TabConfig.cmdEvent.perform();
			break;
		case 7:
			GameScreen.gI().cmdListFriend.perform();
			break;
		case 8:
			if (Main.isPC)
			{
				GameCanvas.start_Left_Dialog(T.changeSizeScreen, new iCommand(T.select, 13, this));
			}
			else
			{
				TabConfig.cmdKeypad.perform();
			}
			break;
		case 9:
			TabConfig.cmdShowClan.perform();
			break;
		case 10:
			GameScreen.gI().cmdParty.perform();
			break;
		case 11:
			if (Main.isWP8)
			{
				Main.naptienWP8();
			}
			else if (Main.IphoneVersionApp)
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			else
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		case 12:
			Main.exit2();
			break;
		case 13:
			if (mGraphics.zoomLevel > 1)
			{
				Rms.saveRMSInt("levelScreenKN", 1);
			}
			else
			{
				Rms.saveRMSInt("levelScreenKN", 0);
			}
			Main.exit();
			break;
		case 14:
		{
			mVector mVector = new mVector("Menu2 vecngua");
			this.isShowMenu = false;
			if ((int)GameScreen.player.typeMount != -1)
			{
				TabConfig.cmdXuongNgua.perform();
			}
			else
			{
				for (int i = 0; i < vecInvetoryPlayer.size(); i++)
				{
					MainItem mainItem = (MainItem)vecInvetoryPlayer.elementAt(i);
					if (mainItem != null && mainItem.ItemCatagory == 4 && this.isNgua((short)mainItem.Id))
					{
						mVector.addElement(mainItem);
					}
				}
				if (mVector.size() > 0)
				{
					GameScreen.gI().doMenuUseNgua(mVector);
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.khongcongua);
				}
			}
			break;
		}
		case 20:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][0], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 21:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][1], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 22:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][2], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 23:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][3], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 24:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][4], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		case 25:
			GameCanvas.start_Left_Dialog(TabConfig.me.itemID[1][5], new iCommand(T.buy, index + TabConfig.me.itemID[0].Length, this));
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000976 RID: 2422 RVA: 0x0009935C File Offset: 0x0009755C
	public void updateMenuKey()
	{
		if (!Menu2.isPaint)
		{
			return;
		}
		if (!this.isShowMenu)
		{
			return;
		}
		bool flag = false;
		if (Menu2.isGiaotiep)
		{
			if (GameCanvas.keyMyPressed[2])
			{
				flag = true;
				this.menuSelectedItem--;
				if (this.menuSelectedItem < 0)
				{
					this.menuSelectedItem = this.menuItems.size() - 1;
				}
				GameCanvas.clearKeyPressed(2);
			}
			else if (GameCanvas.keyMyPressed[8])
			{
				flag = true;
				this.menuSelectedItem++;
				if (this.menuSelectedItem > this.menuItems.size() - 1)
				{
					this.menuSelectedItem = 0;
				}
				GameCanvas.clearKeyPressed(8);
			}
			int selectFocus = this.SelectFocus;
			if (GameCanvas.keyMyPressed[4])
			{
				this.SelectFocus--;
				GameCanvas.clearKeyPressed(4);
			}
			if (GameCanvas.keyMyPressed[6])
			{
				this.SelectFocus++;
				GameCanvas.clearKeyPressed(6);
			}
			this.SelectFocus = base.resetSelect(this.SelectFocus, this.vecFocus.size() - 1, true);
			if (this.SelectFocus != selectFocus)
			{
				Menu2.objSelect = (MainObject)this.vecFocus.elementAt(this.SelectFocus);
			}
		}
		else if ((int)Menu2.isNPCMenu == 1)
		{
			int num = this.menuSelectedItem;
			if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[2])
			{
				this.menuSelectedItem--;
				GameCanvas.clearKeyHold(4);
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[8])
			{
				this.menuSelectedItem++;
				GameCanvas.clearKeyHold(6);
				GameCanvas.clearKeyHold(8);
			}
			this.menuSelectedItem = base.resetSelect(this.menuSelectedItem, this.menuItems.size() - 1, false);
			if (num != this.menuSelectedItem)
			{
				for (int i = 0; i < this.menuItems.size(); i++)
				{
					iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
					if (i == this.menuSelectedItem)
					{
						iCommand.isSelect = true;
					}
					else
					{
						iCommand.isSelect = false;
					}
				}
			}
			if (GameCanvas.keyMyHold[5])
			{
				GameCanvas.clearKeyHold(5);
				if (this.menuSelectedItem < this.menuItems.size() && this.menuSelectedItem >= 0)
				{
					((iCommand)this.menuItems.elementAt(this.menuSelectedItem)).perform();
				}
			}
		}
		else if ((int)Menu2.isNPCMenu == 0)
		{
			if (GameCanvas.keyMyPressed[2] || GameCanvas.keyMyPressed[4])
			{
				flag = true;
				this.menuSelectedItem--;
				if (this.menuSelectedItem < 0)
				{
					this.menuSelectedItem = this.menuItems.size() - 1;
				}
				GameCanvas.clearKeyPressed(2);
				GameCanvas.clearKeyPressed(4);
			}
			else if (GameCanvas.keyMyPressed[8] || GameCanvas.keyMyPressed[6])
			{
				flag = true;
				this.menuSelectedItem++;
				if (this.menuSelectedItem > this.menuItems.size() - 1)
				{
					this.menuSelectedItem = 0;
				}
				GameCanvas.clearKeyPressed(6);
				GameCanvas.clearKeyPressed(8);
			}
		}
		if (flag)
		{
			if (this.pos == -1)
			{
				Menu2.cmtoX = this.menuSelectedItem * this.menuW + this.menuW - GameCanvas.w / 2;
			}
			else
			{
				Menu2.cmtoX = (this.menuSelectedItem + 1) * this.menuW - this.menuH / 2;
			}
			if (Menu2.cmtoX > Menu2.cmxLim)
			{
				Menu2.cmtoX = Menu2.cmxLim;
			}
			if (Menu2.cmtoX < 0)
			{
				Menu2.cmtoX = 0;
			}
			if (this.menuSelectedItem == this.menuItems.size() - 1 || this.menuSelectedItem == 0)
			{
				Menu2.cmx = Menu2.cmtoX;
			}
		}
		if ((int)Menu2.isNPCMenu == 0)
		{
			if (this.pos == -1)
			{
				this.updatePos_LEFT_RIGHT();
			}
			else
			{
				this.update_Pos_UP_DOWN();
			}
			if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.menuX - 5, this.menuTemY - 5 - this.hPlus, this.w + 10, this.menuH + 10 + this.hPlus))
			{
				this.doCloseMenu();
			}
		}
		else if ((int)Menu2.isNPCMenu == 2)
		{
			this.updatePos_LEFT_RIGHT();
			if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.menuX - 5, this.menuY - 5, this.w + 10, this.menuH + 10))
			{
				this.timeShow = -1;
			}
		}
		base.updatekey();
	}

	// Token: 0x06000977 RID: 2423 RVA: 0x00099820 File Offset: 0x00097A20
	public void updatePos_LEFT_RIGHT()
	{
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(this.menuX, this.menuY, this.w, this.menuH))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.px;
				}
				this.pointerDownFirstX = GameCanvas.px;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					this.menuSelectedItem = (Menu2.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
				}
				int num = GameCanvas.px - this.pointerDownLastX[0];
				if (num != 0 && this.menuSelectedItem != -1)
				{
					this.menuSelectedItem = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.px;
				Menu2.cmtoX -= num;
				if (Menu2.cmtoX < 0)
				{
					Menu2.cmtoX = 0;
				}
				if (Menu2.cmtoX > Menu2.cmxLim)
				{
					Menu2.cmtoX = Menu2.cmxLim;
				}
				if (Menu2.cmx < 0 || Menu2.cmx > Menu2.cmxLim)
				{
					num /= 2;
				}
				Menu2.cmx -= num;
			}
		}
		if (GameCanvas.isPointerClick && this.pointerIsDowning)
		{
			int a = GameCanvas.px - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				Menu2.cmtoX = Menu2.cmx;
				this.pointerDownFirstX = -1000;
				this.menuSelectedItem = (Menu2.cmtoX + GameCanvas.px - this.menuX) / this.menuW;
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.menuSelectedItem != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.menuSelectedItem == -1 && !this.isDownWhenRunning)
			{
				if (Menu2.cmx < 0)
				{
					Menu2.cmtoX = 0;
				}
				else if (Menu2.cmx > Menu2.cmxLim)
				{
					Menu2.cmtoX = Menu2.cmxLim;
				}
				else
				{
					int num2 = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num2 > 10)
					{
						num2 = 10;
					}
					else if (num2 < -10)
					{
						num2 = -10;
					}
					else
					{
						num2 = 0;
					}
					this.cmRun = -num2 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
		if (GameCanvas.isPointerRelease && this.pointerIsDowning)
		{
			this.pointerIsDowning = false;
		}
	}

	// Token: 0x06000978 RID: 2424 RVA: 0x00099B9C File Offset: 0x00097D9C
	private void update_Pos_UP_DOWN()
	{
		if (GameCanvas.keyMyPressed[5])
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			this.doCloseMenu();
			iCommand cmd = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
			this.perform(cmd);
		}
		else if (GameCanvas.keyMyPressed[12])
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			this.doCloseMenu();
			iCommand cmd2 = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
			this.perform(cmd2);
		}
		if (GameCanvas.isPointerSelect && Menu2.isGiaotiep)
		{
			int selectFocus = this.SelectFocus;
			if (GameCanvas.isPoint(this.menuX + 13 - 14, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 2 - 14, 28, 28))
			{
				this.SelectFocus--;
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.isPoint(this.menuX + this.w - 13 - 14, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 2 - 14, 28, 28))
			{
				this.SelectFocus++;
				GameCanvas.isPointerSelect = false;
			}
			this.SelectFocus = base.resetSelect(this.SelectFocus, this.vecFocus.size() - 1, true);
			if (this.SelectFocus != selectFocus)
			{
				Menu2.objSelect = (MainObject)this.vecFocus.elementAt(this.SelectFocus);
			}
		}
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(this.menuX, this.menuY, this.w, this.menuH))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					this.menuSelectedItem = (Menu2.cmtoX + GameCanvas.py - this.menuY) / this.menuW;
				}
				int num = GameCanvas.py - this.pointerDownLastX[0];
				if (num != 0 && this.menuSelectedItem != -1)
				{
					this.menuSelectedItem = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.py;
				Menu2.cmtoX -= num;
				if (Menu2.cmtoX < 0)
				{
					Menu2.cmtoX = 0;
				}
				if (Menu2.cmtoX > Menu2.cmxLim)
				{
					Menu2.cmtoX = Menu2.cmxLim;
				}
				if (Menu2.cmx < 0 || Menu2.cmx > Menu2.cmxLim)
				{
					num /= 2;
				}
				Menu2.cmx -= num;
			}
		}
		if (GameCanvas.isPointerClick && this.pointerIsDowning)
		{
			int a = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning && GameCanvas.isPointerSelect)
			{
				this.cmRun = 0;
				Menu2.cmtoX = Menu2.cmx;
				this.pointerDownFirstX = -1000;
				this.menuSelectedItem = (Menu2.cmtoX + GameCanvas.py - this.menuY) / this.menuW;
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.menuSelectedItem != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.menuSelectedItem == -1 && !this.isDownWhenRunning)
			{
				if (Menu2.cmx < 0)
				{
					Menu2.cmtoX = 0;
				}
				else if (Menu2.cmx > Menu2.cmxLim)
				{
					Menu2.cmtoX = Menu2.cmxLim;
				}
				else
				{
					int num2 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num2 > 10)
					{
						num2 = 10;
					}
					else if (num2 < -10)
					{
						num2 = -10;
					}
					else
					{
						num2 = 0;
					}
					this.cmRun = -num2 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
		if (GameCanvas.isPointerRelease && this.pointerIsDowning)
		{
			this.pointerIsDowning = false;
		}
	}

	// Token: 0x06000979 RID: 2425 RVA: 0x0009A0AC File Offset: 0x000982AC
	public void moveCamera()
	{
		if (this.cmRun != 0 && !this.pointerIsDowning)
		{
			Menu2.cmtoX += this.cmRun / 100;
			if (Menu2.cmtoX < 0)
			{
				Menu2.cmtoX = 0;
			}
			else if (Menu2.cmtoX > Menu2.cmxLim)
			{
				Menu2.cmtoX = Menu2.cmxLim;
			}
			else
			{
				Menu2.cmx = Menu2.cmtoX;
			}
			this.cmRun = this.cmRun * 9 / 10;
			if (this.cmRun < 100 && this.cmRun > -100)
			{
				this.cmRun = 0;
			}
		}
		if (Menu2.cmx != Menu2.cmtoX && !this.pointerIsDowning)
		{
			this.cmvx = Menu2.cmtoX - Menu2.cmx << 2;
			this.cmdx += this.cmvx;
			Menu2.cmx += this.cmdx >> 4;
			this.cmdx &= 15;
		}
	}

	// Token: 0x0600097A RID: 2426 RVA: 0x0009A1B8 File Offset: 0x000983B8
	public void paintMenu(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (!Menu2.isLoadData)
		{
			return;
		}
		if ((int)Menu2.isNPCMenu == 1)
		{
			this.paint_NPC_MENU(g);
		}
		else if ((int)Menu2.isNPCMenu == 0)
		{
			AvMain.paintDialog(g, this.menuX - 6, this.menuTemY - this.hPlus - 6, this.w + 12, this.menuH + this.hPlus + 12, 0);
			AvMain.paintRectNice(g, this.menuX, this.menuTemY, this.w, this.menuH, 2);
			mFont.tahoma_7b_black.drawString(g, this.nameMenu, this.menuX + this.w / 2, this.menuTemY - this.hPlus + GameCanvas.hCommand / 4, 2, mGraphics.isTrue);
			if (Menu2.isGiaotiep)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.menuX, this.menuY - this.hPlus + GameCanvas.hCommand + 2, this.w, this.menuW - 4, 1);
				}
				else
				{
					for (int i = 0; i <= this.w / 32; i++)
					{
						if (i < this.w / 32)
						{
							g.drawRegion(MainTabNew.imgTab[1], 0, 0, 32, this.menuW - 4, 0, this.menuX + i * 32, this.menuTemY - this.hPlus + GameCanvas.hCommand + 2, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(MainTabNew.imgTab[1], 0, 0, 32, this.menuW - 4, 0, this.menuX + this.w - 32, this.menuTemY - this.hPlus + GameCanvas.hCommand + 2, 0, mGraphics.isTrue);
						}
					}
				}
				if (this.vecFocus.size() > 1)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 16, 13, 8, 6, this.menuX + 8 - GameCanvas.gameTick % 3, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
					g.drawRegion(MainTabNew.imgTab[7], 0, 24, 13, 8, 6, this.menuX + this.w - 8 + GameCanvas.gameTick % 3, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
				}
				AvMain.FontBorderColor(g, Menu2.objSelect.name, this.menuX + this.w / 2 + 13, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 4 + 3, 2, 2);
				int num = mFont.tahoma_7b_black.getWidth(Menu2.objSelect.name) / 2 + 1;
				Menu2.objSelect.paintAvatarFocus(g, this.menuX + this.w / 2 - num - 2, this.menuTemY - this.hPlus + GameCanvas.hCommand + this.menuW / 4 + 8);
			}
			if (!Menu2.isPaint)
			{
				return;
			}
			if (this.pos == -1)
			{
				g.setClip(this.menuX + 2, this.menuTemY + 2, this.w - 4, this.menuH - 4);
				g.translate(-Menu2.cmx, 0);
				for (int j = 0; j < this.menuItems.size(); j++)
				{
					if (j == this.menuSelectedItem)
					{
						g.setColor(AvMain.color[3]);
						g.fillRoundRect(this.menuX + j * this.menuW + 3, this.menuTemY + 3, this.menuW - 8, this.menuH - 6, 6, 6, mGraphics.isTrue);
					}
					string[] array = ((iCommand)this.menuItems.elementAt(j)).subCaption;
					if (array == null)
					{
						array = new string[]
						{
							((iCommand)this.menuItems.elementAt(j)).caption
						};
					}
					int num2 = this.menuTemY + (this.menuH - array.Length * 14) / 2 + 1;
					for (int k = 0; k < array.Length; k++)
					{
						if (j == this.menuSelectedItem)
						{
							mFont.tahoma_7b_white.drawString(g, array[k], this.menuX + j * this.menuW + this.menuW / 2 - 1, num2 + k * 14, 2, mGraphics.isTrue);
						}
						else
						{
							mFont.tahoma_7b_black.drawString(g, array[k], this.menuX + j * this.menuW + this.menuW / 2 - 1, num2 + k * 14, 2, mGraphics.isTrue);
						}
					}
				}
			}
			else
			{
				g.setClip(this.menuX + 3, this.menuY + 3, this.w - 6, this.menuH - 6);
				g.translate(0, -Menu2.cmx);
				g.setColor(AvMain.color[4]);
				if (this.pos == 2 || this.pos == 4)
				{
					for (int l = 0; l < this.menuItems.size() - 1; l++)
					{
						g.setColor(AvMain.color[4]);
						g.fillRect(this.menuX + 8, this.menuY + 3 + this.menuW + l * this.menuW, this.w - 16, 1, mGraphics.isTrue);
					}
				}
				int num3 = Menu2.cmx / this.menuW - 1;
				if (num3 < 0)
				{
					num3 = 0;
				}
				int num4 = num3 + this.sizeMenu + 2;
				if (num4 > this.menuItems.size())
				{
					num4 = this.menuItems.size();
					num3 = num4 - this.sizeMenu - 2;
					if (num3 < 0)
					{
						num3 = 0;
					}
				}
				if (this.menuSelectedItem > -1)
				{
					base.paintSelect(g, this.menuX + 3, this.menuY + 3 + this.menuSelectedItem * this.menuW, this.w - 6, this.menuW + 1);
				}
				for (int m = num3; m < num4; m++)
				{
					iCommand iCommand = (iCommand)this.menuItems.elementAt(m);
					if (this.pos == 2)
					{
						iCommand.paintCaptionImageMenu(g, this.menuX + this.w / 2, this.menuY + 6 + this.menuW / 4 + m * this.menuW, 2);
					}
					else if (this.pos == 0 || this.pos == 3)
					{
						iCommand.paintCaptionImageMenu(g, this.menuX + 6, this.menuY + 6 + this.menuW / 4 + m * this.menuW, 0);
					}
					else if (this.pos == 1)
					{
						iCommand.paintCaptionImageMenu(g, this.menuX + this.w - 6, this.menuY + 6 + this.menuW / 4 + m * this.menuW, 1);
					}
					else if (this.pos == 4)
					{
						iCommand.paintCaptionImageMenu(g, this.menuX + 10, this.menuY + 6 + this.menuW / 4 + m * this.menuW, 0);
					}
				}
				GameCanvas.resetTrans(g);
				if (GameScreen.help.Step >= 0 && Menu2.isHelp)
				{
					int num5 = GameScreen.help.itemMenuHelp();
					if (num5 >= 0)
					{
						MainHelp.paintPopup(g, this.menuX - 6 - 70, this.menuY + 16 + num5 * this.menuW - GameCanvas.hText, 70, GameCanvas.hText, -1, T.helpMenu);
						g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, this.menuX + 4 + GameCanvas.gameTick / 2 % 4, this.menuY + 14 + num5 * this.menuW, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
					}
				}
				base.paintCmd(g);
			}
		}
		else if ((int)Menu2.isNPCMenu == 2)
		{
			if (this.isPosPoint)
			{
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 0, 0, 20, 16, 0, this.menuX - 20, this.menuY + this.menuH - 16, 0, mGraphics.isTrue);
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 20, 0, 20, 16, 0, this.menuX + this.hShow, this.menuY + this.menuH - 16, 0, mGraphics.isTrue);
				if (this.hShow == this.menuH)
				{
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 2, this.menuX, this.menuY, 0, mGraphics.isTrue);
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 0, this.menuX + 20, this.menuY, 0, mGraphics.isTrue);
				}
				else
				{
					for (int n = 0; n < this.hShow; n += this.menuH)
					{
						if (n == 0)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 2, this.menuX, this.menuY, 0, mGraphics.isTrue);
						}
						else if (n + this.menuH >= this.hShow)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 0, this.menuX + n, this.menuY, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 20, 40, 40, 0, this.menuX + n, this.menuY, 0, mGraphics.isTrue);
						}
					}
				}
				g.setClip(this.menuX + 5, this.menuY - 20, this.hShow - 10, this.menuH + 20);
			}
			else
			{
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 0, 0, 20, 16, 0, this.menuX + this.w / 2 - this.hShow / 2 - 20, this.menuY + this.menuH - 16, 0, mGraphics.isTrue);
				g.drawRegion(PaintInfoGameScreen.imgOther[4], 20, 0, 20, 16, 0, this.menuX + this.w / 2 + this.hShow / 2, this.menuY + this.menuH - 16, 0, mGraphics.isTrue);
				if (this.hShow == this.menuH)
				{
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 2, this.menuX + this.w / 2 - 20, this.menuY, 0, mGraphics.isTrue);
					g.drawRegion(PaintInfoGameScreen.imgBackQuick, 20, 0, 20, 40, 0, this.menuX + this.w / 2, this.menuY, 0, mGraphics.isTrue);
				}
				else
				{
					for (int num6 = 0; num6 < this.hShow; num6 += this.menuH)
					{
						if (num6 == 0)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 2, this.menuX + this.w / 2 - this.hShow / 2 + num6, this.menuY, 0, mGraphics.isTrue);
						}
						else if (num6 + this.menuH >= this.hShow)
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 0, 40, 40, 0, this.menuX + this.w / 2 - this.hShow / 2 + num6, this.menuY, 0, mGraphics.isTrue);
						}
						else
						{
							g.drawRegion(PaintInfoGameScreen.imgBackQuick, 0, 20, 40, 40, 0, this.menuX + this.w / 2 - this.hShow / 2 + num6, this.menuY, 0, mGraphics.isTrue);
						}
					}
				}
				g.setClip(this.menuX + this.w / 2 - this.hShow / 2 + 5, this.menuY - 20, this.hShow - 10, this.menuH + 20);
			}
			g.translate(-Menu2.cmx, 0);
			for (int num7 = 0; num7 < this.menuItems.size(); num7++)
			{
				iCommand iCommand2 = (iCommand)this.menuItems.elementAt(num7);
				iCommand2.paint(g, iCommand2.xCmd, iCommand2.yCmd);
			}
			GameCanvas.resetTrans(g);
			g.translate(-Menu2.cmx, 0);
			for (int num8 = 0; num8 < this.menuItems.size(); num8++)
			{
				iCommand iCommand3 = (iCommand)this.menuItems.elementAt(num8);
				iCommand3.paintClickCaption(g, iCommand3.xCmd, iCommand3.yCmd, 2);
			}
		}
	}

	// Token: 0x0600097B RID: 2427 RVA: 0x0009AE78 File Offset: 0x00099078
	private void paint_NPC_MENU(mGraphics g)
	{
		int num = this.menuX + 6;
		int y = this.menuY + 8;
		AvMain.paintDialog(g, this.menuX, this.menuTemY, this.w, this.menuH, 12);
		MainObject mainObject = MainObject.get_Object(this.IdNpc, this.typeO);
		if (mainObject == null)
		{
			return;
		}
		mainObject.paintBigAvatar(g, this.menuX + this.w - 10, this.menuY);
		AvMain.Font3dWhite(g, mainObject.name, num + 10, y, 0);
		if (this.runText != null)
		{
			this.runText.paintText(g, this.archorRunText);
		}
		GameCanvas.resetTrans(g);
		for (int i = 0; i < this.menuItems.size(); i++)
		{
			iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
	}

	// Token: 0x0600097C RID: 2428 RVA: 0x0009AF68 File Offset: 0x00099168
	public void doCloseMenu()
	{
		this.isShowMenu = false;
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerEnd = true;
	}

	// Token: 0x0600097D RID: 2429 RVA: 0x0009AF84 File Offset: 0x00099184
	public void updateMenu()
	{
		if ((int)this.timeShow > 0)
		{
			this.timeShow += 1;
			if (this.hShow < this.w)
			{
				this.hShow += this.menuH;
				if (this.hShow >= this.w)
				{
					this.hShow = this.w;
					this.timeShow = 0;
				}
			}
		}
		else if ((int)this.timeShow < 0)
		{
			this.timeShow -= 1;
			if (this.hShow > 0)
			{
				this.hShow -= this.menuH;
				if (this.hShow <= 0)
				{
					this.hShow = 0;
					this.timeShow = 0;
					this.doCloseMenu();
				}
			}
		}
		if (!Menu2.isLoadData)
		{
			return;
		}
		this.moveCamera();
		if ((int)Menu2.isNPCMenu == 1)
		{
			if (this.runText != null)
			{
				this.runText.updateDlg();
			}
			for (int i = 0; i < this.menuItems.size(); i++)
			{
				iCommand iCommand = (iCommand)this.menuItems.elementAt(i);
				iCommand.updatePointer();
			}
		}
		else if ((int)Menu2.isNPCMenu == 2 && !GameCanvas.isPointerMove && (int)this.timeShow == 0)
		{
			for (int j = 0; j < this.menuItems.size(); j++)
			{
				iCommand iCommand2 = (iCommand)this.menuItems.elementAt(j);
				iCommand2.updatePointerShow(Menu2.cmx, 0);
			}
		}
		if (this.menuTemY > this.menuY)
		{
			int num = this.menuTemY - this.menuY >> 1;
			if (num < 1)
			{
				num = 1;
			}
			this.menuTemY -= num;
		}
		if (Menu2.xc != 0)
		{
			Menu2.xc >>= 1;
			if (Menu2.xc < 0)
			{
				Menu2.xc = 0;
			}
		}
		if (this.waitToPerform > 0)
		{
			this.waitToPerform--;
			if (this.waitToPerform == 0)
			{
				this.isShowMenu = false;
				if (this.menuSelectedItem >= 0)
				{
					iCommand cmd = (iCommand)this.menuItems.elementAt(this.menuSelectedItem);
					this.perform(cmd);
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					GameCanvas.isPointerEnd = true;
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x0600097E RID: 2430 RVA: 0x0009B1F4 File Offset: 0x000993F4
	public void perform(iCommand cmd)
	{
		if (cmd != null)
		{
			if (cmd.action != null)
			{
				cmd.action.perform();
			}
			else if (cmd.Pointer != null)
			{
				cmd.Pointer.commandPointer((int)cmd.indexMenu, (int)cmd.subIndex);
			}
			else
			{
				GameCanvas.currentScreen.commandMenu((int)cmd.indexMenu, (int)cmd.subIndex);
			}
			GameCanvas.isPointerSelect = false;
			mSound.playSound(42, mSound.volumeSound);
		}
	}

	// Token: 0x04000E92 RID: 3730
	public const sbyte NORMAL = 0;

	// Token: 0x04000E93 RID: 3731
	public const sbyte NPC_MENU = 1;

	// Token: 0x04000E94 RID: 3732
	public const sbyte QUICK_MENU = 2;

	// Token: 0x04000E95 RID: 3733
	public bool isShowMenu;

	// Token: 0x04000E96 RID: 3734
	public mVector menuItems;

	// Token: 0x04000E97 RID: 3735
	public int menuSelectedItem;

	// Token: 0x04000E98 RID: 3736
	public int SelectFocus;

	// Token: 0x04000E99 RID: 3737
	public int menuX;

	// Token: 0x04000E9A RID: 3738
	public int menuY;

	// Token: 0x04000E9B RID: 3739
	public int menuW;

	// Token: 0x04000E9C RID: 3740
	public int menuH;

	// Token: 0x04000E9D RID: 3741
	public int menuTemY;

	// Token: 0x04000E9E RID: 3742
	public int hPlus;

	// Token: 0x04000E9F RID: 3743
	public static int cmtoX;

	// Token: 0x04000EA0 RID: 3744
	public static int cmx;

	// Token: 0x04000EA1 RID: 3745
	public static int cmdy;

	// Token: 0x04000EA2 RID: 3746
	public static int cmvy;

	// Token: 0x04000EA3 RID: 3747
	public static int cmxLim;

	// Token: 0x04000EA4 RID: 3748
	public static int xc;

	// Token: 0x04000EA5 RID: 3749
	private int pos;

	// Token: 0x04000EA6 RID: 3750
	private int sizeMenu;

	// Token: 0x04000EA7 RID: 3751
	private string nameMenu = string.Empty;

	// Token: 0x04000EA8 RID: 3752
	private string[] mStrTalk;

	// Token: 0x04000EA9 RID: 3753
	public RunWord runText;

	// Token: 0x04000EAA RID: 3754
	public static bool isHelp;

	// Token: 0x04000EAB RID: 3755
	public static bool isGiaotiep;

	// Token: 0x04000EAC RID: 3756
	public static bool isPaint = true;

	// Token: 0x04000EAD RID: 3757
	public static bool isLoadData = true;

	// Token: 0x04000EAE RID: 3758
	public static sbyte isNPCMenu;

	// Token: 0x04000EAF RID: 3759
	private mVector vecFocus;

	// Token: 0x04000EB0 RID: 3760
	public static MainObject objSelect;

	// Token: 0x04000EB1 RID: 3761
	private int IdMenu;

	// Token: 0x04000EB2 RID: 3762
	private int IdNpc;

	// Token: 0x04000EB3 RID: 3763
	public static int IdNPCLast;

	// Token: 0x04000EB4 RID: 3764
	private sbyte typeO;

	// Token: 0x04000EB5 RID: 3765
	private int waitToPerform;

	// Token: 0x04000EB6 RID: 3766
	private int cmRun;

	// Token: 0x04000EB7 RID: 3767
	private sbyte timeShow;

	// Token: 0x04000EB8 RID: 3768
	private int hShow;

	// Token: 0x04000EB9 RID: 3769
	private int maxShow;

	// Token: 0x04000EBA RID: 3770
	private bool disableClose;

	// Token: 0x04000EBB RID: 3771
	public int w;

	// Token: 0x04000EBC RID: 3772
	private int pa;

	// Token: 0x04000EBD RID: 3773
	private bool trans;

	// Token: 0x04000EBE RID: 3774
	private int pointerDownTime;

	// Token: 0x04000EBF RID: 3775
	private int pointerDownFirstX;

	// Token: 0x04000EC0 RID: 3776
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000EC1 RID: 3777
	private bool pointerIsDowning;

	// Token: 0x04000EC2 RID: 3778
	private bool isDownWhenRunning;

	// Token: 0x04000EC3 RID: 3779
	private int archorRunText;

	// Token: 0x04000EC4 RID: 3780
	private bool isPosPoint;

	// Token: 0x04000EC5 RID: 3781
	private iCommand cmdChangeScreen;

	// Token: 0x04000EC6 RID: 3782
	private iCommand cmdTouch;

	// Token: 0x04000EC7 RID: 3783
	public iCommand cmdNgua;

	// Token: 0x04000EC8 RID: 3784
	private int xBegin;

	// Token: 0x04000EC9 RID: 3785
	private int w2cmd;

	// Token: 0x04000ECA RID: 3786
	private int cmvx;

	// Token: 0x04000ECB RID: 3787
	private int cmdx;
}
