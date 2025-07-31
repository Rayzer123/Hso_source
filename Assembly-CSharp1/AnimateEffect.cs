using System;

// Token: 0x02000030 RID: 48
public class AnimateEffect : MainEffect
{
	// Token: 0x06000235 RID: 565 RVA: 0x0000D2C4 File Offset: 0x0000B4C4
	public AnimateEffect(sbyte type, bool isStart, int number, int timeLimit)
	{
		this.timeLimit = timeLimit;
		this.curTime = (int)(GameCanvas.timeNow / 1000L);
		this.type = type;
		int num = 1;
		switch (type)
		{
		case 1:
			num = 3;
			this.imgEffect = mImage.createImage("/efleaf.img");
			break;
		case 2:
			num = 2;
			this.imgEffect = mImage.createImage("/efsnow.img");
			break;
		case 3:
			this.imgEffect = mImage.createImage("/efhoa.img");
			break;
		case 4:
			num = 12;
			break;
		case 5:
			this.isStop = true;
			return;
		}
		if (number > 0)
		{
			this.number = number;
		}
		else if (number == -1)
		{
			this.number = GameCanvas.w * GameCanvas.h / (8 * num * 200);
		}
		else if (number == -2)
		{
			this.number = GameCanvas.w * GameCanvas.h / (6 * num * 200);
		}
		else if (number == -3)
		{
			this.number = GameCanvas.w * GameCanvas.h / (3 * num * 200);
		}
		else if (number == -4)
		{
			this.number = GameCanvas.w * GameCanvas.h / (2 * num * 200);
		}
		else
		{
			this.number = 10;
		}
		if ((int)type != 4)
		{
			for (int i = 0; i < this.number; i++)
			{
				Point point;
				if (isStart)
				{
					point = new Point((MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w * 2)) * 10, (MainScreen.cameraMain.yCam - GameCanvas.h * 2 + CRes.random(GameCanvas.h * 2)) * 10);
				}
				else
				{
					point = new Point();
					this.rndPos(point);
				}
				if ((int)type == 2 || (int)this.type == 3)
				{
					point.h = CRes.random(3);
				}
				else
				{
					point.h = CRes.random(4);
				}
				if ((int)type == 5)
				{
					point.vx = CRes.random(2, 8);
					point.vy = CRes.random(2, 12);
				}
				point.limitY = 16 + CRes.random(3) * 4;
				point.v = CRes.random(-1, 1);
				point.color = CRes.random(point.limitY);
				point.frame = CRes.random(2);
				if ((int)type == 2)
				{
					point.dis = (int)((sbyte)CRes.random(6));
				}
				else if ((int)type == 1)
				{
					point.dis = (int)((sbyte)CRes.random(4));
				}
				else
				{
					point.dis = (int)((sbyte)CRes.random(20));
				}
				this.list.addElement(point);
			}
		}
	}

	// Token: 0x06000237 RID: 567 RVA: 0x0000D5B8 File Offset: 0x0000B7B8
	public void close()
	{
	}

	// Token: 0x06000238 RID: 568 RVA: 0x0000D5BC File Offset: 0x0000B7BC
	public void stop()
	{
		this.isStop = true;
	}

	// Token: 0x06000239 RID: 569 RVA: 0x0000D5C8 File Offset: 0x0000B7C8
	public new void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		g.translate(-MainScreen.cameraMain.xCam, -MainScreen.cameraMain.yCam);
		switch (this.type)
		{
		case 0:
			this.paintRain(g);
			break;
		case 1:
			this.paintFallingLeaves(g);
			break;
		case 2:
			this.paintSnow(g);
			break;
		case 3:
			this.paintFallingFlower(g);
			break;
		case 5:
			this.paintCloud(g);
			break;
		}
	}

	// Token: 0x0600023A RID: 570 RVA: 0x0000D660 File Offset: 0x0000B860
	private void paintCloud(mGraphics g)
	{
		if (this.imgEffectCloud != null)
		{
			for (int i = 0; i < this.list.size(); i++)
			{
				Point point = (Point)this.list.elementAt(i);
				if (point.x / 10 > MainScreen.cameraMain.xCam - this.wimg / 2 && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w + this.wimg / 2 && point.y / 10 > MainScreen.cameraMain.yCam - this.himg / 2)
				{
					g.drawImage(this.imgEffectCloud[point.frame], point.x / 10, point.y / 10, 3, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x0600023B RID: 571 RVA: 0x0000D73C File Offset: 0x0000B93C
	private void paintSnow(mGraphics g)
	{
		if (this.imgEffect != null)
		{
			for (int i = 0; i < this.number; i++)
			{
				Point point = (Point)this.list.elementAt(i);
				if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
				{
					g.drawRegion(this.imgEffect, 0, 7 * point.dis, 7, 7, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x0600023C RID: 572 RVA: 0x0000D7FC File Offset: 0x0000B9FC
	private void paintFallingFlower(mGraphics g)
	{
		if (this.imgEffect != null)
		{
			for (int i = 0; i < this.number; i++)
			{
				Point point = (Point)this.list.elementAt(i);
				if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
				{
					int num = 2 - point.h + 1;
					if (num < 2)
					{
						num = point.dis / 10;
					}
					g.drawRegion(this.imgEffect, 0, num * 10, 10, 10, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
					point.dis++;
					if (point.dis >= 20)
					{
						point.dis = 0;
					}
				}
			}
		}
	}

	// Token: 0x0600023D RID: 573 RVA: 0x0000D8FC File Offset: 0x0000BAFC
	private void paintFallingLeaves(mGraphics g)
	{
		if (this.imgEffect != null)
		{
			for (int i = 0; i < this.number; i++)
			{
				Point point = (Point)this.list.elementAt(i);
				if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
				{
					if (CRes.random(6) == 0)
					{
						point.dis = (int)((byte)CRes.random(4));
					}
					g.drawRegion(this.imgEffect, 0, point.dis * 10, 16, 10, 0, point.x / 10, point.y / 10, 3, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x0600023E RID: 574 RVA: 0x0000D9D8 File Offset: 0x0000BBD8
	private void paintRain(mGraphics g)
	{
		g.setColor(14540253);
		for (int i = 0; i < this.number; i++)
		{
			Point point = (Point)this.list.elementAt(i);
			if (point.x / 10 > MainScreen.cameraMain.xCam && point.x / 10 < MainScreen.cameraMain.xCam + GameCanvas.w && point.y / 10 > MainScreen.cameraMain.yCam)
			{
				g.fillRect(point.x / 10, point.y / 10, 1, point.h + 2, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x0600023F RID: 575 RVA: 0x0000DA90 File Offset: 0x0000BC90
	public static void updateWind()
	{
		int num = 1;
		if (GameCanvas.gameTick % 6 == 3)
		{
			num = CRes.random(15);
		}
		if (num == 0 && AnimateEffect.wind == 5)
		{
			AnimateEffect.wind = 5 + CRes.random(20);
			AnimateEffect.countWind = 50 + CRes.random(100);
		}
		if (AnimateEffect.countWind > 0)
		{
			AnimateEffect.countWind--;
		}
		if (AnimateEffect.countWind == 0 && AnimateEffect.wind > 5 && GameCanvas.gameTick % 4 == 2)
		{
			AnimateEffect.wind--;
		}
	}

	// Token: 0x06000240 RID: 576 RVA: 0x0000DB28 File Offset: 0x0000BD28
	public new void update()
	{
		if (this.timeLimit > 0 && GameCanvas.timeNow / 1000L - (long)this.curTime > (long)this.timeLimit)
		{
			this.isStop = true;
		}
		switch (this.type)
		{
		case 0:
			this.updateRain();
			break;
		case 1:
			this.updateFallingLeaves();
			break;
		case 2:
			this.updateSnow();
			break;
		case 3:
			this.updateFlower();
			break;
		case 4:
			this.updateThienThach();
			break;
		case 5:
			this.updateCloud();
			break;
		}
	}

	// Token: 0x06000241 RID: 577 RVA: 0x0000DBD4 File Offset: 0x0000BDD4
	private void updateCloud()
	{
		for (int i = 0; i < this.list.size(); i++)
		{
			Point point = (Point)this.list.elementAt(i);
			point.y += point.vy;
			point.x += point.vx * AnimateEffect.dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				this.list.removeElement(point);
				i--;
			}
		}
		if (this.timeLimit > 0 && GameCanvas.timeNow / 1000L - (long)this.curTime > (long)this.timeLimit)
		{
			mSystem.outz("ooooooooooooooooooooooooooooo");
			return;
		}
		if (!this.isStop && CRes.random(350) < this.numClound)
		{
			Point point2 = new Point();
			this.rndPos(point2);
			point2.h = CRes.random(4);
			point2.limitY = 16 + CRes.random(3) * 4;
			point2.v = CRes.random(-1, 1);
			point2.color = CRes.random(point2.limitY);
			point2.frame = CRes.random(2);
			point2.dis = (int)((byte)CRes.random(20));
			point2.vx = CRes.random(2, 8);
			point2.vy = CRes.random(2, 12);
			this.list.addElement(point2);
		}
	}

	// Token: 0x06000242 RID: 578 RVA: 0x0000DDB4 File Offset: 0x0000BFB4
	private void updateThienThach()
	{
		if (CRes.random(250) < this.number)
		{
			int num = CRes.random(1, 3);
			GameScreen.addEffectKill(86, 0, 0, 0, 0, (sbyte)num);
		}
	}

	// Token: 0x06000243 RID: 579 RVA: 0x0000DDEC File Offset: 0x0000BFEC
	private void updateSnow()
	{
		for (int i = 0; i < this.number; i++)
		{
			Point point = (Point)this.list.elementAt(i);
			point.y += (point.h + 4) * 3;
			point.x += (point.h + 1) * 2 + AnimateEffect.wind * AnimateEffect.dirWind;
			if ((point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw) && CRes.random(40) == 0)
			{
				this.rndPos(point);
			}
		}
	}

	// Token: 0x06000244 RID: 580 RVA: 0x0000DF00 File Offset: 0x0000C100
	private void updateFlower()
	{
		for (int i = 0; i < this.number; i++)
		{
			Point point = (Point)this.list.elementAt(i);
			point.y += (point.h + 2) * 5;
			point.x += (point.h + 1) * 2 + AnimateEffect.wind * AnimateEffect.dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				this.rndPos(point);
			}
		}
	}

	// Token: 0x06000245 RID: 581 RVA: 0x0000E008 File Offset: 0x0000C208
	private void updateFallingLeaves()
	{
		for (int i = 0; i < this.number; i++)
		{
			Point point = (Point)this.list.elementAt(i);
			point.y += 15;
			point.x += point.v * 10 + AnimateEffect.wind * AnimateEffect.dirWind;
			point.color++;
			if (point.color >= point.limitY)
			{
				point.color = 0;
			}
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				this.rndPos(point);
			}
		}
	}

	// Token: 0x06000246 RID: 582 RVA: 0x0000E12C File Offset: 0x0000C32C
	private void updateRain()
	{
		for (int i = 0; i < this.number; i++)
		{
			Point point = (Point)this.list.elementAt(i);
			point.y += (point.h + 1) * 15 + (3 - point.h) * 3;
			point.g++;
			point.x += (3 - point.h + 1) * 2 + AnimateEffect.wind * AnimateEffect.dirWind;
			if (point.y / 10 < MainScreen.cameraMain.yCam - GameCanvas.hw || point.y / 10 > MainScreen.cameraMain.yCam + (GameCanvas.h + GameCanvas.hh) - (4 - point.h) * 50 || point.x / 10 < MainScreen.cameraMain.xCam - GameCanvas.hw || point.x / 10 > MainScreen.cameraMain.xCam + GameCanvas.w + GameCanvas.hw)
			{
				this.rndPos(point);
			}
		}
	}

	// Token: 0x06000247 RID: 583 RVA: 0x0000E250 File Offset: 0x0000C450
	private void rndPos(Point pos)
	{
		if (this.isStop)
		{
			this.list.removeElement(pos);
			this.number = this.list.size();
			if (this.list.size() == 0)
			{
				this.close();
			}
		}
		else
		{
			if ((int)this.type == 5)
			{
				pos.y = (MainScreen.cameraMain.yCam - GameCanvas.hh + CRes.random(GameCanvas.h / 2)) * 10;
				if (AnimateEffect.dirWind > 0)
				{
					pos.x = (MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w)) * 10;
				}
				else
				{
					pos.x = (MainScreen.cameraMain.xCam + GameCanvas.hw + CRes.random(GameCanvas.w)) * 10;
				}
				pos.frame = CRes.random(2);
				pos.vx = CRes.random(2, 8);
				pos.vy = CRes.random(2, 12);
			}
			else
			{
				pos.y = (MainScreen.cameraMain.yCam - GameCanvas.hh + CRes.random(GameCanvas.h * 2)) * 10;
				pos.x = (MainScreen.cameraMain.xCam - GameCanvas.hw + CRes.random(GameCanvas.w * 2)) * 10;
			}
			if ((int)this.type == 2 || (int)this.type == 3)
			{
				pos.h = CRes.random(3);
			}
			else if ((int)this.type == 0)
			{
				pos.h = CRes.random(1, 5);
			}
			else
			{
				pos.h = CRes.random(4);
			}
		}
	}

	// Token: 0x040001FE RID: 510
	public const sbyte RAIN = 0;

	// Token: 0x040001FF RID: 511
	public const sbyte FALLING_LEAVES = 1;

	// Token: 0x04000200 RID: 512
	public const sbyte SNOW = 2;

	// Token: 0x04000201 RID: 513
	public const sbyte FALLING_FLOWER = 3;

	// Token: 0x04000202 RID: 514
	public const sbyte THIEN_THACH = 4;

	// Token: 0x04000203 RID: 515
	public const sbyte CLOUD = 5;

	// Token: 0x04000204 RID: 516
	public sbyte type;

	// Token: 0x04000205 RID: 517
	public int number;

	// Token: 0x04000206 RID: 518
	public int timeLimit;

	// Token: 0x04000207 RID: 519
	public int curTime;

	// Token: 0x04000208 RID: 520
	public int numClound;

	// Token: 0x04000209 RID: 521
	public mVector list = new mVector("AnimateEffect list");

	// Token: 0x0400020A RID: 522
	public new bool isStop;

	// Token: 0x0400020B RID: 523
	private static int wind = 5;

	// Token: 0x0400020C RID: 524
	private static int countWind;

	// Token: 0x0400020D RID: 525
	private static int dirWind = CRes.random_Am_0(2);

	// Token: 0x0400020E RID: 526
	public mImage imgEffect;

	// Token: 0x0400020F RID: 527
	public mImage[] imgEffectCloud;

	// Token: 0x04000210 RID: 528
	private int wimg;

	// Token: 0x04000211 RID: 529
	private int himg;

	// Token: 0x04000212 RID: 530
	private new int vx;

	// Token: 0x04000213 RID: 531
	private new int vy;
}
