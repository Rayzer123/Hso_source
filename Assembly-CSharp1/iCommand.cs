using System;

// Token: 0x020000A7 RID: 167
public class iCommand
{
	// Token: 0x0600082F RID: 2095 RVA: 0x0008E45C File Offset: 0x0008C65C
	public iCommand(string caption, IAction action)
	{
		this.caption = caption;
		this.action = action;
	}

	// Token: 0x06000830 RID: 2096 RVA: 0x0008E4A0 File Offset: 0x0008C6A0
	public iCommand(string caption, int type, object obj, AvMain pointer)
	{
		this.caption = caption;
		this.indexMenu = (sbyte)type;
		this.Pointer = pointer;
		this.obj = obj;
	}

	// Token: 0x06000831 RID: 2097 RVA: 0x0008E4F4 File Offset: 0x0008C6F4
	public iCommand(string caption, int type)
	{
		this.caption = caption;
		this.indexMenu = (sbyte)type;
	}

	// Token: 0x06000832 RID: 2098 RVA: 0x0008E52C File Offset: 0x0008C72C
	public iCommand()
	{
	}

	// Token: 0x06000833 RID: 2099 RVA: 0x0008E560 File Offset: 0x0008C760
	public iCommand(string caption, int type, AvMain pointer)
	{
		this.caption = caption;
		this.indexMenu = (sbyte)type;
		this.Pointer = pointer;
	}

	// Token: 0x06000834 RID: 2100 RVA: 0x0008E5AC File Offset: 0x0008C7AC
	public iCommand(string caption, int type, int subType, AvMain pointer)
	{
		this.caption = caption;
		this.indexMenu = (sbyte)type;
		this.subIndex = (sbyte)subType;
		this.Pointer = pointer;
	}

	// Token: 0x06000835 RID: 2101 RVA: 0x0008E600 File Offset: 0x0008C800
	public iCommand(string caption, int type, int subIndex)
	{
		this.caption = caption;
		this.indexMenu = (sbyte)type;
		this.subIndex = (sbyte)subIndex;
	}

	// Token: 0x06000837 RID: 2103 RVA: 0x0008E650 File Offset: 0x0008C850
	public void perform(string str)
	{
		if (this.actionChat != null)
		{
			this.actionChat(str);
		}
	}

	// Token: 0x06000838 RID: 2104 RVA: 0x0008E66C File Offset: 0x0008C86C
	public void setFraCaption(FrameImage fra)
	{
		this.fraImgCaption = fra;
		this.wimgCaption = this.fraImgCaption.frameWidth;
		this.himgCaption = this.fraImgCaption.frameHeight;
		this.nframe = this.fraImgCaption.nFrame;
		this.beginframe = 0;
		if (GameCanvas.isSmallScreen)
		{
			this.wstr = mFont.tahoma_7_white.getWidth(this.caption);
		}
		else
		{
			this.wstr = mFont.tahoma_7b_white.getWidth(this.caption);
		}
	}

	// Token: 0x06000839 RID: 2105 RVA: 0x0008E6F8 File Offset: 0x0008C8F8
	public void setFraCaption(FrameImage fra, int nframe, int beginframe)
	{
		this.fraImgCaption = fra;
		this.wimgCaption = this.fraImgCaption.frameWidth;
		this.himgCaption = this.fraImgCaption.frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (GameCanvas.isSmallScreen)
		{
			this.wstr = mFont.tahoma_7_white.getWidth(this.caption);
		}
		else
		{
			this.wstr = mFont.tahoma_7b_white.getWidth(this.caption);
		}
	}

	// Token: 0x0600083A RID: 2106 RVA: 0x0008E778 File Offset: 0x0008C978
	public void setFraCaption(FrameImage[] fra, int nframe, int beginframe)
	{
		this.fraImgCaptionArr = fra;
		this.wimgCaption = this.fraImgCaptionArr[0].frameWidth;
		this.himgCaption = this.fraImgCaptionArr[0].frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (GameCanvas.isSmallScreen)
		{
			this.wstr = mFont.tahoma_7_white.getWidth(this.caption);
		}
		else
		{
			this.wstr = mFont.tahoma_7b_white.getWidth(this.caption);
		}
	}

