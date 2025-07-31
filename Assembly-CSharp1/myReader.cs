using System;
using System.Text;
using UnityEngine;

// Token: 0x02000028 RID: 40
public class myReader
{
	// Token: 0x060001D3 RID: 467 RVA: 0x0000BF54 File Offset: 0x0000A154
	public myReader()
	{
	}

	// Token: 0x060001D4 RID: 468 RVA: 0x0000BF5C File Offset: 0x0000A15C
	public myReader(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x060001D5 RID: 469 RVA: 0x0000BF6C File Offset: 0x0000A16C
	public myReader(string filename)
	{
		TextAsset textAsset = (TextAsset)Resources.Load(filename, typeof(TextAsset));
		this.buffer = mSystem.convertToSbyte(textAsset.bytes);
	}

	// Token: 0x060001D7 RID: 471 RVA: 0x0000BFAC File Offset: 0x0000A1AC
	public sbyte readSByte()
	{
		if (this.posRead < this.buffer.Length)
		{
			return this.buffer[this.posRead++];
		}
		this.posRead = this.buffer.Length;
		return 0;
	}

	// Token: 0x060001D8 RID: 472 RVA: 0x0000BFF4 File Offset: 0x0000A1F4
	public sbyte readsbyte()
	{
		return this.readSByte();
	}

	// Token: 0x060001D9 RID: 473 RVA: 0x0000BFFC File Offset: 0x0000A1FC
	public sbyte readByte()
	{
		return this.readSByte();
	}

	// Token: 0x060001DA RID: 474 RVA: 0x0000C004 File Offset: 0x0000A204
	public void mark(int readlimit)
	{
		this.posMark = this.posRead;
	}

	// Token: 0x060001DB RID: 475 RVA: 0x0000C014 File Offset: 0x0000A214
	public void reset()
	{
		this.posRead = this.posMark;
	}

	// Token: 0x060001DC RID: 476 RVA: 0x0000C024 File Offset: 0x0000A224
	public byte readUnsignedByte()
	{
		return myReader.convertSbyteToByte(this.readSByte());
	}

	// Token: 0x060001DD RID: 477 RVA: 0x0000C034 File Offset: 0x0000A234
	public short readShort()
	{
		short num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (short)(num << 8);
			num |= (short)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001DE RID: 478 RVA: 0x0000C080 File Offset: 0x0000A280
	public ushort readUnsignedShort()
	{
		ushort num = 0;
		for (int i = 0; i < 2; i++)
		{
			num = (ushort)(num << 8);
			num |= (ushort)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001DF RID: 479 RVA: 0x0000C0CC File Offset: 0x0000A2CC
	public int readInt()
	{
		int num = 0;
		for (int i = 0; i < 4; i++)
		{
			num <<= 8;
			num |= (255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001E0 RID: 480 RVA: 0x0000C114 File Offset: 0x0000A314
	public long readLong()
	{
		long num = 0L;
		for (int i = 0; i < 8; i++)
		{
			num <<= 8;
			num |= (long)(255 & (int)this.buffer[this.posRead++]);
		}
		return num;
	}

	// Token: 0x060001E1 RID: 481 RVA: 0x0000C160 File Offset: 0x0000A360
	public bool readBool()
	{
		return (int)this.readSByte() > 0;
	}

	// Token: 0x060001E2 RID: 482 RVA: 0x0000C178 File Offset: 0x0000A378
	public bool readBoolean()
	{
		return (int)this.readSByte() > 0;
	}

	// Token: 0x060001E3 RID: 483 RVA: 0x0000C190 File Offset: 0x0000A390
	public string readString()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x060001E4 RID: 484 RVA: 0x0000C1D8 File Offset: 0x0000A3D8
	public string readStringUTF()
	{
		short num = this.readShort();
		byte[] array = new byte[(int)num];
		for (int i = 0; i < (int)num; i++)
		{
			array[i] = myReader.convertSbyteToByte(this.readSByte());
		}
		UTF8Encoding utf8Encoding = new UTF8Encoding();
		return utf8Encoding.GetString(array);
	}

	// Token: 0x060001E5 RID: 485 RVA: 0x0000C220 File Offset: 0x0000A420
	public string readUTF()
	{
		return this.readStringUTF();
	}

	// Token: 0x060001E6 RID: 486 RVA: 0x0000C228 File Offset: 0x0000A428
	public int read()
	{
		if (this.posRead < this.buffer.Length)
		{
			return (int)this.readSByte();
		}
		return -1;
	}

	// Token: 0x060001E7 RID: 487 RVA: 0x0000C248 File Offset: 0x0000A448
	public int read(ref sbyte[] data)
	{
		if (data == null)
		{
			return 0;
		}
		int num = 0;
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = this.readSByte();
			if (this.posRead > this.buffer.Length)
			{
				return -1;
			}
			num++;
		}
		return num;
	}

	// Token: 0x060001E8 RID: 488 RVA: 0x0000C29C File Offset: 0x0000A49C
	public void readFully(ref sbyte[] data)
	{
		if (data == null || data.Length + this.posRead > this.buffer.Length)
		{
			return;
		}
		for (int i = 0; i < data.Length; i++)
		{
			data[i] = this.readSByte();
		}
	}

	// Token: 0x060001E9 RID: 489 RVA: 0x0000C2E8 File Offset: 0x0000A4E8
	public int available()
	{
		return this.buffer.Length - this.posRead;
	}

	// Token: 0x060001EA RID: 490 RVA: 0x0000C2FC File Offset: 0x0000A4FC
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x060001EB RID: 491 RVA: 0x0000C314 File Offset: 0x0000A514
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x060001EC RID: 492 RVA: 0x0000C364 File Offset: 0x0000A564
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x060001ED RID: 493 RVA: 0x0000C370 File Offset: 0x0000A570
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x060001EE RID: 494 RVA: 0x0000C37C File Offset: 0x0000A57C
	public void read(ref sbyte[] data, int arg1, int arg2)
	{
		if (data == null)
		{
			return;
		}
		for (int i = 0; i < arg2; i++)
		{
			data[i + arg1] = this.readSByte();
			if (this.posRead > this.buffer.Length)
			{
				return;
			}
		}
	}

	// Token: 0x040001C5 RID: 453
	public sbyte[] buffer;

	// Token: 0x040001C6 RID: 454
	private int posRead;

	// Token: 0x040001C7 RID: 455
	private int posMark;

	// Token: 0x040001C8 RID: 456
	private static string fileName;

	// Token: 0x040001C9 RID: 457
	private static int status;
}
