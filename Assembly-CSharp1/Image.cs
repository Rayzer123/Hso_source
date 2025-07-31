using System;
using System.Threading;
using UnityEngine;

// Token: 0x0200000B RID: 11
public class Image
{
	// Token: 0x0600005B RID: 91 RVA: 0x00003044 File Offset: 0x00001244
	public static Image createEmptyImage()
	{
		return Image.__createEmptyImage();
	}

	// Token: 0x0600005C RID: 92 RVA: 0x0000304C File Offset: 0x0000124C
	public static Image createImageOLD(string filename)
	{
		return Image.__createImage(filename);
	}

	// Token: 0x0600005D RID: 93 RVA: 0x00003054 File Offset: 0x00001254
	public static Image createImage(string filename)
	{
		return Image._createImageByPNG(filename);
	}

	// Token: 0x0600005E RID: 94 RVA: 0x0000305C File Offset: 0x0000125C
	public static Image createImageSprite(string filename)
	{
		return Image._createImageByPNG(filename);
	}

	// Token: 0x0600005F RID: 95 RVA: 0x00003064 File Offset: 0x00001264
	public static Image _createImageByPNG(string path)
	{
		Texture2D texture2D = Resources.Load(path) as Texture2D;
		if (texture2D == null)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image _createImageByPNG " + path);
		}
		return new Image
		{
			texture = texture2D,
			w = texture2D.width,
			h = texture2D.height
		};
	}

	// Token: 0x06000060 RID: 96 RVA: 0x000030C0 File Offset: 0x000012C0
	public static Image createImage(byte[] imageData, string path)
	{
		return Image.__createImage(imageData);
	}

	// Token: 0x06000061 RID: 97 RVA: 0x000030C8 File Offset: 0x000012C8
	public static Image createImage(Image src, int x, int y, int w, int h, int transform)
	{
		return Image.__createImage(src, x, y, w, h, transform);
	}

	// Token: 0x06000062 RID: 98 RVA: 0x000030D8 File Offset: 0x000012D8
	public static Image createImage(int w, int h)
	{
		return Image.__createImage(w, h);
	}

	// Token: 0x06000063 RID: 99 RVA: 0x000030E4 File Offset: 0x000012E4
	public static Image createImage(Image img)
	{
		Image image = Image.createImage(img.w, img.h);
		image.texture = img.texture;
		image.texture.Apply();
		return image;
	}

	// Token: 0x06000064 RID: 100 RVA: 0x0000311C File Offset: 0x0000131C
	public static Image createImage(sbyte[] imageData, int offset, int lenght, string path)
	{
		if (offset + lenght > imageData.Length)
		{
			return null;
		}
		byte[] array = new byte[lenght];
		for (int i = 0; i < lenght; i++)
		{
			array[i] = Image.convertSbyteToByte(imageData[i + offset]);
		}
		return Image.createImage(array, path);
	}

	// Token: 0x06000065 RID: 101 RVA: 0x00003164 File Offset: 0x00001364
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x06000066 RID: 102 RVA: 0x0000317C File Offset: 0x0000137C
	public static byte[] convertArrSbyteToArrByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x06000067 RID: 103 RVA: 0x000031CC File Offset: 0x000013CC
	public static Image createRGBImage(int[] rbg, int w, int h, bool bl)
	{
		Image image = Image.createImage(w, h);
		Color[] array = new Color[rbg.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = Image.setColorFromRBG(rbg[i]);
		}
		image.texture.SetPixels(0, 0, w, h, array);
		image.texture.Apply();
		return image;
	}

	// Token: 0x06000068 RID: 104 RVA: 0x00003230 File Offset: 0x00001430
	public static Color setColorFromRBG(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float b = (float)num / 256f;
		float g = (float)num2 / 256f;
		float r = (float)num3 / 256f;
		Color result = new Color(r, g, b);
		return result;
	}

	// Token: 0x06000069 RID: 105 RVA: 0x00003288 File Offset: 0x00001488
	public static void update()
	{
		if (Image.status == 2)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createEmptyImage();
			Image.status = 0;
		}
		else if (Image.status == 3)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createImage(Image.filenametemp);
			Image.status = 0;
		}
		else if (Image.status == 4)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createImage(Image.datatemp);
			Image.status = 0;
		}
		else if (Image.status == 5)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createImage(Image.imgSrcTemp, Image.xtemp, Image.ytemp, Image.wtemp, Image.htemp, Image.transformtemp);
			Image.status = 0;
		}
		else if (Image.status == 6)
		{
			Image.status = 1;
			Image.imgTemp = Image.__createImage(Image.wtemp, Image.htemp);
			Image.status = 0;
		}
	}

	// Token: 0x0600006A RID: 106 RVA: 0x00003380 File Offset: 0x00001580
	private static Image _createEmptyImage()
	{
		if (Image.status != 0)
		{
			Cout.LogError("CANNOT CREATE EMPTY IMAGE WHEN CREATING OTHER IMAGE");
			return null;
		}
		Image.imgTemp = null;
		Image.status = 2;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Image.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout.LogError("TOO LONG FOR CREATE EMPTY IMAGE");
			Image.status = 0;
		}
		return Image.imgTemp;
	}

	// Token: 0x0600006B RID: 107 RVA: 0x000033FC File Offset: 0x000015FC
	private static Image _createImage(string filename)
	{
		if (Image.status != 0)
		{
			Cout.LogError("CANNOT CREATE IMAGE " + filename + " WHEN CREATING OTHER IMAGE");
			return null;
		}
		Image.imgTemp = null;
		Image.filenametemp = filename;
		Image.status = 3;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Image.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout.LogError("TOO LONG FOR CREATE IMAGE " + filename);
			Image.status = 0;
		}
		return Image.imgTemp;
	}

	// Token: 0x0600006C RID: 108 RVA: 0x00003490 File Offset: 0x00001690
	private static Image _createImage(byte[] imageData)
	{
		if (Image.status != 0)
		{
			Cout.LogError("CANNOT CREATE IMAGE(FromArray) WHEN CREATING OTHER IMAGE");
			return null;
		}
		Image.imgTemp = null;
		Image.datatemp = imageData;
		Image.status = 4;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Image.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout.LogError("TOO LONG FOR CREATE IMAGE(FromArray)");
			Image.status = 0;
		}
		return Image.imgTemp;
	}

	// Token: 0x0600006D RID: 109 RVA: 0x00003510 File Offset: 0x00001710
	private static Image _createImage(Image src, int x, int y, int w, int h, int transform)
	{
		if (Image.status != 0)
		{
			Cout.LogError("CANNOT CREATE IMAGE(FromSrcPart) WHEN CREATING OTHER IMAGE");
			return null;
		}
		Image.imgTemp = null;
		Image.imgSrcTemp = src;
		Image.xtemp = x;
		Image.ytemp = y;
		Image.wtemp = w;
		Image.htemp = h;
		Image.transformtemp = transform;
		Image.status = 5;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Image.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout.LogError("TOO LONG FOR CREATE IMAGE(FromSrcPart)");
			Image.status = 0;
		}
		return Image.imgTemp;
	}

	// Token: 0x0600006E RID: 110 RVA: 0x000035B0 File Offset: 0x000017B0
	private static Image _createImage(int w, int h)
	{
		if (Image.status != 0)
		{
			Cout.LogError("CANNOT CREATE IMAGE(w,h) WHEN CREATING OTHER IMAGE");
			return null;
		}
		Image.imgTemp = null;
		Image.wtemp = w;
		Image.htemp = h;
		Image.status = 6;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Image.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Cout.LogError("TOO LONG FOR CREATE IMAGE(w,h)");
			Image.status = 0;
		}
		return Image.imgTemp;
	}

	// Token: 0x0600006F RID: 111 RVA: 0x00003638 File Offset: 0x00001838
	public static byte[] loadData(string filename)
	{
		Image image = new Image();
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		if (textAsset == null || textAsset.bytes == null || textAsset.bytes.Length == 0)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage " + filename);
		}
		sbyte[] array = ArrayCast.cast(textAsset.bytes);
		Debug.LogError("CHIEU DAI MANG BYTE IMAGE CREAT = " + array.Length);
		return textAsset.bytes;
	}

	// Token: 0x06000070 RID: 112 RVA: 0x000036C0 File Offset: 0x000018C0
	private static Image __createImage(string filename)
	{
		Image image = new Image();
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		if (textAsset == null || textAsset.bytes == null || textAsset.bytes.Length == 0)
		{
			throw new Exception("NULL POINTER EXCEPTION AT Image __createImage");
		}
		image.texture.LoadImage(textAsset.bytes);
		image.w = image.texture.width;
		image.h = image.texture.height;
		Image.setTextureQuality(image);
		return image;
	}

	// Token: 0x06000071 RID: 113 RVA: 0x00003754 File Offset: 0x00001954
	private static Image __createImage(byte[] imageData)
	{
		if (imageData == null || imageData.Length == 0)
		{
			Cout.LogError("Create Image from byte array fail");
			return null;
		}
		Image image = new Image();
		try
		{
			image.texture.LoadImage(imageData);
			image.w = image.texture.width;
			image.h = image.texture.height;
			Image.setTextureQuality(image);
		}
		catch (Exception ex)
		{
			Cout.LogError("CREAT IMAGE FROM ARRAY FAIL \n" + Environment.StackTrace);
		}
		return image;
	}

	// Token: 0x06000072 RID: 114 RVA: 0x000037F4 File Offset: 0x000019F4
	private static Image __createImage(Image src, int x, int y, int w, int h, int transform)
	{
		Image image = new Image();
		image.texture = new Texture2D(w, h);
		y = src.texture.height - y - h;
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				int num = i;
				if (transform == 2)
				{
					num = w - i;
				}
				int num2 = j;
				image.texture.SetPixel(i, j, src.texture.GetPixel(x + num, y + num2));
			}
		}
		image.texture.Apply();
		image.w = image.texture.width;
		image.h = image.texture.height;
		Image.setTextureQuality(image);
		return image;
	}

	// Token: 0x06000073 RID: 115 RVA: 0x000038B0 File Offset: 0x00001AB0
	private static Image __createEmptyImage()
	{
		return new Image();
	}

	// Token: 0x06000074 RID: 116 RVA: 0x000038B8 File Offset: 0x00001AB8
	public static Image __createImage(int w, int h)
	{
		Image image = new Image();
		image.texture = new Texture2D(w, h, TextureFormat.RGBA32, false);
		Image.setTextureQuality(image);
		image.w = w;
		image.h = h;
		image.texture.Apply();
		return image;
	}

	// Token: 0x06000075 RID: 117 RVA: 0x000038FC File Offset: 0x00001AFC
	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	// Token: 0x06000076 RID: 118 RVA: 0x00003904 File Offset: 0x00001B04
	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	// Token: 0x06000077 RID: 119 RVA: 0x0000390C File Offset: 0x00001B0C
	public int getWidth()
	{
		return this.w / mGraphics.zoomLevel;
	}

	// Token: 0x06000078 RID: 120 RVA: 0x0000391C File Offset: 0x00001B1C
	public int getHeight()
	{
		return this.h / mGraphics.zoomLevel;
	}

	// Token: 0x06000079 RID: 121 RVA: 0x0000392C File Offset: 0x00001B2C
	private static void setTextureQuality(Image img)
	{
		Image.setTextureQuality(img.texture);
	}

	// Token: 0x0600007A RID: 122 RVA: 0x0000393C File Offset: 0x00001B3C
	public static void setTextureQuality(Texture2D texture)
	{
		texture.anisoLevel = 0;
		texture.filterMode = FilterMode.Point;
		texture.mipMapBias = 0f;
		texture.wrapMode = TextureWrapMode.Clamp;
	}

	// Token: 0x0600007B RID: 123 RVA: 0x0000396C File Offset: 0x00001B6C
	public Color[] getColor()
	{
		return this.texture.GetPixels();
	}

	// Token: 0x0600007C RID: 124 RVA: 0x0000397C File Offset: 0x00001B7C
	public int getRealImageWidth()
	{
		return this.w;
	}

	// Token: 0x0600007D RID: 125 RVA: 0x00003984 File Offset: 0x00001B84
	public int getRealImageHeight()
	{
		return this.h;
	}

	// Token: 0x0600007E RID: 126 RVA: 0x0000398C File Offset: 0x00001B8C
	public void getRGB(int[] data, int x1, int x2, int x3, int x4, int x5, int x6)
	{
		Color[] pixels = this.texture.GetPixels();
	}

	// Token: 0x0400003B RID: 59
	private const int INTERVAL = 5;

	// Token: 0x0400003C RID: 60
	private const int MAXTIME = 500;

	// Token: 0x0400003D RID: 61
	public Texture2D texture = new Texture2D(1, 1);

	// Token: 0x0400003E RID: 62
	public static Image imgTemp;

	// Token: 0x0400003F RID: 63
	public static string filenametemp;

	// Token: 0x04000040 RID: 64
	public static byte[] datatemp;

	// Token: 0x04000041 RID: 65
	public static Image imgSrcTemp;

	// Token: 0x04000042 RID: 66
	public static int xtemp;

	// Token: 0x04000043 RID: 67
	public static int ytemp;

	// Token: 0x04000044 RID: 68
	public static int wtemp;

	// Token: 0x04000045 RID: 69
	public static int htemp;

	// Token: 0x04000046 RID: 70
	public static int transformtemp;

	// Token: 0x04000047 RID: 71
	public int w;

	// Token: 0x04000048 RID: 72
	public int h;

	// Token: 0x04000049 RID: 73
	public static int status;

	// Token: 0x0400004A RID: 74
	public Color colorBlend = Color.black;
}
