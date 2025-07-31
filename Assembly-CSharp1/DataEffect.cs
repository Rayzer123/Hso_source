using System;

// Token: 0x02000042 RID: 66
public class DataEffect
{
	// Token: 0x060002ED RID: 749 RVA: 0x00027AA8 File Offset: 0x00025CA8
	public DataEffect(sbyte[] array, int idimg, bool isMonster)
	{
		this.idimg = (short)idimg;
		this.setDataType1(array);
	}

	// Token: 0x060002EE RID: 750 RVA: 0x00027AEC File Offset: 0x00025CEC
	public DataEffect(sbyte[] array)
	{
		try
		{
			DataInputStream dataInputStream = new DataInputStream(array);
			int num = (int)dataInputStream.readByte();
			this.smallImage = new SmallImage[num];
			for (int i = 0; i < num; i++)
			{
				this.smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num2 = (int)dataInputStream.readShort();
			for (int j = 0; j < num2; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector = new mVector();
				for (int k = 0; k < (int)b; k++)
				{
					PartFrame o = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					mVector.addElement(o);
				}
				this.listFrame.addElement(new FrameEff(mVector));
			}
			short num3 = dataInputStream.readShort();
			this.sequence = new sbyte[(int)num3];
			for (int l = 0; l < (int)num3; l++)
			{
				this.sequence[l] = (sbyte)dataInputStream.readShort();
			}
			sbyte b2 = dataInputStream.readByte();
			sbyte b3 = dataInputStream.readByte();
			num3 = (short)dataInputStream.readByte();
			sbyte[] array2 = new sbyte[(int)num3];
			for (int m = 0; m < (int)num3; m++)
			{
				array2[m] = dataInputStream.readByte();
			}
			Animation o2 = new Animation(array2);
			this.listAnima.addElement(o2);
			num3 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num3];
			for (int n = 0; n < (int)num3; n++)
			{
				array2[n] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			this.listAnima.addElement(o2);
			num3 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num3];
			for (int num4 = 0; num4 < (int)num3; num4++)
			{
				array2[num4] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			this.listAnima.addElement(o2);
			num3 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num3];
			for (int num5 = 0; num5 < (int)num3; num5++)
			{
				array2[num5] = dataInputStream.readByte();
			}
			o2 = new Animation(array2);
			this.listAnima.addElement(o2);
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	// Token: 0x060002F0 RID: 752 RVA: 0x00027DF0 File Offset: 0x00025FF0
	public void setDataType1(sbyte[] array)
	{
		DataInputStream dataInputStream = null;
		this.listFrame.removeAllElements();
		this.listAnima.removeAllElements();
		try
		{
			dataInputStream = new DataInputStream(array);
			int num = (int)dataInputStream.readByte();
			this.smallImage = new SmallImage[num];
			for (int i = 0; i < num; i++)
			{
				this.smallImage[i] = new SmallImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
			}
			int num2 = 0;
			int num3 = -1000000;
			int num4 = (int)dataInputStream.readShort();
			for (int j = 0; j < num4; j++)
			{
				sbyte b = dataInputStream.readByte();
				mVector mVector = new mVector();
				for (int k = 0; k < (int)b; k++)
				{
					PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
					partFrame.flip = dataInputStream.readByte();
					partFrame.onTop = dataInputStream.readByte();
					mVector.addElement(partFrame);
					if (j == 0)
					{
						if (num3 < (int)(partFrame.dy + this.smallImage[(int)partFrame.idSmallImg].h))
						{
							num3 = (int)(partFrame.dy + this.smallImage[(int)partFrame.idSmallImg].h);
						}
						if (num2 < CRes.abs((int)partFrame.dy))
						{
							num2 = CRes.abs((int)partFrame.dy);
						}
					}
				}
				if (j == 0 && num3 <= -5)
				{
					this.isFly = (sbyte)num3;
				}
				this.listFrame.addElement(new FrameEff(mVector, null));
			}
			this.FrameWith = this.smallImage[0].w;
			this.FrameHeight = (short)num2;
			short num5 = dataInputStream.readShort();
			this.sequence = new sbyte[(int)num5];
			for (int l = 0; l < (int)num5; l++)
			{
				this.sequence[l] = (sbyte)dataInputStream.readShort();
			}
			num5 = (short)dataInputStream.readByte();
			sbyte[] array2 = new sbyte[(int)num5];
			for (int m = 0; m < (int)num5; m++)
			{
				array2[m] = dataInputStream.readByte();
			}
			Animation o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int n = 0; n < (int)num5; n++)
			{
				array2[n] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num6 = 0; num6 < (int)num5; num6++)
			{
				array2[num6] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num7 = 0; num7 < (int)num5; num7++)
			{
				array2[num7] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num8 = 0; num8 < (int)num5; num8++)
			{
				array2[num8] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num9 = 0; num9 < (int)num5; num9++)
			{
				array2[num9] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num10 = 0; num10 < (int)num5; num10++)
			{
				array2[num10] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			num5 = (short)dataInputStream.readByte();
			array2 = new sbyte[(int)num5];
			for (int num11 = 0; num11 < (int)num5; num11++)
			{
				array2[num11] = dataInputStream.readByte();
			}
			o = new Animation(array2);
			this.listAnima.addElement(o);
			if (dataInputStream.available() > 0)
			{
				this.idShadow = dataInputStream.readByte();
				for (int num12 = 0; num12 < num4; num12++)
				{
					FrameEff frameEff = (FrameEff)this.listFrame.elementAt(num12);
					frameEff.xShadow = dataInputStream.readByte();
					frameEff.yShadow = (int)dataInputStream.readByte();
				}
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
		finally
		{
			try
			{
				dataInputStream.close();
			}
			catch (Exception ex2)
			{
			}
		}
	}

	// Token: 0x060002F1 RID: 753 RVA: 0x000282F4 File Offset: 0x000264F4
	public Animation getAnim(int action)
	{
		return (Animation)this.listAnima.elementAt((int)DataEffect.indexAction[action]);
	}

	// Token: 0x060002F2 RID: 754 RVA: 0x00028310 File Offset: 0x00026510
	public int getFrame(int f, int action, int way)
	{
		Animation animation = (Animation)this.listAnima.elementAt((int)DataEffect.indexAction2[way][action]);
		if (f < animation.frame.Length)
		{
			return (int)animation.frame[f];
		}
		return 0;
	}

	// Token: 0x060002F3 RID: 755 RVA: 0x00028354 File Offset: 0x00026554
	public int getFrame(int f, int action)
	{
		Animation animation = (Animation)this.listAnima.elementAt((int)DataEffect.indexAction[action]);
		if (f < animation.frame.Length)
		{
			return (int)animation.frame[f];
		}
		return 0;
	}

	// Token: 0x060002F4 RID: 756 RVA: 0x00028394 File Offset: 0x00026594
	public void paint(mGraphics g, int idFrame, int x, int y, int way, mImage img)
	{
		if (img == null)
		{
			return;
		}
		idFrame = 0;
		FrameEff frameEff = (FrameEff)this.listFrame.elementAt(idFrame);
		try
		{
			for (int i = 0; i < frameEff.listPart.size(); i++)
			{
				PartFrame partFrame = (PartFrame)frameEff.listPart.elementAt(i);
				SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
				int num = (int)partFrame.dx;
				if (way == 2)
				{
					num = -num - (int)smallImage.w;
				}
				g.drawRegion(img, (int)smallImage.x, (int)smallImage.y, (int)smallImage.w, (int)smallImage.h, way, x + num, y + (int)partFrame.dy, 0, mGraphics.isFalse);
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	// Token: 0x060002F5 RID: 757 RVA: 0x0002847C File Offset: 0x0002667C
	public void paintPet(mGraphics g, int idFrame, int x, int y, int way, mImage img)
	{
		if (img == null)
		{
			return;
		}
		FrameEff frameEff = (FrameEff)this.listFrame.elementAt(idFrame);
		if (frameEff != null)
		{
			if (frameEff.listPartTop == null)
			{
			}
		}
		try
		{
			if (frameEff != null)
			{
				for (int i = 0; i < frameEff.listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)frameEff.listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					int num = (int)partFrame.dx;
					int num2 = (int)smallImage.w;
					int num3 = (int)smallImage.h;
					int num4 = (int)smallImage.x;
					int num5 = (int)smallImage.y;
					if (num4 > mImage.getImageWidth(img.image))
					{
						num4 = 0;
					}
					if (num5 > mImage.getImageHeight(img.image))
					{
						num5 = 0;
					}
					if (num4 + num2 > mImage.getImageWidth(img.image))
					{
						num2 = mImage.getImageWidth(img.image) - num4;
					}
					if (num5 + num3 > mImage.getImageHeight(img.image))
					{
						num3 = mImage.getImageHeight(img.image) - num5;
					}
					if (way == 2)
					{
						num = -num - num2;
					}
					if ((int)partFrame.flip != 1)
					{
						g.drawRegion(img, num4, num5, num2, num3, way, x + num, y + (int)partFrame.dy, 0, false);
					}
					else
					{
						g.drawRegion(img, num4, num5, num2, num3, (way != 2) ? 2 : 0, x + num, y + (int)partFrame.dy, 0, false);
					}
				}
			}
		}
		catch (Exception ex)
		{
			ex.ToString();
		}
	}

	// Token: 0x060002F6 RID: 758 RVA: 0x00028644 File Offset: 0x00026844
	public mVector getDataPet()
	{
		mVector result = new mVector();
		mVector mVector = (mVector)Pet.PET_DATA.get(string.Empty + this.idimg);
		if (mVector != null)
		{
			result = mVector;
		}
		return result;
	}

	// Token: 0x060002F7 RID: 759 RVA: 0x00028688 File Offset: 0x00026888
	public Animation getAnim(int action, int way)
	{
		return (Animation)this.listAnima.elementAt((int)DataEffect.indexAction2[way][action]);
	}

	// Token: 0x040003CE RID: 974
	public mVector listFrame = new mVector();

	// Token: 0x040003CF RID: 975
	public mVector listAnima = new mVector();

	// Token: 0x040003D0 RID: 976
	public SmallImage[] smallImage;

	// Token: 0x040003D1 RID: 977
	public sbyte[] sequence;

	// Token: 0x040003D2 RID: 978
	public short idimg;

	// Token: 0x040003D3 RID: 979
	private short FrameWith;

	// Token: 0x040003D4 RID: 980
	private short FrameHeight;

	// Token: 0x040003D5 RID: 981
	public string name = string.Empty;

	// Token: 0x040003D6 RID: 982
	public sbyte isFly;

	// Token: 0x040003D7 RID: 983
	public sbyte idShadow;

	// Token: 0x040003D8 RID: 984
	public static sbyte[][] indexAction2 = new sbyte[][]
	{
		new sbyte[]
		{
			0,
			0,
			1,
			2,
			3,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1,
			1
		},
		new sbyte[]
		{
			4,
			4,
			5,
			6,
			7,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5
		}
	};

	// Token: 0x040003D9 RID: 985
	public static sbyte[] indexAction = new sbyte[]
	{
		0,
		0,
		1,
		2,
		3,
		1,
		1,
		1,
		1
	};
}
