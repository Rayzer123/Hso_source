using System;

// Token: 0x020000A4 RID: 164
public class TabShopNew : MainTabNew
{
	// Token: 0x0600080A RID: 2058 RVA: 0x00086B74 File Offset: 0x00084D74
	public TabShopNew(mVector vec, sbyte typeShop, string nametab, int idTab, sbyte isTypeShop)
	{
		this.typeTab = typeShop;
		this.isShop = false;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + 1;
		this.numW = MainTabNew.wblack / (int)MainTabNew.wOneItem;
		this.numHPaint = MainTabNew.hblack / (int)MainTabNew.wOneItem;
		this.maxSize = vec.size();
		if (this.maxSize % this.numW != 0)
		{
			this.maxSize += this.numW - this.maxSize % this.numW;
		}
		if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			this.vecShop = Item.VecInvetoryPlayer;
			if (this.maxSize < (int)Player.maxInven)
			{
				this.maxSize = (int)Player.maxInven;
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			this.vecShop = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			this.vecShop = Item.VecChestPlayer;
			if (this.maxSize < (int)Player.maxChest)
			{
				this.maxSize = (int)Player.maxChest;
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			this.vecShop = Item.VecPetContainer;
			if (this.maxSize < (int)Player.maxPet)
			{
				this.maxSize = (int)Player.maxChest;
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			this.vecShop = Item.VecClanInvetory;
		}
		else
		{
			this.vecShop = vec;
			TabShopNew.IdTabSave = idTab;
			this.isShop = true;
		}
		this.maxSize = 42;
		this.currentTab = 0;
		TabShopNew.maxTab = (sbyte)(Player.maxInven / 42);
		if (this.isShop)
		{
			this.maxSize = this.vecShop.size();
		}
		if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			TabShopNew.maxTab = (sbyte)(Player.maxPet / 42);
		}
		this.numH = (this.maxSize - 1) / this.numW + 1;
		this.nameTab = nametab;
		this.IDTab = idTab;
		this.isTypeShop = isTypeShop;
		if ((int)isTypeShop == (int)TabShopNew.SHOP_KHAM_NGOC)
		{
			this.numofGem = 2;
		}
		if ((int)isTypeShop == (int)TabShopNew.SHOP_GHEP_NGOC || (int)isTypeShop == (int)TabShopNew.SHOP_ANY_NGUYEN_LIEU)
		{
			this.numofGem = 5;
		}
		if (nametab == null || nametab.Length == 0)
		{
			this.nameTab = "Name Tab";
		}
		this.cmdHoiMua = new iCommand(T.buy, 0, this);
		this.cmdSelect = new iCommand(T.use, 6, this);
		this.cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		this.cmdBuyPotion = new iCommand(T.buy, 2, this);
		this.cmdMua = new iCommand(T.buy, 3, this);
		this.cmdHoiXoaItem = new iCommand(T.vucbo, 4, this);
		this.cmdXoaItem = new iCommand(T.vucbo, 5, this);
		this.cmdMenuInven = new iCommand(T.select, 7, this);
		this.cmdSetKey = new iCommand(T.setKey, 8, this);
		this.cmdHoiSell = new iCommand(T.sell, 11, this);
		this.cmdSell = new iCommand(T.sell, 10, this);
		this.cmdGetChest = new iCommand(T.layra, 13, this);
		this.cmdSetChest = new iCommand(T.catvao, 14, this);
		this.cmdGetPotionChest = new iCommand(T.layra, 15, this);
		this.cmdSetPotionChest = new iCommand(T.catvao, 16, this);
		this.cmdSellMore = new iCommand(T.sellmore, 17, this);
		this.cmdRebuild = new iCommand(T.dapdo, 20, this);
		this.cmdUnRebuild = new iCommand(T.layra, 21, this);
		this.cmdNextIcon = new iCommand(T.next, 22, this);
		this.cmdReplace = new iCommand(T.replace, 23, this);
		this.cmdWing = new iCommand(T.nangcap, 24, this);
		this.cmdCreateWing = new iCommand(T.taoCanh, 3, this);
		this.cmdDepositPet = new iCommand(T.aptrung, 25, this);
		this.cmdWithdrawPet = new iCommand(T.use, 26, this);
		this.cmdFoodPet = new iCommand(T.choan, 27, this);
		this.cmdPetInfo = new iCommand(T.info, 28, this);
		this.cmdPetFeed = new iCommand(T.choan, 29, this);
		this.cmdHopNguyeLieu = new iCommand(T.hopThanh, 30, this);
		this.cmdMua1 = new iCommand(T.buy + " 1", 31, this);
		this.cmdMua10 = new iCommand(T.buy + " 10", 32, this);
		this.cmdMua30 = new iCommand(T.buy + " 30", 33, this);
		this.cmdKhamgoc = new iCommand(T.khamNgoc, 36, this);
		this.cmdBovao = new iCommand(T.bovao, 37, this);
		this.cmdGhepNgoc = new iCommand(T.bovao, 38, this);
		this.cmdLayra = new iCommand(T.layra, 39, this);
		this.cmdMuaNhieu = new iCommand(T.muaNhieu, 0, this);
		this.cmdDuclo = new iCommand(T.DucLo, 40, this);
		this.cmdHoidaugia = new iCommand(T.daugia, 41, this);
		this.cmdDaugia = new iCommand(T.daugia, 42, this);
		this.cmdHoanThanh = new iCommand(T.hoanthanh, 44, this);
		this.cmdOkSell = new iCommand(T.hoanthanh, 45, this);
		this.cmdBuyItemOtherplayer = new iCommand(T.buy, 46, this);
		this.cmdhuy = new iCommand(T.cancel, 47, this);
		this.cmdNghiban = new iCommand(T.NghiBan, 48, this);
		this.cmdChatWorld = new iCommand(T.text2kenhthegioi, 49, this);
		this.cmdHoprac = new iCommand(T.hoprac, 52, this);
		this.cmdlayracra = new iCommand(T.layra, 53, this);
		this.cmdHopAn = new iCommand(T.bovao, 54, this);
		this.cmdbanNguyenLieu = new iCommand(T.daugia, 55, this);
		this.cmdNextInven = new iCommand(T.tabhanhtrang, 56, this);
		this.cmdKhacItem = new iCommand(T.khac, 57, this);
		this.init();
	}

	// Token: 0x0600080C RID: 2060 RVA: 0x00087344 File Offset: 0x00085544
	public new void setNameCmd(string name)
	{
		this.nameCmdBuy = name;
		this.cmdHoiMua.caption = name;
		this.cmdMua.caption = name;
	}

	// Token: 0x0600080D RID: 2061 RVA: 0x00087368 File Offset: 0x00085568
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
		MainTabNew.timePaintInfo = 0;
		int num;
		if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			if (TabShopNew.isSortInven)
			{
				Item.VecInvetoryPlayer = CRes.selectionSortInven(Item.VecInvetoryPlayer);
				TabShopNew.isSortInven = false;
			}
			num = Item.VecInvetoryPlayer.size();
		}
		else if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			num = Item.VecItemSell.size();
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST || (int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			num = Item.VecChestPlayer.size();
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			num = Item.VecClanInvetory.size();
		}
		else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			num = Item.VecPetContainer.size();
		}
		else
		{
			num = this.vecShop.size();
		}
		MainScreen.cameraSub.setAll(0, this.numH * (int)MainTabNew.wOneItem - MainTabNew.hblack - (int)MainTabNew.wOne5 + 8, 0, 0);
		this.list = new ListNew(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack, 0, 0, MainScreen.cameraSub.yLimit);
		this.listContent = null;
		if (num == 0)
		{
			MainTabNew.Focus = MainTabNew.TAB;
		}
		else if (!GameCanvas.isTouch)
		{
			if ((int)this.typeTab == (int)MainTabNew.SHOP)
			{
				if ((int)this.isTypeShop == (int)TabShopNew.SHOP_BANG)
				{
					this.center = this.cmdMenuInven;
				}
				else if ((int)this.isTypeShop == (int)TabShopNew.WING)
				{
					this.center = this.cmdCreateWing;
				}
				else
				{
					this.center = this.cmdHoiMua;
				}
			}
			else if ((int)this.typeTab == (int)MainTabNew.CHEST)
			{
				if (Item.VecChestPlayer.size() > 0)
				{
					this.center = this.cmdMenuInven;
				}
			}
			else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
			{
				if (Item.VecClanInvetory.size() > 0)
				{
					this.center = this.cmdMenuInven;
				}
			}
			else if ((int)this.typeTab == (int)MainTabNew.INVENTORY)
			{
				if (Item.VecInvetoryPlayer.size() > 0)
				{
					this.center = this.cmdMenuInven;
				}
			}
			else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER && Item.VecPetContainer.size() > 0)
			{
				this.center = this.cmdMenuInven;
			}
			this.right = this.cmdBack;
		}
		this.currentTab = 0;
		base.init();
	}

	// Token: 0x0600080E RID: 2062 RVA: 0x0008766C File Offset: 0x0008586C
	public override void commandPointer(int index, object obj)
	{
		mSystem.outz("commandPointer index = " + index);
		mVector mVector;
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			mVector = Item.VecInvetoryPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			mVector = Item.VecChestPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			mVector = Item.VecPetContainer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			mVector = Item.VecClanInvetory;
		}
		else
		{
			mVector = this.vecShop;
		}
		if (this.idSelect < 0 && index > 0)
		{
			return;
		}
		if (MainTabNew.longwidth == 0)
		{
			MainTabNew.timePaintInfo = 0;
		}
		if (index == 43)
		{
			MainItem mainItem = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem != null)
			{
				item_sell item_sell = (item_sell)obj;
				int price = 0;
				int num = 1;
				try
				{
					if (item_sell != null)
					{
						price = item_sell.price;
						num = (int)item_sell.soluuong;
					}
				}
				catch (Exception ex)
				{
					GameCanvas.start_Ok_Dialog(T.nhapsai);
					price = 0;
					return;
				}
				short id = (short)mainItem.Id;
				item_sell o = new item_sell(id, price, num, mainItem.ItemCatagory);
				Item.VecItem_Sell_in_store.addElement(o);
				if (mainItem.ItemCatagory == 4)
				{
					MainItem mainItem2 = mainItem.clonePotion();
					mainItem2.numPotion = num;
					Item.VecItemSell.addElement(mainItem2);
				}
				else if (mainItem.ItemCatagory == 7)
				{
					MainItem mainItem3 = mainItem.cloneNguyenLieu();
					mainItem3.numPotion = num;
					Item.VecItemSell.addElement(mainItem3);
				}
				else
				{
					Item.VecItemSell.addElement(mainItem);
				}
			}
			if (this.vecListCmd != null)
			{
				this.vecListCmd.removeAllElements();
			}
			GameCanvas.end_Dialog();
		}
		if (obj != null)
		{
			obj = null;
		}
	}

	// Token: 0x0600080F RID: 2063 RVA: 0x000878A4 File Offset: 0x00085AA4
	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		this.idSelect = 0;
		base.backTab();
	}

	// Token: 0x06000810 RID: 2064 RVA: 0x000878C0 File Offset: 0x00085AC0
	public override void commandPointer(int index, int subIndex)
	{
		Item item = null;
		mVector mVector;
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			mVector = Item.VecInvetoryPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			mVector = Item.VecChestPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			mVector = Item.VecPetContainer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			mVector = Item.VecClanInvetory;
		}
		else
		{
			mVector = this.vecShop;
		}
		if (this.idSelect < 0 && index > 0)
		{
			return;
		}
		if (MainTabNew.longwidth == 0)
		{
			MainTabNew.timePaintInfo = 0;
		}
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
			item = (Item)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			if ((int)this.isTypeShop == (int)TabShopNew.SHOP_STORE_OTHER_PLAYER && (!GameCanvas.isTouch || (GameCanvas.isTouch && mSystem.isj2me)))
			{
				this.cmdBuyItemOtherplayer.perform();
				return;
			}
			if (item.diaHoiEvent != string.Empty)
			{
				GameCanvas.start_Left_Dialog(item.diaHoiEvent, this.cmdMua);
				return;
			}
			if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
			{
				this.inputDialog = new InputDialog();
				this.inputDialog.setinfoSmallNew(T.nhapsoluongcanmua, this.cmdBuyPotion, true, -1, item.priceItem, T.buySell, item.getPriceType());
				GameCanvas.currentDialog = this.inputDialog;
			}
			else if (item.ItemCatagory == 3)
			{
				this.cmdMua.caption = T.buy;
				GameCanvas.start_Left_Dialog(string.Concat(new object[]
				{
					T.hoiBuy,
					"1 ",
					item.itemName,
					". ",
					T.voigia,
					item.priceItem,
					item.getPriceType(),
					"?"
				}), this.cmdMua);
			}
			else if (item.ItemCatagory == 6)
			{
				if (item.priceItem > 0L)
				{
					this.cmdMua.caption = T.buy;
					GameCanvas.start_Left_Dialog(string.Concat(new object[]
					{
						T.hoiBuy,
						item.itemName,
						". ",
						T.voigia,
						item.priceItem,
						item.getPriceType(),
						"?"
					}), this.cmdMua);
				}
				else if (item.imageId == GameScreen.player.hair)
				{
					GameCanvas.start_Ok_Dialog(T.dangdungtocnay);
				}
				else
				{
					this.cmdMua.caption = T.use;
					GameCanvas.start_Left_Dialog(T.dungitem, this.cmdMua);
				}
			}
			else if (item.ItemCatagory == 8)
			{
				this.cmdMua.caption = T.select;
				GameCanvas.start_Left_Dialog(T.hoichoniconclan, this.cmdMua);
			}
			break;
		case 2:
			if ((Item)mVector.elementAt(this.idSelect) == null)
			{
				return;
			}
			GameCanvas.start_Left_Dialog(T.dungitem, new iCommand(T.use, 6, this));
			break;
		case 3:
		{
			MainItem mainItem = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem == null)
			{
				return;
			}
			int num = 1;
			try
			{
				num = int.Parse(this.inputDialog.tfInput.getText());
			}
			catch (Exception ex)
			{
				num = 1;
			}
			GlobalService.gI().buy_item((sbyte)this.IDTab, (short)mainItem.Id, (short)num);
			GameCanvas.end_Dialog();
			break;
		}
		case 4:
		case 32:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			GlobalService.gI().buy_item((sbyte)this.IDTab, (short)item.Id, 1);
			GameCanvas.end_Dialog();
			break;
		case 5:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			GameCanvas.start_Left_Dialog(T.hoiDelItem + item.itemName + "?", this.cmdXoaItem);
			break;
		case 6:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			GlobalService.gI().delete_Item((sbyte)item.ItemCatagory, (short)item.Id, 0);
			MainTabNew.timePaintInfo = 0;
			GameCanvas.end_Dialog();
			break;
		case 7:
		{
			MainItem mainItem2 = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem2 == null)
			{
				return;
			}
			if (mainItem2.ItemCatagory == 5)
			{
				GameCanvas.start_Ok_Dialog(T.khongthedung);
				return;
			}
			if (mainItem2.ItemCatagory == 4)
			{
				if ((int)mainItem2.typePotion > 1 || Player.timeDelayPotion[(int)mainItem2.typePotion].value <= 0)
				{
					if (GameScreen.help.setStep_Next(2, 4) && (int)mainItem2.typePotion == 0)
					{
						GameScreen.help.Next++;
						GameScreen.help.setNext();
					}
					if ((int)mainItem2.typePotion >= 2 || (((int)mainItem2.typePotion != 0 || GameScreen.player.hp != GameScreen.player.maxHp) && ((int)mainItem2.typePotion != 1 || GameScreen.player.mp != GameScreen.player.maxMp)))
					{
						if ((int)mainItem2.typePotion == Item.ID_TEM_VE_MUA_BAN)
						{
							if (!GameScreen.player.isSelling())
							{
								GameScreen.gI().doSellItem();
							}
						}
						else
						{
							GlobalService.gI().Use_Potion((short)mainItem2.Id);
							if ((int)mainItem2.typePotion < 2)
							{
								Player.timeDelayPotion[(int)mainItem2.typePotion].value = 2000;
								Player.timeDelayPotion[(int)mainItem2.typePotion].limit = 2000;
								Player.timeDelayPotion[(int)mainItem2.typePotion].timebegin = mSystem.currentTimeMillis();
							}
						}
					}
				}
			}
			else
			{
				int num2 = 0;
				if (mainItem2.type_Only_Item < 12)
				{
					num2 = MainTemplateItem.mItem_Rotate_Tem_Equip[mainItem2.type_Only_Item];
				}
				if (num2 == -1)
				{
					mVector mVector2 = new mVector("TabShopNew menu");
					iCommand iCommand = new iCommand(T.leftRing, 12, 0, this);
					Item item2 = (Item)Item.VecEquipPlayer.get(string.Empty + 3);
					if (item2 != null)
					{
						MainImage imageItem = ObjectData.getImageItem((short)item2.imageId);
						if (imageItem != null && imageItem.img != null)
						{
							if (imageItem.w == 0 || imageItem.h == 0)
							{
								imageItem.h = (short)mImage.getImageHeight(imageItem.img.image);
								imageItem.w = (short)mImage.getImageWidth(imageItem.img.image);
							}
							FrameImage fraCaption = new FrameImage(imageItem.img, (int)imageItem.w, (int)imageItem.h);
							iCommand.setFraCaption(fraCaption);
						}
					}
					iCommand iCommand2 = new iCommand(T.rightRing, 12, 1, this);
					Item item3 = (Item)Item.VecEquipPlayer.get(string.Empty + 9);
					if (item3 != null)
					{
						MainImage imageItem2 = ObjectData.getImageItem((short)item3.imageId);
						if (imageItem2 != null && imageItem2.img != null)
						{
							if (imageItem2.w == 0 || imageItem2.h == 0)
							{
								imageItem2.h = (short)mImage.getImageHeight(imageItem2.img.image);
								imageItem2.w = (short)mImage.getImageWidth(imageItem2.img.image);
							}
							FrameImage fraCaption2 = new FrameImage(imageItem2.img, (int)imageItem2.w, (int)imageItem2.h);
							iCommand2.setFraCaption(fraCaption2);
						}
					}
					mVector2.addElement(iCommand);
					mVector2.addElement(iCommand2);
					GameCanvas.menu2.startAt(mVector2, 2, T.Ring, false, null);
				}
				else
				{
					if (mainItem2.ItemCatagory == 7)
					{
						GlobalService.gI().doUseMaterial((short)mainItem2.Id);
					}
					else
					{
						GlobalService.gI().Use_Item((sbyte)mainItem2.Id, (sbyte)num2);
					}
					if (GameScreen.help.setStep_Next(3, 4))
					{
						GameScreen.help.Next++;
						GameScreen.help.setNext();
					}
				}
			}
			MainTabNew.timePaintInfo = 0;
			if (!GameScreen.help.setStep_Next(2, 5) && !GameScreen.help.setStep_Next(3, 5))
			{
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 8:
		{
			item = (Item)mVector.elementAt(this.idSelect);
			if (item == null)
			{
				return;
			}
			mVector menuItems = new mVector("TabShopNew menu2");
			menuItems = this.doMenu(item);
			string name = T.item;
			if ((int)this.isTypeShop == (int)TabShopNew.SHOP_BANG)
			{
				name = T.iconclan;
			}
			GameCanvas.menu2.startAt(menuItems, 2, name, false, null);
			if (GameScreen.help.setStep_Next(2, 9) || GameScreen.help.setStep_Next(2, 4) || GameScreen.help.setStep_Next(3, 4))
			{
				Menu2.isHelp = true;
			}
			break;
		}
		case 9:
		{
			mVector mVector3 = new mVector("TabShopNew menu3");
			for (int i = 0; i < 5; i++)
			{
				iCommand o;
				if (!GameCanvas.isTouch)
				{
					if (TField.isQwerty)
					{
						o = new iCommand(T.phim + PaintInfoGameScreen.mValueChar[i], 9, i, this);
					}
					else
					{
						o = new iCommand(T.phim + PaintInfoGameScreen.mValueHotKey[i], 9, i, this);
					}
				}
				else
				{
					o = new iCommand(T.oso + (i + 1), 9, i, this);
				}
				mVector3.addElement(o);
			}
			GameCanvas.menu2.startAt(mVector3, 2, T.setKey, false, null);
			if (GameScreen.help.Step >= 0 && GameScreen.help.setStep_Next(2, 9))
			{
				GameScreen.help.Next = 10;
				Menu2.isHelp = true;
			}
			break;
		}
		case 10:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || (int)item.typePotion > 1)
			{
				return;
			}
			if (subIndex == 2)
			{
				GameCanvas.start_Ok_Dialog(T.khongganmauvaophimnay);
				return;
			}
			Player.mhotkey[Player.levelTab][subIndex].setHotKey(item.Id, (int)HotKey.POTION, item.typePotion);
			TabSkillsNew.saveSkill();
			if (GameScreen.help.Step >= 0 && (GameScreen.help.setStep_Next(2, 9) || GameScreen.help.setStep_Next(2, 10)))
			{
				GameScreen.help.Next = 11;
				GameScreen.help.setNext();
			}
			break;
		case 11:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			GlobalService.gI().delete_Item((sbyte)item.ItemCatagory, (short)item.Id, 1);
			if (GameCanvas.isTouch)
			{
				this.idSelect = -1;
			}
			MainTabNew.timePaintInfo = 0;
			GameCanvas.end_Dialog();
			break;
		case 12:
		{
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			int num3;
			if (item.ItemCatagory == 3)
			{
				num3 = (1 + item.LvItem / (int)TabShopNew.hesoLv) * (int)TabShopNew.priceSellItem * (100 + item.colorNameItem * (int)TabShopNew.hesoColor) / 100;
				if (num3 > (int)TabShopNew.maxPriceItem)
				{
					num3 = (int)TabShopNew.maxPriceItem;
				}
			}
			else if (item.ItemCatagory == 5)
			{
				num3 = item.numPotion * (int)TabShopNew.priceSellQuest;
			}
			else
			{
				num3 = (int)TabShopNew.priceSellPotion;
			}
			if (item.ItemCatagory == 3)
			{
				if (item.colorNameItem == 0)
				{
					num3 = 1;
				}
				if (item.colorNameItem == 1)
				{
					num3 = 3;
				}
			}
			GameCanvas.start_Left_Dialog(string.Concat(new object[]
			{
				T.hoisell,
				item.itemName,
				"? ",
				T.voigia,
				num3,
				" ",
				T.coin,
				"."
			}), this.cmdSell);
			break;
		}
		case 13:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item != null)
			{
				if (subIndex == 0)
				{
					GlobalService.gI().Use_Item((sbyte)item.Id, 3);
				}
				else if (subIndex == 1)
				{
					GlobalService.gI().Use_Item((sbyte)item.Id, 9);
				}
			}
			break;
		case 14:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item != null)
			{
				int num4 = 1;
				if (item.ItemCatagory != 4)
				{
					if (item.ItemCatagory != 7)
					{
						goto IL_E48;
					}
				}
				try
				{
					num4 = int.Parse(this.inputDialog.tfInput.getText());
				}
				catch (Exception ex2)
				{
					num4 = 1;
				}
				IL_E48:
				GlobalService.gI().Update_Char_Chest(TabShopNew.GET_CHEST, (short)item.Id, (sbyte)item.ItemCatagory, (short)num4);
				if (GameCanvas.isTouch)
				{
					this.idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 15:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item != null)
			{
				int num5 = 1;
				if (item.ItemCatagory != 4)
				{
					if (item.ItemCatagory != 7)
					{
						goto IL_EDC;
					}
				}
				try
				{
					num5 = int.Parse(this.inputDialog.tfInput.getText());
				}
				catch (Exception ex3)
				{
					num5 = 1;
				}
				IL_EDC:
				GlobalService.gI().Update_Char_Chest(TabShopNew.SET_CHEST, (short)item.Id, (sbyte)item.ItemCatagory, (short)num5);
				if (GameCanvas.isTouch)
				{
					this.idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 16:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item != null && (item.ItemCatagory == 4 || item.ItemCatagory == 7))
			{
				this.inputDialog = new InputDialog();
				this.inputDialog.setinfo(T.nhapsoluongcanlay, this.cmdGetChest, true, T.chest);
				GameCanvas.currentDialog = this.inputDialog;
			}
			break;
		case 17:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item != null && (item.ItemCatagory == 4 || item.ItemCatagory == 7))
			{
				this.inputDialog = new InputDialog();
				this.inputDialog.setinfo(T.nhapsoluongcancat, this.cmdSetChest, true, T.tabhanhtrang);
				GameCanvas.currentDialog = this.inputDialog;
			}
			break;
		case 18:
		{
			mVector mVector4 = new mVector("TabShopNew menusell");
			mVector4.addElement(new iCommand(T.banhettrang, 19, 0, this));
			mVector4.addElement(new iCommand(T.banhetxanh, 19, 1, this));
			GameCanvas.menu2.startAt(mVector4, 2, T.sell, false, null);
			break;
		}
		case 19:
			for (int j = 0; j < Item.VecInvetoryPlayer.size(); j++)
			{
				MainItem mainItem3 = (MainItem)Item.VecInvetoryPlayer.elementAt(j);
				if (subIndex == 0)
				{
					if (mainItem3.ItemCatagory == 3 && mainItem3.colorNameItem == 0 && (int)mainItem3.tier == 0)
					{
						GlobalService.gI().delete_Item((sbyte)mainItem3.ItemCatagory, (short)mainItem3.Id, 1);
					}
				}
				else if (subIndex == 1 && mainItem3.ItemCatagory == 3 && mainItem3.colorNameItem == 1 && (int)mainItem3.tier == 0)
				{
					GlobalService.gI().delete_Item((sbyte)mainItem3.ItemCatagory, (short)mainItem3.Id, 1);
				}
			}
			if (GameCanvas.isTouch)
			{
				this.idSelect = -1;
			}
			GameCanvas.end_Dialog();
			break;
		case 20:
		{
			int num6 = 0;
			for (int k = 0; k < Item.VecInvetoryPlayer.size(); k++)
			{
				MainItem mainItem4 = (MainItem)Item.VecInvetoryPlayer.elementAt(k);
				if (subIndex == 0)
				{
					if (mainItem4.ItemCatagory == 3 && mainItem4.colorNameItem == 0)
					{
						num6++;
					}
				}
				else if (subIndex == 1 && mainItem4.ItemCatagory == 3 && mainItem4.colorNameItem == 1)
				{
					num6++;
				}
			}
			if (num6 == 0)
			{
				if (subIndex == 0)
				{
					GameCanvas.start_Ok_Dialog(T.khongcontrang);
				}
				else if (subIndex == 1)
				{
					GameCanvas.start_Ok_Dialog(T.khongconxanh);
				}
			}
			else if (subIndex == 0)
			{
				GameCanvas.start_Left_Dialog(T.hoisell + num6 + T.dotrang, new iCommand(T.sell, 18, 0, this));
			}
			else if (subIndex == 1)
			{
				GameCanvas.start_Left_Dialog(T.hoisell + num6 + T.doxanh, new iCommand(T.sell, 18, 1, this));
			}
			break;
		}
		case 21:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Item(0, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 22:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (item != null)
			{
				sbyte type = (!MainObject.isMaHopNguyenLieu(item.Id)) ? 1 : 6;
				GlobalService.gI().Rebuild_Item(type, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 23:
			GlobalService.gI().NextClan(8);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		case 24:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (item != null)
			{
				GlobalService.gI().Replace_Item(0, (short)item.Id);
			}
			break;
		case 25:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Wing(2, 0, (short)item.Id);
			}
			break;
		case 26:
			mSystem.outz("Deposit pet ------- ");
			item = (Item)mVector.elementAt(this.idSelect);
			if (item != null)
			{
				int num7 = 1;
				GlobalService.gI().Update_Pet_Container(TabShopNew.DEPOSIT_PET, (short)item.Id, (sbyte)item.ItemCatagory, (short)num7);
				if (GameCanvas.isTouch)
				{
					this.idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 27:
			mSystem.outz("withdraw pet ------- ");
			item = (Item)mVector.elementAt(this.idSelect);
			if (item != null)
			{
				int num8 = 1;
				GlobalService.gI().Update_Pet_Container(TabShopNew.WITHDRAW_PET, (short)item.Id, (sbyte)item.ItemCatagory, (short)num8);
				if (GameCanvas.isTouch)
				{
					this.idSelect = -1;
				}
			}
			GameCanvas.end_Dialog();
			break;
		case 28:
			if (this.petCur == null)
			{
				return;
			}
			item = (Item)mVector.elementAt(this.idSelect);
			GlobalService.gI().Pet_Eat((short)this.petCur.Id, (short)item.Id, (sbyte)item.ItemCatagory, MsgDialog.isInven_Equip);
			break;
		case 29:
			item = (Item)mVector.elementAt(this.idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.INVEN);
			}
			break;
		case 30:
		{
			item = (Item)Item.VecPetContainer.elementAt(this.idSelect);
			if (item != null && item.ItemCatagory == 9)
			{
				GameCanvas.start_Pet_Info((PetItem)item, MsgDialog.INVEN);
			}
			mVector mVector5 = new mVector("TabShopNew vectab");
			mVector5.addElement(new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, TabShopNew.INVEN_FOOD_PET)
			{
				petCur = MsgDialog.pet
			});
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector5);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		case 31:
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (item != null)
			{
				GlobalService.gI().Rebuild_Item(4, (short)item.Id, (sbyte)item.ItemCatagory);
				if (MainTabNew.longwidth > 0)
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		case 33:
		{
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			mVector mVector6 = new mVector("TabShopNew menu4");
			string str = string.Concat(new object[]
			{
				T.hoiBuy,
				" ",
				10,
				" ",
				item.itemName,
				" ",
				T.voigia,
				" ",
				item.priceItem * 10L,
				" ",
				((int)item.priceType != 0) ? T.gem : T.coin
			});
			mVector6.addElement(new iCommand(T.yes, 34, 10, this));
			mVector6.addElement(new iCommand(T.cancel, 35, this));
			GameCanvas.start_Select_Dialog(str, mVector6);
			break;
		}
		case 34:
		{
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			mVector mVector7 = new mVector("TabShopNew menu5");
			string str2 = string.Concat(new object[]
			{
				T.hoiBuy,
				" ",
				30,
				" ",
				item.itemName,
				" ",
				T.voigia,
				" ",
				item.priceItem * 30L,
				" ",
				((int)item.priceType != 0) ? T.gem : T.coin
			});
			mVector7.addElement(new iCommand(T.yes, 34, 30, this));
			mVector7.addElement(new iCommand(T.cancel, 35, this));
			GameCanvas.start_Select_Dialog(str2, mVector7);
			break;
		}
		case 35:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null || item.setNameNull())
			{
				return;
			}
			GlobalService.gI().buy_item((sbyte)this.IDTab, (short)item.Id, (short)subIndex);
			GameCanvas.end_Dialog();
			break;
		case 36:
			GameCanvas.end_Dialog();
			break;
		case 37:
		case 41:
		{
			MainItem mainItem5 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem5 != null)
			{
				TabRebuildItem.itemRe = mainItem5;
				TabRebuildItem.countSetpaintinfo = 1;
				if (MainTabNew.longwidth > 0)
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		}
		case 38:
		{
			MainItem mainItem6 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem6 != null)
			{
				if (TabRebuildItem.vecGem.size() > (int)this.numofGem)
				{
					GameCanvas.start_Ok_Dialog(T.khongbothem);
					return;
				}
				TabRebuildItem.addGem(mainItem6);
				if (MainTabNew.longwidth > 0)
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
				}
			}
			break;
		}
		case 39:
		{
			TabRebuildItem.vecGem.removeAllElements();
			TabRebuildItem.itemRe = null;
			MainItem mainItem7 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem7 != null)
			{
				if (mainItem7.numPotion < (int)this.numofGem)
				{
					GameCanvas.start_Ok_Dialog(T.hetNgoc);
					return;
				}
				for (int l = 0; l < (int)this.numofGem; l++)
				{
					TabRebuildItem.addGem(mainItem7);
					if (MainTabNew.longwidth > 0)
					{
						this.idSelect = -1;
						MainTabNew.timePaintInfo = 0;
					}
				}
			}
			break;
		}
		case 40:
			item = (MainItem)mVector.elementAt(this.idSelect);
			if (item == null)
			{
				return;
			}
			if ((int)this.isTypeShop == (int)TabShopNew.SHOP_KHAM_NGOC)
			{
				if (TabRebuildItem.isKham(item))
				{
					TabRebuildItem.removeKhamNgoc(item);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.SHOP_GHEP_NGOC)
			{
				TabRebuildItem.vecGem.removeAllElements();
			}
			break;
		case 42:
		{
			this.inputDialog = new InputDialog();
			string[] info = new string[]
			{
				T.nhapgiaban
			};
			this.inputDialog.setinfo(info, this.cmdDaugia, -1, 0, T.daugia);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		}
		case 43:
		{
			MainItem mainItem8 = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem8 == null)
			{
				return;
			}
			int num9 = 1;
			int num10 = 1;
			string[] array = this.inputDialog.getarrayText();
			if (array != null)
			{
				try
				{
					if (array.Length == 1)
					{
						if (array[0] != null)
						{
							num9 = int.Parse(array[0]);
						}
					}
					else if (array.Length == 2)
					{
						if (array[0] != null)
						{
							num9 = int.Parse(array[0]);
						}
						if (array[1] != null)
						{
							num10 = int.Parse(array[1]);
						}
					}
				}
				catch (Exception ex4)
				{
					GameCanvas.start_Ok_Dialog(T.nhapsai);
					num9 = 1;
					break;
				}
			}
			string str3 = string.Concat(new string[]
			{
				T.hoidaugia,
				mainItem8.itemName,
				" ",
				T.voigia,
				" ",
				MainItem.getDotNumber((long)num9),
				" ",
				T.coin,
				" ?"
			});
			if (num10 > 1)
			{
				str3 = string.Concat(new object[]
				{
					T.hoidaugia,
					" ",
					num10,
					" ",
					mainItem8.itemName,
					" ",
					T.voigia,
					" ",
					MainItem.getDotNumber((long)num9),
					" ",
					T.coin,
					" ?"
				});
			}
			item_sell item_sell = new item_sell();
			item_sell.price = num9;
			item_sell.soluuong = (short)num10;
			mVector mVector8 = new mVector();
			mVector8.addElement(new iCommand(T.yes, 43, item_sell, this));
			mVector8.addElement(new iCommand(T.cancel, 35, this));
			GameCanvas.start_Select_Dialog(str3, mVector8);
			break;
		}
		case 45:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfoSmallNew(T.nhapSlogan, this.cmdOkSell, false, -1, 0L, string.Empty);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 46:
			GlobalService.gI().do_Buy_Sell_Item(0, Item.VecItem_Sell_in_store, this.inputDialog.tfInput.getText(), 0, 0, 0);
			GameCanvas.end_Dialog();
			if (this.vecListCmd != null)
			{
				this.vecListCmd.removeAllElements();
				this.vecListCmd.addElement(this.cmdNghiban);
			}
			base.setPosCmd(this.vecListCmd);
			break;
		case 47:
		{
			MainItem mainItem9 = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem9 != null)
			{
				if (mainItem9.ItemCatagory == 3)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, TabShopNew.idSeller, mainItem9.Id, (sbyte)mainItem9.ItemCatagory);
				}
				else if (mainItem9.ItemCatagory == 7)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, TabShopNew.idSeller, mainItem9.Id, (sbyte)mainItem9.ItemCatagory);
				}
				else if (mainItem9.ItemCatagory == 4)
				{
					GlobalService.gI().do_Buy_Sell_Item(2, null, string.Empty, TabShopNew.idSeller, mainItem9.Id, (sbyte)mainItem9.ItemCatagory);
				}
			}
			break;
		}
		case 48:
			Item.VecItem_Sell_in_store.removeAllElements();
			Item.VecItemSell.removeAllElements();
			break;
		case 49:
			GlobalService.gI().do_Buy_Sell_Item(4, null, string.Empty, 0, 0, 0);
			break;
		case 50:
			this.inputWorld = new InputDialog();
			this.inputWorld.setinfo(T.nhapnoidung, new iCommand(T.chat, 50, this), false, T.textkenhthegioi);
			this.inputWorld.tfInput.isnewTF = true;
			newinput.TYPE_INPUT = 2;
			newinput.input.Select();
			newinput.input.ActivateInputField();
			GameCanvas.currentDialog = this.inputWorld;
			break;
		case 51:
			this.textWorld = newinput.input.text;
			if (this.textWorld != null && this.textWorld.Length > 0)
			{
				GameCanvas.start_Left_Dialog(string.Concat(new object[]
				{
					T.kenhthegioi,
					" (",
					T.phi,
					TabShopNew.PriceChatWorld,
					" ",
					T.gem,
					")",
					T.noidungnhusau,
					"\n",
					this.textWorld
				}), new iCommand(T.chat, 51, this));
			}
			break;
		case 52:
			GlobalService.gI().Chat_World(this.textWorld);
			newinput.input.text = string.Empty;
			newinput.TYPE_INPUT = -1;
			newinput.input.DeactivateInputField();
			GameCanvas.end_Dialog();
			break;
		case 53:
		{
			MainItem mainItem10 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem10 != null)
			{
				if (TabRebuildItem.itemRe != null)
				{
					TabRebuildItem.itemRe = null;
				}
				GlobalService.gI().Hop_rac(0, (short)mainItem10.Id, (sbyte)mainItem10.ItemCatagory);
			}
			this.vecListCmd.removeAllElements();
			break;
		}
		case 54:
		{
			MainItem mainItem11 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem11 != null)
			{
				GlobalService.gI().Hop_rac(1, (short)mainItem11.Id, (sbyte)mainItem11.ItemCatagory);
			}
			this.vecListCmd.removeAllElements();
			break;
		}
		case 55:
		{
			MainItem mainItem12 = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
			if (mainItem12 != null)
			{
				TabRebuildItem.itemRe = mainItem12;
				GlobalService.gI().Hop_rac(0, (short)mainItem12.Id, (sbyte)mainItem12.ItemCatagory);
			}
			this.vecListCmd.removeAllElements();
			break;
		}
		case 56:
		{
			this.inputDialog = new InputDialog();
			string[] info2 = new string[]
			{
				T.nhapgiaban,
				T.soluong
			};
			this.inputDialog.setinfo(info2, this.cmdDaugia, -1, 0, T.daugia);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		}
		case 57:
			this.currentTab += 1;
			if ((int)this.currentTab > (int)TabShopNew.maxTab - 1)
			{
				this.currentTab = 0;
			}
			if (!GameCanvas.isTouch)
			{
				if ((int)this.currentTab == 0)
				{
					this.idSelect = 0;
				}
				if ((int)this.currentTab == 1)
				{
					this.idSelect = 42;
				}
			}
			break;
		case 58:
		{
			MainItem mainItem13 = (MainItem)mVector.elementAt(this.idSelect);
			if (mainItem13 != null)
			{
				GlobalService.gI().DoKhacItem(6, (sbyte)mainItem13.ItemCatagory, (short)mainItem13.Id);
			}
			break;
		}
		}
	}

	// Token: 0x06000811 RID: 2065 RVA: 0x00089994 File Offset: 0x00087B94
	public mVector doMenu(Item item)
	{
		mVector mVector = new mVector("TabShopNew menu7");
		if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			TabShopNew.maxTab = (sbyte)(Player.maxChest / 42);
			if ((int)TabShopNew.maxTab == 1 && Item.VecChestPlayer.size() > 42)
			{
				TabShopNew.maxTab = 2;
			}
		}
		if ((int)this.typeTab == (int)MainTabNew.INVENTORY)
		{
			TabShopNew.maxTab = (sbyte)(Player.maxInven / 42);
		}
		if ((int)this.typeTab != (int)MainTabNew.SHOP && (int)TabShopNew.maxTab > 1)
		{
			mVector.addElement(this.cmdNextInven);
		}
		if ((int)this.isTypeShop == (int)TabShopNew.SHOP_NANG_CAP_MEDEL)
		{
			mVector.addElement(this.cmdHopAn);
			return mVector;
		}
		if ((int)this.isTypeShop == (int)TabShopNew.SHOP_HOP_AN)
		{
			return mVector;
		}
		if ((int)this.isTypeShop == (int)TabShopNew.SHOP_NANG_CAP_MEDEL)
		{
			return mVector;
		}
		if (GameScreen.player.isSelling())
		{
			mVector.addElement(this.cmdNghiban);
			mVector.addElement(this.cmdChatWorld);
			return mVector;
		}
		if ((int)this.isTypeShop == (int)TabShopNew.SHOP_STORE_OTHER_PLAYER)
		{
			mVector.addElement(this.cmdBuyItemOtherplayer);
			return mVector;
		}
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector.addElement(this.cmdHoanThanh);
			mVector.addElement(this.cmdhuy);
			return mVector;
		}
		if ((int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			if (Item.VecItemSell.size() > 0)
			{
				for (int i = 0; i < Item.VecItemSell.size(); i++)
				{
					MainItem mainItem = (MainItem)Item.VecItemSell.elementAt(i);
					if (mainItem.Id == item.Id)
					{
						return mVector;
					}
				}
			}
			if (item.ItemCatagory == 3)
			{
				mVector.addElement(this.cmdHoidaugia);
			}
			else
			{
				mVector.addElement(this.cmdbanNguyenLieu);
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY && !this.isShop_Other_Player)
		{
			if ((int)this.isTypeShop == (int)TabShopNew.SHOP_STORE_OTHER_PLAYER)
			{
				mVector.addElement(this.cmdBuyItemOtherplayer);
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.SHOP_DUC_LO)
			{
				if (item.ItemCatagory == 7 && (int)item.typeMaterial == (int)Item.TYPE_BUA_HUYEN_BI)
				{
					mVector.addElement(this.cmdBovao);
				}
				if (item.ItemCatagory == 3)
				{
					mVector.addElement(this.cmdDuclo);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.SHOP_ANY_NGUYEN_LIEU)
			{
				if (item.ItemCatagory == 7)
				{
					if (TabRebuildItem.vecGem.size() > 0)
					{
						MainItem mainItem2 = (MainItem)TabRebuildItem.vecGem.elementAt(0);
						if (mainItem2.Id == item.Id)
						{
							mVector.addElement(this.cmdlayracra);
							return mVector;
						}
					}
					mVector.addElement(this.cmdHoprac);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.SHOP_GHEP_NGOC)
			{
				if (item.ItemCatagory == 7 && (int)item.typeMaterial == (int)Item.TYPE_NGOC_KHAM)
				{
					if (!TabRebuildItem.isKham(item))
					{
						mVector.addElement(this.cmdGhepNgoc);
					}
					if (TabRebuildItem.isKham(item))
					{
						mVector.addElement(this.cmdLayra);
					}
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.SHOP_KHAM_NGOC)
			{
				if (item.ItemCatagory == 3)
				{
					if (!TabShopNew.isTabHopNL && (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory))
					{
						mVector.addElement(this.cmdKhamgoc);
					}
				}
				else if (item.ItemCatagory == 7 && (int)item.typeMaterial == 49)
				{
					mVector.addElement(this.cmdBovao);
					if (TabRebuildItem.isKham(item))
					{
						mVector.addElement(this.cmdLayra);
					}
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_REBUILD)
			{
				if (item.ItemCatagory == 3)
				{
					if (!TabShopNew.isTabHopNL)
					{
						if (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory)
						{
							mVector.addElement(this.cmdRebuild);
						}
						else
						{
							mVector.addElement(this.cmdUnRebuild);
						}
					}
				}
				else if (item.ItemCatagory == 7)
				{
					if ((int)item.typeMaterial == 11)
					{
						if (!TabShopNew.isTabHopNL)
						{
							if (!TabRebuildItem.isLucky)
							{
								TabRebuildItem.itemDaMayMan = item;
								mVector.addElement(this.cmdRebuild);
							}
							else
							{
								mVector.addElement(this.cmdUnRebuild);
							}
						}
					}
					else if (MainObject.isMaHopNguyenLieu((int)((short)item.Id)) && TabShopNew.isTabHopNL)
					{
						if (TabRebuildItem.itemRe == null || TabRebuildItem.itemRe.Id != item.Id || TabRebuildItem.itemRe.ItemCatagory != item.ItemCatagory)
						{
							mVector.addElement(this.cmdHopNguyeLieu);
						}
						else
						{
							mVector.addElement(this.cmdUnRebuild);
						}
					}
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_REPLACE)
			{
				if (item.ItemCatagory == 3)
				{
					mVector.addElement(this.cmdReplace);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_CHEST)
			{
				if (item.ItemCatagory != 5)
				{
					if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
					{
						mVector.addElement(this.cmdSetPotionChest);
					}
					else
					{
						mVector.addElement(this.cmdSetChest);
					}
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_PET_KEEPER)
			{
				if (item.ItemCatagory == 3 && item.type_Only_Item == 14)
				{
					mVector.addElement(this.cmdDepositPet);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_WING)
			{
				if (item.ItemCatagory == 3 && item.type_Only_Item == 7)
				{
					mVector.addElement(this.cmdWing);
				}
			}
			else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_FOOD_PET)
			{
				mVector.addElement(this.cmdFoodPet);
			}
			else
			{
				if (GameCanvas.currentScreen == GameCanvas.shopNpc && (int)item.canSell == 1)
				{
					mVector.addElement(this.cmdHoiSell);
					if (item.ItemCatagory == 3)
					{
						mVector.addElement(this.cmdSellMore);
					}
				}
				if (GameCanvas.currentScreen != GameCanvas.shopNpc)
				{
					mVector.addElement(this.cmdSelect);
					if (item.ItemCatagory == 4 && (int)item.typePotion < 2)
					{
						mVector.addElement(this.cmdSetKey);
					}
				}
				if (GameCanvas.currentScreen == GameCanvas.AllInfo)
				{
					mVector.addElement(this.cmdHoiXoaItem);
				}
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
			{
				mVector.addElement(this.cmdGetPotionChest);
			}
			else
			{
				mVector.addElement(this.cmdGetChest);
			}
		}
		else if ((int)this.typeTab != (int)MainTabNew.SELLITEM)
		{
			if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
			{
				if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_PET_KEEPER && item.ItemCatagory == 9)
				{
					mVector.addElement(this.cmdPetFeed);
					mVector.addElement(this.cmdWithdrawPet);
				}
			}
			else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
			{
				mVector.addElement(this.cmdSelect);
			}
			else
			{
				this.cmdHoiMua.caption = T.buy;
				if (this.IDTab == (int)ReadMessenge.SHOP_ITEM_EVENT)
				{
					this.cmdHoiMua.caption = this.nameCmdBuy;
				}
				if (item.ItemCatagory == 6 && item.priceItem <= 0L)
				{
					this.cmdHoiMua.caption = T.use;
				}
				if ((int)this.isTypeShop == (int)TabShopNew.WING)
				{
					mVector.addElement(this.cmdCreateWing);
				}
				else if ((int)this.isTypeShop != (int)TabShopNew.SHOP_VANTIEU)
				{
					if (!this.isShop_Other_Player)
					{
						mVector mVector2 = this.vecShop;
						item = (Item)mVector2.elementAt(this.idSelect);
						if (item != null || !item.setNameNull())
						{
							if (item.ItemCatagory == 4 || item.ItemCatagory == 7)
							{
								mVector.addElement(this.cmdMua1);
								mVector.addElement(this.cmdMua10);
								mVector.addElement(this.cmdMua30);
								mVector.addElement(this.cmdMuaNhieu);
							}
							else
							{
								mVector.addElement(this.cmdHoiMua);
							}
						}
					}
				}
				if ((int)this.isTypeShop == (int)TabShopNew.SHOP_BANG)
				{
					this.cmdHoiMua.caption = T.select;
					mVector.addElement(this.cmdNextIcon);
				}
			}
		}
		if ((int)this.typeTab == (int)MainTabNew.INVENTORY)
		{
			mVector.addElement(this.cmdKhacItem);
		}
		return mVector;
	}

	// Token: 0x06000812 RID: 2066 RVA: 0x0008A2EC File Offset: 0x000884EC
	public override void paint(mGraphics g)
	{
		mVector mVector;
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			mVector = Item.VecInvetoryPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			mVector = Item.VecChestPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
		{
			mVector = Item.VecPetContainer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			mVector = Item.VecClanInvetory;
		}
		else
		{
			mVector = this.vecShop;
		}
		GameCanvas.resetTrans(g);
		g.setClip(this.xBegin - (int)MainTabNew.wOne5, this.yBegin, MainTabNew.wblack + (int)MainTabNew.wOne5 * 2, MainTabNew.hblack - (int)MainTabNew.wOne5 / 2 + 1);
		g.translate(-MainScreen.cameraSub.xCam, -MainScreen.cameraSub.yCam);
		int num = mVector.size();
		if (num > 42)
		{
			num = 42;
		}
		if (this.isShop)
		{
			num = this.vecShop.size();
		}
		int num2 = 42 * (int)this.currentTab;
		for (int i = 0; i < num; i++)
		{
			Item item = (Item)mVector.elementAt(i + num2);
			if (item != null)
			{
				if (item.ItemCatagory == 7)
				{
					MainItem material = Item.getMaterial(item.Id);
					if (material != null)
					{
						item.setinfo(material.itemName, material.imageId, 7, item.priceItem, item.priceType, material.content, (int)((short)material.value), material.typeMaterial, 1, material.canSell, material.canTrade);
						item.setColorName(material.colorNameItem);
						item.paintItem(g, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
					}
					else
					{
						Item.put_Material(item.Id);
					}
				}
				else
				{
					item.paintItem(g, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
				}
				if (item.timeUse > 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, (int)MainTabNew.wOneItem - 1, (int)MainTabNew.wOneItem - 1, 0, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, 3, mGraphics.isTrue);
				}
				if ((int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE && !GameScreen.player.isSelling() && Item.VecItemSell.size() > 0)
				{
					for (int j = 0; j < Item.VecItemSell.size(); j++)
					{
						MainItem mainItem = (MainItem)Item.VecItemSell.elementAt(j);
						if (mainItem.Id == item.Id)
						{
							g.setColor(265698349);
							g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
						}
					}
				}
				if ((int)this.isTypeShop == (int)TabShopNew.SHOP_NANG_CAP_MEDEL || (int)this.isTypeShop == (int)TabShopNew.SHOP_ANY_NGUYEN_LIEU || (int)this.isTypeShop == (int)TabShopNew.SHOP_KHAM_NGOC || (int)this.isTypeShop == (int)TabShopNew.SHOP_GHEP_NGOC || (int)this.isTypeShop == (int)TabShopNew.SHOP_DUC_LO)
				{
					if (TabRebuildItem.itemRe != null && item.Id == TabRebuildItem.itemRe.Id && item.ItemCatagory == TabRebuildItem.itemRe.ItemCatagory)
					{
						g.setColor(268038149);
						g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
					}
					if (TabRebuildItem.vecGem.size() > 0)
					{
						for (int k = 0; k < TabRebuildItem.vecGem.size(); k++)
						{
							MainItem mainItem2 = (MainItem)TabRebuildItem.vecGem.elementAt(k);
							g.setColor(268038149);
							if (mainItem2 != null && ((int)item.typeMaterial == (int)Item.TYPE_NGOC_KHAM || (int)item.typeMaterial == (int)Item.TYPE_BUA_HUYEN_BI || (int)this.isTypeShop == (int)TabShopNew.SHOP_ANY_NGUYEN_LIEU) && item.Id == mainItem2.Id && item.ItemCatagory == mainItem2.ItemCatagory)
							{
								g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
							}
						}
					}
				}
				else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_REBUILD)
				{
					if (TabRebuildItem.itemRe != null && ((item.Id == TabRebuildItem.itemRe.Id && item.ItemCatagory == TabRebuildItem.itemRe.ItemCatagory) || (item.ItemCatagory == 7 && (int)item.typeMaterial == 11 && TabRebuildItem.isLucky)))
					{
						g.setColor(16379909);
						g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
					}
				}
				else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_REPLACE)
				{
					if (TabRebuildItem.itemFree != null && item.Id == TabRebuildItem.itemFree.Id && item.ItemCatagory == TabRebuildItem.itemFree.ItemCatagory)
					{
						g.setColor(16379909);
						g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
					}
					if (TabRebuildItem.itemPlus != null && item.Id == TabRebuildItem.itemPlus.Id && item.ItemCatagory == TabRebuildItem.itemPlus.ItemCatagory)
					{
						g.setColor(14040109);
						g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
					}
				}
				else if ((int)this.isTypeShop == (int)TabShopNew.INVEN_AND_WING && TabRebuildItem.itemWing != null && item.Id == TabRebuildItem.itemWing.Id && item.ItemCatagory == TabRebuildItem.itemWing.ItemCatagory)
				{
					g.setColor(16379909);
					g.drawRect(this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2 + 4, (int)MainTabNew.wOneItem - 8, (int)MainTabNew.wOneItem - 8, mGraphics.isTrue);
				}
				if (item.ItemCatagory == 4 && (int)item.typePotion < 2 && (int)this.typeTab == (int)MainTabNew.INVENTORY && Player.timeDelayPotion[(int)item.typePotion].value > 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, (int)MainTabNew.wOneItem - 1, (int)MainTabNew.wOneItem - 1, 0, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, 3, mGraphics.isFalse);
				}
			}
		}
		g.setColor(MainTabNew.color[1]);
		g.drawRect(this.xBegin, this.yBegin, MainTabNew.wblack, (int)MainTabNew.wOneItem * this.numH, mGraphics.isTrue);
		for (int l = 0; l < this.numW / 2; l++)
		{
			g.drawRect(this.xBegin + (int)MainTabNew.wOneItem + l * (int)MainTabNew.wOneItem * 2, this.yBegin, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * this.numH, mGraphics.isTrue);
		}
		for (int m = 0; m < this.numH / 2; m++)
		{
			g.drawRect(this.xBegin, this.yBegin + (int)MainTabNew.wOneItem + m * (int)MainTabNew.wOneItem * 2, MainTabNew.wblack, (int)MainTabNew.wOneItem, mGraphics.isTrue);
		}
		if (this.idSelect > -1 && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			g.setColor(MainTabNew.color[2]);
			g.drawRect(this.xBegin + (this.idSelect - (int)this.currentTab * 42) % this.numW * (int)MainTabNew.wOneItem + 1, this.yBegin + (this.idSelect - (int)this.currentTab * 42) / this.numW * (int)MainTabNew.wOneItem + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
			g.setColor(MainTabNew.color[3]);
			g.drawRect(this.xBegin + (this.idSelect - (int)this.currentTab * 42) % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (this.idSelect - (int)this.currentTab * 42) / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, mGraphics.isTrue);
		}
		g.endClip();
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (int)MainTabNew.Focus == (int)MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			base.paintPopupContent(g, false);
			if (this.vecListCmd != null)
			{
				for (int n = 0; n < this.vecListCmd.size(); n++)
				{
					iCommand iCommand = (iCommand)this.vecListCmd.elementAt(n);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
		}
		if (GameScreen.help.Step >= 0)
		{
			Item item2 = null;
			if (this.idSelect > -1 && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
			{
				item2 = (Item)mVector.elementAt(this.idSelect);
			}
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
			{
				GameScreen.help.itemTabHelp(g, item2, this.typeTab);
			}
		}
		if (!GameCanvas.isSmallScreen && (int)this.isTypeShop == (int)TabShopNew.TOC)
		{
			Item item3 = null;
			if (this.idSelect > -1 && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
			{
				item3 = (Item)mVector.elementAt(this.idSelect);
			}
			int hair = GameScreen.player.hair;
			if (item3 != null)
			{
				hair = item3.imageId;
			}
			base.paintHairShop(g, hair);
		}
		if (!GameScreen.player.isSelling() && (int)this.typeTab == (int)MainTabNew.SELLITEM && this.idSelect >= 0 && this.idSelect < Item.VecItem_Sell_in_store.size())
		{
			item_sell item_sell = (item_sell)Item.VecItem_Sell_in_store.elementAt(this.idSelect);
			if (item_sell != null)
			{
				mFont.tahoma_7_yellow.drawString(g, string.Concat(new string[]
				{
					T.price,
					": ",
					MainItem.getDotNumber((long)item_sell.price),
					" ",
					T.coin
				}), this.xBegin, this.yBegin + (int)MainTabNew.wOneItem * 6, 0, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x06000813 RID: 2067 RVA: 0x0008B124 File Offset: 0x00089324
	public override void update()
	{
		if ((int)this.typeTab != (int)TabShopNew.NORMAL && (int)this.typeTab != (int)MainTabNew.INVEN_AND_STORE && (int)this.typeTab != (int)MainTabNew.CHEST && (int)this.typeTab != (int)MainTabNew.PET_KEEPER && (int)this.currentTab != 0)
		{
			this.currentTab = 0;
		}
		if (GameScreen.help.Step > 0)
		{
			GameScreen.help.updateHelp();
		}
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if (this.listContent != null)
			{
				this.listContent.moveCamera();
			}
			if (GameCanvas.isTouch)
			{
				this.list.moveCamera();
			}
			else
			{
				MainScreen.cameraSub.UpdateCamera();
			}
			mVector mVector;
			if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
			{
				mVector = Item.VecItemSell;
			}
			else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
			{
				mVector = Item.VecInvetoryPlayer;
			}
			else if ((int)this.typeTab == (int)MainTabNew.CHEST)
			{
				mVector = Item.VecChestPlayer;
			}
			else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
			{
				mVector = Item.VecClanInvetory;
			}
			else
			{
				mVector = this.vecShop;
			}
			if (mVector.size() == 0)
			{
				MainTabNew.Focus = MainTabNew.TAB;
				return;
			}
			if (this.idSelect >= mVector.size())
			{
				if (GameCanvas.isTouch)
				{
					this.idSelect = -1;
					this.vecListCmd = null;
				}
				else
				{
					this.idSelect = mVector.size() - 1;
				}
			}
			if ((int)this.typeTab != (int)TabShopNew.SHOP_BANG)
			{
				this.updateContent(mVector, this.idSelect);
			}
		}
		else
		{
			MainTabNew.timePaintInfo = 0;
		}
		if ((int)this.currentTab == 0 && this.idSelect > 42 && !this.isShop)
		{
			this.idSelect = -1;
		}
	}

	// Token: 0x06000814 RID: 2068 RVA: 0x0008B328 File Offset: 0x00089528
	public void updateContent(mVector vec, int idSelect)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				this.setPaintInfo();
			}
		}
		if (this.mContent == null && idSelect >= 0 && idSelect < vec.size())
		{
			Item item = (Item)vec.elementAt(idSelect);
			if (item.ItemCatagory != 5)
			{
				if (item.mcontent == null)
				{
					if (item.timeupdateMore % 100 == 3)
					{
						if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
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
					this.moreInfoconten = item.moreContenGem;
					this.mContent = item.mcontent;
					this.mcolor = item.mColor;
					this.setYCon(item);
				}
			}
		}
	}

	// Token: 0x06000815 RID: 2069 RVA: 0x0008B440 File Offset: 0x00089640
	public override void updatekey()
	{
		mVector mVector;
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			mVector = Item.VecInvetoryPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			mVector = Item.VecChestPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			mVector = Item.VecClanInvetory;
		}
		else
		{
			mVector = this.vecShop;
		}
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			int num = this.idSelect;
			bool flag = false;
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
				this.idSelect -= this.numW;
				GameCanvas.clearKeyHold(2);
				flag = true;
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.idSelect += this.numW;
				GameCanvas.clearKeyHold(8);
				flag = true;
			}
			if (GameCanvas.keyMyHold[4])
			{
				if (this.idSelect % this.numW == 0 && (int)this.currentTab == 0)
				{
					MainTabNew.Focus = MainTabNew.TAB;
				}
				else
				{
					this.idSelect--;
				}
				if ((int)this.currentTab == 1 && this.idSelect == 41)
				{
					this.currentTab -= 1;
				}
				if ((int)this.currentTab == 2 && this.idSelect == 82)
				{
					this.currentTab -= 1;
				}
				GameCanvas.clearKeyHold(4);
				flag = true;
			}
			else if (GameCanvas.keyMyHold[6])
			{
				this.idSelect++;
				GameCanvas.clearKeyHold(6);
				if ((int)TabShopNew.maxTab > 1 && this.idSelect > 0 && this.idSelect % 42 == 0)
				{
					this.currentTab += 1;
					if ((int)this.currentTab > (int)TabShopNew.maxTab - 1)
					{
						this.currentTab = 0;
						this.idSelect = 0;
					}
				}
				flag = true;
			}
			if (flag)
			{
				this.listContent = null;
				this.idSelect = base.resetSelect(this.idSelect, mVector.size() - 1, false);
				if (!GameCanvas.isTouch && ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE || (int)this.typeTab == (int)MainTabNew.CHEST || (int)this.typeTab == (int)MainTabNew.SELLITEM))
				{
					this.center = this.cmdMenuInven;
				}
				TabScreenNew.timeRepaint = 10;
			}
			if (num != this.idSelect)
			{
				MainScreen.cameraSub.moveCamera(0, (this.idSelect / this.numW - 1) * (int)MainTabNew.wOneItem);
				MainTabNew.timePaintInfo = 0;
			}
		}
		base.updatekey();
	}

	// Token: 0x06000816 RID: 2070 RVA: 0x0008B7EC File Offset: 0x000899EC
	public override void setPaintInfo()
	{
		this.mContent = null;
		this.mSubContent = null;
		this.mPlusContent = null;
		mVector mVector;
		if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
		{
			mVector = Item.VecItemSell;
		}
		else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
		{
			mVector = Item.VecInvetoryPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CHEST)
		{
			mVector = Item.VecChestPlayer;
		}
		else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
		{
			mVector = Item.VecClanInvetory;
		}
		else
		{
			mVector = this.vecShop;
		}
		if (this.idSelect >= mVector.size() || this.idSelect < 0)
		{
			if (this.idSelect > mVector.size() - 1)
			{
				this.idSelect = mVector.size() - 1;
			}
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Item item = (Item)mVector.elementAt(this.idSelect);
		if (item != null && item.setNameNull())
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
		this.name = item.itemName;
		this.colorName = item.colorNameItem;
		if (item.ItemCatagory == 7)
		{
			MainItem material = Item.getMaterial(item.Id);
			if (material != null)
			{
				this.colorName = material.colorNameItem;
				if ((int)this.typeTab == (int)MainTabNew.SELLITEM && item.isSell)
				{
					this.mPlusContent = item.mPlusContent;
					this.mPlusColor = item.mPlusColor;
				}
			}
		}
		this.moreInfoconten = item.moreContenGem;
		if (item.ItemCatagory == 3 || (int)this.typeTab == (int)MainTabNew.SHOP)
		{
			this.mPlusContent = item.mPlusContent;
			this.mPlusColor = item.mPlusColor;
		}
		this.listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			int num = 1;
			this.mContent = item.mcontent;
			this.mcolor = item.mColor;
			if (item.mcontent != null)
			{
				num += this.mContent.Length;
			}
			if (item.mPlusContent != null)
			{
				num += item.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - this.hcmd)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - this.hcmd));
			}
			else if (GameCanvas.isTouch)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
			this.sosanh(item);
			return;
		}
		this.wContent = item.sizeW;
		this.setYCon(item);
		if (this.idSelect % this.numW < 2)
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.idSelect % this.numW * (int)MainTabNew.wOneItem;
		}
		else if (this.idSelect % this.numW < 5)
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.idSelect % this.numW * (int)MainTabNew.wOneItem - this.wContent / 2;
		}
		else
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.idSelect % this.numW * (int)MainTabNew.wOneItem - this.wContent;
		}
	}

	// Token: 0x06000817 RID: 2071 RVA: 0x0008BBA0 File Offset: 0x00089DA0
	public override void setYCon(Item item)
	{
		int num = 0;
		if (MainScreen.cameraSub.yCam > 0)
		{
			num = MainScreen.cameraSub.yCam / (int)MainTabNew.wOneItem;
		}
		int num2 = 1;
		this.mContent = item.mcontent;
		this.moreInfoconten = item.moreContenGem;
		this.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num2 += this.mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num2 += item.mPlusContent.Length;
		}
		if (this.idSelect / this.numW < this.numHPaint / 2 + num)
		{
			this.yCon = this.yBegin + (this.idSelect / this.numW + 1) * (int)MainTabNew.wOneItem + 2;
			if (this.yCon - MainScreen.cameraSub.yCam + (num2 + 1) * GameCanvas.hText > GameCanvas.h - (GameCanvas.hCommand - 5))
			{
				this.yCon = GameCanvas.h - (GameCanvas.hCommand - 5) - ((num2 + 1) * GameCanvas.hText - MainScreen.cameraSub.yCam);
			}
		}
		else
		{
			this.yCon = this.yBegin + this.idSelect / this.numW * (int)MainTabNew.wOneItem - 7 - num2 * GameCanvas.hText - MainScreen.cameraSub.yCam;
			if (this.yCon - MainScreen.cameraSub.yCam < 6)
			{
				this.yCon = 6 + MainScreen.cameraSub.yCam;
			}
		}
		if ((num2 + 1) * GameCanvas.hText > MainTabNew.hMaxContent - this.hcmd)
		{
			this.listContent = new ListNew(this.xCon, this.yCon, this.wContent, MainTabNew.hMaxContent, 0, 0, (num2 + 1) * GameCanvas.hText - (MainTabNew.hMaxContent - this.hcmd));
		}
		this.sosanh(item);
	}

	// Token: 0x06000818 RID: 2072 RVA: 0x0008BD78 File Offset: 0x00089F78
	public void sosanh(Item item)
	{
		if ((int)this.typeTab == (int)MainTabNew.INVENTORY && item.ItemCatagory == 3 && (item.classcharItem == 4 || item.classcharItem == (int)GameScreen.player.clazz) && item.type_Only_Item < 12)
		{
			sbyte b = (sbyte)MainTemplateItem.mItem_Rotate_Tem_Equip[item.type_Only_Item];
			Item item4;
			if ((int)b == -1)
			{
				int num = 0;
				int num2 = 0;
				Item item2 = (Item)Item.VecEquipPlayer.get(string.Empty + 3);
				Item item3 = (Item)Item.VecEquipPlayer.get(string.Empty + 9);
				if (item2 == null)
				{
					item4 = item3;
				}
				else if (item3 == null)
				{
					item4 = item2;
				}
				else
				{
					for (int i = 0; i < item2.mInfo.Length; i++)
					{
						num += item2.mInfo[i].value;
					}
					for (int j = 0; j < item3.mInfo.Length; j++)
					{
						num2 += item3.mInfo[j].value;
					}
					if (num >= num2)
					{
						item4 = item3;
					}
					else
					{
						item4 = item2;
					}
				}
			}
			else
			{
				item4 = (Item)Item.VecEquipPlayer.get(string.Empty + b);
			}
			if (item4 != null && item4.type_Only_Item == item.type_Only_Item && this.mContent != null && item4.moreContenGem.size() <= 0)
			{
				this.mSubContent = new string[this.mContent.Length];
				this.mSubColor = new int[this.mContent.Length];
				for (int k = 0; k < this.mSubContent.Length; k++)
				{
					this.mSubContent[k] = string.Empty;
					this.mSubColor[k] = 0;
					for (int l = 0; l < item4.mInfo.Length; l++)
					{
						if (item.mInfo[k].id == item4.mInfo[l].id)
						{
							int num3 = item.mInfo[k].value - item4.mInfo[l].value;
							if (num3 >= 0)
							{
								this.mSubColor[k] = 5;
								this.mSubContent[k] = "+";
							}
							else
							{
								this.mSubContent[k] = "-";
								this.mSubColor[k] = 6;
							}
							string[] mSubContent = this.mSubContent;
							int num4 = k;
							mSubContent[num4] += Item.getPercent((int)Item.isPercentInfoItem[item.mInfo[k].id], CRes.abs(num3));
							string str = Item.nameInfoItem[item.mInfo[k].id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[item.mInfo[k].id], item.mInfo[k].value);
							int width = mFont.tahoma_7_black.getWidth(str + " " + this.mSubContent[k]);
							if (this.wContent < width + 10)
							{
								this.wContent = width + 10;
							}
							break;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000819 RID: 2073 RVA: 0x0008C0D0 File Offset: 0x0008A2D0
	public override void updatePointer()
	{
		bool flag = false;
		if (this.listContent != null && GameCanvas.isPoint(this.listContent.x, this.listContent.y, this.listContent.maxW, this.listContent.maxH))
		{
			this.listContent.update_Pos_UP_DOWN();
			flag = true;
		}
		if (GameCanvas.isTouch && !flag)
		{
			this.list.update_Pos_UP_DOWN();
			MainScreen.cameraSub.yCam = this.list.cmx;
		}
		if (GameCanvas.isPointSelect(this.xBegin, this.yBegin, this.numW * (int)MainTabNew.wOneItem, MainTabNew.hblack - (int)MainTabNew.wOne5 / 2) && !flag)
		{
			int num = (GameCanvas.px - this.xBegin) / (int)MainTabNew.wOneItem + (GameCanvas.py - this.yBegin + MainScreen.cameraSub.yCam) / (int)MainTabNew.wOneItem * this.numW;
			int num2;
			if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
			{
				num2 = Item.VecItemSell.size();
			}
			else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
			{
				num2 = Item.VecInvetoryPlayer.size();
			}
			else if ((int)this.typeTab == (int)MainTabNew.CHEST)
			{
				num2 = Item.VecChestPlayer.size();
			}
			else if ((int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY)
			{
				num2 = Item.VecClanInvetory.size();
			}
			else if ((int)this.typeTab == (int)MainTabNew.PET_KEEPER)
			{
				num2 = Item.VecPetContainer.size();
			}
			else
			{
				num2 = this.vecShop.size();
			}
			if (num >= 0 && num < num2)
			{
				GameCanvas.isPointerSelect = false;
				if (num == this.idSelect)
				{
					if (MainTabNew.longwidth == 0)
					{
						if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE || (int)this.typeTab == (int)MainTabNew.CHEST || (int)this.typeTab == (int)MainTabNew.SELLITEM || (int)this.typeTab == (int)MainTabNew.CLAN_INVENTORY || ((int)this.typeTab == (int)MainTabNew.SHOP && (int)this.isTypeShop == (int)TabShopNew.SHOP_BANG) || (int)this.typeTab == (int)MainTabNew.PET_KEEPER)
						{
							this.cmdMenuInven.perform();
						}
						else if ((int)this.isTypeShop == (int)TabShopNew.WING)
						{
							this.cmdCreateWing.perform();
						}
						else
						{
							this.cmdHoiMua.perform();
						}
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
					this.idSelect = num + 42 * (int)this.currentTab;
					if ((int)this.currentTab == 0 && this.idSelect == 42)
					{
						this.idSelect = -1;
					}
					if ((int)this.currentTab == 1 && this.idSelect == 84)
					{
						this.idSelect = -1;
					}
					if ((int)this.currentTab == 3 && this.idSelect == 126)
					{
						this.idSelect = -1;
					}
					if (this.isShop)
					{
						this.idSelect = num;
					}
					this.cmdListBig();
					this.listContent = null;
				}
				if ((int)MainTabNew.Focus != (int)MainTabNew.INFO)
				{
					MainTabNew.Focus = MainTabNew.INFO;
				}
			}
			else
			{
				this.idSelect = -1;
				MainTabNew.timePaintInfo = 0;
				this.listContent = null;
			}
		}
		if (this.vecListCmd != null && (int)MainTabNew.Focus == (int)MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			for (int i = 0; i < this.vecListCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x0600081A RID: 2074 RVA: 0x0008C4C8 File Offset: 0x0008A6C8
	public void cmdListBig()
	{
		if (MainTabNew.longwidth > 0 && GameCanvas.isTouch)
		{
			this.hcmd = 0;
			mVector mVector;
			if ((int)this.typeTab == (int)MainTabNew.SELLITEM)
			{
				mVector = Item.VecItemSell;
			}
			else if ((int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.INVEN_AND_STORE)
			{
				mVector = Item.VecInvetoryPlayer;
			}
			else if ((int)this.typeTab == (int)MainTabNew.CHEST)
			{
				mVector = Item.VecChestPlayer;
			}
			else
			{
				mVector = this.vecShop;
			}
			if (this.idSelect >= 0 && this.idSelect < mVector.size())
			{
				Item item = (Item)mVector.elementAt(this.idSelect);
				this.vecListCmd = this.doMenu(item);
				base.setPosCmd(this.vecListCmd);
				this.hcmd = (this.vecListCmd.size() + 1) / 2 * iCommand.hButtonCmd;
			}
		}
	}

	// Token: 0x04000C77 RID: 3191
	public static sbyte NORMAL = 0;

	// Token: 0x04000C78 RID: 3192
	public static sbyte TOC = 1;

	// Token: 0x04000C79 RID: 3193
	public static sbyte INVEN_AND_CHEST = 2;

	// Token: 0x04000C7A RID: 3194
	public static sbyte INVEN_AND_REBUILD = 3;

	// Token: 0x04000C7B RID: 3195
	public static sbyte SHOP_BANG = 4;

	// Token: 0x04000C7C RID: 3196
	public static sbyte INVEN_BANG = 5;

	// Token: 0x04000C7D RID: 3197
	public static sbyte INVEN_AND_REPLACE = 6;

	// Token: 0x04000C7E RID: 3198
	public static sbyte INVEN_AND_WING = 7;

	// Token: 0x04000C7F RID: 3199
	public static sbyte WING = 7;

	// Token: 0x04000C80 RID: 3200
	public static sbyte INVEN_AND_PET_KEEPER = 8;

	// Token: 0x04000C81 RID: 3201
	public static sbyte INVEN_FOOD_PET = 9;

	// Token: 0x04000C82 RID: 3202
	public static sbyte INVEN_LOTTERY = 10;

	// Token: 0x04000C83 RID: 3203
	public static sbyte SHOP_VANTIEU = 11;

	// Token: 0x04000C84 RID: 3204
	public static sbyte SHOP_KHAM_NGOC = 12;

	// Token: 0x04000C85 RID: 3205
	public static sbyte SHOP_GHEP_NGOC = 13;

	// Token: 0x04000C86 RID: 3206
	public static sbyte SHOP_DUC_LO = 14;

	// Token: 0x04000C87 RID: 3207
	public static sbyte SHOP_STORE_OTHER_PLAYER = 15;

	// Token: 0x04000C88 RID: 3208
	public static sbyte SHOP_ANY_NGUYEN_LIEU = 16;

	// Token: 0x04000C89 RID: 3209
	public static sbyte SHOP_HOP_AN = 17;

	// Token: 0x04000C8A RID: 3210
	public static sbyte SHOP_NANG_CAP_MEDEL = 18;

	// Token: 0x04000C8B RID: 3211
	public static sbyte UPDATE = -1;

	// Token: 0x04000C8C RID: 3212
	public static sbyte GET_CHEST = 0;

	// Token: 0x04000C8D RID: 3213
	public static sbyte SET_CHEST = 1;

	// Token: 0x04000C8E RID: 3214
	public static sbyte UPDATE_PET_EAT = 2;

	// Token: 0x04000C8F RID: 3215
	public static sbyte WITHDRAW_PET = 0;

	// Token: 0x04000C90 RID: 3216
	public static sbyte DEPOSIT_PET = 1;

	// Token: 0x04000C91 RID: 3217
	public static bool isTabHopNL;

	// Token: 0x04000C92 RID: 3218
	private sbyte currentTab;

	// Token: 0x04000C93 RID: 3219
	public static sbyte maxTab;

	// Token: 0x04000C94 RID: 3220
	public static short priceSellPotion;

	// Token: 0x04000C95 RID: 3221
	public static short priceSellItem;

	// Token: 0x04000C96 RID: 3222
	public static short hesoLv;

	// Token: 0x04000C97 RID: 3223
	public static short hesoColor;

	// Token: 0x04000C98 RID: 3224
	public static short priceSellQuest = 1;

	// Token: 0x04000C99 RID: 3225
	public static short maxPriceItem;

	// Token: 0x04000C9A RID: 3226
	public static short PriceIconClan;

	// Token: 0x04000C9B RID: 3227
	public static short PriceChatWorld = 0;

	// Token: 0x04000C9C RID: 3228
	public static bool isSortInven = false;

	// Token: 0x04000C9D RID: 3229
	private int IDTab;

	// Token: 0x04000C9E RID: 3230
	private int numW = 6;

	// Token: 0x04000C9F RID: 3231
	private int numH = 6;

	// Token: 0x04000CA0 RID: 3232
	private int numHPaint;

	// Token: 0x04000CA1 RID: 3233
	private int maxSize = 60;

	// Token: 0x04000CA2 RID: 3234
	private int idSelect;

	// Token: 0x04000CA3 RID: 3235
	private int hcmd;

	// Token: 0x04000CA4 RID: 3236
	private InputDialog inputWorld;

	// Token: 0x04000CA5 RID: 3237
	private string textWorld = string.Empty;

	// Token: 0x04000CA6 RID: 3238
	public static short idSeller = 0;

	// Token: 0x04000CA7 RID: 3239
	public bool isShop_Other_Player;

	// Token: 0x04000CA8 RID: 3240
	private mVector vecShop = new mVector("TabShopNew vecShop");

	// Token: 0x04000CA9 RID: 3241
	public static int IdTabSave = -1;

	// Token: 0x04000CAA RID: 3242
	public PetItem petCur;

	// Token: 0x04000CAB RID: 3243
	public byte numofGem;

	// Token: 0x04000CAC RID: 3244
	public static mHashTable allidNgocKham = new mHashTable();

	// Token: 0x04000CAD RID: 3245
	private iCommand cmdHoiMua;

	// Token: 0x04000CAE RID: 3246
	private iCommand cmdSelect;

	// Token: 0x04000CAF RID: 3247
	private iCommand cmdBuyPotion;

	// Token: 0x04000CB0 RID: 3248
	private iCommand cmdMua;

	// Token: 0x04000CB1 RID: 3249
	private iCommand cmdHoiXoaItem;

	// Token: 0x04000CB2 RID: 3250
	private iCommand cmdXoaItem;

	// Token: 0x04000CB3 RID: 3251
	private iCommand cmdMenuInven;

	// Token: 0x04000CB4 RID: 3252
	private iCommand cmdSetKey;

	// Token: 0x04000CB5 RID: 3253
	private iCommand cmdHoiSell;

	// Token: 0x04000CB6 RID: 3254
	private iCommand cmdSell;

	// Token: 0x04000CB7 RID: 3255
	private iCommand cmdGetChest;

	// Token: 0x04000CB8 RID: 3256
	private iCommand cmdSetChest;

	// Token: 0x04000CB9 RID: 3257
	private iCommand cmdGetPotionChest;

	// Token: 0x04000CBA RID: 3258
	private iCommand cmdSetPotionChest;

	// Token: 0x04000CBB RID: 3259
	private iCommand cmdSellMore;

	// Token: 0x04000CBC RID: 3260
	private iCommand cmdRebuild;

	// Token: 0x04000CBD RID: 3261
	private iCommand cmdUnRebuild;

	// Token: 0x04000CBE RID: 3262
	private iCommand cmdNextIcon;

	// Token: 0x04000CBF RID: 3263
	private iCommand cmdReplace;

	// Token: 0x04000CC0 RID: 3264
	private iCommand cmdWing;

	// Token: 0x04000CC1 RID: 3265
	private iCommand cmdCreateWing;

	// Token: 0x04000CC2 RID: 3266
	private iCommand cmdDepositPet;

	// Token: 0x04000CC3 RID: 3267
	private iCommand cmdWithdrawPet;

	// Token: 0x04000CC4 RID: 3268
	private iCommand cmdFoodPet;

	// Token: 0x04000CC5 RID: 3269
	private iCommand cmdPetInfo;

	// Token: 0x04000CC6 RID: 3270
	private iCommand cmdPetFeed;

	// Token: 0x04000CC7 RID: 3271
	private iCommand cmdSelectReward;

	// Token: 0x04000CC8 RID: 3272
	private iCommand cmdHopNguyeLieu;

	// Token: 0x04000CC9 RID: 3273
	private iCommand cmdMua1;

	// Token: 0x04000CCA RID: 3274
	private iCommand cmdMua10;

	// Token: 0x04000CCB RID: 3275
	private iCommand cmdMua30;

	// Token: 0x04000CCC RID: 3276
	private iCommand cmdKhamgoc;

	// Token: 0x04000CCD RID: 3277
	private iCommand cmdGhepNgoc;

	// Token: 0x04000CCE RID: 3278
	private iCommand cmdDuclo;

	// Token: 0x04000CCF RID: 3279
	private iCommand cmdBovao;

	// Token: 0x04000CD0 RID: 3280
	private iCommand cmdLayra;

	// Token: 0x04000CD1 RID: 3281
	private iCommand cmdMuaNhieu;

	// Token: 0x04000CD2 RID: 3282
	private iCommand cmdHoidaugia;

	// Token: 0x04000CD3 RID: 3283
	private iCommand cmdDaugia;

	// Token: 0x04000CD4 RID: 3284
	private iCommand cmdHoanThanh;

	// Token: 0x04000CD5 RID: 3285
	private iCommand cmdOkSell;

	// Token: 0x04000CD6 RID: 3286
	private iCommand cmdBuyItemOtherplayer;

	// Token: 0x04000CD7 RID: 3287
	private iCommand cmdhuy;

	// Token: 0x04000CD8 RID: 3288
	private iCommand cmdNghiban;

	// Token: 0x04000CD9 RID: 3289
	private iCommand cmdChatWorld;

	// Token: 0x04000CDA RID: 3290
	private iCommand cmdlaynguyenlieura;

	// Token: 0x04000CDB RID: 3291
	private iCommand cmdHoprac;

	// Token: 0x04000CDC RID: 3292
	private iCommand cmdlayracra;

	// Token: 0x04000CDD RID: 3293
	private iCommand cmdbanNguyenLieu;

	// Token: 0x04000CDE RID: 3294
	private iCommand cmdHopAn;

	// Token: 0x04000CDF RID: 3295
	private iCommand cmdNextInven;

	// Token: 0x04000CE0 RID: 3296
	private iCommand cmdKhacItem;

	// Token: 0x04000CE1 RID: 3297
	private InputDialog inputDialog;

	// Token: 0x04000CE2 RID: 3298
	private ListNew list;

	// Token: 0x04000CE3 RID: 3299
	private mVector vecListCmd;

	// Token: 0x04000CE4 RID: 3300
	public sbyte isTypeShop;

	// Token: 0x04000CE5 RID: 3301
	private string nameCmdBuy = string.Empty;

	// Token: 0x04000CE6 RID: 3302
	private bool isShop;
}
