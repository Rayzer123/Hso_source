using System;

// Token: 0x020000AE RID: 174
public class BackGround
{
	// Token: 0x060008B1 RID: 2225 RVA: 0x00092200 File Offset: 0x00090400
	public static void init()
	{
		BackGround.LoadBackGround();
		BackGround.skyWidth = mImage.getImageWidth(BackGround.mImgSky.image);
		BackGround.skyHeight = mImage.getImageHeight(BackGround.mImgSky.image);
		BackGround.numSkyDraw = GameCanvas.w / BackGround.skyWidth;
		BackGround.seaWidth = mImage.getImageWidth(BackGround.mImgSea.image);
		BackGround.seaHeight = mImage.getImageHeight(BackGround.mImgSea.image);
		BackGround.numSeaDrawW = GameCanvas.w / BackGround.seaWidth;
		BackGround.numSeaDrawH = (GameCanvas.h - (BackGround.fillSkyH + BackGround.skyHeight)) / BackGround.seaHeight;
		BackGround.cloudWidth = mImage.getImageWidth(BackGround.mImgCloud[0].image);
		BackGround.cloudHeight = mImage.getImageHeight(BackGround.mImgCloud[0].image);
		BackGround.numCloudDraw = GameCanvas.w / BackGround.cloudWidth;
		for (int i = 0; i < BackGround.cloudPos.Length; i++)
		{
			BackGround.cloudPos[i] = new mVector2();
			BackGround.cloudPos[i].x = (float)CRes.random(0, GameCanvas.w);
			BackGround.cloudPos[i].y = (float)(CRes.random(6) * 10);
			BackGround.cloudType[i] = CRes.random(1, 3);
			BackGround.cloudVelo[i] = CRes.random(0, 2);
		}
		for (int j = 0; j < BackGround.intingPos.Length; j++)
		{
			BackGround.intingPos[j] = new mVector2();
			BackGround.intingPos[j].x = (float)(GameCanvas.hw - 80 + j * 80);
			BackGround.intingPos[j].y = (float)(GameCanvas.h - 50 - j % 2 * 25);
		}
		BackGround.staticCloudPos = new int[BackGround.numCloudDraw + 2];
		for (int k = 0; k < BackGround.staticCloudPos.Length; k++)
		{
			BackGround.staticCloudPos[k] = k * BackGround.cloudWidth - mImage.getImageWidth(BackGround.mImgCloud[0].image);
		}
	}

