using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000022 RID: 34
public class FontSys
{
	// Token: 0x06000164 RID: 356 RVA: 0x00008794 File Offset: 0x00006994
	public FontSys(sbyte id, int cl1, int cl2)
	{
		string text;
		if ((int)id <= 8 || (int)id >= 30)
		{
			text = "big";
			this.yAddFont = ((mGraphics.zoomLevel != 1) ? -2 : -3);
		}
		else
		{
			text = "mini";
			if (mGraphics.zoomLevel == 1)
			{
				this.yAddFont = -1;
			}
		}
		this.id = id;
		this.cl1 = cl1;
		this.cl2 = cl2;
		text = string.Concat(new object[]
		{
			"FontSys/x",
			mGraphics.zoomLevel,
			"/",
			text
		});
		this.myFont = (Font)Resources.Load(text);
		this.color1 = this.setColor(this.cl1);
		this.color2 = this.setColor(this.cl2);
		this.wO = this.getWidthExactOf("o");
	}

	// Token: 0x06000166 RID: 358 RVA: 0x0000892C File Offset: 0x00006B2C
	public static void init()
	{
	}

	// Token: 0x06000167 RID: 359 RVA: 0x00008930 File Offset: 0x00006B30
	public Color setColor(int rgb)
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

	// Token: 0x06000168 RID: 360 RVA: 0x00008988 File Offset: 0x00006B88
	public Color bigColor(int id)
	{
		Color[] array = new Color[]
		{
			Color.red,
			Color.yellow,
			Color.green,
			Color.white,
			this.setColor(40404),
			Color.red
		};
		return array[id - 25];
	}

	// Token: 0x06000169 RID: 361 RVA: 0x00008A18 File Offset: 0x00006C18
	public void setTypePaint(mGraphics g, string st, int x, int y, int align, sbyte idFont, bool useClip)
	{
		sbyte b = this.id;
		if ((int)idFont > 0)
		{
		}
		x--;
		this.color1 = this.setColor(this.cl1);
		this.color2 = this.setColor(this.cl2);
		this._drawString(g, st, x, y, align, useClip);
	}

	// Token: 0x0600016A RID: 362 RVA: 0x00008A70 File Offset: 0x00006C70
	public Color setColorFont(sbyte id)
	{
		return this.setColor(FontSys.colorJava[(int)id]);
	}

	// Token: 0x0600016B RID: 363 RVA: 0x00008A80 File Offset: 0x00006C80
	public void drawString(mGraphics g, string st, int x, int y, int align, bool useClip)
	{
		this.setTypePaint(g, st, x, y, align, 0, useClip);
	}

	// Token: 0x0600016C RID: 364 RVA: 0x00008AA0 File Offset: 0x00006CA0
	public void drawString(mGraphics g, string st, int x, int y, int align, FontSys font, bool useClip)
	{
		this.setTypePaint(g, st, x, y + 1, align, font.id, useClip);
		this.setTypePaint(g, st, x, y, align, 0, useClip);
	}

	// Token: 0x0600016D RID: 365 RVA: 0x00008AD8 File Offset: 0x00006CD8
	public mVector splitFontVector(string src, int lineWidth)
	{
		mVector mVector = new mVector();
		string text = string.Empty;
		for (int i = 0; i < src.Length; i++)
		{
			if (src[i] == '\n' || src[i] == '\b')
			{
				mVector.addElement(text);
				text = string.Empty;
			}
			else
			{
				text += src[i];
				if (this.getWidth(text) > lineWidth)
				{
					int j;
					for (j = text.Length - 1; j >= 0; j--)
					{
						if (text[j] == ' ')
						{
							break;
						}
					}
					if (j < 0)
					{
						j = text.Length - 1;
					}
					mVector.addElement(mSystem.substring(text, 0, j));
					i = i - (text.Length - j) + 1;
					text = string.Empty;
				}
				if (i == src.Length - 1 && !text.Trim().Equals(string.Empty))
				{
					mVector.addElement(text);
				}
			}
		}
		return mVector;
	}

	// Token: 0x0600016E RID: 366 RVA: 0x00008BE0 File Offset: 0x00006DE0
	public string splitFirst(string str)
	{
		string text = string.Empty;
		bool flag = false;
		for (int i = 0; i < str.Length; i++)
		{
			if (!flag)
			{
				string text2 = str.Substring(i);
				if (this.compare(text2, " "))
				{
					text = text + str[i] + "-";
				}
				else
				{
					text += text2;
				}
				flag = true;
			}
			else if (str[i] == ' ')
			{
				flag = false;
			}
		}
		return text;
	}

	// Token: 0x0600016F RID: 367 RVA: 0x00008C68 File Offset: 0x00006E68
	public string[] splitStrInLine(string src, int lineWidth)
	{
		ArrayList arrayList = this.splitStrInLineA(src, lineWidth);
		string[] array = new string[arrayList.Count];
		for (int i = 0; i < arrayList.Count; i++)
		{
			array[i] = (string)arrayList[i];
		}
		return array;
	}

