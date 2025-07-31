using System;

// Token: 0x02000099 RID: 153
public class MsgDialog : MainDialog
{
	// Token: 0x06000754 RID: 1876 RVA: 0x00070E34 File Offset: 0x0006F034
	public MsgDialog()
	{
		GameCanvas.closeKeyBoard();
		MsgDialog.me = this;
	}

	// Token: 0x06000756 RID: 1878 RVA: 0x00070F34 File Offset: 0x0006F134
	public override void commandTab(int index, int subIndex)
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		switch (index + 1)
		{
		case 0:
		case 8:
			this.closeDialog();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.isMelogin = false;
			MsgDialog.isAutologin = false;
			return;
		case 1:
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
						this.closeDialog();
					}
					else
					{
						GameCanvas.login.Show();
						this.closeDialog();
					}
				}
			}
			else
			{
				if (GameCanvas.currentScreen != GameCanvas.login)
				{
					GameCanvas.login.Show();
				}
				this.closeDialog();
			}
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			GlobalLogicHandler.isMelogin = false;
			return;
		case 2:
			this.closeDialog();
			return;
		case 3:
			GlobalService.gI().quest((short)this.IdQuest, this.main_sub_quest, (sbyte)this.typeQuest);
			this.closeDialog();
			return;
		case 4:
			GameCanvas.worldmap.Show(GameCanvas.game);
			this.closeDialog();
			return;
		case 5:
			this.setMenuParty();
			return;
		case 6:
			Player.isAutoHPMP = true;
			Player.mhotkey[Player.levelTab][4].type = HotKey.NULL;
			Player.mhotkey[Player.levelTab][3].type = HotKey.NULL;
			MainItem.setAddHotKey(1, MsgDialog.isUutien != 0);
			MainItem.setAddHotKey(0, MsgDialog.isUutien != 0);
			MainRMS.setSaveAuto();
			TabSkillsNew.saveSkill();
			this.closeDialog();
			return;
		case 7:
			GameScreen.player.resetPlayer();
			GameCanvas.login.Show();
			this.closeDialog();
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isDisConect = false;
			MsgDialog.isAutologin = false;
			GlobalLogicHandler.isMelogin = false;
			return;
		case 9:
			if (Player.party == null)
			{
				return;
			}
			if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
			{
				this.setChucNangParty();
			}
			else
			{
				mVector mVector = new mVector("MsgChat menu");
				iCommand o = new iCommand(T.leave, 8, this);
				mVector.addElement(o);
				iCommand o2 = new iCommand(T.chatParty, 15, this);
				mVector.addElement(o2);
				GameCanvas.menu2.startAt(mVector, 2, T.chucnang, false, null);
			}
			return;
		case 10:
		{
			int num = -1;
			if ((int)this.mvalueItem[0] < (int)((sbyte)(T.mValueAutoItem[0].Length - 1)))
			{
				num = (int)this.mvalueItem[0];
			}
			Player.autoItem = new AutoGetItem((sbyte)num, this.mvalueItem[1], this.mvalueItem[2]);
			MainRMS.setSaveAuto();
			this.closeDialog();
			return;
		}
		case 11:
			if (this.idSelect >= 0 && this.idSelect < (int)MsgDialog.MaxSkillBuff)
			{
				this.setAutoBuff(this.idSelect);
			}
			return;
		case 12:
			MsgDialog.setMusic();
			this.closeDialog();
			return;
		case 16:
			this.closeDialog();
			GlobalService.gI().arena((sbyte)index);
			return;
		case 17:
			this.closeDialog();
			GameScreen.player.resetAction();
			Session_ME.gI().close();
			GameCanvas.login.Show();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			SelectCharScreen.reSelect = false;
			SelectCharScreen.Canselect = false;
			return;
		}
		this.closeDialog();
	}

	// Token: 0x06000757 RID: 1879 RVA: 0x00071388 File Offset: 0x0006F588
	public override void commandPointer(int index, int subIndex)
	{
		GameCanvas.clearKeyHold();
		GameCanvas.clearKeyPressed();
		switch (index + 1)
		{
		case 0:
			this.closeDialog();
			break;
		case 3:
			if (Player.party == null)
			{
				return;
			}
			if (this.idSelect >= 0 && this.idSelect < Player.party.vecPartys.size())
			{
				ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
				GameCanvas.start_Left_Dialog(T.hoivaonhom + objectParty.name + "?", new iCommand(T.gianhap, 0, this));
			}
			break;
		case 4:
			if (Player.party == null)
			{
				return;
			}
			if (this.idSelect >= 0 && this.idSelect < Player.party.vecPartys.size())
			{
				GameCanvas.start_Left_Dialog(T.hoilapnhom, new iCommand(T.gianhap, 1, this));
			}
			break;
		case 7:
		{
			if (Player.party == null)
			{
				return;
			}
			ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
			GlobalService.gI().Party(3, objectParty.name);
			break;
		}
		case 8:
			this.closeDialog();
			GlobalService.gI().Party(4, string.Empty);
			break;
		case 9:
			this.closeDialog();
			GlobalService.gI().Party(5, string.Empty);
			break;
		case 10:
		{
			if (Player.party == null)
			{
				return;
			}
			ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
			GlobalService.gI().Friend(0, objectParty.name);
			break;
		}
		case 11:
			if (this.quest == null)
			{
				return;
			}
			GameCanvas.start_Left_Dialog(T.hoihuyQuest + this.quest.name, new iCommand(T.cancel, 11, this));
			break;
		case 12:
			if (this.quest == null)
			{
				return;
			}
			GlobalService.gI().quest((short)this.quest.ID, (!this.quest.isMain) ? 1 : 0, 2);
			TabQuest.me.resetTab(true);
			if (!GameScreen.help.setStep_Next(9, 0))
			{
				this.closeDialog();
				this.closeDialog();
			}
			break;
		case 13:
			if (this.link.Length > 0)
			{
				TemMidlet.openUrl(this.link);
			}
			break;
		case 15:
		{
			if (Player.party == null)
			{
				return;
			}
			ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
			GameCanvas.msgchat.addNewChat(objectParty.name, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			GameCanvas.start_Chat_Dialog();
			break;
		}
		case 16:
			GameCanvas.msgchat.addNewChat(T.party, string.Empty, string.Empty, ChatDetail.TYPE_CHAT, true);
			GameCanvas.start_Chat_Dialog();
			break;
		case 17:
		{
			mVector mVector = new mVector("MsgChat vec");
			mVector.addElement(new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.choan, -1, TabShopNew.INVEN_FOOD_PET)
			{
				petCur = MsgDialog.pet
			});
			GameCanvas.foodPet = new TabScreenNew();
			GameCanvas.foodPet.selectTab = 0;
			GameCanvas.foodPet.addMoreTab(mVector);
			GameCanvas.foodPet.Show(GameCanvas.currentScreen);
			break;
		}
		}
	}

	// Token: 0x06000758 RID: 1880 RVA: 0x0007171C File Offset: 0x0006F91C
	public void beginDia()
	{
		GameScreen.player.resetVx_vy();
		this.left = null;
		this.right = null;
		this.center = null;
		this.cmdList.removeAllElements();
	}

	// Token: 0x06000759 RID: 1881 RVA: 0x00071754 File Offset: 0x0006F954
	public void setinfo(string info, iCommand cmd, bool isOnlyCenter)
	{
		this.beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 0;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.cmdList = new mVector("MsgChat cmdlist2");
		this.cmdList.addElement(cmd);
		if (!isOnlyCenter)
		{
			this.cmdList.addElement(this.cmdClose);
		}
		int num = this.cmdList.size();
		if (this.wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			this.wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (this.wDia > GameCanvas.w)
		{
			this.wDia = GameCanvas.w;
		}
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x0600075A RID: 1882 RVA: 0x000718CC File Offset: 0x0006FACC
	public void setinfoDownload(string info, string link, bool isOnlyCenter)
	{
		this.beginDia();
		this.link = link;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 0;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.cmdList = new mVector("MsgChat cmdlist3");
		iCommand o = new iCommand(T.yes, 12, this);
		this.cmdList.addElement(o);
		this.cmdList.addElement(this.cmdClose);
		int num = this.cmdList.size();
		if (this.wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			this.wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (this.wDia > GameCanvas.w)
		{
			this.wDia = GameCanvas.w;
		}
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x0600075B RID: 1883 RVA: 0x00071A44 File Offset: 0x0006FC44
	public void setinfoWait(string info, iCommand cmd)
	{
		this.beginDia();
		this.isWaiting = true;
		this.isSpec = false;
		this.type = 0;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.cmdList = new mVector("MsgChat cmdlist7");
		this.hWait = 0;
		if (cmd != null)
		{
			this.cmdList.addElement(cmd);
			this.hWait = iCommand.hButtonCmd;
		}
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus + this.hWait;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x0600075C RID: 1884 RVA: 0x00071B5C File Offset: 0x0006FD5C
	public void setinfo(string info, mVector cmd)
	{
		this.beginDia();
		if (cmd == null || cmd.size() <= 0)
		{
			GameCanvas.currentDialog = null;
		}
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 0;
		this.cmdList = cmd;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		int num = this.cmdList.size();
		if (this.wDia < 2 * iCommand.wButtonCmd + 10)
		{
			this.wDia = 2 * iCommand.wButtonCmd + 10;
		}
		if (this.wDia > GameCanvas.w)
		{
			this.wDia = GameCanvas.w;
		}
		int num2 = 0;
		if (this.cmdList.size() > 2)
		{
			num2 = iCommand.hButtonCmd;
		}
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus + num2;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5 + ((num <= 2) ? 0 : (iCommand.hButtonCmd + 5));
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x0600075D RID: 1885 RVA: 0x00071CD4 File Offset: 0x0006FED4
	public void setinfoQuest(string info, string status, int IDQuest, int typeQuest, sbyte mainsub)
	{
		this.beginDia();
		this.hSpe = 2;
		this.IdQuest = IDQuest;
		this.typeQuest = typeQuest;
		this.main_sub_quest = mainsub;
		this.isSpec = true;
		iCommand iCommand = new iCommand(T.nhan, 2);
		if (typeQuest == 1)
		{
			iCommand.caption = T.tra;
			this.cmdList.addElement(iCommand);
		}
		else
		{
			this.cmdList.addElement(iCommand);
			iCommand o = new iCommand(T.close, 1);
			if ((int)mainsub == 1)
			{
				this.cmdList.addElement(o);
			}
		}
		this.status = status;
		this.wStatus = mFont.tahoma_7b_white.getWidth(status) + 20;
		this.isWaiting = false;
		this.type = 1;
		this.sizeButtonQuest = 1;
		this.wDia = GameCanvas.w / 5 * 4;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.strinfo = mFont.tahoma_7_white.splitFontArray(info, this.wDia - 20);
		this.hDia = GameCanvas.hText * (this.strinfo.Length + 1) + MsgDialog.hPlus + 20 + ((this.cmdList.size() <= 2) ? 0 : (iCommand.hButtonCmd + 5));
		if (this.hDia > GameCanvas.h / 2 + 10)
		{
			this.hDia = GameCanvas.h / 2 + 10;
		}
		this.cameraDia.setAll(0, GameCanvas.hText * (this.strinfo.Length + 1) + 30 - this.hDia, 0, 0);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x0600075E RID: 1886 RVA: 0x00071EC0 File Offset: 0x000700C0
	public void setinfoQuestRead(MainQuest quest)
	{
		this.beginDia();
		this.hSpe = 2;
		this.status = quest.name;
		this.quest = quest;
		this.isSpec = true;
		this.wStatus = mFont.tahoma_7b_white.getWidth(this.status) + 20;
		this.isWaiting = false;
		this.type = 1;
		this.sizeButtonQuest = 2;
		this.wDia = GameCanvas.w / 5 * 4;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		iCommand o = new iCommand(T.viewMap, 3);
		this.cmdList.addElement(o);
		this.cmdList.addElement(this.cmdCancleQuest);
		this.cmdList.addElement(this.cmdClose);
		this.strinfo = mFont.tahoma_7_white.splitFontArray(quest.strShowDialog, this.wDia - 20);
		this.hDia = GameCanvas.hText * (this.strinfo.Length + 1) + MsgDialog.hPlus + 15 + ((this.cmdList.size() <= 2) ? 0 : (iCommand.hButtonCmd + 5));
		if (!GameCanvas.isTouch && this.hDia > GameCanvas.h * 6 / 7)
		{
			this.hDia = GameCanvas.h * 6 / 7;
		}
		this.cameraDia.setAll(0, GameCanvas.hText * (this.strinfo.Length + 1) + 45 - this.hDia + iCommand.hButtonCmd * this.sizeButtonQuest, 0, 0);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(4);
	}

	// Token: 0x0600075F RID: 1887 RVA: 0x00072098 File Offset: 0x00070298
	public void setinfoParty()
	{
		this.beginDia();
		MsgDialog.timePaintParty = 0;
		this.isWaiting = false;
		this.isSpec = true;
		this.type = 2;
		this.hItem = GameCanvas.hCommand + 5;
		this.wDia = GameCanvas.w / 4 * 3;
		if (this.wDia > 180)
		{
			this.wDia = 180;
		}
		if (Player.party != null)
		{
			MsgDialog.maxSizeParty = Player.party.vecPartys.size();
		}
		else
		{
			MsgDialog.maxSizeParty = 0;
		}
		this.hDia = this.hItem * MsgDialog.maxSizeParty + MsgDialog.hPlus - 10 + GameCanvas.hCommand;
		iCommand o = new iCommand(T.giaotiep, 4);
		this.cmdchucnang = new iCommand(T.chucnang, 8);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2 + ((!GameCanvas.isTouch) ? 0 : GameCanvas.hCommand);
		iCommand iCommand = this.cmdClose;
		if (GameCanvas.isTouch)
		{
			this.cmdList.addElement(this.cmdchucnang);
			this.setPosCmdNew(4);
			iCommand.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.cmdList.addElement(iCommand);
		}
		else
		{
			this.cmdList.addElement(this.cmdchucnang);
			this.cmdList.addElement(o);
			this.setPosCmdNew(0);
			this.right = iCommand;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000760 RID: 1888 RVA: 0x00072258 File Offset: 0x00070458
	public void setinfoAutoHP_MP()
	{
		this.beginDia();
		MsgDialog.timePaintParty = 0;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 4;
		this.hItem = GameCanvas.hCommand;
		this.wDia = GameCanvas.w;
		if (this.wDia > 220)
		{
			this.wDia = 220;
		}
		this.hDia = this.hItem * 3 + MsgDialog.hPlus + GameCanvas.hCommand - 5;
		if (!GameCanvas.isTouch)
		{
			this.hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand = new iCommand("Ok", 5);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2;
		iCommand iCommand2 = this.cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand2.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.cmdList.addElement(iCommand2);
			iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd + 7 - this.hSpe, null, iCommand.caption);
			this.cmdList.addElement(iCommand);
		}
		else
		{
			this.right = iCommand2;
			this.left = iCommand;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000761 RID: 1889 RVA: 0x000723E8 File Offset: 0x000705E8
	public void setinfoAutoGetItem()
	{
		this.beginDia();
		MsgDialog.timePaintParty = 0;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 7;
		this.hItem = GameCanvas.hCommand;
		this.wDia = GameCanvas.w;
		if (this.wDia > 220)
		{
			this.wDia = 220;
		}
		this.hDia = this.hItem * 3 + MsgDialog.hPlus - 5 + GameCanvas.hCommand;
		if (!GameCanvas.isTouch)
		{
			this.hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand = new iCommand("Ok", 9);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2;
		iCommand iCommand2 = this.cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand2.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.cmdList.addElement(iCommand2);
			iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd + 7 - this.hSpe, null, iCommand.caption);
			this.cmdList.addElement(iCommand);
		}
		else
		{
			this.right = iCommand2;
			this.left = iCommand;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000762 RID: 1890 RVA: 0x0007257C File Offset: 0x0007077C
	public void setinfoVolume()
	{
		this.beginDia();
		MsgDialog.timePaintParty = 0;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 13;
		this.hItem = GameCanvas.hCommand;
		this.wDia = GameCanvas.w;
		if (this.wDia > 180)
		{
			this.wDia = 180;
		}
		this.hDia = this.hItem * 2 + MsgDialog.hPlus - 5 + GameCanvas.hCommand;
		if (!GameCanvas.isTouch)
		{
			this.hDia -= iCommand.hButtonCmd;
		}
		iCommand iCommand = new iCommand("Ok", 11);
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		iCommand iCommand2 = this.cmdClose;
		if (GameCanvas.isTouch)
		{
			iCommand2.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.cmdList.addElement(iCommand2);
			iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd + 7 - this.hSpe, null, iCommand.caption);
			this.cmdList.addElement(iCommand);
		}
		else
		{
			this.right = iCommand2;
			this.left = iCommand;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000763 RID: 1891 RVA: 0x00072708 File Offset: 0x00070908
	public void setDiaHelp(string info, iCommand cmd, int x, int y, int archor, bool isCamera, int w)
	{
		this.beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 5;
		this.wDia = w;
		this.cmdHelp = cmd;
		this.cmdList = new mVector("MsgChat cmdlist");
		this.cmdHelp.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2, null, this.cmdHelp.caption);
		this.cmdList.addElement(this.cmdHelp);
		this.strinfo = mFont.tahoma_7_white.splitFontArray(info, this.wDia - 4);
		this.hDia = GameCanvas.hText * this.strinfo.Length;
		this.xDia = x;
		this.yDia = y;
		if (archor == 5 || archor == 3 || archor == 4 || archor == 6)
		{
			this.yDia += this.hDia;
		}
		if (archor == 8)
		{
			this.xDia -= this.wDia;
		}
		this.archor = archor;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000764 RID: 1892 RVA: 0x0007284C File Offset: 0x00070A4C
	public void setinfoSHOW(string info, iCommand cmd, bool isOnlyCenter, string nameShow)
	{
		this.beginDia();
		if (cmd == null)
		{
			GameCanvas.currentDialog = null;
		}
		this.nameShow = nameShow;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 6;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.cmdList = new mVector("MsgChat cmdlist4");
		this.cmdList.addElement(cmd);
		if (!isOnlyCenter)
		{
			this.cmdList.addElement(this.cmdClose);
		}
		int num = this.cmdList.size();
		if (this.wDia < num * iCommand.wButtonCmd + (num - 1) * 10 + 10)
		{
			this.wDia = num * iCommand.wButtonCmd + (num - 1) * 10 + 10;
		}
		if (this.wDia > GameCanvas.w)
		{
			this.wDia = GameCanvas.w;
		}
		this.strinfo = mFont.tahoma_7_white.splitFontArray(info, this.wDia - 20);
		this.hDia = GameCanvas.hText * (this.strinfo.Length + 1) + iCommand.hButtonCmd + 20;
		if (this.hDia > GameCanvas.h - GameCanvas.hCommand)
		{
			this.hDia = GameCanvas.h - GameCanvas.hCommand;
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, GameCanvas.hText * (this.strinfo.Length + 1) + iCommand.hButtonCmd + 20 - this.hDia);
		}
		else
		{
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, 0);
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew((!GameCanvas.isTouch) ? 0 : 4);
	}

	// Token: 0x06000765 RID: 1893 RVA: 0x00072A98 File Offset: 0x00070C98
	public void setInfoAutoBuff()
	{
		this.beginDia();
		MsgDialog.timePaintParty = 0;
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 8;
		this.hItem = GameCanvas.hCommand;
		this.wDia = (int)MsgDialog.MaxSkillBuff * 60;
		if (this.wDia > 220)
		{
			this.wDia = 220;
		}
		this.wbuff = this.wDia / (int)MsgDialog.MaxSkillBuff;
		this.hDia = this.hItem * 2 + GameCanvas.hCommand;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2;
		if (GameCanvas.isTouch)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
			this.cmdList.addElement(this.cmdClose);
		}
		else
		{
			iCommand left = new iCommand(T.select, 10);
			this.left = left;
			this.right = this.cmdClose;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x06000766 RID: 1894 RVA: 0x00072BE0 File Offset: 0x00070DE0
	public void setInfoTime(string info, short time)
	{
		this.beginDia();
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 9;
		this.timeDia = time;
		this.timeset = GameCanvas.timeNow;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		this.cmdList = new mVector("MsgChat cmdlist5");
		this.cmdList.addElement(this.cmdClose);
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus + this.hWait;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.h - GameCanvas.hCommand * 2 - this.hDia - 5;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.setPosCmdNew(0);
	}

	// Token: 0x06000767 RID: 1895 RVA: 0x00072CF8 File Offset: 0x00070EF8
	public void setShowChangeItem(string nameDia, string info, MainItem[] datanguyenlieu, MainItem sanpham)
	{
		TabRebuildItem.vecEffRe.removeAllElements();
		this.beginDia();
		this.isWaiting = false;
		this.isSpec = false;
		this.nameShow = nameDia;
		this.datanguyenlieu = datanguyenlieu;
		this.sanpham = sanpham;
		this.StepShow = 0;
		this.timeShow = 0;
		this.type = 10;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 240)
		{
			this.wDia = 240;
		}
		this.cmdList = new mVector("MsgDiaLog cmdList2");
		this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		this.hDia = 15 * this.strinfo.Length + MsgDialog.hPlus + 50;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.posItemNguyenlieu = mSystem.new_M_Int(datanguyenlieu.Length + 1, 2);
		int num = 0;
		if (datanguyenlieu.Length > 4)
		{
			num = 30;
		}
		else if (datanguyenlieu.Length > 2)
		{
			num = 15;
		}
		for (int i = 0; i < this.posItemNguyenlieu.Length; i++)
		{
			if (i == this.posItemNguyenlieu.Length - 1)
			{
				this.posItemNguyenlieu[i][0] = this.xDia + this.wDia / 2;
				this.posItemNguyenlieu[i][1] = this.yDia + this.hDia - GameCanvas.hCommand - 35;
			}
			else
			{
				this.posItemNguyenlieu[i][0] = this.xDia + this.wDia / 6 + i % 2 * (this.wDia / 3) * 2;
				this.posItemNguyenlieu[i][1] = this.yDia + this.hDia - GameCanvas.hCommand - 35 + num - i / 2 * 30;
				TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posItemNguyenlieu[i][0], this.posItemNguyenlieu[i][1]);
			}
		}
	}

	// Token: 0x06000768 RID: 1896 RVA: 0x00072F0C File Offset: 0x0007110C
	public void setShowOpenBox(string nameDia, MainItem[] itemsanpham, string info, sbyte isFullEff, sbyte isLottery)
	{
		TabRebuildItem.vecEffRe.removeAllElements();
		this.beginDia();
		this.isWaiting = false;
		this.isSpec = false;
		this.isLottery = isLottery;
		this.isFullEff = isFullEff;
		this.nameShow = nameDia;
		this.itemsanpham = itemsanpham;
		this.StepShow = 0;
		this.timeShow = 0;
		this.indexShow1 = 0;
		this.indexShow2 = 0;
		this.type = 11;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 240)
		{
			this.wDia = 240;
		}
		if (info != null)
		{
			this.strinfo = this.fontDia.splitFontArray(info, this.wDia - 20);
		}
		else
		{
			this.strinfo = null;
		}
		this.cmdList = new mVector("MsgDiaLog cmdList3");
		this.hDia = MsgDialog.hPlus + 60;
		if (this.strinfo != null)
		{
			this.hDia += this.strinfo.Length * GameCanvas.hText;
		}
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.wsizeBox = 55;
		if (this.wsizeBox * (itemsanpham.Length - 1) > this.wDia - 30)
		{
			this.wsizeBox = 30;
		}
		int num = 0;
		if (itemsanpham.Length % 2 == 0)
		{
			num = this.wsizeBox / 2;
		}
		num += (itemsanpham.Length - 1) / 2 * this.wsizeBox;
		this.posItemNguyenlieu = new int[this.itemsanpham.Length][];
		for (int i = 0; i < this.posItemNguyenlieu.Length; i++)
		{
			this.posItemNguyenlieu[i] = new int[2];
		}
		for (int j = 0; j < this.posItemNguyenlieu.Length; j++)
		{
			this.posItemNguyenlieu[j][0] = this.xDia + this.wDia / 2 - num + j * this.wsizeBox;
			this.posItemNguyenlieu[j][1] = this.yDia + this.hDia - GameCanvas.hCommand - 45;
		}
	}

	// Token: 0x06000769 RID: 1897 RVA: 0x00073144 File Offset: 0x00071344
	public void setUpdateData()
	{
		this.nameShow = T.update;
		MsgDialog.curupdate = 0;
		MsgDialog.maxupdate = 20;
		this.beginDia();
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 12;
		this.wDia = GameCanvas.w - 30;
		if (this.wDia > 240)
		{
			this.wDia = 240;
		}
		MsgDialog.wUpdate = this.wDia / 4 * 3;
		MsgDialog.hUpdate = 16;
		this.cmdList = new mVector("MsgDiaLog cmdList4");
		this.strinfo = this.fontDia.splitFontArray(T.updateData, this.wDia - 20);
		this.hDia = 30 + MsgDialog.hPlus;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - this.hDia / 2;
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
	}

	// Token: 0x0600076A RID: 1898 RVA: 0x0007324C File Offset: 0x0007144C
	public void setPetInfo(PetItem pet, sbyte typeInven_Equip)
	{
		if ((int)typeInven_Equip != -1)
		{
			MsgDialog.isInven_Equip = typeInven_Equip;
		}
		MsgDialog.pet = pet;
		this.nameShow = pet.itemName;
		this.hItem = GameCanvas.hText;
		this.beginDia();
		this.isWaiting = false;
		this.isSpec = false;
		this.type = 14;
		this.wDia = GameCanvas.w - 30;
		MsgDialog.hUpdate = 8;
		if (this.wDia > 200)
		{
			this.wDia = 200;
		}
		MsgDialog.wUpdate = this.wDia / 2;
		this.cmdPet = new iCommand(T.choan, 16, this);
		this.cmdList = new mVector("MsgDiaLog cmdList");
		this.cmdList.addElement(this.cmdPet);
		int num = (7 + pet.mcontent.Length) * GameCanvas.hText + MsgDialog.hPlus + 10;
		if (num > GameCanvas.h - GameCanvas.hCommand * 2)
		{
			this.hDia = GameCanvas.h - GameCanvas.hCommand * 2;
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, num - this.hDia);
		}
		else
		{
			this.hDia = num;
			this.xDia = GameCanvas.hw - this.wDia / 2;
			this.yDia = GameCanvas.hh - this.hDia / 2;
			this.list = new ListNew(this.xDia, this.yDia, this.wDia, this.hDia, 0, 0, 0);
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		if (GameCanvas.isTouch)
		{
			this.setPosCmdNew(4);
		}
		this.cmdList.addElement(this.cmdClose);
		if (GameCanvas.isTouch)
		{
			this.cmdClose.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
		else
		{
			this.setPosCmdNew(0);
		}
	}

	// Token: 0x0600076B RID: 1899 RVA: 0x00073488 File Offset: 0x00071688
	public void setPosCmdNew(int yplus)
	{
		this.idCommand = 0;
		if (this.cmdList.size() > 0)
		{
			int num = this.cmdList.size();
			if (num == 1)
			{
				this.xBegin = this.xDia + this.wDia / 2;
				this.w2cmd = 0;
			}
			else if (num == 2)
			{
				this.w2cmd = 10;
				this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
			}
			else
			{
				this.w2cmd = 10;
				this.xBegin = this.xDia + this.wDia / 2 - this.w2cmd / 2 - iCommand.wButtonCmd / 2;
			}
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(i);
				iCommand.isSelect = false;
				if (num == 3 && i == 2)
				{
					iCommand.setPos(this.xDia + this.wDia / 2, this.yDia + this.hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 - this.hSpe + i / 2 * (iCommand.hButtonCmd + 5) - ((!this.isSpec) ? 0 : 4) + yplus, null, iCommand.caption);
				}
				else
				{
					iCommand.setPos(this.xBegin + i % 2 * (iCommand.wButtonCmd + this.w2cmd), this.yDia + this.hDia - iCommand.hButtonCmd - (num - 1) / 2 * (iCommand.hButtonCmd + 5) + 7 - this.hSpe + i / 2 * (iCommand.hButtonCmd + 5) - ((!this.isSpec) ? 0 : 4) + yplus, null, iCommand.caption);
				}
				if (i == 0)
				{
					iCommand.isSelect = true;
				}
			}
		}
	}

	// Token: 0x0600076C RID: 1900 RVA: 0x0007366C File Offset: 0x0007186C
	public override void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		switch (this.type)
		{
		case 0:
			AvMain.paintDialog(g, this.xDia, this.yDia, this.wDia, this.hDia, 12);
			for (int i = 0; i < this.strinfo.Length; i++)
			{
				this.fontDia.drawString(g, this.strinfo[i], GameCanvas.w / 2, this.yDia + 12 + i * 15, 2, mGraphics.isTrue);
			}
			if (this.isWaiting)
			{
				MsgDialog.fraWaiting.drawFrame(this.fWait % MsgDialog.fraWaiting.nFrame, GameCanvas.hw, this.yDia + 25 + this.strinfo.Length * 15, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			break;
		case 1:
			AvMain.paintTabNew(g, this.xDia, this.yDia, this.wDia, this.hDia, true, 0);
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, GameCanvas.hw - 32, this.yDia + 11, 64, 14, 2);
			}
			else
			{
				for (int j = 0; j < 2; j++)
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 32, 14, 0, GameCanvas.hw - 32 + j * 32, this.yDia + 11, 0, mGraphics.isTrue);
				}
			}
			mFont.tahoma_7b_white.drawString(g, T.quest, GameCanvas.hw, this.yDia + 12, 2, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, this.status, this.xDia + 10, this.yDia + 27, 0, mGraphics.isTrue);
			g.setClip(this.xDia + 3, this.yDia + 39, this.wDia - 6, this.hDia - 55 - iCommand.hButtonCmd * this.sizeButtonQuest);
			g.translate(0, -this.cameraDia.yCam);
			for (int k = 0; k < this.strinfo.Length; k++)
			{
				mFont.tahoma_7_black.drawString(g, this.strinfo[k], this.xDia + 11, this.yDia + 27 + (k + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			break;
		case 2:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.party);
			int num = this.yDia + GameCanvas.hCommand + 3;
			int num2 = 2;
			if (Player.party != null)
			{
				if (!GameCanvas.isTouch || MsgDialog.timePaintParty > 0)
				{
					g.setColor(11904141);
					g.fillRect(this.xDia + 9, num - 2 + this.idSelect * this.hItem, this.wDia - 17, this.hItem - 1, mGraphics.isTrue);
				}
				if (Player.party != null)
				{
					for (int l = 0; l < Player.party.vecPartys.size(); l++)
					{
						ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(l);
						if (objectParty.name.CompareTo(Player.party.nameMain) == 0)
						{
							AvMain.Font3dColorAndColor(g, string.Concat(new object[]
							{
								objectParty.name,
								" ",
								T.Lv,
								objectParty.Lv
							}), this.xDia + 11, num, 0, 7, 0);
						}
						else
						{
							mFont.tahoma_7b_white.drawString(g, string.Concat(new object[]
							{
								objectParty.name,
								" ",
								T.Lv,
								objectParty.Lv
							}), this.xDia + 11, num, 0, mGraphics.isTrue);
						}
						if (objectParty.name.CompareTo(GameScreen.player.name) == 0)
						{
							objectParty.hp = GameScreen.player.hp;
							objectParty.maxhp = GameScreen.player.maxHp;
						}
						g.setColor(0);
						g.fillRect(this.xDia + 11, num + 14 - num2, 42, 4, mGraphics.isTrue);
						g.setColor(8062494);
						g.fillRect(this.xDia + 12, num + 15 - num2, 40, 2, mGraphics.isTrue);
						g.setColor(16197705);
						g.fillRect(this.xDia + 12, num + 15 - num2, 40 * objectParty.hp / objectParty.maxhp, 2, mGraphics.isTrue);
						string text = "map";
						if (WorldMapScreen.namePos != null && objectParty.idMap < WorldMapScreen.namePos.Length)
						{
							text = WorldMapScreen.namePos[objectParty.idMap];
						}
						mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
						{
							text,
							" - ",
							T.Area,
							(int)objectParty.idArea + 1
						}), this.xDia + 11, num + 20 - num2 * 2, 0, mGraphics.isTrue);
						num += this.hItem;
						if (l < Player.party.vecPartys.size() - 1)
						{
							g.setColor(AvMain.color[4]);
							g.fillRect(this.xDia + 12, num - 3, this.wDia - 24, 1, mGraphics.isTrue);
						}
					}
				}
			}
			else
			{
				mFont.tahoma_7_black.drawString(g, T.noParty, this.xDia + this.wDia / 2, num, 2, mGraphics.isTrue);
			}
			base.paint(g);
			break;
		}
		case 4:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.auto);
			int num3 = this.yDia + this.hItem + 11;
			int num4 = this.xDia + 30 - ((!GameCanvas.isTouch) ? 0 : 10);
			g.setColor(MainTabNew.color[0]);
			for (int m = 0; m < T.mAuto.Length; m++)
			{
				mFont.tahoma_7_white.drawString(g, T.mAuto[m], num4, num3, 0, mGraphics.isTrue);
				int width = mFont.tahoma_7_black.getWidth(T.mAuto[0]);
				g.fillRect(num4 + width, num3 - 3, 35, 18, mGraphics.isTrue);
				mFont.tahoma_7_white.drawString(g, "   " + MsgDialog.mHPMP[m] + "     %", num4 + 3 + width, num3, 0, mGraphics.isTrue);
				num3 += this.hItem;
			}
			mFont.tahoma_7_white.drawString(g, T.mUtien[MsgDialog.isUutien], num4, num3, 0, mGraphics.isTrue);
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num4 - 4 + GameCanvas.gameTick % 3, this.yDia + this.hItem + 17 + this.idSelect * this.hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			base.paintCmd(g);
			break;
		}
		case 5:
			MainHelp.paintPopup(g, this.xDia, this.yDia, this.wDia, this.hDia, this.archor, this.strinfo);
			break;
		case 6:
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.nameShow);
			g.setClip(this.xDia, this.yDia + GameCanvas.hCommand + 2, this.wDia, this.hDia - GameCanvas.hCommand - iCommand.hButtonCmd - 8);
			g.translate(0, -this.list.cmx);
			for (int n = 0; n < this.strinfo.Length; n++)
			{
				mFont.tahoma_7_white.drawString(g, this.strinfo[n], this.xDia + 8, this.yDia + GameCanvas.hCommand + 2 + n * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			break;
		case 7:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.auto);
			int num5 = this.yDia + this.hItem + 11;
			int num6 = this.xDia + 30 - ((!GameCanvas.isTouch) ? 0 : 10);
			g.setColor(MainTabNew.color[3]);
			for (int num7 = 0; num7 < T.mAutoItem.Length; num7++)
			{
				mFont.tahoma_7b_white.drawString(g, T.mAutoItem[num7], num6, num5, 0, mGraphics.isTrue);
				int width2 = mFont.tahoma_7b_white.getWidth(T.mAutoItem[num7]);
				mFont.tahoma_7_white.drawString(g, "< " + T.mValueAutoItem[num7][(int)this.mvalueItem[num7]] + " >", num6 + 3 + width2, num5, 0, mGraphics.isTrue);
				num5 += this.hItem;
			}
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num6 - 4 + GameCanvas.gameTick % 3, this.yDia + this.hItem + 17 + this.idSelect * this.hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			base.paintCmd(g);
			break;
		}
		case 8:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.auto);
			int num8 = this.yDia + GameCanvas.hCommand + this.hItem;
			int num9 = this.xDia + this.wbuff / 2;
			if (!GameCanvas.isTouch)
			{
				g.setColor(15722248);
				g.fillRect(num9 - 12 + this.idSelect * this.wbuff, num8 - 12, 24, 24, mGraphics.isTrue);
			}
			for (int num10 = 0; num10 < (int)MsgDialog.MaxSkillBuff; num10++)
			{
				Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(MsgDialog.Autobuff[num10][2]);
				skill.paint(g, num9, num8, 3);
				if (MsgDialog.Autobuff[num10][1] == 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, 20, 0, num9, num8, 3, mGraphics.isTrue);
				}
				num9 += this.wbuff;
			}
			GameCanvas.resetTrans(g);
			base.paintCmd(g);
			break;
		}
		case 9:
			AvMain.paintDialog(g, this.xDia, this.yDia, this.wDia, this.hDia, 12);
			for (int num11 = 0; num11 < this.strinfo.Length; num11++)
			{
				if (num11 == this.strinfo.Length - 1)
				{
					this.fontDia.drawString(g, string.Concat(new object[]
					{
						this.strinfo[num11],
						" ",
						this.timeDia,
						"'."
					}), GameCanvas.w / 2, this.yDia + 12 + num11 * 15, 2, mGraphics.isTrue);
				}
				else
				{
					this.fontDia.drawString(g, this.strinfo[num11], GameCanvas.w / 2, this.yDia + 12 + num11 * 15, 2, mGraphics.isTrue);
				}
			}
			break;
		case 10:
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.nameShow);
			if (this.StepShow < 2)
			{
				for (int num12 = 0; num12 < this.posItemNguyenlieu.Length; num12++)
				{
					g.drawImage(AvMain.imgHotKey, this.posItemNguyenlieu[num12][0], this.posItemNguyenlieu[num12][1], 3, mGraphics.isTrue);
				}
				if (this.StepShow == 0)
				{
					for (int num13 = 0; num13 < this.datanguyenlieu.Length; num13++)
					{
						if (this.timeShow >= 4)
						{
							if (this.datanguyenlieu[num13] != null)
							{
								this.datanguyenlieu[num13].paintItem(g, this.posItemNguyenlieu[num13][0], this.posItemNguyenlieu[num13][1], 21, 1, 0);
							}
						}
					}
				}
			}
			else if (this.StepShow == 2)
			{
				for (int num14 = 0; num14 < this.strinfo.Length; num14++)
				{
					mFont.tahoma_7_white.drawString(g, this.strinfo[num14], this.xDia + 8, this.yDia + GameCanvas.hCommand + 2 + num14 * GameCanvas.hText, 0, mGraphics.isTrue);
				}
				int num15 = this.posItemNguyenlieu.Length - 1;
				if (this.sanpham != null)
				{
					this.sanpham.paintItem(g, this.posItemNguyenlieu[num15][0], this.posItemNguyenlieu[num15][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, this.posItemNguyenlieu[num15][0], this.posItemNguyenlieu[num15][1], 3, mGraphics.isTrue);
			}
			for (int num16 = 0; num16 < TabRebuildItem.vecEffRe.size(); num16++)
			{
				MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(num16);
				mainEffect.paint(g);
			}
			break;
		case 11:
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.nameShow);
			if (this.strinfo != null)
			{
				for (int num17 = 0; num17 < this.strinfo.Length; num17++)
				{
					mFont.tahoma_7_white.drawString(g, this.strinfo[num17], this.xDia + 8, this.yDia + GameCanvas.hCommand + 2 + num17 * GameCanvas.hText, 0, mGraphics.isTrue);
				}
			}
			for (int num18 = 0; num18 < this.posItemNguyenlieu.Length; num18++)
			{
				if (this.indexShow1 == -1 || num18 <= this.indexShow1)
				{
					g.drawImage(AvMain.imgHotKey, this.posItemNguyenlieu[num18][0], this.posItemNguyenlieu[num18][1], 3, mGraphics.isTrue);
				}
			}
			for (int num19 = 0; num19 < this.itemsanpham.Length; num19++)
			{
				if ((int)this.itemsanpham[num19].canSell != 0)
				{
					this.itemsanpham[num19].paintItem(g, this.posItemNguyenlieu[num19][0], this.posItemNguyenlieu[num19][1], 21, 1, 0);
					if (this.itemsanpham[num19].ItemCatagory == 3)
					{
						MainTabNew.setTextColorName(this.itemsanpham[num19].colorNameItem).drawString(g, this.itemsanpham[num19].itemName, this.posItemNguyenlieu[num19][0], this.posItemNguyenlieu[num19][1] + 14, 2, mGraphics.isTrue);
					}
				}
			}
			for (int num20 = 0; num20 < TabRebuildItem.vecEffRe.size(); num20++)
			{
				MainEffect mainEffect2 = (MainEffect)TabRebuildItem.vecEffRe.elementAt(num20);
				mainEffect2.paint(g);
			}
			break;
		case 12:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.nameShow);
			for (int num21 = 0; num21 < this.strinfo.Length; num21++)
			{
				mFont.tahoma_7_white.drawString(g, this.strinfo[num21], this.xDia + 8, this.yDia + GameCanvas.hCommand + 4 + num21 * GameCanvas.hText, 0, mGraphics.isTrue);
			}
			int num22 = this.xDia + this.wDia / 2 - MsgDialog.wUpdate / 2;
			int num23 = MsgDialog.hUpdate - 10;
			int num = this.yDia + this.hDia - num23 - 25;
			int num24 = num - 5;
			g.setColor(2698542);
			g.fillRect(num22 - 4, num24 + 15, MsgDialog.wUpdate + 2, num23, mGraphics.isTrue);
			g.fillRect(num22 - 4 + 1, num24 + 14, MsgDialog.wUpdate, 1, mGraphics.isTrue);
			g.fillRect(num22 - 4 + 1, num24 + 15 + num23, MsgDialog.wUpdate, 1, mGraphics.isTrue);
			g.setColor(3027507);
			g.fillRect(num22 - 4 + 1, num24 + 15, MsgDialog.wUpdate, num23, mGraphics.isTrue);
			if (MsgDialog.maxupdate > 0 && MsgDialog.curupdate > 0)
			{
				int num25 = MsgDialog.curupdate * MsgDialog.wUpdate / MsgDialog.maxupdate;
				if (num25 <= 0)
				{
					num25 = 1;
				}
				else if (num25 > MsgDialog.wUpdate)
				{
					num25 = MsgDialog.wUpdate;
				}
				g.setColor(10339648);
				g.fillRect(num22 - 4 + 1, num24 + 15, num25, num23, mGraphics.isTrue);
			}
			int num26 = MsgDialog.curupdate * 100 / MsgDialog.maxupdate;
			mFont.tahoma_7b_white.drawString(g, num26 + "%", this.xDia + this.wDia / 2, num24, 2, mGraphics.isTrue);
			break;
		}
		case 13:
		{
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, T.SetMusic);
			int num27 = this.yDia + this.hItem + 11;
			int num28 = this.xDia + 30 - ((!GameCanvas.isTouch) ? 0 : 10);
			g.setColor(MainTabNew.color[3]);
			for (int num29 = 0; num29 < T.mVolume.Length; num29++)
			{
				mFont.tahoma_7b_white.drawString(g, T.mVolume[num29], num28, num27, 0, mGraphics.isTrue);
				int width3 = mFont.tahoma_7b_white.getWidth(T.mVolume[num29]);
				mFont.tahoma_7_white.drawString(g, "< " + (((int)MsgDialog.mvalueVolume[num29] != 0) ? T.off : T.on) + " >", num28 + 3 + width3, num27, 0, mGraphics.isTrue);
				num27 += this.hItem;
			}
			if (!GameCanvas.isTouch)
			{
				g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, num28 - 4 + GameCanvas.gameTick % 3, this.yDia + this.hItem + 17 + this.idSelect * this.hItem, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isTrue);
			}
			GameCanvas.resetTrans(g);
			base.paintCmd(g);
			break;
		}
		case 14:
		{
			if (MsgDialog.pet == null)
			{
				return;
			}
			base.paintFormList(g, this.xDia, this.yDia, this.wDia, this.hDia, this.nameShow);
			int num30 = this.yDia + this.hItem * 2;
			int num31 = this.xDia + 10;
			g.setClip(this.xDia, this.yDia + GameCanvas.hCommand + 2, this.wDia, this.hDia - GameCanvas.hCommand - iCommand.hButtonCmd - 8);
			g.translate(0, -this.list.cmx);
			MsgDialog.pet.paintShowPet(g, num31 + (int)MainTabNew.wOneItem / 2, num30 + (int)MainTabNew.wOneItem / 2 + (int)MainTabNew.wOneItem / 4, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem / 2, 0, 1);
			mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
			{
				T.level,
				MsgDialog.pet.LvItem,
				" + ",
				(int)(MsgDialog.pet.experience / 10),
				",",
				(int)(MsgDialog.pet.experience % 10),
				"%"
			}), num31 + 40, num30, 0, mGraphics.isTrue);
			num30 += GameCanvas.hText;
			int num32 = MsgDialog.pet.age / 24;
			int num33 = MsgDialog.pet.age % 24;
			mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
			{
				T.tuoi,
				num32,
				"d ",
				num33,
				"h"
			}), num31 + 40, num30, 0, mGraphics.isTrue);
			num30 += GameCanvas.hText;
			MainTabNew.setTextColor((int)Item.colorInfoItem[MsgDialog.pet.petAttack.id]).drawString(g, string.Concat(new object[]
			{
				Item.nameInfoItem[MsgDialog.pet.petAttack.id],
				": ",
				MsgDialog.pet.petAttack.value,
				"-",
				MsgDialog.pet.petAttack.maxDam
			}), num31 + 40, num30, 0, mGraphics.isTrue);
			num30 += this.hItem;
			mFont.tahoma_7_white.drawString(g, T.choan, num31 + 8, num30, 0, mGraphics.isTrue);
			this.paintStatus(g, (int)MsgDialog.pet.growpoint, num31 + 65, num30 + 1, (int)MsgDialog.pet.maxgrow);
			num30 += this.hItem;
			for (int num34 = 0; num34 < T.mKynangPet.Length; num34++)
			{
				mFont.tahoma_7_white.drawString(g, T.mKynangPet[num34], num31 + 8, num30, 0, mGraphics.isTrue);
				this.paintStatus(g, (int)MsgDialog.pet.mvaluetiemnang[num34], num31 + 65, num30 + 1, (int)MsgDialog.pet.maxtiemnang);
				num30 += this.hItem;
			}
			for (int num35 = 0; num35 < MsgDialog.pet.mInfo.Length; num35++)
			{
				if (MsgDialog.pet.mInfo[num35].id > 6)
				{
					string st = Item.nameInfoItem[MsgDialog.pet.mInfo[num35].id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[MsgDialog.pet.mInfo[num35].id], MsgDialog.pet.mInfo[num35].value);
					MainTabNew.setTextColor((int)Item.colorInfoItem[MsgDialog.pet.mInfo[num35].id]).drawString(g, st, num31 + 8, num30, 0, mGraphics.isTrue);
					num30 += this.hItem;
				}
			}
			GameCanvas.resetTrans(g);
			base.paintCmd(g);
			break;
		}
		}
		GameCanvas.resetTrans(g);
		if (this.cmdList != null)
		{
			for (int num36 = 0; num36 < this.cmdList.size(); num36++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(num36);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x0600076D RID: 1901 RVA: 0x00074DC0 File Offset: 0x00072FC0
	public void paintStatus(mGraphics g, int cur, int xp, int yp, int max)
	{
		g.setColor(2698542);
		g.fillRect(xp - 4, yp + 1, MsgDialog.wUpdate + 2, MsgDialog.hUpdate, mGraphics.isTrue);
		g.fillRect(xp - 4 + 1, yp, MsgDialog.wUpdate, 1, mGraphics.isTrue);
		g.fillRect(xp - 4 + 1, yp + 1 + MsgDialog.hUpdate, MsgDialog.wUpdate, 1, mGraphics.isTrue);
		g.setColor(3027507);
		g.fillRect(xp - 4 + 1, yp + 1, MsgDialog.wUpdate, MsgDialog.hUpdate, mGraphics.isTrue);
		if (cur * 100 / max > 0)
		{
			int num = cur * 100 / max * MsgDialog.wUpdate / 100;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > MsgDialog.wUpdate)
			{
				num = MsgDialog.wUpdate;
			}
			g.setColor(10339648);
			g.fillRect(xp - 4 + 1, yp + 1, num, MsgDialog.hUpdate, mGraphics.isTrue);
		}
		mFont.tahoma_7b_white.drawString(g, cur + string.Empty, xp + MsgDialog.wUpdate / 2, yp, 2, mGraphics.isTrue);
	}

	// Token: 0x0600076E RID: 1902 RVA: 0x00074EE8 File Offset: 0x000730E8
	public void paintCommand()
	{
	}

	// Token: 0x0600076F RID: 1903 RVA: 0x00074EEC File Offset: 0x000730EC
	public override void update()
	{
		if (this.isWaiting)
		{
			this.fWait++;
			if (this.fWait > 1200)
			{
				if (Session_ME.gI().isConnected() && GameCanvas.currentScreen != GameCanvas.login && GameCanvas.currentScreen != GameCanvas.load)
				{
					GameCanvas.start_Ok_Dialog(T.thulai);
				}
				else
				{
					mVector mVector = new mVector("MsgDiaLog vec");
					if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
					{
						mVector.addElement(new iCommand(T.again, 0));
					}
					mVector.addElement(new iCommand(T.exit, 6));
					GameCanvas.start_Select_Dialog(T.disconnect, mVector);
					GlobalLogicHandler.isDisConect = true;
					GlobalLogicHandler.timeReconnect = mSystem.currentTimeMillis() + 30000L;
				}
			}
		}
		if (this.type == 6 || this.type == 14)
		{
			this.list.moveCamera();
		}
		if (GlobalLogicHandler.isDisConect && GlobalLogicHandler.timeReconnect - mSystem.currentTimeMillis() <= 0L)
		{
			this.relogin();
		}
		this.updatekey();
		this.updatePointer();
		if (this.type == 2)
		{
			if (Player.party != null)
			{
				if (Player.party.vecPartys.size() != MsgDialog.maxSizeParty || MsgDialog.maxSizeParty == -1)
				{
					MsgDialog.maxSizeParty = Player.party.vecPartys.size();
					this.hDia = this.hItem * MsgDialog.maxSizeParty + MsgDialog.hPlus - 10 + GameCanvas.hCommand;
					this.yDia = GameCanvas.hh - GameCanvas.hCommand - this.hDia / 2 + ((!GameCanvas.isTouch) ? 0 : GameCanvas.hCommand);
					this.numh = (this.hDia - 6) / 32;
					this.cmdList.removeAllElements();
					iCommand o = new iCommand(T.giaotiep, 4);
					this.cmdchucnang = new iCommand(T.leave, 8);
					if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
					{
						this.cmdchucnang.caption = T.chucnang;
					}
					iCommand iCommand = this.cmdClose;
					if (GameCanvas.isTouch)
					{
						this.cmdList.addElement(this.cmdchucnang);
						this.setPosCmdNew(4);
						iCommand.setPos(this.xDia + this.wDia - 12, this.yDia + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
						this.cmdList.addElement(iCommand);
					}
					else
					{
						this.cmdList.addElement(this.cmdchucnang);
						this.cmdList.addElement(o);
						this.setPosCmdNew(4);
						this.right = iCommand;
					}
				}
				if (MsgDialog.timePaintParty > 0)
				{
					MsgDialog.timePaintParty--;
				}
			}
			else
			{
				this.cmdList.removeAllElements();
				iCommand iCommand2 = this.cmdClose;
				if (GameCanvas.isTouch)
				{
					iCommand2.setPos(this.xDia + this.wDia - 6, this.yDia + 4, PaintInfoGameScreen.fraCloseMenu, string.Empty);
					this.cmdList.addElement(iCommand2);
				}
				else
				{
					this.right = iCommand2;
				}
			}
		}
		else if (this.type == 3 || this.type == 6 || this.type == 14)
		{
			this.cameraDia.UpdateCamera();
		}
		else if (this.type == 9)
		{
			if ((GameCanvas.timeNow - this.timeset) / 1000L > 1L)
			{
				this.timeset += 1000L;
				this.timeDia -= 1;
				if (this.timeDia <= 0)
				{
					this.cmdClose.perform();
				}
			}
		}
		else if (this.type == 10)
		{
			this.timeShow++;
			if (this.StepShow == 0)
			{
				if (this.timeShow == 30)
				{
					this.timeShow = 0;
					this.StepShow = 1;
				}
			}
			else if (this.StepShow == 1)
			{
				if (this.timeShow == 1)
				{
					mSound.playSound(29, mSound.volumeSound);
					for (int i = 0; i < this.posItemNguyenlieu.Length - 1; i++)
					{
						TabRebuildItem.addEffectEndRebuild(41, this.posItemNguyenlieu[i][0], this.posItemNguyenlieu[i][1], this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][0], this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][1], 1);
					}
				}
				if (this.timeShow >= 16)
				{
					mSound.playSound(26, mSound.volumeSound);
					this.StepShow = 2;
					this.timeShow = 0;
					this.cmdList.addElement(this.cmdClose);
					this.setPosCmdNew(0);
					TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][0], this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][1]);
					TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][0], this.posItemNguyenlieu[this.posItemNguyenlieu.Length - 1][1]);
				}
			}
			else if (this.StepShow == 2)
			{
			}
			for (int j = 0; j < TabRebuildItem.vecEffRe.size(); j++)
			{
				MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(j);
				mainEffect.update();
				if (mainEffect.isStop)
				{
					TabRebuildItem.vecEffRe.removeElement(mainEffect);
				}
			}
		}
		else if (this.type == 11)
		{
			this.timeShow++;
			if (this.StepShow == 0)
			{
				if (this.indexShow1 >= 0 && this.timeShow % 5 == 1)
				{
					TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posItemNguyenlieu[this.indexShow1][0], this.posItemNguyenlieu[this.indexShow1][1]);
					if (this.indexShow1 < this.itemsanpham.Length - 1)
					{
						this.indexShow1++;
					}
					else
					{
						this.indexShow1 = -1;
					}
				}
				if (this.timeShow > 5 && this.timeShow % 5 == 1)
				{
					if ((int)this.isFullEff == 0)
					{
						TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posItemNguyenlieu[this.indexShow2][0], this.posItemNguyenlieu[this.indexShow2][1]);
					}
					this.itemsanpham[this.indexShow2].canSell = 1;
					if (this.indexShow2 < this.itemsanpham.Length - 1)
					{
						this.indexShow2++;
						mSound.playSound(29, mSound.volumeSound);
					}
					else
					{
						mSound.playSound(29, mSound.volumeSound);
						this.indexShow2 = -1;
						this.indexShow1 = -1;
						this.timeShow = 0;
						this.StepShow = 1;
						this.cmdList.addElement(this.cmdClose);
						this.setPosCmdNew(0);
					}
				}
			}
			for (int k = 0; k < TabRebuildItem.vecEffRe.size(); k++)
			{
				MainEffect mainEffect2 = (MainEffect)TabRebuildItem.vecEffRe.elementAt(k);
				mainEffect2.update();
				if (mainEffect2.isStop)
				{
					TabRebuildItem.vecEffRe.removeElement(mainEffect2);
				}
			}
		}
		else if (this.type == 12)
		{
			if (Session_ME.gI().isConnected())
			{
				if (MsgDialog.curupdate >= MsgDialog.maxupdate && GameCanvas.gameTick % 40 == 20)
				{
					GameCanvas.start_Ok_Dialog(T.updateok);
				}
			}
			else
			{
				GameCanvas.start_Center_Dialog_Only(T.disconnect, new iCommand(T.exit, -1));
			}
		}
	}

	// Token: 0x06000770 RID: 1904 RVA: 0x000756AC File Offset: 0x000738AC
	public override void updatekey()
	{
		if (this.type == 1)
		{
			this.cameraDia.UpdateCamera();
			if (GameCanvas.keyMyHold[2])
			{
				this.cameraDia.yTo -= GameCanvas.hText;
				if (this.cameraDia.yTo < 0)
				{
					this.cameraDia.yTo = 0;
				}
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.cameraDia.yTo += GameCanvas.hText;
				if (this.cameraDia.yTo > this.cameraDia.yLimit)
				{
					this.cameraDia.yTo = this.cameraDia.yLimit;
				}
				GameCanvas.clearKeyHold(8);
			}
		}
		else if (this.type == 2)
		{
			if (Player.party != null)
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
				this.idSelect = base.resetSelect(this.idSelect, Player.party.vecPartys.size() - 1, true);
			}
			else
			{
				this.left = null;
			}
		}
		else if (this.type == 6 || this.type == 14)
		{
			if (GameCanvas.keyMyHold[2])
			{
				this.list.cmtoX -= GameCanvas.hText;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.list.cmtoX += GameCanvas.hText;
				GameCanvas.clearKeyHold(8);
			}
			if (this.list.cmtoX > this.list.cmxLim)
			{
				this.list.cmtoX = this.list.cmxLim;
			}
			if (this.list.cmtoX < 0)
			{
				this.list.cmtoX = 0;
			}
		}
		else if (this.type == 4)
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
			this.idSelect = base.resetSelect(this.idSelect, 2, true);
			if (GameCanvas.keyMyHold[4])
			{
				switch (this.idSelect)
				{
				case 0:
					if (MsgDialog.mHPMP[0] > 10)
					{
						MsgDialog.mHPMP[0] -= 10;
					}
					break;
				case 1:
					if (MsgDialog.mHPMP[1] > 10)
					{
						MsgDialog.mHPMP[1] -= 10;
					}
					break;
				case 2:
					if (MsgDialog.isUutien == 1)
					{
						MsgDialog.isUutien = 0;
					}
					break;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				switch (this.idSelect)
				{
				case 0:
					if (MsgDialog.mHPMP[0] < 90)
					{
						MsgDialog.mHPMP[0] += 10;
					}
					break;
				case 1:
					if (MsgDialog.mHPMP[1] < 90)
					{
						MsgDialog.mHPMP[1] += 10;
					}
					break;
				case 2:
					if (MsgDialog.isUutien == 0)
					{
						MsgDialog.isUutien = 1;
					}
					break;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (this.type == 7)
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
			this.idSelect = base.resetSelect(this.idSelect, 2, true);
			if (GameCanvas.keyMyHold[4])
			{
				if ((int)this.mvalueItem[this.idSelect] == 0)
				{
					this.mvalueItem[this.idSelect] = (sbyte)(T.mValueAutoItem[this.idSelect].Length - 1);
				}
				else
				{
					sbyte[] array = this.mvalueItem;
					int num = this.idSelect;
					array[num] -= 1;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if ((int)this.mvalueItem[this.idSelect] == (int)((sbyte)(T.mValueAutoItem[this.idSelect].Length - 1)))
				{
					this.mvalueItem[this.idSelect] = 0;
				}
				else
				{
					sbyte[] array2 = this.mvalueItem;
					int num2 = this.idSelect;
					array2[num2] += 1;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (this.type == 13)
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
			this.idSelect = base.resetSelect(this.idSelect, 1, true);
			if (GameCanvas.keyMyHold[4])
			{
				if ((int)this.mvalueItem[this.idSelect] == 0)
				{
					this.mvalueItem[this.idSelect] = 1;
				}
				else
				{
					sbyte[] array3 = this.mvalueItem;
					int num3 = this.idSelect;
					array3[num3] -= 1;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if ((int)this.mvalueItem[this.idSelect] == 1)
				{
					this.mvalueItem[this.idSelect] = 0;
				}
				else
				{
					sbyte[] array4 = this.mvalueItem;
					int num4 = this.idSelect;
					array4[num4] += 1;
				}
				GameCanvas.clearKeyHold(6);
			}
		}
		else if (this.type == 8)
		{
			if (GameCanvas.keyMyHold[4])
			{
				this.idSelect--;
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				this.idSelect++;
				GameCanvas.clearKeyHold(6);
			}
			this.idSelect = base.resetSelect(this.idSelect, (int)MsgDialog.MaxSkillBuff - 1, true);
		}
		if (this.cmdList != null)
		{
			int num5 = this.cmdList.size();
			if (!GameCanvas.isTouch && num5 > 0)
			{
				int num6 = this.idCommand;
				if (GameCanvas.keyMyHold[4])
				{
					this.idCommand--;
					GameCanvas.clearKeyHold(4);
				}
				else if (GameCanvas.keyMyHold[6])
				{
					this.idCommand++;
					GameCanvas.clearKeyHold(6);
				}
				this.idCommand = base.resetSelect(this.idCommand, num5 - 1, false);
				if (this.typeQuest == 2)
				{
					iCommand iCommand = (iCommand)this.cmdList.elementAt(this.idCommand);
					if (iCommand == this.cmdClose)
					{
						this.idCommand = 0;
					}
				}
				if (num6 != this.idCommand)
				{
					for (int i = 0; i < num5; i++)
					{
						iCommand iCommand2 = (iCommand)this.cmdList.elementAt(i);
						if (i == this.idCommand)
						{
							iCommand2.isSelect = true;
						}
						else
						{
							iCommand2.isSelect = false;
						}
					}
				}
			}
		}
		if (GameCanvas.keyMyHold[5])
		{
			GameCanvas.clearKeyHold(5);
			if (this.cmdList != null && this.idCommand < this.cmdList.size())
			{
				((iCommand)this.cmdList.elementAt(this.idCommand)).perform();
			}
		}
		base.updatekey();
	}

	// Token: 0x06000771 RID: 1905 RVA: 0x00075E6C File Offset: 0x0007406C
	public override void updatePointer()
	{
		if (this.type == 2)
		{
			if (Player.party != null && GameCanvas.isPointSelect(this.xDia, this.yDia + GameCanvas.hCommand, this.wDia, this.hDia - GameCanvas.hCommand))
			{
				int num = (GameCanvas.py - (this.yDia + GameCanvas.hCommand)) / this.hItem;
				if (num >= 0 && num <= Player.party.vecPartys.size() - 1)
				{
					mSound.playSound(42, mSound.volumeSound);
					this.idSelect = num;
					this.idSelect = base.resetSelect(this.idSelect, Player.party.vecPartys.size() - 1, false);
					MsgDialog.timePaintParty = 3;
					this.setMenuParty();
					GameCanvas.isPointerSelect = false;
				}
			}
		}
		else if (this.type == 4)
		{
			int num2 = this.yDia + this.hItem + 11;
			int x = this.xDia + 30 - ((!GameCanvas.isTouch) ? 0 : 10) + mFont.tahoma_7_black.getWidth(T.mAuto[0]);
			if (GameCanvas.isPointSelect(x, num2 - 5, 40, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (MsgDialog.mHPMP[0] < 90)
				{
					MsgDialog.mHPMP[0] += 10;
				}
				else
				{
					MsgDialog.mHPMP[0] = 10;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(x, num2 + this.hItem - 5, 40, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (MsgDialog.mHPMP[1] < 90)
				{
					MsgDialog.mHPMP[1] += 10;
				}
				else
				{
					MsgDialog.mHPMP[1] = 10;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(this.xDia + 30 - ((!GameCanvas.isTouch) ? 0 : 10), num2 + this.hItem * 2, 120, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if (MsgDialog.isUutien == 0)
				{
					MsgDialog.isUutien = 1;
				}
				else
				{
					MsgDialog.isUutien = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (this.type == 7)
		{
			int num3 = this.yDia + this.hItem + 11;
			int xDia = this.xDia;
			if (GameCanvas.isPointSelect(xDia, num3 - 4, this.wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if ((int)this.mvalueItem[0] == (int)((sbyte)(T.mValueAutoItem[0].Length - 1)))
				{
					this.mvalueItem[0] = 0;
				}
				else
				{
					sbyte[] array = this.mvalueItem;
					int num4 = 0;
					array[num4] += 1;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(xDia, num3 + this.hItem - 4, this.wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if ((int)this.mvalueItem[1] == (int)((sbyte)(T.mValueAutoItem[1].Length - 1)))
				{
					this.mvalueItem[1] = 0;
				}
				else
				{
					sbyte[] array2 = this.mvalueItem;
					int num5 = 1;
					array2[num5] += 1;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(xDia, num3 + this.hItem * 2, this.wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if ((int)this.mvalueItem[2] == (int)((sbyte)(T.mValueAutoItem[2].Length - 1)))
				{
					this.mvalueItem[2] = 0;
				}
				else
				{
					sbyte[] array3 = this.mvalueItem;
					int num6 = 2;
					array3[num6] += 1;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (this.type == 13)
		{
			int num7 = this.yDia + this.hItem + 11;
			int xDia2 = this.xDia;
			if (GameCanvas.isPointSelect(xDia2, num7 - 4, this.wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if ((int)MsgDialog.mvalueVolume[0] == 1)
				{
					MsgDialog.mvalueVolume[0] = 0;
				}
				else
				{
					sbyte[] array4 = MsgDialog.mvalueVolume;
					int num8 = 0;
					array4[num8] += 1;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(xDia2, num7 + this.hItem - 4, this.wDia, 20))
			{
				mSound.playSound(42, mSound.volumeSound);
				if ((int)MsgDialog.mvalueVolume[1] == 1)
				{
					MsgDialog.mvalueVolume[1] = 0;
				}
				else
				{
					sbyte[] array5 = MsgDialog.mvalueVolume;
					int num9 = 1;
					array5[num9] += 1;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		else if (this.type == 6 || this.type == 14)
		{
			this.list.update_Pos_UP_DOWN();
		}
		else if (this.type == 8)
		{
			int num10 = this.yDia + GameCanvas.hCommand + this.hItem;
			int num11 = this.xDia + this.wbuff / 2;
			for (int i = 0; i < (int)MsgDialog.MaxSkillBuff; i++)
			{
				if (GameCanvas.isPointSelect(num11 + i * this.wbuff - 20, num10 - 20, 40, 40))
				{
					mSound.playSound(42, mSound.volumeSound);
					GameCanvas.isPointerSelect = false;
					this.setAutoBuff(i);
					break;
				}
			}
		}
		else if (this.type == 5 && GameCanvas.isPointSelect(0, 0, GameCanvas.w, GameCanvas.h))
		{
			this.cmdHelp.perform();
			GameCanvas.isPointerSelect = false;
		}
		if (this.cmdList != null)
		{
			for (int j = 0; j < this.cmdList.size(); j++)
			{
				iCommand iCommand = (iCommand)this.cmdList.elementAt(j);
				iCommand.updatePointer();
			}
		}
	}

	// Token: 0x06000772 RID: 1906 RVA: 0x00076430 File Offset: 0x00074630
	public void setMenuParty()
	{
		if (Player.party == null)
		{
			return;
		}
		ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
		if (objectParty.name.CompareTo(GameScreen.player.name) == 0)
		{
			return;
		}
		mVector mVector = new mVector("MsgDiaLog menu");
		iCommand o = new iCommand(T.addFriend, 9, this);
		mVector.addElement(o);
		iCommand o2 = new iCommand(T.trochuyen, 14, this);
		mVector.addElement(o2);
		if (GameScreen.player.name.CompareTo(Player.party.nameMain) == 0)
		{
			string text = objectParty.name;
			if (text.Length > 8)
			{
				text = mSystem.substring(text, 0, 7) + "...";
			}
			iCommand o3 = new iCommand(T.yeucau + text + " " + T.leave, 6, this);
			mVector.addElement(o3);
		}
		GameCanvas.menu2.startAt(mVector, 2, objectParty.name, false, null);
	}

	// Token: 0x06000773 RID: 1907 RVA: 0x00076538 File Offset: 0x00074738
	private void setChucNangParty()
	{
		if (Player.party == null)
		{
			return;
		}
		ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(this.idSelect);
		mVector mVector = new mVector("MsgDiaLog menu2");
		if (objectParty.name.CompareTo(GameScreen.player.name) != 0)
		{
			string text = objectParty.name;
			if (text.Length > 8)
			{
				text = mSystem.substring(text, 0, 7) + "...";
			}
			iCommand o = new iCommand(string.Concat(new string[]
			{
				T.yeucau,
				" ",
				text,
				" ",
				T.leave
			}), 6, this);
			mVector.addElement(o);
		}
		iCommand o2 = new iCommand(T.leave, 8, this);
		mVector.addElement(o2);
		iCommand o3 = new iCommand(T.mainCancle, 7, this);
		mVector.addElement(o3);
		iCommand o4 = new iCommand(T.chatParty, 15, this);
		mVector.addElement(o4);
		GameCanvas.menu2.startAt(mVector, 2, T.chucnang, false, null);
	}

	// Token: 0x06000774 RID: 1908 RVA: 0x0007664C File Offset: 0x0007484C
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

	// Token: 0x06000775 RID: 1909 RVA: 0x0007666C File Offset: 0x0007486C
	public void setAutoBuff(int index)
	{
		if (MsgDialog.Autobuff[index][1] == 0)
		{
			if (Player.mCurentLvSkill[MsgDialog.Autobuff[index][0]] > 0)
			{
				MsgDialog.Autobuff[index][1] = 1;
				Player.isAutoBuff = 1;
			}
			else
			{
				GameCanvas.start_Ok_Dialog(T.chuahoc);
			}
		}
		else
		{
			MsgDialog.Autobuff[index][1] = 0;
			Player.isAutoBuff = 0;
			for (int i = 0; i < MsgDialog.Autobuff.Length; i++)
			{
				if (MsgDialog.Autobuff[i][1] == 1)
				{
					Player.isAutoBuff = 1;
					break;
				}
			}
		}
		MainRMS.setSaveAuto();
	}

	// Token: 0x06000776 RID: 1910 RVA: 0x00076708 File Offset: 0x00074908
	public void relogin()
	{
		GlobalLogicHandler.isDisConect = true;
		GlobalLogicHandler.timeReconnect = mSystem.currentTimeMillis() + 30000L;
		if (GameCanvas.currentScreen.isGameScr())
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
					MsgDialog.isAutologin = true;
					GameScreen.player.resetPlayer();
					if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
					{
						GlobalService.gI().send_cmd_server(61);
					}
					this.closeDialog();
				}
				else
				{
					GameCanvas.login.Show();
					this.closeDialog();
				}
			}
		}
		else
		{
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
				GlobalService.gI().login(LoginScreen.tfusername.getText(), LoginScreen.tfpassword.getText(), GameMidlet.version, "0", "0", "0", SelectCharScreen.IDCHAR, LoadMap.Area);
				MsgDialog.isAutologin = true;
				GameScreen.player.resetPlayer();
				if (WorldMapScreen.namePos == null || TabQuest.nameItemQuest == null)
				{
					GlobalService.gI().send_cmd_server(61);
				}
				this.closeDialog();
			}
			else
			{
				GameCanvas.login.Show();
				this.closeDialog();
			}
		}
		GameCanvas.start_Wait_Dialog(T.dangdangnhap, new iCommand(T.close, 7));
		GameCanvas.countLogin = mSystem.currentTimeMillis();
	}

	// Token: 0x06000777 RID: 1911 RVA: 0x00076904 File Offset: 0x00074B04
	public static void setMusic()
	{
		if (MsgDialog.mvalueVolume != null)
		{
			mSound.isMusic = ((int)MsgDialog.mvalueVolume[0] == 0);
			mSound.isSound = ((int)MsgDialog.mvalueVolume[1] == 0);
			if (!mSound.isMusic)
			{
				mSound.pauseCurMusic();
			}
			else if (LoginScreen.MusicRandom == 0)
			{
				mSound.playMus(0, mSound.volumeMusic, true);
			}
			else
			{
				mSound.playMus(1, mSound.volumeMusic, true);
			}
			DataOutputStream dataOutputStream = new DataOutputStream();
			try
			{
				dataOutputStream.writeByte(MsgDialog.mvalueVolume[0]);
				dataOutputStream.writeByte(MsgDialog.mvalueVolume[1]);
				CRes.saveRMS("isVolume", dataOutputStream.toByteArray());
				dataOutputStream.close();
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x04000B11 RID: 2833
	public const sbyte NORMAL = 0;

	// Token: 0x04000B12 RID: 2834
	public const sbyte QUEST = 1;

	// Token: 0x04000B13 RID: 2835
	public const sbyte PARTY = 2;

	// Token: 0x04000B14 RID: 2836
	public const sbyte LIST_PARTY = 3;

	// Token: 0x04000B15 RID: 2837
	public const sbyte AUTO_HP_MP = 4;

	// Token: 0x04000B16 RID: 2838
	public const sbyte HELP = 5;

	// Token: 0x04000B17 RID: 2839
	public const sbyte SHOW = 6;

	// Token: 0x04000B18 RID: 2840
	public const sbyte AUTO_GET_ITEM = 7;

	// Token: 0x04000B19 RID: 2841
	public const sbyte AUTO_BUFF = 8;

	// Token: 0x04000B1A RID: 2842
	public const sbyte DIA_TIME = 9;

	// Token: 0x04000B1B RID: 2843
	public const sbyte SHOW_CHANGE_ITEM = 10;

	// Token: 0x04000B1C RID: 2844
	public const sbyte SHOW_OPEN_BOX = 11;

	// Token: 0x04000B1D RID: 2845
	public const sbyte UPDATE_DATA = 12;

	// Token: 0x04000B1E RID: 2846
	public const sbyte SET_VOLUME = 13;

	// Token: 0x04000B1F RID: 2847
	public const sbyte PET_INFO = 14;

	// Token: 0x04000B20 RID: 2848
	public const sbyte Info_arena = 15;

	// Token: 0x04000B21 RID: 2849
	public const sbyte OPEN_BOX = 0;

	// Token: 0x04000B22 RID: 2850
	public const sbyte BOX_QUEST = 1;

	// Token: 0x04000B23 RID: 2851
	private MsgDialog LastDia;

	// Token: 0x04000B24 RID: 2852
	private string status;

	// Token: 0x04000B25 RID: 2853
	private string link = string.Empty;

	// Token: 0x04000B26 RID: 2854
	private string nameShow;

	// Token: 0x04000B27 RID: 2855
	private int wStatus;

	// Token: 0x04000B28 RID: 2856
	public static int maxSizeParty;

	// Token: 0x04000B29 RID: 2857
	public int maxSizeList;

	// Token: 0x04000B2A RID: 2858
	private int fWait;

	// Token: 0x04000B2B RID: 2859
	private int IdQuest;

	// Token: 0x04000B2C RID: 2860
	private int typeQuest;

	// Token: 0x04000B2D RID: 2861
	private int idSelect;

	// Token: 0x04000B2E RID: 2862
	private int idSelectBuy;

	// Token: 0x04000B2F RID: 2863
	private int idCommand;

	// Token: 0x04000B30 RID: 2864
	private int sizeParty;

	// Token: 0x04000B31 RID: 2865
	private sbyte main_sub_quest;

	// Token: 0x04000B32 RID: 2866
	private bool isWaiting;

	// Token: 0x04000B33 RID: 2867
	private bool isSpec;

	// Token: 0x04000B34 RID: 2868
	public static sbyte MaxSkillBuff = 0;

	// Token: 0x04000B35 RID: 2869
	private mVector cmdList = new mVector("MsgChat cmdList");

	// Token: 0x04000B36 RID: 2870
	private iCommand cmdClose = new iCommand(T.close, -1, MsgDialog.me);

	// Token: 0x04000B37 RID: 2871
	private iCommand cmdCancleQuest = new iCommand(T.cancel, 10, MsgDialog.me);

	// Token: 0x04000B38 RID: 2872
	private iCommand cmdchucnang;

	// Token: 0x04000B39 RID: 2873
	private iCommand cmdHelp;

	// Token: 0x04000B3A RID: 2874
	private iCommand cmdPet;

	// Token: 0x04000B3B RID: 2875
	public static FrameImage fraWaiting;

	// Token: 0x04000B3C RID: 2876
	private Camera cameraDia = new Camera();

	// Token: 0x04000B3D RID: 2877
	private ListNew list;

	// Token: 0x04000B3E RID: 2878
	private int hItem;

	// Token: 0x04000B3F RID: 2879
	private int hWait;

	// Token: 0x04000B40 RID: 2880
	private int hSpe;

	// Token: 0x04000B41 RID: 2881
	public static int hPlus = 52;

	// Token: 0x04000B42 RID: 2882
	public static int timePaintParty = 0;

	// Token: 0x04000B43 RID: 2883
	private MainQuest quest;

	// Token: 0x04000B44 RID: 2884
	public static int isUutien = 0;

	// Token: 0x04000B45 RID: 2885
	public static int[] mHPMP = new int[]
	{
		50,
		50
	};

	// Token: 0x04000B46 RID: 2886
	private int archor = -1;

	// Token: 0x04000B47 RID: 2887
	private sbyte[] mvalueItem = new sbyte[3];

	// Token: 0x04000B48 RID: 2888
	public static sbyte[] mvalueVolume = null;

	// Token: 0x04000B49 RID: 2889
	public static mVector vecListEvent = new mVector("MsgDiaLog vecListEvent");

	// Token: 0x04000B4A RID: 2890
	private int min;

	// Token: 0x04000B4B RID: 2891
	private int max;

	// Token: 0x04000B4C RID: 2892
	private int hbutton;

	// Token: 0x04000B4D RID: 2893
	private int wbuff;

	// Token: 0x04000B4E RID: 2894
	public static int[][] Autobuff;

	// Token: 0x04000B4F RID: 2895
	private mFont fontDia = mFont.tahoma_7_white;

	// Token: 0x04000B50 RID: 2896
	public static MsgDialog me;

	// Token: 0x04000B51 RID: 2897
	private sbyte isLottery;

	// Token: 0x04000B52 RID: 2898
	private int sizeButtonQuest = 1;

	// Token: 0x04000B53 RID: 2899
	private short timeDia;

	// Token: 0x04000B54 RID: 2900
	private long timeset;

	// Token: 0x04000B55 RID: 2901
	private MainItem[] datanguyenlieu;

	// Token: 0x04000B56 RID: 2902
	private MainItem sanpham;

	// Token: 0x04000B57 RID: 2903
	private int StepShow;

	// Token: 0x04000B58 RID: 2904
	private int timeShow;

	// Token: 0x04000B59 RID: 2905
	private int[][] posItemNguyenlieu;

	// Token: 0x04000B5A RID: 2906
	private MainItem[] itemsanpham;

	// Token: 0x04000B5B RID: 2907
	private int wsizeBox;

	// Token: 0x04000B5C RID: 2908
	private int indexShow1;

	// Token: 0x04000B5D RID: 2909
	private int indexShow2;

	// Token: 0x04000B5E RID: 2910
	private sbyte isFullEff;

	// Token: 0x04000B5F RID: 2911
	public static int maxupdate;

	// Token: 0x04000B60 RID: 2912
	public static int curupdate;

	// Token: 0x04000B61 RID: 2913
	public static int wUpdate;

	// Token: 0x04000B62 RID: 2914
	public static int hUpdate;

	// Token: 0x04000B63 RID: 2915
	public static PetItem pet;

	// Token: 0x04000B64 RID: 2916
	public static sbyte isInven_Equip = 0;

	// Token: 0x04000B65 RID: 2917
	public static sbyte INVEN = 0;

	// Token: 0x04000B66 RID: 2918
	public static sbyte EQUIP = 1;

	// Token: 0x04000B67 RID: 2919
	private int xBegin;

	// Token: 0x04000B68 RID: 2920
	private int w2cmd;

	// Token: 0x04000B69 RID: 2921
	private bool isTran;

	// Token: 0x04000B6A RID: 2922
	private int yCamBegin;

	// Token: 0x04000B6B RID: 2923
	public static bool isAutologin = false;
}