	// Token: 0x0600083B RID: 2107 RVA: 0x0008E7FC File Offset: 0x0008C9FC
	public void setPosImg(int x, int y, FrameImage fra, int nframe, int beginframe)
	{
		this.xCmd = x;
		this.yCmd = y;
		this.fraImgCaption = fra;
		this.wimgCaption = this.fraImgCaption.frameWidth;
		this.himgCaption = this.fraImgCaption.frameHeight;
		this.nframe = nframe;
		this.beginframe = beginframe;
		if (this.fraImageCmd != null)
		{
			this.wimgCmd = this.fraImageCmd.frameWidth;
			this.himgCmd = this.fraImageCmd.frameHeight;
			if (this.wimgCmd < 28)
			{
				this.wimgCmd = 28;
			}
			if (this.himgCmd < 28)
			{
				this.himgCmd = 28;
			}
		}
		else
		{
			this.wimgCmd = 70;
			this.himgCmd = iCommand.hButtonCmd;
		}
	}

	// Token: 0x0600083C RID: 2108 RVA: 0x0008E8C0 File Offset: 0x0008CAC0
	public void setPos(int x, int y, FrameImage fra, string caption)
	{
		this.caption = caption;
		this.xCmd = x;
		this.yCmd = y;
		this.fraImageCmd = fra;
		if (this.fraImageCmd != null)
		{
			this.wimgCmd = this.fraImageCmd.frameWidth;
			this.himgCmd = this.fraImageCmd.frameHeight;
			if (this.wimgCmd < 28)
			{
				this.wimgCmd = 28;
			}
			if (this.himgCmd < 28)
			{
				this.himgCmd = 28;
			}
		}
		else
		{
			this.wimgCmd = 70;
			this.himgCmd = iCommand.hButtonCmd;
		}
	}

	// Token: 0x0600083D RID: 2109 RVA: 0x0008E95C File Offset: 0x0008CB5C
	public void setPos_BoxText(int x, int y, FrameImage fra, string caption, int wBox, int hBox)
	{
		this.isButtonDai = true;
		this.caption = caption;
		this.xCmd = x;
		this.yCmd = y;
		this.fraImageCmd = fra;
		if (this.fraImageCmd != null)
		{
			this.wimgCmd = this.fraImageCmd.frameWidth;
			this.himgCmd = this.fraImageCmd.frameHeight;
			if (this.wimgCmd < 28)
			{
				this.wimgCmd = 28;
			}
			if (this.himgCmd < 28)
			{
				this.himgCmd = 28;
			}
		}
		else
		{
			this.wimgCmd = wBox;
			this.himgCmd = hBox;
		}
	}

	// Token: 0x0600083E RID: 2110 RVA: 0x0008E9FC File Offset: 0x0008CBFC
	public void setPos_ShowName(int x, int y, FrameImage fra, string clickcaption, int xdich, int ydich)
	{
		this.caption = string.Empty;
		this.clickCaption = clickcaption;
		this.xCmd = x;
		this.yCmd = y;
		this.xdich = xdich;
		this.ydich = ydich;
		this.fraImageCmd = fra;
		if (this.fraImageCmd != null)
		{
			this.wimgCmd = this.fraImageCmd.frameWidth;
			this.himgCmd = this.fraImageCmd.frameHeight;
			if (this.wimgCmd < 28)
			{
				this.wimgCmd = 28;
			}
			if (this.himgCmd < 28)
			{
				this.himgCmd = 28;
			}
		}
		else
		{
			this.wimgCmd = 70;
			this.himgCmd = iCommand.hButtonCmd;
		}
	}

