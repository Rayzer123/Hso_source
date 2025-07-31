using System;
using System.Collections;

// Token: 0x02000043 RID: 67
public class DataSkillEff
{
	// Token: 0x060002F8 RID: 760 RVA: 0x000286A4 File Offset: 0x000268A4
	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy)
	{
		this.idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		this.loadData(array);
	}

	// Token: 0x060002F9 RID: 761 RVA: 0x00028724 File Offset: 0x00026924
	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy, sbyte typemove)
	{
		this.idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		this.Typemove = typemove;
		this.loadData(array);
	}

	// Token: 0x060002FA RID: 762 RVA: 0x000287AC File Offset: 0x000269AC
	public DataSkillEff(short ideff, int x, int y, sbyte[] arr)
	{
		this.idEff = ideff;
		this.x = (short)x;
		this.y = (short)y;
		this.loadData(arr);
		this.isremovebyFrame = true;
	}

	// Token: 0x060002FB RID: 763 RVA: 0x00028834 File Offset: 0x00026A34
	public DataSkillEff(int id)
	{
		this.idEff = (short)id;
	}

	// Token: 0x060002FC RID: 764 RVA: 0x000288A0 File Offset: 0x00026AA0
	public DataSkillEff(sbyte[] array, short ideff, int dxx, int dyy, long time, sbyte typemove)
	{
		this.idEff = ideff;
		this.dxx = dxx;
		this.dyy = dyy;
		this.Typemove = typemove;
		this.timelive = time;
		this.isremovebyTime = true;
		this.loadData(array);
	}

	// Token: 0x060002FD RID: 765 RVA: 0x00028938 File Offset: 0x00026B38
	public DataSkillEff(int type, int dx, int dy)
	{
		this.indexSkill = (short)type;
		this.dxx = dx;
		this.dyy = dy;
		this.load(type);
	}

	// Token: 0x060002FE RID: 766 RVA: 0x000289B8 File Offset: 0x00026BB8
	public DataSkillEff(int type, int x, int y, int lvpaint)
	{
		this.indexSkill = (short)type;
		this.x = (short)x;
		this.y = (short)y;
		this.leavelPaint = (sbyte)lvpaint;
		this.load(type);
	}

	// Token: 0x06000300 RID: 768 RVA: 0x00028A78 File Offset: 0x00026C78
	public void load(int idEff)
	{
		try
		{
			this.idEff = (short)idEff;
			EffectData effectData = (EffectData)DataSkillEff.hasDataSkilleff.get(string.Empty + idEff);
			if (effectData == null)
			{
				DataInputStream dataInputStream = mImage.openFile("/dataeff/" + idEff);
				short num = (short)dataInputStream.available();
				sbyte[] array = new sbyte[(int)num];
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = dataInputStream.readByte();
				}
				EffectData effectData2 = new EffectData();
				effectData2.setdata(array);
				DataSkillEff.hasDataSkilleff.put(string.Empty + idEff, effectData2);
				this.loadData(array);
			}
			else
			{
				this.loadData(effectData.data);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000301 RID: 769 RVA: 0x00028B68 File Offset: 0x00026D68
	public bool isHavedata()
	{
		if (this.isLoadData)
		{
			return true;
		}
		this.loadData(null);
		return false;
	}

	// Token: 0x06000302 RID: 770 RVA: 0x00028B80 File Offset: 0x00026D80
	public void loadData(sbyte[] array)
	{
		try
		{
			if (array == null || array.Length == 0)
			{
				EffectData effectData = (EffectData)DataSkillEff.ALL_DATA_EFFECT.get(string.Empty + ((int)this.idEff + GameData.ID_START_SKILL));
				if (effectData != null && effectData.data != null)
				{
					array = effectData.data;
					effectData.timeRemove = GameCanvas.timeNow;
				}
				if (effectData == null)
				{
					effectData = new EffectData((short)((int)this.idEff + GameData.ID_START_SKILL));
					DataSkillEff.ALL_DATA_EFFECT.put(string.Empty + ((int)this.idEff + GameData.ID_START_SKILL), effectData);
					GameData.RequestImgandData((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					effectData.timeRemove = (long)((int)(mSystem.currentTimeMillis() / 1000L));
				}
			}
			if (array != null && array.Length > 0)
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
					mVector mVector2 = new mVector();
					for (int k = 0; k < (int)b; k++)
					{
						PartFrame partFrame = new PartFrame(dataInputStream.readShort(), dataInputStream.readShort(), dataInputStream.readByte());
						partFrame.flip = dataInputStream.readByte();
						partFrame.onTop = dataInputStream.readByte();
						if ((int)partFrame.onTop == 0)
						{
							mVector.addElement(partFrame);
						}
						else
						{
							mVector2.addElement(partFrame);
						}
					}
					this.listFrame.addElement(new FrameEff(mVector, mVector2));
				}
				short num3 = (short)dataInputStream.readUnsignedByte();
				this.sequence = new sbyte[(int)num3];
				for (int l = 0; l < (int)num3; l++)
				{
					this.sequence[l] = (sbyte)dataInputStream.readShort();
				}
				this.indexStartSkill = dataInputStream.readByte();
				num3 = (short)dataInputStream.readByte();
				this.frameChar[0] = new sbyte[(int)num3];
				for (int m = 0; m < (int)num3; m++)
				{
					this.frameChar[0][m] = dataInputStream.readByte();
				}
				num3 = (short)dataInputStream.readByte();
				this.frameChar[1] = new sbyte[(int)num3];
				for (int n = 0; n < (int)num3; n++)
				{
					this.frameChar[1][n] = dataInputStream.readByte();
				}
				num3 = (short)dataInputStream.readByte();
				this.frameChar[3] = new sbyte[(int)num3];
				for (int num4 = 0; num4 < (int)num3; num4++)
				{
					this.frameChar[3][num4] = dataInputStream.readByte();
				}
				this.isLoadData = true;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000303 RID: 771 RVA: 0x00028EAC File Offset: 0x000270AC
	public void paintTopWeaPon(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000304 RID: 772 RVA: 0x00029080 File Offset: 0x00027280
	public void paintTopPP(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000305 RID: 773 RVA: 0x00029254 File Offset: 0x00027454
	public void paintTop(mGraphics g, int x, int y)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if ((int)this.Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector mVector = frameEff.listPartTop;
				mVector = frameEff.listPartBottom;
				for (int i = 0; i < mVector.size(); i++)
				{
					PartFrame partFrame = (PartFrame)mVector.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num3 > imageWidth)
						{
							num3 = 0;
						}
						if (num4 > imageHeight)
						{
							num4 = 0;
						}
						if (num3 + num > imageWidth)
						{
							num = imageWidth - num3;
						}
						if (num4 + num2 > imageHeight)
						{
							num2 = imageHeight - num4;
						}
						g.drawRegion(imgIcon.img, num3, num4, num, num2, ((int)partFrame.flip != 1) ? 0 : 2, x + dx + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000306 RID: 774 RVA: 0x00029408 File Offset: 0x00027608
	public void paintBottomPP(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000307 RID: 775 RVA: 0x000295DC File Offset: 0x000277DC
	public void paintTopHorse(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000308 RID: 776 RVA: 0x000297B0 File Offset: 0x000279B0
	public void paintBottomHorse(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000309 RID: 777 RVA: 0x00029984 File Offset: 0x00027B84
	public void paintBottomWeaPon(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030A RID: 778 RVA: 0x00029B58 File Offset: 0x00027D58
	public void paintBottom(mGraphics g, int x, int y)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if ((int)this.Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt((int)this.Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int dx = (int)partFrame.dx;
						int num = (int)smallImage.w;
						int num2 = (int)smallImage.h;
						int num3 = (int)smallImage.x;
						int num4 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num3 > imageWidth)
						{
							num3 = 0;
						}
						if (num4 > imageHeight)
						{
							num4 = 0;
						}
						if (num3 + num > imageWidth)
						{
							num = imageWidth - num3;
						}
						if (num4 + num2 > imageHeight)
						{
							num2 = imageHeight - num4;
						}
						g.drawRegion(imgIcon.img, num3, num4, num, num2, ((int)partFrame.flip != 1) ? 0 : 2, x + dx + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030B RID: 779 RVA: 0x00029D08 File Offset: 0x00027F08
	public void paintTop(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030C RID: 780 RVA: 0x00029EDC File Offset: 0x000280DC
	public void paintBottom(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030D RID: 781 RVA: 0x0002A0B0 File Offset: 0x000282B0
	public void paintTopAll(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030E RID: 782 RVA: 0x0002A284 File Offset: 0x00028484
	public void paintBottomAll(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600030F RID: 783 RVA: 0x0002A458 File Offset: 0x00028658
	public bool lockmoveByeffAuto()
	{
		return (int)this.Typemove == 1;
	}

	// Token: 0x06000310 RID: 784 RVA: 0x0002A464 File Offset: 0x00028664
	public bool CanpaintByeffauto()
	{
		return (int)this.Typemove == 2;
	}

	// Token: 0x06000311 RID: 785 RVA: 0x0002A470 File Offset: 0x00028670
	public bool isTanghinhbyEffauto()
	{
		return (int)this.Typemove == 17;
	}

	// Token: 0x06000312 RID: 786 RVA: 0x0002A480 File Offset: 0x00028680
	public void update()
	{
		try
		{
			if (this.isHavedata())
			{
				if (this.isremovebyTime && this.timelive - mSystem.currentTimeMillis() < 0L)
				{
					this.wantDetroy = true;
				}
				this.f += 1;
				if ((int)this.f >= this.sequence.Length)
				{
					if (this.isremovebyFrame)
					{
						this.wantDetroy = true;
					}
					if (this.isremovebyTime)
					{
						this.f = 0;
					}
					if (!this.isremovebyTime && mSystem.currentTimeMillis() - this.lasttime > (long)((int)this.loop * 1000))
					{
						this.f = 0;
						this.lasttime = mSystem.currentTimeMillis();
						this.loop = (sbyte)CRes.random(1, 8);
					}
				}
				if ((int)this.f > 0 && (int)this.f < this.sequence.Length)
				{
					this.Frame = this.sequence[(int)this.f];
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.println("loi update me day");
		}
	}

	// Token: 0x06000313 RID: 787 RVA: 0x0002A5BC File Offset: 0x000287BC
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = DataSkillEff.ALL_DATA_EFFECT.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				EffectData effectData = (EffectData)DataSkillEff.ALL_DATA_EFFECT.get(k);
				if ((GameCanvas.timeNow - effectData.timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					DataSkillEff.ALL_DATA_EFFECT.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000314 RID: 788 RVA: 0x0002A664 File Offset: 0x00028864
	public void paintTopHair(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000315 RID: 789 RVA: 0x0002A838 File Offset: 0x00028A38
	public void paintBottomHair(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000316 RID: 790 RVA: 0x0002AA0C File Offset: 0x00028C0C
	public void paintTopWing(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000317 RID: 791 RVA: 0x0002ABE0 File Offset: 0x00028DE0
	public void paintBottomName(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000318 RID: 792 RVA: 0x0002ADB4 File Offset: 0x00028FB4
	public void paintTopName(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartTop = frameEff.listPartTop;
				for (int i = 0; i < listPartTop.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartTop.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x06000319 RID: 793 RVA: 0x0002AF88 File Offset: 0x00029188
	public void paintBottomWing(mGraphics g, int x, int y, int Frame, int rotale)
	{
		if (!this.isHavedata())
		{
			return;
		}
		if (Frame < this.listFrame.size())
		{
			FrameEff frameEff = (FrameEff)this.listFrame.elementAt(Frame);
			try
			{
				mVector listPartBottom = frameEff.listPartBottom;
				for (int i = 0; i < listPartBottom.size(); i++)
				{
					PartFrame partFrame = (PartFrame)listPartBottom.elementAt(i);
					SmallImage smallImage = this.smallImage[(int)partFrame.idSmallImg];
					ImageIcon imgIcon = GameData.getImgIcon((short)((int)this.idEff + GameData.ID_START_SKILL), this.typRequestImg);
					if (imgIcon != null && imgIcon.img != null)
					{
						int num = (int)partFrame.dx;
						int num2 = (int)smallImage.w;
						int num3 = (int)smallImage.h;
						int num4 = (int)smallImage.x;
						int num5 = (int)smallImage.y;
						int imageWidth = mImage.getImageWidth(imgIcon.img.image);
						int imageHeight = mImage.getImageHeight(imgIcon.img.image);
						if (num4 > imageWidth)
						{
							num4 = 0;
						}
						if (num5 > imageHeight)
						{
							num5 = 0;
						}
						if (num4 + num2 > imageWidth)
						{
							num2 = imageWidth - num4;
						}
						if (num5 + num3 > imageHeight)
						{
							num3 = imageHeight - num5;
						}
						int num6 = ((int)partFrame.flip != 1) ? 0 : 2;
						if (rotale == 2 || rotale == 6)
						{
							if (num6 == 2)
							{
								num6 = 0;
							}
							else
							{
								num6 = 2;
							}
							num = -(num + num2);
						}
						g.drawRegion(imgIcon.img, num4, num5, num2, num3, num6, x + num + this.dxx, y + (int)partFrame.dy + this.dyy, 0, false);
					}
				}
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x040003DA RID: 986
	public bool isMatna;

	// Token: 0x040003DB RID: 987
	public bool isLoadData;

	// Token: 0x040003DC RID: 988
	public mVector listFrame = new mVector();

	// Token: 0x040003DD RID: 989
	public mVector listAnima = new mVector();

	// Token: 0x040003DE RID: 990
	public SmallImage[] smallImage;

	// Token: 0x040003DF RID: 991
	public sbyte[][] frameChar = new sbyte[][]
	{
		new sbyte[1],
		new sbyte[1],
		new sbyte[1],
		new sbyte[1]
	};

	// Token: 0x040003E0 RID: 992
	public sbyte[] sequence;

	// Token: 0x040003E1 RID: 993
	public sbyte Frame;

	// Token: 0x040003E2 RID: 994
	public sbyte f;

	// Token: 0x040003E3 RID: 995
	public bool IsStop;

	// Token: 0x040003E4 RID: 996
	public long timeRemove;

	// Token: 0x040003E5 RID: 997
	public static sbyte TYPE_EFFECT_END = 0;

	// Token: 0x040003E6 RID: 998
	public static sbyte TYPE_EFFECT_STARTSKILL = 1;

	// Token: 0x040003E7 RID: 999
	public static sbyte TYPE_EFFECT_BUFF = 2;

	// Token: 0x040003E8 RID: 1000
	public bool wantDetroy;

	// Token: 0x040003E9 RID: 1001
	public static mHashTable hasDataSkilleff = new mHashTable();

	// Token: 0x040003EA RID: 1002
	public sbyte leavelPaint;

	// Token: 0x040003EB RID: 1003
	public short x;

	// Token: 0x040003EC RID: 1004
	public short y;

	// Token: 0x040003ED RID: 1005
	private short indexSkill;

	// Token: 0x040003EE RID: 1006
	public sbyte indexStartSkill;

	// Token: 0x040003EF RID: 1007
	public short idEff;

	// Token: 0x040003F0 RID: 1008
	private int dxx;

	// Token: 0x040003F1 RID: 1009
	private int dyy;

	// Token: 0x040003F2 RID: 1010
	public int typRequestImg = 112;

	// Token: 0x040003F3 RID: 1011
	public sbyte Typemove;

	// Token: 0x040003F4 RID: 1012
	public bool isremovebyTime;

	// Token: 0x040003F5 RID: 1013
	public static mHashTable ALL_DATA_EFFECT = new mHashTable();

	// Token: 0x040003F6 RID: 1014
	private sbyte loop;

	// Token: 0x040003F7 RID: 1015
	private long lasttime;

	// Token: 0x040003F8 RID: 1016
	public long timelive;

	// Token: 0x040003F9 RID: 1017
	public bool isremovebyFrame;
}
