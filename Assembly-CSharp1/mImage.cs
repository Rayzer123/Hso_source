using System;

// Token: 0x0200002F RID: 47
public class mImage
{
	// Token: 0x06000229 RID: 553 RVA: 0x0000D0A4 File Offset: 0x0000B2A4
	public static string getLink(string str)
	{
		str = Main.res + str;
		return str;
	}

	// Token: 0x0600022A RID: 554 RVA: 0x0000D0B4 File Offset: 0x0000B2B4
	public static mImage createImage(string url)
	{
		bool flag = false;
		mImage mImage = new mImage();
		string filename = string.Empty;
		try
		{
			filename = Main.res + mImage.cutPng("/x" + mGraphics.zoomLevel + url);
			mImage.image = Image.createImage(filename);
		}
		catch (Exception ex)
		{
			flag = true;
		}
		if (mImage.image == null || flag)
		{
			return null;
		}
		return mImage;
	}

	// Token: 0x0600022B RID: 555 RVA: 0x0000D140 File Offset: 0x0000B340
	public static string cutPng(string str)
	{
		string result = str;
		if (str.Contains(".png"))
		{
			result = str.Replace(".png", string.Empty);
		}
		else if (str.Contains(".img"))
		{
			result = str.Replace(".img", string.Empty);
		}
		return result;
	}

	// Token: 0x0600022C RID: 556 RVA: 0x0000D198 File Offset: 0x0000B398
	public static DataInputStream openFile(string path)
	{
		return DataInputStream.getResourceAsStream(mImage.getLink(path));
	}

	// Token: 0x0600022D RID: 557 RVA: 0x0000D1B4 File Offset: 0x0000B3B4
	public static mImage createImage(int w, int h)
	{
		return new mImage
		{
			image = Image.createImage(w * mGraphics.zoomLevel, h * mGraphics.zoomLevel)
		};
	}

	// Token: 0x0600022E RID: 558 RVA: 0x0000D1E4 File Offset: 0x0000B3E4
	public static mImage createImage(sbyte[] data, int w, int h, string path)
	{
		return new mImage
		{
			image = Image.createImage(data, 0, data.Length, path)
		};
	}

	// Token: 0x0600022F RID: 559 RVA: 0x0000D20C File Offset: 0x0000B40C
	public TemGraphics getGraphics()
	{
		return new TemGraphics();
	}

	// Token: 0x06000230 RID: 560 RVA: 0x0000D220 File Offset: 0x0000B420
	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	// Token: 0x06000231 RID: 561 RVA: 0x0000D228 File Offset: 0x0000B428
	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	// Token: 0x06000232 RID: 562 RVA: 0x0000D230 File Offset: 0x0000B430
	public void getRGB(int[] rgbData, int offset, int scanlength, int x, int y, int width, int height)
	{
	}

	// Token: 0x06000233 RID: 563 RVA: 0x0000D234 File Offset: 0x0000B434
	public static mImage createRGBImage(int[] rgb, int width, int height, bool processAlpha)
	{
		return new mImage
		{
			image = Image.createRGBImage(rgb, width, height, processAlpha)
		};
	}

	// Token: 0x06000234 RID: 564 RVA: 0x0000D258 File Offset: 0x0000B458
	public static mImage loadImageRMS(string path)
	{
		mImage mImage = null;
		try
		{
			sbyte[] array = Rms.loadRMS(path);
			if (array != null)
			{
				Image image = Image.createImage(array, 0, array.Length, path);
				mImage = new mImage();
				mImage.image = image;
			}
		}
		catch (Exception ex)
		{
			return null;
		}
		return mImage;
	}

	// Token: 0x040001FD RID: 509
	public Image image = new Image();
}
