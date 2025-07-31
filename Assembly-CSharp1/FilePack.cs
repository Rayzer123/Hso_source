using System;

// Token: 0x020000B7 RID: 183
public class FilePack
{
	// Token: 0x06000931 RID: 2353 RVA: 0x00096848 File Offset: 0x00094A48
	public FilePack()
	{
		this.codeLen = this.code.Length;
	}

	// Token: 0x06000932 RID: 2354 RVA: 0x00096884 File Offset: 0x00094A84
	public FilePack(string name, sbyte[] array)
	{
		int num = 0;
		int num2 = 0;
		this.name = name;
		if (array == null)
		{
			this.open();
		}
		else
		{
			this.openbyArray(array);
		}
		if (this.file == null)
		{
			FilePack.instance = null;
			return;
		}
		try
		{
			this.nFile = this.encode(this.file.readUnsignedByte());
			this.fname = new string[this.nFile];
			this.fpos = new int[this.nFile];
			this.flen = new int[this.nFile];
			for (int i = 0; i < this.nFile; i++)
			{
				int num3 = this.encode((int)this.file.readByte());
				sbyte[] array2 = new sbyte[num3];
				this.file.read(ref array2);
				this.encode(array2);
				this.fname[i] = new string(mSystem.ToCharArray(array2));
				this.fpos[i] = num;
				this.flen[i] = this.encode(this.file.readUnsignedShort());
				num += this.flen[i];
				num2 += this.flen[i];
			}
			this.fullData = new sbyte[num2];
			this.file.readFully(ref this.fullData);
			this.encode(this.fullData);
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi FilePack 1");
		}
		this.close();
	}

	// Token: 0x06000934 RID: 2356 RVA: 0x00096A78 File Offset: 0x00094C78
	public static void reset()
	{
		if (FilePack.instance != null)
		{
			FilePack.instance.close();
		}
		FilePack.instance = null;
		mSystem.gcc();
	}

	// Token: 0x06000935 RID: 2357 RVA: 0x00096A9C File Offset: 0x00094C9C
	public static mImage getImg(string path)
	{
		return FilePack.instance.loadImage(path + ".png");
	}

	// Token: 0x06000936 RID: 2358 RVA: 0x00096AB4 File Offset: 0x00094CB4
	public static void init(string path)
	{
		FilePack.instance = new FilePack(path, null);
	}

	// Token: 0x06000937 RID: 2359 RVA: 0x00096AC4 File Offset: 0x00094CC4
	public static void initByArray(sbyte[] array)
	{
		FilePack.instance = new FilePack(string.Empty, array);
	}

	// Token: 0x06000938 RID: 2360 RVA: 0x00096AD8 File Offset: 0x00094CD8
	private int encode(int i)
	{
		return i;
	}

	// Token: 0x06000939 RID: 2361 RVA: 0x00096ADC File Offset: 0x00094CDC
	private void encode(sbyte[] bytes)
	{
		int num = bytes.Length;
		for (int i = 0; i < num; i++)
		{
			bytes[i] = (sbyte)((int)bytes[i] ^ (int)this.code[i % this.codeLen]);
		}
	}

	// Token: 0x0600093A RID: 2362 RVA: 0x00096B18 File Offset: 0x00094D18
	private void open()
	{
		this.file = new DataInputStream(this.name);
	}

	// Token: 0x0600093B RID: 2363 RVA: 0x00096B2C File Offset: 0x00094D2C
	private void openbyArray(sbyte[] array)
	{
		this.file = new DataInputStream(array);
	}

	// Token: 0x0600093C RID: 2364 RVA: 0x00096B3C File Offset: 0x00094D3C
	public void close()
	{
		try
		{
			if (this.file != null)
			{
				this.file.close();
			}
		}
		catch (Exception ex)
		{
			mSystem.outloi("loi FilePack 1");
		}
	}

	// Token: 0x0600093D RID: 2365 RVA: 0x00096B90 File Offset: 0x00094D90
	public sbyte[] loadFile(string fileName)
	{
		try
		{
			for (int i = 0; i < this.nFile; i++)
			{
				if (this.fname[i].CompareTo(fileName) == 0)
				{
					sbyte[] array = new sbyte[this.flen[i]];
					Array.Copy(this.fullData, this.fpos[i], array, 0, this.flen[i]);
					return array;
				}
			}
		}
		catch (Exception ex)
		{
			Cout.Log("File '" + fileName + "' not found!");
		}
		return null;
	}

	// Token: 0x0600093E RID: 2366 RVA: 0x00096C38 File Offset: 0x00094E38
	public mImage loadImage(string fileName)
	{
		for (int i = 0; i < this.nFile; i++)
		{
			if (this.fname[i].CompareTo(fileName) == 0)
			{
				return mImage.createImage(this.fullData, this.fpos[i], this.flen[i], fileName);
			}
		}
		return null;
	}

	// Token: 0x0600093F RID: 2367 RVA: 0x00096C90 File Offset: 0x00094E90
	public sbyte[] loadData(string name)
	{
		for (int i = 0; i < this.nFile; i++)
		{
			if (this.fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[this.flen[i]];
				Array.Copy(this.fullData, this.fpos[i], array, 0, this.flen[i]);
				return array;
			}
		}
		return null;
	}

	// Token: 0x06000940 RID: 2368 RVA: 0x00096CF8 File Offset: 0x00094EF8
	public sbyte[] getBinaryFile(string name)
	{
		for (int i = 0; i < this.nFile; i++)
		{
			if (this.fname[i].CompareTo(name) == 0)
			{
				sbyte[] array = new sbyte[this.flen[i]];
				Array.Copy(this.fullData, this.fpos[i], array, 0, this.flen[i]);
				return array;
			}
		}
		mSystem.outloi("File '" + name + "' not found!");
		return null;
	}

	// Token: 0x04000E16 RID: 3606
	public const string wps = "/wps/";

	// Token: 0x04000E17 RID: 3607
	public const string weapon = "/weapon/";

	// Token: 0x04000E18 RID: 3608
	public static FilePack instance;

	// Token: 0x04000E19 RID: 3609
	public string[] fname;

	// Token: 0x04000E1A RID: 3610
	private int[] fpos;

	// Token: 0x04000E1B RID: 3611
	private int[] flen;

	// Token: 0x04000E1C RID: 3612
	private sbyte[] fullData;

	// Token: 0x04000E1D RID: 3613
	private int nFile;

	// Token: 0x04000E1E RID: 3614
	private string name;

	// Token: 0x04000E1F RID: 3615
	private sbyte[] code = new sbyte[]
	{
		78,
		103,
		117,
		121,
		101,
		110,
		86,
		97,
		110,
		77,
		105,
		110,
		104
	};

	// Token: 0x04000E20 RID: 3616
	private int codeLen;

	// Token: 0x04000E21 RID: 3617
	public static string[] charAvatar = new string[]
	{
		"leg",
		"body",
		"head",
		"hat",
		"eye",
		"hair",
		"wing"
	};

	// Token: 0x04000E22 RID: 3618
	private DataInputStream file;
}
