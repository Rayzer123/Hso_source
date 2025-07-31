using System;

// Token: 0x0200004A RID: 74
public class Item
{
	// Token: 0x06000337 RID: 823 RVA: 0x0002B6F0 File Offset: 0x000298F0
	public bool isOutTime()
	{
		return mSystem.currentTimeMillis() / 1000L - this.currentTimeItemFashion > (long)this.timeDefaultItemFashion;
	}

	// Token: 0x06000338 RID: 824 RVA: 0x0002B720 File Offset: 0x00029920
	public bool isFashionItem()
	{
		return this.timeDefaultItemFashion != -1;
	}

	// Token: 0x06000339 RID: 825 RVA: 0x0002B730 File Offset: 0x00029930
	public long getTimeItemFashion()
	{
		return mSystem.currentTimeMillis() - this.currentTimeItemFashion;
	}

	// Token: 0x0600033A RID: 826 RVA: 0x0002B740 File Offset: 0x00029940
	public static bool isWeapone(int type)
	{
		return type >= 8 && type <= 11;
	}

	// Token: 0x0600033B RID: 827 RVA: 0x0002B754 File Offset: 0x00029954
	public void addhole(short[] typehole)
	{
	}

	// Token: 0x0600033C RID: 828 RVA: 0x0002B758 File Offset: 0x00029958
	public static bool isMaterial_Light_Drak(int typeMaterial)
	{
		return typeMaterial > 22 && typeMaterial < 33;
	}

