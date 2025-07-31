using System;

// Token: 0x02000087 RID: 135
public class MapScr : MainScreen
{
	// Token: 0x0600066E RID: 1646 RVA: 0x000600EC File Offset: 0x0005E2EC
	public MapScr()
	{
		this.center = new iCommand(T.close, 0, this);
	}

	// Token: 0x06000670 RID: 1648 RVA: 0x000601E0 File Offset: 0x0005E3E0
	protected void resetCMLim()
	{
		int num = GameCanvas.loadmap.idMap;
		if (num > MapScr.x.Length)
		{
			num = MapScr.x.Length - 1;
		}
		int num2 = 0;
		int num3 = 0;
		if (!mSystem.isWinphone)
		{
			num2 = mImage.getImageWidth(MiniMap.imgMiniMap.image);
			num3 = mImage.getImageHeight(MiniMap.imgMiniMap.image);
		}
		this.xM = (GameCanvas.w - num2) / 2;
		this.yM = (GameCanvas.h - 20 - num3) / 2;
		if (this.xM < 0)
		{
			this.xM = 0;
		}
		if (this.yM < 0)
		{
			this.yM = 0;
		}
		if (this.modeCurrentMap)
		{
			MapScr.mcmxLim = num2 + 20 - GameCanvas.w;
			MapScr.mcmyLim = mImage.getImageHeight(MiniMap.imgMiniMap.image) + 40 - GameCanvas.h;
			this.maxPX = num2 + 20;
			this.maxPY = num2 + 40;
			if (this.maxPY < GameCanvas.h - 26)
			{
				this.maxPY = GameCanvas.h - 26;
			}
			if (this.maxPX < GameCanvas.w)
			{
				this.maxPX = GameCanvas.w;
			}
			MapScr.mfx = this.xM + GameScreen.player.x / 12;
			MapScr.mfy = this.yM + GameScreen.player.y / 12;
		}
		else
		{
			MapScr.mcmxLim = 340 - GameCanvas.w;
			MapScr.mcmyLim = 340 - GameCanvas.h;
			MapScr.mfx = MapScr.x[num] + MapScr.dx;
			MapScr.mfy = MapScr.y[num] + MapScr.dy;
			this.maxPX = 330 + MapScr.dx;
			this.maxPY = 310 + MapScr.dy;
		}
		this.maxPX -= 10;
		this.maxPY -= 10;
		if (MapScr.mcmxLim < 0)
		{
			MapScr.mcmxLim = 0;
		}
		if (MapScr.mcmyLim < 0)
		{
			MapScr.mcmyLim = 0;
		}
		MapScr.mcmx = (MapScr.mcmy = 0);
		MapScr.mcmtoX = (MapScr.mcmtoY = 0);
		MapScr.mcmtoX = MapScr.mfx - GameCanvas.hw;
		MapScr.mcmtoY = MapScr.mfy - GameCanvas.hh;
	}

	// Token: 0x06000671 RID: 1649 RVA: 0x00060420 File Offset: 0x0005E620
	public static MapScr gI()
	{
		if (MapScr.instance == null)
		{
			MapScr.instance = new MapScr();
		}
		return MapScr.instance;
	}

	// Token: 0x06000672 RID: 1650 RVA: 0x0006043C File Offset: 0x0005E63C
	public override void Show()
	{
		base.Show();
		this.center = new iCommand(T.close, 0, this);
		if (MapScr.imgMap == null)
		{
			MapScr.imgMap = mImage.createImage("/wm.png");
			MapScr.mapW = mImage.getImageWidth(MapScr.imgMap.image);
			MapScr.mapH = mImage.getImageWidth(MapScr.imgMap.image);
		}
		if (GameCanvas.w > MapScr.mapW)
		{
			MapScr.dx = GameCanvas.w / 2 - MapScr.mapW / 2;
		}
		if (GameCanvas.h > MapScr.mapH)
		{
			MapScr.dy = GameCanvas.h / 2 - MapScr.mapH / 2;
		}
		this.resetCMLim();
		MapScr.findMapNearestPoint();
		MapScr.mapNames = T.mapName;
	}

