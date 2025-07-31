using System;

// Token: 0x02000089 RID: 137
public class SelectCharScreen : MainScreen
{
	// Token: 0x060006AF RID: 1711 RVA: 0x00066C80 File Offset: 0x00064E80
	public SelectCharScreen()
	{
		this.wCenter = (GameCanvas.w - this.wRectChar * 3) / 4;
		this.init();
	}

	// Token: 0x060006B1 RID: 1713 RVA: 0x00066D1C File Offset: 0x00064F1C
	public override void Show()
	{
		mSound.stopSoundAll();
		if (LoginScreen.MusicRandom == 0)
		{
			mSound.playMus(0, mSound.volumeMusic, true);
		}
		else
		{
			mSound.playMus(1, mSound.volumeMusic, true);
		}
		this.timeSelect = 0;
		this.objSelect = null;
		this.isSelect = false;
		this.isSend = false;
		Player.isNewPlayer = false;
		GameScreen.Vecplayers.removeAllElements();
		base.Show();
		SelectCharScreen.isSelectOk = false;
		GameCanvas.saveImage.start();
		GameScreen.infoGame.setNameServer(GameCanvas.listServer[(int)GameCanvas.IndexServer, 0]);
		GameCanvas.countLogin = 0L;
	}

	// Token: 0x060006B2 RID: 1714 RVA: 0x00066DBC File Offset: 0x00064FBC
	public override void commandTab(int index, int sub)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				Main.isExit = true;
				GameCanvas.login.Show();
				Session_ME.gI().close();
				GameScreen.player = new Player(0, 0, "unname", 0, 0);
			}
		}
		else
		{
			this.doSelect();
		}
		base.commandTab(index, sub);
	}

	// Token: 0x060006B3 RID: 1715 RVA: 0x00066E24 File Offset: 0x00065024
	public void init()
	{
		if (!GameCanvas.isTouch)
		{
			this.center = new iCommand(T.select, 0);
		}
		this.cmdExit = new iCommand(T.exit, 1);
		if (GameCanvas.isTouch)
		{
			this.cmdExit.setPos(PaintInfoGameScreen.fraBack.frameWidth / 2, GameCanvas.h - PaintInfoGameScreen.fraBack.frameHeight / 2, PaintInfoGameScreen.fraBack, this.cmdExit.caption);
		}
		this.left = this.cmdExit;
	}

	// Token: 0x060006B4 RID: 1716 RVA: 0x00066EAC File Offset: 0x000650AC
	public void setCaptionCmd()
	{
		this.cmdExit.caption = T.exit;
	}

	// Token: 0x060006B5 RID: 1717 RVA: 0x00066EC0 File Offset: 0x000650C0
	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		if (LoginScreen.logo != null)
		{
			g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 60, 3, mGraphics.isFalse);
		}
		BackGround.paint_CloudOnLogo(g);
		GameScreen.infoGame.paintNameServer(g, GameCanvas.listServer[(int)GameCanvas.IndexServer, 0]);
		BackGround.paint_FloatingPlatform(g);
		BackGround.paint_StaticCloud(g);
		for (int i = 0; i < 3; i++)
		{
			if (i < SelectCharScreen.VecSelectChar.size())
			{
				Other_Players other_Players = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(i);
				other_Players.paintPlayer(g, -1);
				mFont.tahoma_7b_black.drawString(g, T.level + other_Players.Lv, other_Players.x, other_Players.y - other_Players.hOne - 10, 2, mGraphics.isFalse);
				this.paintName(g, other_Players.name, other_Players.x, other_Players.y - other_Players.hOne, i, other_Players.myClan);
			}
			else
			{
				this.paintName(g, T.createChar, this.mShadow[i][0], this.mShadow[i][1], i, null);
			}
		}
		BackGround.paintLight(g);
		base.paint(g);
		if (SelectCharScreen.reSelect)
		{
			g.setColor(0);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			if (LoginScreen.logo != null)
			{
				g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 16, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
				g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 9, 3, mGraphics.isFalse);
			}
		}
		if ((int)PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if ((int)PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
		if (LoginScreen.isPaintHotLine)
		{
			mFont.tahoma_7_yellow.drawString(g, T.HotLine, GameCanvas.w, 0, 1, mGraphics.isFalse);
			g.setColor(16514362);
			g.fillRect(GameCanvas.w - LoginScreen.wLine + ((!mSystem.isIphone) ? 0 : 14), 10, LoginScreen.wLine, 1, mGraphics.isFalse);
		}
	}

	// Token: 0x060006B6 RID: 1718 RVA: 0x00067130 File Offset: 0x00065330
	public override void update()
	{
		GameScreen.infoGame.updateInfoChar();
		if (LoginScreen.hShowServer < 20)
		{
			LoginScreen.hShowServer += 4;
			if (LoginScreen.hShowServer > 20)
			{
				LoginScreen.hShowServer = 20;
			}
		}
		if (this.timeSelect > 0)
		{
			this.timeSelect++;
			if (this.timeSelect == 18)
			{
				this.objSelect.f = 0;
				this.objSelect.Action = 1;
			}
		}
		if (!GameCanvas.isTouch)
		{
			if (this.selectChar > SelectCharScreen.VecSelectChar.size() - 1)
			{
				this.center.caption = T.create;
			}
			else
			{
				this.center.caption = T.select;
			}
		}
		if (MsgDialog.isAutologin)
		{
			this.autoSelect();
		}
		for (int i = 0; i < SelectCharScreen.VecSelectChar.size(); i++)
		{
			Other_Players other_Players = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(i);
			if (other_Players.Action == 2)
			{
				other_Players.PlashNow.update(other_Players);
			}
			else if (other_Players.Action == 1)
			{
				other_Players.f++;
				if (other_Players.f > other_Players.A_Move.Length - 1)
				{
					other_Players.f = 0;
				}
				other_Players.frame = (int)other_Players.A_Move[other_Players.f];
				if (this.isSelect && !this.isSend)
				{
					Other_Players other_Players2 = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(this.selectChar);
					MainRMS.isLoadShowAuto = true;
					SelectCharScreen.IDCHAR = other_Players2.ID;
					GlobalService.gI().select_char(0, SelectCharScreen.IDCHAR);
					LoadMapScreen.isNextMap = false;
					GameCanvas.load.Show();
					this.isSend = true;
					GameScreen.help.Step = -1;
					GlobalService.gI().Save_RMS_Server(1, 2, null);
					GlobalService.gI().Save_RMS_Server(1, 1, null);
					Main.main.processPurchaseRMS();
					SelectCharScreen.reSelect = false;
					GlobalLogicHandler.timeReconnect = 0L;
					GlobalLogicHandler.isDisConect = false;
					GlobalLogicHandler.isMelogin = false;
					MsgDialog.isAutologin = false;
				}
				other_Players.y += other_Players.vy;
			}
			else
			{
				other_Players.updateActionPerson();
			}
			other_Players.updateEye();
		}
		BackGround.updateSky();
		if (SelectCharScreen.reSelect && SelectCharScreen.Canselect)
		{
			this.doSelect();
			SelectCharScreen.Canselect = false;
		}
	}

	// Token: 0x060006B7 RID: 1719 RVA: 0x00067398 File Offset: 0x00065598
	public override void updatekey()
	{
		if (SelectCharScreen.reSelect)
		{
			return;
		}
		if (!this.isSelect)
		{
			if (GameCanvas.keyMyHold[4])
			{
				this.selectChar--;
				GameCanvas.clearKeyHold();
			}
			else if (GameCanvas.keyMyHold[6])
			{
				this.selectChar++;
				GameCanvas.clearKeyHold();
			}
			this.selectChar = base.resetSelect(this.selectChar, 2, true);
			base.updatekey();
		}
	}

	// Token: 0x060006B8 RID: 1720 RVA: 0x00067418 File Offset: 0x00065618
	public void setPosPaint(mVector vList)
	{
		SelectCharScreen.VecSelectChar.removeAllElements();
		if (vList != null)
		{
			SelectCharScreen.VecSelectChar = vList;
		}
		for (int i = 0; i < 3; i++)
		{
			int num = GameCanvas.hw - 80 + i * 80;
			int num2 = GameCanvas.h - 60 - i % 2 * 25;
			if (i < SelectCharScreen.VecSelectChar.size())
			{
				Other_Players other_Players = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(i);
				int x = GameCanvas.hw - 80 + i * 80;
				int y = GameCanvas.h - 60 - i % 2 * 25;
				other_Players.x = x;
				other_Players.y = y;
			}
			this.mShadow[i][0] = num;
			this.mShadow[i][1] = num2;
		}
	}

	// Token: 0x060006B9 RID: 1721 RVA: 0x000674D4 File Offset: 0x000656D4
	private void paintName(mGraphics g, string name, int xp, int yp, int index, MainClan clan)
	{
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 24, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 24, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp - 1, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp + 1, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp, yp - 25, 2, mGraphics.isFalse);
		mFont.tahoma_7b_black.drawString(g, name, xp, yp - 23, 2, mGraphics.isFalse);
		mFont.tahoma_7b_white.drawString(g, name, xp, yp - 24, 2, mGraphics.isFalse);
		if (clan != null)
		{
			MainImage imageIconClan = ObjectData.getImageIconClan(clan.IdIcon);
			if (imageIconClan.img != null)
			{
				int num = (mFont.tahoma_7b_white.getWidth(clan.shortName) + 11) / 2;
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = this.frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							this.frameClan = (sbyte)(((int)this.frameClan + 1) % num2);
						}
						g.drawRegion(imageIconClan.img, 0, (int)this.frameicon[(int)this.frameClan] * 18, 18, 18, 0, xp - num + 6, yp - 32, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, xp - num + 6, yp - 32, 3, mGraphics.isFalse);
					}
					Item.eff_UpLv.paintUpgradeEffect(xp - num + 6, yp - 32 - 1, clan.getEffChucVu(), 14, g, 0);
				}
				mFont.tahoma_7b_white.drawString(g, clan.shortName, xp - num + 15, yp - 32 - 6, 0, mGraphics.isFalse);
				yp -= 18;
			}
		}
		if (index == this.selectChar && !this.isSelect && !GameCanvas.isTouch)
		{
			g.drawImage(AvMain.imgSelect, xp, yp - 35 + GameCanvas.gameTick % 5, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060006BA RID: 1722 RVA: 0x00067734 File Offset: 0x00065934
	public override void updatePointer()
	{
		if (SelectCharScreen.reSelect)
		{
			return;
		}
		if (GameCanvas.isPointerSelect && !this.isSelect)
		{
			for (int i = 0; i < this.mShadow.Length; i++)
			{
				if (GameCanvas.isPoint(this.mShadow[i][0] - 5, this.mShadow[i][1] - 65, 50, 90))
				{
					this.selectChar = i;
					this.doSelect();
					this.selectChar = base.resetSelect(this.selectChar, 2, true);
					GameCanvas.isPointerSelect = false;
					break;
				}
			}
		}
		base.updatePointer();
	}

	// Token: 0x060006BB RID: 1723 RVA: 0x000677D4 File Offset: 0x000659D4
	public void autoSelect()
	{
		Other_Players other_Players = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(this.selectChar);
		MainRMS.isLoadShowAuto = true;
		SelectCharScreen.IDCHAR = other_Players.ID;
		GlobalService.gI().select_char(0, SelectCharScreen.IDCHAR);
		LoadMapScreen.isNextMap = false;
		GameCanvas.load.Show();
		this.isSend = true;
		mSystem.println("vao ham chon char ne " + SelectCharScreen.IDCHAR);
		GameScreen.help.Step = -1;
		GlobalService.gI().Save_RMS_Server(1, 2, null);
		GlobalService.gI().Save_RMS_Server(1, 1, null);
		SelectCharScreen.reSelect = false;
		MsgDialog.isAutologin = false;
	}

	// Token: 0x060006BC RID: 1724 RVA: 0x0006787C File Offset: 0x00065A7C
	public void doSelect()
	{
		if (this.selectChar > SelectCharScreen.VecSelectChar.size() - 1)
		{
			mSound.playSound(41, mSound.volumeSound);
			GameCanvas.createChar = new CreateChar();
			GameCanvas.createChar.Show((sbyte)this.selectChar);
		}
		else
		{
			this.isSelect = true;
			this.timeSelect = 1;
			this.objSelect = (Other_Players)SelectCharScreen.VecSelectChar.elementAt(this.selectChar);
			this.objSelect.Action = 2;
			this.objSelect.f = 0;
			this.objSelect.beginFire();
			this.objSelect.PlashNow.setPlash(((int)this.objSelect.clazz != 3) ? 1 : 16);
			this.objSelect.Direction = 0;
			if ((int)this.objSelect.clazz == 2 || (int)this.objSelect.clazz == 3)
			{
				mSound.playSound(16, mSound.volumeSound);
			}
			else
			{
				mSound.playSound(6, mSound.volumeSound);
			}
		}
	}

	// Token: 0x060006BD RID: 1725 RVA: 0x00067990 File Offset: 0x00065B90
	public override void keyBack()
	{
		this.cmdExit.perform();
	}

	// Token: 0x040009E1 RID: 2529
	private int wRectChar = 50;

	// Token: 0x040009E2 RID: 2530
	private int hRectChar = 80;

	// Token: 0x040009E3 RID: 2531
	private int selectChar;

	// Token: 0x040009E4 RID: 2532
	private int wCenter;

	// Token: 0x040009E5 RID: 2533
	private int frame;

	// Token: 0x040009E6 RID: 2534
	public static mVector VecSelectChar = new mVector("PaintInfoGameScr VecSelectChar");

	// Token: 0x040009E7 RID: 2535
	private int[][] mShadow = mSystem.new_M_Int(3, 2);

	// Token: 0x040009E8 RID: 2536
	private bool isSelect;

	// Token: 0x040009E9 RID: 2537
	private bool isSend;

	// Token: 0x040009EA RID: 2538
	public static int IDCHAR = -1;

	// Token: 0x040009EB RID: 2539
	public static bool isSelectOk = false;

	// Token: 0x040009EC RID: 2540
	public static bool reSelect = false;

	// Token: 0x040009ED RID: 2541
	public static bool Canselect = false;

	// Token: 0x040009EE RID: 2542
	private int[] mplash = new int[0];

	// Token: 0x040009EF RID: 2543
	public iCommand cmdExit;

	// Token: 0x040009F0 RID: 2544
	private int direction;

	// Token: 0x040009F1 RID: 2545
	public sbyte[] frameicon = new sbyte[]
	{
		0,
		1,
		2,
		1
	};

	// Token: 0x040009F2 RID: 2546
	public sbyte frameClan;

	// Token: 0x040009F3 RID: 2547
	private Other_Players objSelect;

	// Token: 0x040009F4 RID: 2548
	private int timeSelect;
}
