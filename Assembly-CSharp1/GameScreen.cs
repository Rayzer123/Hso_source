using System;

// Token: 0x0200007F RID: 127
public class GameScreen : MainScreen
{
	// Token: 0x060005CE RID: 1486 RVA: 0x0005589C File Offset: 0x00053A9C
	public GameScreen()
	{
		this.cmdAddfriend = new iCommand(T.addFriend, 0);
		this.cmdInfoChar = new iCommand(T.info, 1);
		this.cmdChat = new iCommand(T.trochuyen, 2);
		this.cmdMoiParty = new iCommand(T.moiParty, 3);
		this.cmdNewParty = new iCommand(T.newParty, 5);
		this.cmdBuy_Sell = new iCommand(T.buySell, 7);
		this.cmdSetWeather = new iCommand("mua", 25, this);
		this.cmdChucNang = new iCommand(T.chucnang, 14);
		this.cmdAddMemClan = new iCommand(T.addmemclan, 15);
		this.cmdGiaotiep = new iCommand(T.giaotiep, 0, this);
		this.cmdMenu = new iCommand(T.menu, 1, this);
		this.cmdShowChat = new iCommand(T.tinnhan, 4, this);
		this.cmdParty = new iCommand(T.party, 6, this);
		this.cmdSetPk = new iCommand(T.setPk, 8, this);
		this.cmdSetDoSat = new iCommand(T.dosat, 10, this);
		this.cmdChangeMap = new iCommand(T.changeArea, 12, this);
		this.cmdListFriend = new iCommand(T.listFriend, 15, this);
		this.cmdAutoFire = new iCommand(T.autoFire, 16, this);
		this.cmdEndHelp = new iCommand(T.endHelp, 17, this);
		this.cmdAutoItem = new iCommand(T.autoItem, 18, this);
		this.cmdAutoMPHP = new iCommand(T.autoHP, 19, this);
		this.cmdThachDau = new iCommand(T.thachdau, 20, this);
		this.cmdAutoBuff = new iCommand(T.autoBuff, 21, this);
		this.cmdShowAuto = new iCommand(T.info, 22, this);
		this.cmdInfoVantieu = new iCommand(T.info, 27, this);
		this.cmdQuickChat = new iCommand(T.chat, 28, this);
		this.cmdplayerStore = new iCommand(T.gianHang, 30, this);
		this.cmdinfoMiNuong = new iCommand(T.info, 31, this);
	}

	// Token: 0x060005D0 RID: 1488 RVA: 0x00055C70 File Offset: 0x00053E70
	public static GameScreen gI()
	{
		if (GameCanvas.game == null)
		{
			GameCanvas.game = new GameScreen();
		}
		return GameCanvas.game;
	}

	// Token: 0x060005D1 RID: 1489 RVA: 0x00055C8C File Offset: 0x00053E8C
	public override void Show()
	{
		this.left = null;
		this.right = null;
		this.center = null;
		if (Main.isPC)
		{
			this.cmdMenu.isNotShowTab = true;
			this.left = this.cmdMenu;
		}
		base.Show();
		GameScreen.isMoveCamera = false;
		GameCanvas.clearAll();
	}

	// Token: 0x060005D2 RID: 1490 RVA: 0x00055CE4 File Offset: 0x00053EE4
	public void checkRemoveImage()
	{
		if (!GameCanvas.isTouch)
		{
			this.checkClear();
		}
		ImageEffectAuto.SetRemoveAll();
		ImageEffect.SetRemoveAll();
		BackGround.mImgSky = null;
		BackGround.mImgSea = null;
		BackGround.mImgFloating = null;
		BackGround.mImgBoat = null;
		mSystem.my_Gc();
		PaintInfoGameScreen.timeDoNotClick = GameCanvas.timeNow;
		GameScreen.vecWeather.removeAllElements();
	}

	// Token: 0x060005D3 RID: 1491 RVA: 0x00055D3C File Offset: 0x00053F3C
	public void setCaptionCmd()
	{
		this.cmdAddfriend.caption = T.addFriend;
		this.cmdInfoChar.caption = T.info;
		this.cmdChat.caption = T.trochuyen;
		this.cmdMoiParty.caption = T.moiParty;
		this.cmdNewParty.caption = T.newParty;
		this.cmdBuy_Sell.caption = T.buySell;
		this.cmdChucNang.caption = T.chucnang;
		this.cmdAddMemClan.caption = T.addmemclan;
		this.cmdGiaotiep.caption = T.giaotiep;
		this.cmdMenu.caption = T.menu;
		this.cmdShowChat.caption = T.tinnhan;
		this.cmdParty.caption = T.party;
		this.cmdSetPk.caption = T.setPk;
		this.cmdSetDoSat.caption = T.dosat;
		this.cmdChangeMap.caption = T.changeArea;
		this.cmdListFriend.caption = T.listFriend;
		this.cmdAutoFire.caption = T.autoFire;
		this.cmdEndHelp.caption = T.endHelp;
		this.cmdAutoItem.caption = T.autoItem;
		this.cmdAutoMPHP.caption = T.autoHP;
		this.cmdThachDau.caption = T.thachdau;
		this.cmdAutoBuff.caption = T.autoBuff;
		this.cmdShowAuto.caption = T.info;
		this.cmdInfoVantieu.caption = T.info;
		this.cmdQuickChat.caption = T.chat;
	}

