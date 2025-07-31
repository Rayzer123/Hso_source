using System;

// Token: 0x020000B4 RID: 180
public class CRes
{
	// Token: 0x060008F2 RID: 2290 RVA: 0x00094DCC File Offset: 0x00092FCC
	public static void init()
	{
		CRes.cosz = new short[91];
		CRes.tanz = new int[91];
		for (int i = 0; i <= 90; i++)
		{
			CRes.cosz[i] = CRes.sinz[90 - i];
			if (CRes.cosz[i] == 0)
			{
				CRes.tanz[i] = int.MaxValue;
			}
			else
			{
				CRes.tanz[i] = ((int)CRes.sinz[i] << 10) / (int)CRes.cosz[i];
			}
		}
		for (int j = 0; j < CRes.charPartInfo.Length; j++)
		{
			CRes.charPartInfo[j] = new CharPartInfo[256];
		}
		for (int k = 0; k < CRes.wpSplashInfos.Length; k++)
		{
			CRes.wpSplashInfos[k] = new WPSplashInfo[5][];
			for (int l = 0; l < CRes.wpSplashInfos[k].Length; l++)
			{
				CRes.wpSplashInfos[k][l] = new WPSplashInfo[3];
			}
		}
	}

	// Token: 0x060008F3 RID: 2291 RVA: 0x00094EC4 File Offset: 0x000930C4
	public static int sin(int a)
	{
		if (a >= 0 && a < 90)
		{
			return (int)CRes.sinz[a];
		}
		if (a >= 90 && a < 180)
		{
			return (int)CRes.sinz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return (int)(-(int)CRes.sinz[a - 180]);
		}
		return (int)(-(int)CRes.sinz[360 - a]);
	}

	// Token: 0x060008F4 RID: 2292 RVA: 0x00094F3C File Offset: 0x0009313C
	public static int cos(int a)
	{
		if (a >= 0 && a < 90)
		{
			return (int)CRes.cosz[a];
		}
		if (a >= 90 && a < 180)
		{
			return (int)(-(int)CRes.cosz[180 - a]);
		}
		if (a >= 180 && a < 270)
		{
			return (int)(-(int)CRes.cosz[a - 180]);
		}
		return (int)CRes.cosz[360 - a];
	}

	// Token: 0x060008F5 RID: 2293 RVA: 0x00094FB4 File Offset: 0x000931B4
	public static int tan(int a)
	{
		if (a >= 0 && a < 90)
		{
			return CRes.tanz[a];
		}
		if (a >= 90 && a < 180)
		{
			return -CRes.tanz[180 - a];
		}
		if (a >= 180 && a < 270)
		{
			return CRes.tanz[a - 180];
		}
		return -CRes.tanz[360 - a];
	}

	// Token: 0x060008F6 RID: 2294 RVA: 0x0009502C File Offset: 0x0009322C
	public static int atan(int a)
	{
		for (int i = 0; i <= 90; i++)
		{
			if (CRes.tanz[i] >= a)
			{
				return i;
			}
		}
		return 0;
	}

	// Token: 0x060008F7 RID: 2295 RVA: 0x0009505C File Offset: 0x0009325C
	public static int angle(int dx, int dy)
	{
		int num;
		if (dx != 0)
		{
			int a = global::Math.abs((dy << 10) / dx);
			num = CRes.atan(a);
			if (dy >= 0 && dx < 0)
			{
				num = 180 - num;
			}
			if (dy < 0 && dx < 0)
			{
				num = 180 + num;
			}
			if (dy < 0 && dx >= 0)
			{
				num = 360 - num;
			}
		}
		else
		{
			num = ((dy <= 0) ? 270 : 90);
		}
		return num;
	}

	// Token: 0x060008F8 RID: 2296 RVA: 0x000950E0 File Offset: 0x000932E0
	public static int fixangle(int angle)
	{
		if (angle >= 360)
		{
			angle %= 360;
		}
		if (angle < 0)
		{
			angle = 360 + angle % 360;
		}
		return angle;
	}

