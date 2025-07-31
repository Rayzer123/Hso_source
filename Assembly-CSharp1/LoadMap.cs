using System;
using UnityEngine;

// Token: 0x020000D3 RID: 211
public class LoadMap
{
	// Token: 0x060009D1 RID: 2513 RVA: 0x000A5F20 File Offset: 0x000A4120
	public LoadMap()
	{
		this.maxX = GameCanvas.w / LoadMap.wTile + 1;
		this.maxY = GameCanvas.h / LoadMap.wTile + 1;
		this.load_Table_Map();
		LoadMap.me = this;
	}

	// Token: 0x060009D2 RID: 2514 RVA: 0x000A5F70 File Offset: 0x000A4170
	// Note: this type is marked as 'beforefieldinit'.
	static LoadMap()
	{
		int[] array = new int[4];
		array[0] = 5;
		array[1] = 4;
		array[2] = 1;
		LoadMap.mTranPointChangeMap = array;
		LoadMap.isShowEffAuto = 0;
		LoadMap.EFF_NORMAL = 0;
		LoadMap.EFF_PHOBANG_END = 1;
		LoadMap.idTile = -1;
		LoadMap.wTile = 24;
		LoadMap.timeVibrateScreen = 0;
		LoadMap.Area = 0;
		LoadMap.MaxArea = 10;
		LoadMap.typeMap = 0;
		LoadMap.imgTileMap = new mImage[80];
		LoadMap.Thacnuoc = new mVector("LoadMap Thacnuoc");
		LoadMap.colorMap = new Color[9][][];
		LoadMap.totalTile = new int[]
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
		LoadMap.mItemMapLogin = new MainItemMap[0];
	}

	// Token: 0x060009D3 RID: 2515 RVA: 0x000A605C File Offset: 0x000A425C
	public static LoadMap get_Item()
	{
		return (LoadMap.me != null) ? LoadMap.me : (LoadMap.me = new LoadMap());
	}

	// Token: 0x060009D4 RID: 2516 RVA: 0x000A6080 File Offset: 0x000A4280
	public bool mapLang()
	{
		return GameScreen.isMapLang;
	}

