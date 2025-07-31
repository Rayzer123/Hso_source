using System;

// Token: 0x02000096 RID: 150
public class MainList
{
	// Token: 0x0600071E RID: 1822 RVA: 0x0006C20C File Offset: 0x0006A40C
	public MainList(int x, int y, int maxW, int maxH, int itemH, int maxSize, int limX, int value, mVector vec)
	{
		this.x = x;
		this.y = y;
		this.maxW = maxW;
		this.maxH = maxH;
		this.itemH = itemH;
		this.maxSize = maxSize;
		this.value = value;
		this.cmxLim = limX;
		this.vecCmd = vec;
	}

	// Token: 0x0600071F RID: 1823 RVA: 0x0006C270 File Offset: 0x0006A470
	public MainList(int x, int y, int maxW, int maxH, int itemH, int maxSize, int limX, int value, iCommand cmd)
	{
		this.x = x;
		this.y = y;
		this.maxW = maxW;
		this.maxH = maxH;
		this.itemH = itemH;
		this.maxSize = maxSize;
		this.value = value;
		this.cmxLim = limX;
		this.cmdCenter = cmd;
	}

	// Token: 0x06000720 RID: 1824 RVA: 0x0006C2D4 File Offset: 0x0006A4D4
	public void updateMenuKey()
	{
		bool flag = false;
		if (GameCanvas.keyMyPressed[2] || GameCanvas.keyMyPressed[4])
		{
			flag = true;
			this.value--;
			if (this.value < 0)
			{
				this.value = this.maxSize - 1;
			}
			GameCanvas.clearKeyPressed(2);
			GameCanvas.clearKeyPressed(4);
		}
		else if (GameCanvas.keyMyPressed[8] || GameCanvas.keyMyPressed[6])
		{
			flag = true;
			this.value++;
			if (this.value > this.maxSize - 1)
			{
				this.value = 0;
			}
			GameCanvas.clearKeyPressed(6);
			GameCanvas.clearKeyPressed(8);
		}
		if (flag)
		{
			this.cmtoX = (this.value + 1) * this.itemH - this.maxH / 2;
			if (this.cmtoX > this.cmxLim)
			{
				this.cmtoX = this.cmxLim;
			}
			if (this.cmtoX < 0)
			{
				this.cmtoX = 0;
			}
			if (this.value == this.maxSize - 1 || this.value == 0)
			{
				this.cmx = this.cmtoX;
			}
		}
		this.update_Pos_UP_DOWN();
	}

