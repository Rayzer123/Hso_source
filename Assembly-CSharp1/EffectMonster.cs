using System;

// Token: 0x02000035 RID: 53
public class EffectMonster
{
	// Token: 0x06000271 RID: 625 RVA: 0x00012BCC File Offset: 0x00010DCC
	public static void addEffectMonster(MainMonster mon)
	{
		EffectMonster effectMonster = new EffectMonster();
		effectMonster.idMon = mon.catalogyMonster;
		effectMonster.monster = mon;
		if (effectMonster.monster.isMonsterHouse())
		{
			if (effectMonster.idMon == 89)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g128.png"), 53, 49);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[0];
				effectMonster.dx = -3;
				effectMonster.dy = 70;
				effectMonster.dxDie = 0;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight - 2;
			}
			else if (effectMonster.idMon == 90)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g129.png"), 44, 44);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[1];
				effectMonster.dx = 0;
				effectMonster.dy = 30;
				effectMonster.dxDie = 0;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			else if (effectMonster.idMon == 91)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g130.png"), 50, 51);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[2];
				effectMonster.dx = 0;
				effectMonster.dy = 20;
				effectMonster.dxDie = 5;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			else if (effectMonster.idMon == 92)
			{
				effectMonster.imgAuto = new FrameImage(mImage.createImage("/eff/g131.png"), 40, 40);
				effectMonster.imgDie = ItemMap.img_HouseArena_Die[3];
				effectMonster.dx = 22;
				effectMonster.dy = 22;
				effectMonster.dxDie = 5;
				effectMonster.dyDie = -effectMonster.imgDie.frameHeight;
			}
			effectMonster.x = mon.x;
			effectMonster.y = mon.y;
			effectMonster.w = (effectMonster.h = -1);
			effectMonster.h = mon.hOne;
			effectMonster.wImg = effectMonster.imgAuto.frameWidth;
			effectMonster.hImg = effectMonster.imgAuto.frameHeight;
			effectMonster.isPaint = true;
			effectMonster.isUpdate = true;
			effectMonster.isPaintDie = false;
			effectMonster.f = 0;
			effectMonster.fDie = 0;
			effectMonster.imgEff = new FrameImage(68);
			EffectMonster.listEffectMonster.addElement(effectMonster);
		}
	}

	// Token: 0x06000272 RID: 626 RVA: 0x00012E14 File Offset: 0x00011014
	public void setTurnOff()
	{
		if (this.isPaintDie)
		{
			this.isPaint = false;
		}
		if (!this.isPaintDie)
		{
			this.isPaintDie = true;
		}
	}

	// Token: 0x06000273 RID: 627 RVA: 0x00012E48 File Offset: 0x00011048
	public void update()
	{
		if (this.isUpdate)
		{
			if (EffectMonster.buffDame)
			{
				if (this.nFrame != new sbyte[]
				{
					0,
					0,
					1,
					1,
					2,
					2,
					3,
					3
				})
				{
					this.nFrame = new sbyte[]
					{
						0,
						0,
						1,
						1,
						2,
						2,
						3,
						3
					};
				}
			}
			else if (this.nFrame != new sbyte[]
			{
				0,
				0,
				0,
				1,
				1,
				1,
				2,
				2,
				2,
				3,
				3,
				3
			})
			{
				this.nFrame = new sbyte[]
				{
					0,
					0,
					0,
					1,
					1,
					1,
					2,
					2,
					2,
					3,
					3,
					3
				};
			}
			if (this.monster.hp > 0)
			{
				this.f++;
				if (this.f > this.nFrame.Length - 1)
				{
					this.f = 0;
				}
				this.x = this.monster.x;
				this.y = this.monster.y;
			}
			else
			{
				this.setTurnOff();
			}
			if (GameScreen.timeArena != 0L && mSystem.currentTimeMillis() - GameScreen.timeArena > 2700000L)
			{
				this.setTurnOff();
			}
		}
	}

	// Token: 0x06000274 RID: 628 RVA: 0x00012F68 File Offset: 0x00011168
	public void paint(mGraphics g)
	{
		try
		{
			if (this.isPaint && this.imgAuto != null)
			{
				if (this.w < 0)
				{
					this.w = this.monster.wOne;
					this.h = this.monster.hOne;
				}
				this.imgAuto.drawFrame((int)this.nFrame[this.f], this.x - this.wImg / 2 + this.dx, this.y - this.h - this.hImg + this.dy, 0, g);
			}
		}
		catch (Exception ex)
		{
			this.isPaint = false;
			this.isUpdate = false;
			this.isPaintDie = false;
		}
	}

	// Token: 0x06000275 RID: 629 RVA: 0x00013044 File Offset: 0x00011244
	public void paintDie(mGraphics g)
	{
		try
		{
			if (this.isPaintDie && this.imgDie != null)
			{
				if (this.w < 0)
				{
					this.w = this.monster.wOne;
					this.h = this.monster.hOne;
				}
				this.imgDie.drawFrame((int)this.nFramedie[this.fDie], this.x - this.w / 2 + this.dxDie, this.y + this.dyDie, 0, g);
			}
		}
		catch (Exception ex)
		{
			this.isPaint = false;
			this.isUpdate = false;
			this.isPaintDie = false;
		}
	}

	// Token: 0x04000282 RID: 642
	public const sbyte mon_Tower1 = 89;

	// Token: 0x04000283 RID: 643
	public const sbyte mon_Tower2 = 90;

	// Token: 0x04000284 RID: 644
	public const sbyte mon_Tower3 = 91;

	// Token: 0x04000285 RID: 645
	public const sbyte mon_Tower4 = 92;

	// Token: 0x04000286 RID: 646
	public static mVector listEffectMonster = new mVector("EffectMonster listEffectMonster");

	// Token: 0x04000287 RID: 647
	private FrameImage imgAuto;

	// Token: 0x04000288 RID: 648
	private FrameImage imgDie;

	// Token: 0x04000289 RID: 649
	private FrameImage imgEff;

	// Token: 0x0400028A RID: 650
	private bool isPaint = true;

	// Token: 0x0400028B RID: 651
	private bool isUpdate;

	// Token: 0x0400028C RID: 652
	private bool isPaintDie = true;

	// Token: 0x0400028D RID: 653
	private int x;

	// Token: 0x0400028E RID: 654
	private int y;

	// Token: 0x0400028F RID: 655
	private int w;

	// Token: 0x04000290 RID: 656
	private int h;

	// Token: 0x04000291 RID: 657
	private int dx;

	// Token: 0x04000292 RID: 658
	private int dy;

	// Token: 0x04000293 RID: 659
	private int f;

	// Token: 0x04000294 RID: 660
	private int idMon;

	// Token: 0x04000295 RID: 661
	private int wImg;

	// Token: 0x04000296 RID: 662
	private int hImg;

	// Token: 0x04000297 RID: 663
	private int fDie;

	// Token: 0x04000298 RID: 664
	private int dxDie;

	// Token: 0x04000299 RID: 665
	private int dyDie;

	// Token: 0x0400029A RID: 666
	private MainObject monster;

	// Token: 0x0400029B RID: 667
	public sbyte[] nFrame = new sbyte[]
	{
		0,
		0,
		1,
		1,
		2,
		2,
		3,
		3
	};

	// Token: 0x0400029C RID: 668
	public sbyte[] nFramedie = new sbyte[8];

	// Token: 0x0400029D RID: 669
	public static bool buffDame = false;
}
