using System;

// Token: 0x02000041 RID: 65
public class CharPartInfo
{
	// Token: 0x060002E5 RID: 741 RVA: 0x00026F38 File Offset: 0x00025138
	public CharPartInfo(sbyte type, short id)
	{
		this.type = type;
		this.id = id;
		this.dx = mSystem.new_M_Int(4, 6);
		this.dy = mSystem.new_M_Int(4, 6);
		int value = 0;
		switch (type)
		{
		case 0:
		case 1:
			value = 5;
			break;
		case 2:
		case 3:
		case 4:
		case 5:
			value = 1;
			break;
		case 6:
			value = 2;
			break;
		}
		this.x = mSystem.new_M_Int(4, value);
		this.y = mSystem.new_M_Int(4, value);
		this.w = mSystem.new_M_Int(4, value);
		this.h = mSystem.new_M_Int(4, value);
		this.loadNew(type, id);
	}

	// Token: 0x060002E7 RID: 743 RVA: 0x00027078 File Offset: 0x00025278
	public void load(sbyte[] arr, int type, int Id)
	{
		FilePack.initByArray(arr);
		this.image = FilePack.getImg(Id + string.Empty);
		DataInputStream dataInputStream = new DataInputStream(FilePack.instance.loadData(Id + ".d"));
		FilePack.reset();
		this.avx0 = CRes.readSignByte(dataInputStream);
		this.avy0 = CRes.readSignByte(dataInputStream);
		this.avw0 = CRes.readSignByte(dataInputStream);
		this.avh0 = CRes.readSignByte(dataInputStream);
		this.avxf = CRes.readSignByte(dataInputStream);
		this.avyf = CRes.readSignByte(dataInputStream);
		try
		{
			for (int i = 0; i < 4; i++)
			{
				for (int j = 0; j < this.x[i].Length; j++)
				{
					this.x[i][j] = dataInputStream.read();
					this.y[i][j] = dataInputStream.read();
					this.w[i][j] = dataInputStream.read();
					this.h[i][j] = dataInputStream.read();
				}
				for (int k = 0; k < 6; k++)
				{
					this.dx[i][k] = CRes.readSignByte(dataInputStream);
					this.dy[i][k] = CRes.readSignByte(dataInputStream);
				}
			}
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
			mSystem.outloi("loi CharPart 1");
		}
	}