	// Token: 0x0600033D RID: 829 RVA: 0x0002B76C File Offset: 0x0002996C
	public void paintItem(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (this.itemName == null)
		{
			if (this.setNameNull())
			{
				return;
			}
		}
		else
		{
			if (this.colorNameItem > 0)
			{
				int num = this.colorNameItem;
				if (this.colorNameItem >= 20 && this.colorNameItem < 30)
				{
					num = 6;
				}
				else if (this.colorNameItem >= 30 && this.colorNameItem < 40)
				{
					num = 7;
				}
				else if (this.colorNameItem >= 40 && this.colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (this.ItemCatagory == 6)
			{
				if (this.priceItem <= 0L)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, this.imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (this.ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)this.imageId);
			}
			else if (this.ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)this.imageId);
			}
			else if (this.ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)this.Id);
			}
			else if (this.ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)this.imageId);
			}
			if (this.ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = Item.frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							this.frame = (byte)((int)(this.frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, (int)(Item.frameicon[(int)this.frame] * 18), 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (this.ItemCatagory == 3 && (int)this.tier > 0)
			{
				int upgrade = (int)this.tier;
				if (this.type_Only_Item == 7)
				{
					upgrade = (int)this.tier / 2;
				}
				Item.eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if (this.numPotion > 1)
		{
			mFont.number_Yellow_Small.drawString(g, this.numPotion + string.Empty, x + w / 2 - 1 - numlech, y + w / 2 - 9 - numlech, 1, mGraphics.isTrue);
		}
		if ((int)this.isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (this.ItemCatagory == 3)
		{
			if (this.timeUse > 0)
			{
				this.updateTime();
			}
			if (this.isFashionItem())
			{
				this.updateFashion();
			}
		}
	}

	// Token: 0x0600033E RID: 830 RVA: 0x0002BAFC File Offset: 0x00029CFC
	public virtual void paintItem_notnum(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (this.itemName == null)
		{
			if (this.setNameNull())
			{
				return;
			}
		}
		else
		{
			if (this.colorNameItem > 0)
			{
				int num = this.colorNameItem;
				if (this.colorNameItem >= 20 && this.colorNameItem < 30)
				{
					num = 6;
				}
				else if (this.colorNameItem >= 30 && this.colorNameItem < 40)
				{
					num = 7;
				}
				else if (this.colorNameItem >= 40 && this.colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (this.ItemCatagory == 6)
			{
				if (this.priceItem <= 0L)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, this.imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (this.ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)this.imageId);
			}
			else if (this.ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)this.imageId);
			}
			else if (this.ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)this.Id);
			}
			else if (this.ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)this.imageId);
			}
			if (this.ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = Item.frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							this.frame = (byte)((int)(this.frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, (int)(Item.frameicon[(int)this.frame] * 18), 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (this.ItemCatagory == 3 && (int)this.tier > 0)
			{
				int upgrade = (int)this.tier;
				if (this.type_Only_Item == 7)
				{
					upgrade = (int)this.tier / 2;
				}
				Item.eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if ((int)this.isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (this.ItemCatagory == 3)
		{
			if (this.timeUse > 0)
			{
				this.updateTime();
			}
			if (this.isFashionItem())
			{
				this.updateFashion();
			}
		}
	}

	// Token: 0x0600033F RID: 831 RVA: 0x0002BE44 File Offset: 0x0002A044
	public void paintItemNew(mGraphics g, int x, int y, int w, int lech, int numlech)
	{
		MainImage mainImage = null;
		if (this.itemName == null)
		{
			if (this.setNameNull())
			{
				return;
			}
		}
		else
		{
			if (this.colorNameItem > 0)
			{
				int num = this.colorNameItem;
				if (this.colorNameItem >= 20 && this.colorNameItem < 30)
				{
					num = 6;
				}
				else if (this.colorNameItem >= 30 && this.colorNameItem < 40)
				{
					num = 7;
				}
				else if (this.colorNameItem >= 40 && this.colorNameItem < 50)
				{
					num = 8;
				}
				g.drawRegion(AvMain.imgColorItem, 0, (num - 1) * 32, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
			}
			if (this.ItemCatagory == 6)
			{
				if (this.priceItem <= 0L)
				{
					g.drawRegion(AvMain.imgColorItem, 0, 0, w - 1, w - 1, 2, x - (w - 1) / 2, y - (w - 1) / 2, 0, mGraphics.isTrue);
				}
				CRes.getCharPartInfo(5, this.imageId).paintShow(g, x, y, 0, 0);
				return;
			}
			if (this.ItemCatagory == 5)
			{
				mainImage = ObjectData.getImageQuestItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 4)
			{
				mainImage = ObjectData.getImagePotion((short)this.imageId);
			}
			else if (this.ItemCatagory == 3)
			{
				mainImage = ObjectData.getImageItem((short)this.imageId);
			}
			else if (this.ItemCatagory == 7)
			{
				mainImage = ObjectData.getImageMaterial((short)this.imageId);
			}
			else if (this.ItemCatagory == 8)
			{
				mainImage = ObjectData.getImageIconClan((short)this.Id);
			}
			else if (this.ItemCatagory == 9)
			{
				mainImage = ObjectData.getImageIconPet((short)this.imageId);
			}
			if (this.ItemCatagory != 6)
			{
				if (mainImage != null && mainImage.img != null)
				{
					if (mImage.getImageHeight(mainImage.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 10 == 0)
						{
							int num2 = Item.frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							this.frame = (byte)((int)(this.frame + 1) % num2);
						}
						g.drawRegion(mainImage.img, 0, (int)(Item.frameicon[(int)this.frame] * 18), 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(mainImage.img, x, y, 3, mGraphics.isTrue);
					}
				}
				else
				{
					g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, 3, mGraphics.isTrue);
				}
			}
			if (this.ItemCatagory == 3 && (int)this.tier > 0)
			{
				int upgrade = (int)this.tier;
				if (this.type_Only_Item == 7)
				{
					upgrade = (int)this.tier / 2;
				}
				Item.eff_UpLv.paintUpgradeEffect(x, y, upgrade, w - 4, g, lech);
			}
		}
		if ((int)this.isLock > 0)
		{
			g.drawImage(AvMain.imgLock, x + 4, y + 3, 0, mGraphics.isTrue);
		}
		if (this.ItemCatagory == 3)
		{
			if (this.timeUse > 0)
			{
				this.updateTime();
			}
			if (this.isFashionItem())
			{
				this.updateFashion();
			}
		}
	}

	// Token: 0x06000340 RID: 832 RVA: 0x0002C18C File Offset: 0x0002A38C
	public void updateTime()
	{
		if ((GameCanvas.timeNow - this.timeDem) / 1000L >= 60L && !this.isFashionItem())
		{
			this.timeDem += 60000L;
			this.timeUse--;
			if (this.mPlusContent != null)
			{
				if (this.timeUse > 0)
				{
					if (this.type_Only_Item == 14)
					{
						this.mPlusContent[0] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(this.timeUse);
					}
					else
					{
						this.mPlusContent[0] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(this.timeUse);
					}
				}
				else
				{
					this.mPlusContent[0] = string.Empty;
				}
			}
		}
	}

	// Token: 0x06000341 RID: 833 RVA: 0x0002C258 File Offset: 0x0002A458
	public void updateFashion()
	{
		if ((GameCanvas.timeNow - this.timeDem) / 1000L >= 60L)
		{
			this.timeDem += 60000L;
			int num = (int)((long)this.timeDefaultItemFashion - this.getTimeItemFashion() / 60000L);
			if (this.mPlusContent != null)
			{
				if (num > 0)
				{
					if (this.type_Only_Item == 14)
					{
						this.mPlusContent[0] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(num);
					}
					else
					{
						this.mPlusContent[0] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(num);
					}
				}
				else
				{
					this.mPlusContent[0] = string.Empty;
				}
			}
		}
	}

	// Token: 0x06000342 RID: 834 RVA: 0x0002C310 File Offset: 0x0002A510
	public bool setNameNull()
	{
		if (this.itemName != null)
		{
			return false;
		}
		MainTemplateItem itemTem = MainTemplateItem.getItemTem(this.IdTem);
		if (itemTem.name != null)
		{
			this.setValueItem(itemTem);
			return false;
		}
		MainTemplateItem.getItemTem(this.IdTem);
		return true;
	}

	// Token: 0x06000343 RID: 835 RVA: 0x0002C358 File Offset: 0x0002A558
	public void setValueItem(MainTemplateItem item)
	{
		this.itemName = item.name;
		this.imageId = item.IconId;
		this.type_Only_Item = item.typeItem;
		if (this.mInfo == null)
		{
			MainInfoItem[] array = new MainInfoItem[item.mValueItem.Length];
			for (int i = 0; i < item.mValueItem.Length; i++)
			{
				array[i] = new MainInfoItem(i, item.mValueItem[i]);
			}
			this.mInfo = array;
			this.setContentTem();
		}
	}

	// Token: 0x06000344 RID: 836 RVA: 0x0002C3DC File Offset: 0x0002A5DC
	public void setContentTem()
	{
		int num = 0;
		for (int i = 0; i < this.mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = this.mInfo[i];
			if (mainInfoItem.value > 0)
			{
				num++;
			}
		}
		this.mcontent = new string[num];
		this.mColor = new int[num];
		num = 0;
		int width = mFont.tahoma_7b_white.getWidth(this.itemName);
		if (width > this.sizeW - 10)
		{
			this.sizeW = width + 10;
		}
		for (int j = 0; j < this.mInfo.Length; j++)
		{
			MainInfoItem mainInfoItem2 = this.mInfo[j];
			if (mainInfoItem2.value > 0)
			{
				this.mcontent[num] = Item.nameInfoItem[j] + ": " + mainInfoItem2.value;
				if ((int)Item.isPercentInfoItem[j] == 1)
				{
					string[] array = this.mcontent;
					int num2 = num;
					array[num2] += "%";
				}
				this.mColor[num] = (int)Item.colorInfoItem[j];
				width = mFont.tahoma_7_black.getWidth(this.mcontent[num]);
				if (width > this.sizeW - 10)
				{
					this.sizeW = width + 10;
				}
				num++;
			}
		}
		if (this.sizeW > 200 && GameCanvas.isTouch)
		{
			this.sizeW = 130;
		}
		this.setSliptConten();
	}

	// Token: 0x06000345 RID: 837 RVA: 0x0002C550 File Offset: 0x0002A750
	public void setContentItem()
	{
		if (this.itemName == null)
		{
			this.itemName = null;
			return;
		}
		int num = this.mInfo.Length;
		mVector mVector = new mVector("EffectSkill tem");
		for (int i = 0; i < this.mInfo.Length; i++)
		{
			MainInfoItem mainInfoItem = this.mInfo[i];
			if ((int)Item.isPercentInfoItem[mainInfoItem.id] == 4)
			{
				InfocontenNew o = new InfocontenNew(mainInfoItem.value, i);
				this.moreContenGem.addElement(o);
			}
			else if (Item.isATB_Can_paint((int)Item.isPercentInfoItem[mainInfoItem.id]))
			{
				mVector.addElement(mainInfoItem);
			}
		}
		num = mVector.size();
		this.mcontent = new string[num];
		this.mColor = new int[num];
		int width = mFont.tahoma_7b_white.getWidth(this.itemName);
		if (width > this.sizeW - 10)
		{
			this.sizeW = width + 10;
		}
		for (int j = 0; j < num; j++)
		{
			MainInfoItem mainInfoItem2 = (MainInfoItem)mVector.elementAt(j);
			if (mainInfoItem2.value == 0)
			{
				this.mcontent[j] = Item.nameInfoItem[mainInfoItem2.id];
			}
			else if (this.type_Only_Item == 14)
			{
				if (mainInfoItem2.maxDam > 0)
				{
					this.mcontent[j] = string.Concat(new object[]
					{
						Item.nameInfoItem[mainInfoItem2.id],
						": ",
						Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value),
						"-",
						mainInfoItem2.maxDam
					});
				}
				else
				{
					this.mcontent[j] = Item.nameInfoItem[mainInfoItem2.id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value);
				}
			}
			else
			{
				this.mcontent[j] = Item.nameInfoItem[mainInfoItem2.id] + ": " + ((mainInfoItem2.id != 70) ? Item.getPercent((int)Item.isPercentInfoItem[mainInfoItem2.id], mainInfoItem2.value) : MainItem.getDotNumber((long)mainInfoItem2.value));
				if (mainInfoItem2.id == 70)
				{
					this.Selling = 1;
				}
			}
			this.mColor[j] = (int)Item.colorInfoItem[mainInfoItem2.id];
			width = mFont.tahoma_7_black.getWidth(this.mcontent[j]);
			if (width > this.sizeW - 10)
			{
				this.sizeW = width + 10;
			}
		}
		int num2 = 0;
		if (this.timeUse > 0)
		{
			num2++;
		}
		bool flag = this.isFashionItem();
		int num3 = (int)((long)this.timeDefaultItemFashion - this.getTimeItemFashion() / 60000L);
		if (num3 <= 0)
		{
			flag = false;
		}
		if (flag)
		{
			num2++;
		}
		if (this.priceItem > 0L)
		{
			num2++;
		}
		if (this.ItemCatagory == 3 && this.classcharItem < 4 && this.classcharItem > -1)
		{
			num2++;
		}
		if (this.type_Only_Item != 14 && this.LvItem > 0)
		{
			num2++;
		}
		if (num2 > 0)
		{
			this.mPlusContent = new string[num2];
			this.mPlusColor = new int[num2];
			num2 = 0;
			if (this.timeUse > 0)
			{
				this.mPlusColor[num2] = 6;
				if (this.type_Only_Item == 14)
				{
					this.mPlusContent[num2] = T.thoigianaptrung + PaintInfoGameScreen.getStringTime(this.timeUse);
				}
				else
				{
					this.mPlusContent[num2] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(this.timeUse);
				}
				width = mFont.tahoma_7_black.getWidth(this.mPlusContent[num2]);
				if (width > this.sizeW - 10)
				{
					this.sizeW = width + 10;
				}
				num2++;
			}
			if (flag)
			{
				this.mPlusColor[num2] = 6;
				this.mPlusContent[num2] = T.thoigianconlai + PaintInfoGameScreen.getStringTime(num3);
				num2++;
			}
			if (this.ItemCatagory == 3 && this.classcharItem < 4 && this.classcharItem > -1)
			{
				this.mPlusContent[num2] = "[" + T.mClass[this.classcharItem] + "]";
				if (this.classcharItem == (int)GameScreen.player.clazz)
				{
					this.mPlusColor[num2] = 0;
				}
				else
				{
					this.mPlusColor[num2] = 6;
				}
				num2++;
			}
			if (this.priceItem > 0L)
			{
				this.mPlusContent[num2] = string.Concat(new object[]
				{
					T.price,
					": ",
					this.priceItem,
					this.getPriceType()
				});
				this.mPlusColor[num2] = 2;
				num2++;
			}
			if (this.type_Only_Item != 14 && this.LvItem > 0)
			{
				this.mPlusContent[num2] = T.LVyeucau + this.LvItem;
				this.mPlusColor[num2] = 0;
				width = mFont.tahoma_7_black.getWidth(this.mPlusContent[num2]);
				if (width > this.sizeW - 10)
				{
					this.sizeW = width + 10;
				}
			}
		}
		else
		{
			this.mPlusContent = null;
			this.mPlusColor = null;
		}
		if (this.sizeW > 200 && GameCanvas.isTouch)
		{
			this.sizeW = 130;
		}
		this.setSliptConten();
	}

	// Token: 0x06000346 RID: 838 RVA: 0x0002CB20 File Offset: 0x0002AD20
	public void setSliptConten()
	{
		if (this.mcontent == null || (this.mcontent != null && this.mcontent.Length == 1) || this.mcontent.Length == 0)
		{
			return;
		}
		if (this.ItemCatagory != 3)
		{
			return;
		}
		int lineWidth = this.sizeW;
		mVector mVector = new mVector();
		string text = this.mcontent[0];
		sbyte b = (sbyte)this.mColor[0];
		for (int i = 1; i < this.mcontent.Length; i++)
		{
			string[] array = mFont.tahoma_7_black.splitFontArray(this.mcontent[i], lineWidth);
			for (int j = 0; j < array.Length; j++)
			{
				Atb_info o = new Atb_info(array[j], this.mColor[i]);
				mVector.addElement(o);
			}
		}
		this.mcontent = new string[mVector.size() + 1];
		this.mColor = new int[mVector.size() + 1];
		this.mcontent[0] = text;
		this.mColor[0] = (int)b;
		for (int k = 0; k < mVector.size(); k++)
		{
			Atb_info atb_info = (Atb_info)mVector.elementAt(k);
			this.mcontent[k + 1] = atb_info.info;
			this.mColor[k + 1] = (int)atb_info.id_color;
		}
	}

	// Token: 0x06000347 RID: 839 RVA: 0x0002CC80 File Offset: 0x0002AE80
	public static string getPercent(int t, int value)
	{
		if (t == 1)
		{
			if (value % 100 == 0)
			{
				return value / 100 + "%";
			}
			if (value % 10 == 0)
			{
				return string.Concat(new object[]
				{
					value / 100,
					".",
					value % 100 / 10,
					"%"
				});
			}
			return string.Concat(new object[]
			{
				value / 100,
				".",
				value % 100 / 10,
				string.Empty,
				value % 10,
				"%"
			});
		}
		else
		{
			if (t == 2)
			{
				return string.Concat(new object[]
				{
					value / 1000,
					",",
					value % 1000 / 100,
					"s"
				});
			}
			if (t == 3)
			{
				return value + "$";
			}
			if (t == 4)
			{
				return " ";
			}
			if (t == 6)
			{
				return value + " " + T.coin;
			}
			if (t == 7)
			{
				return string.Empty;
			}
			return string.Empty + value;
		}
	}

	// Token: 0x06000348 RID: 840 RVA: 0x0002CDE0 File Offset: 0x0002AFE0
	public string getPriceType()
	{
		string result = " " + T.coin;
		if ((int)this.priceType == 1)
		{
			result = " " + T.gem;
		}
		return result;
	}

	// Token: 0x06000349 RID: 841 RVA: 0x0002CE1C File Offset: 0x0002B01C
	public static Item getItemVec(int type, short ID, mVector vec)
	{
		for (int i = 0; i < vec.size(); i++)
		{
			Item item = (Item)vec.elementAt(i);
			if (item.Id == (int)ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	// Token: 0x0600034A RID: 842 RVA: 0x0002CE68 File Offset: 0x0002B068
	public static Item getItemInventory(int type, short ID)
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			Item item = (Item)Item.VecInvetoryPlayer.elementAt(i);
			if (item.Id == (int)ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	// Token: 0x0600034B RID: 843 RVA: 0x0002CEBC File Offset: 0x0002B0BC
	public static Item getItemChest(int type, short ID)
	{
		for (int i = 0; i < Item.VecChestPlayer.size(); i++)
		{
			Item item = (Item)Item.VecChestPlayer.elementAt(i);
			if (item.Id == (int)ID && item.ItemCatagory == type)
			{
				return item;
			}
		}
		return null;
	}

	// Token: 0x0600034C RID: 844 RVA: 0x0002CF10 File Offset: 0x0002B110
	public static MainItem getMaterial(int id)
	{
		return (MainItem)MainTemplateItem.hashMaterialTem.get(id + string.Empty);
	}

	// Token: 0x0600034D RID: 845 RVA: 0x0002CF40 File Offset: 0x0002B140
	public static void put_Material(int id)
	{
		MainItem v = new MainItem();
		MainTemplateItem.hashMaterialTem.put(string.Empty + id, v);
		GlobalService.gI().RequestMaterialTemplate((short)id);
	}

	// Token: 0x0600034E RID: 846 RVA: 0x0002CF7C File Offset: 0x0002B17C
	public virtual bool isMaterialHopNguyenLieu()
	{
		return false;
	}

	// Token: 0x0600034F RID: 847 RVA: 0x0002CF80 File Offset: 0x0002B180
	public static bool isATB_Can_paint(int id)
	{
		for (int i = 0; i < Item.ATB_Can_Not_Paint.Length; i++)
		{
			if (id == (int)Item.ATB_Can_Not_Paint[i])
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000350 RID: 848 RVA: 0x0002CFB8 File Offset: 0x0002B1B8
	public void setinfo(int ID, string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		this.Id = ID;
		this.ItemCatagory = typeMain;
		this.priceItem = price;
		this.priceType = priceType;
		this.value = value;
		this.canSell = Sell;
		this.canTrade = Trade;
		this.content = content;
		this.typeMaterial = typeitem;
		if (content != null)
		{
			this.mMoreContent(content);
		}
		this.IndexSort = 2;
	}

	// Token: 0x06000351 RID: 849 RVA: 0x0002D030 File Offset: 0x0002B230
	public void setinfo(string itemName, int imageId, int typeMain, long price, sbyte priceType, string content, int value, sbyte typeitem, short num, sbyte Sell, sbyte Trade)
	{
		this.itemName = itemName;
		this.imageId = imageId;
		this.ItemCatagory = typeMain;
		this.priceItem = price;
		this.priceType = priceType;
		this.value = value;
		this.canSell = Sell;
		this.canTrade = Trade;
		this.content = content;
		this.typeMaterial = typeitem;
		if (content != null)
		{
			this.mMoreContent(content);
		}
		this.IndexSort = 2;
	}

	// Token: 0x06000352 RID: 850 RVA: 0x0002D0A0 File Offset: 0x0002B2A0
	public virtual void mMoreContent(string str)
	{
		this.sizeW = 86;
		if (MainTabNew.longwidth > 0)
		{
			this.sizeW = MainTabNew.longwidth - 5;
		}
		this.mcontent = mFont.tahoma_7_black.splitFontArray(str, this.sizeW - 5);
		if (MainTabNew.longwidth == 0 && ((this.mcontent.Length + 1) * GameCanvas.hText > GameCanvas.h / 4 * 3 || mFont.tahoma_7b_black.getWidth(this.itemName) > 70))
		{
			this.sizeW = 120;
			this.mcontent = mFont.tahoma_7_black.splitFontArray(str, this.sizeW - 5);
		}
		this.mColor = new int[this.mcontent.Length];
		for (int i = 0; i < this.mColor.Length; i++)
		{
			this.mColor[i] = 0;
		}
		int num = 0;
		if (this.priceItem > 0L)
		{
			num++;
		}
		if (num > 0)
		{
			this.mPlusContent = new string[num];
			this.mPlusColor = new int[num];
			if (this.priceItem > 0L)
			{
				this.mPlusContent[num - 1] = T.price + ": " + MainItem.getDotNumber(this.priceItem) + this.getPriceType();
				this.mPlusColor[num - 1] = 2;
			}
		}
		else
		{
			this.mPlusContent = null;
			this.mPlusColor = null;
		}
	}

	// Token: 0x06000353 RID: 851 RVA: 0x0002D204 File Offset: 0x0002B404
	public void setColorName(int colorNameItem)
	{
		this.colorNameItem = colorNameItem;
	}

	// Token: 0x04000414 RID: 1044
	public const sbyte HP = 0;

	// Token: 0x04000415 RID: 1045
	public const sbyte MP = 1;

	// Token: 0x04000416 RID: 1046
	public const sbyte COIN = 2;

	// Token: 0x04000417 RID: 1047
	public const sbyte GOLD = 6;

	// Token: 0x04000418 RID: 1048
	public static sbyte TYPE_NGOC_KHAM = 49;

	// Token: 0x04000419 RID: 1049
	public static sbyte TYPE_BUA_HUYEN_BI = 50;

	// Token: 0x0400041A RID: 1050
	public static int ID_TEM_VE_MUA_BAN = 51;

	// Token: 0x0400041B RID: 1051
	public static string[] nameInfoItem;

	// Token: 0x0400041C RID: 1052
	public static sbyte[] colorInfoItem;

	// Token: 0x0400041D RID: 1053
	public static sbyte[] isPercentInfoItem;

	// Token: 0x0400041E RID: 1054
	public string itemName;

	// Token: 0x0400041F RID: 1055
	public string content;

	// Token: 0x04000420 RID: 1056
	public string itemNameExcludeLv;

	// Token: 0x04000421 RID: 1057
	public MainInfoItem[] mInfo;

	// Token: 0x04000422 RID: 1058
	public string[] mcontent;

	// Token: 0x04000423 RID: 1059
	public string[] mPlusContent;

	// Token: 0x04000424 RID: 1060
	public int[] mColor;

	// Token: 0x04000425 RID: 1061
	public int[] mPlusColor;

	// Token: 0x04000426 RID: 1062
	public int timeupdateMore;

	// Token: 0x04000427 RID: 1063
	public int timeUse;

	// Token: 0x04000428 RID: 1064
	public long priceItem;

	// Token: 0x04000429 RID: 1065
	public bool isSell;

	// Token: 0x0400042A RID: 1066
	public static Effect_UpLv_Item eff_UpLv = new Effect_UpLv_Item();

	// Token: 0x0400042B RID: 1067
	public int sizeW = 60;

	// Token: 0x0400042C RID: 1068
	public int imageId;

	// Token: 0x0400042D RID: 1069
	public int ItemCatagory;

	// Token: 0x0400042E RID: 1070
	public short IdTem;

	// Token: 0x0400042F RID: 1071
	public static FrameImage fraeffitemdrop;

	// Token: 0x04000430 RID: 1072
	private int wImage = 16;

	// Token: 0x04000431 RID: 1073
	public sbyte canSell;

	// Token: 0x04000432 RID: 1074
	public sbyte canTrade;

	// Token: 0x04000433 RID: 1075
	public sbyte tier;

	// Token: 0x04000434 RID: 1076
	public sbyte typeMaterial;

	// Token: 0x04000435 RID: 1077
	public sbyte isLock;

	// Token: 0x04000436 RID: 1078
	public sbyte IndexSort;

	// Token: 0x04000437 RID: 1079
	public long timeDem;

	// Token: 0x04000438 RID: 1080
	public sbyte can_sell_for_other_player;

	// Token: 0x04000439 RID: 1081
	public sbyte Selling;

	// Token: 0x0400043A RID: 1082
	public int timeDefaultItemFashion = -1;

	// Token: 0x0400043B RID: 1083
	public long currentTimeItemFashion = -1L;

	// Token: 0x0400043C RID: 1084
	public sbyte CanShell_CanNotTrade;

	// Token: 0x0400043D RID: 1085
	public string[] infoHop = new string[]
	{
		string.Empty,
		string.Empty
	};

	// Token: 0x0400043E RID: 1086
	public static mHashTable VecEquipPlayer = new mHashTable();

	// Token: 0x0400043F RID: 1087
	public static mVector VecInvetoryPlayer = new mVector("Item VecInvetoryPlayer");

	// Token: 0x04000440 RID: 1088
	public static mVector VecChestPlayer = new mVector("Item VecChestPlayer");

	// Token: 0x04000441 RID: 1089
	public static mVector VecPetContainer = new mVector("Item VecPetContainer");

	// Token: 0x04000442 RID: 1090
	public static mVector VecClanInvetory = new mVector("Item VecClanInvetory");

	// Token: 0x04000443 RID: 1091
	public static mVector VecLotteryReward = new mVector("Item VecLotteryReward");

	// Token: 0x04000444 RID: 1092
	public static mVector VecItemSell = new mVector("Item Sell");

	// Token: 0x04000445 RID: 1093
	public static mVector VecItem_Sell_in_store = new mVector("Item Sell in store");

	// Token: 0x04000446 RID: 1094
	public static mHashTable HashImageItem = new mHashTable();

	// Token: 0x04000447 RID: 1095
	public static mHashTable HashImagePotion = new mHashTable();

	// Token: 0x04000448 RID: 1096
	public static mHashTable HashImageQuestItem = new mHashTable();

	// Token: 0x04000449 RID: 1097
	public static mHashTable HashImageMaterial = new mHashTable();

	// Token: 0x0400044A RID: 1098
	public static mHashTable HashImageIconClan = new mHashTable();

	// Token: 0x0400044B RID: 1099
	public static mHashTable HashImageIconArcheClan = new mHashTable();

	// Token: 0x0400044C RID: 1100
	public static mHashTable HashImagePetIcon = new mHashTable();

	// Token: 0x0400044D RID: 1101
	public static mHashTable HashImageMount = new mHashTable();

	// Token: 0x0400044E RID: 1102
	public mVector moreContenGem = new mVector("EffectSkill moreContenGem");

	// Token: 0x0400044F RID: 1103
	public int numPotion;

	// Token: 0x04000450 RID: 1104
	public sbyte typePotion;

	// Token: 0x04000451 RID: 1105
	public int classcharItem;

	// Token: 0x04000452 RID: 1106
	public int colorNameItem;

	// Token: 0x04000453 RID: 1107
	public int Id;

	// Token: 0x04000454 RID: 1108
	public int idTab;

	// Token: 0x04000455 RID: 1109
	public int sell;

	// Token: 0x04000456 RID: 1110
	public int value;

	// Token: 0x04000457 RID: 1111
	public sbyte priceType;

	// Token: 0x04000458 RID: 1112
	public int idPart;

	// Token: 0x04000459 RID: 1113
	public int type_Only_Item;

	// Token: 0x0400045A RID: 1114
	public int LvItem;

	// Token: 0x0400045B RID: 1115
	public string diaHoiEvent = string.Empty;

	// Token: 0x0400045C RID: 1116
	public static byte[] frameicon = new byte[]
	{
		0,
		1,
		2,
		1
	};

	// Token: 0x0400045D RID: 1117
	public byte frame;

	// Token: 0x0400045E RID: 1118
	public Item itemClone;

	// Token: 0x0400045F RID: 1119
	public static sbyte[] ATB_Can_Not_Paint;
}
