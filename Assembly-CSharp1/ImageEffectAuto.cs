using System;
using System.Collections;

// Token: 0x020000AC RID: 172
public class ImageEffectAuto
{
	// Token: 0x0600089C RID: 2204 RVA: 0x00091D38 File Offset: 0x0008FF38
	public ImageEffectAuto(int Id)
	{
		this.imageId = Id;
		this.img = mImage.createImage("/effauto/eff_" + Id + ".png");
		if (Id == 8 && this.img.image.getRealImageHeight() == 0 && this.img.image.getRealImageWidth() == 0)
		{
			this.img = null;
		}
		this.timeRemove = GameCanvas.timeNow;
	}

	// Token: 0x0600089E RID: 2206 RVA: 0x00091DC4 File Offset: 0x0008FFC4
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = ImageEffectAuto.hashImageEffAuto.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(k);
				if ((GameCanvas.timeNow - imageEffectAuto.timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					ImageEffectAuto.hashImageEffAuto.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600089F RID: 2207 RVA: 0x00091E6C File Offset: 0x0009006C
	public static mImage setImage(int Id)
	{
		ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(string.Empty + Id);
		if (imageEffectAuto == null)
		{
			imageEffectAuto = new ImageEffectAuto(Id);
			ImageEffectAuto.hashImageEffAuto.put(string.Empty + Id, imageEffectAuto);
			if (imageEffectAuto == null || imageEffectAuto.img == null)
			{
				GlobalService.gI().load_image_data_part_char(111, (short)Id);
			}
		}
		else
		{
			imageEffectAuto.timeRemove = GameCanvas.timeNow;
		}
		return imageEffectAuto.img;
	}

	// Token: 0x060008A0 RID: 2208 RVA: 0x00091EF8 File Offset: 0x000900F8
	public static mImage setImageMatna(int Id)
	{
		ImageEffectAuto imageEffectAuto = (ImageEffectAuto)ImageEffectAuto.hashImageEffAuto.get(string.Empty + Id);
		if (imageEffectAuto == null)
		{
			imageEffectAuto = new ImageEffectAuto(Id);
			ImageEffectAuto.hashImageEffAuto.put(string.Empty + Id, imageEffectAuto);
			if (imageEffectAuto == null || imageEffectAuto.img == null)
			{
				GlobalService.gI().load_image_data_part_char(7, (short)Id);
			}
		}
		else
		{
			imageEffectAuto.timeRemove = GameCanvas.timeNow;
		}
		return imageEffectAuto.img;
	}

	// Token: 0x060008A1 RID: 2209 RVA: 0x00091F84 File Offset: 0x00090184
	public static void SetRemoveAll()
	{
		ImageEffectAuto.hashImageEffAuto.clear();
	}

	// Token: 0x04000D72 RID: 3442
	public static mHashTable hashImageEffAuto = new mHashTable();

	// Token: 0x04000D73 RID: 3443
	public long timeRemove;

	// Token: 0x04000D74 RID: 3444
	private int imageId;

	// Token: 0x04000D75 RID: 3445
	public mImage img;
}
