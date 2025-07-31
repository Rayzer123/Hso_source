using System;

// Token: 0x02000086 RID: 134
public class MainScreen : AvMain
{
	// Token: 0x06000667 RID: 1639 RVA: 0x00060078 File Offset: 0x0005E278
	public virtual void Show()
	{
		GameCanvas.clearKeyPressed();
		GameCanvas.currentScreen = this;
		GameCanvas.end_Dialog();
		GameCanvas.menu2.isShowMenu = false;
	}

	// Token: 0x06000668 RID: 1640 RVA: 0x00060098 File Offset: 0x0005E298
	public virtual bool isGameScr()
	{
		return false;
	}

	// Token: 0x06000669 RID: 1641 RVA: 0x0006009C File Offset: 0x0005E29C
	public virtual void Show(MainScreen screen)
	{
		if (screen != null)
		{
			this.lastScreen = screen;
		}
		GameCanvas.clearKeyPressed();
		GameCanvas.currentScreen = this;
		GameCanvas.end_Dialog();
		GameCanvas.menu2.isShowMenu = false;
	}

	// Token: 0x0600066A RID: 1642 RVA: 0x000600D4 File Offset: 0x0005E2D4
	public override void paint(mGraphics g)
	{
		base.paint(g);
	}

	// Token: 0x0600066B RID: 1643 RVA: 0x000600E0 File Offset: 0x0005E2E0
	public override void update()
	{
	}

	// Token: 0x0600066C RID: 1644 RVA: 0x000600E4 File Offset: 0x0005E2E4
	public virtual void keyPress(int keyCode)
	{
	}

	// Token: 0x0600066D RID: 1645 RVA: 0x000600E8 File Offset: 0x0005E2E8
	public virtual void keyBack()
	{
	}

	// Token: 0x0400093B RID: 2363
	private MainScreen mainScreen;

	// Token: 0x0400093C RID: 2364
	public MainScreen lastScreen;

	// Token: 0x0400093D RID: 2365
	public static Camera cameraMain;

	// Token: 0x0400093E RID: 2366
	public static Camera cameraSub;

	// Token: 0x0400093F RID: 2367
	public string name = string.Empty;
}
