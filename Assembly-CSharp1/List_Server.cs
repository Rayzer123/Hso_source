using System;

// Token: 0x02000082 RID: 130
public class List_Server : MainScreen
{
	// Token: 0x06000624 RID: 1572 RVA: 0x0005BA64 File Offset: 0x00059C64
	public List_Server()
	{
		this.cmdClose = new iCommand(T.close, -1);
		this.cmdchat = new iCommand(T.trochuyen, 1, this);
		this.cmdMenuPoiter = new iCommand(T.menu, 3, this);
		this.cmdInfo = new iCommand(T.info, 4, this);
		this.prePage = new iCommand(T.vetruoc, 5, this);
		this.nextPage = new iCommand(T.toitruoc, 6, this);
		this.cmddelete = new iCommand(T.del, 0, this);
		this.cmdhoidelete = new iCommand(T.del, 2, this);
		this.cmdPhongchuc = new iCommand(T.phonghacap, 7, this);
		this.cmdDuoiMem = new iCommand(T.moiroiclan, 8, this);
		this.cmdInfoCLan = new iCommand(T.info, 10, this);
		this.cmdListMemClan = new iCommand(T.xemdanhsach, 11, this);
		this.cmdDongGopClan = new iCommand(T.donggopclan, 12, this);
		this.cmdUpdateFriendList = new iCommand(T.update, 13, this);
		this.cmdThidau = new iCommand(T.thachdau, 14, this);
	}

	// Token: 0x06000626 RID: 1574 RVA: 0x0005BC58 File Offset: 0x00059E58
	public static List_Server gI()
	{
		if (List_Server.me == null)
		{
			return List_Server.me = new List_Server();
		}
		return List_Server.me;
	}

	// Token: 0x06000627 RID: 1575 RVA: 0x0005BC78 File Offset: 0x00059E78
	public void doSetCaption()
	{
		this.cmdClose.caption = T.close;
		this.cmdchat.caption = T.trochuyen;
		this.cmdMenuPoiter.caption = T.menu;
		this.cmdInfo.caption = T.info;
		this.prePage.caption = T.vetruoc;
		this.nextPage.caption = T.toitruoc;
		this.cmddelete.caption = T.del;
		this.cmdhoidelete.caption = T.del;
		this.cmdPhongchuc.caption = T.phonghacap;
		this.cmdDuoiMem.caption = T.moiroiclan;
		this.cmdInfoCLan.caption = T.info;
		this.cmdListMemClan.caption = T.xemdanhsach;
		this.cmdDongGopClan.caption = T.donggopclan;
		this.cmdUpdateFriendList.caption = T.update;
		this.cmdThidau.caption = T.thachdau;
	}