	// Token: 0x0600083F RID: 2111 RVA: 0x0008EAB0 File Offset: 0x0008CCB0
	public void setPosXY(int x, int y)
	{
		this.xCmd = x;
		this.yCmd = y;
	}

	// Token: 0x06000840 RID: 2112 RVA: 0x0008EAC0 File Offset: 0x0008CCC0
	public void perform()
	{
		if (GameCanvas.menu2.isShowMenu && (GameCanvas.menu2.runText == null || GameCanvas.menu2.runText.checkDlgStep()))
		{
			GameCanvas.menu2.doCloseMenu();
		}
		if (this.action != null)
		{
			this.action.perform();
			GameCanvas.isPointerSelect = false;
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			mSound.playSound(41, mSound.volumeSound);
		}
		else
		{
			mSound.playSound(41, mSound.volumeSound);
			if (this.Pointer != null)
			{
				if (this.obj != null)
				{
					this.Pointer.commandPointer((int)this.indexMenu, this.obj);
				}
				else
				{
					this.Pointer.commandPointer((int)this.indexMenu, (int)this.subIndex);
				}
				GameCanvas.isPointerSelect = false;
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
			}
			else
			{
				if (GameCanvas.currentDialog != null)
				{
					GameCanvas.currentDialog.commandTab((int)this.indexMenu, (int)this.subIndex);
					GameCanvas.isPointerSelect = false;
					GameCanvas.clearKeyHold();
					GameCanvas.clearKeyPressed();
					return;
				}
				if (ChatTextField.isShow)
				{
					ChatTextField.gI().commandTab((int)this.indexMenu, (int)this.subIndex);
					return;
				}
				if (GameCanvas.menu2.isShowMenu)
				{
					GameCanvas.currentScreen.commandMenu((int)this.indexMenu, (int)this.subIndex);
					return;
				}
				if (GameCanvas.subDialog != null)
				{
					GameCanvas.subDialog.commandTab((int)this.indexMenu, (int)this.subIndex);
					return;
				}
				GameCanvas.currentScreen.commandTab((int)this.indexMenu, (int)this.subIndex);
				return;
			}
		}
	}

	// Token: 0x06000841 RID: 2113 RVA: 0x0008EC68 File Offset: 0x0008CE68
	public void update()
	{
	}

	// Token: 0x06000842 RID: 2114 RVA: 0x0008EC6C File Offset: 0x0008CE6C
	public void paint(mGraphics g, int x, int y)
	{
		if (Main.isPC && this.caption == null)
		{
			return;
		}
		if (this.isNotShowTab)
		{
			return;
		}
		if (this.isPosCmd())
		{
			if (this.fraImageCmd != null)
			{
				this.fraImageCmd.drawFrame(this.frameCmd, this.xCmd, this.yCmd, 0, 3, g);
			}
			else
			{
				this.paintbutton(g, this.xCmd, this.yCmd);
			}
			this.paintCaptionImage(g, this.xCmd, this.yCmd - 6, 2);
		}
		else
		{
			if (this.fraImageCmd != null)
			{
				this.fraImageCmd.drawFrame(this.frameCmd, x, y, 0, 3, g);
			}
			else
			{
				this.paintbutton(g, x, y);
			}
			this.paintCaptionImage(g, x, y - 6, 2);
		}
	}

