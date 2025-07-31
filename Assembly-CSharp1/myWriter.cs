using System;
using System.IO;
using System.Text;

// Token: 0x02000029 RID: 41
public class myWriter
{
	// Token: 0x060001F0 RID: 496 RVA: 0x0000C3E8 File Offset: 0x0000A5E8
	public void writeSByte(sbyte value)
	{
		this.checkLenght(0);
		this.buffer[this.posWrite++] = value;
	}

	// Token: 0x060001F1 RID: 497 RVA: 0x0000C418 File Offset: 0x0000A618
	public void writeSByteUncheck(sbyte value)
	{
		this.buffer[this.posWrite++] = value;
	}

	// Token: 0x060001F2 RID: 498 RVA: 0x0000C440 File Offset: 0x0000A640
	public void writeByte(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x060001F3 RID: 499 RVA: 0x0000C44C File Offset: 0x0000A64C
	public void writeByte(int value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x060001F4 RID: 500 RVA: 0x0000C458 File Offset: 0x0000A658
	public void writeUnsignedByte(byte value)
	{
		this.writeSByte((sbyte)value);
	}

	// Token: 0x060001F5 RID: 501 RVA: 0x0000C464 File Offset: 0x0000A664
	public void writeUnsignedByte(byte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck((sbyte)value[i]);
		}
	}

	// Token: 0x060001F6 RID: 502 RVA: 0x0000C498 File Offset: 0x0000A698
	public void writeSByte(sbyte[] value)
	{
		this.checkLenght(value.Length);
		for (int i = 0; i < value.Length; i++)
		{
			this.writeSByteUncheck(value[i]);
		}
	}

	// Token: 0x060001F7 RID: 503 RVA: 0x0000C4CC File Offset: 0x0000A6CC
	public void writeShort(short value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x060001F8 RID: 504 RVA: 0x0000C504 File Offset: 0x0000A704
	public void writeShort(int value)
	{
		this.checkLenght(2);
		short num = (short)value;
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(num >> i * 8));
		}
	}

	// Token: 0x060001F9 RID: 505 RVA: 0x0000C53C File Offset: 0x0000A73C
	public void writeUnsignedShort(ushort value)
	{
		this.checkLenght(2);
		for (int i = 1; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x060001FA RID: 506 RVA: 0x0000C574 File Offset: 0x0000A774
	public void writeInt(int value)
	{
		this.checkLenght(4);
		for (int i = 3; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x060001FB RID: 507 RVA: 0x0000C5AC File Offset: 0x0000A7AC
	public void writeLong(long value)
	{
		this.checkLenght(8);
		for (int i = 7; i >= 0; i--)
		{
			this.writeSByteUncheck((sbyte)(value >> i * 8));
		}
	}

	// Token: 0x060001FC RID: 508 RVA: 0x0000C5E4 File Offset: 0x0000A7E4
	public void writeBoolean(bool value)
	{
		this.writeSByte((!value) ? 0 : 1);
	}

	// Token: 0x060001FD RID: 509 RVA: 0x0000C5FC File Offset: 0x0000A7FC
	public void writeBool(bool value)
	{
		this.writeSByte((!value) ? 0 : 1);
	}

	// Token: 0x060001FE RID: 510 RVA: 0x0000C614 File Offset: 0x0000A814
	public void writeString(string value)
	{
		char[] array = value.ToCharArray();
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		for (int i = 0; i < array.Length; i++)
		{
			this.writeSByteUncheck((sbyte)array[i]);
		}
	}

	// Token: 0x060001FF RID: 511 RVA: 0x0000C65C File Offset: 0x0000A85C
	public void writeUTF(string value)
	{
		Encoding unicode = Encoding.Unicode;
		Encoding encoding = Encoding.GetEncoding(65001);
		byte[] bytes = unicode.GetBytes(value);
		byte[] array = Encoding.Convert(unicode, encoding, bytes);
		this.writeShort((short)array.Length);
		this.checkLenght(array.Length);
		foreach (sbyte value2 in array)
		{
			this.writeSByteUncheck(value2);
		}
	}

	// Token: 0x06000200 RID: 512 RVA: 0x0000C6C8 File Offset: 0x0000A8C8
	public void write(sbyte value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000201 RID: 513 RVA: 0x0000C6D4 File Offset: 0x0000A8D4
	public void write(sbyte[] value)
	{
		this.writeSByte(value);
	}

	// Token: 0x06000202 RID: 514 RVA: 0x0000C6E0 File Offset: 0x0000A8E0
	public sbyte[] getData()
	{
		if (this.posWrite <= 0)
		{
			return null;
		}
		sbyte[] array = new sbyte[this.posWrite];
		for (int i = 0; i < this.posWrite; i++)
		{
			array[i] = this.buffer[i];
		}
		return array;
	}

	// Token: 0x06000203 RID: 515 RVA: 0x0000C72C File Offset: 0x0000A92C
	public void checkLenght(int ltemp)
	{
		if (this.posWrite + ltemp > this.lenght)
		{
			sbyte[] array = new sbyte[this.lenght + 1024 + ltemp];
			for (int i = 0; i < this.lenght; i++)
			{
				array[i] = this.buffer[i];
			}
			this.buffer = null;
			this.buffer = array;
			this.lenght += 1024 + ltemp;
		}
	}

	// Token: 0x06000204 RID: 516 RVA: 0x0000C7A4 File Offset: 0x0000A9A4
	private static void convertString(string[] args)
	{
		string path = args[0];
		string path2 = args[1];
		using (StreamReader streamReader = new StreamReader(path, Encoding.Unicode))
		{
			using (StreamWriter streamWriter = new StreamWriter(path2, false, Encoding.UTF8))
			{
				myWriter.CopyContents(streamReader, streamWriter);
			}
		}
	}

	// Token: 0x06000205 RID: 517 RVA: 0x0000C834 File Offset: 0x0000AA34
	private static void CopyContents(TextReader input, TextWriter output)
	{
		char[] array = new char[8192];
		int count;
		while ((count = input.Read(array, 0, array.Length)) != 0)
		{
			output.Write(array, 0, count);
		}
		output.Flush();
		string text = output.ToString();
	}

	// Token: 0x06000206 RID: 518 RVA: 0x0000C87C File Offset: 0x0000AA7C
	public byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x06000207 RID: 519 RVA: 0x0000C894 File Offset: 0x0000AA94
	public byte[] convertSbyteToByte(sbyte[] var)
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

	// Token: 0x06000208 RID: 520 RVA: 0x0000C8E4 File Offset: 0x0000AAE4
	public void Close()
	{
		this.buffer = null;
	}

	// Token: 0x06000209 RID: 521 RVA: 0x0000C8F0 File Offset: 0x0000AAF0
	public void close()
	{
		this.buffer = null;
	}

	// Token: 0x040001CA RID: 458
	public sbyte[] buffer = new sbyte[2048];

	// Token: 0x040001CB RID: 459
	private int posWrite;

	// Token: 0x040001CC RID: 460
	private int lenght = 2048;
}
