using System;
using System.Threading;
using UnityEngine;

// Token: 0x02000007 RID: 7
public class DataInputStream
{
	// Token: 0x06000042 RID: 66 RVA: 0x00002D8C File Offset: 0x00000F8C
	public DataInputStream(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.r = new myReader(ArrayCast.cast(textAsset.bytes));
	}

	// Token: 0x06000043 RID: 67 RVA: 0x00002DCC File Offset: 0x00000FCC
	public DataInputStream(sbyte[] data)
	{
		this.r = new myReader(data);
	}

	// Token: 0x06000044 RID: 68 RVA: 0x00002DE0 File Offset: 0x00000FE0
	public static void update()
	{
		if (DataInputStream.status == 2)
		{
			DataInputStream.status = 1;
			DataInputStream.istemp = DataInputStream.__getResourceAsStream(DataInputStream.filenametemp);
			DataInputStream.status = 0;
		}
	}

	// Token: 0x06000045 RID: 69 RVA: 0x00002E14 File Offset: 0x00001014
	public static DataInputStream getResourceAsStream(string filename)
	{
		return DataInputStream.__getResourceAsStream(filename);
	}

	// Token: 0x06000046 RID: 70 RVA: 0x00002E1C File Offset: 0x0000101C
	private static DataInputStream _getResourceAsStream(string filename)
	{
		if (DataInputStream.status != 0)
		{
			for (int i = 0; i < 500; i++)
			{
				Thread.Sleep(5);
				if (DataInputStream.status == 0)
				{
					break;
				}
			}
			if (DataInputStream.status != 0)
			{
				Debug.LogError("CANNOT GET INPUTSTREAM " + filename + " WHEN GETTING " + DataInputStream.filenametemp);
				return null;
			}
		}
		DataInputStream.istemp = null;
		DataInputStream.filenametemp = filename;
		DataInputStream.status = 2;
		int j;
		for (j = 0; j < 500; j++)
		{
			Thread.Sleep(5);
			if (DataInputStream.status == 0)
			{
				break;
			}
		}
		if (j == 500)
		{
			Debug.LogError("TOO LONG FOR CREATE INPUTSTREAM " + filename);
			DataInputStream.status = 0;
			return null;
		}
		return DataInputStream.istemp;
	}

	// Token: 0x06000047 RID: 71 RVA: 0x00002EEC File Offset: 0x000010EC
	private static DataInputStream __getResourceAsStream(string filename)
	{
		DataInputStream result;
		try
		{
			result = new DataInputStream(filename);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x06000048 RID: 72 RVA: 0x00002F34 File Offset: 0x00001134
	public short readShort()
	{
		return this.r.readShort();
	}

	// Token: 0x06000049 RID: 73 RVA: 0x00002F44 File Offset: 0x00001144
	public int readInt()
	{
		return this.r.readInt();
	}

	// Token: 0x0600004A RID: 74 RVA: 0x00002F54 File Offset: 0x00001154
	public int read()
	{
		return (int)this.r.readUnsignedByte();
	}

	// Token: 0x0600004B RID: 75 RVA: 0x00002F64 File Offset: 0x00001164
	public void read(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x0600004C RID: 76 RVA: 0x00002F74 File Offset: 0x00001174
	public void close()
	{
		this.r.Close();
	}

	// Token: 0x0600004D RID: 77 RVA: 0x00002F84 File Offset: 0x00001184
	public void Close()
	{
		this.r.Close();
	}

	// Token: 0x0600004E RID: 78 RVA: 0x00002F94 File Offset: 0x00001194
	public string readUTF()
	{
		return this.r.readUTF();
	}

	// Token: 0x0600004F RID: 79 RVA: 0x00002FA4 File Offset: 0x000011A4
	public sbyte readByte()
	{
		return this.r.readByte();
	}

	// Token: 0x06000050 RID: 80 RVA: 0x00002FB4 File Offset: 0x000011B4
	public long readLong()
	{
		return this.r.readLong();
	}

	// Token: 0x06000051 RID: 81 RVA: 0x00002FC4 File Offset: 0x000011C4
	public bool readBoolean()
	{
		return this.r.readBoolean();
	}

	// Token: 0x06000052 RID: 82 RVA: 0x00002FD4 File Offset: 0x000011D4
	public int readUnsignedByte()
	{
		return (int)((byte)this.r.readByte());
	}

	// Token: 0x06000053 RID: 83 RVA: 0x00002FE4 File Offset: 0x000011E4
	public int readUnsignedShort()
	{
		return (int)this.r.readUnsignedShort();
	}

	// Token: 0x06000054 RID: 84 RVA: 0x00002FF4 File Offset: 0x000011F4
	public void readFully(ref sbyte[] data)
	{
		this.r.read(ref data);
	}

	// Token: 0x06000055 RID: 85 RVA: 0x00003004 File Offset: 0x00001204
	public int available()
	{
		return this.r.available();
	}

	// Token: 0x04000035 RID: 53
	private const int INTERVAL = 5;

	// Token: 0x04000036 RID: 54
	private const int MAXTIME = 500;

	// Token: 0x04000037 RID: 55
	public myReader r;

	// Token: 0x04000038 RID: 56
	public static DataInputStream istemp;

	// Token: 0x04000039 RID: 57
	private static int status;

	// Token: 0x0400003A RID: 58
	private static string filenametemp;
}
