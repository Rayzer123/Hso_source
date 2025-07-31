using System;
using System.Globalization;
using UnityEngine;

// Token: 0x020000D7 RID: 215
public class MiniMap
{
	// Token: 0x060009FE RID: 2558 RVA: 0x000A89B0 File Offset: 0x000A6BB0
	public static MiniMap gI()
	{
		return (MiniMap.me != null) ? MiniMap.me : (MiniMap.me = new MiniMap());
	}

	// Token: 0x060009FF RID: 2559 RVA: 0x000A89D4 File Offset: 0x000A6BD4
	public void setSize()
	{
		if (GameCanvas.w > 300 && GameCanvas.h > 300)
		{
			MiniMap.wMini = 3;
		}
		else if (GameCanvas.w > 200 && GameCanvas.h > 200)
		{
			MiniMap.wMini = 2;
		}
		this.maxX = 25;
		this.maxY = 20;
		if (this.maxX > GameCanvas.loadmap.mapW)
		{
			this.maxX = GameCanvas.loadmap.mapW;
		}
		if (this.maxY > GameCanvas.loadmap.mapH)
		{
			this.maxY = GameCanvas.loadmap.mapH;
		}
		if (GameCanvas.isTouch)
		{
			PaintInfoGameScreen.xFocus = GameCanvas.w - GameCanvas.minimap.maxX * MiniMap.wMini - 55;
		}
		this.miniCamera.setAll((GameCanvas.loadmap.mapW - this.maxX) * MiniMap.wMini, (GameCanvas.loadmap.mapH - this.maxY) * MiniMap.wMini, (GameScreen.player.x / LoadMap.wTile - this.maxX / 2) * MiniMap.wMini, (GameScreen.player.y / LoadMap.wTile - this.maxY / 2) * MiniMap.wMini);
		if (MiniMap.imgMiniMap != null && MiniMap.imgMiniMap.image != null)
		{
			MiniMap.imgMiniMap.image.texture = null;
			MiniMap.imgMiniMap.image = null;
			mSystem.gcc();
		}
		MiniMap.isLoadMiniMapOk = false;
		MiniMap.isAtMiniMap = true;
		MiniMap.CreateMiniMap(MiniMap.wMini, (!Main.isWindowsPhone) ? 0 : 1);
	}

	// Token: 0x06000A00 RID: 2560 RVA: 0x000A8B88 File Offset: 0x000A6D88
	public static void loadColorMiniMap(int tileId)
	{
		if (MiniMap.colorMiniMap[tileId] != null)
		{
			return;
		}
		mImage[] array = new mImage[MiniMap.totalTile[tileId]];
		MiniMap.colorMiniMap[tileId] = new Color[MiniMap.totalTile[tileId]][];
		for (int i = 0; i < MiniMap.totalTile[tileId]; i++)
		{
			string text = (i >= 9) ? ("tile_small" + tileId + "_") : ("tile_small" + tileId + "_0");
			array[i] = mImage.createImage(string.Concat(new object[]
			{
				"/Tile/tile_small",
				tileId,
				"/",
				text,
				i + 1,
				".png"
			}));
			MiniMap.colorMiniMap[tileId][i] = array[i].image.texture.GetPixels();
			array[i].image.texture = null;
			array[i] = null;
		}
		mSystem.gcc();
	}

	// Token: 0x06000A01 RID: 2561 RVA: 0x000A8C88 File Offset: 0x000A6E88
	public static byte[] getByteArray(Image img)
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

