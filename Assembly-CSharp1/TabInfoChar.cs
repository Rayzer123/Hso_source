using System;

// Token: 0x0200009E RID: 158
public class TabInfoChar : MainTabNew
{
	// Token: 0x0600079F RID: 1951 RVA: 0x00079218 File Offset: 0x00077418
	public TabInfoChar(string name)
	{
		this.typeTab = MainTabNew.MY_INFO;
		this.nameTab = name;
		if (GameCanvas.isTouch)
		{
			this.hitem = 24;
		}
		if (GameCanvas.h <= 200)
		{
			this.hitem = 18;
		}
		this.plusTouch = this.hitem - 20;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.w4 = MainTabNew.wblack / 4;
		this.init();
		this.cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		this.cmdSetPoint = new iCommand(T.setPoint, 0, this);
		this.cmdHoiSendSetPoint = new iCommand(T.cong, 3, this);
		this.cmdSendSetPoint = new iCommand(T.cong, 1, this);
		this.cmdSendSetPointOne = new iCommand(T.cong, 2, this);
	}

	// Token: 0x060007A0 RID: 1952 RVA: 0x00079350 File Offset: 0x00077550
	public override void init()
	{
		int y = this.yBegin + 4 + GameCanvas.hText + this.hitem * T.mKyNang.Length + 2;
		int num = MainTabNew.hblack - (GameCanvas.hText + 2 + this.hitem * T.mKyNang.Length);
		this.hmax = GameScreen.player.mInfoChar.Length * GameCanvas.hText - num + 5;
		this.list = new ListNew(this.xBegin, y, MainTabNew.wblack, num, 0, 0, this.hmax);
		if (MainTabNew.longwidth > 0)
		{
			this.list.x = MainTabNew.xlongwidth;
			this.list.y = MainTabNew.ylongwidth + (int)MainTabNew.wOneItem;
			this.list.maxW = MainTabNew.longwidth;
			this.list.maxH = MainTabNew.hblack - (int)MainTabNew.wOneItem;
			this.list.cmxLim = GameScreen.player.mInfoChar.Length * GameCanvas.hText - this.hSmall + (int)MainTabNew.wOneItem + 10;
		}
		if (this.hmax < 0)
		{
			this.hmax = 0;
		}
		MainScreen.cameraSub.setAll(0, this.list.cmxLim, 0, 0);
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdBack;
			if (Player.diemTiemNang > 0)
			{
				this.center = this.cmdSetPoint;
			}
		}
		this.timePaintFocus = 0;
		base.init();
		if (GameCanvas.isSmallScreen)
		{
			for (int i = 0; i < GameScreen.player.mInfoChar.Length; i++)
			{
				MainInfoItem mainInfoItem = GameScreen.player.mInfoChar[i];
				if (mainInfoItem.id < 23 || mainInfoItem.id > 26)
				{
					string text = this.strInfoSmall;
					this.strInfoSmall = string.Concat(new string[]
					{
						text,
						Item.nameInfoItem[mainInfoItem.id],
						": ",
						Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value),
						"\n"
					});
				}
			}
		}
	}

	// Token: 0x060007A1 RID: 1953 RVA: 0x00079570 File Offset: 0x00077770
	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		this.idSelect = 0;
		base.backTab();
	}

	// Token: 0x060007A2 RID: 1954 RVA: 0x0007958C File Offset: 0x0007778C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
			if (Player.diemTiemNang == 1)
			{
				GameCanvas.start_Left_Dialog(T.cong1diem + T.mKyNang[this.idSelect] + T.nhandc + this.infoShow(1), this.cmdSendSetPointOne);
			}
			else if (Player.diemTiemNang > 0)
			{
				this.inputDialog = new InputDialog();
				this.inputDialog.setinfo(string.Concat(new object[]
				{
					T.nhapsodiem,
					T.mKyNang[this.idSelect],
					T.nhohonhoacbang,
					Player.diemTiemNang,
					") "
				}), this.cmdHoiSendSetPoint, true, T.kynang);
				GameCanvas.currentDialog = this.inputDialog;
			}
			break;
		case 2:
		{
			short num = 0;
			try
			{
				num = short.Parse(this.inputDialog.tfInput.getText());
			}
			catch (Exception ex)
			{
				num = 0;
			}
			if (num < 1)
			{
				return;
			}
			if ((int)num > Player.diemTiemNang)
			{
				GameCanvas.start_Ok_Dialog(T.khongthecong + Player.diemTiemNang);
			}
			else
			{
				GlobalService.gI().Add_Base_Skill_Point(0, (sbyte)this.idSelect, num);
				GameCanvas.end_Dialog();
				if (GameScreen.help.setStep_Next(7, 6))
				{
					GameScreen.help.Next++;
					GameScreen.help.setNext();
				}
			}
			break;
		}
		case 3:
			GlobalService.gI().Add_Base_Skill_Point(0, (sbyte)this.idSelect, 1);
			if (GameScreen.help.setStep_Next(7, 6))
			{
				GameScreen.help.Next++;
			}
			GameCanvas.end_Dialog();
			break;
		case 4:
		{
			short num2 = 0;
			try
			{
				num2 = short.Parse(this.inputDialog.tfInput.getText());
			}
			catch (Exception ex2)
			{
				num2 = 0;
			}
			if (num2 < 1)
			{
				return;
			}
			if ((int)num2 > Player.diemTiemNang)
			{
				GameCanvas.start_Ok_Dialog(T.khongthecong + Player.diemTiemNang);
			}
			else
			{
				GameCanvas.start_Left_Dialog(string.Concat(new object[]
				{
					num2,
					T.diemcongvao,
					T.mKyNang[this.idSelect],
					T.nhandc,
					this.infoShow((int)num2)
				}), this.cmdSendSetPoint);
			}
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060007A3 RID: 1955 RVA: 0x00079844 File Offset: 0x00077A44
	public override void paint(mGraphics g)
	{
		int num = this.yBegin + 4;
		int num2 = this.xBegin + 4;
		mFont.tahoma_7_white.drawString(g, T.diemtiemnang + Player.diemTiemNang, num2, num, 0, mGraphics.isFalse);
		num += GameCanvas.hText + 2;
		for (int i = 0; i < T.mKyNang.Length; i++)
		{
			int num3 = this.xBegin + this.w4 - this.w4 / 4 + this.xplus;
			int num4 = num + this.hitem * i + this.plusTouch;
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, num3 + 2 - this.plusTouch / 2, num4 - 1 - this.plusTouch / 2, 24 + this.plusTouch, 13 + this.plusTouch, 4);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[12], 0, 0, 24 + this.plusTouch, 13 + this.plusTouch, 0, num3 + 2 - this.plusTouch / 2, num4 - 1 - this.plusTouch / 2, 0, mGraphics.isFalse);
			}
			mFont.tahoma_7b_white.drawString(g, T.mKyNang[i] + ":", num3 - this.plusTouch / 2 - this.xplus - this.w4 / 2 - ((!GameCanvas.isSmallScreen) ? 0 : 4), num4, 0, mGraphics.isTrue);
			mFont.tahoma_7b_white.drawString(g, Player.mTiemnang[0][i] + string.Empty, num3 + 14, num4, 2, mGraphics.isTrue);
			if (Player.mTiemnang[1][i] > 0)
			{
				mFont.tahoma_7b_blue.drawString(g, "+" + Player.mTiemnang[1][i], num3 + 26 + this.plusTouch, num4, 0, mGraphics.isFalse);
			}
		}
		g.setColor(MainTabNew.color[3]);
		if (this.idSelect != 4 && (this.timePaintFocus > 0 || !GameCanvas.isTouch) && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			int x = this.xBegin + this.w4 - this.w4 / 4 + this.xplus + 2 - this.plusTouch / 2;
			int y = num + this.hitem * this.idSelect + this.plusTouch / 2 - 1;
			g.drawRect(x, y, 24 + this.plusTouch, 13 + this.plusTouch, mGraphics.isFalse);
		}
		num += this.hitem * T.mKyNang.Length;
		if (MainTabNew.longwidth > 0)
		{
			GameCanvas.resetTrans(g);
			mFont.tahoma_7b_white.drawString(g, T.info, MainTabNew.xlongwidth + MainTabNew.longwidth / 2, MainTabNew.ylongwidth + (int)MainTabNew.wOneItem / 4, 2, mGraphics.isFalse);
			g.setClip(MainTabNew.xlongwidth, MainTabNew.ylongwidth + (int)MainTabNew.wOneItem + 4, MainTabNew.longwidth, this.hSmall - (int)MainTabNew.wOneItem - 6);
			g.translate(MainTabNew.xlongwidth, MainTabNew.ylongwidth + (int)MainTabNew.wOneItem);
			g.translate(0, -MainScreen.cameraSub.yCam);
			num2 = 4;
			num = 4;
		}
		else
		{
			if (!GameCanvas.isSmallScreen && this.idSelect == 4)
			{
				if (MainScreen.cameraSub.yCam > 0)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 0, 13, 8, 0, this.xBegin + MainTabNew.wblack - 16, num - 2 + GameCanvas.gameTick % 3, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraSub.yCam < MainScreen.cameraSub.yLimit)
				{
					g.drawRegion(MainTabNew.imgTab[7], 0, 8, 13, 8, 0, this.xBegin + MainTabNew.wblack - 16, this.yBegin + MainTabNew.hblack - 10 - GameCanvas.gameTick % 3, 0, mGraphics.isFalse);
				}
			}
			if (!GameCanvas.isSmallScreen)
			{
				g.setClip(this.xBegin, num - 5, MainTabNew.wblack, this.yBegin + MainTabNew.hblack - num + 3);
				g.translate(0, -MainScreen.cameraSub.yCam);
			}
		}
		if (!GameCanvas.isSmallScreen)
		{
			for (int j = 0; j < GameScreen.player.mInfoChar.Length; j++)
			{
				MainInfoItem mainInfoItem = GameScreen.player.mInfoChar[j];
				if (mainInfoItem.id < 23 || mainInfoItem.id > 26)
				{
					mFont mFont = mFont.tahoma_7_white;
					mFont = MainTabNew.setTextColor((int)Item.colorInfoItem[mainInfoItem.id]);
					string st = Item.nameInfoItem[mainInfoItem.id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], mainInfoItem.value);
					mFont.drawString(g, st, num2, num, 0, mGraphics.isTrue);
					int num5 = 0;
					if (GameScreen.player.vecBuff != null)
					{
						for (int k = 0; k < GameScreen.player.vecBuff.size(); k++)
						{
							MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(k);
							if (mainBuff.minfo != null)
							{
								for (int l = 0; l < mainBuff.minfo.Length; l++)
								{
									if (mainInfoItem.id == mainBuff.minfo[l].id)
									{
										num5 += mainBuff.minfo[l].value;
									}
								}
							}
						}
					}
					if (num5 != 0)
					{
						string str = string.Empty;
						mFont mFont2 = mFont.tahoma_7_green;
						if (num5 > 0)
						{
							str = " +" + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], num5);
						}
						else
						{
							str = " " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem.id], num5);
							mFont2 = mFont.tahoma_7_red;
						}
						int width = mFont.tahoma_7_white.getWidth(st);
						mFont2.drawString(g, " " + str, num2 + width, num, 0, mGraphics.isTrue);
					}
					num += GameCanvas.hText;
				}
			}
		}
		else
		{
			mFont.tahoma_7b_white.drawString(g, T.info, num2 + MainTabNew.wblack / 2, num - GameCanvas.hText / 2, 2, mGraphics.isTrue);
		}
	}

	// Token: 0x060007A4 RID: 1956 RVA: 0x00079EA0 File Offset: 0x000780A0
	public override void update()
	{
		if (GameCanvas.isTouch)
		{
			this.list.moveCamera();
			this.list.update_Pos_UP_DOWN();
			MainScreen.cameraSub.yCam = this.list.cmx;
		}
		else
		{
			MainScreen.cameraSub.UpdateCamera();
		}
		if (!GameCanvas.isTouch)
		{
			if (Player.diemTiemNang > 0 && this.idSelect != 4)
			{
				if (this.center == null)
				{
					this.center = this.cmdSetPoint;
				}
			}
			else if (this.center != null)
			{
				this.center = null;
			}
		}
		if (this.timePaintFocus > 0 && GameCanvas.currentDialog == null)
		{
			this.timePaintFocus--;
		}
	}

	// Token: 0x060007A5 RID: 1957 RVA: 0x00079F64 File Offset: 0x00078164
	public override void updatekey()
	{
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			if (this.idSelect == 4)
			{
				if (GameCanvas.isSmallScreen)
				{
					this.idSelect = 3;
					GameCanvas.start_Show_Dialog(this.strInfoSmall, T.info);
				}
				else if (GameCanvas.keyMyHold[2])
				{
					this.xCamInfo -= GameCanvas.hText;
					if (this.xCamInfo < 0)
					{
						this.idSelect = 3;
					}
					GameCanvas.clearKeyHold(2);
					MainScreen.cameraSub.moveCamera(0, this.xCamInfo);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					this.xCamInfo += GameCanvas.hText;
					if (this.xCamInfo > this.hmax)
					{
						this.xCamInfo = this.hmax;
					}
					GameCanvas.clearKeyHold(8);
					MainScreen.cameraSub.moveCamera(0, this.xCamInfo);
				}
			}
			else
			{
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
				else if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
				{
					MainTabNew.Focus = MainTabNew.TAB;
					GameCanvas.clearKeyHold(4);
					GameCanvas.clearKeyHold(6);
				}
				int num = T.mKyNang.Length - 1;
				if (this.hmax > 0)
				{
					num++;
				}
				this.idSelect = base.resetSelect(this.idSelect, num, false);
				this.xCamInfo = 0;
			}
		}
		base.updatekey();
	}

	// Token: 0x060007A6 RID: 1958 RVA: 0x0007A10C File Offset: 0x0007830C
	public override void updatePointer()
	{
		if (GameCanvas.isPointerSelect)
		{
			for (int i = 0; i < 4; i++)
			{
				int num = this.xBegin + this.w4 - this.w4 / 4 + this.xplus;
				int num2 = this.yBegin + GameCanvas.hText + 4 + this.hitem * i + this.plusTouch + 2;
				if (GameCanvas.isPoint(num - 2 - this.plusTouch / 2, num2 - 5 - this.plusTouch / 2, 32 + this.plusTouch, 21 + this.plusTouch))
				{
					this.idSelect = i;
					this.cmdSetPoint.perform();
					GameCanvas.isPointerSelect = false;
					this.timePaintFocus = 10;
					break;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x060007A7 RID: 1959 RVA: 0x0007A1D4 File Offset: 0x000783D4
	public string infoShow(int point)
	{
		string text = string.Empty;
		switch (this.idSelect)
		{
		case 0:
			text = text + "\n" + T.chimang + this.setpercent(2, point);
			text = text + "\n" + T.tatcasatthuong + this.setpercent(20, point);
			if ((int)GameScreen.player.clazz == 0)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongvatly,
					"+",
					4 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuonglua,
					"+",
					4 * point
				});
			}
			else if ((int)GameScreen.player.clazz == 1)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongvatly,
					"+",
					4 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongdoc,
					"+",
					4 * point
				});
			}
			break;
		case 1:
			text = text + "\n" + T.nedon + this.setpercent(2, point);
			text = text + "\n" + T.phongthu + this.setpercent(10, point);
			if ((int)GameScreen.player.clazz == 3)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.phongthu,
					"+",
					22 * point
				});
			}
			else if ((int)GameScreen.player.clazz == 1)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.phongthu,
					"+",
					22 * point
				});
			}
			else
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.phongthu,
					"+",
					20 * point
				});
			}
			break;
		case 2:
			text = text + "\n" + T.phansatthuong + this.setpercent(2, point);
			if ((int)GameScreen.player.clazz == 0)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.mau,
					"+",
					320 * point
				});
			}
			else if ((int)GameScreen.player.clazz == 2)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.mau,
					"+",
					310 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.nangluong,
					"+",
					1 * point
				});
			}
			else
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.mau,
					"+",
					300 * point
				});
				if ((int)GameScreen.player.clazz == 2)
				{
					text = text + "\n" + T.khangtatcast + this.setpercent(5, point);
				}
			}
			break;
		case 3:
			text = text + "\n" + T.xuyengiap + this.setpercent(2, point);
			if ((int)GameScreen.player.clazz == 2)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.nangluong,
					"+",
					11 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongvatly,
					"+",
					4 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongbang,
					"+",
					4 * point
				});
				text = text + "\n" + T.satthuongvatly + this.setpercent(18, point);
				text = text + "\n" + T.satthuongbang + this.setpercent(18, point);
			}
			else if ((int)GameScreen.player.clazz == 3)
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.nangluong,
					"+",
					11 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongvatly,
					"+",
					4 * point
				});
				text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.satthuongdien,
					"+",
					4 * point
				});
				text = text + "\n" + T.satthuongvatly + this.setpercent(18, point);
				text = text + "\n" + T.satthuongdien + this.setpercent(18, point);
			}
			else
			{
				string text2 = text;
				text = string.Concat(new object[]
				{
					text2,
					"\n",
					T.nangluong,
					"+",
					10 * point
				});
			}
			break;
		}
		return text;
	}

	// Token: 0x060007A8 RID: 1960 RVA: 0x0007A7C0 File Offset: 0x000789C0
	public string setpercent(int value, int point)
	{
		string result = string.Empty;
		int num = value * point;
		if (num % 100 == 0)
		{
			result = "+" + num / 100 + "%";
		}
		else if (num % 10 == 0)
		{
			result = string.Concat(new object[]
			{
				"+",
				num / 100,
				".",
				num % 100 / 10,
				"%"
			});
		}
		else
		{
			result = string.Concat(new object[]
			{
				"+",
				num / 100,
				".",
				num % 100 / 10,
				string.Empty,
				num % 10,
				"%"
			});
		}
		return result;
	}

	// Token: 0x04000BC3 RID: 3011
	private int w4;

	// Token: 0x04000BC4 RID: 3012
	private int idSelect;

	// Token: 0x04000BC5 RID: 3013
	private int hmax;

	// Token: 0x04000BC6 RID: 3014
	private int xCamInfo;

	// Token: 0x04000BC7 RID: 3015
	private int hitem = 20;

	// Token: 0x04000BC8 RID: 3016
	private int plusTouch;

	// Token: 0x04000BC9 RID: 3017
	private int xplus = 30;

	// Token: 0x04000BCA RID: 3018
	private iCommand cmdSetPoint;

	// Token: 0x04000BCB RID: 3019
	private iCommand cmdSendSetPoint;

	// Token: 0x04000BCC RID: 3020
	private iCommand cmdSendSetPointOne;

	// Token: 0x04000BCD RID: 3021
	private iCommand cmdHoiSendSetPoint;

	// Token: 0x04000BCE RID: 3022
	private int timePaintFocus;

	// Token: 0x04000BCF RID: 3023
	private InputDialog inputDialog;

	// Token: 0x04000BD0 RID: 3024
	private ListNew list;

	// Token: 0x04000BD1 RID: 3025
	private string strInfoSmall = string.Empty;
}
