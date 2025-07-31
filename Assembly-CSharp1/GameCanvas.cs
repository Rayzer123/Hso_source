using System;

// Token: 0x020000A9 RID: 169
public class GameCanvas
{
	// Token: 0x0600084E RID: 2126 RVA: 0x0008FCDC File Offset: 0x0008DEDC
	public GameCanvas()
	{
		GameCanvas.instance = this;
		this.mainCanvas = TemMidlet.temCanvas;
		GameCanvas.device = TemMidlet.DIVICE;
		GameCanvas.stringPackageName = mSystem.getPackageName();
		this.getSize();
		mSystem.doSetWpLinkIp();
		mFont.loadmFont();
		IndoServer.setLinkIp();
		Usa_Server.setLinkIp();
		if (GameCanvas.w < 200 || GameCanvas.h < 200)
		{
			GameCanvas.isSmallScreen = true;
			if ((int)LoginScreen.indexInfoLogin == 1)
			{
				LoginScreen.indexInfoLogin = 2;
			}
			iCommand.wButtonCmd = 56;
		}
		GameCanvas.wCommand = 36;
		PaintInfoGameScreen.isLevelPoint = false;
		if (GameCanvas.isTouch)
		{
			GameCanvas.wCommand = 40;
			GameCanvas.listPoint = new mVector("GameCanvas listPoint");
			iCommand.hButtonCmd = 30;
			iCommand.wButtonCmd = 80;
			MsgDialog.hPlus = 58;
		}
		else if (GameCanvas.isSmallScreen)
		{
			GameCanvas.wCommand = 30;
		}
		GameCanvas.saveImage = new SaveImageRMS();
		if (CRes.loadRMS("isQty") != null)
		{
			TField.isQwerty = true;
		}
		try
		{
			sbyte[] array = CRes.loadRMS("isLowDevice");
			if (array != null)
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				int num = (int)dataInputStream.readByte();
				if (num == 1)
				{
					GameCanvas.lowGraphic = true;
				}
				else
				{
					GameCanvas.lowGraphic = false;
				}
			}
		}
		catch (Exception ex)
		{
		}
		try
		{
			sbyte[] array2 = CRes.loadRMS("isIndexRes");
			if (array2 != null)
			{
				DataInputStream dataInputStream2 = new DataInputStream(array2);
				GameCanvas.IndexRes = dataInputStream2.readByte();
			}
		}
		catch (Exception ex2)
		{
		}
		try
		{
			if ((int)TemMidlet.DIVICE > 0)
			{
				sbyte[] array3 = CRes.loadRMS("isIndexPart");
				if (array3 != null)
				{
					DataInputStream dataInputStream3 = new DataInputStream(array3);
					GameCanvas.IndexCharPar = dataInputStream3.readShort();
				}
			}
			else
			{
				GameCanvas.IndexCharPar = 0;
			}
		}
		catch (Exception ex3)
		{
		}
		GameCanvas.IndexServer = 6;
		try
		{
			sbyte[] array4 = CRes.loadRMS("isIndexServer");
			if (array4 != null)
			{
				GameCanvas.IndexServer = array4[0];
			}
		}
		catch (Exception ex4)
		{
		}
		try
		{
			if ((int)TemMidlet.DIVICE > 0)
			{
				MsgDialog.mvalueVolume = new sbyte[2];
				MsgDialog.mvalueVolume[0] = 0;
				MsgDialog.mvalueVolume[1] = 0;
				sbyte[] array5 = CRes.loadRMS("isVolume");
				if (array5 != null)
				{
					DataInputStream dataInputStream4 = new DataInputStream(array5);
					MsgDialog.mvalueVolume[0] = dataInputStream4.readByte();
					MsgDialog.mvalueVolume[1] = dataInputStream4.readByte();
				}
				MsgDialog.setMusic();
			}
		}
		catch (Exception ex5)
		{
		}
		if (IndoServer.isIndoSv)
		{
			GameCanvas.IndexServer = 1;
			try
			{
				sbyte[] array6 = CRes.loadRMS("isIndexServer");
				if (array6 != null)
				{
					GameCanvas.IndexServer = array6[0];
				}
			}
			catch (Exception ex6)
			{
			}
		}
		if (Usa_Server.isUsa_server)
		{
			GameCanvas.IndexServer = 0;
		}
		CreateImageStatic.LoadImage();
		MainScreen.cameraMain = new Camera();
		MainScreen.cameraSub = new Camera();
		GameCanvas.loadmap = new LoadMap();
		GameCanvas.minimap = new MiniMap();
		GameCanvas.login = new LoginScreen();
		GameCanvas.game = new GameScreen();
		GameCanvas.load = new LoadMapScreen();
		GameCanvas.worldmap = new WorldMapScreen();
		GameCanvas.readMessenge = new ReadMessenge();
		GameCanvas.maintab = new MainTabNew();
		GameCanvas.AllInfo = new TabScreenNew();
		GameCanvas.msgchat = new MsgChat();
		GameCanvas.selectChar = new SelectCharScreen();
		GameCanvas.mevent = new EventScreen();
		MainListSkill.loadIndexEffKill();
		GameCanvas.logo = new LogoScreen();
		GameCanvas.logo.Show();
		int[] musicID = new int[9];
		int[] sID = new int[59];
		mSound.volumeSound = 1;
		mSound.volumeMusic = 1;
		mSound.init(musicID, sID);
		StoryScreen.setTypeStory();
	}

	// Token: 0x0600084F RID: 2127 RVA: 0x00090100 File Offset: 0x0008E300
	// Note: this type is marked as 'beforefieldinit'.
	static GameCanvas()
	{
		string[,] array = new string[8, 2];
		array[0, 0] = "Chiến Thần";
		array[0, 1] = "112.213.85.108";
		array[1, 0] = "Rồng Lửa";
		array[1, 1] = "27.0.12.133";
		array[2, 0] = "Global Server";
		array[2, 1] = "hsglobal.teamobi.com";
		array[3, 0] = "Phượng Hoàng";
		array[3, 1] = "112.213.85.75";
		array[4, 0] = "Nhân Mã";
		array[4, 1] = "27.0.14.90";
		array[5, 0] = "Kì Lân";
		array[5, 1] = "27.0.12.41";
		array[6, 0] = "Thiên Hà (New)";
		array[6, 1] = "hs7.teamobi.com";
		array[7, 0] = "Thách Đấu";
		array[7, 1] = "112.213.84.17";
		GameCanvas.listServer = array;
		GameCanvas.portServer = new int[]
		{
			19129,
			19129,
			19129,
			19129,
			19129,
			19129,
			19129,
			19129
		};
		int[] array2 = new int[8];
		array2[2] = 1;
		GameCanvas.langServer = array2;
		GameCanvas.countLogin = 0L;
		GameCanvas.linkIP = "http://knightageonline.com/srvip/";
		GameCanvas.isBB = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerEnd = false;
		GameCanvas.hCommand = 25;
		GameCanvas.hText = 14;
		GameCanvas.hLoad = 0;
		GameCanvas.timeNow = 0L;
		GameCanvas.keyMyPressed = new bool[41];
		GameCanvas.keyMyReleased = new bool[41];
		GameCanvas.keyMyHold = new bool[41];
		GameCanvas.coutPaintSplash = 30;
		GameCanvas.countTips = 0L;
		GameCanvas.iTips = 0;
	}

	// Token: 0x06000850 RID: 2128 RVA: 0x000902F0 File Offset: 0x0008E4F0
	public static void loadCaptionCmd()
	{
		GameCanvas.login.setCaptionCmd();
		GameCanvas.game.setCaptionCmd();
		GameCanvas.AllInfo.setCaptionCmd();
		GameCanvas.msgchat.setCaptionCmd();
		GameCanvas.selectChar.setCaptionCmd();
		GameCanvas.mevent.setCaptionCmd();
	}

	// Token: 0x06000851 RID: 2129 RVA: 0x0009033C File Offset: 0x0008E53C
	public void paint(TemGraphics gx)
	{
		this.g = gx.g;
		GameCanvas.currentScreen.paint(this.g);
		if (this.setShowEvent())
		{
			GameScreen.infoGame.paintShowEvent(this.g);
			GameScreen.infoGame.paintInfoChar(this.g);
		}
		if (GameCanvas.subDialog != null)
		{
			GameCanvas.subDialog.paint(this.g);
		}
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog.paint(this.g);
		}
		else if (GameCanvas.menu2.isShowMenu)
		{
			GameCanvas.menu2.paintMenu(this.g);
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().paint(this.g);
		}
		GameCanvas.resetTrans(this.g);
		if (GameCanvas.hLoad > 0)
		{
			this.g.setColor(0);
			this.g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		}
	}

	// Token: 0x06000852 RID: 2130 RVA: 0x00090448 File Offset: 0x0008E648
	public static void closeKeyBoard()
	{
		mGraphics.addYWhenOpenKeyBoard = 0;
		GameCanvas.timeOpenKeyBoard = 0;
		Main.closeKeyBoard();
	}

	// Token: 0x06000853 RID: 2131 RVA: 0x0009045C File Offset: 0x0008E65C
	public static void Translate()
	{
		if (TouchScreenKeyboard.visible)
		{
			GameCanvas.timeOpenKeyBoard++;
			if (GameCanvas.timeOpenKeyBoard > ((!Main.isWindowsPhone) ? 10 : 5))
			{
				if (GameCanvas.currentScreen == GameCanvas.login)
				{
					mGraphics.addYWhenOpenKeyBoard = ((mGraphics.zoomLevel != 1) ? 50 : 55);
				}
				else if (ChatTextField.isShow)
				{
					mGraphics.addYWhenOpenKeyBoard = 45;
				}
			}
		}
		else
		{
			mGraphics.addYWhenOpenKeyBoard = 0;
			GameCanvas.timeOpenKeyBoard = 0;
		}
	}

	// Token: 0x06000854 RID: 2132 RVA: 0x000904EC File Offset: 0x0008E6EC
	public bool setShowEvent()
	{
		return GameCanvas.currentScreen == GameCanvas.game || GameCanvas.currentScreen == GameCanvas.AllInfo || GameCanvas.currentScreen == GameCanvas.shopNpc || GameCanvas.currentScreen == GameCanvas.foodPet || GameCanvas.currentScreen == GameCanvas.worldmap || GameCanvas.currentScreen == GameCanvas.buy_sell || GameCanvas.currentScreen == GameCanvas.info_other_player || GameCanvas.currentScreen == GameCanvas.mevent || GameCanvas.currentScreen == GameCanvas.clan || GameCanvas.currentScreen == MiniMapFull_Screen.gI() || GameCanvas.currentScreen == List_Server.gI();
	}

	// Token: 0x06000855 RID: 2133 RVA: 0x000905A4 File Offset: 0x0008E7A4
	public void update()
	{
		if ((mGraphics.zoomLevel == 1 || Main.isIpod || Main.isIphone4) && !Main.isPC)
		{
			GameCanvas.lowGraphic = true;
		}
		GameCanvas.Translate();
		if (GameCanvas.loadmap != null)
		{
			GameCanvas.loadmap.update();
		}
		GameCanvas.gameTick++;
		if (GameCanvas.gameTick > 10000)
		{
			GameCanvas.gameTick = 0;
		}
		if (GameCanvas.gameTick % 5 == 0)
		{
			GameCanvas.timeNow = mSystem.currentTimeMillis();
		}
		if (GameCanvas.hLoad > 0)
		{
			GameCanvas.hLoad -= GameCanvas.h / 10;
		}
		if (this.setShowEvent())
		{
			GameScreen.infoGame.updateEvent();
			GameScreen.infoGame.updateInfoServer();
			GameScreen.infoGame.updateInfoChar();
			GameScreen.infoGame.updateInfoCharServer();
		}
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog.update();
		}
		else if (GameCanvas.menu2.isShowMenu)
		{
			GameCanvas.menu2.updateMenu();
			GameCanvas.menu2.updateMenuKey();
		}
		else if (GameCanvas.subDialog != null)
		{
			GameCanvas.subDialog.update();
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().updatekey();
			ChatTextField.gI().updatePointer();
		}
		else
		{
			GameCanvas.currentScreen.updatekey();
			GameCanvas.currentScreen.updatePointer();
		}
		GameCanvas.currentScreen.update();
		GameCanvas.isPointerClick = false;
		if (GameScreen.timeResetCam > 0)
		{
			GameScreen.timeResetCam--;
			if (GameScreen.timeResetCam == 0)
			{
				GameScreen.isMoveCamera = false;
			}
		}
		if (GlobalLogicHandler.isDisconnect)
		{
			GlobalLogicHandler.isDisconnect = false;
			mSystem.outz("mat ket noi");
			mVector mVector = new mVector();
			if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login && GameCanvas.currentScreen != GameCanvas.load)
			{
				mVector.addElement(new iCommand(T.again, 0));
			}
			mVector.addElement(new iCommand(T.exit, 6));
			if (!Main.isExit)
			{
				GameCanvas.start_Select_Dialog(T.disconnect, mVector);
			}
			if (GameScreen.player != null)
			{
				GameScreen.player.resetAction();
				if ((int)Player.isAutoFire == 1)
				{
					Player.setCurAutoFire();
				}
			}
		}
		GameCanvas.coutPaintSplash--;
		this.updateCountTick();
	}

	// Token: 0x06000856 RID: 2134 RVA: 0x00090800 File Offset: 0x0008EA00
	public void reSume()
	{
		if (GameCanvas.currentScreen != GameCanvas.login && GameCanvas.currentScreen != GameCanvas.load)
		{
			if (SelectCharScreen.isSelectOk)
			{
				GameCanvas.login.Show();
				sbyte[] array = CRes.loadRMS("user_pass");
				if (array != null)
				{
					try
					{
						LoginScreen.loadUser_Pass();
					}
					catch (Exception ex)
					{
					}
					GameCanvas.connect();
					GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
					GameScreen.player.resetPlayer();
					if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
					{
						GlobalService.gI().send_cmd_server(61);
					}
				}
				else
				{
					GameCanvas.login.Show();
				}
			}
		}
		else if (GameCanvas.currentScreen != GameCanvas.login)
		{
			GameCanvas.login.Show();
		}
	}

	// Token: 0x06000857 RID: 2135 RVA: 0x00090914 File Offset: 0x0008EB14
	public static void resetTrans(mGraphics g)
	{
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(0, 0);
		g.setClip(-200, -200, GameCanvas.w + 400, GameCanvas.h + 400);
	}

	// Token: 0x06000858 RID: 2136 RVA: 0x00090964 File Offset: 0x0008EB64
	public static void start_Ok_Dialog(string str)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, new iCommand("Ok", -1), true);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x06000859 RID: 2137 RVA: 0x00090990 File Offset: 0x0008EB90
	public static void start_Ok_Dialog(string str, sbyte t)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, new iCommand("Ok", (int)t), true);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085A RID: 2138 RVA: 0x000909C0 File Offset: 0x0008EBC0
	public static void start_Download_Dialog(string str, string link)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoDownload(str, link, false);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085B RID: 2139 RVA: 0x000909E4 File Offset: 0x0008EBE4
	public static void start_Show_Dialog(string str, string name)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoSHOW(str, new iCommand(T.close, -1), true, name);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085C RID: 2140 RVA: 0x00090A14 File Offset: 0x0008EC14
	public static void start_Wait_Dialog(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoWait(str, cmd);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085D RID: 2141 RVA: 0x00090A38 File Offset: 0x0008EC38
	public static void start_Select_Dialog(string str, mVector cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085E RID: 2142 RVA: 0x00090A5C File Offset: 0x0008EC5C
	public static void start_Center_Dialog_Only(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd, true);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600085F RID: 2143 RVA: 0x00090A80 File Offset: 0x0008EC80
	public static void start_Left_Dialog(string str, iCommand cmd)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfo(str, cmd, false);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x06000860 RID: 2144 RVA: 0x00090AA4 File Offset: 0x0008ECA4
	public static void start_Quest_Dialog(string str, string status, int ID, int type, sbyte mainsub)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoQuest(str, status, ID, type, mainsub);
		Cout.println((int)mainsub);
		GameCanvas.subDialog = msgDialog;
	}

	// Token: 0x06000861 RID: 2145 RVA: 0x00090AD4 File Offset: 0x0008ECD4
	public static void start_Quest_DialogRead(MainQuest quest)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoQuestRead(quest);
		GameCanvas.subDialog = msgDialog;
	}

	// Token: 0x06000862 RID: 2146 RVA: 0x00090AF4 File Offset: 0x0008ECF4
	public static void start_Party_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoParty();
		GameCanvas.subDialog = msgDialog;
	}

	// Token: 0x06000863 RID: 2147 RVA: 0x00090B14 File Offset: 0x0008ED14
	public static void start_Auto_HPMP_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoAutoHP_MP();
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x06000864 RID: 2148 RVA: 0x00090B34 File Offset: 0x0008ED34
	public static void start_Volume_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoVolume();
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x06000865 RID: 2149 RVA: 0x00090B54 File Offset: 0x0008ED54
	public static void start_Auto_Item_Dialog()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setinfoAutoGetItem();
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x06000866 RID: 2150 RVA: 0x00090B74 File Offset: 0x0008ED74
	public static void start_Auto_Buff()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setInfoAutoBuff();
		GameCanvas.subDialog = msgDialog;
	}

	// Token: 0x06000867 RID: 2151 RVA: 0x00090B94 File Offset: 0x0008ED94
	public static void start_Chat_Dialog()
	{
		GameCanvas.msgchat.checkRemoveText();
		GameCanvas.msgchat.init();
		GameCanvas.subDialog = GameCanvas.msgchat;
	}

	// Token: 0x06000868 RID: 2152 RVA: 0x00090BB4 File Offset: 0x0008EDB4
	public static void start_More_Input_Dialog(string[] str, iCommand cmd, short type, short idNPC, string name, string[] infomacdinh, sbyte typemo)
	{
		GameCanvas.end_Dialog();
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(str, cmd, type, idNPC, name, infomacdinh, typemo);
		GameCanvas.subDialog = inputDialog;
	}

	// Token: 0x06000869 RID: 2153 RVA: 0x00090BE4 File Offset: 0x0008EDE4
	public static void start_More_Input_Dialog(string[] str, iCommand cmd, short type, short idNPC, string name)
	{
		InputDialog inputDialog = new InputDialog();
		inputDialog.setinfo(str, cmd, type, idNPC, name);
		GameCanvas.subDialog = inputDialog;
	}

	// Token: 0x0600086A RID: 2154 RVA: 0x00090C0C File Offset: 0x0008EE0C
	public static void start_Time_Dialog(string info, short time)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setInfoTime(info, time);
		GameCanvas.subDialog = msgDialog;
	}

	// Token: 0x0600086B RID: 2155 RVA: 0x00090C30 File Offset: 0x0008EE30
	public static void start_Change_Item(string name, string info, MainItem[] datanguyenlieu, MainItem sanpham)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setShowChangeItem(name, info, datanguyenlieu, sanpham);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600086C RID: 2156 RVA: 0x00090C54 File Offset: 0x0008EE54
	public static void start_Open_Box(string name, string info, MainItem[] data, sbyte typeOpen, sbyte isLottery)
	{
		if (info != null && info.Trim().Length == 0)
		{
			info = null;
		}
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setShowOpenBox(name, data, info, typeOpen, isLottery);
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600086D RID: 2157 RVA: 0x00090C94 File Offset: 0x0008EE94
	public static void start_Update_Data()
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setUpdateData();
		GameCanvas.currentDialog = msgDialog;
	}

	// Token: 0x0600086E RID: 2158 RVA: 0x00090CB4 File Offset: 0x0008EEB4
	public static void start_Pet_Info(PetItem pet, sbyte type)
	{
		MsgDialog msgDialog = new MsgDialog();
		msgDialog.setPetInfo(pet, type);
		GameCanvas.subDialog = msgDialog;
		if (pet != null)
		{
			GlobalService.gI().Update_Pet_Eat(TabShopNew.UPDATE_PET_EAT, (short)pet.Id);
		}
	}

	// Token: 0x0600086F RID: 2159 RVA: 0x00090CF4 File Offset: 0x0008EEF4
	public static void end_Dialog()
	{
		GameCanvas.currentDialog = null;
		GameCanvas.subDialog = null;
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		if (GameScreen.help.Step >= 0)
		{
			GameScreen.help.timeReset = 20;
		}
	}

	// Token: 0x06000870 RID: 2160 RVA: 0x00090D34 File Offset: 0x0008EF34
	public static void end_Dialog_Help()
	{
		GameCanvas.currentDialog = null;
	}

	// Token: 0x06000871 RID: 2161 RVA: 0x00090D3C File Offset: 0x0008EF3C
	public static void addInfoCharServer(string str)
	{
		GameCanvas.resetTip();
		if (str != null && str.Length > 0)
		{
			GameScreen.VecInfoServer.addElement(str);
		}
	}

	// Token: 0x06000872 RID: 2162 RVA: 0x00090D6C File Offset: 0x0008EF6C
	public static void addInfoChar(string str)
	{
		if (str != null && str.Length > 0)
		{
			if (mFont.tahoma_7_black.getWidth(str) > 140)
			{
				GameCanvas.addInfoCharCline(str);
			}
			else
			{
				GameScreen.infoGame.strInfoCharCline = str;
				GameScreen.infoGame.ydInfoChar = 10;
				GameScreen.infoGame.timeInfoCharCline = 0;
			}
		}
	}

	// Token: 0x06000873 RID: 2163 RVA: 0x00090DD0 File Offset: 0x0008EFD0
	public static void addInfoCharCline(string str)
	{
		if (str != null && str.Length > 0)
		{
			GameScreen.VecInfoChar.addElement(str);
		}
	}

	// Token: 0x06000874 RID: 2164 RVA: 0x00090DF0 File Offset: 0x0008EFF0
	public void mapKeyPress(int keyCode)
	{
		PaintInfoGameScreen.timeDoNotClick = GameCanvas.timeNow;
		PaintInfoGameScreen.isShowInGame = true;
		if (GameCanvas.currentDialog != null)
		{
			GameCanvas.currentDialog.keypress(keyCode);
		}
		else if (GameCanvas.subDialog != null)
		{
			GameCanvas.subDialog.keypress(keyCode);
		}
		else if (ChatTextField.isShow)
		{
			ChatTextField.gI().keyPressed(keyCode);
		}
		else
		{
			GameCanvas.currentScreen.keyPress(keyCode);
		}
		if (TField.isQwerty)
		{
			if (GameCanvas.keyAsciiPress == 114 || GameCanvas.keyAsciiPress == 82)
			{
				GameCanvas.keyMyHold[21] = true;
				GameCanvas.keyMyPressed[21] = true;
			}
			else if (GameCanvas.keyAsciiPress == 116 || GameCanvas.keyAsciiPress == 84)
			{
				GameCanvas.keyMyHold[23] = true;
				GameCanvas.keyMyPressed[23] = true;
			}
			else if (GameCanvas.keyAsciiPress == 121 || GameCanvas.keyAsciiPress == 89)
			{
				GameCanvas.keyMyHold[25] = true;
				GameCanvas.keyMyPressed[25] = true;
			}
			else if (GameCanvas.keyAsciiPress == 117 || GameCanvas.keyAsciiPress == 85)
			{
				GameCanvas.keyMyHold[27] = true;
				GameCanvas.keyMyPressed[27] = true;
			}
			else if (GameCanvas.keyAsciiPress == 105 || GameCanvas.keyAsciiPress == 73)
			{
				GameCanvas.keyMyHold[29] = true;
				GameCanvas.keyMyPressed[29] = true;
			}
		}
		switch (keyCode)
		{
		case 35:
			GameCanvas.keyMyHold[11] = true;
			GameCanvas.keyMyPressed[11] = true;
			return;
		default:
			switch (keyCode + 7)
			{
			case 0:
				goto IL_3C6;
			case 1:
				break;
			case 2:
				GameCanvas.keyMyHold[36] = true;
				GameCanvas.keyMyPressed[36] = true;
				return;
			case 3:
				GameCanvas.keyMyHold[34] = true;
				GameCanvas.keyMyPressed[34] = true;
				return;
			case 4:
				GameCanvas.keyMyHold[33] = true;
				GameCanvas.keyMyPressed[33] = true;
				return;
			case 5:
				GameCanvas.keyMyHold[32] = true;
				GameCanvas.keyMyPressed[32] = true;
				return;
			case 6:
				GameCanvas.keyMyHold[31] = true;
				GameCanvas.keyMyPressed[31] = true;
				return;
			default:
				switch (keyCode)
				{
				case 97:
					GameCanvas.keyMyHold[39] = true;
					GameCanvas.keyMyPressed[39] = true;
					return;
				default:
					if (keyCode == -22)
					{
						goto IL_3C6;
					}
					if (keyCode != -21)
					{
						if (keyCode == 10)
						{
							GameCanvas.keyMyHold[5] = true;
							GameCanvas.keyMyPressed[5] = true;
							return;
						}
						if (keyCode == 115)
						{
							GameCanvas.keyMyHold[38] = true;
							GameCanvas.keyMyPressed[38] = true;
							return;
						}
						if (keyCode != 119)
						{
							return;
						}
						GameCanvas.keyMyHold[30] = true;
						GameCanvas.keyMyPressed[30] = true;
						return;
					}
					break;
				case 99:
					GameCanvas.keyMyHold[37] = true;
					GameCanvas.keyMyPressed[37] = true;
					return;
				case 100:
					GameCanvas.keyMyHold[40] = true;
					GameCanvas.keyMyPressed[40] = true;
					return;
				}
				break;
			}
			GameCanvas.keyMyHold[12] = true;
			GameCanvas.keyMyPressed[12] = true;
			return;
			IL_3C6:
			GameCanvas.keyMyHold[13] = true;
			GameCanvas.keyMyPressed[13] = true;
			return;
		case 42:
			GameCanvas.keyMyHold[10] = true;
			GameCanvas.keyMyPressed[10] = true;
			return;
		case 48:
			GameCanvas.keyMyHold[0] = true;
			GameCanvas.keyMyPressed[0] = true;
			return;
		case 49:
			GameCanvas.keyMyHold[1] = true;
			GameCanvas.keyMyPressed[1] = true;
			return;
		case 50:
			GameCanvas.keyMyHold[2] = true;
			GameCanvas.keyMyPressed[2] = true;
			return;
		case 51:
			GameCanvas.keyMyHold[3] = true;
			GameCanvas.keyMyPressed[3] = true;
			return;
		case 52:
			GameCanvas.keyMyHold[4] = true;
			GameCanvas.keyMyPressed[4] = true;
			return;
		case 53:
			if (GameCanvas.currentScreen == GameScreen.gI() && !ChatTextField.isShow)
			{
				GameCanvas.keyMyHold[5] = true;
				GameCanvas.keyMyPressed[5] = true;
			}
			return;
		case 54:
			GameCanvas.keyMyHold[6] = true;
			GameCanvas.keyMyPressed[6] = true;
			return;
		case 55:
		case 56:
		case 57:
			GameCanvas.keyMyHold[keyCode - 28] = true;
			GameCanvas.keyMyPressed[keyCode - 28] = true;
			return;
		}
	}

	// Token: 0x06000875 RID: 2165 RVA: 0x000911EC File Offset: 0x0008F3EC
	public void mapKeyRelease(int keyCode)
	{
		switch (keyCode)
		{
		case 35:
			GameCanvas.keyMyHold[11] = false;
			return;
		default:
			switch (keyCode + 7)
			{
			case 0:
				goto IL_1E3;
			case 1:
				break;
			case 2:
				GameCanvas.keyMyHold[36] = false;
				return;
			case 3:
				GameCanvas.keyMyHold[34] = false;
				return;
			case 4:
				GameCanvas.keyMyHold[33] = false;
				return;
			case 5:
				GameCanvas.keyMyHold[32] = false;
				return;
			case 6:
				GameCanvas.keyMyHold[31] = false;
				return;
			default:
				switch (keyCode)
				{
				case 97:
					GameCanvas.keyMyHold[39] = false;
					return;
				default:
					if (keyCode == -22)
					{
						goto IL_1E3;
					}
					if (keyCode != -21)
					{
						if (keyCode == 71)
						{
							GameCanvas.keyMyHold[37] = false;
							return;
						}
						if (keyCode == 115)
						{
							GameCanvas.keyMyHold[38] = false;
							return;
						}
						if (keyCode != 119)
						{
							return;
						}
						GameCanvas.keyMyHold[30] = false;
						return;
					}
					break;
				case 100:
					GameCanvas.keyMyHold[40] = false;
					return;
				}
				break;
			case 11:
				GameCanvas.keyMyHold[36] = false;
				return;
			case 17:
				GameCanvas.keyMyHold[5] = false;
				GameCanvas.keyMyPressed[5] = false;
				return;
			}
			GameCanvas.keyMyHold[12] = false;
			return;
			IL_1E3:
			GameCanvas.keyMyHold[13] = false;
			return;
		case 42:
			GameCanvas.keyMyHold[10] = false;
			return;
		case 48:
			GameCanvas.keyMyHold[0] = false;
			return;
		case 49:
			GameCanvas.keyMyHold[1] = false;
			return;
		case 50:
			GameCanvas.keyMyHold[2] = false;
			return;
		case 51:
			GameCanvas.keyMyHold[3] = false;
			GameCanvas.keyMyPressed[3] = true;
			return;
		case 52:
			GameCanvas.keyMyHold[4] = true;
			return;
		case 53:
			GameCanvas.keyMyHold[5] = false;
			return;
		case 54:
			GameCanvas.keyMyHold[6] = false;
			return;
		case 55:
		case 56:
		case 57:
			GameCanvas.keyMyHold[keyCode - 28] = false;
			return;
		}
	}

	// Token: 0x06000876 RID: 2166 RVA: 0x000913F0 File Offset: 0x0008F5F0
	public void keyPressed(int keyCode)
	{
		if (TField.isQwerty && ((keyCode >= 48 && keyCode <= 57) || (keyCode >= 65 && keyCode <= 122) || keyCode == 10 || keyCode == 8 || keyCode == 13 || keyCode == 32))
		{
			GameCanvas.keyAsciiPress = keyCode;
		}
		this.mapKeyPress(keyCode);
	}

	// Token: 0x06000877 RID: 2167 RVA: 0x00091454 File Offset: 0x0008F654
	public void keyReleased(int keyCode)
	{
		if (TField.isQwerty)
		{
			GameCanvas.keyAsciiPress = 0;
		}
		this.mapKeyRelease(keyCode);
	}

	// Token: 0x06000878 RID: 2168 RVA: 0x00091470 File Offset: 0x0008F670
	public static bool isKeyPressed(int index)
	{
		return GameCanvas.keyMyPressed[index];
	}

	// Token: 0x06000879 RID: 2169 RVA: 0x00091484 File Offset: 0x0008F684
	public void pointerDragged(int x, int y)
	{
		GameCanvas.px = x / mGraphics.zoomLevel;
		GameCanvas.py = y / mGraphics.zoomLevel;
		if (GameCanvas.isPointerMove)
		{
			GameCanvas.listPoint.addElement(new Position(x, y));
		}
		else if (CRes.abs(GameCanvas.px - GameCanvas.pxLast) >= 15 || CRes.abs(GameCanvas.py - GameCanvas.pyLast) >= 15)
		{
			GameCanvas.isPointerMove = true;
		}
	}

	// Token: 0x0600087A RID: 2170 RVA: 0x00091500 File Offset: 0x0008F700
	public void pointerPressed(int x, int y)
	{
		PaintInfoGameScreen.timeDoNotClick = GameCanvas.timeNow;
		PaintInfoGameScreen.isShowInGame = true;
		GameCanvas.isPointerDown = true;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerEnd = false;
		if (GameCanvas.currentScreen == MapScr.gI())
		{
			GameCanvas.isPointerClick = true;
		}
		GameCanvas.pxLast = x / mGraphics.zoomLevel;
		GameCanvas.pyLast = y / mGraphics.zoomLevel;
		GameCanvas.px = x / mGraphics.zoomLevel;
		GameCanvas.py = y / mGraphics.zoomLevel;
	}

	// Token: 0x0600087B RID: 2171 RVA: 0x00091580 File Offset: 0x0008F780
	public void pointerReleased(int x, int y)
	{
		if (!GameCanvas.isPointerMove && !GameCanvas.isPointerEnd && global::Math.abs(GameCanvas.px - GameCanvas.pxLast) <= 5 && global::Math.abs(GameCanvas.py - GameCanvas.pyLast) <= 5)
		{
			GameCanvas.isPointerSelect = true;
		}
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerRelease = true;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerClick = true;
		GameCanvas.isPointerEnd = false;
		GameCanvas.px = x / mGraphics.zoomLevel;
		GameCanvas.py = y / mGraphics.zoomLevel;
	}

	// Token: 0x0600087C RID: 2172 RVA: 0x00091614 File Offset: 0x0008F814
	public static void clearKeyPressed()
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		for (int i = 0; i < GameCanvas.keyMyPressed.Length; i++)
		{
			GameCanvas.keyMyPressed[i] = false;
		}
	}

	// Token: 0x0600087D RID: 2173 RVA: 0x00091650 File Offset: 0x0008F850
	public static void clearKeyPressed(int keycode)
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.keyMyPressed[keycode] = false;
	}

	// Token: 0x0600087E RID: 2174 RVA: 0x00091668 File Offset: 0x0008F868
	public static void clearKeyHold()
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			GameCanvas.keyMyHold[i] = false;
		}
	}

	// Token: 0x0600087F RID: 2175 RVA: 0x000916A4 File Offset: 0x0008F8A4
	public static void clearKeyHold(int keycode)
	{
		GameCanvas.isPointerRelease = false;
		GameCanvas.isPointerDown = false;
		GameCanvas.keyMyHold[keycode] = false;
	}

	// Token: 0x06000880 RID: 2176 RVA: 0x000916BC File Offset: 0x0008F8BC
	public static void clearKeyReleased()
	{
		GameCanvas.isPointerDown = false;
		GameCanvas.isPointerRelease = false;
		for (int i = 0; i < GameCanvas.keyMyReleased.Length; i++)
		{
			GameCanvas.keyMyReleased[i] = false;
		}
	}

	// Token: 0x06000881 RID: 2177 RVA: 0x000916F8 File Offset: 0x0008F8F8
	public static void clearAll()
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		GameCanvas.clearKeyReleased();
		GameCanvas.isPointerSelect = false;
		GameCanvas.isPointerMove = false;
		GameCanvas.isPointerClick = false;
		GameCanvas.isPointerDown = false;
	}

	// Token: 0x06000882 RID: 2178 RVA: 0x00091724 File Offset: 0x0008F924
	public static void connect()
	{
		if (!Session_ME.gI().isConnected())
		{
			if (LoginScreen.ip != null)
			{
				Session_ME.gI().connect(LoginScreen.ip, 19129);
			}
			else
			{
				string host = GameCanvas.listServer[(int)GameCanvas.IndexServer, 1];
				int port = GameCanvas.portServer[(int)GameCanvas.IndexServer];
				if (IndoServer.isIndoSv && (int)GameCanvas.IndexServer == 1)
				{
					port = 19130;
				}
				Session_ME.gI().connect(host, port);
			}
		}
	}

	// Token: 0x06000883 RID: 2179 RVA: 0x000917AC File Offset: 0x0008F9AC
	public void getSize()
	{
		GameCanvas.w = TemCanvas.wMain;
		GameCanvas.h = TemCanvas.hMain;
		GameCanvas.hw = GameCanvas.w / 2;
		GameCanvas.hh = GameCanvas.h / 2;
	}

	// Token: 0x06000884 RID: 2180 RVA: 0x000917E8 File Offset: 0x0008F9E8
	public static int getSecond()
	{
		return (int)(mSystem.currentTimeMillis() / 1000L);
	}

	// Token: 0x06000885 RID: 2181 RVA: 0x000917F8 File Offset: 0x0008F9F8
	public static bool isPointer(int x, int y, int w, int h)
	{
		return (GameCanvas.isPointerDown || GameCanvas.isPointerRelease) && GameCanvas.isPoint(x, y, w, h);
	}

	// Token: 0x06000886 RID: 2182 RVA: 0x0009181C File Offset: 0x0008FA1C
	public static bool isPointSelect(int x, int y, int w, int h)
	{
		return GameCanvas.isPointerSelect && GameCanvas.isPoint(x, y, w, h);
	}

	// Token: 0x06000887 RID: 2183 RVA: 0x00091834 File Offset: 0x0008FA34
	public static bool isPoint(int x, int y, int w, int h)
	{
		return GameCanvas.px >= x && GameCanvas.px <= x + w && GameCanvas.py >= y && GameCanvas.py <= y + h;
	}

	// Token: 0x06000888 RID: 2184 RVA: 0x0009186C File Offset: 0x0008FA6C
	public static bool isPointLast(int x, int y, int w, int h)
	{
		return GameCanvas.pxLast >= x && GameCanvas.pxLast <= x + w && GameCanvas.pyLast >= y && GameCanvas.pyLast <= y + h;
	}

	// Token: 0x06000889 RID: 2185 RVA: 0x000918A4 File Offset: 0x0008FAA4
	public static bool keyMove(int Dir)
	{
		if (Main.isPC)
		{
			if (GameCanvas.keyMyHold[Dir])
			{
				return true;
			}
		}
		else
		{
			switch (Dir)
			{
			case 0:
				if (GameCanvas.keyMyHold[38] || GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[28])
				{
					return true;
				}
				break;
			case 1:
				if (GameCanvas.keyMyHold[30] || GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[22])
				{
					return true;
				}
				break;
			case 2:
				if (GameCanvas.keyMyHold[39] || GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[24])
				{
					return true;
				}
				break;
			case 3:
				if (GameCanvas.keyMyHold[40] || GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[26])
				{
					return true;
				}
				break;
			}
		}
		return false;
	}

	// Token: 0x0600088A RID: 2186 RVA: 0x000919A0 File Offset: 0x0008FBA0
	public void clearKeyMove(int Dir)
	{
		if (Main.isPC)
		{
			GameCanvas.keyMyHold[Dir] = false;
		}
		else
		{
			switch (Dir)
			{
			case 0:
				GameCanvas.keyMyHold[38] = false;
				GameCanvas.keyMyHold[8] = false;
				GameCanvas.keyMyHold[28] = false;
				break;
			case 1:
				GameCanvas.keyMyHold[30] = false;
				GameCanvas.keyMyHold[2] = false;
				GameCanvas.keyMyHold[22] = false;
				break;
			case 2:
				GameCanvas.keyMyHold[40] = false;
				GameCanvas.keyMyHold[4] = false;
				GameCanvas.keyMyHold[24] = false;
				break;
			case 3:
				GameCanvas.keyMyHold[39] = false;
				GameCanvas.keyMyHold[6] = false;
				GameCanvas.keyMyHold[26] = false;
				break;
			}
		}
	}

	// Token: 0x0600088B RID: 2187 RVA: 0x00091A60 File Offset: 0x0008FC60
	public static bool isKeyUp()
	{
		return GameCanvas.keyMyHold[31];
	}

	// Token: 0x0600088C RID: 2188 RVA: 0x00091A70 File Offset: 0x0008FC70
	public static bool isKeyDown()
	{
		return GameCanvas.keyMyHold[32];
	}

	// Token: 0x0600088D RID: 2189 RVA: 0x00091A80 File Offset: 0x0008FC80
	public static void releaseKeyUp()
	{
		GameCanvas.keyMyHold[31] = false;
	}

	// Token: 0x0600088E RID: 2190 RVA: 0x00091A8C File Offset: 0x0008FC8C
	public static void releaseKeyDown()
	{
		GameCanvas.keyMyHold[32] = false;
	}

	// Token: 0x0600088F RID: 2191 RVA: 0x00091A98 File Offset: 0x0008FC98
	public void updateCountTick()
	{
		if (GameCanvas.countTips != 0L && mSystem.currentTimeMillis() - GameCanvas.countTips >= 600000L)
		{
			GameCanvas.iTips = CRes.random(T.mTips.Length);
			GameCanvas.addInfoCharServer(T.Tips + T.mTips[GameCanvas.iTips]);
		}
	}

	// Token: 0x06000890 RID: 2192 RVA: 0x00091AF0 File Offset: 0x0008FCF0
	public static void resetTip()
	{
		GameCanvas.countTips = mSystem.currentTimeMillis();
		GameCanvas.iTips = 0;
	}

	// Token: 0x04000D18 RID: 3352
	public static int naptien;

	// Token: 0x04000D19 RID: 3353
	public static bool isPlaySound = true;

	// Token: 0x04000D1A RID: 3354
	private TemCanvas mainCanvas;

	// Token: 0x04000D1B RID: 3355
	public static MainScreen currentScreen;

	// Token: 0x04000D1C RID: 3356
	public static LogoScreen logo;

	// Token: 0x04000D1D RID: 3357
	public static LoginScreen login;

	// Token: 0x04000D1E RID: 3358
	public static GameScreen game;

	// Token: 0x04000D1F RID: 3359
	public static LoadMapScreen load;

	// Token: 0x04000D20 RID: 3360
	public static WorldMapScreen worldmap;

	// Token: 0x04000D21 RID: 3361
	public static StoryScreen story;

	// Token: 0x04000D22 RID: 3362
	public static MsgChat msgchat;

	// Token: 0x04000D23 RID: 3363
	public static EventScreen mevent;

	// Token: 0x04000D24 RID: 3364
	public static SelectCharScreen selectChar;

	// Token: 0x04000D25 RID: 3365
	public static CreateChar createChar;

	// Token: 0x04000D26 RID: 3366
	public static List_Ip_Server_Screen listIp;

	// Token: 0x04000D27 RID: 3367
	public static Info_Other_Player info_other_player;

	// Token: 0x04000D28 RID: 3368
	public static Clan_Screen clan;

	// Token: 0x04000D29 RID: 3369
	public static MiniMapFull_Screen fullMiniMap;

	// Token: 0x04000D2A RID: 3370
	public static T t = new T();

	// Token: 0x04000D2B RID: 3371
	private mGraphics g = new mGraphics();

	// Token: 0x04000D2C RID: 3372
	public static Menu2 menu2 = new Menu2();

	// Token: 0x04000D2D RID: 3373
	public static LoadMap loadmap;

	// Token: 0x04000D2E RID: 3374
	public static MiniMap minimap;

	// Token: 0x04000D2F RID: 3375
	public static GameCanvas instance;

	// Token: 0x04000D30 RID: 3376
	public static MainDialog currentDialog;

	// Token: 0x04000D31 RID: 3377
	public static MainDialog subDialog;

	// Token: 0x04000D32 RID: 3378
	public static ReadMessenge readMessenge;

	// Token: 0x04000D33 RID: 3379
	public static MainTabNew maintab;

	// Token: 0x04000D34 RID: 3380
	public static TabScreenNew AllInfo;

	// Token: 0x04000D35 RID: 3381
	public static TabScreenNew shopNpc;

	// Token: 0x04000D36 RID: 3382
	public static TabScreenNew foodPet;

	// Token: 0x04000D37 RID: 3383
	public static Buy_Sell_Screen buy_sell;

	// Token: 0x04000D38 RID: 3384
	public static MapBackGround mapBack;

	// Token: 0x04000D39 RID: 3385
	public static SaveImageRMS saveImage;

	// Token: 0x04000D3A RID: 3386
	public static bool isTouch = true;

	// Token: 0x04000D3B RID: 3387
	public static bool lowGraphic = false;

	// Token: 0x04000D3C RID: 3388
	public static bool isSmallScreen = false;

	// Token: 0x04000D3D RID: 3389
	public static bool isVN_Eng = true;

	// Token: 0x04000D3E RID: 3390
	public static sbyte device = 0;

	// Token: 0x04000D3F RID: 3391
	public static string stringPackageName = string.Empty;

	// Token: 0x04000D40 RID: 3392
	public static sbyte IndexRes = -1;

	// Token: 0x04000D41 RID: 3393
	public static sbyte IndexServer = 6;

	// Token: 0x04000D42 RID: 3394
	public static short IndexCharPar = -1;

	// Token: 0x04000D43 RID: 3395
	public static long timenextLogin;

	// Token: 0x04000D44 RID: 3396
	public static string[,] listServer;

	// Token: 0x04000D45 RID: 3397
	public static int[] portServer;

	// Token: 0x04000D46 RID: 3398
	public static int[] langServer;

	// Token: 0x04000D47 RID: 3399
	public static long countLogin;

	// Token: 0x04000D48 RID: 3400
	public static string linkIP;

	// Token: 0x04000D49 RID: 3401
	public static bool isBB;

	// Token: 0x04000D4A RID: 3402
	public static bool isPointerDown;

	// Token: 0x04000D4B RID: 3403
	public static bool isPointerRelease;

	// Token: 0x04000D4C RID: 3404
	public static bool isPointerSelect;

	// Token: 0x04000D4D RID: 3405
	public static bool isPointerMove;

	// Token: 0x04000D4E RID: 3406
	public static bool isPointerClick;

	// Token: 0x04000D4F RID: 3407
	public static bool isPointerEnd;

	// Token: 0x04000D50 RID: 3408
	public static int w;

	// Token: 0x04000D51 RID: 3409
	public static int h;

	// Token: 0x04000D52 RID: 3410
	public static int hw;

	// Token: 0x04000D53 RID: 3411
	public static int hh;

	// Token: 0x04000D54 RID: 3412
	public static int hCommand;

	// Token: 0x04000D55 RID: 3413
	public static int hText;

	// Token: 0x04000D56 RID: 3414
	public static int hFontBorder;

	// Token: 0x04000D57 RID: 3415
	public static int hFontF;

	// Token: 0x04000D58 RID: 3416
	public static int hNormal;

	// Token: 0x04000D59 RID: 3417
	public static int wCommand;

	// Token: 0x04000D5A RID: 3418
	public static int hLoad;

	// Token: 0x04000D5B RID: 3419
	public static int px;

	// Token: 0x04000D5C RID: 3420
	public static int py;

	// Token: 0x04000D5D RID: 3421
	public static int pxLast;

	// Token: 0x04000D5E RID: 3422
	public static int pyLast;

	// Token: 0x04000D5F RID: 3423
	public static int gameTick;

	// Token: 0x04000D60 RID: 3424
	public static long timeNow;

	// Token: 0x04000D61 RID: 3425
	public static bool[] keyMyPressed;

	// Token: 0x04000D62 RID: 3426
	public static bool[] keyMyReleased;

	// Token: 0x04000D63 RID: 3427
	public static bool[] keyMyHold;

	// Token: 0x04000D64 RID: 3428
	public static bool isMoto;

	// Token: 0x04000D65 RID: 3429
	public static int coutPaintSplash;

	// Token: 0x04000D66 RID: 3430
	public static int timeOpenKeyBoard;

	// Token: 0x04000D67 RID: 3431
	public static int keyAsciiPress;

	// Token: 0x04000D68 RID: 3432
	public static mVector listPoint;

	// Token: 0x04000D69 RID: 3433
	public static long countTips;

	// Token: 0x04000D6A RID: 3434
	public static int iTips;
}
