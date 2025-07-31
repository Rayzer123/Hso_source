using System;

// Token: 0x0200009D RID: 157
public class TabConfig : MainTabNew
{
	// Token: 0x06000795 RID: 1941 RVA: 0x00077F48 File Offset: 0x00076148
	public TabConfig(string name, mVector vec, sbyte type)
	{
		this.typeTab = type;
		this.nameTab = name;
		this.vecConfig = vec;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.w2 = MainTabNew.wblack / 2;
		this.wFocus = MainTabNew.wblack - (int)MainTabNew.wOne5 * 2;
		if (this.wFocus > 130)
		{
			this.wFocus = 130;
		}
		this.hItem = GameCanvas.hCommand;
		if (GameCanvas.isTouch)
		{
			this.hItem = 28;
		}
		this.cmdBack = new iCommand(T.back, -1, this);
		this.cmdSelect = new iCommand(T.select, 0, this);
		this.cmdlogout = new iCommand(T.logout, 4, this);
		TabConfig.cmdKeypad = new iCommand(T.chuyensang, 7, this);
		this.cmdHelp = new iCommand(T.help, 10, this);
		this.cmdSetting = new iCommand(T.auto, 11, this);
		this.cmdChucNang = new iCommand(T.chucnang, 12, this);
		TabConfig.cmdEvent = new iCommand(T.mevent, 13, this);
		TabConfig.cmdShowClan = new iCommand(T.clan, 14, this);
		if (Main.isPC)
		{
			TabConfig.cmdChangeScreen = new iCommand(T.changeScrennSmall, 20, this);
			if (Main.level == 1)
			{
				TabConfig.cmdChangeScreen.caption = T.normalScreen;
			}
			else
			{
				TabConfig.cmdChangeScreen.caption = ((mGraphics.zoomLevel != 1) ? T.changeScrennSmall : T.normalScreen);
			}
		}
		this.cmdShowFullMini = new iCommand(T.minimap, 15, this);
		this.cmdChatWorld = new iCommand(T.textkenhthegioi, 16, this);
		this.cmdDiamond = new iCommand(T.naptien + " " + T.gem + (Main.IphoneVersionApp ? " (Buy gem)" : string.Empty), 19, this);
		this.cmdDiamondIOSVND = new iCommand(T.naptien + " card", 22, this);
		this.cmdDiamondIOS = new iCommand("Buy on the App Store", 23, this);
		TabConfig.cmdXuongNgua = new iCommand(T.textXuongNgua + string.Empty, 37, this);
		if (mSound.isEnableSound)
		{
			this.cmdSoundSetting = new iCommand(T.SetMusic, 36, this);
		}
		this.cmdVongquay = new iCommand(T.annguoichoi, 40, this);
		this.cmdkhac = new iCommand(T.khac, 45, this);
		this.cmdHieuUng = new iCommand(T.tathieuung, 46, this);
		this.init();
		TabConfig.me = this;
	}

	// Token: 0x06000796 RID: 1942 RVA: 0x000782AC File Offset: 0x000764AC
	public void exit()
	{
		GameCanvas.start_Left_Dialog(T.hoithoat, new iCommand(T.yes, 6, this));
	}

