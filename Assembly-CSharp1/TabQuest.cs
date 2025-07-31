using System;

// Token: 0x020000A2 RID: 162
public class TabQuest : MainTabNew
{
	// Token: 0x060007CE RID: 1998 RVA: 0x0007F4A8 File Offset: 0x0007D6A8
	public TabQuest(string name)
	{
		this.typeTab = MainTabNew.QUEST;
		TabQuest.me = this;
		this.nameTab = string.Empty;
		this.HQuest = GameCanvas.hText;
		if (GameCanvas.isTouch)
		{
			this.HQuest = GameCanvas.hCommand;
		}
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.init();
		this.cmdView = new iCommand(T.view, 0, this);
		this.cmdRead = new iCommand(T.read, 1, this);
		this.cmdBack = new iCommand(T.back, -1, this);
		this.cmdCancle = new iCommand(T.cancel, 2, this);
		int num = MainTabNew.ylongwidth + this.hSmall;
		int xlongwidth = MainTabNew.xlongwidth;
		this.cmdCancle.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 15, null, this.cmdCancle.caption);
		if (MainTabNew.is320)
		{
			this.cmdCancle.setPos(this.cmdCancle.xCmd, num - 10, PaintInfoGameScreen.fraButton2, this.cmdCancle.caption);
		}
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
	}

	// Token: 0x060007D0 RID: 2000 RVA: 0x0007F620 File Offset: 0x0007D820
	public override void init()
	{
		this.resetTab(true);
		this.xdich = (MainTabNew.wblack - this.wMainTab * 2) / 2;
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdBack;
		}
		this.name = null;
		this.mContent = null;
		this.mPlusContent = null;
		this.questCurrent = null;
		this.listContent = null;
		base.init();
	}

	// Token: 0x060007D1 RID: 2001 RVA: 0x0007F68C File Offset: 0x0007D88C
	public override void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		this.idSelect = 0;
		base.backTab();
	}

	// Token: 0x060007D2 RID: 2002 RVA: 0x0007F6A8 File Offset: 0x0007D8A8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
			MapScr.gI().Show();
			break;
		case 2:
		{
			MainQuest mainQuest = this.QuestSelect();
			if (mainQuest != null)
			{
				GameCanvas.start_Quest_DialogRead(mainQuest);
			}
			break;
		}
		case 3:
			if (this.questCurrent == null)
			{
				return;
			}
			GameCanvas.start_Left_Dialog(T.hoihuyQuest + this.questCurrent.name, new iCommand(T.cancel, 3, this));
			break;
		case 4:
			if (this.questCurrent == null)
			{
				return;
			}
			GlobalService.gI().quest((short)this.questCurrent.ID, (!this.questCurrent.isMain) ? 1 : 0, 2);
			this.resetTab(true);
			GameCanvas.end_Dialog();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060007D3 RID: 2003 RVA: 0x0007F798 File Offset: 0x0007D998
	public MainQuest QuestSelect()
	{
		int num = MainQuest.vecQuestDoing_Main.size();
		if (this.idSelect < 0 || this.idSelect >= num + MainQuest.vecQuestDoing_Sub.size())
		{
			return null;
		}
		MainQuest mainQuest;
		if (this.idSelect < num)
		{
			mainQuest = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(this.idSelect);
			mainQuest.strShowDialog = mainQuest.strShortDetail;
			if ((int)mainQuest.typeQuest == 0 || (int)mainQuest.typeQuest == 1)
			{
				MainQuest mainQuest2 = mainQuest;
				mainQuest2.strShowDialog = mainQuest2.strShowDialog + "\n " + T.mucdohoanthanh;
				for (int i = 0; i < mainQuest.mIdQuest.Length; i++)
				{
					string text = string.Empty;
					if ((int)mainQuest.typeQuest == 1)
					{
						CatalogyMonster catalogyMonster = MainMonster.getCatalogyMonster((int)mainQuest.mIdQuest[i]);
						if (catalogyMonster != null)
						{
							text = catalogyMonster.name;
						}
					}
					else if (TabQuest.nameItemQuest != null)
					{
						text = TabQuest.nameItemQuest[(int)mainQuest.mIdQuest[i]];
					}
					MainQuest mainQuest3 = mainQuest;
					string strShowDialog = mainQuest3.strShowDialog;
					mainQuest3.strShowDialog = string.Concat(new object[]
					{
						strShowDialog,
						"\n ",
						text,
						(!text.Equals(string.Empty)) ? ": " : string.Empty,
						mainQuest.mQuestGot[i],
						"/",
						mainQuest.mtotalQuest[i]
					});
				}
			}
		}
		else
		{
			mainQuest = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(this.idSelect - num);
			mainQuest.strShowDialog = mainQuest.strShortDetail;
			if ((int)mainQuest.typeQuest == 0 || (int)mainQuest.typeQuest == 1)
			{
				MainQuest mainQuest4 = mainQuest;
				mainQuest4.strShowDialog = mainQuest4.strShowDialog + "\n " + T.mucdohoanthanh;
				for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
				{
					string text2 = string.Empty;
					if ((int)mainQuest.typeQuest == 1)
					{
						text2 = string.Empty;
						if (MainMonster.getCatalogyMonster((int)mainQuest.mIdQuest[j]) != null)
						{
							CatalogyMonster catalogyMonster2 = MainMonster.getCatalogyMonster((int)mainQuest.mIdQuest[j]);
							if (catalogyMonster2 != null)
							{
								text2 = catalogyMonster2.name;
							}
						}
					}
					else
					{
						text2 = TabQuest.nameItemQuest[(int)mainQuest.mIdQuest[j]];
					}
					MainQuest mainQuest5 = mainQuest;
					string strShowDialog = mainQuest5.strShowDialog;
					mainQuest5.strShowDialog = string.Concat(new object[]
					{
						strShowDialog,
						"\n ",
						text2,
						(!text2.Equals(string.Empty)) ? ": " : string.Empty,
						mainQuest.mQuestGot[j],
						"/",
						mainQuest.mtotalQuest[j]
					});
				}
			}
		}
		return mainQuest;
	}

	// Token: 0x060007D4 RID: 2004 RVA: 0x0007FA6C File Offset: 0x0007DC6C
	public void setPaint()
	{
		if (MainTabNew.longwidth == 0)
		{
			return;
		}
		this.vecListCmd.removeAllElements();
		this.questCurrent = this.QuestSelect();
		if (this.questCurrent != null)
		{
			this.name = this.questCurrent.name;
			this.mContent = mFont.tahoma_7_white.splitFontArray(this.questCurrent.strShowDialog, MainTabNew.longwidth - 8);
			int num = this.questCurrent.strShowDialog.Length * GameCanvas.hText - (MainTabNew.hMaxContent - iCommand.hButtonCmd * 2);
			if (num < 0)
			{
				num = 0;
			}
			this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num);
			if (GameCanvas.isTouch)
			{
				this.vecListCmd.addElement(this.cmdCancle);
			}
			this.mPlusContent = null;
		}
		else
		{
			this.name = null;
			this.mContent = null;
			this.mPlusContent = null;
			this.questCurrent = null;
		}
	}

	// Token: 0x060007D5 RID: 2005 RVA: 0x0007FB6C File Offset: 0x0007DD6C
	public override void paint(mGraphics g)
	{
		int num = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + this.xdich;
		int num2 = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOne5;
		if (this.tabSelect == 0)
		{
			this.paintTabBig(g, num + this.wMainTab, num2 - 1, this.wMainTab);
			mFont.tahoma_7_white.drawString(g, T.mQuest[1], num + this.wMainTab + this.wMainTab / 2, num2 + (int)MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
		}
		else
		{
			this.paintTabBig(g, num, num2 - 1, this.wMainTab);
			mFont.tahoma_7_white.drawString(g, T.mQuest[0], num + this.wMainTab / 2, num2 + (int)MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
			num += this.wMainTab;
		}
		this.xselect = num;
		this.paintTabFocus(g, this.xselect, num2 - 1, this.wMainTab);
		mFont mFont = mFont.tahoma_7b_white;
		if ((int)MainTabNew.Focus == (int)MainTabNew.TAB)
		{
			mFont = mFont.tahoma_7_white;
		}
		mFont.drawString(g, T.mQuest[this.tabSelect], this.xselect + this.wMainTab / 2, num2 + (int)MainTabNew.wOneItem / 2 - 7, 2, mGraphics.isFalse);
		g.setClip(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack);
		g.translate(0, -MainScreen.cameraSub.yCam);
		num2 = this.yBegin + 4;
		num = this.xBegin + 4;
		int num3 = 0;
		if (this.maxSize == 0)
		{
			this.paintRong(g, num + MainTabNew.wblack / 2 - 4, num2 + (int)MainTabNew.wOne5);
			num2 += this.HQuest;
		}
		else if (this.tabSelect == 1)
		{
			for (int i = 0; i < MainQuest.vecQuestFinish.size(); i++)
			{
				if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect == i)
				{
					g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isTrue);
				}
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(i);
				mFont.tahoma_7b_white.drawString(g, mainQuest.name, num + 18, num2, 0, mGraphics.isTrue);
				if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect == i)
				{
					for (int j = 0; j < mainQuest.mstrHelp.Length; j++)
					{
						num2 += GameCanvas.hText;
						mFont.tahoma_7_white.drawString(g, mainQuest.mstrHelp[j], num + 25, num2, 0, mGraphics.isTrue);
					}
				}
				num2 += this.HQuest;
				num3++;
			}
		}
		else
		{
			if (MainQuest.vecQuestDoing_Main.size() > 0)
			{
				AvMain.Font3dWhite(g, T.mainQuest, num, num2, 0);
				num2 += this.HQuest;
				for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
				{
					if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect == num3)
					{
						g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isFalse);
					}
					MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
					mFont.tahoma_7b_white.drawString(g, mainQuest2.name, num + 18, num2, 0, mGraphics.isFalse);
					num2 += this.HQuest;
					num3++;
				}
			}
			if (MainQuest.vecQuestDoing_Sub.size() > 0)
			{
				AvMain.Font3dWhite(g, T.subQuest, num, num2, 0);
				num2 += this.HQuest;
				for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
				{
					MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
					if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect == num3)
					{
						g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num - GameCanvas.gameTick % 3, num2, 0, mGraphics.isFalse);
					}
					mFont.tahoma_7b_white.drawString(g, mainQuest3.name, num + 18, num2, 0, mGraphics.isFalse);
					num2 += this.HQuest;
					num3++;
				}
			}
		}
		num2 += this.HQuest / 2;
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect == num3)
		{
			g.setColor(MainTabNew.color[3]);
			g.fillRect(this.xBegin + MainTabNew.wblack / 2 - 49, num2 - 1, 98, 18, mGraphics.isFalse);
		}
		this.xMap = this.xBegin + MainTabNew.wblack / 2 - 48;
		this.yMap = num2;
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, this.xMap, this.yMap, 96, 16, 4);
		}
		else
		{
			for (int m = 0; m < 4; m++)
			{
				g.drawRegion(MainTabNew.imgTab[8], 0, 0, 24, 16, 0, this.xMap + 24 * m, this.yMap, 0, mGraphics.isFalse);
			}
		}
		mFont.tahoma_7_white.drawString(g, T.viewMap, this.xBegin + MainTabNew.wblack / 2, num2 + 2, 2, mGraphics.isFalse);
		if (MainTabNew.longwidth > 0 && (int)MainTabNew.Focus == (int)MainTabNew.INFO && this.name != null)
		{
			this.paintInfoQuest(g);
			if (this.vecListCmd != null)
			{
				for (int n = 0; n < this.vecListCmd.size(); n++)
				{
					iCommand iCommand = (iCommand)this.vecListCmd.elementAt(n);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
		}
	}

	// Token: 0x060007D6 RID: 2006 RVA: 0x00080154 File Offset: 0x0007E354
	public void paintInfoQuest(mGraphics g)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		GameCanvas.resetTrans(g);
		int xlongwidth = MainTabNew.xlongwidth;
		int ylongwidth = MainTabNew.ylongwidth;
		int num2 = ylongwidth;
		g.setClip(xlongwidth + 1, num2 + 1, MainTabNew.longwidth - 2, this.hSmall - 2);
		MainTabNew.paintNameItem(g, xlongwidth + MainTabNew.longwidth / 2, num2 + (int)MainTabNew.wOneItem / 2 - 5, MainTabNew.longwidth, this.name, this.colorName);
		num2 += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
		GameCanvas.resetTrans(g);
		this.scr.setStyle(this.mContent.Length + 2, GameCanvas.hText + 2, xlongwidth, num2 + (int)MainTabNew.wOneItem + 2 - GameCanvas.hText * 2, MainTabNew.longwidth, MainTabNew.hMaxContent + GameCanvas.hText, true, 1);
		this.scr.setClip(g, xlongwidth, num2 + (int)MainTabNew.wOneItem + 2 - GameCanvas.hText, MainTabNew.longwidth, MainTabNew.hMaxContent - (int)MainTabNew.wOneItem - 2 - iCommand.hButtonCmd / 2);
		if (this.mContent != null)
		{
			for (int i = 0; i < this.mContent.Length; i++)
			{
				if (this.mContent[i] != null)
				{
					mFont mFont;
					if (this.mcolor != null)
					{
						mFont = MainTabNew.setTextColor(this.mcolor[i]);
					}
					else
					{
						mFont = mFont.tahoma_7_white;
					}
					mFont.drawString(g, this.mContent[i], xlongwidth + num, num2 + 2 + (i + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					if (this.mSubContent != null)
					{
						int num3 = mFont.getWidth(this.mContent[i]) + 5;
						mFont = MainTabNew.setTextColor(this.mSubColor[i]);
						mFont.drawString(g, this.mSubContent[i], xlongwidth + num3 + num, num2 + 2 + (i + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					}
				}
			}
		}
		g.endClip();
		GameCanvas.resetTrans(g);
	}

	// Token: 0x060007D7 RID: 2007 RVA: 0x0008034C File Offset: 0x0007E54C
	public void paintTabFocus(mGraphics g, int x, int y, int wMainTab)
	{
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, x, y, wMainTab, 32, 2);
		}
		else
		{
			for (int i = 0; i <= wMainTab / 32; i++)
			{
				if (i == 0)
				{
					g.drawImage(MainTabNew.imgTab[9], x, y, 0, mGraphics.isFalse);
				}
				else if (i == wMainTab / 32)
				{
					g.drawRegion(MainTabNew.imgTab[9], 0, 0, 32, 32, 2, x + wMainTab - 32, y, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[2], x + i * 32, y, 0, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x060007D8 RID: 2008 RVA: 0x000803FC File Offset: 0x0007E5FC
	public void paintTabBig(mGraphics g, int x, int y, int wMainTab)
	{
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, x, y, wMainTab, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1, 3);
		}
		else
		{
			for (int i = 0; i <= wMainTab / 32; i++)
			{
				if (i == 0)
				{
					g.drawRegion(MainTabNew.imgTab[11], 0, 0, 32, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1, 0, x, y, 0, mGraphics.isFalse);
				}
				else if (i == wMainTab / 32)
				{
					g.drawRegion(MainTabNew.imgTab[11], 0, 0, 32, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1, 2, x + wMainTab - 32, y, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[10], 0, 0, 32, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1, 0, x + i * 32, y, 0, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x060007D9 RID: 2009 RVA: 0x000804EC File Offset: 0x0007E6EC
	public override void update()
	{
		ScrollResult scrollResult = this.scr.updateKey();
		if (scrollResult.isDowning || scrollResult.isFinish)
		{
		}
		if (scrollResult.isFinish || GameCanvas.isKeyPressed(5))
		{
		}
		this.scr.updatecm();
		MainScreen.cameraSub.UpdateCamera();
		base.update();
	}

	// Token: 0x060007DA RID: 2010 RVA: 0x0008054C File Offset: 0x0007E74C
	public override void updatekey()
	{
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			int num = this.idSelect;
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
			if (GameCanvas.keyMyHold[4])
			{
				if (this.tabSelect == 0)
				{
					MainTabNew.Focus = MainTabNew.TAB;
					this.idSelect = 0;
				}
				else
				{
					this.tabSelect = 0;
					this.resetTab(true);
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (this.tabSelect == 1)
				{
					this.tabSelect = 0;
					this.resetTab(true);
				}
				else
				{
					this.tabSelect = 1;
					this.resetTab(true);
				}
				GameCanvas.clearKeyHold(6);
			}
			if (this.maxSize > 0)
			{
				this.idSelect = base.resetSelect(this.idSelect, this.maxSize, true);
			}
			else
			{
				this.idSelect = 0;
			}
			this.setPaint();
			if (this.tabSelect == 1)
			{
				if (!GameCanvas.isTouch)
				{
					if (this.idSelect < this.maxSize)
					{
						if (this.center != null)
						{
							this.center = null;
						}
					}
					else if (this.center != this.cmdView)
					{
						this.center = this.cmdView;
						TabScreenNew.timeRepaint = 10;
					}
					if (this.left != null)
					{
						this.left = null;
					}
				}
				if (num != this.idSelect)
				{
					this.resetTab(false);
					if (this.idSelect == this.maxSize)
					{
						MainScreen.cameraSub.moveCamera(0, MainScreen.cameraSub.yLimit);
					}
					else
					{
						MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(this.idSelect);
						MainScreen.cameraSub.moveCamera(0, this.idSelect * this.HQuest + mainQuest.mstrHelp.Length * GameCanvas.hText - MainTabNew.hblack / 2);
					}
				}
			}
			else if (this.idSelect < this.maxSize)
			{
				if (!GameCanvas.isTouch)
				{
					if (this.center != this.cmdRead)
					{
						this.center = this.cmdRead;
						TabScreenNew.timeRepaint = 10;
					}
					if (num != this.idSelect)
					{
						MainScreen.cameraSub.moveCamera(0, (this.idSelect + 2) * this.HQuest - MainTabNew.hblack / 2);
					}
				}
			}
			else if (this.center != this.cmdView && !GameCanvas.isTouch)
			{
				this.center = this.cmdView;
				TabScreenNew.timeRepaint = 10;
				if (num != this.idSelect)
				{
					MainScreen.cameraSub.moveCamera(0, MainScreen.cameraSub.yLimit);
				}
				if (this.left != null)
				{
					this.left = null;
				}
			}
		}
		base.updatekey();
	}

	// Token: 0x060007DB RID: 2011 RVA: 0x00080848 File Offset: 0x0007EA48
	public void resetTab(bool isResetCmy)
	{
		TabScreenNew.timeRepaint = 10;
		int num;
		if (this.tabSelect == 0)
		{
			this.maxSize = MainQuest.vecQuestDoing_Main.size() + MainQuest.vecQuestDoing_Sub.size();
			num = this.maxSize + ((MainQuest.vecQuestDoing_Main.size() <= 0) ? 0 : 1) + ((MainQuest.vecQuestDoing_Sub.size() <= 0) ? 0 : 1) + 2;
		}
		else
		{
			this.maxSize = MainQuest.vecQuestFinish.size();
			if (this.idSelect < this.maxSize)
			{
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(this.idSelect);
				num = this.maxSize + 2 + mainQuest.mstrHelp.Length;
			}
			else
			{
				num = this.maxSize + 2;
			}
		}
		this.hmax = num * this.HQuest - MainTabNew.hblack + 5;
		if (this.hmax < 0)
		{
			this.hmax = 0;
		}
		this.wMainTab = (int)MainTabNew.wOneItem * 3;
		if (isResetCmy)
		{
			MainScreen.cameraSub.setAll(0, this.hmax, 0, 0);
		}
		else
		{
			MainScreen.cameraSub.yLimit = this.hmax;
		}
	}

	// Token: 0x060007DC RID: 2012 RVA: 0x00080980 File Offset: 0x0007EB80
	private void paintRong(mGraphics g, int xp, int yp)
	{
		mFont.tahoma_7_white.drawString(g, T.khongconhiemvu, xp, yp, 2, mGraphics.isFalse);
	}

	// Token: 0x060007DD RID: 2013 RVA: 0x0008099C File Offset: 0x0007EB9C
	public override void updatePointer()
	{
		if (GameCanvas.isPointerSelect)
		{
			int num = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + this.xdich;
			int y = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOne5;
			if (GameCanvas.isPoint(num, y, this.wMainTab, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1))
			{
				if (this.tabSelect != 0)
				{
					this.tabSelect = 0;
					this.resetTab(true);
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPoint(num + this.wMainTab, y, this.wMainTab, (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 + 1))
			{
				if (this.tabSelect != 1)
				{
					this.tabSelect = 1;
					this.resetTab(true);
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (GameCanvas.isPointerSelect && GameCanvas.isPoint(this.xMap, this.yMap - MainScreen.cameraSub.yCam - 4, 96, 24))
		{
			GameCanvas.isPointerSelect = false;
			this.cmdView.perform();
		}
		if (this.maxSize > 0)
		{
			if (GameCanvas.isPointSelect(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack))
			{
				if (this.tabSelect == 0)
				{
					int num2 = this.yBegin + 4 + this.HQuest;
					int num3 = (GameCanvas.py - num2 + MainScreen.cameraSub.yCam) / this.HQuest;
					if (MainQuest.vecQuestDoing_Main.size() > 0 && MainQuest.vecQuestDoing_Sub.size() > 0)
					{
						if (num3 == MainQuest.vecQuestDoing_Main.size())
						{
							num3 = -1;
						}
						else if (num3 > MainQuest.vecQuestDoing_Main.size())
						{
							num3--;
						}
					}
					if (num3 > -1 && num3 <= this.maxSize)
					{
						if (num3 == this.idSelect)
						{
							if (MainTabNew.longwidth == 0 && this.idSelect < this.maxSize)
							{
								this.cmdRead.perform();
							}
						}
						else
						{
							this.idSelect = num3;
							this.idSelect = base.resetSelect(this.idSelect, this.maxSize, false);
						}
						GameCanvas.isPointerSelect = false;
					}
					this.setPaint();
				}
				else
				{
					int num4 = (GameCanvas.py - this.yBegin + MainScreen.cameraSub.yCam) / this.HQuest;
					if (num4 < this.idSelect)
					{
						this.idSelect = num4;
					}
					else if (this.idSelect < this.maxSize)
					{
						MainQuest mainQuest = (MainQuest)MainQuest.vecQuestFinish.elementAt(this.idSelect);
						int num5 = this.yBegin + this.idSelect * this.HQuest + mainQuest.mstrHelp.Length * GameCanvas.hText;
						if (num5 < GameCanvas.py + MainScreen.cameraSub.yCam)
						{
							num4 = (GameCanvas.py + MainScreen.cameraSub.yCam - num5) / this.HQuest + this.idSelect;
							this.idSelect = num4;
							this.idSelect = base.resetSelect(this.idSelect, this.maxSize, false);
							GameCanvas.isPointerSelect = false;
						}
					}
					this.setPaint();
				}
			}
			if (GameCanvas.isPointerMove)
			{
				if (this.hmax > 0 && GameCanvas.pxLast > this.xBegin && GameCanvas.pxLast < this.xBegin + MainTabNew.wblack && GameCanvas.pyLast > this.yBegin && GameCanvas.pyLast < this.yBegin + MainTabNew.hblack)
				{
					if (!this.isTran)
					{
						this.isTran = true;
						this.yCambegin = MainScreen.cameraSub.yCam;
					}
					else
					{
						MainScreen.cameraSub.yTo = this.yCambegin + GameCanvas.pyLast - GameCanvas.py;
						if (MainScreen.cameraSub.yTo > MainScreen.cameraSub.yLimit)
						{
							MainScreen.cameraSub.yTo = MainScreen.cameraSub.yLimit;
						}
						if (MainScreen.cameraSub.yTo < 0)
						{
							MainScreen.cameraSub.yTo = 0;
						}
						TabScreenNew.timeRepaint = 10;
					}
				}
			}
			else
			{
				this.isTran = false;
				this.yCambegin = 0;
			}
			if (this.vecListCmd != null && (int)MainTabNew.Focus == (int)MainTabNew.INFO && this.name != null)
			{
				for (int i = 0; i < this.vecListCmd.size(); i++)
				{
					iCommand iCommand = (iCommand)this.vecListCmd.elementAt(i);
					iCommand.updatePointer();
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x04000C26 RID: 3110
	private int idSelect;

	// Token: 0x04000C27 RID: 3111
	private int maxSize;

	// Token: 0x04000C28 RID: 3112
	private int hmax;

	// Token: 0x04000C29 RID: 3113
	private Scroll scr = new Scroll();

	// Token: 0x04000C2A RID: 3114
	public static TabQuest me;

	// Token: 0x04000C2B RID: 3115
	private int xdich;

	// Token: 0x04000C2C RID: 3116
	private int wMainTab;

	// Token: 0x04000C2D RID: 3117
	private int xselect;

	// Token: 0x04000C2E RID: 3118
	private int HQuest;

	// Token: 0x04000C2F RID: 3119
	private int tabSelect;

	// Token: 0x04000C30 RID: 3120
	private iCommand cmdView;

	// Token: 0x04000C31 RID: 3121
	private iCommand cmdRead;

	// Token: 0x04000C32 RID: 3122
	private new iCommand cmdBack;

	// Token: 0x04000C33 RID: 3123
	private iCommand cmdCancle;

	// Token: 0x04000C34 RID: 3124
	private int xMap;

	// Token: 0x04000C35 RID: 3125
	private int yMap;

	// Token: 0x04000C36 RID: 3126
	public static string[] nameItemQuest;

	// Token: 0x04000C37 RID: 3127
	private mVector vecListCmd = new mVector("TabQuest vecListCmd");

	// Token: 0x04000C38 RID: 3128
	private MainQuest questCurrent;

	// Token: 0x04000C39 RID: 3129
	private bool isTran;

	// Token: 0x04000C3A RID: 3130
	private int yCambegin;
}
