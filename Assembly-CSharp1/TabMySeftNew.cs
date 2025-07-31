using System;

// Token: 0x020000A0 RID: 160
public class TabMySeftNew : MainTabNew
{
	// Token: 0x060007BD RID: 1981 RVA: 0x0007D024 File Offset: 0x0007B224
	public TabMySeftNew(string nametab)
	{
		this.wsize = (int)MainTabNew.wOneItem;
		this.typeTab = MainTabNew.EQUIP;
		if (GameCanvas.isSmallScreen)
		{
			TabMySeftNew.delta = 10;
		}
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.h12 = MainTabNew.hblack / 12;
		this.w5 = MainTabNew.wblack / 5;
		this.numW = MainTabNew.wblack / (int)MainTabNew.wOneItem;
		if (this.numW > 6)
		{
			this.numW = 6;
		}
		this.xStart = this.xBegin + MainTabNew.wblack / 2 - this.numW * (int)MainTabNew.wOneItem / 2 + ((!GameCanvas.isSmallScreen) ? (this.numW / 2) : 0);
		this.yStart = this.yBegin + this.h12 * 10 - (int)MainTabNew.wOneItem;
		this.numH = TabMySeftNew.maxSize / this.numW;
		this.nameTab = nametab;
		if (nametab == null || nametab.Length == 0)
		{
			this.nameTab = "Name Tab";
		}
		this.cmdCloseChange = new iCommand(T.close, -2, this);
		this.cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		this.cmdChange = new iCommand(T.change, 0, this);
		this.cmdChangeEquip = new iCommand(T.equip, 1, this);
		this.cmdPetInfo = new iCommand(T.info, 2, this);
		this.cmdPetFeed = new iCommand(T.choan, 3, this);
		this.cmdNexTab = new iCommand(T.trangbi2, 4, this);
		this.cmdReturn = new iCommand(T.trangbi1, 5, this);
		if (!GameCanvas.isTouch)
		{
			this.left = this.cmdNexTab;
		}
		this.indexTab = 0;
	}

