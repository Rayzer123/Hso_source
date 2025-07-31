using System;

// Token: 0x02000005 RID: 5
public class ArrayCast
{
	// Token: 0x06000038 RID: 56 RVA: 0x00002CD0 File Offset: 0x00000ED0
	public static sbyte[] cast(byte[] data)
	{
		sbyte[] array = new sbyte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (sbyte)data[i];
		}
		return array;
	}

	// Token: 0x06000039 RID: 57 RVA: 0x00002D04 File Offset: 0x00000F04
	public static byte[] cast(sbyte[] data)
	{
		byte[] array = new byte[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (byte)data[i];
		}
		return array;
	}

	// Token: 0x0600003A RID: 58 RVA: 0x00002D38 File Offset: 0x00000F38
	public static char[] ToCharArray(sbyte[] data)
	{
		char[] array = new char[data.Length];
		for (int i = 0; i < array.Length; i++)
		{
			array[i] = (char)data[i];
		}
		return array;
	}
}
