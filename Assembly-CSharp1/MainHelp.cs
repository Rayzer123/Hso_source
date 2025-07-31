using System;

// Token: 0x02000051 RID: 81
public class MainHelp : AvMain
{
	// Token: 0x06000371 RID: 881 RVA: 0x0002E484 File Offset: 0x0002C684
	public MainHelp()
	{
		this.cmdNext = new iCommand(T.next, 0, this);
	}

	// Token: 0x06000373 RID: 883 RVA: 0x0002E4D8 File Offset: 0x0002C6D8
	public void setCaptionCmd()
	{
		this.cmdNext.caption = T.next;
	}

	// Token: 0x06000374 RID: 884 RVA: 0x0002E4EC File Offset: 0x0002C6EC
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				GameCanvas.end_Dialog_Help();
				this.p = null;
				this.Step = -1;
				this.Next = 0;
				this.setNext();
				this.SaveStep();
			}
		}
		else
		{
			this.Next++;
			this.setNext();
		}
	}

	// Token: 0x06000375 RID: 885 RVA: 0x0002E554 File Offset: 0x0002C754
	public void loadBeginGame(sbyte[] bData)
	{
		if (bData == null)
		{
			this.Step = 0;
			this.Next = -5;
		}
	}

	// Token: 0x06000376 RID: 886 RVA: 0x0002E56C File Offset: 0x0002C76C
	public void LoadStep(sbyte[] bData)
	{
		this.p = null;
		if (bData == null)
		{
			this.Step = 0;
			this.Next = -5;
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(bData);
		try
		{
			this.Step = (int)dataInputStream.readByte();
			this.Next = (int)dataInputStream.readByte();
		}
		catch (Exception ex)
		{
			this.Step = -1;
			this.Next = 0;
		}
		mSystem.outz(string.Concat(new object[]
		{
			"next=",
			this.Next,
			"  step=",
			this.Step
		}));
		if (GameCanvas.currentScreen != GameCanvas.load)
		{
			this.setNext();
		}
	}

	// Token: 0x06000377 RID: 887 RVA: 0x0002E640 File Offset: 0x0002C840
	public void SaveStep()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(this.Step);
			dataOutputStream.writeByte(this.Next);
			CRes.saveRMSName(1, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000378 RID: 888 RVA: 0x0002E6A4 File Offset: 0x0002C8A4
	public void SaveStep(sbyte step, sbyte next)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(step);
			dataOutputStream.writeByte(next);
			CRes.saveRMSName(1, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000379 RID: 889 RVA: 0x0002E700 File Offset: 0x0002C900
	public void SaveBegin()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte(0);
			CRes.saveRMSName(2, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600037A RID: 890 RVA: 0x0002E754 File Offset: 0x0002C954
	public void NextStep()
	{
		this.Step++;
		this.Next = 0;
	}

	// Token: 0x0600037B RID: 891 RVA: 0x0002E76C File Offset: 0x0002C96C
	public void setNext()
	{
		if (GameCanvas.loadmap.idMap != 0)
		{
			return;
		}
		if (GameScreen.isFinishHelp)
		{
			return;
		}
		this.cmdNext.caption = T.next;
		this.idTabHelp = -2;
		if (this.isSave())
		{
			this.SaveStep();
		}
		if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
		{
			if (this.Step == 0 && this.Next == 1)
			{
				this.Step = 0;
				this.Next = 2;
				this.SaveStep();
			}
			if (this.Step == 1 && this.Next == 8)
			{
				this.Step = 1;
				this.Next = 9;
				this.SaveStep();
			}
			if (this.Step == 2 && this.Next == 6)
			{
				this.Step = 2;
				this.Next = 7;
				this.SaveStep();
			}
			if (this.Step == 2 && this.Next == 11)
			{
				this.Step = 4;
				this.Next = 9;
				this.SaveStep();
			}
			if (this.Step == 7 && this.Next == 1)
			{
				this.Step = 8;
				this.Next = 0;
				this.SaveStep();
			}
			if (this.Step == 6 && this.Next == 1)
			{
				this.Step = 6;
				this.Next = 2;
				this.SaveStep();
			}
		}
		string[][] str = T.mHelp;
		if (GameCanvas.isTouch)
		{
			switch (this.Step)
			{
			case 0:
				if (this.Next == 2)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog = new MsgDialog();
						if (Main.isPC)
						{
							msgDialog.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, PaintInfoGameScreen.yPointMove - PaintInfoGameScreen.wArrowMove - 5, 6, false, 90);
						}
						else
						{
							msgDialog.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, PaintInfoGameScreen.xPointMove - 45, PaintInfoGameScreen.yPointMove - PaintInfoGameScreen.wArrowMove - 5, 2, false, 90);
						}
						GameCanvas.currentDialog = msgDialog;
					}
					return;
				}
				if (this.Next == 3)
				{
					str = T.mHelpPoint;
				}
				break;
			case 1:
				if (this.Next == 0)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog2 = new MsgDialog();
						if (Main.isPC)
						{
							msgDialog2.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 40, PaintInfoGameScreen.yPointKill - 40, -1, false, 80);
						}
						else
						{
							msgDialog2.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, PaintInfoGameScreen.xPointKill - 40, PaintInfoGameScreen.yPointKill - 40, 2, false, 80);
						}
						GameCanvas.currentDialog = msgDialog2;
					}
					return;
				}
				if (this.Next == 8)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog3 = new MsgDialog();
						msgDialog3.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, PaintInfoGameScreen.mPosOther[0][0], PaintInfoGameScreen.mPosOther[0][1] + 22, 3, false, 90);
						GameCanvas.currentDialog = msgDialog3;
					}
					return;
				}
				if (this.Next == 9)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						this.p = new Point();
						this.p.x = PaintInfoGameScreen.mPosOther[0][0];
						this.p.w = 80;
						this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
						this.p.h = this.strpopup.Length * GameCanvas.hText;
						this.p.y = PaintInfoGameScreen.mPosOther[0][1] + 22 + this.p.h;
						this.p.fRe = 3;
						this.p.dis = 1;
						this.p.frame = 1;
					}
					return;
				}
				break;
			case 2:
				switch (this.Next)
				{
				case 2:
				case 3:
				case 7:
					str = T.mHelpPoint;
					break;
				case 4:
				case 9:
				case 10:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						this.p = new Point();
						this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 4;
						this.p.w = 80;
						this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
						this.p.h = this.strpopup.Length * GameCanvas.hText;
						this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + this.p.h;
						this.p.fRe = 3;
						this.p.dis = 1;
						this.p.frame = 1;
					}
					this.idTabHelp = (int)MainTabNew.INVENTORY;
					return;
				}
				break;
			case 3:
			{
				int next = this.Next;
				if (next == 4)
				{
					if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
					{
						GameCanvas.end_Dialog_Help();
						int num = 3;
						for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
						{
							MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
							if (mainItem.ItemCatagory == 3)
							{
								num = i + 1;
								break;
							}
						}
						mSystem.println("index " + num);
						if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
						{
							this.p = new Point();
							this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOneItem * num - 40 + (int)MainTabNew.wOne5 * 4;
							this.p.w = 80;
							this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
							this.p.h = this.strpopup.Length * GameCanvas.hText;
							this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + this.p.h;
							this.p.fRe = 5;
							this.p.dis = 1;
							this.p.frame = 1;
						}
						this.idTabHelp = (int)MainTabNew.INVENTORY;
					}
					else
					{
						GameCanvas.end_Dialog_Help();
						if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
						{
							this.p = new Point();
							this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOneItem * 3 - 40 + (int)MainTabNew.wOne5 * 4;
							this.p.w = 80;
							this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
							this.p.h = this.strpopup.Length * GameCanvas.hText;
							this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + this.p.h;
							this.p.fRe = 5;
							this.p.dis = 1;
							this.p.frame = 1;
						}
						this.idTabHelp = (int)MainTabNew.INVENTORY;
					}
					return;
				}
				if (next == 8)
				{
					str = T.mHelpPoint;
				}
				break;
			}
			case 4:
				if (this.Next == 9)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						this.p = new Point();
						this.p.x = TabScreenNew.xback;
						this.p.y = TabScreenNew.yback - iCommand.hButtonCmd;
						this.p.w = 80;
						this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
						this.p.h = this.strpopup.Length * GameCanvas.hText;
						this.p.fRe = 0;
						this.p.dis = 1;
						this.p.frame = 1;
					}
					this.idTabHelp = -1;
					return;
				}
				break;
			case 5:
				switch (this.Next)
				{
				case 1:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog4 = new MsgDialog();
						msgDialog4.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, GameCanvas.w - 96, GameCanvas.minimap.maxY * MiniMap.wMini + 16, 5, false, 90);
						GameCanvas.currentDialog = msgDialog4;
					}
					return;
				case 2:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog5 = new MsgDialog();
						msgDialog5.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, GameCanvas.w - 96, GameCanvas.minimap.maxY * MiniMap.wMini + 16, 6, false, 90);
						GameCanvas.currentDialog = msgDialog5;
					}
					GameCanvas.minimap.setPoint(51, 2, GameCanvas.loadmap.idMap);
					return;
				case 4:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog6 = new MsgDialog();
						msgDialog6.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini - 96, 45, 4, false, 90);
						GameCanvas.currentDialog = msgDialog6;
					}
					return;
				case 5:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog7 = new MsgDialog();
						msgDialog7.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, (!Main.isPC) ? (PaintInfoGameScreen.mPosOther[3][0] - 96 + 25) : (GameCanvas.hw - 45), PaintInfoGameScreen.mPosOther[3][1] - 10, (!Main.isPC) ? 1 : -1, false, 90);
						GameCanvas.currentDialog = msgDialog7;
					}
					return;
				case 6:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog8 = new MsgDialog();
						msgDialog8.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, PaintInfoGameScreen.mPosOther[2][0] - 96 + 25, PaintInfoGameScreen.mPosOther[2][1] - 10, 1, false, 90);
						GameCanvas.currentDialog = msgDialog8;
					}
					return;
				case 7:
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						MsgDialog msgDialog9 = new MsgDialog();
						msgDialog9.setDiaHelp(T.mHelpPoint[this.Step][this.Next], this.cmdNext, PaintInfoGameScreen.mPosOther[1][0], PaintInfoGameScreen.mPosOther[1][1] + 45, 3, false, 90);
						GameCanvas.currentDialog = msgDialog9;
					}
					return;
				}
				break;
			case 6:
				if (this.Next == 2)
				{
					GameCanvas.end_Dialog_Help();
					if (this.Next < T.mHelpPoint[this.Step].Length && T.mHelpPoint[this.Step][this.Next].Length > 0)
					{
						this.p = new Point();
						this.p.x = PaintInfoGameScreen.mPosOther[0][0];
						this.p.w = 80;
						this.strpopup = mFont.tahoma_7_black.splitFontArray(T.mHelpPoint[this.Step][this.Next], this.p.w);
						this.p.h = this.strpopup.Length * GameCanvas.hText;
						this.p.y = PaintInfoGameScreen.mPosOther[0][1] + this.p.h + 22;
						this.p.fRe = 3;
						this.p.dis = 1;
						this.p.frame = 1;
					}
					return;
				}
				break;
			case 7:
				switch (this.Next)
				{
				case 6:
				case 9:
					str = T.mHelpPoint;
					break;
				}
				break;
			case 8:
				if (this.Next == 7)
				{
					str = T.mHelpPoint;
				}
				break;
			case 9:
				if (this.Next == 1 || this.Next == 5)
				{
					str = T.mHelpPoint;
				}
				break;
			}
		}
		switch (this.Step)
		{
		case 0:
			this.Step0(str);
			break;
		case 1:
			this.Step1(str);
			break;
		case 2:
			this.Step2(str);
			break;
		case 3:
			this.Step3(str);
			break;
		case 4:
			this.Step4(str);
			break;
		case 5:
			this.Step5(str);
			break;
		case 6:
			this.Step6(str);
			break;
		case 7:
			this.Step7(str);
			break;
		case 8:
			this.Step8(str);
			break;
		case 9:
			this.Step9(str);
			break;
		}
	}

	// Token: 0x0600037C RID: 892 RVA: 0x0002F7B0 File Offset: 0x0002D9B0
	public bool isSave()
	{
		switch (this.Step)
		{
		case 0:
			if (this.Next == 0)
			{
				return true;
			}
			break;
		case 1:
			if (this.Next == 1 || this.Next == 9)
			{
				return true;
			}
			break;
		case 2:
			if (this.Next == 4 || this.Next == 9)
			{
				return true;
			}
			break;
		case 3:
			if (this.Next == 4 || this.Next == 8)
			{
				return true;
			}
			break;
		case 5:
			if (this.Next == 0 || this.Next == 8)
			{
				return true;
			}
			break;
		case 6:
			if (this.Next == 2 || this.Next == 0)
			{
				return true;
			}
			break;
		case 7:
			if (this.Next == 6 || this.Next == 9)
			{
				return true;
			}
			break;
		case 8:
			if (this.Next == 7 || this.Next == 10)
			{
				return true;
			}
			break;
		case 9:
			if (this.Next == 1 || this.Next == 7)
			{
				return true;
			}
			break;
		}
		return false;
	}

	// Token: 0x0600037D RID: 893 RVA: 0x0002F904 File Offset: 0x0002DB04
	public bool setStep_Next(int s, int n)
	{
		return this.Step == s && this.Next == n;
	}

	// Token: 0x0600037E RID: 894 RVA: 0x0002F924 File Offset: 0x0002DB24
	public void updateHelp()
	{
		if (this.Step >= 0)
		{
			if (this.timeReset > 0)
			{
				this.timeReset--;
				if (this.timeReset == 1)
				{
					if (GameCanvas.currentDialog == null && GameCanvas.subDialog == null)
					{
						mSystem.outz(string.Concat(new object[]
						{
							"Step=",
							this.Step,
							"  Next=",
							this.Next
						}));
						this.setNext();
					}
					else
					{
						this.timeReset = 20;
					}
				}
			}
			switch (this.Step)
			{
			case 0:
				if (this.Next == -4 || this.Next == -2)
				{
					this.tickBegin++;
					if (GameCanvas.currentDialog != null)
					{
						GameCanvas.end_Dialog_Help();
						this.timeReset = -1;
					}
					if (GameScreen.player.posTransRoad == null && this.tickBegin > 10)
					{
						this.Next++;
						this.setNext();
					}
				}
				if (this.Next == -3)
				{
					if (GameCanvas.currentDialog != null)
					{
						GameCanvas.end_Dialog_Help();
					}
					this.tickBegin++;
					if (this.tickBegin > 60)
					{
						this.Next++;
						this.setNext();
						this.tickBegin = 0;
					}
				}
				if (this.Next == 5 && this.p != null && CRes.abs(GameScreen.player.x - this.p.x) < 10 && CRes.abs(GameScreen.player.y - this.p.y) < 10)
				{
					this.p = null;
					this.NextStep();
					this.setNext();
				}
				break;
			case 2:
				if (!GameCanvas.menu2.isShowMenu && this.Next == 10)
				{
					this.Next = 9;
				}
				break;
			case 5:
				if (this.Next == 0)
				{
					this.tickBegin++;
					if (this.tickBegin >= 20)
					{
						this.Next++;
						this.setNext();
					}
				}
				break;
			}
		}
	}

	// Token: 0x0600037F RID: 895 RVA: 0x0002FB8C File Offset: 0x0002DD8C
	public void paintHelpFrist(mGraphics g)
	{
		if (this.Step != 2 && this.Step != 3 && this.Step != 4 && this.Step != 7 && this.Step != 8 && (this.Step != 9 || this.Next == 0) && this.p != null && this.p.dis == 0 && this.fra != null)
		{
			this.fra.drawFrame(GameCanvas.gameTick / 2 % this.fra.nFrame, this.p.x, this.p.y, 0, 3, g);
		}
	}

	// Token: 0x06000380 RID: 896 RVA: 0x0002FC4C File Offset: 0x0002DE4C
	public void paintHelpLast(mGraphics g)
	{
		if (this.Step != 2 && this.Step != 3 && this.Step != 4 && this.Step != 7 && this.Step != 8 && (this.Step != 9 || this.Next == 0) && this.p != null && this.p.dis == 1)
		{
			if (this.p.frame == 0)
			{
				if (this.fra != null)
				{
					this.fra.drawFrame(GameCanvas.gameTick / 2 % this.fra.nFrame, this.p.x, this.p.y, 0, 3, g);
				}
			}
			else if (this.p.frame == 1)
			{
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
		}
	}

	// Token: 0x06000381 RID: 897 RVA: 0x0002FD74 File Offset: 0x0002DF74
	public int itemMenuHelp()
	{
		switch (this.Step)
		{
		case 1:
			if (this.Next == 9)
			{
				return 0;
			}
			break;
		case 2:
			if (this.Next == 4)
			{
				return 0;
			}
			if (this.Next == 9)
			{
				return 1;
			}
			if (this.Next == 10)
			{
				return 4;
			}
			break;
		case 3:
			if (this.Next == 4)
			{
				return 0;
			}
			break;
		case 6:
			if (this.Next == 2)
			{
				return 0;
			}
			break;
		}
		return -1;
	}

	// Token: 0x06000382 RID: 898 RVA: 0x0002FE1C File Offset: 0x0002E01C
	public void itemTabHelp(mGraphics g, Item item, sbyte id)
	{
		if (this.idTabHelp != (int)id && this.idTabHelp != -1)
		{
			return;
		}
		switch (this.Step)
		{
		case 2:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv && (this.Next == 4 || this.Next == 9))
			{
				return;
			}
			if ((this.Next == 4 || this.Next == 9) && item != null && item.ItemCatagory == 4 && (int)item.typePotion == 0 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		case 3:
			if (this.Next == 4 && item != null && item.ItemCatagory == 3 && item.type_Only_Item == 6 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			if (this.Next == 8 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		case 4:
			if (this.Next == 9 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		case 7:
			if ((this.Next == 6 || this.Next == 9) && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		case 8:
			if (this.Next == 7 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		case 9:
			if (this.Next == 1 && this.p != null)
			{
				GameCanvas.resetTrans(g);
				MainHelp.paintPopup(g, this.p.x, this.p.y, this.p.w, this.p.h, this.p.fRe, this.strpopup);
			}
			break;
		}
	}

	// Token: 0x06000383 RID: 899 RVA: 0x000301BC File Offset: 0x0002E3BC
	public static void paintPopup(mGraphics g, int x, int y, int w, int h, int archor, string[] str)
	{
		int num = y - h;
		g.setColor(MainHelp.color[0]);
		g.fillRect(x - 3, num, w + 6, h, mGraphics.isFalse);
		g.fillRect(x, num - 3, w, h + 6, mGraphics.isFalse);
		g.setColor(MainHelp.color[1]);
		g.fillRect(x - 2, num - 2, w + 4, h + 4, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 0, 3, 3, 0, x - 3, num - 3, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 3, 3, 3, 0, x + w, num - 3, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 9, 3, 3, 0, x - 3, num + h, 0, mGraphics.isFalse);
		g.drawRegion(PopupChat.mPopup[0], 0, 6, 3, 3, 0, x + w, num + h, 0, mGraphics.isFalse);
		for (int i = 0; i < str.Length; i++)
		{
			mFont.tahoma_7_black.drawString(g, str[i], x + w / 2, num + 1 + i * GameCanvas.hText, 2, mGraphics.isFalse);
		}
		switch (archor)
		{
		case 0:
			g.drawImage(AvMain.imgSelect, x, y + 2 + GameCanvas.gameTick / 2 % 4, 0, mGraphics.isFalse);
			break;
		case 1:
			g.drawImage(AvMain.imgSelect, x + w, y + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 2:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv && GameScreen.help.Step == 8 && (GameScreen.help.Next == 3 || GameScreen.help.Next == 2))
			{
				return;
			}
			g.drawImage(AvMain.imgSelect, x + w / 2, y + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isFalse);
			break;
		case 3:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, 0, mGraphics.isFalse);
			break;
		case 4:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x + w, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 5:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 1, x + w / 2, y - h - 20 + 2 + GameCanvas.gameTick / 2 % 4, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isFalse);
			break;
		case 7:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 5, x + GameCanvas.gameTick / 2 % 4, y - h / 2, mGraphics.VCENTER | mGraphics.RIGHT, mGraphics.isFalse);
			break;
		case 8:
			g.drawRegion(AvMain.imgSelect, 0, 0, 12, 16, 4, x + w + 1 + GameCanvas.gameTick / 2 % 4, y - h / 2, mGraphics.VCENTER | mGraphics.LEFT, mGraphics.isFalse);
			break;
		}
	}

	// Token: 0x06000384 RID: 900 RVA: 0x00030500 File Offset: 0x0002E700
	public void Step0(string[][] str)
	{
		int next = this.Next;
		switch (next + 5)
		{
		case 0:
			return;
		case 1:
			this.tickBegin = 0;
			this.SaveBegin();
			Player.isLockKey = true;
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad(10, 16, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 40);
			return;
		case 2:
			Player.isLockKey = true;
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			GameScreen.player.Direction = 2;
			GameScreen.player.strChatPopup = "...";
			this.tickBegin = 0;
			return;
		case 3:
			this.tickBegin = 0;
			Player.isLockKey = true;
			GameScreen.player.resetAction();
			GameScreen.player.toX = GameScreen.player.x;
			GameScreen.player.toY = GameScreen.player.y;
			GameScreen.player.xStopMove = 0;
			GameScreen.player.yStopMove = 0;
			GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad(24 + CRes.random_Am_0(3), 21 + CRes.random_Am_0(3), GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 40);
			return;
		case 4:
		{
			mVector mVector = new mVector("MainHelp menu");
			mVector.addElement(this.cmdNext);
			iCommand o = new iCommand(T.cancel, 1, this);
			mVector.addElement(o);
			GameCanvas.start_Select_Dialog(T.hoihelp, mVector);
			return;
		}
		case 9:
		{
			if (Player.isLockKey)
			{
				Player.isLockKey = false;
			}
			if (!Player.isSendMove)
			{
				Player.isSendMove = true;
			}
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				int num = GameCanvas.w - 30;
				if (num > 200)
				{
					num = 200;
				}
				int x = GameCanvas.hw - num / 2;
				int y = GameCanvas.h - GameCanvas.hCommand * 2;
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, x, y, -1, false, num);
				GameCanvas.currentDialog = msgDialog;
			}
			int num2 = 80;
			int num3 = 0;
			bool flag = false;
			do
			{
				num3++;
				int num4 = GameScreen.player.x + CRes.random_Am(40, num2);
				int num5 = GameScreen.player.y + CRes.random_Am(40, num2);
				int tile = GameCanvas.loadmap.getTile(num4, num5);
				if (GameScreen.setIsInScreen(num4, num5) && tile != -1 && tile != 1)
				{
					flag = true;
					this.p = new Point();
					this.p.x = num4;
					this.p.y = num5;
					this.p.dis = 0;
					this.p.frame = 0;
					this.fra = PaintInfoGameScreen.fraFocusIngame;
				}
				if (num3 > 10)
				{
					num2 += 10;
					num3 = 0;
				}
			}
			while (!flag);
			return;
		}
		case 10:
			GameCanvas.end_Dialog_Help();
			return;
		}
		GameCanvas.end_Dialog_Help();
		this.dialogCenter(str);
	}

	// Token: 0x06000385 RID: 901 RVA: 0x000308B8 File Offset: 0x0002EAB8
	public void Step1(string[][] str)
	{
		int next = this.Next;
		switch (next)
		{
		case 2:
			GameCanvas.end_Dialog_Help();
			break;
		default:
			if (next != 9)
			{
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					int num = GameCanvas.w - 30;
					if (num > 200)
					{
						num = 200;
					}
					int x = GameCanvas.hw - num / 2;
					int y = GameCanvas.h - GameCanvas.hCommand * 2;
					MsgDialog msgDialog = new MsgDialog();
					msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, x, y, -1, false, num);
					GameCanvas.currentDialog = msgDialog;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					this.p = new Point();
					this.p.x = 3;
					this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
					this.p.w = 80;
					this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
					this.p.h = this.strpopup.Length * GameCanvas.hText;
					this.p.fRe = 2;
					this.p.dis = 1;
					this.p.frame = 1;
				}
			}
			break;
		case 5:
			GameCanvas.end_Dialog_Help();
			break;
		}
	}

	// Token: 0x06000386 RID: 902 RVA: 0x00030A78 File Offset: 0x0002EC78
	private void Step2(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			this.leftTab(0, str);
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 2:
		case 3:
		case 7:
		case 8:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 3, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = GameCanvas.hw - 40;
				this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.fRe = 2;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = (int)MainTabNew.INVENTORY;
			break;
		case 5:
		case 6:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = GameCanvas.hw - 40;
				this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.fRe = 2;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = (int)MainTabNew.INVENTORY;
			break;
		case 10:
			this.idTabHelp = (int)MainTabNew.INVENTORY;
			break;
		case 11:
		case 12:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem * 2 + (int)MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 3, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 13:
			this.NextStep();
			this.setNext();
			break;
		}
	}

	// Token: 0x06000387 RID: 903 RVA: 0x00030F4C File Offset: 0x0002F14C
	public void Step3(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
		case 1:
		case 2:
		case 3:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem * 3 - 40 + (int)MainTabNew.wOne5 * 4, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = GameCanvas.hw - 40;
				this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.fRe = 2;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = (int)MainTabNew.INVENTORY;
			break;
		case 5:
		case 6:
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			this.leftTab(1, str);
			break;
		case 8:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 16 + this.p.h;
				this.p.fRe = 3;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = -1;
			break;
		}
	}

	// Token: 0x06000388 RID: 904 RVA: 0x000312D8 File Offset: 0x0002F4D8
	public void Step4(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
		case 4:
		case 5:
		case 6:
		case 7:
		case 8:
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 1:
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack / 5 * 2 + TabMySeftNew.delta + 16, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + MainTabNew.hblack / 12 * 8 / 2, 7, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 2:
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack / 5 * 2 + TabMySeftNew.delta - 16, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + MainTabNew.hblack / 12 * 8 / 2, 8, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 3:
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack - (int)MainTabNew.wOneItem * 2 - (int)MainTabNew.wOne5 - 20, 2, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = GameCanvas.w - 83;
				this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.fRe = 2;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = -1;
			break;
		}
	}

	// Token: 0x06000389 RID: 905 RVA: 0x000316A4 File Offset: 0x0002F8A4
	public void Step5(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
			if (GameCanvas.isVN_Eng || IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				this.p = null;
				GameScreen.player.strChatPopup = T.timduongtoilang;
				this.tickBegin = 0;
			}
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.w - 96, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini - 16, 2, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 2:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.w - 96, GameCanvas.h - 23 - GameCanvas.minimap.maxY * MiniMap.wMini - 16, -1, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			GameCanvas.minimap.setPoint(51, 2, GameCanvas.loadmap.idMap);
			break;
		case 3:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, 3, 60, 5, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog4 = new MsgDialog();
				msgDialog4.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.w - 93, 45, 5, false, 90);
				GameCanvas.currentDialog = msgDialog4;
			}
			break;
		case 5:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog5 = new MsgDialog();
				msgDialog5.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.w - 93, GameCanvas.h - GameCanvas.hCommand, 2, false, 90);
				GameCanvas.currentDialog = msgDialog5;
			}
			break;
		case 6:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog6 = new MsgDialog();
				msgDialog6.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, GameCanvas.h - GameCanvas.hCommand - 14 - 25, 2, false, 90);
				GameCanvas.currentDialog = msgDialog6;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			this.dialogCenter(str);
			break;
		case 8:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				if (!this.isStepp5)
				{
					GameCanvas.end_Dialog_Help();
					this.p = null;
					GameScreen.player.strChatPopup = T.timduongtoilang;
					this.tickBegin = 0;
					GameCanvas.end_Dialog_Help();
					this.isStepp5 = true;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
			}
			break;
		}
	}

	// Token: 0x0600038A RID: 906 RVA: 0x00031A8C File Offset: 0x0002FC8C
	public void Step6(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
		case 1:
			this.dialogCenter(str);
			break;
		case 2:
			GameCanvas.end_Dialog_Help();
			this.PopupLeft(str);
			break;
		}
	}

	// Token: 0x0600038B RID: 907 RVA: 0x00031ADC File Offset: 0x0002FCDC
	public void Step7(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			this.leftTab(2, str);
			break;
		case 1:
		case 2:
		case 3:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				int num = 20;
				if (GameCanvas.isTouch)
				{
					num = 24;
				}
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, num * T.mKyNang.Length + MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + 20, 5, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				int num2 = 20;
				if (GameCanvas.isTouch)
				{
					num2 = 24;
				}
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + MainTabNew.wblack / 2, num2 * T.mKyNang.Length + MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem, 2, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 5:
		case 7:
		case 8:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 6:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				int x = MainTabNew.gI().xTab + MainTabNew.wblack / 4 + 30;
				int y = MainTabNew.gI().yTab + GameCanvas.hText + GameCanvas.h / 5 + 4 + ((!GameCanvas.isTouch) ? 0 : 4);
				this.p = new Point();
				this.p.x = x;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.y = y;
				this.p.fRe = 2;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = (int)MainTabNew.MY_INFO;
			break;
		case 9:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem * 3 + 16 + this.p.h;
				this.p.fRe = 3;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = -1;
			break;
		}
	}

	// Token: 0x0600038C RID: 908 RVA: 0x00031F64 File Offset: 0x00030164
	private void Step8(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				this.leftTab(3, str);
				GameCanvas.AllInfo.selectTab = 3;
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog = new MsgDialog();
					msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
					GameCanvas.currentDialog = msgDialog;
				}
			}
			break;
		case 1:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				this.leftTab(4, str);
				GameCanvas.AllInfo.selectTab = 4;
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog2 = new MsgDialog();
					msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack / 2, 7, false, 90);
					GameCanvas.currentDialog = msgDialog2;
				}
			}
			break;
		case 2:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog3 = new MsgDialog();
					msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack / 2, 2, false, 90);
					GameCanvas.currentDialog = msgDialog3;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog4 = new MsgDialog();
					msgDialog4.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + MainTabNew.wblack / 2 + MainTabNew.wblack / 8, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack / 2, 7, false, 90);
					GameCanvas.currentDialog = msgDialog4;
				}
			}
			break;
		case 3:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog5 = new MsgDialog();
					msgDialog5.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + MainTabNew.wblack / 4 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack / 2, 2, false, 90);
					GameCanvas.currentDialog = msgDialog5;
				}
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog6 = new MsgDialog();
					msgDialog6.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + MainTabNew.wblack / 4 * 3, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack / 2, 8, false, 90);
					GameCanvas.currentDialog = msgDialog6;
				}
			}
			break;
		case 4:
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
			{
				GameCanvas.end_Dialog_Help();
				this.Step = -1;
				this.Next = 0;
				this.SaveStep();
			}
			else
			{
				GameCanvas.end_Dialog_Help();
				if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
				{
					MsgDialog msgDialog7 = new MsgDialog();
					msgDialog7.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
					GameCanvas.currentDialog = msgDialog7;
				}
			}
			break;
		case 5:
		case 6:
		case 8:
		case 9:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog8 = new MsgDialog();
				msgDialog8.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog8;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2 + MainTabNew.wblack / 8 * 3;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
				this.p.fRe = -1;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = (int)MainTabNew.SKILLS;
			break;
		case 10:
			GameCanvas.end_Dialog_Help();
			break;
		}
	}

	// Token: 0x0600038D RID: 909 RVA: 0x0003266C File Offset: 0x0003086C
	public void Step9(string[][] str)
	{
		switch (this.Next)
		{
		case 0:
			GameCanvas.end_Dialog_Help();
			this.dialogCenter(str);
			break;
		case 1:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				this.p = new Point();
				this.p.x = MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2;
				this.p.w = 80;
				this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
				this.p.h = this.strpopup.Length * GameCanvas.hText;
				this.p.y = MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 5 + 16 + this.p.h;
				this.p.fRe = 3;
				this.p.dis = 1;
				this.p.frame = 1;
			}
			this.idTabHelp = -1;
			break;
		case 2:
		case 5:
		case 6:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog = new MsgDialog();
				msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, GameCanvas.hw - 45, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * 2 + 22, 6, false, 90);
				GameCanvas.currentDialog = msgDialog;
			}
			break;
		case 3:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog2 = new MsgDialog();
				msgDialog2.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + MainTabNew.wblack / 4 - 45, MainTabNew.gI().yTab + (int)MainTabNew.wOneItem + GameCanvas.h / 5 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog2;
			}
			break;
		case 4:
			GameCanvas.end_Dialog_Help();
			if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
			{
				MsgDialog msgDialog3 = new MsgDialog();
				msgDialog3.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOneItem + MainTabNew.wblack / 4 * 3 - 45, MainTabNew.gI().yTab + (int)MainTabNew.wOneItem + GameCanvas.h / 5 + 22, 5, false, 90);
				GameCanvas.currentDialog = msgDialog3;
			}
			break;
		case 7:
			GameCanvas.end_Dialog_Help();
			this.Step = -1;
			this.Next = 0;
			this.SaveStep();
			break;
		}
	}

	// Token: 0x0600038E RID: 910 RVA: 0x000329B8 File Offset: 0x00030BB8
	public void PopupLeft(string[][] str)
	{
		if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
		{
			this.p = new Point();
			this.p.x = 3;
			this.p.y = GameCanvas.h - GameCanvas.hCommand - 14;
			this.p.w = 80;
			this.strpopup = mFont.tahoma_7_black.splitFontArray(str[this.Step][this.Next], this.p.w);
			this.p.h = this.strpopup.Length * GameCanvas.hText;
			this.p.fRe = 2;
			this.p.dis = 1;
			this.p.frame = 1;
		}
	}

	// Token: 0x0600038F RID: 911 RVA: 0x00032A98 File Offset: 0x00030C98
	public void dialogCenter(string[][] str)
	{
		if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
		{
			int num = GameCanvas.w - 30;
			if (num > 200)
			{
				num = 200;
			}
			int x = GameCanvas.hw - num / 2;
			int y = GameCanvas.h - GameCanvas.hCommand * 2;
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, x, y, -1, false, num);
			GameCanvas.currentDialog = msgDialog;
		}
	}

	// Token: 0x06000390 RID: 912 RVA: 0x00032B34 File Offset: 0x00030D34
	public void leftTab(int index, string[][] str)
	{
		GameCanvas.end_Dialog_Help();
		if (this.Next < str[this.Step].Length && str[this.Step][this.Next].Length > 0)
		{
			MsgDialog msgDialog = new MsgDialog();
			msgDialog.setDiaHelp(str[this.Step][this.Next], this.cmdNext, MainTabNew.gI().xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2, MainTabNew.gI().yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + 16 + index * (int)MainTabNew.wOneItem, 3, false, 90);
			GameCanvas.currentDialog = msgDialog;
		}
	}

	// Token: 0x040004D8 RID: 1240
	public const sbyte FRIST = 0;

	// Token: 0x040004D9 RID: 1241
	public const sbyte LAST = 1;

	// Token: 0x040004DA RID: 1242
	public const sbyte POINT_FRAME = 0;

	// Token: 0x040004DB RID: 1243
	public const sbyte POPUP_HAND = 1;

	// Token: 0x040004DC RID: 1244
	public const sbyte POS_NULL = -1;

	// Token: 0x040004DD RID: 1245
	public const sbyte POS_LEFT = 0;

	// Token: 0x040004DE RID: 1246
	public const sbyte POS_RIGHT = 1;

	// Token: 0x040004DF RID: 1247
	public const sbyte POS_CENTER = 2;

	// Token: 0x040004E0 RID: 1248
	public const sbyte POS_TOP_LEFT = 3;

	// Token: 0x040004E1 RID: 1249
	public const sbyte POS_TOP_RIGHT = 4;

	// Token: 0x040004E2 RID: 1250
	public const sbyte POS_TOP_CENTER = 5;

	// Token: 0x040004E3 RID: 1251
	public const sbyte POS_TOP_NULL = 6;

	// Token: 0x040004E4 RID: 1252
	public const sbyte POS_LEFT_CENTER = 7;

	// Token: 0x040004E5 RID: 1253
	public const sbyte POS_RIGHT_CENTER = 8;

	// Token: 0x040004E6 RID: 1254
	public int Step = -1;

	// Token: 0x040004E7 RID: 1255
	public int Next = -5;

	// Token: 0x040004E8 RID: 1256
	public int idTabHelp = -2;

	// Token: 0x040004E9 RID: 1257
	public int tickBegin;

	// Token: 0x040004EA RID: 1258
	public int timeReset;

	// Token: 0x040004EB RID: 1259
	private iCommand cmdNext;

	// Token: 0x040004EC RID: 1260
	public Point p;

	// Token: 0x040004ED RID: 1261
	public FrameImage fra;

	// Token: 0x040004EE RID: 1262
	public string[] strpopup;

	// Token: 0x040004EF RID: 1263
	public new static int[] color = new int[]
	{
		3349556,
		16760428
	};

	// Token: 0x040004F0 RID: 1264
	private bool isStepp5;
}
