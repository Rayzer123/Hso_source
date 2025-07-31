using System;

// Token: 0x020000A6 RID: 166
public class TabSkillsNew : MainTabNew
{
	// Token: 0x0600081C RID: 2076 RVA: 0x0008C5CC File Offset: 0x0008A7CC
	public TabSkillsNew(string name)
	{
		this.typeTab = MainTabNew.SKILLS;
		this.nameTab = name;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack % 8 / 2;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		TabSkillsNew.XYpaint = mSystem.new_M_Int(Player.MaxSkill, 2);
		int num = this.yBegin + (int)MainTabNew.wOneItem / 2 + GameCanvas.hText;
		for (int i = 0; i < Player.MaxSkill; i++)
		{
			if (i == 0)
			{
				TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 2;
				TabSkillsNew.XYpaint[i][1] = num;
				num += this.sizeKill * 2;
			}
			else
			{
				TabSkillsNew.XYpaint[i][1] = num;
				if (i % 2 == 1)
				{
					TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 4;
				}
				else
				{
					TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 4 * 3;
					num += this.sizeKill * 2;
				}
			}
		}
		this.init();
		this.cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		this.cmdSetPoint = new iCommand(T.setPoint, 0, this);
		this.cmdSendSetPoint = new iCommand(T.cong, 1, this);
		this.cmdSendSetPointOne = new iCommand(T.cong, 2, this);
		this.cmdSetKey = new iCommand(T.setKey, 3, this);
		this.cmdMenu = new iCommand(T.select, 5, this);
		this.cmdupskill = new iCommand(T.nangcap, 6, this);
		this.vecEffRe.removeAllElements();
		this.w8 = MainTabNew.wblack / 8;
	}

	// Token: 0x0600081E RID: 2078 RVA: 0x0008C804 File Offset: 0x0008AA04
	public override void init()
	{
		MainTabNew.timePaintInfo = 0;
		int yLimit = TabSkillsNew.XYpaint[Player.MaxSkill - 1][1] - this.yBegin + this.sizeKill - MainTabNew.hblack + 5;
		MainScreen.cameraSub.setAll(0, yLimit, 0, 0);
		this.list = new ListNew(this.xBegin, this.yBegin + GameCanvas.hText + 2, MainTabNew.wblack, MainTabNew.hblack - GameCanvas.hText - 2, 0, 0, MainScreen.cameraSub.yLimit);
		if (!GameCanvas.isTouch)
		{
			this.right = this.cmdBack;
			this.center = this.cmdMenu;
		}
		if (GameCanvas.isTouch)
		{
			this.idSelect = -1;
		}
		else
		{
			this.idSelect = 0;
		}
		this.listContent = null;
	}

	// Token: 0x0600081F RID: 2079 RVA: 0x0008C8D0 File Offset: 0x0008AAD0
	public new void backTab()
	{
		if (this.isSaveSkill)
		{
			TabSkillsNew.saveSkill();
			this.isSaveSkill = false;
		}
		MainTabNew.timePaintInfo = 0;
		MainTabNew.Focus = MainTabNew.TAB;
		if (GameCanvas.isTouch)
		{
			this.idSelect = -1;
		}
		else
		{
			this.idSelect = 0;
		}
		base.backTab();
	}

