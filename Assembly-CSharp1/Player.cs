using System;

// Token: 0x02000072 RID: 114
public class Player : MainObject
{
	// Token: 0x0600054A RID: 1354 RVA: 0x0004ADEC File Offset: 0x00048FEC
	public Player()
	{
	}

	// Token: 0x0600054B RID: 1355 RVA: 0x0004AE24 File Offset: 0x00049024
	public Player(int ID, sbyte type, string name, int x, int y) : base(ID, type, name, x, y)
	{
		this.ischar = true;
		Player.party = null;
		this.typeObject = 0;
		this.hOne = 40;
		this.wOne = 30;
		this.vMax = 6;
		this.name = name;
		this.wFocus = 140;
		Player.cmdNextFocus = new iCommand(T.next, 0, this);
		Player.cmdRevice = new iCommand(T.hoisinh, 1, this);
		Player.cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
		Player.cmdVeLang = new iCommand(T.velang, 2, this);
		Player.cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
		this.PlashNow = new SplashSkill();
		this.ListKillNow = new ListSkill();
		Player.isNewPlayer = false;
		this.xsai = 1;
		this.ysai = 2;
		for (int i = 0; i < Player.timeDelaySkill.Length; i++)
		{
			Player.timeDelaySkill[i] = new DelaySkill();
			Player.timeDelaySkill[i].value = 0;
			Player.timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
		}
		for (int j = 0; j < Player.timeDelayPotion.Length; j++)
		{
			Player.timeDelayPotion[j] = new DelaySkill();
			Player.timeDelayPotion[j].value = 0;
			Player.timeDelayPotion[j].timebegin = mSystem.currentTimeMillis();
		}
		this.timeSendmove = mSystem.currentTimeMillis();
		this.timeCombo = -1;
	}

	// Token: 0x0600054D RID: 1357 RVA: 0x0004B138 File Offset: 0x00049338
	public override bool isMainChar()
	{
		return true;
	}

	// Token: 0x0600054E RID: 1358 RVA: 0x0004B13C File Offset: 0x0004933C
	public void doResetLastXY()
	{
		this.lastX = 1000000;
		this.lastY = 1000000;
	}

	// Token: 0x0600054F RID: 1359 RVA: 0x0004B154 File Offset: 0x00049354
	public static void init0()
	{
		for (int i = 0; i < Player.mhotkey.Length; i++)
		{
			Player.mhotkey[i] = new HotKey[5];
		}
	}