	// Token: 0x060005D4 RID: 1492 RVA: 0x00055EDC File Offset: 0x000540DC
	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 2:
			GameCanvas.AllInfo.Show(this);
			break;
		}
		base.commandTab(index, sub);
	}

	// Token: 0x060005D5 RID: 1493 RVA: 0x00055F24 File Offset: 0x00054124
	public override void commandMenu(int index, int sub)
	{
		switch (index)
		{
		case 0:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Friend(0, Menu2.objSelect.name);
			}
			break;
		case 1:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Re_Info_Other_Object(Menu2.objSelect.name, Info_Other_Player.VIEW);
			}
			break;
		case 2:
			if (Menu2.objSelect != null)
			{
				GameCanvas.msgchat.addNewChat(Menu2.objSelect.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			}
			GameCanvas.start_Chat_Dialog();
			break;
		case 3:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Party(1, Menu2.objSelect.name);
			}
			break;
		case 5:
			GlobalService.gI().Party(0, string.Empty);
			break;
		case 7:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Buy_Sell(0, Menu2.objSelect.name, 0, 0, 0);
			}
			break;
		case 14:
			this.MenuChucNang();
			break;
		case 15:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Add_And_AnS_MemClan(10, Menu2.objSelect.name);
			}
			break;
		}
		base.commandMenu(index, sub);
	}

	// Token: 0x060005D6 RID: 1494 RVA: 0x0005609C File Offset: 0x0005429C
	public void MenuChucNang()
	{
		mVector mVector = new mVector("GameScr menu3");
		mVector.addElement(this.cmdListFriend);
		string caption = T.off + " " + T.dosat;
		if ((int)GameScreen.player.typePk != 0)
		{
			mVector.addElement(this.cmdSetPk);
			caption = T.on + " " + T.dosat;
		}
		this.cmdSetDoSat.caption = caption;
		mVector.addElement(this.cmdSetDoSat);
		if ((int)Player.isAutoFire > -1)
		{
			this.cmdAutoFire.caption = T.off + T.autoFire;
		}
		else
		{
			this.cmdAutoFire.caption = T.on + T.autoFire;
		}
		mVector.addElement(this.cmdAutoFire);
		if (Player.autoItem != null)
		{
			this.cmdAutoItem.caption = T.off + T.autoItem;
		}
		else
		{
			this.cmdAutoItem.caption = T.on + T.autoItem;
		}
		mVector.addElement(this.cmdAutoItem);
		if (Player.isAutoHPMP)
		{
			this.cmdAutoMPHP.caption = T.off + T.autoHP;
		}
		else
		{
			this.cmdAutoMPHP.caption = T.on + T.autoHP;
		}
		mVector.addElement(this.cmdAutoMPHP);
		if (GameScreen.help.Step >= 0)
		{
			mVector.addElement(this.cmdEndHelp);
		}
		GameCanvas.menu2.startAt(mVector, 2, T.chucnang, false, null);
	}

	// Token: 0x060005D7 RID: 1495 RVA: 0x0005623C File Offset: 0x0005443C
	public void doArea()
	{
		GlobalService.gI().Request_Area();
		GameScreen.isReArea = true;
		GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
	}

	// Token: 0x060005D8 RID: 1496 RVA: 0x00056264 File Offset: 0x00054464
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			GameCanvas.end_Dialog();
			if (GameScreen.player.isSelling())
			{
				this.do_Show_SellItem();
			}
			else
			{
				if (GameScreen.infoGame.isMapThachdau() && !GameCanvas.isTouch)
				{
					return;
				}
				if (GameScreen.ObjFocus != null)
				{
					if (GameScreen.ObjFocus.isSelling())
					{
						this.cmdplayerStore.perform();
					}
					else if (!GameScreen.player.setFirePlayer(GameScreen.ObjFocus) || (int)GameScreen.ObjFocus.typeObject != 0)
					{
						GameScreen.ObjFocus.GiaoTiep();
						if ((int)Player.isAutoFire == 1)
						{
							Player.setCurAutoFire();
						}
						GameScreen.player.resetAction();
						GameScreen.timePaintCmdGiaotiep = 0;
					}
					else if (this.center == this.cmdGiaotiep)
					{
						this.center = null;
					}
				}
			}
			break;
		case 1:
			GameCanvas.end_Dialog();
			if (GameScreen.player.isSelling())
			{
				this.do_Show_SellItem();
			}
			else
			{
				GameCanvas.AllInfo.Show(GameCanvas.game);
				GlobalService.gI().send_cmd_server(59);
				if (GameScreen.help.setStep_Next(1, 9))
				{
					GameCanvas.AllInfo.selectTab = 0;
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
				else if (GameScreen.help.setStep_Next(6, 2))
				{
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			break;
		case 4:
			GameCanvas.start_Chat_Dialog();
			break;
		case 6:
			if (Player.party != null)
			{
				GameCanvas.start_Party_Dialog();
			}
			break;
		case 8:
		{
			mVector mVector = new mVector("GameScr menu");
			for (int i = 0; i < T.mColorPk.Length; i++)
			{
				if (i > 0 || (int)GameScreen.player.typePk != -1)
				{
					iCommand iCommand = new iCommand(T.mColorPk[i], 9, (i != 0) ? i : -1, this);
					if (mGraphics.zoomLevel >= 3)
					{
						if (i > 0)
						{
							FrameImage[] array = new FrameImage[3];
							for (int j = 0; j < array.Length; j++)
							{
								array[j] = AvMain.fraPkArr[i * 3 + j];
							}
							iCommand.setFraCaption(array, 3, i * 3);
						}
					}
					else if (i > 0)
					{
						iCommand.setFraCaption(AvMain.fraPk, 3, i * 3);
					}
					mVector.addElement(iCommand);
				}
			}
			GameCanvas.menu2.startAt(mVector, 4, T.setPk, false, null);
			break;
		}
		case 9:
			GlobalService.gI().set_Pk((sbyte)subIndex);
			break;
		case 10:
			if ((int)GameScreen.player.typePk != 0)
			{
				GameCanvas.start_Left_Dialog(T.hoibatdosat, new iCommand(T.on, 24, this));
			}
			else
			{
				GlobalService.gI().set_Pk(-1);
			}
			break;
		case 13:
			GlobalService.gI().Change_Area((sbyte)subIndex);
			break;
		case 15:
			if (!List_Server.isLoadFriend)
			{
				GlobalService.gI().Friend(4, string.Empty);
				GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			}
			else
			{
				List_Server.gI().vecListServer = List_Server.vecMyFriend;
				List_Server.gI().typeList = 0;
				List_Server.gI().updateList();
				List_Server.gI().setMinMax();
				List_Server.gI().setXmove();
				List_Server.gI().setCmd();
				List_Server.gI().nameList = T.listFriend;
				List_Server.gI().page = 99;
				List_Server.gI().Show(this);
			}
			break;
		case 16:
			if ((int)Player.isAutoFire > -1)
			{
				Player.isAutoFire = -1;
				Player.isCurAutoFire = false;
			}
			else
			{
				Player.isAutoFire = 0;
				Player.isCurAutoFire = true;
			}
			break;
		case 17:
			GameScreen.help.p = null;
			GameScreen.help.Step = -1;
			GameScreen.help.Next = 0;
			GameScreen.help.setNext();
			GameScreen.help.SaveStep();
			break;
		case 18:
			if (Player.autoItem != null)
			{
				Player.autoItem.isremove = true;
			}
			else
			{
				GameCanvas.start_Auto_Item_Dialog();
			}
			break;
		case 19:
			if (Player.isAutoHPMP)
			{
				Player.isAutoHPMP = false;
				MainRMS.setSaveAuto();
			}
			else
			{
				GameCanvas.start_Auto_HPMP_Dialog();
			}
			break;
		case 20:
			if (Menu2.objSelect != null)
			{
				GlobalService.gI().Thach_Dau(0, Menu2.objSelect.name);
			}
			break;
		case 21:
			GameCanvas.start_Auto_Buff();
			break;
		case 22:
			PaintInfoGameScreen.isShowInfoAuto = !PaintInfoGameScreen.isShowInfoAuto;
			MainRMS.setSaveTouch();
			break;
		case 24:
			GlobalService.gI().set_Pk(0);
			GameCanvas.end_Dialog();
			break;
		case 25:
			GameScreen.AddEffWeather(0, false, -4, 300);
			break;
		case 26:
			if (subIndex >= 0 && subIndex <= this.menuNgua.size() - 1)
			{
				MainItem mainItem = (MainItem)this.menuNgua.elementAt(subIndex);
				if (mainItem != null)
				{
					GlobalService.gI().Use_Potion((short)mainItem.Id);
				}
			}
			break;
		case 27:
			GlobalService.gI().Dynamic_Menu(-56, 0, 0);
			break;
		case 28:
		{
			mVector mVector2 = new mVector("GameScr menuchat");
			for (int k = 0; k < T.mQuickChat.Length; k++)
			{
				iCommand iCommand2 = new iCommand(T.mQuickChat[k], 29, k, this);
				mVector2.addElement(iCommand2);
			}
			GameCanvas.menu2.startAt(mVector2, 4, T.chat, false, null);
			break;
		}
		case 29:
			GameScreen.player.strChatPopup = T.mQuickChat[subIndex];
			GlobalService.gI().chatPopup(T.mQuickChat[subIndex]);
			break;
		case 30:
			if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.isSelling())
			{
				GlobalService.gI().do_Buy_Sell_Item(1, null, string.Empty, (short)GameScreen.ObjFocus.ID, 0, 0);
			}
			break;
		case 31:
			if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.isMiNuong())
			{
				GlobalService.gI().RequestInfo_MiNuong(0, (short)(GameScreen.ObjFocus.ID + 1000));
			}
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060005D9 RID: 1497 RVA: 0x000568F0 File Offset: 0x00054AF0
	public void doSellItem()
	{
		GameCanvas.end_Dialog();
		Item.VecItem_Sell_in_store.removeAllElements();
		Item.VecItemSell.removeAllElements();
		mVector mVector = new mVector("Sell");
		sbyte isTypeShop = 0;
		TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVEN_AND_STORE, T.tabhanhtrang, -1, isTypeShop);
		mVector.addElement(tabShopNew);
		mVector vec = new mVector("info");
		TabShopNew tabShopNew2 = new TabShopNew(vec, MainTabNew.SELLITEM, T.gianHang, -1, 0);
		mVector.addElement(tabShopNew2);
		GameCanvas.shopNpc = new TabScreenNew();
		GameCanvas.shopNpc.selectTab = 0;
		GameCanvas.shopNpc.addMoreTab(mVector);
		GameCanvas.shopNpc.Show(GameScreen.gI());
	}

	// Token: 0x060005DA RID: 1498 RVA: 0x00056998 File Offset: 0x00054B98
	public void do_Show_SellItem()
	{
		GameCanvas.end_Dialog();
		mVector mVector = new mVector("Sell");
		sbyte isTypeShop = 0;
		TabShopNew tabShopNew = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVEN_AND_STORE, T.tabhanhtrang, -1, isTypeShop);
		mVector.addElement(tabShopNew);
		mVector vec = new mVector("info");
		TabShopNew tabShopNew2 = new TabShopNew(vec, MainTabNew.SELLITEM, T.gianHang, -1, 0);
		mVector.addElement(tabShopNew2);
		GameCanvas.shopNpc = new TabScreenNew();
		GameCanvas.shopNpc.selectTab = 0;
		GameCanvas.shopNpc.addMoreTab(mVector);
		GameCanvas.shopNpc.Show(GameScreen.gI());
	}

	// Token: 0x060005DB RID: 1499 RVA: 0x00056A2C File Offset: 0x00054C2C
	public void paintMonsterEffect(mGraphics g)
	{
		for (int i = 0; i < EffectMonster.listEffectMonster.size(); i++)
		{
			EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(i);
			effectMonster.paint(g);
		}
	}

	// Token: 0x060005DC RID: 1500 RVA: 0x00056A6C File Offset: 0x00054C6C
	public void paintMonsterDieEffect(mGraphics g)
	{
		for (int i = 0; i < EffectMonster.listEffectMonster.size(); i++)
		{
			EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(i);
			effectMonster.paintDie(g);
		}
	}

	// Token: 0x060005DD RID: 1501 RVA: 0x00056AAC File Offset: 0x00054CAC
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		try
		{
			GameScreen.dx = 0;
			GameScreen.dy = 0;
			if (LoadMap.timeVibrateScreen > 0)
			{
				if (LoadMap.timeVibrateScreen > 100)
				{
					GameScreen.dy = CRes.random_Am_0(3);
					if (LoadMap.timeVibrateScreen == 101)
					{
						LoadMap.timeVibrateScreen = 0;
					}
				}
				else
				{
					GameScreen.dy = CRes.random_Am_0(3);
					GameScreen.dx = CRes.random_Am(0, 2);
				}
				LoadMap.timeVibrateScreen--;
			}
			g.translate(GameScreen.dx, GameScreen.dy);
			g.translate(-MainScreen.cameraMain.xCam, -MainScreen.cameraMain.yCam);
			if (GameCanvas.mapBack != null)
			{
				GameCanvas.mapBack.paint(g);
			}
			if (LoadMap.idTile == 9)
			{
				g.setColor(367554);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			}
			GameCanvas.loadmap.paint(g);
			GameScreen.infoGame.paintShip(g);
			if (this.isFullScreen)
			{
				g.drawRecAlpa(0, 0, GameCanvas.loadmap.mapW * 24, GameCanvas.loadmap.mapH * 24, this.colorRec);
			}
			else if (this.wRec > 0)
			{
				g.fillRecAlpla(this.xRec, this.yRec, this.wRec, this.hRec, this.colorRec);
			}
			for (int i = 0; i < GameScreen.vecDataeff.size(); i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)GameScreen.vecDataeff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.paintTop(g, (int)dataSkillEff.x, (int)dataSkillEff.y);
				}
			}
			for (int j = 0; j < LoadMap.Thacnuoc.size(); j++)
			{
				ThacNuoc thacNuoc = (ThacNuoc)LoadMap.Thacnuoc.elementAt(j);
				thacNuoc.paint(g);
			}
			for (int k = 0; k < GameScreen.vecStep.size(); k++)
			{
				Point point = (Point)GameScreen.vecStep.elementAt(k);
				point.paint(g);
			}
			for (int l = 0; l < GameScreen.vecEffInMap.size(); l++)
			{
				Point point2 = (Point)GameScreen.vecEffInMap.elementAt(l);
				point2.paint(g);
			}
			if (GameScreen.help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
			{
				GameScreen.help.paintHelpFrist(g);
			}
			if (GameCanvas.isTouch && Player.timeFocus > 0 && GameScreen.player.posTransRoad != null && Player.xFocus >= 0)
			{
				PaintInfoGameScreen.fraFocusIngame.drawFrame((4 - Player.timeFocus / 2) % PaintInfoGameScreen.fraFocusIngame.nFrame, Player.xFocus, Player.yFocus, 0, 3, g);
			}
			EffectManager.lowEffects.paintAll(g);
			this.paintMonsterDieEffect(g);
			ItemMap.paintDieHouseArena(g);
			try
			{
				this.pz = 0;
				this.o = 0;
				this.maxob.y = 10000;
				GameScreen.maxtr.y = 10000;
				while (this.pz < GameScreen.Vecplayers.size() || this.o < LoadMap.mItemMap.size())
				{
					this.ob = this.maxob;
					GameScreen.tr = GameScreen.maxtr;
					if (this.pz < GameScreen.Vecplayers.size())
					{
						this.ob = (MainObject)GameScreen.Vecplayers.elementAt(this.pz);
					}
					if (this.o < LoadMap.mItemMap.size())
					{
						GameScreen.tr = (MainItemMap)LoadMap.mItemMap.elementAt(this.o);
					}
					if (GameScreen.tr == null || this.ob.y + this.ob.ysai < GameScreen.tr.y + LoadMap.wTile)
					{
						if (MainObject.isInScreen(this.ob) && !this.ob.isStop && !this.ob.isRemove)
						{
							this.ob.paint(g);
							if (this.ob.chat != null && this.ob.chat.strChat != null)
							{
								this.ob.chat.paint(g);
							}
						}
						this.pz++;
						if (GameScreen.tr == null)
						{
							this.o++;
						}
					}
					else
					{
						if (GameScreen.tr.isInScreen() && GameScreen.tr != null)
						{
							GameScreen.tr.paint(g);
						}
						this.o++;
					}
				}
			}
			catch (Exception ex)
			{
				mSystem.outloi("loi gameScreen paint Doi tuong");
			}
			for (int m = 0; m < GameScreen.arrowsUp.size(); m++)
			{
				IArrow arrow = (IArrow)GameScreen.arrowsUp.elementAt(m);
				if (arrow != null)
				{
					arrow.paint(g);
				}
			}
			for (int n = 0; n < GameScreen.vecDataeff.size(); n++)
			{
				DataSkillEff dataSkillEff2 = (DataSkillEff)GameScreen.vecDataeff.elementAt(n);
				if (dataSkillEff2 != null)
				{
					dataSkillEff2.paintBottom(g, (int)dataSkillEff2.x, (int)dataSkillEff2.y);
				}
			}
			this.paintMonsterEffect(g);
			for (int num = 0; num < GameScreen.vecDataeff.size(); num++)
			{
				DataSkillEff dataSkillEff3 = (DataSkillEff)GameScreen.vecDataeff.elementAt(num);
				if (dataSkillEff3 != null)
				{
					dataSkillEff3.paintBottom(g, (int)dataSkillEff3.x, (int)dataSkillEff3.y);
				}
			}
			for (int num2 = 0; num2 < LoadMap.vecPointChange.size(); num2++)
			{
				Point point3 = (Point)LoadMap.vecPointChange.elementAt(num2);
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, LoadMap.mTranPointChangeMap[point3.dis], point3.x + GameCanvas.gameTick % 6 * point3.vx, point3.y + GameCanvas.gameTick % 6 * point3.vy, 3, mGraphics.isFalse);
				AvMain.Font3dWhite(g, point3.name, point3.x2 + GameCanvas.gameTick % 6 * point3.vx, point3.y2 + GameCanvas.gameTick % 6 * point3.vy, point3.f);
			}
			if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject != 1)
			{
				GameScreen.ObjFocus.paintNameFocus(g);
			}
			int num3 = GameScreen.VecNum.size();
			EffectManager.hiEffects.paintAll(g);
			if (GameScreen.vecHightEffAuto.size() > 0)
			{
				for (int num4 = 0; num4 < GameScreen.vecHightEffAuto.size(); num4++)
				{
					EffectAuto effectAuto = (EffectAuto)GameScreen.vecHightEffAuto.elementAt(num4);
					if (effectAuto != null)
					{
						effectAuto.paint(g);
					}
				}
			}
			for (int num5 = 0; num5 < num3; num5++)
			{
				MainEffect mainEffect = (MainEffect)GameScreen.VecNum.elementAt(num5);
				if (MainEffect.isInScreen(mainEffect.x, mainEffect.y, 10, 10) && !mainEffect.isRemove && !mainEffect.isStop)
				{
					mainEffect.paint(g);
				}
			}
			for (int num6 = 0; num6 < GameScreen.vecWeather.size(); num6++)
			{
				AnimateEffect animateEffect = (AnimateEffect)GameScreen.vecWeather.elementAt(num6);
				animateEffect.paint(g);
			}
			MainObject.paintFocus(g);
			GameCanvas.resetTrans(g);
			if ((int)GameScreen.timePaintCmdGiaotiep > 0 && this.cmdGiaotiep != null)
			{
				this.cmdGiaotiep.paint(g, this.cmdGiaotiep.xCmd, this.cmdGiaotiep.yCmd);
			}
			if ((!GameCanvas.menu2.isShowMenu || (int)Menu2.isNPCMenu == 2) && (GameCanvas.currentDialog == null || (GameScreen.help.Step == 5 && GameScreen.help.Next < 8) || (GameCanvas.isTouch && (GameScreen.help.Step == 0 || GameScreen.help.Step == 1))) && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game && (PaintInfoGameScreen.isShowInGame || PaintInfoGameScreen.hShowInGame < 100))
			{
				if (GameScreen.player.currentQuest == null)
				{
					if (GameCanvas.isTouch)
					{
						g.translate(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini, 0 - PaintInfoGameScreen.hShowInGame);
					}
					else
					{
						g.translate(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini - 3, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini + PaintInfoGameScreen.hShowInGame);
					}
					if (GameCanvas.isTouch)
					{
						if (!GameScreen.infoGame.isMapThachdau() && !GameScreen.infoGame.isMapchienthanh())
						{
							AvMain.paintDialog(g, GameCanvas.minimap.maxX * MiniMap.wMini - 40, GameCanvas.minimap.maxY * MiniMap.wMini - 19, 40, 35, 1);
							mFont.tahoma_7b_black.drawString(g, T.Area + LoadMap.getAreaPaint(), GameCanvas.minimap.maxX * MiniMap.wMini - 37 + 17, GameCanvas.minimap.maxY * MiniMap.wMini + 3, 2, mGraphics.isFalse);
						}
						string text = string.Empty;
						if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
						{
							GameScreen.infoGame.paintTimeHS(g);
							text = LoadMap.getTimeArena(GameScreen.timeArena);
							if (!text.Equals(string.Empty))
							{
								g.fillRect(GameCanvas.minimap.maxX * MiniMap.wMini - GameCanvas.w / 2 - 18, GameCanvas.minimap.maxY * MiniMap.wMini - 38, 36, 17, 0, 60, mGraphics.isFalse);
								AvMain.Font3dWhite(g, text, GameCanvas.minimap.maxX * MiniMap.wMini - GameCanvas.w / 2, GameCanvas.minimap.maxY * MiniMap.wMini - 35, 2);
							}
						}
						else
						{
							text = LoadMap.getTimeSpecialRegion();
							if (!text.Equals(string.Empty))
							{
								mFont.tahoma_7_white.drawString(g, text, GameCanvas.minimap.maxX * MiniMap.wMini - 42, GameCanvas.minimap.maxY * MiniMap.wMini + 3, 1, mGraphics.isFalse);
							}
						}
					}
					else
					{
						string text2 = string.Empty;
						if (GameCanvas.isSmallScreen)
						{
							mFont.tahoma_7_black.drawString(g, T.Area + LoadMap.getAreaPaint(), 14, -13, 2, mGraphics.isFalse);
							if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
							{
								GameScreen.infoGame.paintTimeHS(g);
								text2 = LoadMap.getTimeArena(GameScreen.timeArena);
								if (!text2.Equals(string.Empty))
								{
									AvMain.Font3dWhite(g, text2, 14, -30, 1);
								}
							}
							else
							{
								text2 = LoadMap.getTimeSpecialRegion();
								if (!text2.Equals(string.Empty))
								{
									mFont.tahoma_7_white.drawString(g, text2, 14, -30, 1, mGraphics.isFalse);
								}
							}
						}
						else
						{
							AvMain.paintDialog(g, GameCanvas.minimap.maxX * MiniMap.wMini - 37, -17, 40, 35, 1);
							mFont.tahoma_7b_black.drawString(g, T.Area + LoadMap.getAreaPaint(), GameCanvas.minimap.maxX * MiniMap.wMini - 34 + 17, -14, 2, mGraphics.isFalse);
							if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
							{
								GameScreen.infoGame.paintTimeHS(g);
								text2 = LoadMap.getTimeArena(GameScreen.timeArena);
								if (!text2.Equals(string.Empty))
								{
									AvMain.Font3dWhite(g, text2, GameCanvas.minimap.maxX * MiniMap.wMini - 39, -14, 1);
								}
							}
							else
							{
								text2 = LoadMap.getTimeSpecialRegion();
								if (!text2.Equals(string.Empty))
								{
									mFont.tahoma_7_white.drawString(g, text2, GameCanvas.minimap.maxX * MiniMap.wMini - 39, -14, 1, mGraphics.isFalse);
								}
							}
						}
					}
					GameCanvas.minimap.paint(g);
					GameCanvas.resetTrans(g);
					GameScreen.infoGame.paintPos_minimap(g, GameCanvas.w, 0);
					if (GameScreen.player != null && !mSystem.isj2me)
					{
						if (GameScreen.player.Action == 4)
						{
							g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, 0, 60, mGraphics.isFalse);
						}
						else if (GameScreen.player.ispaintHit)
						{
							PaintInfoGameScreen.paintHitscr(g, GameScreen.player.isMaxdame);
						}
					}
					GameScreen.infoGame.paintInfoPlayer(g, 0, 0 - PaintInfoGameScreen.hShowInGame, !GameCanvas.isSmallScreen, mFont.tahoma_7_white);
					GameScreen.infoGame.paintInfoThachDau(g, 0, 0 - PaintInfoGameScreen.hShowInGame);
					GameScreen.infoGame.paintInfoThachDauOtherPlayer(g, GameCanvas.w / 2 + 20, 0 - PaintInfoGameScreen.hShowInGame);
					GameScreen.infoGame.paintInfoFocus(g);
					if (!GameCanvas.isTouch && GameScreen.player.Action != 4)
					{
						GameScreen.infoGame.paintKillPlayer(g);
					}
					GameScreen.infoGame.PaintIconPlayer(g);
					if (!GameCanvas.menu2.isShowMenu)
					{
						GameScreen.infoGame.paintPoiterAll(g);
					}
					if (PaintInfoGameScreen.numMess > 0)
					{
						g.drawImage(AvMain.imgMess, PaintInfoGameScreen.xMess, PaintInfoGameScreen.yMess - PaintInfoGameScreen.hShowInGame, 0, mGraphics.isFalse);
						string str = PaintInfoGameScreen.numMess + string.Empty;
						if (PaintInfoGameScreen.numMess > 20)
						{
							str = "20+";
						}
						AvMain.Font3dWhite(g, str, PaintInfoGameScreen.xMess + 17, PaintInfoGameScreen.yMess - 1 - PaintInfoGameScreen.hShowInGame, 0);
					}
				}
				GameCanvas.resetTrans(g);
				if (GameScreen.infoGame.strInfoServer == null && PaintInfoGameScreen.isShowInGame && !GameCanvas.menu2.isShowMenu)
				{
					if (GameCanvas.isTouch)
					{
						base.paintCmd(g);
					}
					else
					{
						base.paintCmd_OnlyText(g);
					}
				}
				if (this.imgCombo != null)
				{
					g.drawImage(this.imgCombo, 5, 46, 0, false);
				}
			}
			GameCanvas.resetTrans(g);
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				if (!GameScreen.isFinishHelp && GameScreen.help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
				{
					GameScreen.help.paintHelpLast(g);
				}
			}
			else if (GameScreen.help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && !ChatTextField.isShow && GameCanvas.subDialog == null && GameCanvas.currentScreen == GameCanvas.game)
			{
				GameScreen.help.paintHelpLast(g);
			}
			GameScreen.infoGame.paintNameMap(g);
			GameScreen.infoGame.paintIconClan(g);
			if ((int)PaintInfoGameScreen.paint18plush == 1 && this.canpaint18plus())
			{
				PaintInfoGameScreen.paintinfo18plush(g);
			}
			for (int num7 = 0; num7 < GameScreen.vecTimecountDown.size(); num7++)
			{
				TimecountDown timecountDown = (TimecountDown)GameScreen.vecTimecountDown.elementAt(num7);
				if (timecountDown != null)
				{
					timecountDown.paint(g);
				}
			}
			GameCanvas.resetTrans(g);
			if (GameScreen.textServer != null && GameScreen.textServer.Length > 0)
			{
				for (int num8 = 0; num8 < GameScreen.textServer.Length; num8++)
				{
					AvMain.Font3dWhite(g, GameScreen.textServer[num8], GameCanvas.w - 10, GameCanvas.minimap.maxY * MiniMap.wMini + 15 + num8 * GameCanvas.hText, 1);
				}
			}
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x060005DE RID: 1502 RVA: 0x00057BA0 File Offset: 0x00055DA0
	public bool canpaint18plus()
	{
		if (GameScreen.idmap18 != null)
		{
			for (int i = 0; i < GameScreen.idmap18.Length; i++)
			{
				if ((int)GameScreen.idmap18[i] == GameCanvas.loadmap.idMap)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x060005DF RID: 1503 RVA: 0x00057BE8 File Offset: 0x00055DE8
	public void checkPaintNamearena()
	{
		if (GameCanvas.gameTick % 50 == 0)
		{
			for (int i = 0; i < GameScreen.Vecplayers.size() - 1; i++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
				mainObject.Namearena = false;
			}
			for (int j = 0; j < GameScreen.Vecplayers.size() - 1; j++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if (mainObject2 != null && (int)mainObject2.typeObject == 0)
				{
					for (int k = j + 1; k < GameScreen.Vecplayers.size(); k++)
					{
						MainObject mainObject3 = (MainObject)GameScreen.Vecplayers.elementAt(k);
						if ((int)mainObject3.typeObject == 0 && mainObject3 != null && CRes.abs(mainObject2.x - mainObject3.x) <= 20 && CRes.abs(mainObject2.y - mainObject3.y) <= 20)
						{
							mainObject2.Namearena = true;
							mainObject3.Namearena = true;
						}
					}
				}
			}
		}
	}

	// Token: 0x060005E0 RID: 1504 RVA: 0x00057D04 File Offset: 0x00055F04
	public override void update()
	{
		try
		{
			for (int i = 0; i < GameScreen.vecDataeff.size(); i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)GameScreen.vecDataeff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.update();
					if (dataSkillEff.wantDetroy)
					{
						GameScreen.vecDataeff.removeElement(dataSkillEff);
						i--;
					}
				}
			}
			for (int j = 0; j < GameScreen.vecEffInMap.size(); j++)
			{
				Point point = (Point)GameScreen.vecEffInMap.elementAt(j);
				point.updateInMap();
				if (point.isRemove)
				{
					GameScreen.vecEffInMap.removeElement(point);
					j--;
				}
			}
			for (int k = 0; k < GameScreen.vecTimecountDown.size(); k++)
			{
				TimecountDown timecountDown = (TimecountDown)GameScreen.vecTimecountDown.elementAt(k);
				timecountDown.update();
				if (timecountDown.wantdestroy)
				{
					GameScreen.vecTimecountDown.removeElement(timecountDown);
				}
			}
			for (int l = 0; l < GameScreen.vecStep.size(); l++)
			{
				Point point2 = (Point)GameScreen.vecStep.elementAt(l);
				point2.updateInMap();
				if (point2.isRemove)
				{
					GameScreen.vecStep.removeElement(point2);
					l--;
				}
			}
			for (int m = 0; m < LoadMap.Thacnuoc.size(); m++)
			{
				ThacNuoc thacNuoc = (ThacNuoc)LoadMap.Thacnuoc.elementAt(m);
				thacNuoc.update();
			}
			if (GameScreen.help.Step >= 0)
			{
				GameScreen.help.updateHelp();
			}
			if (Player.timeFocus > 0)
			{
				Player.timeFocus--;
			}
			if (GameCanvas.mapBack != null)
			{
				GameCanvas.mapBack.updateCloud();
			}
			for (int n = 0; n < LoadMap.mItemMap.size(); n++)
			{
				MainItemMap mainItemMap = (MainItemMap)LoadMap.mItemMap.elementAt(n);
				if ((int)mainItemMap.TypeItem == 1)
				{
					mainItemMap.update();
				}
			}
			for (int num = 0; num < GameScreen.Vecplayers.size(); num++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(num);
				if (mainObject.isStop && !mainObject.isRemove)
				{
					mainObject.timeStop++;
					if (mainObject.timeStop >= 5)
					{
						mainObject.isRemove = true;
					}
				}
				else if (mainObject == null || mainObject.isRemove)
				{
					GameScreen.Vecplayers.removeElementAt(num);
					num--;
				}
				else
				{
					mainObject.update();
					mainObject.ySort = mainObject.y + mainObject.ysai;
				}
			}
			for (int num2 = GameScreen.arrowsUp.size() - 1; num2 >= 0; num2--)
			{
				IArrow arrow = (IArrow)GameScreen.arrowsUp.elementAt(num2);
				arrow.update();
				if (arrow.wantDestroy)
				{
					GameScreen.arrowsUp.removeElementAt(num2);
				}
			}
			CRes.quickSort(GameScreen.Vecplayers);
			this.checkPaintNamearena();
			for (int num3 = 0; num3 < GameScreen.VecNum.size(); num3++)
			{
				MainEffect mainEffect = (MainEffect)GameScreen.VecNum.elementAt(num3);
				if (mainEffect == null || mainEffect.isRemove)
				{
					GameScreen.VecNum.removeElement(mainEffect);
					num3--;
				}
				else if (!mainEffect.isStop)
				{
					mainEffect.update();
				}
			}
			if ((int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END)
			{
				MainScreen.cameraMain.moveCamera(MainScreen.cameraMain.xLimit / 2, MainScreen.cameraMain.yLimit / 2);
			}
			else if (GameScreen.player.currentQuest == null)
			{
				if (GameScreen.isMoveCamera)
				{
					MainScreen.cameraMain.setCameraWithLim(GameScreen.xCur - GameScreen.xMoveCam, GameScreen.yCur - GameScreen.yMoveCam);
				}
				else
				{
					MainScreen.cameraMain.moveCamera(GameScreen.player.x - GameCanvas.hw, GameScreen.player.y - GameCanvas.hh);
				}
			}
			else
			{
				MainObject mainObject2 = MainObject.get_Object(GameScreen.player.currentQuest.idNPCChat, 2);
				if (mainObject2 != null)
				{
					MainScreen.cameraMain.moveCamera(GameScreen.player.x - GameCanvas.hw, mainObject2.y - GameCanvas.hh - GameCanvas.hh / 4);
				}
				else
				{
					MainScreen.cameraMain.moveCamera(GameScreen.player.x - GameCanvas.hw, GameScreen.player.y - GameCanvas.hh);
				}
			}
			MainScreen.cameraMain.UpdateCamera();
			GameCanvas.minimap.miniCamera.moveCamera((GameScreen.player.x / LoadMap.wTile - GameCanvas.minimap.maxX / 2) * MiniMap.wMini, (GameScreen.player.y / LoadMap.wTile - GameCanvas.minimap.maxY / 2) * MiniMap.wMini);
			GameCanvas.minimap.miniCamera.UpdateCamera();
			bool flag = false;
			for (int num4 = 0; num4 < GameScreen.vecWeather.size(); num4++)
			{
				flag = true;
				AnimateEffect animateEffect = (AnimateEffect)GameScreen.vecWeather.elementAt(num4);
				animateEffect.update();
				if ((int)animateEffect.type == 4)
				{
					if (animateEffect.isStop)
					{
						GameScreen.vecWeather.removeElement(animateEffect);
						num4--;
					}
				}
				else if ((int)animateEffect.type == 5)
				{
					if (animateEffect.isStop && animateEffect.list.size() == 0)
					{
						GameScreen.vecWeather.removeElement(animateEffect);
						num4--;
					}
				}
				else if (animateEffect.list.size() == 0)
				{
					GameScreen.vecWeather.removeElement(animateEffect);
					num4--;
				}
			}
			if (flag)
			{
				AnimateEffect.updateWind();
			}
			if (GameCanvas.gameTick % 200 == 0)
			{
				ImageEffect.SetRemove();
				ImageEffectAuto.SetRemove();
				DataSkillEff.SetRemove();
				CRes.setRemoveCharPartInfo();
				GameData.SetRemove();
				MainObject.SetRemove();
				EffectAuto.SetRemove();
			}
			if (GameScreen.ObjFocus != null && GameScreen.ObjFocus.isRemove)
			{
				GameScreen.ObjFocus = null;
			}
			if (Player.autoItem != null && Player.autoItem.isremove)
			{
				Player.autoItem = null;
				MainRMS.setSaveAuto();
			}
			if ((int)GameScreen.timePaintCmdGiaotiep > 0)
			{
				if (this.cmdGiaotiep != null)
				{
					MainObject mainObject3 = MainObject.get_Object(this.cmdGiaotiep.IdGiaotiep, 0);
					if (mainObject3 == null)
					{
						GameScreen.timePaintCmdGiaotiep = 0;
					}
					else
					{
						this.cmdGiaotiep.setPosXY(mainObject3.x - MainScreen.cameraMain.xCam, mainObject3.y - MainScreen.cameraMain.yCam - mainObject3.hOne - 30);
					}
				}
				GameScreen.timePaintCmdGiaotiep -= 1;
			}
			if (!GameCanvas.isTouch && (GameCanvas.timeNow - GameScreen.timeCheckDelHash) / 1000L > 300L)
			{
				this.checkClear();
			}
			if (GameScreen.demNumSoundEff > 0 && GameCanvas.gameTick % 30 == 0)
			{
				GameScreen.demNumSoundEff--;
			}
			EffectManager.hiEffects.updateAll();
			EffectManager.lowEffects.updateAll();
			if (GameScreen.vecHightEffAuto.size() > 0)
			{
				for (int num5 = 0; num5 < GameScreen.vecHightEffAuto.size(); num5++)
				{
					EffectAuto effectAuto = (EffectAuto)GameScreen.vecHightEffAuto.elementAt(num5);
					if (effectAuto.wantdestroy)
					{
						GameScreen.vecHightEffAuto.removeElement(effectAuto);
					}
					if (effectAuto != null)
					{
						effectAuto.update();
					}
				}
			}
			GameScreen.infoGame.countTimeHS();
			for (int num6 = 0; num6 < EffectMonster.listEffectMonster.size(); num6++)
			{
				EffectMonster effectMonster = (EffectMonster)EffectMonster.listEffectMonster.elementAt(num6);
				effectMonster.update();
			}
		}
		catch (Exception ex)
		{
			mSystem.println("----loi update gamescr:" + ex.ToString());
		}
	}

	// Token: 0x060005E1 RID: 1505 RVA: 0x00058560 File Offset: 0x00056760
	public void checkClear()
	{
		GameScreen.timeCheckDelHash = GameCanvas.timeNow;
		ObjectData.checkDelHash(MainMonster.HashImageMonster);
		ObjectData.checkDelHash(GameScreen.HashImageItemMap);
		ObjectData.checkDelHash(Item.HashImageIconClan);
	}

	// Token: 0x060005E2 RID: 1506 RVA: 0x00058598 File Offset: 0x00056798
	public override void updatekey()
	{
		if (!Player.isLockKey)
		{
			base.updatekey();
		}
		if (GameScreen.player != null)
		{
			GameScreen.player.updateKey();
		}
	}

	// Token: 0x060005E3 RID: 1507 RVA: 0x000585CC File Offset: 0x000567CC
	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			if ((int)GameScreen.timePaintCmdGiaotiep > 0 && this.cmdGiaotiep != null)
			{
				this.cmdGiaotiep.updatePointer();
			}
			base.updatePointer();
			GameScreen.infoGame.updatePoiterAll();
		}
	}

	// Token: 0x060005E4 RID: 1508 RVA: 0x00058618 File Offset: 0x00056818
	public void doMenu()
	{
		if (GameScreen.player.Action == 1)
		{
			GameScreen.player.resetMove();
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
		}
		mVector mVector = new mVector("GameScr menu2");
		mVector.addElement(this.cmdMyseft);
		mVector.addElement(this.cmdChucNang);
		if (Player.party != null)
		{
			mVector.addElement(this.cmdParty);
		}
		if ((int)GameScreen.player.typePk == 0 || (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typePk == 0))
		{
			mVector.addElement(this.cmdGiaotiep);
		}
		mVector.addElement(this.cmdChangeMap);
		GameCanvas.menu2.startAt(mVector, 2, T.menuChinh, false, null);
		if (GameScreen.help.setStep_Next(1, 9) || GameScreen.help.setStep_Next(6, 2))
		{
			Menu2.isHelp = true;
		}
		GameScreen.player.resetAction();
	}

	// Token: 0x060005E5 RID: 1509 RVA: 0x00058718 File Offset: 0x00056918
	public void doMenuUseNgua(mVector vec)
	{
		this.menuNgua = new mVector("GameScr menungua2");
		this.menuNgua = vec;
		mVector mVector = new mVector("GameScr newvec");
		for (int i = 0; i < vec.size(); i++)
		{
			MainItem mainItem = (MainItem)vec.elementAt(i);
			if (mainItem != null)
			{
				string itemName = mainItem.itemName;
				iCommand iCommand = new iCommand(itemName, 26, i, this);
				mVector.addElement(iCommand);
				GameCanvas.menu2.startAt(mVector, 2, T.TuseNgua, false, null);
			}
		}
	}

	// Token: 0x060005E6 RID: 1510 RVA: 0x000587A0 File Offset: 0x000569A0
	public void doMenuAuto()
	{
		mVector mVector = new mVector("GameScr menu3");
		if ((int)Player.isAutoFire > -1)
		{
			GameScreen.gI().cmdAutoFire.caption = T.off + T.autoFire;
		}
		else
		{
			GameScreen.gI().cmdAutoFire.caption = T.on + T.autoFire;
		}
		mVector.addElement(GameScreen.gI().cmdAutoFire);
		if (Player.autoItem != null)
		{
			GameScreen.gI().cmdAutoItem.caption = T.off + T.autoItem;
		}
		else
		{
			GameScreen.gI().cmdAutoItem.caption = T.on + T.autoItem;
		}
		mVector.addElement(GameScreen.gI().cmdAutoItem);
		if (Player.isAutoHPMP)
		{
			GameScreen.gI().cmdAutoMPHP.caption = T.off + T.autoHP;
		}
		else
		{
			GameScreen.gI().cmdAutoMPHP.caption = T.on + T.autoHP;
		}
		mVector.addElement(GameScreen.gI().cmdAutoMPHP);
		mVector.addElement(GameScreen.gI().cmdAutoBuff);
		this.cmdShowAuto.caption = T.on + T.showAuto;
		if (PaintInfoGameScreen.isShowInfoAuto)
		{
			this.cmdShowAuto.caption = T.off + T.showAuto;
		}
		mVector.addElement(GameScreen.gI().cmdShowAuto);
		GameCanvas.menu2.startAt(mVector, 2, T.auto, false, null);
	}

	// Token: 0x060005E7 RID: 1511 RVA: 0x0005893C File Offset: 0x00056B3C
	public static void addEffectKill(int type, int idFrom, sbyte temFrom, mVector vec)
	{
		Object_Effect_Skill objfire = new Object_Effect_Skill((short)idFrom, temFrom);
		if (mSystem.isj2me && GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
		{
			if (idFrom != GameScreen.player.ID)
			{
				if ((int)EffectSkill.countSkillArena <= 3)
				{
					EffectSkill.countSkillArena += 1;
				}
			}
			GameScreen.StartAddEffectSkill(type, objfire, vec);
		}
		else
		{
			GameScreen.StartAddEffectSkill(type, objfire, vec);
		}
	}

	// Token: 0x060005E8 RID: 1512 RVA: 0x000589C8 File Offset: 0x00056BC8
	public static void StartAddEffectSkill(int type, Object_Effect_Skill objfire, mVector vec)
	{
		if (type == 119)
		{
			EffectSkill eff = new EffectSkill(114, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff);
			EffectSkill eff2 = new EffectSkill(115, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff2);
		}
		else if (type == 118)
		{
			EffectSkill eff3 = new EffectSkill(65, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff3);
			mVector mVector = new mVector();
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				if (object_Effect_Skill != null)
				{
					mVector.addElement(object_Effect_Skill);
					EffectSkill eff4 = new EffectSkill(62, objfire, mVector, 0);
					GameScreen.addEffect2Vector(eff4);
					mVector.removeAllElements();
				}
			}
		}
		else if (type == 117)
		{
			EffectSkill eff5 = new EffectSkill(20, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff5);
			EffectSkill eff6 = new EffectSkill(91, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff6);
		}
		else if (type == 116)
		{
			EffectSkill eff7 = new EffectSkill(53, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff7);
			EffectSkill eff8 = new EffectSkill(77, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff8);
		}
		else if (type == 123)
		{
			EffectSkill eff9 = new EffectSkill(60, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff9);
			mVector mVector2 = new mVector();
			for (int j = 0; j < vec.size(); j++)
			{
				Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)vec.elementAt(j);
				if (object_Effect_Skill2 != null)
				{
					mVector2.addElement(object_Effect_Skill2);
					EffectSkill eff10 = new EffectSkill(49, objfire, mVector2, 0);
					GameScreen.addEffect2Vector(eff10);
					mVector2.removeAllElements();
				}
			}
		}
		else if (type == 122)
		{
			mVector mVector3 = new mVector();
			for (int k = 0; k < vec.size(); k++)
			{
				Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)vec.elementAt(k);
				if (object_Effect_Skill3 != null)
				{
					mVector3.addElement(object_Effect_Skill3);
					EffectSkill eff11 = new EffectSkill(51, objfire, mVector3, 0);
					GameScreen.addEffect2Vector(eff11);
					mVector3.removeAllElements();
				}
			}
			EffectSkill eff12 = new EffectSkill(66, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff12);
		}
		else if (type == 121)
		{
			EffectSkill eff13 = new EffectSkill(34, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff13);
			mVector mVector4 = new mVector();
			for (int l = 0; l < vec.size(); l++)
			{
				Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)vec.elementAt(l);
				if (object_Effect_Skill4 != null)
				{
					mVector4.addElement(object_Effect_Skill4);
					EffectSkill eff14 = new EffectSkill(55, objfire, mVector4, 0);
					GameScreen.addEffect2Vector(eff14);
					mVector4.removeAllElements();
				}
			}
		}
		else if (type == 120)
		{
			mVector mVector5 = new mVector();
			for (int m = 0; m < vec.size(); m++)
			{
				Object_Effect_Skill object_Effect_Skill5 = (Object_Effect_Skill)vec.elementAt(m);
				if (object_Effect_Skill5 != null)
				{
					mVector5.addElement(object_Effect_Skill5);
					EffectSkill eff15 = new EffectSkill(54, objfire, mVector5, 0);
					GameScreen.addEffect2Vector(eff15);
					mVector5.removeAllElements();
				}
			}
			EffectSkill eff16 = new EffectSkill(11, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff16);
		}
		else if (GameScreen.infoGame.isMapchienthanh() || GameScreen.infoGame.ismapHouse(GameCanvas.loadmap.idMap))
		{
			if ((int)objfire.ID == GameScreen.player.ID)
			{
				EffectSkill eff17 = new EffectSkill(type, objfire, vec, 0);
				GameScreen.addEffect2Vector(eff17);
			}
			else
			{
				EffectSkill effectSkill = new EffectSkill(type, objfire, vec, 0);
				if (effectSkill.levelPaint == -1)
				{
					if (EffectManager.hiEffects.size() <= 20)
					{
						GameScreen.addEffect2Vector(effectSkill);
					}
				}
				else if (EffectManager.lowEffects.size() <= 20)
				{
					GameScreen.addEffect2Vector(effectSkill);
				}
			}
		}
		else
		{
			EffectSkill eff18 = new EffectSkill(type, objfire, vec, 0);
			GameScreen.addEffect2Vector(eff18);
		}
	}

	// Token: 0x060005E9 RID: 1513 RVA: 0x00058D88 File Offset: 0x00056F88
	public static void addEffectKill(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast)
	{
		mVector mVector = new mVector("GameScr vec3");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector, 0);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005EA RID: 1514 RVA: 0x00058DD4 File Offset: 0x00056FD4
	public static void addEffectKill(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast, sbyte sub)
	{
		mVector mVector = new mVector("GameScr vec");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector, (int)sub);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005EB RID: 1515 RVA: 0x00058E24 File Offset: 0x00057024
	public static void addEffectKill(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		if (!EffectSkill.isMultiTarget(type))
		{
			EffectSkill eff = new EffectSkill(type, objkill, vec, (int)sub);
			GameScreen.addEffect2Vector(eff);
		}
		else
		{
			for (int i = 0; i < vec.size(); i++)
			{
				mVector mVector = new mVector("GameScr vector");
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				mVector.addElement(object_Effect_Skill);
				EffectSkill eff2 = new EffectSkill(type, objkill, mVector, (int)sub);
				GameScreen.addEffect2Vector(eff2);
			}
		}
	}

	// Token: 0x060005EC RID: 1516 RVA: 0x00058EA8 File Offset: 0x000570A8
	public static void StartEffect_Chiemthanh(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub)
	{
		MainObject mainObject = MainObject.get_Object(idFrom, temFrom);
		if (mainObject.x <= 216)
		{
			for (int i = 0; i < 3; i++)
			{
				EffectSkill eff = new EffectSkill(mainObject.x, mainObject.y + 12, mainObject.x + (int)GameScreen.posSkill[0][i], mainObject.y + (int)GameScreen.posSkill[1][i], 0);
				EffectManager.addHiEffect(eff);
			}
		}
		else if (mainObject.x >= 384)
		{
			for (int j = 0; j < 3; j++)
			{
				EffectSkill eff2 = new EffectSkill(mainObject.x, mainObject.y + 12, mainObject.x + (int)GameScreen.posSkill[0][j], mainObject.y + (int)GameScreen.posSkill[1][j], 1);
				EffectManager.addHiEffect(eff2);
			}
		}
	}

	// Token: 0x060005ED RID: 1517 RVA: 0x00058F80 File Offset: 0x00057180
	public static void addEffectKillSubTime(int type, int idFrom, sbyte temFrom, mVector vec, sbyte sub, int time)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		GameScreen.addEffect2Vector(new EffectSkill(type, objkill, vec, (int)sub)
		{
			timeRemove = time
		});
	}

	// Token: 0x060005EE RID: 1518 RVA: 0x00058FB0 File Offset: 0x000571B0
	public static void addEffectKillSubTime(int type, int idFrom, sbyte temFrom, int idTo, sbyte temTo, int hpshow, int hplast, sbyte sub, int time)
	{
		mVector mVector = new mVector("GameScr vec2");
		Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill((short)idTo, temTo);
		object_Effect_Skill.setHP(hpshow, hplast);
		mVector.addElement(object_Effect_Skill);
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		EffectSkill eff = new EffectSkill(type, objkill, mVector, (int)sub);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005EF RID: 1519 RVA: 0x00059000 File Offset: 0x00057200
	public static MainItemMap addEffectAuto(string key, string value)
	{
		return new EffectAuto(key, value);
	}

	// Token: 0x060005F0 RID: 1520 RVA: 0x00059018 File Offset: 0x00057218
	public static void addEffectKillTime(int type, int idFrom, sbyte temFrom, mVector vec, int timeRemove, int subType)
	{
		Object_Effect_Skill objkill = new Object_Effect_Skill((short)idFrom, temFrom);
		GameScreen.addEffect2Vector(new EffectSkill(type, objkill, vec, subType)
		{
			timeRemove = timeRemove
		});
	}

	// Token: 0x060005F1 RID: 1521 RVA: 0x00059048 File Offset: 0x00057248
	public static void addEffect2Vector(MainEffect eff)
	{
		if (eff.levelPaint != -1)
		{
			EffectManager.addHiEffect(eff);
		}
		else
		{
			EffectManager.addLowEffect(eff);
		}
	}

	// Token: 0x060005F2 RID: 1522 RVA: 0x00059068 File Offset: 0x00057268
	public static void addEffectEndKill(int type, int x, int y)
	{
		EffectEnd eff = new EffectEnd(type, x, y);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005F3 RID: 1523 RVA: 0x00059084 File Offset: 0x00057284
	public static void addEffectEndFromSv(int type, int id, int x, int y)
	{
		EffectEnd eff = new EffectEnd(type, id, x, y);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005F4 RID: 1524 RVA: 0x000590A4 File Offset: 0x000572A4
	public static void addEffectEndKill_Direction(int type, int x, int y, int direction, sbyte levelPaint)
	{
		EffectEnd eff = new EffectEnd(type, x, y, direction, levelPaint);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005F5 RID: 1525 RVA: 0x000590C4 File Offset: 0x000572C4
	public static void addEffectEndKill_Time(int type, int x, int y, long timeRemove)
	{
		EffectEnd eff = new EffectEnd(type, x, y, timeRemove);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005F6 RID: 1526 RVA: 0x000590E4 File Offset: 0x000572E4
	public static void addEffectKill(int type, int x, int y, int time, short id, sbyte tem)
	{
		EffectSkill eff = new EffectSkill(type, x, y, time, id, tem);
		GameScreen.addEffect2Vector(eff);
	}

	// Token: 0x060005F7 RID: 1527 RVA: 0x00059108 File Offset: 0x00057308
	public static void addEffectNew(int type, int x, int y, int time, short id, sbyte tem, short idFrom, sbyte temFrom, bool addLow)
	{
		EffectSkill effectSkill = new EffectSkill(type, x, y, time, id, tem);
		effectSkill.setObjFrom(idFrom, temFrom);
		if (addLow)
		{
			EffectManager.addLowEffect(effectSkill);
		}
		else
		{
			EffectManager.addHiEffect(effectSkill);
		}
	}

	// Token: 0x060005F8 RID: 1528 RVA: 0x00059148 File Offset: 0x00057348
	public static void addEffectNum(string content, int x, int y, int typeColor, int idFrom)
	{
		if (GameScreen.infoGame.isMapchienthanh() && idFrom != GameScreen.player.ID)
		{
			return;
		}
		EffectNum obj = new EffectNum(content, x, y, typeColor);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(obj);
		}
		else
		{
			GameScreen.VecNum.setElementAt(obj, num);
		}
	}

	// Token: 0x060005F9 RID: 1529 RVA: 0x000591B8 File Offset: 0x000573B8
	public static void addEffectNum(string content, int x, int y, int typeColor)
	{
		EffectNum obj = new EffectNum(content, x, y, typeColor);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(obj);
		}
		else
		{
			GameScreen.VecNum.setElementAt(obj, num);
		}
	}

	// Token: 0x060005FA RID: 1530 RVA: 0x00059208 File Offset: 0x00057408
	public static void addEffectNum(string content, int x, int y, int typeColor, int sub, int idFrom)
	{
		if (GameScreen.infoGame.isMapchienthanh() && idFrom != GameScreen.player.ID)
		{
			return;
		}
		EffectNum obj = new EffectNum(content, x, y, typeColor, sub);
		int num = GameScreen.find_Index_Stop(GameScreen.VecNum);
		if (num == GameScreen.VecNum.size())
		{
			GameScreen.VecNum.addElement(obj);
		}
		else
		{
			GameScreen.VecNum.setElementAt(obj, num);
		}
	}

	// Token: 0x060005FB RID: 1531 RVA: 0x0005927C File Offset: 0x0005747C
	public static void addPlayer(MainObject obj)
	{
		GameScreen.Vecplayers.addElement(obj);
	}

	// Token: 0x060005FC RID: 1532 RVA: 0x0005928C File Offset: 0x0005748C
	public short[] updateFindRoad(int xF, int yF, int xTo, int yTo, int maxSize)
	{
		if (MainObject.getDistance(xF * LoadMap.wTile, yF * LoadMap.wTile, xTo * LoadMap.wTile, yTo * LoadMap.wTile) <= LoadMap.wTile)
		{
			return null;
		}
		this.xStart = (int)((sbyte)this.cmxMini);
		this.yStart = (int)((sbyte)this.cmyMini);
		xF -= this.xStart;
		yF -= this.yStart;
		xTo -= this.xStart;
		yTo -= this.yStart;
		for (int i = 0; i < GameCanvas.loadmap.mapFind.Length; i++)
		{
			for (int j = 0; j < GameCanvas.loadmap.mapFind[i].Length; j++)
			{
				int num = (this.yStart + j) * GameCanvas.loadmap.mapW + (this.xStart + i);
				if (num < GameCanvas.loadmap.mapType.Length - 1)
				{
					if (GameCanvas.loadmap.mapType[num] == 1 || GameCanvas.loadmap.mapType[num] == -1)
					{
						GameCanvas.loadmap.mapFind[i][j] = -1;
					}
					else
					{
						GameCanvas.loadmap.mapFind[i][j] = 0;
					}
				}
			}
		}
		int num2 = xF;
		int num3 = yF;
		short num4 = (short)num2;
		short num5 = (short)num3;
		GameCanvas.loadmap.mapFind[num2][num3] = 1;
		short num6 = 2;
		int num7 = GameCanvas.loadmap.mapFind.Length;
		int num8 = GameCanvas.loadmap.mapFind[0].Length;
		int num9 = 0;
		for (;;)
		{
			num9++;
			if (num9 > 1000)
			{
				break;
			}
			int num10 = -1;
			int num11 = -1;
			if (num2 + 1 < num7 && (int)GameCanvas.loadmap.mapFind[num2 + 1][num3] == 0)
			{
				GameCanvas.loadmap.mapFind[num2 + 1][num3] = (sbyte)num6;
				num10 = num2 + 1;
				num11 = num3;
			}
			if (num2 - 1 >= 0 && (int)GameCanvas.loadmap.mapFind[num2 - 1][num3] == 0)
			{
				GameCanvas.loadmap.mapFind[num2 - 1][num3] = (sbyte)num6;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2 - 1, num3, xTo, yTo))
					{
						num10 = num2 - 1;
						num11 = num3;
					}
				}
				else
				{
					num10 = num2 - 1;
					num11 = num3;
				}
			}
			if (num3 + 1 < num8 && (int)GameCanvas.loadmap.mapFind[num2][num3 + 1] == 0)
			{
				GameCanvas.loadmap.mapFind[num2][num3 + 1] = (sbyte)num6;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2, num3 + 1, xTo, yTo))
					{
						num10 = num2;
						num11 = num3 + 1;
					}
				}
				else
				{
					num10 = num2;
					num11 = num3 + 1;
				}
			}
			if (num3 - 1 >= 0 && (int)GameCanvas.loadmap.mapFind[num2][num3 - 1] == 0)
			{
				GameCanvas.loadmap.mapFind[num2][num3 - 1] = (sbyte)num6;
				if (num10 != -1)
				{
					if (CRes.setDis(num10, num11, xTo, yTo) > CRes.setDis(num2, num3 - 1, xTo, yTo))
					{
						num10 = num2;
						num11 = num3 - 1;
					}
				}
				else
				{
					num10 = num2;
					num11 = num3 - 1;
				}
			}
			int num12 = -1;
			if (num10 != -1)
			{
				num12 = 0;
				num2 = num10;
				num3 = num11;
			}
			else
			{
				num3 = (num2 = 1000);
			}
			short num13 = 0;
			while ((int)num13 < num7)
			{
				short num14 = 0;
				while ((int)num14 < num8)
				{
					if ((int)GameCanvas.loadmap.mapFind[(int)num13][(int)num14] > 1 && this.setContinue((int)num13, (int)num14, GameCanvas.loadmap.mapFind) && (int)GameCanvas.loadmap.mapFind[(int)num13][(int)num14] + CRes.setDis((int)num13, (int)num14, xTo, yTo) < (int)num6 + CRes.setDis(num2, num3, xTo, yTo))
					{
						num2 = (int)num13;
						num3 = (int)num14;
						num6 = (short)GameCanvas.loadmap.mapFind[(int)num13][(int)num14];
						num12 = 0;
					}
					num14 += 1;
				}
				num13 += 1;
			}
			if (num2 == xTo && num3 == yTo)
			{
				goto Block_28;
			}
			if (num12 != 0)
			{
				goto IL_444;
			}
			num6 += 1;
			if ((int)num6 > maxSize)
			{
				goto Block_30;
			}
		}
		return new short[maxSize + 1];
		Block_28:
		if (num6 >= 127)
		{
			return new short[maxSize + 1];
		}
		int num15 = 0;
		short[] array = new short[(int)num6];
		for (;;)
		{
			array[num15] = (short)((num2 << 8) + num3);
			if (num2 + 1 < num7 && (int)GameCanvas.loadmap.mapFind[num2 + 1][num3] == (int)GameCanvas.loadmap.mapFind[num2][num3] - 1)
			{
				num2 = (int)((short)(num2 + 1));
			}
			else if (num2 - 1 >= 0 && (int)GameCanvas.loadmap.mapFind[num2 - 1][num3] == (int)GameCanvas.loadmap.mapFind[num2][num3] - 1)
			{
				num2 = (int)((short)(num2 - 1));
			}
			else if (num3 + 1 < num8 && (int)GameCanvas.loadmap.mapFind[num2][num3 + 1] == (int)GameCanvas.loadmap.mapFind[num2][num3] - 1)
			{
				num3 = (int)((short)(num3 + 1));
			}
			else if (num3 - 1 >= 0 && (int)GameCanvas.loadmap.mapFind[num2][num3 - 1] == (int)GameCanvas.loadmap.mapFind[num2][num3] - 1)
			{
				num3 = (int)((short)(num3 - 1));
			}
			if (num2 == (int)num4 && num3 == (int)num5)
			{
				break;
			}
			num15++;
		}
		array[(int)(num6 - 1)] = (short)((xF << 8) + yF);
		return array;
		Block_30:
		return new short[(int)num6];
		IL_444:
		return new short[maxSize + 1];
	}

	// Token: 0x060005FD RID: 1533 RVA: 0x00059850 File Offset: 0x00057A50
	private bool setContinue(int i, int j, sbyte[][] mapFind)
	{
		return (i + 1 < mapFind.Length && (int)mapFind[i + 1][j] == 0) || (i - 1 >= 0 && (int)mapFind[i - 1][j] == 0) || (j + 1 < mapFind[i].Length && (int)mapFind[i][j + 1] == 0) || (j - 1 >= 0 && (int)mapFind[i][j - 1] == 0);
	}

	// Token: 0x060005FE RID: 1534 RVA: 0x000598C4 File Offset: 0x00057AC4
	public static int find_Index_Stop(mVector vec)
	{
		int result = vec.size();
		for (int i = 0; i < vec.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)vec.elementAt(i);
			if (mainEffect.isStop && !mainEffect.isRemove)
			{
				return i;
			}
		}
		return result;
	}

	// Token: 0x060005FF RID: 1535 RVA: 0x00059918 File Offset: 0x00057B18
	public static void Remove_ChangeMap()
	{
		LoadMap.mItemMap.removeAllElements();
		GameScreen.vecDataeff.removeAllElements();
		GameScreen.vecStep.removeAllElements();
	}

	// Token: 0x06000600 RID: 1536 RVA: 0x00059938 File Offset: 0x00057B38
	public static void Remove_ChangeArea()
	{
	}

	// Token: 0x06000601 RID: 1537 RVA: 0x0005993C File Offset: 0x00057B3C
	public static void RemoveLoadMap()
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != GameScreen.player && mainObject != GameScreen.pet)
			{
				mainObject.isRemove = true;
				mainObject.isBinded = false;
				mainObject.isDongBang = false;
				mainObject.isSleep = false;
				mainObject.isStun = false;
				mainObject.isMoveOut = false;
				mainObject.isno = false;
				mainObject.isnoBoss84 = false;
			}
		}
		GameScreen.vecDataeff.removeAllElements();
		GameScreen.VecNum.removeAllElements();
		GameScreen.vecStep.removeAllElements();
		EffectManager.hiEffects.reMoveAll();
		EffectManager.lowEffects.reMoveAll();
		GameScreen.player.effAuto = null;
		MiniMap.vecNPC_Map.removeAllElements();
		GameScreen.vecHightEffAuto.removeAllElements();
		GameScreen.player.isBinded = false;
		GameScreen.player.isSleep = false;
		GameScreen.player.isStun = false;
		GameScreen.player.isDongBang = false;
		GameScreen.player.isMoveOut = false;
		GameScreen.player.isno = false;
		GameScreen.player.isnoBoss84 = false;
		ItemMap.isPaintDieHouseArena = false;
	}

	// Token: 0x06000602 RID: 1538 RVA: 0x00059A68 File Offset: 0x00057C68
	public static bool isWater(int x, int y)
	{
		return GameCanvas.loadmap.getTile(x, y) == 2;
	}

	// Token: 0x06000603 RID: 1539 RVA: 0x00059A7C File Offset: 0x00057C7C
	public static void AddEffWeather(sbyte type, bool isSt, int num, int time)
	{
		AnimateEffect animateEffect = new AnimateEffect(type, isSt, num, time);
		GameScreen.vecWeather.addElement(animateEffect);
	}

	// Token: 0x06000604 RID: 1540 RVA: 0x00059AA0 File Offset: 0x00057CA0
	public static bool setIsInScreen(int x, int y)
	{
		return x >= MainScreen.cameraMain.xCam && x <= MainScreen.cameraMain.xCam + GameCanvas.w && y >= MainScreen.cameraMain.yCam && y <= MainScreen.cameraMain.yCam + GameCanvas.h;
	}

	// Token: 0x06000605 RID: 1541 RVA: 0x00059AFC File Offset: 0x00057CFC
	public static void addSoundEff(int id)
	{
		if (GameScreen.demNumSoundEff <= 3)
		{
			mSound.playSound(id, mSound.volumeSound);
			GameScreen.demNumSoundEff++;
		}
	}

	// Token: 0x06000606 RID: 1542 RVA: 0x00059B2C File Offset: 0x00057D2C
	public static void addEffInMap(int x, int y, int type, int Dir)
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		if (type == 0)
		{
			if ((int)GameScreen.player.typeMount == -1 && GameCanvas.gameTick % 4 == 0)
			{
				mSound.playSound(46, mSound.volumeSound);
			}
		}
		else if (type == 1 && GameCanvas.gameTick % 4 == 0)
		{
			mSound.playSound(51, mSound.volumeSound);
		}
		if (LoadMap.idTile != 3 && LoadMap.idTile != 8)
		{
			return;
		}
		Point point = new Point();
		point.x = x;
		point.y = y;
		point.color = type;
		point.fRe = 40;
		if (point.color == 0)
		{
			point.fRe = CRes.random(28, 43);
			point.maxframe = 1;
			point.isSmall = true;
			point.fSmall = CRes.random(point.fRe / 2 - 5, point.fRe / 2 + 6);
		}
		else if (point.color == 1)
		{
			return;
		}
		if (Dir == 1)
		{
			point.dis = 0;
		}
		else if (Dir == 0)
		{
			point.dis = 3;
		}
		else if (Dir == 2)
		{
			point.dis = 6;
		}
		else if (Dir == 3)
		{
			point.dis = 5;
		}
		if (point.color == 0)
		{
			GameScreen.vecStep.addElement(point);
		}
		else
		{
			GameScreen.vecEffInMap.addElement(point);
		}
	}

	// Token: 0x06000607 RID: 1543 RVA: 0x00059C98 File Offset: 0x00057E98
	public static void checkAddEff(int type, int x, int y, int time, short id, sbyte tem, short idFrom, sbyte temFrom, bool addLow)
	{
		if (addLow)
		{
			for (int i = 0; i < EffectManager.lowEffects.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)EffectManager.lowEffects.elementAt(i);
				if (mainEffect != null && !mainEffect.isRemove)
				{
					if (mainEffect.typeEffect == type && mainEffect.objBeKillMain != null && mainEffect.objBeKillMain.ID == (int)id)
					{
						mainEffect.setTimeRemove((short)time);
						mainEffect.objBeKillMain.vx = 0;
						mainEffect.objBeKillMain.vy = 0;
						mainEffect.objBeKillMain.toX = x;
						mainEffect.objBeKillMain.toY = y;
						if (type == 101)
						{
							mainEffect.objBeKillMain.isSleep = true;
						}
						else if (type == 102)
						{
							mainEffect.objBeKillMain.isStun = true;
						}
						else if (type == 107)
						{
							mainEffect.objBeKillMain.isno = true;
						}
						else if (type == 103)
						{
							mainEffect.objBeKillMain.isnoBoss84 = true;
						}
						else if (type == 100)
						{
							mainEffect.objBeKillMain.isDongBang = true;
						}
						else
						{
							mainEffect.objBeKillMain.isBinded = true;
						}
						return;
					}
				}
			}
			GameScreen.addEffectNew(type, x, y, time, id, tem, idFrom, 1, type != 100);
		}
		else
		{
			for (int j = 0; j < EffectManager.hiEffects.size(); j++)
			{
				MainEffect mainEffect2 = (MainEffect)EffectManager.hiEffects.elementAt(j);
				if (mainEffect2 != null && !mainEffect2.isRemove)
				{
					if (mainEffect2.typeEffect == type && mainEffect2.objBeKillMain != null && mainEffect2.objBeKillMain.ID == (int)id)
					{
						mainEffect2.setTimeRemove((short)time);
						mainEffect2.objBeKillMain.vx = 0;
						mainEffect2.objBeKillMain.vy = 0;
						mainEffect2.objBeKillMain.toX = x;
						mainEffect2.objBeKillMain.toY = y;
						if (type == 101)
						{
							mainEffect2.objBeKillMain.isSleep = true;
						}
						else if (type == 102)
						{
							mainEffect2.objBeKillMain.isStun = true;
						}
						else if (type == 107)
						{
							mainEffect2.objBeKillMain.isno = true;
						}
						else if (type == 103)
						{
							mainEffect2.objBeKillMain.isnoBoss84 = true;
						}
						else
						{
							mainEffect2.objBeKillMain.isBinded = true;
						}
						return;
					}
				}
			}
			GameScreen.addEffectNew(type, x, y, time, id, tem, idFrom, 1, false);
		}
	}

	// Token: 0x06000608 RID: 1544 RVA: 0x00059F24 File Offset: 0x00058124
	public static MainObject findOwner(MainObject owner)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.findOwner(owner))
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x06000609 RID: 1545 RVA: 0x00059F74 File Offset: 0x00058174
	public static MainObject findChar(short id)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && (int)mainObject.typeObject == 0 && mainObject.ID == (int)id)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600060A RID: 1546 RVA: 0x00059FD0 File Offset: 0x000581D0
	public static MainObject findObj(short id)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && mainObject.ID == (int)id)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600060B RID: 1547 RVA: 0x0005A020 File Offset: 0x00058220
	public static void startNewMagicBeam(int type, MainObject from, MainObject to, int x, int y, int power, short effect, int effTail, int effEnd)
	{
		MagicBeam magicBeam = new MagicBeam();
		magicBeam.set(type, x, y, power, effect, from, to);
		magicBeam.setEff(effTail, effEnd);
		GameScreen.arrowsUp.addElement(magicBeam);
	}

	// Token: 0x0600060C RID: 1548 RVA: 0x0005A058 File Offset: 0x00058258
	public static void startNewArrow(int type, MainObject from, MainObject to, int x, int y, int power, sbyte effect, int imgIndex)
	{
		Arrow arrow = new Arrow(imgIndex);
		arrow.set(type, x, y, power, (short)effect, from, to);
		GameScreen.arrowsUp.addElement(arrow);
	}

	// Token: 0x0600060D RID: 1549 RVA: 0x0005A08C File Offset: 0x0005828C
	public static MainObject findMonster(short id)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && (int)mainObject.typeObject == 1 && mainObject.ID == (int)id)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600060E RID: 1550 RVA: 0x0005A0E8 File Offset: 0x000582E8
	public static MainObject findObjByteCat(short id, sbyte cat)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && (int)mainObject.typeObject == (int)cat && mainObject.ID == (int)id)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600060F RID: 1551 RVA: 0x0005A144 File Offset: 0x00058344
	public override bool isGameScr()
	{
		return true;
	}

	// Token: 0x0400084E RID: 2126
	public static int ID_DLG_BUY_KC = -32059;

	// Token: 0x0400084F RID: 2127
	public static Player player = new Player(0, 0, "unname", 0, 0);

	// Token: 0x04000850 RID: 2128
	public static Pet pet = null;

	// Token: 0x04000851 RID: 2129
	public static short[] idmap18;

	// Token: 0x04000852 RID: 2130
	public static mVector vecDataeff = new mVector();

	// Token: 0x04000853 RID: 2131
	public static MainObject ObjFocus = null;

	// Token: 0x04000854 RID: 2132
	public static mVector VecNum = new mVector("GameScr VecNum");

	// Token: 0x04000855 RID: 2133
	public static mVector Vecplayers = new mVector("GameScr Vecplayers");

	// Token: 0x04000856 RID: 2134
	public static mVector VecInfoServer = new mVector("GameScr VecInfoServer");

	// Token: 0x04000857 RID: 2135
	public static mVector VecInfoChar = new mVector("GameScr menu");

	// Token: 0x04000858 RID: 2136
	public static mVector vecEffInMap = new mVector("GameScr vecEffInMap");

	// Token: 0x04000859 RID: 2137
	public static mVector vecStep = new mVector("GameScr vecStep");

	// Token: 0x0400085A RID: 2138
	public static mHashTable HashImageItemMap = new mHashTable();

	// Token: 0x0400085B RID: 2139
	public static mHashTable HashImageNPC = new mHashTable();

	// Token: 0x0400085C RID: 2140
	public static mVector vecWeather = new mVector("GameScr vecWeather");

	// Token: 0x0400085D RID: 2141
	public static MainHelp help = new MainHelp();

	// Token: 0x0400085E RID: 2142
	public static PaintInfoGameScreen infoGame = new PaintInfoGameScreen();

	// Token: 0x0400085F RID: 2143
	public iCommand cmdMenu;

	// Token: 0x04000860 RID: 2144
	public iCommand cmdGiaotiep;

	// Token: 0x04000861 RID: 2145
	public iCommand cmdMyseft;

	// Token: 0x04000862 RID: 2146
	public iCommand cmdAddfriend;

	// Token: 0x04000863 RID: 2147
	public iCommand cmdInfoChar;

	// Token: 0x04000864 RID: 2148
	public iCommand cmdChat;

	// Token: 0x04000865 RID: 2149
	public iCommand cmdMoiParty;

	// Token: 0x04000866 RID: 2150
	public iCommand cmdShowChat;

	// Token: 0x04000867 RID: 2151
	public iCommand cmdNewParty;

	// Token: 0x04000868 RID: 2152
	public iCommand cmdParty;

	// Token: 0x04000869 RID: 2153
	public iCommand cmdBuy_Sell;

	// Token: 0x0400086A RID: 2154
	public iCommand cmdSetWeather;

	// Token: 0x0400086B RID: 2155
	public iCommand cmdChangeMap;

	// Token: 0x0400086C RID: 2156
	public iCommand cmdChucNang;

	// Token: 0x0400086D RID: 2157
	public iCommand cmdListFriend;

	// Token: 0x0400086E RID: 2158
	public iCommand cmdAutoFire;

	// Token: 0x0400086F RID: 2159
	public iCommand cmdSetPk;

	// Token: 0x04000870 RID: 2160
	public iCommand cmdSetDoSat;

	// Token: 0x04000871 RID: 2161
	public iCommand cmdEndHelp;

	// Token: 0x04000872 RID: 2162
	public iCommand cmdAutoItem;

	// Token: 0x04000873 RID: 2163
	public iCommand cmdAutoMPHP;

	// Token: 0x04000874 RID: 2164
	public iCommand cmdThachDau;

	// Token: 0x04000875 RID: 2165
	public iCommand cmdAutoBuff;

	// Token: 0x04000876 RID: 2166
	public iCommand cmdShowAuto;

	// Token: 0x04000877 RID: 2167
	public iCommand cmdAddMemClan;

	// Token: 0x04000878 RID: 2168
	public iCommand cmdQuickChat;

	// Token: 0x04000879 RID: 2169
	public iCommand cmdInfoVantieu;

	// Token: 0x0400087A RID: 2170
	public iCommand cmdplayerStore;

	// Token: 0x0400087B RID: 2171
	public iCommand cmdinfoMiNuong;

	// Token: 0x0400087C RID: 2172
	public static long timeCheckDelHash;

	// Token: 0x0400087D RID: 2173
	public static sbyte timePaintCmdGiaotiep = 0;

	// Token: 0x0400087E RID: 2174
	public static bool isMoveCamera = false;

	// Token: 0x0400087F RID: 2175
	public static int xMoveCam;

	// Token: 0x04000880 RID: 2176
	public static int yMoveCam;

	// Token: 0x04000881 RID: 2177
	public static int xCur;

	// Token: 0x04000882 RID: 2178
	public static int yCur;

	// Token: 0x04000883 RID: 2179
	public static int timeResetCam;

	// Token: 0x04000884 RID: 2180
	public static int demNumSoundEff = 0;

	// Token: 0x04000885 RID: 2181
	public static string nameSpecialRegion = string.Empty;

	// Token: 0x04000886 RID: 2182
	public static long timeSpRegion = 0L;

	// Token: 0x04000887 RID: 2183
	public static long timeArena = -1L;

	// Token: 0x04000888 RID: 2184
	public static mVector vecHightEffAuto = new mVector("Hight EffectAuto");

	// Token: 0x04000889 RID: 2185
	public static bool isInPetArea = false;

	// Token: 0x0400088A RID: 2186
	public static mVector arrowsUp = new mVector();

	// Token: 0x0400088B RID: 2187
	public static mVector vecTimecountDown = new mVector("Time");

	// Token: 0x0400088C RID: 2188
	public static bool isHideOderPlayer = false;

	// Token: 0x0400088D RID: 2189
	public static bool isFinishHelp = false;

	// Token: 0x0400088E RID: 2190
	public static string[] textServer;

	// Token: 0x0400088F RID: 2191
	public static bool isShowHoiSinh = false;

	// Token: 0x04000890 RID: 2192
	public static bool isMapLang = false;

	// Token: 0x04000891 RID: 2193
	public int xRec;

	// Token: 0x04000892 RID: 2194
	public int yRec;

	// Token: 0x04000893 RID: 2195
	public int wRec;

	// Token: 0x04000894 RID: 2196
	public int hRec;

	// Token: 0x04000895 RID: 2197
	public int colorRec;

	// Token: 0x04000896 RID: 2198
	public bool isFullScreen;

	// Token: 0x04000897 RID: 2199
	public mImage imgCombo;

	// Token: 0x04000898 RID: 2200
	public bool isCombo;

	// Token: 0x04000899 RID: 2201
	public static bool isReArea = false;

	// Token: 0x0400089A RID: 2202
	public int pz;

	// Token: 0x0400089B RID: 2203
	public int o;

	// Token: 0x0400089C RID: 2204
	private MainObject ob;

	// Token: 0x0400089D RID: 2205
	private MainObject maxob = new MainObject();

	// Token: 0x0400089E RID: 2206
	public static MainItemMap tr;

	// Token: 0x0400089F RID: 2207
	public static MainItemMap maxtr = new MainItemMap();

	// Token: 0x040008A0 RID: 2208
	public static int dx = 0;

	// Token: 0x040008A1 RID: 2209
	public static int dy = 0;

	// Token: 0x040008A2 RID: 2210
	public static string goiMes = string.Empty;

	// Token: 0x040008A3 RID: 2211
	public mVector menuNgua = new mVector("GameScr menungua");

	// Token: 0x040008A4 RID: 2212
	public static short[][] posSkill = new short[][]
	{
		new short[]
		{
			-72,
			0,
			120
		},
		new short[]
		{
			144,
			192,
			120
		}
	};

	// Token: 0x040008A5 RID: 2213
	private int xStart;

	// Token: 0x040008A6 RID: 2214
	private int yStart;

	// Token: 0x040008A7 RID: 2215
	private int cmxMini;

	// Token: 0x040008A8 RID: 2216
	private int cmyMini;
}
