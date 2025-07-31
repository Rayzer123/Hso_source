using System;

// Token: 0x0200000D RID: 13
public class Math
{
	// Token: 0x06000083 RID: 131 RVA: 0x000039D4 File Offset: 0x00001BD4
	public static int abs(int i)
	{
		return (i <= 0) ? (-i) : i;
	}

	// Token: 0x06000084 RID: 132 RVA: 0x000039E8 File Offset: 0x00001BE8
	public static float abs(float i)
	{
		return (i <= 0f) ? (-i) : i;
	}

	// Token: 0x06000085 RID: 133 RVA: 0x00003A00 File Offset: 0x00001C00
	public static int min(int x, int y)
	{
		return (x >= y) ? y : x;
	}

	// Token: 0x06000086 RID: 134 RVA: 0x00003A10 File Offset: 0x00001C10
	public static int max(int x, int y)
	{
		return (x <= y) ? y : x;
	}

	// Token: 0x06000087 RID: 135 RVA: 0x00003A20 File Offset: 0x00001C20
	public static int pow(int data, int x)
	{
		int num = 1;
		for (int i = 0; i < x; i++)
		{
			num *= data;
		}
		return num;
	}
}
