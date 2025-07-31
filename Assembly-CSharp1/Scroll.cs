using System;

// Token: 0x0200009C RID: 156
public class Scroll
{
	// Token: 0x06000787 RID: 1927 RVA: 0x00077104 File Offset: 0x00075304
	public void clear()
	{
		this.cmtoX = 0;
		this.cmtoY = 0;
		this.cmx = 0;
		this.cmy = 0;
		this.cmvx = 0;
		this.cmvy = 0;
		this.cmdx = 0;
		this.cmdy = 0;
		this.cmxLim = 0;
		this.cmyLim = 0;
		this.width = 0;
		this.height = 0;
	}

	// Token: 0x06000788 RID: 1928 RVA: 0x00077168 File Offset: 0x00075368
	public void setClip(mGraphics g, int x, int y, int w, int h)
	{
		g.setClip(x, y, w, h - 1);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(-this.cmx, -this.cmy);
	}

	// Token: 0x06000789 RID: 1929 RVA: 0x000771AC File Offset: 0x000753AC
	public void setClip(mGraphics g)
	{
		g.setClip(this.xPos + 1, this.yPos + 1, this.width - 2, this.height - 2);
		g.translate(-g.getTranslateX(), -g.getTranslateY());
		g.translate(-this.cmx, -this.cmy);
	}

	// Token: 0x0600078A RID: 1930 RVA: 0x00077208 File Offset: 0x00075408
	public ScrollResult updateKey()
	{
		if (this.styleUPDOWN)
		{
			return this.updateKeyScrollUpDown();
		}
		return this.updateKeyScrollLeftRight();
	}

