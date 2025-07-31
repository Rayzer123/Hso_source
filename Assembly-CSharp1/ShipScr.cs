using System;

// Token: 0x0200008A RID: 138
public class ShipScr : MainScreen
{
	// Token: 0x060006BF RID: 1727 RVA: 0x000679C0 File Offset: 0x00065BC0
	public static ShipScr gI()
	{
		if (ShipScr.instance == null)
		{
			ShipScr.instance = new ShipScr();
		}
		return ShipScr.instance;
	}

	// Token: 0x060006C0 RID: 1728 RVA: 0x000679DC File Offset: 0x00065BDC
	public void setShipScr(short maxTime)
	{
		this.isSpeed = false;
		this.left = null;
		this.right = null;
		this.cmdFaster = new iCommand(T.speedUp, -1, this);
		this.center = this.cmdFaster;
		this.timeStart = mSystem.currentTimeMillis();
		this.maxTime = maxTime;
		this.timeDone = this.timeStart + (long)(maxTime * 1000);
		this.xShip = 0;
		this.yShip = GameCanvas.h * 2 / 3;
		this.speed = 0;
		this.timeSpeed = 0;
		this.ideffect = 50;
		this.eff = new EffectAuto((int)this.ideffect, this.xShip, this.yShip, 0, 0, 1, 0);
		this.timeMove = (long)((int)(maxTime * 1000) / (GameCanvas.w + 120));
	}

	// Token: 0x060006C1 RID: 1729 RVA: 0x00067AA8 File Offset: 0x00065CA8
	public override void update()
	{
		this.timeC = LoadMap.getTimeCountDown(this.timeStart, (int)this.maxTime);
		BackGround.updateSky();
		this.updateShip();
		if (this.isSpeed || this.timeDone - mSystem.currentTimeMillis() <= 10000L)
		{
			this.center = null;
		}
		GameScreen.player.dyWater = 0;
		GameScreen.player.Action = 0;
		GameScreen.player.x = this.xShip + this.speed + 30;
		GameScreen.player.y = this.yShip - 40;
		GameScreen.player.Direction = 3;
		GameScreen.player.updateActionPerson();
		base.update();
	}

	// Token: 0x060006C2 RID: 1730 RVA: 0x00067B60 File Offset: 0x00065D60
	public void updateShip()
	{
		this.curr = mSystem.currentTimeMillis();
		if (!this.isSpeed)
		{
			if (this.curr - this.last >= this.timeMove)
			{
				this.speed++;
				this.last = this.curr;
			}
			if (this.timeDone - mSystem.currentTimeMillis() <= 0L)
			{
				this.timeDone = mSystem.currentTimeMillis() + 20000L;
				GlobalService.gI().useShip(this.typeMap);
			}
		}
		else
		{
			this.speed += 2;
			if (this.xShip + this.speed >= GameCanvas.w)
			{
				this.timeDone = mSystem.currentTimeMillis() + 20000L;
				GlobalService.gI().useShip(this.typeMap);
			}
		}
		if (this.eff != null)
		{
			this.eff.update();
			this.eff.x = this.speed;
		}
	}

	// Token: 0x060006C3 RID: 1731 RVA: 0x00067C60 File Offset: 0x00065E60
	public override void paint(mGraphics g)
	{
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		g.setColor(3490674);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isTrue);
		BackGround.paint_SeaAuto(g);
		this.paintShip(g);
		GameScreen.player.paintPlayer(g, -1);
		BackGround.paint_SeaCloud(g);
		base.paint(g);
	}

	// Token: 0x060006C4 RID: 1732 RVA: 0x00067CC4 File Offset: 0x00065EC4
	public void paintShip(mGraphics g)
	{
		if (this.eff != null)
		{
			this.eff.paint(g);
		}
	}

	// Token: 0x060006C5 RID: 1733 RVA: 0x00067CE0 File Offset: 0x00065EE0
	public override void Show()
	{
		this.lastScreen = GameCanvas.game;
		base.Show();
		GameCanvas.clearAll();
		GameScreen.infoGame.resetShip();
	}

	// Token: 0x060006C6 RID: 1734 RVA: 0x00067D10 File Offset: 0x00065F10
	public override void updatekey()
	{
		base.updatekey();
	}

	// Token: 0x060006C7 RID: 1735 RVA: 0x00067D18 File Offset: 0x00065F18
	public override void updatePointer()
	{
		base.updatePointer();
	}

	// Token: 0x060006C8 RID: 1736 RVA: 0x00067D20 File Offset: 0x00065F20
	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			GlobalService.gI().useShip(2);
		}
	}

	// Token: 0x040009F5 RID: 2549
	public static ShipScr instance;

	// Token: 0x040009F6 RID: 2550
	public sbyte ideffect = -1;

	// Token: 0x040009F7 RID: 2551
	public sbyte typeMap = 1;

	// Token: 0x040009F8 RID: 2552
	public EffectAuto eff;

	// Token: 0x040009F9 RID: 2553
	public int speed = 1;

	// Token: 0x040009FA RID: 2554
	public short maxTime;

	// Token: 0x040009FB RID: 2555
	public long last;

	// Token: 0x040009FC RID: 2556
	public long curr;

	// Token: 0x040009FD RID: 2557
	public long timeDone;

	// Token: 0x040009FE RID: 2558
	public long timeStart;

	// Token: 0x040009FF RID: 2559
	public bool isSpeed;

	// Token: 0x04000A00 RID: 2560
	private iCommand cmdFaster;

	// Token: 0x04000A01 RID: 2561
	private string timeC;

	// Token: 0x04000A02 RID: 2562
	public int xShip;

	// Token: 0x04000A03 RID: 2563
	public int yShip;

	// Token: 0x04000A04 RID: 2564
	public short timeSpeed;

	// Token: 0x04000A05 RID: 2565
	private long timeMove;
}
