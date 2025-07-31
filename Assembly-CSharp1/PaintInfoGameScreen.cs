using System;

// Token: 0x02000088 RID: 136
public class PaintInfoGameScreen
{
	// Token: 0x06000679 RID: 1657 RVA: 0x00061080 File Offset: 0x0005F280
	public static void init()
	{
		PaintInfoGameScreen.xPointKill = GameCanvas.w - 35;
		PaintInfoGameScreen.yPointKill = GameCanvas.h - 45;
		PaintInfoGameScreen.xPaintSkill = GameCanvas.hw - 50;
		PaintInfoGameScreen.yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;
		PaintInfoGameScreen.xPaintSkill = GameCanvas.hw - 50;
		PaintInfoGameScreen.yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;
		PaintInfoGameScreen.xPointMove = 50;
		PaintInfoGameScreen.yPointMove = GameCanvas.h - 50;
	}

	// Token: 0x0600067A RID: 1658 RVA: 0x000610FC File Offset: 0x0005F2FC
	public static void loadPaintInfo()
	{
		PaintInfoGameScreen.init();
		PaintInfoGameScreen.wInfoServer = GameCanvas.w * 2 / 3;
		PaintInfoGameScreen.winfo18plus = GameCanvas.hw - GameCanvas.hw / 3;
		PaintInfoGameScreen.yBeginInfo = GameCanvas.h / 4 - 30;
		PaintInfoGameScreen.xFocus = GameCanvas.w - 52;
		PaintInfoGameScreen.yFocus = 0;
		PaintInfoGameScreen.xParty = 2;
		PaintInfoGameScreen.yParty = 60;
		PaintInfoGameScreen.xMess = 70;
		PaintInfoGameScreen.yMess = 45;
		if (GameCanvas.isTouch)
		{
			PaintInfoGameScreen.loadImagePointer();
			PaintInfoGameScreen.xFocus = GameCanvas.hw;
		}
		PaintInfoGameScreen.wShowEvent = 130;
	}

	// Token: 0x0600067B RID: 1659 RVA: 0x00061190 File Offset: 0x0005F390
	public static void loadImagePointer()
	{
		PaintInfoGameScreen.wSkill = 32;
		int num = PaintInfoGameScreen.gocBegin;
		for (int i = 0; i < PaintInfoGameScreen.mPosKill.Length; i++)
		{
			PaintInfoGameScreen.mPosKill[i][0] = PaintInfoGameScreen.xPointKill + CRes.cos(CRes.fixangle(num)) * PaintInfoGameScreen.lSkill / 1000;
			PaintInfoGameScreen.mPosKill[i][1] = PaintInfoGameScreen.yPointKill + CRes.sin(CRes.fixangle(num)) * PaintInfoGameScreen.lSkill / 1000;
			num -= 45;
		}
		PaintInfoGameScreen.xPaintSkill = GameCanvas.w - PaintInfoGameScreen.wSkill * 6;
		PaintInfoGameScreen.yPaintSkill = GameCanvas.h - 24;
		PaintInfoGameScreen.mPosOther[0][0] = 8;
		PaintInfoGameScreen.mPosOther[0][1] = 43;
		PaintInfoGameScreen.mPosOther[1][0] = 8;
		PaintInfoGameScreen.mPosOther[1][1] = 73;
		PaintInfoGameScreen.mPosOther[2][0] = GameCanvas.w - 27;
		PaintInfoGameScreen.mPosOther[2][1] = GameCanvas.h - 145;
		if (Main.isPC)
		{
			PaintInfoGameScreen.mPosOther[2][1] = GameCanvas.h - 31;
		}
		PaintInfoGameScreen.mPosOther[3][0] = GameCanvas.w - 27;
		PaintInfoGameScreen.mPosOther[3][1] = GameCanvas.h - 175;
		if (mSystem.isIP_GDX)
		{
			PaintInfoGameScreen.mPosOther[3][0] = GameCanvas.w - 60;
			PaintInfoGameScreen.mPosOther[3][1] = GameCanvas.h - 146;
		}
		PaintInfoGameScreen.mPosOther[4][0] = GameCanvas.hw - 20;
		PaintInfoGameScreen.mPosOther[4][1] = GameCanvas.h - 16;
		PaintInfoGameScreen.setPosTouch();
		if (!Main.isPC)
		{
			PaintInfoGameScreen.mPosOther[3][0] = GameCanvas.w - 62;
			PaintInfoGameScreen.mPosOther[3][1] = GameCanvas.h - 151;
		}
		PaintInfoGameScreen.xMess = 45;
		PaintInfoGameScreen.yMess = 45;
		PaintInfoGameScreen.imgOther = new mImage[5];
		for (int j = 0; j < PaintInfoGameScreen.imgOther.Length; j++)
		{
			PaintInfoGameScreen.imgOther[j] = mImage.createImage("/point/other_" + j + ".png");
			PaintInfoGameScreen.mSizeImgOther[j][0] = mImage.getImageWidth(PaintInfoGameScreen.imgOther[j].image);
			PaintInfoGameScreen.mSizeImgOther[j][1] = mImage.getImageHeight(PaintInfoGameScreen.imgOther[j].image) / 2;
		}
		PaintInfoGameScreen.imgMove = new mImage[3];
		for (int k = 0; k < PaintInfoGameScreen.imgMove.Length; k++)
		{
			if (k != 1)
			{
				PaintInfoGameScreen.imgMove[k] = mImage.createImage("/point/move_" + k + ".png");
			}
		}
		for (int l = 0; l < PaintInfoGameScreen.mPosMove.Length; l++)
		{
			PaintInfoGameScreen.mPosMove[l][0] = PaintInfoGameScreen.xPointMove + ((l >= 2) ? 0 : (-PaintInfoGameScreen.wArrowMove + PaintInfoGameScreen.wArrowMove * 2 * (l % 2)));
			PaintInfoGameScreen.mPosMove[l][1] = PaintInfoGameScreen.yPointMove + ((l <= 1) ? 0 : (-PaintInfoGameScreen.wArrowMove + PaintInfoGameScreen.wArrowMove * 2 * (l % 2)));
		}
		PaintInfoGameScreen.imgFire = new mImage[2];
		for (int m = 0; m < PaintInfoGameScreen.imgFire.Length; m++)
		{
			PaintInfoGameScreen.imgFire[m] = mImage.createImage("/point/fire_" + m + ".png");
		}
		PaintInfoGameScreen.fraClose = new FrameImage(mImage.createImage("/point/close.png"), 14, 14);
		PaintInfoGameScreen.fraCloseMenu = new FrameImage(mImage.createImage("/point/closemenu.png"), 21, 21);
		PaintInfoGameScreen.fraBack = new FrameImage(mImage.createImage("/point/buttonback.png"), 57, 30);
		PaintInfoGameScreen.fraMenu = new FrameImage(mImage.createImage("/point/buttonmenu.png"), 32, 32);
		PaintInfoGameScreen.fraButton = new FrameImage(mImage.createImage("/point/button.png"), 80, 30);
		PaintInfoGameScreen.fraButton2 = new FrameImage(mImage.createImage("/point/button2.png"), 60, 19);
		PaintInfoGameScreen.fraContact = new FrameImage(mImage.createImage("/point/contact.png"), 26, 26);
		PaintInfoGameScreen.mfraIconQuick = new FrameImage[11];
		for (int n = 0; n < PaintInfoGameScreen.mfraIconQuick.Length; n++)
		{
			PaintInfoGameScreen.mfraIconQuick[n] = new FrameImage(mImage.createImage("/point/quick_" + n + ".png"), 30, 30);
		}
		PaintInfoGameScreen.imgBackQuick = mImage.createImage("/point/backquick.png");
		PaintInfoGameScreen.imgmove = mImage.createImage("/interface/move.png");
	}

