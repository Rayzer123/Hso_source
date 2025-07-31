using System;

// Token: 0x02000039 RID: 57
public class MainEffect
{
	// Token: 0x060002CB RID: 715 RVA: 0x00026928 File Offset: 0x00024B28
	public virtual void paint(mGraphics g)
	{
	}

	// Token: 0x060002CC RID: 716 RVA: 0x0002692C File Offset: 0x00024B2C
	public virtual void update()
	{
		this.x += this.vx;
		this.y += this.vy;
	}

	// Token: 0x060002CD RID: 717 RVA: 0x00026960 File Offset: 0x00024B60
	public void setPosition(int x, int y, int xto, int yto)
	{
		this.x = x;
		this.y = y;
		this.toX = xto;
		this.toY = yto;
	}

	// Token: 0x060002CE RID: 718 RVA: 0x00026980 File Offset: 0x00024B80
	public static bool isInScreen(int x, int y, int w, int h)
	{
		return x >= MainScreen.cameraMain.xCam - w && x <= MainScreen.cameraMain.xCam + GameCanvas.w + w && y >= MainScreen.cameraMain.yCam - h && y <= MainScreen.cameraMain.yCam + GameCanvas.h + h;
	}

	// Token: 0x060002CF RID: 719 RVA: 0x000269E4 File Offset: 0x00024BE4
	public virtual void setObjFrom(short id, sbyte tem)
	{
	}

	// Token: 0x060002D0 RID: 720 RVA: 0x000269E8 File Offset: 0x00024BE8
	public virtual void setTimeRemove(short time)
	{
	}

	// Token: 0x0400037A RID: 890
	public bool isPaint = true;

	// Token: 0x0400037B RID: 891
	public int typeEffect;

	// Token: 0x0400037C RID: 892
	public int valueEffect;

	// Token: 0x0400037D RID: 893
	public int timeRemove;

	// Token: 0x0400037E RID: 894
	public int x;

	// Token: 0x0400037F RID: 895
	public int y;

	// Token: 0x04000380 RID: 896
	public int toX;

	// Token: 0x04000381 RID: 897
	public int toY;

	// Token: 0x04000382 RID: 898
	public int f;

	// Token: 0x04000383 RID: 899
	public int frame;

	// Token: 0x04000384 RID: 900
	public int ysai;

	// Token: 0x04000385 RID: 901
	public int Direction;

	// Token: 0x04000386 RID: 902
	public int vMax;

	// Token: 0x04000387 RID: 903
	public int vx;

	// Token: 0x04000388 RID: 904
	public int vy;

	// Token: 0x04000389 RID: 905
	public int hOne;

	// Token: 0x0400038A RID: 906
	public int subf;

	// Token: 0x0400038B RID: 907
	public int fRemove;

	// Token: 0x0400038C RID: 908
	public int levelPaint;

	// Token: 0x0400038D RID: 909
	private long timeBegin;

	// Token: 0x0400038E RID: 910
	public MainObject objBeKillMain;

	// Token: 0x0400038F RID: 911
	public sbyte[] nFrame;

	// Token: 0x04000390 RID: 912
	public sbyte[] nSubFrame;

	// Token: 0x04000391 RID: 913
	public FrameImage fraImgEff;

	// Token: 0x04000392 RID: 914
	public FrameImage fraImgSubEff;

	// Token: 0x04000393 RID: 915
	public FrameImage fraImgSub2Eff;

	// Token: 0x04000394 RID: 916
	public FrameImage fraImgSub3Eff;

	// Token: 0x04000395 RID: 917
	public bool isRemove;

	// Token: 0x04000396 RID: 918
	public bool isStop;
}
