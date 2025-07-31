using System;
using System.IO;

// Token: 0x02000084 RID: 132
public class LoginScreen : MainScreen
{
	// Token: 0x06000643 RID: 1603 RVA: 0x0005DD9C File Offset: 0x0005BF9C
	public LoginScreen()
	{
		this.init();
	}

	// Token: 0x06000645 RID: 1605 RVA: 0x0005DE2C File Offset: 0x0005C02C
	public new void Show()
	{
		try
		{
			BackGround.init();
			mSound.stopSoundAll();
			LoginScreen.MusicRandom = CRes.random(2);
			if (LoginScreen.MusicRandom == 0)
			{
				mSound.playMus(0, mSound.volumeMusic, true);
			}
			else
			{
				mSound.playMus(1, mSound.volumeMusic, true);
			}
			base.Show();
			if (LoginScreen.isAutoLogin)
			{
				sbyte[] array = CRes.loadRMS("local_server");
				if (array != null)
				{
					DataInputStream dataInputStream = new DataInputStream(array);
					try
					{
						LoginScreen.isServer = dataInputStream.readByte();
					}
					catch (Exception ex)
					{
					}
				}
				sbyte[] array2 = CRes.loadRMS("user_pass");
				if (array2 != null)
				{
					try
					{
						LoginScreen.loadUser_Pass();
					}
					catch (Exception ex2)
					{
					}
					GameCanvas.connect();
					if (LoginScreen.username.Length > 0)
					{
						this.login(LoginScreen.username, LoginScreen.password);
					}
					else if (LoginScreen.tfusername.getText().Length > 0)
					{
						this.login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText());
					}
				}
			}
			else
			{
				sbyte[] array3 = CRes.loadRMS("user_pass");
				if (array3 != null)
				{
					try
					{
						LoginScreen.loadUser_Pass();
					}
					catch (Exception ex3)
					{
					}
				}
			}
			LoginScreen.isAutoLogin = false;
			this.section = 0;
			this.setScreen();
		}
		catch (Exception ex4)
		{
		}
	}

	// Token: 0x06000646 RID: 1606 RVA: 0x0005DFDC File Offset: 0x0005C1DC
	private void login(string name, string pass)
	{
		if (LoginScreen.tfusername.getText().CompareTo("doiip") == 0 && LoginScreen.tfpassword.getText().Equals("master"))
		{
			GameCanvas.linkIP = "http://knightageonline.com/srvip2/";
			GameCanvas.start_Ok_Dialog("Da doi ip thanh cong");
			return;
		}
		GlobalService.gI().login(name, pass, GameMidlet.version, "0", "0", "0", -1, -1);
		if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
		{
			GlobalService.gI().send_cmd_server(61);
		}
	}

	// Token: 0x06000647 RID: 1607 RVA: 0x0005E074 File Offset: 0x0005C274
	public string catUsername(string url)
	{
		if (url.Contains("ip"))
		{
			url = url.Substring(2);
		}
		return url;
	}

	// Token: 0x06000648 RID: 1608 RVA: 0x0005E090 File Offset: 0x0005C290
	public void init()
	{
		if (GameCanvas.h < 240)
		{
			this.hpaint = 10;
		}
		this.yBorder = GameCanvas.hh - 30 + this.hpaint;
		if (GameCanvas.h - this.yBorder < 160)
		{
			this.yBorder = GameCanvas.h - 160 + this.hpaint + 20;
		}
		if (GameCanvas.isTouch)
		{
			this.wBorder = GameCanvas.hw + 40;
			this.hitem = 10;
			this.yLoginBox = GameCanvas.hh - 50;
		}
		else
		{
			this.wBorder = GameCanvas.w / 2;
		}
		LoginScreen.wLine = mFont.tahoma_7_yellow.getWidth(T.HotLine);
		if (IndoServer.isIndoSv || Usa_Server.isUsa_server)
		{
			LoginScreen.isPaintHotLine = false;
		}
		if (GameCanvas.langServer[(int)GameCanvas.IndexServer] != 0)
		{
			LoginScreen.isPaintHotLine = false;
		}
		if (this.wBorder < 130)
		{
			this.wBorder = 130 + GameCanvas.hw / 2;
		}
		if (GameCanvas.isTouch)
		{
			LoginScreen.tfusername = new TField(GameCanvas.hw - this.wBorder / 2 + 15, this.yLoginBox + this.hitem + this.hitem / 2, this.wBorder - 30);
			LoginScreen.tfpassword = new TField(GameCanvas.hw - this.wBorder / 2 + 15, this.yLoginBox + this.hitem * 2 + this.hitem / 2 + LoginScreen.tfusername.height, this.wBorder - 30, 30);
			LoginScreen.tfpassword.showSubTextField = false;
			LoginScreen.tfusername.showSubTextField = false;
		}
		else
		{
			LoginScreen.tfusername = new TField(GameCanvas.hw - this.wBorder / 2 + 15, this.yBorder + this.hitem + this.hitem / 2, this.wBorder - 30);
			LoginScreen.tfpassword = new TField(GameCanvas.hw - this.wBorder / 2 + 15, this.yBorder + this.hitem * 2 + this.hitem / 2 + LoginScreen.tfusername.height, this.wBorder - 30);
		}
		LoginScreen.tfusername.setStringNull(T.username);
		LoginScreen.tfpassword.setStringNull(T.password);
		LoginScreen.tfpassword.setIputType(TField.INPUT_TYPE_PASSWORD);
		bool flag = true;
		if (GameCanvas.isTouch && !Main.isPC)
		{
			flag = false;
		}
		if (flag)
		{
			LoginScreen.tfusername.setFocus(true);
		}
		this.cmdLogin = new iCommand(T.choi_daco_TK, 0);
		this.cmdQuickPlay = new iCommand(T.choimoi, 1);
		this.cmdNewPlay = new iCommand(T.choimoi, 1);
		this.cmdOK = new iCommand("OK", 2);
		this.cmdSubMenu = new iCommand(T.menu, 3);
		this.cmdPlay = new iCommand(T.choi_daco_TK, 4);
		this.cmdUserAccount = new iCommand(T.daco_TK, 5, this);
		this.cmdChooseServer = new iCommand(T.maychu + ": " + GameCanvas.listServer[(int)GameCanvas.IndexServer, 0], 6, this);
		this.cmdChangePassword = new iCommand(T.quenpass, 7, this);
		this.cmdGraphicsSetting = new iCommand(T.cauhinhthap, 8, this);
		this.cmdSoundSetting = new iCommand(T.SetMusic, 9, this);
		this.cmdHotLine = new iCommand(T.HotLine, 23, this);
		if ((int)TemMidlet.currentIAPStore == (int)TemMidlet.NOKIA_STORE)
		{
			this.cmdNokiaInfo = new iCommand(T.about, 21, this);
		}
		this.cmdThoat = new iCommand(T.exit + " Game", -1, this);
		if (GameCanvas.h < 240)
		{
			this.hpaint = -15;
		}
		this.strhelpregister = mFont.tahoma_7_black.splitFontArray(T.texthelpRegister, this.wBorder - 20);
		this.setHeightBorder(false);
	}

	// Token: 0x06000649 RID: 1609 RVA: 0x0005E48C File Offset: 0x0005C68C
	public void setCaptionCmd()
	{
		LoginScreen.tfusername.setStringNull(T.username);
		LoginScreen.tfpassword.setStringNull(T.password);
		LoginScreen.tfusername.cmdClear.caption = T.del;
		LoginScreen.tfpassword.cmdClear.caption = T.del;
		this.cmdLogin.caption = T.choi_daco_TK;
		this.cmdQuickPlay.caption = T.choimoi;
		this.cmdNewPlay.caption = T.choimoi;
		this.cmdPlay.caption = T.choi_daco_TK;
		this.cmdOK.caption = "OK";
		if (!GameCanvas.isTouch)
		{
			this.cmdSubMenu.caption = T.menu;
		}
		this.cmdThoat.caption = T.exit;
		this.cmdChangePassword.caption = T.quenpass;
		this.cmdGraphicsSetting.caption = T.cauhinhthap;
		this.cmdSoundSetting.caption = T.SetMusic;
		this.setCmdCap();
		if ((int)TemMidlet.currentIAPStore == (int)TemMidlet.NOKIA_STORE)
		{
			this.cmdNokiaInfo.caption = T.about;
		}
		this.strhelpregister = mFont.tahoma_7_black.splitFontArray(T.texthelpRegister, this.wBorder - 20);
	}

	// Token: 0x0600064A RID: 1610 RVA: 0x0005E5D0 File Offset: 0x0005C7D0
	public void setPosCmd()
	{
		int num = this.yBorder + this.hBorder - iCommand.hButtonCmd / 2 - this.hitem;
		if (num + iCommand.hButtonCmd / 2 > GameCanvas.h)
		{
			num = GameCanvas.h - iCommand.hButtonCmd / 2;
		}
		int num2 = this.yLoginBox + this.hBorder - iCommand.hButtonCmd / 2 - this.hitem;
		if (num2 + iCommand.hButtonCmd / 2 > GameCanvas.h)
		{
			num2 = GameCanvas.h - iCommand.hButtonCmd / 2;
		}
		this.wBoxText = 160;
		this.hBoxText = 25;
		if (GameCanvas.isTouch)
		{
			this.cmdOK.setPos(GameCanvas.hw - iCommand.wButtonCmd / 2 - 5, num2, null, this.cmdOK.caption);
			int x = LoginScreen.tfpassword.x + LoginScreen.tfpassword.width - AvMain.fraFogetPass.frameWidth / 2 - 10;
			this.cmdChangePassword.setPos(x, num2 - 37, AvMain.fraFogetPass, this.cmdChangePassword.caption);
			this.cmdChangePassword.setFraCaption(AvMain.fraFogetPass, 2, 0);
			this.cmdNewPlay.setPos(GameCanvas.hw + iCommand.wButtonCmd / 2 + 5, num2, null, this.cmdNewPlay.caption);
			this.cmdPlay.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 80, null, this.cmdPlay.caption, this.wBoxText, this.hBoxText);
			this.cmdLogin.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 80, null, this.cmdLogin.caption, this.wBoxText, this.hBoxText);
			this.cmdQuickPlay.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 80, null, this.cmdQuickPlay.caption, this.wBoxText, this.hBoxText);
			this.cmdUserAccount.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 45, null, this.cmdUserAccount.caption, this.wBoxText, this.hBoxText);
			this.cmdChooseServer.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 10, null, this.cmdChooseServer.caption, this.wBoxText, this.hBoxText);
		}
		else
		{
			this.wBoxText = 140;
			this.cmdUserAccount.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 60, null, this.cmdUserAccount.caption, this.wBoxText, this.hBoxText);
			this.cmdChooseServer.setPos_BoxText(GameCanvas.hw - this.wBoxText / 2, num - 20, null, this.cmdChooseServer.caption, this.wBoxText, this.hBoxText);
		}
	}

	// Token: 0x0600064B RID: 1611 RVA: 0x0005E8A0 File Offset: 0x0005CAA0
	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paint_StaticCloud(g);
		if (this.isPaintLogo)
		{
			if (this.section != 1 && LoginScreen.logo != null)
			{
				if (GameCanvas.isTouch)
				{
					g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - GameCanvas.hh / 2, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 60 - GameCanvas.hh / 8, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			BackGround.paint_CloudOnLogo(g);
			BackGround.paintLight(g);
			switch (this.section)
			{
			case 0:
				this.cmdUserAccount.paintbutton(g, this.cmdUserAccount.xCmd, this.cmdUserAccount.yCmd);
				this.cmdChooseServer.paintbutton(g, this.cmdChooseServer.xCmd, this.cmdChooseServer.yCmd);
				this.cmdUserAccount.paintCaptionImage(g, this.cmdUserAccount.xCmd, this.cmdUserAccount.yCmd - 6, 2);
				this.cmdChooseServer.paintCaptionImage(g, this.cmdChooseServer.xCmd, this.cmdChooseServer.yCmd - 6, 2);
				break;
			case 1:
				if (GameCanvas.isTouch)
				{
					AvMain.paintTabNew(g, GameCanvas.hw - this.wBorder / 2, this.yLoginBox - 5, this.wBorder, this.hBorder + 5, true, 14);
				}
				else
				{
					AvMain.paintTabNew(g, GameCanvas.hw - this.wBorder / 2, this.yBorder - 5, this.wBorder, this.hBorder + 5, true, 14);
				}
				LoginScreen.tfusername.paint(g);
				LoginScreen.tfpassword.paint(g);
				this.cmdChangePassword.paintImage(g, this.cmdChangePassword.xCmd, this.cmdChangePassword.yCmd - 6, 3, 1);
				break;
			}
		}
		GameCanvas.resetTrans(g);
		if (!mSystem.isIP_TrucTiep)
		{
			mFont.tahoma_7_yellow.drawString(g, "version: " + GameMidlet.version, GameCanvas.w - 2, 2, 1, mGraphics.isFalse);
		}
		else
		{
			mFont.tahoma_7_yellow.drawString(g, "in-house test version: " + GameMidlet.version, GameCanvas.w - 2, 2, 1, mGraphics.isFalse);
		}
		if ((int)PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if ((int)PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
		if (LoginScreen.isPaintHotLine)
		{
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 15, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - LoginScreen.wLine + ((!mSystem.isIphone) ? 0 : 14), 25, LoginScreen.wLine, 1, mGraphics.isFalse);
		}
		base.paint(g);
	}

	// Token: 0x0600064C RID: 1612 RVA: 0x0005EBB8 File Offset: 0x0005CDB8
	public override void update()
	{
		if (LoginScreen.hShowServer < 20)
		{
			LoginScreen.hShowServer += 4;
			if (LoginScreen.hShowServer > 20)
			{
				LoginScreen.hShowServer = 20;
			}
		}
		if (this.section != 0)
		{
			LoginScreen.tfusername.update();
			LoginScreen.tfpassword.update();
		}
		else
		{
			this.setCmdCap();
		}
		if (GameCanvas.menu2.isShowMenu)
		{
			this.isPaintLogo = false;
		}
		else
		{
			this.isPaintLogo = true;
		}
		BackGround.updateSky();
	}

	// Token: 0x0600064D RID: 1613 RVA: 0x0005EC44 File Offset: 0x0005CE44
	public override void updatekey()
	{
		if (GameCanvas.isKeyDown())
		{
			if (LoginScreen.tfusername.isFocusedz())
			{
				LoginScreen.tfusername.setFocus(false);
				bool flag = true;
				if (GameCanvas.isTouch && !Main.isPC)
				{
					flag = false;
				}
				if (flag)
				{
					LoginScreen.tfpassword.setFocus(true);
				}
			}
			else if (LoginScreen.tfpassword.isFocusedz())
			{
				bool flag2 = true;
				if (GameCanvas.isTouch && !Main.isPC)
				{
					flag2 = false;
				}
				if (flag2)
				{
					LoginScreen.tfusername.setFocus(true);
				}
				LoginScreen.tfpassword.setFocus(false);
			}
			GameCanvas.releaseKeyDown();
			GameCanvas.clearKeyHold(8);
		}
		else if (GameCanvas.isKeyUp())
		{
			if (LoginScreen.tfusername.isFocusedz())
			{
				LoginScreen.tfusername.setFocus(false);
				LoginScreen.tfpassword.setFocus(true);
			}
			else if (LoginScreen.tfpassword.isFocusedz())
			{
				LoginScreen.tfusername.setFocus(true);
				LoginScreen.tfpassword.setFocus(false);
			}
			GameCanvas.releaseKeyUp();
			GameCanvas.clearKeyHold(2);
		}
		if (!GameCanvas.isTouch)
		{
			if (LoginScreen.tfusername.isFocusedz())
			{
				this.right = LoginScreen.tfusername.setCmdClear();
			}
			else if (LoginScreen.tfpassword.isFocusedz())
			{
				this.right = LoginScreen.tfpassword.setCmdClear();
			}
			else
			{
				this.right = null;
			}
		}
		base.updatekey();
	}

	// Token: 0x0600064E RID: 1614 RVA: 0x0005EDBC File Offset: 0x0005CFBC
	public override void updatePointer()
	{
		if (this.section != 0)
		{
			LoginScreen.tfusername.updatePoiter();
			LoginScreen.tfpassword.updatePoiter();
		}
		if (this.section == 1)
		{
			this.cmdChangePassword.updatePointer();
		}
		else if (this.section == 0)
		{
			this.cmdChooseServer.updatePointer();
			this.cmdUserAccount.updatePointer();
		}
		else if (this.section == 2)
		{
		}
		base.updatePointer();
	}

	// Token: 0x0600064F RID: 1615 RVA: 0x0005EE3C File Offset: 0x0005D03C
	public override void keyPress(int keyCode)
	{
		if (LoginScreen.tfusername.isFocusedz())
		{
			LoginScreen.tfusername.keyPressed(keyCode);
		}
		else if (LoginScreen.tfpassword.isFocusedz())
		{
			LoginScreen.tfpassword.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	// Token: 0x06000650 RID: 1616 RVA: 0x0005EE8C File Offset: 0x0005D08C
	public static void saveUser_Pass()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(LoginScreen.tfusername.getText());
			dataOutputStream.writeUTF(LoginScreen.tfpassword.getText());
			CRes.saveRMS("user_pass", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000651 RID: 1617 RVA: 0x0005EEFC File Offset: 0x0005D0FC
	public static void saveIndexServer()
	{
		try
		{
			sbyte[] data = new sbyte[]
			{
				GameCanvas.IndexServer
			};
			CRes.saveRMS("isIndexServer", data);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000652 RID: 1618 RVA: 0x0005EF4C File Offset: 0x0005D14C
	public static void loadUser_Pass()
	{
		sbyte[] array = CRes.loadRMS("user_pass");
		if (array == null)
		{
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(array);
		LoginScreen.tfusername.setText(dataInputStream.readUTF());
		LoginScreen.tfpassword.setText(dataInputStream.readUTF());
		string text = LoginScreen.tfusername.getText();
		if (text.Length >= 10)
		{
			text = text.Substring(0, 10);
		}
		if (text.CompareTo("knightauto") == 0)
		{
			LoginScreen.username = LoginScreen.tfusername.getText();
			LoginScreen.password = LoginScreen.tfpassword.getText();
			LoginScreen.tfusername.setText(string.Empty);
			LoginScreen.tfpassword.setText(string.Empty);
		}
	}

	// Token: 0x06000653 RID: 1619 RVA: 0x0005F000 File Offset: 0x0005D200
	public void doMenu()
	{
		mVector mVector = new mVector("LoginScreen menu");
		if (this.section == 0)
		{
			if (!GameCanvas.isTouch)
			{
				mVector.addElement(this.cmdUserAccount);
				mVector.addElement(this.cmdChooseServer);
				mVector.addElement(this.cmdChangePassword);
				mVector.addElement(this.cmdHotLine);
			}
			if (GameCanvas.lowGraphic)
			{
				this.cmdGraphicsSetting.caption = T.off + T.cauhinhthap;
			}
			else
			{
				this.cmdGraphicsSetting.caption = T.on + T.cauhinhthap;
			}
			if ((int)TemMidlet.DIVICE == 0)
			{
				mVector.addElement(this.cmdGraphicsSetting);
			}
			else
			{
				mVector.addElement(this.cmdSoundSetting);
			}
			if ((int)TemMidlet.currentIAPStore == (int)TemMidlet.NOKIA_STORE)
			{
				mVector.addElement(this.cmdNokiaInfo);
			}
		}
		else if (this.section != 1)
		{
			if (this.section == 2)
			{
			}
		}
		mVector.addElement(this.cmdThoat);
		GameCanvas.menu2.startAt(mVector, 2, T.menuChinh, false, null);
	}

	// Token: 0x06000654 RID: 1620 RVA: 0x0005F128 File Offset: 0x0005D328
	public void setScreen()
	{
		switch (this.section)
		{
		case 0:
			if (GameCanvas.h < 240)
			{
				this.hpaint = 10;
			}
			LoginScreen.tfusername.setFocus(Main.isPC);
			LoginScreen.tfpassword.setFocus(false);
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdSubMenu;
			}
			else
			{
				this.left = null;
			}
			if (LoginScreen.tfusername.getText().Length > 0)
			{
				this.center = this.cmdLogin;
			}
			else if (LoginScreen.username.Length > 0)
			{
				this.center = this.cmdPlay;
			}
			else
			{
				this.center = this.cmdQuickPlay;
			}
			break;
		case 1:
			if (!GameCanvas.isTouch)
			{
				LoginScreen.tfusername.setFocus(true);
				LoginScreen.tfpassword.setFocus(false);
			}
			this.left = this.cmdNewPlay;
			this.center = this.cmdOK;
			this.setHeightBorder(false);
			if (GameCanvas.h < 240)
			{
				this.hpaint = 10;
			}
			LoginScreen.hShowServer = 0;
			break;
		case 2:
			this.left = null;
			this.center = null;
			break;
		}
	}

	// Token: 0x06000655 RID: 1621 RVA: 0x0005F280 File Offset: 0x0005D480
	public void setHeightBorder(bool istext)
	{
		this.hBorder = LoginScreen.tfusername.height * 2 + this.hitem * 4;
		if (GameCanvas.isTouch)
		{
			this.hBorder += iCommand.hButtonCmd + 3;
		}
		else
		{
			this.hBorder += GameCanvas.hh / 8;
		}
		if (istext)
		{
			this.hBorder += this.strhelpregister.Length * GameCanvas.hText;
		}
		this.setPosCmd();
	}

	// Token: 0x06000656 RID: 1622 RVA: 0x0005F308 File Offset: 0x0005D508
	protected void doRegister()
	{
		mSystem.outz("Dzo day doi mat khau");
		if (LoginScreen.tfusername.getText().Equals(string.Empty))
		{
			GameCanvas.start_Ok_Dialog(T.chuanhapsdt);
			return;
		}
		if (LoginScreen.tfpassword.getText().Equals(string.Empty))
		{
			GameCanvas.start_Ok_Dialog(T.chuanhapmk);
			return;
		}
		if (LoginScreen.tfusername.getText().Length < 5)
		{
			GameCanvas.start_Ok_Dialog(T.nameMin6char);
			return;
		}
		string text = null;
		try
		{
			long num = long.Parse(LoginScreen.tfusername.getText());
			if (LoginScreen.tfusername.getText().Length < 8 || LoginScreen.tfusername.getText().Length > 12 || (!LoginScreen.tfusername.getText().StartsWith("0") && LoginScreen.tfusername.getText().StartsWith("84")))
			{
				text = T.sdtkhople;
			}
		}
		catch (Exception ex)
		{
			if (LoginScreen.tfusername.getText().IndexOf("@") == -1 || LoginScreen.tfusername.getText().IndexOf(".") == -1)
			{
				text = T.emailkhople;
			}
		}
		if (text != null)
		{
			GameCanvas.start_Ok_Dialog(text);
		}
	}

	// Token: 0x06000657 RID: 1623 RVA: 0x0005F470 File Offset: 0x0005D670
	public new void keyBack()
	{
		this.cmdThoat.perform();
	}

	// Token: 0x06000658 RID: 1624 RVA: 0x0005F480 File Offset: 0x0005D680
	public override void commandTab(int index, int sub)
	{
		switch (index)
		{
		case 0:
			GameCanvas.connect();
			this.login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText());
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isMelogin = false;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 1:
			GameCanvas.connect();
			this.login("1", "1");
			break;
		case 2:
			this.section = 0;
			this.setScreen();
			break;
		case 3:
			this.doMenu();
			break;
		case 4:
			GameCanvas.connect();
			this.login(LoginScreen.username, LoginScreen.password);
			break;
		}
	}

	// Token: 0x06000659 RID: 1625 RVA: 0x0005F53C File Offset: 0x0005D73C
	public override void commandMenu(int index, int sub)
	{
		base.commandMenu(index, sub);
	}

	// Token: 0x0600065A RID: 1626 RVA: 0x0005F554 File Offset: 0x0005D754
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			GameCanvas.start_Left_Dialog(T.hoithoat, new iCommand(T.exit, 10, this));
			break;
		default:
			switch (index)
			{
			case 21:
				GameCanvas.start_Left_Dialog(T.textabout1 + GameMidlet.version + "\n" + T.textabout2, new iCommand(T.nokiaprivacy, 22, this));
				break;
			case 22:
				TemMidlet.openUrl("http://teamobi.com/terms.htm");
				break;
			case 23:
				TemMidlet.instance.call(T.numberHotLine);
				break;
			}
			break;
		case 6:
			this.section = 1;
			this.setScreen();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.isMelogin = false;
			MsgDialog.isAutologin = false;
			break;
		case 7:
			GameCanvas.listIp = new List_Ip_Server_Screen();
			GameCanvas.listIp.Show();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isMelogin = false;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			break;
		case 8:
		{
			string link = string.Empty;
			if (IndoServer.isIndoSv)
			{
				link = "http://ksatriaonline.indonaga.com/forum/app/index.php?for=event&do=changepass";
			}
			else if ((int)GameCanvas.IndexServer == (int)mSystem.INDEX_SV_GLOBAL)
			{
				link = "http://forum.knightageonline.com/app/index.php?for=event&do=resetpass&lang=en";
			}
			else
			{
				link = "http://forum.knightageonline.com/app/index.php?for=event&do=resetpass&lang=store";
			}
			GameCanvas.start_Download_Dialog(T.lienhe, link);
			break;
		}
		case 9:
		{
			GameCanvas.lowGraphic = !GameCanvas.lowGraphic;
			sbyte b = (!GameCanvas.lowGraphic) ? 0 : 1;
			sbyte[] data = new sbyte[]
			{
				b
			};
			try
			{
				CRes.saveRMS("isLowDevice", data);
			}
			catch (Exception ex)
			{
			}
			break;
		}
		case 10:
			GameCanvas.start_Volume_Dialog();
			break;
		case 11:
			GameMidlet.destroy();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x0600065B RID: 1627 RVA: 0x0005F750 File Offset: 0x0005D950
	public static void loadVersionGame()
	{
		sbyte[] array = CRes.loadRMS("versionGame");
		if (array == null)
		{
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(array);
		string text = dataInputStream.readUTF();
		if (!text.Equals(GameMidlet.version))
		{
			Rms.deleteAllRecord();
		}
	}

	// Token: 0x0600065C RID: 1628 RVA: 0x0005F794 File Offset: 0x0005D994
	public static void saveversionGame()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(GameMidlet.version);
			CRes.saveRMS("versionGame", dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai  save versionGame!!! : " + ex.ToString());
		}
	}

	// Token: 0x0600065D RID: 1629 RVA: 0x0005F804 File Offset: 0x0005DA04
	private void setCmdCap()
	{
		if (this.cmdChooseServer.caption != T.maychu + ": " + GameCanvas.listServer[(int)GameCanvas.IndexServer, 0])
		{
			this.cmdChooseServer.caption = T.maychu + ": " + GameCanvas.listServer[(int)GameCanvas.IndexServer, 0];
		}
		if (GameCanvas.isTouch)
		{
			if (LoginScreen.tfusername.getText().Length > 0)
			{
				if (this.cmdUserAccount.caption != T.doi_TK_khac)
				{
					this.cmdUserAccount.caption = T.doi_TK_khac;
				}
				if (LoginScreen.tfusername.getText().Length > 13)
				{
					string text = string.Empty;
					if (!LoginScreen.tfusername.getText().Equals(LoginScreen.userSv))
					{
						text = T.choi_daco_TK + ": " + LoginScreen.tfusername.getText().Substring(0, 12) + "...";
					}
					else
					{
						text = T.choimoi;
					}
					if (this.cmdLogin.caption != text)
					{
						this.cmdLogin.caption = text;
					}
					if (this.cmdPlay.caption != text)
					{
						this.cmdPlay.caption = text;
					}
				}
				else if (this.cmdLogin.caption != T.choi_daco_TK + ": " + LoginScreen.tfusername.getText())
				{
					this.cmdLogin.caption = T.choi_daco_TK + ": " + LoginScreen.tfusername.getText();
					this.cmdPlay.caption = T.choi_daco_TK + ": " + LoginScreen.tfusername.getText();
				}
			}
			else if (LoginScreen.username.Length > 0)
			{
				if (this.cmdUserAccount.caption != T.doi_TK_khac)
				{
					this.cmdUserAccount.caption = T.doi_TK_khac;
				}
			}
			else if (this.cmdUserAccount.caption != T.daco_TK)
			{
				this.cmdUserAccount.caption = T.daco_TK;
			}
		}
		else if (LoginScreen.tfusername.getText().Length > 0)
		{
			if (LoginScreen.tfusername.getText().Length > 8)
			{
				string text2 = T.username + ": " + LoginScreen.tfusername.getText().Substring(0, 8) + "...";
				if (this.cmdUserAccount.caption != text2)
				{
					this.cmdUserAccount.caption = text2;
				}
			}
			else if (this.cmdUserAccount.caption != T.username + ": " + LoginScreen.tfusername.getText())
			{
				this.cmdUserAccount.caption = T.username + ": " + LoginScreen.tfusername.getText();
			}
		}
		else if (LoginScreen.username.Length > 0)
		{
			if (this.cmdUserAccount.caption != T.doi_TK_khac)
			{
				this.cmdUserAccount.caption = T.doi_TK_khac;
			}
		}
		else if (this.cmdUserAccount.caption != T.daco_TK)
		{
			this.cmdUserAccount.caption = T.daco_TK;
		}
	}

	// Token: 0x0600065E RID: 1630 RVA: 0x0005FB8C File Offset: 0x0005DD8C
	public void checkLoginAgain(sbyte indexSv)
	{
		try
		{
			LoginScreen.username = LoginScreen.tfusername.getText();
			LoginScreen.password = LoginScreen.tfpassword.getText();
			if (LoginScreen.username.Length > 0)
			{
				this.center = this.cmdPlay;
			}
			else
			{
				this.center = this.cmdQuickPlay;
			}
			sbyte[] array = CRes.loadRMS("isIndexServer");
			sbyte b = indexSv;
			if (array != null)
			{
				b = array[0];
			}
			if ((int)b == (int)indexSv)
			{
				sbyte[] array2 = CRes.loadRMS("user_pass");
				if (array2 != null)
				{
					try
					{
						LoginScreen.loadUser_Pass();
					}
					catch (IOException ex)
					{
					}
					GameCanvas.connect();
					if (LoginScreen.username.Length > 0)
					{
						this.login(LoginScreen.username, LoginScreen.password);
					}
					else if (LoginScreen.tfusername.getText().Length > 0)
					{
						this.login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText());
					}
				}
			}
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x0400090A RID: 2314
	public const sbyte LOGIN = 0;

	// Token: 0x0400090B RID: 2315
	public const sbyte USER_INFO = 1;

	// Token: 0x0400090C RID: 2316
	public const sbyte SERVER_INFO = 2;

	// Token: 0x0400090D RID: 2317
	public int hpaint;

	// Token: 0x0400090E RID: 2318
	public int section;

	// Token: 0x0400090F RID: 2319
	public int hitem = 10;

	// Token: 0x04000910 RID: 2320
	private int hBorder;

	// Token: 0x04000911 RID: 2321
	private int wBorder;

	// Token: 0x04000912 RID: 2322
	private int yBorder;

	// Token: 0x04000913 RID: 2323
	public static bool isAutoLogin = true;

	// Token: 0x04000914 RID: 2324
	public static bool isPaintHotLine = true;

	// Token: 0x04000915 RID: 2325
	public static sbyte isServer = 0;

	// Token: 0x04000916 RID: 2326
	public static TField tfusername;

	// Token: 0x04000917 RID: 2327
	public static TField tfpassword;

	// Token: 0x04000918 RID: 2328
	public static string username = string.Empty;

	// Token: 0x04000919 RID: 2329
	public static string password = string.Empty;

	// Token: 0x0400091A RID: 2330
	public static int hShowServer = 0;

	// Token: 0x0400091B RID: 2331
	public static sbyte indexInfoLogin = 1;

	// Token: 0x0400091C RID: 2332
	private static string[] server = new string[]
	{
		"anh Trí",
		"ku Ngân",
		"Server"
	};

	// Token: 0x0400091D RID: 2333
	public static mImage logo;

	// Token: 0x0400091E RID: 2334
	public static string userSv;

	// Token: 0x0400091F RID: 2335
	private string[] strhelpregister;

	// Token: 0x04000920 RID: 2336
	public static string ip = null;

	// Token: 0x04000921 RID: 2337
	private InputDialog input;

	// Token: 0x04000922 RID: 2338
	public static int MusicRandom = 0;

	// Token: 0x04000923 RID: 2339
	public static int wLine;

	// Token: 0x04000924 RID: 2340
	private iCommand cmdLogin;

	// Token: 0x04000925 RID: 2341
	private iCommand cmdThoat;

	// Token: 0x04000926 RID: 2342
	private iCommand cmdChooseServer;

	// Token: 0x04000927 RID: 2343
	private iCommand cmdQuickPlay;

	// Token: 0x04000928 RID: 2344
	private iCommand cmdNewPlay;

	// Token: 0x04000929 RID: 2345
	private iCommand cmdPlay;

	// Token: 0x0400092A RID: 2346
	private iCommand cmdUserAccount;

	// Token: 0x0400092B RID: 2347
	private iCommand cmdOK;

	// Token: 0x0400092C RID: 2348
	private iCommand cmdSubMenu;

	// Token: 0x0400092D RID: 2349
	private iCommand cmdChangePassword;

	// Token: 0x0400092E RID: 2350
	private iCommand cmdGraphicsSetting;

	// Token: 0x0400092F RID: 2351
	private iCommand cmdSoundSetting;

	// Token: 0x04000930 RID: 2352
	private iCommand cmdNokiaInfo;

	// Token: 0x04000931 RID: 2353
	private iCommand cmdHotLine;

	// Token: 0x04000932 RID: 2354
	private int t;

	// Token: 0x04000933 RID: 2355
	public static string strip;

	// Token: 0x04000934 RID: 2356
	private int yLoginBox;

	// Token: 0x04000935 RID: 2357
	private int wBoxText;

	// Token: 0x04000936 RID: 2358
	private int hBoxText;

	// Token: 0x04000937 RID: 2359
	private bool isPaintLogo = true;
}
