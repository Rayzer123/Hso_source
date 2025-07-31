using System;

// Token: 0x02000093 RID: 147
public class InputDialog : MainDialog
{
	// Token: 0x06000706 RID: 1798 RVA: 0x00069EEC File Offset: 0x000680EC
	public InputDialog()
	{
		this.cmdClose = new iCommand(T.close, -1);
		InputDialog.istouchMore = 15;
		if (GameCanvas.isTouch)
		{
			InputDialog.hTouch = iCommand.hButtonCmd + 5;
		}
	}

	// Token: 0x06000708 RID: 1800 RVA: 0x00069F44 File Offset: 0x00068144
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

	// Token: 0x06000709 RID: 1801 RVA: 0x00069F64 File Offset: 0x00068164
	public override void commandTab(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.closeDialog();
			break;
		case 1:
		{
			string[] array = new string[this.mtfInput.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = string.Empty;
				if (this.mtfInput[i].getText().Length > 0)
				{
					array[i] = this.mtfInput[i].getText();
				}
			}
			GlobalService.gI().nap_tien(this.type, array);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		}
		case 2:
		{
			mVector mVector = new mVector();
			bool flag = (int)this.idNPC == GameScreen.ID_DLG_BUY_KC;
			for (int j = 0; j < this.mtfInput.Length; j++)
			{
				string o = string.Empty;
				if (this.mtfInput[j].getText().Length > 0)
				{
					o = this.mtfInput[j].getText();
				}
				mVector.addElement(o);
			}
			if (flag)
			{
				mVector.addElement(mSystem.getLong());
				mVector.addElement(mSystem.getLat());
			}
			GlobalService.gI().sendMoreServerInfo(this.idNPC, this.type, mVector);
			this.closeDialog();
			break;
		}
		}
		base.commandTab(index, subIndex);
	}

	// Token: 0x0600070A RID: 1802 RVA: 0x0006A0C8 File Offset: 0x000682C8
	public void setinfo(string[] info, iCommand cmd, short type, short idNPC, string name, string[] texmacdinh, sbyte typepaint)
	{
		this.isMore = true;
		this.isNew = false;
		this.left = null;
		this.right = null;
		this.center = null;
		this.mtfInput = null;
		InputDialog.hitem = 50;
		this.type = type;
		this.idNPC = idNPC;
		if (cmd == null)
		{
			GameCanvas.subDialog = null;
		}
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 140)
		{
			this.wDia = 140;
		}
		this.mtfInput = new TField[info.Length];
		this.strinfo = info;
		this.name = name;
		if (this.mtfInput.Length > 3)
		{
			this.iscroll = true;
		}
		if (this.iscroll)
		{
			this.wDia = GameCanvas.w / 4 * 3;
			this.hDia = GameCanvas.h / 5 * 4;
			this.wDia = GameCanvas.w - 30;
			if (this.wDia > 140)
			{
				this.wDia = 140;
			}
			if (this.hDia < 210)
			{
				this.hDia = 210;
			}
			else if (this.hDia > 280)
			{
				this.hDia = 280;
			}
			if (this.hDia < 210)
			{
				this.hDia = 210;
			}
			else if (this.hDia > 280)
			{
				this.hDia = 280;
			}
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			if (this.yDia < 20)
			{
				this.yDia = 20;
			}
			if (GameCanvas.isSmallScreen)
			{
				this.yDia = 0;
			}
		}
		else
		{
			this.hDia = (TField.getHeight() + 18) * this.strinfo.Length + 6 + GameCanvas.hCommand;
			this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		for (int i = 0; i < this.mtfInput.Length; i++)
		{
			this.mtfInput[i] = new TField(this.xDia + 10, this.yDia + 8 + (TField.getHeight() + 18) * i + InputDialog.istouchMore + GameCanvas.hCommand, this.wDia - 20);
			this.mtfInput[i].setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			if (GameCanvas.currentScreen != GameCanvas.createChar)
			{
				this.right = this.cmdClose;
			}
			this.left = cmd;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
		}
		if (!GameCanvas.isTouch)
		{
			this.mtfInput[0].setFocus(true);
			this.right = this.mtfInput[0].cmdClear;
		}
		if (this.iscroll)
		{
			MainScreen.cameraSub.setAll(0, this.mtfInput.Length * InputDialog.hitem - this.hDia + GameCanvas.hCommand + 30, 0, 0);
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, InputDialog.hitem, 0, MainScreen.cameraSub.yLimit);
		}
		if ((int)typepaint == 0)
		{
			for (int j = 0; j < this.mtfInput.Length; j++)
			{
				this.mtfInput[j].setStringNull(info[j]);
			}
		}
		for (int k = 0; k < this.mtfInput.Length; k++)
		{
			this.mtfInput[k].setText(texmacdinh[k]);
		}
	}

	// Token: 0x0600070B RID: 1803 RVA: 0x0006A520 File Offset: 0x00068720
	public void setinfo(string info, iCommand cmd, bool isNum, string nameInput)
	{
		this.isMore = false;
		this.isNew = false;
		this.left = null;
		this.right = null;
		this.center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.strinfo = this.fontInput.splitFontArray(info, this.wDia - 20);
		this.name = nameInput;
		this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.tfInput = new TField(this.xDia + 10, this.yDia + this.hDia - InputDialog.hTouch - (TField.getHeight() + 8), this.wDia - 20);
		this.tfInput.isNotUseChangeTextBox = true;
		this.tfInput.setMaxTextLenght(100);
		if (isNum)
		{
			this.tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		this.tfInput.setText(string.Empty);
		if (!Main.isPC)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
			this.tfInput.title = info;
		}
		else
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.center = cmd;
			this.left = this.cmdClose;
			this.tfInput.setFocus(true);
			this.right = this.tfInput.cmdClear;
		}
	}

	// Token: 0x0600070C RID: 1804 RVA: 0x0006A79C File Offset: 0x0006899C
	public void setinfo(string[] info, iCommand cmd, short type, short idNPC, string name)
	{
		this.isMore = true;
		this.isNew = false;
		this.left = null;
		this.right = null;
		this.center = null;
		this.mtfInput = null;
		InputDialog.hitem = 50;
		this.type = type;
		this.idNPC = idNPC;
		if (cmd == null)
		{
			GameCanvas.subDialog = null;
		}
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 140)
		{
			this.wDia = 140;
		}
		this.mtfInput = new TField[info.Length];
		this.strinfo = info;
		this.name = name;
		if (this.mtfInput.Length > 3)
		{
			this.iscroll = true;
		}
		if (this.iscroll)
		{
			this.wDia = GameCanvas.w / 4 * 3;
			this.hDia = GameCanvas.h / 5 * 4;
			this.wDia = GameCanvas.w - 30;
			if (this.wDia > 140)
			{
				this.wDia = 140;
			}
			if (this.hDia < 210)
			{
				this.hDia = 210;
			}
			else if (this.hDia > 280)
			{
				this.hDia = 280;
			}
			if (this.hDia < 210)
			{
				this.hDia = 210;
			}
			else if (this.hDia > 280)
			{
				this.hDia = 280;
			}
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			if (this.yDia < 20)
			{
				this.yDia = 20;
			}
			if (GameCanvas.isSmallScreen)
			{
				this.yDia = 0;
			}
		}
		else
		{
			this.hDia = (TField.getHeight() + 18) * this.strinfo.Length + 6 + GameCanvas.hCommand;
			this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		for (int i = 0; i < this.mtfInput.Length; i++)
		{
			this.mtfInput[i] = new TField(this.xDia + 10, this.yDia + 8 + (TField.getHeight() + 18) * i + InputDialog.istouchMore + GameCanvas.hCommand, this.wDia - 20);
			this.mtfInput[i].setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 13, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
		}
		if (!GameCanvas.isTouch)
		{
			this.mtfInput[0].setFocus(true);
			this.right = this.mtfInput[0].cmdClear;
		}
		if (this.iscroll)
		{
			MainScreen.cameraSub.setAll(0, this.mtfInput.Length * InputDialog.hitem - this.hDia + GameCanvas.hCommand + 30, 0, 0);
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, InputDialog.hitem, 0, MainScreen.cameraSub.yLimit);
		}
	}

	// Token: 0x0600070D RID: 1805 RVA: 0x0006AB88 File Offset: 0x00068D88
	public void setinfoSmallNew(string info, iCommand cmd, bool isNum, int defValue, long price, string xuluong)
	{
		this.isMore = false;
		this.isNew = true;
		this.left = null;
		this.right = null;
		this.center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.price = price;
		this.info = info;
		this.name = string.Empty;
		this.xuluong = xuluong;
		this.wDia = GameCanvas.w / 3 * 2;
		if (this.wDia > 160)
		{
			this.wDia = 160;
		}
		string empty = string.Empty;
		this.strinfo = this.fontInput.splitFontArray(info + " " + empty, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		int num = this.wDia - 100;
		if (num < 40)
		{
			num = 40;
		}
		this.tfInput = new TField(this.xDia + this.wDia / 2 - num / 2, this.yDia + this.hDia - InputDialog.hTouch - (TField.getHeight() + 8), num);
		if (isNum)
		{
			this.tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		if (defValue >= 0)
		{
			this.tfInput.setText(string.Empty + defValue);
		}
		this.strtam = this.tfInput.getText();
		if (GameCanvas.isTouch)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
			this.tfInput.setFocus(true);
			this.right = this.tfInput.cmdClear;
		}
	}

	// Token: 0x0600070E RID: 1806 RVA: 0x0006AE14 File Offset: 0x00069014
	public void setinfoSmallNew(string info, iCommand cmd, bool isNum, int defValue, long price, string name, string xuluong)
	{
		this.isMore = false;
		this.isNew = true;
		this.left = null;
		this.right = null;
		this.center = null;
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.price = price;
		this.info = info;
		this.name = name;
		this.xuluong = xuluong;
		this.wDia = GameCanvas.w / 3 * 2;
		if (this.wDia > 160)
		{
			this.wDia = 160;
		}
		string str = string.Concat(new object[]
		{
			"\n",
			T.price,
			" ",
			price,
			" ",
			xuluong
		});
		this.strinfo = this.fontInput.splitFontArray(info + " " + str, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + GameCanvas.hCommand;
		this.hDia += InputDialog.hTouch + InputDialog.istouchMore;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		int num = this.wDia - 100;
		if (num < 40)
		{
			num = 40;
		}
		this.tfInput = new TField(this.xDia + this.wDia / 2 - num / 2, this.yDia + this.hDia - InputDialog.hTouch - (TField.getHeight() + 8), num);
		this.tfInput.isNotUseChangeTextBox = true;
		if (isNum)
		{
			this.tfInput.setIputType(TField.INPUT_TYPE_NUMERIC);
		}
		if (defValue >= 0)
		{
			this.tfInput.setText(string.Empty + defValue);
		}
		this.strtam = this.tfInput.getText();
		if (!Main.isPC)
		{
			cmd.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd / 2 - 5, null, cmd.caption);
			this.cmdClose.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.right = this.cmdClose;
			this.left = cmd;
		}
		else
		{
			this.center = cmd;
			this.left = this.cmdClose;
			this.tfInput.setFocus(true);
			this.right = this.tfInput.cmdClear;
		}
	}

	// Token: 0x0600070F RID: 1807 RVA: 0x0006B0E0 File Offset: 0x000692E0
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.name);
		if (this.iscroll)
		{
			g.setClip(this.xDia + 10, this.yDia + GameCanvas.hCommand, this.wDia, this.hDia - InputDialog.hitem - 10);
			g.translate(0, -MainScreen.cameraSub.yCam);
		}
		int num = this.yDia + InputDialog.istouchMore + GameCanvas.hCommand;
		if (this.isMore)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				this.fontInput.drawString(g, this.strinfo[i], GameCanvas.w / 2, num - 5 + i * (TField.getHeight() + 18), 2, mGraphics.isTrue);
				this.mtfInput[i].paintByList(g);
			}
		}
		else
		{
			for (int j = 0; j < this.strinfo.Length; j++)
			{
				this.fontInput.drawString(g, this.strinfo[j], GameCanvas.w / 2, num + j * 15 - 5, 2, mGraphics.isTrue);
			}
			this.tfInput.paintByList(g);
		}
		GameCanvas.resetTrans(g);
		base.paintCmd(g);
	}

	// Token: 0x06000710 RID: 1808 RVA: 0x0006B23C File Offset: 0x0006943C
	public override void keypress(int keyCode)
	{
		if (this.isMore)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				if (this.mtfInput[i].isFocusedz())
				{
					this.mtfInput[i].keyPressed(keyCode);
					return;
				}
			}
		}
		else
		{
			this.tfInput.keyPressed(keyCode);
		}
		base.keypress(keyCode);
	}

	// Token: 0x06000711 RID: 1809 RVA: 0x0006B2A8 File Offset: 0x000694A8
	public override void update()
	{
		this.updatekey();
		this.updatePointer();
		if (this.isMore)
		{
			for (int i = 0; i < this.mtfInput.Length; i++)
			{
				this.mtfInput[i].update();
			}
		}
		else if (this.tfInput != null)
		{
			if (this.tfInput.isnewTF && this.tfInput.isFocus && !newinput.input.isFocused)
			{
				newinput.input.Select();
				newinput.input.ActivateInputField();
			}
			this.tfInput.update();
			if (Main.isPC && this.right != this.tfInput.cmdClear)
			{
				this.right = this.tfInput.cmdClear;
			}
			if (this.isNew && this.tfInput.getText().CompareTo(this.strtam) != 0)
			{
				this.strtam = this.tfInput.getText();
				int num = 0;
				try
				{
					num = int.Parse(this.strtam);
				}
				catch (Exception ex)
				{
					num = 0;
				}
				string str = string.Concat(new object[]
				{
					"\n",
					T.price,
					" ",
					this.price * (long)num,
					" ",
					this.xuluong
				});
				this.strinfo = this.fontInput.splitFontArray(this.info + " " + str, this.wDia - 20);
				this.hDia = 15 * this.strinfo.Length + 10 + TField.getHeight() + InputDialog.hTouch + InputDialog.istouchMore + GameCanvas.hCommand;
				int num2 = this.wDia - 100;
				if (num2 < 40)
				{
					num2 = 40;
				}
				this.xDia = GameCanvas.hw - this.wDia / 2;
				this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia + 15;
				this.numw = (this.wDia - 6) / 32;
				this.numh = (this.hDia - 6) / 32;
				this.tfInput.x = this.xDia + this.wDia / 2 - num2 / 2;
				this.tfInput.y = this.yDia + this.hDia - (TField.getHeight() + 8) - InputDialog.hTouch;
			}
		}
		base.update();
	}

	// Token: 0x06000712 RID: 1810 RVA: 0x0006B544 File Offset: 0x00069744
	public override void updatekey()
	{
		if (this.isMore)
		{
			int num = this.idSelect;
			if (GameCanvas.keyMyHold[8])
			{
				for (int i = 0; i < this.mtfInput.Length; i++)
				{
					if (this.mtfInput[i].isFocusedz())
					{
						this.mtfInput[i].setFocus(false);
						if (i < this.mtfInput.Length - 1)
						{
							this.mtfInput[i + 1].setFocus(true);
							this.idSelect = i + 1;
							if (Main.isPC)
							{
								this.right = this.mtfInput[i + 1].cmdClear;
							}
						}
						else
						{
							this.mtfInput[0].setFocus(true);
							this.idSelect = 0;
							if (Main.isPC)
							{
								this.right = this.mtfInput[0].cmdClear;
							}
						}
						break;
					}
				}
				GameCanvas.clearKeyHold(8);
			}
			else if (GameCanvas.keyMyHold[2] && !Main.isPC)
			{
				for (int j = 0; j < this.mtfInput.Length; j++)
				{
					if (this.mtfInput[j].isFocusedz())
					{
						this.mtfInput[j].setFocus(false);
						if (j > 0)
						{
							this.mtfInput[j - 1].setFocus(true);
							this.idSelect = j - 1;
						}
						else
						{
							this.mtfInput[this.mtfInput.Length - 1].setFocus(true);
							this.idSelect = this.mtfInput.Length - 1;
						}
						break;
					}
				}
				GameCanvas.clearKeyHold(2);
			}
			this.idSelect = base.resetSelect(this.idSelect, this.mtfInput.Length - 1, false);
			if (num != this.idSelect && !Main.isPC)
			{
				MainScreen.cameraSub.moveCamera(0, this.idSelect * 40 - this.hDia / 2 + 40 + GameCanvas.hCommand);
			}
		}
		base.updatekey();
	}

	// Token: 0x06000713 RID: 1811 RVA: 0x0006B73C File Offset: 0x0006993C
	public string[] getarrayText()
	{
		string[] array = new string[this.mtfInput.Length];
		for (int i = 0; i < this.mtfInput.Length; i++)
		{
			array[i] = this.mtfInput[i].getText();
		}
		return array;
	}

	// Token: 0x06000714 RID: 1812 RVA: 0x0006B784 File Offset: 0x00069984
	public override void updatePointer()
	{
		base.updatePointer();
		if (this.isMore)
		{
			if (this.iscroll)
			{
				if (GameCanvas.isTouch && this.list != null)
				{
					this.list.moveCamera();
					this.list.update_Pos_UP_DOWN();
					MainScreen.cameraSub.yCam = this.list.cmx;
				}
				else
				{
					MainScreen.cameraSub.UpdateCamera();
				}
				if (GameCanvas.isPointSelect(this.xDia, this.yDia + GameCanvas.hCommand, this.wDia, this.hDia - GameCanvas.hCommand))
				{
					for (int i = 0; i < this.mtfInput.Length; i++)
					{
						this.mtfInput[i].isFocus = false;
					}
					int num = (MainScreen.cameraSub.yCam + GameCanvas.py - this.yDia - GameCanvas.hCommand) / InputDialog.hitem;
					if (num >= 0 && num < this.mtfInput.Length)
					{
						if (GameCanvas.isTouch)
						{
							this.mtfInput[num].updatepointerByList();
						}
						else
						{
							this.mtfInput[num].update();
						}
					}
					GameCanvas.isPointerSelect = false;
				}
			}
			else
			{
				for (int j = 0; j < this.mtfInput.Length; j++)
				{
					this.mtfInput[j].updatePoiter();
				}
			}
		}
		else if (this.tfInput != null)
		{
			this.tfInput.updatePoiter();
		}
	}

	// Token: 0x04000A47 RID: 2631
	public TField tfInput;

	// Token: 0x04000A48 RID: 2632
	private iCommand cmdClose;

	// Token: 0x04000A49 RID: 2633
	public TField[] mtfInput;

	// Token: 0x04000A4A RID: 2634
	private bool isMore;

	// Token: 0x04000A4B RID: 2635
	private bool iscroll;

	// Token: 0x04000A4C RID: 2636
	private bool isNew;

	// Token: 0x04000A4D RID: 2637
	private long price;

	// Token: 0x04000A4E RID: 2638
	private string name;

	// Token: 0x04000A4F RID: 2639
	private string info;

	// Token: 0x04000A50 RID: 2640
	private string xuluong;

	// Token: 0x04000A51 RID: 2641
	private new short type;

	// Token: 0x04000A52 RID: 2642
	private short idNPC = -1;

	// Token: 0x04000A53 RID: 2643
	public static int hTouch;

	// Token: 0x04000A54 RID: 2644
	public static int istouchMore;

	// Token: 0x04000A55 RID: 2645
	public static int hitem;

	// Token: 0x04000A56 RID: 2646
	private mFont fontInput = mFont.tahoma_7_white;

	// Token: 0x04000A57 RID: 2647
	public bool isnew;

	// Token: 0x04000A58 RID: 2648
	private ListNew list;

	// Token: 0x04000A59 RID: 2649
	private string strtam;

	// Token: 0x04000A5A RID: 2650
	private int idSelect;
}