	// Token: 0x06000550 RID: 1360 RVA: 0x0004B188 File Offset: 0x00049388
	public void init()
	{
		TabShopNew o = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, TabShopNew.NORMAL);
		mVector mVector = new mVector("Player (init) v");
		mVector.addElement(o);
		TabMySeftNew o2 = new TabMySeftNew(T.tabtrangbi);
		mVector.addElement(o2);
		TabInfoChar o3 = new TabInfoChar(T.tabthongtin);
		mVector.addElement(o3);
		this.tabskills = new TabSkillsNew(T.tabkynang);
		mVector.addElement(this.tabskills);
		TabQuest o4 = new TabQuest(T.tabnhiemvu);
		mVector.addElement(o4);
		mVector vec = new mVector("Player mcmdTest");
		if (GameCanvas.isTouch)
		{
			TabConfig o5 = new TabConfig(T.tabchucnang, vec, MainTabNew.FUNCTION);
			mVector.addElement(o5);
		}
		else
		{
			TabConfig o6 = new TabConfig(T.tabhethong, vec, MainTabNew.CONFIG);
			mVector.addElement(o6);
			TabConfig o7 = new TabConfig(T.tabchucnang, vec, MainTabNew.FUNCTION);
			mVector.addElement(o7);
		}
		GameCanvas.AllInfo.addMoreTab(mVector);
	}

	// Token: 0x06000551 RID: 1361 RVA: 0x0004B290 File Offset: 0x00049490
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			this.nextFocus();
			break;
		case 1:
			GlobalService.gI().gohome(1);
			GameCanvas.start_Ok_Dialog(T.pleaseWait);
			break;
		case 2:
			GameCanvas.start_Left_Dialog(T.muonvelang, new iCommand(Player.cmdVeLang.caption, 3, this));
			break;
		case 3:
			GlobalService.gI().gohome(0);
			GameCanvas.end_Dialog();
			break;
		case 4:
			GlobalService.gI().do_Buy_Sell_Item(4, null, string.Empty, 0, 0, 0);
			break;
		case 5:
			GameCanvas.end_Dialog();
			break;
		}
	}

	// Token: 0x06000552 RID: 1362 RVA: 0x0004B340 File Offset: 0x00049540
	public override void setPainthit(sbyte time, bool isMax)
	{
		this.timeHit = time;
		this.isMaxdame = isMax;
	}

	// Token: 0x06000553 RID: 1363 RVA: 0x0004B350 File Offset: 0x00049550
	public override void paint(mGraphics g)
	{
		base.paintPlayer(g, 100);
		base.paintEffectCharWearing(g);
		this.paintNameStore(g, this.x, this.y);
	}

	// Token: 0x06000554 RID: 1364 RVA: 0x0004B380 File Offset: 0x00049580
	public override void paintNameStore(mGraphics g, int x, int y)
	{
		if (this.nameStore != null && !this.nameStore.name.Equals(string.Empty))
		{
			this.nameStore.paint(g);
		}
	}

	// Token: 0x06000555 RID: 1365 RVA: 0x0004B3B4 File Offset: 0x000495B4
	public override void paintBigAvatar(mGraphics g, int x, int y)
	{
	}

	// Token: 0x06000556 RID: 1366 RVA: 0x0004B3B8 File Offset: 0x000495B8
	public override void update()
	{
		try
		{
			if (this.moveToBoss && this.vx == 0 && this.vy == 0)
			{
				this.moveToBoss = false;
			}
			if (this.moveToBoss)
			{
				if (this.vx != 0)
				{
					this.vx = 0;
				}
				if (this.vy != 0)
				{
					this.vy = 0;
				}
				this.frameLeg = CRes.random(0, 4);
			}
			base.updateActionPerson();
			if (this.currentQuest == null)
			{
				this.setFocus();
			}
			base.setMove(true);
			this.updatePlayer();
			base.updateEye();
			base.updateDataEffect();
			if (Player.party != null && Player.party.update())
			{
				Player.party = null;
			}
			this.updateDelaySkill();
			if (Player.timeResetAuto > 0)
			{
				Player.timeResetAuto--;
			}
			if ((this.vx != 0 || this.vy != 0) && !this.isTanHinh && GameCanvas.gameTick % 3 == 0)
			{
				if (!this.isWater && !this.isFootSnow)
				{
					if (this.Direction == 2)
					{
						GameScreen.addEffInMap(this.x + CRes.random_Am(0, 3), this.y + CRes.random_Am(0, 3) + mSystem.dyCharStep, 0, this.Direction);
					}
					else if (this.Direction == 3)
					{
						GameScreen.addEffInMap(this.x + CRes.random_Am(0, 3), this.y + CRes.random_Am(0, 3) - mSystem.dyCharStep, 0, this.Direction);
					}
					else
					{
						GameScreen.addEffInMap(this.x + CRes.random_Am(0, 3), this.y + CRes.random_Am(0, 3), 0, this.Direction);
					}
				}
				else
				{
					GameScreen.addEffInMap(this.x, this.y, 1, this.Direction);
				}
			}
			this.updateoverHP_MP();
			base.updateEffectCharWearing();
			if (this.nameStore != null)
			{
				this.nameStore.updatePos(this.x, this.y - this.hOne - 30);
			}
			base.update();
			if ((int)this.timeHit > 0)
			{
				this.ispaintHit = true;
				this.timeHit -= 1;
			}
			else
			{
				this.ispaintHit = false;
			}
		}
		catch (Exception ex)
		{
			mSystem.println("----loi update player:" + ex.ToString());
		}
	}

	// Token: 0x06000557 RID: 1367 RVA: 0x0004B644 File Offset: 0x00049844
	private void updatePlayer()
	{
		if (this.KillFire != -1)
		{
			if (CRes.abs(this.x - this.xFire) <= 4 && CRes.abs(this.y - this.yFire) <= 4)
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
			if (this.posTransRoad == null && (CRes.abs(this.x - this.xFire) > 4 || CRes.abs(this.y - this.yFire) > 4))
			{
				this.Move_to_Focus_Person();
			}
		}
		else
		{
			this.timeHuyKill = 0;
		}
		if (this.hp <= 0 && this.Action != 4)
		{
			base.resetAction();
			this.Action = 4;
			if ((int)LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
			{
				GameScreen.gI().center = Player.cmdVeLang;
				Player.cmdVeLang.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
			}
			else if ((int)LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
			{
				GameScreen.gI().center = Player.cmdRevice;
				Player.cmdRevice.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
			}
			else if (!GameScreen.infoGame.isMapThachdau())
			{
				GameScreen.gI().left = Player.cmdRevice;
				GameScreen.gI().right = Player.cmdVeLang;
				Player.cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
				Player.cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
			}
			GameScreen.addEffectEndKill(11, this.x, this.y);
		}
		if (this.currentQuest == null)
		{
			if (this.Action == 4 && !GameScreen.infoGame.isMapThachdau())
			{
				if ((int)LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
				{
					if (GameScreen.gI().center != Player.cmdVeLang)
					{
						GameScreen.gI().center = Player.cmdVeLang;
						Player.cmdVeLang.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
					}
				}
				else if ((int)LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
				{
					if (GameScreen.gI().center != Player.cmdRevice)
					{
						GameScreen.gI().center = Player.cmdRevice;
						Player.cmdRevice.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
					}
				}
				else
				{
					if (GameScreen.gI().left != Player.cmdRevice)
					{
						GameScreen.gI().left = Player.cmdRevice;
						Player.cmdRevice.setPos(iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdRevice.caption);
					}
					if (GameScreen.gI().right != Player.cmdVeLang)
					{
						GameScreen.gI().right = Player.cmdVeLang;
						Player.cmdVeLang.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, Player.cmdVeLang.caption);
					}
				}
			}
			else if (GameCanvas.isTouch)
			{
				if ((int)LoadMap.typeMap == LoadMap.MAP_THACH_DAU)
				{
					if (GameScreen.gI().center == Player.cmdVeLang)
					{
						GameScreen.gI().center = null;
					}
				}
				else if ((int)LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
				{
					if (GameScreen.gI().center == Player.cmdRevice)
					{
						GameScreen.gI().center = null;
					}
				}
				else
				{
					if (GameScreen.gI().left == Player.cmdRevice)
					{
						GameScreen.gI().left = null;
					}
					if (GameScreen.gI().right == Player.cmdVeLang)
					{
						GameScreen.gI().right = null;
					}
				}
			}
			else
			{
				if (this.center == Player.cmdRevice)
				{
					this.center = null;
				}
				if (GameScreen.gI().right == null || GameScreen.gI().right != Player.cmdNextFocus)
				{
					GameScreen.gI().right = Player.cmdNextFocus;
				}
				if (GameScreen.gI().left != GameScreen.gI().cmdMenu)
				{
					GameScreen.gI().left = GameScreen.gI().cmdMenu;
				}
			}
		}
		if (this.posTransRoad != null && !this.moveToBoss)
		{
			if (this.isBinded)
			{
				return;
			}
			if (CRes.abs(this.x - this.toX) <= 6 && CRes.abs(this.y - this.toY) <= 6)
			{
				if (this.countAutoMove > this.posTransRoad.Length - 1)
				{
					this.countAutoMove = 0;
					this.posTransRoad = null;
					Player.timeStand = 0;
					this.xStopMove = 0;
					this.yStopMove = 0;
				}
				else
				{
					if (this.countAutoMove == this.posTransRoad.Length - 1 && this.xStopMove > 0 && this.yStopMove > 0)
					{
						this.toX = this.xStopMove;
						this.toY = this.yStopMove;
					}
					else
					{
						sbyte b = (sbyte)(this.posTransRoad[this.countAutoMove] >> 8);
						sbyte b2 = (sbyte)(this.posTransRoad[this.countAutoMove] & 255);
						this.toX = (int)b * LoadMap.wTile + LoadMap.wTile / 2;
						this.toY = (int)b2 * LoadMap.wTile + LoadMap.wTile / 2;
					}
					this.countAutoMove++;
				}
			}
			this.move_to_XY();
		}
		else
		{
			if (!Player.isSendMove)
			{
				Player.isSendMove = true;
				this.xStand = this.x;
				this.yStand = this.y;
			}
			if (Player.isLockKey && !GameScreen.help.setStep_Next(0, -4) && !GameScreen.help.setStep_Next(0, -2))
			{
				Player.isLockKey = false;
			}
		}
		int distance = MainObject.getDistance(this.xStand, this.yStand, this.x, this.y);
		bool flag = false;
		if (mSystem.currentTimeMillis() - this.timeSendmove > 250L && Player.timeStand <= 0)
		{
			flag = true;
		}
		if (this.posTransRoad != null && mSystem.currentTimeMillis() - this.timeSendmove > 250L)
		{
			flag = true;
		}
		if (flag || (Player.timeStand > 20 && distance >= 5 && this.posTransRoad == null))
		{
			if (Player.isSendMove && !this.isMoveOut)
			{
				GlobalService.gI().player_move((short)this.x, (short)this.y);
				this.timeSendmove = mSystem.currentTimeMillis();
			}
			this.xStand = this.x;
			this.yStand = this.y;
			this.countSendMove = 0;
		}
		if (Player.autoItem != null && GameCanvas.gameTick % 5 == 0)
		{
			this.autoGetItem();
		}
		if ((int)Player.isAutoFire == 1 && this.posTransRoad == null)
		{
			if (Player.PointSucKhoe <= 0)
			{
				Player.isAutoFire = 0;
			}
			if ((int)Player.isAutoFire == 1)
			{
				if (this.Action == 0)
				{
					this.coutauto++;
				}
				else
				{
					this.coutauto = 0;
				}
				if (this.coutauto > 500)
				{
					GameCanvas.addInfoChar(T.farfocus);
					this.KillFire = -1;
					this.IDAttack = -1;
					this.vecObjFocusSkill = null;
					this.coutauto = 0;
					this.dofire();
				}
			}
			if (this.Action != 2 && this.Action != 4 && (MainObject.getDistance(this.x, this.y, Player.xBeginAutoFire, Player.yBeginAutofire) > this.wFocus * 3 / 2 || Player.demUnFire > 100))
			{
				this.toX = this.x;
				this.toY = this.y;
				this.xStopMove = Player.xBeginAutoFire;
				this.yStopMove = Player.yBeginAutofire;
				this.posTransRoad = GameCanvas.game.updateFindRoad(this.xStopMove / LoadMap.wTile, this.yStopMove / LoadMap.wTile, this.x / LoadMap.wTile, this.y / LoadMap.wTile, 20);
				Player.xFocus = -1;
				Player.yFocus = -1;
				if (this.posTransRoad != null && this.posTransRoad.Length > 20)
				{
					this.posTransRoad = null;
				}
			}
			if (this.posTransRoad == null && this.Action != 2 && this.Action != 4)
			{
				this.setAutoFire();
			}
			if (this.Action == 4)
			{
				Player.setCurAutoFire();
			}
		}
		if (Player.isAutoHPMP && this.Action != 4 && GameCanvas.gameTick % 5 == 0)
		{
			if (this.hp * 100 / this.maxHp < MsgDialog.mHPMP[0])
			{
				HotKey hotKey = Player.mhotkey[Player.levelTab][4];
				if (hotKey != null && (int)hotKey.type == (int)HotKey.POTION && (int)hotKey.typePotion == 0)
				{
					Item itemInventory = Item.getItemInventory(4, hotKey.id);
					if (itemInventory != null && (int)itemInventory.typePotion < 2 && Player.timeDelayPotion[(int)itemInventory.typePotion].value <= 0)
					{
						GlobalService.gI().Use_Potion((short)itemInventory.Id);
						Player.timeDelayPotion[(int)itemInventory.typePotion].value = 2000;
						Player.timeDelayPotion[(int)itemInventory.typePotion].limit = 2000;
						Player.timeDelayPotion[(int)itemInventory.typePotion].timebegin = mSystem.currentTimeMillis();
					}
				}
			}
			if (this.mp * 100 / this.maxMp < MsgDialog.mHPMP[1])
			{
				HotKey hotKey2 = Player.mhotkey[Player.levelTab][3];
				if ((int)hotKey2.type == (int)HotKey.POTION && (int)hotKey2.typePotion == 1)
				{
					Item itemInventory2 = Item.getItemInventory(4, hotKey2.id);
					if (itemInventory2 != null && Player.timeDelayPotion[(int)itemInventory2.typePotion].value <= 0)
					{
						GlobalService.gI().Use_Potion((short)itemInventory2.Id);
						Player.timeDelayPotion[(int)itemInventory2.typePotion].value = 2000;
						Player.timeDelayPotion[(int)itemInventory2.typePotion].limit = 2000;
						Player.timeDelayPotion[(int)itemInventory2.typePotion].timebegin = mSystem.currentTimeMillis();
					}
				}
			}
		}
		if (GameScreen.ObjFocus != null)
		{
			Player.typeFocusLast = GameScreen.ObjFocus.typeObject;
			Player.timeFocusLast = 0;
		}
		else if ((int)Player.timeFocusLast < 20)
		{
			Player.timeFocusLast += 1;
		}
		if ((this.vx != 0 || this.vy != 0) && Player.timeFocusNPC < 5)
		{
			Player.timeFocusNPC = 10;
		}
		if (!Player.isFocusNPC && Player.timeFocusNPC > 5)
		{
			Player.timeFocusNPC++;
			if (Player.timeFocusNPC > 60)
			{
				Player.isFocusNPC = true;
				Player.timeFocusNPC = 0;
			}
		}
		if ((int)Player.isAutoFire == 1 && GameScreen.ObjFocus != null && MainObject.getDistance(Player.xBeginAutoFire, Player.yBeginAutofire, GameScreen.ObjFocus.x, GameScreen.ObjFocus.y) > 240)
		{
			this.nextMonster();
		}
	}

	// Token: 0x06000558 RID: 1368 RVA: 0x0004C264 File Offset: 0x0004A464
	private void autoGetItem()
	{
		if (GameCanvas.gameTick % 200 == 0)
		{
			int num = Item.VecInvetoryPlayer.size();
			if (Player.isFullInven)
			{
				if (num < (int)Player.maxInven)
				{
					Player.isFullInven = false;
				}
				else
				{
					GameCanvas.addInfoChar(T.fullInven);
					if ((int)GameScreen.ObjFocus.typeObject == 4 || (int)GameScreen.ObjFocus.typeObject == 3 || (int)GameScreen.ObjFocus.typeObject == 5 || (int)GameScreen.ObjFocus.typeObject == 7 || (int)GameScreen.ObjFocus.typeObject == 3)
					{
						this.nextFocus();
					}
				}
			}
			else if (num >= (int)Player.maxInven)
			{
				Player.isFullInven = true;
			}
		}
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && !mainObject.isSend)
			{
				if ((int)mainObject.typeObject == 4 || (int)mainObject.typeObject == 3 || (int)mainObject.typeObject == 5 || (int)mainObject.typeObject == 7)
				{
					if (this.setGetItem(mainObject) && MainObject.getDistance(this.x, this.y, mainObject.x, mainObject.y) < this.wFocus)
					{
						GlobalService.gI().Get_Item_Map((short)mainObject.ID, mainObject.typeObject);
					}
					mainObject.isSend = true;
				}
			}
		}
	}

	// Token: 0x06000559 RID: 1369 RVA: 0x0004C3F0 File Offset: 0x0004A5F0
	public bool isItem(MainObject obj)
	{
		return (int)obj.typeObject == 4 || (int)obj.typeObject == 3 || (int)obj.typeObject == 5 || (int)obj.typeObject == 7;
	}

	// Token: 0x0600055A RID: 1370 RVA: 0x0004C434 File Offset: 0x0004A634
	private bool setGetItem(MainObject obj)
	{
		switch (obj.typeObject)
		{
		case 3:
			if (Player.isFullInven)
			{
				return false;
			}
			if ((int)Player.autoItem.valueColorItem == -1)
			{
				return false;
			}
			if ((int)obj.colorName >= (int)Player.autoItem.valueColorItem)
			{
				return true;
			}
			break;
		case 4:
			if ((int)obj.colorName == 0)
			{
				if ((int)Player.autoItem.isGetPotion == (int)AutoGetItem.POI_NHAT_MAU || (int)Player.autoItem.isGetPotion == (int)AutoGetItem.POI_NHAT_HET)
				{
					return true;
				}
			}
			else
			{
				if ((int)obj.colorName != 1)
				{
					return (int)obj.colorName == 2 || (int)obj.colorName != 6 || true;
				}
				if ((int)Player.autoItem.isGetPotion == (int)AutoGetItem.POI_NHAT_NANG_LUONG || (int)Player.autoItem.isGetPotion == (int)AutoGetItem.POI_NHAT_HET)
				{
					return true;
				}
			}
			break;
		case 5:
		case 7:
			return true;
		}
		return false;
	}

	// Token: 0x0600055B RID: 1371 RVA: 0x0004C550 File Offset: 0x0004A750
	public void setAutoFire()
	{
		if (!ListSkill.canAttack())
		{
			return;
		}
		long num = mSystem.currentTimeMillis();
		MainObject objFocus = GameScreen.ObjFocus;
		if (objFocus == null || objFocus.Action == 4 || (int)objFocus.typeObject != 1 || objFocus.isSend || objFocus.isDie)
		{
			if (objFocus != null && objFocus.isDie)
			{
				GameScreen.ObjFocus = null;
			}
			this.nextMonster();
		}
		if (GameScreen.ObjFocus == null || (int)GameScreen.ObjFocus.typeObject != 1 || (int)GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		if ((int)Player.isAutoBuff == 1 && (num - this.timeAutoBuff) / (long)ListSkill.limitTimeAtt > 2L)
		{
			this.timeAutoBuff = num;
			for (int i = 0; i < (int)MsgDialog.MaxSkillBuff; i++)
			{
				if (MsgDialog.Autobuff[i][1] != 0)
				{
					if (this.setDelaySkill(MsgDialog.Autobuff[i][0], -1))
					{
						Skill skillFormId = MainListSkill.getSkillFormId(MsgDialog.Autobuff[i][0]);
						if ((int)skillFormId.typeSkill == 1)
						{
							this.setAutoBuff((int)skillFormId.typeBuff, MsgDialog.Autobuff[i][0], GameScreen.ObjFocus);
						}
					}
				}
			}
		}
		if ((int)Player.IndexFire < Player.mhotkey[0].Length - 1)
		{
			for (int j = (int)Player.IndexFire + 1; j < Player.mhotkey[0].Length; j++)
			{
				HotKey hotKey = Player.mhotkey[Player.levelTab][j];
				if ((int)hotKey.type == (int)HotKey.SKILL && this.setDelaySkill((int)hotKey.id, -1))
				{
					this.setActionHotKey(j, false);
					Player.timeFristSkill = num;
					Player.IndexFire = (sbyte)j;
					return;
				}
			}
		}
		if ((int)Player.IndexFire > 0)
		{
			for (int k = 0; k <= (int)Player.IndexFire; k++)
			{
				HotKey hotKey2 = Player.mhotkey[Player.levelTab][k];
				if ((int)hotKey2.type == (int)HotKey.SKILL && this.setDelaySkill((int)hotKey2.id, -1))
				{
					this.setActionHotKey(k, false);
					Player.timeFristSkill = num;
					Player.IndexFire = (sbyte)k;
					return;
				}
			}
		}
		if (this.setDelaySkill(0, -1))
		{
			this.setActionHotKey(-1, false);
			Player.timeFristSkill = num;
		}
	}

	// Token: 0x0600055C RID: 1372 RVA: 0x0004C7B4 File Offset: 0x0004A9B4
	public void nextMonster()
	{
		if (!Player.isCurAutoFire)
		{
			Player.isAutoFire = -1;
			return;
		}
		int num = this.wFocus * 3 / 2;
		MainObject mainObject = null;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject2 != null && mainObject2.Action != 4 && !mainObject2.isSend)
			{
				if ((int)mainObject2.typeObject == 1 && !mainObject2.isLuaThieng())
				{
					int distance = MainObject.getDistance(this.x, this.y, mainObject2.x, mainObject2.y);
					if (distance < num || (int)mainObject2.typeBoss == 2)
					{
						num = distance;
						mainObject = mainObject2;
						if ((int)mainObject2.typeBoss == 2)
						{
							break;
						}
					}
				}
			}
		}
		if (mainObject != null)
		{
			PaintInfoGameScreen.isPaintInfoFocus = true;
			GameScreen.ObjFocus = mainObject;
			Player.demUnFire = 0;
		}
		else
		{
			PaintInfoGameScreen.isPaintInfoFocus = false;
			Player.demUnFire += 1;
		}
	}

	// Token: 0x0600055D RID: 1373 RVA: 0x0004C8C0 File Offset: 0x0004AAC0
	public void movePC()
	{
		if (GameCanvas.keyMove(39))
		{
			if (!this.isSelling())
			{
				this.Action = 1;
				this.Direction = 2;
				this.vx = -(this.vMax + base.getVmount());
				this.vy = 0;
				this.resetMove();
				this.setValueAuto(0);
			}
			else
			{
				mVector mVector = new mVector();
				mVector.addElement(new iCommand(T.yes, 4, this));
				mVector.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector);
			}
		}
		else if (GameCanvas.keyMove(40))
		{
			if (!this.isSelling())
			{
				this.Action = 1;
				this.Direction = 3;
				this.vx = this.vMax + base.getVmount();
				this.vy = 0;
				this.resetMove();
				this.setValueAuto(0);
			}
			else
			{
				mVector mVector2 = new mVector();
				mVector2.addElement(new iCommand(T.yes, 4, this));
				mVector2.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector2);
			}
		}
		else if (GameCanvas.keyMove(30))
		{
			if (!this.isSelling())
			{
				this.Action = 1;
				this.Direction = 1;
				this.vy = -(this.vMax + base.getVmount());
				this.vx = 0;
				this.resetMove();
				this.setValueAuto(0);
			}
			else
			{
				mVector mVector3 = new mVector();
				mVector3.addElement(new iCommand(T.yes, 4, this));
				mVector3.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector3);
			}
		}
		else if (GameCanvas.keyMove(38))
		{
			if (!this.isSelling())
			{
				this.Action = 1;
				this.Direction = 0;
				this.vy = this.vMax + base.getVmount();
				this.vx = 0;
				this.resetMove();
				this.setValueAuto(0);
			}
			else
			{
				mVector mVector4 = new mVector();
				mVector4.addElement(new iCommand(T.yes, 4, this));
				mVector4.addElement(new iCommand(T.cancel, 5, this));
				GameCanvas.start_Select_Dialog(T.can_not_move, mVector4);
			}
		}
	}

	// Token: 0x0600055E RID: 1374 RVA: 0x0004CAF8 File Offset: 0x0004ACF8
	public void updateKey()
	{
		if (!base.Canmove())
		{
			return;
		}
		if ((int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END)
		{
			return;
		}
		if (Player.isLockKey)
		{
			return;
		}
		if (this.currentQuest != null)
		{
			if (!GameCanvas.menu2.isShowMenu)
			{
				Player.timeQuest++;
				if (Player.timeQuest > 100)
				{
					this.currentQuest = null;
					GameScreen.gI().center = null;
					GameCanvas.clearKeyHold();
					GameCanvas.isPointerSelect = false;
				}
			}
			else
			{
				Player.timeQuest = 0;
			}
		}
		else
		{
			if (this.Action != 4 && !this.isTanHinh)
			{
				if (!this.isBinded && !this.isSleep && !this.isStun && !this.isMoveOut && !this.isDongBang && this.Action != 2 && this.Action != 3)
				{
					this.vx = 0;
					this.vy = 0;
					if (GameCanvas.keyMove((!Main.isPC) ? 2 : 33) || GameCanvas.keyMove(39))
					{
						if (!this.isSelling())
						{
							this.Action = 1;
							this.Direction = 2;
							this.vx = -(this.vMax + base.getVmount());
							this.vy = 0;
							this.resetMove();
							this.setValueAuto(0);
						}
						else
						{
							mVector mVector = new mVector();
							mVector.addElement(new iCommand(T.yes, 4, this));
							mVector.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector);
						}
					}
					else if (GameCanvas.keyMove((!Main.isPC) ? 3 : 34) || GameCanvas.keyMove(40))
					{
						if (!this.isSelling())
						{
							this.Action = 1;
							this.Direction = 3;
							this.vx = this.vMax + base.getVmount();
							this.vy = 0;
							this.resetMove();
							this.setValueAuto(0);
						}
						else
						{
							mVector mVector2 = new mVector();
							mVector2.addElement(new iCommand(T.yes, 4, this));
							mVector2.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector2);
						}
					}
					else if (GameCanvas.keyMove((!Main.isPC) ? 1 : 31) || GameCanvas.keyMove(30))
					{
						if (!this.isSelling())
						{
							this.Action = 1;
							this.Direction = 1;
							this.vy = -(this.vMax + base.getVmount());
							this.vx = 0;
							this.resetMove();
							this.setValueAuto(0);
						}
						else
						{
							mVector mVector3 = new mVector();
							mVector3.addElement(new iCommand(T.yes, 4, this));
							mVector3.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector3);
						}
					}
					else if (GameCanvas.keyMove((!Main.isPC) ? 0 : 32) || GameCanvas.keyMove(38))
					{
						if (!this.isSelling())
						{
							this.Action = 1;
							this.Direction = 0;
							this.vy = this.vMax + base.getVmount();
							this.vx = 0;
							this.resetMove();
							this.setValueAuto(0);
						}
						else
						{
							mVector mVector4 = new mVector();
							mVector4.addElement(new iCommand(T.yes, 4, this));
							mVector4.addElement(new iCommand(T.cancel, 5, this));
							GameCanvas.start_Select_Dialog(T.can_not_move, mVector4);
						}
					}
					if (this.vx == 0 && this.vy == 0)
					{
						Player.timeStand++;
					}
					else
					{
						Player.timeStand = 0;
					}
				}
				if (GameCanvas.keyMyHold[13] && Main.isPC)
				{
					GameCanvas.clearKeyHold(13);
					this.nextFocus();
				}
				if (GameCanvas.keyMyHold[37] && Main.isPC)
				{
					GameCanvas.clearKeyHold(37);
					ChatTextField.isShow = !ChatTextField.isShow;
				}
			}
			if (GameCanvas.keyMyHold[11] && !GameCanvas.isTouch)
			{
				GameCanvas.clearKeyHold(11);
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
			if (GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 21 : 1])
			{
				this.setActionHotKey(0, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 23 : 2])
			{
				this.setActionHotKey(1, true);
			}
			else if (GameCanvas.keyMyHold[(!Main.isPC || Player.isCapCha()) ? 5 : 36] || GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 25 : 3])
			{
				this.setActionHotKey(2, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 27 : 4])
			{
				this.setActionHotKey(3, true);
			}
			else if (GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 29 : 5])
			{
				this.setActionHotKey(4, true);
			}
		}
		if (GameCanvas.keyMyHold[(!Main.isPC) ? 20 : 6])
		{
			if (GameScreen.ObjFocus == null || (int)GameScreen.ObjFocus.typeBoss != 2)
			{
				if (PaintInfoGameScreen.timeChange == 0)
				{
					PaintInfoGameScreen.timeChange = 1;
				}
			}
			GameCanvas.clearKeyHold((!Main.isPC) ? 20 : 6);
		}
	}

	// Token: 0x0600055F RID: 1375 RVA: 0x0004D0D8 File Offset: 0x0004B2D8
	public static bool isCapCha()
	{
		return GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeBoss == 2;
	}

	// Token: 0x06000560 RID: 1376 RVA: 0x0004D0F8 File Offset: 0x0004B2F8
	public void setFocus()
	{
		if ((int)Player.isAutoFire == 1)
		{
			return;
		}
		if (GameScreen.ObjFocus != null && ((int)GameScreen.ObjFocus.typeBoss == 2 || GameScreen.ObjFocus.isLuaThieng()))
		{
			return;
		}
		if (GameScreen.ObjFocus != null)
		{
			if ((GameScreen.ObjFocus.Action == 4 && (int)GameScreen.ObjFocus.typeObject != 0) || MainObject.getDistance(GameScreen.ObjFocus.x, GameScreen.ObjFocus.y, this.x, this.y) > this.wFocus + 20 || (GameScreen.ObjFocus.isDie && (int)GameScreen.ObjFocus.typeObject == 1))
			{
				if (!GameScreen.infoGame.isMapThachdau())
				{
					GameScreen.ObjFocus = null;
					PaintInfoGameScreen.isPaintInfoFocus = false;
				}
			}
			else if (!GameCanvas.isTouch && ((int)GameScreen.ObjFocus.typeObject == 2 || ((int)GameScreen.ObjFocus.typeObject == 0 && !this.setFirePlayer(GameScreen.ObjFocus) && GameScreen.gI().center != GameScreen.gI().cmdGiaotiep && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang()))))
			{
				GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
			}
		}
		if (GameScreen.ObjFocus == null)
		{
			if (GameScreen.gI().center != null)
			{
				GameScreen.gI().center = null;
			}
			int num = GameScreen.Vecplayers.size();
			if (this.indexFocus > num - 1)
			{
				this.indexFocus = num - 1;
			}
			int num2 = 1000;
			int num3 = -1;
			MainObject mainObject = null;
			for (int i = 0; i < num; i++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt((i + this.indexFocus) % num);
				int distance = MainObject.getDistance(mainObject2.x, mainObject2.y, this.x, this.y);
				if (distance <= this.wFocus)
				{
					int num4 = this.setTypeFocus((int)mainObject2.typeObject);
					if (mainObject2.ID != GameScreen.player.ID && (mainObject2.Action != 4 || (int)mainObject2.typeObject == 0) && (!mainObject2.isRemove && num4 >= num3 && (!mainObject2.isDie || (int)mainObject2.typeObject != 1)) && (int)mainObject2.typeObject != 9 && !mainObject2.isLuaThieng() && !mainObject2.isDongBang)
					{
						if ((distance < this.wFocus || (mainObject != null && ((int)mainObject.typeObject == 0 || (int)mainObject.typeObject == 2) && ((int)mainObject2.typeObject == 3 || (int)mainObject2.typeObject == 1 || (int)mainObject2.typeObject == 4 || (int)mainObject2.typeObject == 5 || (int)mainObject2.typeObject == 7))) && (distance < num2 || num4 > num3) && (((int)mainObject2.typeObject != 0 && (int)mainObject2.typeObject != 2) || (int)Player.timeFocusLast >= 20 || (int)Player.typeFocusLast == 0 || (int)Player.typeFocusLast == 2))
						{
							mainObject = mainObject2;
							num2 = distance;
							this.indexFocus = i;
							num3 = num4;
						}
					}
				}
			}
			if (mainObject != null)
			{
				if (!mainObject.canFocus())
				{
					return;
				}
				GameScreen.ObjFocus = mainObject;
				if (!GameCanvas.isTouch)
				{
					if ((GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 2) || ((int)GameScreen.ObjFocus.typeObject == 0 && !this.setFirePlayer(GameScreen.ObjFocus) && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())))
					{
						GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
					}
					else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
					{
						GameScreen.gI().center = null;
					}
					GameScreen.gI().right = Player.cmdNextFocus;
				}
			}
			else if (GameScreen.gI().right == Player.cmdNextFocus)
			{
				GameScreen.gI().right = null;
			}
		}
	}

	// Token: 0x06000561 RID: 1377 RVA: 0x0004D584 File Offset: 0x0004B784
	public bool setStatusPk(MainObject obj)
	{
		return GameCanvas.loadmap.mapLang() || (int)obj.typeObject == 2 || ((int)this.typePk == -1 || (int)this.typePk == 10) || ((int)obj.typeObject == 1 && obj.typeMonster == 7) || obj.isMonstervantieu() || ((int)obj.typeObject == 0 && ((int)obj.typePk == 0 || (int)obj.typePk == 10 || ((int)obj.typePk != (int)this.typePk && (int)obj.typePk != -1) || (int)this.typePk == 0));
	}

	// Token: 0x06000562 RID: 1378 RVA: 0x0004D654 File Offset: 0x0004B854
	private int setTypeFocus(int typeObj)
	{
		int result = -1;
		switch (typeObj)
		{
		case 0:
		case 2:
			result = 0;
			break;
		case 1:
			result = 1;
			break;
		case 3:
		case 4:
		case 5:
		case 7:
			result = 2;
			break;
		}
		return result;
	}

	// Token: 0x06000563 RID: 1379 RVA: 0x0004D6A8 File Offset: 0x0004B8A8
	public void nextFocus()
	{
		if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		this.setValueAuto(0);
		MainObject mainObject = null;
		int num = -1;
		if (Player.isFocusNPC)
		{
			for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(i);
				if (!GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap) || (int)mainObject2.typePk != (int)this.typePk || (int)mainObject2.typeObject != 0)
				{
					if (mainObject2.isNPC())
					{
						if (GameScreen.ObjFocus != null && mainObject2 == GameScreen.ObjFocus)
						{
							num = i;
						}
						else if ((mainObject == null || num >= 0) && MainObject.getDistance(mainObject2.x, mainObject2.y, this.x, this.y) < this.wFocus)
						{
							mainObject = mainObject2;
							this.indexFocus = i;
							GameScreen.ObjFocus = mainObject;
							if (!GameCanvas.isTouch)
							{
								if ((int)mainObject.typeObject == 2 || (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 0 && !this.setFirePlayer(GameScreen.ObjFocus) && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())))
								{
									GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
								}
								else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
								{
									GameScreen.gI().center = null;
								}
							}
							Player.isFocusNPC = false;
							return;
						}
					}
				}
			}
		}
		mainObject = null;
		int num2 = -1;
		num = -1;
		for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
		{
			MainObject mainObject3 = (MainObject)GameScreen.Vecplayers.elementAt(j);
			if (mainObject3 != GameScreen.player && (mainObject3.Action != 4 || (int)mainObject3.typeObject == 0) && this.setStatusPk(mainObject3) && (int)mainObject3.typeObject != 9 && (int)mainObject3.typeObject != 10 && !mainObject3.isLuaThieng() && !mainObject3.isDongBang && mainObject3.canFocus())
			{
				if (!PaintInfoGameScreen.isMarket(GameCanvas.loadmap.idMap) || (int)mainObject3.typeObject != 0 || mainObject3.isSelling())
				{
					if (!this.isItem(mainObject3) || Player.autoItem == null)
					{
						if (GameScreen.ObjFocus != null && mainObject3 == GameScreen.ObjFocus)
						{
							num = j;
						}
						else if ((mainObject == null || num >= 0) && MainObject.getDistance(mainObject3.x, mainObject3.y, this.x, this.y) < this.wFocus)
						{
							mainObject = mainObject3;
							num2 = j;
						}
						if (num >= 0 && num2 > num)
						{
							this.indexFocus = j;
							GameScreen.ObjFocus = mainObject;
							if (!GameCanvas.isTouch)
							{
								if ((int)mainObject.typeObject == 2 || ((int)GameScreen.ObjFocus.typeObject == 0 && !this.setFirePlayer(GameScreen.ObjFocus) && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())))
								{
									GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
								}
								else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
								{
									GameScreen.gI().center = null;
								}
							}
							return;
						}
					}
				}
			}
		}
		if (mainObject != null)
		{
			GameScreen.ObjFocus = mainObject;
			if (!GameCanvas.isTouch)
			{
				if ((int)mainObject.typeObject == 2 || ((int)GameScreen.ObjFocus.typeObject == 0 && !this.setFirePlayer(GameScreen.ObjFocus) && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())))
				{
					GameScreen.gI().center = GameScreen.gI().cmdGiaotiep;
				}
				else if (GameScreen.gI().center == GameScreen.gI().cmdGiaotiep)
				{
					GameScreen.gI().center = null;
				}
			}
		}
	}

	// Token: 0x06000564 RID: 1380 RVA: 0x0004DB3C File Offset: 0x0004BD3C
	public void setActionHotKey(int index, bool isSetDef)
	{
		GameCanvas.clearAll();
		if (this.Action != 4 && GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 1 && (int)GameScreen.ObjFocus.typeBoss == 2)
		{
			if (index >= 0 && index <= 5)
			{
				GlobalService.gI().Mon_Capchar((sbyte)index);
			}
			return;
		}
		if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 1)
		{
			if (GameScreen.ObjFocus.isMonstervantieu())
			{
				if (GameScreen.ObjFocus.getnameOwner().Equals(this.name))
				{
					GameScreen.gI().cmdInfoVantieu.perform();
					return;
				}
				if (!GameScreen.ObjFocus.getnameOwner().Equals(this.name))
				{
					if ((int)this.typePk != 0 && !base.isPkVantieu())
					{
						return;
					}
					if ((int)this.typePk == 11)
					{
						if (!GameScreen.ObjFocus.isMonsterVantieuDen())
						{
							return;
						}
					}
					else if ((int)this.typePk == 12)
					{
						if (!GameScreen.ObjFocus.isMonsterVantieuTrang())
						{
							return;
						}
					}
					else if ((int)this.typePk == 13 && !GameScreen.ObjFocus.isMonsterVantieuDen())
					{
						return;
					}
				}
			}
			if (GameScreen.ObjFocus.isMiNuong())
			{
				GameScreen.gI().cmdinfoMiNuong.perform();
				return;
			}
		}
		HotKey hotKey;
		if (index == -1)
		{
			hotKey = new HotKey();
			hotKey.setHotKey(0, (int)HotKey.SKILL, 0);
		}
		else
		{
			hotKey = Player.mhotkey[Player.levelTab][index];
		}
		if ((int)hotKey.type == (int)HotKey.SKILL)
		{
			Player.skillDefault = (int)hotKey.id;
		}
		if ((int)hotKey.type == (int)HotKey.POTION)
		{
			Item itemInventory = Item.getItemInventory(4, hotKey.id);
			if (itemInventory != null && (int)itemInventory.typePotion < 2)
			{
				if (Player.timeDelayPotion[(int)itemInventory.typePotion].value <= 0)
				{
					if (((int)itemInventory.typePotion != 0 || this.hp != this.maxHp) && ((int)itemInventory.typePotion != 1 || this.mp != this.maxMp))
					{
						GlobalService.gI().Use_Potion((short)itemInventory.Id);
						Player.timeDelayPotion[(int)itemInventory.typePotion].value = 2000;
						Player.timeDelayPotion[(int)itemInventory.typePotion].limit = 2000;
						Player.timeDelayPotion[(int)itemInventory.typePotion].timebegin = mSystem.currentTimeMillis();
					}
				}
			}
			else if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 2 && index == 2)
			{
				GameScreen.gI().cmdGiaotiep.perform();
				return;
			}
			return;
		}
		if (GameScreen.ObjFocus == null)
		{
			if ((int)hotKey.type == (int)HotKey.SKILL && this.setDelaySkill((int)hotKey.id, index))
			{
				Skill skillFormId = MainListSkill.getSkillFormId((int)hotKey.id);
				if ((int)skillFormId.typeSkill == 1 && ((int)skillFormId.typeBuff == 1 || (int)skillFormId.typeBuff == 2))
				{
					this.posTransRoad = null;
					this.IDAttack = this.ID;
					mVector mVector = new mVector("Player vec");
					Object_Effect_Skill o = new Object_Effect_Skill((short)this.ID, this.typeObject);
					mVector.addElement(o);
					this.ListKillNow.setFireSkill(this, mVector, (int)hotKey.id, -1);
				}
			}
		}
		else
		{
			if ((int)GameScreen.ObjFocus.typeObject == 3 || (int)GameScreen.ObjFocus.typeObject == 4 || (int)GameScreen.ObjFocus.typeObject == 5 || (int)GameScreen.ObjFocus.typeObject == 7)
			{
				if (!GameScreen.ObjFocus.isSend)
				{
					GlobalService.gI().Get_Item_Map((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
					GameScreen.ObjFocus.isSend = true;
				}
				return;
			}
			if ((int)GameScreen.ObjFocus.typeObject == 2 && index == 2)
			{
				GameScreen.gI().cmdGiaotiep.perform();
				return;
			}
			if (this.Action == 2 || this.Action == 4 || this.currentQuest != null || this.isTanHinh)
			{
				if (this.Action == 4 && (int)GameScreen.ObjFocus.typeObject == 0 && index == 2 && ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang()))
				{
					GameScreen.gI().cmdGiaotiep.perform();
				}
				return;
			}
			if ((int)hotKey.type == (int)HotKey.SKILL && this.setDelaySkill((int)hotKey.id, index))
			{
				Skill skillFormId2 = MainListSkill.getSkillFormId((int)hotKey.id);
				if ((int)skillFormId2.typeSkill == 1)
				{
					if (this.setAutoBuff((int)skillFormId2.typeBuff, (int)hotKey.id, GameScreen.ObjFocus))
					{
						return;
					}
				}
				else if ((int)skillFormId2.typeSkill == 0 && GameScreen.ObjFocus.Action != 4 && (int)GameScreen.ObjFocus.typeObject != 2)
				{
					if (this.setFirePlayer(GameScreen.ObjFocus))
					{
						this.setStartSkill((int)hotKey.id, isSetDef);
						return;
					}
					if ((int)GameScreen.ObjFocus.typeObject == 1 && GameScreen.ObjFocus.typeMonster == 7 && this.myClan != null && GameScreen.ObjFocus.myClan != null && this.myClan.IdClan == GameScreen.ObjFocus.myClan.IdClan)
					{
						mVector mVector2 = new mVector("Player vec2");
						Object_Effect_Skill o2 = new Object_Effect_Skill((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
						mVector2.addElement(o2);
						GlobalService.gI().fire_monster(mVector2, 0);
						if ((int)Player.isAutoFire == 1)
						{
							Player.setCurAutoFire();
						}
						return;
					}
				}
			}
			if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject == 0 && index == 2 && !this.setFirePlayer(GameScreen.ObjFocus))
			{
				if (GameScreen.ObjFocus.isSelling())
				{
					GameScreen.gI().cmdplayerStore.perform();
				}
				else if ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())
				{
					GameScreen.gI().cmdGiaotiep.perform();
					return;
				}
			}
		}
	}

	// Token: 0x06000565 RID: 1381 RVA: 0x0004E1DC File Offset: 0x0004C3DC
	public void setStartSkill(int id, bool isset)
	{
		this.posTransRoad = null;
		if (GameScreen.ObjFocus == null)
		{
			return;
		}
		this.IDAttack = GameScreen.ObjFocus.ID;
		mVector mVector = new mVector("Player vec8");
		Object_Effect_Skill o = new Object_Effect_Skill((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
		mVector.addElement(o);
		this.ListKillNow.setFireSkill(this, mVector, id, -1);
		Player.timeFristSkill = mSystem.currentTimeMillis();
		if ((int)GameScreen.ObjFocus.typeObject == 1 && (int)Player.isAutoFire == 0)
		{
			Player.isAutoFire = 1;
			Player.isCurAutoFire = true;
			Player.xBeginAutoFire = this.x;
			Player.yBeginAutofire = this.y;
		}
	}

	// Token: 0x06000566 RID: 1382 RVA: 0x0004E290 File Offset: 0x0004C490
	public bool setDelaySkill(int t, int index)
	{
		if (Player.mCurentLvSkill[t] - 1 < 0)
		{
			if (index >= 0)
			{
				if (index == 2)
				{
					Player.mhotkey[Player.levelTab][index].setHotKey(0, (int)HotKey.SKILL, 0);
				}
				else
				{
					Player.mhotkey[Player.levelTab][index].type = HotKey.NULL;
				}
			}
			return false;
		}
		if (Player.timeDelaySkill[t].value > 0)
		{
			return false;
		}
		int mpLost = (int)MainListSkill.getSkillFormId(t).mLvSkill[Player.mCurentLvSkill[t] + Player.mPlusLvSkill[t] - 1].mpLost;
		if (this.mp < mpLost)
		{
			return false;
		}
		if ((int)this.typeMount == 0)
		{
			GameCanvas.addInfoChar(T.TisNguaNau);
			return false;
		}
		return this.KillFire != t;
	}

	// Token: 0x06000567 RID: 1383 RVA: 0x0004E360 File Offset: 0x0004C560
	public mVector setSkillLan(int index, MainObject objBe)
	{
		mVector mVector = new mVector("Player vec7");
		Object_Effect_Skill o = new Object_Effect_Skill((short)objBe.ID, objBe.typeObject);
		mVector.addElement(o);
		sbyte typeObject = objBe.typeObject;
		Skill skillFormId = MainListSkill.getSkillFormId(index);
		if (Player.mCurentLvSkill[skillFormId.Id] == 0)
		{
			return mVector;
		}
		if ((int)skillFormId.typeSkill == 1)
		{
			this.ListKillNow.classbuff = this.clazz;
			this.ListKillNow.typebuff = skillFormId.typeBuff;
			if ((int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].nTarget > 0 && ((int)typeObject == 0 || (int)skillFormId.typeBuff == 3))
			{
				int num = 1;
				for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
				{
					MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
					if (mainObject.ID != objBe.ID && mainObject != GameScreen.player && (int)typeObject == (int)mainObject.typeObject && mainObject.Action != 4)
					{
						if ((int)typeObject == 0)
						{
							if ((int)skillFormId.typeBuff == 3 && !this.setFirePlayer(mainObject))
							{
								goto IL_232;
							}
							if ((int)skillFormId.typeBuff == 2 && this.setFirePlayer(mainObject))
							{
								goto IL_232;
							}
						}
						mSystem.outz("range" + skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].range_lan);
						if (MainObject.getDistance(objBe.x, objBe.y, mainObject.x, mainObject.y) <= (int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].range_lan)
						{
							o = new Object_Effect_Skill((short)mainObject.ID, mainObject.typeObject);
							mVector.addElement(o);
							num++;
						}
						if (num >= (int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].nTarget)
						{
							return mVector;
						}
					}
					IL_232:;
				}
			}
		}
		else if ((int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].nTarget > 1)
		{
			int num2 = 1;
			for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
			{
				MainObject mainObject2 = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if (mainObject2.ID != objBe.ID && mainObject2 != GameScreen.player && (int)typeObject == (int)mainObject2.typeObject && mainObject2.Action != 4)
				{
					if ((int)typeObject != 0 || this.setFirePlayer(mainObject2))
					{
						if (MainObject.getDistance(objBe.x, objBe.y, mainObject2.x, mainObject2.y) <= (int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].range_lan)
						{
							o = new Object_Effect_Skill((short)mainObject2.ID, mainObject2.typeObject);
							mVector.addElement(o);
							num2++;
						}
						if (num2 >= (int)skillFormId.mLvSkill[Player.mCurentLvSkill[skillFormId.Id] + Player.mPlusLvSkill[skillFormId.Id] - 1].nTarget)
						{
							return mVector;
						}
					}
				}
			}
		}
		return mVector;
	}

	// Token: 0x06000568 RID: 1384 RVA: 0x0004E718 File Offset: 0x0004C918
	public void setAddDelaySkill(int t, int index)
	{
		if (t == 35)
		{
			for (int i = 0; i < Player.mKillPlayer.Length; i++)
			{
				Player.timeDelaySkill[i].value = 2000;
				Player.timeDelaySkill[i].limit = 2000;
				Player.timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
			}
		}
		else if (Player.mKillPlayer[index] == t)
		{
			LvSkill lvSkill = MainListSkill.getSkillFormId(index).mLvSkill[Player.mCurentLvSkill[index] + Player.mPlusLvSkill[index] - 1];
			Player.timeDelaySkill[index].value = lvSkill.getdelay();
			Player.timeDelaySkill[index].limit = lvSkill.getdelay();
			Player.timeDelaySkill[index].typeSkill = HotKey.SKILL;
			Player.timeDelaySkill[index].timebegin = mSystem.currentTimeMillis();
			if (lvSkill.mpLost > 0)
			{
				this.mp -= (int)lvSkill.mpLost;
			}
			Skill skillFormId = MainListSkill.getSkillFormId(index);
			if (skillFormId != null && (int)skillFormId.typeSkill == 0)
			{
				Player.timeDelaySkill[index].isSkillAttack = true;
			}
		}
	}

	// Token: 0x06000569 RID: 1385 RVA: 0x0004E834 File Offset: 0x0004CA34
	public void updateDelaySkill()
	{
		for (int i = 0; i < Player.timeDelaySkill.Length; i++)
		{
			if (Player.timeDelaySkill[i] != null && Player.timeDelaySkill[i].value > -150)
			{
				Player.timeDelaySkill[i].value -= (int)(mSystem.currentTimeMillis() - Player.timeDelaySkill[i].timebegin);
				Player.timeDelaySkill[i].timebegin = mSystem.currentTimeMillis();
			}
		}
		for (int j = 0; j < Player.timeDelayPotion.Length; j++)
		{
			if (Player.timeDelayPotion[j].value > -150)
			{
				Player.timeDelayPotion[j].value -= (int)(mSystem.currentTimeMillis() - Player.timeDelayPotion[j].timebegin);
				Player.timeDelayPotion[j].timebegin = mSystem.currentTimeMillis();
			}
		}
	}

	// Token: 0x0600056A RID: 1386 RVA: 0x0004E918 File Offset: 0x0004CB18
	public void resetCoolDown()
	{
		for (int i = 0; i < Player.timeDelaySkill.Length; i++)
		{
			if (Player.timeDelaySkill[i].isSkillAttack)
			{
				Player.timeDelaySkill[i].value = 0;
			}
		}
	}

	// Token: 0x0600056B RID: 1387 RVA: 0x0004E95C File Offset: 0x0004CB5C
	public void resetMove()
	{
		if (this.KillFire != -1)
		{
			this.KillFire = -1;
			this.posTransRoad = null;
			this.toX = this.x;
			this.toY = this.y;
			this.xStopMove = 0;
			this.yStopMove = 0;
		}
	}

	// Token: 0x0600056C RID: 1388 RVA: 0x0004E9AC File Offset: 0x0004CBAC
	public bool setFirePlayer(MainObject obj)
	{
		if (obj.canfire())
		{
			return true;
		}
		if (obj.isLuaThieng())
		{
			return false;
		}
		if (GameCanvas.loadmap.mapLang())
		{
			return false;
		}
		if (obj == null)
		{
			return false;
		}
		if (this.isStun || this.isDongBang)
		{
			return false;
		}
		if (obj.isSleep)
		{
			return true;
		}
		if (obj.isMoveOut)
		{
			return true;
		}
		if ((int)obj.typeObject == 0 && (int)obj.typeSpec == 1)
		{
			return ((int)obj.typePk < 1 || (int)obj.typePk > 9 || (int)this.typePk < 1 || (int)this.typePk > 9 || (int)obj.typePk != (int)this.typePk) && (obj.myClan == null || GameScreen.player.myClan == null || obj.myClan.IdClan != GameScreen.player.myClan.IdClan);
		}
		if (this.Action == 4 || obj.Action == 4)
		{
			return false;
		}
		if ((int)obj.typeObject == 0)
		{
			return ((int)obj.typePk < 1 || (int)obj.typePk > 9 || (int)this.typePk < 1 || (int)this.typePk > 9 || (int)obj.typePk != (int)this.typePk) && this.pointPk < 2000 && (((int)this.typePk == 12 && ((int)obj.typePk == 13 || (int)obj.typePk == 11)) || (((int)this.typePk != 12 || (int)obj.typePk != 12) && (((int)this.typePk == 13 && (int)obj.typePk == 12) || (((int)this.typePk != 13 || ((int)obj.typePk != 13 && (int)obj.typePk != 11)) && (((int)this.typePk == 11 && (int)obj.typePk == 12) || (((int)this.typePk != 11 || ((int)obj.typePk != 11 && (int)obj.typePk != 13)) && (((int)this.typePk == 10 && this.setPlayerPk((short)obj.ID)) || ((int)obj.typePk == 0 || (int)obj.typePk == 10) || ((int)obj.typePk != -1 && (int)this.typePk != -1 && (int)this.typePk != (int)obj.typePk && (int)this.typePk != 10) || (obj.Lv > 10 && (int)this.typePk == 0))))))));
		}
		if (Player.PointSucKhoe <= 0)
		{
			GameCanvas.addInfoChar(T.yeusuckhoe);
			return false;
		}
		return (int)obj.typeObject != 1 || obj.typeMonster != 7 || this.myClan == null || obj.myClan == null || this.myClan.IdClan != obj.myClan.IdClan;
	}

	// Token: 0x0600056D RID: 1389 RVA: 0x0004ED24 File Offset: 0x0004CF24
	public bool setPlayerPk(short id)
	{
		for (int i = 0; i < Player.vecPlayerPk.Length; i++)
		{
			if (id == Player.vecPlayerPk[i])
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600056E RID: 1390 RVA: 0x0004ED5C File Offset: 0x0004CF5C
	public void dofire()
	{
		if ((int)Player.isAutoFire == 0)
		{
			Player.isAutoFire = 1;
			Player.xBeginAutoFire = this.x;
			Player.yBeginAutofire = this.y;
			Player.timeResetAuto = 60;
			Player.isCurAutoFire = true;
		}
		else if ((int)Player.isAutoFire == -1)
		{
			GameCanvas.keyMyPressed[(!Main.isPC || Player.isCapCha()) ? 25 : 3] = true;
			Player.isAutoFire = 1;
			Player.xBeginAutoFire = this.x;
			Player.yBeginAutofire = this.y;
			Player.timeResetAuto = 60;
			Player.isCurAutoFire = false;
		}
	}

	// Token: 0x0600056F RID: 1391 RVA: 0x0004EDFC File Offset: 0x0004CFFC
	public void setPointFocus()
	{
		if (GameScreen.ObjFocus == null)
		{
			return;
		}
		if ((int)GameScreen.ObjFocus.typeBoss == 2)
		{
			return;
		}
		if (GameScreen.ObjFocus.isNPC())
		{
			GameScreen.gI().cmdGiaotiep.perform();
			if ((int)Player.isAutoFire == 1)
			{
				Player.setCurAutoFire();
			}
			return;
		}
		if ((int)GameScreen.ObjFocus.typeObject == 0)
		{
			if (this.setFirePlayer(GameScreen.ObjFocus))
			{
				HotKey hotKey = Player.mhotkey[Player.levelTab][(int)Player.IndexFire];
				if ((int)hotKey.type != (int)HotKey.SKILL)
				{
					for (int i = 0; i < Player.mhotkey[Player.levelTab].Length; i++)
					{
						hotKey = Player.mhotkey[Player.levelTab][i];
						if ((int)hotKey.type == (int)HotKey.SKILL)
						{
							Player.IndexFire = (sbyte)i;
							if ((int)Player.isAutoFire == 1)
							{
								Player.setCurAutoFire();
							}
							break;
						}
					}
				}
				this.setActionHotKey((int)Player.IndexFire, false);
			}
			else if (GameScreen.ObjFocus.isSelling())
			{
				GameScreen.gI().cmdplayerStore.perform();
			}
			else if ((int)this.typePk == -1 || (int)this.typePk == 10 || GameCanvas.loadmap.mapLang())
			{
				GameScreen.gI().cmdGiaotiep.setPos(GameScreen.ObjFocus.x - MainScreen.cameraMain.xCam, GameScreen.ObjFocus.y - MainScreen.cameraMain.yCam - GameScreen.ObjFocus.hOne - 30, PaintInfoGameScreen.fraContact, string.Empty);
				GameScreen.gI().cmdGiaotiep.IdGiaotiep = GameScreen.ObjFocus.ID;
				GameScreen.timePaintCmdGiaotiep = 60;
			}
			return;
		}
		if ((int)GameScreen.ObjFocus.typeObject == 4 || (int)GameScreen.ObjFocus.typeObject == 3 || (int)GameScreen.ObjFocus.typeObject == 5 || (int)GameScreen.ObjFocus.typeObject == 7)
		{
			if (!GameScreen.ObjFocus.isSend)
			{
				GlobalService.gI().Get_Item_Map((short)GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject);
				GameScreen.ObjFocus.isSend = true;
			}
			return;
		}
		if ((int)GameScreen.ObjFocus.typeObject == 1)
		{
			if (GameScreen.ObjFocus.Action == 4)
			{
				return;
			}
			if (GameScreen.ObjFocus.isMiNuong())
			{
				GameScreen.gI().cmdinfoMiNuong.perform();
				return;
			}
			if (!GameScreen.ObjFocus.isMonstervantieu())
			{
				this.dofire();
			}
			else if (GameScreen.ObjFocus.isMonstervantieu())
			{
				if (GameScreen.ObjFocus.getnameOwner().Equals(this.name))
				{
					GameScreen.gI().cmdInfoVantieu.perform();
				}
				else if (!GameScreen.ObjFocus.getnameOwner().Equals(this.name))
				{
					if ((int)this.typePk == 0)
					{
						this.dofire();
					}
					else if ((int)this.typePk == 11 || (int)this.typePk == 13)
					{
						if (GameScreen.ObjFocus.isMonsterVantieuDen())
						{
							this.dofire();
						}
					}
					else if ((int)this.typePk == 12 && GameScreen.ObjFocus.isMonsterVantieuTrang())
					{
						this.dofire();
					}
				}
			}
		}
	}

	// Token: 0x06000570 RID: 1392 RVA: 0x0004F168 File Offset: 0x0004D368
	public void resetPlayer()
	{
		Player.party = null;
		this.currentQuest = null;
		this.chat = null;
	}

	// Token: 0x06000571 RID: 1393 RVA: 0x0004F180 File Offset: 0x0004D380
	public void setValueAuto(int value)
	{
		if ((int)Player.isAutoFire != -1)
		{
			if (Player.isCurAutoFire)
			{
				Player.isAutoFire = (sbyte)value;
			}
			else
			{
				Player.isAutoFire = -1;
			}
			if ((int)Player.isAutoFire == 0)
			{
				Player.xBeginAutoFire = -1;
				Player.yBeginAutofire = -1;
			}
		}
	}

	// Token: 0x06000572 RID: 1394 RVA: 0x0004F1CC File Offset: 0x0004D3CC
	public bool setAutoBuff(int typeBuff, int id, MainObject objFo)
	{
		if (objFo == null)
		{
			this.posTransRoad = null;
			this.IDAttack = this.ID;
			mVector mVector = new mVector("Player vec3");
			Object_Effect_Skill o = new Object_Effect_Skill((short)this.ID, this.typeObject);
			mVector.addElement(o);
			this.ListKillNow.setFireSkill(this, mVector, id, -1);
			return true;
		}
		if (typeBuff == 2)
		{
			this.posTransRoad = null;
			this.IDAttack = this.ID;
			mVector mVector2 = new mVector("Player vec4");
			Object_Effect_Skill o2;
			if (objFo.Action == 4 || (int)objFo.typeObject == 2 || (int)this.typePk == 0 || (int)objFo.typePk == 0 || (int)objFo.typePk == 10 || ((int)objFo.typePk != -1 && (int)this.typePk != -1 && (int)this.typePk != (int)objFo.typePk))
			{
				o2 = new Object_Effect_Skill((short)this.ID, this.typeObject);
			}
			else
			{
				o2 = new Object_Effect_Skill((short)objFo.ID, objFo.typeObject);
			}
			mVector2.addElement(o2);
			this.ListKillNow.setFireSkill(this, mVector2, id, -1);
			return true;
		}
		if (typeBuff == 1)
		{
			this.posTransRoad = null;
			this.IDAttack = this.ID;
			mVector mVector3 = new mVector("Player vec5");
			Object_Effect_Skill o3 = new Object_Effect_Skill((short)this.ID, this.typeObject);
			mVector3.addElement(o3);
			this.ListKillNow.setFireSkill(this, mVector3, id, -1);
			return true;
		}
		if (typeBuff == 3 && objFo.Action != 4 && (int)objFo.typeObject != 2 && this.setFirePlayer(objFo))
		{
			this.posTransRoad = null;
			this.IDAttack = objFo.ID;
			mVector mVector4 = new mVector("Player vec6");
			Object_Effect_Skill o4 = new Object_Effect_Skill((short)objFo.ID, objFo.typeObject);
			mVector4.addElement(o4);
			this.ListKillNow.setFireSkill(this, mVector4, id, -1);
			return true;
		}
		return false;
	}

	// Token: 0x06000573 RID: 1395 RVA: 0x0004F3D0 File Offset: 0x0004D5D0
	public static bool setFirePlayerSpec(MainObject obj)
	{
		return obj != null && ((int)obj.typeObject == 0 && (int)obj.typeSpec == 1 && (obj.myClan == null || GameScreen.player.myClan == null || obj.myClan.IdClan != GameScreen.player.myClan.IdClan));
	}

	// Token: 0x06000574 RID: 1396 RVA: 0x0004F43C File Offset: 0x0004D63C
	public bool checkGiaoTiep()
	{
		return GameScreen.ObjFocus != null && ((int)GameScreen.ObjFocus.typeObject == 2 || (((int)GameScreen.ObjFocus.typeObject != 1 || (GameScreen.ObjFocus.myClan != null && GameScreen.player.myClan != null && GameScreen.ObjFocus.myClan.IdClan == GameScreen.player.myClan.IdClan)) && !this.setFirePlayer(GameScreen.ObjFocus)));
	}

	// Token: 0x06000575 RID: 1397 RVA: 0x0004F4D0 File Offset: 0x0004D6D0
	public override void move_to_XY()
	{
		if (this.isSelling())
		{
			this.toX = this.x;
			this.toY = this.y;
			this.posTransRoad = null;
			mVector mVector = new mVector();
			mVector.addElement(new iCommand(T.yes, 4, this));
			mVector.addElement(new iCommand(T.cancel, 5, this));
			GameCanvas.start_Select_Dialog(T.can_not_move, mVector);
			return;
		}
		if (!base.Canmove() || this.isBinded)
		{
			this.toX = this.x;
			this.toY = this.y;
			return;
		}
		if (this.isMoveOut)
		{
			return;
		}
		if (this.x != this.toX)
		{
			this.vy = 0;
			this.Action = 1;
			if (CRes.abs(this.x - this.toX) > this.vMax + base.getVmount())
			{
				if (this.x > this.toX)
				{
					this.vx = -(this.vMax + base.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 2;
				}
				else
				{
					this.vx = this.vMax + base.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 3;
				}
			}
			else if (CRes.abs(this.x - this.toX) < this.vMax + base.getVmount())
			{
				if (this.x > this.toX)
				{
					this.vx = -CRes.abs(this.x - this.toX);
					this.PrevDir = this.Direction;
					this.Direction = 2;
				}
				else
				{
					this.vx = CRes.abs(this.x - this.toX);
					this.PrevDir = this.Direction;
					this.Direction = 3;
				}
			}
			else if (this.x > this.toX)
			{
				this.vx = -(this.vMax + base.getVmount());
				this.PrevDir = this.Direction;
				this.Direction = 2;
			}
			else
			{
				this.vx = this.vMax + base.getVmount();
				this.PrevDir = this.Direction;
				this.Direction = 3;
			}
		}
		else if (this.y != this.toY)
		{
			this.vx = 0;
			this.Action = 1;
			if (CRes.abs(this.y - this.toY) > this.vMax + base.getVmount())
			{
				if (this.y > this.toY)
				{
					this.vy = -(this.vMax + base.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 1;
				}
				else
				{
					this.vy = this.vMax + base.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 0;
				}
			}
			else if (CRes.abs(this.y - this.toY) < this.vMax + base.getVmount())
			{
				if (this.y > this.toY)
				{
					this.vy = -CRes.abs(this.y - this.toY);
					this.PrevDir = this.Direction;
					this.Direction = 1;
				}
				else
				{
					this.vy = CRes.abs(this.y - this.toY);
					this.PrevDir = this.Direction;
					this.Direction = 0;
				}
			}
			else if (this.y > this.toY)
			{
				this.vy = -(this.vMax + base.getVmount());
				this.PrevDir = this.Direction;
				this.Direction = 1;
			}
			else
			{
				this.vy = this.vMax + base.getVmount();
				this.PrevDir = this.Direction;
				this.Direction = 0;
			}
		}
		else
		{
			this.vx = 0;
			this.vy = 0;
			this.Action = 0;
		}
	}

	// Token: 0x06000576 RID: 1398 RVA: 0x0004F8E0 File Offset: 0x0004DAE0
	public override void addEffectCharWearing(int typeeffect, int idimage)
	{
		EffectCharWearing o = new EffectCharWearing((sbyte)typeeffect, idimage);
		this.vecEffectCharWearing.addElement(o);
	}

	// Token: 0x06000577 RID: 1399 RVA: 0x0004F904 File Offset: 0x0004DB04
	public static void setCurAutoFire()
	{
		if (Player.isCurAutoFire)
		{
			Player.isAutoFire = 0;
		}
		else
		{
			Player.isAutoFire = -1;
		}
	}

	// Token: 0x06000578 RID: 1400 RVA: 0x0004F924 File Offset: 0x0004DB24
	public override void removeNameStore()
	{
		this.nameStore = null;
	}

	// Token: 0x06000579 RID: 1401 RVA: 0x0004F930 File Offset: 0x0004DB30
	public void dofire_()
	{
		Player.isAutoFire = 1;
		Player.xBeginAutoFire = this.x;
		Player.yBeginAutofire = this.y;
		Player.timeResetAuto = 60;
		Player.isCurAutoFire = true;
	}

	// Token: 0x0600057A RID: 1402 RVA: 0x0004F95C File Offset: 0x0004DB5C
	public override void setNameStore(string name)
	{
		if (this.nameStore == null)
		{
			this.nameStore = new PopupChat();
		}
		this.nameStore.setChat(name, this.isStop);
		this.nameStore.updatePos(this.x, this.y - this.hOne - 30);
	}

	// Token: 0x0600057B RID: 1403 RVA: 0x0004F9B4 File Offset: 0x0004DBB4
	public override bool isSelling()
	{
		return this.nameStore != null;
	}

	// Token: 0x0400076E RID: 1902
	public static iCommand cmdNextFocus;

	// Token: 0x0400076F RID: 1903
	public static iCommand cmdRevice;

	// Token: 0x04000770 RID: 1904
	public static iCommand cmdVeLang;

	// Token: 0x04000771 RID: 1905
	public static int levelTab = 0;

	// Token: 0x04000772 RID: 1906
	public static int PointSucKhoe = 0;

	// Token: 0x04000773 RID: 1907
	public static int MaxSkill = 21;

	// Token: 0x04000774 RID: 1908
	public static int timeX2 = 0;

	// Token: 0x04000775 RID: 1909
	public static int timeResetAuto = 0;

	// Token: 0x04000776 RID: 1910
	public static int PointArena = 0;

	// Token: 0x04000777 RID: 1911
	public static long timeSetX2;

	// Token: 0x04000778 RID: 1912
	public static bool isNewPlayer = false;

	// Token: 0x04000779 RID: 1913
	public static bool isAutoHPMP = false;

	// Token: 0x0400077A RID: 1914
	public static bool isLockKey = false;

	// Token: 0x0400077B RID: 1915
	public static bool isSendMove = true;

	// Token: 0x0400077C RID: 1916
	public static bool isPhong = false;

	// Token: 0x0400077D RID: 1917
	public static sbyte isAutoFire = 1;

	// Token: 0x0400077E RID: 1918
	public static sbyte isAutoBuff = 0;

	// Token: 0x0400077F RID: 1919
	public static AutoGetItem autoItem;

	// Token: 0x04000780 RID: 1920
	public static bool isFullInven = false;

	// Token: 0x04000781 RID: 1921
	public static long timeFristSkill;

	// Token: 0x04000782 RID: 1922
	public static DelaySkill[] timeDelaySkill = new DelaySkill[Player.MaxSkill];

	// Token: 0x04000783 RID: 1923
	public static DelaySkill[] timeDelayPotion = new DelaySkill[3];

	// Token: 0x04000784 RID: 1924
	public static int diemTiemNang = 0;

	// Token: 0x04000785 RID: 1925
	public static int diemKyNang = 0;

	// Token: 0x04000786 RID: 1926
	public static int[][] mTiemnang = mSystem.new_M_Int(2, 4);

	// Token: 0x04000787 RID: 1927
	public static HotKey[][] mhotkey = new HotKey[3][];

	// Token: 0x04000788 RID: 1928
	public static short maxInven = 42;

	// Token: 0x04000789 RID: 1929
	public static short maxChest = 20;

	// Token: 0x0400078A RID: 1930
	public static short maxPet = 24;

	// Token: 0x0400078B RID: 1931
	public static sbyte typeX2 = 0;

	// Token: 0x0400078C RID: 1932
	public sbyte timeHit;

	// Token: 0x0400078D RID: 1933
	public int timeCombo;

	// Token: 0x0400078E RID: 1934
	public long timeSendmove;

	// Token: 0x0400078F RID: 1935
	public bool ispaintHit;

	// Token: 0x04000790 RID: 1936
	public bool isMaxdame;

	// Token: 0x04000791 RID: 1937
	public static sbyte[] ID_HAIR_NO_HAT;

	// Token: 0x04000792 RID: 1938
	private PopupChat nameStore;

	// Token: 0x04000793 RID: 1939
	public int lastX = 1000000;

	// Token: 0x04000794 RID: 1940
	public int lastY = 1000000;

	// Token: 0x04000795 RID: 1941
	public static int[] mKillPlayer = new int[Player.MaxSkill];

	// Token: 0x04000796 RID: 1942
	public static int[] mCurentLvSkill = new int[Player.MaxSkill];

	// Token: 0x04000797 RID: 1943
	public static int[] mPlusLvSkill = new int[Player.MaxSkill];

	// Token: 0x04000798 RID: 1944
	public string[] mKhangChar = new string[5];

	// Token: 0x04000799 RID: 1945
	public MainInfoItem[] mInfoChar;

	// Token: 0x0400079A RID: 1946
	public MainQuest currentQuest;

	// Token: 0x0400079B RID: 1947
	public static MainParty party;

	// Token: 0x0400079C RID: 1948
	public static int xFocus = -1;

	// Token: 0x0400079D RID: 1949
	public static int yFocus = -1;

	// Token: 0x0400079E RID: 1950
	public static int timeFocus = 0;

	// Token: 0x0400079F RID: 1951
	public new static int skillDefault = 0;

	// Token: 0x040007A0 RID: 1952
	public static int xBeginAutoFire = -1;

	// Token: 0x040007A1 RID: 1953
	public static int yBeginAutofire = -1;

	// Token: 0x040007A2 RID: 1954
	public static short[] vecPlayerPk = new short[0];

	// Token: 0x040007A3 RID: 1955
	public TabSkillsNew tabskills;

	// Token: 0x040007A4 RID: 1956
	private int coutauto;

	// Token: 0x040007A5 RID: 1957
	public static sbyte IndexFire = 0;

	// Token: 0x040007A6 RID: 1958
	private long timeAutoBuff;

	// Token: 0x040007A7 RID: 1959
	public static short demUnFire = 0;

	// Token: 0x040007A8 RID: 1960
	private int xtam;

	// Token: 0x040007A9 RID: 1961
	private int ytam;

	// Token: 0x040007AA RID: 1962
	private int counttam;

	// Token: 0x040007AB RID: 1963
	private int skilltam;

	// Token: 0x040007AC RID: 1964
	public static int testloadmap = 0;

	// Token: 0x040007AD RID: 1965
	public new static int timeStand = 0;

	// Token: 0x040007AE RID: 1966
	public static int timeQuest;

	// Token: 0x040007AF RID: 1967
	public static sbyte typeFocusLast = -1;

	// Token: 0x040007B0 RID: 1968
	public static sbyte timeFocusLast = 0;

	// Token: 0x040007B1 RID: 1969
	private int indexFocus;

	// Token: 0x040007B2 RID: 1970
	public static bool isFocusNPC = false;

	// Token: 0x040007B3 RID: 1971
	public static int timeFocusNPC = 0;

	// Token: 0x040007B4 RID: 1972
	public static bool isCurAutoFire = false;
}