	// Token: 0x06000820 RID: 2080 RVA: 0x0008C928 File Offset: 0x0008AB28
	public override void commandPointer(int index, int subIndex)
	{
		if ((this.idSelect == -1 || this.idSelect > TabSkillsNew.vecPaintSkill.size() - 1) && index != -1)
		{
			return;
		}
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
		{
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect);
			if (skill.lvMin > GameScreen.player.Lv)
			{
				GameCanvas.start_Ok_Dialog(T.capdochuadu);
				return;
			}
			if (Player.diemKyNang == 1)
			{
				GameCanvas.start_Left_Dialog(T.cong1kynang + skill.name, this.cmdSendSetPointOne);
			}
			else if (Player.diemKyNang > 0)
			{
				int num = Player.diemKyNang;
				if (num > 10 - Player.mCurentLvSkill[skill.Id])
				{
					num = 10 - Player.mCurentLvSkill[skill.Id];
				}
				this.inputDialog = new InputDialog();
				this.inputDialog.setinfo(string.Concat(new object[]
				{
					T.nhapsodiem,
					skill.name,
					T.nhohonhoacbang,
					num,
					")"
				}), this.cmdSendSetPoint, true, T.tabkynang);
				GameCanvas.currentDialog = this.inputDialog;
			}
			break;
		}
		case 2:
		{
			short num2 = 0;
			try
			{
				num2 = short.Parse(this.inputDialog.tfInput.getText());
			}
			catch (Exception ex)
			{
				num2 = 0;
			}
			if (num2 < 1)
			{
				return;
			}
			GlobalService.gI().Add_Base_Skill_Point(1, (sbyte)((Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect)).Id, num2);
			if (GameScreen.help.setStep_Next(8, 7))
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			else
			{
				GameCanvas.end_Dialog();
			}
			break;
		}
		case 3:
			GameCanvas.end_Dialog();
			GlobalService.gI().Add_Base_Skill_Point(1, (sbyte)((Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect)).Id, 1);
			if (GameScreen.help.setStep_Next(8, 7))
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			MainTabNew.timePaintInfo = 0;
			break;
		case 4:
		{
			mVector mVector = new mVector("TabSkillsNew menu");
			for (int i = 0; i < 5; i++)
			{
				iCommand o;
				if (!GameCanvas.isTouch)
				{
					if (TField.isQwerty)
					{
						o = new iCommand(T.phim + PaintInfoGameScreen.mValueChar[i], 4, i, this);
					}
					else
					{
						o = new iCommand(T.phim + PaintInfoGameScreen.mValueHotKey[i], 4, i, this);
					}
				}
				else
				{
					o = new iCommand(T.oso + (i + 1), 4, i, this);
				}
				mVector.addElement(o);
			}
			GameCanvas.menu2.startAt(mVector, 2, T.setKey, false, null);
			break;
		}
		case 5:
		{
			Skill skill2 = (Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect);
			Player.mhotkey[Player.levelTab][subIndex].setHotKey(skill2.Id, (int)HotKey.SKILL, 0);
			if (GameCanvas.isTouch)
			{
				TabSkillsNew.saveSkill();
			}
			else
			{
				this.isSaveSkill = true;
			}
			break;
		}
		case 6:
		{
			if (this.idSelect == -1)
			{
				return;
			}
			mVector mVector2 = new mVector("TabSkillsNew vecmenu");
			mVector2 = this.doMenu();
			if (mVector2 != null && mVector2.size() > 0)
			{
				GameCanvas.menu2.startAt(mVector2, 2, T.kynang, false, null);
			}
			break;
		}
		case 7:
			GlobalService.gI().Add_Base_Skill_Point(2, (sbyte)((Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect)).Id);
			this.vecEffRe.removeAllElements();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x06000821 RID: 2081 RVA: 0x0008CD50 File Offset: 0x0008AF50
	public void upgraderesult(int type)
	{
		if (type == 0)
		{
			mSound.playSound(27, mSound.volumeSound);
			this.vecEffRe.removeAllElements();
			this.addEffectEnd_ReBuild_ss(11, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2);
			this.addEffectRebuild(69, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2, 300);
			this.addEffectRebuild(69, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2, 300);
			GameCanvas.addInfoChar(T.thatbai);
		}
		else
		{
			mSound.playSound(26, mSound.volumeSound);
			this.vecEffRe.removeAllElements();
			this.addEffectEnd_ReBuild_ss(32, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2);
			this.addEffectEnd_ReBuild_ss(33, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2);
			this.addEffectEnd_ReBuild_ss(34, TabSkillsNew.XYpaint[this.idSelect][0], TabSkillsNew.XYpaint[this.idSelect][1] + this.sizeKill / 2);
			GameCanvas.addInfoChar(T.thanhcong);
		}
	}

	// Token: 0x06000822 RID: 2082 RVA: 0x0008CEC4 File Offset: 0x0008B0C4
	public void addEffectEnd_ReBuild_ss(int type, int x, int y)
	{
		EffectEnd o = new EffectEnd(type, x, y);
		this.vecEffRe.addElement(o);
	}

