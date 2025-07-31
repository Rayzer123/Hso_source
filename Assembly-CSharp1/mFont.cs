using System;

// Token: 0x0200002E RID: 46
public class mFont
{
	// Token: 0x06000216 RID: 534 RVA: 0x0000CAEC File Offset: 0x0000ACEC
	public mFont(string strFont, string pathImage, string pathData, int space, int id)
	{
		int num = this.setColorFontByID(id);
		this.fontS = new FontSys((sbyte)id, num, num);
	}

	// Token: 0x06000217 RID: 535 RVA: 0x0000CB18 File Offset: 0x0000AD18
	public mFont(string strFont, string pathImage, string pathData, int space, int color, sbyte ID)
	{
		color = this.setColorFontByID((int)ID);
		this.fontS = new FontSys(ID, color, color);
	}

	// Token: 0x06000219 RID: 537 RVA: 0x0000CB9C File Offset: 0x0000AD9C
	public static void loadmFont()
	{
		mFont.tahoma_7b_orange = new mFont(mFont.str, "/mfont/tahoma_7b_orange.png", "/mfont/tahoma_7b", 0, 0);
		mFont.tahoma_7b_blue = new mFont(mFont.str, "/mfont/tahoma_7b_blue.png", "/mfont/tahoma_7b", 0, 1);
		mFont.tahoma_7b_black = new mFont(mFont.str, "/mfont/tahoma_7b_black.png", "/mfont/tahoma_7b", 0, 2);
		mFont.tahoma_7b_yellow = new mFont(mFont.str, "/mfont/tahoma_7b_yellow.png", "/mfont/tahoma_7b", 0, 3);
		mFont.tahoma_7b_violet = new mFont(mFont.str, "/mfont/tahoma_7b_violet.png", "/mfont/tahoma_7b", 0, 4);
		mFont.tahoma_7b_white = new mFont(mFont.str, "/mfont/tahoma_7b_white.png", "/mfont/tahoma_7b", 0, 5);
		mFont.tahoma_7b_green = new mFont(mFont.str, "/mfont/tahoma_7b_green.png", "/mfont/tahoma_7b", 0, 6);
		mFont.tahoma_7b_brown = new mFont(mFont.str, "/mfont/tahoma_7b_brown.png", "/mfont/tahoma_7b", 0, 7);
		mFont.tahoma_7b_red = new mFont(mFont.str, "/mfont/tahoma_7b_red.png", "/mfont/tahoma_7b", 0, 8);
		mFont.tahoma_7_black = new mFont(mFont.str, "/mfont/tahoma_7_black.png", "/mfont/tahoma_7", 0, 9);
		mFont.tahoma_7_white = new mFont(mFont.str, "/mfont/tahoma_7_white.png", "/mfont/tahoma_7", 0, 10);
		mFont.tahoma_7_yellow = new mFont(mFont.str, "/mfont/tahoma_7_yellow.png", "/mfont/tahoma_7", 0, 11);
		mFont.tahoma_7_orange = new mFont(mFont.str, "/mfont/tahoma_7_orange.png", "/mfont/tahoma_7", 0, 12);
		mFont.tahoma_7_red = new mFont(mFont.str, "/mfont/tahoma_7_red.png", "/mfont/tahoma_7", 0, 13);
		mFont.tahoma_7_blue = new mFont(mFont.str, "/mfont/tahoma_7_blue.png", "/mfont/tahoma_7", 0, 14);
		mFont.tahoma_7_green = new mFont(mFont.str, "/mfont/tahoma_7_green.png", "/mfont/tahoma_7", 0, 15);
		mFont.tahoma_7_violet = new mFont(mFont.str, "/mfont/tahoma_7_violet.png", "/mfont/tahoma_7", 0, 21);
		mFont.tahoma_7_gray = new mFont(mFont.str, "/mfont/tahoma_7_gray.png", "/mfont/tahoma_7", 0, 22);
		mFont.number_yellow = new mFont(" 0123456789+-", "/mfont/number_yellow.png", "/mfont/number", 0, 16);
		mFont.number_red = new mFont(" 0123456789+-", "/mfont/number_red.png", "/mfont/number", 0, 17);
		mFont.number_green = new mFont(" 0123456789+-", "/mfont/number_green.png", "/mfont/number", 0, 18);
		mFont.number_white = new mFont(" 0123456789+-", "/mfont/number_white.png", "/mfont/number", 0, 19);
		mFont.number_orange = new mFont(" 0123456789+-", "/mfont/number_orange.png", "/mfont/number", 0, 20);
		mFont.tahoma_8b_brown = new mFont(mFont.str, "/mfont/tahoma_7b_brown.png", "/mfont/tahoma_7b", 0, 30);
		mFont.tahoma_8b_black = new mFont(mFont.str, "/mfont/tahoma_7b_black.png", "/mfont/tahoma_7b", 0, 31);
		mFont.number_Yellow_Small = new mFont(mFont.str, "/mfont/number_yellow.png", "/mfont/number", 0, 11);
	}