	// Token: 0x060009D5 RID: 2517 RVA: 0x000A6088 File Offset: 0x000A4288
	public void load_Table_Map()
	{
		try
		{
			DataInputStream dataInputStream = mImage.openFile("/table_item");
			short num = dataInputStream.readShort();
			for (short num2 = 0; num2 < num; num2 += 1)
			{
				short idimage = dataInputStream.readShort();
				dataInputStream.readByte();
				short dx = dataInputStream.readShort();
				short dy = dataInputStream.readShort();
				sbyte b = dataInputStream.readByte();
				int[][] array = mSystem.new_M_Int((int)b, 2);
				for (int i = 0; i < (int)b; i++)
				{
					array[i][0] = (int)dataInputStream.readByte();
					array[i][1] = (int)dataInputStream.readByte();
				}
				LoadMap.vecMapItem.addElement(new MainItemMap(num2, idimage, (int)dx, (int)dy, array));
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi load map 1");
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x060009D6 RID: 2518 RVA: 0x000A6180 File Offset: 0x000A4380
	public static void load_Table_Map(sbyte[] tableItem)
	{
		try
		{
			LoadMap.vecMapItem.removeAllElements();
			DataInputStream dataInputStream = new DataInputStream(tableItem);
			short num = dataInputStream.readShort();
			for (short num2 = 0; num2 < num; num2 += 1)
			{
				short idimage = dataInputStream.readShort();
				dataInputStream.readByte();
				short dx = dataInputStream.readShort();
				short dy = dataInputStream.readShort();
				sbyte b = dataInputStream.readByte();
				int[][] array = mSystem.new_M_Int((int)b, 2);
				for (int i = 0; i < (int)b; i++)
				{
					array[i][0] = (int)dataInputStream.readByte();
					array[i][1] = (int)dataInputStream.readByte();
				}
				LoadMap.vecMapItem.addElement(new MainItemMap(num2, idimage, (int)dx, (int)dy, array));
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi load map 1");
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x060009D7 RID: 2519 RVA: 0x000A627C File Offset: 0x000A447C
	public static void loadTileBig(int id, bool isLogin)
	{
		if (!LoadMap.isTileMoi() && Main.isSprite && !isLogin)
		{
			return;
		}
		if (id < 0)
		{
			return;
		}
		LoadMap.resetDataImgTileBig();
		if (id <= 10)
		{
			LoadMap.imgTileMap = new mImage[MiniMap.totalTile[id]];
		}
		else
		{
			LoadMap.imgTileMap = new mImage[80];
		}
		if (id == 15)
		{
			LoadMap.imgTileMap = new mImage[100];
		}
		if (id == 16)
		{
			LoadMap.imgTileMap = new mImage[100];
		}
		for (int i = 0; i < LoadMap.imgTileMap.Length; i++)
		{
			string text = (i >= 9) ? ("tile" + id + "_") : ("tile" + id + "_0");
			mImage mImage = mImage.createImage(string.Concat(new object[]
			{
				"/Tile/tile",
				id,
				"/",
				text,
				i + 1,
				".png"
			}));
			LoadMap.imgTileMap[i] = mImage;
		}
		if (id == 1 || id == 9 || id == 10)
		{
			LoadMap.loadMapLoginPc(id);
		}
	}

	// Token: 0x060009D8 RID: 2520 RVA: 0x000A63BC File Offset: 0x000A45BC
	public static void loadMapLoginPc(int id)
	{
		if (Main.imgTileMapLogin == null)
		{
			Main.imgTileMapLogin = new mImage[80];
		}
		for (int i = 0; i < LoadMap.imgTileMap.Length; i++)
		{
			string text = (i >= 9) ? ("tile" + id + "_") : ("tile" + id + "_0");
			if (Main.imgTileMapLogin[i] == null)
			{
				Main.imgTileMapLogin[i] = mImage.createImage(string.Concat(new object[]
				{
					"/Tile/tile",
					id,
					"/",
					text,
					i + 1,
					".png"
				}));
			}
		}
	}

	// Token: 0x060009D9 RID: 2521 RVA: 0x000A6484 File Offset: 0x000A4684
	public static void resetDataImgTileBig()
	{
		for (int i = 0; i < LoadMap.imgTileMap.Length; i++)
		{
			if (LoadMap.imgTileMap[i] != null && LoadMap.imgTileMap[i].image != null)
			{
				LoadMap.imgTileMap[i].image.texture = null;
				LoadMap.imgTileMap[i].image = null;
			}
		}
		mSystem.gcc();
	}

	// Token: 0x060009DA RID: 2522 RVA: 0x000A64EC File Offset: 0x000A46EC
	public void loadmap(sbyte[] mbyte)
	{
		try
		{
			LoadMap.Thacnuoc.removeAllElements();
			DataInputStream dataInputStream = new DataInputStream(mbyte);
			this.mapW = (int)dataInputStream.readByte();
			this.mapH = (int)dataInputStream.readByte();
			int num = (int)dataInputStream.readByte();
			if (LoadMap.idTile != num)
			{
				LoadMap.idTile = num;
				LoadMap.loadTileBig(num, false);
				LoadMap.imgTileWater = mImage.createImage("/tilewater" + LoadMap.idTile + ".png");
				DataInputStream dataInputStream2 = mImage.openFile("/tile_map_info_" + LoadMap.idTile);
				this.fWater = dataInputStream2.read();
				this.fStand = dataInputStream2.read();
				if (LoadMap.isTileMoi())
				{
					if (LoadMap.idTile == 9)
					{
						this.fWater = 127;
						this.fStand = 19;
						this.fStartWater = 19;
						this.fEndWater = 26;
					}
					else if (LoadMap.idTile == 10)
					{
						this.fWater = 127;
						this.fStand = 5;
						this.fStartWater = 4;
						this.fEndWater = 25;
					}
					else if (LoadMap.idTile == 11)
					{
						this.fWater = 127;
						this.fStand = 21;
						this.fStartWater = 20;
						this.fEndWater = 37;
					}
					else if (LoadMap.idTile == 12)
					{
						this.fWater = 127;
						this.fStand = 34;
						this.fStartWater = 35;
						this.fEndWater = 44;
					}
					else if (LoadMap.idTile == 13)
					{
						this.fWater = 0;
						this.fStand = 47;
						this.fStartWater = 0;
						this.fEndWater = 0;
					}
					else if (LoadMap.idTile == 14)
					{
						this.fWater = 0;
						this.fStand = 26;
						this.fStartWater = 0;
						this.fEndWater = 0;
					}
					else if (LoadMap.idTile == 15)
					{
						this.fWater = 0;
						this.fStand = 9;
						this.fStartWater = 0;
						this.fEndWater = 0;
					}
					else if (LoadMap.idTile == 16)
					{
						this.fWater = 0;
						this.fStand = 42;
						this.fStartWater = 0;
						this.fEndWater = 0;
					}
				}
			}
			this.maxWMap = this.mapW * LoadMap.wTile;
			this.maxHMap = this.mapH * LoadMap.wTile;
			this.limitW = this.maxWMap - GameCanvas.w;
			this.limitH = this.maxHMap - GameCanvas.h;
			MainScreen.cameraMain.setAll(this.limitW, this.limitH, GameScreen.player.x - GameCanvas.hw, GameScreen.player.y - GameCanvas.hh);
			this.mapPaint = new int[this.mapW * this.mapH];
			this.mapType = new int[this.mapW * this.mapH];
			this.mapFind = new sbyte[this.mapW][];
			mSystem.setDataArrByte(ref this.mapFind, this.mapH);
			this.limitMap = this.mapW * this.mapH;
			for (int i = 0; i < this.mapW * this.mapH; i++)
			{
				sbyte b = dataInputStream.readByte();
				this.mapPaint[i] = (int)b;
				if (!LoadMap.isTileMoi())
				{
					if ((int)b >= this.fStand || (int)b == 0)
					{
						this.mapType[i] = 1;
					}
					else if ((int)b >= this.fWater)
					{
						this.mapType[i] = 2;
					}
					else
					{
						this.mapType[i] = 0;
					}
				}
				else
				{
					if (LoadMap.idTile == 9)
					{
						if ((int)b == 27 || (int)b == 28 || (int)b == 29 || (int)b == 30 || (int)b == 31)
						{
							ThacNuoc o = new ThacNuoc((int)b - 27, i % this.mapW * 24, i / this.mapW * 24);
							LoadMap.Thacnuoc.addElement(o);
						}
					}
					else if (LoadMap.idTile == 10)
					{
						if ((int)b == 18 || (int)b == 19)
						{
							ThacNuoc o2 = new ThacNuoc((int)b - 18 + 5, i % this.mapW * 24, i / this.mapW * 24);
							LoadMap.Thacnuoc.addElement(o2);
						}
					}
					else if (LoadMap.idTile == 11)
					{
						if ((int)b == 38 || (int)b == 39)
						{
							ThacNuoc o3 = new ThacNuoc((int)b - 38 + 7, i % this.mapW * 24, i / this.mapW * 24);
							LoadMap.Thacnuoc.addElement(o3);
						}
					}
					else if (LoadMap.idTile != 12)
					{
						if (LoadMap.idTile != 13)
						{
							if (LoadMap.idTile != 14)
							{
								if (LoadMap.idTile != 15)
								{
									if (LoadMap.idTile == 16)
									{
									}
								}
							}
						}
					}
					if ((int)b >= this.fStand || (int)b == 0)
					{
						this.mapType[i] = 1;
					}
					else
					{
						this.mapType[i] = 0;
					}
				}
			}
			LoadMap.isShowEffAuto = LoadMap.EFF_NORMAL;
			if (!LoadMap.isTileMoi())
			{
				if (Main.isSprite)
				{
					mSystem.loadImageMap(GameCanvas.loadmap.mapW * LoadMap.wTile, GameCanvas.loadmap.mapH * LoadMap.wTile, this.idMap);
				}
			}
			else
			{
				mSystem.loadImageMap(GameCanvas.loadmap.mapW * LoadMap.wTile, GameCanvas.loadmap.mapH * LoadMap.wTile, this.idMap);
			}
		}
		catch (Exception ex)
		{
			Cout.LogError2("loi load map 2" + ex.ToString());
		}
	}

	// Token: 0x060009DB RID: 2523 RVA: 0x000A6AD8 File Offset: 0x000A4CD8
	public static void loadColorMap(int tileId)
	{
		if (LoadMap.colorMap[tileId] != null)
		{
			return;
		}
		mImage[] array = new mImage[LoadMap.totalTile[tileId]];
		LoadMap.colorMap[tileId] = new Color[LoadMap.totalTile[tileId]][];
		for (int i = 0; i < LoadMap.totalTile[tileId]; i++)
		{
			string text = (i >= 9) ? ("tile" + tileId + "_") : ("tile" + tileId + "_0");
			array[i] = mImage.createImage(string.Concat(new object[]
			{
				"/Tile/tile",
				tileId,
				"/",
				text,
				i + 1,
				".png"
			}));
			LoadMap.colorMap[tileId][i] = array[i].image.texture.GetPixels();
			array[i].image.texture = null;
			array[i] = null;
		}
		mSystem.gcc();
	}

	// Token: 0x060009DC RID: 2524 RVA: 0x000A6BD8 File Offset: 0x000A4DD8
	public mImage loadImageMap(ItemMapSprite scr, ref int timeRemove, ref bool isLoadOK)
	{
		LoadMap.loadColorMap(LoadMap.idTile);
		mImage result;
		try
		{
			int num = LoadMap.wTile;
			mImage mImage = mImage.createImage(scr.wimg, scr.himg);
			int num2 = scr.x / 24;
			int num3 = scr.y / 24;
			int num4 = scr.wimg / 24;
			int num5 = scr.himg / 24;
			for (int i = 0; i < num4; i++)
			{
				for (int j = 0; j < num5; j++)
				{
					int num6 = GameCanvas.loadmap.mapPaint[(j + num3) * GameCanvas.loadmap.mapW + (i + num2)] - 1;
					if (num6 > -1)
					{
						mImage.image.texture.SetPixels(i * num * mGraphics.zoomLevel, (num5 - 1 - j) * num * mGraphics.zoomLevel, num * mGraphics.zoomLevel, num * mGraphics.zoomLevel, LoadMap.colorMap[LoadMap.idTile][num6]);
					}
				}
			}
			mImage.image.texture.Apply();
			timeRemove = (int)(mSystem.currentTimeMillis() / 1000L);
			isLoadOK = true;
			result = mImage;
		}
		catch (Exception ex)
		{
			Debug.Log(ex.ToString() + " LOI--------");
			result = null;
		}
		return result;
	}

	// Token: 0x060009DD RID: 2525 RVA: 0x000A6D44 File Offset: 0x000A4F44
	public void load_ItemMap(sbyte[] mbyte)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(mbyte);
			LoadMap.mItemMap.removeAllElements();
			short num = dataInputStream.readShort();
			int num2 = 0;
			for (int i = 0; i < (int)num; i++)
			{
				short id = dataInputStream.readShort();
				MainItemMap mainItemMap = this.get_Item((int)id);
				if (mainItemMap == null)
				{
					id = 85;
					mainItemMap = this.get_Item((int)id);
				}
				ItemMap itemMap = new ItemMap(mainItemMap.IDItem, mainItemMap.IDImage, mainItemMap.dx, mainItemMap.dy, mainItemMap.Block);
				short num3 = dataInputStream.readShort();
				short num4 = dataInputStream.readShort();
				if (!GameCanvas.lowGraphic || mainItemMap.Block.Length > 0)
				{
					this.Block_TileMap_Item((int)num3, (int)num4, mainItemMap.Block);
					itemMap.setInfoItem((int)num3 * LoadMap.wTile, (int)num4 * LoadMap.wTile);
					LoadMap.mItemMap.addElement(itemMap);
					num2++;
				}
			}
			if (dataInputStream.available() > 0 && !GameCanvas.lowGraphic)
			{
				short num5 = dataInputStream.readShort();
				mSystem.outz("size=" + num5);
				for (int j = 0; j < (int)num5; j++)
				{
					int num6 = (int)dataInputStream.readByte();
					string text = string.Empty;
					for (int k = 0; k < num6; k++)
					{
						text += (char)dataInputStream.readByte();
					}
					num6 = (int)dataInputStream.readByte();
					string text2 = string.Empty;
					for (int l = 0; l < num6; l++)
					{
						text2 += (char)dataInputStream.readByte();
					}
					LoadMap.mItemMap.addElement(GameScreen.addEffectAuto(text, text2));
				}
			}
			CRes.quickSort1(LoadMap.mItemMap);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x060009DE RID: 2526 RVA: 0x000A6F50 File Offset: 0x000A5150
	public void paint(mGraphics g)
	{
		try
		{
			int num = MainScreen.cameraMain.xCam / LoadMap.wTile - 1;
			int num2 = MainScreen.cameraMain.yCam / LoadMap.wTile - 1;
			if (num < 0)
			{
				num = 0;
			}
			if (num2 < 0)
			{
				num2 = 0;
			}
			int num3 = num + this.maxX + 2;
			int num4 = num2 + this.maxY + 2;
			if (num3 > this.mapW)
			{
				num3 = this.mapW;
			}
			if (num4 > this.mapH)
			{
				num4 = this.mapH;
			}
			for (int i = num; i < num3; i++)
			{
				for (int j = num2; j < num4; j++)
				{
					if (!LoadMapScreen.isNextMap)
					{
						break;
					}
					int num5 = this.mapPaint[j * this.mapW + i] - 1;
					if (!LoadMap.isTileMoi())
					{
						if (num5 >= this.fWater - 1 && num5 < this.fStand - 1 && ((GameCanvas.gameTick % 14 < 7 && i % 2 == 0) || (GameCanvas.gameTick % 14 > 7 && i % 2 != 0)))
						{
							g.drawRegionNotSetClip(LoadMap.imgTileWater, (num5 - (this.fWater - 1)) / 10 * LoadMap.wTile, (num5 - (this.fWater - 1)) % 10 * LoadMap.wTile, LoadMap.wTile, LoadMap.wTile, 0, i * LoadMap.wTile, j * LoadMap.wTile, 0);
						}
						else if (num5 > -1)
						{
							int num6 = num5 % 10;
							int num7 = num5 / 10;
							if (LoadMap.imgTileMap[num5] != null && !Main.isSprite)
							{
								g.drawImage(LoadMap.imgTileMap[num5], i * LoadMap.wTile, j * LoadMap.wTile, 0, mGraphics.isFalse);
							}
						}
					}
					else if (num5 >= this.fStartWater - 1 && num5 < this.fEndWater && ((GameCanvas.gameTick % 14 < 7 && i % 2 == 0) || (GameCanvas.gameTick % 14 > 7 && i % 2 != 0)))
					{
						g.drawRegionNotSetClip(LoadMap.imgTileWater, (num5 - (this.fStartWater - 1)) / 10 * LoadMap.wTile, (num5 - (this.fStartWater - 1)) % 10 * LoadMap.wTile, LoadMap.wTile, LoadMap.wTile, 0, i * LoadMap.wTile, j * LoadMap.wTile, 0);
					}
					else if (num5 > -1)
					{
						int num8 = num5 % 10;
						int num9 = num5 / 10;
						if (LoadMap.imgTileMap[num5] != null && !Main.isSprite)
						{
							g.drawImage(LoadMap.imgTileMap[num5], i * LoadMap.wTile, j * LoadMap.wTile, 0, mGraphics.isFalse);
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060009DF RID: 2527 RVA: 0x000A723C File Offset: 0x000A543C
	public void update()
	{
		if (!LoadMap.isTileMoi())
		{
			if (Main.isSprite)
			{
				for (int i = 0; i < mSystem.totalImageMap.size(); i++)
				{
					ItemMapSprite itemMapSprite = (ItemMapSprite)mSystem.totalImageMap.elementAt(i);
					if (itemMapSprite != null)
					{
						itemMapSprite.update();
					}
				}
			}
		}
		else
		{
			for (int j = 0; j < mSystem.totalImageMap.size(); j++)
			{
				ItemMapSprite itemMapSprite2 = (ItemMapSprite)mSystem.totalImageMap.elementAt(j);
				if (itemMapSprite2 != null)
				{
					itemMapSprite2.update();
				}
			}
		}
	}

	// Token: 0x060009E0 RID: 2528 RVA: 0x000A72D4 File Offset: 0x000A54D4
	public int getTile(int xset, int yset)
	{
		int num = yset / LoadMap.wTile * this.mapW + xset / LoadMap.wTile;
		if (num > this.limitMap || xset < 0 || xset >= this.limitW + GameCanvas.w || yset < 0 || yset >= this.limitH + GameCanvas.h)
		{
			return 1;
		}
		return this.mapType[num];
	}

	// Token: 0x060009E1 RID: 2529 RVA: 0x000A7340 File Offset: 0x000A5540
	public int getIndex(int xset, int yset)
	{
		return yset / LoadMap.wTile * this.mapW + xset / LoadMap.wTile;
	}

	// Token: 0x060009E2 RID: 2530 RVA: 0x000A7358 File Offset: 0x000A5558
	public MainItemMap get_Item(int id)
	{
		for (int i = 0; i < LoadMap.vecMapItem.size(); i++)
		{
			MainItemMap mainItemMap = (MainItemMap)LoadMap.vecMapItem.elementAt(i);
			if ((int)mainItemMap.IDItem == id)
			{
				return mainItemMap;
			}
		}
		return null;
	}

	// Token: 0x060009E3 RID: 2531 RVA: 0x000A73A0 File Offset: 0x000A55A0
	public void Block_TileMap_Item(int indexW, int indexH, int[][] mb)
	{
		try
		{
			for (int i = 0; i < mb.Length; i++)
			{
				if (indexW + mb[i][0] >= 0 && indexW + mb[i][0] < this.mapW && indexH + mb[i][1] >= 0 && indexH + mb[i][1] < this.mapH)
				{
					this.mapType[(indexH + mb[i][1]) * this.mapW + (indexW + mb[i][0])] = 1;
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi load map 4");
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x060009E4 RID: 2532 RVA: 0x000A7468 File Offset: 0x000A5668
	public void setBlockNPC(int x, int y, int w, int h)
	{
		if (this.mapW == 0)
		{
			this.mapW = 1;
		}
		int index = this.getIndex(x, y);
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				if (index % this.mapW - w / 2 + i >= 0 && index % this.mapW - w / 2 + i < this.mapW && index / this.mapW - h / 2 + j >= 0 && index / this.mapW - h / 2 < this.mapH)
				{
					this.mapType[(index / this.mapW - h / 2 + j) * this.mapW + (index % this.mapW - w / 2 + i)] = 1;
				}
			}
		}
	}

	// Token: 0x060009E5 RID: 2533 RVA: 0x000A753C File Offset: 0x000A573C
	public void setBlockNPC_Server(int x, int y, int w, int h)
	{
		if (this.mapW == 0)
		{
			this.mapW = 1;
		}
		int index = this.getIndex(x, y);
		for (int i = 0; i < w; i++)
		{
			for (int j = 0; j < h; j++)
			{
				if (index % this.mapW - w / 2 + i >= 0 && index % this.mapW - w / 2 + i < this.mapW && index / this.mapW - h / 2 + j >= 0 && index / this.mapW - h / 2 < this.mapH)
				{
					this.mapType[(index / this.mapW - h / 2 + j) * this.mapW + (index % this.mapW + i)] = 1;
				}
			}
		}
	}

	// Token: 0x060009E6 RID: 2534 RVA: 0x000A760C File Offset: 0x000A580C
	public static sbyte getAreaPaint()
	{
		return (sbyte)((int)LoadMap.Area + 1);
	}

	// Token: 0x060009E7 RID: 2535 RVA: 0x000A7618 File Offset: 0x000A5818
	public static string getTimeSpecialRegion()
	{
		string str = string.Empty;
		long num = (GameScreen.timeSpRegion - mSystem.currentTimeMillis()) / 1000L;
		if (num <= 0L)
		{
			return string.Empty;
		}
		long num2 = num / 3600L;
		long num3 = num / 60L;
		long num4 = num;
		if (num2 > 0L)
		{
			str = string.Concat(new object[]
			{
				num2,
				"h",
				num % 3600L / 60L,
				"'"
			});
		}
		else if (num3 > 0L)
		{
			str = string.Concat(new object[]
			{
				num3,
				"p",
				num % 60L,
				"s"
			});
		}
		else
		{
			str = num4 + "s";
		}
		return GameScreen.nameSpecialRegion + string.Empty + str;
	}

	// Token: 0x060009E8 RID: 2536 RVA: 0x000A7708 File Offset: 0x000A5908
	public static bool isTileMoi()
	{
		return LoadMap.idTile >= 9;
	}

	// Token: 0x060009E9 RID: 2537 RVA: 0x000A771C File Offset: 0x000A591C
	public static string getTimeArena(long timeStart)
	{
		string result = string.Empty;
		long num = (timeStart + 3600000L - mSystem.currentTimeMillis()) / 1000L;
		if (num <= 0L)
		{
			return string.Empty;
		}
		long num2 = num / 60L;
		long num3 = num;
		if (num2 > 0L)
		{
			if (num2 < 10L)
			{
				if (num % 60L >= 0L && num % 60L < 10L)
				{
					result = string.Concat(new object[]
					{
						"0",
						num2,
						":0",
						num % 60L
					});
				}
				else
				{
					result = string.Concat(new object[]
					{
						"0",
						num2,
						":",
						num % 60L
					});
				}
			}
			else if (num % 60L >= 0L && num % 60L < 10L)
			{
				result = num2 + ":0" + num % 60L;
			}
			else
			{
				result = num2 + ":" + num % 60L;
			}
		}
		else
		{
			result = ((num3 >= 10L) ? (num3 + "s") : ("0" + num3 + "s"));
		}
		return result;
	}

	// Token: 0x060009EA RID: 2538 RVA: 0x000A7884 File Offset: 0x000A5A84
	public static string convertSecondsToHMmSs(long now)
	{
		int num = (int)(now / 1000L) % 60;
		int num2 = (int)(now / 60000L % 60L);
		int num3 = (int)(now / 3600000L % 24L);
		if (num <= 0 && num3 <= 0 && num2 <= 0)
		{
			return string.Concat(new object[]
			{
				0,
				"h: ",
				0,
				"': ",
				0
			});
		}
		return string.Concat(new object[]
		{
			num3,
			"h: ",
			num2,
			"': ",
			num
		});
	}

	// Token: 0x060009EB RID: 2539 RVA: 0x000A793C File Offset: 0x000A5B3C
	public static string getTimeCountDown(long timeStart, int secondCount)
	{
		string result = string.Empty;
		long num = (timeStart + (long)(secondCount * 1000) - mSystem.currentTimeMillis()) / 1000L;
		if (num <= 0L)
		{
			return string.Empty;
		}
		long num2 = num / 60L;
		long num3 = num;
		if (num2 > 0L)
		{
			if (num2 < 10L)
			{
				if (num % 60L >= 0L && num % 60L < 10L)
				{
					result = string.Concat(new object[]
					{
						"0",
						num2,
						":0",
						num % 60L
					});
				}
				else
				{
					result = string.Concat(new object[]
					{
						"0",
						num2,
						":",
						num % 60L
					});
				}
			}
			else if (num % 60L >= 0L && num % 60L < 10L)
			{
				result = num2 + ":0" + num % 60L;
			}
			else
			{
				result = num2 + ":" + num % 60L;
			}
		}
		else
		{
			result = ((num3 >= 10L) ? (num3 + "s") : ("0" + num3 + "s"));
		}
		return result;
	}

	// Token: 0x060009EC RID: 2540 RVA: 0x000A7AA4 File Offset: 0x000A5CA4
	public static string converSecon2hours(int totalSeconds)
	{
		int num = totalSeconds % 60;
		int num2 = totalSeconds / 60;
		int num3 = num2 % 60;
		int num4 = num2 / 60;
		if (num4 > 0)
		{
			return num4 + ":" + num3;
		}
		if (num3 > 0)
		{
			return num3 + ":" + num;
		}
		if (num < 10)
		{
			return "0:" + num;
		}
		return num + string.Empty;
	}

	// Token: 0x04001175 RID: 4469
	public const int T_MAP_NULL = -1;

	// Token: 0x04001176 RID: 4470
	public const int T_MAP_NORMAL = 0;

	// Token: 0x04001177 RID: 4471
	public const int T_MAP_STAND = 1;

	// Token: 0x04001178 RID: 4472
	public const int T_MAP_SLOW = 2;

	// Token: 0x04001179 RID: 4473
	public static int MAP_NORMAL = 0;

	// Token: 0x0400117A RID: 4474
	public static int MAP_THACH_DAU = 1;

	// Token: 0x0400117B RID: 4475
	public static int MAP_PHO_BANG = 2;

	// Token: 0x0400117C RID: 4476
	public static int MAP_PET_CONTAINER = 3;

	// Token: 0x0400117D RID: 4477
	public static mVector vecMapItem = new mVector("LoadMap vecMapItem");

	// Token: 0x0400117E RID: 4478
	public static mVector vecPointChange = new mVector("LoadMap vecPointChange");

	// Token: 0x0400117F RID: 4479
	public static mVector mItemMap = new mVector("LoadMap mItemMap");

	// Token: 0x04001180 RID: 4480
	public static int[] mTranPointChangeMap;

	// Token: 0x04001181 RID: 4481
	public int idMap;

	// Token: 0x04001182 RID: 4482
	public int idMapMini;

	// Token: 0x04001183 RID: 4483
	public int mapW;

	// Token: 0x04001184 RID: 4484
	public int mapH;

	// Token: 0x04001185 RID: 4485
	public int limitW;

	// Token: 0x04001186 RID: 4486
	public int limitH;

	// Token: 0x04001187 RID: 4487
	public int limitMap;

	// Token: 0x04001188 RID: 4488
	public int maxX;

	// Token: 0x04001189 RID: 4489
	public int maxY;

	// Token: 0x0400118A RID: 4490
	public int maxWMap;

	// Token: 0x0400118B RID: 4491
	public int maxHMap;

	// Token: 0x0400118C RID: 4492
	public static sbyte isShowEffAuto;

	// Token: 0x0400118D RID: 4493
	public static sbyte EFF_NORMAL;

	// Token: 0x0400118E RID: 4494
	public static sbyte EFF_PHOBANG_END;

	// Token: 0x0400118F RID: 4495
	public static int idTile;

	// Token: 0x04001190 RID: 4496
	public string nameMap = string.Empty;

	// Token: 0x04001191 RID: 4497
	public static int wTile;

	// Token: 0x04001192 RID: 4498
	public int[] mapPaint;

	// Token: 0x04001193 RID: 4499
	public int[] mapType;

	// Token: 0x04001194 RID: 4500
	public static int[] mStatusArea;

	// Token: 0x04001195 RID: 4501
	public sbyte[][] mapFind;

	// Token: 0x04001196 RID: 4502
	public static mImage imgTileWater;

	// Token: 0x04001197 RID: 4503
	public static int timeVibrateScreen;

	// Token: 0x04001198 RID: 4504
	public static sbyte Area;

	// Token: 0x04001199 RID: 4505
	public static sbyte MaxArea;

	// Token: 0x0400119A RID: 4506
	public static sbyte typeMap;

	// Token: 0x0400119B RID: 4507
	public mImage itemLogin0;

	// Token: 0x0400119C RID: 4508
	public mImage itemLogin1;

	// Token: 0x0400119D RID: 4509
	public mImage itemLogin2;

	// Token: 0x0400119E RID: 4510
	public static LoadMap me;

	// Token: 0x0400119F RID: 4511
	private int fStand;

	// Token: 0x040011A0 RID: 4512
	private int fWater;

	// Token: 0x040011A1 RID: 4513
	private int fStartWater;

	// Token: 0x040011A2 RID: 4514
	private int fEndWater;

	// Token: 0x040011A3 RID: 4515
	public static mImage[] imgTileMap;

	// Token: 0x040011A4 RID: 4516
	private float currentX;

	// Token: 0x040011A5 RID: 4517
	private float currentY;

	// Token: 0x040011A6 RID: 4518
	public static mVector Thacnuoc;

	// Token: 0x040011A7 RID: 4519
	public static Color[][][] colorMap;

	// Token: 0x040011A8 RID: 4520
	public static int[] totalTile;

	// Token: 0x040011A9 RID: 4521
	public static MainItemMap[] mItemMapLogin;

	// Token: 0x040011AA RID: 4522
	public int mapWLogin;

	// Token: 0x040011AB RID: 4523
	public int mapHLogin;

	// Token: 0x040011AC RID: 4524
	public int[] mapPaintLogin;

	// Token: 0x040011AD RID: 4525
	public static int[] mapPaintLoginOld;
}