	// Token: 0x06000823 RID: 2083 RVA: 0x0008CEE8 File Offset: 0x0008B0E8
	public void addEffectRebuild(int type, int x, int y, int time)
	{
		EffectSkill o = new EffectSkill(type, x, y, time, 0, 0);
		this.vecEffRe.addElement(o);
	}

	// Token: 0x06000824 RID: 2084 RVA: 0x0008CF10 File Offset: 0x0008B110
	public void setXYSkill(mVector vec)
	{
		TabSkillsNew.XYpaint = null;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack % 8 / 2;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		TabSkillsNew.XYpaint = mSystem.new_M_Int(Player.MaxSkill, 2);
		int num = this.yBegin + (int)MainTabNew.wOneItem / 2 + GameCanvas.hText;
		for (int i = 0; i < vec.size(); i++)
		{
			Skill skill = (Skill)vec.elementAt(i);
			if (skill != null)
			{
				if (i == 0)
				{
					TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 2;
					TabSkillsNew.XYpaint[i][1] = num;
					num += this.sizeKill * 2;
				}
				else
				{
					TabSkillsNew.XYpaint[i][1] = num;
					if ((int)skill.typePaint == 0)
					{
						TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 4;
					}
					else if ((int)skill.typePaint == 1)
					{
						TabSkillsNew.XYpaint[i][0] = this.xBegin + MainTabNew.wblack / 4 * 3;
						if (i < vec.size() - 2)
						{
							num += this.sizeKill * 2;
						}
					}
				}
			}
		}
	}

