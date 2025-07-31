using System;
using System.Collections;

// Token: 0x020000AB RID: 171
public class ImageEffect
{
	// Token: 0x06000894 RID: 2196 RVA: 0x00091B40 File Offset: 0x0008FD40
	public ImageEffect(int Id)
	{
		this.imageId = Id;
		this.img = mImage.createImage("/eff/g" + Id + ".png");
		if (this.img == null || this.img.image == null)
		{
			this.img = ImageEffect.getEffectImgFromRMS(Id);
		}
		this.timeRemove = GameCanvas.timeNow;
	}

	// Token: 0x06000895 RID: 2197 RVA: 0x00091BAC File Offset: 0x0008FDAC
	public ImageEffect()
	{
	}

	// Token: 0x06000896 RID: 2198 RVA: 0x00091BB4 File Offset: 0x0008FDB4
	public ImageEffect(int Id, mImage image)
	{
		this.imageId = Id;
		this.img = image;
		this.timeRemove = GameCanvas.timeNow;
	}

	// Token: 0x06000898 RID: 2200 RVA: 0x00091BEC File Offset: 0x0008FDEC
	public static mImage getEffectImgFromRMS(int id)
	{
		mImage result = new mImage();
		ImageEffect.lastTime = GameCanvas.timeNow;
		GlobalService.gI().load_image_data_part_char(110, (short)id);
		return result;
	}

	// Token: 0x06000899 RID: 2201 RVA: 0x00091C18 File Offset: 0x0008FE18
	public static mImage setImage(int Id)
	{
		ImageEffect imageEffect = (ImageEffect)ImageEffect.hashImageEff.get(string.Empty + Id);
		if (imageEffect == null)
		{
			imageEffect = new ImageEffect(Id);
			ImageEffect.hashImageEff.put(string.Empty + Id, imageEffect);
		}
		else
		{
			imageEffect.timeRemove = GameCanvas.timeNow;
		}
		return imageEffect.img;
	}

	// Token: 0x0600089A RID: 2202 RVA: 0x00091C84 File Offset: 0x0008FE84
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = ImageEffect.hashImageEff.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageEffect imageEffect = (ImageEffect)ImageEffect.hashImageEff.get(k);
				if ((GameCanvas.timeNow - imageEffect.timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					ImageEffect.hashImageEff.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600089B RID: 2203 RVA: 0x00091D2C File Offset: 0x0008FF2C
	public static void SetRemoveAll()
	{
		ImageEffect.hashImageEff.clear();
	}

	// Token: 0x04000D6D RID: 3437
	public static mHashTable hashImageEff = new mHashTable();

	// Token: 0x04000D6E RID: 3438
	public static long lastTime = 0L;

	// Token: 0x04000D6F RID: 3439
	public long timeRemove;

	// Token: 0x04000D70 RID: 3440
	public int imageId;

	// Token: 0x04000D71 RID: 3441
	public mImage img;
}
