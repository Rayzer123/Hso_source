using System;
using System.Text;
using UnityEngine;

// Token: 0x02000020 RID: 32
public class mSystem
{
	// Token: 0x06000130 RID: 304 RVA: 0x00007D38 File Offset: 0x00005F38
	public static bool isHideNaptien()
	{
		return false;
	}

	// Token: 0x06000131 RID: 305 RVA: 0x00007D3C File Offset: 0x00005F3C
	public static void mDebug(string s)
	{
		Debug.LogWarning(s);
	}

	// Token: 0x06000132 RID: 306 RVA: 0x00007D44 File Offset: 0x00005F44
	public static string getLong()
	{
		return string.Empty;
	}

	// Token: 0x06000133 RID: 307 RVA: 0x00007D4C File Offset: 0x00005F4C
	public static string getLat()
	{
		return string.Empty;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x00007D54 File Offset: 0x00005F54
	public static void doChangeMenuNapapple()
	{
	}

	// Token: 0x06000135 RID: 309 RVA: 0x00007D58 File Offset: 0x00005F58
	public static void println(string str)
	{
	}

	// Token: 0x06000136 RID: 310 RVA: 0x00007D5C File Offset: 0x00005F5C
	public static void arraycopy(sbyte[] scr, int scrPos, sbyte[] dest, int destPos, int lenght)
	{
		Array.Copy(scr, scrPos, dest, destPos, lenght);
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00007D6C File Offset: 0x00005F6C
	public static void arrayReplace(sbyte[] scr, int scrPos, ref sbyte[] dest, int destPos, int lenght)
	{
		if (scr == null || dest == null || scrPos + lenght > scr.Length)
		{
			return;
		}
		sbyte[] array = new sbyte[dest.Length + lenght];
		for (int i = 0; i < destPos; i++)
		{
			array[i] = dest[i];
		}
		for (int j = destPos; j < destPos + lenght; j++)
		{
			array[j] = scr[scrPos + j - destPos];
		}
		for (int k = destPos + lenght; k < array.Length; k++)
		{
			array[k] = dest[destPos + k - lenght];
		}
	}

	// Token: 0x06000138 RID: 312 RVA: 0x00007DFC File Offset: 0x00005FFC
	public static long currentTimeMillis()
	{
		DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
		return (DateTime.UtcNow.Ticks - dateTime.Ticks) / 10000L;
	}

	// Token: 0x06000139 RID: 313 RVA: 0x00007E3C File Offset: 0x0000603C
	public static void freeData()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x0600013A RID: 314 RVA: 0x00007E4C File Offset: 0x0000604C
	public static sbyte[] convertToSbyte(byte[] scr)
	{
		sbyte[] array = new sbyte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (sbyte)scr[i];
		}
		return array;
	}

	// Token: 0x0600013B RID: 315 RVA: 0x00007E80 File Offset: 0x00006080
	public static sbyte[] convertToSbyte(string scr)
	{
		ASCIIEncoding asciiencoding = new ASCIIEncoding();
		byte[] bytes = asciiencoding.GetBytes(scr);
		return mSystem.convertToSbyte(bytes);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x00007EA4 File Offset: 0x000060A4
	public static byte[] convetToByte(sbyte[] scr)
	{
		byte[] array = new byte[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			if ((int)scr[i] > 0)
			{
				array[i] = (byte)scr[i];
			}
			else
			{
				array[i] = (byte)((int)scr[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x0600013D RID: 317 RVA: 0x00007EF4 File Offset: 0x000060F4
	public static char[] ToCharArray(sbyte[] scr)
	{
		char[] array = new char[scr.Length];
		for (int i = 0; i < scr.Length; i++)
		{
			array[i] = (char)scr[i];
		}
		return array;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x00007F28 File Offset: 0x00006128
	public static int currentHour()
	{
		return DateTime.Now.Hour;
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00007F44 File Offset: 0x00006144
	public static void gcc()
	{
		Resources.UnloadUnusedAssets();
		GC.Collect();
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00007F54 File Offset: 0x00006154
	public static void outloi(string str)
	{
		Cout.Log(str);
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00007F5C File Offset: 0x0000615C
	public static void outz(string str)
	{
		Cout.Log(str);
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00007F64 File Offset: 0x00006164
	public static void setDataArrInt(ref int[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new int[Length];
		}
	}

	// Token: 0x06000143 RID: 323 RVA: 0x00007F90 File Offset: 0x00006190
	public static void setDataArrInt(ref int[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new int[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new int[Length2];
			}
		}
	}

	// Token: 0x06000144 RID: 324 RVA: 0x00007FE0 File Offset: 0x000061E0
	public static void setDataArrByte(ref sbyte[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new sbyte[Length];
		}
	}

	// Token: 0x06000145 RID: 325 RVA: 0x0000800C File Offset: 0x0000620C
	public static void setDataArrByte(ref sbyte[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new sbyte[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new sbyte[Length2];
			}
		}
	}

	// Token: 0x06000146 RID: 326 RVA: 0x0000805C File Offset: 0x0000625C
	public static void setDataArrShort(ref short[][] data, int Length)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new short[Length];
		}
	}

	// Token: 0x06000147 RID: 327 RVA: 0x00008088 File Offset: 0x00006288
	public static void setDataArrShort(ref short[][][] data, int Length1, int Length2)
	{
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = new short[Length1][];
			for (int j = 0; j < data[i].Length; j++)
			{
				data[i][j] = new short[Length2];
			}
		}
	}

	// Token: 0x06000148 RID: 328 RVA: 0x000080D8 File Offset: 0x000062D8
	public static void my_Gc()
	{
		mSystem.gcc();
	}

	// Token: 0x06000149 RID: 329 RVA: 0x000080E0 File Offset: 0x000062E0
	public static int[][] new_M_Int(int value1, int value2)
	{
		int[][] array = new int[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new int[value2];
		}
		return array;
	}

	// Token: 0x0600014A RID: 330 RVA: 0x00008114 File Offset: 0x00006314
	public static string[][] new_M_String(int value1, int value2)
	{
		string[][] array = new string[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new string[value2];
		}
		return array;
	}

	// Token: 0x0600014B RID: 331 RVA: 0x00008148 File Offset: 0x00006348
	public static sbyte[][] new_M_Byte(int value1, int value2)
	{
		sbyte[][] array = new sbyte[value1][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[value2];
		}
		return array;
	}

	// Token: 0x0600014C RID: 332 RVA: 0x0000817C File Offset: 0x0000637C
	public static sbyte[][][] new_M_Byte(int value1, int value2, int value3)
	{
		sbyte[][][] array = new sbyte[value1][][];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = new sbyte[value2][];
			for (int j = 0; j < value2; j++)
			{
				array[i][j] = new sbyte[value3];
			}
		}
		return array;
	}

	// Token: 0x0600014D RID: 333 RVA: 0x000081CC File Offset: 0x000063CC
	public static string substring(string scr, int startIndex, int lenght)
	{
		string result;
		try
		{
			if (scr == null)
			{
				result = string.Empty;
			}
			else
			{
				result = scr.Substring(startIndex, lenght - startIndex);
			}
		}
		catch (Exception ex)
		{
			result = scr.Substring(startIndex, 0);
		}
		return result;
	}

	// Token: 0x0600014E RID: 334 RVA: 0x00008230 File Offset: 0x00006430
	public static int getTotalColumOrRow(int wh)
	{
		int num = 256 * mGraphics.zoomLevel;
		if (wh <= num)
		{
			return 1;
		}
		int num2 = wh / num;
		int num3 = wh % num;
		if (num3 == 0)
		{
			return num2;
		}
		if (num3 != 0)
		{
			return num2 + 1;
		}
		return 0;
	}

	// Token: 0x0600014F RID: 335 RVA: 0x00008270 File Offset: 0x00006470
	public static mImage loadImageByPNG(string path, ref int timeRemove, ref bool isLoadOK)
	{
		mImage result;
		try
		{
			Cout.LogError2(" LOAD IMAGE --------------------");
			Texture2D texture2D = Resources.Load<Texture2D>(path);
			mImage mImage = new mImage();
			mImage.image.texture = texture2D;
			mImage.image.w = texture2D.width;
			mImage.image.h = texture2D.height;
			timeRemove = (int)(mSystem.currentTimeMillis() / 1000L);
			isLoadOK = true;
			result = mImage;
		}
		catch (Exception ex)
		{
			Cout.LogError2(" Loi load imgSprite " + ex.ToString() + " !! " + path);
			result = null;
		}
		return result;
	}

	// Token: 0x06000150 RID: 336 RVA: 0x00008328 File Offset: 0x00006528
	public static void loadImageMap(int w, int h, int idMap)
	{
		Cout.LogError2(" LOAD MAP-----------------------BEGIN " + idMap);
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		for (int i = 0; i < mSystem.totalImageMap.size(); i++)
		{
			ItemMapSprite itemMapSprite = (ItemMapSprite)mSystem.totalImageMap.elementAt(i);
			if (itemMapSprite != null && itemMapSprite.img != null)
			{
				if (itemMapSprite.img.image != null)
				{
					itemMapSprite.img.image.texture = null;
					itemMapSprite.img.image = null;
				}
			}
		}
		mSystem.totalImageMap.removeAllElements();
		mSystem.gcc();
		int totalColumOrRow = mSystem.getTotalColumOrRow(w);
		int totalColumOrRow2 = mSystem.getTotalColumOrRow(h);
		int num = totalColumOrRow * totalColumOrRow2;
		for (int j = 0; j < num; j++)
		{
			ItemMapSprite itemMapSprite2 = new ItemMapSprite();
			string text = (j >= 9) ? "/m_" : "/m_0";
			itemMapSprite2.path = string.Concat(new object[]
			{
				"ImageMap/x",
				mGraphics.zoomLevel,
				"/map",
				idMap,
				text,
				j + 1
			});
			int num2 = 256 * mGraphics.zoomLevel;
			if (j % totalColumOrRow * num2 <= w - num2)
			{
				itemMapSprite2.wimg = num2;
			}
			else
			{
				itemMapSprite2.wimg = w - num2 * (j % totalColumOrRow);
			}
			if (j / totalColumOrRow * num2 <= h - num2)
			{
				itemMapSprite2.himg = num2;
			}
			else
			{
				itemMapSprite2.himg = h - num2 * (j / totalColumOrRow);
			}
			itemMapSprite2.x = j % totalColumOrRow * 256;
			itemMapSprite2.y = j / totalColumOrRow * 256;
			mSystem.totalImageMap.addElement(itemMapSprite2);
		}
		Cout.LogError2(" LOAD MAP-----------------------END");
	}

	// Token: 0x06000151 RID: 337 RVA: 0x0000850C File Offset: 0x0000670C
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

	// Token: 0x06000152 RID: 338 RVA: 0x0000855C File Offset: 0x0000675C
	public static string[] split(string original, string separator)
	{
		mVector mVector = new mVector();
		for (int i = original.IndexOf(separator); i >= 0; i = original.IndexOf(separator))
		{
			mVector.addElement(original.Substring(0, i));
			original = original.Substring(i + separator.Length);
		}
		mVector.addElement(original);
		string[] array = new string[mVector.size()];
		if (mVector.size() > 0)
		{
			for (int j = 0; j < mVector.size(); j++)
			{
				array[j] = (string)mVector.elementAt(j);
			}
		}
		return array;
	}

	// Token: 0x06000153 RID: 339 RVA: 0x000085F0 File Offset: 0x000067F0
	public static string getPackageName()
	{
		return string.Empty;
	}

	// Token: 0x06000154 RID: 340 RVA: 0x000085F8 File Offset: 0x000067F8
	public static void doSetWpLinkIp()
	{
	}

	// Token: 0x0400014D RID: 333
	public static mVector totalImageMap = new mVector();

	// Token: 0x0400014E RID: 334
	public static bool isMaHoa = false;

	// Token: 0x0400014F RID: 335
	public static bool isIP_GDX = false;

	// Token: 0x04000150 RID: 336
	public static bool isIP_TrucTiep = false;

	// Token: 0x04000151 RID: 337
	public static bool isj2me = false;

	// Token: 0x04000152 RID: 338
	public static int dyCharStep = 0;

	// Token: 0x04000153 RID: 339
	public static bool isImgLocal = false;

	// Token: 0x04000154 RID: 340
	public static sbyte INDEX_SV_GLOBAL = 2;

	// Token: 0x04000155 RID: 341
	public static bool isIphone = false;

	// Token: 0x04000156 RID: 342
	public static bool isWinphone = false;
}
