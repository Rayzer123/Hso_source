using System;

// Token: 0x0200007C RID: 124
public class Clan_Screen : MainScreen
{
	// Token: 0x060005A5 RID: 1445 RVA: 0x00052258 File Offset: 0x00050458
	public Clan_Screen()
	{
		this.hTouch = 0;
		if (GameCanvas.isTouch)
		{
			this.hTouch = iCommand.hButtonCmd;
		}
		this.init(180);
	}

	// Token: 0x060005A7 RID: 1447 RVA: 0x000522C0 File Offset: 0x000504C0
	public override void Show(MainScreen screen)
	{
		base.Show(screen);
		GameCanvas.end_Dialog();
	}

	// Token: 0x060005A8 RID: 1448 RVA: 0x000522D0 File Offset: 0x000504D0
	public void setInfoClan(MainClan clan, sbyte type)
	{
		this.type = type;
		this.clanShow = clan;
		if (this.clanShow == null)
		{
			this.lastScreen.Show(this.lastScreen.lastScreen);
			return;
		}
		this.updateShow();
		this.cmdClose = new iCommand(T.close, -1, this);
		this.cmdXemList = new iCommand(T.xemdanhsach, 2, this);
		if ((int)type == 1)
		{
			this.cmdXemList.caption = T.thanhvien;
			this.left = this.cmdXemList;
		}
		else if ((int)type == 0)
		{
			this.cmdMenu = new iCommand(T.menu, 0, this);
			this.cmdGopXu = new iCommand(T.gop + T.coin, 3, this);
			this.cmdGopLuong = new iCommand(T.gop + T.gem, 4, this);
			this.cmdInfoMySeft = new iCommand(T.info + " " + T.banthan, 6, this);
			this.cmdChucNang = new iCommand(T.chucnang, 7, this);
			this.cmdChangeSlogan = new iCommand(T.doiSlogan, 8, this);
			this.cmdChangeNoiQuy = new iCommand(T.doiNoiquy, 9, this);
			this.cmdPhongcap = new iCommand(T.phonghacap, 2, this);
			this.cmdRoiClan = new iCommand(T.roiclan, 11, this);
			this.cmdChatBang = new iCommand(T.chattoanbang, 12, this);
			this.cmdThongBao = new iCommand(T.doithongbao, 13, this);
			this.cmdInvenClan = new iCommand(T.tabhanhtrang + " " + T.clan, 14, this);
			this.left = this.cmdMenu;
		}
		this.right = this.cmdClose;
		if (GameCanvas.isTouch)
		{
			this.left.setPos(this.xbegin + this.wScreen / 2, this.ybegin + this.wScreen - iCommand.hButtonCmd / 2 - 4, PaintInfoGameScreen.fraButton, this.left.caption);
			this.right.setPos(this.xbegin + this.wScreen - 12, this.ybegin + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
	}

	// Token: 0x060005A9 RID: 1449 RVA: 0x00052508 File Offset: 0x00050708
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.lastScreen.Show(this.lastScreen.lastScreen);
			break;
		case 1:
		{
			mVector mVector = new mVector("Clan_Screen menu");
			if ((int)this.type == 1)
			{
				mVector.addElement(this.cmdXemList);
				mVector.addElement(this.cmdXinvao);
			}
			else if ((int)this.type == 0)
			{
				if (GameScreen.player.myClan == null || GameScreen.player.myClan.isRemove)
				{
					this.lastScreen.Show(this.lastScreen.lastScreen);
					GameCanvas.start_Ok_Dialog(T.bankhongconclan);
					return;
				}
				mVector.addElement(this.cmdXemList);
				mVector.addElement(this.cmdInfoMySeft);
				mVector.addElement(this.cmdChatBang);
				if (GameScreen.player.myClan.getChucNang())
				{
					mVector.addElement(this.cmdChucNang);
					mVector.addElement(this.cmdInvenClan);
				}
				mVector.addElement(this.cmdGopXu);
				mVector.addElement(this.cmdGopLuong);
				if ((int)GameScreen.player.myClan.chucvu != 127)
				{
					mVector.addElement(this.cmdRoiClan);
				}
			}
			GameCanvas.menu2.startAt(mVector, 2, T.chucnang, false, null);
			break;
		}
		case 2:
			GlobalService.gI().ChucNang_Clan(0, this.clanShow.IdClan);
			GameCanvas.start_Ok_Dialog(T.dagoidangky);
			break;
		case 3:
			GlobalService.gI().ChucNang_Clan(13, this.clanShow.IdClan);
			GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			break;
		case 4:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfo(T.nhapsoxumuongop, new iCommand(T.gop, 5, 6, this), true, T.gop + T.coin);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 5:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfo(T.nhapsoluongmuongop, new iCommand(T.gop, 5, 7, this), true, T.gop + T.gem);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 6:
		{
			int num = 0;
			try
			{
				num = int.Parse(this.inputDialog.tfInput.getText());
			}
			catch (Exception ex)
			{
				break;
			}
			if (num > 0)
			{
				GlobalService.gI().gop_Xu_Luong_Clan((sbyte)subIndex, num);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		}
		case 7:
			GlobalService.gI().info_Mem_Clan(14, GameScreen.player.name);
			GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			break;
		case 8:
			if (GameScreen.player.myClan == null || GameScreen.player.myClan.isRemove)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
				GameCanvas.start_Ok_Dialog(T.bankhongconclan);
				return;
			}
			if ((int)GameScreen.player.myClan.chucvu == 127)
			{
				mVector mVector2 = new mVector("Clan_Screen menu2");
				mVector2.addElement(this.cmdPhongcap);
				mVector2.addElement(this.cmdChangeSlogan);
				mVector2.addElement(this.cmdChangeNoiQuy);
				mVector2.addElement(this.cmdThongBao);
				GameCanvas.menu2.startAt(mVector2, 2, T.chucnang, false, null);
			}
			else
			{
				this.cmdPhongcap.perform();
			}
			break;
		case 9:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 16, this), false, T.change + " " + T.slogan);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 10:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 17, this), false, T.change + " " + T.noiquy);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 11:
		{
			string text = this.inputDialog.tfInput.getText();
			if (text != null)
			{
				GlobalService.gI().Change_Slo_NoiQuy_Clan((sbyte)subIndex, text);
				GameCanvas.start_Ok_Dialog(T.pleaseWait);
			}
			break;
		}
		case 12:
			GameCanvas.start_Left_Dialog(T.hoiroiClan, new iCommand(T.roiclan, 15, this));
			break;
		case 13:
			GameCanvas.msgchat.addNewChat(T.tabBangHoi, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 14:
			this.inputDialog = new InputDialog();
			this.inputDialog.setinfo(T.nhapthongtindoi, new iCommand(T.change, 10, 2, this), false, T.change + " " + T.thongbao);
			GameCanvas.currentDialog = this.inputDialog;
			break;
		case 15:
			GlobalService.gI().InvenClan(21);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 16:
			GlobalService.gI().Delete_Mem_Clan(18, GameScreen.player.name);
			this.lastScreen.Show(this.lastScreen.lastScreen);
			break;
		}
	}

	// Token: 0x060005AA RID: 1450 RVA: 0x00052A9C File Offset: 0x00050C9C
	public void init(int w)
	{
		this.wScreen = w;
		this.hScreen = w;
		if (this.hScreen > GameCanvas.h - 20)
		{
			this.hScreen = GameCanvas.h - 20;
		}
		if (this.wScreen > GameCanvas.w - 20)
		{
			this.wScreen = GameCanvas.w - 20;
		}
		this.xbegin = GameCanvas.hw - this.wScreen / 2;
		this.ybegin = GameCanvas.hh - this.hScreen / 2;
	}

	// Token: 0x060005AB RID: 1451 RVA: 0x00052B24 File Offset: 0x00050D24
	public override void paint(mGraphics g)
	{
		if (this.lastScreen != null)
		{
			this.lastScreen.paint(g);
		}
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = this.ybegin;
		int num2 = this.xbegin;
		base.paintFormList(g, num2, num, this.wScreen, this.hScreen, T.clan);
		num2 += 5;
		num += GameCanvas.hCommand + 2;
		g.setClip(this.xbegin, num, this.wScreen, this.hScreen - GameCanvas.hCommand - this.hTouch - 5);
		g.translate(0, -this.cam.yCam);
		AvMain.Font3dWhite(g, this.clanShow.name, this.xbegin + this.wScreen / 2, num + 4, 2);
		num += GameCanvas.hText + GameCanvas.hText / 2;
		mFont.tahoma_7b_white.drawString(g, T.bieutuong, num2, num, 0, mGraphics.isTrue);
		MainImage mainImage = ObjectData.getImageIconClan(this.clanShow.IdIcon);
		if (mainImage.img != null)
		{
			if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
			{
				if (GameCanvas.gameTick % 6 == 0)
				{
					int num3 = this.frameicon.Length;
					if (num3 == 0)
					{
						num3 = 1;
					}
					this.clanShow.frameClan = (sbyte)(((int)this.clanShow.frameClan + 1) % num3);
				}
				g.drawRegion(mainImage.img, 0, (int)this.frameicon[(int)this.clanShow.frameClan] * 18, 18, 18, 0, num2 + 70, num + 6, 3, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(mainImage.img, num2 + 70, num + 6, 3, mGraphics.isTrue);
			}
		}
		mFont.tahoma_7b_white.drawString(g, this.clanShow.shortName, num2 + 78, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
		{
			T.level,
			this.clanShow.Lv,
			" +",
			this.clanShow.ptLv / 10,
			",",
			this.clanShow.ptLv % 10,
			"%    ",
			T.hang,
			": ",
			this.clanShow.hang
		}), num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
		{
			T.soluong,
			this.clanShow.numMem,
			"/",
			this.clanShow.maxMem
		}), num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.mChucVuClan[0] + ": " + this.clanShow.nameThuLinh, num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		for (int i = 0; i < this.mslogan.Length; i++)
		{
			mFont.tahoma_7_white.drawString(g, this.mslogan[i], num2, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
		}
		mFont.tahoma_7b_white.drawString(g, T.quyxu + ": " + MainItem.getDotNumber(this.clanShow.coin), num2, num, 0, mGraphics.isTrue);
		num += GameCanvas.hText;
		mFont.tahoma_7b_white.drawString(g, T.quyngoc + ": " + MainItem.getDotNumber((long)this.clanShow.gold), num2, num, 0, mGraphics.isTrue);
		if (this.clanShow.mthanhtich != null)
		{
			for (int j = 0; j < this.clanShow.mthanhtich.Length; j++)
			{
				num += 20;
				mainImage = ObjectData.getImageIconArCheClan((short)this.clanShow.mthanhtich[j].id);
				if (mainImage.img != null)
				{
					g.drawImage(mainImage.img, num2 + 9, num + 5, 3, mGraphics.isTrue);
				}
				mFont.tahoma_7_yellow.drawString(g, this.clanShow.mthanhtich[j].num + string.Empty, num2 + 16, num + 4, 2, mGraphics.isTrue);
				mFont.tahoma_7b_white.drawString(g, ": " + this.clanShow.mthanhtich[j].nameThanhTich, num2 + 22, num, 0, mGraphics.isTrue);
			}
			num += 5;
		}
		num += GameCanvas.hText;
		for (int k = 0; k < this.mnoiquy.Length; k++)
		{
			mFont.tahoma_7_white.drawString(g, this.mnoiquy[k], num2, num, 0, mGraphics.isTrue);
			num += GameCanvas.hText;
		}
		if (GameCanvas.currentScreen == this && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
		{
			base.paint(g);
		}
	}

	// Token: 0x060005AC RID: 1452 RVA: 0x00053054 File Offset: 0x00051254
	public void updateShow()
	{
		if (this.clanShow.slogan.Length > 100)
		{
			this.init(220);
		}
		else if (this.clanShow.noiquy.Length > 100)
		{
			this.init(220);
		}
		this.mslogan = mFont.tahoma_7_white.splitFontArray(this.clanShow.slogan, this.wScreen - 10);
		this.mnoiquy = mFont.tahoma_7_white.splitFontArray(this.clanShow.noiquy, this.wScreen - 10);
		int num = GameCanvas.hCommand + 2 + (6 + this.mnoiquy.Length + this.mslogan.Length) * GameCanvas.hText;
		if (this.clanShow.mthanhtich != null)
		{
			num += 20 * this.clanShow.mthanhtich.Length + 5;
		}
		if (num > this.hScreen - GameCanvas.hCommand - this.hTouch - 5)
		{
			this.list = new ListNew(this.xbegin, this.ybegin, this.wScreen, this.hScreen, 0, 0, num - (this.hScreen - GameCanvas.hCommand - this.hTouch - 5));
		}
		else
		{
			this.list = new ListNew(this.xbegin, this.ybegin, this.wScreen, this.hScreen, 0, 0, 0);
		}
		this.cam.setAll(0, this.list.cmxLim, 0, 0);
		Clan_Screen.isUpdateThongTin = false;
	}

	// Token: 0x060005AD RID: 1453 RVA: 0x000531DC File Offset: 0x000513DC
	public override void update()
	{
		if (this.lastScreen != null)
		{
			this.lastScreen.update();
		}
		if (Clan_Screen.isUpdateThongTin)
		{
			this.updateShow();
			Clan_Screen.isUpdateThongTin = false;
		}
		if (GameCanvas.isTouch)
		{
			this.list.moveCamera();
			this.cam.yCam = this.list.cmx;
		}
		else
		{
			this.cam.UpdateCamera();
		}
		base.update();
	}

	// Token: 0x060005AE RID: 1454 RVA: 0x00053258 File Offset: 0x00051458
	public override void updatekey()
	{
		if (this.cam.yLimit > 0)
		{
			if (GameCanvas.keyMyHold[2])
			{
				if (this.cam.yTo > 0)
				{
					this.cam.yTo -= GameCanvas.hText;
				}
				if (this.cam.yTo < 0)
				{
					this.cam.yTo = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				if (this.cam.yTo < this.cam.yLimit)
				{
					this.cam.yTo += GameCanvas.hText;
				}
				if (this.cam.yTo > this.cam.yLimit)
				{
					this.cam.yTo = this.cam.yLimit;
				}
				GameCanvas.clearKeyHold(2);
			}
		}
		base.updatekey();
	}

	// Token: 0x060005AF RID: 1455 RVA: 0x00053350 File Offset: 0x00051550
	public override void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			this.list.update_Pos_UP_DOWN();
		}
		base.updatePointer();
	}

	// Token: 0x040007FF RID: 2047
	public const sbyte MY_CLAN = 0;

	// Token: 0x04000800 RID: 2048
	public const sbyte VIEW_CLAN = 1;

	// Token: 0x04000801 RID: 2049
	public static bool isUpdateThongTin = true;

	// Token: 0x04000802 RID: 2050
	private int xbegin;

	// Token: 0x04000803 RID: 2051
	private int ybegin;

	// Token: 0x04000804 RID: 2052
	private int wScreen;

	// Token: 0x04000805 RID: 2053
	private int hScreen;

	// Token: 0x04000806 RID: 2054
	private int hTouch;

	// Token: 0x04000807 RID: 2055
	private MainClan clanShow;

	// Token: 0x04000808 RID: 2056
	private string[] mslogan;

	// Token: 0x04000809 RID: 2057
	private string[] mnoiquy;

	// Token: 0x0400080A RID: 2058
	private sbyte type;

	// Token: 0x0400080B RID: 2059
	private iCommand cmdMenu;

	// Token: 0x0400080C RID: 2060
	private iCommand cmdXinvao;

	// Token: 0x0400080D RID: 2061
	private iCommand cmdXemList;

	// Token: 0x0400080E RID: 2062
	private iCommand cmdGopXu;

	// Token: 0x0400080F RID: 2063
	private iCommand cmdGopLuong;

	// Token: 0x04000810 RID: 2064
	private iCommand cmdInfoMySeft;

	// Token: 0x04000811 RID: 2065
	private iCommand cmdChucNang;

	// Token: 0x04000812 RID: 2066
	private iCommand cmdChangeSlogan;

	// Token: 0x04000813 RID: 2067
	private iCommand cmdChangeNoiQuy;

	// Token: 0x04000814 RID: 2068
	private iCommand cmdPhongcap;

	// Token: 0x04000815 RID: 2069
	private iCommand cmdClose;

	// Token: 0x04000816 RID: 2070
	private iCommand cmdRoiClan;

	// Token: 0x04000817 RID: 2071
	private iCommand cmdChatBang;

	// Token: 0x04000818 RID: 2072
	private iCommand cmdThongBao;

	// Token: 0x04000819 RID: 2073
	private iCommand cmdInvenClan;

	// Token: 0x0400081A RID: 2074
	private InputDialog inputDialog;

	// Token: 0x0400081B RID: 2075
	private ListNew list;

	// Token: 0x0400081C RID: 2076
	private Camera cam = new Camera();

	// Token: 0x0400081D RID: 2077
	public sbyte[] frameicon = new sbyte[]
	{
		0,
		1,
		2,
		1
	};

	// Token: 0x0400081E RID: 2078
	public sbyte frameClan;
}