	// Token: 0x060008F9 RID: 2297 RVA: 0x00095110 File Offset: 0x00093310
	public static int subangle(int a1, int a2)
	{
		int num = a2 - a1;
		if (num < -180)
		{
			return num + 360;
		}
		if (num > 180)
		{
			return num - 360;
		}
		return num;
	}

	// Token: 0x060008FA RID: 2298 RVA: 0x00095148 File Offset: 0x00093348
	public static int abs(int a)
	{
		if (a < 0)
		{
			return -a;
		}
		return a;
	}

	// Token: 0x060008FB RID: 2299 RVA: 0x00095158 File Offset: 0x00093358
	public static int random(int a)
	{
		return CRes.r.nextInt(a);
	}

	// Token: 0x060008FC RID: 2300 RVA: 0x00095168 File Offset: 0x00093368
	public static int random_Am_0(int a)
	{
		return ((CRes.r.nextInt(2) != 0) ? -1 : 1) * CRes.r.nextInt(a) + 1;
	}

	// Token: 0x060008FD RID: 2301 RVA: 0x000951A0 File Offset: 0x000933A0
	public static int random_Am(int a, int b)
	{
		int num = a + CRes.r.nextInt(b - a);
		if (CRes.random(2) == 0)
		{
			num = -num;
		}
		return num;
	}

	// Token: 0x060008FE RID: 2302 RVA: 0x000951CC File Offset: 0x000933CC
	public static int random(int a, int b)
	{
		return a + CRes.r.nextInt(b - a);
	}

	// Token: 0x060008FF RID: 2303 RVA: 0x000951E0 File Offset: 0x000933E0
	public static int sqrt(int a)
	{
		if (a <= 0)
		{
			return 0;
		}
		int num = (a + 1) / 2;
		int num2;
		do
		{
			num2 = num;
			num = num / 2 + a / (2 * num);
		}
		while (global::Math.abs(num2 - num) > 1);
		return num;
	}

	// Token: 0x06000900 RID: 2304 RVA: 0x00095218 File Offset: 0x00093418
	public static float sqrt(float a)
	{
		if (a <= 0f)
		{
			return 0f;
		}
		float num = (a + 1f) / 2f;
		float num2;
		do
		{
			num2 = num;
			num = num / 2f + a / (2f * num);
		}
		while (global::Math.abs(num2 - num) > 1f);
		return num;
	}

	// Token: 0x06000901 RID: 2305 RVA: 0x0009526C File Offset: 0x0009346C
	public static int setDis(int x1, int y1, int x2, int y2)
	{
		return CRes.abs(x1 - x2) + CRes.abs(y1 - y2);
	}

	// Token: 0x06000902 RID: 2306 RVA: 0x00095280 File Offset: 0x00093480
	public static void quickSort(mVector actors)
	{
		CRes.recQuickSort(actors, 0, actors.size() - 1);
	}

