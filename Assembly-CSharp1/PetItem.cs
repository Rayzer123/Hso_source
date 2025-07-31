using System;

// Token: 0x0200006F RID: 111
public class PetItem : Item
{
	// Token: 0x0600052D RID: 1325 RVA: 0x0004909C File Offset: 0x0004729C
	public PetItem()
	{
	}

	// Token: 0x0600052E RID: 1326 RVA: 0x000490A4 File Offset: 0x000472A4
	public PetItem(int ID, string itemName, int iconId, int itemNameColor, int classTypeEquipment, int catagory, MainInfoItem[] mainInfo, int type, short level, int petType, sbyte frameNumberImg, sbyte petImageId)
	{
		this.itemNameExcludeLv = itemName;
		this.itemName = itemName;
		this.imageId = iconId;
		this.Id = ID;
		this.tier = 0;
		if ((int)this.tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
		this.colorNameItem = itemNameColor;
		this.classcharItem = classTypeEquipment;
		this.ItemCatagory = catagory;
		this.mInfo = mainInfo;
		this.type_Only_Item = type;
		this.IdTem = -1;
		this.priceItem = 0L;
		this.LvItem = (int)level;
		this.canSell = 0;
		this.canTrade = 0;
		this.timeUse = 0;
		if (this.timeUse > 0)
		{
			this.timeDem = GameCanvas.timeNow;
		}
		else
		{
			this.timeDem = 0L;
		}
		this.priceType = 0;
		this.type = petType;
		if ((mVector)Pet.PET_DATA.get(string.Empty + petImageId) != null)
		{
			this.isPetTool = true;
		}
		this.nFrameImgPet = frameNumberImg;
		this.petImageId = petImageId;
		if ((this.mInfo != null && this.mInfo.Length > 0) || this.priceItem > 0L || this.timeDem > 0L)
		{
			if (this.mInfo != null && this.mInfo.Length > 0)
			{
				mainInfo = CRes.selectionSort(mainInfo);
			}
			base.setContentItem();
		}
		this.IndexSort = 10;
		if (this.mInfo != null && this.mInfo.Length > 0)
		{
			for (int i = 0; i < this.mInfo.Length; i++)
			{
				MainInfoItem mainInfoItem = this.mInfo[i];
				if (mainInfoItem.id <= 6 && mainInfoItem.value > 0)
				{
					this.petAttack = mainInfoItem;
				}
			}
		}
	}

	// Token: 0x0600052F RID: 1327 RVA: 0x00049288 File Offset: 0x00047488
	public void setTimeUser(int timeDefault, long currentTime)
	{
		this.timeDefaultItemFashion = timeDefault;
		this.currentTimeItemFashion = currentTime;
	}

	// Token: 0x06000530 RID: 1328 RVA: 0x00049298 File Offset: 0x00047498
	public void setInfoPetOld(int ID, string itemName, int iconId, int itemNameColor, int classTypeEquipment, int catagory, MainInfoItem[] mainInfo, int type, short level, int petType, sbyte frameNumberImg, sbyte petImageId)
	{
		this.itemNameExcludeLv = itemName;
		this.itemName = itemName;
		this.imageId = iconId;
		this.Id = ID;
		this.tier = 0;
		if ((int)this.tier > 0)
		{
			this.itemName = this.itemName + " +" + this.tier;
		}
		this.colorNameItem = itemNameColor;
		this.classcharItem = classTypeEquipment;
		this.ItemCatagory = catagory;
		this.mInfo = mainInfo;
		this.type_Only_Item = type;
		this.IdTem = -1;
		this.priceItem = 0L;
		this.LvItem = (int)level;
		this.canSell = 0;
		this.canTrade = 0;
		this.timeUse = 0;
		if (this.timeUse > 0)
		{
			this.timeDem = GameCanvas.timeNow;
		}
		else
		{
			this.timeDem = 0L;
		}
		this.priceType = 0;
		this.type = petType;
		this.nFrameImgPet = frameNumberImg;
		this.petImageId = petImageId;
		if ((this.mInfo != null && this.mInfo.Length > 0) || this.priceItem > 0L || this.timeDem > 0L)
		{
			if (this.mInfo != null && this.mInfo.Length > 0)
			{
				mainInfo = CRes.selectionSort(mainInfo);
			}
			base.setContentItem();
		}
		this.IndexSort = 10;
		if (this.mInfo != null && this.mInfo.Length > 0)
		{
			for (int i = 0; i < this.mInfo.Length; i++)
			{
				MainInfoItem mainInfoItem = this.mInfo[i];
				if (mainInfoItem.id <= 6 && mainInfoItem.value > 0)
				{
					this.petAttack = mainInfoItem;
				}
			}
		}
	}

	// Token: 0x06000531 RID: 1329 RVA: 0x0004944C File Offset: 0x0004764C
	public void setInfoPet(int age, short growPoint, short str, short agi, short hea, short spi, short maxgrow, short maxtiemnang, short experience)
	{
		this.age = age;
		this.growpoint = growPoint;
		this.maxgrow = maxgrow;
		this.strength = str;
		this.agility = agi;
		this.health = hea;
		this.spirit = spi;
		this.maxtiemnang = maxtiemnang;
		this.experience = experience;
		this.mvaluetiemnang = new short[4];
		this.mvaluetiemnang[0] = this.strength;
		this.mvaluetiemnang[1] = this.agility;
		this.mvaluetiemnang[2] = this.health;
		this.mvaluetiemnang[3] = this.spirit;
	}

	// Token: 0x06000532 RID: 1330 RVA: 0x000494E4 File Offset: 0x000476E4
	public new void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		base.paintItem(g, x, y, w, lech, numlech);
	}