	// Token: 0x06000A02 RID: 2562 RVA: 0x000A8CD8 File Offset: 0x000A6ED8
	public mImage loadMiniMapWinDowsPhone(int s)
	{
		mImage mImage = null;
		try
		{
			MiniMap.isLoadMiniMapOk = false;
			MiniMap.loadColorMiniMap(LoadMap.idTile);
			string text = string.Concat(new object[]
			{
				"x",
				mGraphics.zoomLevel,
				"minimap",
				LoadMap.me.idMap
			});
			sbyte[] array = Rms.loadRMS(text);
			if (array != null)
			{
				mImage.image = Image.createImage(array, 0, array.Length, text);
			}
			else
			{
				try
				{
					for (int i = 0; i < GameCanvas.loadmap.mapW; i++)
					{
						for (int j = 0; j < GameCanvas.loadmap.mapH; j++)
						{
							int num = GameCanvas.loadmap.mapPaint[j * GameCanvas.loadmap.mapW + i] - 1;
							if (num > -1 && num < MiniMap.colorMiniMap[LoadMap.idTile].Length)
							{
								mImage.image.texture.SetPixels(i * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - j) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, MiniMap.colorMiniMap[LoadMap.idTile][num]);
							}
						}
					}
				}
				catch (Exception ex)
				{
					Debug.Log(ex.ToString());
					MiniMap.loi = "11111   " + ex.ToString();
				}
				mImage.image.texture.Apply();
				byte[] byteArray = MiniMap.getByteArray(mImage.image);
				Rms.saveRMS(text, ArrayCast.cast(byteArray));
			}
			MiniMap.isLoadMiniMapOk = true;
		}
		catch (Exception ex2)
		{
			MiniMap.loi = ex2.ToString();
		}
		return mImage;
	}

	// Token: 0x06000A03 RID: 2563 RVA: 0x000A8EC8 File Offset: 0x000A70C8
	public static ImageData getImgData(short idSmall, short add, bool isThread)
	{
		ImageData imageData = (ImageData)MiniMap.totalSmallImage.get((int)(idSmall + add) + string.Empty);
		if (GameCanvas.loadmap.mapW == 1 && GameCanvas.loadmap.mapH == 1)
		{
			return null;
		}
		if (imageData == null)
		{
			imageData = new ImageData();
			imageData.id = idSmall;
			string text = "xcreatminimap_" + (int)(idSmall + add);
			sbyte[] array = Rms.loadRMS(text);
			if (array != null)
			{
				imageData.img = mImage.createImage(array, 0, array.Length, text);
				MiniMap.isLoadMiniMapOk = true;
			}
			else if (isThread)
			{
				imageData.img = MiniMap.LoadAnhMiniMap(text, (int)idSmall, (int)add, GameCanvas.loadmap.mapW, GameCanvas.loadmap.mapH, Main.sizeMiniMap);
			}
			else
			{
				MiniMap.isLoadMiniMapOk = false;
			}
			imageData.timeRemove = (int)(mSystem.currentTimeMillis() / 1000L);
			MiniMap.isLoadMiniMapOk = true;
			imageData.timeGetBack = (long)((int)(mSystem.currentTimeMillis() / 1000L));
			MiniMap.totalSmallImage.put(string.Empty + (int)(idSmall + add), imageData);
		}
		else
		{
			if (imageData.img == null)
			{
				MiniMap.isLoadMiniMapOk = false;
				string text2 = "xcreatminimap_" + (int)(idSmall + add);
				sbyte[] array2 = Rms.loadRMS(text2);
				if (array2 != null)
				{
					imageData.img = mImage.createImage(array2, 0, array2.Length, text2);
					MiniMap.isLoadMiniMapOk = true;
				}
				else if (isThread)
				{
					imageData.img = MiniMap.LoadAnhMiniMap(text2, (int)idSmall, (int)add, GameCanvas.loadmap.mapW, GameCanvas.loadmap.mapH, Main.sizeMiniMap);
					MiniMap.isLoadMiniMapOk = true;
				}
				else
				{
					MiniMap.isLoadMiniMapOk = false;
				}
			}
			else
			{
				MiniMap.isLoadMiniMapOk = true;
			}
			imageData.timeRemove = (int)(mSystem.currentTimeMillis() / 1000L);
		}
		return imageData;
	}

	// Token: 0x06000A04 RID: 2564 RVA: 0x000A90A4 File Offset: 0x000A72A4
	public static mImage LoadAnhMiniMap(string pathRSM, int id, int add, int w, int h, int sizeMiniMap)
	{
		try
		{
			mImage mImage = mImage.createImage(w * sizeMiniMap, h * sizeMiniMap);
			MiniMap.isLoadMiniMapOk = false;
			MiniMap.loadColorMiniMap(LoadMap.idTile);
			Color[] array = null;
			if (GameCanvas.mapBack != null)
			{
				string text = GameCanvas.mapBack.colorMini;
				if (text.IndexOf('x') != -1)
				{
					text = text.Replace("0x", string.Empty);
				}
				float num = 0f;
				float num2 = 0f;
				float num3 = 0f;
				if (text.Length == 6)
				{
					num = (float)int.Parse(text.Substring(0, 2), NumberStyles.AllowHexSpecifier);
					num2 = (float)int.Parse(text.Substring(2, 2), NumberStyles.AllowHexSpecifier);
					num3 = (float)int.Parse(text.Substring(4, 2), NumberStyles.AllowHexSpecifier);
				}
				Color color = new Color(num / 255f, num2 / 255f, num3 / 255f);
				array = new Color[sizeMiniMap * mGraphics.zoomLevel * sizeMiniMap * mGraphics.zoomLevel];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = color;
				}
			}
			try
			{
				for (int j = 0; j < w; j++)
				{
					for (int k = 0; k < h; k++)
					{
						int num4 = GameCanvas.loadmap.mapPaint[k * w + j] - 1;
						if (num4 <= -1 && array != null)
						{
							mImage.image.texture.SetPixels(j * sizeMiniMap * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, array);
						}
						if (num4 > -1 && num4 < MiniMap.colorMiniMap[LoadMap.idTile].Length)
						{
							if (!MiniMap.isStartMiniMap || id != GameCanvas.loadmap.idMap)
							{
								MiniMap.isLoadMiniMapOk = false;
								MiniMap.isStartMiniMap = true;
								return null;
							}
							mImage.image.texture.SetPixels(j * sizeMiniMap * mGraphics.zoomLevel, (h - 1 - k) * sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, sizeMiniMap * mGraphics.zoomLevel, MiniMap.colorMiniMap[LoadMap.idTile][num4]);
						}
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("Loi LoadAnhMiniMap:  " + ex.ToString());
			}
			mImage.image.texture.Apply();
			if (!MiniMap.isStartMiniMap || id != GameCanvas.loadmap.idMap)
			{
				MiniMap.isLoadMiniMapOk = false;
				MiniMap.isStartMiniMap = true;
				return null;
			}
			byte[] byteArray = MiniMap.getByteArray(mImage.image);
			Rms.saveRMS(pathRSM, ArrayCast.cast(byteArray));
			return mImage;
		}
		catch (Exception)
		{
		}
		return null;
	}

	// Token: 0x06000A05 RID: 2565 RVA: 0x000A93B0 File Offset: 0x000A75B0
	public static sbyte[] get_Byte_Array(Image img)
	{
		int[] array = new int[img.getWidth() * img.getHeight()];
		sbyte[] result = null;
		try
		{
			img.getRGB(array, 0, img.getWidth(), 0, 0, img.getWidth(), img.getHeight());
		}
		catch (Exception ex)
		{
		}
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			for (int i = 0; i < array.Length; i++)
			{
				dataOutputStream.writeInt(array[i]);
			}
			result = dataOutputStream.toByteArray();
			dataOutputStream.close();
			dataOutputStream.close();
		}
		catch (Exception ex2)
		{
		}
		return result;
	}

	// Token: 0x06000A06 RID: 2566 RVA: 0x000A9478 File Offset: 0x000A7678
	public static void CreateMiniMap(int s, sbyte type)
	{
		MiniMap.isLoadMiniMapOk = false;
		mImage mImage = mImage.createImage(GameCanvas.loadmap.mapW * s, GameCanvas.loadmap.mapH * s);
		if ((int)type == 1)
		{
			Main.sizeMiniMap = s;
			Main.isLoad = true;
			Main.main.creatMiniMap();
			return;
		}
		MiniMap.loadColorMiniMap(LoadMap.idTile);
		Color[] array = null;
		if (GameCanvas.mapBack != null)
		{
			string text = GameCanvas.mapBack.colorMini;
			if (text.IndexOf('x') != -1)
			{
				text = text.Replace("0x", string.Empty);
			}
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			if (text.Length == 6)
			{
				num = (float)int.Parse(text.Substring(0, 2), NumberStyles.AllowHexSpecifier);
				num2 = (float)int.Parse(text.Substring(2, 2), NumberStyles.AllowHexSpecifier);
				num3 = (float)int.Parse(text.Substring(4, 2), NumberStyles.AllowHexSpecifier);
			}
			Color color = new Color(num / 255f, num2 / 255f, num3 / 255f);
			array = new Color[s * mGraphics.zoomLevel * s * mGraphics.zoomLevel];
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = color;
			}
		}
		try
		{
			for (int j = 0; j < GameCanvas.loadmap.mapW; j++)
			{
				for (int k = 0; k < GameCanvas.loadmap.mapH; k++)
				{
					int num4 = GameCanvas.loadmap.mapPaint[k * GameCanvas.loadmap.mapW + j] - 1;
					if (num4 <= -1 && array != null)
					{
						mImage.image.texture.SetPixels(j * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, array);
					}
					if (num4 > -1 && num4 < MiniMap.colorMiniMap[LoadMap.idTile].Length)
					{
						mImage.image.texture.SetPixels(j * s * mGraphics.zoomLevel, (GameCanvas.loadmap.mapH - 1 - k) * s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, s * mGraphics.zoomLevel, MiniMap.colorMiniMap[LoadMap.idTile][num4]);
					}
				}
			}
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString() + MiniMap.colorMiniMap[LoadMap.idTile].Length);
		}
		mImage.image.texture.Apply();
		if (MiniMap.isAtMiniMap)
		{
			MiniMap.imgMiniMap = mImage;
		}
		else
		{
			MiniMapFull_Screen.gI().imgtest = mImage;
		}
		MiniMap.isLoadMiniMapOk = true;
	}

	// Token: 0x06000A07 RID: 2567 RVA: 0x000A975C File Offset: 0x000A795C
	public void paint(mGraphics g)
	{
		if (GameScreen.infoGame.isMapThachdau() || GameScreen.infoGame.isMapchienthanh())
		{
			return;
		}
		g.setColor(7612434);
		g.fillRect(-3, -3 + mGraphics.addYWhenOpenKeyBoard, this.maxX * MiniMap.wMini + 6, this.maxY * MiniMap.wMini + 6, mGraphics.isFalse);
		g.setColor(16307052);
		g.fillRect(-2, -2 + mGraphics.addYWhenOpenKeyBoard, this.maxX * MiniMap.wMini + 4, this.maxY * MiniMap.wMini + 4, mGraphics.isFalse);
		g.setColor((!MiniMap.isLoadMiniMapOk) ? 0 : 4724752);
		g.fillRect(-1, -1 + mGraphics.addYWhenOpenKeyBoard, this.maxX * MiniMap.wMini + 2, this.maxY * MiniMap.wMini + 2, mGraphics.isFalse);
		g.setClip(0, 0 + mGraphics.addYWhenOpenKeyBoard, this.maxX * MiniMap.wMini, this.maxY * MiniMap.wMini);
		if (!MiniMap.isLoadMiniMapOk)
		{
			this.fWait++;
			MsgDialog.fraWaiting.drawFrame(this.fWait % MsgDialog.fraWaiting.nFrame, (this.maxX * MiniMap.wMini + 2) / 2, (this.maxY * MiniMap.wMini + 4) / 2 - 5, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
		}
		g.translate(-this.miniCamera.xCam, -this.miniCamera.yCam);
		if (MiniMap.isLoadMiniMapOk && MiniMap.isAtMiniMap)
		{
			if (Main.isWindowsPhone)
			{
				ImageData imgData = MiniMap.getImgData((short)GameCanvas.loadmap.idMap, (short)GameCanvas.loadmap.idMap, false);
				if (imgData != null && !imgData.isLoad && imgData.img != null)
				{
					g.drawImage(imgData.img, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isTrue);
				}
			}
			else if (MiniMap.imgMiniMap != null)
			{
				g.drawImage(MiniMap.imgMiniMap, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isTrue);
			}
			int num = MiniMap.wMini;
			for (int i = 0; i < LoadMap.vecPointChange.size(); i++)
			{
				Point point = (Point)LoadMap.vecPointChange.elementAt(i);
				g.setColor(6156031);
				switch (point.f)
				{
				case 0:
					g.fillRect(point.x * num / LoadMap.wTile - num, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isTrue);
					break;
				case 1:
					g.fillRect(point.x * num / LoadMap.wTile, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isTrue);
					break;
				case 2:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isTrue);
					break;
				case 3:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isTrue);
					break;
				}
			}
		}
		if ((int)LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
		{
			for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if ((int)mainObject.typeObject == 1)
				{
					AvMain.fraObjMiniMap.drawFrame(11, mainObject.x / LoadMap.wTile * MiniMap.wMini, mainObject.y / LoadMap.wTile * MiniMap.wMini, 0, 3, g);
				}
			}
		}
		if (MiniMap.isLoadMiniMapOk)
		{
			for (int k = 0; k < MiniMap.vecNPC_Map.size(); k++)
			{
				NPCMini npcmini = (NPCMini)MiniMap.vecNPC_Map.elementAt(k);
				AvMain.fraObjMiniMap.drawFrame(npcmini.type + 4, npcmini.x / LoadMap.wTile * MiniMap.wMini, npcmini.y / LoadMap.wTile * MiniMap.wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
			}
		}
		if (MiniMap.isLoadMiniMapOk)
		{
			AvMain.fraObjMiniMap.drawFrame((GameScreen.player.Action != 4) ? GameScreen.player.Direction : 9, GameScreen.player.x / LoadMap.wTile * MiniMap.wMini, GameScreen.player.y / LoadMap.wTile * MiniMap.wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
		}
		if (!MiniMap.isLoadMiniMapOk)
		{
			return;
		}
		if (LoadMap.idTile == 9)
		{
			g.setColor(367554);
		}
		else
		{
			g.setColor(255);
		}
		if (Player.party != null)
		{
			for (int l = 0; l < Player.party.vecPartys.size(); l++)
			{
				ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(l);
				if (objectParty.name.CompareTo(GameScreen.player.name) != 0 && objectParty.idMap == GameCanvas.loadmap.idMap)
				{
					AvMain.fraObjMiniMap.drawFrame(10, objectParty.x / LoadMap.wTile * MiniMap.wMini, objectParty.y / LoadMap.wTile * MiniMap.wMini + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
				}
			}
		}
		if (MiniMap.pHelp != null && MiniMap.pHelp.frame == GameCanvas.loadmap.idMap)
		{
			int num2 = MiniMap.pHelp.x;
			int num3 = MiniMap.pHelp.y;
			if (num2 < this.miniCamera.xCam + 3)
			{
				num2 = this.miniCamera.xCam + 3;
			}
			if (num2 > this.miniCamera.xCam + this.maxX * MiniMap.wMini - 3)
			{
				num2 = this.miniCamera.xCam + this.maxX * MiniMap.wMini - 3;
			}
			if (num3 < this.miniCamera.yCam + 3)
			{
				num3 = this.miniCamera.yCam + 3;
			}
			if (num3 > this.miniCamera.yCam + this.maxY * MiniMap.wMini - 3)
			{
				num3 = this.miniCamera.yCam + this.maxY * MiniMap.wMini - 3;
			}
			WorldMapScreen.fraMyPos.drawFrame(GameCanvas.gameTick / 2 % WorldMapScreen.fraMyPos.nFrame, num2, num3 + mGraphics.addYWhenOpenKeyBoard, 0, 3, g);
		}
	}

	// Token: 0x06000A08 RID: 2568 RVA: 0x000A9E38 File Offset: 0x000A8038
	public static void addNPCMini(NPCMini npc)
	{
		MainObject mainObject = MainObject.get_Object(npc.ID, 2);
		if (mainObject != null)
		{
			MiniMap.SetTypeNPC(mainObject);
			npc.type = mainObject.typeNPC;
			MiniMap.vecNPC_Map.addElement(npc);
		}
	}

	// Token: 0x06000A09 RID: 2569 RVA: 0x000A9E78 File Offset: 0x000A8078
	public static void addMonMini(int id, sbyte tem)
	{
		MainObject mainObject = MainObject.get_Object(id, tem);
		if (mainObject != null)
		{
			NPCMini npcmini = new NPCMini(id, mainObject.x, mainObject.y);
			npcmini.type = 8;
			for (int i = 0; i < MiniMap.vecNPC_Map.size(); i++)
			{
				NPCMini npcmini2 = (NPCMini)MiniMap.vecNPC_Map.elementAt(i);
				if (npcmini2.ID == id && npcmini2.type == npcmini.type)
				{
					npcmini2.x = npcmini.x;
					npcmini2.y = npcmini.y;
					return;
				}
			}
			MiniMap.vecNPC_Map.addElement(npcmini);
		}
	}

	// Token: 0x06000A0A RID: 2570 RVA: 0x000A9F1C File Offset: 0x000A811C
	public static void SetTypeNPC(MainObject obj)
	{
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == obj.ID && (obj.typeNPC == 0 || obj.typeNPC == 2))
			{
				obj.typeNPC = 1;
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == obj.ID)
			{
				obj.typeNPC = 3;
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == obj.ID && obj.typeNPC == 0)
			{
				obj.typeNPC = 2;
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == obj.ID && obj.typeNPC == 0)
			{
				obj.typeNPC = 2;
			}
		}
	}

	// Token: 0x06000A0B RID: 2571 RVA: 0x000AA074 File Offset: 0x000A8274
	public void setPoint(int x, int y, int idMap)
	{
		if (MiniMap.pHelp == null)
		{
			MiniMap.pHelp = new Point();
		}
		MiniMap.pHelp.x = x * MiniMap.wMini - MiniMap.wMini / 2;
		MiniMap.pHelp.y = y * MiniMap.wMini - MiniMap.wMini / 2;
		MiniMap.pHelp.frame = idMap;
	}

	// Token: 0x06000A0C RID: 2572 RVA: 0x000AA0D4 File Offset: 0x000A82D4
	public void updatePoint()
	{
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000A0D RID: 2573 RVA: 0x000AA0D8 File Offset: 0x000A82D8
	// (set) Token: 0x06000A0E RID: 2574 RVA: 0x000AA0E0 File Offset: 0x000A82E0
	public int fWait { get; set; }

	// Token: 0x040011C9 RID: 4553
	public int maxX;

	// Token: 0x040011CA RID: 4554
	public int maxY;

	// Token: 0x040011CB RID: 4555
	public static int wMini = 3;

	// Token: 0x040011CC RID: 4556
	public global::Camera miniCamera = new global::Camera();

	// Token: 0x040011CD RID: 4557
	public static mImage imgMiniMap;

	// Token: 0x040011CE RID: 4558
	public static mVector vecNPC_Map = new mVector("MiniMap vecNPC_Map");

	// Token: 0x040011CF RID: 4559
	public static Point pHelp;

	// Token: 0x040011D0 RID: 4560
	public static MiniMap me;

	// Token: 0x040011D1 RID: 4561
	public static bool isStartMiniMap = false;

	// Token: 0x040011D2 RID: 4562
	public static mHashTable totalSmallImage = new mHashTable();

	// Token: 0x040011D3 RID: 4563
	public static bool isLoadMiniMapOk;

	// Token: 0x040011D4 RID: 4564
	public static Color[][][] colorMiniMap = new Color[17][][];

	// Token: 0x040011D5 RID: 4565
	public static int[] totalTile = new int[]
	{
		72,
		60,
		57,
		64,
		47,
		43,
		66,
		61,
		52,
		51,
		61,
		62,
		67,
		69,
		59,
		99,
		99
	};

	// Token: 0x040011D6 RID: 4566
	public static string loi = "loi";

	// Token: 0x040011D7 RID: 4567
	public static bool isAtMiniMap;

	// Token: 0x040011D8 RID: 4568
	private int[] color = new int[]
	{
		1045997,
		16115463,
		12237219,
		15603253
	};
}
