using System;
using UnityEngine;

// Token: 0x020000DE RID: 222
public class ReadMessenge : AvMain
{
	// Token: 0x06000A80 RID: 2688 RVA: 0x000AD62C File Offset: 0x000AB82C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			GlobalService.gI().Buy_Sell(1, this.nameBuySell, 0, 0, 0);
			GameCanvas.end_Dialog();
			break;
		case 1:
			GlobalService.gI().Party(2, this.nameParty);
			GameCanvas.end_Dialog();
			break;
		case 2:
			GameCanvas.end_Dialog();
			if (subIndex >= 0)
			{
				GlobalService.gI().dialog_Server(this.idDialog, this.typeDialog, (sbyte)subIndex);
			}
			break;
		case 3:
			MainObject.StepHelpServer += 1;
			if ((int)MainObject.StepHelpServer >= MainObject.strHelpNPC.Length - 1)
			{
				GameCanvas.menu2.startAt_NPC(null, MainObject.strHelpNPC[MainObject.strHelpNPC.Length - 1], subIndex, 2, false, 2);
			}
			else
			{
				mVector mVector = new mVector("ReadMessenge menu");
				iCommand o = new iCommand(T.next, 3, subIndex, this);
				mVector.addElement(o);
				GameCanvas.menu2.startAt_NPC(mVector, MainObject.strHelpNPC[(int)MainObject.StepHelpServer], subIndex, 2, false, 2);
			}
			break;
		case 4:
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Replace_Item(2, 0);
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		}
	}

	// Token: 0x06000A81 RID: 2689 RVA: 0x000AD770 File Offset: 0x000AB970
	public void khamNgoc(Message msg)
	{
		try
		{
			GameCanvas.end_Dialog();
			TabRebuildItem.isBeginEff = 1;
			TabRebuildItem.isNextRebuild = msg.reader().readByte();
			TabRebuildItem.contentShow = msg.reader().readUTF();
			TabRebuildItem.vecGem.removeAllElements();
			short num = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			if (num != -1 && (int)b == 7)
			{
				MainItem material = Item.getMaterial((int)num);
				if (material != null)
				{
					TabRebuildItem.itemRe = material;
				}
				else
				{
					TabRebuildItem.itemRe = new MainItem();
					TabRebuildItem.itemRe.Id = (int)num;
					TabRebuildItem.itemRe.ItemCatagory = 7;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A82 RID: 2690 RVA: 0x000AD838 File Offset: 0x000ABA38
	public void mainCharInfo(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string text = msg.reader().readUTF();
			text = text.ToLower();
			int hp = msg.reader().readInt();
			int num = msg.reader().readInt();
			int mp = msg.reader().readInt();
			int maxMp = msg.reader().readInt();
			sbyte b = msg.reader().readByte();
			sbyte clazz = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			if (GameScreen.player == null)
			{
				GameScreen.player = new Player((int)id, 0, text.ToLower(), 50, 50);
			}
			GameScreen.player.setInfo((int)b, (int)b2, (int)b3);
			sbyte b4 = msg.reader().readByte();
			MainInfoItem[] array = new MainInfoItem[(int)b4];
			int num2 = 0;
			for (int i = 0; i < GameScreen.player.mKhangChar.Length; i++)
			{
				GameScreen.player.mKhangChar[i] = "0";
			}
			for (int j = 0; j < (int)b4; j++)
			{
				if (GameMidlet.version.Equals("1.1.0"))
				{
					array[j] = new MainInfoItem((int)msg.reader().readUnsignedByte(), (int)msg.reader().readUnsignedShort());
				}
				else
				{
					array[j] = new MainInfoItem((int)msg.reader().readUnsignedByte(), msg.reader().readInt());
				}
				if (array[j].id >= 16 && array[j].id <= 20)
				{
					GameScreen.player.mKhangChar[array[j].id - 16] = MainItem.getNopercent(array[j].value);
				}
				if (array[j].id >= 23 && array[j].id <= 26)
				{
					num2++;
				}
			}
			if (num2 == 0)
			{
				GameScreen.player.mInfoChar = array;
			}
			else
			{
				GameScreen.player.mInfoChar = new MainInfoItem[(int)b4 - num2];
				num2 = 0;
				for (int k = 0; k < array.Length; k++)
				{
					if (array[k].id < 23 || array[k].id > 26)
					{
						GameScreen.player.mInfoChar[num2] = new MainInfoItem(array[k].id, array[k].value);
						num2++;
					}
				}
			}
			GameScreen.player.Lv = msg.reader().readShort();
			GameScreen.player.phantramLv = msg.reader().readShort();
			Player.diemTiemNang = (int)msg.reader().readShort();
			Player.diemKyNang = (int)msg.reader().readShort();
			for (int l = 0; l < Player.mTiemnang[0].Length; l++)
			{
				Player.mTiemnang[0][l] = (int)msg.reader().readShort();
			}
			for (int m = 0; m < Player.mTiemnang[0].Length; m++)
			{
				Player.mTiemnang[1][m] = (int)msg.reader().readShort();
			}
			Player.mCurentLvSkill = new int[Player.MaxSkill];
			for (int n = 0; n < Player.MaxSkill; n++)
			{
				Player.mCurentLvSkill[n] = (int)msg.reader().readByte();
			}
			for (int num3 = 0; num3 < Player.MaxSkill; num3++)
			{
				Player.mPlusLvSkill[num3] = (int)msg.reader().readByte();
			}
			for (int num4 = 0; num4 < Player.MaxSkill; num4++)
			{
				int num5 = -1;
				bool flag = true;
				if (Player.mCurentLvSkill[num4] > 0)
				{
					if (num4 < 9)
					{
						for (int num6 = 0; num6 < 3; num6++)
						{
							HotKey hotKey = Player.mhotkey[Player.levelTab][num6];
							if (hotKey != null)
							{
								if (num5 == -1)
								{
									if ((int)hotKey.type == (int)HotKey.NULL)
									{
										num5 = num6;
										flag = false;
									}
								}
								else if ((int)hotKey.type == (int)HotKey.SKILL && (int)hotKey.id == num4)
								{
									num5 = -1;
									break;
								}
							}
						}
					}
				}
				else
				{
					flag = false;
				}
				if (num5 != -1)
				{
					Player.mhotkey[Player.levelTab][num5].setHotKey(num4, (int)HotKey.SKILL, 0);
				}
				if (flag)
				{
					break;
				}
			}
			GameScreen.player.typePk = msg.reader().readByte();
			GameScreen.player.pointPk = msg.reader().readShort();
			Player.maxInven = (short)msg.reader().readByte();
			TabShopNew.maxTab = (sbyte)(Player.maxInven / 42);
			short num7 = msg.reader().readShort();
			if (num7 >= 0)
			{
				int idClan = msg.reader().readInt();
				GameScreen.player.myClan = new MainClan(idClan, num7, msg.reader().readUTF(), msg.reader().readByte());
			}
			GameScreen.nameSpecialRegion = msg.reader().readUTF();
			GameScreen.timeSpRegion = msg.reader().readLong();
			Skill.resetContent();
			GameScreen.player.typeObject = 0;
			GameScreen.player.name = text.ToLower();
			GameScreen.player.ID = (int)id;
			GameScreen.player.hp = hp;
			if (GameScreen.player.hp > 0 && GameScreen.player.Action == 4)
			{
				GameScreen.player.resetAction();
				GameScreen.player.weapon_frame = 0;
				GameScreen.player.Action = 0;
				GameScreen.player.vecBuff.removeAllElements();
				GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
			}
			GameScreen.player.maxHp = num;
			GameScreen.player.hpEffect = num / 10;
			GameScreen.player.mp = mp;
			GameScreen.player.maxMp = maxMp;
			GameScreen.player.clazz = clazz;
			GameScreen.player.weapon_frame = 0;
			if (!Player.isNewPlayer)
			{
				EventScreen.vecListEvent.removeAllElements();
				EventScreen.vecEventShow.removeAllElements();
				if (!GameScreen.Vecplayers.Equals(GameScreen.player))
				{
					GameScreen.addPlayer(GameScreen.player);
				}
				GameScreen.player.init();
				Player.isNewPlayer = true;
				MsgChat.vecChatTab.removeAllElements();
				GameCanvas.msgchat.addNewChat(T.tinden, string.Empty, T.thongbaotuserver, ChatDetail.TYPE_SERVER, false);
				Player.vecPlayerPk = new short[0];
				MainRMS.RequietRMS();
				GlobalService.gI().send_cmd_server(59);
				PaintInfoGameScreen.numMess = 0;
				GameScreen.VecInfoServer.removeAllElements();
				GameScreen.VecInfoChar.removeAllElements();
				GameScreen.infoGame.strInfoServer = null;
				GameScreen.infoGame.strInfoCharCline = null;
				GameScreen.infoGame.strInfoCharServer = null;
				Player.typeX2 = 0;
				if (GameScreen.player.Lv == 1)
				{
					Player.isAutoFire = -1;
				}
				GlobalService.gI().Save_RMS_Server(1, 4, null);
				GlobalService.gI().Save_RMS_Server(1, 3, null);
				TemMidlet.submitPurchase();
			}
			MainTabNew.timePaintInfo = 0;
			sbyte b5 = msg.reader().readByte();
			short[] array2 = new short[(int)b5];
			for (int num8 = 0; num8 < (int)b5; num8++)
			{
				array2[num8] = -1;
				array2[num8] = msg.reader().readShort();
			}
			GameScreen.player.idPartFashion = array2;
			GameCanvas.naptien = (int)msg.reader().readByte();
			short idMatna = -1;
			try
			{
				idMatna = msg.reader().readShort();
			}
			catch (Exception ex)
			{
				idMatna = -1;
			}
			GameScreen.player.idMatna = idMatna;
			try
			{
				sbyte b6 = msg.reader().readByte();
				if ((int)b6 == 1)
				{
					GameScreen.player.paintMatnaTruocNon = true;
				}
				else
				{
					GameScreen.player.paintMatnaTruocNon = false;
				}
			}
			catch (Exception ex2)
			{
			}
			short idPhiPhong = -1;
			try
			{
				idPhiPhong = msg.reader().readShort();
			}
			catch (Exception ex3)
			{
				idPhiPhong = -1;
			}
			GameScreen.player.idPhiPhong = idPhiPhong;
			short idWeaPon = -1;
			try
			{
				idWeaPon = msg.reader().readShort();
			}
			catch (Exception ex4)
			{
				idWeaPon = -1;
			}
			GameScreen.player.idWeaPon = idWeaPon;
			short idHorse = -1;
			try
			{
				idHorse = msg.reader().readShort();
			}
			catch (Exception ex5)
			{
				idHorse = -1;
			}
			GameScreen.player.idHorse = idHorse;
			short idHair = -1;
			try
			{
				idHair = msg.reader().readShort();
			}
			catch (Exception ex6)
			{
				idHair = -1;
			}
			GameScreen.player.idHair = idHair;
			short idWing = -1;
			try
			{
				idWing = msg.reader().readShort();
			}
			catch (Exception ex7)
			{
				idHair = -1;
			}
			GameScreen.player.idWing = idWing;
			short idName = -1;
			try
			{
				idName = msg.reader().readShort();
			}
			catch (Exception ex8)
			{
				idName = -1;
			}
			GameScreen.player.idName = idName;
			short idBody = -1;
			try
			{
				idBody = msg.reader().readShort();
			}
			catch (Exception ex9)
			{
			}
			GameScreen.player.idBody = idBody;
			short idLeg = -1;
			try
			{
				idLeg = msg.reader().readShort();
			}
			catch (Exception ex10)
			{
			}
			GameScreen.player.idLeg = idLeg;
			short idBienhinh = -1;
			try
			{
				idBienhinh = msg.reader().readShort();
			}
			catch (Exception ex11)
			{
			}
			GameScreen.player.idBienhinh = idBienhinh;
		}
		catch (Exception ex12)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex12.ToString()
			}));
		}
	}

	// Token: 0x06000A83 RID: 2691 RVA: 0x000AE32C File Offset: 0x000AC52C
	public void objectMove(Message msg)
	{
		try
		{
			while (msg.reader().available() > 0)
			{
				sbyte b = msg.reader().readByte();
				short typeMonster = msg.reader().readShort();
				short id = msg.reader().readShort();
				short num = msg.reader().readShort();
				short num2 = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				if (LoadMapScreen.isNextMap)
				{
					if ((int)b2 != 127)
					{
						MainObject mainObject = MainObject.get_Object((int)id, b);
						if (mainObject == null)
						{
							if ((int)b == 1)
							{
								MainMonster.createMonster((int)id, (int)num, (int)num2, (int)typeMonster);
								GlobalService.gI().monster_info(id);
							}
							else if ((int)b == 0)
							{
								Other_Players other_Players = new Other_Players((int)id, b, string.Empty, (int)num, (int)num2);
								other_Players.Direction = CRes.random(4);
								other_Players.setWearingListChar(null);
								GameScreen.addPlayer(other_Players);
								GlobalService.gI().char_info(id);
								other_Players.timeRePlayerInfo = GameCanvas.timeNow;
							}
							else if ((int)b == 2)
							{
								GameScreen.addPlayer(new Other_Players((int)id, b, string.Empty, (int)num, (int)num2)
								{
									isObject = true
								});
								GlobalService.gI().new_npc_info(id);
							}
						}
						else
						{
							if (mainObject.isRemove)
							{
								break;
							}
							if (mainObject == GameScreen.player)
							{
								if (CRes.abs(GameScreen.player.x - (int)num) > 24 || CRes.abs(GameScreen.player.y - (int)num2) > 24)
								{
									Player.isLockKey = true;
									Player.isSendMove = false;
									GameScreen.player.toX = GameScreen.player.x;
									GameScreen.player.toY = GameScreen.player.y;
									GameScreen.player.xStopMove = (int)num;
									GameScreen.player.yStopMove = (int)num2;
									try
									{
										GameScreen.player.posTransRoad = GameCanvas.game.updateFindRoad((int)num / LoadMap.wTile, (int)num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 20);
									}
									catch (Exception ex)
									{
										mainObject.x = (int)num;
										mainObject.y = (int)num2;
										GameScreen.player.posTransRoad = null;
										Player.isLockKey = false;
										Player.isSendMove = true;
									}
								}
								if (GameScreen.player.posTransRoad == null || GameScreen.player.posTransRoad.Length >= 20)
								{
									mainObject.x = (int)num;
									mainObject.y = (int)num2;
									GameScreen.player.posTransRoad = null;
									Player.isLockKey = false;
									Player.isSendMove = true;
								}
							}
							else if ((int)mainObject.typeObject == 1)
							{
								mainObject.toX = (int)num;
								mainObject.toY = (int)num2;
								mainObject.isMove = true;
								if ((int)b2 == 126)
								{
									if ((int)mainObject.StepMovebocap != 1)
									{
										GameScreen.addEffectEndKill(54, mainObject.x, mainObject.y - 20);
									}
									mainObject.x = mainObject.toX;
									mainObject.y = mainObject.toY;
									mainObject.isMove = false;
									mainObject.StepMovebocap = -1;
								}
								else if ((int)b2 == 125)
								{
									mainObject.StepMovebocap = 0;
								}
							}
							else if (mainObject.Action != 2 && mainObject.Action != 4 && mainObject.KillFire == -1)
							{
								mainObject.toX = (int)num;
								mainObject.toY = (int)num2;
								mainObject.countCharStand = 0;
								if (Player.party != null)
								{
									Player.party.setPos(mainObject.name, (int)num, (int)num2, mainObject.hp, mainObject.maxHp);
								}
							}
						}
					}
					else if ((int)b2 == 127)
					{
						MainObject mainObject2 = MainObject.get_Object((int)id, b);
						if (mainObject2 != null)
						{
							if (mainObject2.isRemove)
							{
								break;
							}
							mainObject2.isMoveOut = true;
							mainObject2.xMoveOut = (int)num;
							mainObject2.yMoveOut = (int)num2;
						}
						else if ((int)b == 0)
						{
							Other_Players other_Players2 = new Other_Players((int)id, b, string.Empty, (int)num, (int)num2);
							other_Players2.Direction = CRes.random(4);
							other_Players2.setWearingListChar(null);
							GameScreen.addPlayer(other_Players2);
							GlobalService.gI().char_info(id);
							other_Players2.timeRePlayerInfo = GameCanvas.timeNow;
							mainObject2.isMoveOut = true;
							mainObject2.xMoveOut = (int)num;
							mainObject2.yMoveOut = (int)num2;
						}
					}
				}
			}
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x06000A84 RID: 2692 RVA: 0x000AE7CC File Offset: 0x000AC9CC
	public void newNPCInfo(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string name = msg.reader().readUTF();
			int num = msg.reader().readInt();
			int hp = msg.reader().readInt();
			short lv = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			short num3 = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			string text = msg.reader().readUTF();
			short num4 = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 2);
			if (mainObject == null || mainObject.isRemove)
			{
				mSystem.outz("New npc is null");
			}
			else
			{
				mainObject.name = name;
				mainObject.x = (int)num2;
				mainObject.y = (int)num3;
				mainObject.toX = (int)num2;
				mainObject.toY = (int)num3;
				mainObject.Lv = lv;
				mainObject.maxHp = num;
				mainObject.hp = hp;
				mainObject.hpEffect = num / 10;
				mainObject.imageId = (int)num4;
				mainObject.typeObject = 2;
				if (num4 == -1)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					sbyte b5 = msg.reader().readByte();
					mainObject.setInfo((int)b3, (int)b4, (int)b5);
					sbyte[] array = new sbyte[12];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = -1;
					}
					sbyte b6 = msg.reader().readByte();
					for (int j = 0; j < (int)b6; j++)
					{
						sbyte b7 = msg.reader().readByte();
						sbyte b8 = msg.reader().readByte();
						array[(int)b7] = b8;
					}
					mainObject.setWearingListChar(array);
					short num5 = msg.reader().readShort();
					if (num5 != -1)
					{
						int idClan = msg.reader().readInt();
						string shortname = msg.reader().readUTF();
						sbyte chucvu = msg.reader().readByte();
						mainObject.myClan = new MainClan(idClan, num5, shortname, chucvu);
					}
					else
					{
						mainObject.myClan = null;
					}
				}
				else
				{
					sbyte numFrame = msg.reader().readByte();
					short idBigAvatar = msg.reader().readShort();
					mainObject.numFrame = numFrame;
					mainObject.IdBigAvatar = (int)idBigAvatar;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A85 RID: 2693 RVA: 0x000AEA60 File Offset: 0x000ACC60
	public void charInfo(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			string text = msg.reader().readUTF();
			text = text.ToLower();
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			sbyte clazz = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			sbyte b4 = msg.reader().readByte();
			short lv = msg.reader().readShort();
			int hp = msg.reader().readInt();
			int num3 = msg.reader().readInt();
			sbyte typePk = msg.reader().readByte();
			short pointPk = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			if (mainObject != null && !mainObject.isRemove)
			{
				if ((int)b == -126 && text.EndsWith(","))
				{
					mainObject.iscuop = true;
					text = text.Substring(0, text.Length - 1);
				}
				mainObject.name = text;
				mainObject.toX = (int)num;
				mainObject.toY = (int)num2;
				mainObject.clazz = clazz;
				mainObject.weapon_frame = 0;
				mainObject.Lv = lv;
				mainObject.maxHp = num3;
				mainObject.hp = hp;
				mainObject.typePk = typePk;
				mainObject.hpEffect = num3 / 10;
				mainObject.pointPk = pointPk;
				mainObject.isBot = b;
				if (mainObject.isNPC())
				{
					mainObject.nameGiaotiep = mainObject.name;
					mainObject.infoObject = T.tuchoi;
					MiniMap.addNPCMini(new NPCMini((int)mainObject.isBot, (int)num, (int)num2));
				}
				if ((int)b == -126)
				{
					mainObject.typeSpec = 1;
				}
				mainObject.setInfo((int)b2, (int)b3, (int)b4);
				if (Player.party != null)
				{
					Player.party.setObjParty(mainObject);
				}
				if (mainObject.hp <= 0)
				{
					mainObject.hp = 0;
					mainObject.mp = 0;
					mainObject.resetAction();
					mainObject.Action = 4;
					mainObject.timedie = GameCanvas.timeNow;
				}
				sbyte[] array = new sbyte[12];
				short[][] array2 = new short[12][];
				for (int i = 0; i < array2.Length; i++)
				{
					array2[i] = new short[3];
				}
				for (int j = 0; j < array2.Length; j++)
				{
					for (int k = 0; k < array2[j].Length; k++)
					{
						array2[j][k] = -1;
					}
				}
				for (int l = 0; l < array.Length; l++)
				{
					array[l] = -1;
				}
				sbyte b5 = msg.reader().readByte();
				mainObject.removeAllEffCharWearing();
				mSystem.outz(b5 + "  size ");
				for (int m = 0; m < (int)b5; m++)
				{
					sbyte b6 = msg.reader().readByte();
					sbyte b7 = msg.reader().readByte();
					array[(int)b6] = b7;
					sbyte b8 = msg.reader().readByte();
					for (int n = 0; n < (int)b8; n++)
					{
						array2[(int)b6][n] = msg.reader().readShort();
					}
					short num4 = msg.reader().readShort();
					if (num4 != -1)
					{
						if ((int)b6 == 0)
						{
							mainObject.addEffectCharWearing(1, (int)num4);
						}
						else if ((int)b6 == 2)
						{
							mainObject.addEffectCharWearing(0, (int)num4);
						}
						else if ((int)b6 == 1)
						{
							mainObject.addEffectCharWearing(2, (int)num4);
						}
					}
				}
				mainObject.setWearingListChar(array);
				mainObject.setArrayGemKham(array2);
				short num5 = msg.reader().readShort();
				if (num5 >= 0)
				{
					int idClan = msg.reader().readInt();
					mainObject.myClan = new MainClan(idClan, num5, msg.reader().readUTF(), msg.reader().readByte());
				}
				else
				{
					mainObject.myClan = null;
				}
				sbyte b9 = msg.reader().readByte();
				if ((int)b9 >= 0)
				{
					sbyte imageId = msg.reader().readByte();
					sbyte nFrame = msg.reader().readByte();
					MainObject mainObject2 = GameScreen.findOwner(mainObject);
					if (mainObject2 != null)
					{
						GameScreen.Vecplayers.removeElement(mainObject2);
					}
					Pet pet = Pet.createPet(mainObject, (short)b9, nFrame, imageId);
					if (pet != null)
					{
						GameScreen.addPlayer(pet);
					}
				}
				sbyte b10 = msg.reader().readByte();
				short[] array3 = new short[(int)b10];
				for (int num6 = 0; num6 < (int)b10; num6++)
				{
					array3[num6] = -1;
					array3[num6] = msg.reader().readShort();
				}
				mainObject.idPartFashion = array3;
				try
				{
					mainObject.idImageHenshin = msg.reader().readShort();
				}
				catch (Exception ex)
				{
				}
				sbyte typeMount = msg.reader().readByte();
				bool isFootSnow = msg.reader().readBool();
				mainObject.isFootSnow = isFootSnow;
				mainObject.typeMount = typeMount;
				sbyte typefocus = msg.reader().readByte();
				sbyte typefire = msg.reader().readByte();
				mainObject.typefocus = typefocus;
				mainObject.typefire = typefire;
				short idMatna = -1;
				try
				{
					idMatna = msg.reader().readShort();
				}
				catch (Exception ex2)
				{
					idMatna = -1;
				}
				mainObject.idMatna = idMatna;
				try
				{
					sbyte b11 = msg.reader().readByte();
					if ((int)b11 == 1)
					{
						mainObject.paintMatnaTruocNon = true;
					}
					else
					{
						mainObject.paintMatnaTruocNon = false;
					}
				}
				catch (Exception ex3)
				{
				}
				short idPhiPhong = -1;
				try
				{
					idPhiPhong = msg.reader().readShort();
				}
				catch (Exception ex4)
				{
					idPhiPhong = -1;
				}
				mainObject.idPhiPhong = idPhiPhong;
				short idWeaPon = -1;
				try
				{
					idWeaPon = msg.reader().readShort();
				}
				catch (Exception ex5)
				{
					idWeaPon = -1;
				}
				mainObject.idWeaPon = idWeaPon;
				short idHorse = -1;
				try
				{
					idHorse = msg.reader().readShort();
				}
				catch (Exception ex6)
				{
					idHorse = -1;
				}
				mainObject.idHorse = idHorse;
				short idHair = -1;
				try
				{
					idHair = msg.reader().readShort();
				}
				catch (Exception ex7)
				{
					idHair = -1;
				}
				mainObject.idHair = idHair;
				short idWing = -1;
				try
				{
					idWing = msg.reader().readShort();
				}
				catch (Exception ex8)
				{
					idWing = -1;
				}
				mainObject.idWing = idWing;
				short idName = -1;
				try
				{
					idName = msg.reader().readShort();
				}
				catch (Exception ex9)
				{
					idName = -1;
				}
				mainObject.idName = idName;
				short idBody = -1;
				try
				{
					idBody = msg.reader().readShort();
				}
				catch (Exception ex10)
				{
				}
				mainObject.idBody = idBody;
				short idLeg = -1;
				try
				{
					idLeg = msg.reader().readShort();
				}
				catch (Exception ex11)
				{
				}
				mainObject.idLeg = idLeg;
				short idBienhinh = -1;
				try
				{
					idBienhinh = msg.reader().readShort();
				}
				catch (Exception ex12)
				{
				}
				mainObject.idBienhinh = idBienhinh;
			}
		}
		catch (Exception ex13)
		{
		}
	}

	// Token: 0x06000A86 RID: 2694 RVA: 0x000AF2B0 File Offset: 0x000AD4B0
	public void monsterInfo(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			short num = (short)msg.reader().readUnsignedByte();
			short toX = msg.reader().readShort();
			short toY = msg.reader().readShort();
			int hp = msg.reader().readInt();
			int maxHp = msg.reader().readInt();
			sbyte id2 = msg.reader().readByte();
			int num2 = msg.reader().readInt();
			MainMonster mainMonster = (MainMonster)MainObject.get_Object((int)id, 1);
			if (mainMonster != null && !mainMonster.isRemove)
			{
				mainMonster.Lv = num;
				mainMonster.toX = (int)toX;
				mainMonster.toY = (int)toY;
				mainMonster.hp = hp;
				mainMonster.maxHp = maxHp;
				mainMonster.isInfo = true;
				mainMonster.setLvmonster((int)num);
				mainMonster.timeReveice = num2;
				if (num2 == -2)
				{
					mainMonster.typeBoss = 1;
				}
				if (num2 == -3)
				{
					string text = msg.reader().readUTF();
					mSystem.outz("capchar day");
					mainMonster.typeBoss = 2;
					MainObject.vecCapchar.removeAllElements();
					MainObject.strCapchar = string.Empty;
					GameScreen.ObjFocus = mainMonster;
					GameCanvas.addInfoChar(T.helpCapchar);
				}
				if (num2 == -4)
				{
					mainMonster.typeBoss = 3;
					mainMonster.xPhoBang = (int)msg.reader().readShort();
					mainMonster.yPhoBang = (int)msg.reader().readShort();
				}
				if (num2 == -5)
				{
					mainMonster.typeBoss = 4;
					mainMonster.xPhoBang = (int)msg.reader().readShort();
					mainMonster.yPhoBang = (int)msg.reader().readShort();
				}
				short num3 = msg.reader().readShort();
				if (num3 >= 0)
				{
					int idClan = msg.reader().readInt();
					mainMonster.myClan = new MainClan(idClan, num3, msg.reader().readUTF(), msg.reader().readByte());
				}
				else
				{
					mainMonster.myClan = null;
				}
				mainMonster.skillDefault = new Monster_Skill(id2);
				if (mainMonster.hp <= 0)
				{
					mainMonster.hp = 0;
					mainMonster.mp = 0;
					if (mainMonster.Action != 4)
					{
						MainObject.startDeadFly(mainMonster, GameScreen.player.ID, CRes.random(3));
					}
				}
				if (mainMonster.typeMonster == 7)
				{
					MiniMap.addMonMini(mainMonster.ID, 1);
					mainMonster.name = msg.reader().readUTF();
				}
				sbyte b = msg.reader().readByte();
				sbyte b2 = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				mainMonster.isServerControl = ((int)b == 1);
				mainMonster.vMax = (int)b2;
				mainMonster.Direction = (int)b3;
				string text2 = msg.reader().readUTF();
				mainMonster.nameowner = text2;
				if (!text2.Equals(string.Empty) || mainMonster.isMiNuong())
				{
					mainMonster.setspeedVantieu((int)b2);
				}
				long timelive = msg.reader().readLong();
				mainMonster.colorName = msg.reader().readByte();
				mainMonster.setTimelive(timelive);
				EffectMonster.addEffectMonster(mainMonster);
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A87 RID: 2695 RVA: 0x000AF640 File Offset: 0x000AD840
	public void playerExit(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			if ((int)num != GameScreen.player.ID)
			{
				MainObject mainObject = MainObject.get_Object((int)num, 0);
				if (mainObject != null && !mainObject.isRemove)
				{
					Pet pet = (Pet)MainObject.get_Object(mainObject.ID, 9);
					if (pet != null)
					{
						GameScreen.addEffectEndKill(35, pet.x, pet.y - 20);
						pet.isStop = true;
					}
					GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
					mainObject.isStop = true;
				}
				MainObject mainObject2 = MainObject.get_Object((int)num, 1);
				if (mainObject2 != null && !mainObject2.isRemove)
				{
					GameScreen.addEffectEndKill(35, mainObject2.x, mainObject2.y - 20);
					mainObject2.isStop = true;
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A88 RID: 2696 RVA: 0x000AF770 File Offset: 0x000AD970
	public void changeMap(Message msg)
	{
		bool flag = false;
		try
		{
			GameCanvas.game.wRec = 0;
			GameCanvas.game.isFullScreen = false;
			GameScreen.infoGame.idCharLoiDai1 = -1;
			GameScreen.infoGame.idCharLoiDai2 = -1;
			if (Main.isWindowsPhone)
			{
				MiniMap.isStartMiniMap = false;
			}
			LoadMapScreen.isNextMap = false;
			if ((int)Player.isAutoFire > -1)
			{
				Player.setCurAutoFire();
			}
			if (GameCanvas.currentScreen != GameCanvas.load)
			{
				GameCanvas.load.Show();
			}
			GameScreen.Remove_ChangeMap();
			GameScreen.RemoveLoadMap();
			GameCanvas.loadmap.idMap = (int)msg.reader().readShort();
			GameCanvas.worldmap.setPosPlayer(GameCanvas.loadmap.idMap);
			GameScreen.infoGame.setCountTimeHS(GameCanvas.loadmap.idMap, mSystem.currentTimeMillis(), 30);
			GameScreen.player.x = (int)(msg.reader().readShort() * 24);
			GameScreen.player.y = (int)(msg.reader().readShort() * 24);
			GameScreen.player.xStand = GameScreen.player.x;
			GameScreen.player.yStand = GameScreen.player.y;
			GameScreen.player.resetMove();
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			if (GameScreen.pet != null)
			{
				GameScreen.pet.x = GameScreen.player.x;
				GameScreen.pet.y = GameScreen.player.y;
				GameScreen.pet.clearWayPoints();
			}
			GameCanvas.loadmap.idMapMini = (int)msg.reader().readShort();
			GameCanvas.loadmap.nameMap = msg.reader().readUTF();
			short num = msg.reader().readShort();
			sbyte[] mbyte = null;
			if (num > 0)
			{
				mbyte = new sbyte[(int)num];
				msg.reader().read(ref mbyte);
			}
			GameCanvas.loadmap.loadmap(mbyte);
			sbyte b = msg.reader().readByte();
			if ((int)b >= 0)
			{
				short h = msg.reader().readShort();
				GameCanvas.mapBack = new MapBackGround();
				GameCanvas.mapBack.setBackGround(b, h);
			}
			else
			{
				GameCanvas.mapBack = null;
			}
			short num2 = msg.reader().readShort();
			GameCanvas.load.mItemMap = null;
			if (num2 > 0)
			{
				GameCanvas.load.mItemMap = new sbyte[(int)num2];
				msg.reader().read(ref GameCanvas.load.mItemMap);
				GameCanvas.loadmap.load_ItemMap(GameCanvas.load.mItemMap);
			}
			GameScreen.player.useShip = false;
			if (GameCanvas.loadmap.idMap == 19)
			{
				GameScreen.infoGame.eff = new EffectAuto(50, 1080, 96, 0, 0, 1, 0);
			}
			else if (GameCanvas.loadmap.idMap == 67)
			{
				GameScreen.infoGame.eff = new EffectAuto(50, 360, 672, 0, 0, 1, 0);
			}
			if (Main.isWindowsPhone)
			{
				MiniMap.isStartMiniMap = true;
			}
			LoadMap.me.idMap = GameCanvas.loadmap.idMap;
			LoadMap.vecPointChange.removeAllElements();
			sbyte b2 = msg.reader().readByte();
			for (int i = 0; i < (int)b2; i++)
			{
				Point point = new Point();
				point.x = (int)msg.reader().readShort();
				point.y = (int)msg.reader().readShort();
				point.name = msg.reader().readUTF();
				int num3 = 100;
				if (point.x < num3)
				{
					point.dis = 0;
					point.x2 = point.x - 8;
					point.y2 = point.y - 18;
					point.f = 0;
					point.vx = -1;
				}
				else if (point.x > GameCanvas.loadmap.mapW * LoadMap.wTile - num3)
				{
					point.dis = 1;
					point.f = 1;
					point.x2 = point.x + 8;
					point.y2 = point.y - 18;
					point.vx = 1;
				}
				else if (point.y < GameCanvas.loadmap.mapW * LoadMap.wTile / 2)
				{
					point.y -= 10;
					point.dis = 2;
					point.f = 2;
					point.x2 = point.x;
					point.y2 = point.y + 10;
					point.vy = -1;
				}
				else
				{
					point.dis = 3;
					point.f = 2;
					point.x2 = point.x;
					point.y2 = point.y - 20;
					point.vy = 1;
				}
				LoadMap.vecPointChange.addElement(point);
			}
			try
			{
				GameCanvas.minimap.setSize();
			}
			catch (Exception ex)
			{
				mSystem.println("----loi readmess minimap.setSize:" + ex.ToString());
			}
			sbyte b3 = msg.reader().readByte();
			LoadMap.Area = msg.reader().readByte();
			GameCanvas.end_Dialog();
			GameCanvas.clearKeyHold();
			GameCanvas.load.isTele = false;
			if ((int)b3 == 1)
			{
				GameCanvas.load.isTele = true;
			}
			LoadMap.typeMap = msg.reader().readByte();
			if ((int)LoadMap.typeMap == LoadMap.MAP_PET_CONTAINER)
			{
				GameScreen.isInPetArea = true;
			}
			else
			{
				GameScreen.isInPetArea = false;
			}
			LoadMapScreen.isNextMap = true;
			GameCanvas.timenextLogin = 0L;
			GameCanvas.countLogin = 0L;
			try
			{
				GameScreen.isMapLang = msg.reader().readBool();
				GameScreen.isShowHoiSinh = msg.reader().readBool();
			}
			catch (Exception ex2)
			{
				GameScreen.isShowHoiSinh = false;
				GameScreen.isMapLang = false;
			}
		}
		catch (Exception ex3)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex3.ToString()
			}));
			if (flag)
			{
				LoadMapScreen.isNextMap = true;
			}
		}
	}

	// Token: 0x06000A89 RID: 2697 RVA: 0x000AFDCC File Offset: 0x000ADFCC
	public void fireMonster(Message msg)
	{
		try
		{
			this.Fire_Object(msg, 0, 1);
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A8A RID: 2698 RVA: 0x000AFE40 File Offset: 0x000AE040
	public void charWearing(Message msg)
	{
		MainObject mainObject = null;
		try
		{
			short id = msg.reader().readShort();
			mainObject = MainObject.get_Object((int)id, 0);
			if (mainObject != null && !mainObject.isRemove)
			{
				sbyte b = msg.reader().readByte();
				sbyte[] array = new sbyte[(int)b];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = -1;
				}
				if (mainObject == GameScreen.player)
				{
					Item.VecEquipPlayer.clear();
					if (GameScreen.pet != null)
					{
						GameScreen.Vecplayers.removeElement(GameScreen.pet);
					}
					for (int j = 0; j < mainObject.slotGem.Length; j++)
					{
						mainObject.slotGem[j] = -1;
					}
				}
				bool isFootSnow = false;
				mainObject.removeAllEffCharWearing();
				for (int k = 0; k < (int)b; k++)
				{
					sbyte b2 = msg.reader().readByte();
					if ((int)b2 > -1)
					{
						string itemName = msg.reader().readUTF();
						sbyte b3 = msg.reader().readByte();
						sbyte b4 = msg.reader().readByte();
						short imageId = msg.reader().readShort();
						sbyte b5 = msg.reader().readByte();
						sbyte plusItem = msg.reader().readByte();
						short lvItem = msg.reader().readShort();
						sbyte b6 = msg.reader().readByte();
						array[k] = b5;
						sbyte b7 = msg.reader().readByte();
						MainInfoItem[] array2 = new MainInfoItem[(int)b7];
						for (int l = 0; l < (int)b7; l++)
						{
							int num = (int)msg.reader().readUnsignedByte();
							array2[l] = new MainInfoItem(num, msg.reader().readInt());
							if ((int)b2 == 8 && num == 67)
							{
								isFootSnow = true;
							}
						}
						sbyte isLock = msg.reader().readByte();
						MainItem mainItem = MainItem.MainItem_Item((int)b2, itemName, (int)imageId, plusItem, (int)b6, (int)b3, 3, array2, (int)b4, false, -1, 0L, lvItem, 0, 0, 0, 0, isLock);
						if (mainObject == GameScreen.player)
						{
							Item.VecEquipPlayer.put(string.Empty + b2, mainItem);
							if (mainItem.moreContenGem.size() > 0)
							{
								for (int m = 0; m < mainItem.moreContenGem.size(); m++)
								{
									InfocontenNew infocontenNew = (InfocontenNew)mainItem.moreContenGem.elementAt(m);
									if (infocontenNew.idimage >= 23 && infocontenNew.idimage <= 27)
									{
										mainObject.slotGem[m] = 0;
									}
									else if (infocontenNew.idimage >= 28 && infocontenNew.idimage <= 32)
									{
										mainObject.slotGem[m] = 1;
									}
									else if (infocontenNew.idimage == -1)
									{
										mainObject.slotGem[m] = -1;
									}
								}
							}
							if ((int)b4 == 1)
							{
								foreach (MainInfoItem mainInfoItem in array2)
								{
									if (mainInfoItem.id == 71)
									{
										mainObject.addEffectCharWearing(2, mainInfoItem.value);
									}
								}
							}
							if ((int)b4 == 0)
							{
								foreach (MainInfoItem mainInfoItem2 in array2)
								{
									if (mainInfoItem2.id == 71)
									{
										mainObject.addEffectCharWearing(1, mainInfoItem2.value);
									}
								}
							}
							if ((int)b4 == 2)
							{
								foreach (MainInfoItem mainInfoItem3 in array2)
								{
									if (mainInfoItem3.id == 71)
									{
										mainObject.addEffectCharWearing(0, mainInfoItem3.value);
									}
								}
							}
						}
					}
					else
					{
						array[k] = -1;
					}
				}
				mainObject.isFootSnow = isFootSnow;
				int catagory = 9;
				sbyte b8 = 14;
				sbyte b9 = msg.reader().readByte();
				sbyte imageId2 = 0;
				sbyte nFrame = 6;
				if ((int)b9 > -1)
				{
					string itemName2 = msg.reader().readUTF();
					sbyte b10 = msg.reader().readByte();
					short level = msg.reader().readShort();
					short experience = msg.reader().readShort();
					sbyte b11 = msg.reader().readByte();
					sbyte b12 = msg.reader().readByte();
					imageId2 = b12;
					sbyte b13 = msg.reader().readByte();
					nFrame = b13;
					sbyte b14 = msg.reader().readByte();
					int age = msg.reader().readInt();
					short growPoint = msg.reader().readShort();
					short maxgrow = msg.reader().readShort();
					short str = msg.reader().readShort();
					short agi = msg.reader().readShort();
					short hea = msg.reader().readShort();
					short spi = msg.reader().readShort();
					short maxtiemnang = msg.reader().readShort();
					sbyte b15 = msg.reader().readByte();
					MainInfoItem[] array3 = new MainInfoItem[(int)b15];
					for (int num4 = 0; num4 < (int)b15; num4++)
					{
						int id2 = (int)msg.reader().readUnsignedByte();
						int value = msg.reader().readInt();
						int maxDam = msg.reader().readInt();
						array3[num4] = new MainInfoItem(id2, value, maxDam);
					}
					PetItem petItem = new PetItem((int)b9, itemName2, (int)b11, (int)b14, (int)b10, catagory, array3, (int)b8, level, (int)b11, b13, b12);
					petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
					sbyte b16 = msg.reader().readByte();
					if ((int)b16 == 1)
					{
						int timeDefault = msg.reader().readInt();
						string s = msg.reader().readUTF();
						petItem.setTimeUser(timeDefault, long.Parse(s));
					}
					if (mainObject == GameScreen.player)
					{
						Item.VecEquipPlayer.put(string.Empty + b9, petItem);
					}
					array[5] = b11;
					if (GameCanvas.subDialog != null && GameCanvas.subDialog.type == 14 && (int)MsgDialog.isInven_Equip == (int)MsgDialog.EQUIP)
					{
						MsgDialog.pet = petItem;
					}
				}
				mainObject.setWearingEquip(array);
				if (mainObject.Equals(GameScreen.player))
				{
					Pet pet = null;
					if (GameScreen.player.pet != -1)
					{
						pet = Pet.createPet(GameScreen.player, (short)GameScreen.player.pet, nFrame, imageId2);
					}
					GameScreen.pet = pet;
					if (GameScreen.pet != null)
					{
						GameScreen.addPlayer(GameScreen.pet);
					}
				}
				sbyte b17 = msg.reader().readByte();
				short[] array4 = new short[(int)b17];
				for (int num5 = 0; num5 < (int)b17; num5++)
				{
					array4[num5] = -1;
					array4[num5] = msg.reader().readShort();
				}
				mainObject.idPartFashion = array4;
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi(" wearing ");
			if (GameScreen.player != null)
			{
				if (mainObject == GameScreen.player)
				{
					Session_ME.gI().close();
					mVector mVector = new mVector("ReadMessenge vec2");
					if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
					{
						mVector.addElement(new iCommand(T.again, 0));
					}
					mVector.addElement(new iCommand(T.exit, 6));
					GameCanvas.start_Select_Dialog(T.disconnect, mVector);
					if (GameScreen.player != null)
					{
						GameScreen.player.resetAction();
					}
				}
				else
				{
					mainObject.isRemove = true;
				}
			}
		}
	}

	// Token: 0x06000A8B RID: 2699 RVA: 0x000B05B8 File Offset: 0x000AE7B8
	public void dieMonster(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num2, 1);
			if (GameScreen.help.setStep_Next(1, 2) && (int)num == GameScreen.player.ID)
			{
				GameScreen.help.Next++;
				GameScreen.help.setNext();
				Player.isAutoFire = -1;
			}
			if (mainObject != null && !mainObject.isRemove)
			{
				if (mainObject.hp != 0)
				{
					mainObject.hp = 0;
				}
				mainObject.coutEff = 100;
				if (mainObject.Action == 4 || mainObject.isDie)
				{
					if ((int)mainObject.typeBoss != 0)
					{
						mainObject.isRemove = true;
						if ((int)mainObject.typeBoss == 2)
						{
							MainObject.imgCapchar = null;
						}
					}
					mainObject.timedie = GameCanvas.timeNow;
				}
				else
				{
					mainObject.hp = 0;
					if ((int)mainObject.typeBoss != 0)
					{
						mainObject.isRemove = true;
						if ((int)mainObject.typeBoss == 2)
						{
							MainObject.imgCapchar = null;
						}
					}
					else
					{
						MainObject.startDeadFly((MainMonster)mainObject, (int)num, CRes.random(3));
					}
					if ((int)num == GameScreen.player.ID && mainObject.timeReveice >= 0)
					{
						MainQuest.updateQuestKillMonster((int)num2);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A8C RID: 2700 RVA: 0x000B076C File Offset: 0x000AE96C
	public void petAttack(Message msg)
	{
		try
		{
			sbyte skillId = msg.reader().readByte();
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			mVector mVector = new mVector("ReadMessenge vecObjectBeAttacked");
			for (int i = 0; i < (int)b; i++)
			{
				short id2 = msg.reader().readShort();
				int hpShow = msg.reader().readInt();
				int hpLast = msg.reader().readInt();
				Monster_Skill skill = new Monster_Skill(14);
				Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(id2, tem, skill);
				object_Effect_Skill.setHP(hpShow, hpLast);
				MainObject mainObject = MainObject.get_Object((int)id2, tem);
				if (mainObject != null && !mainObject.isRemove)
				{
					mVector.addElement(object_Effect_Skill);
				}
			}
			Pet pet = (Pet)MainObject.get_Object((int)id, 9);
			MainObject mainObject2 = MainObject.get_Object((int)id, 0);
			int hp = msg.reader().readInt();
			int mp = msg.reader().readInt();
			if (mainObject2 != null)
			{
				mainObject2.hp = hp;
				mainObject2.mp = mp;
			}
			if (pet != null)
			{
				pet.vecObjskill = mVector;
				pet.setState(2);
				pet.initAttackState(skillId);
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A8D RID: 2701 RVA: 0x000B0904 File Offset: 0x000AEB04
	public void monsterFire(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			MainMonster mainMonster = (MainMonster)MainObject.get_Object((int)id, 1);
			if (mainMonster != null && !mainMonster.isRemove)
			{
				bool flag = mainMonster.isBossNew();
				if (mainMonster.Action == 4)
				{
					if (mainMonster.timeReveice < 0)
					{
						return;
					}
					mainMonster.Reveive();
				}
				mainMonster.isMove = false;
				mainMonster.vx = 0;
				mainMonster.vy = 0;
				if ((int)b == 1)
				{
					int hp = msg.reader().readInt();
					sbyte tem = msg.reader().readByte();
					sbyte b2 = msg.reader().readByte();
					mainMonster.hp = hp;
					if ((int)b2 > 0)
					{
						if (mainMonster.vecObjskill != null && mainMonster.vecObjskill.size() > 0)
						{
							Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
							mainMonster.IDAttack = (int)object_Effect_Skill.ID;
							if (mainMonster.skillDefault == null)
							{
								mainMonster.skillDefault = new Monster_Skill(14);
							}
							if (!flag)
							{
								object_Effect_Skill.skillMonster = mainMonster.skillDefault;
							}
							mainMonster.beginFire();
							mainMonster.beginSkill();
						}
						mVector mVector = new mVector("ReadMessenge vecBe");
						bool flag2 = false;
						mVector mVector2 = new mVector("ReadMessenge allPlayerDie");
						for (int i = 0; i < (int)b2; i++)
						{
							short id2 = msg.reader().readShort();
							int hpShow = msg.reader().readInt();
							int num = msg.reader().readInt();
							sbyte id3 = msg.reader().readByte();
							Monster_Skill skill = new Monster_Skill(id3);
							Object_Effect_Skill object_Effect_Skill2 = new Object_Effect_Skill(id2, tem, skill);
							object_Effect_Skill2.setHP(hpShow, num);
							sbyte b3 = msg.reader().readByte();
							object_Effect_Skill2.mEffTypePlus = new int[(int)b3];
							object_Effect_Skill2.mEff_HP_Plus = new int[(int)b3];
							for (int j = 0; j < (int)b3; j++)
							{
								object_Effect_Skill2.mEffTypePlus[j] = (int)msg.reader().readByte();
								object_Effect_Skill2.mEff_HP_Plus[j] = msg.reader().readInt();
							}
							MainObject mainObject = MainObject.get_Object((int)id2, tem);
							if (mainObject != null && !mainObject.isRemove)
							{
								mVector.addElement(object_Effect_Skill2);
								if (mainObject.hp > 0)
								{
									mainObject.hp = num;
								}
								if (mainObject.ID == GameScreen.player.ID)
								{
									int maxHp = GameScreen.player.maxHp;
									int num2 = num / maxHp * 100;
									GameScreen.player.setPainthit(4, num2 > 20);
								}
								if (mainObject.hp <= 0)
								{
									flag2 = true;
									mVector2.addElement(mainObject);
								}
							}
						}
						mainMonster.vecObjskill = mVector;
						mainMonster.hp = hp;
						mainMonster.isRunAttack = true;
						mainMonster.timeMaxMoveAttack = 3000;
						mainMonster.timeBeginMoveAttack = GameCanvas.timeNow;
						if (flag2 || (int)mainMonster.typeBoss == 1 || (int)mainMonster.typeBoss == 2)
						{
							Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
							mainMonster.IDAttack = (int)object_Effect_Skill3.ID;
							if (mainMonster.skillDefault == null)
							{
								mainMonster.skillDefault = new Monster_Skill(14);
							}
							if (!flag)
							{
								object_Effect_Skill3.skillMonster = mainMonster.skillDefault;
							}
							mainMonster.beginFire();
							mainMonster.beginSkill();
						}
						for (int k = 0; k < mVector2.size(); k++)
						{
							MainObject mainObject2 = (MainObject)mVector2.elementAt(k);
							mainObject2.resetAction();
							mainObject2.Action = 4;
							mainObject2.timedie = GameCanvas.timeNow;
							mainObject2.f = 0;
							GameScreen.addEffectEndKill(11, mainObject2.x, mainObject2.y);
						}
					}
				}
				else if ((int)b == 0)
				{
					if (mainMonster.vecObjskill != null && mainMonster.vecObjskill.size() > 0)
					{
						Object_Effect_Skill object_Effect_Skill4 = (Object_Effect_Skill)mainMonster.vecObjskill.elementAt(0);
						mainMonster.IDAttack = (int)object_Effect_Skill4.ID;
						if (mainMonster.skillDefault == null)
						{
							mainMonster.skillDefault = new Monster_Skill(14);
						}
						if (!flag)
						{
							object_Effect_Skill4.skillMonster = mainMonster.skillDefault;
						}
						mainMonster.beginFire();
						mainMonster.beginSkill();
					}
					mainMonster.isRunAttack = false;
					mainMonster.posTransRoad = null;
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A8E RID: 2702 RVA: 0x000B0DC8 File Offset: 0x000AEFC8
	public void loadImage(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			string path = string.Empty + num;
			sbyte[] array = new sbyte[msg.reader().available()];
			msg.reader().read(ref array);
			if (num == 9999)
			{
				MainObject.imgCapchar = mImage.createImage(array, 0, array.Length, path);
			}
			else
			{
				if (ObjectData.setIdOK(num))
				{
					SaveImageRMS.vecSaveImage.addElement(new idSaveImage(num, array));
				}
				mImage im = mImage.createImage(array, 0, array.Length, path);
				if (num >= 13000)
				{
					Item.HashImageItem.put(string.Empty + (int)(num - 2000), new MainImage(im));
				}
				else if (num >= 10700)
				{
					Item.HashImageMount.put(string.Empty + (int)(num - 10700), new MainImage(im));
				}
				else if (num >= 10200)
				{
					Pet.HashImagePet.put(string.Empty + (int)(num - 10200), new MainImage(im));
				}
				else if (num >= 10000)
				{
					Item.HashImagePetIcon.put(string.Empty + (int)(num - 10000), new MainImage(im));
				}
				else if (num >= 9500)
				{
					Item.HashImageIconArcheClan.put(string.Empty + (int)(num - 9500), new MainImage(im));
				}
				else if (num >= 7000)
				{
					Item.HashImageIconClan.put(string.Empty + (int)(num - 7000), new MainImage(im));
				}
				else if (num >= 6000)
				{
					Skill.hashImageSkill.put(string.Empty + (int)(num - 6000), new MainImage(im));
				}
				else if (num >= 5500)
				{
					Item.HashImageMaterial.put(string.Empty + (int)(num - 5500), new MainImage(im));
				}
				else if (num >= 5000)
				{
					Item.HashImageQuestItem.put(string.Empty + (int)(num - 5000), new MainImage(im));
				}
				else if (num >= 4000)
				{
					Item.HashImagePotion.put(string.Empty + (int)(num - 4000), new MainImage(im));
				}
				else if (num >= 3000)
				{
					GameScreen.HashImageNPC.put(string.Empty + (int)(num - 3000), new MainImage(im));
				}
				else if (num >= 2000)
				{
					Item.HashImageItem.put(string.Empty + (int)(num - 2000), new MainImage(im));
				}
				else if (num >= 1000)
				{
					MainMonster.HashImageMonster.put(string.Empty + (int)(num - 1000), new MainImage(im));
				}
				else
				{
					GameScreen.HashImageItemMap.put(string.Empty + num, new MainImage(im));
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A8F RID: 2703 RVA: 0x000B1198 File Offset: 0x000AF398
	public void charInventory(Message msg)
	{
		this.update_InVen_Or_Chest(msg, Item.VecInvetoryPlayer, MainTabNew.INVENTORY);
	}

	// Token: 0x06000A90 RID: 2704 RVA: 0x000B11AC File Offset: 0x000AF3AC
	public static sbyte getColorNum(short id, int num)
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item != null && item.ItemCatagory == 7 && item.Id == (int)id && item.numPotion >= num)
			{
				return 1;
			}
		}
		return 0;
	}

	// Token: 0x06000A91 RID: 2705 RVA: 0x000B1214 File Offset: 0x000AF414
	public static string getInfoNum(short id, int num)
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item != null && item.ItemCatagory == 7 && item.Id == (int)id)
			{
				return item.numPotion + "/" + num;
			}
		}
		return 0 + "/" + num;
	}

	// Token: 0x06000A92 RID: 2706 RVA: 0x000B12A0 File Offset: 0x000AF4A0
	public void npcInfo(Message msg)
	{
		try
		{
			sbyte typeShop = MainTabNew.SHOP;
			string nameCmd = string.Empty;
			bool isShop_Other_Player = false;
			string text = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			TabShopNew.isTabHopNL = false;
			if ((int)b < 0)
			{
				MainObject mainObject = MainObject.get_Object((int)b, 2);
				if (mainObject != null && !mainObject.isRemove)
				{
					mainObject.strChatPopup = text;
				}
			}
			else
			{
				GameCanvas.start_Ok_Dialog(T.danglaydulieu);
				short num = msg.reader().readShort();
				mVector mVector = new mVector("ReadMessenge vectorInfoNPC");
				sbyte isTypeShop = TabShopNew.NORMAL;
				sbyte isTypeShop2 = TabShopNew.NORMAL;
				if ((int)b == (int)ReadMessenge.SHOP_OTHER_PLAYER)
				{
					isShop_Other_Player = true;
					isTypeShop2 = TabShopNew.SHOP_STORE_OTHER_PLAYER;
					for (int i = 0; i < (int)num; i++)
					{
						sbyte b2 = msg.reader().readByte();
						if ((int)b2 == 3)
						{
							short num2 = msg.reader().readShort();
							string itemName = msg.reader().readUTF();
							sbyte b3 = msg.reader().readByte();
							sbyte b4 = msg.reader().readByte();
							short imageId = msg.reader().readShort();
							sbyte plusItem = msg.reader().readByte();
							short lvItem = msg.reader().readShort();
							sbyte b5 = msg.reader().readByte();
							sbyte b6 = msg.reader().readByte();
							MainInfoItem[] array = new MainInfoItem[(int)b6];
							for (int j = 0; j < (int)b6; j++)
							{
								int id = (int)msg.reader().readUnsignedByte();
								int value = msg.reader().readInt();
								array[j] = new MainInfoItem(id, value);
							}
							sbyte typeMoney = msg.reader().readByte();
							MainItem o = MainItem.MainItem_Item((int)num2, itemName, (int)imageId, plusItem, (int)b5, (int)b3, 3, array, (int)b4, false, num2, 0L, lvItem, 0, 0, 0, typeMoney, 0);
							mVector.addElement(o);
						}
						if ((int)b2 == 7)
						{
							short id2 = msg.reader().readShort();
							short num3 = msg.reader().readShort();
							sbyte b7 = msg.reader().readByte();
							sbyte b8 = msg.reader().readByte();
							long num4 = msg.reader().readLong();
							MainItem material = Item.getMaterial((int)id2);
							if (material != null)
							{
								MainItem o2 = MainItem.MainItem_Material((int)id2, material.itemName, material.imageId, 7, num4, 0, material.content, material.value, material.typeMaterial, num3, b7, b8);
								mVector.addElement(o2);
							}
							else
							{
								MainItem mainItem = new MainItem();
								mainItem.Id = (int)id2;
								mainItem.numPotion = (int)num3;
								mainItem.canSell = b7;
								mainItem.canTrade = b8;
								mainItem.priceItem = num4;
								mainItem.priceType = 0;
								mainItem.ItemCatagory = 7;
								Item.put_Material((int)id2);
								mVector.addElement(mainItem);
							}
						}
						if ((int)b2 == 4)
						{
							short id3 = msg.reader().readShort();
							short numPotion = msg.reader().readShort();
							long price = msg.reader().readLong();
							MainTemplateItem potionTem = MainTemplateItem.getPotionTem(id3);
							if (potionTem != null)
							{
								MainItem o3 = new MainItem(potionTem.ID, potionTem.IconId, potionTem.name, potionTem.contentPotion, (int)numPotion, 4, price, potionTem.typePotion, 0, 0, 0);
								mVector.addElement(o3);
							}
						}
					}
					short idSeller = msg.reader().readShort();
					TabShopNew.idSeller = idSeller;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_VANTIEU)
				{
					isTypeShop2 = TabShopNew.SHOP_VANTIEU;
					for (int k = 0; k < (int)num; k++)
					{
						short num5 = msg.reader().readShort();
						string itemName2 = msg.reader().readUTF();
						sbyte b9 = msg.reader().readByte();
						sbyte b10 = msg.reader().readByte();
						short imageId2 = msg.reader().readShort();
						long price2 = msg.reader().readLong();
						short lvItem2 = msg.reader().readShort();
						sbyte b11 = msg.reader().readByte();
						sbyte b12 = msg.reader().readByte();
						MainInfoItem[] array2 = new MainInfoItem[(int)b12];
						for (int l = 0; l < (int)b12; l++)
						{
							int id4 = (int)msg.reader().readUnsignedByte();
							int value2 = msg.reader().readInt();
							array2[l] = new MainInfoItem(id4, value2);
						}
						sbyte typeMoney2 = msg.reader().readByte();
						MainItem o4 = MainItem.MainItem_Item((int)num5, itemName2, (int)imageId2, 0, (int)b11, (int)b9, 3, array2, (int)b10, false, num5, price2, lvItem2, 0, 0, 0, typeMoney2, 0);
						mVector.addElement(o4);
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_POTION)
				{
					for (int m = 0; m < (int)num; m++)
					{
						short id5 = msg.reader().readShort();
						MainTemplateItem potionTem2 = MainTemplateItem.getPotionTem(id5);
						if (potionTem2 != null)
						{
							MainItem o5 = new MainItem(potionTem2.ID, potionTem2.IconId, potionTem2.name, potionTem2.contentPotion, 1, 4, potionTem2.PricePoition, potionTem2.typePotion, potionTem2.moneyType, 0, 0);
							mVector.addElement(o5);
						}
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_ITEM || (int)b == (int)ReadMessenge.WING || (int)b == (int)ReadMessenge.SHOP_ITEM_EVENT)
				{
					if ((int)b == (int)ReadMessenge.WING)
					{
						isTypeShop2 = TabShopNew.WING;
					}
					for (int n = 0; n < (int)num; n++)
					{
						short num6 = msg.reader().readShort();
						string itemName3 = msg.reader().readUTF();
						sbyte b13 = msg.reader().readByte();
						sbyte b14 = msg.reader().readByte();
						short imageId3 = msg.reader().readShort();
						long price3 = msg.reader().readLong();
						short lvItem3 = msg.reader().readShort();
						sbyte b15 = msg.reader().readByte();
						sbyte b16 = msg.reader().readByte();
						MainInfoItem[] array3 = new MainInfoItem[(int)b16];
						for (int num7 = 0; num7 < (int)b16; num7++)
						{
							int id6 = (int)msg.reader().readUnsignedByte();
							int value3 = msg.reader().readInt();
							array3[num7] = new MainInfoItem(id6, value3);
						}
						sbyte typeMoney3 = msg.reader().readByte();
						MainItem mainItem2 = MainItem.MainItem_Item((int)num6, itemName3, (int)imageId3, 0, (int)b15, (int)b13, 3, array3, (int)b14, false, num6, price3, lvItem3, 0, 0, 0, typeMoney3, 0);
						if ((int)b == (int)ReadMessenge.SHOP_ITEM_EVENT)
						{
							mainItem2.diaHoiEvent = msg.reader().readUTF();
						}
						mVector.addElement(mainItem2);
					}
					if ((int)b == (int)ReadMessenge.SHOP_ITEM_EVENT)
					{
						nameCmd = msg.reader().readUTF();
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_HAIR)
				{
					isTypeShop2 = TabShopNew.TOC;
					for (int num8 = 0; num8 < (int)num; num8++)
					{
						short num9 = msg.reader().readShort();
						string itemName4 = msg.reader().readUTF();
						short imageId4 = msg.reader().readShort();
						long price4 = msg.reader().readLong();
						sbyte priceType = msg.reader().readByte();
						sbyte b17 = msg.reader().readByte();
						MainInfoItem[] array4 = new MainInfoItem[(int)b17];
						for (int num10 = 0; num10 < (int)b17; num10++)
						{
							int id7 = (int)msg.reader().readUnsignedByte();
							int value4 = msg.reader().readInt();
							array4[num10] = new MainInfoItem(id7, value4);
						}
						MainItem o6 = MainItem.MainItem_Toc((int)num9, itemName4, (int)imageId4, 0, 6, array4, false, num9, price4, priceType, 0, 0);
						mVector.addElement(o6);
					}
				}
				else if ((int)b == (int)ReadMessenge.CHEST)
				{
					isTypeShop = TabShopNew.INVEN_AND_CHEST;
					typeShop = MainTabNew.CHEST;
					if (Item.VecChestPlayer.size() == 0)
					{
						GlobalService.gI().Update_Char_Chest(-1, 0, 0, 0);
					}
					mVector = Item.VecChestPlayer;
				}
				else if ((int)b == (int)ReadMessenge.PET_KEEPER)
				{
					isTypeShop = TabShopNew.INVEN_AND_PET_KEEPER;
					typeShop = MainTabNew.PET_KEEPER;
					isTypeShop2 = TabShopNew.INVEN_AND_PET_KEEPER;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_MATERIAL)
				{
					typeShop = MainTabNew.SHOP;
					for (int num11 = 0; num11 < (int)num; num11++)
					{
						short id8 = msg.reader().readShort();
						MainItem material2 = Item.getMaterial((int)id8);
						if (material2 != null)
						{
							MainItem o7 = MainItem.MainItem_Material((int)id8, material2.itemName, material2.imageId, 7, material2.priceItem, material2.priceType, material2.content, (int)((short)material2.value), material2.typeMaterial, 1, material2.canSell, material2.canTrade);
							mVector.addElement(o7);
						}
						else
						{
							mVector.addElement(new MainItem
							{
								Id = (int)id8,
								ItemCatagory = 7
							});
						}
					}
				}
				else if ((int)b == (int)ReadMessenge.REBUILD || (int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU)
				{
					isTypeShop = TabShopNew.INVEN_AND_REBUILD;
					typeShop = MainTabNew.REBUILD;
					if ((int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU)
					{
						TabShopNew.isTabHopNL = true;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_HOP_AN)
				{
					isTypeShop = TabShopNew.SHOP_HOP_AN;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_NANG_CAP_MEDAL)
				{
					isTypeShop = TabShopNew.SHOP_NANG_CAP_MEDEL;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_ANY_NGUYEN_LIEU)
				{
					isTypeShop = TabShopNew.SHOP_ANY_NGUYEN_LIEU;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_GHEP_NGOC)
				{
					isTypeShop = TabShopNew.SHOP_GHEP_NGOC;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_DUC_LO)
				{
					isTypeShop = TabShopNew.SHOP_DUC_LO;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_KHAM_NGOC)
				{
					isTypeShop = TabShopNew.SHOP_KHAM_NGOC;
					typeShop = MainTabNew.REBUILD;
				}
				else if ((int)b == (int)ReadMessenge.SHOP_ICONCLAN_FREE || (int)b == (int)ReadMessenge.SHOP_ICONCLAN_VIP)
				{
					typeShop = MainTabNew.SHOP;
					isTypeShop2 = TabShopNew.SHOP_BANG;
					for (int num12 = 0; num12 < (int)num; num12++)
					{
						short num13 = 0;
						if ((int)b == (int)ReadMessenge.SHOP_ICONCLAN_VIP)
						{
							num13 = TabShopNew.PriceIconClan;
						}
						MainItem o8 = new MainItem((int)msg.reader().readShort(), (long)num13);
						mVector.addElement(o8);
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_POTION_CLAN)
				{
					typeShop = MainTabNew.SHOP;
					isTypeShop2 = TabShopNew.NORMAL;
					for (int num14 = 0; num14 < (int)num; num14++)
					{
						short id9 = msg.reader().readShort();
						MainTemplateItem potionTem3 = MainTemplateItem.getPotionTem(id9);
						if (potionTem3 != null)
						{
							MainItem o9 = new MainItem(potionTem3.ID, potionTem3.IconId, potionTem3.name, potionTem3.contentPotion, 1, 4, potionTem3.PricePoition, potionTem3.typePotion, potionTem3.moneyType, 0, 0);
							mVector.addElement(o9);
						}
					}
				}
				else if ((int)b == (int)ReadMessenge.REPLACE)
				{
					isTypeShop = TabShopNew.INVEN_AND_REPLACE;
					typeShop = MainTabNew.REBUILD;
				}
				mVector mVector2 = new mVector("ReadMessenge vec11");
				if ((int)b != (int)ReadMessenge.SHOP_ICONCLAN_FREE && (int)b != (int)ReadMessenge.SHOP_ICONCLAN_VIP && (int)b != (int)ReadMessenge.SHOP_POTION_CLAN)
				{
					mVector2.addElement(new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, isTypeShop)
					{
						isShop_Other_Player = isShop_Other_Player
					});
				}
				MainTabNew mainTabNew;
				if ((int)b == (int)ReadMessenge.REBUILD || (int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_REBUILD);
					mainTabNew.isTabHopNguyenLieu = ((int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU);
					if ((int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU)
					{
						TabShopNew.isTabHopNL = true;
					}
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num15 = 0; num15 < TabRebuildItem.idMaterial.Length; num15++)
					{
						MainItem material3 = Item.getMaterial((int)TabRebuildItem.idMaterial[num15]);
						int num16 = 0;
						if (material3 != null)
						{
							Item itemInventory = Item.getItemInventory(material3.ItemCatagory, (short)material3.Id);
							if (itemInventory != null)
							{
								num16 = itemInventory.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num15] = num16;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_KHAM_NGOC)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_KHAM_NGOC);
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num17 = 0; num17 < TabRebuildItem.idMaterial.Length; num17++)
					{
						MainItem material4 = Item.getMaterial((int)TabRebuildItem.idMaterial[num17]);
						int num18 = 0;
						if (material4 != null)
						{
							Item itemInventory2 = Item.getItemInventory(material4.ItemCatagory, (short)material4.Id);
							if (itemInventory2 != null)
							{
								num18 = itemInventory2.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num17] = num18;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_DUC_LO)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_DUC_LO);
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num19 = 0; num19 < TabRebuildItem.idMaterial.Length; num19++)
					{
						MainItem material5 = Item.getMaterial((int)TabRebuildItem.idMaterial[num19]);
						int num20 = 0;
						if (material5 != null)
						{
							Item itemInventory3 = Item.getItemInventory(material5.ItemCatagory, (short)material5.Id);
							if (itemInventory3 != null)
							{
								num20 = itemInventory3.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num19] = num20;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_HOP_AN)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
					mainTabNew.isCreate_medal = true;
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num21 = 0; num21 < TabRebuildItem.idMaterial.Length; num21++)
					{
						MainItem material6 = Item.getMaterial((int)TabRebuildItem.idMaterial[num21]);
						int num22 = 0;
						if (material6 != null)
						{
							Item itemInventory4 = Item.getItemInventory(material6.ItemCatagory, (short)material6.Id);
							if (itemInventory4 != null)
							{
								num22 = itemInventory4.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num21] = num22;
					}
					int num23 = (int)msg.reader().readByte();
					TabRebuildItem.vecGem.removeAllElements();
					for (int num24 = 0; num24 < num23; num24++)
					{
						short num25 = msg.reader().readShort();
						short num26 = msg.reader().readShort();
						sbyte b18 = 7;
						if (num25 != -1 && (int)b18 == 7)
						{
							TabRebuildItem.numColor[num24] = ReadMessenge.getColorNum(num25, (int)num26);
							TabRebuildItem.numofGem[num24] = ReadMessenge.getInfoNum(num25, (int)num26);
							MainItem material7 = Item.getMaterial((int)num25);
							if (material7 != null)
							{
								TabRebuildItem.vecGem.addElement(material7);
							}
							if (material7 == null)
							{
								MainItem mainItem3 = new MainItem();
								mainItem3.Id = (int)num25;
								mainItem3.ItemCatagory = 7;
								TabRebuildItem.vecGem.addElement(mainItem3);
							}
						}
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_NANG_CAP_MEDAL)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
					mainTabNew.isUPgradeMedal = true;
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num27 = 0; num27 < TabRebuildItem.idMaterial.Length; num27++)
					{
						MainItem material8 = Item.getMaterial((int)TabRebuildItem.idMaterial[num27]);
						int num28 = 0;
						if (material8 != null)
						{
							Item itemInventory5 = Item.getItemInventory(material8.ItemCatagory, (short)material8.Id);
							if (itemInventory5 != null)
							{
								num28 = itemInventory5.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num27] = num28;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_ANY_NGUYEN_LIEU)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_ANY);
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num29 = 0; num29 < TabRebuildItem.idMaterial.Length; num29++)
					{
						MainItem material9 = Item.getMaterial((int)TabRebuildItem.idMaterial[num29]);
						int num30 = 0;
						if (material9 != null)
						{
							Item itemInventory6 = Item.getItemInventory(material9.ItemCatagory, (short)material9.Id);
							if (itemInventory6 != null)
							{
								num30 = itemInventory6.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num29] = num30;
					}
				}
				else if ((int)b == (int)ReadMessenge.SHOP_GHEP_NGOC)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_GHEP_NGOC);
					TabRebuildItem.vecGem.removeAllElements();
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
					for (int num31 = 0; num31 < TabRebuildItem.idMaterial.Length; num31++)
					{
						MainItem material10 = Item.getMaterial((int)TabRebuildItem.idMaterial[num31]);
						int num32 = 0;
						if (material10 != null)
						{
							Item itemInventory7 = Item.getItemInventory(material10.ItemCatagory, (short)material10.Id);
							if (itemInventory7 != null)
							{
								num32 = itemInventory7.numPotion;
							}
						}
						TabRebuildItem.numMaterialInven[num31] = num32;
					}
				}
				else if ((int)b == (int)ReadMessenge.REPLACE)
				{
					mainTabNew = new TabRebuildItem(text, TabRebuildItem.TYPE_REPLACE_PLUS);
					TabRebuildItem.itemRe = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemFree = null;
				}
				else
				{
					mainTabNew = new TabShopNew(mVector, typeShop, text, (int)b, isTypeShop2);
					if ((int)b == (int)ReadMessenge.SHOP_ITEM_EVENT)
					{
						mainTabNew.setNameCmd(nameCmd);
					}
				}
				mVector2.addElement(mainTabNew);
				GameCanvas.shopNpc = new TabScreenNew();
				if ((int)b != (int)ReadMessenge.SHOP_ICONCLAN_FREE && (int)b != (int)ReadMessenge.SHOP_ICONCLAN_VIP && (int)b != (int)ReadMessenge.SHOP_POTION_CLAN)
				{
					GameCanvas.shopNpc.selectTab = 1;
				}
				else
				{
					GameCanvas.shopNpc.selectTab = 0;
				}
				GameCanvas.shopNpc.addMoreTab(mVector2);
				GameCanvas.shopNpc.Show(GameScreen.gI());
				GameCanvas.end_Dialog();
				if ((int)b == (int)ReadMessenge.REBUILD || (int)b == (int)ReadMessenge.REPLACE || (int)b == (int)ReadMessenge.TAB_HOP_NGUYEN_LIEU)
				{
					mainTabNew.init();
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("hay loi day ah");
		}
	}

	// Token: 0x06000A93 RID: 2707 RVA: 0x000B249C File Offset: 0x000B069C
	public void itemTemplate(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			for (int i = 0; i < (int)num; i++)
			{
				short num2 = msg.reader().readShort();
				short iconId = msg.reader().readShort();
				long price = msg.reader().readLong();
				string name = msg.reader().readUTF();
				string content = msg.reader().readUTF();
				sbyte typepotion = msg.reader().readByte();
				sbyte moneytype = msg.reader().readByte();
				sbyte sell = msg.reader().readByte();
				short value = msg.reader().readShort();
				bool canTrade = msg.reader().readBoolean();
				MainTemplateItem v = new MainTemplateItem(num2, iconId, price, name, content, typepotion, moneytype, sell, value, canTrade);
				MainTemplateItem.hashPotionTem.put(string.Empty + num2, v);
			}
			int num3 = (int)msg.reader().readUnsignedByte();
			Item.nameInfoItem = new string[num3];
			Item.colorInfoItem = new sbyte[num3];
			Item.isPercentInfoItem = new sbyte[num3];
			for (int j = 0; j < num3; j++)
			{
				Item.nameInfoItem[j] = msg.reader().readUTF();
				Item.colorInfoItem[j] = msg.reader().readByte();
				Item.isPercentInfoItem[j] = msg.reader().readByte();
			}
			short num4 = msg.reader().readShort();
			for (int k = 0; k < (int)num4; k++)
			{
				short num5 = msg.reader().readShort();
				short imageId = msg.reader().readShort();
				long price2 = msg.reader().readLong();
				string itemName = msg.reader().readUTF();
				string content2 = msg.reader().readUTF();
				sbyte typeitem = msg.reader().readByte();
				sbyte priceType = msg.reader().readByte();
				sbyte sell2 = msg.reader().readByte();
				short value2 = msg.reader().readShort();
				sbyte trade = msg.reader().readByte();
				sbyte b = msg.reader().readByte();
				MainItem mainItem = MainItem.MainItem_Material((int)num5, itemName, (int)imageId, 7, price2, priceType, content2, (int)value2, typeitem, 1, sell2, trade);
				mainItem.setColorName((int)b);
				MainTemplateItem.hashMaterialTem.put(string.Empty + num5, mainItem);
			}
			TabShopNew.priceSellPotion = msg.reader().readShort();
			TabShopNew.priceSellItem = msg.reader().readShort();
			TabShopNew.hesoLv = msg.reader().readShort();
			TabShopNew.hesoColor = msg.reader().readShort();
			TabShopNew.priceSellQuest = msg.reader().readShort();
			TabShopNew.maxPriceItem = msg.reader().readShort();
			TabShopNew.PriceIconClan = msg.reader().readShort();
			TabShopNew.PriceChatWorld = (short)msg.reader().readByte();
			LoginScreen.indexInfoLogin = 0;
			sbyte b2 = msg.reader().readByte();
			mSystem.outz("size pet template = " + b2);
			for (int l = 0; l < (int)b2; l++)
			{
				short num6 = msg.reader().readShort();
				sbyte b3 = msg.reader().readByte();
				MainTemplateItem.hashPetTem.put(string.Empty + num6, b3);
			}
			try
			{
				sbyte b4 = msg.reader().readByte();
				MainObject.idMaterialHopNguyenLieu = new short[(int)b4];
				for (int m = 0; m < (int)b4; m++)
				{
					MainObject.idMaterialHopNguyenLieu[m] = msg.reader().readShort();
				}
			}
			catch (Exception ex)
			{
				mSystem.println("----Err Readmess:-- itemTemplate");
			}
			try
			{
				sbyte paint18plush = msg.reader().readByte();
				PaintInfoGameScreen.paint18plush = paint18plush;
			}
			catch (Exception ex2)
			{
				PaintInfoGameScreen.paint18plush = 0;
			}
			try
			{
				sbyte b5 = msg.reader().readByte();
				GameScreen.idmap18 = new short[(int)b5];
				for (int n = 0; n < (int)b5; n++)
				{
					GameScreen.idmap18[n] = (short)msg.reader().readUnsignedByte();
				}
			}
			catch (Exception ex3)
			{
				GameScreen.idmap18 = new short[0];
			}
		}
		catch (Exception ex4)
		{
			Session_ME.gI().close();
			mVector mVector = new mVector("ReadMessenge vec7");
			if (SelectCharScreen.isSelectOk && GameCanvas.currentScreen != GameCanvas.login)
			{
				mVector.addElement(new iCommand(T.again, 0));
			}
			mVector.addElement(new iCommand(T.exit, 6));
			GameCanvas.start_Select_Dialog(T.disconnect, mVector);
		}
	}

	// Token: 0x06000A94 RID: 2708 RVA: 0x000B29A4 File Offset: 0x000B0BA4
	public void catalogyMonster(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			for (int i = 0; i < (int)num; i++)
			{
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				short lv = (short)msg.reader().readUnsignedByte();
				int maxHp = msg.reader().readInt();
				sbyte b = msg.reader().readByte();
				CatalogyMonster o = new CatalogyMonster((int)id, (int)lv, maxHp, (int)b, name);
				MainMonster.VecCatalogyMonSter.addElement(o);
			}
			sbyte b2 = msg.reader().readByte();
			MountTemplate.FRAME_VE_TRUOC = new sbyte[(int)b2][];
			for (int j = 0; j < (int)b2; j++)
			{
				int num2 = (int)msg.reader().readByte();
				MountTemplate.FRAME_VE_TRUOC[j] = new sbyte[num2];
				for (int k = 0; k < num2; k++)
				{
					MountTemplate.FRAME_VE_TRUOC[j][k] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.DY_CHAR_STAND = new sbyte[(int)b2][];
			for (int l = 0; l < (int)b2; l++)
			{
				int num3 = (int)msg.reader().readByte();
				MountTemplate.DY_CHAR_STAND[l] = new sbyte[num3];
				for (int m = 0; m < num3; m++)
				{
					MountTemplate.DY_CHAR_STAND[l][m] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.DY_CHAR_MOVE = new sbyte[(int)b2][];
			for (int n = 0; n < (int)b2; n++)
			{
				int num4 = (int)msg.reader().readByte();
				MountTemplate.DY_CHAR_MOVE[n] = new sbyte[num4];
				for (int num5 = 0; num5 < num4; num5++)
				{
					MountTemplate.DY_CHAR_MOVE[n][num5] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.dx = new sbyte[(int)b2][];
			for (int num6 = 0; num6 < (int)b2; num6++)
			{
				int num7 = (int)msg.reader().readByte();
				MountTemplate.dx[num6] = new sbyte[num7];
				for (int num8 = 0; num8 < num7; num8++)
				{
					MountTemplate.dx[num6][num8] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.dy = new sbyte[(int)b2][];
			for (int num9 = 0; num9 < (int)b2; num9++)
			{
				int num10 = (int)msg.reader().readByte();
				MountTemplate.dy[num9] = new sbyte[num10];
				for (int num11 = 0; num11 < num10; num11++)
				{
					MountTemplate.dy[num9][num11] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.FRAME_MOVE_LR = new sbyte[(int)b2][];
			for (int num12 = 0; num12 < (int)b2; num12++)
			{
				int num13 = (int)msg.reader().readByte();
				MountTemplate.FRAME_MOVE_LR[num12] = new sbyte[num13];
				for (int num14 = 0; num14 < num13; num14++)
				{
					MountTemplate.FRAME_MOVE_LR[num12][num14] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.FRAME_MOVE_DOWN = new sbyte[(int)b2][];
			for (int num15 = 0; num15 < (int)b2; num15++)
			{
				int num16 = (int)msg.reader().readByte();
				MountTemplate.FRAME_MOVE_DOWN[num15] = new sbyte[num16];
				for (int num17 = 0; num17 < num16; num17++)
				{
					MountTemplate.FRAME_MOVE_DOWN[num15][num17] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.FRAME_MOVE_UP = new sbyte[(int)b2][];
			for (int num18 = 0; num18 < (int)b2; num18++)
			{
				int num19 = (int)msg.reader().readByte();
				MountTemplate.FRAME_MOVE_UP[num18] = new sbyte[num19];
				for (int num20 = 0; num20 < num19; num20++)
				{
					MountTemplate.FRAME_MOVE_UP[num18][num20] = msg.reader().readByte();
				}
			}
			b2 = msg.reader().readByte();
			MountTemplate.speed = new sbyte[(int)b2];
			for (int num21 = 0; num21 < (int)b2; num21++)
			{
				MountTemplate.speed[num21] = msg.reader().readByte();
			}
			sbyte b3 = msg.reader().readByte();
			Item.ATB_Can_Not_Paint = new sbyte[(int)b3];
			for (int num22 = 0; num22 < (int)b3; num22++)
			{
				Item.ATB_Can_Not_Paint[num22] = msg.reader().readByte();
			}
			try
			{
				sbyte b4 = msg.reader().readByte();
				Pet.mTypemove = new sbyte[(int)b4];
				for (int num23 = 0; num23 < (int)b4; num23++)
				{
					Pet.mTypemove[num23] = msg.reader().readByte();
				}
				if (Pet.mTypemove == null || Pet.mTypemove.Length == 0 || (int)b4 == 0)
				{
					Pet.mTypemove = new sbyte[]
					{
						2,
						1,
						0,
						2,
						0,
						1
					};
				}
			}
			catch (Exception ex)
			{
				Pet.mTypemove = new sbyte[]
				{
					2,
					1,
					0,
					2,
					0,
					1
				};
			}
			try
			{
				sbyte b5 = msg.reader().readByte();
				MainTemplateItem.mItem_Equip_Tem = new int[(int)b5];
				for (int num24 = 0; num24 < (int)b5; num24++)
				{
					MainTemplateItem.mItem_Equip_Tem[num24] = (int)msg.reader().readByte();
				}
				if (MainTemplateItem.mItem_Equip_Tem == null || MainTemplateItem.mItem_Equip_Tem.Length == 0 || (int)b5 == 0)
				{
					MainTemplateItem.mItem_Equip_Tem = new int[]
					{
						-1,
						0,
						3,
						4,
						5,
						12,
						2,
						1,
						6,
						4,
						7,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2,
						-2
					};
				}
			}
			catch (Exception ex2)
			{
				MainTemplateItem.mItem_Equip_Tem = new int[]
				{
					-1,
					0,
					3,
					4,
					5,
					12,
					2,
					1,
					6,
					4,
					7,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2,
					-2
				};
			}
			try
			{
				sbyte b6 = msg.reader().readByte();
				MainTemplateItem.mItem_Rotate_Tem_Equip = new int[(int)b6];
				for (int num25 = 0; num25 < (int)b6; num25++)
				{
					MainTemplateItem.mItem_Rotate_Tem_Equip[num25] = (int)msg.reader().readByte();
				}
				if (MainTemplateItem.mItem_Rotate_Tem_Equip == null || MainTemplateItem.mItem_Rotate_Tem_Equip.Length == 0 || (int)b6 == 0)
				{
					MainTemplateItem.mItem_Rotate_Tem_Equip = new int[]
					{
						1,
						7,
						6,
						2,
						-1,
						4,
						8,
						10,
						0,
						0,
						0,
						0,
						5
					};
				}
			}
			catch (Exception ex3)
			{
				MainTemplateItem.mItem_Rotate_Tem_Equip = new int[]
				{
					1,
					7,
					6,
					2,
					-1,
					4,
					8,
					10,
					0,
					0,
					0,
					0,
					5
				};
			}
			try
			{
				sbyte b7 = msg.reader().readByte();
				MainMonster.idBossNew = new short[(int)b7];
				for (int num26 = 0; num26 < (int)b7; num26++)
				{
					MainMonster.idBossNew[num26] = msg.reader().readShort();
				}
				if (MainMonster.idBossNew == null || MainMonster.idBossNew.Length == 0 || (int)b7 == 0)
				{
					MainMonster.idBossNew = new short[]
					{
						104,
						103,
						105,
						106,
						135
					};
				}
			}
			catch (Exception ex4)
			{
				MainTemplateItem.mItem_Rotate_Tem_Equip = new int[]
				{
					1,
					7,
					6,
					2,
					-1,
					4,
					8,
					10,
					0,
					0,
					0,
					0,
					5
				};
			}
			try
			{
				int num27 = (int)msg.reader().readByte();
				Player.ID_HAIR_NO_HAT = new sbyte[num27];
				for (int num28 = 0; num28 < num27; num28++)
				{
					Player.ID_HAIR_NO_HAT[num28] = msg.reader().readByte();
				}
			}
			catch (Exception ex5)
			{
				Player.ID_HAIR_NO_HAT = null;
			}
			try
			{
				sbyte b8 = msg.reader().readByte();
				for (int num29 = 0; num29 < (int)b8; num29++)
				{
					sbyte b9 = msg.reader().readByte();
					short num30 = msg.reader().readShort();
					if (num30 > 0)
					{
						sbyte[] array = new sbyte[(int)num30];
						for (int num31 = 0; num31 < (int)num30; num31++)
						{
							array[num31] = msg.reader().readByte();
						}
						mVector mVector = new mVector();
						DataEffect o2 = new DataEffect(array, (int)b9, true);
						mVector.addElement(o2);
						Pet.PET_DATA.put(string.Empty + b9, mVector);
					}
				}
			}
			catch (Exception ex6)
			{
			}
			sbyte[][] array2;
			try
			{
				short num32 = msg.reader().readShort();
				array2 = new sbyte[(int)num32][];
				for (int num33 = 0; num33 < (int)num32; num33++)
				{
					sbyte b10 = msg.reader().readByte();
					array2[num33] = new sbyte[(int)b10];
					for (int num34 = 0; num34 < (int)b10; num34++)
					{
						array2[num33][num34] = msg.reader().readByte();
					}
				}
			}
			catch (Exception ex7)
			{
				array2 = null;
			}
			if (array2 != null)
			{
				EffectSkill.arrInfoEff = array2;
			}
			sbyte[] array3;
			try
			{
				sbyte b11 = msg.reader().readByte();
				array3 = new sbyte[(int)b11];
				for (int num35 = 0; num35 < (int)b11; num35++)
				{
					array3[num35] = msg.reader().readByte();
				}
			}
			catch (Exception ex8)
			{
				array3 = null;
			}
			if (array3 != null)
			{
				MountTemplate.Arr_Fly = array3;
			}
		}
		catch (Exception ex9)
		{
			Debug.LogWarning("vao cho nay ne ");
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex9.ToString()
			}));
		}
	}

	// Token: 0x06000A95 RID: 2709 RVA: 0x000B3438 File Offset: 0x000B1638
	public void listChar(Message msg)
	{
		try
		{
			LoginScreen.saveUser_Pass();
			LoginScreen.saveversionGame();
			LoginScreen.saveIndexServer();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
			Item.VecInvetoryPlayer.removeAllElements();
			Item.VecChestPlayer.removeAllElements();
			SelectCharScreen.VecSelectChar.removeAllElements();
			sbyte b = msg.reader().readByte();
			mVector mVector = new mVector("ReadMessenge vList");
			int num = (GameCanvas.w - 150) / 4;
			int num2 = num;
			for (int i = 0; i < (int)b; i++)
			{
				int num3 = GameCanvas.hh - 25 - 20 * ((i + 1) % 2);
				int id = msg.reader().readInt();
				string name = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				sbyte b4 = msg.reader().readByte();
				sbyte b5 = msg.reader().readByte();
				sbyte[] array = new sbyte[12];
				for (int j = 0; j < array.Length; j++)
				{
					array[j] = -1;
				}
				for (int k = 0; k < (int)b5; k++)
				{
					sbyte b6 = msg.reader().readByte();
					sbyte b7 = msg.reader().readByte();
					array[(int)b6] = b7;
				}
				short lv = msg.reader().readShort();
				sbyte clazz = msg.reader().readByte();
				msg.reader().readByte();
				msg.reader().readByte();
				Other_Players other_Players = new Other_Players(id, 0, name, 0, 0);
				short num4 = msg.reader().readShort();
				if (num4 >= 0)
				{
					other_Players.myClan = new MainClan(0, num4, msg.reader().readUTF(), msg.reader().readByte());
				}
				other_Players.clazz = clazz;
				other_Players.setInfo((int)b2, (int)b4, (int)b3);
				other_Players.setWearingListChar(array);
				other_Players.Lv = lv;
				other_Players.x = num2 + 25;
				other_Players.y = num3 + 50;
				num2 += 50 + num;
				mVector.addElement(other_Players);
			}
			GameCanvas.selectChar.setPosPaint(mVector);
			if ((int)b == 0)
			{
				GameCanvas.createChar = new CreateChar();
				GameCanvas.createChar.Show(0);
			}
			else
			{
				GameCanvas.selectChar.Show();
			}
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000A96 RID: 2710 RVA: 0x000B36E8 File Offset: 0x000B18E8
	public void npcBig(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				string name = msg.reader().readUTF();
				string text = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				short num = msg.reader().readShort();
				short num2 = msg.reader().readShort();
				sbyte wBlock = msg.reader().readByte();
				sbyte hBlock = msg.reader().readByte();
				sbyte nFrame = msg.reader().readByte();
				MainObject mainObject = MainObject.get_Object((int)b2, 2);
				if (mainObject == null)
				{
					mainObject = new NPC(name, text, b2, b3, num, num2, wBlock, hBlock, nFrame);
				}
				else
				{
					mainObject.name = name;
					mainObject.nameGiaotiep = text;
					mainObject.imageId = (int)b3;
					mainObject.x = (int)num;
					mainObject.y = (int)num2;
				}
				mainObject.isRemove = false;
				mainObject.IdBigAvatar = (int)msg.reader().readByte() + 500;
				mainObject.infoObject = msg.reader().readUTF();
				mainObject.isPerson = msg.reader().readByte();
				mainObject.isShowHP = ((int)msg.reader().readByte() == 1);
				mainObject.typeObject = 2;
				GameScreen.addPlayer(mainObject);
				MiniMap.addNPCMini(new NPCMini((int)b2, (int)num, (int)num2));
				if ((int)b2 == -52)
				{
					Mount mount = new Mount(0, 2, (int)(num + 48), (int)(num2 + 10));
					if (!GameScreen.Vecplayers.contains(mount))
					{
						GameScreen.addPlayer(mount);
					}
					mount = new Mount(2, 0, (int)(num + 43), (int)(num2 - 4));
					if (!GameScreen.Vecplayers.contains(mount))
					{
						GameScreen.addPlayer(mount);
					}
					mount = new Mount(3, 3, (int)(num - 18), (int)(num2 + 7));
					if (!GameScreen.Vecplayers.contains(mount))
					{
						GameScreen.addPlayer(mount);
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A97 RID: 2711 RVA: 0x000B391C File Offset: 0x000B1B1C
	public void onReceiveInfoQuest(Message m)
	{
		try
		{
			sbyte b = m.reader().readByte();
			if ((int)b < 3)
			{
				sbyte b2 = m.reader().readByte();
				string name = string.Empty;
				MainQuest mainQuest = null;
				if ((int)b == 0)
				{
					MainQuest.vecQuestList.removeAllElements();
				}
				else if ((int)b == 1)
				{
					MainQuest.vecQuestFinish.removeAllElements();
				}
				else if ((int)b == 2)
				{
					MainQuest.vecQuestDoing_Main.removeAllElements();
					MainQuest.vecQuestDoing_Sub.removeAllElements();
				}
				sbyte b3 = 0;
				while ((int)b3 < (int)b2)
				{
					short id = m.reader().readShort();
					bool flag = m.reader().readBoolean();
					name = m.reader().readUTF();
					switch (b)
					{
					case 0:
					{
						sbyte b4 = m.reader().readByte();
						string strDetailTalk = m.reader().readUTF();
						sbyte b5 = m.reader().readByte();
						string strDetailHelp = m.reader().readUTF();
						mainQuest = new MainQuest((int)id, flag, name, (int)b4, strDetailTalk, b5, strDetailHelp);
						MainQuest.vecQuestList.addElement(mainQuest);
						break;
					}
					case 1:
					{
						sbyte b6 = m.reader().readByte();
						string strDetailTalk2 = m.reader().readUTF();
						string strDetailHelp2 = m.reader().readUTF();
						mainQuest = new MainQuest((int)id, flag, name, (int)b6, strDetailTalk2, strDetailHelp2);
						MainQuest.vecQuestFinish.addElement(mainQuest);
						break;
					}
					case 2:
					{
						sbyte b5 = m.reader().readByte();
						string strShortDetail = m.reader().readUTF();
						string strDetailHelp3 = m.reader().readUTF();
						sbyte b6 = m.reader().readByte();
						if ((int)b5 == 0)
						{
							sbyte b7 = m.reader().readByte();
							short[] array = new short[(int)b7];
							short[] array2 = new short[(int)b7];
							short[] array3 = new short[(int)b7];
							sbyte b8 = 0;
							while ((int)b8 < (int)b7)
							{
								array[(int)b8] = m.reader().readShort();
								array3[(int)b8] = m.reader().readShort();
								array2[(int)b8] = m.reader().readShort();
								b8 += 1;
							}
							mainQuest = new MainQuest((int)id, flag, name, strDetailHelp3, b5, strShortDetail, (int)b6, array, array2, array3, 0);
						}
						else if ((int)b5 == 1)
						{
							sbyte b9 = m.reader().readByte();
							short[] array4 = new short[(int)b9];
							short[] array5 = new short[(int)b9];
							short[] array6 = new short[(int)b9];
							sbyte b10 = 0;
							while ((int)b10 < (int)b9)
							{
								array4[(int)b10] = m.reader().readShort();
								array6[(int)b10] = m.reader().readShort();
								array5[(int)b10] = m.reader().readShort();
								b10 += 1;
							}
							mainQuest = new MainQuest((int)id, flag, name, strDetailHelp3, b5, strShortDetail, (int)b6, array4, array5, array6, 1);
						}
						else if ((int)b5 == 2)
						{
							b6 = m.reader().readByte();
							string strShortDetail2 = m.reader().readUTF();
							mainQuest = new MainQuest((int)id, flag, name, strDetailHelp3, (int)b6, strShortDetail2);
						}
						if (mainQuest != null)
						{
							if (flag)
							{
								MainQuest.vecQuestDoing_Main.addElement(mainQuest);
							}
							else
							{
								MainQuest.vecQuestDoing_Sub.addElement(mainQuest);
							}
						}
						break;
					}
					}
					b3 += 1;
				}
				if ((int)b != 0)
				{
					if ((int)b == 1 || (int)b == 2)
					{
						((MainTabNew)GameCanvas.AllInfo.VecTabScreen.elementAt((int)MainTabNew.QUEST)).init();
					}
				}
			}
			else
			{
				sbyte b11 = m.reader().readByte();
				sbyte b12 = m.reader().readByte();
			}
			for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
				if ((int)mainObject.typeObject == 2)
				{
					if ((int)b == 0)
					{
						if (mainObject.typeNPC == 1)
						{
							mainObject.typeNPC = 0;
						}
					}
					else if ((int)b == 1)
					{
						if (mainObject.typeNPC == 3)
						{
							mainObject.typeNPC = 0;
						}
					}
					else if ((int)b == 2 && mainObject.typeNPC == 2)
					{
						mainObject.typeNPC = 0;
					}
					for (int j = 0; j < MainQuest.vecQuestList.size(); j++)
					{
						MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestList.elementAt(j);
						if (mainQuest2.idNPC_From == mainObject.ID && mainObject.typeNPC != 3)
						{
							mainObject.typeNPC = 1;
						}
					}
					for (int k = 0; k < MainQuest.vecQuestFinish.size(); k++)
					{
						MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestFinish.elementAt(k);
						if (mainQuest3.idNPC_To == mainObject.ID)
						{
							mainObject.typeNPC = 3;
						}
					}
					for (int l = 0; l < MainQuest.vecQuestDoing_Main.size(); l++)
					{
						MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(l);
						if (mainQuest4.idNPC_To == mainObject.ID && mainObject.typeNPC == 0)
						{
							mainObject.typeNPC = 2;
						}
					}
					for (int n = 0; n < MainQuest.vecQuestDoing_Sub.size(); n++)
					{
						MainQuest mainQuest5 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(n);
						if (mainQuest5.idNPC_To == mainObject.ID && mainObject.typeNPC == 0)
						{
							mainObject.typeNPC = 2;
						}
					}
				}
			}
			for (int num = 0; num < MiniMap.vecNPC_Map.size(); num++)
			{
				NPCMini npcmini = (NPCMini)MiniMap.vecNPC_Map.elementAt(num);
				if ((int)b == 0)
				{
					if (npcmini.type == 1)
					{
						npcmini.type = 0;
					}
				}
				else if ((int)b == 1)
				{
					if (npcmini.type == 3)
					{
						npcmini.type = 0;
					}
				}
				else if ((int)b == 2 && npcmini.type == 2)
				{
					npcmini.type = 0;
				}
				MainObject mainObject2 = MainObject.get_Object(npcmini.ID, 2);
				if (mainObject2 != null && !mainObject2.isRemove)
				{
					npcmini.type = mainObject2.typeNPC;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A98 RID: 2712 RVA: 0x000B3FB8 File Offset: 0x000B21B8
	public void Dynamic_Menu(Message msg)
	{
		try
		{
			short idnpc = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			mVector mVector = new mVector("ReadMessenge cmd");
			for (int i = 0; i < (int)b2; i++)
			{
				iCommand o = new iCommand(msg.reader().readUTF(), null);
				mVector.addElement(o);
			}
			string name = msg.reader().readUTF();
			GameCanvas.menu2.setinfoDynamic(mVector, 2, (int)b, (int)idnpc, name);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A99 RID: 2713 RVA: 0x000B406C File Offset: 0x000B226C
	public void Item_More_Info(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			TabMySeftNew.mItemInfo = new MainInfoItem[(int)b];
			TabMySeftNew.mItemInfoShow = new MainInfoItem[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				int id = (int)msg.reader().readUnsignedByte();
				int value = msg.reader().readInt();
				MainInfoItem mainInfoItem = new MainInfoItem(id, value);
				if (mainInfoItem.id >= 16 && mainInfoItem.id <= 20)
				{
					TabMySeftNew.meffskill[mainInfoItem.id - 16] = MainItem.getNopercent(mainInfoItem.value);
				}
				TabMySeftNew.mItemInfo[i] = mainInfoItem;
				TabMySeftNew.mItemInfoShow[i] = mainInfoItem;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9A RID: 2714 RVA: 0x000B4144 File Offset: 0x000B2344
	public void Set_XP(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num, 0);
			if (mainObject != null && !mainObject.isRemove)
			{
				mainObject.phantramLv = msg.reader().readShort();
				int num2 = msg.reader().readInt();
				if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
				{
					GameScreen.addEffectNum(num2 + "xp", mainObject.x, mainObject.y - mainObject.hOne, 1, (int)num);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9B RID: 2715 RVA: 0x000B41FC File Offset: 0x000B23FC
	public void Level_Up(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num, 0);
			if (mainObject != null && !mainObject.isRemove)
			{
				mainObject.Lv = (short)msg.reader().readByte();
				GameScreen.addEffectKill(42, (int)num, 0, (int)num, 0, 0, 0);
				if (mainObject == GameScreen.player && GameScreen.help.setStep_Next(5, 8))
				{
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
					if ((int)Player.isAutoFire == -1)
					{
						Player.isAutoFire = 0;
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9C RID: 2716 RVA: 0x000B42B8 File Offset: 0x000B24B8
	public void Login_Ok(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			sbyte[] array = new sbyte[(int)num];
			for (int i = 0; i < (int)num; i++)
			{
				array[i] = msg.reader().readsbyte();
			}
			LoadMap.load_Table_Map(array);
			GameScreen.vecTimecountDown.removeAllElements();
			PaintInfoGameScreen.idicon = -1;
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9D RID: 2717 RVA: 0x000B4338 File Offset: 0x000B2538
	public void ItemDrop(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			short idIcon = msg.reader().readShort();
			short id2 = msg.reader().readShort();
			string name = msg.reader().readUTF();
			sbyte color = 0;
			if ((int)b == 3 || (int)b == 4 || (int)b == 7)
			{
				color = msg.reader().readByte();
			}
			short id3 = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, 1);
			if (mainObject != null && !mainObject.isRemove)
			{
				int x = mainObject.x;
				int y = mainObject.y;
				Item_Drop obj = new Item_Drop((int)id2, b, name, x, y, idIcon, color);
				GameScreen.addPlayer(obj);
			}
			else
			{
				MainObject mainObject2 = MainObject.get_Object((int)id3, 0);
				if (mainObject2 != null)
				{
					int x = mainObject2.x;
					int y = mainObject2.y;
					Item_Drop obj2 = new Item_Drop((int)id2, b, name, x, y, idIcon, color);
					GameScreen.addPlayer(obj2);
				}
				else
				{
					mSystem.outz(" obj nay da null");
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9E RID: 2718 RVA: 0x000B4478 File Offset: 0x000B2678
	public void GetItemMap(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			short num = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Item_Object((int)id, (int)b);
			if (mainObject != null && !mainObject.isRemove)
			{
				if ((int)b == 5 && (int)num == GameScreen.player.ID)
				{
					MainQuest.updateQuestGetItem(mainObject.imageId, mainObject.name);
				}
				MainObject mainObject2 = MainObject.get_Object((int)num, 0);
				if (mainObject2 != null && !mainObject2.isRemove)
				{
					if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
					{
						if ((int)mainObject.typeObject == 3 && (int)mainObject.colorName > 0)
						{
							GameScreen.addEffectNum(mainObject.name, mainObject2.x, mainObject2.y - mainObject2.hOne / 2, -(int)mainObject.colorName, (int)num);
						}
						else
						{
							GameScreen.addEffectNum(mainObject.name, mainObject2.x, mainObject2.y - mainObject2.hOne / 2, 5, (int)num);
						}
					}
					mainObject.setVx_Vy_Item(mainObject2.x, mainObject2.y - mainObject2.hOne / 2);
					mainObject.isRunAttack = true;
				}
				else
				{
					mainObject.isRemove = true;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A9F RID: 2719 RVA: 0x000B45EC File Offset: 0x000B27EC
	public void get_Item_Tem(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			string name = msg.reader().readUTF();
			sbyte typeItem = msg.reader().readByte();
			sbyte idPartItem = msg.reader().readByte();
			sbyte classitem = msg.reader().readByte();
			short iconId = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			int[] array = new int[(int)b];
			sbyte[] array2 = new sbyte[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				array2[i] = msg.reader().readByte();
				array[i] = msg.reader().readInt();
			}
			MainTemplateItem v = new MainTemplateItem(num, name, typeItem, idPartItem, classitem, iconId, array, array2);
			MainTemplateItem.hashItemTem.put(string.Empty + num, v);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA0 RID: 2720 RVA: 0x000B46F4 File Offset: 0x000B28F4
	public void Skill_List(Message msg)
	{
		try
		{
			MsgDialog.MaxSkillBuff = 0;
			mVector mVector = new mVector("ReadMessenge vec14");
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				Skill skill = new Skill();
				skill.Id = (int)msg.reader().readByte();
				skill.iconId = msg.reader().readByte();
				skill.name = msg.reader().readUTF();
				skill.typeSkill = msg.reader().readByte();
				if ((int)skill.typeSkill == 1)
				{
					MsgDialog.MaxSkillBuff += 1;
				}
				skill.range = msg.reader().readShort();
				skill.detail = msg.reader().readUTF();
				skill.typeBuff = msg.reader().readByte();
				skill.subEff = msg.reader().readByte();
				sbyte b2 = msg.reader().readByte();
				skill.mLvSkill = new LvSkill[(int)b2];
				for (int j = 0; j < (int)b2; j++)
				{
					mSystem.outz("Lvskill=" + j);
					skill.mLvSkill[j] = new LvSkill();
					skill.mLvSkill[j].mpLost = msg.reader().readShort();
					skill.mLvSkill[j].LvRe = msg.reader().readShort();
					if (j == 0)
					{
						skill.lvMin = skill.mLvSkill[j].LvRe;
					}
					skill.mLvSkill[j].delay = msg.reader().readInt();
					skill.mLvSkill[j].timeBuff = msg.reader().readInt();
					skill.mLvSkill[j].per_Sub_Eff = msg.reader().readByte();
					skill.mLvSkill[j].time_Sub_Eff = msg.reader().readShort();
					skill.mLvSkill[j].plus_Hp = msg.reader().readShort();
					skill.mLvSkill[j].plus_Mp = msg.reader().readShort();
					sbyte b3 = msg.reader().readByte();
					skill.mLvSkill[j].minfo = new MainInfoItem[(int)b3];
					for (int k = 0; k < (int)b3; k++)
					{
						skill.mLvSkill[j].minfo[k] = new MainInfoItem((int)msg.reader().readUnsignedByte(), msg.reader().readInt());
					}
					skill.mLvSkill[j].nTarget = msg.reader().readByte();
					skill.mLvSkill[j].range_lan = msg.reader().readShort();
				}
				skill.performDur = msg.reader().readShort();
				skill.typePaint = msg.reader().readByte();
				mVector.addElement(skill);
			}
			mVector = CRes.selectionSortIDSkill(mVector);
			TabSkillsNew.vecPaintSkill = CRes.selectionSortSkill(mVector);
			MainListSkill.setKill((int)GameScreen.player.clazz);
			GameScreen.player.tabskills.setXYSkill(TabSkillsNew.vecPaintSkill);
			GameCanvas.load.isLoadSkill = true;
			MsgDialog.Autobuff = mSystem.new_M_Int((int)MsgDialog.MaxSkillBuff, 3);
			int num = 0;
			for (int l = 0; l < TabSkillsNew.vecPaintSkill.size(); l++)
			{
				Skill skill2 = (Skill)TabSkillsNew.vecPaintSkill.elementAt(l);
				if ((int)skill2.typeSkill == 1)
				{
					MsgDialog.Autobuff[num][0] = skill2.Id;
					MsgDialog.Autobuff[num][1] = 0;
					MsgDialog.Autobuff[num][2] = l;
					num++;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA1 RID: 2721 RVA: 0x000B4AC4 File Offset: 0x000B2CC4
	public void use_Potion(Message msg)
	{
		try
		{
			TabScreenNew.timeRepaint = 5;
			sbyte b = msg.reader().readByte();
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num, b);
			if (mainObject != null && !mainObject.isRemove)
			{
				if (num2 != -1 && mainObject == GameScreen.player)
				{
					Item itemInventory = Item.getItemInventory(4, num2);
					if (itemInventory != null)
					{
						itemInventory.numPotion--;
						if (itemInventory.numPotion <= 0)
						{
							Item.VecInvetoryPlayer.removeElement(itemInventory);
						}
					}
				}
				sbyte b2 = msg.reader().readByte();
				if ((int)b2 == 0)
				{
					mainObject.maxHp = msg.reader().readInt();
					mainObject.hp = msg.reader().readInt();
					int num3 = msg.reader().readInt();
					if (mainObject.hp > 0)
					{
						if (mainObject.Action == 4)
						{
							mainObject.resetAction();
							mainObject.Action = 0;
							mainObject.vecBuff.removeAllElements();
							if (mainObject == GameScreen.player)
							{
								GlobalService.gI().player_move((short)GameScreen.player.x, (short)GameScreen.player.y);
							}
						}
					}
					else
					{
						mainObject.hp = 0;
						mainObject.mp = 0;
						if (mainObject.Action != 4)
						{
							if ((int)b == 1)
							{
								MainObject.startDeadFly((MainMonster)mainObject, GameScreen.player.ID, CRes.random(3));
							}
							else
							{
								mainObject.resetAction();
								mainObject.Action = 4;
								mainObject.timedie = GameCanvas.timeNow;
								mainObject.f = 0;
								GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
							}
						}
					}
					if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
					{
						if (num3 > 0)
						{
							GameScreen.addEffectNum("+" + num3, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, (int)num);
						}
						else if (num3 < 0)
						{
							GameScreen.addEffectNum(string.Empty + num3, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, (int)num);
						}
					}
				}
				else if ((int)b2 == 1)
				{
					mainObject.maxMp = msg.reader().readInt();
					mainObject.mp = msg.reader().readInt();
					int num4 = msg.reader().readInt();
					if (!GameCanvas.lowGraphic || mainObject == GameScreen.player)
					{
						if (num4 > 0)
						{
							GameScreen.addEffectNum("+" + num4, mainObject.x, mainObject.y - mainObject.hOne / 2, 4, (int)num);
						}
						else if (num4 < 0)
						{
							GameScreen.addEffectNum(string.Empty + num4, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, (int)num);
						}
					}
				}
				else if ((int)b2 == 2)
				{
					mainObject.maxHp = msg.reader().readInt();
					mainObject.hp = msg.reader().readInt();
					int num5 = msg.reader().readInt();
					if (!GameCanvas.lowGraphic)
					{
						if (num5 > 0)
						{
							mSystem.outz("dzo day ---");
							GameScreen.addEffectNum("+" + num5, mainObject.x, mainObject.y - mainObject.hOne / 2, 3, (int)num);
						}
						else if (num5 < 0)
						{
							mSystem.outz("hoac dzo day ---");
							GameScreen.addEffectNum(string.Empty + num5, mainObject.x, mainObject.y - mainObject.hOne / 2, 6, (int)num);
						}
					}
				}
				else if ((int)b2 == 3)
				{
					mainObject.hp = msg.reader().readInt();
					int num6 = msg.reader().readInt();
					GameScreen.addEffectNum(string.Empty + num6, mainObject.x, mainObject.y - mainObject.hOne / 2, 9, (int)num);
					GameScreen.addEffectEndKill(0, mainObject.x, mainObject.y + mainObject.vy * 2 / 1000 - 5);
					GameScreen.addEffectEndKill(9, mainObject.x, mainObject.y + mainObject.vy * 2 / 1000 + 5);
					GameScreen.addEffectEndKill(4, mainObject.x, mainObject.y);
				}
				if (Player.party != null)
				{
					Player.party.setPos(mainObject.name, mainObject.x, mainObject.y, mainObject.hp, mainObject.maxHp);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA2 RID: 2722 RVA: 0x000B4FD4 File Offset: 0x000B31D4
	public void chatPopup(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			if (mainObject != null && !mainObject.isRemove)
			{
				string text = msg.reader().readUTF();
				if (text != null && text.Trim().Length != 0)
				{
					mainObject.strChatPopup = text;
					GameCanvas.msgchat.addNewChat(T.tinden, mainObject.name + ": ", text, ChatDetail.TYPE_SERVER, false);
				}
			}
		}
		catch (Exception ex)
		{
			Cout.println("loi chat popup" + ex.ToString());
		}
	}

	// Token: 0x06000AA3 RID: 2723 RVA: 0x000B50A4 File Offset: 0x000B32A4
	public void chatTab(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			string text2 = msg.reader().readUTF();
			if (text2 != null && text2.Trim().Length != 0)
			{
				if (text.CompareTo(T.tinden) == 0)
				{
					GameCanvas.msgchat.addNewChat(text, T.thongbao + ": ", text2, ChatDetail.TYPE_SERVER, false);
				}
				else if (text.CompareTo(T.tabThuLinh) == 0)
				{
					GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_SERVER, false);
				}
				else if (text.CompareTo(T.tabBangHoi) == 0)
				{
					GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_CHAT, false);
				}
				else if (text.CompareTo(T.party) == 0)
				{
					GameCanvas.msgchat.addNewChat(text, string.Empty, text2, ChatDetail.TYPE_CHAT, false);
				}
				else
				{
					GameCanvas.msgchat.addNewChat(text, text + ": ", text2, ChatDetail.TYPE_CHAT, false);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA4 RID: 2724 RVA: 0x000B51E4 File Offset: 0x000B33E4
	public void Friend(Message msg)
	{
		try
		{
			string nameList = T.listFriend;
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				string namecheck = msg.reader().readUTF();
				GameCanvas.mevent.addEvent(namecheck, 1, T.loimoikb, 0);
			}
			else if ((int)b == 4 || (int)b == 1)
			{
				if ((int)b == 4)
				{
					nameList = msg.reader().readUTF();
					sbyte b2 = msg.reader().readByte();
				}
				int num = 1;
				if ((int)b == 4)
				{
					num = (int)msg.reader().readUnsignedByte();
				}
				mVector mVector = new mVector("ReadMessenge vec6");
				for (int i = 0; i < num; i++)
				{
					string name = msg.reader().readUTF();
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					sbyte b5 = msg.reader().readByte();
					short num2 = msg.reader().readShort();
					sbyte b6 = msg.reader().readByte();
					sbyte[] array = new sbyte[12];
					for (int j = 0; j < array.Length; j++)
					{
						array[j] = -1;
					}
					for (int k = 0; k < (int)b6; k++)
					{
						sbyte b7 = msg.reader().readByte();
						sbyte b8 = msg.reader().readByte();
						array[(int)b8] = b7;
					}
					sbyte typeOnline = msg.reader().readByte();
					MainObject mainObject = new MainObject(0, 0, name, 0, 0);
					short num3 = msg.reader().readShort();
					if (num3 >= 0)
					{
						mainObject.myClan = new MainClan(0, num3, msg.reader().readUTF(), msg.reader().readByte());
					}
					mainObject.setInfo((int)b3, (int)b4, (int)b5);
					mainObject.typeOnline = typeOnline;
					mainObject.Lv = num2;
					mainObject.setWearingListChar(array);
					mainObject.infoObject = T.level + num2;
					if ((int)b == 1)
					{
						GameCanvas.addInfoChar(mainObject.name + T.chapnhanketban);
						List_Server.vecMyFriend.addElement(mainObject);
						if ((int)List_Server.gI().typeList == 0)
						{
							List_Server.gI().setMinMax();
							List_Server.gI().setXmove();
							List_Server.gI().setCmd();
						}
					}
					else
					{
						mVector.addElement(mainObject);
					}
				}
				if ((int)b == 4)
				{
					List_Server.vecMyFriend.removeAllElements();
					List_Server.gI().typeList = 0;
					List_Server.vecMyFriend = mVector;
					List_Server.gI().vecListServer = mVector;
					List_Server.gI().setSize(0);
					List_Server.gI().updateList();
					List_Server.gI().setMinMax();
					List_Server.gI().setXmove();
					List_Server.gI().setCmd();
					List_Server.gI().nameList = nameList;
					List_Server.gI().page = 99;
					List_Server.isLoadFriend = true;
					if (GameCanvas.currentScreen != List_Server.gI())
					{
						if (GameCanvas.currentScreen.lastScreen != List_Server.gI())
						{
							List_Server.gI().Show(GameCanvas.currentScreen);
						}
						else
						{
							List_Server.gI().Show(GameCanvas.game);
						}
					}
					else
					{
						GameCanvas.end_Dialog();
					}
				}
				GameCanvas.end_Dialog();
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA5 RID: 2725 RVA: 0x000B5544 File Offset: 0x000B3744
	public void lastlogout(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			GameCanvas.timenextLogin = (GameCanvas.timenextLogin = mSystem.currentTimeMillis() + (long)((int)b * 1000));
			GameScreen.player.resetAction();
			Session_ME.gI().close();
			GameScreen.player = new Player(0, 0, "unname", 0, 0);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA6 RID: 2726 RVA: 0x000B55C8 File Offset: 0x000B37C8
	public void Login_Fail(Message msg)
	{
		try
		{
			string str = msg.reader().readUTF();
			GameCanvas.start_Ok_Dialog(str);
			sbyte b = 0;
			try
			{
				b = msg.reader().readByte();
			}
			catch (Exception ex)
			{
				b = 0;
			}
			if ((int)b == 0)
			{
				GlobalLogicHandler.isMelogin = false;
			}
			if ((int)b == 1)
			{
				GlobalLogicHandler.isMelogin = true;
			}
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x06000AA7 RID: 2727 RVA: 0x000B565C File Offset: 0x000B385C
	public void Register(Message msg)
	{
		try
		{
			bool flag = msg.reader().readBoolean();
			string str = msg.reader().readUTF();
			if (flag)
			{
				GameCanvas.login.section = 0;
				GameCanvas.login.setScreen();
			}
			GameCanvas.start_Ok_Dialog(str);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA8 RID: 2728 RVA: 0x000B56CC File Offset: 0x000B38CC
	public void Party(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				Player.party = new MainParty(GameScreen.player.name, GameScreen.player.Lv, GameCanvas.loadmap.idMap, LoadMap.getAreaPaint());
				GameCanvas.start_Ok_Dialog(T.vuataonhom);
			}
			else if ((int)b == 1)
			{
				this.nameParty = msg.reader().readUTF();
				GameCanvas.mevent.addEvent(this.nameParty, 2, T.moivaoParty, 0);
			}
			else if ((int)b == 2)
			{
				MainParty mainParty = null;
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					if (i == 0)
					{
						mainParty = new MainParty(msg.reader().readUTF(), msg.reader().readShort(), (int)msg.reader().readUnsignedByte(), msg.reader().readByte());
					}
					else
					{
						mainParty.addObjParty(msg.reader().readUTF(), msg.reader().readShort(), (int)msg.reader().readUnsignedByte(), msg.reader().readByte());
					}
				}
				Player.party = mainParty;
				MsgDialog.maxSizeParty = -1;
			}
			else if ((int)b == 3)
			{
				GameCanvas.start_Ok_Dialog(T.moikhoinhom);
				Player.party = null;
			}
			else if ((int)b == 4)
			{
				GameCanvas.start_Ok_Dialog(T.giaitannhom);
				Player.party = null;
			}
			else if ((int)b == 5)
			{
				GameCanvas.start_Ok_Dialog(T.roikhoinhom);
				Player.party = null;
			}
			if (Player.party != null)
			{
				Player.party.setIsParty();
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AA9 RID: 2729 RVA: 0x000B5894 File Offset: 0x000B3A94
	public void Buy_Sell(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				this.nameBuySell = msg.reader().readUTF();
				GameCanvas.mevent.addEvent(this.nameBuySell, 3, T.loimoigiaodich, 0);
			}
			else if ((int)b == 1)
			{
				string name = msg.reader().readUTF();
				GameCanvas.buy_sell = new Buy_Sell_Screen();
				GameCanvas.buy_sell.setinfoBuySell(name);
				GameCanvas.buy_sell.Show(GameCanvas.currentScreen);
			}
			else if ((int)b == 2 || (int)b == 3)
			{
				sbyte index = msg.reader().readByte();
				sbyte b2 = msg.reader().readByte();
				short num = msg.reader().readShort();
				short idIcon = msg.reader().readShort();
				short numPo = 1;
				sbyte colorname = 0;
				sbyte charclass = 0;
				short lvMin = 0;
				sbyte lvup = 0;
				string name2 = string.Empty;
				string contentPotion = null;
				MainInfoItem[] array = null;
				if ((int)b2 == 4)
				{
					numPo = msg.reader().readShort();
					MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num);
					contentPotion = mainTemplateItem.contentPotion;
					name2 = mainTemplateItem.name;
				}
				else if ((int)b2 == 3)
				{
					name2 = msg.reader().readUTF();
					colorname = msg.reader().readByte();
					charclass = msg.reader().readByte();
					lvMin = msg.reader().readShort();
					lvup = msg.reader().readByte();
					sbyte b3 = msg.reader().readByte();
					array = new MainInfoItem[(int)b3];
					for (int i = 0; i < (int)b3; i++)
					{
						int id = (int)msg.reader().readUnsignedByte();
						int value = msg.reader().readInt();
						array[i] = new MainInfoItem(id, value);
					}
				}
				else if ((int)b2 == 7)
				{
					numPo = msg.reader().readShort();
					MainItem material = Item.getMaterial((int)num);
					if (material != null)
					{
						contentPotion = material.content;
						name2 = material.itemName;
					}
					else
					{
						contentPotion = string.Empty;
						name2 = string.Empty;
					}
				}
				MainItem item = new MainItem((int)num, name2, (int)numPo, (int)idIcon, b2, contentPotion, array, colorname, charclass, lvMin, lvup, 0, 0);
				Buy_Sell_Screen.setmItemOther(item, b, index);
			}
			else if ((int)b == 4)
			{
				GameCanvas.buy_sell.typeLock = msg.reader().readByte();
				if ((int)GameCanvas.buy_sell.typeLock == 1)
				{
					GameCanvas.buy_sell.center = null;
					GameCanvas.buy_sell.left = null;
				}
				if ((int)GameCanvas.buy_sell.typeLock == 2)
				{
					GameCanvas.buy_sell.center = null;
					GameCanvas.buy_sell.left = GameCanvas.buy_sell.cmdGiaodich;
					GameCanvas.buy_sell.setPosCmd();
				}
			}
			else if ((int)b == 5)
			{
				sbyte b4 = msg.reader().readByte();
				if ((int)b4 == 0)
				{
					GameCanvas.buy_sell.left = null;
					GameCanvas.buy_sell.right = null;
					GameCanvas.buy_sell.center = new iCommand(T.cancel, 8);
					GameCanvas.buy_sell.setPosCmd();
					GameCanvas.buy_sell.typeActionBuySell = 0;
					GameCanvas.start_Ok_Dialog(T.xinchogiaodich + GameCanvas.buy_sell.nameBuy + T.xacnhangiaodich);
				}
				else if ((int)b4 == 1)
				{
					GameCanvas.buy_sell.typeActionBuySell = 1;
				}
				else if ((int)b4 == 2)
				{
					if (GameCanvas.buy_sell.lastScreen.lastScreen != null)
					{
						GameCanvas.buy_sell.lastScreen.Show(GameCanvas.buy_sell.lastScreen.lastScreen);
					}
					else
					{
						GameCanvas.buy_sell.lastScreen.Show();
					}
					GameCanvas.buy_sell = null;
					GameCanvas.start_Ok_Dialog(T.giaodichthanhcong);
				}
			}
			else if ((int)b == 6)
			{
				if (GameCanvas.buy_sell.lastScreen.lastScreen != null)
				{
					GameCanvas.buy_sell.lastScreen.Show(GameCanvas.buy_sell.lastScreen.lastScreen);
				}
				else
				{
					GameCanvas.buy_sell.lastScreen.Show();
				}
				GameCanvas.buy_sell = null;
				GameCanvas.start_Ok_Dialog(T.huygiaodich);
			}
			else if ((int)b == 7)
			{
				GameCanvas.buy_sell.moneyBuySell[1] = msg.reader().readInt();
			}
			else if ((int)b == 8)
			{
				GameCanvas.buy_sell.moneyBuySell[0] = msg.reader().readInt();
			}
			else if ((int)b == 9)
			{
				string text = msg.reader().readUTF();
				GameCanvas.buy_sell.strchat[1] = text;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AAA RID: 2730 RVA: 0x000B5D5C File Offset: 0x000B3F5C
	public void Buff(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			short id = msg.reader().readShort();
			sbyte b3 = msg.reader().readByte();
			int time = msg.reader().readInt();
			short id2 = msg.reader().readShort();
			sbyte tem = msg.reader().readByte();
			MainObject mainObject;
			if ((int)b2 == 6)
			{
				mainObject = MainObject.get_Object((int)id, 9);
			}
			else if ((int)b2 == 4)
			{
				mainObject = MainObject.get_Object((int)id, 1);
			}
			else
			{
				mainObject = MainObject.get_Object((int)id, 0);
			}
			MainObject mainObject2 = MainObject.get_Object((int)id2, tem);
			if (mainObject != null && !mainObject.isRemove && mainObject != GameScreen.player && (int)b == 0 && mainObject.Action != 4 && mainObject.Action != 2)
			{
				if (mainObject2 != null)
				{
					if ((int)b2 == 4 && mainObject2 == mainObject && !mainObject2.isRemove)
					{
						GameScreen.addEffectKillSubTime(MainListSkill.mSkillAllClasses[(int)b2][(int)b3], mainObject.ID, mainObject.typeObject, mainObject.ID, mainObject.typeObject, 0, mainObject.hp, (sbyte)MainListSkill.mBuffAllClasses[(int)b2][(int)b3], 850);
					}
				}
				else
				{
					mVector mVector = new mVector("ReadMessenge vec");
					Object_Effect_Skill o = new Object_Effect_Skill((short)mainObject.ID, mainObject.typeObject);
					mVector.addElement(o);
					if ((int)b2 == 6)
					{
						Pet pet = (Pet)mainObject;
						pet.setState(2);
					}
					mainObject.ListKillNow.setFireSkill(mainObject, mVector, (int)b3, b2);
				}
			}
			if (mainObject2 != null && !mainObject2.isRemove)
			{
				mainObject2.addBuff(MainListSkill.mBuffAllClasses[(int)b2][(int)b3], time, 0);
				if (mainObject2 == GameScreen.player)
				{
					MainBuff buff = MainBuff.getBuff(MainListSkill.mBuffAllClasses[(int)b2][(int)b3], 0);
					if (buff != null)
					{
						buff.idIcon = (short)msg.reader().readByte();
						sbyte b4 = msg.reader().readByte();
						buff.minfotam = new MainInfoItem[(int)b4];
						MainInfoItem[] array = new MainInfoItem[(int)b4];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new MainInfoItem((int)msg.reader().readUnsignedByte(), msg.reader().readInt());
						}
						buff.minfotam = array;
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AAB RID: 2731 RVA: 0x000B5FFC File Offset: 0x000B41FC
	public void firePK(Message msg)
	{
		try
		{
			this.Fire_Object(msg, 0, 0);
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000AAC RID: 2732 RVA: 0x000B6070 File Offset: 0x000B4270
	public void diePlayer(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			short id2 = msg.reader().readShort();
			short pointPk = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			MainObject mainObject2 = MainObject.get_Object((int)id2, b);
			if (mainObject2 != null && !mainObject2.isRemove && (int)b == 0)
			{
				mainObject2.pointPk = pointPk;
			}
			if (mainObject != null && !mainObject.isRemove && mainObject.Action != 4)
			{
				mainObject.hp = 0;
				mainObject.resetAction();
				mainObject.Action = 4;
				mainObject.timedie = GameCanvas.timeNow;
				GameScreen.addEffectEndKill(11, mainObject.x, mainObject.y);
				if (GameScreen.player == mainObject)
				{
					if (!GameScreen.infoGame.isMapChienTruong(GameCanvas.loadmap.idMap))
					{
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
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AAD RID: 2733 RVA: 0x000B62B4 File Offset: 0x000B44B4
	public void pk(Message msg)
	{
		try
		{
			short id = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, 0);
			if (mainObject != null && !mainObject.isRemove)
			{
				mainObject.typePk = b;
				if (mainObject == GameScreen.player)
				{
					GameScreen.player.pointPk = msg.reader().readShort();
					string caption = T.off + " " + T.dosat;
					if ((int)GameScreen.player.typePk != 0)
					{
						caption = T.on + " " + T.dosat;
					}
					GameScreen.gI().cmdSetDoSat.caption = caption;
					if ((int)b > 0)
					{
						GlobalService.gI().Thach_Dau(2, string.Empty);
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AAE RID: 2734 RVA: 0x000B63A4 File Offset: 0x000B45A4
	public void Fire_Object(Message msg, sbyte temFrom, sbyte temTo)
	{
		try
		{
			if (LoadMapScreen.isNextMap)
			{
				short num = msg.reader().readShort();
				MainObject mainObject = MainObject.get_Object((int)num, temFrom);
				if (mainObject != null && !mainObject.isRemove)
				{
					sbyte b = msg.reader().readByte();
					sbyte b2 = msg.reader().readByte();
					if ((int)b2 > 0)
					{
						mVector mVector = new mVector("ReadMessenge vec6");
						for (int i = 0; i < (int)b2; i++)
						{
							short num2 = msg.reader().readShort();
							Object_Effect_Skill object_Effect_Skill = new Object_Effect_Skill(num2, temTo);
							int num3 = msg.reader().readInt();
							int hpLast = msg.reader().readInt();
							object_Effect_Skill.setHP(num3, hpLast);
							if ((int)num2 == GameScreen.player.ID)
							{
								int maxHp = GameScreen.player.maxHp;
								int num4 = num3 / maxHp * 100;
								GameScreen.player.setPainthit(4, num4 > 20);
							}
							sbyte b3 = msg.reader().readByte();
							object_Effect_Skill.mEffTypePlus = new int[(int)b3];
							object_Effect_Skill.mEff_HP_Plus = new int[(int)b3];
							for (int j = 0; j < (int)b3; j++)
							{
								object_Effect_Skill.mEffTypePlus[j] = (int)msg.reader().readByte();
								object_Effect_Skill.mEff_HP_Plus[j] = msg.reader().readInt();
							}
							MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill.ID, temTo);
							if (mainObject2 != null && !mainObject2.isRemove)
							{
								mVector.addElement(object_Effect_Skill);
							}
						}
						int hp = msg.reader().readInt();
						int mp = msg.reader().readInt();
						sbyte b4 = msg.reader().readByte();
						int num5 = msg.reader().readInt();
						if ((int)num == GameScreen.player.ID)
						{
							for (int k = 0; k < mVector.size(); k++)
							{
								Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)mVector.elementAt(k);
								MainObject mainObject3 = MainObject.get_Object((int)object_Effect_Skill2.ID, temTo);
								if (mainObject3 != null && !mainObject3.isRemove)
								{
									int typeColor = 2;
									if (mainObject != null && !mainObject.isRemove)
									{
										int num6 = EffectSkill.setAddEffKillPlus(object_Effect_Skill2.mEffTypePlus, mainObject, mainObject3, object_Effect_Skill2.mEff_HP_Plus);
										if (num6 != -1)
										{
											typeColor = num6;
										}
									}
									if (mainObject3.ID != GameScreen.player.ID)
									{
										if (object_Effect_Skill2.hpShow == 0)
										{
											typeColor = 6;
											GameScreen.addEffectNum(T.hut, mainObject3.x, mainObject3.y - mainObject3.hOne, typeColor, mainObject3.ID);
										}
										else
										{
											GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject3.x, mainObject3.y - mainObject3.hOne, typeColor, mainObject3.ID);
										}
										if (num5 > 0)
										{
											GameScreen.addEffectNum("-" + num5, mainObject3.x, mainObject3.y - mainObject3.hOne, (int)b4, mainObject3.ID);
										}
									}
									mainObject3.hp = object_Effect_Skill2.hpLast;
									if ((int)mainObject3.typeObject == 1 && mainObject3.hp <= 0)
									{
										MainObject.startDeadFly((MainMonster)mainObject3, (int)num, CRes.random(3));
										if (mainObject3.timeReveice >= 0)
										{
											MainQuest.updateQuestKillMonster(mainObject3.ID);
										}
									}
								}
							}
						}
						else if (mainObject != null && !mainObject.isRemove && mVector.size() > 0)
						{
							mainObject.posTransRoad = null;
							mainObject.vecObjFocusSkill = mVector;
							mainObject.ListKillNow.setFireSkill(mainObject, mVector, (int)b, -1);
						}
						if (mainObject != null && !mainObject.isRemove)
						{
							mainObject.hp = hp;
							mainObject.mp = mp;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AAF RID: 2735 RVA: 0x000B67B8 File Offset: 0x000B49B8
	public void other_player_info(Message msg)
	{
		try
		{
			MainObject mainObject = new MainObject();
			mainObject.ID = (int)msg.reader().readShort();
			mainObject.name = msg.reader().readUTF();
			mainObject.clazz = msg.reader().readByte();
			mainObject.head = (int)msg.reader().readByte();
			mainObject.eye = (int)msg.reader().readByte();
			mainObject.hair = (int)msg.reader().readByte();
			mainObject.Lv = msg.reader().readShort();
			mainObject.hp = msg.reader().readInt();
			mainObject.maxHp = msg.reader().readInt();
			mainObject.typePk = msg.reader().readByte();
			mainObject.pointPk = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			sbyte[] array = new sbyte[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = -1;
			}
			Info_Other_Player.vecEquipShow.clear();
			for (int j = 0; j < (int)b; j++)
			{
				sbyte b2 = msg.reader().readByte();
				if ((int)b2 > -1)
				{
					string itemName = msg.reader().readUTF();
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					short imageId = msg.reader().readShort();
					sbyte b5 = msg.reader().readByte();
					sbyte plusItem = msg.reader().readByte();
					short lvItem = msg.reader().readShort();
					sbyte b6 = msg.reader().readByte();
					array[j] = b5;
					sbyte b7 = msg.reader().readByte();
					MainInfoItem[] array2 = new MainInfoItem[(int)b7];
					for (int k = 0; k < (int)b7; k++)
					{
						int id = (int)msg.reader().readUnsignedByte();
						int value = msg.reader().readInt();
						array2[k] = new MainInfoItem(id, value);
					}
					sbyte can_Sell = msg.reader().readByte();
					MainItem mainItem = MainItem.MainItem_Item((int)b2, itemName, (int)imageId, plusItem, (int)b6, (int)b3, 3, array2, (int)b4, false, -1, 0L, lvItem, 0, 0, 0, 0, 0);
					mainItem.set_can_Sell(can_Sell);
					Info_Other_Player.vecEquipShow.put(string.Empty + b2, mainItem);
				}
				else
				{
					array[j] = -1;
				}
			}
			mainObject.setWearingEquip(array);
			short num = msg.reader().readShort();
			if (num >= 0)
			{
				mainObject.myClan = new MainClan(0, num, msg.reader().readUTF(), msg.reader().readByte());
				mainObject.myClan.name = msg.reader().readUTF();
			}
			sbyte b8 = msg.reader().readByte();
			if ((int)b8 > -1)
			{
				string itemName2 = msg.reader().readUTF();
				sbyte b9 = msg.reader().readByte();
				short level = msg.reader().readShort();
				short experience = msg.reader().readShort();
				sbyte b10 = msg.reader().readByte();
				sbyte petImageId = msg.reader().readByte();
				sbyte frameNumberImg = msg.reader().readByte();
				sbyte b11 = msg.reader().readByte();
				int age = msg.reader().readInt();
				short growPoint = msg.reader().readShort();
				short maxgrow = msg.reader().readShort();
				short str = msg.reader().readShort();
				short agi = msg.reader().readShort();
				short hea = msg.reader().readShort();
				short spi = msg.reader().readShort();
				short maxtiemnang = msg.reader().readShort();
				sbyte b12 = msg.reader().readByte();
				MainInfoItem[] array3 = new MainInfoItem[(int)b12];
				for (int l = 0; l < (int)b12; l++)
				{
					int id2 = (int)msg.reader().readUnsignedByte();
					int value2 = msg.reader().readInt();
					int maxDam = msg.reader().readInt();
					array3[l] = new MainInfoItem(id2, value2, maxDam);
				}
				PetItem petItem = new PetItem((int)b8, itemName2, (int)b10, (int)b11, (int)b9, 9, array3, 14, level, (int)b10, frameNumberImg, petImageId);
				petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
				Info_Other_Player.vecEquipShow.put(string.Empty + b8, petItem);
				array[5] = b10;
				Info_Other_Player.showPet = petItem;
			}
			else
			{
				Info_Other_Player.showPet = null;
			}
			Info_Other_Player.showObject = mainObject;
			sbyte type = msg.reader().readByte();
			if (GameCanvas.info_other_player == null)
			{
				GameCanvas.info_other_player = new Info_Other_Player();
			}
			GameCanvas.info_other_player.init(type);
			GameCanvas.info_other_player.Show(GameCanvas.currentScreen);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB0 RID: 2736 RVA: 0x000B6C94 File Offset: 0x000B4E94
	public void eff_plus_time(Message msg)
	{
		try
		{
			sbyte tem = msg.reader().readByte();
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			if (mainObject != null && !mainObject.isRemove)
			{
				sbyte b = msg.reader().readByte();
				sbyte b2 = msg.reader().readByte();
				MainBuff.setEffHead((int)b, (int)b2, mainObject);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB1 RID: 2737 RVA: 0x000B6D20 File Offset: 0x000B4F20
	public void changeArea(Message msg)
	{
		try
		{
			LoadMapScreen.isNextMap = false;
			if (GameCanvas.currentScreen != GameCanvas.load)
			{
				GameCanvas.load.Show();
			}
			GameScreen.RemoveLoadMap();
			LoadMapScreen.isNextMap = true;
			LoadMap.Area = msg.reader().readByte();
			GameScreen.player.x = (int)(msg.reader().readShort() * 24);
			GameScreen.player.y = (int)(msg.reader().readShort() * 24);
			GameScreen.player.resetMove();
			GameScreen.player.posTransRoad = null;
			GameScreen.player.resetAction();
			if (GameScreen.pet != null)
			{
				GameScreen.pet.x = GameScreen.player.x;
				GameScreen.pet.y = GameScreen.player.y;
				GameScreen.pet.clearWayPoints();
			}
			GameCanvas.end_Dialog();
			GameCanvas.clearKeyHold();
			GameCanvas.load.isTele = false;
		}
		catch (Exception ex)
		{
			Cout.LogError2(" loi gi day ");
		}
	}

	// Token: 0x06000AB2 RID: 2738 RVA: 0x000B6E38 File Offset: 0x000B5038
	public void update_Status_Area(Message msg)
	{
		try
		{
			LoadMap.MaxArea = msg.reader().readByte();
			LoadMap.mStatusArea = new int[(int)LoadMap.MaxArea];
			string[] array = new string[(int)LoadMap.MaxArea];
			for (int i = 0; i < (int)LoadMap.MaxArea; i++)
			{
				LoadMap.mStatusArea[i] = (int)msg.reader().readByte();
				int num = (int)msg.reader().readByte();
				if (num != 0)
				{
					LoadMap.mStatusArea[i] = num;
				}
			}
			for (int j = 0; j < (int)LoadMap.MaxArea; j++)
			{
				array[j] = msg.reader().readUTF();
			}
			GameCanvas.start_Wait_Dialog(T.danglaydulieu, new iCommand(T.close, -1));
			GameScreen.isReArea = false;
			mVector mVector = new mVector("ReadMessenge menu4");
			for (int k = 0; k < (int)LoadMap.MaxArea; k++)
			{
				iCommand iCommand = new iCommand(array[k], 13, k, GameScreen.gI());
				iCommand.setFraCaption(PaintInfoGameScreen.fraStatusArea, 1, LoadMap.mStatusArea[k]);
				mVector.addElement(iCommand);
			}
			GameCanvas.menu2.startAt(mVector, 2, T.khuvuc, false, null);
			GameCanvas.end_Dialog();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB3 RID: 2739 RVA: 0x000B6F90 File Offset: 0x000B5190
	public void remove_Actor(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Item_Object((int)id, (int)b);
			if (mainObject != null && !mainObject.isRemove)
			{
				if ((int)b == 1)
				{
					if ((int)mainObject.typeBoss == 4)
					{
						sbyte b2 = msg.reader().readByte();
						if ((int)b2 == 0)
						{
							mainObject.isMonPhoBangDie = true;
							mainObject.vMax = 6;
						}
						else
						{
							mainObject.isStop = true;
						}
					}
					else if ((int)mainObject.typeBoss == 3)
					{
						sbyte b3 = msg.reader().readByte();
						if ((int)b3 == 0)
						{
							mainObject.isMonPhoBangDie = true;
							mainObject.vMax = 6;
						}
						else
						{
							mainObject.isStop = true;
						}
					}
					else if ((int)mainObject.typeBoss == 2)
					{
						sbyte b4 = msg.reader().readByte();
						if ((int)b4 == 1)
						{
							GameScreen.addEffectKill(80, mainObject.x, mainObject.y - 70, 200, id, 1);
							mainObject.isStop = true;
						}
						else
						{
							mainObject.isStop = true;
							MainObject.imgCapchar = null;
						}
					}
					else
					{
						mainObject.isStop = true;
					}
				}
				else if ((int)b == 2)
				{
					sbyte b5 = msg.reader().readByte();
					if ((int)b5 == 1)
					{
						mainObject.isMonPhoBangDie = true;
						LoadMap.isShowEffAuto = LoadMap.EFF_PHOBANG_END;
					}
					else
					{
						GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
						mainObject.isStop = true;
					}
				}
				else
				{
					if ((int)b == 0)
					{
						GameScreen.addEffectEndKill(35, mainObject.x, mainObject.y - 20);
					}
					mainObject.isStop = true;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB4 RID: 2740 RVA: 0x000B7164 File Offset: 0x000B5364
	public void Save_RMS_Server(Message msg)
	{
		try
		{
			sbyte id = msg.reader().readByte();
			short num = msg.reader().readShort();
			sbyte[] array = null;
			if (num > 0)
			{
				array = new sbyte[(int)num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = msg.reader().readByte();
				}
			}
			MainRMS.setLoadRMS(id, array);
		}
		catch (Exception ex)
		{
			Cout.println(string.Concat(new object[]
			{
				"LOI TAI CMD  ",
				msg.command,
				" >> ",
				ex.ToString()
			}));
		}
	}

	// Token: 0x06000AB5 RID: 2741 RVA: 0x000B7224 File Offset: 0x000B5424
	public void List_Pk(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			Player.vecPlayerPk = new short[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				Player.vecPlayerPk[i] = msg.reader().readShort();
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB6 RID: 2742 RVA: 0x000B7298 File Offset: 0x000B5498
	public void List_Serverz(Message msg)
	{
		try
		{
			mSystem.outz("danh sach day000000000000000");
			sbyte b = msg.reader().readByte();
			string nameList = msg.reader().readUTF();
			sbyte page = msg.reader().readByte();
			int num = msg.reader().readInt();
			int num2 = (int)msg.reader().readUnsignedByte();
			mVector mVector = new mVector("ReadMessenge vec8");
			if ((int)b == 3)
			{
				for (int i = 0; i < num2; i++)
				{
					string name = msg.reader().readUTF();
					int idClan = msg.reader().readInt();
					short idicon = msg.reader().readShort();
					string shortname = msg.reader().readUTF();
					string slogan = msg.reader().readUTF();
					MainClan mainClan = new MainClan(idClan, idicon, shortname, 122);
					mainClan.name = name;
					mainClan.slogan = slogan;
					if (num > num2 && i == num2 - 1)
					{
						mainClan.hang = num;
					}
					else
					{
						mainClan.hang = i;
					}
					mVector.addElement(mainClan);
				}
			}
			else
			{
				for (int j = 0; j < num2; j++)
				{
					string name2 = msg.reader().readUTF();
					sbyte b2 = msg.reader().readByte();
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					short lv = msg.reader().readShort();
					sbyte b5 = msg.reader().readByte();
					sbyte[] array = new sbyte[12];
					for (int k = 0; k < array.Length; k++)
					{
						array[k] = -1;
					}
					for (int l = 0; l < (int)b5; l++)
					{
						sbyte b6 = msg.reader().readByte();
						sbyte b7 = msg.reader().readByte();
						array[(int)b7] = b6;
					}
					sbyte typeOnline = msg.reader().readByte();
					string infoObject = msg.reader().readUTF();
					MainObject mainObject = new MainObject(0, 0, name2, 0, 0);
					short num3 = msg.reader().readShort();
					if (num3 >= 0)
					{
						mainObject.myClan = new MainClan(0, num3, msg.reader().readUTF(), msg.reader().readByte());
					}
					mainObject.setInfo((int)b2, (int)b3, (int)b4);
					mainObject.typeOnline = typeOnline;
					mainObject.Lv = lv;
					mainObject.setWearingListChar(array);
					mainObject.infoObject = infoObject;
					if (num > num2 && j == num2 - 1)
					{
						mainObject.hang = num;
					}
					else
					{
						mainObject.hang = j;
					}
					mVector.addElement(mainObject);
				}
			}
			if (mVector.size() != 0)
			{
				if ((int)b == 1)
				{
					if (num > num2)
					{
						mVector.insertElementAt(new MainObject(0, 0, "...", 0, 0)
						{
							hang = -1
						}, num2 - 1);
					}
				}
				else if ((int)b == 3)
				{
					mSystem.outz("hang=" + num);
					if (num > num2)
					{
						mVector.insertElementAt(new MainClan(0, -1, "...", 122)
						{
							hang = -1
						}, num2 - 1);
					}
				}
				else if ((int)b == 6 && num > num2)
				{
					mVector.insertElementAt(new MainObject(0, 0, "...", 0, 0)
					{
						hang = -1
					}, num2 - 1);
				}
				List_Server.gI().vecListServer = mVector;
				List_Server.gI().setSize(b);
				List_Server.gI().updateList();
				List_Server.gI().setMinMax();
				List_Server.gI().setXmove();
				List_Server.gI().setCmd();
				List_Server.gI().nameList = nameList;
				List_Server.gI().page = page;
				if (GameCanvas.currentScreen != List_Server.gI())
				{
					if (GameCanvas.currentScreen.lastScreen != List_Server.gI())
					{
						List_Server.gI().Show(GameCanvas.currentScreen);
					}
					else
					{
						List_Server.gI().Show(GameCanvas.game);
					}
				}
				else
				{
					GameCanvas.end_Dialog();
				}
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.GetBaseException());
		}
	}

	// Token: 0x06000AB7 RID: 2743 RVA: 0x000B76EC File Offset: 0x000B58EC
	public void suckhoe(Message msg)
	{
		try
		{
			Player.PointSucKhoe = msg.reader().readInt();
			Player.PointArena = msg.reader().readInt();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB8 RID: 2744 RVA: 0x000B7740 File Offset: 0x000B5940
	public void chat_npc(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)b, 2);
			if (mainObject != null && !mainObject.isRemove)
			{
				mainObject.strChatPopup = msg.reader().readUTF();
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AB9 RID: 2745 RVA: 0x000B77AC File Offset: 0x000B59AC
	public void InfoServer_Download(Message msg)
	{
		try
		{
			string str = msg.reader().readUTF();
			string text = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			if (GameScreen.player != null && GameScreen.player.Action != 2 && GameScreen.player.Action != 4)
			{
				GameScreen.player.resetAction();
				GameScreen.player.posTransRoad = null;
			}
			if ((int)b == 15)
			{
				GameCanvas.start_Ok_Dialog(str, b);
			}
			else if (text.Length == 0)
			{
				GameCanvas.start_Ok_Dialog(str);
			}
			else
			{
				GameCanvas.start_Download_Dialog(str, text);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ABA RID: 2746 RVA: 0x000B7878 File Offset: 0x000B5A78
	public void name_server(Message msg)
	{
		try
		{
			int num = (int)msg.reader().readUnsignedByte();
			string[] array = new string[num];
			for (int i = 0; i < num; i++)
			{
				array[i] = msg.reader().readUTF();
			}
			WorldMapScreen.namePos = array;
			sbyte b = msg.reader().readByte();
			string[] array2 = new string[(int)b];
			for (int j = 0; j < (int)b; j++)
			{
				array2[j] = msg.reader().readUTF();
			}
			TabQuest.nameItemQuest = array2;
			sbyte b2 = msg.reader().readByte();
			TabRebuildItem.mNameMaterial = new string[(int)b2];
			TabRebuildItem.idMaterial = new short[(int)b2];
			TabRebuildItem.numMaterialInven = new int[(int)b2];
			for (int k = 0; k < (int)b2; k++)
			{
				TabRebuildItem.idMaterial[k] = msg.reader().readShort();
				MainItem material = Item.getMaterial((int)TabRebuildItem.idMaterial[k]);
				if (material != null)
				{
					TabRebuildItem.mNameMaterial[k] = material.itemName;
				}
			}
			sbyte b3 = msg.reader().readByte();
			TabRebuildItem.dataRebuild = new DataRebuildItem[(int)b3];
			for (int l = 0; l < (int)b3; l++)
			{
				TabRebuildItem.dataRebuild[l] = new DataRebuildItem();
				TabRebuildItem.dataRebuild[l].lv = msg.reader().readByte();
				TabRebuildItem.dataRebuild[l].priceCoin = msg.reader().readInt();
				mSystem.outz("vang=" + TabRebuildItem.dataRebuild[l].priceCoin);
				TabRebuildItem.dataRebuild[l].priceGold = (int)msg.reader().readShort();
				TabRebuildItem.dataRebuild[l].mValue = new sbyte[4];
				for (int m = 0; m < 4; m++)
				{
					TabRebuildItem.dataRebuild[l].mValue[m] = msg.reader().readByte();
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ABB RID: 2747 RVA: 0x000B7A9C File Offset: 0x000B5C9C
	public void x2_Xp(Message msg)
	{
		try
		{
			sbyte typeX = msg.reader().readByte();
			Player.typeX2 = typeX;
			Player.timeSetX2 = GameCanvas.timeNow;
			Player.timeX2 = (int)msg.reader().readShort();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ABC RID: 2748 RVA: 0x000B7AFC File Offset: 0x000B5CFC
	public void loadImageDataCharPart(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short num = msg.reader().readShort();
			string path = string.Empty + num;
			int num2 = msg.reader().readInt();
			sbyte[] array = new sbyte[num2];
			msg.reader().read(ref array);
			int num3 = 0;
			if (msg.reader().available() > 0)
			{
				num3 = msg.reader().available();
			}
			sbyte[] array2 = new sbyte[1];
			if (num3 > 0)
			{
				array2 = new sbyte[num3];
				msg.reader().read(ref array2);
			}
			if ((int)TemMidlet.DIVICE > 0)
			{
				MainImageDataPartChar o = new MainImageDataPartChar(array, array2, b, num, (short)array.Length);
				SaveImageRMS.vecSaveCharPart.addElement(o);
			}
			if ((int)b == 110)
			{
				ImageEffect imageEffect = (ImageEffect)ImageEffect.hashImageEff.get(string.Empty + num);
				if (imageEffect != null)
				{
					imageEffect.timeRemove = GameCanvas.timeNow;
					imageEffect.img = mImage.createImage(array, 0, 0, path);
				}
			}
			else if ((int)b == 111)
			{
				ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(string.Empty + num);
				if (imageEffectAuto != null)
				{
					imageEffectAuto.timeRemove = GameCanvas.timeNow;
					imageEffectAuto.img = mImage.createImage(array, 0, 0, path);
				}
				DataEffAuto dataEffAuto = (DataEffAuto)EffectAuto.ALL_DATA_EFF_AUTO.get(string.Empty + num);
				if (dataEffAuto != null)
				{
					CRes.saveRMS("data_eff" + num, array2);
					dataEffAuto.timeremove = GameCanvas.timeNow;
					dataEffAuto.setdata(array2);
				}
			}
			else if ((int)b == 112)
			{
				ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(string.Empty + ((int)num + GameData.ID_START_SKILL));
				if (imageIcon != null)
				{
					imageIcon.timeRemove = GameCanvas.timeNow;
					imageIcon.img = mImage.createImage(array, 0, 0, path);
				}
				EffectData effectData = (EffectData)DataSkillEff.ALL_DATA_EFFECT.get(string.Empty + ((int)num + GameData.ID_START_SKILL));
				if (effectData != null)
				{
					effectData.timeRemove = GameCanvas.timeNow;
					effectData.setdata(array2);
				}
			}
			else if ((int)b == 113)
			{
				ImageIcon imageIcon2 = (ImageIcon)GameData.listImgIcon.get(string.Empty + ((int)num + GameData.ID_START_SKILL));
				if (imageIcon2 != null)
				{
					imageIcon2.timeRemove = GameCanvas.timeNow;
					imageIcon2.img = mImage.createImage(array, 0, 0, path);
				}
				DataSkillEff effMatNa = MainObject.getEffMatNa((int)num);
				if (effMatNa != null)
				{
					effMatNa.loadData(array2);
				}
			}
			MsgDialog.curupdate++;
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ABD RID: 2749 RVA: 0x000B7DFC File Offset: 0x000B5FFC
	public void loadImageDataAutoEff(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b != 100)
			{
				if ((int)b == 4)
				{
					short num = msg.reader().readShort();
					sbyte[] array = new sbyte[(int)num];
					for (int i = 0; i < array.Length; i++)
					{
						array[i] = msg.reader().readByte();
					}
					short id = msg.reader().readShort();
					sbyte b2 = msg.reader().readByte();
					for (int j = 0; j < (int)b2; j++)
					{
						short id2 = msg.reader().readShort();
						sbyte cat = msg.reader().readByte();
						MainObject mainObject = GameScreen.findObjByteCat(id2, cat);
						if (mainObject != null)
						{
							EffectAuto o = new EffectAuto((int)id, mainObject.x, mainObject.y, array);
							GameScreen.vecHightEffAuto.addElement(o);
						}
					}
				}
				else if ((int)b == 3)
				{
					short id3 = msg.reader().readShort();
					sbyte tem = msg.reader().readByte();
					int id4 = (int)msg.reader().readUnsignedByte();
					MainObject mainObject2 = MainObject.get_Object((int)id3, tem);
					if (mainObject2 != null)
					{
						mainObject2.removeDataSkillEff(id4);
					}
				}
				else if ((int)b == 101)
				{
					short num2 = msg.reader().readShort();
					for (int k = 0; k < LoadMap.mItemMap.size(); k++)
					{
						MainItemMap mainItemMap = (MainItemMap)LoadMap.mItemMap.elementAt(k);
						if (mainItemMap != null && mainItemMap.idActor == num2)
						{
							LoadMap.mItemMap.removeElement(mainItemMap);
						}
					}
				}
				else
				{
					int num3 = (int)msg.reader().readShort();
					sbyte[] array2 = new sbyte[num3];
					for (int l = 0; l < array2.Length; l++)
					{
						array2[l] = msg.reader().readByte();
					}
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					int num4 = (int)msg.reader().readUnsignedByte();
					switch (b)
					{
					case 0:
					{
						short id5 = msg.reader().readShort();
						sbyte tem2 = msg.reader().readByte();
						sbyte lvpaint = msg.reader().readByte();
						short num5 = msg.reader().readShort();
						sbyte canmove = msg.reader().readByte();
						long time = (long)(num5 * 1000) + mSystem.currentTimeMillis();
						MainObject mainObject3 = MainObject.get_Object((int)id5, tem2);
						if (mainObject3 != null)
						{
							mainObject3.addEffAutoFromsv(num4, mainObject3.x, mainObject3.y, 0, 0, 0, 0, array2, lvpaint, time, canmove, (int)b3, (int)b4);
						}
						break;
					}
					case 1:
					{
						short x = msg.reader().readShort();
						short y = msg.reader().readShort();
						sbyte b5 = msg.reader().readByte();
						sbyte b6 = msg.reader().readByte();
						short num6 = msg.reader().readShort();
						short loop = msg.reader().readShort();
						sbyte b7 = msg.reader().readByte();
						if ((int)b6 != 0 && num6 != 0)
						{
							MainObject mainObject4 = MainObject.get_Object((int)num6, b7);
							if (mainObject4 != null)
							{
								mainObject4.hOne = (int)b6;
							}
						}
						if ((int)b5 == 3)
						{
							EffectAuto o2 = new EffectAuto(num4, (int)x, (int)y, 0, 0, (int)b5, 5, array2, loop);
							GameScreen.vecHightEffAuto.addElement(o2);
						}
						else if ((int)b7 == 1)
						{
							for (int m = 0; m < LoadMap.mItemMap.size(); m++)
							{
								MainItemMap mainItemMap2 = (MainItemMap)LoadMap.mItemMap.elementAt(m);
								if (mainItemMap2 != null && mainItemMap2.idActor == num6)
								{
									return;
								}
							}
							EffectAuto effectAuto = new EffectAuto(num4, (int)x, (int)y, 0, 0, (int)b5, 0, array2);
							effectAuto.setidActor((int)num6);
							LoadMap.mItemMap.addElement(effectAuto);
							GameCanvas.loadmap.setBlockNPC((int)x, (int)y, (int)b3, (int)b4);
							CRes.quickSort1(LoadMap.mItemMap);
						}
						else
						{
							EffectAuto effectAuto2 = new EffectAuto(num4, (int)x, (int)y, 0, 0, (int)b5, 0, array2);
							effectAuto2.setidActor((int)num6);
							LoadMap.mItemMap.addElement(effectAuto2);
							GameCanvas.loadmap.setBlockNPC((int)x, (int)y, (int)b3, (int)b4);
							CRes.quickSort1(LoadMap.mItemMap);
						}
						break;
					}
					case 2:
					{
						short id6 = msg.reader().readShort();
						sbyte tem3 = msg.reader().readByte();
						sbyte b8 = msg.reader().readByte();
						int num7 = msg.reader().readInt();
						if ((int)b8 == 17)
						{
							if (num7 < 0)
							{
								GameScreen.player.addDataEff(num4, array2, (int)b3, (int)b4);
							}
							else if (num7 > 0)
							{
								long timelive = (long)num7 + mSystem.currentTimeMillis();
								GameScreen.player.addDataEff(num4, array2, (int)b3, (int)b4, timelive, b8);
							}
						}
						else
						{
							MainObject mainObject5 = MainObject.get_Object((int)id6, tem3);
							if (mainObject5 != null)
							{
								if (num7 < 0)
								{
									mainObject5.addDataEff(num4, array2, (int)b3, (int)b4);
								}
								else if (num7 > 0)
								{
									long timelive2 = (long)num7 + mSystem.currentTimeMillis();
									mainObject5.addDataEff(num4, array2, (int)b3, (int)b4, timelive2, b8);
								}
								else
								{
									mainObject5.addDataEff2(num4, array2, (int)b3, (int)b4, 0L, b8);
								}
							}
						}
						break;
					}
					}
				}
			}
			else if ((int)b == 100)
			{
				short id7 = msg.reader().readShort();
				int num8 = (int)msg.reader().readUnsignedByte();
				sbyte b9 = msg.reader().readByte();
				sbyte b10 = msg.reader().readByte();
				if ((int)b9 == 0 || (int)b9 == 1)
				{
					MainObject mainObject6 = MainObject.get_Object((int)id7, b9);
					if (mainObject6 != null)
					{
						if ((int)b10 == 0)
						{
							for (int n = 0; n < mainObject6.vecEffauto.size(); n++)
							{
								EffectAuto effectAuto3 = (EffectAuto)mainObject6.vecEffauto.elementAt(n);
								if (effectAuto3 != null && (int)effectAuto3.IDImage == num8)
								{
									mainObject6.vecEffauto.removeElement(effectAuto3);
								}
							}
						}
						else if ((int)b10 == 1)
						{
							for (int num9 = 0; num9 < mainObject6.veclowEffauto.size(); num9++)
							{
								EffectAuto effectAuto4 = (EffectAuto)mainObject6.veclowEffauto.elementAt(num9);
								if (effectAuto4 != null && (int)effectAuto4.IDImage == num8)
								{
									mainObject6.veclowEffauto.removeElement(effectAuto4);
								}
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.println("loadImageDataAutoEff loi  ");
		}
	}

	// Token: 0x06000ABE RID: 2750 RVA: 0x000B84C0 File Offset: 0x000B66C0
	public void nap_tien(Message msg)
	{
		try
		{
			GameCanvas.end_Dialog();
			short type = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			string[] array = new string[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				array[i] = msg.reader().readUTF();
			}
			string caption = msg.reader().readUTF();
			string name = msg.reader().readUTF();
			GameCanvas.start_More_Input_Dialog(array, new iCommand(caption, 0), type, -1, name);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ABF RID: 2751 RVA: 0x000B8568 File Offset: 0x000B6768
	public void delete_rms(Message msg)
	{
		try
		{
			if ((int)GameCanvas.IndexRes != -1)
			{
				TemMidlet.delRMS();
			}
			sbyte b = msg.reader().readByte();
			sbyte[] data = new sbyte[]
			{
				b
			};
			CRes.saveRMS("isIndexRes", data);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC0 RID: 2752 RVA: 0x000B85D0 File Offset: 0x000B67D0
	public void CharChest(Message msg)
	{
		mSystem.outz("oiiiiiiiiiiiiiiiiiiiiii");
		this.update_InVen_Or_Chest(msg, Item.VecChestPlayer, MainTabNew.CHEST);
	}

	// Token: 0x06000AC1 RID: 2753 RVA: 0x000B85F0 File Offset: 0x000B67F0
	private PetItem createPetItemFromMessage(Message msg)
	{
		try
		{
			int catagory = 9;
			sbyte b = 14;
			string itemName = msg.reader().readUTF();
			sbyte b2 = msg.reader().readByte();
			short id = msg.reader().readShort();
			short level = msg.reader().readShort();
			short experience = msg.reader().readShort();
			sbyte b3 = msg.reader().readByte();
			sbyte petImageId = msg.reader().readByte();
			sbyte frameNumberImg = msg.reader().readByte();
			sbyte b4 = msg.reader().readByte();
			int age = msg.reader().readInt();
			short growPoint = msg.reader().readShort();
			short maxgrow = msg.reader().readShort();
			short str = msg.reader().readShort();
			short agi = msg.reader().readShort();
			short hea = msg.reader().readShort();
			short spi = msg.reader().readShort();
			short maxtiemnang = msg.reader().readShort();
			sbyte b5 = msg.reader().readByte();
			MainInfoItem[] array = new MainInfoItem[(int)b5];
			for (int i = 0; i < (int)b5; i++)
			{
				int id2 = (int)msg.reader().readUnsignedByte();
				int value = msg.reader().readInt();
				int maxDam = msg.reader().readInt();
				array[i] = new MainInfoItem(id2, value, maxDam);
			}
			PetItem petItem = new PetItem((int)id, itemName, (int)b3, (int)b4, (int)b2, catagory, array, (int)b, level, (int)b3, frameNumberImg, petImageId);
			petItem.setInfoPet(age, growPoint, str, agi, hea, spi, maxgrow, maxtiemnang, experience);
			return petItem;
		}
		catch (Exception ex)
		{
		}
		return null;
	}

	// Token: 0x06000AC2 RID: 2754 RVA: 0x000B87B4 File Offset: 0x000B69B4
	private MainItem createItemFromMessage(Message msg)
	{
		try
		{
			int typeMain = 3;
			string itemName = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			short id = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			short imageId = msg.reader().readShort();
			sbyte tier = msg.reader().readByte();
			short level = msg.reader().readShort();
			sbyte b3 = msg.reader().readByte();
			sbyte canSell = msg.reader().readByte();
			sbyte canTrade = msg.reader().readByte();
			sbyte b4 = msg.reader().readByte();
			MainInfoItem[] array = new MainInfoItem[(int)b4];
			for (int i = 0; i < (int)b4; i++)
			{
				sbyte b5 = msg.reader().readByte();
				int value = msg.reader().readInt();
				array[i] = new MainInfoItem((int)b5, value);
			}
			int timeUse = msg.reader().readInt();
			sbyte isLock = msg.reader().readByte();
			return new MainItem((int)id, itemName, (int)imageId, tier, (int)b3, (int)b, typeMain, array, (int)b2, false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock);
		}
		catch (Exception ex)
		{
		}
		return null;
	}

	// Token: 0x06000AC3 RID: 2755 RVA: 0x000B8910 File Offset: 0x000B6B10
	public void UpdatePetContainer(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			mVector vecPetContainer = Item.VecPetContainer;
			if ((int)b2 == 0)
			{
				MainTemplateItem.removeUpdateItemVec((int)b3, vecPetContainer);
				if ((int)b3 == 3)
				{
					sbyte b4 = msg.reader().readByte();
					sbyte b5 = msg.reader().readByte();
					for (int i = 0; i < (int)b5; i++)
					{
						MainItem o = this.createItemFromMessage(msg);
						vecPetContainer.addElement(o);
					}
				}
				else if ((int)b3 == 9)
				{
					sbyte b4 = msg.reader().readByte();
					sbyte b6 = msg.reader().readByte();
					for (int j = 0; j < (int)b6; j++)
					{
						PetItem o2 = this.createPetItemFromMessage(msg);
						vecPetContainer.addElement(o2);
					}
					if (GameScreen.isInPetArea)
					{
						for (int k = 0; k < Item.VecPetContainer.size(); k++)
						{
							PetItem petItem = (PetItem)vecPetContainer.elementAt(k);
							mSystem.outz("pet type " + petItem.type);
							Pet pet = (Pet)MainObject.get_Object(petItem.Id, 9);
							if (GameCanvas.subDialog != null && GameCanvas.subDialog.type == 14 && (int)MsgDialog.isInven_Equip == (int)MsgDialog.INVEN)
							{
								mSystem.outz(" Id item pet in MsgDialog = " + MsgDialog.pet.Id);
								if (MsgDialog.pet.Id == petItem.Id)
								{
									MsgDialog.pet = petItem;
								}
							}
							if (pet == null)
							{
								Pet obj = Pet.createPet((short)petItem.type, petItem.Id, petItem.nFrameImgPet, petItem.petImageId);
								GameScreen.addPlayer(obj);
							}
						}
					}
				}
			}
			else if ((int)b2 == 1)
			{
				if ((int)b3 == 3)
				{
					sbyte b4 = msg.reader().readByte();
					MainItem mainItem = this.createItemFromMessage(msg);
					Item itemVec = Item.getItemVec((int)b4, (short)mainItem.Id, vecPetContainer);
					if (itemVec == null)
					{
						vecPetContainer.addElement(mainItem);
					}
					else
					{
						vecPetContainer.setElementAt(mainItem, vecPetContainer.indexOf(itemVec));
					}
				}
				else if ((int)b3 == 9)
				{
					sbyte b4 = msg.reader().readByte();
					PetItem petItem2 = this.createPetItemFromMessage(msg);
					Item itemVec2 = Item.getItemVec((int)b4, (short)petItem2.Id, vecPetContainer);
					if (itemVec2 == null)
					{
						vecPetContainer.addElement(petItem2);
					}
					else
					{
						vecPetContainer.setElementAt(petItem2, vecPetContainer.indexOf(itemVec2));
					}
					if (GameScreen.isInPetArea)
					{
						Pet obj2 = Pet.createPet((short)petItem2.type, petItem2.Id, petItem2.nFrameImgPet, petItem2.petImageId);
						GameScreen.addPlayer(obj2);
					}
				}
			}
			else if ((int)b2 == 2)
			{
				sbyte b4 = msg.reader().readByte();
				short id = msg.reader().readShort();
				Item itemVec3 = Item.getItemVec((int)b4, id, vecPetContainer);
				if (itemVec3 != null)
				{
					vecPetContainer.removeElement(itemVec3);
				}
				PetItem petItem3 = (PetItem)itemVec3;
				if (petItem3 != null && petItem3.type >= 0)
				{
					Pet pet2 = (Pet)MainObject.get_Item_Object(petItem3.Id, 9);
					if (pet2 != null)
					{
						GameScreen.Vecplayers.removeElement(pet2);
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC4 RID: 2756 RVA: 0x000B8CA0 File Offset: 0x000B6EA0
	public void Dialog_server(Message msg)
	{
		try
		{
			GameCanvas.end_Dialog();
			this.idDialog = msg.reader().readShort();
			this.typeDialog = msg.reader().readByte();
			string str = msg.reader().readUTF();
			mVector mVector = new mVector("ReadMessenge vec4");
			mVector.addElement(new iCommand("Ok", 2, 1, this));
			mVector.addElement(new iCommand(T.cancel, 2, 0, this));
			GameCanvas.start_Select_Dialog(str, mVector);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC5 RID: 2757 RVA: 0x000B8D40 File Offset: 0x000B6F40
	public void update_InVen_Or_Chest(Message msg, mVector vec, sbyte act)
	{
		try
		{
			MainTemplateItem.isload = false;
			if ((int)act == (int)MainTabNew.CHEST)
			{
				Player.maxChest = (short)msg.reader().readByte();
				mSystem.outz("size chest=" + Player.maxChest);
			}
			sbyte b = msg.reader().readByte();
			sbyte b2 = msg.reader().readByte();
			if ((int)act == (int)MainTabNew.INVENTORY)
			{
				long coin = msg.reader().readLong();
				int num = msg.reader().readInt();
				GameScreen.player.coin = coin;
				GameScreen.player.gold = (long)num;
			}
			if ((int)b == 0)
			{
				MainTemplateItem.removeUpdateItemVec((int)b2, vec);
				if ((int)b2 == 4)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					for (int i = 0; i < (int)b4; i++)
					{
						short num2 = msg.reader().readShort();
						short numPotion = msg.reader().readShort();
						sbyte issell = msg.reader().readByte();
						sbyte istrade = msg.reader().readByte();
						MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num2);
						MainItem o = new MainItem((int)num2, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, (int)numPotion, (int)b3, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, issell, istrade);
						vec.addElement(o);
					}
					if ((int)act == (int)MainTabNew.INVENTORY)
					{
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
					}
				}
				else if ((int)b2 == 3)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b5 = msg.reader().readByte();
					for (int j = 0; j < (int)b5; j++)
					{
						string text = msg.reader().readUTF();
						sbyte b6 = msg.reader().readByte();
						short id = msg.reader().readShort();
						sbyte b7 = msg.reader().readByte();
						short imageId = msg.reader().readShort();
						sbyte tier = msg.reader().readByte();
						short level = msg.reader().readShort();
						sbyte b8 = msg.reader().readByte();
						sbyte canSell = msg.reader().readByte();
						sbyte canTrade = msg.reader().readByte();
						sbyte b9 = msg.reader().readByte();
						MainInfoItem[] array = new MainInfoItem[(int)b9];
						for (int k = 0; k < (int)b9; k++)
						{
							int id2 = (int)msg.reader().readUnsignedByte();
							int value = msg.reader().readInt();
							array[k] = new MainInfoItem(id2, value);
							mSystem.outz(string.Concat(new object[]
							{
								"name=",
								text,
								"id=",
								array[k].id,
								"   value=",
								array[k].value
							}));
						}
						int timeUse = msg.reader().readInt();
						sbyte isLock = msg.reader().readByte();
						sbyte b10 = msg.reader().readByte();
						int timeDefault = -1;
						string s = "-1";
						if ((int)b10 == 1)
						{
							timeDefault = msg.reader().readInt();
							s = msg.reader().readUTF();
						}
						sbyte canShell_notCanTrade = msg.reader().readByte();
						MainItem mainItem = new MainItem((int)id, text, (int)imageId, tier, (int)b8, (int)b6, (int)b3, array, (int)b7, false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock, timeDefault, long.Parse(s));
						mainItem.setCanShell_notCanTrade(canShell_notCanTrade);
						vec.addElement(mainItem);
					}
				}
				else if ((int)b2 == 5)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b11 = msg.reader().readByte();
					for (int l = 0; l < (int)b11; l++)
					{
						short id3 = msg.reader().readShort();
						string name = msg.reader().readUTF();
						short numQItem = msg.reader().readShort();
						string questitem = T.questitem;
						sbyte issell2 = msg.reader().readByte();
						sbyte istrade2 = msg.reader().readByte();
						MainItem o2 = new MainItem((int)id3, name, (int)numQItem, questitem, issell2, istrade2);
						vec.addElement(o2);
					}
				}
				else if ((int)b2 == 7)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b12 = msg.reader().readByte();
					for (int m = 0; m < (int)b12; m++)
					{
						short id4 = msg.reader().readShort();
						short num3 = msg.reader().readShort();
						sbyte b13 = msg.reader().readByte();
						sbyte b14 = msg.reader().readByte();
						MainItem material = Item.getMaterial((int)id4);
						if (material != null)
						{
							MainItem o3 = MainItem.MainItem_Material((int)id4, material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, material.value, material.typeMaterial, num3, b13, b14);
							vec.addElement(o3);
						}
						else
						{
							MainItem mainItem2 = new MainItem();
							mainItem2.Id = (int)id4;
							mainItem2.numPotion = (int)num3;
							mainItem2.canSell = b13;
							mainItem2.canTrade = b14;
							mainItem2.ItemCatagory = 7;
							Item.put_Material((int)id4);
							vec.addElement(mainItem2);
						}
					}
				}
				if ((int)act == (int)MainTabNew.INVENTORY && (int)b2 != 3)
				{
					TabShopNew.isSortInven = true;
				}
			}
			else if ((int)b == 1)
			{
				if ((int)b2 == 4)
				{
					sbyte b3 = msg.reader().readByte();
					short num4 = msg.reader().readShort();
					short numPotion2 = msg.reader().readShort();
					sbyte b15 = msg.reader().readByte();
					sbyte b16 = msg.reader().readByte();
					Item itemVec = Item.getItemVec((int)b3, num4, vec);
					if (itemVec != null)
					{
						itemVec.numPotion = (int)numPotion2;
						itemVec.canSell = b15;
						itemVec.canTrade = b16;
					}
					else
					{
						MainTemplateItem mainTemplateItem2 = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num4);
						MainItem o4 = new MainItem((int)num4, mainTemplateItem2.IconId, mainTemplateItem2.name, mainTemplateItem2.contentPotion, (int)numPotion2, (int)b3, mainTemplateItem2.PricePoition, mainTemplateItem2.typePotion, mainTemplateItem2.moneyType, b15, b16);
						vec.addElement(o4);
					}
					if ((int)act == (int)MainTabNew.INVENTORY)
					{
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
						if (GameScreen.help.setStep_Next(1, 5))
						{
							GameScreen.help.Next++;
							GameScreen.help.setNext();
						}
					}
				}
				else if ((int)b2 == 3)
				{
					sbyte b3 = msg.reader().readByte();
					string itemName = msg.reader().readUTF();
					sbyte b17 = msg.reader().readByte();
					short id5 = msg.reader().readShort();
					Item itemVec2 = Item.getItemVec((int)b3, id5, vec);
					sbyte b18 = msg.reader().readByte();
					short imageId2 = msg.reader().readShort();
					sbyte plusItem = msg.reader().readByte();
					short lvItem = msg.reader().readShort();
					sbyte b19 = msg.reader().readByte();
					sbyte issell3 = msg.reader().readByte();
					sbyte istrade3 = msg.reader().readByte();
					sbyte b20 = msg.reader().readByte();
					MainInfoItem[] array2 = new MainInfoItem[(int)b20];
					for (int n = 0; n < (int)b20; n++)
					{
						array2[n] = new MainInfoItem((int)msg.reader().readUnsignedByte(), msg.reader().readInt());
					}
					int timeUse2 = msg.reader().readInt();
					sbyte isLock2 = msg.reader().readByte();
					sbyte b21 = msg.reader().readByte();
					int timeDefault2 = -1;
					string s2 = "-1";
					if ((int)b21 == 1)
					{
						timeDefault2 = msg.reader().readInt();
						s2 = msg.reader().readUTF();
					}
					sbyte canShell_notCanTrade2 = msg.reader().readByte();
					MainItem mainItem3 = MainItem.MainItem_Item((int)id5, itemName, (int)imageId2, plusItem, (int)b19, (int)b17, (int)b3, array2, (int)b18, false, -1, 0L, lvItem, issell3, istrade3, timeUse2, 0, isLock2, timeDefault2, long.Parse(s2));
					mainItem3.setCanShell_notCanTrade(canShell_notCanTrade2);
					if (itemVec2 == null)
					{
						vec.addElement(mainItem3);
					}
					else
					{
						vec.setElementAt(mainItem3, vec.indexOf(itemVec2));
					}
				}
				else if ((int)b2 == 9)
				{
					sbyte b3 = msg.reader().readByte();
					PetItem petItem = this.createPetItemFromMessage(msg);
					Item itemVec3 = Item.getItemVec((int)b3, (short)petItem.Id, vec);
					if (itemVec3 == null)
					{
						vec.addElement(petItem);
					}
					else
					{
						mSystem.outz("replace pet");
						vec.setElementAt(petItem, vec.indexOf(itemVec3));
					}
				}
				else if ((int)b2 == 5)
				{
					sbyte b3 = msg.reader().readByte();
					short id6 = msg.reader().readShort();
					string name2 = msg.reader().readUTF();
					short num5 = msg.reader().readShort();
					string questitem2 = T.questitem;
					sbyte b22 = msg.reader().readByte();
					sbyte b23 = msg.reader().readByte();
					Item itemVec4 = Item.getItemVec((int)b3, id6, vec);
					if (itemVec4 == null)
					{
						MainItem o5 = new MainItem((int)id6, name2, (int)num5, questitem2, b22, b23);
						vec.addElement(o5);
					}
					else
					{
						itemVec4.numPotion = (int)num5;
						itemVec4.canSell = b22;
						itemVec4.canTrade = b23;
					}
				}
				else if ((int)b2 == 7)
				{
					sbyte b3 = msg.reader().readByte();
					short id7 = msg.reader().readShort();
					short num6 = msg.reader().readShort();
					sbyte b24 = msg.reader().readByte();
					sbyte b25 = msg.reader().readByte();
					Item item = Item.getItemVec((int)b3, id7, vec);
					if (item != null)
					{
						item.numPotion = (int)num6;
						item.canSell = b24;
						item.canTrade = b25;
					}
					else
					{
						MainItem material2 = Item.getMaterial((int)id7);
						if (material2 != null)
						{
							item = MainItem.MainItem_Material((int)id7, material2.itemName, material2.imageId, 7, material2.priceItem, material2.priceType, material2.content, (int)material2.canTrade, material2.typeMaterial, num6, b24, b25);
							vec.addElement(item);
						}
						else
						{
							MainItem mainItem4 = new MainItem();
							mainItem4.Id = (int)id7;
							mainItem4.numPotion = (int)num6;
							mainItem4.canSell = b24;
							mainItem4.canTrade = b25;
							mainItem4.ItemCatagory = 7;
							Item.put_Material((int)id7);
							vec.addElement(mainItem4);
						}
					}
					if ((int)act == (int)MainTabNew.INVENTORY)
					{
						for (int num7 = 0; num7 < TabRebuildItem.idMaterial.Length; num7++)
						{
							MainItem material3 = Item.getMaterial((int)TabRebuildItem.idMaterial[num7]);
							int num8 = 0;
							if (material3 != null)
							{
								Item itemInventory = Item.getItemInventory(material3.ItemCatagory, (short)material3.Id);
								if (itemInventory != null)
								{
									num8 = itemInventory.numPotion;
								}
							}
							TabRebuildItem.numMaterialInven[num7] = num8;
						}
					}
				}
				if ((int)act == (int)MainTabNew.INVENTORY)
				{
					if (GameScreen.help.Step == 1 && GameScreen.help.Next == 5)
					{
						GameScreen.help.Next++;
						GameScreen.help.setNext();
					}
					if ((int)b2 != 3)
					{
						TabShopNew.isSortInven = true;
					}
				}
			}
			else if ((int)b == 2)
			{
				sbyte b3 = msg.reader().readByte();
				short id8 = msg.reader().readShort();
				Item itemVec5 = Item.getItemVec((int)b3, id8, vec);
				if (itemVec5 != null)
				{
					vec.removeElement(itemVec5);
				}
				if ((int)act == (int)MainTabNew.INVENTORY)
				{
					if ((int)b2 == 4)
					{
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
					}
					else if ((int)b2 == 7 && (int)act == (int)MainTabNew.INVENTORY)
					{
						for (int num9 = 0; num9 < TabRebuildItem.idMaterial.Length; num9++)
						{
							MainItem mainItem5 = (MainItem)MainTemplateItem.hashMaterialTem.get(string.Empty + TabRebuildItem.idMaterial[num9]);
							int num10 = 0;
							if (mainItem5 != null)
							{
								Item itemInventory2 = Item.getItemInventory(mainItem5.ItemCatagory, (short)mainItem5.Id);
								if (itemInventory2 != null)
								{
									num10 = itemInventory2.numPotion;
								}
							}
							TabRebuildItem.numMaterialInven[num9] = num10;
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
		MainTemplateItem.isload = true;
		MainTabNew.timePaintInfo = 0;
	}

	// Token: 0x06000AC6 RID: 2758 RVA: 0x000B99EC File Offset: 0x000B7BEC
	public void Rebuild_Item(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				short id = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				if ((int)b2 == 3)
				{
					Item itemInventory = Item.getItemInventory((int)b2, id);
					if (itemInventory != null && (int)TabRebuildItem.isBeginEff == 0)
					{
						TabRebuildItem.itemRe = MainItem.MainItem_Item((int)id, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, (int)b2, itemInventory.mInfo, itemInventory.type_Only_Item, false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
					}
				}
				else
				{
					TabRebuildItem.isLucky = true;
				}
				if ((int)TabRebuildItem.isBeginEff == 0)
				{
					TabRebuildItem.tilemayman = msg.reader().readUTF();
					TabRebuildItem.tilemaymanafter = TabRebuildItem.tilemayman;
				}
				else
				{
					TabRebuildItem.tilemaymanafter = msg.reader().readUTF();
				}
			}
			else if ((int)b == 1)
			{
				sbyte b3 = msg.reader().readByte();
				if ((int)b3 == 3)
				{
					TabRebuildItem.itemRe = null;
				}
				else
				{
					TabRebuildItem.isLucky = false;
				}
				if ((int)TabRebuildItem.isBeginEff == 0)
				{
					TabRebuildItem.tilemayman = msg.reader().readUTF();
					TabRebuildItem.tilemaymanafter = TabRebuildItem.tilemayman;
				}
				else
				{
					TabRebuildItem.tilemaymanafter = msg.reader().readUTF();
				}
			}
			else if ((int)b == 2)
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.isBeginEff = 1;
				TabRebuildItem.isNextRebuild = msg.reader().readByte();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				mSystem.outloi("thanh cong hay that bai=" + TabRebuildItem.isNextRebuild);
			}
			else if ((int)b == 3)
			{
				GameCanvas.end_Dialog();
				string name = msg.reader().readUTF();
				GameCanvas.menu2.startAt_NPC(null, name, Menu2.IdNPCLast, 2, false, 0);
			}
			else if ((int)b == 4)
			{
				short id2 = msg.reader().readShort();
				short num = msg.reader().readShort();
				string original = msg.reader().readUTF();
				sbyte b4 = msg.reader().readByte();
				Item itemInventory2 = Item.getItemInventory((int)b4, id2);
				if (itemInventory2 != null)
				{
					TabRebuildItem.itemRe = MainItem.MainItem_Item((int)id2, itemInventory2.itemNameExcludeLv, itemInventory2.imageId, itemInventory2.tier, itemInventory2.colorNameItem, itemInventory2.classcharItem, (int)b4, itemInventory2.mInfo, itemInventory2.type_Only_Item, false, itemInventory2.IdTem, itemInventory2.priceItem, (short)itemInventory2.LvItem, itemInventory2.canSell, itemInventory2.canTrade, 0, 0, 0);
					TabRebuildItem.itemRe.itemClone = null;
					TabRebuildItem.itemRe.infoHop = mSystem.split(original, "|");
					MainItem material = Item.getMaterial(TabRebuildItem.itemRe.Id);
					if (material != null)
					{
						TabRebuildItem.itemRe.itemName = material.itemName;
					}
					int id3 = (int)num;
					MainItem material2 = Item.getMaterial(id3);
					if (material2 != null)
					{
						if (material2.isMaterialHopNguyenLieu())
						{
							TabRebuildItem.itemRe.itemClone = material2.clone();
						}
					}
					else
					{
						MainItem mainItem = new MainItem();
						mainItem.Id = id3;
						mainItem.ItemCatagory = 7;
						TabRebuildItem.itemRe.itemClone = mainItem;
					}
				}
			}
			else if ((int)b == 5)
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.isBeginEff = 1;
				TabRebuildItem.isNextRebuild = msg.reader().readByte();
				TabRebuildItem.contentShow = msg.reader().readUTF();
			}
			else if ((int)b == 6)
			{
				TabRebuildItem.itemRe = null;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC7 RID: 2759 RVA: 0x000B9DAC File Offset: 0x000B7FAC
	public void ReplacePlusItem(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				short id = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				Item itemInventory = Item.getItemInventory(3, id);
				if (itemInventory != null)
				{
					if ((int)b2 == 1)
					{
						TabRebuildItem.itemPlus = MainItem.MainItem_Item((int)id, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
					}
					else if ((int)b2 == 0)
					{
						TabRebuildItem.itemFree = MainItem.MainItem_Item((int)id, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
					}
				}
				else
				{
					mSystem.outz("k le no null=");
				}
			}
			else if ((int)b == 1)
			{
				GameCanvas.end_Dialog();
				short num = msg.reader().readShort();
				if (TabRebuildItem.itemPlus != null && TabRebuildItem.itemFree != null)
				{
					mVector mVector = new mVector("ReadMessenge menu3");
					mVector.addElement(new iCommand(T.replace, 4, this));
					GameCanvas.menu2.startAt_NPC(mVector, string.Concat(new object[]
					{
						T.hoichuyendo,
						TabRebuildItem.itemPlus.itemName,
						T.qua,
						TabRebuildItem.itemFree.itemName,
						"? ",
						T.phi,
						": ",
						num,
						" ",
						T.gem,
						"."
					}), Menu2.IdNPCLast, 2, false, 0);
				}
			}
			else if ((int)b == 2)
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				TabRebuildItem.isBeginEff = 1;
			}
			else if ((int)b == 3)
			{
				GameCanvas.end_Dialog();
				string name = msg.reader().readUTF();
				GameCanvas.menu2.startAt_NPC(null, name, Menu2.IdNPCLast, 2, false, 0);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC8 RID: 2760 RVA: 0x000BA028 File Offset: 0x000B8228
	public void Thach_Dau(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				string namecheck = msg.reader().readUTF();
				short numThachdau = msg.reader().readShort();
				GameCanvas.mevent.addEvent(namecheck, 4, T.loimoithachdau, (int)numThachdau);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AC9 RID: 2761 RVA: 0x000BA09C File Offset: 0x000B829C
	public void Help_From_Server(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)b, 2);
			if (mainObject != null && !mainObject.isRemove)
			{
				string original = msg.reader().readUTF();
				MainObject.strHelpNPC = mFont.split(original, "\b");
				MainObject.StepHelpServer = 0;
				mVector mVector = new mVector("ReadMessenge menu2");
				iCommand o = new iCommand(T.next, 3, (int)b, this);
				mVector.addElement(o);
				GameCanvas.menu2.startAt_NPC(mVector, MainObject.strHelpNPC[0], (int)b, 2, false, 2);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ACA RID: 2762 RVA: 0x000BA158 File Offset: 0x000B8358
	public void Clan(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("nhan mess bang=" + b);
			string text = string.Empty;
			string text2 = string.Empty;
			sbyte b2 = 122;
			short num = 0;
			switch (b)
			{
			case 10:
				text = msg.reader().readUTF();
				GameCanvas.mevent.addEvent(text, 5, T.loimoivaoclan, 0);
				break;
			case 14:
			{
				text = msg.reader().readUTF();
				short num2 = msg.reader().readShort();
				b2 = msg.reader().readByte();
				long num3 = msg.reader().readLong();
				int num4 = msg.reader().readInt();
				GameCanvas.start_Ok_Dialog(string.Concat(new object[]
				{
					T.thanhvien,
					": ",
					text,
					" ",
					T.level,
					num2,
					"\n",
					T.chucvu,
					MainClan.getNameChucVu(b2),
					"\n",
					T.gop,
					T.coin,
					": ",
					num3,
					"\n",
					T.gop,
					T.gem,
					": ",
					num4
				}));
				break;
			}
			case 15:
			{
				sbyte b3 = msg.reader().readByte();
				sbyte b4 = msg.reader().readByte();
				if ((int)b4 == 0)
				{
					int idClan = msg.reader().readInt();
					num = msg.reader().readShort();
					text2 = msg.reader().readUTF();
					text = msg.reader().readUTF();
					short lv = msg.reader().readShort();
					short ptlv = msg.reader().readShort();
					short hang = msg.reader().readShort();
					short numMem = msg.reader().readShort();
					short maxMem = msg.reader().readShort();
					string nameBoss = msg.reader().readUTF();
					string slogan = msg.reader().readUTF();
					string noiquy = msg.reader().readUTF();
					long num3 = msg.reader().readLong();
					int num4 = msg.reader().readInt();
					sbyte b5 = msg.reader().readByte();
					MainThanhTichClan[] array = null;
					if ((int)b5 > 0)
					{
						array = new MainThanhTichClan[(int)b5];
						for (int i = 0; i < array.Length; i++)
						{
							array[i] = new MainThanhTichClan(msg.reader().readByte(), msg.reader().readByte(), msg.reader().readUTF());
						}
					}
					if ((int)b3 == 0)
					{
						if (GameScreen.player.myClan == null)
						{
							GameScreen.player.myClan = new MainClan(idClan, num, text2, 122);
						}
						GameScreen.player.myClan.setInfoClan(text, lv, ptlv, hang, numMem, maxMem, slogan, noiquy, nameBoss, num3, num4, array);
						if (GameCanvas.clan == null)
						{
							GameCanvas.clan = new Clan_Screen();
						}
						GameCanvas.clan.setInfoClan(GameScreen.player.myClan, b3);
						GameCanvas.clan.Show(GameCanvas.currentScreen);
					}
					else
					{
						MainClan mainClan = new MainClan(idClan, num, text2, 122);
						mainClan.setInfoClan(text, lv, ptlv, hang, numMem, maxMem, slogan, noiquy, nameBoss, num3, num4, array);
						if (GameCanvas.clan == null)
						{
							GameCanvas.clan = new Clan_Screen();
						}
						GameCanvas.clan.setInfoClan(mainClan, b3);
						GameCanvas.clan.Show(GameCanvas.currentScreen);
					}
					GameCanvas.end_Dialog();
				}
				else if ((int)b4 == 1)
				{
					if (GameScreen.player.myClan != null)
					{
						GameScreen.player.myClan.coin = msg.reader().readLong();
						GameScreen.player.myClan.gold = msg.reader().readInt();
					}
				}
				else if ((int)b4 == 2)
				{
					if (GameScreen.player.myClan != null)
					{
						GameScreen.player.myClan.noiquy = msg.reader().readUTF();
						Clan_Screen.isUpdateThongTin = true;
					}
				}
				else if ((int)b4 == 3 && GameScreen.player.myClan != null)
				{
					GameScreen.player.myClan.slogan = msg.reader().readUTF();
					Clan_Screen.isUpdateThongTin = true;
				}
				break;
			}
			case 19:
			{
				short num5 = msg.reader().readShort();
				string strB = msg.reader().readUTF();
				int num6 = msg.reader().readInt();
				if (num6 != -1)
				{
					text = msg.reader().readUTF();
					text2 = msg.reader().readUTF();
					num = msg.reader().readShort();
					b2 = msg.reader().readByte();
				}
				if (num5 != 32000)
				{
					MainObject mainObject = MainObject.get_Object((int)num5, 0);
					if (mainObject != null)
					{
						if (num6 == -1)
						{
							if (mainObject.myClan != null)
							{
								mainObject.myClan.isRemove = true;
							}
						}
						else if (mainObject.myClan == null)
						{
							mainObject.myClan = new MainClan(num6, num, text2, b2);
						}
						else
						{
							mainObject.myClan.IdClan = num6;
							mainObject.myClan.IdIcon = num;
							mainObject.myClan.shortName = text2.ToUpper();
							mainObject.myClan.chucvu = b2;
						}
					}
				}
				if (GameCanvas.currentScreen == List_Server.gI() && (int)List_Server.gI().typeList == 4)
				{
					for (int j = 0; j < List_Server.gI().vecListServer.size(); j++)
					{
						MainObject mainObject2 = (MainObject)List_Server.gI().vecListServer.elementAt(j);
						if (mainObject2.name.CompareTo(strB) == 0)
						{
							if (mainObject2.myClan != null)
							{
								if (num6 == -1)
								{
									mainObject2.myClan.chucvu = 121;
								}
								else
								{
									mainObject2.myClan.chucvu = b2;
								}
							}
							break;
						}
					}
				}
				break;
			}
			case 20:
			{
				string str = msg.reader().readUTF();
				GameCanvas.start_Ok_Dialog(str);
				break;
			}
			case 21:
			{
				sbyte b6 = msg.reader().readByte();
				mSystem.outz("typeinven=" + b6);
				if ((int)b6 == 3)
				{
					Item.VecClanInvetory.removeAllElements();
					short num7 = msg.reader().readShort();
					for (int k = 0; k < (int)num7; k++)
					{
						short num8 = msg.reader().readShort();
						short numPotion = msg.reader().readShort();
						MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num8);
						MainItem o = new MainItem((int)num8, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, (int)numPotion, 4, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, 0, 0);
						Item.VecClanInvetory.addElement(o);
					}
					mVector mVector = new mVector("ReadMessenge vec3");
					TabShopNew o2 = new TabShopNew(Item.VecClanInvetory, MainTabNew.CLAN_INVENTORY, T.tabBangHoi, -1, TabShopNew.NORMAL);
					mVector.addElement(o2);
					GameCanvas.shopNpc = new TabScreenNew();
					GameCanvas.shopNpc.selectTab = 0;
					GameCanvas.shopNpc.addMoreTab(mVector);
					GameCanvas.shopNpc.Show(GameScreen.gI());
					GameCanvas.end_Dialog();
				}
				else if ((int)b6 == 2)
				{
					short id = msg.reader().readShort();
					Item itemVec = Item.getItemVec(4, id, Item.VecClanInvetory);
					if (itemVec != null)
					{
						Item.VecClanInvetory.removeElement(itemVec);
					}
				}
				else if ((int)b6 == 0)
				{
					short num9 = msg.reader().readShort();
					short num10 = msg.reader().readShort();
					Item itemVec2 = Item.getItemVec(4, num9, Item.VecClanInvetory);
					if (itemVec2 != null)
					{
						itemVec2.numPotion = (int)num10;
						mSystem.outz("num=" + num10);
					}
					else
					{
						MainTemplateItem mainTemplateItem2 = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num9);
						MainItem o3 = new MainItem((int)num9, mainTemplateItem2.IconId, mainTemplateItem2.name, mainTemplateItem2.contentPotion, (int)num10, 4, mainTemplateItem2.PricePoition, mainTemplateItem2.typePotion, mainTemplateItem2.moneyType, 0, 0);
						Item.VecClanInvetory.addElement(o3);
					}
				}
				break;
			}
			case 22:
				if (GameScreen.player.myClan != null)
				{
					GameScreen.player.myClan.typeX2 = msg.reader().readByte();
					GameScreen.player.myClan.timeX2 = msg.reader().readShort();
					mSystem.outz(string.Concat(new object[]
					{
						"type=",
						GameScreen.player.myClan.typeX2,
						"time=",
						GameScreen.player.myClan.timeX2
					}));
				}
				break;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ACB RID: 2763 RVA: 0x000BAAD4 File Offset: 0x000B8CD4
	public void updateHpNPC(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short hp = msg.reader().readShort();
			short maxHp = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)b2, 2);
			if (mainObject != null && !mainObject.isRemove)
			{
				mainObject.hp = (int)hp;
				mainObject.maxHp = (int)maxHp;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ACC RID: 2764 RVA: 0x000BAB68 File Offset: 0x000B8D68
	public void Dialog_More_server(Message msg)
	{
		try
		{
			GameCanvas.end_Dialog();
			this.idDialog = msg.reader().readShort();
			this.typeDialog = msg.reader().readByte();
			string name = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			string[] array = new string[(int)b];
			string[] array2 = new string[(int)b];
			sbyte typemo = 1;
			sbyte[] array3 = new sbyte[(int)b];
			for (int i = 0; i < (int)b; i++)
			{
				array[i] = msg.reader().readUTF();
				array3[i] = msg.reader().readByte();
				array2[i] = string.Empty;
			}
			try
			{
				for (int j = 0; j < (int)b; j++)
				{
					array2[j] = msg.reader().readUTF();
				}
				typemo = msg.reader().readByte();
			}
			catch (Exception ex)
			{
			}
			GameCanvas.start_More_Input_Dialog(array, new iCommand("OK", 1), (short)this.typeDialog, this.idDialog, name, array2, typemo);
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x06000ACD RID: 2765 RVA: 0x000BACB0 File Offset: 0x000B8EB0
	public void InfoEasyFromServer(Message msg)
	{
		try
		{
			string str = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				GameCanvas.addInfoChar(str);
			}
			else if ((int)b == 1)
			{
				GameCanvas.addInfoCharServer(str);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ACE RID: 2766 RVA: 0x000BAD1C File Offset: 0x000B8F1C
	public void EffFormServer(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte tem = msg.reader().readByte();
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			short idFrom = msg.reader().readShort();
			MainObject mainObject = MainObject.get_Object((int)num, tem);
			if ((int)b >= 0 && mainObject != null && !mainObject.isRemove)
			{
				switch (b)
				{
				case 0:
					GameScreen.addEffectEndKill(38, mainObject.x, mainObject.y - 20);
					break;
				case 1:
					mSystem.outz(string.Concat(new object[]
					{
						"time=",
						num2,
						" 00000000000000 =",
						mainObject.name
					}));
					for (int i = 0; i < EffectManager.hiEffects.size(); i++)
					{
						MainEffect mainEffect = (MainEffect)EffectManager.hiEffects.elementAt(i);
						if (mainEffect.typeEffect == 85 && mainEffect.objBeKillMain != null && mainEffect.objBeKillMain.ID == (int)num)
						{
							if (num2 == 0)
							{
								mainEffect.isStop = true;
							}
							return;
						}
					}
					GameScreen.addEffectKill(85, mainObject.x, mainObject.y, (int)num2, num, tem);
					break;
				case 2:
					for (int j = 0; j < EffectManager.hiEffects.size(); j++)
					{
						MainEffect mainEffect2 = (MainEffect)EffectManager.hiEffects.elementAt(j);
						if (mainEffect2.typeEffect == 87 && mainEffect2.objBeKillMain != null && mainEffect2.objBeKillMain.ID == (int)num && num2 == 0)
						{
							mainEffect2.isStop = true;
							return;
						}
					}
					GameScreen.addEffectKill(87, mainObject.x, mainObject.y, (int)num2, num, tem);
					break;
				case 3:
					GameScreen.addEffectEndKill(43, mainObject.x, mainObject.y);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 4:
					GameScreen.checkAddEff(94, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 5:
					GameScreen.checkAddEff(100, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 6:
					GameScreen.checkAddEff(101, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 7:
					GameScreen.checkAddEff(102, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 8:
					GameScreen.checkAddEff(107, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 9:
					mainObject.beginFire();
					GameScreen.checkAddEff(103, mainObject.x, mainObject.y, (int)num2, num, tem, idFrom, 1, false);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 10:
					mainObject.addnewBuff(12, (int)num2);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 11:
					mainObject.addnewBuff(13, (int)num2);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 12:
					mainObject.addnewBuff(11, (int)num2);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				case 13:
					mainObject.addnewBuff(14, (int)num2);
					if ((int)b2 > 0)
					{
						LoadMap.timeVibrateScreen = (int)b2;
					}
					break;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ACF RID: 2767 RVA: 0x000BB150 File Offset: 0x000B9350
	public void EffWeather(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == -1)
			{
				for (int i = 0; i < GameScreen.vecWeather.size(); i++)
				{
					AnimateEffect animateEffect = (AnimateEffect)GameScreen.vecWeather.elementAt(i);
					if ((int)animateEffect.type == 0 || (int)animateEffect.type == 2 || (int)animateEffect.type == 1 || (int)animateEffect.type == 4)
					{
						animateEffect.stop();
					}
				}
			}
			else
			{
				short num = msg.reader().readShort();
				short num2 = msg.reader().readShort();
				mSystem.outz("okiiiiiiiiiiiiiiiiiii888888888888888=" + num2);
				if (num2 == 0)
				{
					for (int j = 0; j < GameScreen.vecWeather.size(); j++)
					{
						AnimateEffect animateEffect2 = (AnimateEffect)GameScreen.vecWeather.elementAt(j);
						if ((int)animateEffect2.type == (int)b)
						{
							mSystem.outz("okiiiiiiiiiiiiiiiiiii888888888888888huy mua");
							animateEffect2.isStop = true;
							break;
						}
					}
				}
				else if ((int)b == 0 || (int)b == 2 || (int)b == 1 || (int)b == 4)
				{
					mSystem.outz(string.Concat(new object[]
					{
						"okiiiiiiiiiiiiiiiiiii888888888888888=",
						b,
						"    num=",
						num
					}));
					for (int k = 0; k < GameScreen.vecWeather.size(); k++)
					{
						AnimateEffect animateEffect3 = (AnimateEffect)GameScreen.vecWeather.elementAt(k);
						if ((int)animateEffect3.type == (int)b)
						{
							animateEffect3.isStop = true;
							break;
						}
					}
					GameScreen.AddEffWeather(b, true, (int)num, (int)num2);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD0 RID: 2768 RVA: 0x000BB340 File Offset: 0x000B9540
	public void Num_Eff(Message msg)
	{
		try
		{
			sbyte tem = msg.reader().readByte();
			short id = msg.reader().readShort();
			string content = msg.reader().readUTF();
			sbyte b = msg.reader().readByte();
			MainObject mainObject = MainObject.get_Object((int)id, tem);
			if (mainObject != null && !mainObject.isRemove)
			{
				GameScreen.addEffectNum(content, mainObject.x, mainObject.y - mainObject.hOne / 2, 8, (int)b);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD1 RID: 2769 RVA: 0x000BB3E4 File Offset: 0x000B95E4
	public void Rebuild_Wing(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				TabRebuildItem.isChetao = msg.reader().readInt();
				TabRebuildItem.nameWing = msg.reader().readUTF();
				TabRebuildItem.priceWing = msg.reader().readInt();
				TabRebuildItem.lvReWing = msg.reader().readShort();
				TabRebuildItem.timeUseWing = msg.reader().readInt();
				sbyte b2 = msg.reader().readByte();
				TabRebuildItem.dataWing = new DataRebuildItem[(int)b2];
				for (int i = 0; i < (int)b2; i++)
				{
					short id = msg.reader().readShort();
					short valueWing = msg.reader().readShort();
					TabRebuildItem.dataWing[i] = new DataRebuildItem(id, valueWing);
				}
				TabRebuildItem.numWingMaterialInven = new int[(int)b2];
				for (int j = 0; j < TabRebuildItem.dataWing.Length; j++)
				{
					MainItem material = Item.getMaterial((int)TabRebuildItem.dataWing[j].id);
					int num = 0;
					if (material != null)
					{
						Item itemInventory = Item.getItemInventory(material.ItemCatagory, (short)material.Id);
						if (itemInventory != null)
						{
							num = itemInventory.numPotion;
						}
					}
					TabRebuildItem.numWingMaterialInven[j] = num;
				}
			}
			else if ((int)b == 1)
			{
				string name = msg.reader().readUTF();
				TabRebuildItem.itemWing = null;
				mVector mVector = new mVector("ReadMessenge vec12");
				TabShopNew o = new TabShopNew(Item.VecInvetoryPlayer, MainTabNew.INVENTORY, T.tabhanhtrang, -1, TabShopNew.INVEN_AND_WING);
				mVector.addElement(o);
				MainTabNew mainTabNew = new TabRebuildItem(name, TabRebuildItem.TYPE_REBUILD_WING);
				mVector.addElement(mainTabNew);
				GameCanvas.shopNpc = new TabScreenNew();
				GameCanvas.shopNpc.selectTab = 1;
				GameCanvas.shopNpc.addMoreTab(mVector);
				GameCanvas.shopNpc.Show(GameScreen.gI());
				GameCanvas.end_Dialog();
				mainTabNew.init();
			}
			else if ((int)b == 2)
			{
				short num2 = msg.reader().readShort();
				if (num2 == -1)
				{
					TabRebuildItem.itemWing = null;
				}
				else
				{
					Item itemInventory2 = Item.getItemInventory(3, num2);
					if (itemInventory2 != null && (int)TabRebuildItem.isBeginEff == 0)
					{
						TabRebuildItem.itemWing = MainItem.MainItem_Item((int)num2, itemInventory2.itemNameExcludeLv, itemInventory2.imageId, itemInventory2.tier, itemInventory2.colorNameItem, itemInventory2.classcharItem, 3, itemInventory2.mInfo, itemInventory2.type_Only_Item, false, itemInventory2.IdTem, itemInventory2.priceItem, (short)itemInventory2.LvItem, itemInventory2.canSell, itemInventory2.canTrade, 0, 0, 0);
					}
				}
			}
			else if ((int)b == 5)
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				TabRebuildItem.idWingOk = msg.reader().readShort();
				TabRebuildItem.isBeginEff = 1;
			}
			else if ((int)b == 4)
			{
				GameCanvas.end_Dialog();
				string name2 = msg.reader().readUTF();
				GameCanvas.menu2.startAt_NPC(null, name2, Menu2.IdNPCLast, 2, false, 0);
			}
			else if ((int)b == 6)
			{
				TabRebuildItem.itemWing = null;
				TabRebuildItem.dataWing = null;
				TabRebuildItem.priceWing = 0;
				TabRebuildItem.timeUseWing = 0;
				TabRebuildItem.nameWing = string.Empty;
				TabRebuildItem.isChetao = 0;
				TabRebuildItem.lvReWing = 0;
				TabRebuildItem.idWingOk = 0;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD2 RID: 2770 RVA: 0x000BB748 File Offset: 0x000B9948
	public void Open_Box(Message msg)
	{
		try
		{
			string name = msg.reader().readUTF();
			int num = (int)msg.reader().readByte();
			MainItem[] array = new MainItem[num];
			for (int i = 0; i < num; i++)
			{
				string name2 = msg.reader().readUTF();
				short idIcon = msg.reader().readShort();
				int numPo = msg.reader().readInt();
				sbyte item_potion = msg.reader().readByte();
				sbyte lvup = msg.reader().readByte();
				sbyte b = msg.reader().readByte();
				mSystem.outz("color=" + b);
				array[i] = new MainItem(name2, (int)idIcon, numPo, item_potion, lvup, b);
			}
			string info = msg.reader().readUTF();
			sbyte typeOpen = msg.reader().readByte();
			sbyte isLottery = msg.reader().readByte();
			if (num != 0)
			{
				GameCanvas.start_Open_Box(name, info, array, typeOpen, isLottery);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD3 RID: 2771 RVA: 0x000BB868 File Offset: 0x000B9A68
	public void UpdateDataAndroid(Message msg)
	{
		try
		{
			GameCanvas.IndexCharPar = msg.reader().readShort();
			short maxupdate = msg.reader().readShort();
			GameCanvas.start_Update_Data();
			MsgDialog.curupdate = 0;
			MsgDialog.maxupdate = (int)maxupdate;
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD4 RID: 2772 RVA: 0x000BB8CC File Offset: 0x000B9ACC
	public void SoSanhDataAndroid(Message msg)
	{
		try
		{
			GameCanvas.IndexCharPar = msg.reader().readShort();
			short num = msg.reader().readShort();
			int num2 = 0;
			for (int i = 0; i < (int)num; i++)
			{
				sbyte b = msg.reader().readByte();
				short num3 = msg.reader().readShort();
				int num4 = msg.reader().readInt();
				try
				{
					bool flag = false;
					sbyte[] array = CRes.loadRMS(string.Concat(new object[]
					{
						"img_data_char_",
						b,
						"_",
						num3
					}));
					if (array == null)
					{
						flag = true;
					}
					else
					{
						DataInputStream dataInputStream = new DataInputStream(array);
						short num5 = dataInputStream.readShort();
						if (num4 != (int)num5)
						{
							flag = true;
						}
					}
					if (flag)
					{
						GlobalService.gI().load_image_data_part_char(b, num3);
						num2++;
					}
				}
				catch (Exception ex)
				{
				}
			}
			if (num2 > 0)
			{
				GameCanvas.start_Update_Data();
				MsgDialog.curupdate = 0;
				MsgDialog.maxupdate = num2;
			}
			mSystem.outz("==========" + GameCanvas.IndexCharPar);
		}
		catch (Exception ex2)
		{
		}
	}

	// Token: 0x06000AD5 RID: 2773 RVA: 0x000BBA2C File Offset: 0x000B9C2C
	public void useMount(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = b;
			if (b2 != 0)
			{
				if (b2 == 1)
				{
					sbyte b3 = msg.reader().readByte();
					sbyte b4 = msg.reader().readByte();
					short id = msg.reader().readShort();
					short r = msg.reader().readShort();
					MainObject mainObject = MainObject.get_Object((int)id, 1);
					if (mainObject != null)
					{
						mainObject.setEffectauto((int)b4, (int)r, (short)b3);
					}
				}
			}
			else
			{
				sbyte typeMount = msg.reader().readByte();
				short id2 = msg.reader().readShort();
				MainObject mainObject2 = MainObject.get_Object((int)id2, 0);
				if (mainObject2 != null)
				{
					mainObject2.typeMount = typeMount;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD6 RID: 2774 RVA: 0x000BBB18 File Offset: 0x000B9D18
	public void monsterSkillInfo(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			mSystem.outz("size = " + b);
			for (int i = 0; i < (int)b; i++)
			{
				sbyte b2 = msg.reader().readByte();
				sbyte b3 = msg.reader().readByte();
				short num = msg.reader().readShort();
				Monster_Skill.hashMonsterSkillInfo.put(string.Empty + b2, num);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD7 RID: 2775 RVA: 0x000BBBC8 File Offset: 0x000B9DC8
	public void monsterDetonate(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte tem = msg.reader().readByte();
			short id = msg.reader().readShort();
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			sbyte b2 = msg.reader().readByte();
			sbyte b3 = msg.reader().readByte();
			sbyte b4 = msg.reader().readByte();
			sbyte b5 = msg.reader().readByte();
			sbyte b6 = msg.reader().readByte();
			sbyte b7 = msg.reader().readByte();
			MainMonster mainMonster = (MainMonster)MainObject.get_Object((int)id, tem);
			sbyte b8 = b;
			if (b8 != 0)
			{
				if (b8 == 1)
				{
					switch (b2)
					{
					case 0:
						GameScreen.addEffectEndKill(38, mainMonster.x, mainMonster.y - 20);
						break;
					case 1:
						GameScreen.addEffectKill(85, mainMonster.x, mainMonster.y, (int)b3, id, tem);
						break;
					case 2:
						GameScreen.addEffectKill(87, mainMonster.x, mainMonster.y, (int)b3, id, tem);
						break;
					case 3:
						GameScreen.addEffectEndKill(36, mainMonster.x, mainMonster.y);
						break;
					}
					mainMonster.x = (int)num;
					mainMonster.y = (int)num2;
					switch (b4)
					{
					case 0:
						GameScreen.addEffectEndKill(38, mainMonster.x, mainMonster.y - 20);
						break;
					case 1:
						GameScreen.addEffectKill(85, mainMonster.x, mainMonster.y, (int)b5, id, tem);
						break;
					case 2:
						GameScreen.addEffectKill(87, mainMonster.x, mainMonster.y, (int)b5, id, tem);
						break;
					case 3:
						mainMonster.isDetonateInDest = true;
						break;
					}
				}
			}
			else
			{
				mainMonster.vMax = 8;
				mainMonster.toX = (int)num;
				mainMonster.toY = (int)num2;
				mainMonster.isDetonateInDest = true;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD8 RID: 2776 RVA: 0x000BBE0C File Offset: 0x000BA00C
	public void petGainXP(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			short num2 = msg.reader().readShort();
			short num3 = msg.reader().readShort();
			int num4 = msg.reader().readInt();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AD9 RID: 2777 RVA: 0x000BBE74 File Offset: 0x000BA074
	public void receiveLotteryReward(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				Item.VecLotteryReward.removeAllElements();
				sbyte b2 = msg.reader().readByte();
				for (int i = 0; i < (int)b2; i++)
				{
					sbyte b3 = msg.reader().readByte();
					if ((int)b3 == 3)
					{
						string itemName = msg.reader().readUTF();
						sbyte b4 = msg.reader().readByte();
						short id = msg.reader().readShort();
						sbyte b5 = msg.reader().readByte();
						short imageId = msg.reader().readShort();
						sbyte tier = msg.reader().readByte();
						short level = msg.reader().readShort();
						sbyte b6 = msg.reader().readByte();
						sbyte b7 = msg.reader().readByte();
						MainInfoItem[] array = new MainInfoItem[(int)b7];
						for (int j = 0; j < (int)b7; j++)
						{
							sbyte b8 = msg.reader().readByte();
							int value = msg.reader().readInt();
							array[j] = new MainInfoItem((int)b8, value);
						}
						MainItem o = new MainItem((int)id, itemName, (int)imageId, tier, (int)b6, (int)b4, (int)b3, array, (int)b5, false, -1, 0L, level, 0, 0, -1, 0, 0);
						Item.VecLotteryReward.addElement(o);
					}
					else if ((int)b3 == 4)
					{
						short num = msg.reader().readShort();
						short numPotion = msg.reader().readShort();
						MainTemplateItem mainTemplateItem = (MainTemplateItem)MainTemplateItem.hashPotionTem.get(string.Empty + num);
						MainItem o2 = new MainItem((int)num, mainTemplateItem.IconId, mainTemplateItem.name, mainTemplateItem.contentPotion, (int)numPotion, 4, mainTemplateItem.PricePoition, mainTemplateItem.typePotion, mainTemplateItem.moneyType, 0, 0);
						Item.VecLotteryReward.addElement(o2);
					}
					else if ((int)b3 == 7)
					{
						short id2 = msg.reader().readShort();
						short num2 = msg.reader().readShort();
						MainItem material = Item.getMaterial((int)id2);
						if (material != null)
						{
							MainItem o3 = MainItem.MainItem_Material((int)id2, material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, material.value, material.typeMaterial, num2, 0, 0);
							Item.VecLotteryReward.addElement(o3);
						}
						else
						{
							MainItem mainItem = new MainItem();
							mainItem.Id = (int)id2;
							mainItem.ItemCatagory = 7;
							mainItem.numPotion = (int)num2;
							Item.VecLotteryReward.addElement(mainItem);
						}
					}
				}
				mVector mVector = new mVector("ReadMessenge vec13");
				MainTabNew o4 = new TabLottery(T.moly, Item.VecLotteryReward, 0);
				mVector.addElement(o4);
				GameCanvas.shopNpc = new TabScreenNew();
				GameCanvas.shopNpc.selectTab = 0;
				GameCanvas.shopNpc.addMoreTab(mVector);
				GameCanvas.shopNpc.Show(GameScreen.gI());
				GameCanvas.end_Dialog();
			}
			else if ((int)b == 1)
			{
				sbyte b9 = msg.reader().readByte();
				sbyte b10 = msg.reader().readByte();
				TabLottery.changeSection(1);
				TabLottery.setLuckyNumber(b10);
				TabLottery.isReady = false;
				mSystem.outz("itemIndex = " + b9);
				mSystem.outz("posIndex = " + b10);
			}
			else if ((int)b == 2)
			{
				sbyte b11 = msg.reader().readByte();
				if ((int)b11 == 1)
				{
					mSystem.outz("Trung ------------");
					sbyte b12 = msg.reader().readByte();
					sbyte luckyNumber = msg.reader().readByte();
					TabLottery.setLuckyNumber(luckyNumber);
					TabLottery.isWin = true;
				}
				else
				{
					mSystem.outz("Ko Trung ------------");
					sbyte b13 = msg.reader().readByte();
					mSystem.outz("luckyNumber ------------ " + b13);
					sbyte b14 = msg.reader().readByte();
					TabLottery.setLuckyNumber(b13);
					TabLottery.isWin = false;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADA RID: 2778 RVA: 0x000BC290 File Offset: 0x000BA490
	public void writeUserAccountInfoToRMS(Message msg)
	{
		try
		{
			string text = msg.reader().readUTF();
			string text2 = msg.reader().readUTF();
			DataOutputStream dataOutputStream = new DataOutputStream();
			dataOutputStream.writeUTF(text);
			dataOutputStream.writeUTF(text2);
			CRes.saveRMS("user_pass", dataOutputStream.toByteArray());
			dataOutputStream.close();
			LoginScreen.userSv = text;
			LoginScreen.tfusername.setText(text);
			LoginScreen.tfpassword.setText(text2);
			LoginScreen.username = text;
			LoginScreen.password = text2;
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADB RID: 2779 RVA: 0x000BC330 File Offset: 0x000BA530
	public void UpdateInfoArena(Message msg)
	{
		try
		{
			sbyte type = msg.reader().readByte();
			sbyte totalHouse = msg.reader().readByte();
			short totalPlayer = msg.reader().readShort();
			sbyte b = msg.reader().readByte();
			GameScreen.infoGame.setSttArena(type, totalHouse, totalPlayer);
			if ((int)b == 0)
			{
				long timeArena = msg.reader().readLong();
				GameScreen.timeArena = timeArena;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADC RID: 2780 RVA: 0x000BC3C0 File Offset: 0x000BA5C0
	public void updateMarkKiller(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			if ((int)b == 0)
			{
				short id = msg.reader().readShort();
				short markKiller = msg.reader().readShort();
				MainObject mainObject = MainObject.get_Object((int)id, 0);
				if (mainObject != null)
				{
					mainObject.markKiller = markKiller;
				}
			}
			else if ((int)b == 1)
			{
				ItemMap.isPaintDieHouseArena = true;
			}
			else if ((int)b == 2)
			{
				short id2 = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				MainObject mainObject2 = MainObject.get_Object((int)id2, 1);
				if (mainObject2 != null && (int)b2 != 0)
				{
					mainObject2.addeffAuto((int)b2, mainObject2.x, mainObject2.y, 0, 0, ((int)b2 != 57) ? 0 : 2, 0);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADD RID: 2781 RVA: 0x000BC4B4 File Offset: 0x000BA6B4
	public void useItemArena(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				sbyte b = msg.reader().readByte();
				if ((int)b == 1)
				{
					EffectMonster.buffDame = true;
				}
				else
				{
					EffectMonster.buffDame = false;
				}
				break;
			}
			case 1:
			{
				short idImageHenshin = msg.reader().readShort();
				short id = msg.reader().readShort();
				MainObject mainObject = MainObject.get_Object((int)id, 0);
				if (mainObject != null)
				{
					mainObject.idImageHenshin = idImageHenshin;
				}
				break;
			}
			case 2:
			{
				sbyte b2 = msg.reader().readByte();
				short id2 = msg.reader().readShort();
				MainObject mainObject2 = MainObject.get_Object((int)id2, 0);
				if (mainObject2 != null)
				{
					if ((int)b2 == 1)
					{
						mainObject2.isPaint_No = true;
					}
					else
					{
						mainObject2.isPaint_No = false;
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADE RID: 2782 RVA: 0x000BC5C4 File Offset: 0x000BA7C4
	public void npcServer(Message msg)
	{
		try
		{
			short xNPC = msg.reader().readShort();
			short yNPC = msg.reader().readShort();
			short xBlockNPC = msg.reader().readShort();
			short yBlockNPC = msg.reader().readShort();
			sbyte wBlockNPC = msg.reader().readByte();
			sbyte hBlockNPC = msg.reader().readByte();
			sbyte dxNPC = msg.reader().readByte();
			sbyte dyNPC = msg.reader().readByte();
			sbyte nFrameNPC = msg.reader().readByte();
			string nameGiaoTiep = msg.reader().readUTF();
			string nameNPC = msg.reader().readUTF();
			sbyte idNPC = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			sbyte[] array = new sbyte[(int)b];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = (sbyte)msg.reader().readShort();
			}
			short num = msg.reader().readShort();
			sbyte[] array2 = new sbyte[(int)num];
			for (int j = 0; j < array2.Length; j++)
			{
				array2[j] = msg.reader().readByte();
			}
			sbyte b2 = msg.reader().readByte();
			sbyte[] array3 = new sbyte[(int)b2];
			for (int k = 0; k < array3.Length; k++)
			{
				array3[k] = msg.reader().readByte();
			}
			sbyte b3 = msg.reader().readByte();
			for (int l = 0; l < GameScreen.Vecplayers.size(); l++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(l);
				if (mainObject.isNPC_server() && mainObject.ID == (int)b3)
				{
					mainObject.setInfo(idNPC, xNPC, yNPC, dxNPC, dyNPC, nFrameNPC, nameGiaoTiep, nameNPC, xBlockNPC, yBlockNPC, wBlockNPC, hBlockNPC, array, array2, array3);
					return;
				}
			}
			NPCserver npcserver = new NPCserver(idNPC, xNPC, yNPC, dxNPC, dyNPC, nFrameNPC, nameGiaoTiep, nameNPC, xBlockNPC, yBlockNPC, wBlockNPC, hBlockNPC, array, array2, array3);
			npcserver.ID = (int)b3;
			GameScreen.Vecplayers.addElement(npcserver);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000ADF RID: 2783 RVA: 0x000BC808 File Offset: 0x000BAA08
	public void useShip(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			short shipScr = msg.reader().readShort();
			GameScreen.player.useShip = true;
			if ((int)b == 0)
			{
				GameScreen.infoGame.isShipMove = true;
				ShipScr.gI().setShipScr(shipScr);
			}
			else if ((int)b == 2)
			{
				ShipScr.gI().isSpeed = true;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE0 RID: 2784 RVA: 0x000BC894 File Offset: 0x000BAA94
	public void ThachDau(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			sbyte b2 = b;
			if (b2 != 0)
			{
				if (b2 == 1)
				{
					sbyte b3 = msg.reader().readByte();
					PaintInfoGameScreen.timeThachdau = mSystem.currentTimeMillis() / 1000L + (long)b3;
				}
			}
			else
			{
				short id = msg.reader().readShort();
				int mp = msg.reader().readInt();
				int maxMp = msg.reader().readInt();
				MainObject mainObject = MainObject.get_Object((int)id, 0);
				if (mainObject != null)
				{
					mainObject.mp = mp;
					mainObject.maxMp = maxMp;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE1 RID: 2785 RVA: 0x000BC964 File Offset: 0x000BAB64
	public void StoreInfo(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 1:
			{
				short id = msg.reader().readShort();
				string nameStore = msg.reader().readUTF();
				MainObject mainObject = GameScreen.findChar(id);
				if (mainObject != null)
				{
					mainObject.setNameStore(nameStore);
				}
				break;
			}
			case 2:
			{
				short num = msg.reader().readShort();
				MainObject mainObject2 = GameScreen.findChar(num);
				if (GameScreen.player != null && (int)num == GameScreen.player.ID)
				{
					Item.VecItem_Sell_in_store.removeAllElements();
					Item.VecItemSell.removeAllElements();
				}
				if (mainObject2 != null)
				{
					mainObject2.removeNameStore();
				}
				break;
			}
			case 3:
			{
				Item.VecItemSell.removeAllElements();
				sbyte b = msg.reader().readByte();
				for (int i = 0; i < (int)b; i++)
				{
					sbyte b2 = msg.reader().readByte();
					if ((int)b2 == 3)
					{
						short num2 = msg.reader().readShort();
						string itemName = msg.reader().readUTF();
						sbyte b3 = msg.reader().readByte();
						sbyte b4 = msg.reader().readByte();
						short imageId = msg.reader().readShort();
						sbyte plusItem = msg.reader().readByte();
						short lvItem = msg.reader().readShort();
						sbyte b5 = msg.reader().readByte();
						sbyte b6 = msg.reader().readByte();
						MainInfoItem[] array = new MainInfoItem[(int)b6];
						for (int j = 0; j < (int)b6; j++)
						{
							sbyte b7 = msg.reader().readByte();
							int value = msg.reader().readInt();
							array[j] = new MainInfoItem((int)b7, value);
						}
						sbyte typeMoney = msg.reader().readByte();
						MainItem mainItem = MainItem.MainItem_Item((int)num2, itemName, (int)imageId, plusItem, (int)b5, (int)b3, 3, array, (int)b4, false, num2, 0L, lvItem, 0, 0, 0, typeMoney, 0);
						mainItem.isSell = true;
						Item.VecItemSell.addElement(mainItem);
					}
					if ((int)b2 == 7)
					{
						short id2 = msg.reader().readShort();
						short num3 = msg.reader().readShort();
						sbyte b8 = msg.reader().readByte();
						sbyte b9 = msg.reader().readByte();
						long num4 = msg.reader().readLong();
						MainItem material = Item.getMaterial((int)id2);
						if (material != null)
						{
							MainItem mainItem2 = MainItem.MainItem_Material((int)id2, material.itemName, material.imageId, 7, num4, 0, material.content, material.value, material.typeMaterial, num3, b8, b9);
							mainItem2.isSell = true;
							Item.VecItemSell.addElement(mainItem2);
						}
						else
						{
							MainItem mainItem3 = new MainItem();
							mainItem3.Id = (int)id2;
							mainItem3.numPotion = (int)num3;
							mainItem3.canSell = b8;
							mainItem3.canTrade = b9;
							mainItem3.priceItem = num4;
							mainItem3.priceType = 0;
							mainItem3.isSell = true;
							mainItem3.ItemCatagory = 7;
							Item.put_Material((int)id2);
							Item.VecItemSell.addElement(mainItem3);
						}
					}
					if ((int)b2 == 4)
					{
						short id3 = msg.reader().readShort();
						short numPotion = msg.reader().readShort();
						long num5 = (long)msg.reader().readInt();
						MainTemplateItem potionTem = MainTemplateItem.getPotionTem(id3);
						if (potionTem != null)
						{
							MainItem o = new MainItem(potionTem.ID, potionTem.IconId, potionTem.name, string.Concat(new string[]
							{
								potionTem.contentPotion,
								". ",
								T.price,
								" ",
								MainItem.getDotNumber(num5),
								" ",
								T.coin
							}), (int)numPotion, 4, num5, potionTem.typePotion, potionTem.moneyType, 0, 0);
							Item.VecItemSell.addElement(o);
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE2 RID: 2786 RVA: 0x000BCD6C File Offset: 0x000BAF6C
	public void MiNuongInfo(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				MainObject mainObject = GameScreen.findMonster(id);
				if (mainObject != null)
				{
					mainObject.SetnameOwner(name);
				}
				break;
			}
			case 1:
			{
				short idCharLoiDai = msg.reader().readShort();
				short idCharLoiDai2 = msg.reader().readShort();
				GameScreen.infoGame.idCharLoiDai1 = idCharLoiDai;
				GameScreen.infoGame.idCharLoiDai2 = idCharLoiDai2;
				break;
			}
			case 2:
			{
				short id2 = msg.reader().readShort();
				short effect = msg.reader().readShort();
				short effTail = msg.reader().readShort();
				short effEnd = msg.reader().readShort();
				sbyte b = msg.reader().readByte();
				MainObject mainObject2 = GameScreen.findObj(id2);
				if (mainObject2 != null)
				{
					for (int i = 0; i < (int)b; i++)
					{
						short id3 = msg.reader().readShort();
						int power = msg.reader().readInt();
						MainObject mainObject3 = GameScreen.findObj(id3);
						if (mainObject3 != null)
						{
							GameScreen.startNewMagicBeam(15, mainObject2, mainObject3, mainObject2.x, mainObject2.y, power, effect, (int)effTail, (int)effEnd);
						}
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE3 RID: 2787 RVA: 0x000BCEF0 File Offset: 0x000BB0F0
	public void infoclanChiemthanh(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				int idicon = msg.reader().readInt();
				string nameclan = msg.reader().readUTF();
				PaintInfoGameScreen.idicon = idicon;
				PaintInfoGameScreen.nameclan = nameclan;
				break;
			}
			case 1:
			{
				GameScreen.vecTimecountDown.removeAllElements();
				sbyte b = msg.reader().readByte();
				for (int i = 0; i < (int)b; i++)
				{
					short num = msg.reader().readShort();
					string tile = msg.reader().readUTF();
					if (num > 0)
					{
						TimecountDown o = new TimecountDown((int)num, tile, GameCanvas.w / 2, GameCanvas.hText + 10 + i * GameCanvas.hText);
						GameScreen.vecTimecountDown.addElement(o);
					}
				}
				break;
			}
			case 2:
			{
				int num2 = (int)msg.reader().readByte();
				if (num2 > 0)
				{
					GameScreen.textServer = new string[num2];
					for (int j = 0; j < num2; j++)
					{
						GameScreen.textServer[j] = msg.reader().readUTF();
					}
				}
				else
				{
					GameScreen.textServer = null;
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE4 RID: 2788 RVA: 0x000BD05C File Offset: 0x000BB25C
	public void onHopRac(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
			{
				TabRebuildItem.vecGem.removeAllElements();
				sbyte b = msg.reader().readByte();
				short id = msg.reader().readShort();
				for (int i = 0; i < (int)b; i++)
				{
					MainItem material = Item.getMaterial((int)id);
					if (material != null)
					{
						TabRebuildItem.vecGem.addElement(material);
					}
					else
					{
						MainItem mainItem = new MainItem();
						mainItem.Id = (int)id;
						TabRebuildItem.itemRe.ItemCatagory = 7;
						TabRebuildItem.vecGem.addElement(mainItem);
					}
				}
				break;
			}
			case 1:
				TabRebuildItem.vecGem.removeAllElements();
				break;
			case 2:
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.isBeginEff = 1;
				TabRebuildItem.isNextRebuild = msg.reader().readByte();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				TabRebuildItem.vecGem.removeAllElements();
				short num = msg.reader().readShort();
				sbyte b2 = msg.reader().readByte();
				if (num != -1 && (int)b2 == 7)
				{
					MainItem material2 = Item.getMaterial((int)num);
					if (material2 != null)
					{
						TabRebuildItem.itemRe = material2;
					}
					else
					{
						TabRebuildItem.itemRe = new MainItem();
						TabRebuildItem.itemRe.Id = (int)num;
						TabRebuildItem.itemRe.ItemCatagory = 7;
					}
				}
				break;
			}
			case 3:
				GameCanvas.end_Dialog();
				TabRebuildItem.isBeginEff = 1;
				TabRebuildItem.itemRe = null;
				TabRebuildItem.isNextRebuild = msg.reader().readByte();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				TabRebuildItem.vecGem.removeAllElements();
				if ((int)TabRebuildItem.isNextRebuild == 3)
				{
					sbyte b3 = msg.reader().readByte();
					string itemName = msg.reader().readUTF();
					sbyte b4 = msg.reader().readByte();
					short id2 = msg.reader().readShort();
					sbyte b5 = msg.reader().readByte();
					short imageId = msg.reader().readShort();
					sbyte tier = msg.reader().readByte();
					short level = msg.reader().readShort();
					sbyte b6 = msg.reader().readByte();
					sbyte canSell = msg.reader().readByte();
					sbyte canTrade = msg.reader().readByte();
					sbyte b7 = msg.reader().readByte();
					MainInfoItem[] array = new MainInfoItem[(int)b7];
					for (int j = 0; j < (int)b7; j++)
					{
						sbyte b8 = msg.reader().readByte();
						int value = msg.reader().readInt();
						array[j] = new MainInfoItem((int)b8, value);
					}
					int timeUse = msg.reader().readInt();
					sbyte isLock = msg.reader().readByte();
					sbyte b9 = msg.reader().readByte();
					int timeDefault = -1;
					string s = "-1";
					if ((int)b9 == 1)
					{
						timeDefault = msg.reader().readInt();
						s = msg.reader().readUTF();
					}
					sbyte canShell_notCanTrade = msg.reader().readByte();
					MainItem mainItem2 = new MainItem((int)id2, itemName, (int)imageId, tier, (int)b6, (int)b4, (int)b3, array, (int)b5, false, -1, 0L, level, canSell, canTrade, timeUse, 0, isLock, timeDefault, long.Parse(s));
					mainItem2.setCanShell_notCanTrade(canShell_notCanTrade);
					TabRebuildItem.itemRe = mainItem2;
				}
				break;
			case 4:
			{
				int num2 = (int)msg.reader().readByte();
				TabRebuildItem.vecGem.removeAllElements();
				for (int k = 0; k < num2; k++)
				{
					short num3 = msg.reader().readShort();
					short num4 = msg.reader().readShort();
					sbyte b10 = 7;
					if (num3 != -1 && (int)b10 == 7)
					{
						TabRebuildItem.numColor[k] = ReadMessenge.getColorNum(num3, (int)num4);
						TabRebuildItem.numofGem[k] = ReadMessenge.getInfoNum(num3, (int)num4);
						MainItem material3 = Item.getMaterial((int)num3);
						if (material3 != null)
						{
							TabRebuildItem.vecGem.addElement(material3);
						}
						else
						{
							MainItem mainItem3 = new MainItem();
							mainItem3.Id = (int)num3;
							mainItem3.ItemCatagory = 7;
							TabRebuildItem.vecGem.addElement(mainItem3);
						}
					}
				}
				break;
			}
			case 5:
			{
				GameCanvas.end_Dialog();
				TabRebuildItem.isBeginEff = 1;
				TabRebuildItem.itemRe = null;
				TabRebuildItem.isNextRebuild = msg.reader().readByte();
				TabRebuildItem.contentShow = msg.reader().readUTF();
				TabRebuildItem.vecGem.removeAllElements();
				short id3 = msg.reader().readShort();
				Item itemInventory = Item.getItemInventory(3, id3);
				if (itemInventory != null)
				{
					TabRebuildItem.itemRe = MainItem.MainItem_Item((int)id3, itemInventory.itemNameExcludeLv, itemInventory.imageId, itemInventory.tier, itemInventory.colorNameItem, itemInventory.classcharItem, 3, itemInventory.mInfo, itemInventory.type_Only_Item, false, itemInventory.IdTem, itemInventory.priceItem, (short)itemInventory.LvItem, itemInventory.canSell, itemInventory.canTrade, 0, 0, 0);
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE5 RID: 2789 RVA: 0x000BD564 File Offset: 0x000BB764
	public void Material_Template(Message msg)
	{
		try
		{
			short num = msg.reader().readShort();
			short imageId = msg.reader().readShort();
			long price = msg.reader().readLong();
			string itemName = msg.reader().readUTF();
			string content = msg.reader().readUTF();
			sbyte typeitem = msg.reader().readByte();
			sbyte priceType = msg.reader().readByte();
			sbyte sell = msg.reader().readByte();
			short value = msg.reader().readShort();
			sbyte trade = msg.reader().readByte();
			sbyte b = msg.reader().readByte();
			MainItem mainItem = (MainItem)MainTemplateItem.hashMaterialTem.get(num + string.Empty);
			if (mainItem != null)
			{
				mainItem.setinfo((int)num, itemName, (int)imageId, 7, price, priceType, content, (int)value, typeitem, 1, sell, trade);
				mainItem.setColorName((int)b);
			}
			for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
			{
				MainItem mainItem2 = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
				if (mainItem2 != null && mainItem2.ItemCatagory == 7 && mainItem2.Id == (int)num)
				{
					mainItem2.setinfo((int)num, itemName, (int)imageId, 7, price, priceType, content, (int)value, typeitem, 1, sell, trade);
					mainItem2.setColorName((int)b);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE6 RID: 2790 RVA: 0x000BD6E8 File Offset: 0x000BB8E8
	public void onFillRec_Time(Message msg)
	{
		try
		{
			switch (msg.reader().readByte())
			{
			case 0:
				GameCanvas.game.isFullScreen = false;
				GameCanvas.game.colorRec = msg.reader().readInt();
				GameCanvas.game.xRec = (int)msg.reader().readShort();
				GameCanvas.game.yRec = (int)msg.reader().readShort();
				GameCanvas.game.wRec = (int)msg.reader().readShort();
				GameCanvas.game.hRec = (int)msg.reader().readShort();
				break;
			case 1:
				GameCanvas.game.colorRec = msg.reader().readInt();
				GameCanvas.game.isFullScreen = true;
				break;
			case 2:
			{
				sbyte b = msg.reader().readByte();
				short idIcon = msg.reader().readShort();
				short id = msg.reader().readShort();
				string name = msg.reader().readUTF();
				sbyte color = 0;
				if ((int)b == 3 || (int)b == 4 || (int)b == 7)
				{
					color = msg.reader().readByte();
				}
				short x = msg.reader().readShort();
				short y = msg.reader().readShort();
				Item_Drop obj = new Item_Drop((int)id, b, name, (int)x, (int)y, idIcon, color);
				GameScreen.addPlayer(obj);
				break;
			}
			case 3:
			{
				int num = msg.reader().readInt();
				GameCanvas.game.imgCombo = null;
				if (num > 0)
				{
					sbyte[] array = new sbyte[num];
					if (num > 0)
					{
						for (int i = 0; i < num; i++)
						{
							array[i] = msg.reader().readByte();
						}
						GameCanvas.game.imgCombo = mImage.createImage(array, 0, array.Length, string.Empty);
						GameCanvas.game.isCombo = true;
					}
				}
				else
				{
					GameCanvas.game.imgCombo = null;
					GameScreen.player.timeCombo = -1;
				}
				break;
			}
			case 4:
				GameScreen.player.resetCoolDown();
				GameScreen.player.timeCombo = msg.reader().readInt();
				break;
			case 5:
			{
				sbyte b2 = msg.reader().readByte();
				if ((int)b2 == 1)
				{
					this.onContinueFire();
				}
				break;
			}
			case 7:
			{
				short ideff = msg.reader().readShort();
				short x2 = msg.reader().readShort();
				short y2 = msg.reader().readShort();
				DataSkillEff o = new DataSkillEff(ideff, (int)x2, (int)y2, null);
				GameScreen.vecDataeff.addElement(o);
				break;
			}
			case 8:
			{
				short ideff2 = msg.reader().readShort();
				sbyte b3 = msg.reader().readByte();
				short id2 = msg.reader().readShort();
				if ((int)b3 == 0)
				{
					MainObject mainObject = GameScreen.findChar(id2);
					if (mainObject != null)
					{
						DataSkillEff o2 = new DataSkillEff(ideff2, mainObject.x, mainObject.y, null);
						GameScreen.vecDataeff.addElement(o2);
					}
				}
				else
				{
					MainObject mainObject2 = GameScreen.findMonster(id2);
					if (mainObject2 != null)
					{
						DataSkillEff o3 = new DataSkillEff(ideff2, mainObject2.x, mainObject2.y, null);
						GameScreen.vecDataeff.addElement(o3);
					}
				}
				break;
			}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE7 RID: 2791 RVA: 0x000BDA5C File Offset: 0x000BBC5C
	public void onUpSkill(Message msg)
	{
		try
		{
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000AE8 RID: 2792 RVA: 0x000BDA90 File Offset: 0x000BBC90
	public void onContinueFire()
	{
		try
		{
			GameScreen.ObjFocus = null;
			GameScreen.player.nextMonster();
			GameScreen.player.dofire_();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x040011E5 RID: 4581
	public const sbyte UPDATE_ALL = 0;

	// Token: 0x040011E6 RID: 4582
	public const sbyte ADD_REPLACE = 1;

	// Token: 0x040011E7 RID: 4583
	public const sbyte DELETE = 2;

	// Token: 0x040011E8 RID: 4584
	public const sbyte UPDATE_SIZECHEST = 3;

	// Token: 0x040011E9 RID: 4585
	public short idDialog;

	// Token: 0x040011EA RID: 4586
	public sbyte typeDialog;

	// Token: 0x040011EB RID: 4587
	public static sbyte SHOP_ITEM_EVENT = 100;

	// Token: 0x040011EC RID: 4588
	public static sbyte SHOP_POTION;

	// Token: 0x040011ED RID: 4589
	public static sbyte SHOP_ITEM = 1;

	// Token: 0x040011EE RID: 4590
	public static sbyte SHOP_HAIR = 2;

	// Token: 0x040011EF RID: 4591
	public static sbyte CHEST = 3;

	// Token: 0x040011F0 RID: 4592
	public static sbyte SHOP_MATERIAL = 4;

	// Token: 0x040011F1 RID: 4593
	public static sbyte REBUILD = 5;

	// Token: 0x040011F2 RID: 4594
	public static sbyte SHOP_ICONCLAN_FREE = 6;

	// Token: 0x040011F3 RID: 4595
	public static sbyte SHOP_ICONCLAN_VIP = 7;

	// Token: 0x040011F4 RID: 4596
	public static sbyte SHOP_POTION_CLAN = 8;

	// Token: 0x040011F5 RID: 4597
	public static sbyte REPLACE = 9;

	// Token: 0x040011F6 RID: 4598
	public static sbyte WING = 10;

	// Token: 0x040011F7 RID: 4599
	public static sbyte PET_KEEPER = 11;

	// Token: 0x040011F8 RID: 4600
	public static sbyte TAB_HOP_NGUYEN_LIEU = 12;

	// Token: 0x040011F9 RID: 4601
	public static sbyte SHOP_VANTIEU = 13;

	// Token: 0x040011FA RID: 4602
	public static sbyte SHOP_KHAM_NGOC = 14;

	// Token: 0x040011FB RID: 4603
	public static sbyte SHOP_GHEP_NGOC = 15;

	// Token: 0x040011FC RID: 4604
	public static sbyte SHOP_DUC_LO = 16;

	// Token: 0x040011FD RID: 4605
	public static sbyte SHOP_OTHER_PLAYER = 17;

	// Token: 0x040011FE RID: 4606
	public static sbyte SHOP_ANY_NGUYEN_LIEU = 18;

	// Token: 0x040011FF RID: 4607
	public static sbyte SHOP_HOP_AN = 19;

	// Token: 0x04001200 RID: 4608
	public static sbyte SHOP_NANG_CAP_MEDAL = 20;

	// Token: 0x04001201 RID: 4609
	private string nameParty = string.Empty;

	// Token: 0x04001202 RID: 4610
	private string nameBuySell = string.Empty;
}
