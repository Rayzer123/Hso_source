using System;

// Token: 0x0200007E RID: 126
public class EventScreen : MainScreen
{
	// Token: 0x060005BD RID: 1469 RVA: 0x00054538 File Offset: 0x00052738
	public EventScreen()
	{
		this.cmdSeL = new iCommand(T.view, 2, 0, this);
		this.cmdDel = new iCommand(T.delMess, 2, 1, this);
		this.hItem = GameCanvas.hCommand + 5;
		this.wDia = GameCanvas.w / 4 * 3;
		if (this.wDia > 180)
		{
			this.wDia = 180;
		}
	}

	// Token: 0x060005BF RID: 1471 RVA: 0x000545E4 File Offset: 0x000527E4
	public void setCaptionCmd()
	{
		this.cmdSeL.caption = T.view;
		this.cmdDel.caption = T.delMess;
	}

	// Token: 0x060005C0 RID: 1472 RVA: 0x00054614 File Offset: 0x00052814
	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		PaintInfoGameScreen.numMess = 0;
	}

	// Token: 0x060005C1 RID: 1473 RVA: 0x00054624 File Offset: 0x00052824
	public void init()
	{
		for (int i = 0; i < EventScreen.vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)EventScreen.vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				EventScreen.vecListEvent.removeElement(mainEvent);
				i--;
			}
		}
		this.hbutton = iCommand.hButtonCmd * 3 / 2;
		if (GameCanvas.isTouch)
		{
			this.hbutton = 0;
		}
		this.maxSizeList = (GameCanvas.h / 4 * 3 - (10 + GameCanvas.hCommand)) / this.hItem + 1;
		this.hDia = this.hItem * this.maxSizeList + 10 + GameCanvas.hCommand;
		this.maxSizeList += 2;
		this.min = 0;
		this.max = this.maxSizeList;
		if (this.max > EventScreen.vecListEvent.size())
		{
			this.max = EventScreen.vecListEvent.size();
		}
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2 - GameCanvas.hCommand / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.updateList();
	}

	// Token: 0x060005C2 RID: 1474 RVA: 0x00054774 File Offset: 0x00052974
	private void updateList()
	{
		EventScreen.cmdList.removeAllElements();
		iCommand iCommand = new iCommand(T.close, -1, this);
		if (GameCanvas.isTouch)
		{
			iCommand.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			EventScreen.cmdList.addElement(iCommand);
		}
		else
		{
			if (EventScreen.vecListEvent.size() > 0)
			{
				iCommand o = new iCommand(T.menu, 1, this);
				EventScreen.cmdList.addElement(o);
			}
			EventScreen.cmdList.addElement(iCommand);
			this.setPosCmdNew(0);
		}
		this.cameraDia.setAll(0, this.hItem * EventScreen.vecListEvent.size() - (this.hDia - GameCanvas.hCommand - this.hbutton), 0, 0);
		this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, this.cameraDia.yLimit);
		if (this.idSelect >= EventScreen.vecListEvent.size())
		{
			if (GameCanvas.isTouch)
			{
				this.idSelect = -1;
			}
			else
			{
				this.idSelect = 0;
			}
		}
	}

	// Token: 0x060005C3 RID: 1475 RVA: 0x000548AC File Offset: 0x00052AAC
	public void setPosCmdNew(int yplus)
	{
		this.idCommand = 0;
		if (EventScreen.cmdList.size() > 0)
		{
			int num = EventScreen.cmdList.size();
			if (num == 1)
			{
				this.xBegin = this.xDia + this.wDia / 2;
				this.w2cmd = 0;
			}
			else if (num == 2)
			{
				this.w2cmd = 20;
				this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
			}
			else
			{
				this.w2cmd = 20;
				this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)EventScreen.cmdList.elementAt(i);
				iCommand.isSelect = false;
				if (num == 3 && i == 2)
				{
					iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5) + yplus, null, iCommand.caption);
				}
				else
				{
					iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), this.yDia + this.hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 + i / 2 * (iCommand.hButtonCmd + 5) + yplus, null, iCommand.caption);
				}
				if (i == 0)
				{
					iCommand.isSelect = true;
				}
			}
		}
	}

	// Token: 0x060005C4 RID: 1476 RVA: 0x00054A58 File Offset: 0x00052C58
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.lastScreen.Show(this.lastScreen.lastScreen);
			break;
		case 2:
			if (this.idSelect < 0 || this.idSelect >= EventScreen.vecListEvent.size())
			{
				return;
			}
			if (this.idSelect > 0)
			{
				mVector mVector = new mVector("EventScreen vec");
				mVector.addElement(this.cmdSeL);
				mVector.addElement(this.cmdDel);
				GameCanvas.menu2.startAt(mVector, 2, T.mevent, false, null);
			}
			else
			{
				this.cmdSeL.perform();
			}
			break;
		case 3:
		{
			if (this.idSelect < 0 || this.idSelect >= EventScreen.vecListEvent.size())
			{
				return;
			}
			bool isre = false;
			if (subIndex == 1)
			{
				isre = true;
			}
			MainEvent mevent = (MainEvent)EventScreen.vecListEvent.elementAt(this.idSelect);
			this.doEvent(isre, mevent);
			break;
		}
		}
	}

	// Token: 0x060005C5 RID: 1477 RVA: 0x00054B70 File Offset: 0x00052D70
	public override void paint(mGraphics g)
	{
		if (this.lastScreen != null)
		{
			this.lastScreen.paint(g);
		}
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.mevent);
		int num = this.yDia + GameCanvas.hCommand + 3;
		if (EventScreen.vecListEvent.size() > 0)
		{
			g.setClip(this.xDia + 4, num, this.wDia - 8, this.hDia - GameCanvas.hCommand - this.hbutton - 6);
			g.translate(0, -this.cameraDia.yCam);
			if (this.idSelect >= 0)
			{
				g.setColor(11904141);
				g.fillRect(this.xDia + 4, num - 2 + this.idSelect * this.hItem, this.wDia - 8, this.hItem - 1, mGraphics.isTrue);
			}
			num += this.hItem * this.min;
			for (int i = this.min; i < this.max; i++)
			{
				if (i >= 0 || i < EventScreen.vecListEvent.size())
				{
					MainEvent mainEvent = (MainEvent)EventScreen.vecListEvent.elementAt(i);
					int num2 = 0;
					if (mainEvent.isNew == 1 && GameCanvas.gameTick % 20 > 9)
					{
						num2 = 1;
					}
					PaintInfoGameScreen.fraEvent.drawFrame(mainEvent.IDCmd * 2 + 1 - num2, this.xDia + 20, num + this.hItem / 2 - 2, 0, 3, g);
					if (GameCanvas.isTouch && i > 0)
					{
						PaintInfoGameScreen.fraClose.drawFrame(0, this.xDia + this.wDia - 20, num + this.hItem / 2 - 2, 0, 3, g);
					}
					mFont.tahoma_7b_white.drawString(g, mainEvent.nameEvent, this.xDia + 35, num + 1, 0, mGraphics.isTrue);
					mFont.tahoma_7_white.drawString(g, mainEvent.contentEvent, this.xDia + 42, num + 13, 0, mGraphics.isTrue);
					num += this.hItem;
					if (i < EventScreen.vecListEvent.size() - 1)
					{
						g.setColor(AvMain.color[4]);
						g.fillRect(this.xDia + 6, num - 3, this.wDia - 12, 1, mGraphics.isTrue);
					}
				}
			}
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, T.noEvent, this.xDia + this.wDia / 2, num + 3, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
		if (EventScreen.cmdList != null)
		{
			for (int j = 0; j < EventScreen.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)EventScreen.cmdList.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x060005C6 RID: 1478 RVA: 0x00054E68 File Offset: 0x00053068
	public override void update()
	{
		if (GameCanvas.currentScreen == this)
		{
			this.lastScreen.update();
		}
		int yCam = this.cameraDia.yCam;
		if (GameCanvas.isTouch)
		{
			this.list.moveCamera();
		}
		else
		{
			this.cameraDia.UpdateCamera();
		}
		base.update();
		int num = EventScreen.vecListEvent.size();
		for (int i = 0; i < EventScreen.vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)EventScreen.vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				EventScreen.vecListEvent.removeElement(mainEvent);
				i--;
			}
		}
		if (this.idSelect < 0 || this.idSelect >= EventScreen.vecListEvent.size())
		{
			if (GameCanvas.isTouch)
			{
				this.idSelect = -1;
			}
			else
			{
				this.idSelect = 0;
			}
		}
		if (this.cameraDia.yCam != yCam || num != EventScreen.vecListEvent.size())
		{
			this.min = this.cameraDia.yCam / this.hItem;
			this.max = this.min + this.maxSizeList;
			if (this.max > EventScreen.vecListEvent.size())
			{
				this.max = EventScreen.vecListEvent.size();
				this.min = this.max - this.maxSizeList;
			}
			if (this.min < 0)
			{
				this.min = 0;
			}
		}
	}

	// Token: 0x060005C7 RID: 1479 RVA: 0x00054FE8 File Offset: 0x000531E8
	public override void updatekey()
	{
		if (EventScreen.vecListEvent.size() > 0)
		{
			if (GameCanvas.keyMyHold[2])
			{
				this.idSelect--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.idSelect++;
				GameCanvas.clearKeyHold(8);
			}
			this.idSelect = base.resetSelect(this.idSelect, EventScreen.vecListEvent.size() - 1, true);
			this.cameraDia.moveCamera(0, this.idSelect * this.hItem - (this.hDia / 2 - GameCanvas.hCommand - this.hbutton));
		}
		else if (EventScreen.cmdList.size() > 1)
		{
			EventScreen.cmdList.removeAllElements();
			EventScreen.cmdList.addElement(new iCommand(T.close, -1, this));
			this.setPosCmdNew(0);
			this.idSelect = 0;
		}
		if (EventScreen.cmdList != null)
		{
			int num = EventScreen.cmdList.size();
			if (!GameCanvas.isTouch && num > 0)
			{
				int num2 = this.idCommand;
				if (GameCanvas.keyMyHold[4])
				{
					this.idCommand--;
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					this.idCommand++;
					GameCanvas.clearKeyHold(6);
				}
				this.idCommand = base.resetSelect(this.idCommand, num - 1, false);
				if (num2 != this.idCommand)
				{
					for (int i = 0; i < num; i++)
					{
						iCommand iCommand = (iCommand)EventScreen.cmdList.elementAt(i);
						if (i == this.idCommand)
						{
							iCommand.isSelect = true;
						}
						else
						{
							iCommand.isSelect = false;
						}
					}
				}
			}
		}
		if (GameCanvas.keyMyHold[5])
		{
			GameCanvas.clearKeyHold(5);
			if (EventScreen.cmdList != null && this.idCommand < EventScreen.cmdList.size())
			{
				((iCommand)EventScreen.cmdList.elementAt(this.idCommand)).perform();
			}
		}
	}

	// Token: 0x060005C8 RID: 1480 RVA: 0x000551FC File Offset: 0x000533FC
	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			this.list.update_Pos_UP_DOWN();
			this.cameraDia.yCam = this.list.cmx;
		}
		if (EventScreen.vecListEvent.size() > 0 && GameCanvas.isPointSelect(this.xDia, this.yDia + GameCanvas.hCommand, this.wDia, this.hDia - GameCanvas.hCommand))
		{
			int num = (GameCanvas.py - (this.yDia + GameCanvas.hCommand)) / this.hItem;
			if (num >= 0 && num <= EventScreen.vecListEvent.size() - 1)
			{
				this.idSelect = num;
				this.idSelect = base.resetSelect(this.idSelect, EventScreen.vecListEvent.size() - 1, false);
				bool isre = false;
				if (GameCanvas.isPointSelect(this.xDia + this.wDia - 30, this.yDia + GameCanvas.hCommand, 30, this.hDia - GameCanvas.hCommand) && this.idSelect > 0)
				{
					isre = true;
				}
				MainEvent mevent = (MainEvent)EventScreen.vecListEvent.elementAt(this.idSelect);
				this.doEvent(isre, mevent);
				GameCanvas.isPointerSelect = false;
			}
		}
		if (EventScreen.cmdList != null)
		{
			for (int i = 0; i < EventScreen.cmdList.size(); i++)
			{
				iCommand iCommand = (iCommand)EventScreen.cmdList.elementAt(i);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x060005C9 RID: 1481 RVA: 0x00055374 File Offset: 0x00053574
	public void doEvent(bool isre, MainEvent mevent)
	{
		if (isre)
		{
			mevent.isRemove = true;
			return;
		}
		if (PaintInfoGameScreen.numMess > 0)
		{
			PaintInfoGameScreen.numMess--;
		}
		switch (mevent.IDCmd)
		{
		case 0:
			MsgChat.setIndexFocus(mevent.nameEvent);
			GameCanvas.start_Chat_Dialog();
			mevent.isNew = 0;
			break;
		case 1:
		{
			mVector mVector = new mVector("EventScreen vec2");
			mVector.addElement(new iCommand(T.chapnhan, 1, 1, mevent));
			mVector.addElement(new iCommand(T.tuchoi, 1, 2, mevent));
			mVector.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.yeucauketban, mVector);
			mevent.isNew = 0;
			break;
		}
		case 2:
		{
			mVector mVector = new mVector("EventScreen vec3");
			mVector.addElement(new iCommand(T.chapnhan, 2, 1, mevent));
			mVector.addElement(new iCommand(T.tuchoi, 2, 0, mevent));
			mVector.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.loimoiParty, mVector);
			mevent.isNew = 0;
			break;
		}
		case 3:
		{
			mVector mVector = new mVector("EventScreen vec4");
			mVector.addElement(new iCommand(T.chapnhan, 3, 1, mevent));
			mVector.addElement(new iCommand(T.tuchoi, 3, 0, mevent));
			mVector.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.hoigiaodich, mVector);
			mevent.isNew = 0;
			break;
		}
		case 4:
		{
			mVector mVector = new mVector("EventScreen vec5");
			mVector.addElement(new iCommand(T.chapnhan, 4, 1, mevent));
			mVector.addElement(new iCommand(T.info, 4, 2, mevent));
			mVector.addElement(new iCommand(T.cancel, 4, 0, mevent));
			GameCanvas.start_Select_Dialog(string.Concat(new object[]
			{
				mevent.nameEvent,
				T.hoithachdau,
				mevent.numThachDau,
				" ",
				T.coin,
				"."
			}), mVector);
			mevent.isNew = 0;
			break;
		}
		case 5:
		{
			mVector mVector = new mVector("EventScreen vec6");
			mVector.addElement(new iCommand(T.chapnhan, 5, 1, mevent));
			mVector.addElement(new iCommand(T.close, -1));
			GameCanvas.start_Select_Dialog(mevent.nameEvent + T.moivaoclan, mVector);
			mevent.isNew = 0;
			break;
		}
		}
	}

	// Token: 0x060005CA RID: 1482 RVA: 0x00055604 File Offset: 0x00053804
	public static MainEvent setEvent(string name, sbyte type)
	{
		for (int i = 0; i < EventScreen.vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)EventScreen.vecListEvent.elementAt(i);
			if (mainEvent.isRemove)
			{
				EventScreen.vecListEvent.removeElement(mainEvent);
				i--;
			}
			else if (mainEvent.IDCmd == (int)type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return mainEvent;
			}
		}
		return null;
	}

	// Token: 0x060005CB RID: 1483 RVA: 0x00055680 File Offset: 0x00053880
	public static MainEvent setEventShow(string name, sbyte type)
	{
		for (int i = 0; i < EventScreen.vecEventShow.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)EventScreen.vecEventShow.elementAt(i);
			if (mainEvent.IDCmd == (int)type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return mainEvent;
			}
		}
		return null;
	}

	// Token: 0x060005CC RID: 1484 RVA: 0x000556DC File Offset: 0x000538DC
	public static int setIndexEvent(string name, sbyte type)
	{
		for (int i = 0; i < EventScreen.vecListEvent.size(); i++)
		{
			MainEvent mainEvent = (MainEvent)EventScreen.vecListEvent.elementAt(i);
			if (mainEvent.IDCmd == (int)type && mainEvent.nameEvent.CompareTo(name) == 0)
			{
				return i;
			}
		}
		return -1;
	}

	// Token: 0x060005CD RID: 1485 RVA: 0x00055738 File Offset: 0x00053938
	public void addEvent(string namecheck, sbyte type, string content, int numThachdau)
	{
		MainEvent mainEvent = EventScreen.setEvent(namecheck, type);
		if (mainEvent == null)
		{
			mainEvent = new MainEvent(0, (int)type, namecheck, content);
			EventScreen.vecListEvent.addElement(mainEvent);
			this.updateList();
			this.min = this.cameraDia.yCam / this.hItem;
			this.max = this.min + this.maxSizeList;
			if (this.max > EventScreen.vecListEvent.size())
			{
				this.max = EventScreen.vecListEvent.size();
				this.min = this.max - this.maxSizeList;
			}
			if (this.min < 0)
			{
				this.min = 0;
			}
		}
		else if ((int)type == 0)
		{
			mainEvent.contentEvent = content;
		}
		if (namecheck.CompareTo(T.tinden) != 0)
		{
			PaintInfoGameScreen.numMess++;
			mainEvent.isNew = 1;
			mainEvent.numThachDau = numThachdau;
			if ((int)type != 0 || (namecheck.CompareTo(T.tabBangHoi) != 0 && namecheck.CompareTo(T.tabThuLinh) != 0))
			{
				MainEvent mainEvent2 = EventScreen.setEventShow(namecheck, type);
				if (mainEvent2 == null)
				{
					MainEvent o = new MainEvent(mainEvent.IDObj, mainEvent.IDCmd, mainEvent.nameEvent, mainEvent.contentEvent);
					EventScreen.vecEventShow.addElement(o);
				}
				else if ((int)type == 0)
				{
					mainEvent2.contentEvent = mainEvent.contentEvent;
				}
			}
		}
	}

	// Token: 0x04000838 RID: 2104
	public int hItem;

	// Token: 0x04000839 RID: 2105
	public int wDia;

	// Token: 0x0400083A RID: 2106
	public int maxSizeList;

	// Token: 0x0400083B RID: 2107
	public int hbutton;

	// Token: 0x0400083C RID: 2108
	public int hDia;

	// Token: 0x0400083D RID: 2109
	public int min;

	// Token: 0x0400083E RID: 2110
	public int max;

	// Token: 0x0400083F RID: 2111
	public int xDia;

	// Token: 0x04000840 RID: 2112
	public int yDia;

	// Token: 0x04000841 RID: 2113
	public int numw;

	// Token: 0x04000842 RID: 2114
	public int numh;

	// Token: 0x04000843 RID: 2115
	public int idSelect;

	// Token: 0x04000844 RID: 2116
	public int idCommand;

	// Token: 0x04000845 RID: 2117
	private iCommand cmdSeL;

	// Token: 0x04000846 RID: 2118
	private iCommand cmdDel;

	// Token: 0x04000847 RID: 2119
	public static mVector vecListEvent = new mVector("EventScreen vecListEvent");

	// Token: 0x04000848 RID: 2120
	public static mVector vecEventShow = new mVector("EventScreen vecEventShow");

	// Token: 0x04000849 RID: 2121
	public static mVector cmdList = new mVector("EventScreen cmdList");

	// Token: 0x0400084A RID: 2122
	private Camera cameraDia = new Camera();

	// Token: 0x0400084B RID: 2123
	private ListNew list;

	// Token: 0x0400084C RID: 2124
	private int xBegin;

	// Token: 0x0400084D RID: 2125
	private int w2cmd;
}