	// Token: 0x0600078B RID: 1931 RVA: 0x00077224 File Offset: 0x00075424
	private ScrollResult updateKeyScrollUpDown()
	{
		int num = this.xPos;
		int num2 = this.yPos;
		int w = this.width;
		int num3 = this.height;
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(num, num2, w, num3))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.selectedItem = -1;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					if (this.ITEM_PER_LINE > 1)
					{
						int num4 = (this.cmtoY + GameCanvas.py - num2) / this.ITEM_SIZE;
						int num5 = (this.cmtoX + GameCanvas.px - num) / this.ITEM_SIZE;
						this.selectedItem = num4 * this.ITEM_PER_LINE + num5;
					}
					else
					{
						this.selectedItem = (this.cmtoY + GameCanvas.py - num2) / this.ITEM_SIZE;
					}
				}
				int num6 = GameCanvas.py - this.pointerDownLastX[0];
				if (num6 != 0 && this.selectedItem != -1)
				{
					this.selectedItem = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.py;
				this.cmtoY -= num6;
				if (this.cmtoY < 0)
				{
					this.cmtoY = 0;
				}
				if (this.cmtoY > this.cmyLim)
				{
					this.cmtoY = this.cmyLim;
				}
				if (this.cmy < 0 || this.cmy > this.cmyLim)
				{
					num6 /= 2;
				}
				this.cmy -= num6;
			}
		}
		bool isFinish = false;
		if (GameCanvas.isPointerRelease && this.pointerIsDowning)
		{
			int i2 = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerRelease = false;
			if (global::Math.abs(i2) < 20 && global::Math.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				this.cmtoY = this.cmy;
				this.pointerDownFirstX = -1000;
				if (this.ITEM_PER_LINE > 1)
				{
					int num7 = (this.cmtoY + GameCanvas.py - num2) / this.ITEM_SIZE;
					int num8 = (this.cmtoX + GameCanvas.px - num) / this.ITEM_SIZE;
					this.selectedItem = num7 * this.ITEM_PER_LINE + num8;
				}
				else
				{
					this.selectedItem = (this.cmtoY + GameCanvas.py - num2) / this.ITEM_SIZE;
				}
				this.pointerDownTime = 0;
				isFinish = true;
			}
			else if (this.selectedItem != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				isFinish = true;
			}
			else if (this.selectedItem == -1 && !this.isDownWhenRunning)
			{
				if (this.cmy < 0)
				{
					this.cmtoY = 0;
				}
				else if (this.cmy > this.cmyLim)
				{
					this.cmtoY = this.cmyLim;
				}
				else
				{
					int num9 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num9 > 10)
					{
						num9 = 10;
					}
					else if (num9 < -10)
					{
						num9 = -10;
					}
					else
					{
						num9 = 0;
					}
					this.cmRun = -num9 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerRelease = false;
		}
		return new ScrollResult
		{
			selected = this.selectedItem,
			isFinish = isFinish,
			isDowning = this.pointerIsDowning
		};
	}

	// Token: 0x0600078C RID: 1932 RVA: 0x0007767C File Offset: 0x0007587C
	private ScrollResult updateKeyScrollLeftRight()
	{
		int num = this.xPos;
		int num2 = this.yPos;
		int w = this.width;
		int num3 = this.height;
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(num, num2, w, num3))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.px;
				}
				this.pointerDownFirstX = GameCanvas.px;
				this.pointerIsDowning = true;
				this.selectedItem = -1;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					this.selectedItem = (this.cmtoX + GameCanvas.px - num) / this.ITEM_SIZE;
				}
				int num4 = GameCanvas.px - this.pointerDownLastX[0];
				if (num4 != 0 && this.selectedItem != -1)
				{
					this.selectedItem = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.px;
				this.cmtoX -= num4;
				if (this.cmtoX < 0)
				{
					this.cmtoX = 0;
				}
				if (this.cmtoX > this.cmxLim)
				{
					this.cmtoX = this.cmxLim;
				}
				if (this.cmx < 0 || this.cmx > this.cmxLim)
				{
					num4 /= 2;
				}
				this.cmx -= num4;
			}
		}
		bool isFinish = false;
		if (GameCanvas.isPointerRelease && this.pointerIsDowning)
		{
			int i2 = GameCanvas.px - this.pointerDownLastX[0];
			GameCanvas.isPointerRelease = false;
			if (global::Math.abs(i2) < 20 && global::Math.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.selectedItem = (this.cmtoX + GameCanvas.px - num) / this.ITEM_SIZE;
				this.pointerDownTime = 0;
				isFinish = true;
			}
			else if (this.selectedItem != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				isFinish = true;
			}
			else if (this.selectedItem == -1 && !this.isDownWhenRunning)
			{
				if (this.cmx < 0)
				{
					this.cmtoX = 0;
				}
				else if (this.cmx > this.cmxLim)
				{
					this.cmtoX = this.cmxLim;
				}
				else
				{
					int num5 = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num5 > 10)
					{
						num5 = 10;
					}
					else if (num5 < -10)
					{
						num5 = -10;
					}
					else
					{
						num5 = 0;
					}
					this.cmRun = -num5 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerRelease = false;
		}
		return new ScrollResult
		{
			selected = this.selectedItem,
			isFinish = isFinish,
			isDowning = this.pointerIsDowning
		};
	}

	// Token: 0x0600078D RID: 1933 RVA: 0x00077A30 File Offset: 0x00075C30
	public void updatecm()
	{
		int num = this.xPos;
		int num2 = this.yPos;
		int w = this.width;
		int num3 = this.height;
		if (GameCanvas.isPointer(num, num2, w, num3) && GameCanvas.isTouch && !this.FocusNew)
		{
			this.FocusNew = true;
		}
		if (this.cmRun != 0 && !this.pointerIsDowning)
		{
			if (this.styleUPDOWN)
			{
				this.cmtoY += this.cmRun / 100;
				if (this.cmtoY < 0)
				{
					this.cmtoY = 0;
				}
				else if (this.cmtoY > this.cmyLim)
				{
					this.cmtoY = this.cmyLim;
				}
				else
				{
					this.cmy = this.cmtoY;
				}
			}
			else
			{
				this.cmtoX += this.cmRun / 100;
				if (this.cmtoX < 0)
				{
					this.cmtoX = 0;
				}
				else if (this.cmtoX > this.cmxLim)
				{
					this.cmtoX = this.cmxLim;
				}
				else
				{
					this.cmx = this.cmtoX;
				}
			}
			this.cmRun = this.cmRun * 9 / 10;
			if (this.cmRun < 100 && this.cmRun > -100)
			{
				this.cmRun = 0;
			}
		}
		if (this.cmx != this.cmtoX && !this.pointerIsDowning)
		{
			this.cmvx = this.cmtoX - this.cmx << 2;
			this.cmdx += this.cmvx;
			this.cmx += this.cmdx >> 4;
			this.cmdx &= 15;
		}
		if (this.cmy != this.cmtoY && !this.pointerIsDowning)
		{
			this.cmvy = this.cmtoY - this.cmy << 2;
			this.cmdy += this.cmvy;
			this.cmy += this.cmdy >> 4;
			this.cmdy &= 15;
		}
	}

	// Token: 0x0600078E RID: 1934 RVA: 0x00077C64 File Offset: 0x00075E64
	public void setStyle(int nItem, int ITEM_SIZE, int xPos, int yPos, int width, int height, bool styleUPDOWN, int ITEM_PER_LINE)
	{
		this.xPos = xPos;
		this.yPos = yPos;
		this.ITEM_SIZE = ITEM_SIZE;
		this.nITEM = nItem;
		this.width = width;
		this.height = height;
		this.styleUPDOWN = styleUPDOWN;
		this.ITEM_PER_LINE = ITEM_PER_LINE;
		if (styleUPDOWN)
		{
			this.cmyLim = nItem * ITEM_SIZE - height;
		}
		else
		{
			this.cmxLim = nItem * ITEM_SIZE - width;
		}
		if (this.cmyLim < 0)
		{
			this.cmyLim = 0;
		}
		if (this.cmxLim < 0)
		{
			this.cmxLim = 0;
		}
	}

	// Token: 0x0600078F RID: 1935 RVA: 0x00077CF8 File Offset: 0x00075EF8
	public void moveTo(int to)
	{
		if (this.styleUPDOWN)
		{
			to -= (this.height - this.ITEM_SIZE * 2) / 2;
			this.cmtoY = to;
			if (this.cmtoY < 0)
			{
				this.cmtoY = 0;
			}
			if (this.cmtoY > this.cmyLim)
			{
				this.cmtoY = this.cmyLim;
			}
		}
		else
		{
			to -= (this.width - this.ITEM_SIZE) / 2;
			this.cmtoX = to;
			if (this.cmtoX < 0)
			{
				this.cmtoX = 0;
			}
			if (this.cmtoX > this.cmxLim)
			{
				this.cmtoX = this.cmxLim;
			}
		}
	}

	// Token: 0x06000790 RID: 1936 RVA: 0x00077DAC File Offset: 0x00075FAC
	public void moveCmrTo(int to)
	{
		if (to > 0)
		{
			this.cmtoY += this.ITEM_SIZE;
		}
		else if (to < 0)
		{
			this.cmtoY -= 20;
		}
		if (this.cmtoY < 0)
		{
			this.cmtoY = 0;
		}
		if (this.cmtoY > this.cmyLim)
		{
			this.cmtoY = this.cmyLim;
		}
	}

	// Token: 0x06000791 RID: 1937 RVA: 0x00077E20 File Offset: 0x00076020
	public static Scroll gI()
	{
		if (Scroll.me == null)
		{
			Scroll.me = new Scroll();
		}
		return Scroll.me;
	}

	// Token: 0x06000792 RID: 1938 RVA: 0x00077E3C File Offset: 0x0007603C
	public void setInfo(int x, int y, int h, int color)
	{
		this.x = x;
		this.y = y;
		this.h = h;
		this.color = color;
		this.hScroll = h - (int)MainTabNew.wOneItem;
	}

	// Token: 0x06000793 RID: 1939 RVA: 0x00077E6C File Offset: 0x0007606C
	public void paint(mGraphics g)
	{
		g.setColor(this.color);
		g.fillRect(this.x - 2, this.y - 1, 3, 1, mGraphics.isTrue);
		g.fillRect(this.x - 3, this.y, 1, this.h - 1, mGraphics.isTrue);
		g.fillRect(this.x + 1, this.y, 1, this.h - 1, mGraphics.isTrue);
		g.fillRect(this.x - 2, this.y + this.h - 1, 3, 1, mGraphics.isTrue);
		g.fillRect(this.x - 2, this.y + this.yScroll, 3, (int)MainTabNew.wOneItem, mGraphics.isTrue);
	}

	// Token: 0x06000794 RID: 1940 RVA: 0x00077F34 File Offset: 0x00076134
	public void setYScrool(int yS, int yMax)
	{
		this.yScroll = yS * this.hScroll / yMax;
	}

	// Token: 0x04000B84 RID: 2948
	private int x;

	// Token: 0x04000B85 RID: 2949
	private int y;

	// Token: 0x04000B86 RID: 2950
	private int h;

	// Token: 0x04000B87 RID: 2951
	private int color;

	// Token: 0x04000B88 RID: 2952
	private int yScroll;

	// Token: 0x04000B89 RID: 2953
	private int hScroll;

	// Token: 0x04000B8A RID: 2954
	public int cmtoX;

	// Token: 0x04000B8B RID: 2955
	public int cmtoY;

	// Token: 0x04000B8C RID: 2956
	public int cmx;

	// Token: 0x04000B8D RID: 2957
	public int cmy;

	// Token: 0x04000B8E RID: 2958
	public int cmvx;

	// Token: 0x04000B8F RID: 2959
	public int cmvy;

	// Token: 0x04000B90 RID: 2960
	public int cmdx;

	// Token: 0x04000B91 RID: 2961
	public int cmdy;

	// Token: 0x04000B92 RID: 2962
	public int xPos;

	// Token: 0x04000B93 RID: 2963
	public int yPos;

	// Token: 0x04000B94 RID: 2964
	public int width;

	// Token: 0x04000B95 RID: 2965
	public int height;

	// Token: 0x04000B96 RID: 2966
	public int cmxLim;

	// Token: 0x04000B97 RID: 2967
	public int cmyLim;

	// Token: 0x04000B98 RID: 2968
	public static Scroll me;

	// Token: 0x04000B99 RID: 2969
	private int pointerDownTime;

	// Token: 0x04000B9A RID: 2970
	private int pointerDownFirstX;

	// Token: 0x04000B9B RID: 2971
	public int[] pointerDownLastX = new int[3];

	// Token: 0x04000B9C RID: 2972
	public bool pointerIsDowning;

	// Token: 0x04000B9D RID: 2973
	public bool isDownWhenRunning;

	// Token: 0x04000B9E RID: 2974
	private int cmRun;

	// Token: 0x04000B9F RID: 2975
	public int selectedItem;

	// Token: 0x04000BA0 RID: 2976
	public int ITEM_SIZE;

	// Token: 0x04000BA1 RID: 2977
	public int nITEM;

	// Token: 0x04000BA2 RID: 2978
	public int ITEM_PER_LINE;

	// Token: 0x04000BA3 RID: 2979
	public bool styleUPDOWN = true;

	// Token: 0x04000BA4 RID: 2980
	public bool FocusNew;
}
