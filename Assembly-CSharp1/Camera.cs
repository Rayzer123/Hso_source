using System;

// Token: 0x020000B5 RID: 181
public class Camera
{
	// Token: 0x06000923 RID: 2339 RVA: 0x0009634C File Offset: 0x0009454C
	public void setAll(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		if (this.yLimit < 0)
		{
			this.yLimit = 0;
		}
		if (this.xLimit < 0)
		{
			this.xLimit = 0;
		}
		if (xCam > xLimit)
		{
			xCam = xLimit;
		}
		if (xCam < 0)
		{
			xCam = 0;
		}
		if (yCam > yLimit)
		{
			yCam = yLimit;
		}
		if (yCam < 0)
		{
			yCam = 0;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x06000924 RID: 2340 RVA: 0x000963D8 File Offset: 0x000945D8
	public void setAllTo(int xLimit, int yLimit, int xCam, int yCam)
	{
		this.xLimit = xLimit;
		this.yLimit = yLimit;
		if (this.yLimit < 0)
		{
			this.yLimit = 0;
		}
		if (this.xLimit < 0)
		{
			this.xLimit = 0;
		}
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x06000925 RID: 2341 RVA: 0x00096428 File Offset: 0x00094628
	public void setCamera(int xCam, int yCam)
	{
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x06000926 RID: 2342 RVA: 0x00096448 File Offset: 0x00094648
	public void setCameraWithLim(int xCam, int yCam)
	{
		if (xCam < 0)
		{
			xCam = 0;
		}
		if (xCam > this.xLimit)
		{
			xCam = this.xLimit;
		}
		if (yCam < 0)
		{
			yCam = 0;
		}
		if (yCam > this.yLimit)
		{
			yCam = this.yLimit;
		}
		this.xCam = xCam;
		this.yCam = yCam;
		this.xTo = xCam;
		this.yTo = yCam;
	}

	// Token: 0x06000927 RID: 2343 RVA: 0x000964B0 File Offset: 0x000946B0
	public void moveCamera(int xTo, int yTo)
	{
		this.xTo = xTo;
		this.yTo = yTo;
	}

	// Token: 0x06000928 RID: 2344 RVA: 0x000964C0 File Offset: 0x000946C0
	public void UpdateCamera()
	{
		if (GameScreen.player.useShip)
		{
			if (GameCanvas.loadmap.idMap != 19)
			{
				return;
			}
			if (this.yCam == 0)
			{
				return;
			}
			this.yTo = 0;
		}
		if (this.xCam != this.xTo)
		{
			this.cmvx = this.xTo - this.xCam << 1;
			this.cmdx += this.cmvx;
			this.xCam += this.cmdx >> 4;
			this.cmdx &= 15;
			if (this.xCam < 0)
			{
				this.xCam = 0;
			}
			if (this.xCam > this.xLimit)
			{
				this.xCam = this.xLimit;
			}
		}
		if (this.yCam != this.yTo)
		{
			this.cmvy = this.yTo - this.yCam << 1;
			this.cmdy += this.cmvy;
			this.yCam += this.cmdy >> 4;
			this.cmdy &= 15;
			if (this.yCam < 0)
			{
				this.yCam = 0;
			}
			if (this.yCam > this.yLimit)
			{
				this.yCam = this.yLimit;
			}
		}
	}

	// Token: 0x06000929 RID: 2345 RVA: 0x00096628 File Offset: 0x00094828
	public void UpdateCameraCreate()
	{
		if (this.xCam != this.xTo)
		{
			this.cmvx = this.xTo - this.xCam << 1;
			this.cmdx += this.cmvx;
			this.xCam += this.cmdx >> 4;
			this.cmdx &= 15;
		}
		if (this.yCam != this.yTo)
		{
			this.cmvy = this.yTo - this.yCam << 1;
			this.cmdy += this.cmvy;
			this.yCam += this.cmdy >> 4;
			this.cmdy &= 15;
			if (this.yCam < 0)
			{
				this.yCam = 0;
			}
			if (this.yCam > this.yLimit)
			{
				this.yCam = this.yLimit;
			}
		}
	}

	// Token: 0x04000E08 RID: 3592
	public static Camera instance;

	// Token: 0x04000E09 RID: 3593
	public int xCam;

	// Token: 0x04000E0A RID: 3594
	public int yCam;

	// Token: 0x04000E0B RID: 3595
	public int xTo;

	// Token: 0x04000E0C RID: 3596
	public int yTo;

	// Token: 0x04000E0D RID: 3597
	public int xLimit;

	// Token: 0x04000E0E RID: 3598
	public int yLimit;

	// Token: 0x04000E0F RID: 3599
	public long timeDelay;

	// Token: 0x04000E10 RID: 3600
	private int cmvx;

	// Token: 0x04000E11 RID: 3601
	private int cmdx;

	// Token: 0x04000E12 RID: 3602
	private int cmvy;

	// Token: 0x04000E13 RID: 3603
	private int cmdy;
}