	// Token: 0x0600067C RID: 1660 RVA: 0x000615FC File Offset: 0x0005F7FC
	public static void paintHitscr(mGraphics g, bool isMaxdame)
	{
		if (isMaxdame)
		{
			PaintInfoGameScreen.delta = 0;
		}
		else
		{
			PaintInfoGameScreen.delta = 10;
		}
		g.drawRegion(AvMain.imghitScr[0], 0, 0, PaintInfoGameScreen.imgHitWidth[0], PaintInfoGameScreen.imgHitHeight[0], 0, GameCanvas.w - PaintInfoGameScreen.imgHitWidth[0] + PaintInfoGameScreen.delta, -PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, PaintInfoGameScreen.imgHitWidth[0], PaintInfoGameScreen.imgHitHeight[0], 1, GameCanvas.w - PaintInfoGameScreen.imgHitWidth[0] + PaintInfoGameScreen.delta, GameCanvas.h - PaintInfoGameScreen.imgHitHeight[0] + PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, PaintInfoGameScreen.imgHitWidth[0], PaintInfoGameScreen.imgHitHeight[0], 2, -PaintInfoGameScreen.delta, -PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imghitScr[0], 0, 0, PaintInfoGameScreen.imgHitWidth[0], PaintInfoGameScreen.imgHitHeight[0], 4, -PaintInfoGameScreen.delta, GameCanvas.h - PaintInfoGameScreen.imgHitHeight[0] + PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		int num = (GameCanvas.w + PaintInfoGameScreen.delta - 2 * PaintInfoGameScreen.imgHitWidth[0]) / PaintInfoGameScreen.imgHitWidth[1] + 1;
		for (int i = 0; i < num; i++)
		{
			g.drawRegion(AvMain.imghitScr[1], 0, 0, PaintInfoGameScreen.imgHitWidth[1], PaintInfoGameScreen.imgHitHeight[1], 0, PaintInfoGameScreen.imgHitWidth[0] + PaintInfoGameScreen.imgHitWidth[1] * i - PaintInfoGameScreen.delta, -PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imghitScr[1], 0, 0, PaintInfoGameScreen.imgHitWidth[1], PaintInfoGameScreen.imgHitHeight[1], 1, PaintInfoGameScreen.imgHitWidth[0] + PaintInfoGameScreen.imgHitWidth[1] * i - PaintInfoGameScreen.delta, GameCanvas.h - PaintInfoGameScreen.imgHitHeight[1] + PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		}
		int num2 = (GameCanvas.w + PaintInfoGameScreen.delta - 2 * PaintInfoGameScreen.imgHitHeight[0]) / PaintInfoGameScreen.imgHitHeight[2] + 1;
		for (int j = 0; j < num2; j++)
		{
			g.drawRegion(AvMain.imghitScr[2], 0, 0, PaintInfoGameScreen.imgHitWidth[2], PaintInfoGameScreen.imgHitHeight[2], 0, -PaintInfoGameScreen.delta, PaintInfoGameScreen.imgHitHeight[0] + PaintInfoGameScreen.imgHitHeight[2] * j - PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imghitScr[2], 0, 0, PaintInfoGameScreen.imgHitWidth[2], PaintInfoGameScreen.imgHitHeight[2], 2, GameCanvas.w - PaintInfoGameScreen.imgHitWidth[2] + PaintInfoGameScreen.delta, PaintInfoGameScreen.imgHitHeight[0] + PaintInfoGameScreen.imgHitHeight[2] * j - PaintInfoGameScreen.delta, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x0600067D RID: 1661 RVA: 0x00061898 File Offset: 0x0005FA98
	public void paintKillPlayer(mGraphics g)
	{
		if (PaintInfoGameScreen.timeChange == 0)
		{
			int num = PaintInfoGameScreen.yPaintSkill + PaintInfoGameScreen.hShowInGame;
			if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeBoss == 2)
			{
				for (int i = 0; i < 5; i++)
				{
					g.drawImage(AvMain.imgHotKey, PaintInfoGameScreen.xPaintSkill + i * PaintInfoGameScreen.wSkill, num - 5, 0, mGraphics.isFalse);
					if (Main.isPC && TField.isQwerty)
					{
						AvMain.Font3dWhite(g, PaintInfoGameScreen.mValueChar[i] + string.Empty, PaintInfoGameScreen.xPaintSkill + i * PaintInfoGameScreen.wSkill + 11, num, 2);
					}
					else
					{
						AvMain.Font3dWhite(g, PaintInfoGameScreen.mValueHotKey[i] + string.Empty, PaintInfoGameScreen.xPaintSkill + i * PaintInfoGameScreen.wSkill + 11, num, 2);
					}
				}
				return;
			}
			num = 5 - PaintInfoGameScreen.hShowInGame;
			for (int j = 0; j < Player.mhotkey[0].Length; j++)
			{
				g.drawImage(AvMain.imgHotKey, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill, PaintInfoGameScreen.yPaintSkill - num, 0, mGraphics.isFalse);
				HotKey hotKey = Player.mhotkey[Player.levelTab][j];
				DelaySkill delaySkill = null;
				if ((int)hotKey.type == (int)HotKey.SKILL)
				{
					Skill skillFormId = MainListSkill.getSkillFormId((int)hotKey.id);
					if (skillFormId != null)
					{
						skillFormId.paint(g, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 11, PaintInfoGameScreen.yPaintSkill - num + 11, 3);
					}
					delaySkill = Player.timeDelaySkill[(int)hotKey.id];
				}
				else if ((int)hotKey.type == (int)HotKey.POTION && MainTemplateItem.isload)
				{
					Item itemInventory = Item.getItemInventory(4, hotKey.id);
					if (itemInventory != null && (int)itemInventory.typePotion < 2)
					{
						itemInventory.paintItem(g, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 11, PaintInfoGameScreen.yPaintSkill + 11 - num, (int)MainTabNew.wOneItem, 0, 3);
						delaySkill = Player.timeDelayPotion[(int)itemInventory.typePotion];
					}
					else
					{
						hotKey.setHotKey(0, (int)HotKey.NULL, 0);
						MainItem.setAddHotKey(1, false);
						MainItem.setAddHotKey(0, false);
					}
				}
				if ((int)hotKey.type != (int)HotKey.NULL && delaySkill != null && delaySkill.limit > 0)
				{
					if (delaySkill.value > 0)
					{
						int num2 = delaySkill.value * 20 / delaySkill.limit;
						if (num2 < 1)
						{
							num2 = 1;
						}
						g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, num2, 0, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 1, PaintInfoGameScreen.yPaintSkill + 1 - num, 0, mGraphics.isFalse);
						int num3 = delaySkill.value / 1000;
						string st = string.Empty;
						if (num3 == 0)
						{
							st = "0." + delaySkill.value % 1000 / 100;
						}
						else
						{
							st = string.Empty + num3;
						}
						mFont.tahoma_7b_white.drawString(g, st, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 11, PaintInfoGameScreen.yPaintSkill + 5 - num, 2, mGraphics.isFalse);
					}
					else if (delaySkill.value > -150)
					{
						g.setColor(15658700);
						g.fillRoundRect(PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 1, PaintInfoGameScreen.yPaintSkill - num + 1, 20, 20, 4, 4, mGraphics.isFalse);
					}
				}
				if (!GameCanvas.isTouch)
				{
					if (TField.isQwerty)
					{
						mFont.tahoma_7b_white.drawString(g, PaintInfoGameScreen.mValueChar[j] + string.Empty, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 12, PaintInfoGameScreen.yPaintSkill - num - 11, 2, mGraphics.isFalse);
					}
					else
					{
						mFont.tahoma_7b_white.drawString(g, PaintInfoGameScreen.mValueHotKey[j] + string.Empty, PaintInfoGameScreen.xPaintSkill + j * PaintInfoGameScreen.wSkill + 12, PaintInfoGameScreen.yPaintSkill - num - 11, 2, mGraphics.isFalse);
					}
				}
			}
		}
		else
		{
			this.paintChangeSkill(g);
		}
		int num4 = 4;
		if (Main.isPC)
		{
			for (int k = 0; k < 6; k++)
			{
				mFont.tahoma_7_black.drawString(g, k + 1 + string.Empty, PaintInfoGameScreen.xPaintSkill + k * PaintInfoGameScreen.wSkill + 12, PaintInfoGameScreen.yPaintSkill - num4 - 10, 2, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, k + 1 + string.Empty, PaintInfoGameScreen.xPaintSkill + k * PaintInfoGameScreen.wSkill + 12, PaintInfoGameScreen.yPaintSkill - num4 - 11, 2, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x0600067E RID: 1662 RVA: 0x00061D5C File Offset: 0x0005FF5C
	public void paintBuffPlayer(mGraphics g)
	{
		for (int i = 0; i < GameScreen.player.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)GameScreen.player.vecBuff.elementAt(i);
		}
	}

	// Token: 0x0600067F RID: 1663 RVA: 0x00061DA0 File Offset: 0x0005FFA0
	private void paintChangeSkill(mGraphics g)
	{
		for (int i = 0; i < 10; i++)
		{
			int num = Player.levelTab;
			int num2;
			if (i < 5)
			{
				num2 = PaintInfoGameScreen.timeChange * 8;
			}
			else
			{
				num2 = 64 - PaintInfoGameScreen.timeChange * 8;
				if (Player.levelTab == 0)
				{
					num = 1;
				}
				else
				{
					num = 0;
				}
			}
			g.drawImage(AvMain.imgHotKey, PaintInfoGameScreen.xPaintSkill + i % 5 * PaintInfoGameScreen.wSkill - 1, num2 + PaintInfoGameScreen.yPaintSkill - 1, 0, mGraphics.isFalse);
			HotKey hotKey = Player.mhotkey[num][i % 5];
			if ((int)hotKey.type == (int)HotKey.SKILL)
			{
				Skill skillFormId = MainListSkill.getSkillFormId((int)hotKey.id);
				skillFormId.paint(g, PaintInfoGameScreen.xPaintSkill + i % 5 * PaintInfoGameScreen.wSkill + 11, num2 + PaintInfoGameScreen.yPaintSkill + 11, 3);
			}
			else if ((int)hotKey.type == (int)HotKey.POTION)
			{
				Item itemInventory = Item.getItemInventory(4, hotKey.id);
				if (itemInventory != null)
				{
					itemInventory.paintItem(g, PaintInfoGameScreen.xPaintSkill + i % 5 * PaintInfoGameScreen.wSkill + 11, num2 + PaintInfoGameScreen.yPaintSkill + 11, (int)MainTabNew.wOneItem, 0, 3);
				}
			}
		}
	}

	// Token: 0x06000680 RID: 1664 RVA: 0x00061ED0 File Offset: 0x000600D0
	public void paintInfoThachDau(mGraphics g, int x, int y)
	{
		if (!this.isMapThachdau())
		{
			return;
		}
		GameCanvas.resetTrans(g);
		if (this.idCharLoiDai1 != -1)
		{
			MainObject mainObject = GameScreen.findObjByteCat(this.idCharLoiDai1, 0);
			if (mainObject != null)
			{
				int num = GameCanvas.w / 2 - 20;
				int num2 = num / (PaintInfoGameScreen.WBlackclolor / 2);
				if (num2 < 0)
				{
					num2 = 1;
				}
				if (num2 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x + num - (PaintInfoGameScreen.WBlackclolor - 2) + 2, y + 3, 0, mGraphics.isTrue);
					int num3 = (num - (PaintInfoGameScreen.WBlackclolor - 2) * 2) / 5;
					if (num3 <= 0)
					{
						num3 = 1;
					}
					for (int i = 0; i < num3 + 1; i++)
					{
						g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 4 + i * 5, y + 3, 0, mGraphics.isTrue);
					}
				}
				if (mainObject.hp > 0)
				{
					long num4 = (long)mainObject.maxHp;
					long num5 = (long)mainObject.hp;
					long num6 = (long)num;
					long num7 = num5 * num6;
					int num8 = (int)(num7 / num4);
					int num9 = num + 1;
					g.setClip(x, y + 4, num9 - (num - num8), 7);
					int num10 = num / (PaintInfoGameScreen.WRedclor / 2);
					if (num10 < 0)
					{
						num10 = 1;
					}
					if (num10 == 1)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
						g.drawRegion(AvMain.imgcolorhpmp, 2, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1 + num - (PaintInfoGameScreen.WRedclor - 2), y + 4, 0, mGraphics.isTrue);
						int num11 = (num - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
						if (num11 <= 0)
						{
							num11 = 1;
						}
						for (int j = 0; j < num11 + 1; j++)
						{
							g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + j * 5, y + 4, 0, mGraphics.isTrue);
						}
					}
				}
				if (mainObject.mp > 0)
				{
				}
				g.endClip();
				GameCanvas.resetTrans(g);
				AvMain.Font3dColor(g, mainObject.name.ToUpper() + " Lv: " + mainObject.Lv, x + 2, y + 24 - 10, 0, 0);
				if (!mainObject.overHP)
				{
					mFont.tahoma_7_white.drawString(g, mainObject.hp + "/" + mainObject.maxHp, num / 2, y + 2, 2, mGraphics.isTrue);
				}
				else
				{
					mFont mFont = mFont.tahoma_7_white;
					if ((int)MainObject.countmp > 5)
					{
						mFont = mFont.tahoma_7_red;
					}
					mFont.drawString(g, mainObject.hp + "/" + mainObject.maxHp, num / 2, y + 2, 2, mGraphics.isTrue);
				}
				if (PaintInfoGameScreen.timeThachdau - mSystem.currentTimeMillis() / 1000L > 0L)
				{
					long num12 = PaintInfoGameScreen.timeThachdau - mSystem.currentTimeMillis() / 1000L;
					g.drawRegion(AvMain.imgBackInfo, 0, 0, 140, 20, 0, GameCanvas.w / 2, y + 35, 3, mGraphics.isFalse);
					mFont.tahoma_7_white.drawString(g, T.TimeThachDau + num12, GameCanvas.w / 2, y + 30, 2, mGraphics.isFalse);
				}
			}
		}
		else
		{
			int num13 = GameCanvas.w / 2 - 20;
			int num14 = num13 / (PaintInfoGameScreen.WBlackclolor / 2);
			if (num14 < 0)
			{
				num14 = 1;
			}
			if (num14 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isFalse);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 15, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 15, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x + num13 - (PaintInfoGameScreen.WBlackclolor - 2) + 2, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 9, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x + num13 - (PaintInfoGameScreen.WBlackclolor - 2) + 2, y + 15, 0, mGraphics.isTrue);
				int num15 = (num13 - (PaintInfoGameScreen.WBlackclolor - 2) * 2) / 5;
				if (num15 <= 0)
				{
					num15 = 1;
				}
				for (int k = 0; k < num15 + 1; k++)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 2 + k * 5, y + 3, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 9, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 2 + k * 5, y + 15, 0, mGraphics.isTrue);
				}
			}
			if (GameScreen.player.hp > 0)
			{
				long num16 = (long)GameScreen.player.maxHp;
				long num17 = (long)GameScreen.player.hp;
				long num18 = (long)num13;
				long num19 = num17 * num18;
				int num20 = (int)(num19 / num16);
				int num21 = num13 + 1;
				g.setClip(x, y + 4, num21 - (num13 - num20), 7);
				int num22 = num13 / (PaintInfoGameScreen.WRedclor / 2);
				if (num22 < 0)
				{
					num22 = 1;
				}
				if (num22 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1 + num13 - (PaintInfoGameScreen.WRedclor - 2), y + 4, 0, mGraphics.isTrue);
					int num23 = (num13 - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
					if (num23 <= 0)
					{
						num23 = 1;
					}
					for (int l = 0; l < num23 + 1; l++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + l * 5, y + 4, 0, mGraphics.isTrue);
					}
				}
			}
			if (GameScreen.player.mp > 0)
			{
				long num24 = (long)GameScreen.player.maxMp;
				long num25 = (long)GameScreen.player.mp;
				long num26 = (long)num13;
				long num27 = num25 * num26;
				int num28 = num13 + 2;
				int num29 = (int)(num27 / num24);
				g.setClip(x, y + 16, num28 - (num13 - num29), 7);
				int num30 = num13 / (PaintInfoGameScreen.WRedclor / 2);
				if (num30 < 0)
				{
					num30 = 1;
				}
				if (num30 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 7, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1 + num13 - (PaintInfoGameScreen.WRedclor - 2), y + 16, 0, mGraphics.isTrue);
					int num31 = (num13 - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
					if (num31 <= 0)
					{
						num31 = 1;
					}
					for (int m = 0; m < num31 + 1; m++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 7, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + m * 5, y + 16, 0, mGraphics.isTrue);
					}
				}
			}
			g.endClip();
			GameCanvas.resetTrans(g);
			AvMain.Font3dColor(g, GameScreen.player.name.ToUpper() + " Lv: " + GameScreen.player.Lv, x + 2, y + 24, 0, 0);
			if (!GameScreen.player.overHP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, num13 / 2, y + 2, 2, mGraphics.isTrue);
			}
			else
			{
				mFont mFont2 = mFont.tahoma_7_white;
				if ((int)MainObject.countmp > 5)
				{
					mFont2 = mFont.tahoma_7_red;
				}
				mFont2.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, num13 / 2, y + 2, 2, mGraphics.isTrue);
			}
			if (!GameScreen.player.overMP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, num13 / 2, y + 14, 2, mGraphics.isFalse);
			}
			else
			{
				mFont mFont3 = mFont.tahoma_7_white;
				if ((int)MainObject.countmp > 5)
				{
					mFont3 = mFont.tahoma_7_blue;
				}
				mFont3.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, num13 / 2, y + 14, 2, mGraphics.isTrue);
			}
			if (PaintInfoGameScreen.timeThachdau - mSystem.currentTimeMillis() / 1000L > 0L)
			{
				long num32 = PaintInfoGameScreen.timeThachdau - mSystem.currentTimeMillis() / 1000L;
				g.drawRegion(AvMain.imgBackInfo, 0, 0, 140, 20, 0, GameCanvas.w / 2, y + 35, 3, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, T.TimeThachDau + num32, GameCanvas.w / 2, y + 30, 2, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x06000681 RID: 1665 RVA: 0x000628E4 File Offset: 0x00060AE4
	public void paintInfoThachDauOtherPlayer(mGraphics g, int x, int y)
	{
		if (!this.isMapThachdau())
		{
			return;
		}
		if (this.idCharLoiDai2 != -1)
		{
			MainObject mainObject = GameScreen.findObjByteCat(this.idCharLoiDai2, 0);
			if (mainObject != null)
			{
				GameCanvas.resetTrans(g);
				int num = GameCanvas.w / 2 - 20;
				int num2 = num / (PaintInfoGameScreen.WBlackclolor / 2);
				if (num2 < 0)
				{
					num2 = 1;
				}
				if (num2 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 3, 0, mGraphics.isTrue);
					int num3 = (num - (PaintInfoGameScreen.WBlackclolor - 2) * 2) / 5;
					if (num3 <= 0)
					{
						num3 = 1;
					}
					for (int i = 0; i < num3 + 1; i++)
					{
						g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 4 + i * 5, y + 3, 0, mGraphics.isTrue);
					}
				}
				if (mainObject.hp > 0)
				{
					long num4 = (long)mainObject.maxHp;
					long num5 = (long)mainObject.hp;
					long num6 = (long)num;
					long num7 = num5 * num6;
					int num8 = (int)(num7 / num4);
					g.setClip(x + (num - num8), y + 4, GameCanvas.w / 2 - (num - num8), 7);
					int num9 = num / (PaintInfoGameScreen.WRedclor / 2);
					if (num9 < 0)
					{
						num9 = 1;
					}
					if (num9 == 1)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
						g.drawRegion(AvMain.imgcolorhpmp, 2, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 4, 0, mGraphics.isTrue);
						int num10 = (num - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
						if (num10 <= 0)
						{
							num10 = 1;
						}
						for (int j = 0; j < num10 + 1; j++)
						{
							g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + j * 5, y + 4, 0, mGraphics.isTrue);
						}
					}
				}
				if (mainObject.mp <= 0 || mainObject.maxMp > 0)
				{
				}
				g.endClip();
				GameCanvas.resetTrans(g);
				AvMain.Font3dColor(g, mainObject.name.ToUpper() + " Lv: " + mainObject.Lv, x + num - 2, y + 24 - 10, 1, 0);
				if (!mainObject.overHP)
				{
					mFont.tahoma_7_white.drawString(g, mainObject.hp + "/" + mainObject.maxHp, x + num / 2, y + 2, 2, mGraphics.isTrue);
				}
				else
				{
					mFont mFont = mFont.tahoma_7_white;
					if ((int)MainObject.countmp > 5)
					{
						mFont = mFont.tahoma_7_red;
					}
					mFont.drawString(g, mainObject.hp + "/" + mainObject.maxHp, x + num / 2, y + 2, 2, mGraphics.isTrue);
				}
			}
		}
		else
		{
			if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeObject != 0))
			{
				return;
			}
			GameCanvas.resetTrans(g);
			int num11 = GameCanvas.w / 2 - 20;
			int num12 = num11 / (PaintInfoGameScreen.WBlackclolor / 2);
			if (num12 < 0)
			{
				num12 = 1;
			}
			if (num12 == 1)
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, PaintInfoGameScreen.WBlackclolor, 9, 0, x, y + 15, 0, mGraphics.isFalse);
			}
			else
			{
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, x, y + 15, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 0, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 3, 0, mGraphics.isTrue);
				g.drawRegion(AvMain.imgcolorhpmp_back, 2, 9, PaintInfoGameScreen.WBlackclolor - 2, 9, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 15, 0, mGraphics.isTrue);
				int num13 = (num11 - (PaintInfoGameScreen.WBlackclolor - 2) * 2) / 5;
				if (num13 <= 0)
				{
					num13 = 1;
				}
				for (int k = 0; k < num13 + 1; k++)
				{
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 0, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 2 + k * 5, y + 3, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp_back, 10, 9, 15, 9, 0, x + PaintInfoGameScreen.WBlackclolor - 2 + k * 5, y + 15, 0, mGraphics.isTrue);
				}
			}
			if (GameScreen.ObjFocus.hp > 0)
			{
				long num14 = (long)GameScreen.ObjFocus.maxHp;
				long num15 = (long)GameScreen.ObjFocus.hp;
				long num16 = (long)num11;
				long num17 = num15 * num16;
				int num18 = (int)(num17 / num14);
				g.setClip(x + (num11 - num18), y + 4, GameCanvas.w / 2 - (num11 - num18), 7);
				int num19 = num11 / (PaintInfoGameScreen.WRedclor / 2);
				if (num19 < 0)
				{
					num19 = 1;
				}
				if (num19 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 4, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 0, PaintInfoGameScreen.WRedclor - 2, 7, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 4, 0, mGraphics.isTrue);
					int num20 = (num11 - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
					if (num20 <= 0)
					{
						num20 = 1;
					}
					for (int l = 0; l < num20 + 1; l++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 0, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + l * 5, y + 4, 0, mGraphics.isTrue);
					}
				}
			}
			if (GameScreen.ObjFocus.mp > 0 && GameScreen.ObjFocus.maxMp > 0)
			{
				long num21 = (long)GameScreen.ObjFocus.maxMp;
				long num22 = (long)GameScreen.ObjFocus.mp;
				long num23 = (long)num11;
				long num24 = num22 * num23;
				int num25 = (int)(num24 / num21);
				g.setClip(x + (num11 - num25), y + 16, GameCanvas.w / 2 - (num11 - num25), 7);
				int num26 = num11 / (PaintInfoGameScreen.WRedclor / 2);
				if (num26 < 0)
				{
					num26 = 1;
				}
				if (num26 == 1)
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, PaintInfoGameScreen.WRedclor, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawRegion(AvMain.imgcolorhpmp, 0, 7, PaintInfoGameScreen.WRedclor - 2, 7, 0, x + 1, y + 16, 0, mGraphics.isTrue);
					g.drawRegion(AvMain.imgcolorhpmp, 2, 7, PaintInfoGameScreen.WRedclor - 2, 7, 0, GameCanvas.w - PaintInfoGameScreen.WBlackclolor, y + 16, 0, mGraphics.isTrue);
					int num27 = (num11 - (PaintInfoGameScreen.WRedclor - 2) * 2) / 5;
					if (num27 <= 0)
					{
						num27 = 1;
					}
					for (int m = 0; m < num27 + 1; m++)
					{
						g.drawRegion(AvMain.imgcolorhpmp, 10, 7, 15, 7, 0, x + PaintInfoGameScreen.WRedclor - 2 + m * 5, y + 16, 0, mGraphics.isTrue);
					}
				}
			}
			g.endClip();
			GameCanvas.resetTrans(g);
			AvMain.Font3dColor(g, GameScreen.ObjFocus.name.ToUpper() + " Lv: " + GameScreen.ObjFocus.Lv, x + num11 - 2, y + 24, 1, 0);
			if (!GameScreen.ObjFocus.overHP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.ObjFocus.hp + "/" + GameScreen.ObjFocus.maxHp, x + num11 / 2, y + 2, 2, mGraphics.isTrue);
			}
			else
			{
				mFont mFont2 = mFont.tahoma_7_white;
				if ((int)MainObject.countmp > 5)
				{
					mFont2 = mFont.tahoma_7_red;
				}
				mFont2.drawString(g, GameScreen.ObjFocus.hp + "/" + GameScreen.ObjFocus.maxHp, x + num11 / 2, y + 2, 2, mGraphics.isTrue);
			}
			if (!GameScreen.ObjFocus.overMP)
			{
				mFont.tahoma_7_white.drawString(g, GameScreen.ObjFocus.mp + "/" + GameScreen.ObjFocus.maxMp, x + num11 / 2, y + 14, 2, mGraphics.isFalse);
			}
			else
			{
				mFont mFont3 = mFont.tahoma_7_white;
				if ((int)MainObject.countmp > 5)
				{
					mFont3 = mFont.tahoma_7_blue;
				}
				mFont3.drawString(g, GameScreen.ObjFocus.mp + "/" + GameScreen.ObjFocus.maxMp, x + num11 / 2, y + 14, 2, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x06000682 RID: 1666 RVA: 0x0006324C File Offset: 0x0006144C
	public void paintInfoPlayer(mGraphics g, int x, int y, bool isborder, mFont fontLv)
	{
		if (this.isMapThachdau())
		{
			return;
		}
		y += mGraphics.addYWhenOpenKeyBoard;
		if (isborder)
		{
			g.drawRegion(AvMain.imgInfo, 0, 0, 16, 42, 0, x + 1, y + 2, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgInfo, 0, 84, 16, 42, 0, x + 96, y + 2, mGraphics.TOP | mGraphics.RIGHT, mGraphics.isFalse);
			for (int i = 0; i < 4; i++)
			{
				g.drawRegion(AvMain.imgInfo, 0, 42, 16, 42, 0, x + 17 + 16 * i, y + 2, 0, mGraphics.isFalse);
			}
			x += 8;
			y += 4;
		}
		g.drawImage(AvMain.imghpmp, x + 2, y + 3, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgcolorhpmp_back, 0, 0, 62, 9, 0, x + 19, y + 3, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgcolorhpmp_back, 0, 9, 62, 9, 0, x + 19, y + 15, 0, mGraphics.isFalse);
		if (GameScreen.player.hp > 0)
		{
			int num = GameScreen.player.hp * 60 / GameScreen.player.maxHp;
			if (num <= 0)
			{
				num = 1;
			}
			else if (num > 60)
			{
				num = 60;
			}
			g.drawRegion(AvMain.imgcolorhpmp, 0, 0, num, 7, 0, x + 20, y + 4, 0, mGraphics.isFalse);
		}
		if (GameScreen.player.mp > 0)
		{
			int num2 = GameScreen.player.mp * 60 / GameScreen.player.maxMp;
			if (num2 <= 0)
			{
				num2 = 1;
			}
			else if (num2 > 60)
			{
				num2 = 60;
			}
			g.drawRegion(AvMain.imgcolorhpmp, 0, 7, num2, 7, 0, x + 20, y + 16, 0, mGraphics.isFalse);
		}
		fontLv.drawString(g, string.Concat(new object[]
		{
			"Lv.",
			GameScreen.player.Lv,
			" + ",
			(int)(GameScreen.player.phantramLv / 10),
			",",
			(int)(GameScreen.player.phantramLv % 10),
			"%"
		}), x + 3, y + 24, 0, mGraphics.isFalse);
		if (GameScreen.player.phantramLv > 0)
		{
			int w = (int)(GameScreen.player.phantramLv / 10 * 77 / 100);
			g.setColor(3514158);
			g.fillRect(x + 3, y + 35, w, 2, mGraphics.isFalse);
		}
		if (!GameScreen.player.overHP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, x + 50, y + 2, 2, mGraphics.isFalse);
		}
		else
		{
			mFont mFont = mFont.tahoma_7_white;
			if ((int)MainObject.countmp > 5)
			{
				mFont = mFont.tahoma_7_red;
			}
			mFont.drawString(g, GameScreen.player.hp + "/" + GameScreen.player.maxHp, x + 50, y + 2, 2, mGraphics.isFalse);
		}
		if (!GameScreen.player.overMP)
		{
			mFont.tahoma_7_white.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, x + 50, y + 14, 2, mGraphics.isFalse);
		}
		else
		{
			mFont mFont2 = mFont.tahoma_7_white;
			if ((int)MainObject.countmp > 5)
			{
				mFont2 = mFont.tahoma_7_blue;
			}
			mFont2.drawString(g, GameScreen.player.mp + "/" + GameScreen.player.maxMp, x + 50, y + 14, 2, mGraphics.isFalse);
		}
	}

	// Token: 0x06000683 RID: 1667 RVA: 0x00063634 File Offset: 0x00061834
	public void paintInfoChar(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		int num = PaintInfoGameScreen.yBeginInfo;
		if (this.strInfoServer != null)
		{
			g.setClip(GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2, num, PaintInfoGameScreen.wInfoServer, 20);
			for (int i = 0; i < PaintInfoGameScreen.wInfoServer / 140 + 1; i++)
			{
				if (i == PaintInfoGameScreen.wInfoServer / 140)
				{
					g.drawRegion(AvMain.imgBackInfo, 0, 0, PaintInfoGameScreen.wInfoServer % 140, 20, 0, GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2 + i * 140, num, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2 + i * 140, num, 0, mGraphics.isFalse);
				}
			}
			mFont.tahoma_7_yellow.drawString(g, this.strInfoServer, GameCanvas.hw + PaintInfoGameScreen.wInfoServer / 2 - this.xPaintInfo, num + 4, 0, mGraphics.isTrue);
			num += this.hImgInfo;
		}
		if (this.strInfoCharServer != null)
		{
			g.setClip(GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2, num, PaintInfoGameScreen.wInfoServer, 20);
			for (int j = 0; j < PaintInfoGameScreen.wInfoServer / 140 + 1; j++)
			{
				if (j == PaintInfoGameScreen.wInfoServer / 140)
				{
					g.drawRegion(AvMain.imgBackInfo, 0, 0, PaintInfoGameScreen.wInfoServer % 140, 20, 0, GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2 + j * 140, num, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - PaintInfoGameScreen.wInfoServer / 2 + j * 140, num, 0, mGraphics.isFalse);
				}
			}
			mFont.tahoma_7b_white.drawString(g, this.strInfoCharServer, GameCanvas.hw + PaintInfoGameScreen.wInfoServer / 2 - this.xPaintInfoChar, num + 4, 0, mGraphics.isTrue);
			num += this.hImgInfo;
		}
		if (this.strInfoCharCline != null)
		{
			g.setClip(GameCanvas.hw - 70, num, 140, 20);
			g.drawImage(AvMain.imgBackInfo, GameCanvas.hw - 70, num + this.ydInfoChar, 0, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, this.strInfoCharCline, GameCanvas.hw, num + 4 + this.ydInfoChar, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x06000684 RID: 1668 RVA: 0x0006389C File Offset: 0x00061A9C
	public void PaintIconPlayer(mGraphics g)
	{
		int num = 102;
		int num2 = 8 - PaintInfoGameScreen.hShowInGame;
		if (GameCanvas.isSmallScreen)
		{
			num = 90;
			num2 = 7 - PaintInfoGameScreen.hShowInGame;
		}
		if (Player.diemTiemNang > 0 && !this.isMapThachdau())
		{
			PaintInfoGameScreen.fralevelup.drawFrame(GameCanvas.gameTick / 4 % 2, num, num2, 0, 3, g);
		}
		if (Player.diemKyNang > 0 && !this.isMapThachdau())
		{
			PaintInfoGameScreen.fralevelup.drawFrame(2 + GameCanvas.gameTick / 4 % 2, num, num2 + 14, 0, 3, g);
		}
		if ((int)Player.isAutoFire > -1)
		{
			g.drawImage(PaintInfoGameScreen.imgauto, num + 1, num2 + 28, 3, mGraphics.isFalse);
		}
		if ((int)Player.typeX2 == 1)
		{
			if (GameCanvas.gameTick % 200 < 100)
			{
				g.drawImage(PaintInfoGameScreen.imgxp, num + 1, num2 + 42, 3, mGraphics.isFalse);
			}
			else
			{
				mFont.tahoma_7_green.drawString(g, this.getTimex2(), num - 7, num2 + 36, 0, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x06000685 RID: 1669 RVA: 0x000639A8 File Offset: 0x00061BA8
	public string getTimex2()
	{
		if (Player.timeX2 > 0 && (GameCanvas.timeNow - Player.timeSetX2) / 1000L > 60L)
		{
			Player.timeSetX2 += 60000L;
			Player.timeX2--;
		}
		return PaintInfoGameScreen.getStringTime(Player.timeX2);
	}

	// Token: 0x06000686 RID: 1670 RVA: 0x00063A04 File Offset: 0x00061C04
	public static string getStringTime(int time)
	{
		if (time >= 60)
		{
			return string.Concat(new object[]
			{
				time / 60,
				"h",
				time % 60,
				"'"
			});
		}
		return time + "'";
	}

	// Token: 0x06000687 RID: 1671 RVA: 0x00063A60 File Offset: 0x00061C60
	public static string getStringTime2(int time)
	{
		return time / 60 + "'";
	}

	// Token: 0x06000688 RID: 1672 RVA: 0x00063A84 File Offset: 0x00061C84
	public void updateInfoServer()
	{
		if (GameScreen.VecInfoServer.size() > 0)
		{
			if (this.strInfoServer == null)
			{
				this.strInfoServer = (string)GameScreen.VecInfoServer.elementAt(0);
				if (this.strInfoServer != null && this.strInfoServer.Trim().Length > 0)
				{
					GameCanvas.msgchat.addNewChat(T.tinden, T.text2kenhthegioi, this.strInfoServer, ChatDetail.TYPE_SERVER, false);
				}
				int num = GameScreen.VecInfoServer.size();
				if (num < 2)
				{
					this.speedInfo = 2;
				}
				else if (num < 5)
				{
					this.speedInfo = 3;
				}
				else
				{
					this.speedInfo = 4;
				}
				this.xPaintInfo = 0;
				this.xmaxInfo = mFont.tahoma_7_white.getWidth(this.strInfoServer) + PaintInfoGameScreen.wInfoServer;
				if (this.xmaxInfo < PaintInfoGameScreen.wInfoServer)
				{
					this.xmaxInfo = PaintInfoGameScreen.wInfoServer;
				}
			}
			else
			{
				if (this.xPaintInfo >= this.xmaxInfo)
				{
					this.timepaintServer++;
					this.timepaintServer = 0;
					this.strInfoServer = null;
					GameScreen.VecInfoServer.removeElementAt(0);
				}
				this.xPaintInfo += this.speedInfo;
			}
		}
	}

	// Token: 0x06000689 RID: 1673 RVA: 0x00063BCC File Offset: 0x00061DCC
	public void updateInfoCharServer()
	{
		if (GameScreen.VecInfoChar.size() > 0)
		{
			if (this.strInfoCharServer == null)
			{
				this.strInfoCharServer = (string)GameScreen.VecInfoChar.elementAt(0);
				int num = GameScreen.VecInfoChar.size();
				if (num < 2)
				{
					this.speedInfoChar = 2;
				}
				else if (num < 5)
				{
					this.speedInfoChar = 3;
				}
				else
				{
					this.speedInfoChar = 4;
				}
				this.xPaintInfoChar = 0;
				this.xmaxInfoChar = mFont.tahoma_7b_white.getWidth(this.strInfoCharServer) + PaintInfoGameScreen.wInfoServer;
				if (this.xmaxInfoChar < PaintInfoGameScreen.wInfoServer)
				{
					this.xmaxInfoChar = PaintInfoGameScreen.wInfoServer;
				}
			}
			else
			{
				if (this.xPaintInfoChar >= this.xmaxInfoChar)
				{
					this.timePaintInfoChar = 0;
					this.strInfoCharServer = null;
					GameScreen.VecInfoChar.removeElementAt(0);
				}
				this.xPaintInfoChar += this.speedInfoChar;
			}
		}
	}

	// Token: 0x0600068A RID: 1674 RVA: 0x00063CC4 File Offset: 0x00061EC4
	public void paintInfoFocus(mGraphics g)
	{
		if (this.isMapThachdau())
		{
			return;
		}
		if (!PaintInfoGameScreen.isPaintInfoFocus && !Main.isPC && PaintInfoGameScreen.isLevelPoint)
		{
			return;
		}
		if (GameScreen.ObjFocus != null)
		{
			int num = PaintInfoGameScreen.yFocus - PaintInfoGameScreen.hShowInGame + 2;
			int num2 = PaintInfoGameScreen.xFocus;
			if (this.isMapchienthanh())
			{
				num2 = GameCanvas.w - 62;
				num = PaintInfoGameScreen.yFocus - PaintInfoGameScreen.hShowInGame + 2 + GameCanvas.hText;
			}
			MainObject objFocus = GameScreen.ObjFocus;
			if ((int)objFocus.typeObject == 3)
			{
				AvMain.Font3dColor(g, objFocus.name, num2 + 48, num + 2, 1, objFocus.colorName);
			}
			else if ((int)objFocus.typeObject == 0 || (int)objFocus.typeObject == 1)
			{
				if (objFocus.myClan != null && (int)objFocus.typeSpec == 0)
				{
					int num3 = mFont.tahoma_7b_white.getWidth(objFocus.name) + 1;
					objFocus.paintIconClan(g, num2 + 48 - num3 / 2, num + 7, 2);
					num += 12;
				}
				if ((int)objFocus.typeObject == 1)
				{
					sbyte colorName = objFocus.colorName;
					AvMain.Font3dColorAndColor(g, objFocus.name, num2 + 48, num + 2, 1, 7, colorName);
				}
				else
				{
					AvMain.Font3dWhite(g, objFocus.name, num2 + 48, num + 2, 1);
				}
				num += 10;
				AvMain.Font3dColorAndColor(g, T.Lv + objFocus.Lv, num2 + 48, num + 2, 1, 7, objFocus.colorName);
			}
			else
			{
				AvMain.Font3dWhite(g, objFocus.name, num2 + 48, num + 2, 1);
			}
			if ((int)objFocus.typeObject == 0 || (int)objFocus.typeObject == 1 || (int)objFocus.typeObject == 2)
			{
				g.drawImage(AvMain.imgcolorhpSmall_back, num2 - 4, num + 14, 0, mGraphics.isFalse);
				if (objFocus.maxHp > 0 && objFocus.hp > 0)
				{
					long num4 = 50L;
					long num5 = (long)objFocus.hp;
					long num6 = num4 * num5;
					int num7 = (int)(num6 / (long)objFocus.maxHp);
					if (num7 <= 0)
					{
						num7 = 1;
					}
					else if (num7 > 50)
					{
						num7 = 50;
					}
					g.drawRegion(AvMain.imgcolorhpSmall, 0, 0, num7 + 1, 7, 0, num2 - 4, num + 14, 0, mGraphics.isFalse);
				}
				mFont.tahoma_7_white.drawString(g, objFocus.hp + "/" + objFocus.maxHp, num2 - 4 + 26, num + 20, 2, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x0600068B RID: 1675 RVA: 0x00063F54 File Offset: 0x00062154
	public void updateInfoChar()
	{
		if (this.strInfoCharCline != null)
		{
			this.timeInfoCharCline++;
			if (this.timeInfoCharCline >= 120)
			{
				this.timeInfoCharCline = 0;
				this.strInfoCharCline = null;
			}
			if (this.ydInfoChar > 0)
			{
				this.ydInfoChar -= 2;
			}
		}
		if (!GameCanvas.isTouch && PaintInfoGameScreen.timeChange > 0)
		{
			PaintInfoGameScreen.timeChange++;
			if (PaintInfoGameScreen.timeChange > 8)
			{
				PaintInfoGameScreen.timeChange = 0;
				Player.levelTab++;
				if (Player.levelTab > 2)
				{
					Player.levelTab = 0;
				}
			}
		}
		if (PaintInfoGameScreen.timeNameMap > 0)
		{
			if (PaintInfoGameScreen.timeNameMap == 20)
			{
				PaintInfoGameScreen.vyNameMap = 10;
			}
			else if (PaintInfoGameScreen.timeNameMap < 20 && PaintInfoGameScreen.vyNameMap > -20)
			{
				PaintInfoGameScreen.vyNameMap -= 4;
			}
			if (PaintInfoGameScreen.yNameMap > -30)
			{
				PaintInfoGameScreen.yNameMap += PaintInfoGameScreen.vyNameMap;
			}
			else
			{
				PaintInfoGameScreen.timeNameMap = 0;
			}
		}
	}

	// Token: 0x0600068C RID: 1676 RVA: 0x0006406C File Offset: 0x0006226C
	public void updateEvent()
	{
		if (EventScreen.vecEventShow.size() > 0)
		{
			if (this.eventShow == null)
			{
				this.eventShow = (MainEvent)EventScreen.vecEventShow.elementAt(0);
				this.timeEvent = 100;
				this.hShowEvent = 0;
			}
			else
			{
				this.timeEvent--;
				if (this.timeEvent <= 0)
				{
					this.eventShow = null;
					EventScreen.vecEventShow.removeElementAt(0);
				}
				if (this.hShowEvent < 35)
				{
					this.hShowEvent += 10;
				}
				if (this.hShowEvent > 35)
				{
					this.hShowEvent = 35;
				}
			}
			if (GameCanvas.isPointSelect(GameCanvas.hw - PaintInfoGameScreen.wShowEvent / 2, 0, PaintInfoGameScreen.wShowEvent, 35))
			{
				MainEvent mainEvent = EventScreen.setEvent(this.eventShow.nameEvent, (sbyte)this.eventShow.IDCmd);
				if (mainEvent != null)
				{
					GameCanvas.mevent.doEvent(false, mainEvent);
				}
				if (this.timeEvent > 40)
				{
					this.timeEvent = 40;
				}
				GameCanvas.isPointerSelect = false;
			}
			if (GameCanvas.keyMyHold[11])
			{
				GameCanvas.clearKeyHold(11);
				int num = EventScreen.setIndexEvent(this.eventShow.nameEvent, (sbyte)this.eventShow.IDCmd);
				if (num >= 0)
				{
					GameCanvas.mevent.idSelect = num;
				}
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
		}
		else if (this.hShowEvent > 0)
		{
			this.hShowEvent -= 20;
		}
	}

	// Token: 0x0600068D RID: 1677 RVA: 0x00064200 File Offset: 0x00062400
	public void paintShowEvent(mGraphics g)
	{
		if (this.eventShow != null || this.hShowEvent > 0)
		{
			GameCanvas.resetTrans(g);
			int num = GameCanvas.hw - PaintInfoGameScreen.wShowEvent / 2;
			int indexcolor = 2;
			if (GameCanvas.gameTick % 16 > 7)
			{
				indexcolor = 12;
			}
			AvMain.paintDialogNew(g, num, -5, PaintInfoGameScreen.wShowEvent, this.hShowEvent + 5, indexcolor);
			if (this.eventShow != null)
			{
				PaintInfoGameScreen.fraEvent.drawFrame(this.eventShow.IDCmd * 2, num + 20, -35 + this.hShowEvent + 17 + 3, 0, 3, g);
				mFont.tahoma_7b_white.drawString(g, this.eventShow.nameEvent, num + 35, -35 + this.hShowEvent + 5, 0, mGraphics.isTrue);
				mFont.tahoma_7_white.drawString(g, this.eventShow.contentEvent, num + 42, -35 + this.hShowEvent + 18, 0, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x0600068E RID: 1678 RVA: 0x000642F0 File Offset: 0x000624F0
	public void paintPoiterAll(mGraphics g)
	{
		if (!GameCanvas.isTouch)
		{
			return;
		}
		for (int i = 0; i < PaintInfoGameScreen.mPosOther.Length; i++)
		{
			if (i != 3 || !PaintInfoGameScreen.isLevelPoint)
			{
				int num = 0;
				if (PaintInfoGameScreen.timePointer > 0 && PaintInfoGameScreen.keyPoint == 100 + i)
				{
					num = 1;
				}
				if (GameScreen.player.Action != 4)
				{
					int num2 = PaintInfoGameScreen.mPosOther[i][0];
					int num3 = PaintInfoGameScreen.mPosOther[i][1];
					if (i == 0)
					{
						num3 -= PaintInfoGameScreen.hShowInGame;
					}
					else if (i == 1)
					{
						num2 -= PaintInfoGameScreen.hShowInGame;
					}
					else if (i == 4)
					{
						num3 += PaintInfoGameScreen.hShowInGame;
					}
					else
					{
						num2 += PaintInfoGameScreen.hShowInGame;
					}
					bool flag = true;
					if (i == 0 && GameScreen.player.Lv > 10)
					{
						flag = false;
					}
					if (flag)
					{
						if (i != 1)
						{
							g.drawRegion(PaintInfoGameScreen.imgOther[i], 0, num * PaintInfoGameScreen.mSizeImgOther[i][1], PaintInfoGameScreen.mSizeImgOther[i][0], PaintInfoGameScreen.mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawRegion(PaintInfoGameScreen.imgOther[i], 0, 0, PaintInfoGameScreen.mSizeImgOther[i][0], PaintInfoGameScreen.mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isTrue);
							if (this.timeDownChat != -1L && mSystem.currentTimeMillis() - this.timeDownChat >= 100L)
							{
								if (GameCanvas.gameTick % 2 == 0)
								{
									this.hClip++;
								}
								if (this.hClip >= PaintInfoGameScreen.mSizeImgOther[i][1])
								{
									this.hClip = PaintInfoGameScreen.mSizeImgOther[i][1];
								}
							}
							g.setClip(num2, num3, PaintInfoGameScreen.mSizeImgOther[i][0], this.hClip);
							g.drawRegion(PaintInfoGameScreen.imgOther[i], 0, PaintInfoGameScreen.mSizeImgOther[i][1], PaintInfoGameScreen.mSizeImgOther[i][0], PaintInfoGameScreen.mSizeImgOther[i][1], 0, num2, num3, 0, mGraphics.isTrue);
							GameCanvas.resetTrans(g);
						}
					}
				}
			}
		}
		if (GameScreen.player.Action == 4)
		{
			return;
		}
		if (PaintInfoGameScreen.isLevelPoint)
		{
			this.paintKillPlayer(g);
		}
		else
		{
			g.drawImage(PaintInfoGameScreen.imgMove[0], PaintInfoGameScreen.xPointMove - PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointMove, 3, mGraphics.isFalse);
			for (int j = 0; j < 4; j++)
			{
				if (PaintInfoGameScreen.timePointer > 0 && this.mKeyMove[j] == PaintInfoGameScreen.keyPoint)
				{
					g.drawRegion(PaintInfoGameScreen.imgMove[2], 0, 0, 32, 56, this.mRotateMove[j] + ((j <= 1) ? 0 : 4), PaintInfoGameScreen.mPosMove[j][0] - PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.mPosMove[j][1], 3, mGraphics.isFalse);
				}
			}
			int num4 = 0;
			if (PaintInfoGameScreen.timePointer > 0 && PaintInfoGameScreen.keyPoint == 5)
			{
				num4 = 1;
			}
			g.drawImage(AvMain.imgHotKey, PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointKill, 3, mGraphics.isFalse);
			if (PaintInfoGameScreen.timeChange == 0)
			{
				if (GameScreen.ObjFocus != null && (int)GameScreen.ObjFocus.typeBoss == 2)
				{
					for (int k = 0; k < 5; k++)
					{
						int y = 0;
						if (PaintInfoGameScreen.timePointer > 0 && PaintInfoGameScreen.keyPoint == PaintInfoGameScreen.mValueHotKey[k])
						{
							y = 1;
						}
						int x;
						int num5;
						if (k == 2)
						{
							x = PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame;
							num5 = PaintInfoGameScreen.yPointKill;
						}
						else
						{
							x = PaintInfoGameScreen.mPosKill[k - ((k <= 2) ? 0 : 1)][0] + PaintInfoGameScreen.hShowInGame;
							num5 = PaintInfoGameScreen.mPosKill[k - ((k <= 2) ? 0 : 1)][1];
						}
						g.drawRegion(PaintInfoGameScreen.imgFire[1], 0, y, 50, 50, 0, x, num5, 3, mGraphics.isFalse);
						g.drawImage(AvMain.imgHotKey, x, num5, 3, mGraphics.isFalse);
						AvMain.Font3dWhite(g, PaintInfoGameScreen.mValueHotKey[k] + string.Empty, x, num5 - 5, 2);
					}
					return;
				}
				HotKey hotKey = Player.mhotkey[Player.levelTab][2];
				if (GameScreen.player.checkGiaoTiep())
				{
					g.drawImage(AvMain.imgicongt, PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointKill, 3, mGraphics.isFalse);
				}
				else if (hotKey != null && (int)hotKey.type == (int)HotKey.SKILL)
				{
					Skill skillFormId = MainListSkill.getSkillFormId((int)hotKey.id);
					if (skillFormId != null)
					{
						skillFormId.paint(g, PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointKill, 3);
					}
				}
				else if (hotKey != null && (int)hotKey.type == (int)HotKey.POTION)
				{
					Item itemInventory = Item.getItemInventory(4, hotKey.id);
					if (itemInventory != null)
					{
						itemInventory.paintItem(g, PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointKill, (int)MainTabNew.wOneItem, 0, 3);
					}
				}
				for (int l = 0; l < PaintInfoGameScreen.mPosKill.Length; l++)
				{
					int num6 = 0;
					if (PaintInfoGameScreen.timePointer > 0 && PaintInfoGameScreen.keyPoint == PaintInfoGameScreen.mKeySkill[l])
					{
						num6 = 1;
					}
					g.drawRegion(PaintInfoGameScreen.imgFire[1], 0, num6 * 50, 50, 50, 0, PaintInfoGameScreen.mPosKill[l][0] + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.mPosKill[l][1], 3, mGraphics.isFalse);
					g.drawImage(AvMain.imgHotKey, PaintInfoGameScreen.mPosKill[l][0] + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.mPosKill[l][1], 3, mGraphics.isFalse);
					hotKey = Player.mhotkey[Player.levelTab][l + ((l <= 1) ? 0 : 1)];
					if (hotKey != null && (int)hotKey.type == (int)HotKey.SKILL)
					{
						Skill skillFormId2 = MainListSkill.getSkillFormId((int)hotKey.id);
						if (skillFormId2 != null)
						{
							skillFormId2.paint(g, PaintInfoGameScreen.mPosKill[l][0] + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.mPosKill[l][1], 3);
						}
					}
					else if (hotKey != null && (int)hotKey.type == (int)HotKey.POTION && MainTemplateItem.isload)
					{
						Item itemInventory2 = Item.getItemInventory(4, hotKey.id);
						if (itemInventory2 != null)
						{
							if (MainTemplateItem.isload)
							{
								itemInventory2.paintItem(g, PaintInfoGameScreen.mPosKill[l][0] + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.mPosKill[l][1], (int)MainTabNew.wOneItem, 0, 3);
							}
						}
						else
						{
							hotKey.setHotKey(0, (int)HotKey.NULL, 0);
							MainItem.setAddHotKey(1, false);
							MainItem.setAddHotKey(0, false);
						}
					}
				}
				for (int m = 0; m < 5; m++)
				{
					HotKey hotKey2 = Player.mhotkey[Player.levelTab][m];
					if (hotKey2 != null && (int)hotKey2.type != (int)HotKey.NULL)
					{
						int num7;
						int num8;
						if (m == 2)
						{
							num7 = PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame;
							num8 = PaintInfoGameScreen.yPointKill;
						}
						else
						{
							num7 = PaintInfoGameScreen.mPosKill[m - ((m <= 2) ? 0 : 1)][0] + PaintInfoGameScreen.hShowInGame;
							num8 = PaintInfoGameScreen.mPosKill[m - ((m <= 2) ? 0 : 1)][1];
						}
						DelaySkill delaySkill = null;
						if (hotKey2 != null && (int)hotKey2.type == (int)HotKey.SKILL)
						{
							delaySkill = Player.timeDelaySkill[(int)hotKey2.id];
						}
						else if (hotKey2 != null && (int)hotKey2.type == (int)HotKey.POTION && MainTemplateItem.isload)
						{
							Item itemInventory3 = Item.getItemInventory(4, hotKey2.id);
							if (itemInventory3 != null && (int)itemInventory3.typePotion < 2)
							{
								delaySkill = Player.timeDelayPotion[(int)itemInventory3.typePotion];
							}
						}
						if (delaySkill != null && delaySkill.limit > 0)
						{
							if (delaySkill.value > 0)
							{
								int num9 = delaySkill.value * 20 / delaySkill.limit;
								if (num9 < 1)
								{
									num9 = 1;
								}
								g.drawRegion(AvMain.imgDelaySkill, 0, 0, 20, num9, 0, num7 - 10, num8 - 10, 0, mGraphics.isFalse);
								int num10 = delaySkill.value / 1000;
								string st = string.Empty;
								if (num10 == 0)
								{
									st = "0." + delaySkill.value % 1000 / 100;
								}
								else
								{
									st = string.Empty + num10;
								}
								mFont.tahoma_7b_white.drawString(g, st, num7, num8 - 5, 2, mGraphics.isFalse);
							}
							else if (delaySkill.value > -150)
							{
								g.setColor(15658700);
								g.fillRoundRect(num7 - 10, num8 - 10, 20, 20, 4, 4, mGraphics.isFalse);
							}
						}
					}
				}
			}
			else
			{
				this.paintChangeTab(g);
			}
			g.drawRegion(PaintInfoGameScreen.imgFire[0], 0, num4 * 50, 50, 50, 0, PaintInfoGameScreen.xPointKill + PaintInfoGameScreen.hShowInGame, PaintInfoGameScreen.yPointKill, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x0600068F RID: 1679 RVA: 0x00064C18 File Offset: 0x00062E18
	public void updatePoiterAll()
	{
		if (PaintInfoGameScreen.timePointer > 0)
		{
			PaintInfoGameScreen.timePointer--;
		}
		if (PaintInfoGameScreen.timeChange > 0)
		{
			PaintInfoGameScreen.timeChange++;
			if (PaintInfoGameScreen.timeChange > 6)
			{
				PaintInfoGameScreen.timeChange = 0;
				Player.levelTab++;
				if (Player.levelTab > 2)
				{
					Player.levelTab = 0;
				}
			}
		}
		if ((int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END)
		{
			return;
		}
		bool flag = true;
		if (GameCanvas.isPointerSelect)
		{
			if (PaintInfoGameScreen.isLevelPoint)
			{
				if (GameCanvas.isPoint(PaintInfoGameScreen.xPaintSkill + 11 - PaintInfoGameScreen.wSkill / 2, PaintInfoGameScreen.yPaintSkill + 11 - PaintInfoGameScreen.wSkill / 2, 5 * PaintInfoGameScreen.wSkill, PaintInfoGameScreen.wSkill))
				{
					int num = (GameCanvas.px - PaintInfoGameScreen.xPaintSkill + 11) / PaintInfoGameScreen.wSkill;
					GameCanvas.isPointerSelect = false;
					if (num >= 0 && num < Player.mhotkey[Player.levelTab].Length)
					{
						HotKey hotKey = Player.mhotkey[Player.levelTab][num];
						if (PaintInfoGameScreen.isLevelPoint)
						{
							if ((int)hotKey.type == (int)HotKey.SKILL)
							{
								if (GameScreen.ObjFocus != null)
								{
									GameScreen.player.setActionHotKey(num, false);
								}
							}
							else
							{
								if (num == 2)
								{
									PaintInfoGameScreen.keyPoint = 5;
								}
								else
								{
									PaintInfoGameScreen.keyPoint = PaintInfoGameScreen.mKeySkill[(num <= 1) ? num : (num - 1)];
								}
								int num2 = 20 + PaintInfoGameScreen.keyPoint;
								if (Main.isPC && !Player.isCapCha())
								{
									if (num2 == 27)
									{
										num2 = 4;
									}
									else if (num2 == 29)
									{
										num2 = 5;
									}
									if (num2 == 21)
									{
										num2 = 1;
									}
									else if (num2 == 23)
									{
										num2 = 2;
									}
									else if (num2 == 25)
									{
										num2 = 3;
									}
								}
								GameCanvas.keyMyPressed[num2] = true;
							}
						}
						PaintInfoGameScreen.timePointer = 3;
						flag = false;
					}
				}
			}
			else if (GameCanvas.isPoint(PaintInfoGameScreen.xPointKill - PaintInfoGameScreen.wMainSkill / 2, PaintInfoGameScreen.yPointKill - PaintInfoGameScreen.wMainSkill / 2, PaintInfoGameScreen.wMainSkill, PaintInfoGameScreen.wMainSkill))
			{
				GameCanvas.isPointerSelect = false;
				PaintInfoGameScreen.keyPoint = 5;
				PaintInfoGameScreen.timePointer = 3;
				GameCanvas.keyMyPressed[25] = true;
				GameCanvas.keyMyPressed[5] = true;
				flag = false;
			}
			else
			{
				for (int i = 0; i < PaintInfoGameScreen.mPosKill.Length; i++)
				{
					if (GameCanvas.isPoint(PaintInfoGameScreen.mPosKill[i][0] - PaintInfoGameScreen.wSkill / 2, PaintInfoGameScreen.mPosKill[i][1] - PaintInfoGameScreen.wSkill / 2, PaintInfoGameScreen.wSkill, PaintInfoGameScreen.wSkill))
					{
						GameCanvas.isPointerSelect = false;
						PaintInfoGameScreen.keyPoint = PaintInfoGameScreen.mKeySkill[i];
						GameCanvas.keyMyPressed[20 + PaintInfoGameScreen.keyPoint] = true;
						PaintInfoGameScreen.timePointer = 3;
						flag = false;
						break;
					}
				}
			}
			if (GameCanvas.isPointerSelect)
			{
				for (int j = 0; j < PaintInfoGameScreen.mPosOther.Length; j++)
				{
					if (j != 3 || !PaintInfoGameScreen.isLevelPoint)
					{
						if (GameCanvas.isPoint(PaintInfoGameScreen.mPosOther[j][0] - 2, PaintInfoGameScreen.mPosOther[j][1] - 2, PaintInfoGameScreen.mSizeImgOther[j][0] + 4, PaintInfoGameScreen.mSizeImgOther[j][1] + 4))
						{
							GameCanvas.isPointerSelect = false;
							if (j == 1 && this.timeDownChat == -1L)
							{
								this.timeDownChat = mSystem.currentTimeMillis();
							}
							this.selectPointer(j);
							flag = false;
							break;
						}
					}
				}
				if (GameCanvas.isPoint(MainTabNew.gI().xChar, MainTabNew.gI().yChar, 90, 35))
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(0);
					return;
				}
				if (GameCanvas.isPoint(PaintInfoGameScreen.xMess - 4, PaintInfoGameScreen.yMess - 4, 24, 20))
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(-1);
				}
				if (GameCanvas.isPoint(GameCanvas.w - 50, GameCanvas.minimap.maxY * MiniMap.wMini - 8, 50, 30))
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(-2);
				}
				else if (GameCanvas.isPoint(GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini, 0, GameCanvas.minimap.maxX * MiniMap.wMini, GameCanvas.minimap.maxY * MiniMap.wMini) && !this.isMapThachdau())
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(-4);
				}
				if (GameCanvas.isPoint(95, 0, 24, 40))
				{
					GameCanvas.isPointerSelect = false;
					this.selectPointer(-3);
				}
				for (int k = 0; k < LoadMap.vecPointChange.size(); k++)
				{
					Point point = (Point)LoadMap.vecPointChange.elementAt(k);
					int num3 = point.x - MainScreen.cameraMain.xCam;
					int num4 = point.y - MainScreen.cameraMain.yCam;
					if (GameCanvas.isPoint(num3 - 12, num4 - 12, 24, 24))
					{
						GameScreen.player.toX = GameScreen.player.x;
						GameScreen.player.toY = GameScreen.player.y;
						this.posTam = GameCanvas.game.updateFindRoad(point.x / LoadMap.wTile, point.y / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 16);
						if (this.posTam != null && this.posTam.Length > 16)
						{
							this.posTam = null;
						}
						GameScreen.player.posTransRoad = this.posTam;
						Player.xFocus = point.x;
						Player.yFocus = point.y;
						Player.timeFocus = 9;
						GameCanvas.isPointerSelect = false;
						if ((int)Player.isAutoFire == 1)
						{
							Player.setCurAutoFire();
						}
						break;
					}
				}
			}
		}
		else if (!PaintInfoGameScreen.isLevelPoint)
		{
			if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
			{
				for (int l = 0; l < PaintInfoGameScreen.mPosOther.Length; l++)
				{
					if (GameCanvas.isPoint(PaintInfoGameScreen.mPosOther[l][0] - 4, PaintInfoGameScreen.mPosOther[l][1] - 4, PaintInfoGameScreen.mSizeImgOther[l][0] + 8, PaintInfoGameScreen.mSizeImgOther[l][1] + 8))
					{
						if (l == 1 && this.timeDownChat == -1L)
						{
							this.timeDownChat = mSystem.currentTimeMillis();
						}
						PaintInfoGameScreen.keyPoint = 100 + l;
						PaintInfoGameScreen.timePointer = 3;
						break;
					}
				}
				if (GameCanvas.isPointLast(PaintInfoGameScreen.xPointMove - 2 * PaintInfoGameScreen.wArrowMove, PaintInfoGameScreen.yPointMove - 2 * PaintInfoGameScreen.wArrowMove, PaintInfoGameScreen.wArrowMove * 4, PaintInfoGameScreen.wArrowMove * 4))
				{
					int num5 = CRes.angle(GameCanvas.px - PaintInfoGameScreen.xPointMove, GameCanvas.py - PaintInfoGameScreen.yPointMove);
					int num6;
					if (num5 > 45 && num5 <= 135)
					{
						num6 = 3;
					}
					else if (num5 > 135 && num5 <= 225)
					{
						num6 = 0;
					}
					else if (num5 > 225 && num5 <= 315)
					{
						num6 = 2;
					}
					else
					{
						num6 = 1;
					}
					GameCanvas.clearKeyHold();
					GameCanvas.isPointerDown = true;
					GameCanvas.isPointerSelect = false;
					PaintInfoGameScreen.keyPoint = this.mKeyMove[num6];
					GameCanvas.keyMyHold[PaintInfoGameScreen.keyPoint] = true;
					PaintInfoGameScreen.timePointer = 3;
					flag = false;
					if ((int)Player.isAutoFire == 1)
					{
						Player.setCurAutoFire();
					}
				}
			}
		}
		else if (PaintInfoGameScreen.isLevelPoint && (GameCanvas.isPointerDown || GameCanvas.isPointerMove))
		{
			for (int m = 0; m < PaintInfoGameScreen.mPosOther.Length; m++)
			{
				if (GameCanvas.isPoint(PaintInfoGameScreen.mPosOther[m][0] - 4, PaintInfoGameScreen.mPosOther[m][1] - 4, PaintInfoGameScreen.mSizeImgOther[m][0] + 8, PaintInfoGameScreen.mSizeImgOther[m][1] + 8))
				{
					if (m == 1 && this.timeDownChat == -1L)
					{
						this.timeDownChat = mSystem.currentTimeMillis();
					}
					PaintInfoGameScreen.keyPoint = 100 + m;
					PaintInfoGameScreen.timePointer = 3;
					break;
				}
			}
		}
		if (flag)
		{
			this.updatePointMoveIngame();
		}
		if (PaintInfoGameScreen.isLevelPoint && GameCanvas.currentScreen == GameCanvas.game)
		{
			if (GameCanvas.isPointerMove)
			{
				if (!GameScreen.isMoveCamera && (CRes.abs(GameCanvas.px - GameCanvas.pxLast) > 36 || CRes.abs(GameCanvas.py - GameCanvas.pyLast) > 36))
				{
					GameScreen.isMoveCamera = true;
				}
				GameScreen.xMoveCam = GameCanvas.px - GameCanvas.pxLast;
				GameScreen.yMoveCam = GameCanvas.py - GameCanvas.pyLast;
				GameScreen.timeResetCam = 40;
			}
			else if (GameCanvas.isPointerDown)
			{
				GameScreen.xCur = MainScreen.cameraMain.xCam;
				GameScreen.yCur = MainScreen.cameraMain.yCam;
				GameScreen.xMoveCam = 0;
				GameScreen.yMoveCam = 0;
			}
		}
	}

	// Token: 0x06000690 RID: 1680 RVA: 0x00065500 File Offset: 0x00063700
	public void updatePointMoveIngame()
	{
		if (GameCanvas.isPointerSelect)
		{
			if (!PaintInfoGameScreen.isLevelPoint && (GameCanvas.isPoint(PaintInfoGameScreen.xPointKill - PaintInfoGameScreen.lSkill - 25, PaintInfoGameScreen.yPointKill - PaintInfoGameScreen.lSkill - 25, PaintInfoGameScreen.lSkill * 2 + 50, PaintInfoGameScreen.lSkill * 2 + 50) || GameCanvas.isPoint(PaintInfoGameScreen.xPointMove - PaintInfoGameScreen.wArrowMove - 30, PaintInfoGameScreen.yPointMove - PaintInfoGameScreen.wArrowMove - 30, PaintInfoGameScreen.wArrowMove * 2 + 60, PaintInfoGameScreen.wArrowMove * 2 + 60)) && GameScreen.player.Action != 4)
			{
				GameCanvas.isPointerSelect = false;
				GameCanvas.isPointerDown = false;
				return;
			}
			int num = GameCanvas.px + MainScreen.cameraMain.xCam;
			int num2 = GameCanvas.py + MainScreen.cameraMain.yCam;
			MainObject mainObject = null;
			if (GameScreen.ObjFocus == null || (int)GameScreen.ObjFocus.typeBoss != 2)
			{
				if (MainObject.getDistance(num, num2, GameScreen.player.x, GameScreen.player.y) <= GameScreen.player.wFocus - 15 || GameScreen.player.Action == 4)
				{
					mainObject = this.setObjectNear(num, num2);
					if (mainObject != null && (int)mainObject.typeObject != 1 && (int)Player.isAutoFire == 1)
					{
						Player.setCurAutoFire();
					}
				}
			}
			if (this.isTouchFocus && GameCanvas.isTouch)
			{
				if (mainObject != null)
				{
					if (!mainObject.canFocus())
					{
						return;
					}
					if (PaintInfoGameScreen.isMarket(GameCanvas.loadmap.idMap) && !mainObject.isSelling() && (int)mainObject.typeObject == 0)
					{
						return;
					}
					mainObject.timeStand = 5;
					GameScreen.ObjFocus = mainObject;
					GameCanvas.isPointerSelect = false;
					if (MainObject.getDistance(mainObject.x, mainObject.y, GameScreen.player.x, GameScreen.player.y) <= GameScreen.player.wFocus)
					{
						GameScreen.player.setPointFocus();
						PaintInfoGameScreen.isPaintInfoFocus = true;
						GameScreen.addEffectKill(68, GameScreen.player.ID, 0, GameScreen.ObjFocus.ID, GameScreen.ObjFocus.typeObject, 0, GameScreen.ObjFocus.hp, ((int)GameScreen.ObjFocus.typeObject != 1) ? 1 : 0);
						this.posTam = null;
					}
					if (GameCanvas.isPointerSelect)
					{
						int tile = GameCanvas.loadmap.getTile(num, num2);
						if (tile != -1 && tile != 1)
						{
							GameScreen.player.toX = GameScreen.player.x;
							GameScreen.player.toY = GameScreen.player.y;
							this.posTam = GameCanvas.game.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 100);
							if (this.posTam != null && this.posTam.Length > 100)
							{
								this.posTam = null;
							}
							this.timeMove = 3;
							GameCanvas.isPointerSelect = false;
							Player.xFocus = num;
							Player.yFocus = num2;
						}
						else
						{
							this.posTam = null;
						}
					}
				}
				else
				{
					if (GameScreen.player.Action == 4)
					{
						return;
					}
					int tile2 = GameCanvas.loadmap.getTile(num, num2);
					if (tile2 != -1 && tile2 != 1)
					{
						GameScreen.player.toX = GameScreen.player.x;
						GameScreen.player.toY = GameScreen.player.y;
						this.posTam = GameCanvas.game.updateFindRoad(num / LoadMap.wTile, num2 / LoadMap.wTile, GameScreen.player.x / LoadMap.wTile, GameScreen.player.y / LoadMap.wTile, 100);
						if (this.posTam != null && this.posTam.Length > 100)
						{
							this.posTam = null;
						}
						if (GameScreen.player.posTransRoad != null)
						{
							this.timeMove = 1;
						}
						else
						{
							this.timeMove = 3;
						}
						GameCanvas.isPointerSelect = false;
						Player.xFocus = num;
						Player.yFocus = num2;
					}
					else
					{
						this.posTam = null;
						GameCanvas.isPointerSelect = false;
					}
				}
			}
			else if (!PaintInfoGameScreen.isLevelPoint && mainObject != null && (int)mainObject.typeObject != 9 && (int)mainObject.typeObject != 10 && !mainObject.isLuaThieng() && !mainObject.isDongBang)
			{
				PaintInfoGameScreen.vecfocus.removeAllElements();
				if (GameScreen.ObjFocus == mainObject)
				{
					if ((int)Player.mhotkey[Player.levelTab][2].type == (int)HotKey.SKILL)
					{
						GameCanvas.keyMyPressed[25] = true;
						GameCanvas.keyMyPressed[5] = true;
					}
					this.timeMove = 0;
					this.posTam = null;
				}
				else
				{
					if (!mainObject.canFocus())
					{
						return;
					}
					mainObject.timeStand = 5;
					GameScreen.ObjFocus = mainObject;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (PaintInfoGameScreen.isLevelPoint && this.timeMove > 0)
		{
			if (this.timeMove == 1 && this.posTam != null && GameScreen.player.Action != 4 && GameScreen.player.Action != 2 && GameScreen.player.currentQuest == null)
			{
				GameScreen.player.xStopMove = 0;
				GameScreen.player.yStopMove = 0;
				if (GameScreen.player.posTransRoad != null)
				{
					GameScreen.player.countAutoMove = 1;
				}
				GameScreen.player.resetMove();
				GameScreen.player.posTransRoad = this.posTam;
				this.posTam = null;
				Player.timeFocus = 9;
				if (Player.timeResetAuto <= 0 && (int)Player.isAutoFire == 1)
				{
					Player.setCurAutoFire();
				}
			}
			this.timeMove--;
		}
	}

	// Token: 0x06000691 RID: 1681 RVA: 0x00065ACC File Offset: 0x00063CCC
	public MainObject setObjectNear(int x, int y)
	{
		MainObject mainObject = null;
		MainObject mainObject2 = null;
		int num = 40;
		bool flag = false;
		int i = 0;
		while (i < GameScreen.Vecplayers.size())
		{
			MainObject mainObject3 = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
			{
				if (((int)mainObject3.typePk != (int)GameScreen.player.typePk && mainObject3 != null && mainObject3 != GameScreen.player && (int)mainObject3.typeObject != 9 && !mainObject3.isLuaThieng() && (int)mainObject3.typeObject != 10 && !mainObject3.isDongBang) || (int)mainObject3.typeObject == 2)
				{
					goto IL_110;
				}
			}
			else if (mainObject3 != null && mainObject3 != GameScreen.player && (int)mainObject3.typeObject != 9 && !mainObject3.isDongBang && (int)mainObject3.typeObject != 10 && !mainObject3.isThacNuoc() && !mainObject3.isLuaThieng())
			{
				goto IL_110;
			}
			IL_230:
			i++;
			continue;
			IL_110:
			if (mainObject3.Action == 4 && (int)mainObject3.typeObject == 1)
			{
				goto IL_230;
			}
			int distance = MainObject.getDistance(x, y, mainObject3.x, mainObject3.y - mainObject3.hOne / 4);
			if (distance >= num && (!GameCanvas.loadmap.mapLang() || (int)mainObject3.typeObject != 2 || distance >= 40 || !Player.isFocusNPC))
			{
				goto IL_230;
			}
			if (!flag)
			{
				flag = true;
				mainObject2 = mainObject3;
			}
			bool flag2 = true;
			for (int j = 0; j < PaintInfoGameScreen.vecfocus.size(); j++)
			{
				MainObject mainObject4 = (MainObject)PaintInfoGameScreen.vecfocus.elementAt(j);
				if (mainObject4 != null)
				{
					if (mainObject4 != null && mainObject3.ID == mainObject4.ID)
					{
						flag2 = false;
						break;
					}
				}
			}
			if (flag2)
			{
				mainObject = mainObject3;
				num = distance;
			}
			if ((int)mainObject3.typeObject == 2 && Player.isFocusNPC)
			{
				PaintInfoGameScreen.vecfocus.addElement(mainObject);
				Player.isFocusNPC = false;
				Player.timeFocusNPC = 0;
				return mainObject;
			}
			goto IL_230;
		}
		if (flag && mainObject == null)
		{
			PaintInfoGameScreen.vecfocus.removeAllElements();
			mainObject = mainObject2;
		}
		if (mainObject != null)
		{
			PaintInfoGameScreen.vecfocus.addElement(mainObject);
		}
		else
		{
			PaintInfoGameScreen.vecfocus.removeAllElements();
		}
		return mainObject;
	}

	// Token: 0x06000692 RID: 1682 RVA: 0x00065D5C File Offset: 0x00063F5C
	public void paintChangeTab(mGraphics g)
	{
		int num = PaintInfoGameScreen.gocBegin;
		if (PaintInfoGameScreen.timeChange > 0)
		{
			num -= PaintInfoGameScreen.timeChange * 30;
		}
		for (int i = 0; i < 8; i++)
		{
			int x = PaintInfoGameScreen.xPointKill + CRes.cos(CRes.fixangle(num)) * PaintInfoGameScreen.lSkill / 1000 + PaintInfoGameScreen.hShowInGame;
			int y = PaintInfoGameScreen.yPointKill + CRes.sin(CRes.fixangle(num)) * PaintInfoGameScreen.lSkill / 1000;
			g.drawImage(AvMain.imgHotKey, x, y, 3, mGraphics.isFalse);
			int num2 = Player.levelTab;
			if (i > 3)
			{
				if (Player.levelTab == 0)
				{
					num2 = 1;
				}
				else
				{
					num2 = 0;
				}
			}
			HotKey hotKey = Player.mhotkey[num2][i % 4 + ((i % 4 <= 1) ? 0 : 1)];
			if (hotKey != null && (int)hotKey.type == (int)HotKey.SKILL)
			{
				Skill skillFormId = MainListSkill.getSkillFormId((int)hotKey.id);
				skillFormId.paint(g, x, y, 3);
			}
			else if (hotKey != null && (int)hotKey.type == (int)HotKey.POTION)
			{
				Item itemInventory = Item.getItemInventory(4, hotKey.id);
				if (itemInventory != null)
				{
					itemInventory.paintItem(g, x, y, (int)MainTabNew.wOneItem, 0, 3);
				}
			}
			num -= 45;
		}
	}

	// Token: 0x06000693 RID: 1683 RVA: 0x00065EB0 File Offset: 0x000640B0
	public void selectPointer(int select)
	{
		switch (select + 4)
		{
		case 0:
			if (!this.isMapchienthanh())
			{
				MiniMapFull_Screen.gI().Show();
				mSound.playSound(41, mSound.volumeSound);
			}
			break;
		case 1:
			if (Player.diemTiemNang > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.AllInfo.Show(GameCanvas.currentScreen);
				GameCanvas.AllInfo.selectTab = 2;
				return;
			}
			if (Player.diemKyNang > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.AllInfo.Show(GameCanvas.currentScreen);
				GameCanvas.AllInfo.selectTab = 3;
				return;
			}
			break;
		case 3:
			if (PaintInfoGameScreen.numMess > 0)
			{
				mSound.playSound(41, mSound.volumeSound);
				GameCanvas.mevent.init();
				GameCanvas.mevent.Show(GameCanvas.currentScreen);
			}
			break;
		case 4:
			if (GameScreen.isMoveCamera)
			{
				GameScreen.isMoveCamera = false;
			}
			else
			{
				GameScreen.gI().cmdMenu.perform();
			}
			break;
		case 5:
			mSound.playSound(41, mSound.volumeSound);
			if (mSystem.currentTimeMillis() - this.timeDownChat <= 500L)
			{
				ChatTextField.gI().setChat();
				this.timeDownChat = -1L;
				this.hClip = 0;
				newinput.TYPE_INPUT = 0;
			}
			else
			{
				GameScreen.gI().cmdQuickChat.perform();
				this.timeDownChat = -1L;
				this.hClip = 0;
			}
			break;
		case 6:
			if (GameScreen.ObjFocus == null || (int)GameScreen.ObjFocus.typeBoss != 2)
			{
				if (PaintInfoGameScreen.timeChange == 0)
				{
					mSound.playSound(41, mSound.volumeSound);
					PaintInfoGameScreen.timeChange = 1;
				}
			}
			break;
		case 7:
			if (GameScreen.ObjFocus != null)
			{
				Player.cmdNextFocus.perform();
			}
			break;
		case 8:
			if (!ChatTextField.isShow)
			{
				GameCanvas.menu2.setAt_Quick();
			}
			break;
		}
	}

	// Token: 0x06000694 RID: 1684 RVA: 0x000660C0 File Offset: 0x000642C0
	public void paintParty(mGraphics g)
	{
		if (Player.party != null)
		{
			for (int i = 0; i < Player.party.vecPartys.size(); i++)
			{
				ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(i);
				if (objectParty.name.CompareTo(GameScreen.player.name) == 0 || objectParty.isRemove)
				{
				}
			}
		}
	}

	// Token: 0x06000695 RID: 1685 RVA: 0x00066138 File Offset: 0x00064338
	public void paintNameMap(mGraphics g)
	{
		if (PaintInfoGameScreen.timeNameMap > 0)
		{
			PaintInfoGameScreen.timeNameMap--;
			AvMain.paintDialog(g, GameCanvas.hw - PaintInfoGameScreen.wNameMap / 2 - 10, PaintInfoGameScreen.yNameMap, PaintInfoGameScreen.wNameMap + 20, 35, 12);
			mFont.tahoma_7b_white.drawString(g, PaintInfoGameScreen.namemap, GameCanvas.hw, PaintInfoGameScreen.yNameMap + 7, 2, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
			{
				"- ",
				T.Area,
				LoadMap.getAreaPaint(),
				" -"
			}), GameCanvas.hw, PaintInfoGameScreen.yNameMap + 20, 2, mGraphics.isFalse);
		}
	}

	// Token: 0x06000696 RID: 1686 RVA: 0x000661F4 File Offset: 0x000643F4
	public void paintNameServer(mGraphics g, string servername)
	{
		if (PaintInfoGameScreen.timeNameMap > 0)
		{
			PaintInfoGameScreen.timeNameMap--;
			AvMain.paintDialog(g, GameCanvas.hw - PaintInfoGameScreen.wNameMap / 2 - 10, PaintInfoGameScreen.yNameMap, PaintInfoGameScreen.wNameMap + 20, 20, 12);
			mFont.tahoma_7b_white.drawString(g, servername, GameCanvas.hw, PaintInfoGameScreen.yNameMap + 4, 2, mGraphics.isFalse);
		}
	}

	// Token: 0x06000697 RID: 1687 RVA: 0x00066260 File Offset: 0x00064460
	public void setNameServer(string servername)
	{
		PaintInfoGameScreen.timeNameMap = 80;
		PaintInfoGameScreen.wNameMap = mFont.tahoma_7b_white.getWidth(servername);
		PaintInfoGameScreen.yNameMap = GameCanvas.h / 8;
		PaintInfoGameScreen.vyNameMap = 0;
		if (PaintInfoGameScreen.wNameMap < 80)
		{
			PaintInfoGameScreen.wNameMap = 80;
		}
	}

	// Token: 0x06000698 RID: 1688 RVA: 0x000662AC File Offset: 0x000644AC
	public static void setNameMap()
	{
		PaintInfoGameScreen.timeNameMap = 80;
		PaintInfoGameScreen.namemap = "map";
		if (WorldMapScreen.namePos != null && GameCanvas.loadmap.idMap < WorldMapScreen.namePos.Length)
		{
			PaintInfoGameScreen.namemap = WorldMapScreen.namePos[GameCanvas.loadmap.idMap];
		}
		PaintInfoGameScreen.wNameMap = mFont.tahoma_7b_white.getWidth(PaintInfoGameScreen.namemap);
		PaintInfoGameScreen.yNameMap = GameCanvas.h / 8;
		PaintInfoGameScreen.vyNameMap = 0;
		if (PaintInfoGameScreen.wNameMap < 80)
		{
			PaintInfoGameScreen.wNameMap = 80;
		}
	}

	// Token: 0x06000699 RID: 1689 RVA: 0x00066338 File Offset: 0x00064538
	public void updateShowIngame()
	{
		if (PaintInfoGameScreen.isShowInGame)
		{
			if (GameCanvas.isSmallScreen)
			{
				if ((GameCanvas.timeNow - PaintInfoGameScreen.timeDoNotClick) / 1000L > 15L)
				{
					PaintInfoGameScreen.isShowInGame = false;
				}
			}
			else if ((GameCanvas.timeNow - PaintInfoGameScreen.timeDoNotClick) / 1000L > 2L)
			{
				PaintInfoGameScreen.isShowInGame = false;
			}
			if (PaintInfoGameScreen.hShowInGame > 0)
			{
				PaintInfoGameScreen.hShowInGame -= 20;
				if (PaintInfoGameScreen.hShowInGame < 0)
				{
					PaintInfoGameScreen.hShowInGame = 0;
				}
			}
		}
		else if (PaintInfoGameScreen.hShowInGame < 100)
		{
			PaintInfoGameScreen.hShowInGame += 10;
		}
	}

	// Token: 0x0600069A RID: 1690 RVA: 0x000663E4 File Offset: 0x000645E4
	public static void setPosTouch()
	{
		if (Main.isPC)
		{
			PaintInfoGameScreen.isLevelPoint = true;
		}
		if (PaintInfoGameScreen.isLevelPoint)
		{
			PaintInfoGameScreen.mPosOther[2][1] = GameCanvas.h - 31;
			PaintInfoGameScreen.mPosOther[4][0] = 0;
		}
		else
		{
			PaintInfoGameScreen.mPosOther[2][1] = GameCanvas.h - 151;
			PaintInfoGameScreen.mPosOther[4][0] = GameCanvas.hw - 20;
		}
	}

	// Token: 0x0600069B RID: 1691 RVA: 0x00066450 File Offset: 0x00064650
	public bool isMapCountTime(int idMap)
	{
		return idMap == 59 || idMap == 57 || idMap == 55 || idMap == 53;
	}

	// Token: 0x0600069C RID: 1692 RVA: 0x00066478 File Offset: 0x00064678
	public bool isMapChienTruong(int idMap)
	{
		return idMap == 61 || idMap == 60 || idMap == 58 || idMap == 56 || idMap == 54;
	}

	// Token: 0x0600069D RID: 1693 RVA: 0x000664A8 File Offset: 0x000646A8
	public bool isMapThachdau()
	{
		return GameScreen.isShowHoiSinh;
	}

	// Token: 0x0600069E RID: 1694 RVA: 0x000664B0 File Offset: 0x000646B0
	public bool isMapchienthanh()
	{
		return GameCanvas.loadmap.idMap == 83 || GameCanvas.loadmap.idMap == 84 || GameCanvas.loadmap.idMap == 85 || GameCanvas.loadmap.idMap == 86 || GameCanvas.loadmap.idMap == 87;
	}

	// Token: 0x0600069F RID: 1695 RVA: 0x00066514 File Offset: 0x00064714
	public bool ismapHouse(int idMap)
	{
		return idMap == 60 || idMap == 58 || idMap == 56 || idMap == 54;
	}

	// Token: 0x060006A0 RID: 1696 RVA: 0x0006653C File Offset: 0x0006473C
	public bool isMapPetcage(int idmap)
	{
		return idmap == 50;
	}

	// Token: 0x060006A1 RID: 1697 RVA: 0x00066544 File Offset: 0x00064744
	public bool isMapLight(int mapId)
	{
		return mapId == 51 || (mapId >= 37 && mapId <= 41);
	}

	// Token: 0x060006A2 RID: 1698 RVA: 0x00066564 File Offset: 0x00064764
	public bool isMapDark(int mapId)
	{
		return mapId == 52 || mapId == 62 || (mapId >= 42 && mapId <= 45);
	}

	// Token: 0x060006A3 RID: 1699 RVA: 0x00066598 File Offset: 0x00064798
	public bool isMapArena(int idMap)
	{
		return this.isMapChienTruong(idMap) || this.isMapCountTime(idMap);
	}

	// Token: 0x060006A4 RID: 1700 RVA: 0x000665B0 File Offset: 0x000647B0
	public void setCountTimeHS(int idMap, long curtime, int timeCount)
	{
		if (this.isMapCountTime(idMap))
		{
			PaintInfoGameScreen.isCountTime = true;
			PaintInfoGameScreen.curTimeHS = (int)(curtime / 1000L + (long)timeCount);
		}
		else
		{
			PaintInfoGameScreen.isCountTime = false;
			PaintInfoGameScreen.timeHS = 0;
		}
	}

	// Token: 0x060006A5 RID: 1701 RVA: 0x000665F4 File Offset: 0x000647F4
	public void countTimeHS()
	{
		if (PaintInfoGameScreen.isCountTime)
		{
			if (PaintInfoGameScreen.timeHS >= 0)
			{
				PaintInfoGameScreen.timeHS = (int)((long)PaintInfoGameScreen.curTimeHS - mSystem.currentTimeMillis() / 1000L);
			}
			else
			{
				PaintInfoGameScreen.isCountTime = false;
				PaintInfoGameScreen.timeHS = 0;
			}
		}
	}

	// Token: 0x060006A6 RID: 1702 RVA: 0x00066640 File Offset: 0x00064840
	public void paintTimeHS(mGraphics g)
	{
		if (PaintInfoGameScreen.isCountTime && PaintInfoGameScreen.timeHS >= 0)
		{
			AvMain.Font3dWhite(g, T.backBattlefield + PaintInfoGameScreen.timeHS + "s", 70 - GameCanvas.w, PaintInfoGameScreen.mPosOther[0][1] + 15, 0);
		}
	}

	// Token: 0x060006A7 RID: 1703 RVA: 0x00066698 File Offset: 0x00064898
	public void setSttArena(sbyte type, sbyte totalHouse, short totalPlayer)
	{
		if ((int)type == -1)
		{
			return;
		}
		sbyte b;
		if ((int)type == 4)
		{
			b = 1;
		}
		else if ((int)type == 5)
		{
			b = 2;
		}
		else if ((int)type == 2)
		{
			b = 3;
		}
		else
		{
			b = 0;
		}
		if ((int)totalHouse != -1)
		{
			this.totalHouse[(int)b] = totalHouse;
		}
		if (totalPlayer != -1)
		{
			this.totalPlayer[(int)b] = totalPlayer;
		}
	}

	// Token: 0x060006A8 RID: 1704 RVA: 0x00066704 File Offset: 0x00064904
	public void paintSttArena(mGraphics g, int xSttArena, int ySttArena, int wSttArena, int hSttArena)
	{
		AvMain.Font3dWhite(g, T.infoArena, xSttArena - 5, ySttArena - 2 * hSttArena, 0);
		PaintInfoGameScreen.imgArenaIcon.drawFrame((int)this.typePaint[4], xSttArena, ySttArena - hSttArena, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
		AvMain.Font3dWhite(g, string.Empty + GameScreen.player.markKiller, xSttArena + wSttArena, ySttArena - hSttArena - 3, 0);
		for (int i = 0; i < this.totalHouse.Length; i++)
		{
			if ((int)this.totalHouse[i] > 0)
			{
				AvMain.fraPk.drawFrame((int)this.typePK[i] * 3 + GameCanvas.gameTick / 3 % 3, xSttArena, ySttArena + i * hSttArena + 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			else
			{
				AvMain.fraPk.drawFrame((int)this.typePK[4] * 3 + GameCanvas.gameTick / 3 % 3, xSttArena, ySttArena + i * hSttArena, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			}
			PaintInfoGameScreen.imgArenaIcon.drawFrame((int)this.typePaint[i], xSttArena + wSttArena, ySttArena + i * hSttArena - 2, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			AvMain.Font3dWhite(g, string.Empty + this.totalHouse[i], xSttArena + wSttArena + 10, ySttArena + i * hSttArena - 3, 0);
			g.drawRegion(MainTabNew.imgTab[3], 0, 32, 16, 16, 0, xSttArena + 3 * wSttArena, ySttArena + i * hSttArena, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			AvMain.Font3dWhite(g, string.Empty + this.totalPlayer[i], xSttArena + 3 * wSttArena + 10, ySttArena + i * hSttArena - 3, 0);
		}
	}

	// Token: 0x060006A9 RID: 1705 RVA: 0x000668C4 File Offset: 0x00064AC4
	public void resetShip()
	{
		this.eff = null;
		this.isShipMove = false;
	}

	// Token: 0x060006AA RID: 1706 RVA: 0x000668D4 File Offset: 0x00064AD4
	public void paintShip(mGraphics g)
	{
		if (GameCanvas.loadmap.idMap == 19)
		{
			if (this.eff == null)
			{
				this.eff = new EffectAuto(50, 1080, 96, 0, 0, 1, 0);
			}
			else
			{
				this.eff.update();
				if (!this.isShipMove)
				{
					this.eff.paint(g);
				}
				else
				{
					this.eff.x += 2;
					this.eff.paint(g);
					GameScreen.player.dyWater = 0;
					GameScreen.player.Action = 0;
					GameScreen.player.Direction = 3;
					GameScreen.player.x = this.eff.x + 30;
					GameScreen.player.y = this.eff.y - 40;
					GameScreen.player.updateActionPerson();
					GameScreen.player.paintPlayer(g, -1);
					if (this.eff.x > 1200)
					{
						ShipScr.gI().typeMap = 1;
						ShipScr.gI().Show();
					}
				}
			}
		}
		else if (GameCanvas.loadmap.idMap == 67)
		{
			if (this.eff == null)
			{
				this.eff = new EffectAuto(50, 360, 672, 0, 0, 1, 0);
			}
			else
			{
				this.eff.update();
				if (!this.isShipMove)
				{
					this.eff.paint(g);
				}
				else
				{
					this.eff.x += 2;
					this.eff.paint(g);
					GameScreen.player.dyWater = 0;
					GameScreen.player.Action = 0;
					GameScreen.player.Direction = 3;
					GameScreen.player.x = this.eff.x + 30;
					GameScreen.player.y = this.eff.y - 40;
					GameScreen.player.updateActionPerson();
					GameScreen.player.paintPlayer(g, -1);
					if (this.eff.x > 480)
					{
						ShipScr.gI().typeMap = 3;
						ShipScr.gI().Show();
					}
				}
			}
		}
	}

	// Token: 0x060006AB RID: 1707 RVA: 0x00066B0C File Offset: 0x00064D0C
	public void paintPos_minimap(mGraphics g, int x, int y)
	{
		if (this.isMapThachdau())
		{
			return;
		}
		this.xPos_minimap = GameScreen.player.x / LoadMap.wTile;
		this.yPos_minimap = GameScreen.player.y / LoadMap.wTile;
		mFont.tahoma_7_yellow.drawString(g, this.xPos_minimap + ":" + this.yPos_minimap, x, y, 1, mGraphics.isFalse);
	}

	// Token: 0x060006AC RID: 1708 RVA: 0x00066B84 File Offset: 0x00064D84
	public static void paintinfo18plush(mGraphics g)
	{
		if ((int)PaintInfoGameScreen.paint18plush == 0)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int x = 110;
		if (GameCanvas.currentScreen != GameCanvas.game)
		{
			x = 0;
		}
		int width = mFont.tahoma_7_white.getWidth("18+ Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.");
		g.setColor(0, 0.6f);
		g.fillRect(x, 0, width, 12, false);
		mFont.tahoma_7_white.drawString(g, "18+ Chơi quá 180 phút mỗi ngày sẽ hại sức khỏe.", x, 0, 0, false);
	}

	// Token: 0x060006AD RID: 1709 RVA: 0x00066BF4 File Offset: 0x00064DF4
	public static bool isMarket(int idmap)
	{
		return idmap == 82;
	}

	// Token: 0x060006AE RID: 1710 RVA: 0x00066BFC File Offset: 0x00064DFC
	public void paintIconClan(mGraphics g)
	{
		if (this.isMapchienthanh() && PaintInfoGameScreen.idicon != -1)
		{
			MainImage imageIconClan = ObjectData.getImageIconClan((short)PaintInfoGameScreen.idicon);
			if (imageIconClan.img != null)
			{
				AvMain.Font3dColor(g, PaintInfoGameScreen.nameclan.ToUpper(), GameCanvas.w / 2, 5, 2, 0);
				g.drawImage(imageIconClan.img, GameCanvas.w / 2 + mFont.tahoma_7_black.getWidth(PaintInfoGameScreen.nameclan) / 2, 10, 3, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x04000969 RID: 2409
	public short idCharLoiDai1 = -1;

	// Token: 0x0400096A RID: 2410
	public short idCharLoiDai2 = -1;

	// Token: 0x0400096B RID: 2411
	private int xPaintInfo;

	// Token: 0x0400096C RID: 2412
	private int xPaintInfoChar;

	// Token: 0x0400096D RID: 2413
	private int xmaxInfo;

	// Token: 0x0400096E RID: 2414
	private int xmaxInfoChar;

	// Token: 0x0400096F RID: 2415
	private int speedInfo = 2;

	// Token: 0x04000970 RID: 2416
	private int speedInfoChar = 2;

	// Token: 0x04000971 RID: 2417
	private int timepaintServer;

	// Token: 0x04000972 RID: 2418
	private int timePaintInfoChar;

	// Token: 0x04000973 RID: 2419
	public int timeInfoCharCline;

	// Token: 0x04000974 RID: 2420
	public int maxtimeChar;

	// Token: 0x04000975 RID: 2421
	public int ydInfoChar;

	// Token: 0x04000976 RID: 2422
	public int hImgInfo = 22;

	// Token: 0x04000977 RID: 2423
	private bool vipInfoChar;

	// Token: 0x04000978 RID: 2424
	public static int xPointMove = 55;

	// Token: 0x04000979 RID: 2425
	public static int yPointMove = GameCanvas.h - 55;

	// Token: 0x0400097A RID: 2426
	public static int xMess;

	// Token: 0x0400097B RID: 2427
	public static int yMess;

	// Token: 0x0400097C RID: 2428
	public static int numMess;

	// Token: 0x0400097D RID: 2429
	public static int yBeginInfo;

	// Token: 0x0400097E RID: 2430
	public static int wInfoServer;

	// Token: 0x0400097F RID: 2431
	public static int winfo18plus;

	// Token: 0x04000980 RID: 2432
	public static int wArrowMove = 30;

	// Token: 0x04000981 RID: 2433
	public static int wPointArrow = 38;

	// Token: 0x04000982 RID: 2434
	public static mImage[] imgMove;

	// Token: 0x04000983 RID: 2435
	public static mImage[] imgFire;

	// Token: 0x04000984 RID: 2436
	public static mImage[] imgOther;

	// Token: 0x04000985 RID: 2437
	public static mImage imgInfoFocus;

	// Token: 0x04000986 RID: 2438
	public static mImage imgauto;

	// Token: 0x04000987 RID: 2439
	public static mImage imgxp;

	// Token: 0x04000988 RID: 2440
	public static mImage imgmove;

	// Token: 0x04000989 RID: 2441
	public static mImage imgBackQuick;

	// Token: 0x0400098A RID: 2442
	public static FrameImage fraClose;

	// Token: 0x0400098B RID: 2443
	public static FrameImage fraFocusIngame;

	// Token: 0x0400098C RID: 2444
	public static FrameImage fraBack;

	// Token: 0x0400098D RID: 2445
	public static FrameImage fraMenu;

	// Token: 0x0400098E RID: 2446
	public static FrameImage fraButton;

	// Token: 0x0400098F RID: 2447
	public static FrameImage fraStatusArea;

	// Token: 0x04000990 RID: 2448
	public static FrameImage fraCloseMenu;

	// Token: 0x04000991 RID: 2449
	public static FrameImage fralevelup;

	// Token: 0x04000992 RID: 2450
	public static FrameImage fraButton2;

	// Token: 0x04000993 RID: 2451
	public static FrameImage fraContact;

	// Token: 0x04000994 RID: 2452
	public static FrameImage fraEvent;

	// Token: 0x04000995 RID: 2453
	public static FrameImage[] mfraIconQuick;

	// Token: 0x04000996 RID: 2454
	private int[] mRotateMove = new int[]
	{
		2,
		0,
		3,
		1
	};

	// Token: 0x04000997 RID: 2455
	private int[] mKeyMove = new int[]
	{
		4,
		6,
		2,
		8
	};

	// Token: 0x04000998 RID: 2456
	public static int[] mKeySkill = new int[]
	{
		1,
		3,
		7,
		9
	};

	// Token: 0x04000999 RID: 2457
	public static int[] mValueHotKey = new int[]
	{
		1,
		3,
		5,
		7,
		9
	};

	// Token: 0x0400099A RID: 2458
	public static string[] mValueChar = new string[]
	{
		"R",
		"T",
		"Y",
		"U",
		"I"
	};

	// Token: 0x0400099B RID: 2459
	private int[] mKeyOther = new int[]
	{
		100,
		101,
		102,
		103
	};

	// Token: 0x0400099C RID: 2460
	public static int[][] mPosKill = mSystem.new_M_Int(4, 2);

	// Token: 0x0400099D RID: 2461
	public static int[][] mPosMove = mSystem.new_M_Int(4, 2);

	// Token: 0x0400099E RID: 2462
	public static int[][] mPosOther = mSystem.new_M_Int(5, 2);

	// Token: 0x0400099F RID: 2463
	public static int[][] mSizeImgOther = mSystem.new_M_Int(5, 2);

	// Token: 0x040009A0 RID: 2464
	public static int timePointer = 0;

	// Token: 0x040009A1 RID: 2465
	public static int keyPoint;

	// Token: 0x040009A2 RID: 2466
	public static int timeChange;

	// Token: 0x040009A3 RID: 2467
	public static int timeNameMap;

	// Token: 0x040009A4 RID: 2468
	public static int wNameMap;

	// Token: 0x040009A5 RID: 2469
	public static int vyNameMap;

	// Token: 0x040009A6 RID: 2470
	public static int yNameMap;

	// Token: 0x040009A7 RID: 2471
	public static string namemap = string.Empty;

	// Token: 0x040009A8 RID: 2472
	public static int xPointKill = GameCanvas.w - 35;

	// Token: 0x040009A9 RID: 2473
	public static int yPointKill = GameCanvas.h - 50;

	// Token: 0x040009AA RID: 2474
	public static int wSkill = 24;

	// Token: 0x040009AB RID: 2475
	public static int wMainSkill = 50;

	// Token: 0x040009AC RID: 2476
	private static int gocBegin = 285;

	// Token: 0x040009AD RID: 2477
	private static int lSkill = 50;

	// Token: 0x040009AE RID: 2478
	private static int xPaintSkill = GameCanvas.hw - 60;

	// Token: 0x040009AF RID: 2479
	private static int yPaintSkill = GameCanvas.h - GameCanvas.hCommand - 14;

	// Token: 0x040009B0 RID: 2480
	public string strInfoServer;

	// Token: 0x040009B1 RID: 2481
	public string strInfoCharCline;

	// Token: 0x040009B2 RID: 2482
	public string strInfoCharServer;

	// Token: 0x040009B3 RID: 2483
	private int indexTab;

	// Token: 0x040009B4 RID: 2484
	public static bool isLevelPoint = false;

	// Token: 0x040009B5 RID: 2485
	public static bool isShowInfoAuto = true;

	// Token: 0x040009B6 RID: 2486
	public static bool isPaintInfoFocus = false;

	// Token: 0x040009B7 RID: 2487
	public static int hShowInGame = 0;

	// Token: 0x040009B8 RID: 2488
	public static bool isShowInGame = true;

	// Token: 0x040009B9 RID: 2489
	public static long timeDoNotClick = 0L;

	// Token: 0x040009BA RID: 2490
	public static int xFocus;

	// Token: 0x040009BB RID: 2491
	private static int yFocus;

	// Token: 0x040009BC RID: 2492
	private static int xParty;

	// Token: 0x040009BD RID: 2493
	private static int yParty;

	// Token: 0x040009BE RID: 2494
	public static int delta;

	// Token: 0x040009BF RID: 2495
	public static int[] imgHitWidth = new int[3];

	// Token: 0x040009C0 RID: 2496
	public static int[] imgHitHeight = new int[3];

	// Token: 0x040009C1 RID: 2497
	public static long timeThachdau;

	// Token: 0x040009C2 RID: 2498
	public static int WBlackclolor;

	// Token: 0x040009C3 RID: 2499
	public static int WRedclor;

	// Token: 0x040009C4 RID: 2500
	private int timeEvent;

	// Token: 0x040009C5 RID: 2501
	private int indexEvent;

	// Token: 0x040009C6 RID: 2502
	private int hShowEvent;

	// Token: 0x040009C7 RID: 2503
	public static int wShowEvent;

	// Token: 0x040009C8 RID: 2504
	private MainEvent eventShow;

	// Token: 0x040009C9 RID: 2505
	private long timeDownChat = -1L;

	// Token: 0x040009CA RID: 2506
	private int hClip;

	// Token: 0x040009CB RID: 2507
	public short[] posTam;

	// Token: 0x040009CC RID: 2508
	private int timeMove;

	// Token: 0x040009CD RID: 2509
	private int xlast;

	// Token: 0x040009CE RID: 2510
	private int ylast;

	// Token: 0x040009CF RID: 2511
	private bool isTouchFocus = true;

	// Token: 0x040009D0 RID: 2512
	public static mVector vecfocus = new mVector("PaintInfoGameScr vecfocus");

	// Token: 0x040009D1 RID: 2513
	public static int timeHS;

	// Token: 0x040009D2 RID: 2514
	public static int curTimeHS;

	// Token: 0x040009D3 RID: 2515
	public static bool isCountTime;

	// Token: 0x040009D4 RID: 2516
	private sbyte[] totalHouse = new sbyte[4];

	// Token: 0x040009D5 RID: 2517
	private short[] totalPlayer = new short[4];

	// Token: 0x040009D6 RID: 2518
	private short totalPoint;

	// Token: 0x040009D7 RID: 2519
	private sbyte[] typePK = new sbyte[]
	{
		1,
		4,
		5,
		2,
		0
	};

	// Token: 0x040009D8 RID: 2520
	public static FrameImage imgArenaIcon;

	// Token: 0x040009D9 RID: 2521
	private sbyte[] typePaint = new sbyte[]
	{
		3,
		2,
		0,
		1,
		4
	};

	// Token: 0x040009DA RID: 2522
	public bool isShipMove;

	// Token: 0x040009DB RID: 2523
	public EffectAuto eff;

	// Token: 0x040009DC RID: 2524
	private int xPos_minimap;

	// Token: 0x040009DD RID: 2525
	private int yPos_minimap;

	// Token: 0x040009DE RID: 2526
	public static sbyte paint18plush = 0;

	// Token: 0x040009DF RID: 2527
	public static int idicon = -1;

	// Token: 0x040009E0 RID: 2528
	public static string nameclan;
}