	// Token: 0x06000673 RID: 1651 RVA: 0x00060500 File Offset: 0x0005E700
	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.translate(10, 10);
		g.translate(-MapScr.mcmx, -MapScr.mcmy);
		if (GameCanvas.w > MapScr.mapW && GameCanvas.h > MapScr.mapH)
		{
			g.drawImage(MapScr.imgMap, GameCanvas.hw, GameCanvas.hh, MapScr.VCENTER_HCENTER, mGraphics.isFalse);
		}
		else if (GameCanvas.w > MapScr.mapW)
		{
			g.drawImage(MapScr.imgMap, GameCanvas.hw, 0, MapScr.TOP_CENTER, mGraphics.isFalse);
		}
		else if (GameCanvas.h > MapScr.mapH)
		{
			g.drawImage(MapScr.imgMap, 0, GameCanvas.hh, MapScr.VCENTER_LEFT, mGraphics.isFalse);
		}
		else
		{
			g.drawImage(MapScr.imgMap, 0, 0, 0, mGraphics.isFalse);
		}
		if (GameCanvas.loadmap.idMap < MapScr.mapNames.Length && GameCanvas.loadmap.idMap >= 0)
		{
			int align = 0;
			if (MapScr.x[GameCanvas.loadmap.idMap] != 1 || MapScr.y[GameCanvas.loadmap.idMap] != 1)
			{
				align = ((MapScr.x[GameCanvas.loadmap.idMap] >= 100) ? ((MapScr.x[GameCanvas.loadmap.idMap] <= 200) ? 2 : 1) : 0);
				g.drawRegion(AvMain.imgFocusMap, 0, GameCanvas.gameTick % 3 * 10, 10, 10, 0, MapScr.x[GameCanvas.loadmap.idMap] + MapScr.dx, MapScr.y[GameCanvas.loadmap.idMap] + MapScr.dy, 3, mGraphics.isFalse);
			}
			int num = 0;
			if (MapScr.x[GameCanvas.loadmap.idMap] != 1 || MapScr.y[GameCanvas.loadmap.idMap] != 1)
			{
				num = MapScr.y[GameCanvas.loadmap.idMap] - 20;
				mFont.tahoma_7b_black.drawString(g, MapScr.mapNames[GameCanvas.loadmap.idMap], MapScr.x[GameCanvas.loadmap.idMap] + MapScr.dx + 1, MapScr.y[GameCanvas.loadmap.idMap] + MapScr.dy - 20 + 1, align, mGraphics.isFalse);
				mFont.tahoma_7b_yellow.drawString(g, MapScr.mapNames[GameCanvas.loadmap.idMap], MapScr.x[GameCanvas.loadmap.idMap] + MapScr.dx, MapScr.y[GameCanvas.loadmap.idMap] + MapScr.dy - 20, align, mGraphics.isFalse);
			}
			if (MapScr.mpoint >= 0 && ((MapScr.taskmapId < 0 && GameCanvas.loadmap.idMap != MapScr.mpoint) || (MapScr.taskmapId >= 0 && MapScr.mpoint != MapScr.taskmapId)))
			{
				align = ((MapScr.x[MapScr.mpoint] >= 100) ? ((MapScr.x[MapScr.mpoint] <= 200) ? 2 : 1) : 0);
				int num2 = MapScr.x[MapScr.mpoint];
				int num3 = MapScr.y[MapScr.mpoint] - 20;
				if (num3 > num && num3 - num < 30)
				{
					num3 += 40;
				}
				if (num3 < num && num - num3 < 20)
				{
					num3 -= 5;
				}
				mFont.tahoma_7b_black.drawString(g, MapScr.mapNames[MapScr.mpoint], num2 + MapScr.dx + 1, num3 + MapScr.dy + 1, align, mGraphics.isFalse);
				mFont.tahoma_7b_yellow.drawString(g, MapScr.mapNames[MapScr.mpoint], num2 + MapScr.dx, num3 + MapScr.dy, align, mGraphics.isFalse);
			}
		}
		if (!GameCanvas.isTouch)
		{
			g.drawRegion(MainTabNew.imgTab[5], 0, 0, 10, 10, 0, MapScr.mfx - 2, MapScr.mfy, 0, mGraphics.isFalse);
		}
		else if (MapScr.mpoint >= 0)
		{
			int num4 = MapScr.x[MapScr.mpoint] - 9;
			int num5 = MapScr.y[MapScr.mpoint];
			g.drawRegion(MainTabNew.imgTab[5], 0, 0, 10, 10, 0, num4 + MapScr.dx, num5 + MapScr.dy, 0, mGraphics.isFalse);
		}
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		base.paint(g);
	}

	// Token: 0x06000674 RID: 1652 RVA: 0x00060980 File Offset: 0x0005EB80
	public override void updatekey()
	{
		base.updatekey();
		MapScr.tick3++;
		if (MapScr.tick3 > 10000)
		{
			MapScr.tick3 = 0;
		}
		if (MapScr.mcmx != MapScr.mcmtoX || MapScr.mcmy != MapScr.mcmtoY)
		{
			MapScr.mcmvx = MapScr.mcmtoX - MapScr.mcmx << 1;
			MapScr.mcmvy = MapScr.mcmtoY - MapScr.mcmy << 1;
			MapScr.mcmdx += MapScr.mcmvx;
			MapScr.mcmx += MapScr.mcmdx >> 4;
			MapScr.mcmdx &= 15;
			MapScr.mcmdy += MapScr.mcmvy;
			MapScr.mcmy += MapScr.mcmdy >> 4;
			MapScr.mcmdy &= 15;
			if (MapScr.mcmx < 0)
			{
				MapScr.mcmx = 0;
			}
			if (MapScr.mcmx > MapScr.mcmxLim)
			{
				MapScr.mcmx = MapScr.mcmxLim;
			}
			if (MapScr.mcmy < 0)
			{
				MapScr.mcmy = 0;
			}
			if (MapScr.mcmy > MapScr.mcmyLim)
			{
				MapScr.mcmy = MapScr.mcmyLim;
			}
		}
		bool flag = false;
		if (GameCanvas.keyMyHold[2])
		{
			MapScr.mfy -= 4;
			if (MapScr.mfy < MapScr.dy - 10)
			{
				MapScr.mfy = MapScr.dy - 10;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[8])
		{
			MapScr.mfy += 4;
			if (MapScr.mfy > this.maxPY)
			{
				MapScr.mfy = this.maxPY;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[4])
		{
			MapScr.mfx -= 4;
			if (MapScr.mfx < MapScr.dx - 10)
			{
				MapScr.mfx = MapScr.dx - 10;
			}
			flag = true;
		}
		if (GameCanvas.keyMyHold[6])
		{
			MapScr.mfx += 4;
			if (MapScr.mfx > this.maxPX)
			{
				MapScr.mfx = this.maxPX;
			}
			flag = true;
		}
		if (flag)
		{
			MapScr.mcmtoX = MapScr.mfx - GameCanvas.hw;
			MapScr.mcmtoY = MapScr.mfy - GameCanvas.hh;
			MapScr.findMapNearestPoint();
		}
		if (GameCanvas.isPointerClick && GameCanvas.py < GameCanvas.h - MapScr.cmdH)
		{
			GameCanvas.isPointerClick = false;
			this.trans = true;
			this.lastX = GameCanvas.px;
			this.lastY = GameCanvas.py;
		}
		else if (GameCanvas.isPointerDown && this.trans)
		{
			MapScr.mcmtoX -= GameCanvas.px - this.lastX;
			MapScr.mcmtoY -= GameCanvas.py - this.lastY;
			if (MapScr.mcmtoX < 0)
			{
				MapScr.mcmtoX = 0;
			}
			if (MapScr.mcmtoY < 0)
			{
				MapScr.mcmtoY = 0;
			}
			if (MapScr.mcmtoX > MapScr.mcmxLim)
			{
				MapScr.mcmtoX = MapScr.mcmxLim;
			}
			if (MapScr.mcmtoY > MapScr.mcmyLim)
			{
				MapScr.mcmtoY = MapScr.mcmyLim;
			}
			MapScr.mcmx = MapScr.mcmtoX;
			MapScr.mcmy = MapScr.mcmtoY;
			this.lastX = GameCanvas.px;
			this.lastY = GameCanvas.py;
		}
		if (GameCanvas.isPointerRelease)
		{
			int num = GameCanvas.pxLast - GameCanvas.px;
			int num2 = GameCanvas.pyLast - GameCanvas.py;
			if (num < 10 && num2 < 10)
			{
				MapScr.mfx = MapScr.mcmx + GameCanvas.pxLast - 8;
				MapScr.mfy = MapScr.mcmy + GameCanvas.pyLast - 8;
				MapScr.findMapNearestPoint();
			}
			this.trans = false;
			GameCanvas.isPointerRelease = false;
		}
		if (GameCanvas.isTouch && GameCanvas.w >= 320)
		{
			this.center.xCmd = GameCanvas.w / 2 - 35;
		}
	}

	// Token: 0x06000675 RID: 1653 RVA: 0x00060D50 File Offset: 0x0005EF50
	private static void findMapNearestPoint()
	{
		MapScr.mpoint = -1;
		int num = 10;
		if (!GameCanvas.isTouch)
		{
			num = 13;
		}
		for (int i = 0; i < MapScr.x.Length; i++)
		{
			if (CRes.abs(MapScr.mfx - (MapScr.x[i] + MapScr.dx)) < num && CRes.abs(MapScr.mfy - (MapScr.y[i] + MapScr.dy)) < num)
			{
				MapScr.mpoint = i;
				break;
			}
		}
	}

	// Token: 0x06000676 RID: 1654 RVA: 0x00060DD4 File Offset: 0x0005EFD4
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				this.modeCurrentMap = !this.modeCurrentMap;
				this.resetCMLim();
			}
		}
		else
		{
			MapScr.imgMap = null;
			GameScreen.gI().Show();
		}
	}

	// Token: 0x04000940 RID: 2368
	private static MapScr instance;

	// Token: 0x04000941 RID: 2369
	private bool modeCurrentMap;

	// Token: 0x04000942 RID: 2370
	public static mImage imgMap = null;

	// Token: 0x04000943 RID: 2371
	public static int mapW;

	// Token: 0x04000944 RID: 2372
	public static int mapH;

	// Token: 0x04000945 RID: 2373
	public static int mfx;

	// Token: 0x04000946 RID: 2374
	public static int mfy;

	// Token: 0x04000947 RID: 2375
	public static int mpoint;

	// Token: 0x04000948 RID: 2376
	public static int tick3;

	// Token: 0x04000949 RID: 2377
	public static int mcmtoX;

	// Token: 0x0400094A RID: 2378
	public static int mcmtoY;

	// Token: 0x0400094B RID: 2379
	public static int mcmvx;

	// Token: 0x0400094C RID: 2380
	public static int mcmvy;

	// Token: 0x0400094D RID: 2381
	public static int mcmdx;

	// Token: 0x0400094E RID: 2382
	public static int mcmdy;

	// Token: 0x0400094F RID: 2383
	public static int mcmx;

	// Token: 0x04000950 RID: 2384
	public static int mcmy;

	// Token: 0x04000951 RID: 2385
	public static int mcmxLim;

	// Token: 0x04000952 RID: 2386
	public static int mcmyLim;

	// Token: 0x04000953 RID: 2387
	public static int taskmapId;

	// Token: 0x04000954 RID: 2388
	private static int dx = 0;

	// Token: 0x04000955 RID: 2389
	private static int dy = 0;

	// Token: 0x04000956 RID: 2390
	public static int cmdH = 22;

	// Token: 0x04000957 RID: 2391
	public static int TOP_CENTER = mGraphics.TOP | mGraphics.HCENTER;

	// Token: 0x04000958 RID: 2392
	public static int TOP_LEFT = mGraphics.TOP | mGraphics.LEFT;

	// Token: 0x04000959 RID: 2393
	public static int TOP_RIGHT = mGraphics.TOP | mGraphics.RIGHT;

	// Token: 0x0400095A RID: 2394
	public static int BOTTOM_HCENTER = mGraphics.BOTTOM | mGraphics.HCENTER;

	// Token: 0x0400095B RID: 2395
	public static int BOTTOM_LEFT = mGraphics.BOTTOM | mGraphics.LEFT;

	// Token: 0x0400095C RID: 2396
	public static int BOTTOM_RIGHT = mGraphics.BOTTOM | mGraphics.RIGHT;

	// Token: 0x0400095D RID: 2397
	public static int VCENTER_HCENTER = mGraphics.VCENTER | mGraphics.HCENTER;

	// Token: 0x0400095E RID: 2398
	public static int VCENTER_LEFT = mGraphics.VCENTER | mGraphics.LEFT;

	// Token: 0x0400095F RID: 2399
	public static int[] x = new int[]
	{
		108,
		111,
		131,
		93,
		76,
		58,
		39,
		102,
		83,
		66,
		49,
		121,
		135,
		154,
		160,
		100,
		94,
		80,
		128,
		73,
		100,
		88,
		53,
		83,
		73,
		127,
		109,
		89,
		72,
		171,
		172,
		185,
		202,
		134,
		117,
		157,
		135,
		99,
		102,
		122,
		139,
		156,
		47,
		44,
		28,
		23,
		0,
		47,
		87,
		0,
		133,
		159,
		23,
		207,
		207,
		239,
		226,
		207,
		207,
		168,
		182,
		217,
		23,
		71,
		24,
		88,
		25,
		66,
		99,
		40,
		47,
		28,
		64,
		47,
		47,
		67,
		83,
		98,
		111,
		128,
		0,
		0,
		117,
		219,
		191,
		219,
		241,
		218,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x04000960 RID: 2400
	public static int[] y = new int[]
	{
		247,
		233,
		220,
		235,
		236,
		238,
		237,
		216,
		212,
		216,
		205,
		210,
		204,
		203,
		182,
		196,
		180,
		172,
		183,
		117,
		144,
		130,
		134,
		146,
		134,
		162,
		160,
		160,
		160,
		141,
		125,
		114,
		116,
		145,
		144,
		147,
		128,
		118,
		98,
		96,
		88,
		75,
		149,
		165,
		165,
		181,
		0,
		118,
		224,
		0,
		235,
		59,
		200,
		201,
		187,
		162,
		167,
		129,
		143,
		171,
		171,
		166,
		217,
		57,
		62,
		60,
		83,
		92,
		72,
		92,
		69,
		43,
		42,
		35,
		18,
		14,
		8,
		14,
		28,
		27,
		0,
		0,
		132,
		116,
		96,
		71,
		94,
		94,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x04000961 RID: 2401
	public static string[] mapNames;

	// Token: 0x04000962 RID: 2402
	private int maxPX;

	// Token: 0x04000963 RID: 2403
	private int maxPY;

	// Token: 0x04000964 RID: 2404
	private int xM;

	// Token: 0x04000965 RID: 2405
	private int yM;

	// Token: 0x04000966 RID: 2406
	private bool trans;

	// Token: 0x04000967 RID: 2407
	private int lastX;

	// Token: 0x04000968 RID: 2408
	private int lastY;
}
