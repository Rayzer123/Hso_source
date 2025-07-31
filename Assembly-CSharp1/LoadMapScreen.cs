using System;

// Token: 0x02000083 RID: 131
public class LoadMapScreen : MainScreen
{
	// Token: 0x0600063E RID: 1598 RVA: 0x0005D7B4 File Offset: 0x0005B9B4
	public override void Show()
	{
		base.Show();
		this.time = GameCanvas.timeNow;
		GameCanvas.saveImage.start();
		PaintInfoGameScreen.timeChange = 0;
	}

	// Token: 0x0600063F RID: 1599 RVA: 0x0005D7D8 File Offset: 0x0005B9D8
	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		if (LoginScreen.logo != null)
		{
			g.drawImage(LoginScreen.logo, GameCanvas.hw, GameCanvas.hh - 16, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 9, 3, mGraphics.isFalse);
			if (this.timeWait > 0L)
			{
				mFont.tahoma_7_white.drawString(g, this.timeWait + string.Empty, GameCanvas.hw, GameCanvas.hh + mImage.getImageHeight(LoginScreen.logo.image) / 2 - 15, 3, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x06000640 RID: 1600 RVA: 0x0005D8C8 File Offset: 0x0005BAC8
	public override void update()
	{
		if ((GameCanvas.timeNow - this.time) / 1000L > 180L && GameCanvas.currentDialog != null)
		{
			GameCanvas.start_Center_Dialog_Only(T.disconnect, new iCommand(T.exit, 0));
			if (GameScreen.player != null)
			{
				GameScreen.player.resetAction();
			}
		}
		else if (GameCanvas.currentDialog == null)
		{
		}
		if (LoadMapScreen.isNextMap && this.isLoadSkill && MainRMS.isLoadBegin && (!Main.isWindowsPhone || MiniMap.isLoadMiniMapOk) && (SaveImageRMS.vecSaveImage.size() <= 5 || (GameCanvas.timeNow - this.time) / 1000L > 45L))
		{
			if (GameScreen.help.setStep_Next(0, -5))
			{
				GameCanvas.story = new StoryScreen();
				GameCanvas.story.setContent();
				GameCanvas.story.Show();
			}
			else
			{
				GameScreen.player.resetMove();
				GameScreen.player.posTransRoad = null;
				GameScreen.player.resetAction();
				GameCanvas.game.Show();
				GameCanvas.game.checkRemoveImage();
				if (MainRMS.showAuto.Length > 0 && MainRMS.isLoadShowAuto)
				{
					MainRMS.isLoadShowAuto = false;
					GameCanvas.start_Show_Dialog(T.autoFire + "\n" + MainRMS.showAuto, T.auto);
				}
				GameCanvas.hLoad = GameCanvas.h / 4 * 3;
				PaintInfoGameScreen.setNameMap();
				if (this.isTele)
				{
					GameScreen.addEffectKill(58, GameScreen.player.ID, GameScreen.player.typeObject, GameScreen.player.ID, GameScreen.player.typeObject, 0, GameScreen.player.hp);
					GameScreen.player.isTanHinh = true;
				}
				if (GameCanvas.loadmap.idMap == 0 && GameScreen.help.setStep_Next(5, 8) && (GameCanvas.isVN_Eng || IndoServer.isIndoSv))
				{
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			if (this.isLoadHelp)
			{
				GameScreen.help.setNext();
				this.isLoadHelp = false;
			}
			SelectCharScreen.isSelectOk = true;
			GlobalService.gI().Ok_Change_Map();
			GlobalService.gI().send_cmd_server(59);
			EffectMonster.listEffectMonster.removeAllElements();
			this.PlayMusicLang();
		}
		bool flag = false;
		if (GameCanvas.timenextLogin - mSystem.currentTimeMillis() > 0L)
		{
			this.timeWait = (GameCanvas.timenextLogin - mSystem.currentTimeMillis()) / 1000L;
		}
		if (GameCanvas.timenextLogin - mSystem.currentTimeMillis() <= 0L && GameCanvas.timenextLogin > 0L)
		{
			flag = true;
		}
		if (flag)
		{
			this.timeWait = 0L;
			GameCanvas.timenextLogin = 0L;
			GameCanvas.login.checkLoginAgain(GameCanvas.IndexServer);
			SelectCharScreen.reSelect = true;
			SelectCharScreen.Canselect = true;
		}
		if (GameCanvas.countLogin > 0L && (mSystem.currentTimeMillis() - GameCanvas.countLogin) / 1000L > 15L)
		{
			GameCanvas.countLogin = 0L;
			GameCanvas.start_Wait_Dialog(T.Logifail, new iCommand(T.close, 16));
		}
	}

	// Token: 0x06000641 RID: 1601 RVA: 0x0005DBF4 File Offset: 0x0005BDF4
	private void PlayMusicLang()
	{
		mSound.stopSoundAll();
		if (GameCanvas.loadmap.idMap >= LoadMapScreen.mMusic.Length - 1 || LoadMapScreen.mMusic[GameCanvas.loadmap.idMap] < 0)
		{
			mSound.playMus(0, mSound.volumeMusic, true);
		}
		else
		{
			mSound.playMus((int)LoadMapScreen.mMusic[GameCanvas.loadmap.idMap], mSound.volumeMusic, true);
		}
	}

	// Token: 0x06000642 RID: 1602 RVA: 0x0005DC60 File Offset: 0x0005BE60
	public static void NPCBig(Message msg)
	{
		try
		{
			sbyte b = msg.reader().readByte();
			for (int i = 0; i < (int)b; i++)
			{
				string name = msg.reader().readUTF();
				string namegt = msg.reader().readUTF();
				sbyte b2 = msg.reader().readByte();
				sbyte idimage = msg.reader().readByte();
				short x = msg.reader().readShort();
				short y = msg.reader().readShort();
				sbyte wBlock = msg.reader().readByte();
				sbyte hBlock = msg.reader().readByte();
				sbyte nFrame = msg.reader().readByte();
				GameScreen.addPlayer(new NPC(name, namegt, b2, idimage, x, y, wBlock, hBlock, nFrame)
				{
					IdBigAvatar = (int)msg.reader().readByte() + 500,
					infoObject = msg.reader().readUTF(),
					isPerson = msg.reader().readByte(),
					typeObject = 2
				});
				MiniMap.addNPCMini(new NPCMini((int)b2, (int)x, (int)y));
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x040008FF RID: 2303
	public bool isLoadSkill;

	// Token: 0x04000900 RID: 2304
	public bool isTele;

	// Token: 0x04000901 RID: 2305
	public bool isLoadHelp;

	// Token: 0x04000902 RID: 2306
	public static bool isNextMap = false;

	// Token: 0x04000903 RID: 2307
	private long time;

	// Token: 0x04000904 RID: 2308
	private long timeWait;

	// Token: 0x04000905 RID: 2309
	public sbyte[] mItemMap;

	// Token: 0x04000906 RID: 2310
	public sbyte[] mEffMap;

	// Token: 0x04000907 RID: 2311
	public sbyte[] mNPCMap;

	// Token: 0x04000908 RID: 2312
	public static bool isInLoadMapScreen = false;

	// Token: 0x04000909 RID: 2313
	public static byte[] mMusic = new byte[]
	{
		2,
		0,
		3,
		2,
		3,
		2,
		6,
		2,
		2,
		2,
		6,
		5,
		5,
		5,
		6,
		4,
		4,
		3,
		6,
		8,
		8,
		8,
		8,
		8,
		8,
		4,
		4,
		4,
		6,
		3,
		3,
		3,
		6,
		1,
		1,
		1,
		5,
		5,
		5,
		5,
		5,
		5,
		8,
		8,
		8,
		8,
		5,
		6,
		5,
		5,
		5,
		2,
		5,
		0
	};
}