	// Token: 0x060002E8 RID: 744 RVA: 0x000271FC File Offset: 0x000253FC
	public void loadNew(sbyte type, short id)
	{
		if (mSystem.isImgLocal && this.timeRe == 0L)
		{
			this.timeRe = GameCanvas.timeNow;
			mImage mImage = null;
			try
			{
				mImage = mImage.createImage(string.Concat(new object[]
				{
					"/c/",
					FilePack.charAvatar[(int)type],
					"/b",
					id,
					"_",
					FilePack.charAvatar[(int)type],
					".png"
				}));
			}
			catch (Exception ex)
			{
				mImage = null;
			}
			if (mImage != null && mImage.image != null)
			{
				DataInputStream dataInputStream = null;
				try
				{
					dataInputStream = mImage.openFile(string.Concat(new object[]
					{
						"/c/",
						FilePack.charAvatar[(int)type],
						"/b",
						id,
						"_",
						FilePack.charAvatar[(int)type],
						"_data"
					}));
				}
				catch (Exception ex2)
				{
				}
				if (dataInputStream != null)
				{
					this.image = mImage;
					FilePack.reset();
					try
					{
						for (int i = 0; i < 3; i++)
						{
							for (int j = 0; j < this.x[i].Length; j++)
							{
								this.x[i][j] = dataInputStream.read();
								this.y[i][j] = dataInputStream.read();
								this.w[i][j] = dataInputStream.read();
								this.h[i][j] = dataInputStream.read();
							}
						}
						for (int k = 0; k < 4; k++)
						{
							for (int l = 0; l < 6; l++)
							{
								this.dx[k][l] = CRes.readSignByte(dataInputStream);
								this.dy[k][l] = CRes.readSignByte(dataInputStream);
							}
						}
					}
					catch (Exception ex3)
					{
					}
					return;
				}
			}
		}
		MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)CharPartInfo.hashImagePartChar.get(type + "_" + id);
		if (mainImageDataPartChar == null)
		{
			this.timeRemove = GameCanvas.timeNow;
			mainImageDataPartChar = new MainImageDataPartChar();
			CharPartInfo.hashImagePartChar.put(type + "_" + id, mainImageDataPartChar);
			this.getFromRms(type, id);
		}
		else if (mainImageDataPartChar.img != null)
		{
			this.image = mainImageDataPartChar.img;
			DataInputStream dataInputStream2 = new DataInputStream(mainImageDataPartChar.isData);
			FilePack.reset();
			try
			{
				for (int m = 0; m < 3; m++)
				{
					for (int n = 0; n < this.x[m].Length; n++)
					{
						this.x[m][n] = dataInputStream2.read();
						this.y[m][n] = dataInputStream2.read();
						this.w[m][n] = dataInputStream2.read();
						this.h[m][n] = dataInputStream2.read();
					}
				}
				for (int num = 0; num < 4; num++)
				{
					for (int num2 = 0; num2 < 6; num2++)
					{
						this.dx[num][num2] = CRes.readSignByte(dataInputStream2);
						this.dy[num][num2] = CRes.readSignByte(dataInputStream2);
					}
				}
			}
			catch (Exception ex4)
			{
				mSystem.outloi("loi CharPart 3");
			}
			CharPartInfo.hashImagePartChar.remove(mainImageDataPartChar);
		}
		else if ((GameCanvas.timeNow - this.timeRemove) / 1000L >= 15L)
		{
			this.getFromRms(type, id);
		}
	}

	// Token: 0x060002E9 RID: 745 RVA: 0x00027600 File Offset: 0x00025800
	public void paint(mGraphics g, int xp, int yp, int dir, int frame)
	{
		try
		{
			if ((int)this.type >= 0)
			{
				int num = dir;
				if (num > 2)
				{
					num = 2;
				}
				if (this.image != null && this.image.image != null)
				{
					int num2 = this.dx[dir][frame];
					int num3 = this.dy[dir][frame];
					if (dir > 2)
					{
						num2 = -this.dx[num][frame] - this.w[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]];
						num3 = this.dy[num][frame];
					}
					g.drawRegion(this.image, this.x[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.y[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.w[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.h[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], (dir <= 2) ? 0 : 2, xp + num2, yp + num3, 0, mGraphics.isTrue);
					this.timeRemove = GameCanvas.timeNow;
				}
				else
				{
					this.loadNew(this.type, this.id);
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.println("loi paint CharPartInfo: " + this.id);
		}
	}

	// Token: 0x060002EA RID: 746 RVA: 0x00027790 File Offset: 0x00025990
	public void paintShow(mGraphics g, int xp, int yp, int dir, int frame)
	{
		if ((int)this.type < 0)
		{
			return;
		}
		int num = dir;
		if (num > 2)
		{
			num = 2;
		}
		if (this.image != null && this.image.image != null)
		{
			g.drawRegion(this.image, this.x[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.y[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.w[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], this.h[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]], (dir <= 2) ? 0 : 2, xp + this.dx[dir][frame], yp - this.h[num][(int)CharPartInfo.PART_OF_FRAME[(int)this.type][frame]] / 2, 0, mGraphics.isTrue);
			this.timeRemove = GameCanvas.timeNow;
		}
		else
		{
			this.loadNew(this.type, this.id);
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, xp, yp, 3, mGraphics.isTrue);
		}
	}

	// Token: 0x060002EB RID: 747 RVA: 0x000278D0 File Offset: 0x00025AD0
	public void paintAvatar(mGraphics g, short xp, short yp, int frame)
	{
		if (this.image != null && this.image.image != null)
		{
			g.drawRegion(this.image, this.avx0, this.avy0, this.avw0, this.avh0, 0, (int)xp + this.avxf, (int)yp + this.avyf, 0, mGraphics.isTrue);
		}
	}

	// Token: 0x060002EC RID: 748 RVA: 0x00027934 File Offset: 0x00025B34
	public void getFromRms(sbyte type, short id)
	{
		if ((int)TemMidlet.DIVICE == 0)
		{
			this.timeRemove = GameCanvas.timeNow;
			GlobalService.gI().load_image_data_part_char(type, id);
			return;
		}
		string text = string.Concat(new object[]
		{
			"img_data_char_",
			type,
			"_",
			id
		});
		sbyte[] array = CRes.loadRMS(text);
		if (array == null)
		{
			this.timeRemove = GameCanvas.timeNow;
			GlobalService.gI().load_image_data_part_char(type, id);
		}
		else
		{
			sbyte[] data;
			sbyte[] array2;
			try
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				dataInputStream.readShort();
				int num = dataInputStream.readInt();
				data = new sbyte[num];
				dataInputStream.read(ref data);
				short num2 = dataInputStream.readShort();
				array2 = new sbyte[(int)num2];
				dataInputStream.read(ref array2);
			}
			catch (Exception ex)
			{
				return;
			}
			mImage img = mImage.createImage(data, 0, 0, text);
			MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)CharPartInfo.hashImagePartChar.get(type + "_" + id);
			if (mainImageDataPartChar == null)
			{
				mainImageDataPartChar = new MainImageDataPartChar(img, array2);
				CharPartInfo.hashImagePartChar.put(type + "_" + id, mainImageDataPartChar);
			}
			else
			{
				mainImageDataPartChar.img = img;
				mainImageDataPartChar.isData = array2;
			}
		}
	}

	// Token: 0x040003BA RID: 954
	public static mHashTable hashImagePartChar = new mHashTable();

	// Token: 0x040003BB RID: 955
	public sbyte type;

	// Token: 0x040003BC RID: 956
	public short id;

	// Token: 0x040003BD RID: 957
	public long timeRemove;

	// Token: 0x040003BE RID: 958
	public long timeRe;

	// Token: 0x040003BF RID: 959
	public int[][] x;

	// Token: 0x040003C0 RID: 960
	public int[][] y;

	// Token: 0x040003C1 RID: 961
	public int[][] w;

	// Token: 0x040003C2 RID: 962
	public int[][] h;

	// Token: 0x040003C3 RID: 963
	public int[][] dx;

	// Token: 0x040003C4 RID: 964
	public int[][] dy;

	// Token: 0x040003C5 RID: 965
	public sbyte[] arrData;

	// Token: 0x040003C6 RID: 966
	public mImage image;

	// Token: 0x040003C7 RID: 967
	private int avxf;

	// Token: 0x040003C8 RID: 968
	private int avyf;

	// Token: 0x040003C9 RID: 969
	private int avx0;

	// Token: 0x040003CA RID: 970
	private int avy0;

	// Token: 0x040003CB RID: 971
	private int avw0;

	// Token: 0x040003CC RID: 972
	private int avh0;

	// Token: 0x040003CD RID: 973
	public static sbyte[][] PART_OF_FRAME = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[]
		{
			0,
			0,
			1,
			2,
			3,
			4
		},
		new sbyte[6],
		new sbyte[6],
		new sbyte[6],
		new sbyte[6],
		new sbyte[]
		{
			0,
			1,
			0,
			1,
			0,
			1
		}
	};
}
