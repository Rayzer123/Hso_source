using System;

// Token: 0x020000BE RID: 190
public class MainImageDataPartChar
{
	// Token: 0x0600095D RID: 2397 RVA: 0x000979D4 File Offset: 0x00095BD4
	public MainImageDataPartChar()
	{
	}

	// Token: 0x0600095E RID: 2398 RVA: 0x000979E4 File Offset: 0x00095BE4
	public MainImageDataPartChar(sbyte[] issImg, sbyte[] iss, sbyte type, short id, short version)
	{
		this.isDataImg = issImg;
		this.count = 0;
		this.isData = iss;
		this.type = type;
		this.id = id;
		this.version = version;
	}

	// Token: 0x0600095F RID: 2399 RVA: 0x00097A20 File Offset: 0x00095C20
	public MainImageDataPartChar(mImage img, sbyte[] iss)
	{
		this.img = img;
		this.count = 0;
		this.isData = iss;
	}

	// Token: 0x06000960 RID: 2400 RVA: 0x00097A50 File Offset: 0x00095C50
	public DataOutputStream getSaveData()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeShort(this.version);
			dataOutputStream.writeInt(this.isDataImg.Length);
			dataOutputStream.write(this.isDataImg);
			dataOutputStream.writeShort(this.isData.Length);
			dataOutputStream.write(this.isData);
		}
		catch (Exception ex)
		{
		}
		return dataOutputStream;
	}

	// Token: 0x04000E50 RID: 3664
	public mImage img;

	// Token: 0x04000E51 RID: 3665
	public int count = -1;

	// Token: 0x04000E52 RID: 3666
	public sbyte type;

	// Token: 0x04000E53 RID: 3667
	public short id;

	// Token: 0x04000E54 RID: 3668
	public short version;

	// Token: 0x04000E55 RID: 3669
	public long timeImageNull;

	// Token: 0x04000E56 RID: 3670
	public sbyte[] isData;

	// Token: 0x04000E57 RID: 3671
	public sbyte[] isDataImg;
}