	// Token: 0x06000825 RID: 2085 RVA: 0x0008D05C File Offset: 0x0008B25C
	public override void paint(mGraphics g)
	{
		mFont.tahoma_7_white.drawString(g, T.diemkynang + Player.diemKyNang, this.xBegin + 2, this.yBegin + 3, 0, mGraphics.isFalse);
		g.setClip(this.xBegin, this.yBegin + GameCanvas.hText + 2, MainTabNew.wblack, MainTabNew.hblack - 2 - GameCanvas.hText);
		g.translate(0, -MainScreen.cameraSub.yCam);
		for (int i = 0; i < TabSkillsNew.vecPaintSkill.size(); i++)
		{
			this.paintLine(g, i);
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(i);
			if (skill != null)
			{
				skill.paint(g, TabSkillsNew.XYpaint[i][0], TabSkillsNew.XYpaint[i][1] + this.sizeKill / 2, 3);
				if (i == this.idSelect && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
				{
					g.drawImage(AvMain.imgSelect_1, TabSkillsNew.XYpaint[i][0] - this.sizeKill / 2 - 2, TabSkillsNew.XYpaint[i][1] - 2, 0, mGraphics.isTrue);
				}
				if (skill.lvMin > GameScreen.player.Lv)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, 20, 0, TabSkillsNew.XYpaint[i][0], TabSkillsNew.XYpaint[i][1] + this.sizeKill / 2, 3, mGraphics.isTrue);
				}
				if (i != 0)
				{
					AvMain.Font3dWhite(g, Player.mCurentLvSkill[skill.Id] + string.Empty, TabSkillsNew.XYpaint[i][0] + this.sizeKill / 2 + 4, TabSkillsNew.XYpaint[i][1] + this.sizeKill / 2 - 12, 0);
					if (Player.mPlusLvSkill[skill.Id] > 0)
					{
						AvMain.Font3dColor(g, "+" + Player.mPlusLvSkill[skill.Id], TabSkillsNew.XYpaint[i][0] + this.sizeKill / 2 + 4, TabSkillsNew.XYpaint[i][1] + this.sizeKill - 12, 0, 1);
					}
				}
			}
		}
		for (int j = 0; j < this.vecEffRe.size(); j++)
		{
			MainEffect mainEffect = (MainEffect)this.vecEffRe.elementAt(j);
			mainEffect.paint(g);
		}
		if (((!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null) || MainTabNew.longwidth > 0) && (int)MainTabNew.Focus == (int)MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			base.paintPopupContent(g, false);
			if (this.vecListCmd != null)
			{
				for (int k = 0; k < this.vecListCmd.size(); k++)
				{
					iCommand iCommand = (iCommand)this.vecListCmd.elementAt(k);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
		}
	}

	// Token: 0x06000826 RID: 2086 RVA: 0x0008D358 File Offset: 0x0008B558
	public void paintLine(mGraphics g, int i)
	{
		g.setColor(MainTabNew.color[6]);
		if (this.stylePaint[i] == 0)
		{
			g.fillRect(TabSkillsNew.XYpaint[i][0], TabSkillsNew.XYpaint[i][1] + this.sizeKill, 1, this.hKill * 2 + this.sizeKill, mGraphics.isTrue);
		}
		else if (this.stylePaint[i] == 1)
		{
			g.fillRect(TabSkillsNew.XYpaint[i][0], TabSkillsNew.XYpaint[i][1] + this.sizeKill, 1, this.sizeKill / 2, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] - 2 * this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.sizeKill / 2, this.w8 * 4 + 1, 1, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] - 2 * this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.sizeKill / 2 + 1, 1, this.sizeKill / 2, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] + 2 * this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.sizeKill / 2 + 1, 1, this.sizeKill / 2, mGraphics.isTrue);
		}
		else if (this.stylePaint[i] == 2)
		{
			g.fillRect(TabSkillsNew.XYpaint[i][0], TabSkillsNew.XYpaint[i][1] + this.sizeKill, 1, this.hKill / 2, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] - this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.hKill / 2, this.w8 * 2 + 1, 1, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] - this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.hKill / 2 + 1, 1, this.hKill / 2 + 4, mGraphics.isTrue);
			g.fillRect(TabSkillsNew.XYpaint[i][0] + this.w8, TabSkillsNew.XYpaint[i][1] + this.sizeKill + this.hKill / 2 + 1, 1, this.hKill / 2 + 4, mGraphics.isTrue);
		}
	}

	// Token: 0x06000827 RID: 2087 RVA: 0x0008D5B8 File Offset: 0x0008B7B8
	public override void update()
	{
		try
		{
			for (int i = 0; i < this.vecEffRe.size(); i++)
			{
				MainEffect mainEffect = (MainEffect)this.vecEffRe.elementAt(i);
				mainEffect.update();
				if (mainEffect.isStop)
				{
					this.vecEffRe.removeElement(mainEffect);
				}
			}
			if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
			{
				if (this.listContent != null)
				{
					this.listContent.moveCamera();
				}
				if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
				{
					MainTabNew.timePaintInfo++;
					if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
					{
						this.setPaintInfo();
					}
				}
				if (GameCanvas.isTouch)
				{
					this.list.moveCamera();
				}
				else
				{
					MainScreen.cameraSub.UpdateCamera();
					if (this.yCon < MainScreen.cameraSub.yCam + 4)
					{
						this.yCon = MainScreen.cameraSub.yCam + 4;
					}
				}
			}
			else
			{
				MainTabNew.timePaintInfo = 0;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000828 RID: 2088 RVA: 0x0008D6E8 File Offset: 0x0008B8E8
	public override void updatekey()
	{
		base.updatekey();
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			int num = this.idSelect;
			if (GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
			{
				TabScreenNew.timeRepaint = 10;
				if (this.idSelect == -1)
				{
					GameCanvas.clearKeyHold();
					this.idSelect = 0;
					return;
				}
			}
			if (this.listContent != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					if (this.listContent.cmtoX > 0)
					{
						this.listContent.cmtoX -= GameCanvas.hText;
					}
					else
					{
						this.listContent.cmtoX = 0;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (this.listContent.cmtoX < this.listContent.cmxLim)
					{
						this.listContent.cmtoX += GameCanvas.hText;
					}
					else
					{
						this.listContent.cmtoX = this.listContent.cmxLim;
					}
					GameCanvas.clearKeyHold(8);
				}
			}
			else if (GameCanvas.keyMyHold[2])
			{
				this.idSelect -= 2;
				if (this.idSelect < 0)
				{
					this.idSelect = 0;
				}
				TabScreenNew.timeRepaint = 10;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				TabScreenNew.timeRepaint = 10;
				this.idSelect += 2;
				if (this.idSelect > TabSkillsNew.vecPaintSkill.size() - 1)
				{
					this.idSelect = TabSkillsNew.vecPaintSkill.size() - 1;
				}
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				TabScreenNew.timeRepaint = 10;
				if (this.idSelect % 2 == 1 || this.idSelect == 0)
				{
					MainTabNew.Focus = MainTabNew.TAB;
					this.idSelect = 0;
				}
				else
				{
					this.idSelect--;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				TabScreenNew.timeRepaint = 10;
				if (this.idSelect < TabSkillsNew.vecPaintSkill.size() - 1)
				{
					this.idSelect++;
				}
				GameCanvas.clearKeyHold(6);
			}
			if (this.idSelect < 0)
			{
				this.idSelect = -1;
				return;
			}
			this.idSelect = base.resetSelect(this.idSelect, TabSkillsNew.vecPaintSkill.size() - 1, false);
			Skill skill = null;
			if (this.idSelect != num && this.idSelect >= 0 && this.idSelect <= TabSkillsNew.vecPaintSkill.size() - 1)
			{
				this.listContent = null;
				this.cmdListBig();
				MainTabNew.timePaintInfo = 0;
				MainScreen.cameraSub.moveCamera(0, TabSkillsNew.XYpaint[this.idSelect][1] - this.yBegin - MainTabNew.hblack / 2);
				skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect);
			}
			if (!GameCanvas.isTouch && skill != null)
			{
				if (this.center == null)
				{
					if (skill.lvMin <= GameScreen.player.Lv && (Player.mCurentLvSkill[skill.Id] != 0 || Player.diemKyNang > 0))
					{
						this.center = this.cmdMenu;
					}
				}
				else if (skill.lvMin > GameScreen.player.Lv || (Player.mCurentLvSkill[skill.Id] == 0 && Player.diemKyNang == 0))
				{
					this.center = null;
				}
			}
		}
	}

	// Token: 0x06000829 RID: 2089 RVA: 0x0008DA98 File Offset: 0x0008BC98
	public override void setPaintInfo()
	{
		if (this.idSelect >= Player.mKillPlayer.Length || this.idSelect == -1)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect);
		if (skill == null)
		{
			this.mContent = null;
			this.mPlusContent = null;
			this.listContent = null;
			return;
		}
		this.name = skill.name;
		if (Player.mCurentLvSkill[skill.Id] > 0)
		{
			this.name = this.name + " Lv" + (Player.mCurentLvSkill[skill.Id] + Player.mPlusLvSkill[skill.Id]);
		}
		this.mContent = skill.getContent();
		this.mPlusContent = null;
		this.listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			int num = this.mContent.Length;
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - this.hcmd)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - this.hcmd));
			}
			else if (GameCanvas.isTouch)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent - this.hcmd, 0, 0, 0);
			}
			this.cmdListBig();
			return;
		}
		int num2 = TabSkillsNew.XYpaint[this.idSelect][0];
		this.xCon = num2 - 45;
		if (this.xCon < 2)
		{
			this.xCon = 2;
		}
		else if (this.xCon + 92 > GameCanvas.w)
		{
			this.xCon = GameCanvas.w - 92;
		}
		this.wContent = 130;
		int num3 = TabSkillsNew.XYpaint[this.idSelect][1] - MainScreen.cameraSub.yCam;
		if (num3 < this.yBegin + MainTabNew.hblack / 2)
		{
			this.yCon = num3 + this.sizeKill + 2 + MainScreen.cameraSub.yCam;
		}
		else
		{
			this.yCon = num3 + 1 - GameCanvas.hText * (this.mContent.Length + 1) - this.sizeKill / 2 + MainScreen.cameraSub.yCam;
		}
		if (this.yCon - MainScreen.cameraSub.yCam + (this.mContent.Length + 1) * GameCanvas.hText + 8 > GameCanvas.h - GameCanvas.hCommand)
		{
			this.yCon = GameCanvas.h - GameCanvas.hCommand - ((this.mContent.Length + 1) * GameCanvas.hText + 8 - MainScreen.cameraSub.yCam);
		}
		if (this.yCon < MainScreen.cameraSub.yCam)
		{
			this.yCon = MainScreen.cameraSub.yCam;
		}
		int num4 = this.mContent.Length;
		if (num4 * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			this.listContent = new ListNew(this.xCon, this.yCon, this.wContent, MainTabNew.hMaxContent, 0, 0, num4 * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	// Token: 0x0600082A RID: 2090 RVA: 0x0008DDB8 File Offset: 0x0008BFB8
	public override void updatePointer()
	{
		bool flag = false;
		if (this.listContent != null && GameCanvas.isPoint(this.listContent.x, this.listContent.y, this.listContent.maxW, this.listContent.maxH))
		{
			this.listContent.update_Pos_UP_DOWN();
			flag = true;
		}
		if (GameCanvas.isTouch && !flag)
		{
			this.list.update_Pos_UP_DOWN();
			MainScreen.cameraSub.yCam = this.list.cmx;
		}
		if (GameCanvas.isPointSelect(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack) && !flag)
		{
			for (int i = 0; i < TabSkillsNew.XYpaint.Length; i++)
			{
				if (GameCanvas.isPoint(TabSkillsNew.XYpaint[i][0] - this.sizeKill / 2 - 2, TabSkillsNew.XYpaint[i][1] - 2 - MainScreen.cameraSub.yCam, this.sizeKill + 4, this.sizeKill + 4))
				{
					if (i != this.idSelect)
					{
						this.listContent = null;
						this.idSelect = i;
						MainTabNew.timePaintInfo = 0;
					}
					else if (MainTabNew.longwidth == 0)
					{
						if (this.idSelect == -1)
						{
							return;
						}
						mVector mVector = new mVector("TabSkillsNew vecmenu2");
						mVector = this.doMenu();
						if (mVector != null && mVector.size() > 0)
						{
							GameCanvas.menu2.startAt(mVector, 2, T.kynang, false, null);
						}
					}
					GameCanvas.isPointerSelect = false;
					this.cmdListBig();
					break;
				}
			}
			if (MainTabNew.longwidth == 0)
			{
				MainTabNew.timePaintInfo = 0;
			}
			GameCanvas.isPointerSelect = false;
		}
		if (this.vecListCmd != null && (int)MainTabNew.Focus == (int)MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			for (int j = 0; j < this.vecListCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(j);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x0600082B RID: 2091 RVA: 0x0008DFC8 File Offset: 0x0008C1C8
	public mVector doMenu()
	{
		mVector mVector = new mVector("TabSkillsNew menu2");
		Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(this.idSelect);
		if (this.idSelect < 0 && this.idSelect >= TabSkillsNew.vecPaintSkill.size())
		{
			return mVector;
		}
		if (Player.diemKyNang > 0 && this.idSelect > 0 && Player.mCurentLvSkill[skill.Id] < 10 && GameScreen.player.Lv >= skill.lvMin)
		{
			mVector.addElement(this.cmdSetPoint);
		}
		if ((int)skill.typeSkill != 2 && Player.mCurentLvSkill[skill.Id] > 0)
		{
			if (mVector.size() == 0 && MainTabNew.longwidth == 0)
			{
				this.cmdSetKey.perform();
				return null;
			}
			mVector.addElement(this.cmdSetKey);
		}
		mVector.addElement(this.cmdupskill);
		this.hcmd = (mVector.size() + 1) / 2 * iCommand.hButtonCmd;
		return mVector;
	}

	// Token: 0x0600082C RID: 2092 RVA: 0x0008E0D8 File Offset: 0x0008C2D8
	public static void saveSkill()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			for (int i = 0; i < Player.mhotkey.Length; i++)
			{
				for (int j = 0; j < Player.mhotkey[0].Length; j++)
				{
					HotKey hotKey = Player.mhotkey[i][j];
					dataOutputStream.writeShort(hotKey.id);
					dataOutputStream.writeByte(hotKey.type);
					dataOutputStream.writeByte(hotKey.typePotion);
				}
			}
			CRes.saveRMSName(0, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600082D RID: 2093 RVA: 0x0008E188 File Offset: 0x0008C388
	public void cmdListBig()
	{
		if (MainTabNew.longwidth > 0 && GameCanvas.isTouch && this.idSelect >= 0)
		{
			this.vecListCmd = this.doMenu();
			base.setPosCmd(this.vecListCmd);
		}
	}

	// Token: 0x0600082E RID: 2094 RVA: 0x0008E1C4 File Offset: 0x0008C3C4
	public static void loadSkill(sbyte[] bData)
	{
		if (bData == null)
		{
			for (int i = 0; i < Player.mhotkey[0].Length; i++)
			{
				Player.mhotkey[0][i] = new HotKey();
				Player.mhotkey[1][i] = new HotKey();
				Player.mhotkey[2][i] = new HotKey();
				if (i == 2)
				{
					Player.mhotkey[0][i].setHotKey(0, (int)HotKey.SKILL, 0);
					Player.mhotkey[1][i].setHotKey(0, (int)HotKey.SKILL, 0);
					Player.mhotkey[2][i].setHotKey(0, (int)HotKey.SKILL, 0);
				}
				else
				{
					Player.mhotkey[0][i].setHotKey(0, (int)HotKey.NULL, 0);
					Player.mhotkey[1][i].setHotKey(0, (int)HotKey.NULL, 0);
					Player.mhotkey[2][i].setHotKey(0, (int)HotKey.NULL, 0);
				}
			}
			if (GameScreen.player.Lv > 1)
			{
				MainItem.setAddHotKey(1, false);
				MainItem.setAddHotKey(0, false);
			}
			return;
		}
		DataInputStream dataInputStream = new DataInputStream(bData);
		try
		{
			for (int j = 0; j < Player.mhotkey.Length; j++)
			{
				for (int k = 0; k < Player.mhotkey[0].Length; k++)
				{
					Player.mhotkey[j][k] = new HotKey();
					Player.mhotkey[j][k].setHotKey((int)dataInputStream.readShort(), (int)dataInputStream.readByte(), dataInputStream.readByte());
				}
			}
		}
		catch (Exception ex)
		{
			for (int l = 0; l < Player.mhotkey[0].Length; l++)
			{
				Player.mhotkey[0][l] = new HotKey();
				Player.mhotkey[1][l] = new HotKey();
				Player.mhotkey[2][l] = new HotKey();
				if (l == 2)
				{
					Player.mhotkey[0][l].setHotKey(0, (int)HotKey.SKILL, 0);
					Player.mhotkey[1][l].setHotKey(0, (int)HotKey.SKILL, 0);
					Player.mhotkey[2][l].setHotKey(0, (int)HotKey.SKILL, 0);
				}
				else
				{
					Player.mhotkey[0][l].setHotKey(0, (int)HotKey.NULL, 0);
					Player.mhotkey[1][l].setHotKey(0, (int)HotKey.NULL, 0);
					Player.mhotkey[2][l].setHotKey(0, (int)HotKey.NULL, 0);
				}
			}
			if (GameScreen.player.Lv > 1)
			{
				MainItem.setAddHotKey(1, false);
				MainItem.setAddHotKey(0, false);
			}
		}
	}

	// Token: 0x04000CE7 RID: 3303
	public static int[][] XYpaint;

	// Token: 0x04000CE8 RID: 3304
	private int sizeKill = 22;

	// Token: 0x04000CE9 RID: 3305
	private int idSelect;

	// Token: 0x04000CEA RID: 3306
	private int hcmd;

	// Token: 0x04000CEB RID: 3307
	private iCommand cmdSetPoint;

	// Token: 0x04000CEC RID: 3308
	private iCommand cmdSendSetPoint;

	// Token: 0x04000CED RID: 3309
	private iCommand cmdSendSetPointOne;

	// Token: 0x04000CEE RID: 3310
	private iCommand cmdSetKey;

	// Token: 0x04000CEF RID: 3311
	private iCommand cmdMenu;

	// Token: 0x04000CF0 RID: 3312
	private iCommand cmdupskill;

	// Token: 0x04000CF1 RID: 3313
	private InputDialog inputDialog;

	// Token: 0x04000CF2 RID: 3314
	private ListNew list;

	// Token: 0x04000CF3 RID: 3315
	private mVector vecListCmd;

	// Token: 0x04000CF4 RID: 3316
	public static mVector vecPaintSkill = new mVector("TabSkillsNew vecPaintSkill");

	// Token: 0x04000CF5 RID: 3317
	private bool isSaveSkill;

	// Token: 0x04000CF6 RID: 3318
	public mVector vecEffRe = new mVector();

	// Token: 0x04000CF7 RID: 3319
	private int[] stylePaint = new int[]
	{
		1,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x04000CF8 RID: 3320
	private int hKill = 4;

	// Token: 0x04000CF9 RID: 3321
	private int w8;
}