	// Token: 0x06000843 RID: 2115 RVA: 0x0008ED40 File Offset: 0x0008CF40
	public void paintCaptionImage(mGraphics g, int x, int y, int pos)
	{
		if (this.caption == null)
		{
			return;
		}
		int num = 0;
		if (this.fraImgCaptionArr == null)
		{
			if (this.fraImgCaption != null)
			{
				if (pos == 2)
				{
					this.fraImgCaption.drawFrame(this.beginframe + GameCanvas.gameTick / 2 % this.nframe, x - this.wimgCaption / 2 - this.wstr / 2, y + this.himgCaption / 2 - 3, 0, 3, g);
					num = this.wimgCaption / 2;
				}
				else if (pos == 0)
				{
					this.fraImgCaption.drawFrame(this.beginframe + GameCanvas.gameTick / 2 % this.nframe, x + this.wimgCaption / 2, y + this.himgCaption / 2 - 4, 0, 3, g);
					num = this.wimgCaption + 6;
				}
			}
		}
		else if (pos == 2)
		{
			this.fraImgCaptionArr[GameCanvas.gameTick / 2 % this.nframe].drawFrame(0, x - this.wimgCaption / 2 - this.wstr / 2, y + this.himgCaption / 2 - 3, 0, 3, g);
			num = this.wimgCaption / 2;
		}
		else if (pos == 0)
		{
			this.fraImgCaptionArr[GameCanvas.gameTick / 2 % this.nframe].drawFrame(0, x + this.wimgCaption / 2, y + this.himgCaption / 2 - 4, 0, 3, g);
			num = this.wimgCaption + 6;
		}
		if (!this.isButtonDai)
		{
			if (GameCanvas.isSmallScreen)
			{
				mFont.tahoma_7_white.drawString(g, this.caption, x + num, y, pos, mGraphics.isTrue);
			}
			else
			{
				AvMain.Font3dColor(g, this.caption, x + num, y, pos, 0);
			}
		}
		else if (GameCanvas.isSmallScreen)
		{
			mFont.tahoma_7_white.drawString(g, this.caption, x + num + this.wimgCmd / 2, y + this.himgCmd / 2 + 1, pos, mGraphics.isTrue);
		}
		else
		{
			AvMain.Font3dColor(g, this.caption, x + num + this.wimgCmd / 2, y + this.himgCmd / 2 + 1, pos, 0);
		}
	}

	// Token: 0x06000844 RID: 2116 RVA: 0x0008EF64 File Offset: 0x0008D164
	public void paintCaptionImageMenu(mGraphics g, int x, int y, int pos)
	{
		int num = 0;
		if (this.fraImgCaptionArr == null)
		{
			if (this.fraImgCaption != null)
			{
				if (pos == 2)
				{
					this.fraImgCaption.drawFrame(this.beginframe + GameCanvas.gameTick / 2 % this.nframe, x - this.wimgCaption / 2 - this.wstr / 2, y + this.himgCaption / 2, 0, 3, g);
					num = this.wimgCaption / 2;
				}
				else if (pos == 0)
				{
					this.fraImgCaption.drawFrame(this.beginframe + GameCanvas.gameTick / 2 % this.nframe, x + this.wimgCaption / 2, y + this.himgCaption / 2, 0, 3, g);
					num = this.wimgCaption + 6;
				}
			}
		}
		else if (pos == 2)
		{
			this.fraImgCaptionArr[GameCanvas.gameTick / 2 % this.nframe].drawFrame(0, x - this.wimgCaption / 2 - this.wstr / 2, y + this.himgCaption / 2 - 3, 0, 3, g);
			num = this.wimgCaption / 2;
		}
		else if (pos == 0)
		{
			this.fraImgCaptionArr[GameCanvas.gameTick / 2 % this.nframe].drawFrame(0, x + this.wimgCaption / 2, y + this.himgCaption / 2 - 4, 0, 3, g);
			num = this.wimgCaption + 6;
		}
		if (GameCanvas.isSmallScreen)
		{
			mFont.tahoma_7_white.drawString(g, this.caption, x + num, y, pos, mGraphics.isFalse);
		}
		else
		{
			AvMain.Font3dColorAndColor(g, this.caption, x + num, y, pos, 7, 0);
		}
	}

	// Token: 0x06000845 RID: 2117 RVA: 0x0008F104 File Offset: 0x0008D304
	public void paintClickCaption(mGraphics g, int x, int y, int pos)
	{
		if (this.frameCmd == 1 && this.clickCaption.Length > 0)
		{
			AvMain.Font3dColor(g, this.clickCaption, x + this.xdich, y + this.ydich, pos, 0);
		}
	}