	// Token: 0x06000903 RID: 2307 RVA: 0x00095294 File Offset: 0x00093494
	private static void recQuickSort(mVector actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				MainObject mainObject = (MainObject)actors.elementAt(right);
				int ySort = mainObject.ySort;
				int num = CRes.partitionIt(actors, left, right, ySort);
				CRes.recQuickSort(actors, left, num - 1);
				CRes.recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi Cres 1");
		}
	}

	// Token: 0x06000904 RID: 2308 RVA: 0x00095314 File Offset: 0x00093514
	private static int partitionIt(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			for (;;)
			{
				while (((MainObject)actors.elementAt(++num)).ySort < pivot)
				{
				}
				while (num2 > 0 && ((MainObject)actors.elementAt(--num2)).ySort > pivot)
				{
				}
				if (num >= num2)
				{
					break;
				}
				CRes.swap(actors, num, num2);
			}
			CRes.swap(actors, num, right);
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi Cres 2");
		}
		return num;
	}

	// Token: 0x06000905 RID: 2309 RVA: 0x000953C4 File Offset: 0x000935C4
	private static void swap(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((MainObject)actors.elementAt(dex2)).ySort != ((MainObject)actors.elementAt(dex1)).ySort)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x06000906 RID: 2310 RVA: 0x00095418 File Offset: 0x00093618
	public static void quickSort1(mVector actors)
	{
		CRes.recQuickSort1(actors, 0, actors.size() - 1);
	}

	// Token: 0x06000907 RID: 2311 RVA: 0x0009542C File Offset: 0x0009362C
	private static void recQuickSort1(mVector actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				MainItemMap mainItemMap = (MainItemMap)actors.elementAt(right);
				int y = mainItemMap.y;
				int num = CRes.partitionIt1(actors, left, right, y);
				CRes.recQuickSort1(actors, left, num - 1);
				CRes.recQuickSort1(actors, num + 1, right);
			}
		}
		catch (Exception ex)
		{
			mSystem.println("loi Cres 1");
		}
	}

	// Token: 0x06000908 RID: 2312 RVA: 0x000954AC File Offset: 0x000936AC
	private static int partitionIt1(mVector actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			for (;;)
			{
				while (((MainItemMap)actors.elementAt(++num)).y < pivot)
				{
				}
				while (num2 > 0 && ((MainItemMap)actors.elementAt(--num2)).y > pivot)
				{
				}
				if (num >= num2)
				{
					break;
				}
				CRes.swap1(actors, num, num2);
			}
			CRes.swap1(actors, num, right);
		}
		catch (Exception ex)
		{
			mSystem.println("loi Cres 2");
		}
		return num;
	}

	// Token: 0x06000909 RID: 2313 RVA: 0x0009555C File Offset: 0x0009375C
	private static void swap1(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((MainItemMap)actors.elementAt(dex2)).y != ((MainItemMap)actors.elementAt(dex1)).y)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x0600090A RID: 2314 RVA: 0x000955B0 File Offset: 0x000937B0
	public static void quickSort(MainItemMap[] actors)
	{
		CRes.recQuickSort(actors, 0, actors.Length - 1);
	}

	// Token: 0x0600090B RID: 2315 RVA: 0x000955C0 File Offset: 0x000937C0
	private static void recQuickSort(MainItemMap[] actors, int left, int right)
	{
		try
		{
			if (right - left > 0)
			{
				int y = actors[right].y;
				int num = CRes.partitionIt(actors, left, right, y);
				CRes.recQuickSort(actors, left, num - 1);
				CRes.recQuickSort(actors, num + 1, right);
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi Cres 3");
		}
	}

	// Token: 0x0600090C RID: 2316 RVA: 0x00095634 File Offset: 0x00093834
	private static int partitionIt(MainItemMap[] actors, int left, int right, int pivot)
	{
		int num = left - 1;
		int num2 = right;
		try
		{
			for (;;)
			{
				while (actors[++num].y < pivot)
				{
				}
				while (num2 > 0 && actors[--num2].y > pivot)
				{
				}
				if (num >= num2)
				{
					break;
				}
				CRes.swap(actors, num, num2);
			}
			CRes.swap(actors, num, right);
		}
		catch (Exception ex)
		{
			mSystem.outloi("LOI PAINT partitionIt TRONG UTIL");
		}
		return num;
	}

	// Token: 0x0600090D RID: 2317 RVA: 0x000956D0 File Offset: 0x000938D0
	private static void swap(MainItemMap[] actors, int dex1, int dex2)
	{
		MainItemMap mainItemMap = actors[dex2];
		if (actors[dex2].y != actors[dex1].y)
		{
			actors[dex2] = actors[dex1];
			actors[dex1] = mainItemMap;
		}
	}

	// Token: 0x0600090E RID: 2318 RVA: 0x00095700 File Offset: 0x00093900
	public static MainInfoItem[] selectionSort(MainInfoItem[] arr)
	{
		int num = arr.Length;
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (arr[j].id < arr[num2].id)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				MainInfoItem mainInfoItem = arr[i];
				arr[i] = arr[num2];
				arr[num2] = mainInfoItem;
			}
		}
		return arr;
	}

	// Token: 0x0600090F RID: 2319 RVA: 0x0009576C File Offset: 0x0009396C
	public static mVector selectionSortIDSkill(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (((Skill)arr.elementAt(j)).Id < ((Skill)arr.elementAt(num2)).Id)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				CRes.swapSkill(arr, i, num2);
			}
		}
		return arr;
	}

	// Token: 0x06000910 RID: 2320 RVA: 0x000957E4 File Offset: 0x000939E4
	public static mVector selectionSortSkill(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if (((Skill)arr.elementAt(j)).lvMin < ((Skill)arr.elementAt(num2)).lvMin)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				CRes.swapSkill(arr, i, num2);
			}
		}
		return arr;
	}

	// Token: 0x06000911 RID: 2321 RVA: 0x0009585C File Offset: 0x00093A5C
	private static void swapSkill(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		if (((Skill)actors.elementAt(dex2)).lvMin != ((Skill)actors.elementAt(dex1)).lvMin)
		{
			actors.setElementAt(actors.elementAt(dex1), dex2);
			actors.setElementAt(obj, dex1);
		}
	}

	// Token: 0x06000912 RID: 2322 RVA: 0x000958B0 File Offset: 0x00093AB0
	public static mVector selectionSortInven(mVector arr)
	{
		int num = arr.size();
		for (int i = 0; i < num - 1; i++)
		{
			int num2 = i;
			for (int j = i + 1; j < num; j++)
			{
				if ((int)((MainItem)arr.elementAt(j)).IndexSort < (int)((MainItem)arr.elementAt(num2)).IndexSort)
				{
					num2 = j;
				}
			}
			if (num2 != i)
			{
				CRes.swapItem(arr, i, num2);
			}
		}
		return arr;
	}

	// Token: 0x06000913 RID: 2323 RVA: 0x0009592C File Offset: 0x00093B2C
	private static void swapItem(mVector actors, int dex1, int dex2)
	{
		object obj = actors.elementAt(dex2);
		actors.setElementAt(actors.elementAt(dex1), dex2);
		actors.setElementAt(obj, dex1);
	}

	// Token: 0x06000914 RID: 2324 RVA: 0x00095958 File Offset: 0x00093B58
	public static int readSignByte(DataInputStream iss)
	{
		sbyte[] array = new sbyte[1];
		try
		{
			iss.r.read(ref array, 0, 1);
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi Cres 5");
		}
		return (int)array[0];
	}

	// Token: 0x06000915 RID: 2325 RVA: 0x000959B0 File Offset: 0x00093BB0
	public static void setRemoveCharPartInfo()
	{
		if (CRes.charPartInfo == null)
		{
			return;
		}
		for (int i = 0; i < CRes.charPartInfo.Length; i++)
		{
			for (int j = 0; j < CRes.charPartInfo[i].Length; j++)
			{
				if (CRes.charPartInfo[i][j] != null && (GameCanvas.timeNow - CRes.charPartInfo[i][j].timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					CRes.charPartInfo[i][j] = null;
				}
			}
		}
	}

	// Token: 0x06000916 RID: 2326 RVA: 0x00095A4C File Offset: 0x00093C4C
	public static CharPartInfo getCharPartInfo(int type, int id)
	{
		if (CRes.charPartInfo[type][id] == null)
		{
			CRes.charPartInfo[type][id] = new CharPartInfo((sbyte)type, (short)id);
		}
		return CRes.charPartInfo[type][id];
	}

	// Token: 0x06000917 RID: 2327 RVA: 0x00095A78 File Offset: 0x00093C78
	public static void getImgWeaPone(int claz, int i, int j)
	{
		try
		{
			MainObject.imgWeapone[claz][i][j] = new WeaponInfo();
			if (mSystem.isImgLocal)
			{
				string[] array = new string[]
				{
					"kiem/",
					"songkiem/",
					"phapsu/",
					"sung/"
				};
				mImage mImage = null;
				try
				{
					mImage = mImage.createImage(string.Concat(new object[]
					{
						"/weapon/",
						array[claz],
						i,
						".img"
					}));
				}
				catch (Exception ex)
				{
				}
				if (mImage != null && mImage.image != null)
				{
					DataInputStream dataInputStream = null;
					try
					{
						dataInputStream = mImage.openFile(string.Concat(new object[]
						{
							"/weapon/",
							array[claz],
							i,
							"_data"
						}));
					}
					catch (Exception ex2)
					{
					}
					if (dataInputStream != null)
					{
						MainObject.imgWeapone[claz][i][j].img = mImage;
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 3; l++)
							{
								MainObject.imgWeapone[claz][i][j].mPos[k][l][0] = (sbyte)dataInputStream.read();
								MainObject.imgWeapone[claz][i][j].mPos[k][l][1] = (sbyte)dataInputStream.read();
							}
							MainObject.imgWeapone[claz][i][j].mRegion[k][0] = (sbyte)dataInputStream.read();
							MainObject.imgWeapone[claz][i][j].mRegion[k][1] = (sbyte)dataInputStream.read();
						}
						MainObject.imgWeapone[claz][i][j].himg = mImage.getImageHeight(MainObject.imgWeapone[claz][i][j].img.image);
						return;
					}
				}
			}
			MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)CRes.hashWeapon.get(claz + "_" + i);
			if (mainImageDataPartChar == null)
			{
				mainImageDataPartChar = new MainImageDataPartChar();
				CRes.hashWeapon.put(claz + "_" + i, mainImageDataPartChar);
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
				CRes.getFromRms((sbyte)claz, (short)i);
				MainObject.imgWeapone[claz][i][j] = null;
			}
			else if (mainImageDataPartChar.img != null)
			{
				MainObject.imgWeapone[claz][i][j].img = mainImageDataPartChar.img;
				DataInputStream dataInputStream2 = new DataInputStream(mainImageDataPartChar.isData);
				FilePack.reset();
				try
				{
					for (int m = 0; m < 4; m++)
					{
						for (int n = 0; n < 3; n++)
						{
							MainObject.imgWeapone[claz][i][j].mPos[m][n][0] = (sbyte)dataInputStream2.read();
							MainObject.imgWeapone[claz][i][j].mPos[m][n][1] = (sbyte)dataInputStream2.read();
						}
						MainObject.imgWeapone[claz][i][j].mRegion[m][0] = (sbyte)dataInputStream2.read();
						MainObject.imgWeapone[claz][i][j].mRegion[m][1] = (sbyte)dataInputStream2.read();
					}
					MainObject.imgWeapone[claz][i][j].himg = mImage.getImageHeight(MainObject.imgWeapone[claz][i][j].img.image);
				}
				catch (Exception ex3)
				{
				}
				CRes.hashWeapon.remove(mainImageDataPartChar);
			}
			else if ((GameCanvas.timeNow - mainImageDataPartChar.timeImageNull) / 1000L >= 15L)
			{
				CRes.getFromRms((sbyte)claz, (short)i);
			}
		}
		catch (Exception ex4)
		{
			mSystem.outloi("loi Cres 7");
		}
		FilePack.reset();
	}

	// Token: 0x06000918 RID: 2328 RVA: 0x00095E80 File Offset: 0x00094080
	public static void getFromRms(sbyte type, short id)
	{
		MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)CRes.hashWeapon.get(type + "_" + id);
		if ((int)TemMidlet.DIVICE == 0)
		{
			if (mainImageDataPartChar != null)
			{
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
			}
			GlobalService.gI().load_image_data_part_char((sbyte)((int)type + 50), id);
			return;
		}
		string text = string.Concat(new object[]
		{
			"img_data_char_",
			(int)type + 50,
			"_",
			id
		});
		sbyte[] array = CRes.loadRMS(text);
		if (array == null)
		{
			if (mainImageDataPartChar != null)
			{
				mainImageDataPartChar.timeImageNull = GameCanvas.timeNow;
			}
			GlobalService.gI().load_image_data_part_char((sbyte)((int)type + 50), id);
		}
		else
		{
			sbyte[] data;
			sbyte[] array2;
			try
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				dataInputStream.readShort();
				int num = dataInputStream.readInt();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				short num2 = dataInputStream.readShort();
				array2 = new sbyte[(int)num2];
				dataInputStream.read(ref array2);
			}
			catch (Exception ex)
			{
				return;
			}
			mImage img = mImage.createImage(data, 0, 0, text);
			if (mainImageDataPartChar == null)
			{
				mainImageDataPartChar = new MainImageDataPartChar(img, array2);
				CRes.hashWeapon.put(type + "_" + id, mainImageDataPartChar);
			}
			else
			{
				mainImageDataPartChar.img = img;
				mainImageDataPartChar.isData = array2;
			}
		}
	}

	// Token: 0x06000919 RID: 2329 RVA: 0x0009600C File Offset: 0x0009420C
	public static WPSplashInfo GetWPSplashInfo(int claz, int i, int j)
	{
		try
		{
			string[] array = new string[]
			{
				"kiem/",
				"songkiem/",
				"phapsu/",
				"sung/"
			};
			CRes.wpSplashInfos[claz][i][j] = new WPSplashInfo();
			CRes.wpSplashInfos[claz][i][j].image = mImage.createImage(string.Concat(new object[]
			{
				"/wps/",
				array[claz],
				i,
				".img"
			}));
			DataInputStream dataInputStream = mImage.openFile(string.Concat(new object[]
			{
				"/wps/",
				array[claz],
				i,
				"_data"
			}));
			if (dataInputStream != null)
			{
				for (int k = 0; k < 4; k++)
				{
					for (int l = 0; l < 8; l++)
					{
						CRes.wpSplashInfos[claz][i][j].P0_X[k][l] = dataInputStream.read();
						CRes.wpSplashInfos[claz][i][j].P0_Y[k][l] = dataInputStream.read();
						CRes.wpSplashInfos[claz][i][j].PF_X[k][l] = CRes.readSignByte(dataInputStream);
						CRes.wpSplashInfos[claz][i][j].PF_Y[k][l] = CRes.readSignByte(dataInputStream);
						CRes.wpSplashInfos[claz][i][j].PF_W[k][l] = dataInputStream.read();
						CRes.wpSplashInfos[claz][i][j].PF_H[k][l] = dataInputStream.read();
					}
				}
			}
			FilePack.reset();
		}
		catch (Exception ex)
		{
			CRes.wpSplashInfos[claz][i][j] = null;
			mSystem.outloi("loi Cres 8");
		}
		return CRes.wpSplashInfos[claz][i][j];
	}

	// Token: 0x0600091A RID: 2330 RVA: 0x000961D4 File Offset: 0x000943D4
	public static WeaponInfo loadImgWeaPone(int i, int j, int index)
	{
		if (MainObject.imgWeapone[i][j][index] == null)
		{
			CRes.load.loadImgWeaPone(i, j, index);
		}
		return MainObject.imgWeapone[i][j][index];
	}

	// Token: 0x0600091B RID: 2331 RVA: 0x0009620C File Offset: 0x0009440C
	public static WPSplashInfo loadWpsPlash(int claz, int i, int j)
	{
		if (CRes.wpSplashInfos[i][j] == null)
		{
			CRes.load.loadWpsPlash(i, j);
		}
		return CRes.wpSplashInfos[claz][i][j];
	}

	// Token: 0x0600091C RID: 2332 RVA: 0x00096234 File Offset: 0x00094434
	public static byte[] encoding(byte[] array)
	{
		if (array != null)
		{
			for (int i = 0; i < array.Length; i++)
			{
				array[i] = ~array[i];
			}
		}
		return array;
	}

	// Token: 0x0600091D RID: 2333 RVA: 0x00096264 File Offset: 0x00094464
	public static void saveRMS(string name, sbyte[] data)
	{
		TemMidlet.saveRMS(name, data);
	}

	// Token: 0x0600091E RID: 2334 RVA: 0x00096270 File Offset: 0x00094470
	public static sbyte[] loadRMS(string name)
	{
		return TemMidlet.loadRMS(name);
	}

	// Token: 0x0600091F RID: 2335 RVA: 0x00096278 File Offset: 0x00094478
	public static bool CheckDelRMS(string str)
	{
		return str.CompareTo("isLowDevice") != 0 && str.CompareTo("isQty") != 0 && str.CompareTo("user_pass") != 0 && ((int)TemMidlet.DIVICE <= 0 || str.Length < 13 || str.Substring(0, 13).CompareTo("img_data_char") != 0) && str.CompareTo("isIndexPart") != 0 && str.CompareTo("isIndexServer") != 0;
	}

	// Token: 0x06000920 RID: 2336 RVA: 0x0009630C File Offset: 0x0009450C
	public static void saveRMSName(sbyte ID, sbyte[] data)
	{
		GlobalService.gI().Save_RMS_Server(0, ID, data);
	}

	// Token: 0x06000921 RID: 2337 RVA: 0x0009631C File Offset: 0x0009451C
	public static bool ktvc(int x1, int xw1, int x2, int xw2, int y1, int yh1, int y2, int yh2)
	{
		return x1 <= xw2 && xw1 >= x2 && y1 <= yh2 && yh1 >= y2;
	}

	// Token: 0x04000DF7 RID: 3575
	public const int LEG = 0;

	// Token: 0x04000DF8 RID: 3576
	public const int BODY = 1;

	// Token: 0x04000DF9 RID: 3577
	public const int HEAD = 2;

	// Token: 0x04000DFA RID: 3578
	public const int HAT = 3;

	// Token: 0x04000DFB RID: 3579
	public const int EYE = 4;

	// Token: 0x04000DFC RID: 3580
	public const int HAIR = 5;

	// Token: 0x04000DFD RID: 3581
	public const int WING = 6;

	// Token: 0x04000DFE RID: 3582
	private static short[] sinz = new short[]
	{
		0,
		18,
		36,
		54,
		71,
		89,
		107,
		125,
		143,
		160,
		178,
		195,
		213,
		230,
		248,
		265,
		282,
		299,
		316,
		333,
		350,
		367,
		384,
		400,
		416,
		433,
		449,
		465,
		481,
		496,
		512,
		527,
		543,
		558,
		573,
		587,
		602,
		616,
		630,
		644,
		658,
		672,
		685,
		698,
		711,
		724,
		737,
		749,
		761,
		773,
		784,
		796,
		807,
		818,
		828,
		839,
		849,
		859,
		868,
		878,
		887,
		896,
		904,
		912,
		920,
		928,
		935,
		943,
		949,
		956,
		962,
		968,
		974,
		979,
		984,
		989,
		994,
		998,
		1002,
		1005,
		1008,
		1011,
		1014,
		1016,
		1018,
		1020,
		1022,
		1023,
		1023,
		1024,
		1024
	};

	// Token: 0x04000DFF RID: 3583
	public static mHashTable hashWeapon = new mHashTable();

	// Token: 0x04000E00 RID: 3584
	private static short[] cosz;

	// Token: 0x04000E01 RID: 3585
	private static int[] tanz;

	// Token: 0x04000E02 RID: 3586
	private static int value = 1;

	// Token: 0x04000E03 RID: 3587
	public static MyRandom r = new MyRandom();

	// Token: 0x04000E04 RID: 3588
	public static mVector quanao = new mVector();

	// Token: 0x04000E05 RID: 3589
	public static CharPartInfo[][] charPartInfo = new CharPartInfo[7][];

	// Token: 0x04000E06 RID: 3590
	public static WPSplashInfo[][][] wpSplashInfos = new WPSplashInfo[4][][];

	// Token: 0x04000E07 RID: 3591
	public static LoadData load = new LoadData();
}
