using System;

// Token: 0x0200006A RID: 106
public class Other_Players : MainObject
{
	// Token: 0x060004FD RID: 1277 RVA: 0x00045B48 File Offset: 0x00043D48
	public Other_Players(int ID, sbyte type, string name, int x, int y) : base(ID, type, name, x, y)
	{
		this.vMax = 6;
		this.hOne = 40;
		this.wOne = 30;
		this.hp = 0;
		this.maxHp = 0;
		this.mp = 0;
		this.maxMp = 0;
		this.xsai = 1;
		this.ysai = 2;
		this.PlashNow = new SplashSkill();
		this.ListKillNow = new ListSkill();
		this.countCharStand = 0;
	}

	// Token: 0x060004FE RID: 1278 RVA: 0x00045BD4 File Offset: 0x00043DD4
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestList.size())
			{
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(subIndex);
				mainQuest.beginQuest();
			}
			break;
		case 1:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestFinish.size())
			{
				MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(subIndex);
				mainQuest2.beginQuest();
			}
			break;
		case 2:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Main.size())
			{
				MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(subIndex);
				mainQuest3.show_Info_Quest_Doing();
			}
			break;
		case 3:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Sub.size())
			{
				MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(subIndex);
				mainQuest4.show_Info_Quest_Doing();
			}
			break;
		case 4:
			GlobalService.gI().getlist_from_npc((sbyte)this.ID);
			break;
		case 5:
			this.NhiemVu();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060004FF RID: 1279 RVA: 0x00045D00 File Offset: 0x00043F00
	public override void paintName(mGraphics g, int id)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		sbyte typePk = GameScreen.player.typePk;
		bool flag = true;
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap) && (int)this.typePk == (int)typePk)
		{
			flag = false;
		}
		string name = this.name;
		mFont mFont = mFont.tahoma_7_white;
		mFont = MainTabNew.setTextColor(id);
		bool flag2 = true;
		int num = 0;
		if ((int)this.typeSpec == 1)
		{
			if ((int)this.typePk > 0)
			{
				flag2 = false;
			}
			num = 5;
		}
		if (this.idName != -1)
		{
			flag2 = false;
		}
		int num2 = 18;
		if (PaintInfoGameScreen.isLevelPoint)
		{
			num2 = 12;
		}
		if (this.typeMonster == 7)
		{
			num2 += 8;
		}
		if (this.isObject && PaintInfoGameScreen.isLevelPoint)
		{
			num2 += 6;
		}
		if (flag2 && !this.Namearena)
		{
			mFont.drawString(g, name, this.x, this.y - this.ysai - this.dy + this.dyWater - ((!this.isDongBang) ? 0 : 5) - this.hOne - num2 - this.dyMount - this.yjum, 2, mGraphics.isFalse);
		}
		if ((int)this.typeObject == 0 && (int)this.typeSpec == 1 && flag2 && !this.iscuop)
		{
			num2 += 10;
			mFont.drawString(g, T.nhanban, this.x, this.y - this.ysai - this.dy + this.dyWater - ((!this.isDongBang) ? 0 : 5) - this.hOne - num2 - this.dyMount - this.yjum, 2, mGraphics.isFalse);
		}
		if ((int)this.typeObject == 2 && this.chat == null)
		{
			AvMain.fraQuest.drawFrame(this.typeNPC, this.x - 6, this.y - this.ysai - this.dy + this.dyWater - this.hOne - num2 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
		}
		int num3 = 0;
		if ((Player.party != null && this.isParty) || this.isShowHP || this.typeMonster == 7)
		{
			int num4 = 44;
			if ((int)this.typeObject == 2 || this.typeMonster == 7)
			{
				num4 = this.hOne + 5;
			}
			g.setColor(8062494);
			g.fillRect(this.x - 20, this.y - this.ysai - this.dy + this.dyWater - num4 - num2 - this.dyMount - this.yjum, 40, 3, mGraphics.isFalse);
			g.setColor(16197705);
			g.fillRect(this.x - 20, this.y - this.ysai - this.dy + this.dyWater - num4 - num2 - this.dyMount - this.yjum, 40 * this.hp / this.maxHp, 3, mGraphics.isFalse);
			num3 += 5;
		}
		if (this.myClan != null && (int)this.typeSpec != 1 && !this.Namearena)
		{
			base.paintIconClan(g, this.x - 1, this.y - this.ysai - this.dy + this.dyWater - this.hOne - num2 - 8 - num3 - this.dyMount - this.yjum, 2);
			num3 += 16;
		}
		if ((int)this.typePk >= 0 && (int)this.typeObject == 0 && flag && !base.isPkVantieu())
		{
			num3 += 59;
			AvMain.fraPk.drawFrame((int)this.typePk * 3 + GameCanvas.gameTick / 3 % 3, this.x, this.y - this.dy + this.dyWater - this.ysai - num3 + 18 - num2 + num - this.dyMount - this.yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x06000500 RID: 1280 RVA: 0x00046154 File Offset: 0x00044354
	public override void paint(mGraphics g)
	{
		int num = 0;
		if ((int)this.typeObject == 0 && GameScreen.isHideOderPlayer)
		{
			base.painthidePlayer(g, num);
			this.paintNameStore(g, this.x, this.y);
			return;
		}
		if ((int)this.typeObject == 2)
		{
			if (this.imageId == -1)
			{
				base.paintPlayer(g, num);
			}
			else
			{
				base.paintObject(g, num);
			}
		}
		else
		{
			base.paintPlayer(g, num);
		}
		base.paintEffectCharWearing(g);
		this.paintNameStore(g, this.x, this.y);
	}

	// Token: 0x06000501 RID: 1281 RVA: 0x000461EC File Offset: 0x000443EC
	public override void paintNameStore(mGraphics g, int x, int y)
	{
		if (this.nameStore != null && !this.nameStore.name.Equals(string.Empty))
		{
			this.nameStore.paint(g);
		}
	}

	// Token: 0x06000502 RID: 1282 RVA: 0x00046220 File Offset: 0x00044420
	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		base.paintAvatarFocus(g, x, y);
	}

	// Token: 0x06000503 RID: 1283 RVA: 0x0004623C File Offset: 0x0004443C
	public override void update()
	{
		base.updateEffectCharWearing();
		base.updateActionPerson();
		base.updateDataEffect();
		if (this.nameStore != null)
		{
			this.nameStore.updatePos(this.x, this.y - this.hOne - 30);
		}
		if (this.KillFire != -1)
		{
			if (CRes.abs(this.x - this.xFire) <= this.vMax + base.getVmount() && CRes.abs(this.y - this.yFire) <= this.vMax + base.getVmount())
			{
				this.timeHuyKill++;
				this.posTransRoad = null;
				this.ListKillNow.setFireSkill(this, this.vecObjFocusSkill, this.KillFire, -1);
				if (this.timeHuyKill > 5)
				{
					this.ListKillNow.fireSkillFree();
					this.timeHuyKill = 0;
					this.KillFire = -1;
				}
			}
		}
		else
		{
			this.timeHuyKill = 0;
		}
		if (!MainObject.isInScreen(this) && !base.setIsInScreen(this.toX, this.toY, this.wOne, this.hOne))
		{
			this.x = this.toX;
			this.y = this.toY;
			this.vx = 0;
			this.vy = 0;
			if (this.Action != 4)
			{
				this.Action = 0;
			}
			return;
		}
		this.Move_to_Focus_Person();
		int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
		base.setMove(1, tile);
		this.updateoverHP_MP();
		base.updateEye();
		base.update();
		if (this.isMonPhoBangDie && this.timeFreeMove < 70)
		{
			this.timeFreeMove++;
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(25);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, this.x + num2, this.y + num3 - this.hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, this.x + num2, this.y + num3 - this.hOne / 2);
					}
				}
			}
			if (this.timeFreeMove >= 70)
			{
				for (int j = 0; j < 6; j++)
				{
					int num4 = CRes.random_Am_0(25);
					int num5 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, this.x + num4, this.y + num5 - this.hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, this.x + num4, this.y + num5 - this.hOne / 2);
					}
				}
				GameScreen.addEffectKill(81, this.x, this.y - 20, 200, 0, 0);
				this.isRemove = true;
				this.isMonPhoBangDie = false;
			}
		}
	}

	// Token: 0x06000504 RID: 1284 RVA: 0x00046558 File Offset: 0x00044758
	public void move_to_XY(int tX, int tY)
	{
		if (CRes.abs(this.x - tX) > 2)
		{
			this.vy = 0;
			this.Action = 1;
			if (CRes.abs(this.x - tX) > this.vMax + base.getVmount())
			{
				if (this.x > tX)
				{
					this.vx = -(this.vMax + base.getVmount());
					this.Direction = 2;
				}
				else
				{
					this.vx = this.vMax + base.getVmount();
					this.Direction = 3;
				}
			}
			else
			{
				this.vx = tX - this.x;
			}
		}
		else if (CRes.abs(this.y - tY) > 2)
		{
			this.vx = 0;
			this.Action = 1;
			if (CRes.abs(this.y - tY) > this.vMax + base.getVmount())
			{
				if (this.y > tY)
				{
					this.vy = -(this.vMax + base.getVmount());
					this.Direction = 1;
				}
				else
				{
					this.vy = this.vMax + base.getVmount();
					this.Direction = 0;
				}
			}
			else
			{
				this.vy = tY - this.y;
			}
		}
		else
		{
			this.vx = 0;
			this.vy = 0;
		}
	}

	// Token: 0x06000505 RID: 1285 RVA: 0x000466B0 File Offset: 0x000448B0
	public override int getIDnpc()
	{
		return (int)this.isBot;
	}

	// Token: 0x06000506 RID: 1286 RVA: 0x000466BC File Offset: 0x000448BC
	public override void GiaoTiep()
	{
		if (this.isNPC())
		{
			MainObject.resetDirection(GameScreen.player, this);
			if ((int)this.isPerson == 0)
			{
				GlobalService.gI().getlist_from_npc((sbyte)this.getIDnpc());
				return;
			}
			mVector mVector = new mVector("Other_Player menu");
			if (this.nameGiaotiep.Length > 0)
			{
				iCommand o = new iCommand(this.nameGiaotiep, 4, this);
				mVector.addElement(o);
			}
			if (this.checkNV())
			{
				iCommand o2 = new iCommand(T.quest, 5, this);
				mVector.addElement(o2);
			}
			GameCanvas.menu2.startAt(mVector, 2, T.giaotiep, false, null);
		}
		else if ((int)this.typeObject == 0 && (int)this.typeSpec == 0)
		{
			mVector mVector2 = new mVector("Other_Player menu2");
			mVector2.addElement(GameScreen.gI().cmdChat);
			mVector2.addElement(GameScreen.gI().cmdAddfriend);
			mVector2.addElement(GameScreen.gI().cmdInfoChar);
			if (Player.party == null || Player.party.vecPartys.size() < 5)
			{
				mVector2.addElement(GameScreen.gI().cmdMoiParty);
			}
			mVector2.addElement(GameScreen.gI().cmdBuy_Sell);
			if ((int)LoadMap.typeMap != LoadMap.MAP_THACH_DAU && (int)LoadMap.typeMap != LoadMap.MAP_PHO_BANG)
			{
				mVector2.addElement(GameScreen.gI().cmdThachDau);
			}
			if (GameScreen.player.myClan != null && GameScreen.player.myClan.setAddMem())
			{
				mVector2.addElement(GameScreen.gI().cmdAddMemClan);
			}
			mVector mVector3 = base.vectorObjectNear();
			mVector3.insertElementAt(this, 0);
			GameCanvas.menu2.startAt(mVector2, 2, T.giaotiep, true, mVector3);
		}
	}

	// Token: 0x06000507 RID: 1287 RVA: 0x00046880 File Offset: 0x00044A80
	public bool checkNV()
	{
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == this.ID)
			{
				return true;
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == this.ID)
			{
				return true;
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == this.ID)
			{
				return true;
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == this.ID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000508 RID: 1288 RVA: 0x00046998 File Offset: 0x00044B98
	public void NhiemVu()
	{
		mVector mVector = new mVector("Other_Player menu");
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == this.ID)
			{
				iCommand iCommand = new iCommand(mainQuest.name, 0, i, this);
				iCommand.setFraCaption(AvMain.fraQuest, 1, 1);
				mVector.addElement(iCommand);
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == this.ID)
			{
				iCommand iCommand2 = new iCommand(mainQuest2.name, 1, j, this);
				iCommand2.setFraCaption(AvMain.fraQuest, 1, 3);
				mVector.addElement(iCommand2);
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == this.ID)
			{
				iCommand iCommand3 = new iCommand(mainQuest3.name, 2, k, this);
				iCommand3.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector.addElement(iCommand3);
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == this.ID)
			{
				iCommand iCommand4 = new iCommand(mainQuest4.name, 3, l, this);
				iCommand4.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector.addElement(iCommand4);
			}
		}
		if (mVector.size() == 0)
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.doCloseMenu();
		}
		else
		{
			GameCanvas.menu2.doCloseMenu();
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.startAt(mVector, 2, T.quest, false, null);
		}
	}

	// Token: 0x06000509 RID: 1289 RVA: 0x00046BA0 File Offset: 0x00044DA0
	public override void addEffectCharWearing(int typeeffect, int idimage)
	{
		EffectCharWearing o = new EffectCharWearing((sbyte)typeeffect, idimage);
		this.vecEffectCharWearing.addElement(o);
	}

	// Token: 0x0600050A RID: 1290 RVA: 0x00046BC4 File Offset: 0x00044DC4
	public override void removeNameStore()
	{
		this.nameStore = null;
	}

	// Token: 0x0600050B RID: 1291 RVA: 0x00046BD0 File Offset: 0x00044DD0
	public override void setNameStore(string name)
	{
		if (this.nameStore == null)
		{
			this.nameStore = new PopupChat();
		}
		this.nameStore.setChat(name, this.isStop);
		this.nameStore.updatePos(this.x, this.y - this.hOne - 30);
	}

	// Token: 0x0600050C RID: 1292 RVA: 0x00046C28 File Offset: 0x00044E28
	public override bool isSelling()
	{
		return this.nameStore != null;
	}

	// Token: 0x0600050D RID: 1293 RVA: 0x00046C38 File Offset: 0x00044E38
	public override bool canFocus()
	{
		return (int)this.typefocus == 1;
	}

	// Token: 0x0600050E RID: 1294 RVA: 0x00046C44 File Offset: 0x00044E44
	public override bool canfire()
	{
		return (int)this.typefire == 1;
	}

	// Token: 0x0400070B RID: 1803
	private PopupChat nameStore;

	// Token: 0x0400070C RID: 1804
	private sbyte[] vmove = new sbyte[]
	{
		-1,
		1
	};
}