	// Token: 0x06000533 RID: 1331 RVA: 0x000494F8 File Offset: 0x000476F8
	public void paintShowPet(mGraphics g, int x, int y, int w, int lech, int numlech, int animIdx)
	{
		MainImage imagePet = ObjectData.getImagePet((short)this.petImageId);
		if (this.isPetTool)
		{
			if (imagePet.img != null)
			{
				int num = 0;
				if (this.isFly())
				{
					num = 15;
				}
				g.drawImage(MainObject.shadow, x, y + 10, 3, mGraphics.isTrue);
				this.paintPetTool(g, imagePet, x, y + num);
				this.doChangeFrmaeBoss();
			}
		}
		else
		{
			if (this.type != 2)
			{
				g.drawImage(MainObject.shadow, x, y + 10, 3, mGraphics.isTrue);
				y -= 10;
			}
			if (imagePet.img != null)
			{
				int num2 = mImage.getImageHeight(imagePet.img.image) / (int)this.nFrameImgPet;
				int num3 = mImage.getImageWidth(imagePet.img.image) / 2;
				g.drawRegion(imagePet.img, num3 * (this.getframe(animIdx) / 3), num2 * (this.getframe(animIdx) % 3), num3, num2, 0, x, y + lech, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x06000534 RID: 1332 RVA: 0x00049600 File Offset: 0x00047800
	public void doChangeFrmaeBoss()
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.petImageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		if (mVector.size() > 0)
		{
			DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
			int action = 0;
			this.frame = (int)((byte)((this.frame + 1) % dataEffect.getAnim(action, 0).frame.Length));
		}
	}

	// Token: 0x06000535 RID: 1333 RVA: 0x0004967C File Offset: 0x0004787C
	public void paintPetTool(mGraphics g, MainImage img, int x, int y)
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.petImageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		if (mVector.size() == 0)
		{
			return;
		}
		try
		{
			DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
			if (dataEffect != null)
			{
				int action = 0;
				int num = 0;
				mVector mVector3 = (mVector)Pet.PET_DATA.get(string.Empty + this.petImageId);
				if (mVector3 != null && img != null && img.img != null)
				{
					dataEffect.paintPet(g, dataEffect.getFrame(this.frame, action, 0), x, y - num, 0, img.img);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000536 RID: 1334 RVA: 0x00049768 File Offset: 0x00047968
	public int getframe(int animIdx)
	{
		switch (this.type)
		{
		case 0:
			return (int)Pet.mOwl[animIdx][0][GameCanvas.gameTick % Pet.mOwl[animIdx][0].Length];
		case 1:
			return (int)Pet.mBat[animIdx][0][GameCanvas.gameTick % Pet.mBat[animIdx][0].Length];
		case 2:
			return (int)Pet.mWoftAnimFrame[animIdx][0][GameCanvas.gameTick % Pet.mWoftAnimFrame[animIdx][0].Length];
		case 3:
			return (int)Pet.mEagle[animIdx][0][GameCanvas.gameTick % Pet.mEagle[animIdx][0].Length];
		default:
			return (int)Pet.mElfAnimFrame[animIdx][0][GameCanvas.gameTick % Pet.mElfAnimFrame[animIdx][0].Length];
		}
	}

	// Token: 0x06000537 RID: 1335 RVA: 0x00049828 File Offset: 0x00047A28
	public bool isFly()
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.petImageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
		return dataEffect != null && (int)dataEffect.isFly <= -5;
	}

	// Token: 0x04000753 RID: 1875
	public sbyte petImageId;

	// Token: 0x04000754 RID: 1876
	public sbyte nFrameImgPet;

	// Token: 0x04000755 RID: 1877
	public int type;

	// Token: 0x04000756 RID: 1878
	public short experience;

	// Token: 0x04000757 RID: 1879
	public int age;

	// Token: 0x04000758 RID: 1880
	public new int frame;

	// Token: 0x04000759 RID: 1881
	public short growpoint;

	// Token: 0x0400075A RID: 1882
	public short maxgrow;

	// Token: 0x0400075B RID: 1883
	public short spirit;

	// Token: 0x0400075C RID: 1884
	public short health;

	// Token: 0x0400075D RID: 1885
	public short agility;

	// Token: 0x0400075E RID: 1886
	public short strength;

	// Token: 0x0400075F RID: 1887
	public short maxtiemnang;

	// Token: 0x04000760 RID: 1888
	public MainInfoItem petAttack;

	// Token: 0x04000761 RID: 1889
	public short[] mvaluetiemnang;

	// Token: 0x04000762 RID: 1890
	public bool isPetTool;
}
