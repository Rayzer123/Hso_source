using System;
using UnityEngine;

// Token: 0x020000B2 RID: 178
public class MapBackGround
{
	// Token: 0x060008CD RID: 2253 RVA: 0x00092CE0 File Offset: 0x00090EE0
	public void setBackGround(sbyte type, short h)
	{
		Debug.LogWarning("load back ground " + type);
		this.typeMap = type;
		this.hBack = (int)h;
		if (GameCanvas.lowGraphic)
		{
			this.color = 6992343;
			this.colorMini = "0x6ab1d7";
			return;
		}
		switch (this.typeMap)
		{
		case 1:
			this.w1 = 256;
			this.size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / this.w1 + 1;
			this.color = 8051685;
			this.colorMini = 8051685 + string.Empty;
			this.h1 = 92;
			this.h2 = 85;
			this.h3 = 110;
			this.hLimit = this.hBack - (this.h1 + this.h2 + this.h3);
			this.sizeScreen = GameCanvas.w / this.w1 + 1;
			this.mImg = new mImage[3];
			this.mImg[0] = mImage.createImage("/bg/bg1_0.img");
			this.mImg[1] = mImage.createImage("/bg/bg1_1.img");
			this.mImg[2] = mImage.createImage("/bg/bg1_2.img");
			this.valueRandom = (this.hLimit + 30) / 2;
			break;
		case 2:
			this.w1 = 120;
			this.size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / this.w1 + 1;
			this.color = 5940735;
			this.colorMini = "0x4c8f98";
			this.h1 = 72;
			this.h2 = 28;
			this.h3 = 77;
			this.hLimit = this.hBack - (this.h1 + this.h2 + this.h3);
			this.sizeScreen = GameCanvas.w / this.w1 + 1;
			this.mImg = new mImage[5];
			this.mImg[0] = mImage.createImage("/bg/bg2_0.img");
			this.mImg[1] = mImage.createImage("/bg/bg2_1.img");
			this.mImg[2] = mImage.createImage("/bg/bg2_20.img");
			this.mImg[3] = mImage.createImage("/bg/bg2_21.img");
			this.mImg[4] = mImage.createImage("/bg/bg2_22.img");
			this.mList3 = new sbyte[this.size1];
			for (int i = 0; i < this.size1; i++)
			{
				this.mList3[i] = (sbyte)CRes.random(3);
			}
			this.valueRandom = 25;
			break;
		case 3:
			this.w1 = 253;
			this.w2 = 96;
			this.size1 = GameCanvas.loadmap.mapW * LoadMap.wTile / this.w1 + 1;
			this.size2 = GameCanvas.loadmap.mapW * LoadMap.wTile / this.w2 + 1;
			this.color = 6992343;
			this.colorMini = "0x6ab1d7";
			this.h1 = 108;
			this.h2 = 72;
			this.nX = (this.hBack - 120) / this.h2;
			if (this.nX > 5)
			{
				this.nX = 5;
			}
			this.hLimit = this.hBack - (this.h1 + this.h2 * this.nX);
			this.sizeScreen = GameCanvas.w / this.w1 + 1;
			this.sizeScreen2 = GameCanvas.w / this.w2 + 1;
			this.mImg = new mImage[2];
			this.mImg[0] = mImage.createImage("/bg/bg3_0.img");
			this.mImg[1] = mImage.createImage("/bg/bg3_1.img");
			this.valueRandom = (this.hLimit + 30) / 2;
			break;
		}
		this.PosCloud = new Point[GameCanvas.loadmap.mapW * LoadMap.wTile / 250 + 1];
		for (int j = 0; j < this.PosCloud.Length; j++)
		{
			this.PosCloud[j] = new Point();
			this.PosCloud[j].x = 125 + CRes.random_Am_0(125) + j * 250;
			this.PosCloud[j].y = this.valueRandom + CRes.random_Am_0(this.valueRandom);
			this.PosCloud[j].vx = -CRes.random(1, 3);
			this.PosCloud[j].frame = CRes.random(0, 2);
		}
		this.mImgCloud = new mImage[2];
		this.mImgCloud[0] = mImage.createImage("/bg/may0.img");
		this.mImgCloud[1] = mImage.createImage("/bg/may1.img");
	}

