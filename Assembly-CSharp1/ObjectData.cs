using System;
using System.Collections;

// Token: 0x02000067 RID: 103
public class ObjectData
{
	// Token: 0x060004E8 RID: 1256 RVA: 0x00044D28 File Offset: 0x00042F28
	public static MainImage getImagePartNPC(short id)
	{
		MainImage mainImage = (MainImage)GameScreen.HashImageNPC.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			GameScreen.HashImageNPC.put(string.Empty + id, mainImage);
			string url = "/resLocal/npc/" + id + ".png";
			if (id >= 500)
			{
				int num = (int)(id - 500);
				url = "/resLocal/npc/icon/" + num + ".png";
			}
			mImage mImage = mImage.createImage(url);
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 3000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 3000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004E9 RID: 1257 RVA: 0x00044E2C File Offset: 0x0004302C
	public static MainImage getImagePartItemMap(short id)
	{
		MainImage mainImage = (MainImage)GameScreen.HashImageItemMap.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			GameScreen.HashImageItemMap.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/tree/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000L);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004EA RID: 1258 RVA: 0x00044F1C File Offset: 0x0004311C
	public static MainImage getImagePartMonster(short id)
	{
		MainImage mainImage = (MainImage)MainMonster.HashImageMonster.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			MainMonster.HashImageMonster.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/mons/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 1000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000L);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 1000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004EB RID: 1259 RVA: 0x00045018 File Offset: 0x00043218
	public static MainImage getImageItem(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageItem.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageItem.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/icon/icon_" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 2000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 2000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004EC RID: 1260 RVA: 0x000450F0 File Offset: 0x000432F0
	public static MainImage getImagePotion(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImagePotion.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImagePotion.put(string.Empty + id, mainImage);
			string url = "/resLocal/potion/potionIcon_" + ((id + 1 < 10) ? ("0" + (int)(id + 1)) : ((int)(id + 1) + string.Empty)) + ".png";
			mImage mImage = mImage.createImage(url);
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 4000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 4000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004ED RID: 1261 RVA: 0x000451F8 File Offset: 0x000433F8
	public static MainImage getImageQuestItem(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageQuestItem.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageQuestItem.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/iconq/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 5000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 5000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004EE RID: 1262 RVA: 0x000452D0 File Offset: 0x000434D0
	public static MainImage getImageMaterial(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageMaterial.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageMaterial.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/material/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 5500);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 5500);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004EF RID: 1263 RVA: 0x000453A8 File Offset: 0x000435A8
	public static MainImage getImageSkill(short id)
	{
		MainImage mainImage = (MainImage)Skill.hashImageSkill.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Skill.hashImageSkill.put(string.Empty + id, mainImage);
			string url = (id >= 10) ? ("/resLocal/skill/iconSkill_" + id + ".png") : ("/resLocal/skill/iconSkill_0" + id + ".png");
			mImage mImage = mImage.createImage(url);
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 6000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 6000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004F0 RID: 1264 RVA: 0x000454A4 File Offset: 0x000436A4
	public static MainImage getImageIconClan(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageIconClan.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageIconClan.put(string.Empty + id, mainImage);
			string url = "/resLocal/iconclan/" + id + ".png";
			if (id >= 500)
			{
				int num = (int)(id - 500);
				url = "/resLocal/iconclan/shop/" + num + ".png";
			}
			mImage mImage = mImage.createImage(url);
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 7000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		else if (!GameCanvas.isTouch)
		{
			mainImage.count = (int)(GameCanvas.timeNow / 1000L);
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 7000);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004F1 RID: 1265 RVA: 0x000455C8 File Offset: 0x000437C8
	public static MainImage getImageIconArCheClan(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageIconArcheClan.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageIconArcheClan.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/iconclan/huyhieu/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 9500);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 9500);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004F2 RID: 1266 RVA: 0x000456A0 File Offset: 0x000438A0
	public static MainImage getImageIconPet(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImagePetIcon.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImagePetIcon.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/pet/icon/icon_pet_" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 10000);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		return mainImage;
	}

	// Token: 0x060004F3 RID: 1267 RVA: 0x00045738 File Offset: 0x00043938
	public static MainImage getImagePet(short id)
	{
		MainImage mainImage = (MainImage)Pet.HashImagePet.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Pet.HashImagePet.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/pet/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 10200);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 10200);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x060004F4 RID: 1268 RVA: 0x00045810 File Offset: 0x00043A10
	public static mImage getFromRms(short id)
	{
		mImage result = null;
		sbyte[] array = null;
		string text = "image" + id;
		if (ObjectData.setIdOK(id))
		{
			array = CRes.loadRMS(text);
		}
		if (array == null)
		{
			GlobalService.gI().load_image(id);
			return result;
		}
		try
		{
			result = mImage.createImage(array, 0, array.Length, text);
		}
		catch (Exception ex)
		{
			GlobalService.gI().load_image(id);
			return null;
		}
		return result;
	}

	// Token: 0x060004F5 RID: 1269 RVA: 0x000458A4 File Offset: 0x00043AA4
	public static bool setIdOK(short id)
	{
		return (int)TemMidlet.DIVICE != 0 || (id >= 4000 && id < 5000) || (id >= 3000 && id < 3500) || (id >= 6000 && id < 7000);
	}

	// Token: 0x060004F6 RID: 1270 RVA: 0x00045904 File Offset: 0x00043B04
	public static void setToRms(sbyte[] mimg, short id)
	{
		try
		{
			CRes.saveRMS("image" + id, mimg);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060004F7 RID: 1271 RVA: 0x00045950 File Offset: 0x00043B50
	public static void checkDelHash(mHashTable hash)
	{
		IDictionaryEnumerator enumerator = hash.GetEnumerator();
		while (enumerator.MoveNext())
		{
			string k = enumerator.Key.ToString();
			MainImage mainImage = (MainImage)hash.get(k);
			if (GameCanvas.timeNow / 1000L - (long)mainImage.count > 300L)
			{
				hash.remove(k);
			}
		}
	}

	// Token: 0x060004F8 RID: 1272 RVA: 0x000459B4 File Offset: 0x00043BB4
	public static MainImage getImageMount(short id)
	{
		MainImage mainImage = (MainImage)Item.HashImageMount.get(string.Empty + id);
		if (mainImage == null)
		{
			mainImage = new MainImage();
			Item.HashImageMount.put(string.Empty + id, mainImage);
			mImage mImage = mImage.createImage("/resLocal/mount/" + id + ".png");
			if (mImage == null)
			{
				mainImage.img = ObjectData.getFromRms(id + 10700);
			}
			else
			{
				mainImage.img = mImage;
			}
		}
		if (mainImage.img == null)
		{
			mainImage.timeImageNull++;
			if (mainImage.timeImageNull >= 200)
			{
				GlobalService.gI().load_image(id + 10700);
				mainImage.timeImageNull = 0;
			}
		}
		return mainImage;
	}

	// Token: 0x040006E6 RID: 1766
	public const short ITEMMAP = 0;

	// Token: 0x040006E7 RID: 1767
	public const short MONSTER = 1000;

	// Token: 0x040006E8 RID: 1768
	public const short ITEM = 2000;

	// Token: 0x040006E9 RID: 1769
	public const short NPC = 3000;

	// Token: 0x040006EA RID: 1770
	public const short POTION = 4000;

	// Token: 0x040006EB RID: 1771
	public const short QUEST_ITEM = 5000;

	// Token: 0x040006EC RID: 1772
	public const short MATERIAL = 5500;

	// Token: 0x040006ED RID: 1773
	public const short SKILL = 6000;

	// Token: 0x040006EE RID: 1774
	public const short ICON_CLAN = 7000;

	// Token: 0x040006EF RID: 1775
	public const short ICON_ARCHE_CLAN = 9500;

	// Token: 0x040006F0 RID: 1776
	public const short CAPCHAR = 9999;

	// Token: 0x040006F1 RID: 1777
	public const short ICON_PET = 10000;

	// Token: 0x040006F2 RID: 1778
	public const short IMAGE_PET = 10200;

	// Token: 0x040006F3 RID: 1779
	public const short IMAGE_TILE = 10400;

	// Token: 0x040006F4 RID: 1780
	public const short IMAGE_TILE_WATER = 10500;

	// Token: 0x040006F5 RID: 1781
	public const short IMAGE_TILE_SMALL = 10600;

	// Token: 0x040006F6 RID: 1782
	public const short IMAGE_MOUNT = 10700;

	// Token: 0x040006F7 RID: 1783
	public const short ITEM_2 = 13000;

	// Token: 0x040006F8 RID: 1784
	public static mVector vecSaveImage = new mVector("ObjectData vecSaveImage");
}