	// Token: 0x06000721 RID: 1825 RVA: 0x0006C408 File Offset: 0x0006A608
	private void update_Pos_UP_DOWN()
	{
		if (GameCanvas.keyMyHold[5])
		{
			if (this.cmdCenter == null)
			{
				if (this.vecCmd != null)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(this.value);
					if (iCommand != null)
					{
						if (iCommand.action != null)
						{
							iCommand.action.perform();
						}
						else if (iCommand.Pointer != null)
						{
							iCommand.Pointer.commandPointer((int)iCommand.indexMenu, (int)iCommand.subIndex);
						}
						else
						{
							GameCanvas.currentScreen.commandMenu((int)iCommand.indexMenu, (int)iCommand.subIndex);
						}
						GameCanvas.clearKeyHold();
						GameCanvas.clearKeyPressed();
					}
				}
			}
		}
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(this.x, this.y, this.maxW, this.maxH))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.py;
				}
				this.pointerDownFirstX = GameCanvas.py;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.py && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
					this.value = (this.cmtoX + GameCanvas.py - this.y) / this.itemH;
				}
				int num = GameCanvas.py - this.pointerDownLastX[0];
				if (num != 0 && this.value != -1)
				{
					this.value = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.py;
				this.cmtoX -= num;
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
					num /= 2;
				}
				this.cmx -= num;
			}
		}
		if (GameCanvas.isPointerClick && this.pointerIsDowning)
		{
			int a = GameCanvas.py - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.py - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.value = (this.cmtoX + GameCanvas.py - this.y) / this.itemH;
				this.pointerDownTime = 0;
				this.waitToPerform = 5;
			}
			else if (this.value != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
				this.waitToPerform = 1;
			}
			else if (this.value == -1 && !this.isDownWhenRunning)
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
					int num2 = GameCanvas.py - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
					if (num2 > 10)
					{
						num2 = 10;
					}
					else if (num2 < -10)
					{
						num2 = -10;
					}
					else
					{
						num2 = 0;
					}
					this.cmRun = -num2 * 100;
				}
			}
			this.pointerIsDowning = false;
			this.pointerDownTime = 0;
			GameCanvas.isPointerClick = false;
		}
	}

	// Token: 0x06000722 RID: 1826 RVA: 0x0006C82C File Offset: 0x0006AA2C
	public void moveCamera()
	{
		if (this.cmRun != 0 && !this.pointerIsDowning)
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
	}

	// Token: 0x06000723 RID: 1827 RVA: 0x0006C948 File Offset: 0x0006AB48
	public void updateMenu()
	{
		this.moveCamera();
		this.updateMenuKey();
		if (this.xc != 0)
		{
			this.xc >>= 1;
			if (this.xc < 0)
			{
				this.xc = 0;
			}
		}
		if (this.waitToPerform > 0)
		{
			this.waitToPerform--;
			if (this.waitToPerform == 0 && this.value >= 0)
			{
				if (this.cmdCenter != null)
				{
					this.cmdCenter.perform();
				}
				else if (this.vecCmd != null)
				{
					iCommand iCommand = (iCommand)this.vecCmd.elementAt(this.value);
					if (iCommand != null)
					{
						if (iCommand.action != null)
						{
							iCommand.action.perform();
						}
						else if (iCommand.Pointer != null)
						{
							iCommand.Pointer.commandPointer((int)iCommand.indexMenu, (int)iCommand.subIndex);
						}
						else
						{
							GameCanvas.currentScreen.commandMenu((int)iCommand.indexMenu, (int)iCommand.subIndex);
						}
						GameCanvas.clearKeyHold();
						GameCanvas.clearKeyPressed();
					}
				}
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				GameCanvas.isPointerEnd = true;
				GameCanvas.isPointerSelect = false;
				mSound.playSound(42, mSound.volumeSound);
			}
		}
	}

	// Token: 0x04000A7C RID: 2684
	public int maxW;

	// Token: 0x04000A7D RID: 2685
	public int itemH;

	// Token: 0x04000A7E RID: 2686
	public int maxH;

	// Token: 0x04000A7F RID: 2687
	public int maxSize;

	// Token: 0x04000A80 RID: 2688
	public int x;

	// Token: 0x04000A81 RID: 2689
	public int y;

	// Token: 0x04000A82 RID: 2690
	public int value;

	// Token: 0x04000A83 RID: 2691
	public int cmtoX;

	// Token: 0x04000A84 RID: 2692
	public int cmx;

	// Token: 0x04000A85 RID: 2693
	public int cmdy;

	// Token: 0x04000A86 RID: 2694
	public int cmvy;

	// Token: 0x04000A87 RID: 2695
	public int cmxLim;

	// Token: 0x04000A88 RID: 2696
	public int xc;

	// Token: 0x04000A89 RID: 2697
	private int pointerDownTime;

	// Token: 0x04000A8A RID: 2698
	private int waitToPerform;

	// Token: 0x04000A8B RID: 2699
	private int pointerDownFirstX;

	// Token: 0x04000A8C RID: 2700
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000A8D RID: 2701
	private bool pointerIsDowning;

	// Token: 0x04000A8E RID: 2702
	private bool isDownWhenRunning;

	// Token: 0x04000A8F RID: 2703
	private int cmRun;

	// Token: 0x04000A90 RID: 2704
	private mVector vecCmd;

	// Token: 0x04000A91 RID: 2705
	private iCommand cmdCenter;

	// Token: 0x04000A92 RID: 2706
	public int w;

	// Token: 0x04000A93 RID: 2707
	private int pa;

	// Token: 0x04000A94 RID: 2708
	private bool trans;

	// Token: 0x04000A95 RID: 2709
	private int cmvx;

	// Token: 0x04000A96 RID: 2710
	private int cmdx;
}