	// Token: 0x060008CE RID: 2254 RVA: 0x00093188 File Offset: 0x00091388
	public void paint(mGraphics g)
	{
		if (GameCanvas.lowGraphic)
		{
			if (MainScreen.cameraMain.yCam <= this.hBack)
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
			}
			return;
		}
		switch (this.typeMap)
		{
		case 1:
		{
			int num = MainScreen.cameraMain.xCam / this.w1;
			int num2 = num + this.sizeScreen + 1;
			if (num2 > this.size1)
			{
				num2 = this.size1;
			}
			if (MainScreen.cameraMain.yCam <= this.hLimit)
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, this.hLimit, mGraphics.isFalse);
			}
			for (int i = num; i < num2; i++)
			{
				if (MainScreen.cameraMain.yCam <= this.h1 + this.hLimit)
				{
					g.drawImage(this.mImg[0], i * this.w1, this.hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= this.h2 + this.h1 + this.hLimit)
				{
					g.drawImage(this.mImg[1], i * this.w1, this.h1 + this.hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= this.h2 + this.h1 + this.h3 + this.hLimit)
				{
					g.drawImage(this.mImg[2], i * this.w1, this.h1 + this.h2 + this.hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		case 2:
		{
			int num = MainScreen.cameraMain.xCam / this.w1;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num + this.sizeScreen + 1;
			if (num2 > this.size1)
			{
				num2 = this.size1;
			}
			if (MainScreen.cameraMain.yCam <= this.hLimit)
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, this.hLimit, mGraphics.isFalse);
			}
			for (int j = num; j < num2; j++)
			{
				if (MainScreen.cameraMain.yCam <= this.h1 + this.hLimit)
				{
					g.drawImage(this.mImg[0], j * this.w1, this.hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= this.h2 + this.h1 + this.hLimit)
				{
					g.drawImage(this.mImg[1], j * this.w1, this.h1 + this.hLimit, 0, mGraphics.isFalse);
				}
				if (MainScreen.cameraMain.yCam <= this.h2 + this.h1 + this.h3 + this.hLimit)
				{
					g.drawImage(this.mImg[2 + (int)this.mList3[j]], j * this.w1, this.h1 + this.h2 + this.hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		case 3:
		{
			if (MainScreen.cameraMain.yCam <= this.hLimit)
			{
				g.setColor(this.color);
				g.fillRect(MainScreen.cameraMain.xCam, MainScreen.cameraMain.yCam, GameCanvas.w, this.hLimit, mGraphics.isFalse);
			}
			int num3 = MainScreen.cameraMain.xCam / this.w2;
			if (num3 < 0)
			{
				num3 = 0;
			}
			int num4 = num3 + this.sizeScreen2 + 1;
			if (num4 > this.size2)
			{
				num4 = this.size2;
			}
			for (int k = num3; k < num4; k++)
			{
				for (int l = 0; l < this.nX; l++)
				{
					g.drawImage(this.mImg[1], k * this.w2, this.hLimit + this.h1 + l * this.h2, 0, mGraphics.isFalse);
				}
			}
			int num = MainScreen.cameraMain.xCam / this.w1;
			if (num < 0)
			{
				num = 0;
			}
			int num2 = num + this.sizeScreen + 1;
			if (num2 > this.size1)
			{
				num2 = this.size1;
			}
			for (int m = num; m < num2; m++)
			{
				if (MainScreen.cameraMain.yCam <= this.h1 + this.hLimit)
				{
					g.drawImage(this.mImg[0], m * this.w1, this.hLimit, 0, mGraphics.isFalse);
				}
			}
			break;
		}
		}
		for (int n = 0; n < this.PosCloud.Length; n++)
		{
			if (MainScreen.cameraMain.yCam - 10 <= this.PosCloud[n].y)
			{
				g.drawImage(this.mImgCloud[this.PosCloud[n].frame], this.PosCloud[n].x, this.PosCloud[n].y, mGraphics.VCENTER | mGraphics.LEFT, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x060008CF RID: 2255 RVA: 0x00093724 File Offset: 0x00091924
	public void updateCloud()
	{
		if (GameCanvas.lowGraphic)
		{
			return;
		}
		for (int i = 0; i < this.PosCloud.Length; i++)
		{
			this.PosCloud[i].x += this.PosCloud[i].vx;
			if (this.PosCloud[i].x < -80)
			{
				this.PosCloud[i].x = GameCanvas.loadmap.mapW * LoadMap.wTile + CRes.random_Am_0(125);
				this.PosCloud[i].y = this.valueRandom + CRes.random_Am_0(this.valueRandom);
				this.PosCloud[i].vx = -CRes.random(1, 3);
				this.PosCloud[i].frame = CRes.random(0, 2);
			}
		}
	}

	// Token: 0x04000DB2 RID: 3506
	private sbyte typeMap;

	// Token: 0x04000DB3 RID: 3507
	private sbyte[] mList3;

	// Token: 0x04000DB4 RID: 3508
	private int w1;

	// Token: 0x04000DB5 RID: 3509
	private int w2;

	// Token: 0x04000DB6 RID: 3510
	private int w3;

	// Token: 0x04000DB7 RID: 3511
	private int size1;

	// Token: 0x04000DB8 RID: 3512
	private int size2;

	// Token: 0x04000DB9 RID: 3513
	private int size3;

	// Token: 0x04000DBA RID: 3514
	private int h1;

	// Token: 0x04000DBB RID: 3515
	private int h2;

	// Token: 0x04000DBC RID: 3516
	private int h3;

	// Token: 0x04000DBD RID: 3517
	private int sizeScreen;

	// Token: 0x04000DBE RID: 3518
	private int hBack;

	// Token: 0x04000DBF RID: 3519
	private int hLimit;

	// Token: 0x04000DC0 RID: 3520
	private int valueRandom;

	// Token: 0x04000DC1 RID: 3521
	private int sizeScreen2;

	// Token: 0x04000DC2 RID: 3522
	private int nX;

	// Token: 0x04000DC3 RID: 3523
	private Point[] PosCloud;

	// Token: 0x04000DC4 RID: 3524
	private mImage[] mImg;

	// Token: 0x04000DC5 RID: 3525
	private mImage[] mImgCloud;

	// Token: 0x04000DC6 RID: 3526
	public int color;

	// Token: 0x04000DC7 RID: 3527
	public string colorMini;
}
