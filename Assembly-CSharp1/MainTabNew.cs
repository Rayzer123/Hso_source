using System;

// Token: 0x02000097 RID: 151
public class MainTabNew : AvMain
{
	// Token: 0x06000724 RID: 1828 RVA: 0x0006CA8C File Offset: 0x0006AC8C
	public MainTabNew()
	{
		if (GameCanvas.isTouch)
		{
			MainTabNew.wOneItem = 26;
		}
		else if (GameCanvas.w >= 240)
		{
			MainTabNew.wOneItem = 24;
		}
		if (GameCanvas.h < 240 && (int)MainTabNew.wOneItem > 24)
		{
			MainTabNew.wOneItem = 24;
		}
		MainTabNew.hMaxContent = GameCanvas.h - GameCanvas.hCommand * 2;
		MainTabNew.wOne5 = (sbyte)((int)MainTabNew.wOneItem / 5);
		MainTabNew.wbackground = GameCanvas.w / 32 + 1;
		MainTabNew.hbackground = GameCanvas.h / 32 + 1;
		int num = GameCanvas.w / (int)MainTabNew.wOneItem;
		if (num > 9)
		{
			num = 9;
		}
		int num2 = GameCanvas.h / 5 * 4 - GameCanvas.hCommand / 2;
		if (GameCanvas.isTouch)
		{
			num2 += GameCanvas.hCommand / 2;
		}
		int num3 = num2 / (int)MainTabNew.wOneItem;
		if (num3 > 8)
		{
			num3 = 8;
		}
		this.wSmall = (num - 1) * (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 * 3 + ((!GameCanvas.isSmallScreen) ? 0 : ((int)MainTabNew.wOne5));
		this.hSmall = num3 * (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5;
		if (this.hSmall % 2 != 0)
		{
			this.hSmall--;
		}
		if (GameCanvas.isTouch)
		{
			if (GameCanvas.w >= 380)
			{
				MainTabNew.longwidth = 170;
				MainTabNew.timeRequest = 5;
				MainTabNew.hMaxContent = this.hSmall - (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5;
				this.xTab = (GameCanvas.w - num * (int)MainTabNew.wOneItem - MainTabNew.longwidth) / 2;
				MainTabNew.xlongwidth = GameCanvas.w - this.xTab - MainTabNew.longwidth;
				MainTabNew.ylongwidth = this.yTab + GameCanvas.h / 5;
			}
			else if (GameCanvas.w > 315)
			{
				MainTabNew.is320 = true;
				if ((int)LoginScreen.indexInfoLogin == 1)
				{
					LoginScreen.indexInfoLogin = 2;
				}
				num = 8;
				this.wSmall = (num - 1) * (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5 * 3;
				MainTabNew.longwidth = 130;
				MainTabNew.timeRequest = 5;
				MainTabNew.hMaxContent = this.hSmall - (int)MainTabNew.wOneItem - (int)MainTabNew.wOne5;
				MainTabNew.xlongwidth = GameCanvas.w - this.xTab - MainTabNew.longwidth + 5;
				MainTabNew.ylongwidth = this.yTab + GameCanvas.h / 5;
			}
		}
		if (MainTabNew.is320)
		{
			this.xTab = -5;
			MainTabNew.xlongwidth = this.xTab + this.wSmall + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2;
			MainTabNew.longwidth = GameCanvas.w - MainTabNew.xlongwidth;
		}
		else
		{
			this.xTab = (GameCanvas.w - num * (int)MainTabNew.wOneItem - MainTabNew.longwidth) / 2;
		}
		this.yTab = 0;
		this.numWSmall = this.wSmall / 32;
		this.numHSmall = this.hSmall / 32;
		MainTabNew.wblack = this.wSmall / (int)MainTabNew.wOneItem * (int)MainTabNew.wOneItem;
		MainTabNew.hblack = (this.hSmall / (int)MainTabNew.wOneItem - 1) * (int)MainTabNew.wOneItem;
		this.numWBlack = MainTabNew.wblack / 32;
		this.numHBlack = MainTabNew.hblack / 32;
		this.xMoney = GameCanvas.w - (this.xTab - 9) - 72;
		if (GameCanvas.isTouch && this.xMoney > GameCanvas.w - 112)
		{
			this.xMoney = GameCanvas.w - 112;
		}
		this.yMoney = 5;
		if (GameCanvas.isSmallScreen)
		{
			this.yMoney = 2;
		}
		this.xChar = 0;
		this.yChar = GameCanvas.h / 10 - 21;
		if (GameCanvas.isSmallScreen)
		{
			this.yChar += 4;
		}
		this.sizeFocus = (int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem;
		if (this.sizeFocus > 32)
		{
			this.sizeFocus = 32;
		}
	}

	// Token: 0x06000726 RID: 1830 RVA: 0x0006CFAC File Offset: 0x0006B1AC
	public static MainTabNew gI()
	{
		if (MainTabNew.instance == null)
		{
			MainTabNew.instance = new MainTabNew();
		}
		return MainTabNew.instance;
	}

	// Token: 0x06000727 RID: 1831 RVA: 0x0006CFC8 File Offset: 0x0006B1C8
	public static void paintRectLowGraphic(mGraphics g, int x, int y, int w, int h, int indexColor)
	{
		g.setColor(MainTabNew.colorLow[indexColor]);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	// Token: 0x06000728 RID: 1832 RVA: 0x0006CFF4 File Offset: 0x0006B1F4
	public virtual void init()
	{
	}

	// Token: 0x06000729 RID: 1833 RVA: 0x0006CFF8 File Offset: 0x0006B1F8
	public virtual void setNameCmd(string name)
	{
	}

	// Token: 0x0600072A RID: 1834 RVA: 0x0006CFFC File Offset: 0x0006B1FC
	public virtual void backTab()
	{
		MainScreen.cameraSub.setAll(0, 0, 0, 0);
		if (GameCanvas.isTouch)
		{
			if (GameCanvas.currentScreen == GameCanvas.AllInfo)
			{
				if (GameCanvas.AllInfo.lastScreen != null && GameCanvas.AllInfo.lastScreen != GameCanvas.AllInfo && GameCanvas.AllInfo.lastScreen != GameCanvas.shopNpc)
				{
					GameCanvas.AllInfo.lastScreen.Show();
				}
				else
				{
					GameCanvas.game.Show();
				}
			}
			else if (GameCanvas.currentScreen == GameCanvas.shopNpc)
			{
				if (GameCanvas.AllInfo.lastScreen != null && GameCanvas.AllInfo.lastScreen != GameCanvas.AllInfo && GameCanvas.AllInfo.lastScreen != GameCanvas.shopNpc)
				{
					GameCanvas.shopNpc.lastScreen.Show();
				}
				else
				{
					GameCanvas.game.Show();
				}
			}
			else if (GameCanvas.currentScreen == GameCanvas.foodPet)
			{
				if (GameCanvas.foodPet.lastScreen != null)
				{
					GameCanvas.foodPet.lastScreen.Show();
				}
				else
				{
					GameCanvas.game.Show();
				}
			}
		}
	}

	// Token: 0x0600072B RID: 1835 RVA: 0x0006D130 File Offset: 0x0006B330
	public override void keypress(int keyCode)
	{
	}

	// Token: 0x0600072C RID: 1836 RVA: 0x0006D134 File Offset: 0x0006B334
	public void paintHairShop(mGraphics g, int hair)
	{
		GameCanvas.resetTrans(g);
		GameScreen.player.paintShowHairPlayer(g, GameCanvas.hw, GameCanvas.h / 10 + 15, hair);
	}

	// Token: 0x0600072D RID: 1837 RVA: 0x0006D164 File Offset: 0x0006B364
	public void paintTab(mGraphics g, string nameTab, int idSelect, mVector vec, bool isClan)
	{
		int num = vec.size();
		if (!Main.isPC && !Main.isIpad)
		{
			g.setColor(14602424);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		}
		for (int i = 0; i < 3; i++)
		{
			g.drawImage(MainTabNew.imgTab[1], this.xMoney + 22 * i, this.yMoney, 0, mGraphics.isFalse);
		}
		if (Main.isPC || Main.isIpad)
		{
			for (int j = 0; j <= this.numWSmall; j++)
			{
				for (int k = 0; k <= this.numHSmall; k++)
				{
					if (j == this.numWSmall)
					{
						if (k == this.numHSmall)
						{
							g.drawImage(MainTabNew.imgTab[0], this.xTab + (int)MainTabNew.wOne5 * 2 + this.wSmall - 64, this.yTab + GameCanvas.h / 5 + this.hSmall - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[0], this.xTab + (int)MainTabNew.wOne5 * 2 + this.wSmall - 64, this.yTab + k * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
						}
					}
					else if (k == this.numHSmall)
					{
						g.drawImage(MainTabNew.imgTab[0], this.xTab + (int)MainTabNew.wOne5 * 2 + j * 32 - 5, this.yTab + GameCanvas.h / 5 + this.hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[0], this.xTab + (int)MainTabNew.wOne5 * 2 + j * 32 - 5, this.yTab + k * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
					}
				}
			}
		}
		for (int l = 0; l <= this.numWSmall; l++)
		{
			for (int m = 0; m <= this.numHSmall; m++)
			{
				if (l == 0 || l == this.numWSmall || m == this.numHSmall || m == 0)
				{
					if (l == this.numWSmall)
					{
						if (m == this.numHSmall)
						{
							g.drawImage(MainTabNew.imgTab[1], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 + this.wSmall - 32, this.yTab + GameCanvas.h / 5 + this.hSmall - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[1], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 + this.wSmall - 32, this.yTab + m * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
						}
					}
					else if (m == this.numHSmall)
					{
						g.drawImage(MainTabNew.imgTab[1], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 + l * 32, this.yTab + GameCanvas.h / 5 + this.hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[1], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 + l * 32, this.yTab + m * 32 + GameCanvas.h / 5, 0, mGraphics.isFalse);
					}
				}
			}
		}
		AvMain.Font3dWhite(g, nameTab, this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2 + this.wSmall / 2, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem / 2 - 6, 2);
		GameScreen.infoGame.paintInfoPlayer(g, 0, 0, !GameCanvas.isSmallScreen, (!GameCanvas.isSmallScreen) ? mFont.tahoma_7_white : mFont.tahoma_7_black);
		g.drawRegion(MainTabNew.imgTab[4], 0, 0, 14, 14, 0, this.xMoney + 4, this.yMoney + 2, 0, mGraphics.isFalse);
		g.drawRegion(MainTabNew.imgTab[4], 0, 14, 14, 14, 0, this.xMoney + 4, this.yMoney + 17, 0, mGraphics.isFalse);
		if (isClan)
		{
			PaintInfoGameScreen.fraEvent.drawFrame(10, this.xMoney - 12, this.yMoney + 10, 0, 3, g);
			if (GameScreen.player.myClan != null)
			{
				mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.myClan.coin), this.xMoney + 19, this.yMoney + 3, 0, mGraphics.isFalse);
				mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber((long)GameScreen.player.myClan.gold), this.xMoney + 19, this.yMoney + 18, 0, mGraphics.isFalse);
			}
		}
		else
		{
			mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.coin), this.xMoney + 19, this.yMoney + 3, 0, mGraphics.isFalse);
			mFont.tahoma_7_white.drawString(g, MainItem.getDotNumber(GameScreen.player.gold), this.xMoney + 19, this.yMoney + 18, 0, mGraphics.isFalse);
		}
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, this.xTab + (int)MainTabNew.wOne5, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * idSelect, (int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 1);
		}
		else if ((int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem > 32)
		{
			g.drawRegion(MainTabNew.imgTab[1], 0, 0, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, this.xTab + (int)MainTabNew.wOne5, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * idSelect, 0, mGraphics.isFalse);
			g.drawRegion(MainTabNew.imgTab[1], 0, 0, (int)MainTabNew.wOne5, (int)MainTabNew.wOneItem, 0, this.xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * idSelect, 0, mGraphics.isFalse);
		}
		else
		{
			g.drawRegion(MainTabNew.imgTab[1], 0, 0, (int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, this.xTab + (int)MainTabNew.wOne5, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * idSelect, 0, mGraphics.isFalse);
		}
		g.setColor(MainTabNew.color[0]);
		for (int n = 0; n < num; n++)
		{
			MainTabNew mainTabNew = (MainTabNew)vec.elementAt(n);
			int num2 = 0;
			if (n != idSelect)
			{
				g.drawRect(this.xTab + (int)MainTabNew.wOne5, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem * n, (int)MainTabNew.wOne5 + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, mGraphics.isFalse);
			}
			else if ((int)MainTabNew.Focus == (int)MainTabNew.TAB || GameCanvas.isTouch)
			{
				num2 = -1 + GameCanvas.gameTick / 2 % 3;
			}
			int num3 = (int)mainTabNew.typeTab;
			if (num3 > (int)MainTabNew.maxTypeTab)
			{
				num3 = (int)this.typeTab;
			}
			g.drawRegion(MainTabNew.imgTab[3], 0, num3 * 16, 16, 16, 0, this.xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2 + (int)MainTabNew.wOneItem / 2 + num2, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem / 2 + (int)MainTabNew.wOneItem * n, mGraphics.VCENTER | mGraphics.HCENTER, mGraphics.isFalse);
			if ((int)mainTabNew.typeTab == (int)MainTabNew.MY_INFO && Player.diemTiemNang > 0)
			{
				PaintInfoGameScreen.fralevelup.drawFrame(GameCanvas.gameTick / 4 % 2, this.xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2 + (int)MainTabNew.wOneItem + num2 - 4, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem * n - 6, 0, 3, g);
			}
			else if ((int)mainTabNew.typeTab == (int)MainTabNew.SKILLS && Player.diemKyNang > 0)
			{
				PaintInfoGameScreen.fralevelup.drawFrame(2 + GameCanvas.gameTick / 4 % 2, this.xTab + (int)MainTabNew.wOne5 + (int)MainTabNew.wOne5 / 2 + (int)MainTabNew.wOneItem + num2 - 4, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem * n - 6, 0, 3, g);
			}
		}
		for (int num4 = 0; num4 <= this.numWBlack; num4++)
		{
			for (int num5 = 0; num5 <= this.numHBlack; num5++)
			{
				if (num4 == this.numWBlack)
				{
					if (num5 == this.numHBlack)
					{
						g.drawImage(MainTabNew.imgTab[2], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack - 32, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[2], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + MainTabNew.wblack - 32, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + num5 * 32, 0, mGraphics.isFalse);
					}
				}
				else if (num5 == this.numHBlack)
				{
					g.drawImage(MainTabNew.imgTab[2], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + num4 * 32, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + MainTabNew.hblack - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[2], this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3 + num4 * 32, this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem + num5 * 32, 0, mGraphics.isFalse);
				}
			}
		}
		if (MainTabNew.longwidth > 0)
		{
			GameCanvas.resetTrans(g);
			int num6 = (MainTabNew.longwidth - 10) / 32;
			int num7 = this.hSmall / 32;
			int num8 = GameCanvas.w - this.xTab - (MainTabNew.longwidth - 10);
			int num9 = this.yTab + GameCanvas.h / 5;
			int num10 = MainTabNew.longwidth / 32;
			int num11 = this.hSmall / 32;
			for (int num12 = 0; num12 <= num10; num12++)
			{
				for (int num13 = 0; num13 <= num7; num13++)
				{
					int num14 = 12;
					if (num13 == 0)
					{
						num14 = 12;
					}
					if (num12 == num10)
					{
						if (num13 == num11)
						{
							g.drawImage(MainTabNew.imgTab[num14], MainTabNew.xlongwidth + MainTabNew.longwidth - 32, MainTabNew.ylongwidth + this.hSmall - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[num14], MainTabNew.xlongwidth + MainTabNew.longwidth - 32, MainTabNew.ylongwidth + num13 * 32, 0, mGraphics.isFalse);
						}
					}
					else if (num13 == num11)
					{
						g.drawImage(MainTabNew.imgTab[num14], MainTabNew.xlongwidth + num12 * 32, MainTabNew.ylongwidth + this.hSmall - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[num14], MainTabNew.xlongwidth + num12 * 32, MainTabNew.ylongwidth + num13 * 32, 0, mGraphics.isFalse);
					}
				}
			}
			for (int num15 = MainTabNew.xlongwidth; num15 < MainTabNew.xlongwidth + MainTabNew.longwidth; num15 += 6)
			{
				g.fillRect(num15, MainTabNew.ylongwidth + (int)MainTabNew.wOneItem, 4, 1, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x0600072E RID: 1838 RVA: 0x0006DDB4 File Offset: 0x0006BFB4
	public void paintPopupContent(mGraphics g, bool isOnlyName)
	{
		if (MainTabNew.longwidth > 0)
		{
			this.paintContentNew(g, isOnlyName);
		}
		else
		{
			this.paintContent(g, isOnlyName);
		}
	}

	// Token: 0x0600072F RID: 1839 RVA: 0x0006DDE4 File Offset: 0x0006BFE4
	public void paintContent(mGraphics g, bool isOnlyName)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		g.setClip(-g.getTranslateX(), -g.getTranslateY(), GameCanvas.w, GameCanvas.h);
		int num2 = 1;
		if (this.mContent != null)
		{
			num2 = this.mContent.Length;
		}
		if (this.mPlusContent != null)
		{
			num2 += this.mPlusContent.Length;
		}
		int num3 = (num2 + 1) * GameCanvas.hText + 8;
		if (num3 > MainTabNew.hMaxContent)
		{
			num3 = MainTabNew.hMaxContent;
		}
		if (this.xCon + this.wContent > GameCanvas.w)
		{
			this.xCon = GameCanvas.w / 2 - this.wContent / 2;
		}
		int num4 = this.yCon;
		g.setColor(MainTabNew.color[10]);
		g.fillRect(this.xCon - 1, num4 - 1, this.wContent + 2, num3 + 2, mGraphics.isTrue);
		g.setColor(MainTabNew.color[2]);
		g.fillRect(this.xCon, num4, this.wContent + 1, num3 + 1, mGraphics.isTrue);
		int num5 = this.wContent / 32;
		int num6 = num3 / 32;
		for (int i = 0; i <= num5; i++)
		{
			for (int j = 0; j <= num6; j++)
			{
				if (i == num5)
				{
					if (j == num6)
					{
						g.drawImage(MainTabNew.imgTab[12], this.xCon + this.wContent - 32, num4 + num3 - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[12], this.xCon + this.wContent - 32, num4 + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == num6)
				{
					g.drawImage(MainTabNew.imgTab[12], this.xCon + i * 32, num4 + num3 - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[12], this.xCon + i * 32, num4 + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
		g.setClip(this.xCon + 1, num4 + 1, this.wContent - 2, num3 - 2);
		if (!isOnlyName)
		{
			if (this.name != null)
			{
				MainTabNew.paintNameItem(g, this.xCon + this.wContent / 2, num4 + 2, this.wContent, this.name, this.colorName);
			}
			if (this.listContent != null)
			{
				g.setClip(this.xCon, num4 + GameCanvas.hText, this.wContent, MainTabNew.hMaxContent - GameCanvas.hText);
				g.translate(0, -this.listContent.cmx);
			}
		}
		if (this.mPlusContent != null)
		{
			for (int k = 0; k < this.mPlusContent.Length; k++)
			{
				num4 += GameCanvas.hText;
				MainTabNew.setTextColor(this.mPlusColor[k]).drawString(g, this.mPlusContent[k], this.xCon + num, num4 + 2, 0, mGraphics.isTrue);
			}
		}
		if (this.mPlusContent == null && this.moreInfoconten.size() > 0)
		{
			num4 += GameCanvas.hText;
		}
		for (int l = 0; l < this.moreInfoconten.size(); l++)
		{
			InfocontenNew infocontenNew = (InfocontenNew)this.moreInfoconten.elementAt(l);
			if (infocontenNew != null)
			{
				if (this.mPlusContent != null)
				{
					Item.eff_UpLv.paintUpgradeEffect(this.xCon + num + this.mPlusContent[0].Length * 5 + 3 + 15 * l, num4 - GameCanvas.hText / 2 + ((this.mPlusContent.Length != 1) ? 0 : GameCanvas.hText), 13, 13, g, 0);
				}
				else
				{
					Item.eff_UpLv.paintUpgradeEffect(this.xCon + num + 16 + 15 * l, num4 - GameCanvas.hText / 2, 13, 13, g, 0);
				}
				if (infocontenNew.idimage != -1)
				{
					MainItem material = Item.getMaterial(infocontenNew.idimage);
					if (material != null)
					{
						if (this.mPlusContent != null && this.mPlusContent[0] != null)
						{
							material.paintItem_notnum(g, this.xCon + num + this.mPlusContent[0].Length * 5 + 3 + 15 * l + 1, num4 - GameCanvas.hText / 2 + 1 + ((this.mPlusContent.Length != 1) ? 0 : GameCanvas.hText), 21, 1, 0);
						}
						else
						{
							material.paintItem_notnum(g, this.xCon + num + 16 + 15 * l, num4 - GameCanvas.hText / 2 + 1, 21, 1, 0);
						}
					}
					else
					{
						Item.put_Material(infocontenNew.idimage);
					}
				}
			}
		}
		if (this.mContent != null)
		{
			for (int m = 0; m < this.mContent.Length; m++)
			{
				if (this.mContent[m] != null)
				{
					mFont mFont;
					if (this.mcolor != null)
					{
						mFont = MainTabNew.setTextColor(this.mcolor[m]);
					}
					else
					{
						mFont = mFont.tahoma_7_white;
					}
					mFont.drawString(g, this.mContent[m], this.xCon + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					if (this.mSubContent != null)
					{
						int num7 = mFont.getWidth(this.mContent[m]) + 5;
						mFont = MainTabNew.setTextColor(this.mSubColor[m]);
						mFont.drawString(g, this.mSubContent[m], this.xCon + num7 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
					}
				}
			}
		}
		else if (!isOnlyName)
		{
			if (this.name != null)
			{
				MainTabNew.paintNameItem(g, this.xCon + this.wContent / 2, num4 + 2, this.wContent, this.name, this.colorName);
			}
		}
		else if (this.name != null)
		{
			MainTabNew.paintNameItem(g, this.xCon + this.wContent / 2, num4 + GameCanvas.hText / 4, this.wContent, this.name, this.colorName);
		}
		if (this.cmd != null)
		{
			this.cmd.paint(g, this.xCon + this.wContent - iCommand.wButtonCmd / 2, num4 + num3 - iCommand.hButtonCmd);
			if (this.xpos_cmd == 0 || this.ypos_cmd == 0)
			{
				this.xpos_cmd = this.xCon + this.wContent - iCommand.wButtonCmd / 2;
				this.ypos_cmd = num4 + num3 - iCommand.hButtonCmd;
			}
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x06000730 RID: 1840 RVA: 0x0006E490 File Offset: 0x0006C690
	public void updateCMD()
	{
		if (this.cmd != null)
		{
			if (this.xpos_cmd != 0 && this.ypos_cmd != 0)
			{
				this.cmd.setPos(this.xpos_cmd, this.ypos_cmd, PaintInfoGameScreen.fraButton, this.cmd.caption);
			}
			if (GameCanvas.isTouch)
			{
				this.cmd.updatePointer();
			}
			else if (GameCanvas.keyMyPressed[5])
			{
				GameCanvas.keyMyPressed[5] = false;
				this.cmd.perform();
			}
		}
	}

	// Token: 0x06000731 RID: 1841 RVA: 0x0006E520 File Offset: 0x0006C720
	public override void update()
	{
		this.updateCMD();
	}

	// Token: 0x06000732 RID: 1842 RVA: 0x0006E528 File Offset: 0x0006C728
	public void paintContentNew(mGraphics g, bool isOnlyName)
	{
		int num = 4;
		TabScreenNew.timeRepaint = 10;
		GameCanvas.resetTrans(g);
		int num2 = MainTabNew.xlongwidth;
		int num3 = MainTabNew.ylongwidth;
		int num4 = num3;
		g.setClip(num2 + 1, num4 + 1, MainTabNew.longwidth - 2, this.hSmall - 2);
		if (!isOnlyName)
		{
			MainTabNew.paintNameItem(g, num2 + MainTabNew.longwidth / 2, num4 + (int)MainTabNew.wOneItem / 2 - 5, MainTabNew.longwidth, this.name, this.colorName);
			if (this.listContent != null)
			{
				g.setClip(num2, num4 + (int)MainTabNew.wOneItem + 2, MainTabNew.longwidth, MainTabNew.hMaxContent - (int)MainTabNew.wOneItem - 2);
				g.translate(0, -this.listContent.cmx);
			}
			num4 += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
		}
		if (this.mPlusContent != null)
		{
			for (int i = 0; i < this.mPlusContent.Length; i++)
			{
				num4 += GameCanvas.hText;
				MainTabNew.setTextColor(this.mPlusColor[i]).drawString(g, this.mPlusContent[i], num2 + num, num4 + 2, 0, mGraphics.isTrue);
			}
		}
		if (this.mPlusContent == null && this.moreInfoconten.size() > 0)
		{
			num4 += GameCanvas.hText;
		}
		for (int j = 0; j < this.moreInfoconten.size(); j++)
		{
			InfocontenNew infocontenNew = (InfocontenNew)this.moreInfoconten.elementAt(j);
			if (infocontenNew != null)
			{
				if (this.mPlusColor != null)
				{
					Item.eff_UpLv.paintUpgradeEffect(num2 + num + this.mPlusContent[0].Length * 5 + 3 + 15 * j, num4 - GameCanvas.hText / 2 + ((this.mPlusContent.Length != 1) ? 0 : GameCanvas.hText), 13, 13, g, 0);
				}
				else
				{
					Item.eff_UpLv.paintUpgradeEffect(num2 + num + 16 + 15 * j, num4 - GameCanvas.hText / 2 + GameCanvas.hText, 13, 13, g, 0);
				}
				if (infocontenNew.idimage != -1)
				{
					MainItem material = Item.getMaterial(infocontenNew.idimage);
					if (material != null)
					{
						if (this.mPlusContent != null && this.mPlusContent[0] != null)
						{
							material.paintItem_notnum(g, num2 + num + this.mPlusContent[0].Length * 5 + 3 + 15 * j + 1, num4 - GameCanvas.hText / 2 + 1 + ((this.mPlusContent.Length != 1) ? 0 : GameCanvas.hText), 21, 1, 0);
						}
						else
						{
							material.paintItem_notnum(g, num2 + num + 16 + 15 * j, num4 - GameCanvas.hText / 2 + GameCanvas.hText + 1, 21, 1, 0);
						}
					}
					else
					{
						Item.put_Material(infocontenNew.idimage);
					}
				}
			}
		}
		if (this.mContent != null)
		{
			PetItem pet = MsgDialog.pet;
			if (this.isPet && pet != null)
			{
				num4 += GameCanvas.hText;
				mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
				{
					T.level,
					pet.LvItem,
					" + ",
					(int)(pet.experience / 10),
					",",
					(int)(pet.experience % 10),
					"%"
				}), num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				int num5 = pet.age / 24;
				int num6 = pet.age % 24;
				int num7 = (int)((long)pet.timeDefaultItemFashion - pet.getTimeItemFashion() / 60000L);
				if (num7 > 0)
				{
					mFont.tahoma_7_red.drawString(g, T.sudungsau + " " + PaintInfoGameScreen.getStringTime(num7), num2 + num, num4 + 2, 0, mGraphics.isTrue);
					num4 += GameCanvas.hText;
				}
				mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
				{
					T.tuoi,
					num5,
					"d ",
					num6,
					"h"
				}), num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				if (pet.petAttack != null)
				{
					MainTabNew.setTextColor((int)Item.colorInfoItem[pet.petAttack.id]).drawString(g, string.Concat(new object[]
					{
						Item.nameInfoItem[pet.petAttack.id],
						": ",
						pet.petAttack.value,
						"-",
						pet.petAttack.maxDam
					}), num2 + num, num4 + 2, 0, mGraphics.isTrue);
				}
				num4 += GameCanvas.hText;
				mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
				{
					T.choan,
					": ",
					pet.growpoint,
					"/",
					pet.maxgrow
				}), num2 + num, num4 + 2, 0, mGraphics.isTrue);
				num4 += GameCanvas.hText;
				for (int k = 0; k < T.mKynangPet.Length; k++)
				{
					mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
					{
						T.mKynangPet[k],
						": ",
						pet.mvaluetiemnang[k],
						"/",
						pet.maxtiemnang
					}), num2 + num, num4 + 2, 0, mGraphics.isTrue);
					num4 += GameCanvas.hText;
				}
				for (int l = 0; l < pet.mInfo.Length; l++)
				{
					if (pet.mInfo[l].id > 6)
					{
						string st = Item.nameInfoItem[pet.mInfo[l].id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[pet.mInfo[l].id], pet.mInfo[l].value);
						MainTabNew.setTextColor((int)Item.colorInfoItem[pet.mInfo[l].id]).drawString(g, st, num2 + num, num4 + 2, 0, mGraphics.isTrue);
						num4 += GameCanvas.hText;
					}
				}
			}
			else
			{
				for (int m = 0; m < this.mContent.Length; m++)
				{
					if (this.mContent[m] != null)
					{
						mFont mFont;
						if (this.mcolor != null)
						{
							mFont = MainTabNew.setTextColor(this.mcolor[m]);
						}
						else
						{
							mFont = mFont.tahoma_7_white;
						}
						mFont.drawString(g, this.mContent[m], num2 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
						if (this.mSubContent != null)
						{
							int num8 = mFont.getWidth(this.mContent[m]) + 5;
							mFont = MainTabNew.setTextColor(this.mSubColor[m]);
							mFont.drawString(g, this.mSubContent[m], num2 + num8 + num, num4 + 2 + (m + 1) * GameCanvas.hText, 0, mGraphics.isTrue);
						}
					}
				}
			}
		}
		else if (isOnlyName)
		{
			mFont.tahoma_7b_white.drawString(g, this.name, num2 + MainTabNew.longwidth / 2, num4 + (int)MainTabNew.wOneItem / 2 - 5, 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x06000733 RID: 1843 RVA: 0x0006ECB4 File Offset: 0x0006CEB4
	public static void paintNameItem(mGraphics g, int x, int y, int w, string name, int colorName)
	{
		if (mFont.tahoma_7b_black.getWidth(name) <= w)
		{
			mFont mFont = MainTabNew.setTextColorName(colorName);
			mFont.drawString(g, name, x, y, 2, mGraphics.isTrue);
		}
		else
		{
			if (MainTabNew.nameCur.CompareTo(name.Trim()) != 0)
			{
				MainTabNew.getTextName(name);
			}
			mFont mFont2 = MainTabNew.setTextColor(colorName);
			mFont2.drawString(g, MainTabNew.namePaint[0], x, y - 6, 2, mGraphics.isTrue);
			mFont2.drawString(g, MainTabNew.namePaint[1], x, y + 6, 2, mGraphics.isTrue);
		}
	}

	// Token: 0x06000734 RID: 1844 RVA: 0x0006ED48 File Offset: 0x0006CF48
	public static void getTextName(string name)
	{
		MainTabNew.nameCur = name.Trim();
		MainTabNew.namePaint = new string[2];
		for (int i = 0; i < MainTabNew.namePaint.Length; i++)
		{
			MainTabNew.namePaint[i] = string.Empty;
		}
		string[] array = mFont.split(MainTabNew.nameCur, " ");
		for (int j = 0; j < array.Length; j++)
		{
			if (j <= array.Length / 2)
			{
				string[] array2 = MainTabNew.namePaint;
				int num = 0;
				array2[num] += array[j];
				if (j < array.Length / 2)
				{
					string[] array3 = MainTabNew.namePaint;
					int num2 = 0;
					array3[num2] += " ";
				}
			}
			else
			{
				string[] array4 = MainTabNew.namePaint;
				int num3 = 1;
				array4[num3] += array[j];
				if (j < array.Length - 1)
				{
					string[] array5 = MainTabNew.namePaint;
					int num4 = 1;
					array5[num4] += " ";
				}
			}
		}
	}

	// Token: 0x06000735 RID: 1845 RVA: 0x0006EE38 File Offset: 0x0006D038
	public static mFont setTextColor(int id)
	{
		int num = id;
		if (id >= 20 && id < 30)
		{
			num = id - 20;
		}
		else if (id >= 30 && id < 40)
		{
			num = id - 30;
		}
		else if (id >= 40 && id < 50)
		{
			num = id - 40;
		}
		switch (num)
		{
		case 0:
			return mFont.tahoma_7_white;
		case 1:
			return mFont.tahoma_7_blue;
		case 2:
			return mFont.tahoma_7_yellow;
		case 3:
			return mFont.tahoma_7_violet;
		case 4:
			return mFont.tahoma_7_orange;
		case 5:
			return mFont.tahoma_7_green;
		case 6:
			return mFont.tahoma_7_red;
		case 7:
			return mFont.tahoma_7_black;
		case 8:
			return mFont.tahoma_7_gray;
		default:
			return mFont.tahoma_7_white;
		}
	}

	// Token: 0x06000736 RID: 1846 RVA: 0x0006EEFC File Offset: 0x0006D0FC
	public static mFont setTextColorName(int id)
	{
		int num = id;
		if (id >= 20 && id < 30)
		{
			num = id - 20;
		}
		else if (id >= 30 && id < 40)
		{
			num = id - 30;
		}
		else if (id >= 40 && id < 50)
		{
			num = id - 40;
		}
		switch (num)
		{
		case 0:
			return mFont.tahoma_7b_white;
		case 1:
			return mFont.tahoma_7b_blue;
		case 2:
			return mFont.tahoma_7b_yellow;
		case 3:
			return mFont.tahoma_7b_violet;
		case 4:
			return mFont.tahoma_7b_orange;
		case 5:
			return mFont.tahoma_7b_green;
		case 7:
			return mFont.tahoma_7b_black;
		case 8:
			return mFont.tahoma_7_gray;
		}
		return mFont.tahoma_7b_white;
	}

	// Token: 0x06000737 RID: 1847 RVA: 0x0006EFBC File Offset: 0x0006D1BC
	public virtual void setPaintInfo()
	{
	}

	// Token: 0x06000738 RID: 1848 RVA: 0x0006EFC0 File Offset: 0x0006D1C0
	public virtual void setYCon(Item item)
	{
	}

	// Token: 0x06000739 RID: 1849 RVA: 0x0006EFC4 File Offset: 0x0006D1C4
	public void setinfoContennew(int id, int index)
	{
		InfocontenNew o = new InfocontenNew(id, index);
		this.moreInfoconten.addElement(o);
	}

	// Token: 0x0600073A RID: 1850 RVA: 0x0006EFE8 File Offset: 0x0006D1E8
	public void setPosCmd(mVector vecListCmd)
	{
		if (vecListCmd == null)
		{
			return;
		}
		int num = vecListCmd.size();
		if (num == 0)
		{
			return;
		}
		int num2 = MainTabNew.ylongwidth + this.hSmall;
		int num3 = MainTabNew.xlongwidth;
		if (num == 1)
		{
			iCommand iCommand = (iCommand)vecListCmd.elementAt(0);
			if (MainTabNew.is320)
			{
				iCommand.setPos(num3 + MainTabNew.longwidth / 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand.caption);
			}
			else
			{
				iCommand.setPos(num3 + MainTabNew.longwidth / 2, num2 - 15, null, iCommand.caption);
			}
		}
		else if (num == 2)
		{
			iCommand iCommand2 = (iCommand)vecListCmd.elementAt(0);
			if (MainTabNew.is320)
			{
				iCommand2.setPos(num3 + MainTabNew.longwidth / 4, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand2.caption);
			}
			else
			{
				iCommand2.setPos(num3 + MainTabNew.longwidth / 4, num2 - 15, null, iCommand2.caption);
			}
			iCommand iCommand3 = (iCommand)vecListCmd.elementAt(1);
			if (MainTabNew.is320)
			{
				iCommand3.setPos(num3 + MainTabNew.longwidth / 4 * 3 + 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand3.caption);
			}
			else
			{
				iCommand3.setPos(num3 + MainTabNew.longwidth / 4 * 3 + 2, num2 - 15, null, iCommand3.caption);
			}
		}
		else
		{
			for (int i = 0; i < num; i++)
			{
				iCommand iCommand4 = (iCommand)vecListCmd.elementAt(i);
				if (i == num - 1 && num % 2 == 1)
				{
					if (MainTabNew.is320)
					{
						iCommand4.setPos(num3 + MainTabNew.longwidth / 2, num2 - 10, PaintInfoGameScreen.fraButton2, iCommand4.caption);
					}
					else
					{
						iCommand4.setPos(num3 + MainTabNew.longwidth / 2, num2 - 15 - (num - 1) / 2 * 30 + i / 2 * 30, null, iCommand4.caption);
					}
				}
				else if (MainTabNew.is320)
				{
					iCommand4.setPos(num3 + MainTabNew.longwidth / 4 + i % 2 * (MainTabNew.longwidth / 2 + 2), num2 - 10 - (num - 1) / 2 * 22 + i / 2 * 22, PaintInfoGameScreen.fraButton2, iCommand4.caption);
				}
				else
				{
					iCommand4.setPos(num3 + MainTabNew.longwidth / 4 + i % 2 * (MainTabNew.longwidth / 2 + 2), num2 - 15 - (num - 1) / 2 * 30 + i / 2 * 30, null, iCommand4.caption);
				}
			}
		}
	}

	// Token: 0x04000A97 RID: 2711
	public const sbyte COLOR_WHITE = 0;

	// Token: 0x04000A98 RID: 2712
	public const sbyte COLOR_BLUE = 1;

	// Token: 0x04000A99 RID: 2713
	public const sbyte COLOR_YELLOW = 2;

	// Token: 0x04000A9A RID: 2714
	public const sbyte COLOR_VIOLET = 3;

	// Token: 0x04000A9B RID: 2715
	public const sbyte COLOR_ORANGE = 4;

	// Token: 0x04000A9C RID: 2716
	public const sbyte COLOR_GREEN = 5;

	// Token: 0x04000A9D RID: 2717
	public const sbyte COLOR_RED = 6;

	// Token: 0x04000A9E RID: 2718
	public const sbyte COLOR_BLACK = 7;

	// Token: 0x04000A9F RID: 2719
	public const sbyte COLOR_GREY = 8;

	// Token: 0x04000AA0 RID: 2720
	public sbyte typeTab;

	// Token: 0x04000AA1 RID: 2721
	public static sbyte maxTypeTab = 13;

	// Token: 0x04000AA2 RID: 2722
	public static sbyte INVENTORY = 0;

	// Token: 0x04000AA3 RID: 2723
	public static sbyte EQUIP = 1;

	// Token: 0x04000AA4 RID: 2724
	public static sbyte MY_INFO = 2;

	// Token: 0x04000AA5 RID: 2725
	public static sbyte SKILLS = 3;

	// Token: 0x04000AA6 RID: 2726
	public static sbyte QUEST = 4;

	// Token: 0x04000AA7 RID: 2727
	public static sbyte CHAT = 5;

	// Token: 0x04000AA8 RID: 2728
	public static sbyte GOLD = 6;

	// Token: 0x04000AA9 RID: 2729
	public static sbyte CONFIG = 7;

	// Token: 0x04000AAA RID: 2730
	public static sbyte SHOP = 8;

	// Token: 0x04000AAB RID: 2731
	public static sbyte CHEST = 9;

	// Token: 0x04000AAC RID: 2732
	public static sbyte REBUILD = 10;

	// Token: 0x04000AAD RID: 2733
	public static sbyte FUNCTION = 11;

	// Token: 0x04000AAE RID: 2734
	public static sbyte CLAN_INVENTORY = 12;

	// Token: 0x04000AAF RID: 2735
	public static sbyte PET_KEEPER = 13;

	// Token: 0x04000AB0 RID: 2736
	public static sbyte IMFO_VANTIEU = 14;

	// Token: 0x04000AB1 RID: 2737
	public static sbyte SELLITEM = 15;

	// Token: 0x04000AB2 RID: 2738
	public static sbyte INVEN_AND_STORE = 16;

	// Token: 0x04000AB3 RID: 2739
	public static sbyte OTHER_PLAYER_STORE = 17;

	// Token: 0x04000AB4 RID: 2740
	public int xTab;

	// Token: 0x04000AB5 RID: 2741
	public int yTab;

	// Token: 0x04000AB6 RID: 2742
	public int wSmall;

	// Token: 0x04000AB7 RID: 2743
	public int hSmall;

	// Token: 0x04000AB8 RID: 2744
	public int numWSmall;

	// Token: 0x04000AB9 RID: 2745
	public int numHSmall;

	// Token: 0x04000ABA RID: 2746
	public int xMoney;

	// Token: 0x04000ABB RID: 2747
	public int yMoney;

	// Token: 0x04000ABC RID: 2748
	public int xChar;

	// Token: 0x04000ABD RID: 2749
	public int yChar;

	// Token: 0x04000ABE RID: 2750
	public int sizeFocus;

	// Token: 0x04000ABF RID: 2751
	public int numWBlack;

	// Token: 0x04000AC0 RID: 2752
	public int numHBlack;

	// Token: 0x04000AC1 RID: 2753
	public static int wbackground;

	// Token: 0x04000AC2 RID: 2754
	public static int hbackground;

	// Token: 0x04000AC3 RID: 2755
	public bool isClan;

	// Token: 0x04000AC4 RID: 2756
	public bool isPet;

	// Token: 0x04000AC5 RID: 2757
	public static int wblack;

	// Token: 0x04000AC6 RID: 2758
	public static int hblack;

	// Token: 0x04000AC7 RID: 2759
	public static int hMaxContent;

	// Token: 0x04000AC8 RID: 2760
	public int xBegin;

	// Token: 0x04000AC9 RID: 2761
	public int yBegin;

	// Token: 0x04000ACA RID: 2762
	public string nameTab = string.Empty;

	// Token: 0x04000ACB RID: 2763
	public static sbyte wOneItem = 20;

	// Token: 0x04000ACC RID: 2764
	public static sbyte wOne5;

	// Token: 0x04000ACD RID: 2765
	public static sbyte Focus = 0;

	// Token: 0x04000ACE RID: 2766
	public static sbyte TAB = 0;

	// Token: 0x04000ACF RID: 2767
	public static sbyte INFO = 1;

	// Token: 0x04000AD0 RID: 2768
	public static mImage[] imgTab = new mImage[15];

	// Token: 0x04000AD1 RID: 2769
	public static mImage img_skIcn;

	// Token: 0x04000AD2 RID: 2770
	public static mImage img_pkIcn;

	// Token: 0x04000AD3 RID: 2771
	public static mImage img_arenaIcn;

	// Token: 0x04000AD4 RID: 2772
	public static MainTabNew instance;

	// Token: 0x04000AD5 RID: 2773
	public iCommand cmdBack;

	// Token: 0x04000AD6 RID: 2774
	public static int longwidth = 0;

	// Token: 0x04000AD7 RID: 2775
	public static int xlongwidth;

	// Token: 0x04000AD8 RID: 2776
	public static int ylongwidth;

	// Token: 0x04000AD9 RID: 2777
	public static int timeRequest = 15;

	// Token: 0x04000ADA RID: 2778
	public ListNew listContent;

	// Token: 0x04000ADB RID: 2779
	public static bool is320 = false;

	// Token: 0x04000ADC RID: 2780
	public mImage imgStarRebuild;

	// Token: 0x04000ADD RID: 2781
	public bool isTabHopNguyenLieu;

	// Token: 0x04000ADE RID: 2782
	public iCommand cmd;

	// Token: 0x04000ADF RID: 2783
	public bool isCreate_medal;

	// Token: 0x04000AE0 RID: 2784
	public bool isUPgradeMedal;

	// Token: 0x04000AE1 RID: 2785
	public static int[] colorLow = new int[]
	{
		14075822,
		10259575,
		7365460,
		8944231,
		4932409
	};

	// Token: 0x04000AE2 RID: 2786
	public new static int[] color = new int[]
	{
		11049346,
		12233362,
		16300104,
		15461355,
		10917760,
		13088156,
		11969934,
		7365460,
		14931390,
		11509641,
		16316584
	};

	// Token: 0x04000AE3 RID: 2787
	public int xpos_cmd;

	// Token: 0x04000AE4 RID: 2788
	public int ypos_cmd;

	// Token: 0x04000AE5 RID: 2789
	private static string nameCur = string.Empty;

	// Token: 0x04000AE6 RID: 2790
	private static string[] namePaint = new string[2];

	// Token: 0x04000AE7 RID: 2791
	public static int timePaintInfo;

	// Token: 0x04000AE8 RID: 2792
	public string[] mContent;

	// Token: 0x04000AE9 RID: 2793
	public string[] mSubContent;

	// Token: 0x04000AEA RID: 2794
	public string[] mPlusContent;

	// Token: 0x04000AEB RID: 2795
	public int[] mcolor;

	// Token: 0x04000AEC RID: 2796
	public int[] mSubColor;

	// Token: 0x04000AED RID: 2797
	public int[] mPlusColor;

	// Token: 0x04000AEE RID: 2798
	public string name;

	// Token: 0x04000AEF RID: 2799
	public int wContent;

	// Token: 0x04000AF0 RID: 2800
	public int colorName;

	// Token: 0x04000AF1 RID: 2801
	public int xCon;

	// Token: 0x04000AF2 RID: 2802
	public int yCon;

	// Token: 0x04000AF3 RID: 2803
	public mVector moreInfoconten = new mVector("MainTabNew moreInfoconten");
}
