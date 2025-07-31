using System;

// Token: 0x02000011 RID: 17
public class MyStream
{
	// Token: 0x06000093 RID: 147 RVA: 0x00004010 File Offset: 0x00002210
	public static DataInputStream readFile(string path)
	{
		path = Main.res + path;
		DataInputStream result;
		try
		{
			result = DataInputStream.getResourceAsStream(path);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}
}