	// Token: 0x060007BF RID: 1983 RVA: 0x0007D26C File Offset: 0x0007B46C
	public override void init()
	{
		if (GameCanvas.isTouch)
		{
			this.idSelect = -1;
		}
		else
		{
			this.idSelect = 0;
		}
		this.isList = false;
		this.listContent = null;
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdBack;
			this.center = this.cmdChange;
		}
		MainTabNew.timePaintInfo = 0;
		base.init();
	}

	// Token: 0x060007C0 RID: 1984 RVA: 0x0007D2D4 File Offset: 0x0007B4D4
	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		if (GameCanvas.isTouch)
		{
			this.idSelect = -1;
		}
		else
		{
			this.idSelect = 0;
		}
		base.backTab();
	}

	// Token: 0x060007C1 RID: 1985 RVA: 0x0007D304 File Offset: 0x0007B504
	public override void commandPointer(int index, int subIndex)
	{
		if ((int)this.idSelect == -1 && index != -1)
		{
			return;
		}
		switch (index + 2)
		{
		case 0:
			MainTabNew.timePaintInfo = 0;
			TabScreenNew.timeRepaint = 10;
			if (!GameCanvas.isTouch)
			{
				this.right = this.cmdBack;
				this.center = this.cmdChange;
			}
			this.isList = false;
			this.vecItemMenu.removeAllElements();
			this.selectList = 0;
			break;
		case 1:
			this.backTab();
			break;
		case 2:
		{
			int num = MainTemplateItem.mItem_Equip_Tem[(int)this.idSelect + (int)this.indexTab];
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + ((int)this.idSelect + (int)this.indexTab));
			if (item == null)
			{
				if (num == -2)
				{
					return;
				}
				if (num == -1)
				{
					if ((int)GameScreen.player.clazz == 2)
					{
						num = 11;
					}
					else if ((int)GameScreen.player.clazz == 3)
					{
						num = 10;
					}
					else
					{
						num = 8 + (int)GameScreen.player.clazz;
					}
				}
			}
			else
			{
				num = item.type_Only_Item;
			}
			if (num == 14)
			{
				if (item != null)
				{
					GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
				}
				return;
			}
			this.listItemMenu(num);
			if (this.vecItemMenu != null && this.vecItemMenu.size() > 0)
			{
				TabScreenNew.timeRepaint = 10;
				this.maxList = this.vecItemMenu.size();
				if (this.maxList > this.numW)
				{
					this.maxList = this.numW;
				}
				int num2 = this.xStart + (int)this.idSelect % this.numW * this.wsize - this.maxList * this.wsize / 2 + (int)MainTabNew.wOneItem / 2;
				int num3 = this.yStart + (int)this.idSelect / this.numW * this.wsize + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5;
				if (num2 < this.xBegin + (int)MainTabNew.wOne5 * 2)
				{
					num2 = this.xBegin + (int)MainTabNew.wOne5 * 2;
				}
				else if (num2 + this.maxList * this.wsize + (int)MainTabNew.wOne5 > this.xBegin + MainTabNew.wblack - (int)MainTabNew.wOne5)
				{
					num2 = this.xBegin + MainTabNew.wblack - (int)MainTabNew.wOne5 - (this.maxList * this.wsize + (int)MainTabNew.wOne5);
				}
				if (num3 + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 > GameCanvas.h - GameCanvas.hCommand / 2)
				{
					num3 = GameCanvas.h - GameCanvas.hCommand / 2 - (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 * 2;
				}
				this.xList = num2;
				this.yList = num3;
				MainScreen.cameraSub.setAllTo((this.vecItemMenu.size() - this.maxList) * this.wsize, 0, 0, 0);
				this.list = new ListNew(this.xList, this.yList, this.maxList * this.wsize, this.wsize, 0, 0, (this.vecItemMenu.size() - this.maxList) * this.wsize);
				this.isList = true;
				TabMySeftNew.mItemInfo = null;
				TabMySeftNew.mItemInfoShow = null;
				if (!GameCanvas.isTouch)
				{
					this.center = this.cmdChangeEquip;
					if (!GameCanvas.isTouch)
					{
						this.right = this.cmdCloseChange;
					}
					else
					{
						this.right = null;
					}
				}
				MainTabNew.timePaintInfo = 0;
			}
			else
			{
				if (!GameCanvas.isTouch)
				{
					this.right = this.cmdBack;
					this.center = this.cmdChange;
				}
				this.isList = false;
				GameCanvas.start_Ok_Dialog(T.khongcovatphanphuhop);
			}
			break;
		}
		case 3:
		{
			Item item = (Item)this.vecItemMenu.elementAt(this.selectList);
			if (item.setNameNull())
			{
				return;
			}
			GlobalService.gI().Use_Item((sbyte)item.Id, this.idSelect);
			MainTabNew.timePaintInfo = 0;
			TabScreenNew.timeRepaint = 10;
			if (!GameCanvas.isTouch)
			{
				this.right = this.cmdBack;
				this.center = this.cmdChange;
			}
			this.isList = false;
			this.vecItemMenu.removeAllElements();
			this.selectList = 0;
			break;
		}
		case 4:
		{
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + this.idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
			}
			break;
		}
		case 5:
		{
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + this.idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.EQUIP);
			}
			mVector mVector = new mVector("TabMySeftNew vecItemMenu");
			mVector.addElement(new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, TabShopNew.INVEN_FOOD_PET)
			{
				petCur = MsgDialog.pet
			});
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		case 6:
			this.indexTab = 12;
			if (GameCanvas.isTouch)
			{
				this.vecListCmd = this.doMenu(null);
				base.setPosCmd(this.vecListCmd);
			}
			if (!GameCanvas.isTouch || (mSystem.isj2me && GameCanvas.isTouch))
			{
				this.left = this.cmdReturn;
			}
			break;
		case 7:
			this.indexTab = 0;
			if (GameCanvas.isTouch)
			{
				this.vecListCmd = this.doMenu(null);
				base.setPosCmd(this.vecListCmd);
			}
			if (!GameCanvas.isTouch || (mSystem.isj2me && GameCanvas.isTouch))
			{
				this.left = this.cmdNexTab;
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060007C2 RID: 1986 RVA: 0x0007D944 File Offset: 0x0007BB44
	public override void paint(mGraphics g)
	{
		GameScreen.player.paintShowPlayer(g, this.xBegin + this.w5 + TabMySeftNew.delta / 2, this.yBegin + this.h12 * 5 / 2 + 15, 0);
		g.setColor(MainTabNew.color[1]);
		if (!GameCanvas.isSmallScreen)
		{
			g.fillRect(this.xBegin + this.w5 / 4, this.yBegin + this.h12 * 6 - this.h12 / 2, this.w5 * 2 - this.w5 / 2 + TabMySeftNew.delta, 1, mGraphics.isFalse);
			g.fillRect(this.xBegin + this.w5 * 2 + TabMySeftNew.delta + this.w5 / 4, this.yBegin + this.h12 * 6 - this.h12 / 2, this.w5 * 2 + TabMySeftNew.delta + this.w5 / 2, 1, mGraphics.isFalse);
		}
		g.fillRect(this.xBegin + this.w5 * 2 + TabMySeftNew.delta, this.yBegin + this.h12 / 4, 1, this.h12 * 8 - this.h12 / 2, mGraphics.isFalse);
		mFont.tahoma_7_orange.drawString(g, string.Empty + GameScreen.player.pointPk, this.xBegin + 15, this.yBegin + this.h12 * 6 - this.h12 / 2 + 4 - ((!GameCanvas.isSmallScreen) ? 0 : 8), 0, mGraphics.isFalse);
		mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointSucKhoe, this.xBegin + 15, this.yBegin + this.h12 * 6 - this.h12 / 2 + GameCanvas.hText + 4 - ((!GameCanvas.isSmallScreen) ? 0 : 12), 0, mGraphics.isFalse);
		g.drawImage(MainTabNew.img_pkIcn, this.xBegin + 4, this.yBegin + this.h12 * 6 - this.h12 / 2 + 4 - ((!GameCanvas.isSmallScreen) ? 0 : 8), 0, mGraphics.isFalse);
		g.drawImage(MainTabNew.img_skIcn, this.xBegin + 4, this.yBegin + this.h12 * 6 - this.h12 / 2 + GameCanvas.hText + 4 - ((!GameCanvas.isSmallScreen) ? 0 : 12), 0, mGraphics.isFalse);
		if (!GameCanvas.isSmallScreen)
		{
			for (int i = 0; i < 5; i++)
			{
				g.drawRegion(MainTabNew.imgTab[5], 0, i * 10, 10, 10, 0, this.xBegin + this.w5 * 2 + TabMySeftNew.delta + 10 + i % 3 * this.w5 + 3, this.yBegin + this.h12 * 6 - this.h12 / 2 + 9 + i / 3 * this.h12, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
				string st = string.Empty;
				if (this.isList)
				{
					if (TabMySeftNew.mItemInfoShow != null)
					{
						st = TabMySeftNew.meffskill[i] + string.Empty;
					}
				}
				else
				{
					st = GameScreen.player.mKhangChar[i];
				}
				mFont.tahoma_7_white.drawString(g, st, this.xBegin + this.w5 * 2 + TabMySeftNew.delta + 14 + i % 3 * this.w5, this.yBegin + this.h12 * 6 - this.h12 / 2 + 3 + i / 3 * this.h12, 0, mGraphics.isFalse);
			}
		}
		this.paintArenaPoint(g);
		g.setColor(MainTabNew.color[4]);
		byte b = 0;
		while ((int)b < TabMySeftNew.maxSize)
		{
			int num = this.xStart + (int)b % this.numW * this.wsize;
			int num2 = this.yStart + (int)b / this.numW * this.wsize;
			Item item = (Item)Item.VecEquipPlayer.get(string.Empty + ((int)b + (int)this.indexTab));
			if (item != null)
			{
				if (item.Id > -1)
				{
					item.paintItem(g, num + (int)MainTabNew.wOneItem / 2, num2 + (int)MainTabNew.wOneItem / 2, (int)MainTabNew.wOneItem, 0, 0);
				}
				else if ((int)this.indexTab <= 0)
				{
					g.drawRegion(MainTabNew.imgTab[6], 0, (int)(b * 20), 20, 20, 0, num + (int)MainTabNew.wOneItem / 2, num2 + (int)MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			else if ((int)this.indexTab <= 0)
			{
				g.drawRegion(MainTabNew.imgTab[6], 0, (int)(b * 20), 20, 20, 0, num + (int)MainTabNew.wOneItem / 2, num2 + (int)MainTabNew.wOneItem / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			}
			g.setColor(MainTabNew.color[4]);
			g.drawRect(num, num2, this.wsize, this.wsize, mGraphics.isFalse);
			b += 1;
		}
		g.setColor(MainTabNew.color[3]);
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && (int)this.idSelect >= 0)
		{
			int num3 = this.xStart + (int)this.idSelect % this.numW * this.wsize;
			int num4 = this.yStart + (int)this.idSelect / this.numW * this.wsize;
			g.drawRect(num3, num4, this.wsize, this.wsize, mGraphics.isFalse);
			g.setColor(MainTabNew.color[2]);
			g.drawRect(num3 + 1, num4 + 1, this.wsize - 2, this.wsize - 2, mGraphics.isFalse);
		}
		if (this.isList)
		{
			if (TabMySeftNew.mItemInfoShow != null)
			{
				this.paintInfoPlayer(g, this.xBegin + this.w5 * 2 + 4 + TabMySeftNew.delta, this.yBegin + 4, TabMySeftNew.mItemInfoShow, this.isShowInfo);
			}
			else
			{
				mFont.tahoma_7_white.drawString(g, T.danglaydulieu, this.xBegin + this.w5 * 2 + 4 + TabMySeftNew.delta, this.yBegin + 4, 0, mGraphics.isFalse);
			}
		}
		else
		{
			this.paintInfoPlayer(g, this.xBegin + this.w5 * 2 + 4 + TabMySeftNew.delta, this.yBegin + 4, GameScreen.player.mInfoChar, true);
		}
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if ((MainTabNew.timePaintInfo > MainTabNew.timeRequest || (this.isList && MainTabNew.timePaintInfo > 5)) && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
			{
				base.paintPopupContent(g, MainTabNew.longwidth <= 0 && this.isList);
			}
			if (this.isList)
			{
				this.paintList(g);
			}
		}
		if (this.vecListCmd != null)
		{
			for (int j = 0; j < this.vecListCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x060007C3 RID: 1987 RVA: 0x0007E0B4 File Offset: 0x0007C2B4
	public void paintList(mGraphics g)
	{
		int num = this.vecItemMenu.size();
		int num2 = (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2;
		if (num2 < 32)
		{
			num2 = 32;
		}
		AvMain.paintDialog(g, this.xList - this.maxList / 2 - (int)MainTabNew.wOne5, this.yList - (int)MainTabNew.wOne5, this.maxList * (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2, num2, 12);
		g.setClip(this.xList + ((num != 1) ? 0 : 1), this.yList, this.maxList * this.wsize + 2, (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2);
		g.translate(-MainScreen.cameraSub.xCam, 0);
		for (int i = 0; i < num; i++)
		{
			Item item = (Item)this.vecItemMenu.elementAt(i);
			item.paintItem(g, this.xList + i * this.wsize + (int)MainTabNew.wOneItem / 2 + ((num != 1) ? 0 : 1), this.yList + (int)MainTabNew.wOneItem / 2, (int)MainTabNew.wOneItem, 0, 0);
		}
		if (num > 0)
		{
			g.setColor(MainTabNew.color[2]);
			g.drawRect(this.xList + this.selectList * this.wsize + ((num != 1) ? 0 : 1), this.yList + 1, this.wsize, this.wsize, mGraphics.isFalse);
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x060007C4 RID: 1988 RVA: 0x0007E240 File Offset: 0x0007C440
	public void paintInfoPlayer(mGraphics g, int x, int y, MainInfoItem[] mItemInfo, bool isNew)
	{
		if (mItemInfo != null)
		{
			foreach (MainInfoItem mainInfoItem in mItemInfo)
			{
				if (mainInfoItem != null)
				{
					if (mainInfoItem.id <= 4 || mainInfoItem.id == 40 || mainInfoItem.id == 14)
					{
						if (mainInfoItem.value != 0)
						{
							mFont mFont = mFont.tahoma_7_white;
							if (!isNew)
							{
								mFont = mFont.tahoma_7_black;
							}
							else
							{
								mFont = MainTabNew.setTextColor((int)Item.colorInfoItem[mainInfoItem.id]);
							}
							string st = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
							mFont.drawString(g, st, x, y, 0, mGraphics.isTrue);
							int num = 0;
							if (GameScreen.player.vecBuff != null && !GameCanvas.isSmallScreen)
							{
								for (int j = 0; j < GameScreen.player.vecBuff.size(); j++)
								{
									MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(j);
									if (mainBuff.minfo != null)
									{
										for (int k = 0; k < mainBuff.minfo.Length; k++)
										{
											if (mainInfoItem.id == mainBuff.minfo[k].id)
											{
												num += mainBuff.minfo[k].value;
											}
										}
									}
								}
							}
							if (num != 0)
							{
								string str = string.Empty;
								mFont mFont2 = mFont.tahoma_7_green;
								if (num > 0)
								{
									str = " +" + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], num);
								}
								else
								{
									str = " " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], num);
									mFont2 = mFont.tahoma_7_red;
								}
								int width = mFont.tahoma_7_white.getWidth(st);
								mFont2.drawString(g, " " + str, x + width, y, 0, mGraphics.isTrue);
							}
							y += GameCanvas.hText;
						}
					}
				}
			}
		}
	}

	// Token: 0x060007C5 RID: 1989 RVA: 0x0007E46C File Offset: 0x0007C66C
	public override void update()
	{
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if (this.listContent != null)
			{
				this.listContent.moveCamera();
			}
			if (this.isList)
			{
				if (GameCanvas.isTouch)
				{
					this.list.moveCamera();
				}
				else
				{
					MainScreen.cameraSub.UpdateCamera();
				}
			}
			this.updateContent();
		}
		else
		{
			MainTabNew.timePaintInfo = 0;
		}
		GameScreen.player.updateEye();
	}

	// Token: 0x060007C6 RID: 1990 RVA: 0x0007E4EC File Offset: 0x0007C6EC
	public void updateContent()
	{
		if ((int)this.idSelect == -1)
		{
			return;
		}
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (this.isList)
			{
				if (MainTabNew.timePaintInfo == 5)
				{
					this.setPaintInfo();
				}
			}
			else if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				this.setPaintInfo();
			}
		}
		else if (this.isList && !this.isShowInfo)
		{
			if (TabMySeftNew.mItemInfo == null)
			{
				this.timeUpdateInfo++;
				if (this.timeUpdateInfo % 100 == 3)
				{
					MainItem mainItem = (MainItem)this.vecItemMenu.elementAt(this.selectList);
					if (mainItem != null)
					{
						GlobalService.gI().Item_More_Info(this.idSelect, (sbyte)mainItem.Id);
					}
				}
			}
			else
			{
				this.mColorInfo = new int[TabMySeftNew.mItemInfo.Length];
				for (int i = 0; i < TabMySeftNew.mItemInfo.Length; i++)
				{
					MainInfoItem mainInfoItem = TabMySeftNew.mItemInfo[i];
					this.mColorInfo[i] = 0;
					for (int j = 0; j < GameScreen.player.mInfoChar.Length; j++)
					{
						MainInfoItem mainInfoItem2 = GameScreen.player.mInfoChar[i];
						if (mainInfoItem.id == mainInfoItem2.id)
						{
							if (mainInfoItem.value > mainInfoItem2.value)
							{
								this.mColorInfo[i] = 2;
							}
							else if (mainInfoItem.value < mainInfoItem2.value)
							{
								this.mColorInfo[i] = 3;
							}
							break;
						}
					}
				}
				this.isShowInfo = true;
			}
		}
	}

	// Token: 0x060007C7 RID: 1991 RVA: 0x0007E694 File Offset: 0x0007C894
	public override void updatekey()
	{
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if (this.isList)
			{
				if (this.listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (this.listContent.cmtoX > 0)
						{
							this.listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (this.listContent.cmtoX < this.listContent.cmxLim)
						{
							this.listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = this.listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				int num = this.selectList;
				if (GameCanvas.keyMyHold[4])
				{
					this.selectList--;
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					this.selectList++;
					GameCanvas.clearKeyHold(6);
				}
				this.selectList = base.resetSelect(this.selectList, this.vecItemMenu.size() - 1, true);
				if (num != this.selectList)
				{
					MainScreen.cameraSub.moveCamera(this.selectList * this.wsize - this.maxList * this.wsize / 2, 0);
					MainTabNew.timePaintInfo = 0;
				}
			}
			else
			{
				int num2 = (int)this.idSelect;
				if (this.listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (this.listContent.cmtoX > 0)
						{
							this.listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (this.listContent.cmtoX < this.listContent.cmxLim)
						{
							this.listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = this.listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				else if (GameCanvas.keyMyHold[2])
				{
					if ((int)this.idSelect >= this.numW)
					{
						this.idSelect = (sbyte)((int)this.idSelect - (int)((sbyte)this.numW));
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if ((int)this.idSelect < TabMySeftNew.maxSize - this.numW)
					{
						this.idSelect = (sbyte)((int)this.idSelect + (int)((sbyte)this.numW));
					}
					GameCanvas.clearKeyHold(8);
				}
				if (GameCanvas.keyMyHold[4])
				{
					if ((int)this.idSelect % this.numW == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						this.idSelect -= 1;
					}
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					this.idSelect += 1;
					GameCanvas.clearKeyHold(6);
				}
				if ((int)this.idSelect >= 0)
				{
					this.idSelect = (sbyte)base.resetSelect((int)this.idSelect, TabMySeftNew.maxSize - 1, false);
				}
				else
				{
					this.idSelect = -1;
					this.vecListCmd = null;
				}
				if (num2 != (int)this.idSelect)
				{
					MainTabNew.timePaintInfo = 0;
					this.listContent = null;
				}
			}
		}
		base.updatekey();
	}

	// Token: 0x060007C8 RID: 1992 RVA: 0x0007EA30 File Offset: 0x0007CC30
	public override void setPaintInfo()
	{
		if ((int)this.idSelect == -1 && !this.isList)
		{
			return;
		}
		Item item;
		if (this.isList)
		{
			item = (Item)this.vecItemMenu.elementAt(this.selectList);
		}
		else
		{
			item = (Item)Item.VecEquipPlayer.get(string.Empty + ((int)this.idSelect + (int)this.indexTab));
		}
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
		if (item.ItemCatagory == 9)
		{
			MsgDialog.pet = (PetItem)item;
			this.isPet = true;
		}
		else
		{
			this.isPet = false;
		}
		int num = 0;
		this.mContent = item.mcontent;
		this.moreInfoconten = item.moreContenGem;
		this.mPlusContent = item.mPlusContent;
		this.mPlusColor = item.mPlusColor;
		this.mcolor = item.mColor;
		this.name = item.itemName;
		this.colorName = item.colorNameItem;
		if (this.isList)
		{
			TabMySeftNew.mItemInfo = null;
			this.timeUpdateInfo = 0;
			this.isShowInfo = false;
			int num2 = mFont.tahoma_7b_white.getWidth(item.itemName) + 8;
			if (num2 < 40)
			{
				num2 = 40;
			}
			this.wContent = num2;
		}
		this.listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			if (this.mContent == null)
			{
				num++;
			}
			else
			{
				num += this.mContent.Length;
			}
			if (this.mPlusContent != null)
			{
				num += this.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - MainTabNew.hMaxContent + 4 * GameCanvas.hText);
			}
			else if (GameCanvas.isTouch)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 4 * GameCanvas.hText);
			}
			return;
		}
		if (this.mContent == null)
		{
			num++;
		}
		else
		{
			num += this.mContent.Length;
		}
		if (this.mPlusContent != null)
		{
			num += this.mPlusContent.Length;
		}
		if (this.isList)
		{
			this.yCon = this.yList - GameCanvas.hText * 2 + (int)MainTabNew.wOne5 / 2;
			this.mSubContent = null;
			this.mContent = null;
			this.mPlusContent = null;
			this.xCon = this.xList + this.maxList * (int)MainTabNew.wOneItem / 2 - this.wContent / 2;
		}
		else
		{
			this.yCon = this.yStart + (int)this.idSelect / this.numW * (int)MainTabNew.wOneItem - 9 - (num + 1) * GameCanvas.hText;
			this.wContent = item.sizeW;
			if ((int)this.idSelect % this.numW < 2)
			{
				this.xCon = this.xStart + (int)MainTabNew.wOneItem / 2 + (int)this.idSelect % this.numW * (int)MainTabNew.wOneItem;
			}
			else if ((int)this.idSelect % this.numW < 4)
			{
				this.xCon = this.xStart + (int)MainTabNew.wOneItem / 2 + (int)this.idSelect % this.numW * (int)MainTabNew.wOneItem - 45;
			}
			else
			{
				this.xCon = this.xStart + (int)MainTabNew.wOneItem / 2 + (int)this.idSelect % this.numW * (int)MainTabNew.wOneItem - 90;
			}
		}
		if (this.yCon + MainScreen.cameraSub.yCam < 2)
		{
			this.yCon = 2 - MainScreen.cameraSub.yCam;
		}
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			this.listContent = new ListNew(this.xCon, this.yCon, this.wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	// Token: 0x060007C9 RID: 1993 RVA: 0x0007EE58 File Offset: 0x0007D058
	public void listItemMenu(int type)
	{
		this.vecItemMenu.removeAllElements();
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item.ItemCatagory == 3 && item.type_Only_Item == type && (item.classcharItem == (int)GameScreen.player.clazz || item.classcharItem > 3))
			{
				this.vecItemMenu.addElement(item);
			}
		}
	}

	// Token: 0x060007CA RID: 1994 RVA: 0x0007EEE4 File Offset: 0x0007D0E4
	public override void updatePointer()
	{
		bool flag = false;
		if (this.isList)
		{
			if (this.listContent != null && GameCanvas.isPoint(this.listContent.x, this.listContent.y, this.listContent.maxW, this.listContent.maxH))
			{
				this.listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isTouch && !flag)
			{
				this.list.updatePos_LEFT_RIGHT();
				MainScreen.cameraSub.xCam = this.list.cmx;
			}
			if (GameCanvas.isPointerSelect && !flag)
			{
				if (GameCanvas.isPoint(this.xList, this.yList, this.wsize * this.maxList, (int)MainTabNew.wOneItem))
				{
					sbyte b = (sbyte)((MainScreen.cameraSub.xCam + GameCanvas.px - this.xList) / this.wsize);
					if ((int)b >= 0 && (int)b < this.vecItemMenu.size())
					{
						if ((int)b == this.selectList)
						{
							this.cmdChangeEquip.perform();
						}
						else
						{
							this.selectList = (int)b;
							MainTabNew.timePaintInfo = 0;
						}
						this.listContent = null;
						mSystem.outz("nullllllllllllll00000000000");
					}
					GameCanvas.isPointerSelect = false;
				}
				else if (!GameCanvas.isPoint(0, GameCanvas.h - GameCanvas.hCommand, GameCanvas.w, GameCanvas.hCommand))
				{
					this.cmdCloseChange.perform();
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		else
		{
			if (this.listContent != null && GameCanvas.isPoint(this.listContent.x, this.listContent.y, this.listContent.maxW, this.listContent.maxH))
			{
				this.listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isPointSelect(this.xStart, this.yStart, this.wsize * this.numW, this.wsize * this.numH) && !flag)
			{
				GameCanvas.isPointerSelect = false;
				sbyte b2 = (sbyte)((GameCanvas.px - this.xStart) / this.wsize + (GameCanvas.py - this.yStart) / this.wsize * this.numW);
				if ((int)b2 >= 0 && (int)b2 < TabMySeftNew.maxSize)
				{
					if ((int)b2 == (int)this.idSelect)
					{
						this.cmdChange.perform();
					}
					else
					{
						this.idSelect = b2;
						MainTabNew.timePaintInfo = 0;
						if ((int)this.idSelect >= 0)
						{
							Item item = (Item)Item.VecEquipPlayer.get(string.Empty + ((int)this.idSelect + (int)this.indexTab));
							if (item != null)
							{
								if (MainTabNew.longwidth > 0)
								{
									this.vecListCmd = this.doMenu(item);
									base.setPosCmd(this.vecListCmd);
								}
							}
							else if ((int)this.indexTab > 0)
							{
								this.vecListCmd = this.doMenu(item);
								base.setPosCmd(this.vecListCmd);
							}
						}
					}
					this.listContent = null;
					mSystem.outz("nullllllllllllll00000000000");
					if ((int)MainTabNew.Focus != (int)MainTabNew.INFO)
					{
						MainTabNew.Focus = MainTabNew.INFO;
					}
				}
			}
		}
		if (this.vecListCmd != null)
		{
			for (int i = 0; i < this.vecListCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(i);
				if (iCommand != null)
				{
					iCommand.updatePointer();
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x060007CB RID: 1995 RVA: 0x0007F274 File Offset: 0x0007D474
	public mVector doMenu(Item item)
	{
		mVector mVector = new mVector("TabMySeftNew menu");
		if ((int)this.indexTab <= 0)
		{
			mVector.addElement(this.cmdNexTab);
		}
		else if ((int)this.indexTab > 0)
		{
			mVector.addElement(this.cmdReturn);
		}
		if (item != null && item.type_Only_Item == 14)
		{
			mVector.addElement(this.cmdPetFeed);
		}
		return mVector;
	}

	// Token: 0x060007CC RID: 1996 RVA: 0x0007F2E4 File Offset: 0x0007D4E4
	public void paintArenaPoint(mGraphics g)
	{
		if (!GameCanvas.isSmallScreen)
		{
			int num = 5;
			g.drawRegion(MainTabNew.img_arenaIcn, 0, 0, 10, 9, 0, this.xBegin + this.w5 * 2 + TabMySeftNew.delta + 10 + num % 3 * this.w5 + 3, this.yBegin + this.h12 * 6 - this.h12 / 2 + 9 + num / 3 * this.h12, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
			mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointArena, this.xBegin + this.w5 * 2 + TabMySeftNew.delta + 14 + num % 3 * this.w5, this.yBegin + this.h12 * 6 - this.h12 / 2 + 3 + num / 3 * this.h12, 0, mGraphics.isFalse);
		}
		else
		{
			mFont.tahoma_7_orange.drawString(g, string.Empty + Player.PointArena, this.xBegin + 15, this.yBegin + this.h12 * 6 - this.h12 / 2 + 2 * GameCanvas.hText + 3 - ((!GameCanvas.isSmallScreen) ? 0 : 16), 0, mGraphics.isFalse);
			g.drawImage(MainTabNew.img_arenaIcn, this.xBegin + 4, this.yBegin + this.h12 * 6 - this.h12 / 2 + 2 * GameCanvas.hText + 4 - ((!GameCanvas.isSmallScreen) ? 0 : 16), 0, mGraphics.isFalse);
		}
	}

	// Token: 0x04000C04 RID: 3076
	public int numW;

	// Token: 0x04000C05 RID: 3077
	public int numH;

	// Token: 0x04000C06 RID: 3078
	public static int maxSize = 12;

	// Token: 0x04000C07 RID: 3079
	private int h12;

	// Token: 0x04000C08 RID: 3080
	private int w5;

	// Token: 0x04000C09 RID: 3081
	public static int delta = 0;

	// Token: 0x04000C0A RID: 3082
	private sbyte idSelect;

	// Token: 0x04000C0B RID: 3083
	private int xStart;

	// Token: 0x04000C0C RID: 3084
	private int yStart;

	// Token: 0x04000C0D RID: 3085
	public static MainInfoItem[] mItemInfo;

	// Token: 0x04000C0E RID: 3086
	public static MainInfoItem[] mItemInfoShow;

	// Token: 0x04000C0F RID: 3087
	private int[] mColorInfo;

	// Token: 0x04000C10 RID: 3088
	private mVector vecItemMenu = new mVector("TabMySeftNew vecItemMenu");

	// Token: 0x04000C11 RID: 3089
	public static string[] meffskill = new string[5];

	// Token: 0x04000C12 RID: 3090
	private bool isList;

	// Token: 0x04000C13 RID: 3091
	private int maxList;

	// Token: 0x04000C14 RID: 3092
	private int selectList;

	// Token: 0x04000C15 RID: 3093
	private int xList;

	// Token: 0x04000C16 RID: 3094
	private int yList;

	// Token: 0x04000C17 RID: 3095
	private int timeUpdateInfo;

	// Token: 0x04000C18 RID: 3096
	private bool isShowInfo;

	// Token: 0x04000C19 RID: 3097
	private mVector vecListCmd = new mVector("vec List cmd");

	// Token: 0x04000C1A RID: 3098
	private sbyte indexTab;

	// Token: 0x04000C1B RID: 3099
	private iCommand cmdChange;

	// Token: 0x04000C1C RID: 3100
	private iCommand cmdChangeEquip;

	// Token: 0x04000C1D RID: 3101
	private iCommand cmdCloseChange;

	// Token: 0x04000C1E RID: 3102
	private iCommand cmdPetInfo;

	// Token: 0x04000C1F RID: 3103
	private iCommand cmdPetFeed;

	// Token: 0x04000C20 RID: 3104
	private iCommand cmdNexTab;

	// Token: 0x04000C21 RID: 3105
	private iCommand cmdReturn;

	// Token: 0x04000C22 RID: 3106
	private ListNew list;

	// Token: 0x04000C23 RID: 3107
	private int wsize;

	// Token: 0x020000A1 RID: 161
	public class infoItem
	{
		// Token: 0x060007CD RID: 1997 RVA: 0x0007F490 File Offset: 0x0007D690
		public infoItem(MainInfoItem[] mItemInfo, short index)
		{
			this.mInfo = mItemInfo;
			this.index = index;
		}

		// Token: 0x04000C24 RID: 3108
		private short index;

		// Token: 0x04000C25 RID: 3109
		private MainInfoItem[] mInfo;
	}
}
