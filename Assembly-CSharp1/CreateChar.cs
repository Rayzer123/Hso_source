using System;

// Token: 0x0200007D RID: 125
public class CreateChar : MainScreen
{
	// Token: 0x060005B0 RID: 1456 RVA: 0x00053370 File Offset: 0x00051570
	public CreateChar()
	{
		if (GameCanvas.isTouch)
		{
			this.hRectChar = 182;
			this.wRectChar = 200;
		}
		this.init();
	}

	// Token: 0x060005B2 RID: 1458 RVA: 0x0005345C File Offset: 0x0005165C
	public void Show(sbyte index)
	{
		mSound.stopSoundAll();
		if (LoginScreen.MusicRandom == 0)
		{
			mSound.playMus(0, mSound.volumeMusic, true);
		}
		else
		{
			mSound.playMus(1, mSound.volumeMusic, true);
		}
		this.index = index;
		base.Show();
	}

	// Token: 0x060005B3 RID: 1459 RVA: 0x00053498 File Offset: 0x00051698
	public override void commandTab(int index, int sub)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				if (SelectCharScreen.VecSelectChar.size() == 0)
				{
					GameCanvas.login.Show();
					Session_ME.gI().close();
					GameScreen.player = new Player(0, 0, "unname", 0, 0);
				}
				else
				{
					GameCanvas.selectChar.Show();
				}
			}
		}
		else
		{
			string text = this.tfNameChar.getText();
			if (text.Length < 6)
			{
				GameCanvas.start_Ok_Dialog(T.nameMin6char);
			}
			else
			{
				Other_Players other_Players = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
				GlobalService.gI().create_char(other_Players.clazz, text, (sbyte)other_Players.hair, (sbyte)other_Players.EyeMain, (sbyte)other_Players.head, this.index);
				GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
			}
		}
		base.commandTab(index, sub);
	}

	// Token: 0x060005B4 RID: 1460 RVA: 0x00053584 File Offset: 0x00051784
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			this.selectClass = 0;
			this.indexChar++;
			this.timeChangeClass = 0;
			if (this.indexChar == 4)
			{
				MainScreen.cameraSub.xCam = -this.wRectChar / 4;
			}
			this.indexChar = base.resetSelect(this.indexChar, T.mClass.Length - 1, true);
			MainScreen.cameraSub.xTo = this.indexChar * this.wRectChar / 4;
			this.cmdclass.caption = T.mClass[this.indexChar];
			Other_Players other_Players = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			this.cmdtoc.caption = T.mCreateChar_HAIR[this.indexChar / 2][other_Players.hair % this.numHair];
			break;
		}
		case 1:
		case 2:
		case 3:
			this.selectClass = index;
			this.editChar(1);
			break;
		}
	}

	// Token: 0x060005B5 RID: 1461 RVA: 0x0005368C File Offset: 0x0005188C
	public void init()
	{
		CreateChar.VecDefaultChar.removeAllElements();
		this.center = new iCommand(T.create, 0);
		this.cmdBack = new iCommand(T.back, 1);
		if (GameCanvas.isTouch)
		{
			int num = iCommand.wButtonCmd / 2;
			if (num < this.wRectChar / 4)
			{
				num = this.wRectChar / 4;
			}
			this.center.setPos(GameCanvas.hw - num, GameCanvas.hh + this.hRectChar / 2 + 4, null, this.center.caption);
			this.cmdBack.setPos(GameCanvas.hw + num, GameCanvas.hh + this.hRectChar / 2 + 4, null, this.cmdBack.caption);
		}
		this.left = this.cmdBack;
		for (int i = 0; i < 4; i++)
		{
			Other_Players other_Players = new Other_Players(i, 0, string.Empty, 0, 0);
			other_Players.clazz = (sbyte)i;
			other_Players.leg = i;
			other_Players.body = i;
			other_Players.hat = -1;
			other_Players.head = 0;
			other_Players.hair = i;
			other_Players.eye = 8 + i;
			other_Players.EyeMain = other_Players.eye;
			other_Players.Direction = 0;
			other_Players.wing = -1;
			other_Players.x = this.wRectChar / 5 + i * this.wRectChar / 4;
			other_Players.y = this.hRectChar / 5 * 2;
			other_Players.weaponType = 0;
			CreateChar.VecDefaultChar.addElement(other_Players);
		}
		this.mselect = new sbyte[4];
		this.indexChar = CRes.random(4);
		this.selectClass = 0;
		MainScreen.cameraSub.setAll(CreateChar.VecDefaultChar.size() * this.wRectChar / 4, 0, this.indexChar * this.wRectChar / 4, 0);
		this.tfNameChar = new TField(GameCanvas.hw - this.wRectChar / 2 + this.wRectChar / 5 - 25, GameCanvas.hh - this.hRectChar / 2 + this.hRectChar / 2 + 10, 60);
		this.tfNameChar.showSubTextField = true;
		if (!GameCanvas.isTouch)
		{
			this.tfNameChar.setFocus(true);
		}
		else
		{
			this.cmdclass = new iCommand(T.mClass[this.indexChar], 0, this);
			this.vecCmd.addElement(this.cmdclass);
			Other_Players other_Players2 = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			this.cmdtoc = new iCommand(T.mCreateChar_HAIR[this.indexChar / 2][other_Players2.hair % this.numHair], 1, this);
			this.vecCmd.addElement(this.cmdtoc);
			int num2 = other_Players2.eye;
			if (num2 < 8)
			{
				num2 = other_Players2.EyeMain;
			}
			this.cmdmat = new iCommand(T.mCreateChar_EYE_FACE[0][num2 - 8], 2, this);
			this.vecCmd.addElement(this.cmdmat);
			this.cmddau = new iCommand(T.mCreateChar_EYE_FACE[1][other_Players2.head], 3, this);
			this.vecCmd.addElement(this.cmddau);
			int num3 = GameCanvas.hw - this.wRectChar / 2;
			int num4 = GameCanvas.hh - this.hRectChar / 2 - GameCanvas.hCommand / 2;
			for (int j = 0; j < this.vecCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecCmd.elementAt(j);
				iCommand.setPos(num3 + this.wRectChar / 3 * 2, num4 + this.hRectChar / 5 * (j + 1) + 5, PaintInfoGameScreen.fraButton2, iCommand.caption);
			}
		}
	}

	// Token: 0x060005B6 RID: 1462 RVA: 0x00053A2C File Offset: 0x00051C2C
	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paintLight(g);
		AvMain.paintTabNew(g, GameCanvas.hw - this.wRectChar / 2, GameCanvas.hh - this.hRectChar / 2 - GameCanvas.hCommand / 2, this.wRectChar, this.hRectChar, true, 0);
		g.translate(GameCanvas.hw - this.wRectChar / 2, GameCanvas.hh - this.hRectChar / 2 - GameCanvas.hCommand / 2);
		Other_Players other_Players = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
		for (int i = 0; i < T.textCreateChar.Length; i++)
		{
			mFont.tahoma_7b_black.drawString(g, T.textCreateChar[i], this.wRectChar / 3 * 2, this.hRectChar / 5 * i + this.hRectChar / 10, 2, mGraphics.isFalse);
		}
		if (!GameCanvas.isTouch)
		{
			AvMain.FontBorderColor(g, T.mClass[this.indexChar], this.wRectChar / 3 * 2, this.hRectChar / 5, 2, 2);
			AvMain.FontBorderColor(g, T.mCreateChar_HAIR[this.indexChar / 2][other_Players.hair % this.numHair], this.wRectChar / 3 * 2, this.hRectChar / 5 * 2, 2, 2);
			int num = other_Players.eye;
			if (num < 8)
			{
				num = other_Players.EyeMain;
			}
			AvMain.FontBorderColor(g, T.mCreateChar_EYE_FACE[0][num - 8], this.wRectChar / 3 * 2, this.hRectChar / 5 * 3, 2, 2);
			AvMain.FontBorderColor(g, T.mCreateChar_EYE_FACE[1][other_Players.head], this.wRectChar / 3 * 2, this.hRectChar / 5 * 4, 2, 2);
		}
		if (!GameCanvas.isTouch)
		{
			g.drawRegion(MainObject.focus, 0, 0, 11, 9, 5, this.wRectChar / 3 * 2 - 35 - this.fFocus / 2 % 4, this.hRectChar / 5 * (this.selectClass + 1) + 4, 3, mGraphics.isFalse);
			g.drawRegion(MainObject.focus, 0, 0, 11, 9, 6, this.wRectChar / 3 * 2 + 35 + this.fFocus / 2 % 4, this.hRectChar / 5 * (this.selectClass + 1) + 4, 3, mGraphics.isFalse);
		}
		mFont.tahoma_7_black.drawString(g, T.namePlayer, this.wRectChar / 5 + 4, this.hRectChar / 2 + 5, 2, mGraphics.isFalse);
		g.setClip(8, 2, this.wRectChar / 5 * 2 - 12, this.hRectChar - 4);
		g.translate(-MainScreen.cameraSub.xCam, 0);
		for (int j = 0; j < CreateChar.VecDefaultChar.size(); j++)
		{
			Other_Players other_Players2 = (Other_Players)CreateChar.VecDefaultChar.elementAt(j);
			if (j == 0)
			{
				other_Players2.paintShowPlayer(g, other_Players2.x + this.wRectChar / 4 * CreateChar.VecDefaultChar.size(), other_Players2.y, other_Players2.Direction);
			}
			if (j == CreateChar.VecDefaultChar.size() - 1)
			{
				other_Players2.paintShowPlayer(g, other_Players2.x - this.wRectChar / 4 * CreateChar.VecDefaultChar.size(), other_Players2.y, other_Players2.Direction);
			}
			other_Players2.paintPlayer(g, -1);
			if (other_Players2.Action == 2)
			{
				other_Players2.PlashNow.update(other_Players2);
			}
			else if (other_Players2.Action == 1)
			{
				other_Players2.f++;
				if (other_Players2.f > other_Players2.A_Move.Length - 1)
				{
					other_Players2.f = 0;
				}
				other_Players2.frame = (int)other_Players2.A_Move[other_Players2.f];
			}
			else
			{
				other_Players2.updateActionPerson();
			}
			other_Players2.updateEye();
		}
		GameCanvas.resetTrans(g);
		for (int k = 0; k < this.vecCmd.size(); k++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(k);
			iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
		}
		this.tfNameChar.paint(g);
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
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 0, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - LoginScreen.wLine + ((!mSystem.isIphone) ? 0 : 14), 10, LoginScreen.wLine, 1, mGraphics.isFalse);
		}
		base.paint(g);
	}

	// Token: 0x060005B7 RID: 1463 RVA: 0x00053EF8 File Offset: 0x000520F8
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
		if (this.timeChangeClass == 0)
		{
			Other_Players other_Players = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			other_Players.Direction = 0;
		}
		else if (this.timeChangeClass == 30 || this.timeChangeClass == 10)
		{
			Other_Players other_Players2 = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			other_Players2.Action = 2;
			other_Players2.f = 0;
			other_Players2.beginFire();
			other_Players2.PlashNow.setPlash((int)other_Players2.clazz);
		}
		else if (this.timeChangeClass == 50)
		{
			Other_Players other_Players3 = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			other_Players3.Action = 1;
			other_Players3.f = 0;
		}
		else if (this.timeChangeClass > 80)
		{
			Other_Players other_Players4 = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
			this.timeChangeClass = 1;
			other_Players4.Action = 0;
			other_Players4.f = 0;
			other_Players4.Direction = ++other_Players4.Direction % 4;
		}
		this.timeChangeClass++;
		this.tfNameChar.update();
		this.fFocus++;
		MainScreen.cameraSub.UpdateCameraCreate();
		MainScreen.cameraSub.UpdateCameraCreate();
		BackGround.updateSky();
	}

	// Token: 0x060005B8 RID: 1464 RVA: 0x00054084 File Offset: 0x00052284
	public override void updatekey()
	{
		Cout.LogWarning(" thong tin " + this.tfNameChar.isFocus);
		if (this.tfNameChar != null && !this.tfNameChar.isFocus)
		{
			if (GameCanvas.keyMyHold[4] && !Main.isPC)
			{
				if (this.selectClass == 0)
				{
					this.indexChar--;
					this.timeChangeClass = 0;
				}
				else
				{
					this.editChar(-1);
				}
				GameCanvas.clearKeyHold(4);
				this.tfNameChar.caretPos = this.tfNameChar.getText().Length + 1;
			}
			else if (GameCanvas.keyMyHold[6] && !Main.isPC)
			{
				if (this.selectClass == 0)
				{
					this.indexChar++;
					this.timeChangeClass = 0;
				}
				else
				{
					this.editChar(1);
				}
				GameCanvas.clearKeyHold(6);
				this.tfNameChar.caretPos = this.tfNameChar.getText().Length + 1;
			}
			else if (GameCanvas.keyMyHold[2])
			{
				this.selectClass--;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.selectClass++;
				GameCanvas.clearKeyHold(8);
			}
		}
		this.selectClass = base.resetSelect(this.selectClass, T.textCreateChar.Length - 1, true);
		if (this.indexChar == 4)
		{
			MainScreen.cameraSub.xCam = -this.wRectChar / 4;
		}
		else if (this.indexChar == -1)
		{
			MainScreen.cameraSub.xCam = 4 * this.wRectChar / 4;
		}
		this.indexChar = base.resetSelect(this.indexChar, T.mClass.Length - 1, true);
		MainScreen.cameraSub.xTo = this.indexChar * this.wRectChar / 4;
		if (this.tfNameChar.isFocusedz())
		{
			if (Main.isPC)
			{
				this.right = this.tfNameChar.setCmdClear();
			}
		}
		else
		{
			this.right = null;
		}
		if (GameCanvas.keyMyPressed[3])
		{
			this.direction = (this.direction + 1) % 4;
		}
		base.updatekey();
	}

	// Token: 0x060005B9 RID: 1465 RVA: 0x000542D4 File Offset: 0x000524D4
	public void editChar(int i)
	{
		Other_Players other_Players = (Other_Players)CreateChar.VecDefaultChar.elementAt(this.indexChar);
		switch (this.selectClass)
		{
		case 1:
			other_Players.hair += i;
			other_Players.hair = this.indexChar / this.numHair * this.numHair + base.resetSelect(other_Players.hair - this.indexChar / this.numHair * this.numHair, this.numHair - 1, true);
			if (GameCanvas.isTouch)
			{
				this.cmdtoc.caption = T.mCreateChar_HAIR[this.indexChar / 2][other_Players.hair % this.numHair];
			}
			break;
		case 2:
			other_Players.eye += i;
			other_Players.eye = 8 + this.indexChar / this.numEye * this.numEye + base.resetSelect(other_Players.eye - 8 - this.indexChar / this.numEye * this.numEye, this.numEye - 1, true);
			other_Players.EyeMain = other_Players.eye;
			mSystem.outz("eye" + other_Players.eye);
			if (GameCanvas.isTouch)
			{
				int num = other_Players.eye;
				if (num < 8)
				{
					num = other_Players.EyeMain;
				}
				this.cmdmat.caption = T.mCreateChar_EYE_FACE[0][num - 8];
			}
			break;
		case 3:
			other_Players.head += i;
			other_Players.head = base.resetSelect(other_Players.head, T.mCreateChar_EYE_FACE[1].Length - 1, true);
			if (GameCanvas.isTouch)
			{
				this.cmddau.caption = T.mCreateChar_EYE_FACE[1][other_Players.head];
			}
			break;
		}
	}

	// Token: 0x060005BA RID: 1466 RVA: 0x000544AC File Offset: 0x000526AC
	public override void keyPress(int keyCode)
	{
		if (this.tfNameChar.isFocusedz())
		{
			this.tfNameChar.keyPressed(keyCode);
		}
		base.keyPress(keyCode);
	}

	// Token: 0x060005BB RID: 1467 RVA: 0x000544E0 File Offset: 0x000526E0
	public override void updatePointer()
	{
		for (int i = 0; i < this.vecCmd.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecCmd.elementAt(i);
			iCommand.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x060005BC RID: 1468 RVA: 0x00054528 File Offset: 0x00052728
	public override void keyBack()
	{
		this.cmdBack.perform();
	}

	// Token: 0x0400081F RID: 2079
	public const int SELECT_CLASS = 0;

	// Token: 0x04000820 RID: 2080
	private int wRectChar = 180;

	// Token: 0x04000821 RID: 2081
	private int hRectChar = 160;

	// Token: 0x04000822 RID: 2082
	public TField tfNameChar;

	// Token: 0x04000823 RID: 2083
	public static mVector VecDefaultChar = new mVector("CreateChar VecDefaultchar");

	// Token: 0x04000824 RID: 2084
	private int frame;

	// Token: 0x04000825 RID: 2085
	private int timeChangeClass;

	// Token: 0x04000826 RID: 2086
	private int fFocus;

	// Token: 0x04000827 RID: 2087
	private int selectClass;

	// Token: 0x04000828 RID: 2088
	private int indexChar;

	// Token: 0x04000829 RID: 2089
	private sbyte[] mselect;

	// Token: 0x0400082A RID: 2090
	private sbyte[][] mCreateChar = mSystem.new_M_Byte(4, 3);

	// Token: 0x0400082B RID: 2091
	private sbyte[][] mEye = new sbyte[][]
	{
		new sbyte[]
		{
			8,
			9
		},
		new sbyte[]
		{
			10,
			11
		}
	};

	// Token: 0x0400082C RID: 2092
	private sbyte[][] mHair = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			1
		},
		new sbyte[]
		{
			2,
			3
		}
	};

	// Token: 0x0400082D RID: 2093
	private int numHair = 2;

	// Token: 0x0400082E RID: 2094
	private int numEye = 2;

	// Token: 0x0400082F RID: 2095
	private sbyte index;

	// Token: 0x04000830 RID: 2096
	private mVector vecCmd = new mVector("CreateChar veccmd");

	// Token: 0x04000831 RID: 2097
	private iCommand cmdclass;

	// Token: 0x04000832 RID: 2098
	private iCommand cmdtoc;

	// Token: 0x04000833 RID: 2099
	private iCommand cmdmat;

	// Token: 0x04000834 RID: 2100
	private iCommand cmddau;

	// Token: 0x04000835 RID: 2101
	private iCommand cmdBack;

	// Token: 0x04000836 RID: 2102
	private int direction;

	// Token: 0x04000837 RID: 2103
	private int cout;
}
