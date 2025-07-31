using System;
using System.Collections;

// Token: 0x02000047 RID: 71
public class GameData
{
	// Token: 0x06000322 RID: 802 RVA: 0x0002B234 File Offset: 0x00029434
	public static GameData gI()
	{
		return (GameData.me != null) ? GameData.me : (GameData.me = new GameData());
	}

	// Token: 0x06000323 RID: 803 RVA: 0x0002B258 File Offset: 0x00029458
	public void getImage()
	{
		if (!this.loadData)
		{
			GameData.loadImgPotion();
			GameData.loadImgGemItem();
			this.loadData = true;
		}
	}

	// Token: 0x06000324 RID: 804 RVA: 0x0002B278 File Offset: 0x00029478
	public static void loadImgPotion()
	{
	}

	// Token: 0x06000325 RID: 805 RVA: 0x0002B27C File Offset: 0x0002947C
	private static void createImgHorse(sbyte[] data, sbyte[][] header)
	{
	}

	// Token: 0x06000326 RID: 806 RVA: 0x0002B280 File Offset: 0x00029480
	public static void saveImgSkill(int ver, sbyte[] array)
	{
	}

	// Token: 0x06000327 RID: 807 RVA: 0x0002B284 File Offset: 0x00029484
	public static void saveImgGem(sbyte ver, sbyte[] array)
	{
	}

	// Token: 0x06000328 RID: 808 RVA: 0x0002B288 File Offset: 0x00029488
	public static void loadImgGemItem()
	{
	}

	// Token: 0x06000329 RID: 809 RVA: 0x0002B28C File Offset: 0x0002948C
	public static void setIndexWait()
	{
	}

	// Token: 0x0600032A RID: 810 RVA: 0x0002B290 File Offset: 0x00029490
	public static ImageIcon getImgIcon(short id, int typeGet)
	{
		ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(id + string.Empty);
		int num = (int)id - GameData.ID_START_SKILL;
		if (imageIcon == null)
		{
			imageIcon = new ImageIcon();
			imageIcon.id = id;
			imageIcon.isLoad = true;
			GameData.listImgIcon.put(id + string.Empty, imageIcon);
			if (imageIcon.img == null && (int)id >= GameData.ID_START_SKILL)
			{
				try
				{
					imageIcon.img = mImage.createImage("/imgDataEff/" + num + ".png");
				}
				catch (Exception ex)
				{
				}
			}
			if (imageIcon.img == null && mSystem.currentTimeMillis() / 1000L - imageIcon.timeGetBack > 30L)
			{
				GlobalService.gI().load_image_data_part_char((sbyte)typeGet, (short)num);
			}
		}
		else
		{
			imageIcon.timeRemove = GameCanvas.timeNow;
		}
		return imageIcon;
	}

	// Token: 0x0600032B RID: 811 RVA: 0x0002B39C File Offset: 0x0002959C
	public static void RequestImgandData(short id, int typeGet)
	{
		ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(id + string.Empty);
		int num = (int)id - GameData.ID_START_SKILL;
		if (imageIcon == null)
		{
			imageIcon = new ImageIcon();
			imageIcon.id = id;
			imageIcon.isLoad = true;
			GameData.listImgIcon.put(id + string.Empty, imageIcon);
			if (imageIcon.img == null && (int)id >= GameData.ID_START_SKILL)
			{
				try
				{
					imageIcon.img = mImage.createImage("/imgDataEff/" + num + ".png");
				}
				catch (Exception ex)
				{
				}
			}
			if (imageIcon.img == null && mSystem.currentTimeMillis() / 1000L - imageIcon.timeGetBack > 30L)
			{
				GlobalService.gI().load_image_data_part_char((sbyte)typeGet, (short)num);
			}
			imageIcon.timeRemove = (long)((int)(mSystem.currentTimeMillis() / 1000L));
		}
	}

	// Token: 0x0600032C RID: 812 RVA: 0x0002B4AC File Offset: 0x000296AC
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = GameData.listImgIcon.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				ImageIcon imageIcon = (ImageIcon)GameData.listImgIcon.get(k);
				if ((GameCanvas.timeNow - imageIcon.timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					GameData.listImgIcon.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000407 RID: 1031
	public static int ID_START_SKILL = 0;

	// Token: 0x04000408 RID: 1032
	private static GameData me;

	// Token: 0x04000409 RID: 1033
	public static FrameImage imgSkillIcon;

	// Token: 0x0400040A RID: 1034
	public static mVector imgHorse = new mVector();

	// Token: 0x0400040B RID: 1035
	public static mHashTable listImgIcon = new mHashTable();

	// Token: 0x0400040C RID: 1036
	private bool loadData;

	// Token: 0x0400040D RID: 1037
	private static sbyte idWait = 0;
}