	// Token: 0x06000628 RID: 1576 RVA: 0x0005BD78 File Offset: 0x00059F78
	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		this.Show(GameCanvas.currentScreen);
	}

	// Token: 0x06000629 RID: 1577 RVA: 0x0005BD90 File Offset: 0x00059F90
	public void setSize(sbyte type)
	{
		this.typeList = type;
		this.hItem = 50;
		if ((int)this.typeList == 2)
		{
			this.hItem = 70;
		}
		this.w = GameCanvas.w / 4 * 3;
		this.h = GameCanvas.h / 5 * 4;
		if (this.w < 160)
		{
			this.w = 160;
		}
		else if (this.w > 280)
		{
			this.w = 280;
		}
		if (this.h < 210)
		{
			this.h = 210;
		}
		else if (this.h > 280)
		{
			this.h = 280;
		}
		this.x = GameCanvas.hw - this.w / 2;
		this.y = GameCanvas.hh - this.h / 2;
		this.idSelect = 0;
		this.maxpaint = (this.h - GameCanvas.hCommand) / this.hItem + 3;
		if (this.vecListServer.size() > 0)
		{
			this.setXmove();
			MainScreen.cameraSub.setAll(0, this.vecListServer.size() * this.hItem - this.h + GameCanvas.hCommand + 10, 0, 0);
			this.list = new ListNew(this.x, this.y, this.w, this.h, this.hItem, 0, MainScreen.cameraSub.yLimit);
			this.min = 0;
			this.max = this.maxpaint;
			if (this.max > this.vecListServer.size())
			{
				this.max = this.vecListServer.size();
			}
			this.setCmd();
		}
		if (GameCanvas.isTouch)
		{
			this.cmdClose.setPos(this.x + this.w - 12, this.y + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		this.right = this.cmdClose;
	}

	// Token: 0x0600062A RID: 1578 RVA: 0x0005BFA0 File Offset: 0x0005A1A0
	private void doMenuPhongChuc()
	{
		if (this.idSelect >= 0 && this.idSelect < this.vecListServer.size())
		{
			MainObject mainObject = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject == null)
			{
				return;
			}
			mVector mVector = new mVector("List_server menu4");
			if ((int)GameScreen.player.myClan.chucvu == 127)
			{
				mVector.addElement(new iCommand(T.mChucVuClan[1], 9, 126, this));
			}
			if ((int)GameScreen.player.myClan.chucvu >= 126)
			{
				mVector.addElement(new iCommand(T.mChucVuClan[2], 9, 125, this));
			}
			if ((int)GameScreen.player.myClan.chucvu >= 125)
			{
				mVector.addElement(new iCommand(T.mChucVuClan[3], 9, 124, this));
				mVector.addElement(new iCommand(T.mChucVuClan[4], 9, 123, this));
				mVector.addElement(new iCommand(T.mChucVuClan[5], 9, 122, this));
			}
			GameCanvas.menu2.startAt(mVector, 2, mainObject.name, false, null);
		}
	}

	// Token: 0x0600062B RID: 1579 RVA: 0x0005C0C4 File Offset: 0x0005A2C4
	private void doMenuListClan()
	{
		if (this.idSelect >= 0 && this.idSelect < this.vecListServer.size())
		{
			MainClan mainClan = (MainClan)this.vecListServer.elementAt(this.idSelect);
			if (mainClan.hang == -1)
			{
				return;
			}
			mVector mVector = new mVector("List_server menu2");
			mVector.addElement(this.cmdInfoCLan);
			mVector.addElement(this.cmdListMemClan);
			GameCanvas.menu2.startAt(mVector, 2, T.clan, false, null);
		}
	}

	// Token: 0x0600062C RID: 1580 RVA: 0x0005C150 File Offset: 0x0005A350
	private void doMenuListTop()
	{
		if (this.idSelect >= 0 && this.idSelect < this.vecListServer.size())
		{
			MainObject mainObject = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject.name.CompareTo(GameScreen.player.name) == 0)
			{
				return;
			}
			mVector mVector = new mVector("List_server menu3");
			if ((int)this.typeList == 4)
			{
				if ((int)GameScreen.player.myClan.chucvu >= 125)
				{
					mVector.addElement(this.cmdPhongchuc);
					if ((int)GameScreen.player.myClan.chucvu >= 126)
					{
						mVector.addElement(this.cmdDuoiMem);
					}
				}
				mVector.addElement(this.cmdDongGopClan);
			}
			if (mainObject != null && (int)mainObject.typeOnline == 1 && mainObject.hang != -1 && mainObject.name.CompareTo(GameScreen.player.name) != 0)
			{
				mVector.addElement(this.cmdInfo);
				mVector.addElement(this.cmdchat);
			}
			GameCanvas.menu2.startAt(mVector, 2, T.chucnang, false, null);
		}
	}

	// Token: 0x0600062D RID: 1581 RVA: 0x0005C280 File Offset: 0x0005A480
	public void doMenu()
	{
		mVector mVector = new mVector("List_server menu");
		if ((int)this.typeList == 0)
		{
			mVector.addElement(this.cmdchat);
			mVector.addElement(this.cmdhoidelete);
			mVector.addElement(this.cmdUpdateFriendList);
		}
		if ((int)this.typeList != 6 && this.idSelect >= 0 && this.idSelect < this.vecListServer.size())
		{
			MainObject mainObject = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject != null && (int)mainObject.typeOnline == 1 && mainObject.hang != -1 && mainObject.name.CompareTo(GameScreen.player.name) != 0)
			{
				mVector.addElement(this.cmdInfo);
			}
		}
		if ((int)this.typeList == 6)
		{
			MainObject mainObject2 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject2 != null && mainObject2.hang != -1 && mainObject2.name.CompareTo(GameScreen.player.name) != 0)
			{
				mVector.addElement(this.cmdInfo);
				mVector.addElement(this.cmdThidau);
			}
		}
		if ((int)this.page != 99)
		{
			if ((int)this.page != 0)
			{
				this.prePage.caption = T.vetruoc + CRes.abs((int)this.page);
				mVector.addElement(this.prePage);
			}
			if ((int)this.page >= 0)
			{
				this.nextPage.caption = T.toitruoc + ((int)this.page + 2);
				mVector.addElement(this.nextPage);
			}
		}
		GameCanvas.menu2.startAt(mVector, 2, T.friend, false, null);
	}

	// Token: 0x0600062E RID: 1582 RVA: 0x0005C458 File Offset: 0x0005A658
	public override void commandTab(int index, int sub)
	{
		if (index == -1)
		{
			if (this.lastScreen == GameCanvas.AllInfo)
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			else
			{
				this.lastScreen.Show();
			}
		}
		base.commandTab(index, sub);
	}

	// Token: 0x0600062F RID: 1583 RVA: 0x0005C4B8 File Offset: 0x0005A6B8
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			MainObject mainObject = (MainObject)List_Server.vecMyFriend.elementAt(this.idSelect);
			GlobalService.gI().Friend(3, mainObject.name);
			List_Server.vecMyFriend.removeElementAt(this.idSelect);
			if (this.idSelect > 0)
			{
				this.idSelect--;
			}
			if (List_Server.vecMyFriend.size() == 0)
			{
				this.left = null;
				this.center = null;
			}
			GameCanvas.end_Dialog();
			break;
		}
		case 1:
		{
			MainObject mainObject2 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject2 != null && mainObject2.hang != -1)
			{
				GameCanvas.msgchat.addNewChat(mainObject2.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
				GameCanvas.start_Chat_Dialog();
			}
			break;
		}
		case 2:
			GameCanvas.start_Left_Dialog(T.deleteFriend, this.cmddelete);
			break;
		case 3:
			if ((int)this.typeList == 1 || (int)this.typeList == 0 || (int)this.typeList == 6)
			{
				this.doMenu();
			}
			else if ((int)this.typeList == 5 || (int)this.typeList == 4)
			{
				this.doMenuListTop();
			}
			else if ((int)this.typeList == 3)
			{
				this.doMenuListClan();
			}
			break;
		case 4:
		{
			if (this.idSelect < 0 || this.idSelect >= this.vecListServer.size())
			{
				return;
			}
			MainObject mainObject3 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject3 != null && mainObject3.hang != -1)
			{
				if ((int)this.typeList == 6)
				{
					GlobalService.gI().Re_Info_Other_Object(mainObject3.name, Info_Other_Player.THACH_DAU_INFO);
				}
				else
				{
					GlobalService.gI().Re_Info_Other_Object(mainObject3.name, Info_Other_Player.VIEW);
				}
			}
			break;
		}
		case 5:
			GlobalService.gI().set_Page((sbyte)(CRes.abs((int)this.page) - 1));
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 6:
			GlobalService.gI().set_Page((sbyte)CRes.abs((int)this.page + 1));
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 7:
			this.doMenuPhongChuc();
			break;
		case 8:
		{
			MainObject mainObject4 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject4 != null)
			{
				GlobalService.gI().Delete_Mem_Clan(18, mainObject4.name);
			}
			break;
		}
		case 9:
		{
			MainObject mainObject4 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject4 != null)
			{
				GlobalService.gI().PhongCap_Clan(4, (sbyte)subIndex, mainObject4.name);
			}
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		}
		case 10:
		{
			MainClan mainClan = (MainClan)this.vecListServer.elementAt(this.idSelect);
			if (mainClan != null && mainClan.hang != -1)
			{
				GlobalService.gI().ChucNang_Clan(15, mainClan.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 11:
		{
			MainClan mainClan2 = (MainClan)this.vecListServer.elementAt(this.idSelect);
			if (mainClan2 != null && mainClan2.hang != -1)
			{
				GlobalService.gI().ChucNang_Clan(13, mainClan2.IdClan);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 12:
		{
			MainObject mainObject4 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject4 != null)
			{
				GlobalService.gI().info_Mem_Clan(14, mainObject4.name);
				GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			}
			break;
		}
		case 13:
			GlobalService.gI().Friend(4, string.Empty);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.cancel, -1));
			break;
		case 14:
		{
			if (this.idSelect < 0 || this.idSelect >= this.vecListServer.size())
			{
				return;
			}
			MainObject mainObject5 = (MainObject)this.vecListServer.elementAt(this.idSelect);
			if (mainObject5 != null && mainObject5.hang != -1)
			{
				GlobalService.gI().doSendThachDau(0, mainObject5.name);
			}
			break;
		}
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000630 RID: 1584 RVA: 0x0005C964 File Offset: 0x0005AB64
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
		base.paintFormList(g, this.x, this.y, this.w, this.h, this.nameList);
		g.translate(this.x, this.y + GameCanvas.hCommand);
		g.setClip(3, 0, this.w, this.h - GameCanvas.hCommand);
		int ybegin = 5;
		if (this.vecListServer == null)
		{
			return;
		}
		if (this.vecListServer.size() > 0)
		{
			if ((int)this.typeList == 3)
			{
				this.paintTopClan(g, ybegin);
			}
			else
			{
				this.paintTopNormal(g, ybegin);
			}
		}
		else if ((int)this.typeList == 0)
		{
			mFont.tahoma_7_white.drawString(g, T.nullFriend, this.w / 2, ybegin, 2, mGraphics.isTrue);
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, T.listnull, this.w / 2, ybegin, 2, mGraphics.isTrue);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this && !ChatTextField.isShow && GameCanvas.subDialog == null)
		{
			base.paint(g);
		}
	}

	// Token: 0x06000631 RID: 1585 RVA: 0x0005CAC8 File Offset: 0x0005ACC8
	private void paintTopClan(mGraphics g, int ybegin)
	{
		g.setColor(10259575);
		g.fillRect(3, -MainScreen.cameraSub.yCam + ybegin + this.idSelect * this.hItem + 1, this.w - 6, this.hItem - 1, mGraphics.isTrue);
		g.translate(0, -MainScreen.cameraSub.yCam);
		ybegin += this.min * this.hItem;
		for (int i = this.min; i < this.max; i++)
		{
			MainClan mainClan = (MainClan)this.vecListServer.elementAt(i);
			if (mainClan.hang == -1)
			{
				mFont.tahoma_7b_white.drawString(g, mainClan.shortName, 20, ybegin + 5, 0, mGraphics.isTrue);
				ybegin += this.hItem;
			}
			else
			{
				MainImage imageIconClan = ObjectData.getImageIconClan(mainClan.IdIcon);
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							mainClan.frameClan = (sbyte)(((int)mainClan.frameClan + 1) % 3);
						}
						g.drawRegion(imageIconClan.img, 0, (int)mainClan.frameClan * 18, 18, 18, 0, 9, ybegin + 11, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, 9, ybegin + 11, 3, mGraphics.isTrue);
					}
				}
				if (GameScreen.player.myClan != null && GameScreen.player.myClan.shortName.CompareTo(mainClan.shortName) == 0)
				{
					AvMain.Font3dWhite(g, mainClan.shortName + " - " + mainClan.name, 20, ybegin + 5, 0);
				}
				else
				{
					mFont.tahoma_7b_white.drawString(g, mainClan.shortName + " - " + mainClan.name, 20, ybegin + 5, 0, mGraphics.isTrue);
				}
				int num = 10;
				mFont.tahoma_7_white.drawString(g, mainClan.slogan, num, 20 + ybegin, 0, mGraphics.isTrue);
				if (mainClan.hang < 4)
				{
					mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainClan.hang], num, 35 + ybegin, 0, mGraphics.isTrue);
				}
				else
				{
					mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainClan.hang + 1), num, 35 + ybegin, 0, mGraphics.isTrue);
				}
				ybegin += this.hItem;
				if (i < this.vecListServer.size() - 1)
				{
					g.setColor(AvMain.color[4]);
					g.fillRect(4, ybegin, this.w - 8, 1, mGraphics.isTrue);
				}
			}
		}
	}

	// Token: 0x06000632 RID: 1586 RVA: 0x0005CD88 File Offset: 0x0005AF88
	public void paintTopNormal(mGraphics g, int ybegin)
	{
		g.setColor(10259575);
		g.fillRect(3, -MainScreen.cameraSub.yCam + ybegin + this.idSelect * this.hItem + 1, this.w - 6, this.hItem - 1, mGraphics.isTrue);
		g.translate(0, -MainScreen.cameraSub.yCam);
		ybegin += this.min * this.hItem;
		for (int i = this.min; i < this.max; i++)
		{
			if (i >= 0 && i < this.vecListServer.size())
			{
				MainObject mainObject = (MainObject)this.vecListServer.elementAt(i);
				if (mainObject.hang == -1)
				{
					mainObject.paintNameShow(g, 50, 5 + ybegin, true);
					ybegin += this.hItem;
					if (i < this.vecListServer.size() - 1)
					{
						g.setColor(AvMain.color[4]);
						g.fillRect(4, ybegin, this.w - 8, 1, mGraphics.isTrue);
					}
				}
				else
				{
					mainObject.paintShowPlayer(g, 20, 40 + ybegin, 0);
					this.paintIconOnline(g, mainObject.typeOnline, 40, 10 + ybegin);
					if (mainObject.name.CompareTo(GameScreen.player.name) == 0)
					{
						string nameAndClan = mainObject.getNameAndClan(" - ");
						int num = 0;
						if (mainObject.myClan != null)
						{
							num = 16;
							mainObject.paintIconClan(g, 50 + num - 7, 5 + ybegin + 6, -1);
						}
						AvMain.FontBorderColor(g, nameAndClan, 50 + num, 5 + ybegin, 0, 0);
					}
					else
					{
						mainObject.paintNameShow(g, 50, 5 + ybegin, true);
					}
					int num2 = 40;
					if (i == this.idSelect)
					{
						g.setClip(35, MainScreen.cameraSub.yCam, this.w - 40, this.h - GameCanvas.hCommand);
						num2 -= this.xMove;
					}
					if ((int)this.typeList == 6)
					{
						if (mainObject.hang < 4)
						{
							mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainObject.hang], num2, 35 + ybegin, 0, mGraphics.isTrue);
						}
						else
						{
							mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainObject.hang + 1), num2, 35 + ybegin, 0, mGraphics.isTrue);
						}
						mFont.tahoma_7_white.drawString(g, mainObject.infoObject, num2, 20 + ybegin, 0, mGraphics.isTrue);
					}
					else if ((int)this.typeList == 4 || (int)this.typeList == 5)
					{
						mFont.tahoma_7_white.drawString(g, T.level + mainObject.Lv, num2, 20 + ybegin, 0, mGraphics.isTrue);
						mFont.tahoma_7_white.drawString(g, MainClan.getNameChucVu(mainObject.myClan.chucvu), num2, 35 + ybegin, 0, mGraphics.isTrue);
					}
					else
					{
						mFont.tahoma_7_white.drawString(g, mainObject.infoObject, num2, 20 + ybegin, 0, mGraphics.isTrue);
						if ((int)this.typeList == 1)
						{
							if (mainObject.hang < 4)
							{
								mFont.tahoma_7b_white.drawString(g, T.hang + " " + T.mhang[mainObject.hang], num2, 35 + ybegin, 0, mGraphics.isTrue);
							}
							else
							{
								mFont.tahoma_7_white.drawString(g, T.hang + " " + (mainObject.hang + 1), num2, 35 + ybegin, 0, mGraphics.isTrue);
							}
						}
					}
					if (i == this.idSelect)
					{
						g.setClip(5, MainScreen.cameraSub.yCam, this.w - 10, this.h - GameCanvas.hCommand);
					}
					ybegin += this.hItem;
					if (i < this.vecListServer.size() - 1)
					{
						g.setColor(AvMain.color[4]);
						g.fillRect(4, ybegin, this.w - 8, 1, mGraphics.isTrue);
					}
				}
			}
		}
	}

	// Token: 0x06000633 RID: 1587 RVA: 0x0005D19C File Offset: 0x0005B39C
	public void paintAr(mGraphics g, int max, int cur, int x, int y)
	{
		g.setColor(0);
		g.fillRect(x, y + 1, 62, 7, mGraphics.isTrue);
		g.fillRect(x + 1, y, 60, 1, mGraphics.isTrue);
		g.fillRect(x + 1, y + 8, 60, 1, mGraphics.isTrue);
		if (cur > 0)
		{
			int num = cur * 60 / max;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > 60)
			{
				num = 60;
			}
			g.setColor(2340367);
			g.fillRect(x + 1, y, num, 1, mGraphics.isTrue);
		}
		mFont.tahoma_7_white.drawString(g, cur + "/" + max, x + 31, y + 4, 2, mGraphics.isTrue);
	}

	// Token: 0x06000634 RID: 1588 RVA: 0x0005D264 File Offset: 0x0005B464
	private void paintIconOnline(mGraphics g, sbyte online, int x, int y)
	{
		int idx = 0;
		if ((int)online == 0)
		{
			idx = 2;
		}
		PaintInfoGameScreen.fraStatusArea.drawFrame(idx, x, y, 0, 3, g);
	}

	// Token: 0x06000635 RID: 1589 RVA: 0x0005D290 File Offset: 0x0005B490
	public override void update()
	{
		this.lastScreen.update();
		if (this.limitMove > 0)
		{
			this.xMove += 2;
			if (this.xMove > this.limitMove)
			{
				this.xMove = 0;
			}
		}
		if (this.vecListServer.size() > 0)
		{
			if (GameCanvas.isTouch && this.list != null)
			{
				this.list.moveCamera();
			}
			else
			{
				MainScreen.cameraSub.UpdateCamera();
			}
			if (MainScreen.cameraSub.yCam != MainScreen.cameraSub.yTo)
			{
				this.setMinMax();
			}
		}
		else if (this.center != null || this.left != null)
		{
			this.center = null;
			this.left = null;
		}
	}

	// Token: 0x06000636 RID: 1590 RVA: 0x0005D364 File Offset: 0x0005B564
	public override void updatekey()
	{
		if (this.vecListServer.size() > 0)
		{
			int num = this.idSelect;
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
			this.idSelect = base.resetSelect(this.idSelect, this.vecListServer.size() - 1, false);
			if (num != this.idSelect)
			{
				this.setXmove();
				MainScreen.cameraSub.moveCamera(0, this.idSelect * this.hItem - this.h / 2 + 40 + GameCanvas.hCommand);
			}
		}
		base.updatekey();
	}

	// Token: 0x06000637 RID: 1591 RVA: 0x0005D430 File Offset: 0x0005B630
	public override void updatePointer()
	{
		if (this.vecListServer.size() > 0)
		{
			if (GameCanvas.isPointSelect(this.x, this.y + GameCanvas.hCommand, this.w, this.h - GameCanvas.hCommand))
			{
				int num = (MainScreen.cameraSub.yCam + GameCanvas.py - this.y - GameCanvas.hCommand) / this.hItem;
				if (num >= 0 && num < this.vecListServer.size())
				{
					GameCanvas.isPointerSelect = false;
					if (num == this.idSelect)
					{
						this.cmdMenuPoiter.perform();
					}
					else
					{
						this.idSelect = num;
						this.setXmove();
					}
				}
				else
				{
					this.idSelect = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.isTouch && this.list != null)
			{
				this.list.update_Pos_UP_DOWN();
				MainScreen.cameraSub.yCam = this.list.cmx;
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000638 RID: 1592 RVA: 0x0005D538 File Offset: 0x0005B738
	public void setMinMax()
	{
		this.min = MainScreen.cameraSub.yCam / this.hItem - 1;
		if (this.min < 0)
		{
			this.min = 0;
		}
		this.max = this.min + this.maxpaint;
		if (this.max > this.vecListServer.size())
		{
			this.max = this.vecListServer.size();
			this.min = this.max - this.maxpaint;
			if (this.min < 0)
			{
				this.min = 0;
			}
		}
	}

	// Token: 0x06000639 RID: 1593 RVA: 0x0005D5D4 File Offset: 0x0005B7D4
	public void setXmove()
	{
		if (this.vecListServer == null || this.idSelect == -1 || this.idSelect > this.vecListServer.size() - 1)
		{
			return;
		}
		this.xMove = 0;
		string st = string.Empty;
		int num = 40;
		if ((int)this.typeList == 3)
		{
			MainClan mainClan = (MainClan)this.vecListServer.elementAt(this.idSelect);
			if (mainClan.hang != -1)
			{
				st = mainClan.slogan;
			}
			num = 20;
		}
		else
		{
			MainObject mainObject = (MainObject)this.vecListServer.elementAt(this.idSelect);
			st = mainObject.infoObject;
		}
		if ((int)this.typeList == 2)
		{
			num = 50;
		}
		this.limitMove = mFont.tahoma_7_black.getWidth(st) - (this.w - num) + 5;
		if (this.limitMove > 0)
		{
			this.limitMove += 25;
		}
	}

	// Token: 0x0600063A RID: 1594 RVA: 0x0005D6C8 File Offset: 0x0005B8C8
	public void setCmd()
	{
		if (this.vecListServer.size() > 0 && !GameCanvas.isTouch)
		{
			this.left = this.cmdMenuPoiter;
			if ((int)this.typeList == 0)
			{
				this.center = this.cmdchat;
			}
		}
	}

	// Token: 0x0600063B RID: 1595 RVA: 0x0005D714 File Offset: 0x0005B914
	public void updateList()
	{
		MainScreen.cameraSub.setAll(0, this.vecListServer.size() * this.hItem - this.h + GameCanvas.hCommand + 10, 0, 0);
		this.list = new ListNew(this.x, this.y, this.w, this.h, this.hItem, 0, MainScreen.cameraSub.yLimit);
	}

	// Token: 0x040008D0 RID: 2256
	public const sbyte FRIEND = 0;

	// Token: 0x040008D1 RID: 2257
	public const sbyte LIST_TOP = 1;

	// Token: 0x040008D2 RID: 2258
	public const sbyte LIST_ARCHE = 2;

	// Token: 0x040008D3 RID: 2259
	public const sbyte LIST_CLAN = 3;

	// Token: 0x040008D4 RID: 2260
	public const sbyte LIST_MEM_CLAN = 4;

	// Token: 0x040008D5 RID: 2261
	public const sbyte LIST_MEM_OTHER_CLAN = 5;

	// Token: 0x040008D6 RID: 2262
	public const sbyte LIST_THI_DAU = 6;

	// Token: 0x040008D7 RID: 2263
	public static List_Server me;

	// Token: 0x040008D8 RID: 2264
	public mVector vecListServer = new mVector("List_server vecListServer");

	// Token: 0x040008D9 RID: 2265
	public static mVector vecMyFriend = new mVector("List_server vecMyFriend");

	// Token: 0x040008DA RID: 2266
	public static mVector vecArche = new mVector("List_server vecMyFriend");

	// Token: 0x040008DB RID: 2267
	public static bool isLoadFriend = false;

	// Token: 0x040008DC RID: 2268
	private int idSelect;

	// Token: 0x040008DD RID: 2269
	private int xMove;

	// Token: 0x040008DE RID: 2270
	private int limitMove;

	// Token: 0x040008DF RID: 2271
	private int hItem = 50;

	// Token: 0x040008E0 RID: 2272
	private int maxpaint;

	// Token: 0x040008E1 RID: 2273
	private int min;

	// Token: 0x040008E2 RID: 2274
	private int max;

	// Token: 0x040008E3 RID: 2275
	private int x;

	// Token: 0x040008E4 RID: 2276
	private int y;

	// Token: 0x040008E5 RID: 2277
	private int w;

	// Token: 0x040008E6 RID: 2278
	private int h;

	// Token: 0x040008E7 RID: 2279
	private iCommand cmdchat;

	// Token: 0x040008E8 RID: 2280
	private iCommand cmdMenuPoiter;

	// Token: 0x040008E9 RID: 2281
	private iCommand cmdInfo;

	// Token: 0x040008EA RID: 2282
	private iCommand cmdClose;

	// Token: 0x040008EB RID: 2283
	private iCommand nextPage;

	// Token: 0x040008EC RID: 2284
	private iCommand prePage;

	// Token: 0x040008ED RID: 2285
	private iCommand cmddelete;

	// Token: 0x040008EE RID: 2286
	private iCommand cmdhoidelete;

	// Token: 0x040008EF RID: 2287
	private iCommand cmdPhongchuc;

	// Token: 0x040008F0 RID: 2288
	private iCommand cmdDuoiMem;

	// Token: 0x040008F1 RID: 2289
	private iCommand cmdInfoCLan;

	// Token: 0x040008F2 RID: 2290
	private iCommand cmdListMemClan;

	// Token: 0x040008F3 RID: 2291
	private iCommand cmdDongGopClan;

	// Token: 0x040008F4 RID: 2292
	private iCommand cmdUpdateFriendList;

	// Token: 0x040008F5 RID: 2293
	private iCommand cmdThidau;

	// Token: 0x040008F6 RID: 2294
	private ListNew list;

	// Token: 0x040008F7 RID: 2295
	public string nameList;

	// Token: 0x040008F8 RID: 2296
	public sbyte page;

	// Token: 0x040008F9 RID: 2297
	public sbyte typeList;

	// Token: 0x040008FA RID: 2298
	private int[][] mPosStar = new int[][]
	{
		new int[]
		{
			6,
			20
		},
		new int[]
		{
			22,
			18
		},
		new int[]
		{
			38,
			20
		},
		new int[]
		{
			14,
			8
		},
		new int[]
		{
			30,
			8
		}
	};

	// Token: 0x040008FB RID: 2299
	public sbyte[] frameicon = new sbyte[]
	{
		0,
		1,
		2,
		1
	};

	// Token: 0x040008FC RID: 2300
	public sbyte frameClan;

	// Token: 0x040008FD RID: 2301
	private bool isTran;

	// Token: 0x040008FE RID: 2302
	private int yCamBegin;
}