	// Token: 0x06000170 RID: 368 RVA: 0x00008CB4 File Offset: 0x00006EB4
	public ArrayList splitStrInLineA(string src, int lineWidth)
	{
		ArrayList arrayList = new ArrayList();
		int num = 0;
		int num2 = 0;
		int length = src.Length;
		if (length < 5)
		{
			arrayList.Add(src);
			return arrayList;
		}
		string text = string.Empty;
		try
		{
			for (;;)
			{
				while (this.getWidthNotExactOf(text) < lineWidth)
				{
					text += src[num2];
					num2++;
					if (src[num2] == '\n')
					{
						break;
					}
					if (num2 >= length - 1)
					{
						num2 = length - 1;
						break;
					}
				}
				if (num2 != length - 1 && src[num2 + 1] != ' ')
				{
					int num3 = num2;
					while (src[num2 + 1] != '\n')
					{
						if (src[num2 + 1] != ' ' || src[num2] == ' ')
						{
							if (num2 != num)
							{
								num2--;
								continue;
							}
						}
						IL_E3:
						if (num2 == num)
						{
							num2 = num3;
							goto IL_ED;
						}
						goto IL_ED;
					}
					goto IL_E3;
				}
				IL_ED:
				string text2 = src.Substring(num, num2 + 1 - num);
				if (text2[0] == '\n')
				{
					text2 = text2.Substring(1, text2.Length - 1);
				}
				if (text2[text2.Length - 1] == '\n')
				{
					text2 = text2.Substring(0, text2.Length - 1);
				}
				arrayList.Add(text2);
				if (num2 == length - 1)
				{
					break;
				}
				num = num2 + 1;
				while (num != length - 1 && src[num] == ' ')
				{
					num++;
				}
				if (num == length - 1)
				{
					break;
				}
				num2 = num;
				text = string.Empty;
			}
		}
		catch (Exception ex)
		{
			Cout.LogWarning(string.Concat(new object[]
			{
				"EXCEPTION WHEN REAL SPLIT ",
				src,
				"\nend=",
				num2,
				"\n",
				ex.Message,
				"\n",
				ex.StackTrace
			}));
			arrayList.Add(src);
		}
		return arrayList;
	}

	// Token: 0x06000171 RID: 369 RVA: 0x00008EE4 File Offset: 0x000070E4
	public string[] splitFontArray(string src, int lineWidth)
	{
		mVector mVector = this.splitFontVector(src, lineWidth);
		string[] array = new string[mVector.size()];
		for (int i = 0; i < mVector.size(); i++)
		{
			array[i] = (string)mVector.elementAt(i);
		}
		return array;
	}

