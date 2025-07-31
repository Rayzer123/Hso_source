using System;

// Token: 0x020000AD RID: 173
public class MotherCanvas
{
	// Token: 0x060008A2 RID: 2210 RVA: 0x00091F90 File Offset: 0x00090190
	public MotherCanvas()
	{
		this.checkZoomLevel(this.getWidth(), this.getHeight());
	}

	// Token: 0x060008A3 RID: 2211 RVA: 0x00091FC4 File Offset: 0x000901C4
	public void checkZoomLevel(int w, int h)
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
			if (Main.isIpod)
			{
				mGraphics.zoomLevel = 2;
			}
			else if (w * h >= 2073600)
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
			if (w > 1024 && h > 768)
			{
				mGraphics.zoomLevel = 3;
			}
		}
	}

	// Token: 0x060008A4 RID: 2212 RVA: 0x0009209C File Offset: 0x0009029C
	public int getWidth()
	{
		return (int)ScaleGUI.WIDTH;
	}

	// Token: 0x060008A5 RID: 2213 RVA: 0x000920A4 File Offset: 0x000902A4
	public int getHeight()
	{
		return (int)ScaleGUI.HEIGHT;
	}

	// Token: 0x060008A6 RID: 2214 RVA: 0x000920AC File Offset: 0x000902AC
	public void setChildCanvas(GameCanvas tCanvas)
	{
		this.tCanvas = tCanvas;
	}

	// Token: 0x060008A7 RID: 2215 RVA: 0x000920B8 File Offset: 0x000902B8
	protected void paint(mGraphics g)
	{
	}

	// Token: 0x060008A8 RID: 2216 RVA: 0x000920BC File Offset: 0x000902BC
	protected void keyPressed(int keyCode)
	{
	}

	// Token: 0x060008A9 RID: 2217 RVA: 0x000920C0 File Offset: 0x000902C0
	protected void keyReleased(int keyCode)
	{
	}

	// Token: 0x060008AA RID: 2218 RVA: 0x000920C4 File Offset: 0x000902C4
	protected void pointerDragged(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerDragged(x, y);
	}

	// Token: 0x060008AB RID: 2219 RVA: 0x000920E8 File Offset: 0x000902E8
	protected void pointerPressed(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerPressed(x, y);
	}

	// Token: 0x060008AC RID: 2220 RVA: 0x0009210C File Offset: 0x0009030C
	protected void pointerReleased(int x, int y)
	{
		x /= mGraphics.zoomLevel;
		y /= mGraphics.zoomLevel;
		this.tCanvas.pointerReleased(x, y);
	}

	// Token: 0x060008AD RID: 2221 RVA: 0x00092130 File Offset: 0x00090330
	public int getWidthz()
	{
		int width = this.getWidth();
		return width / mGraphics.zoomLevel + width % mGraphics.zoomLevel;
	}

	// Token: 0x060008AE RID: 2222 RVA: 0x00092154 File Offset: 0x00090354
	public int getHeightz()
	{
		int height = this.getHeight();
		return height / mGraphics.zoomLevel + height % mGraphics.zoomLevel;
	}

	// Token: 0x04000D76 RID: 3446
	public static MotherCanvas instance;

	// Token: 0x04000D77 RID: 3447
	public GameCanvas tCanvas;

	// Token: 0x04000D78 RID: 3448
	public int zoomLevel = 1;

	// Token: 0x04000D79 RID: 3449
	public Image imgCache;

	// Token: 0x04000D7A RID: 3450
	private int[] imgRGBCache;

	// Token: 0x04000D7B RID: 3451
	private int newWidth;

	// Token: 0x04000D7C RID: 3452
	private int newHeight;

	// Token: 0x04000D7D RID: 3453
	private int[] output;

	// Token: 0x04000D7E RID: 3454
	private int OUTPUTSIZE = 20;
}