	// Token: 0x06000846 RID: 2118 RVA: 0x0008F150 File Offset: 0x0008D350
	public void paintImage(mGraphics g, int x, int y, int pos, int typePaint)
	{
		if (this.fraImgCaption != null)
		{
			if (typePaint == 0)
			{
				this.fraImgCaption.drawFrame(this.beginframe + GameCanvas.gameTick / 2 % this.nframe, x, y + this.himgCaption / 2, 0, pos, g);
			}
			else if (typePaint == 1)
			{
				int num = (this.beginframe + this.frameCmd != 1) ? 0 : 1;
				if (num > this.nframe)
				{
					num = this.beginframe - 1;
				}
				this.fraImgCaption.drawFrame(num, x, y + this.himgCaption / 2, 0, pos, g);
			}
			else
			{
				this.fraImgCaption.drawFrame(this.beginframe, x, y + this.himgCaption / 2, 0, pos, g);
			}
		}
	}

	// Token: 0x06000847 RID: 2119 RVA: 0x0008F21C File Offset: 0x0008D41C
	public void updatePointer()
	{
		if (!this.isButtonDai)
		{
			if (this.isPosCmd())
			{
				if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
				{
					if (GameCanvas.isPoint(this.xCmd - this.wimgCmd / 2 - 5, this.yCmd - this.himgCmd / 2 - 5, this.wimgCmd + 10, this.himgCmd + 10))
					{
						this.frameCmd = 1;
					}
					else
					{
						this.frameCmd = 0;
					}
				}
				else
				{
					this.frameCmd = 0;
				}
				if (GameCanvas.isPointSelect(this.xCmd - this.wimgCmd / 2 - 5, this.yCmd - this.himgCmd / 2 - 5, this.wimgCmd + 10, this.himgCmd + 10))
				{
					this.perform();
					GameCanvas.isPointerSelect = false;
					this.frameCmd = 0;
				}
			}
		}
		else if (this.isPosCmd())
		{
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				if (GameCanvas.isPoint(this.xCmd - 5, this.yCmd - 5, this.wimgCmd + 10, this.himgCmd + 10))
				{
					this.isSelect = true;
					this.frameCmd = 1;
				}
				else
				{
					this.frameCmd = 0;
					this.isSelect = false;
				}
			}
			else
			{
				this.frameCmd = 0;
				this.isSelect = false;
			}
			if (GameCanvas.isPointSelect(this.xCmd - 5, this.yCmd - 5, this.wimgCmd + 10, this.himgCmd + 10))
			{
				this.perform();
				GameCanvas.isPointerSelect = false;
				this.frameCmd = 0;
				this.isSelect = false;
			}
		}
	}

	// Token: 0x06000848 RID: 2120 RVA: 0x0008F3CC File Offset: 0x0008D5CC
	public void updatePointer(int cmx, int cmy)
	{
		if (this.isPosCmd())
		{
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				if (GameCanvas.isPoint(this.xCmd - this.wimgCmd / 2 - 3 - cmx, this.yCmd - this.himgCmd / 2 - 3 - cmy, this.wimgCmd + 6, this.himgCmd + 6))
				{
					this.frameCmd = 1;
				}
				else
				{
					this.frameCmd = 0;
				}
			}
			else
			{
				this.frameCmd = 0;
			}
			if (GameCanvas.isPointSelect(this.xCmd - this.wimgCmd / 2 - 3 - cmx, this.yCmd - this.himgCmd / 2 - 3 - cmy, this.wimgCmd + 6, this.himgCmd + 6))
			{
				this.perform();
				GameCanvas.isPointerSelect = false;
				this.frameCmd = 0;
			}
		}
	}

	// Token: 0x06000849 RID: 2121 RVA: 0x0008F4AC File Offset: 0x0008D6AC
	public void updatePointerShow(int cmx, int cmy)
	{
		if (this.isPosCmd())
		{
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				if (GameCanvas.isPoint(this.xCmd - this.wimgCmd / 2 - 3 - cmx, this.yCmd - this.himgCmd / 2 - 3 - cmy, this.wimgCmd + 6, this.himgCmd + 6))
				{
					this.frameCmd = 1;
				}
				else
				{
					this.frameCmd = 0;
				}
			}
			else
			{
				this.frameCmd = 0;
			}
		}
	}

	// Token: 0x0600084A RID: 2122 RVA: 0x0008F538 File Offset: 0x0008D738
	public void paintbutton(mGraphics g, int x, int y)
	{
		if (GameCanvas.isTouch)
		{
			if (!this.isButtonDai)
			{
				PaintInfoGameScreen.fraButton.drawFrame(this.frameCmd, x, y, 0, 3, g);
			}
			else
			{
				AvMain.paintDialog(g, x, y, this.wimgCmd, this.himgCmd, (!this.isSelect) ? 2 : 1);
			}
		}
		else if (!this.isButtonDai)
		{
			AvMain.paintDialog(g, x - iCommand.wButtonCmd / 2, y - iCommand.hButtonCmd / 2, iCommand.wButtonCmd, iCommand.hButtonCmd, (!this.isSelect) ? 2 : 1);
		}
		else
		{
			AvMain.paintDialog(g, x, y, this.wimgCmd, this.himgCmd, (!this.isSelect) ? 2 : 1);
		}
	}

	// Token: 0x0600084B RID: 2123 RVA: 0x0008F60C File Offset: 0x0008D80C
	public bool isPosCmd()
	{
		return this.xCmd > 0 && this.yCmd > 0;
	}

	// Token: 0x04000CFA RID: 3322
	public bool isButtonDai;

	// Token: 0x04000CFB RID: 3323
	public ActionChat actionChat;

	// Token: 0x04000CFC RID: 3324
	public string caption;

	// Token: 0x04000CFD RID: 3325
	public string clickCaption = string.Empty;

	// Token: 0x04000CFE RID: 3326
	public string[] subCaption;

	// Token: 0x04000CFF RID: 3327
	public IAction action;

	// Token: 0x04000D00 RID: 3328
	public AvMain Pointer;

	// Token: 0x04000D01 RID: 3329
	public sbyte indexMenu;

	// Token: 0x04000D02 RID: 3330
	public sbyte subIndex = -1;

	// Token: 0x04000D03 RID: 3331
	public bool isSelect;

	// Token: 0x04000D04 RID: 3332
	public bool isNotShowTab;

	// Token: 0x04000D05 RID: 3333
	private int nframe;

	// Token: 0x04000D06 RID: 3334
	private int beginframe;

	// Token: 0x04000D07 RID: 3335
	private FrameImage fraImgCaption;

	// Token: 0x04000D08 RID: 3336
	private FrameImage fraImageCmd;

	// Token: 0x04000D09 RID: 3337
	private int wimgCaption;

	// Token: 0x04000D0A RID: 3338
	private int himgCaption;

	// Token: 0x04000D0B RID: 3339
	private int wstr;

	// Token: 0x04000D0C RID: 3340
	private int wimgCmd;

	// Token: 0x04000D0D RID: 3341
	private int himgCmd;

	// Token: 0x04000D0E RID: 3342
	public int xCmd = -1;

	// Token: 0x04000D0F RID: 3343
	public int yCmd = -1;

	// Token: 0x04000D10 RID: 3344
	public int frameCmd;

	// Token: 0x04000D11 RID: 3345
	public int xdich;

	// Token: 0x04000D12 RID: 3346
	public int ydich;

	// Token: 0x04000D13 RID: 3347
	public static int wButtonCmd = 70;

	// Token: 0x04000D14 RID: 3348
	public static int hButtonCmd = 24;

	// Token: 0x04000D15 RID: 3349
	private FrameImage[] fraImgCaptionArr;

	// Token: 0x04000D16 RID: 3350
	public int IdGiaotiep;

	// Token: 0x04000D17 RID: 3351
	public object obj;
}
