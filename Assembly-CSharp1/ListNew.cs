using System;

// Token: 0x02000094 RID: 148
public class ListNew
{
	// Token: 0x06000715 RID: 1813 RVA: 0x0006B900 File Offset: 0x00069B00
	public ListNew(int x, int y, int maxW, int maxH, int itemH, int maxSize, int limX)
	{
		this.x = x;
		this.y = y;
		this.maxW = maxW;
		this.maxH = maxH;
		this.itemH = itemH;
		this.maxSize = maxSize;
		this.cmxLim = limX;
	}

	// Token: 0x06000716 RID: 1814 RVA: 0x0006B954 File Offset: 0x00069B54
	public void updateMenuKey()
	{
		bool flag = false;
		if (GameCanvas.keyMyPressed[2])
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
		else if (GameCanvas.keyMyPressed[8])
		{
			flag = true;
			this.value++;
			if (this.value > this.maxSize - 1)
			{
				this.value = this.maxSize - 1;
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

	// Token: 0x06000717 RID: 1815 RVA: 0x0006BA78 File Offset: 0x00069C78
	public void update_Pos_UP_DOWN()
	{
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
				this.pointerDownTime = 0;
			}
			else if (this.value != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
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

	// Token: 0x06000718 RID: 1816 RVA: 0x0006BDA0 File Offset: 0x00069FA0
	public void updatePos_LEFT_RIGHT()
	{
		if (GameCanvas.isPointerDown)
		{
			if (!this.pointerIsDowning && GameCanvas.isPointer(this.x, this.y, this.maxW, this.maxH))
			{
				for (int i = 0; i < this.pointerDownLastX.Length; i++)
				{
					this.pointerDownLastX[0] = GameCanvas.px;
				}
				this.pointerDownFirstX = GameCanvas.px;
				this.pointerIsDowning = true;
				this.isDownWhenRunning = (this.cmRun != 0);
				this.cmRun = 0;
			}
			else if (this.pointerIsDowning)
			{
				this.pointerDownTime++;
				if (this.pointerDownTime > 5 && this.pointerDownFirstX == GameCanvas.px && !this.isDownWhenRunning)
				{
					this.pointerDownFirstX = -1000;
				}
				int num = GameCanvas.px - this.pointerDownLastX[0];
				if (num != 0 && this.value != -1)
				{
					this.value = -1;
				}
				for (int j = this.pointerDownLastX.Length - 1; j > 0; j--)
				{
					this.pointerDownLastX[j] = this.pointerDownLastX[j - 1];
				}
				this.pointerDownLastX[0] = GameCanvas.px;
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
			int a = GameCanvas.px - this.pointerDownLastX[0];
			GameCanvas.isPointerClick = false;
			if (CRes.abs(a) < 20 && CRes.abs(GameCanvas.px - this.pointerDownFirstX) < 20 && !this.isDownWhenRunning)
			{
				this.cmRun = 0;
				this.cmtoX = this.cmx;
				this.pointerDownFirstX = -1000;
				this.pointerDownTime = 0;
			}
			else if (this.value != -1 && this.pointerDownTime > 5)
			{
				this.pointerDownTime = 0;
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
					int num2 = GameCanvas.px - this.pointerDownLastX[0] + (this.pointerDownLastX[0] - this.pointerDownLastX[1]) + (this.pointerDownLastX[1] - this.pointerDownLastX[2]);
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

	// Token: 0x06000719 RID: 1817 RVA: 0x0006C0C8 File Offset: 0x0006A2C8
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

	// Token: 0x0600071A RID: 1818 RVA: 0x0006C1E4 File Offset: 0x0006A3E4
	public void updateMenu()
	{
		this.moveCamera();
		this.updateMenuKey();
	}

	// Token: 0x04000A5B RID: 2651
	public int maxW;

	// Token: 0x04000A5C RID: 2652
	public int itemH;

	// Token: 0x04000A5D RID: 2653
	public int maxH;

	// Token: 0x04000A5E RID: 2654
	public int maxSize;

	// Token: 0x04000A5F RID: 2655
	public int x;

	// Token: 0x04000A60 RID: 2656
	public int y;

	// Token: 0x04000A61 RID: 2657
	public int value;

	// Token: 0x04000A62 RID: 2658
	public int cmtoX;

	// Token: 0x04000A63 RID: 2659
	public int cmx;

	// Token: 0x04000A64 RID: 2660
	public int cmdy;

	// Token: 0x04000A65 RID: 2661
	public int cmvy;

	// Token: 0x04000A66 RID: 2662
	public int cmxLim;

	// Token: 0x04000A67 RID: 2663
	private int pointerDownTime;

	// Token: 0x04000A68 RID: 2664
	private int pointerDownFirstX;

	// Token: 0x04000A69 RID: 2665
	private int[] pointerDownLastX = new int[3];

	// Token: 0x04000A6A RID: 2666
	private bool pointerIsDowning;

	// Token: 0x04000A6B RID: 2667
	private bool isDownWhenRunning;

	// Token: 0x04000A6C RID: 2668
	private int cmRun;

	// Token: 0x04000A6D RID: 2669
	private mVector vecCmd;

	// Token: 0x04000A6E RID: 2670
	private iCommand cmdCenter;

	// Token: 0x04000A6F RID: 2671
	public int w;

	// Token: 0x04000A70 RID: 2672
	private int pa;

	// Token: 0x04000A71 RID: 2673
	private bool trans;

	// Token: 0x04000A72 RID: 2674
	private int cmvx;

	// Token: 0x04000A73 RID: 2675
	private int cmdx;
}