	// Token: 0x0600021A RID: 538 RVA: 0x0000CE78 File Offset: 0x0000B078
	public int setColorFontByID(int id)
	{
		switch (id)
		{
		case 0:
		case 12:
		case 20:
			return 16686378;
		case 1:
		case 14:
			return 7511551;
		case 2:
		case 9:
		case 31:
			return 1250067;
		case 3:
		case 11:
		case 16:
			return 16580155;
		case 4:
		case 21:
			return 11830015;
		case 5:
		case 10:
		case 19:
			return 16777215;
		case 6:
		case 15:
		case 18:
			return 6741809;
		case 7:
			return 4724752;
		case 8:
		case 13:
		case 17:
			return 16711680;
		case 22:
			return 258434919;
		case 30:
			return 11957553;
		case 32:
			return 16580155;
		}
		return 0;
	}

	// Token: 0x0600021B RID: 539 RVA: 0x0000CF60 File Offset: 0x0000B160
	public void reloadImage()
	{
	}

	// Token: 0x0600021C RID: 540 RVA: 0x0000CF64 File Offset: 0x0000B164
	public void freeImage()
	{
	}

	// Token: 0x0600021D RID: 541 RVA: 0x0000CF68 File Offset: 0x0000B168
	public int getHeight()
	{
		return this.height;
	}

	// Token: 0x0600021E RID: 542 RVA: 0x0000CF70 File Offset: 0x0000B170
	public void setHeight(int height)
	{
		this.height = height;
	}

	// Token: 0x0600021F RID: 543 RVA: 0x0000CF7C File Offset: 0x0000B17C
	public int getWidth(string st)
	{
		return this.fontS.getWidth(st);
	}

	// Token: 0x06000220 RID: 544 RVA: 0x0000CF8C File Offset: 0x0000B18C
	public void drawString(mGraphics g, string st, int x, int y, int align, bool useClip)
	{
		this.fontS.drawString(g, st, x, y, align, useClip);
	}

	// Token: 0x06000221 RID: 545 RVA: 0x0000CFA4 File Offset: 0x0000B1A4
	public void drawString(mGraphics g, string st, int x, int y, int align, mFont font, bool useClip)
	{
		font.fontS.drawString(g, st, x + 1, y, align, useClip);
		font.fontS.drawString(g, st, x, y + 1, align, useClip);
		this.fontS.drawString(g, st, x, y, align, useClip);
	}

	// Token: 0x06000222 RID: 546 RVA: 0x0000CFF4 File Offset: 0x0000B1F4
	public void drawString(mGraphics g, string st, int x, int y, int align, mFont font1, mFont font2, bool useClip)
	{
		font1.fontS.drawString(g, st, x + 1, y, align, useClip);
		font2.fontS.drawString(g, st, x, y + 1, align, useClip);
		this.fontS.drawString(g, st, x, y, align, useClip);
	}

	// Token: 0x06000223 RID: 547 RVA: 0x0000D044 File Offset: 0x0000B244
	public mVector splitFontVector(string src, int lineWidth)
	{
		return this.fontS.splitFontVector(src, lineWidth);
	}

	// Token: 0x06000224 RID: 548 RVA: 0x0000D054 File Offset: 0x0000B254
	public static string[] split(string original, string separator)
	{
		return FontSys.splitStringSv(original, separator);
	}

	// Token: 0x06000225 RID: 549 RVA: 0x0000D060 File Offset: 0x0000B260
	public string splitFirst(string str)
	{
		return this.fontS.splitFirst(str);
	}

	// Token: 0x06000226 RID: 550 RVA: 0x0000D070 File Offset: 0x0000B270
	public string[] splitFontArray(string src, int lineWidth)
	{
		return this.fontS.splitFontArray(src, lineWidth);
	}

	// Token: 0x06000227 RID: 551 RVA: 0x0000D080 File Offset: 0x0000B280
	public bool compare(string strSource, string str)
	{
		return this.fontS.compare(strSource, str);
	}

