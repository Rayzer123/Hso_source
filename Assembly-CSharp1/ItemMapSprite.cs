using System;

// Token: 0x020000E1 RID: 225
public class ItemMapSprite
{
	// Token: 0x06000AF4 RID: 2804 RVA: 0x000BDD08 File Offset: 0x000BBF08
	public bool isPaint(int x1, int xw1, int x2, int xw2, int y1, int yh1, int y2, int yh2)
	{
		x1 *= mGraphics.zoomLevel;
		xw1 *= mGraphics.zoomLevel;
		x2 *= mGraphics.zoomLevel;
		xw2 *= mGraphics.zoomLevel;
		y1 *= mGraphics.zoomLevel;
		yh1 *= mGraphics.zoomLevel;
		y2 *= mGraphics.zoomLevel;
		yh2 *= mGraphics.zoomLevel;
		return x1 <= xw2 && xw1 >= x2 && y1 <= yh2 && yh1 >= y2;
	}

	// Token: 0x06000AF5 RID: 2805 RVA: 0x000BDD88 File Offset: 0x000BBF88
	public void update()
	{
		if (this.isPaint(this.x, this.x + this.wimg, MainScreen.cameraMain.xCam, MainScreen.cameraMain.xCam + GameCanvas.w, this.y, this.y + this.himg, MainScreen.cameraMain.yCam, MainScreen.cameraMain.yCam + GameCanvas.h))
		{
			this.isShow = true;
			this.timeRemove = (int)(mSystem.currentTimeMillis() / 1000L);
		}
		else
		{
			this.isShow = false;
		}
		if (this.isLoadOK && mSystem.currentTimeMillis() / 1000L - (long)this.timeRemove > 360L)
		{
			this.img.image.texture = null;
			this.img = null;
			this.isLoadOK = false;
		}
	}

	// Token: 0x06000AF6 RID: 2806 RVA: 0x000BDE6C File Offset: 0x000BC06C
	public byte[] getByteArray(Image img)
	{
		byte[] result;
		try
		{
			byte[] array = img.texture.EncodeToPNG();
			result = array;
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000AF7 RID: 2807 RVA: 0x000BDEBC File Offset: 0x000BC0BC
	public void loadImage()
	{
		this.img = mImage.loadImageRMS(this.path);
		if (this.img != null)
		{
			return;
		}
		this.img = LoadMap.me.loadImageMap(this, ref this.timeRemove, ref this.isLoadOK);
		byte[] byteArray = this.getByteArray(this.img.image);
		Rms.saveRMS(this.path, ArrayCast.cast(byteArray));
	}

	// Token: 0x06000AF8 RID: 2808 RVA: 0x000BDF28 File Offset: 0x000BC128
	public void paint(mGraphics g)
	{
		if (this.isShow)
		{
			if (this.img == null)
			{
				this.img = mSystem.loadImageByPNG(this.path, ref this.timeRemove, ref this.isLoadOK);
				return;
			}
			g.drawImagaByDrawTexture(this.img, (float)this.x, (float)this.y);
		}
	}

	// Token: 0x04001274 RID: 4724
	public int x;

	// Token: 0x04001275 RID: 4725
	public int y;

	// Token: 0x04001276 RID: 4726
	public int wimg;

	// Token: 0x04001277 RID: 4727
	public int himg;

	// Token: 0x04001278 RID: 4728
	public int timeRemove;

	// Token: 0x04001279 RID: 4729
	public string path;

	// Token: 0x0400127A RID: 4730
	public mImage img;

	// Token: 0x0400127B RID: 4731
	public bool isShow;

	// Token: 0x0400127C RID: 4732
	public bool isLoadOK;
}
