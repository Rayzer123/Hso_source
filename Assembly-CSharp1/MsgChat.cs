using System;

// Token: 0x02000098 RID: 152
public class MsgChat : MainDialog
{
	// Token: 0x0600073B RID: 1851 RVA: 0x0006F268 File Offset: 0x0006D468
	public MsgChat()
	{
		this.wOneItem = (int)MainTabNew.wOneItem;
		this.wOne5 = (int)MainTabNew.wOne5;
		this.wDia = GameCanvas.w / 4 * 3;
		if (this.wDia < 160)
		{
			this.wDia = 160;
		}
		else if (this.wDia > 240)
		{
			this.wDia = 240;
		}
		this.hDia = GameCanvas.h - iCommand.hButtonCmd * 2 - 16;
		if (this.hDia > 240)
		{
			this.hDia = 240;
		}
		this.hchat = (this.hDia - 3 * this.wOneItem) / GameCanvas.hText + 5;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		this.cam.setAll(0, 0, 0, 0);
		this.wMainTab = this.wOneItem * 3;
		if (this.wMainTab > 70)
		{
			this.wMainTab = 70;
		}
		if (this.wOneItem < 20)
		{
			this.maxText = 4;
		}
		this.maxTab = (this.wDia - this.wMainTab - 20) / (this.wOneItem - 1) + 1;
		this.min = MsgChat.idSelect - this.maxTab / 2;
		if (this.min < 0)
		{
			this.min = 0;
		}
		this.max = this.min + this.maxTab;
		if (this.max > MsgChat.vecChatTab.size())
		{
			this.max = MsgChat.vecChatTab.size();
		}
		this.xdich = (this.wDia - (this.maxTab - 1) * (this.wOneItem - 1) - this.wMainTab) / 2;
		MsgChat.cmdChat = new iCommand(T.chat, 0, this);
		MsgChat.cmdDelete = new iCommand(T.delTabChat, 1, this);
		MsgChat.cmdClose = new iCommand(T.trora, -1, this);
		MsgChat.cmdMenu = new iCommand(T.menu, 2, this);
		MsgChat.cmdOkAdd = new iCommand(T.chapnhan, 3, this);
		MsgChat.cmdCancelAdd = new iCommand(T.tuchoi, 4, this);
		this.list = new ListNew(this.xDia, this.yDia + this.wOneItem, this.wDia, this.hDia - 3 * this.wOneItem, 0, 0, 0);
		this.scroll.setInfo(this.xDia + this.wDia - 6, this.yDia + this.wOneItem + 10, this.hDia - this.wOneItem - TField.getHeight() - 25, MainTabNew.color[9]);
		this.cmdChat2 = new iCommand();
		this.cmdChat2.actionChat = delegate(string str)
		{
			MsgChat.curentfocus.tfchat.setText(str);
			MsgChat.cmdChat.perform();
			MsgChat.curentfocus.tfchat.setText(string.Empty);
			MsgChat.curentfocus.tfchat.clearKb();
			TField.isOpenTextBox = false;
			MsgChat.curentfocus.tfchat.isFocus = false;
		};
		this.init();
	}

	// Token: 0x0600073D RID: 1853 RVA: 0x0006F594 File Offset: 0x0006D794
	public void setCaptionCmd()
	{
		MsgChat.cmdChat.caption = T.chat;
		MsgChat.cmdDelete.caption = T.delTabChat;
		MsgChat.cmdClose.caption = T.trora;
		MsgChat.cmdMenu.caption = T.menu;
		MsgChat.cmdOkAdd.caption = T.chapnhan;
		MsgChat.cmdCancelAdd.caption = T.tuchoi;
	}