	// Token: 0x06000797 RID: 1943 RVA: 0x000782C4 File Offset: 0x000764C4
	public override void init()
	{
		mVector mVector = new mVector("TabConfig mcmdTest");
		if (GameCanvas.isTouch)
		{
			if (GameScreen.help.Step >= 0)
			{
				mVector.addElement(GameScreen.gI().cmdEndHelp);
			}
			mVector.addElement(this.cmdHelp);
			if (GameScreen.player.myClan != null)
			{
				mVector.addElement(TabConfig.cmdShowClan);
			}
			if (Player.party != null)
			{
				mVector.addElement(GameScreen.gI().cmdParty);
			}
			mVector.addElement(this.cmdChatWorld);
			if (mSound.isEnableSound)
			{
				mVector.addElement(this.cmdSoundSetting);
			}
			if (Main.isPC)
			{
				mVector.addElement(TabConfig.cmdChangeScreen);
			}
			if ((int)GameScreen.player.typeMount != -1)
			{
				mVector.addElement(TabConfig.cmdXuongNgua);
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.CONFIG)
		{
			string caption = T.off + " " + T.dosat;
			if ((int)GameScreen.player.typePk != 0)
			{
				caption = T.on + " " + T.dosat;
			}
			GameScreen.gI().cmdSetDoSat.caption = caption;
			mVector.addElement(GameScreen.gI().cmdSetPk);
			mVector.addElement(GameScreen.gI().cmdSetDoSat);
			mVector.addElement(this.cmdSetting);
			if (GameScreen.help.Step >= 0)
			{
				mVector.addElement(GameScreen.gI().cmdEndHelp);
			}
			mVector.addElement(this.cmdHelp);
			if (GameScreen.player.Lv >= 10)
			{
				mVector.addElement(this.cmdDiamond);
			}
			mVector.addElement(this.cmdlogout);
			if (Main.isPC)
			{
				mVector.addElement(TabConfig.cmdChangeScreen);
			}
		}
		else if ((int)this.typeTab == (int)MainTabNew.FUNCTION)
		{
			mVector.addElement(GameScreen.gI().cmdListFriend);
			TabConfig.cmdEvent.caption = T.mevent;
			if (PaintInfoGameScreen.numMess > 0)
			{
				TabConfig.cmdEvent.caption = T.mevent + "*";
			}
			mVector.addElement(TabConfig.cmdEvent);
			if (GameScreen.player.myClan != null)
			{
				mVector.addElement(TabConfig.cmdShowClan);
			}
			if (Player.party != null)
			{
				mVector.addElement(GameScreen.gI().cmdParty);
			}
			mVector.addElement(GameScreen.gI().cmdChangeMap);
			mVector.addElement(this.cmdShowFullMini);
			mVector.addElement(this.cmdChatWorld);
			if ((int)GameScreen.player.typeMount != -1)
			{
				mVector.addElement(TabConfig.cmdXuongNgua);
			}
		}
		mVector.addElement(this.cmdVongquay);
		mVector.addElement(this.cmdkhac);
		mVector.addElement(this.cmdHieuUng);
		this.vecConfig = mVector;
		int num = this.vecConfig.size() * this.hItem - MainTabNew.hblack;
		if (num < 0)
		{
			num = 0;
		}
		this.idSelect = 0;
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdBack;
			this.left = this.cmdSelect;
		}
		else
		{
			this.idSelect = -1;
		}
		this.list = new MainList(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack, this.hItem, this.vecConfig.size(), num, this.idSelect, this.vecConfig);
		MainScreen.cameraSub.setAll(0, num, 0, 0);
		base.init();
	}

