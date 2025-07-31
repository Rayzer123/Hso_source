using System;

// Token: 0x020000B3 RID: 179
public class AvMain
{
	// Token: 0x060008D2 RID: 2258 RVA: 0x00093864 File Offset: 0x00091A64
	public virtual void paint(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (GameCanvas.currentDialog == null && !GameCanvas.menu2.isShowMenu)
		{
			this.paintCmd(g);
		}
	}

	// Token: 0x060008D3 RID: 2259 RVA: 0x00093898 File Offset: 0x00091A98
	public virtual void update()
	{
	}

	// Token: 0x060008D4 RID: 2260 RVA: 0x0009389C File Offset: 0x00091A9C
	public virtual void keypress(int keyCode)
	{
	}

	// Token: 0x060008D5 RID: 2261 RVA: 0x000938A0 File Offset: 0x00091AA0
	public virtual void commandPointer(int index, object obj)
	{
	}

	// Token: 0x060008D6 RID: 2262 RVA: 0x000938A4 File Offset: 0x00091AA4
	public void paintCmd(mGraphics g)
	{
		if (GameCanvas.isSmallScreen)
		{
			this.paintCmdSmall(g);
		}
		else
		{
			if (this.left != null)
			{
				this.left.paint(g, GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
			}
			if (this.right != null)
			{
				this.right.paint(g, GameCanvas.w - GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
			}
			if (this.center != null)
			{
				this.center.paint(g, GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
			}
		}
	}

	// Token: 0x060008D7 RID: 2263 RVA: 0x00093950 File Offset: 0x00091B50
	public void paintCmd_OnlyText(mGraphics g)
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		if (GameCanvas.isSmallScreen)
		{
			this.paintCmd_OnlyText_Small(g);
		}
		else
		{
			if (this.left != null)
			{
				AvMain.Font3dWhite(g, this.left.caption, 30, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
			}
			if (this.right != null)
			{
				AvMain.Font3dWhite(g, this.right.caption, GameCanvas.w - 30, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
			}
			if (this.center != null)
			{
				AvMain.Font3dWhite(g, this.center.caption, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
			}
		}
	}

	// Token: 0x060008D8 RID: 2264 RVA: 0x00093A28 File Offset: 0x00091C28
	public void paintCmdSmall(mGraphics g)
	{
		GameCanvas.resetTrans(g);
		if (this.left != null)
		{
			this.left.paint(g, GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (this.right != null)
		{
			this.right.paint(g, GameCanvas.w - GameCanvas.wCommand, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
		if (this.center != null)
		{
			this.center.paint(g, GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd / 2 - 1);
		}
	}

	// Token: 0x060008D9 RID: 2265 RVA: 0x00093AC4 File Offset: 0x00091CC4
	public void paintCmd_OnlyText_Small(mGraphics g)
	{
		if (this.left != null)
		{
			mFont.tahoma_7b_white.drawString(g, this.left.caption, 27, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
		if (this.right != null)
		{
			mFont.tahoma_7b_white.drawString(g, this.right.caption, GameCanvas.w - 27, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
		if (this.center != null)
		{
			mFont.tahoma_7b_white.drawString(g, this.center.caption, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 + 1, 2, mGraphics.isFalse);
		}
	}

	// Token: 0x060008DA RID: 2266 RVA: 0x00093B84 File Offset: 0x00091D84
	public virtual void commandTab(int index, int subIndex)
	{
	}

	// Token: 0x060008DB RID: 2267 RVA: 0x00093B88 File Offset: 0x00091D88
	public virtual void commandMenu(int index, int subIndex)
	{
	}

	// Token: 0x060008DC RID: 2268 RVA: 0x00093B8C File Offset: 0x00091D8C
	public virtual void commandPointer(int index, int subIndex)
	{
	}

	// Token: 0x060008DD RID: 2269 RVA: 0x00093B90 File Offset: 0x00091D90
	public void paintRect(mGraphics g, int x, int y, int w, int h, bool isSelect)
	{
		g.setColor(0);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(1073997);
		if (isSelect)
		{
			g.setColor(16777215);
		}
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	// Token: 0x060008DE RID: 2270 RVA: 0x00093BEC File Offset: 0x00091DEC
	public void paintRect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(0);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(1073997);
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	// Token: 0x060008DF RID: 2271 RVA: 0x00093C38 File Offset: 0x00091E38
	public void paintRect(mGraphics g, int x, int y, int w, int h, int color, int color2)
	{
		g.setColor(color);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
		g.setColor(color2);
		g.fillRect(x + 2, y + 2, w - 4, h - 4, mGraphics.isFalse);
	}

	// Token: 0x060008E0 RID: 2272 RVA: 0x00093C80 File Offset: 0x00091E80
	public static void paintDialog(mGraphics g, int xDia, int yDia, int wDia, int hDia, int Indexcolor)
	{
		if (wDia < 35)
		{
			wDia = 35;
		}
		int num = (wDia - 6) / 32;
		int num2 = (hDia - 6) / 32;
		if (hDia % 2 != 0)
		{
			hDia++;
		}
		if (hDia < 32)
		{
			for (int i = 0; i <= num; i++)
			{
				for (int j = 0; j <= num2; j++)
				{
					if (i == num)
					{
						if (j == num2)
						{
							g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia - 3 + wDia - 32, yDia, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia - 3 + wDia - 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
						}
					}
					else if (j == num2)
					{
						g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia + 3 + i * 32, yDia, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawRegion(MainTabNew.imgTab[Indexcolor], 0, 0, 32, hDia, 0, xDia + 3 + i * 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
					}
				}
			}
		}
		else
		{
			for (int k = 0; k <= num; k++)
			{
				for (int l = 0; l <= num2; l++)
				{
					if (k == num)
					{
						if (l == num2)
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia + 3 + 32 * l, 0, mGraphics.isFalse);
						}
					}
					else if (l == num2)
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + k * 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + k * 32, yDia + 3 + 32 * l, 0, mGraphics.isFalse);
					}
				}
			}
		}
		g.drawRegion(AvMain.imgPopup, 0, 0, 5, 5, 0, xDia, yDia, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgPopup, 0, 5, 5, 5, 0, xDia + wDia - 5, yDia, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgPopup, 0, 15, 5, 5, 0, xDia, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.imgPopup, 0, 10, 5, 5, 0, xDia + wDia - 5, yDia + hDia - 5, 0, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[0]);
		g.fillRect(xDia + 3, yDia, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[1]);
		g.fillRect(xDia + 3, yDia + 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[2]);
		g.fillRect(xDia + 3, yDia + 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[2]);
		g.fillRect(xDia + 3, yDia + hDia - 1, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[4]);
		g.fillRect(xDia + 3, yDia + hDia - 2, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		g.setColor(AvMain.colorDia[0]);
		g.fillRect(xDia + 3, yDia + hDia - 3, wDia - 6, 1, mGraphics.isFalse);
		g.fillRect(xDia + wDia - 3, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
	}

	// Token: 0x060008E1 RID: 2273 RVA: 0x00094064 File Offset: 0x00092264
	public static void paintDialogNew(mGraphics g, int xDia, int yDia, int wDia, int hDia, int Indexcolor)
	{
		if (GameCanvas.lowGraphic)
		{
			AvMain.paintDialog(g, xDia, yDia, wDia, hDia, Indexcolor);
		}
		else
		{
			int num = (wDia - 6) / 32;
			int num2 = (hDia - 6) / 32;
			if (hDia % 2 != 0)
			{
				hDia++;
			}
			for (int i = 0; i <= num; i++)
			{
				for (int j = 0; j <= num2; j++)
				{
					if (j <= 1 || j >= num2 - 1 || i == 0 || i == num)
					{
						if (i == num)
						{
							if (j == num2)
							{
								g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
							}
							else
							{
								g.drawImage(MainTabNew.imgTab[Indexcolor], xDia - 3 + wDia - 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
							}
						}
						else if (j == num2)
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + i * 32, yDia - 3 + hDia - 32, 0, mGraphics.isFalse);
						}
						else
						{
							g.drawImage(MainTabNew.imgTab[Indexcolor], xDia + 3 + i * 32, yDia + 3 + 32 * j, 0, mGraphics.isFalse);
						}
					}
				}
			}
			g.drawRegion(AvMain.imgPopup, 0, 0, 5, 5, 0, xDia, yDia, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgPopup, 0, 5, 5, 5, 0, xDia + wDia - 5, yDia, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgPopup, 0, 15, 5, 5, 0, xDia, yDia + hDia - 5, 0, mGraphics.isFalse);
			g.drawRegion(AvMain.imgPopup, 0, 10, 5, 5, 0, xDia + wDia - 5, yDia + hDia - 5, 0, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[0]);
			g.fillRect(xDia + 3, yDia, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[1]);
			g.fillRect(xDia + 3, yDia + 1, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia + 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[2]);
			g.fillRect(xDia + 3, yDia + 2, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia + 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[2]);
			g.fillRect(xDia + 3, yDia + hDia - 1, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia + wDia - 1, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[4]);
			g.fillRect(xDia + 3, yDia + hDia - 2, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia + wDia - 2, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
			g.setColor(AvMain.colorDia[0]);
			g.fillRect(xDia + 3, yDia + hDia - 3, wDia - 6, 1, mGraphics.isFalse);
			g.fillRect(xDia + wDia - 3, yDia + 3, 1, hDia - 6, mGraphics.isFalse);
		}
	}

	// Token: 0x060008E2 RID: 2274 RVA: 0x00094374 File Offset: 0x00092574
	public static void paintTabNew(mGraphics g, int xTab, int yTab, int wTab, int hTab, bool ismore, sbyte colorBack)
	{
		if (hTab < 32)
		{
			hTab = 32;
		}
		g.setColor(AvMain.color[0]);
		g.fillRect(xTab + AvMain.wimg - 2, yTab + 3, wTab - 2 * AvMain.wimg + 4, hTab - 5, mGraphics.isFalse);
		g.fillRect(xTab + 4, yTab + AvMain.wimg - 2, wTab - 8, hTab - 2 * AvMain.wimg + 4, mGraphics.isFalse);
		g.setColor(AvMain.color[1]);
		g.fillRect(xTab + AvMain.wimg - 2, yTab + 4, wTab - 2 * AvMain.wimg + 4, hTab - 7, mGraphics.isFalse);
		g.fillRect(xTab + 5, yTab + AvMain.wimg - 2, wTab - 10, hTab - 2 * AvMain.wimg + 4, mGraphics.isFalse);
		g.setColor(AvMain.color[0]);
		g.fillRect(xTab + AvMain.wimg - 2, yTab + 5, wTab - 2 * AvMain.wimg + 4, hTab - 9, mGraphics.isFalse);
		g.fillRect(xTab + 6, yTab + AvMain.wimg - 2, wTab - 12, hTab - 2 * AvMain.wimg + 4, mGraphics.isFalse);
		g.setColor(AvMain.color[2]);
		g.fillRect(xTab + 7, yTab + 6, wTab - 14, hTab - 12, mGraphics.isFalse);
		for (int i = 0; i <= (wTab - 15) / 32; i++)
		{
			for (int j = 0; j <= (hTab - 11) / 32; j++)
			{
				if (i == (wTab - 15) / 32)
				{
					if (j == (hTab - 11) / 32)
					{
						g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + wTab - 39, yTab + hTab - 37, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + wTab - 39, yTab + 7 + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == (hTab - 11) / 32)
				{
					g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + 8 + i * 32, yTab + hTab - 37, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + 8 + i * 32, yTab + 7 + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
		g.drawImage(AvMain.tab[0], xTab, yTab, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.tab[0], 0, 0, AvMain.wimg, AvMain.wimg, 2, xTab + wTab - AvMain.wimg, yTab, 0, mGraphics.isFalse);
		g.drawImage(AvMain.tab[1], xTab + 2, yTab + hTab - AvMain.wimg, 0, mGraphics.isFalse);
		g.drawRegion(AvMain.tab[1], 0, 0, 30, 30, 2, xTab + wTab - 32, yTab + hTab - AvMain.wimg, 0, mGraphics.isFalse);
		if (ismore)
		{
			g.drawImage(AvMain.tab[2], xTab + wTab / 2, yTab + 2, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060008E3 RID: 2275 RVA: 0x00094668 File Offset: 0x00092868
	public static void paintRectNice(mGraphics g, int xTab, int yTab, int wTab, int hTab, sbyte colorBack)
	{
		for (int i = 0; i <= wTab / 32; i++)
		{
			for (int j = 0; j <= hTab / 32; j++)
			{
				if (i == wTab / 32)
				{
					if (j == hTab / 32)
					{
						g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + wTab - 32, yTab + hTab - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + wTab - 32, yTab + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == hTab / 32)
				{
					g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + i * 32, yTab + hTab - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[(int)colorBack], xTab + i * 32, yTab + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x060008E4 RID: 2276 RVA: 0x00094758 File Offset: 0x00092958
	public static void fill(int x, int y, int w, int h, int color, mGraphics g)
	{
		g.setColor(color);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	// Token: 0x060008E5 RID: 2277 RVA: 0x00094780 File Offset: 0x00092980
	public static void paintRectText(mGraphics g, int xText, int yText, int wText, int hText, bool isFocus)
	{
		g.setColor(12621920);
		if (isFocus)
		{
			g.setColor(16644568);
		}
		g.drawRegion(AvMain.imgtextfield, 0, (!isFocus) ? 0 : 30, 4, 15, 0, xText, yText, 0, mGraphics.isTrue);
		g.drawRegion(AvMain.imgtextfield, 0, ((!isFocus) ? 0 : 30) + 15, 4, 15, 0, xText + wText - 4, yText + hText - 15, 0, mGraphics.isTrue);
		g.drawRegion(AvMain.imgtextfield, 0, ((!isFocus) ? 0 : 30) + 11, 4, 4, 0, xText, yText + hText - 4, 0, mGraphics.isTrue);
		g.drawRegion(AvMain.imgtextfield, 0, ((!isFocus) ? 0 : 30) + 15, 4, 4, 0, xText + wText - 4, yText, 0, mGraphics.isTrue);
		g.fillRect(xText + 4, yText, wText - 8, hText, mGraphics.isTrue);
		g.fillRect(xText, yText + 4, wText, hText - 8, mGraphics.isTrue);
	}

	// Token: 0x060008E6 RID: 2278 RVA: 0x00094888 File Offset: 0x00092A88
	public void paintSelect(mGraphics g, int x, int y, int w, int h)
	{
		g.setColor(AvMain.SELECTED_COLOR);
		g.fillRect(x, y, w, h, mGraphics.isFalse);
	}

	// Token: 0x060008E7 RID: 2279 RVA: 0x000948B4 File Offset: 0x00092AB4
	public void paintFormList(mGraphics g, int x, int y, int w, int h, string name)
	{
		AvMain.paintDialogNew(g, x - 6, y - 6, w + 12, h + 12, 0);
		AvMain.paintRectNice(g, x, y + GameCanvas.hCommand, w, h - GameCanvas.hCommand, 2);
		MainTabNew.paintNameItem(g, x + w / 2, y + GameCanvas.hCommand / 4, w, name, 7);
	}

	// Token: 0x060008E8 RID: 2280 RVA: 0x0009490C File Offset: 0x00092B0C
	public int resetSelect(int select, int max, bool isreset)
	{
		if (select < 0)
		{
			if (isreset)
			{
				select = max;
			}
			else
			{
				select = 0;
			}
		}
		else if (select > max)
		{
			if (isreset)
			{
				select = 0;
			}
			else
			{
				select = max;
			}
		}
		return select;
	}

	// Token: 0x060008E9 RID: 2281 RVA: 0x00094950 File Offset: 0x00092B50
	public virtual void updatekey()
	{
		if (GameCanvas.keyMyHold[(!Main.isPC) ? 5 : 36] || GameCanvas.keyMyHold[36])
		{
			if (this.center != null)
			{
				GameCanvas.clearKeyPressed(5);
				GameCanvas.clearKeyHold(5);
				GameCanvas.clearKeyPressed(36);
				GameCanvas.clearKeyHold(36);
				Cout.LogError2(" No ");
				this.center.perform();
			}
		}
		else if (GameCanvas.keyMyHold[12])
		{
			if (this.left != null)
			{
				Cout.LogError2(" 222222222222222222 ");
				GameCanvas.clearKeyPressed(12);
				GameCanvas.clearKeyHold(12);
				this.left.perform();
			}
		}
		else if (GameCanvas.keyMyHold[13] && this.right != null)
		{
			GameCanvas.clearKeyPressed(13);
			GameCanvas.clearKeyHold(13);
			this.right.perform();
		}
	}

	// Token: 0x060008EA RID: 2282 RVA: 0x00094A38 File Offset: 0x00092C38
	public virtual void updatePointer()
	{
		if (GameCanvas.isTouch)
		{
			if (this.left != null)
			{
				if (this.left.isPosCmd())
				{
					this.left.updatePointer();
				}
				else if (!this.left.isNotShowTab && GameCanvas.isPointSelect(0, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
				{
					this.left.perform();
				}
			}
			if (this.right != null)
			{
				if (this.right.isPosCmd())
				{
					this.right.updatePointer();
				}
				else if (GameCanvas.isPointSelect(GameCanvas.w - GameCanvas.wCommand * 2, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
				{
					this.right.perform();
				}
			}
			if (this.center != null)
			{
				if (this.center.isPosCmd())
				{
					this.center.updatePointer();
				}
				else if (GameCanvas.isPointSelect(GameCanvas.hw - GameCanvas.wCommand, GameCanvas.h - GameCanvas.hCommand - 5, GameCanvas.wCommand * 2, GameCanvas.hCommand + 10))
				{
					this.center.perform();
				}
			}
		}
	}

	// Token: 0x060008EB RID: 2283 RVA: 0x00094B8C File Offset: 0x00092D8C
	public static void Font3dWhite(mGraphics g, string str, int x, int y, int ar)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		mFont.tahoma_7b_white.drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	// Token: 0x060008EC RID: 2284 RVA: 0x00094BC8 File Offset: 0x00092DC8
	public static void Font3dColor(mGraphics g, string str, int x, int y, int ar, sbyte color)
	{
		mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		MainTabNew.setTextColorName((int)color).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	// Token: 0x060008ED RID: 2285 RVA: 0x00094C08 File Offset: 0x00092E08
	public static void Font3dColorAndColor(mGraphics g, string str, int x, int y, int ar, sbyte color, sbyte color2)
	{
		MainTabNew.setTextColorName((int)color).drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		MainTabNew.setTextColorName((int)color2).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	// Token: 0x060008EE RID: 2286 RVA: 0x00094C4C File Offset: 0x00092E4C
	public static void FontBorderColor(mGraphics g, string str, int x, int y, int ar, int color)
	{
		if (color == 2)
		{
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
		}
		else
		{
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y + 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y + 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x - 1, y, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x + 1, y, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x, y - 1, ar, mGraphics.isTrue);
			mFont.tahoma_7b_black.drawString(g, str, x, y + 1, ar, mGraphics.isTrue);
		}
		MainTabNew.setTextColorName(color).drawString(g, str, x, y, ar, mGraphics.isTrue);
	}

	// Token: 0x060008EF RID: 2287 RVA: 0x00094D58 File Offset: 0x00092F58
	public virtual void loadBegin()
	{
	}

	// Token: 0x04000DC8 RID: 3528
	public iCommand left;

	// Token: 0x04000DC9 RID: 3529
	public iCommand right;

	// Token: 0x04000DCA RID: 3530
	public iCommand center;

	// Token: 0x04000DCB RID: 3531
	public static mImage[] tab = new mImage[4];

	// Token: 0x04000DCC RID: 3532
	public static int wimg;

	// Token: 0x04000DCD RID: 3533
	public static mImage[] imghitScr = new mImage[3];

	// Token: 0x04000DCE RID: 3534
	public static mImage imgtextfield;

	// Token: 0x04000DCF RID: 3535
	public static mImage imgInfo;

	// Token: 0x04000DD0 RID: 3536
	public static mImage imghpmp;

	// Token: 0x04000DD1 RID: 3537
	public static mImage imgcolorhpmp;

	// Token: 0x04000DD2 RID: 3538
	public static mImage imgPopup;

	// Token: 0x04000DD3 RID: 3539
	public static mImage imgBackInfo;

	// Token: 0x04000DD4 RID: 3540
	public static mImage imgWorldMap;

	// Token: 0x04000DD5 RID: 3541
	public static mImage imgSelect;

	// Token: 0x04000DD6 RID: 3542
	public static mImage imgFocusMap;

	// Token: 0x04000DD7 RID: 3543
	public static mImage imgDelaySkill;

	// Token: 0x04000DD8 RID: 3544
	public static mImage imgLoadImg;

	// Token: 0x04000DD9 RID: 3545
	public static mImage imgEyeDie;

	// Token: 0x04000DDA RID: 3546
	public static mImage imgHotKey;

	// Token: 0x04000DDB RID: 3547
	public static mImage imgHotKey2;

	// Token: 0x04000DDC RID: 3548
	public static mImage imgMess;

	// Token: 0x04000DDD RID: 3549
	public static mImage imgColorItem;

	// Token: 0x04000DDE RID: 3550
	public static mImage imgicongt;

	// Token: 0x04000DDF RID: 3551
	public static mImage imgGlass;

	// Token: 0x04000DE0 RID: 3552
	public static mImage imgLock;

	// Token: 0x04000DE1 RID: 3553
	public static mImage imgRect;

	// Token: 0x04000DE2 RID: 3554
	public static mImage imgSelect_1;

	// Token: 0x04000DE3 RID: 3555
	public static mImage imgcolorhpmp_back;

	// Token: 0x04000DE4 RID: 3556
	public static mImage imgcolorhpSmall_back;

	// Token: 0x04000DE5 RID: 3557
	public static mImage imgcolorhpSmall;

	// Token: 0x04000DE6 RID: 3558
	public static mImage img18Plus;

	// Token: 0x04000DE7 RID: 3559
	public static FrameImage fraPlayerDie;

	// Token: 0x04000DE8 RID: 3560
	public static FrameImage fraObjMiniMap;

	// Token: 0x04000DE9 RID: 3561
	public static FrameImage fraPk;

	// Token: 0x04000DEA RID: 3562
	public static FrameImage fraStar;

	// Token: 0x04000DEB RID: 3563
	public static FrameImage fraQuest;

	// Token: 0x04000DEC RID: 3564
	public static FrameImage fraMonSample;

	// Token: 0x04000DED RID: 3565
	public static FrameImage fraDiamond;

	// Token: 0x04000DEE RID: 3566
	public static FrameImage fraPlayerNo;

	// Token: 0x04000DEF RID: 3567
	public static FrameImage imgStun;

	// Token: 0x04000DF0 RID: 3568
	public static FrameImage imgSleep;

	// Token: 0x04000DF1 RID: 3569
	public static FrameImage fraFogetPass;

	// Token: 0x04000DF2 RID: 3570
	public static mImage[] textf = new mImage[2];

	// Token: 0x04000DF3 RID: 3571
	public static int SELECTED_COLOR = 10259575;

	// Token: 0x04000DF4 RID: 3572
	public static FrameImage[] fraPkArr;

	// Token: 0x04000DF5 RID: 3573
	public static int[] color = new int[]
	{
		4724752,
		16300104,
		9998456,
		14733496,
		10127472
	};

	// Token: 0x04000DF6 RID: 3574
	private static int[] colorDia = new int[]
	{
		7875090,
		16316584,
		5309952,
		16300104,
		16300104
	};
}