	// Token: 0x0600073E RID: 1854 RVA: 0x0006F5FC File Offset: 0x0006D7FC
	public void init()
	{
		if (MsgChat.vecChatTab.size() == 0)
		{
			this.right = MsgChat.cmdClose;
		}
		else
		{
			if (MsgChat.curentfocus == null && MsgChat.vecChatTab.size() > 0)
			{
				if (MsgChat.idSelect < 0 || MsgChat.idSelect >= MsgChat.vecChatTab.size())
				{
					MsgChat.idSelect = 0;
				}
				MsgChat.curentfocus = (ChatDetail)MsgChat.vecChatTab.elementAt(MsgChat.idSelect);
				newinput.input.text = string.Empty;
				this.updateSelect();
			}
			if (MsgChat.curentfocus != null)
			{
				this.updateSelect();
			}
			if (GameCanvas.isTouch)
			{
				MsgChat.cmdMenu.setPos(this.xDia + this.wDia - 12, this.yDia - 14, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			}
			this.left = MsgChat.cmdMenu;
		}
	}

	// Token: 0x0600073F RID: 1855 RVA: 0x0006F6E8 File Offset: 0x0006D8E8
	public void openKeyIphone()
	{
		if (!Main.isPC)
		{
			ipKeyboard.openKeyBoard("Chat", ipKeyboard.TEXT, string.Empty, this.cmdChat2);
			MsgChat.curentfocus.tfchat.setFocusWithKb(true);
		}
	}

	// Token: 0x06000740 RID: 1856 RVA: 0x0006F72C File Offset: 0x0006D92C
	public void backTab()
	{
		MsgChat.idSelect = 0;
		this.cam.setAll(0, 0, 0, 0);
		this.list = new ListNew(this.xDia, this.yDia + this.wOneItem, this.wMainTab, this.hDia - 3 * this.wOneItem, 0, 0, 0);
	}

	// Token: 0x06000741 RID: 1857 RVA: 0x0006F784 File Offset: 0x0006D984
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			GameCanvas.end_Dialog();
			newinput.TYPE_INPUT = -1;
			break;
		case 1:
			MsgChat.curentfocus.addStartChat(GameScreen.player.name);
			newinput.input.text = string.Empty;
			break;
		case 2:
		{
			if (MsgChat.idSelect < 0 || MsgChat.idSelect >= MsgChat.vecChatTab.size())
			{
				return;
			}
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(MsgChat.idSelect);
			if (chatDetail != null)
			{
				MainEvent mainEvent = EventScreen.setEvent(chatDetail.name, 0);
				if (mainEvent != null)
				{
					mainEvent.isRemove = true;
				}
				MsgChat.vecChatTab.removeElementAt(MsgChat.idSelect);
				if (MsgChat.idSelect > 0)
				{
					MsgChat.idSelect--;
				}
				if (MsgChat.vecChatTab.size() == 0)
				{
					MsgChat.curentfocus = null;
					this.left = null;
					this.center = null;
					this.right = MsgChat.cmdClose;
				}
				else
				{
					this.updateSelect();
				}
			}
			break;
		}
		case 3:
		{
			if (GameCanvas.isTouch && MsgChat.vecChatTab.size() == 1)
			{
				GameCanvas.end_Dialog();
				return;
			}
			mVector mVector = new mVector("MsgChat menu");
			if (MsgChat.idSelect > 0)
			{
				mVector.addElement(MsgChat.cmdDelete);
			}
			mVector.addElement(MsgChat.cmdClose);
			GameCanvas.menu2.startAt(mVector, 2, T.trochuyen, false, null);
			break;
		}
		case 4:
			GlobalService.gI().Friend(1, MsgChat.curentfocus.friend);
			MsgChat.cmdDelete.perform();
			break;
		case 5:
			GlobalService.gI().Friend(2, MsgChat.curentfocus.friend);
			MsgChat.cmdDelete.perform();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000742 RID: 1858 RVA: 0x0006F964 File Offset: 0x0006DB64
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		AvMain.paintDialogNew(g, this.xDia - 10, this.yDia - GameCanvas.hCommand - 6, this.wDia + 20, this.hDia + GameCanvas.hCommand + 12, 0);
		this.paintBack(g);
		AvMain.FontBorderColor(g, T.trochuyen, this.xDia + this.wDia / 2, this.yDia - GameCanvas.hCommand + GameCanvas.hCommand / 4, 2, 0);
		int num = this.xDia + this.xdich;
		int num2 = this.yDia + this.wOne5;
		if (MsgChat.vecChatTab.size() > 0 && MsgChat.curentfocus != null)
		{
			if (this.min > 0)
			{
				g.drawRegion(MainTabNew.imgTab[13], 0, (!this.isLeft || GameCanvas.gameTick % 6 >= 3) ? 0 : 16, 13, 8, 6, num - 6, num2 + this.wOne5 * 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
			}
			g.setColor(MainTabNew.color[7]);
			for (int i = this.min; i < MsgChat.idSelect; i++)
			{
				ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
				this.paintRectNew(g, num, num2, this.wOneItem, this.wOneItem, chatDetail.isNew, (int)chatDetail.timeNew);
				mFont.tahoma_7_black.drawString(g, MsgChat.strName[i], num + this.wOneItem / 2, num2 + this.wOneItem / 2 - 7, 2, mGraphics.isTrue);
				num += this.wOneItem - 1;
			}
			this.xselect = num;
			num += this.wMainTab - 1;
			for (int j = MsgChat.idSelect + 1; j < this.max; j++)
			{
				ChatDetail chatDetail2 = (ChatDetail)MsgChat.vecChatTab.elementAt(j);
				this.paintRectNew(g, num, num2, this.wOneItem, this.wOneItem, chatDetail2.isNew, (int)chatDetail2.timeNew);
				mFont.tahoma_7_black.drawString(g, MsgChat.strName[j], num + this.wOneItem / 2, num2 + this.wOneItem / 2 - 7, 2, mGraphics.isTrue);
				num += this.wOneItem - 1;
			}
			if (this.max < MsgChat.vecChatTab.size())
			{
				g.drawRegion(MainTabNew.imgTab[13], 0, (!this.isRight || GameCanvas.gameTick % 6 >= 3) ? 8 : 24, 13, 8, 6, num + 7, num2 + this.wOne5 * 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isTrue);
			}
			this.paintTabFocus(g, this.xselect, num2 - 1, this.wMainTab);
			string st = string.Empty;
			if (mFont.tahoma_7b_white.getWidth(MsgChat.curentfocus.name) < this.wMainTab - 4)
			{
				st = MsgChat.curentfocus.name;
			}
			else
			{
				st = mSystem.substring(MsgChat.curentfocus.name, 0, ((int)this.maxText - 1) * 2) + "..";
			}
			mFont tahoma_7b_white = mFont.tahoma_7b_white;
			tahoma_7b_white.drawString(g, st, this.xselect + this.wMainTab / 2, num2 + this.wOneItem / 2 - 7, 2, mGraphics.isTrue);
			num2 += this.wOneItem;
			g.setClip(this.xDia, num2, this.wDia, this.hDia - this.wOneItem - 7 - (((int)MsgChat.curentfocus.typeChat != (int)ChatDetail.TYPE_CHAT) ? 0 : 17));
			g.translate(0, -this.cam.yCam);
			this.minchat = this.cam.yCam / GameCanvas.hText - 2;
			if (this.minchat < 0)
			{
				this.minchat = 0;
			}
			this.maxchat = this.minchat + this.hchat;
			for (int k = this.minchat; k <= this.maxchat; k++)
			{
				if (k < MsgChat.curentfocus.vecDetail.size() && k >= 0)
				{
					MainTextChat mainTextChat = (MainTextChat)MsgChat.curentfocus.vecDetail.elementAt(k);
					MainTabNew.setTextColor((int)mainTextChat.color).drawString(g, mainTextChat.text, this.xDia + this.wOne5, num2 + 2 + k * GameCanvas.hText, 0, mGraphics.isTrue);
				}
			}
			GameCanvas.resetTrans(g);
			if (this.cam.yLimit > 0)
			{
				this.scroll.paint(g);
			}
			if ((int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_CHAT)
			{
				MsgChat.curentfocus.tfchat.paint(g);
			}
		}
		else
		{
			num2 += this.wOneItem;
			mFont.tahoma_7_white.drawString(g, T.noMessage, this.xDia + this.wDia / 2, num2 + 2, 2, mGraphics.isTrue);
		}
		base.paint(g);
	}

	// Token: 0x06000743 RID: 1859 RVA: 0x0006FE6C File Offset: 0x0006E06C
	public override void updatekey()
	{
		if (MsgChat.vecChatTab.size() > 0 && MsgChat.curentfocus != null)
		{
			int num = MsgChat.idSelect;
			if (GameCanvas.keyMyHold[(!Main.isPC) ? 4 : 33])
			{
				if (MsgChat.idSelect != 0)
				{
					MsgChat.idSelect--;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 4 : 33);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC) ? 6 : 34])
			{
				MsgChat.idSelect++;
				GameCanvas.clearKeyHold((!Main.isPC) ? 6 : 34);
			}
			MsgChat.idSelect = base.resetSelect(MsgChat.idSelect, MsgChat.vecChatTab.size() - 1, true);
			if (GameCanvas.keyMyHold[(!Main.isPC) ? 2 : 31])
			{
				this.cam.yTo -= GameCanvas.hText;
				if (this.cam.yTo < 0)
				{
					this.cam.yTo = 0;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 2 : 31);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC) ? 8 : 32])
			{
				this.cam.yTo += GameCanvas.hText;
				if (this.cam.yTo > this.cam.yLimit)
				{
					this.cam.yTo = this.cam.yLimit;
				}
				GameCanvas.clearKeyHold((!Main.isPC) ? 8 : 32);
			}
			if (num != MsgChat.idSelect)
			{
				this.updateSelect();
			}
		}
		base.updatekey();
	}

	// Token: 0x06000744 RID: 1860 RVA: 0x0007004C File Offset: 0x0006E24C
	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			this.list.update_Pos_UP_DOWN();
			this.cam.yCam = this.list.cmx;
		}
		if (MsgChat.curentfocus != null && MsgChat.curentfocus.tfchat != null && MsgChat.curentfocus.tfchat.isFocus)
		{
			newinput.TYPE_INPUT = 1;
			MsgChat.curentfocus.tfchat.isnewTF = true;
		}
		this.isLeft = false;
		this.isRight = false;
		if (MsgChat.vecChatTab.size() > 0 && MsgChat.curentfocus != null)
		{
			for (int i = 0; i < MsgChat.vecChatTab.size(); i++)
			{
				if (i < this.min || i >= this.max)
				{
					ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
					if (chatDetail.isNew)
					{
						if (i < this.min)
						{
							this.isLeft = true;
						}
						else
						{
							this.isRight = true;
						}
					}
				}
			}
			if (MsgChat.vecChatTab.size() == 0)
			{
				MsgChat.idSelect = 0;
			}
			if (this.cam.yLimit > 0)
			{
				this.scroll.setYScrool(this.cam.yCam, this.cam.yLimit);
			}
			if (GameCanvas.isTouch)
			{
				this.list.moveCamera();
			}
			else
			{
				this.cam.UpdateCamera();
				this.cam.UpdateCamera();
			}
			if ((int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_CHAT)
			{
				MsgChat.curentfocus.tfchat.update();
			}
		}
		else if (MsgChat.curentfocus == null && MsgChat.vecChatTab.size() > 0)
		{
			MsgChat.idSelect = 0;
			MsgChat.curentfocus = (ChatDetail)MsgChat.vecChatTab.elementAt(MsgChat.idSelect);
			this.updateSelect();
		}
		this.updatekey();
		this.updatePointer();
		base.update();
	}

	// Token: 0x06000745 RID: 1861 RVA: 0x00070254 File Offset: 0x0006E454
	public override void keypress(int keyCode)
	{
		if (MsgChat.vecChatTab.size() > 0 && MsgChat.curentfocus != null && (int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_CHAT)
		{
			MsgChat.curentfocus.tfchat.keyPressed(keyCode);
		}
		base.keypress(keyCode);
	}

	// Token: 0x06000746 RID: 1862 RVA: 0x000702AC File Offset: 0x0006E4AC
	public static void getStrName()
	{
		MsgChat.strName = new string[MsgChat.vecChatTab.size()];
		for (int i = 0; i < MsgChat.strName.Length; i++)
		{
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
			if (chatDetail.name.Length <= 4)
			{
				MsgChat.strName[i] = chatDetail.name;
			}
			else
			{
				MsgChat.strName[i] = mSystem.substring(chatDetail.name, 0, 4);
			}
		}
	}

	// Token: 0x06000747 RID: 1863 RVA: 0x00070330 File Offset: 0x0006E530
	public void updateCameraNew(int size)
	{
		if (GameCanvas.isTouch)
		{
			this.list.cmxLim = MsgChat.curentfocus.limY;
			if (this.list.cmx + this.hDia / 4 > this.list.cmxLim && this.list.cmxLim > 0)
			{
				this.list.cmtoX += GameCanvas.hText * size;
			}
		}
		else
		{
			this.cam.yLimit = MsgChat.curentfocus.limY;
			if (this.cam.yCam + this.hDia / 4 > this.cam.yLimit)
			{
				this.cam.yTo += GameCanvas.hText * size;
			}
		}
	}

	// Token: 0x06000748 RID: 1864 RVA: 0x00070404 File Offset: 0x0006E604
	public void updateSelect()
	{
		MsgChat.curentfocus = (ChatDetail)MsgChat.vecChatTab.elementAt(MsgChat.idSelect);
		if (this.left == null)
		{
			this.left = MsgChat.cmdMenu;
		}
		if ((int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_CHAT)
		{
			MsgChat.curentfocus.tfchat.setText(string.Empty);
			if (Main.isPC)
			{
				MsgChat.curentfocus.tfchat.setFocus(true);
				this.center = MsgChat.cmdChat;
				this.right = MsgChat.curentfocus.tfchat.setCmdClear();
			}
		}
		else if ((int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_ADDFRIEND)
		{
			this.center = MsgChat.cmdOkAdd;
			this.right = MsgChat.cmdCancelAdd;
		}
		else
		{
			this.center = null;
			this.right = null;
		}
		if ((int)MsgChat.curentfocus.timeNew > 0)
		{
			MsgChat.curentfocus.timeNew = -1;
			MsgChat.curentfocus.isNew = false;
		}
		if (MsgChat.curentfocus.limY > 0)
		{
			int num = MsgChat.curentfocus.limY - this.hDia / 4;
			if (num < 0)
			{
				num = 0;
			}
			if (GameCanvas.isTouch)
			{
				this.list.cmxLim = MsgChat.curentfocus.limY;
				this.list.cmtoX = MsgChat.curentfocus.limY;
			}
			else
			{
				this.cam.setAll(0, MsgChat.curentfocus.limY, 0, num);
				this.cam.yTo = MsgChat.curentfocus.limY;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			this.cam.setAll(0, 0, 0, 0);
		}
		else
		{
			this.list.cmxLim = 0;
			this.list.cmtoX = 0;
		}
		this.min = MsgChat.idSelect - this.maxTab / 2;
		if (this.min < 0)
		{
			this.min = 0;
		}
		this.max = this.min + this.maxTab;
		if (this.max > MsgChat.vecChatTab.size())
		{
			this.max = MsgChat.vecChatTab.size();
			this.min = this.max - this.maxTab;
			if (this.min < 0)
			{
				this.min = 0;
			}
		}
		MsgChat.getStrName();
		TabScreenNew.timeRepaint = 10;
	}

	// Token: 0x06000749 RID: 1865 RVA: 0x00070670 File Offset: 0x0006E870
	public override void updatePointer()
	{
		if (MsgChat.vecChatTab.size() > 0 && MsgChat.curentfocus != null)
		{
			if ((int)MsgChat.curentfocus.typeChat == (int)ChatDetail.TYPE_CHAT)
			{
				MsgChat.curentfocus.tfchat.updatePoiter();
			}
			if (GameCanvas.isPointerSelect)
			{
				int xDia = this.xDia;
				int yDia = this.yDia;
				int num = xDia + this.xdich;
				int num2 = num + (this.maxTab - 1) * (this.wOneItem - 1) + this.wMainTab;
				int num3 = MsgChat.idSelect;
				if (GameCanvas.isPoint(this.xDia, yDia, this.wDia, this.wOneItem))
				{
					if (GameCanvas.px < this.xselect && GameCanvas.px > num)
					{
						num3 = MsgChat.idSelect + (GameCanvas.px - this.xselect) / (this.wOneItem - 1) - 1;
						TabScreenNew.timeRepaint = 10;
					}
					else if (GameCanvas.px > this.xselect + this.wMainTab && GameCanvas.px < num2)
					{
						num3 = MsgChat.idSelect + (GameCanvas.px - this.xselect - this.wMainTab) / (this.wOneItem - 1) + 1;
					}
					else if (GameCanvas.px < num)
					{
						num3 = MsgChat.idSelect - this.maxTab;
					}
					else if (GameCanvas.px > num2)
					{
						num3 = MsgChat.idSelect + this.maxTab;
					}
				}
				num3 = base.resetSelect(num3, MsgChat.vecChatTab.size() - 1, false);
				if (num3 != MsgChat.idSelect)
				{
					MsgChat.idSelect = num3;
					this.updateSelect();
					GameCanvas.isPointerSelect = false;
					TabScreenNew.timeRepaint = 10;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x0600074A RID: 1866 RVA: 0x0007082C File Offset: 0x0006EA2C
	public void addNewChat(string name, string FristContent, string content, sbyte type, bool isFocus)
	{
		for (int i = 0; i < MsgChat.vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
			if (chatDetail.name.CompareTo(name) == 0)
			{
				if (isFocus)
				{
					MsgChat.idSelect = i;
				}
				if (content.Length > 0)
				{
					chatDetail.addString(FristContent + content, name);
					string[] array = mFont.tahoma_7_white.splitFontArray(content, GameCanvas.mevent.wDia / 5 * 2);
					GameCanvas.mevent.addEvent(name, 0, array[0], 0);
				}
				return;
			}
		}
		ChatDetail chatDetail2 = new ChatDetail(name, type);
		if ((int)type == (int)ChatDetail.TYPE_CHAT)
		{
			chatDetail2.addString(T.beginChat + name, name);
		}
		if (content.Length > 0)
		{
			chatDetail2.addString(FristContent + content, name);
			string[] array2 = mFont.tahoma_7_white.splitFontArray(content, GameCanvas.mevent.wDia / 2);
			GameCanvas.mevent.addEvent(name, 0, array2[0], 0);
		}
		MsgChat.vecChatTab.addElement(chatDetail2);
		this.set_text_min_max();
		if (isFocus)
		{
			MsgChat.idSelect = MsgChat.vecChatTab.size() - 1;
		}
	}

	// Token: 0x0600074B RID: 1867 RVA: 0x00070960 File Offset: 0x0006EB60
	public void set_text_min_max()
	{
		MsgChat.getStrName();
		this.min = MsgChat.idSelect - this.maxTab / 2;
		if (this.min < 0)
		{
			this.min = 0;
		}
		this.max = this.min + this.maxTab;
		if (this.max > MsgChat.vecChatTab.size())
		{
			this.max = MsgChat.vecChatTab.size();
			this.min = this.max - this.maxTab;
			if (this.min < 0)
			{
				this.min = 0;
			}
		}
	}

	// Token: 0x0600074C RID: 1868 RVA: 0x000709F8 File Offset: 0x0006EBF8
	public void paintRectNew(mGraphics g, int x, int y, int w, int h, bool isNew, int time)
	{
		if (isNew && (time + GameCanvas.gameTick) % 8 < 4)
		{
			TabScreenNew.timeRepaint = 10;
			g.drawRegion(MainTabNew.imgTab[10], 0, 0, w - 2, h - this.wOne5 - 1, 0, x + 1, y + 1, 0, mGraphics.isTrue);
		}
		g.fillRect(x, y + 1, 1, h - 1, mGraphics.isTrue);
		g.fillRect(x + 1, y, w - 2, 1, mGraphics.isTrue);
		g.fillRect(x + w - 1, y + 1, 1, h - 1, mGraphics.isTrue);
	}

	// Token: 0x0600074D RID: 1869 RVA: 0x00070A90 File Offset: 0x0006EC90
	public void paintTabFocus(mGraphics g, int x, int y, int wMainTab)
	{
		for (int i = 0; i <= wMainTab / 32; i++)
		{
			if (i == 0)
			{
				g.drawImage(MainTabNew.imgTab[9], x, y, 0, mGraphics.isTrue);
			}
			else if (i == wMainTab / 32)
			{
				g.drawRegion(MainTabNew.imgTab[9], 0, 0, 32, 32, 2, x + wMainTab - 32, y, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(MainTabNew.imgTab[2], x + i * 32, y, 0, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x0600074E RID: 1870 RVA: 0x00070B24 File Offset: 0x0006ED24
	public void paintBack(mGraphics g)
	{
		int num = this.hDia - this.wOneItem;
		int num2 = this.wDia / 32;
		int num3 = num / 32;
		for (int i = 0; i <= num2; i++)
		{
			for (int j = 0; j <= num3; j++)
			{
				if (i == num2)
				{
					if (j == num3)
					{
						g.drawImage(MainTabNew.imgTab[2], this.xDia + this.wDia - 32, this.yDia + this.hDia - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[2], this.xDia + this.wDia - 32, this.yDia + this.wOneItem + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == num3)
				{
					g.drawImage(MainTabNew.imgTab[2], this.xDia + i * 32, this.yDia + this.hDia - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[2], this.xDia + i * 32, this.yDia + this.wOneItem + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
	}

	// Token: 0x0600074F RID: 1871 RVA: 0x00070C64 File Offset: 0x0006EE64
	public bool setAddFriend(string name)
	{
		for (int i = 0; i < MsgChat.vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
			if ((int)chatDetail.typeChat == (int)ChatDetail.TYPE_ADDFRIEND && chatDetail.friend.CompareTo(name) == 0)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000750 RID: 1872 RVA: 0x00070CC4 File Offset: 0x0006EEC4
	public static void setFocus(int index)
	{
		if (GameCanvas.subDialog != GameCanvas.msgchat && MsgChat.vecChatTab != null && index >= 0 && index < MsgChat.vecChatTab.size())
		{
			MsgChat.idSelect = index;
		}
	}

	// Token: 0x06000751 RID: 1873 RVA: 0x00070D08 File Offset: 0x0006EF08
	public static void setIndexFocus(string name)
	{
		for (int i = 0; i < MsgChat.vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
			if (chatDetail.name.CompareTo(name) == 0)
			{
				MsgChat.idSelect = i;
				break;
			}
		}
	}

	// Token: 0x06000752 RID: 1874 RVA: 0x00070D60 File Offset: 0x0006EF60
	public void checkRemoveText()
	{
		for (int i = 0; i < MsgChat.vecChatTab.size(); i++)
		{
			ChatDetail chatDetail = (ChatDetail)MsgChat.vecChatTab.elementAt(i);
			int num = chatDetail.vecDetail.size();
			if (num > 80)
			{
				for (int j = 0; j < num - 80; j++)
				{
					chatDetail.vecDetail.removeElementAt(i);
				}
				chatDetail.setLim();
			}
		}
	}

	// Token: 0x04000AF4 RID: 2804
	private int wMainTab;

	// Token: 0x04000AF5 RID: 2805
	private int maxTab;

	// Token: 0x04000AF6 RID: 2806
	private int min;

	// Token: 0x04000AF7 RID: 2807
	private int max;

	// Token: 0x04000AF8 RID: 2808
	private int xdich;

	// Token: 0x04000AF9 RID: 2809
	private sbyte maxText = 5;

	// Token: 0x04000AFA RID: 2810
	private static int idSelect = 0;

	// Token: 0x04000AFB RID: 2811
	private int xselect;

	// Token: 0x04000AFC RID: 2812
	public static mVector vecChatTab = new mVector("MsgChat vecChatTab");

	// Token: 0x04000AFD RID: 2813
	private static string[] strName;

	// Token: 0x04000AFE RID: 2814
	public static ChatDetail curentfocus;

	// Token: 0x04000AFF RID: 2815
	public static iCommand cmdChat;

	// Token: 0x04000B00 RID: 2816
	public static iCommand cmdDelete;

	// Token: 0x04000B01 RID: 2817
	public static iCommand cmdClose;

	// Token: 0x04000B02 RID: 2818
	public static iCommand cmdMenu;

	// Token: 0x04000B03 RID: 2819
	public static iCommand cmdOkAdd;

	// Token: 0x04000B04 RID: 2820
	public static iCommand cmdCancelAdd;

	// Token: 0x04000B05 RID: 2821
	private bool isLeft;

	// Token: 0x04000B06 RID: 2822
	private bool isRight;

	// Token: 0x04000B07 RID: 2823
	private Scroll scroll = new Scroll();

	// Token: 0x04000B08 RID: 2824
	private ListNew list;

	// Token: 0x04000B09 RID: 2825
	private Camera cam = new Camera();

	// Token: 0x04000B0A RID: 2826
	public int wOneItem;

	// Token: 0x04000B0B RID: 2827
	public int wOne5;

	// Token: 0x04000B0C RID: 2828
	private int minchat;

	// Token: 0x04000B0D RID: 2829
	private int maxchat;

	// Token: 0x04000B0E RID: 2830
	private int hchat;

	// Token: 0x04000B0F RID: 2831
	private iCommand cmdChat2;
}
