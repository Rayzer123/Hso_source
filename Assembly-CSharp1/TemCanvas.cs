using System;

// Token: 0x02000002 RID: 2
public class TemCanvas
{
	// Token: 0x06000001 RID: 1 RVA: 0x000020EC File Offset: 0x000002EC
	public TemCanvas()
	{
		TemCanvas.instance = this;
		TemCanvas.hMain = this.getHeight();
		TemCanvas.wMain = this.getWidth();
		this.checkZoomLevel(TemCanvas.wMain, TemCanvas.hMain);
		GameCanvas.isTouch = true;
		TemCanvas.gamecanvas = new GameCanvas();
	}

	// Token: 0x06000003 RID: 3 RVA: 0x00002148 File Offset: 0x00000348
	private int getWidth()
	{
		return (int)ScaleGUI.WIDTH;
	}

	// Token: 0x06000004 RID: 4 RVA: 0x00002150 File Offset: 0x00000350
	private int getHeight()
	{
		return (int)ScaleGUI.HEIGHT;
	}

	// Token: 0x06000005 RID: 5 RVA: 0x00002158 File Offset: 0x00000358
	private void checkZoomLevel(int w, int h)
	{
		if (Main.isWindowsPhone)
		{
			mGraphics.zoomLevel = 2;
			if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h > 384000)
			{
				mGraphics.zoomLevel = 3;
			}
		}
		else if (!Main.isPC)
		{
			if (w * h >= 2073600)
			{
				mGraphics.zoomLevel = 4;
			}
			else if (w * h >= 691200)
			{
				mGraphics.zoomLevel = 3;
			}
			else if (w * h > 153600)
			{
				mGraphics.zoomLevel = 3;
			}
		}
		else
		{
			mGraphics.zoomLevel = 2;
			if (w * h < 480000)
			{
				mGraphics.zoomLevel = 1;
			}
			Main.main.doClearRMS();
		}
		TemCanvas.wMain = (TemCanvas.wMain + mGraphics.zoomLevel - 1) / mGraphics.zoomLevel;
		TemCanvas.hMain = (TemCanvas.hMain + mGraphics.zoomLevel - 1) / mGraphics.zoomLevel;
	}

	// Token: 0x06000006 RID: 6 RVA: 0x0000224C File Offset: 0x0000044C
	public void start()
	{
	}

	// Token: 0x06000007 RID: 7 RVA: 0x00002250 File Offset: 0x00000450
	public void paint(mGraphics gx)
	{
		if (TemCanvas.tem.g == null)
		{
			TemCanvas.tem.g = gx;
		}
		TemCanvas.gamecanvas.paint(TemCanvas.tem);
	}

	// Token: 0x06000008 RID: 8 RVA: 0x0000227C File Offset: 0x0000047C
	public void update()
	{
		TemCanvas.gamecanvas.update();
		GameCanvas.timeNow = mSystem.currentTimeMillis();
	}

	// Token: 0x06000009 RID: 9 RVA: 0x00002294 File Offset: 0x00000494
	public void keyPressed(int keyCode)
	{
		TemCanvas.gamecanvas.keyPressed(keyCode);
	}

	// Token: 0x0600000A RID: 10 RVA: 0x000022A4 File Offset: 0x000004A4
	public void keyReleased(int keyCode)
	{
		TemCanvas.gamecanvas.keyReleased(keyCode);
	}

	// Token: 0x0600000B RID: 11 RVA: 0x000022B4 File Offset: 0x000004B4
	public void pointerDragged(int x, int y)
	{
		TemCanvas.gamecanvas.pointerDragged(x, y);
	}

	// Token: 0x0600000C RID: 12 RVA: 0x000022C4 File Offset: 0x000004C4
	public void pointerPressed(int x, int y)
	{
		TemCanvas.gamecanvas.pointerPressed(x, y);
	}

	// Token: 0x0600000D RID: 13 RVA: 0x000022D4 File Offset: 0x000004D4
	public void pointerReleased(int x, int y)
	{
		TemCanvas.gamecanvas.pointerReleased(x, y);
	}

	// Token: 0x0600000E RID: 14 RVA: 0x000022E4 File Offset: 0x000004E4
	public int getWidthz()
	{
		int width = this.getWidth();
		return width / mGraphics.zoomLevel + width % mGraphics.zoomLevel;
	}

	// Token: 0x0600000F RID: 15 RVA: 0x00002308 File Offset: 0x00000508
	public int getHeightz()
	{
		int height = this.getHeight();
		return height / mGraphics.zoomLevel + height % mGraphics.zoomLevel;
	}

	// Token: 0x04000001 RID: 1
	public static TemCanvas instance;

	// Token: 0x04000002 RID: 2
	public static GameCanvas gamecanvas;

	// Token: 0x04000003 RID: 3
	public static TemGraphics tem = new TemGraphics();

	// Token: 0x04000004 RID: 4
	public static int wMain;

	// Token: 0x04000005 RID: 5
	public static int hMain;

	// Token: 0x04000006 RID: 6
	public static mVector listPoint;
}