	// Token: 0x06000798 RID: 1944 RVA: 0x00078644 File Offset: 0x00076844
	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		this.idSelect = 0;
		base.backTab();
	}

	// Token: 0x06000799 RID: 1945 RVA: 0x00078660 File Offset: 0x00076860
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
			if (this.idSelect > -1)
			{
				iCommand iCommand = (iCommand)this.vecConfig.elementAt(this.idSelect);
				if (iCommand != null)
				{
					if (iCommand.action != null)
					{
						iCommand.action.perform();
					}
					else if (iCommand.Pointer != null)
					{
						iCommand.Pointer.commandPointer((int)iCommand.indexMenu, (int)iCommand.subIndex);
					}
					else
					{
						GameCanvas.currentScreen.commandMenu((int)iCommand.indexMenu, (int)iCommand.subIndex);
					}
				}
			}
			break;
		case 5:
			Main.isExit = true;
			GameScreen.player.resetAction();
			Session_ME.gI().close();
			GameCanvas.login.Show();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 7:
			GameMidlet.destroy();
			break;
		case 8:
			PaintInfoGameScreen.isLevelPoint = !PaintInfoGameScreen.isLevelPoint;
			if (Main.isPC)
			{
				PaintInfoGameScreen.isLevelPoint = true;
			}
			MainRMS.setSaveTouch();
			if (PaintInfoGameScreen.isLevelPoint)
			{
				TabConfig.cmdKeypad.caption = T.chuyensang + T.keypad;
			}
			else
			{
				TabConfig.cmdKeypad.caption = T.chuyensang + T.touch;
			}
			GameCanvas.isPointerSelect = false;
			PaintInfoGameScreen.setPosTouch();
			break;
		case 10:
			GlobalService.gI().set_Pk((sbyte)subIndex);
			break;
		case 11:
			GameCanvas.start_Show_Dialog(T.strhelp, T.help);
			break;
		case 12:
			GameScreen.gI().doMenuAuto();
			break;
		case 14:
			GameCanvas.mevent.init();
			GameCanvas.mevent.Show(GameCanvas.currentScreen);
			break;
		case 15:
			if (GameScreen.player.myClan != null)
			{
				GlobalService.gI().ChucNang_Clan(15, GameScreen.player.myClan.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		case 16:
			MiniMapFull_Screen.gI().Show();
			break;
		case 17:
			this.inputWorld = new InputDialog();
			this.inputWorld.setinfo(T.nhapnoidung, new iCommand(T.chat, 17, this), false, T.textkenhthegioi);
			this.inputWorld.tfInput.isnewTF = true;
			newinput.TYPE_INPUT = 2;
			newinput.input.Select();
			newinput.input.ActivateInputField();
			GameCanvas.currentDialog = this.inputWorld;
			break;
		case 18:
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
				}), new iCommand(T.chat, 18, this));
			}
			break;
		case 19:
			GlobalService.gI().Chat_World(this.textWorld);
			newinput.input.text = string.Empty;
			newinput.TYPE_INPUT = -1;
			newinput.input.DeactivateInputField();
			GameCanvas.end_Dialog();
			break;
		case 20:
			if (!Main.IphoneVersionApp)
			{
				GlobalService.gI().send_cmd_server(-56);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			else
			{
				mVector mVector = new mVector("TabConfig menu");
				mVector.addElement(this.cmdDiamondIOSVND);
				mVector.addElement(this.cmdDiamondIOS);
				GameCanvas.menu2.startAt(mVector, 2, "Kiểu nạp tiền", false, null);
			}
			break;
		case 21:
			GameCanvas.start_Left_Dialog(T.changeSizeScreen, new iCommand(T.select, 21, this));
			break;
		case 22:
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
		case 23:
			GlobalService.gI().send_cmd_server(-56);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 24:
		{
			mVector mVector2 = new mVector("TabConfig menuItem");
			for (int i = 0; i < this.itemID[1].Length; i++)
			{
				iCommand o = new iCommand(this.itemID[1][i], 24 + i, this);
				mVector2.addElement(o);
			}
			GameCanvas.menu2.startAt(mVector2, 2, T.buy + " item", false, null);
			break;
		}
		case 25:
			GameCanvas.start_Left_Dialog(this.itemID[1][0], new iCommand(T.buy, 24 + this.itemID[0].Length, this));
			break;
		case 26:
			GameCanvas.start_Left_Dialog(this.itemID[1][1], new iCommand(T.buy, 25 + this.itemID[0].Length, this));
			break;
		case 27:
			GameCanvas.start_Left_Dialog(this.itemID[1][2], new iCommand(T.buy, 26 + this.itemID[0].Length, this));
			break;
		case 28:
			GameCanvas.start_Left_Dialog(this.itemID[1][3], new iCommand(T.buy, 27 + this.itemID[0].Length, this));
			break;
		case 29:
			GameCanvas.start_Left_Dialog(this.itemID[1][4], new iCommand(T.buy, 28 + this.itemID[0].Length, this));
			break;
		case 30:
			GameCanvas.start_Left_Dialog(this.itemID[1][5], new iCommand(T.buy, 29 + this.itemID[0].Length, this));
			break;
		case 37:
			GameCanvas.start_Volume_Dialog();
			break;
		case 38:
		{
			mVector mVector3 = new mVector("TabConfig vec3");
			mVector3.addElement(new iCommand(T.yes, 38, this));
			mVector3.addElement(new iCommand(T.cancel, 39, this));
			GameCanvas.start_Select_Dialog(T.textHoiXuongNgua, mVector3);
			break;
		}
		case 39:
			GlobalService.gI().useMount(-1);
			this.closeDialog();
			break;
		case 40:
			this.closeDialog();
			break;
		case 41:
			if (!GameScreen.isHideOderPlayer)
			{
				mVector mVector4 = new mVector();
				iCommand o2 = new iCommand(T.yes, 41, this);
				iCommand o3 = new iCommand(T.no, 42, this);
				mVector4.addElement(o2);
				mVector4.addElement(o3);
				GameCanvas.start_Select_Dialog(T.hoiannguoichoi, mVector4);
			}
			else
			{
				mVector mVector5 = new mVector();
				iCommand o4 = new iCommand(T.yes, 43, this);
				iCommand o5 = new iCommand(T.no, 42, this);
				mVector5.addElement(o4);
				mVector5.addElement(o5);
				GameCanvas.start_Select_Dialog(T.hoihienguoichoi, mVector5);
			}
			break;
		case 42:
			GameScreen.isHideOderPlayer = true;
			this.cmdVongquay.caption = T.hiennguoichoi;
			GameCanvas.end_Dialog();
			break;
		case 43:
			GameCanvas.end_Dialog();
			break;
		case 44:
			GameScreen.isHideOderPlayer = false;
			this.cmdVongquay.caption = T.annguoichoi;
			GameCanvas.end_Dialog();
			break;
		case 46:
			GlobalService.gI().request_LotteryItems(5, 0);
			break;
		case 47:
			if ((int)MainObject.hideEff == 0)
			{
				MainObject.hideEff = 1;
				this.cmdHieuUng.caption = T.bathieuung;
			}
			else
			{
				MainObject.hideEff = 0;
				this.cmdHieuUng.caption = T.tathieuung;
			}
			break;
		}
	}

	// Token: 0x0600079A RID: 1946 RVA: 0x00078E88 File Offset: 0x00077088
	public void closeDialog()
	{
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog = null;
		}
		else
		{
			GameCanvas.subDialog = null;
		}
	}

	// Token: 0x0600079B RID: 1947 RVA: 0x00078EA8 File Offset: 0x000770A8
	public override void paint(mGraphics g)
	{
		g.setClip(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack);
		g.translate(0, -this.list.cmx);
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && this.idSelect > -1)
		{
			this.paintFocus(g);
		}
		for (int i = 0; i < this.vecConfig.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecConfig.elementAt(i);
			mFont.tahoma_7b_white.drawString(g, iCommand.caption, this.xBegin + this.w2, this.yBegin + this.hItem / 2 + i * this.hItem - 6, 2, mGraphics.isTrue);
			if (i < this.vecConfig.size() - 1)
			{
				g.setColor(MainTabNew.color[4]);
				g.fillRect(this.xBegin + 8, this.yBegin + (i + 1) * this.hItem - 1, MainTabNew.wblack - 16, 1, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x0600079C RID: 1948 RVA: 0x00078FC4 File Offset: 0x000771C4
	public void paintFocus(mGraphics g)
	{
		g.setColor(MainTabNew.color[5]);
		g.fillRect(this.xBegin + this.w2 - this.wFocus / 2 - 1, this.yBegin + this.idSelect * this.hItem + this.hItem / 2 - 11, this.wFocus + 2, 22, mGraphics.isFalse);
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, this.xBegin + this.w2 - this.wFocus / 2, this.yBegin + this.idSelect * this.hItem + this.hItem / 2 - 10, this.wFocus, 20, 4);
		}
		else
		{
			for (int i = 0; i <= this.wFocus / 24; i++)
			{
				int x = this.xBegin + this.w2 - this.wFocus / 2 + 24 * i;
				if (i == this.wFocus / 24)
				{
					x = this.xBegin + this.w2 + this.wFocus / 2 - 24;
				}
				g.drawRegion(MainTabNew.imgTab[8], 0, 0, 24, 20, 0, x, this.yBegin + this.idSelect * this.hItem + this.hItem / 2 - 10, 0, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x0600079D RID: 1949 RVA: 0x0007911C File Offset: 0x0007731C
	public override void update()
	{
		MainScreen.cameraSub.UpdateCamera();
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null || GameCanvas.currentScreen != GameCanvas.AllInfo)
			{
				return;
			}
			this.list.updateMenu();
			this.idSelect = this.list.value;
			if (this.idSelect >= this.vecConfig.size())
			{
				this.idSelect = -1;
				this.list.value = -1;
			}
		}
	}

	// Token: 0x0600079E RID: 1950 RVA: 0x000791BC File Offset: 0x000773BC
	public override void updatekey()
	{
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO && (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6]))
		{
			MainTabNew.Focus = MainTabNew.TAB;
			this.idSelect = 0;
			GameCanvas.clearKeyHold(4);
			GameCanvas.clearKeyHold(6);
		}
		base.updatekey();
	}

	// Token: 0x04000BA5 RID: 2981
	public static TabConfig me;

	// Token: 0x04000BA6 RID: 2982
	private mVector vecConfig = new mVector("TabConfig vecConfig");

	// Token: 0x04000BA7 RID: 2983
	private int w2;

	// Token: 0x04000BA8 RID: 2984
	private int wFocus;

	// Token: 0x04000BA9 RID: 2985
	private int idSelect;

	// Token: 0x04000BAA RID: 2986
	private int hItem;

	// Token: 0x04000BAB RID: 2987
	private iCommand cmdSelect;

	// Token: 0x04000BAC RID: 2988
	private iCommand cmdlogout;

	// Token: 0x04000BAD RID: 2989
	private iCommand cmdSetAuto;

	// Token: 0x04000BAE RID: 2990
	private iCommand cmdHelp;

	// Token: 0x04000BAF RID: 2991
	private iCommand cmdSetting;

	// Token: 0x04000BB0 RID: 2992
	private iCommand cmdChucNang;

	// Token: 0x04000BB1 RID: 2993
	private iCommand cmdShowFullMini;

	// Token: 0x04000BB2 RID: 2994
	private iCommand cmdChatWorld;

	// Token: 0x04000BB3 RID: 2995
	private iCommand cmdDiamond;

	// Token: 0x04000BB4 RID: 2996
	private iCommand cmdDiamondIOS;

	// Token: 0x04000BB5 RID: 2997
	private iCommand cmdDiamondIOSVND;

	// Token: 0x04000BB6 RID: 2998
	private iCommand cmdSoundSetting;

	// Token: 0x04000BB7 RID: 2999
	private iCommand cmdVongquay;

	// Token: 0x04000BB8 RID: 3000
	private iCommand cmdkhac;

	// Token: 0x04000BB9 RID: 3001
	private iCommand cmdHieuUng;

	// Token: 0x04000BBA RID: 3002
	public static iCommand cmdEvent;

	// Token: 0x04000BBB RID: 3003
	public static iCommand cmdKeypad;

	// Token: 0x04000BBC RID: 3004
	public static iCommand cmdShowClan;

	// Token: 0x04000BBD RID: 3005
	public static iCommand cmdXuongNgua;

	// Token: 0x04000BBE RID: 3006
	public static iCommand cmdChangeScreen;

	// Token: 0x04000BBF RID: 3007
	private MainList list;

	// Token: 0x04000BC0 RID: 3008
	private InputDialog inputWorld;

	// Token: 0x04000BC1 RID: 3009
	public string[][] itemID = new string[][]
	{
		new string[]
		{
			"pack_24_gems",
			"pack_84_gems",
			"pack_150_gems",
			"pack_350_gems",
			"pack_1000_gems",
			"pack_2500_gems"
		},
		new string[]
		{
			"Buy 24 Gem ($0.99)",
			"Buy 84 Gem ($2.99)",
			"Buy 150 Gem ($4.99)",
			"Buy 350 Gem ($9.99)",
			"Buy 1.000 Gem ($24.99)",
			"Buy 2.500 Gem ($49.99)"
		}
	};

	// Token: 0x04000BC2 RID: 3010
	private string textWorld = string.Empty;
}