	// Token: 0x06000172 RID: 370 RVA: 0x00008F30 File Offset: 0x00007130
	public bool compare(string strSource, string str)
	{
		for (int i = 0; i < strSource.Length; i++)
		{
			if ((string.Empty + strSource[i]).Equals(str))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000173 RID: 371 RVA: 0x00008F78 File Offset: 0x00007178
	public int getWidth(string s)
	{
		return this.getWidthExactOf(s);
	}

	// Token: 0x06000174 RID: 372 RVA: 0x00008F84 File Offset: 0x00007184
	public int getWidthExactOf(string s)
	{
		int result;
		try
		{
			result = (int)new GUIStyle
			{
				font = this.myFont
			}.CalcSize(new GUIContent(s)).x / mGraphics.zoomLevel;
		}
		catch (Exception ex)
		{
			Cout.LogError(string.Concat(new string[]
			{
				"GET WIDTH OF ",
				s,
				" FAIL.\n",
				ex.Message,
				"\n",
				ex.StackTrace
			}));
			result = this.getWidthNotExactOf(s);
		}
		return result;
	}

	// Token: 0x06000175 RID: 373 RVA: 0x00009038 File Offset: 0x00007238
	public int getWidthNotExactOf(string s)
	{
		return s.Length * this.wO / mGraphics.zoomLevel;
	}

	// Token: 0x06000176 RID: 374 RVA: 0x00009050 File Offset: 0x00007250
	public int getHeight()
	{
		if (this.height > 0)
		{
			return this.height / mGraphics.zoomLevel;
		}
		GUIStyle guistyle = new GUIStyle();
		guistyle.font = this.myFont;
		try
		{
			this.height = (int)guistyle.CalcSize(new GUIContent("Adg")).y + 2;
		}
		catch (Exception ex)
		{
			Cout.LogError("FAIL GET HEIGHT " + ex.StackTrace);
			this.height = 20;
		}
		return this.height / mGraphics.zoomLevel;
	}

	// Token: 0x06000177 RID: 375 RVA: 0x000090FC File Offset: 0x000072FC
	public void _drawString(mGraphics g, string st, int x0, int y0, int align, bool useClip)
	{
		y0 += this.yAddFont;
		GUIStyle guistyle = new GUIStyle(GUI.skin.label);
		guistyle.font = this.myFont;
		float num = 0f;
		float num2 = 0f;
		switch (align)
		{
		case 0:
			num = (float)x0;
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperLeft;
			break;
		case 1:
			num = (float)(x0 - GameCanvas.w);
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperRight;
			break;
		case 2:
		case 3:
			num = (float)(x0 - GameCanvas.w / 2);
			num2 = (float)y0;
			guistyle.alignment = TextAnchor.UpperCenter;
			break;
		}
		int width = this.getWidth(st);
		guistyle.normal.textColor = this.color1;
		g.drawString(st, (int)num, (int)num2, guistyle, width, useClip);
	}

	// Token: 0x06000178 RID: 376 RVA: 0x000091CC File Offset: 0x000073CC
	public static string[] splitStringSv(string _text, string _searchStr)
	{
		int num = 0;
		int startIndex = 0;
		int length = _searchStr.Length;
		int num2 = _text.IndexOf(_searchStr, startIndex);
		while (num2 != -1)
		{
			startIndex = num2 + length;
			num2 = _text.IndexOf(_searchStr, startIndex);
			num++;
		}
		string[] array = new string[num + 1];
		int num3 = _text.IndexOf(_searchStr);
		int num4 = 0;
		int num5 = 0;
		while (num3 != -1)
		{
			array[num5] = _text.Substring(num4, num3 - num4);
			num4 = num3 + length;
			num3 = _text.IndexOf(_searchStr, num4);
			num5++;
		}
		array[num5] = _text.Substring(num4, _text.Length - num4);
		return array;
	}

	// Token: 0x06000179 RID: 377 RVA: 0x00009274 File Offset: 0x00007474
	public void reloadImage()
	{
	}

	// Token: 0x0600017A RID: 378 RVA: 0x00009278 File Offset: 0x00007478
	public void freeImage()
	{
	}

	// Token: 0x04000159 RID: 345
	public static int LEFT = 0;

	// Token: 0x0400015A RID: 346
	public static int RIGHT = 1;

	// Token: 0x0400015B RID: 347
	public static int CENTER = 2;

	// Token: 0x0400015C RID: 348
	public static int RED = 0;

	// Token: 0x0400015D RID: 349
	public static int YELLOW = 1;

	// Token: 0x0400015E RID: 350
	public static int GREEN = 2;

	// Token: 0x0400015F RID: 351
	public static int FATAL = 3;

	// Token: 0x04000160 RID: 352
	public static int MISS = 4;

	// Token: 0x04000161 RID: 353
	public static int ORANGE = 5;

	// Token: 0x04000162 RID: 354
	public static int ADDMONEY = 6;

	// Token: 0x04000163 RID: 355
	public static int MISS_ME = 7;

	// Token: 0x04000164 RID: 356
	public static int FATAL_ME = 8;

	// Token: 0x04000165 RID: 357
	public static int HP = 9;

	// Token: 0x04000166 RID: 358
	public static int MP = 10;

	// Token: 0x04000167 RID: 359
	private int space;

	// Token: 0x04000168 RID: 360
	private Image imgFont;

	// Token: 0x04000169 RID: 361
	private string strFont;

	// Token: 0x0400016A RID: 362
	private int[][] fImages;

	// Token: 0x0400016B RID: 363
	public int yAddFont;

	// Token: 0x0400016C RID: 364
	public static int[] colorJava = new int[]
	{
		0,
		16711680,
		6520319,
		16777215,
		16755200,
		5449989,
		21285,
		52224,
		7386228,
		16771788,
		0,
		65535,
		21285,
		16776960,
		5592405,
		16742263,
		33023,
		8701737,
		15723503,
		7999781,
		16768815,
		14961237,
		4124899,
		4671303,
		16096312,
		16711680,
		16755200,
		52224,
		16777215,
		6520319,
		16096312
	};

	// Token: 0x0400016D RID: 365
	public Font myFont;

	// Token: 0x0400016E RID: 366
	private int height;

	// Token: 0x0400016F RID: 367
	private int wO;

	// Token: 0x04000170 RID: 368
	public int cl1;

	// Token: 0x04000171 RID: 369
	public int cl2;

	// Token: 0x04000172 RID: 370
	public Color color1 = Color.white;

	// Token: 0x04000173 RID: 371
	public Color color2 = Color.gray;

	// Token: 0x04000174 RID: 372
	public sbyte id;

	// Token: 0x04000175 RID: 373
	public int fstyle;

	// Token: 0x04000176 RID: 374
	public string st1 = "áàảãạăắằẳẵặâấầẩẫậéèẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵđÁÀẢÃẠĂẮẰẲẴẶÂẤẦẨẪẬÉÈẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴĐ";

	// Token: 0x04000177 RID: 375
	public string st2 = "¸µ¶·¹¨¾»¼½Æ©ÊÇÈÉËÐÌÎÏÑªÕÒÓÔÖÝ×ØÜÞãßáâä«èåæçé¬íêëìîóïñòô­øõö÷ùýúûüþ®¸µ¶·¹¡¾»¼½Æ¢ÊÇÈÉËÐÌÎÏÑ£ÕÒÓÔÖÝ×ØÜÞãßáâä¤èåæçé¥íêëìîóïñòô¦øõö÷ùýúûüþ§";
}