	// Token: 0x060008B2 RID: 2226 RVA: 0x000923EC File Offset: 0x000905EC
	public static void paint(mGraphics g)
	{
		g.setColor(16746751);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, true);
		if (BackGround.mImgSky == null || BackGround.mImgSea == null || BackGround.mImgFloating == null)
		{
			BackGround.LoadBackGround();
		}
		else
		{
			BackGround.paint_Sky(g);
			BackGround.paint_Boat(g);
			BackGround.paint_Sea(g);
			BackGround.paint_Cloud(g);
		}
		g.translate(GameCanvas.hw - GameCanvas.loadmap.mapWLogin * LoadMap.wTile / 2, GameCanvas.h - GameCanvas.loadmap.mapHLogin * LoadMap.wTile);
		GameCanvas.resetTrans(g);
	}

	// Token: 0x060008B3 RID: 2227 RVA: 0x00092494 File Offset: 0x00090694
	public static void paintLight(mGraphics g)
	{
	}

	// Token: 0x060008B4 RID: 2228 RVA: 0x00092498 File Offset: 0x00090698
	public static void paint_Boat(mGraphics g)
	{
		g.drawImage(BackGround.mImgBoat, 10, BackGround.fillSkyH + BackGround.skyHeight / 2, 0, mGraphics.isFalse);
	}

	// Token: 0x060008B5 RID: 2229 RVA: 0x000924C8 File Offset: 0x000906C8
	public static void paint_Sky(mGraphics g)
	{
		g.setColor(4941460);
		g.fillRect(0, 0, GameCanvas.w, BackGround.fillSkyH, mGraphics.isFalse);
		for (int i = 0; i < BackGround.numSkyDraw + 1; i++)
		{
			g.drawImage(BackGround.mImgSky, i * BackGround.skyWidth, BackGround.fillSkyH, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008B6 RID: 2230 RVA: 0x0009252C File Offset: 0x0009072C
	public static void paint_Sea(mGraphics g)
	{
		int num = BackGround.fillSkyH + BackGround.skyHeight;
		for (int i = 0; i < BackGround.numSeaDrawW + 1; i++)
		{
			for (int j = 0; j < BackGround.numSeaDrawH + 1; j++)
			{
				g.drawImage(BackGround.mImgSea, i * BackGround.seaWidth, j * BackGround.seaHeight + num, 0, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x060008B7 RID: 2231 RVA: 0x00092598 File Offset: 0x00090798
	public static void paint_Cloud(mGraphics g)
	{
		for (int i = 0; i < 4; i++)
		{
			g.drawImage(BackGround.mImgCloud[BackGround.cloudType[i]], (int)BackGround.cloudPos[i].x, (int)BackGround.cloudPos[i].y, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008B8 RID: 2232 RVA: 0x000925EC File Offset: 0x000907EC
	public static void paint_StaticCloud(mGraphics g)
	{
		int y = GameCanvas.h - BackGround.cloudHeight;
		for (int i = 0; i < BackGround.staticCloudPos.Length; i++)
		{
			g.drawImage(BackGround.mImgCloud[0], BackGround.staticCloudPos[i], y, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008B9 RID: 2233 RVA: 0x00092638 File Offset: 0x00090838
	public static void paint_CloudOnLogo(mGraphics g)
	{
		for (int i = 4; i < BackGround.cloudPos.Length; i++)
		{
			g.drawImage(BackGround.mImgCloud[BackGround.cloudType[i]], (int)BackGround.cloudPos[i].x, (int)BackGround.cloudPos[i].y, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008BA RID: 2234 RVA: 0x00092690 File Offset: 0x00090890
	public static void paint_FloatingPlatform(mGraphics g)
	{
		for (int i = 0; i < BackGround.intingPos.Length; i++)
		{
			g.drawImage(BackGround.mImgFloating, (int)BackGround.intingPos[i].x, (int)BackGround.intingPos[i].y, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
		}
	}

	// Token: 0x060008BB RID: 2235 RVA: 0x000926EC File Offset: 0x000908EC
	public static void updateSky()
	{
		for (int i = 0; i < BackGround.cloudPos.Length; i++)
		{
			BackGround.cloudVelo[i] = 1;
			BackGround.cloudPos[i].x += (float)BackGround.cloudVelo[i];
			if (BackGround.cloudPos[i].x > (float)GameCanvas.w)
			{
				BackGround.cloudPos[i].x = (float)(-(float)mImage.getImageWidth(BackGround.mImgCloud[1].image));
				BackGround.cloudPos[i].y = (float)(CRes.random(6) * 10);
				BackGround.cloudType[i] = CRes.random(1, 3);
				BackGround.cloudVelo[i] = CRes.random(1, 2);
			}
		}
		int num = -1;
		int num2 = -1;
		for (int j = 0; j < BackGround.staticCloudPos.Length; j++)
		{
			BackGround.staticCloudPos[j] += 2;
			if (BackGround.staticCloudPos[j] > GameCanvas.w)
			{
				int num3 = j + 1;
				if (num3 > BackGround.staticCloudPos.Length - 1)
				{
					num3 = 0;
				}
				if (num == -1)
				{
					num = j;
					num2 = num3;
				}
			}
		}
		if (num != -1 && num2 != -1)
		{
			BackGround.staticCloudPos[num] = BackGround.staticCloudPos[num2] - BackGround.cloudWidth;
		}
	}

	// Token: 0x060008BC RID: 2236 RVA: 0x00092824 File Offset: 0x00090A24
	public static void LoadBackGround()
	{
		BackGround.mImgSky = mImage.createImage("/bg/sky.img");
		BackGround.mImgSea = mImage.createImage("/bg/sea.img");
		for (int i = 0; i < BackGround.mImgCloud.Length; i++)
		{
			BackGround.mImgCloud[i] = mImage.createImage("/bg/cloud" + i + ".img");
		}
		BackGround.mImgBoat = mImage.createImage("/bg/boat.img");
		BackGround.mImgFloating = mImage.createImage("/bg/floating.img");
		if (BackGround.mImgSeaAuto == null)
		{
			BackGround.mImgSeaAuto = new FrameImage(mImage.createImage("/bg/seabg.png"), 24, 24);
		}
	}

	// Token: 0x060008BD RID: 2237 RVA: 0x000928C8 File Offset: 0x00090AC8
	public static void LoadImgCloud()
	{
		for (int i = 0; i < BackGround.mImgCloud.Length; i++)
		{
			if (BackGround.mImgCloud[i] == null)
			{
				BackGround.mImgCloud[i] = mImage.createImage("/bg/cloud" + i + ".img");
			}
		}
	}

	// Token: 0x060008BE RID: 2238 RVA: 0x0009291C File Offset: 0x00090B1C
	public static void paint_SeaCloud(mGraphics g)
	{
		for (int i = 0; i < 4; i++)
		{
			g.drawImage(BackGround.mImgCloud[BackGround.cloudType[i]], (int)BackGround.cloudPos[i].x, (int)BackGround.cloudPos[i].y + GameCanvas.h / 2, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x060008BF RID: 2239 RVA: 0x00092978 File Offset: 0x00090B78
	public static void paint_SeaAuto(mGraphics g)
	{
		for (int i = 0; i < GameCanvas.w / 24 + 1; i++)
		{
			for (int j = 0; j < GameCanvas.h / 24 + 1; j++)
			{
				BackGround.mImgSeaAuto.drawFrame((GameCanvas.gameTick % 14 >= 7) ? 0 : 1, i * 24, j * 24, 0, g);
			}
		}
	}

	// Token: 0x04000D7F RID: 3455
	public const int CLOUD_POS_OFFSET_Y = 10;

	// Token: 0x04000D80 RID: 3456
	public static mImage mImgSky = new mImage();

	// Token: 0x04000D81 RID: 3457
	public static mImage mImgSea = new mImage();

	// Token: 0x04000D82 RID: 3458
	public static mImage[] mImgCloud = new mImage[3];

	// Token: 0x04000D83 RID: 3459
	public static mImage mImgBoat = new mImage();

	// Token: 0x04000D84 RID: 3460
	public static mImage mImgFloating = new mImage();

	// Token: 0x04000D85 RID: 3461
	public static FrameImage mImgSeaAuto;

	// Token: 0x04000D86 RID: 3462
	public static mVector2[] cloudPos = new mVector2[7];

	// Token: 0x04000D87 RID: 3463
	public static mVector2[] intingPos = new mVector2[3];

	// Token: 0x04000D88 RID: 3464
	public static int[] cloudType = new int[7];

	// Token: 0x04000D89 RID: 3465
	public static int[] cloudVelo = new int[7];

	// Token: 0x04000D8A RID: 3466
	public static int fillSkyH = 70;

	// Token: 0x04000D8B RID: 3467
	private static int numSkyDraw;

	// Token: 0x04000D8C RID: 3468
	private static int skyWidth;

	// Token: 0x04000D8D RID: 3469
	private static int skyHeight;

	// Token: 0x04000D8E RID: 3470
	private static int numSeaDrawW;

	// Token: 0x04000D8F RID: 3471
	private static int numSeaDrawH;

	// Token: 0x04000D90 RID: 3472
	private static int seaWidth;

	// Token: 0x04000D91 RID: 3473
	private static int seaHeight;

	// Token: 0x04000D92 RID: 3474
	private static int numCloudDraw;

	// Token: 0x04000D93 RID: 3475
	private static int cloudWidth;

	// Token: 0x04000D94 RID: 3476
	private static int cloudHeight;

	// Token: 0x04000D95 RID: 3477
	public static int[] staticCloudPos = new int[3];
}