	// Token: 0x040001D1 RID: 465
	public static int LEFT;

	// Token: 0x040001D2 RID: 466
	public static sbyte RIGHT = 1;

	// Token: 0x040001D3 RID: 467
	public static sbyte CENTER = 2;

	// Token: 0x040001D4 RID: 468
	public static sbyte RED;

	// Token: 0x040001D5 RID: 469
	public static sbyte YELLOW = 1;

	// Token: 0x040001D6 RID: 470
	public static sbyte GREEN = 2;

	// Token: 0x040001D7 RID: 471
	public static sbyte FATAL = 3;

	// Token: 0x040001D8 RID: 472
	public static sbyte MISS = 4;

	// Token: 0x040001D9 RID: 473
	public static sbyte ORANGE = 5;

	// Token: 0x040001DA RID: 474
	public static sbyte ADDMONEY = 6;

	// Token: 0x040001DB RID: 475
	public static sbyte MISS_ME = 7;

	// Token: 0x040001DC RID: 476
	public static sbyte FATAL_ME = 8;

	// Token: 0x040001DD RID: 477
	private int space;

	// Token: 0x040001DE RID: 478
	private int height;

	// Token: 0x040001DF RID: 479
	private string strFont;

	// Token: 0x040001E0 RID: 480
	public FontSys fontS;

	// Token: 0x040001E1 RID: 481
	public static string str = " 0123456789+-*='_?.,<>/[]{}!@#$%^&*():aáàảãạâấầẩẫậăắằẳẵặbcdđeéèẻẽẹêếềểễệfghiíìỉĩịjklmnoóòỏõọôốồổỗộơớờởỡợpqrstuúùủũụưứừửữựvxyýỳỷỹỵzwAÁÀẢÃẠĂẰẮẲẴẶÂẤẦẨẪẬBCDĐEÉÈẺẼẸÊẾỀỂỄỆFGHIÍÌỈĨỊJKLMNOÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢPQRSTUÚÙỦŨỤƯỨỪỬỮỰVXYÝỲỶỸỴZW";

	// Token: 0x040001E2 RID: 482
	public static mFont tahoma_7b_orange;

	// Token: 0x040001E3 RID: 483
	public static mFont tahoma_7b_blue;

	// Token: 0x040001E4 RID: 484
	public static mFont tahoma_7b_black;

	// Token: 0x040001E5 RID: 485
	public static mFont tahoma_7b_yellow;

	// Token: 0x040001E6 RID: 486
	public static mFont tahoma_7b_violet;

	// Token: 0x040001E7 RID: 487
	public static mFont tahoma_7b_white;

	// Token: 0x040001E8 RID: 488
	public static mFont tahoma_7b_green;

	// Token: 0x040001E9 RID: 489
	public static mFont tahoma_7b_red;

	// Token: 0x040001EA RID: 490
	public static mFont tahoma_7b_brown;

	// Token: 0x040001EB RID: 491
	public static mFont tahoma_7_black;

	// Token: 0x040001EC RID: 492
	public static mFont tahoma_7_white;

	// Token: 0x040001ED RID: 493
	public static mFont tahoma_7_yellow;

	// Token: 0x040001EE RID: 494
	public static mFont tahoma_7_orange;

	// Token: 0x040001EF RID: 495
	public static mFont tahoma_7_red;

	// Token: 0x040001F0 RID: 496
	public static mFont tahoma_7_blue;

	// Token: 0x040001F1 RID: 497
	public static mFont tahoma_7_green;

	// Token: 0x040001F2 RID: 498
	public static mFont tahoma_7_violet;

	// Token: 0x040001F3 RID: 499
	public static mFont number_yellow;

	// Token: 0x040001F4 RID: 500
	public static mFont number_red;

	// Token: 0x040001F5 RID: 501
	public static mFont number_green;

	// Token: 0x040001F6 RID: 502
	public static mFont number_white;

	// Token: 0x040001F7 RID: 503
	public static mFont number_orange;

	// Token: 0x040001F8 RID: 504
	public static mFont tahoma_8b_brown;

	// Token: 0x040001F9 RID: 505
	public static mFont tahoma_8b_black;

	// Token: 0x040001FA RID: 506
	public static mFont number_Yellow_Small;

	// Token: 0x040001FB RID: 507
	public static mFont tahoma_7_gray;

	// Token: 0x040001FC RID: 508
	private string pathImage;
}
