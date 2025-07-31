using System;
using System.Collections;

// Token: 0x02000055 RID: 85
public class MainObject : AvMain
{
	// Token: 0x060003CC RID: 972 RVA: 0x00035330 File Offset: 0x00033530
	public MainObject()
	{
	}

	// Token: 0x060003CD RID: 973 RVA: 0x000356E4 File Offset: 0x000338E4
	public MainObject(int ID, sbyte type, string name, int x, int y)
	{
		this.ID = ID;
		this.name = name;
		this.typeObject = type;
		this.x = x;
		this.y = y;
		this.toX = x;
		this.toY = y;
		this.Direction = 0;
	}

	// Token: 0x060003CE RID: 974 RVA: 0x00035AD4 File Offset: 0x00033CD4
	// Note: this type is marked as 'beforefieldinit'.
	static MainObject()
	{
		sbyte[] array = new sbyte[5];
		array[1] = -1;
		MainObject.fixY = array;
		MainObject.ArrMount = new sbyte[]
		{
			3
		};
		MainObject.ArrMount1 = new sbyte[]
		{
			2,
			2,
			2,
			0,
			0,
			3,
			3,
			3,
			0,
			0
		};
	}

	// Token: 0x060003CF RID: 975 RVA: 0x00035C08 File Offset: 0x00033E08
	public static bool isMaHopNguyenLieu(int id)
	{
		bool result;
		try
		{
			for (int i = 0; i < MainObject.idMaterialHopNguyenLieu.Length; i++)
			{
				if ((int)MainObject.idMaterialHopNguyenLieu[i] == id)
				{
					return true;
				}
			}
			result = false;
		}
		catch (Exception ex)
		{
			mSystem.println("----Err mainobj:-- isMaHopNguyenLieu");
			result = false;
		}
		return result;
	}

	// Token: 0x060003D0 RID: 976 RVA: 0x00035C84 File Offset: 0x00033E84
	public virtual string getnameOwner()
	{
		return string.Empty;
	}

	// Token: 0x060003D1 RID: 977 RVA: 0x00035C8C File Offset: 0x00033E8C
	public virtual bool isMainChar()
	{
		return false;
	}

	// Token: 0x060003D2 RID: 978 RVA: 0x00035C90 File Offset: 0x00033E90
	public virtual bool isMonstervantieu()
	{
		return false;
	}

	// Token: 0x060003D3 RID: 979 RVA: 0x00035C94 File Offset: 0x00033E94
	public virtual void setspeedVantieu(int vmax)
	{
	}

	// Token: 0x060003D4 RID: 980 RVA: 0x00035C98 File Offset: 0x00033E98
	public virtual bool isMonsterVantieuTrang()
	{
		return false;
	}

	// Token: 0x060003D5 RID: 981 RVA: 0x00035C9C File Offset: 0x00033E9C
	public virtual bool isMonsterVantieuDen()
	{
		return false;
	}

	// Token: 0x060003D6 RID: 982 RVA: 0x00035CA0 File Offset: 0x00033EA0
	public virtual void setInfo(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
	}

	// Token: 0x060003D7 RID: 983 RVA: 0x00035CA4 File Offset: 0x00033EA4
	public void setInfo(int head, int eye, int hair)
	{
		if (eye < 8)
		{
			eye += 8;
		}
		this.head = head;
		this.eye = eye;
		this.hair = hair;
		this.EyeMain = eye;
	}

	// Token: 0x060003D8 RID: 984 RVA: 0x00035CDC File Offset: 0x00033EDC
	public virtual void setEffectauto(int id, int r, short lv)
	{
	}

	// Token: 0x060003D9 RID: 985 RVA: 0x00035CE0 File Offset: 0x00033EE0
	public void addEffAutoFromsv(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, sbyte lvpaint, long time, sbyte canmove, int dxx, int dyy)
	{
		EffectAuto o = new EffectAuto(id, x, y, dx, dy, typeeff, valueeff, datasv, time, canmove, dxx, dyy);
		if ((int)lvpaint == 0)
		{
			for (int i = 0; i < this.vecEffauto.size(); i++)
			{
				EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
				if (effectAuto != null && (int)effectAuto.IDItem == id)
				{
					this.vecEffauto.removeElement(effectAuto);
				}
			}
			this.vecEffauto.addElement(o);
		}
		else
		{
			for (int j = 0; j < this.veclowEffauto.size(); j++)
			{
				EffectAuto effectAuto2 = (EffectAuto)this.veclowEffauto.elementAt(j);
				if (effectAuto2 != null && (int)effectAuto2.IDItem == id)
				{
					this.veclowEffauto.removeElement(effectAuto2);
				}
			}
			this.veclowEffauto.addElement(o);
		}
	}

	// Token: 0x060003DA RID: 986 RVA: 0x00035DCC File Offset: 0x00033FCC
	public void addeffAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff)
	{
		if (this.isMonstervantieu())
		{
			this.vecEffauto.removeAllElements();
		}
		for (int i = 0; i < this.vecEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
			if (effectAuto != null && (int)effectAuto.IDItem == id)
			{
				this.vecEffauto.removeElement(effectAuto);
			}
		}
		EffectAuto o = new EffectAuto(id, x, y, dx, dy, typeeff, valueeff);
		this.vecEffauto.addElement(o);
	}

	// Token: 0x060003DB RID: 987 RVA: 0x00035E58 File Offset: 0x00034058
	public bool isPkVantieu()
	{
		return (int)this.typePk == 12 || (int)this.typePk == 13 || (int)this.typePk == 11;
	}

	// Token: 0x060003DC RID: 988 RVA: 0x00035E90 File Offset: 0x00034090
	public static void paintShadow(mGraphics g, int dir, int x, int y)
	{
		g.drawRegion(MainObject.shadow1, 0, 0, mImage.getImageWidth(MainObject.shadow1.image), mImage.getImageHeight(MainObject.shadow1.image), 0, x, y, 3, false);
	}

	// Token: 0x060003DD RID: 989 RVA: 0x00035ED0 File Offset: 0x000340D0
	public virtual bool isLuaThieng()
	{
		return false;
	}

	// Token: 0x060003DE RID: 990 RVA: 0x00035ED4 File Offset: 0x000340D4
	public void setWearingListChar(sbyte[] wearing)
	{
		try
		{
			if (wearing == null)
			{
				this.body = -1;
				this.leg = -1;
				this.hat = -1;
				this.wing = -1;
				this.hair = -1;
				this.eye = -1;
				this.head = -1;
				this.weaponType = -1;
				this.pet = -1;
			}
			else
			{
				this.body = (int)wearing[0];
				this.leg = (int)wearing[1];
				this.hat = (int)wearing[2];
				this.wing = (int)wearing[7];
				int num = (int)this.clazz;
				if (num == 3)
				{
					num = 2;
				}
				else if (num == 2)
				{
					num = 3;
				}
				this.weaponType = (int)wearing[8 + num];
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060003DF RID: 991 RVA: 0x00035FA8 File Offset: 0x000341A8
	public virtual void setPainthit(sbyte time, bool isMax)
	{
	}

	// Token: 0x060003E0 RID: 992 RVA: 0x00035FAC File Offset: 0x000341AC
	public void setWearingEquip(sbyte[] wearing)
	{
		if (wearing == null)
		{
			this.body = -1;
			this.leg = -1;
			this.hat = -1;
			this.wing = -1;
			this.weaponType = -1;
			this.pet = -1;
		}
		else
		{
			this.body = (int)wearing[1];
			this.leg = (int)wearing[7];
			this.hat = (int)wearing[6];
			this.wing = (int)wearing[10];
			this.weaponType = (int)wearing[0];
			this.pet = (int)wearing[5];
		}
	}

	// Token: 0x060003E1 RID: 993 RVA: 0x0003602C File Offset: 0x0003422C
	public override void paint(mGraphics g)
	{
	}

	// Token: 0x060003E2 RID: 994 RVA: 0x00036030 File Offset: 0x00034230
	public bool isMountFly()
	{
		return (int)this.typeMount != -1 && MountTemplate.Arr_Fly != null && (int)MountTemplate.Arr_Fly[(int)this.typeMount] == 1;
	}

	// Token: 0x060003E3 RID: 995 RVA: 0x00036070 File Offset: 0x00034270
	public void paintBuffLast(mGraphics g)
	{
		if (this.vecBuff == null)
		{
			return;
		}
		for (int i = this.vecBuff.size() - 1; i >= 0; i--)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuff.elementAt(i);
			if (mainBuff != null && mainBuff.isPaintLast)
			{
				if (mainBuff.typeBuff == 4)
				{
					mainBuff.paint(g, this.x + this.xsai, this.y - this.hOne + 5 + this.ysai);
				}
				else
				{
					mainBuff.paint(g, this.x + this.xsai, this.y + this.ysai);
				}
			}
		}
	}

	// Token: 0x060003E4 RID: 996 RVA: 0x00036128 File Offset: 0x00034328
	public void paintBuffFirst(mGraphics g)
	{
		if (this.vecBuff == null)
		{
			return;
		}
		for (int i = this.vecBuff.size() - 1; i >= 0; i--)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuff.elementAt(i);
			if (mainBuff != null && !mainBuff.isPaintLast)
			{
				if (mainBuff.typeBuff == 4)
				{
					mainBuff.paint(g, this.x + this.xsai, this.y - this.hOne + 5 + this.ysai);
				}
				else
				{
					mainBuff.paint(g, this.x + this.xsai, this.y + this.ysai);
				}
			}
		}
	}

	// Token: 0x060003E5 RID: 997 RVA: 0x000361E0 File Offset: 0x000343E0
	public virtual void paintAvatarFocus(mGraphics g, int x, int y)
	{
		if (this.head != -1)
		{
			CRes.getCharPartInfo(2, this.head).paint(g, x - 1, y + 23, 0, 0);
		}
		if (this.eye != -1)
		{
			CRes.getCharPartInfo(4, this.eye).paint(g, x - 1, y + 23, 0, 0);
		}
		if (this.hair != -1)
		{
			CRes.getCharPartInfo(5, this.hair).paint(g, x - 1, y + 23, 0, 0);
		}
		if (this.hat != -1)
		{
			CRes.getCharPartInfo(3, this.hat).paint(g, x - 1, y + 23, 0, 0);
		}
	}

	// Token: 0x060003E6 RID: 998 RVA: 0x0003628C File Offset: 0x0003448C
	public string getNameAndClan(string plus)
	{
		string text = this.name;
		if (this.myClan != null)
		{
			text = this.myClan.shortName + plus + text;
		}
		return text;
	}

	// Token: 0x060003E7 RID: 999 RVA: 0x000362C0 File Offset: 0x000344C0
	public void paintIconClan(mGraphics g, int x, int y, int pos)
	{
		if (this.myClan != null)
		{
			MainImage imageIconClan = ObjectData.getImageIconClan(this.myClan.IdIcon);
			if (pos == 2)
			{
				int num = (mFont.tahoma_7_white.getWidth(this.myClan.shortName) + 12) / 2;
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num2 = MainObject.frameicon.Length;
							if (num2 == 0)
							{
								num2 = 1;
							}
							this.frameClan = (sbyte)(((int)this.frameClan + 1) % num2);
						}
						g.drawRegion(imageIconClan.img, 0, (int)MainObject.frameicon[(int)this.frameClan] * 18, 18, 18, 0, x - num + 6, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, x - num + 6, y, 3, mGraphics.isTrue);
					}
					Item.eff_UpLv.paintUpgradeEffect(x - num + 6, y - 1, this.myClan.getEffChucVu(), 14, g, 0);
				}
				mFont.tahoma_7_white.drawString(g, this.myClan.shortName, x - num + 15, y - 6, 0, mGraphics.isTrue);
			}
			else if (pos == 0)
			{
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num3 = MainObject.frameicon.Length;
							if (num3 == 0)
							{
								num3 = 1;
							}
							this.frameClan = (sbyte)(((int)this.frameClan + 1) % num3);
						}
						g.drawRegion(imageIconClan.img, 0, (int)MainObject.frameicon[(int)this.frameClan] * 18, 18, 18, 0, x, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, x, y, 3, mGraphics.isTrue);
					}
					Item.eff_UpLv.paintUpgradeEffect(x - 1, y - 1, this.myClan.getEffChucVu(), 14, g, 0);
				}
				mFont.tahoma_7b_white.drawString(g, this.myClan.shortName, x + 13, y, 0, mGraphics.isTrue);
			}
			else if (pos == -1)
			{
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num4 = MainObject.frameicon.Length;
							if (num4 == 0)
							{
								num4 = 1;
							}
							this.frameClan = (sbyte)(((int)this.frameClan + 1) % num4);
						}
						g.drawRegion(imageIconClan.img, 0, (int)MainObject.frameicon[(int)this.frameClan] * 18, 18, 18, 0, x - 1, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, x - 1, y, 3, mGraphics.isTrue);
					}
					Item.eff_UpLv.paintUpgradeEffect(x - 1, y - 1, this.myClan.getEffChucVu(), 14, g, 0);
				}
			}
			else if (pos == -2)
			{
				int num5 = (mFont.tahoma_7_white.getWidth(this.myClan.shortName + " - " + this.myClan.name) + 15) / 2;
				if (imageIconClan.img != null)
				{
					if (mImage.getImageHeight(imageIconClan.img.image) / 18 == 3)
					{
						if (GameCanvas.gameTick % 6 == 0)
						{
							int num6 = MainObject.frameicon.Length;
							if (num6 == 0)
							{
								num6 = 1;
							}
							this.frameClan = (sbyte)(((int)this.frameClan + 1) % num6);
						}
						g.drawRegion(imageIconClan.img, 0, (int)MainObject.frameicon[(int)this.frameClan] * 18, 18, 18, 0, x - num5 + 7, y, 3, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(imageIconClan.img, x - num5 + 7, y, 3, mGraphics.isTrue);
					}
					Item.eff_UpLv.paintUpgradeEffect(x - num5 + 6, y - 1, this.myClan.getEffChucVu(), 14, g, 0);
				}
				mFont.tahoma_7_white.drawString(g, this.myClan.shortName + " - " + this.myClan.name, x - num5 + 15, y - 6, 0, mGraphics.isTrue);
			}
		}
	}

	// Token: 0x060003E8 RID: 1000 RVA: 0x000366DC File Offset: 0x000348DC
	public void paintObject(mGraphics g, int nameIdx)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC((short)this.imageId);
		if (imagePartNPC.img != null)
		{
			this.hOne = mImage.getImageHeight(imagePartNPC.img.image) / (int)this.numFrame;
			this.wOne = mImage.getImageWidth(imagePartNPC.img.image);
			g.drawRegion(imagePartNPC.img, 0, GameCanvas.gameTick / 7 % (int)this.numFrame * this.hOne, this.wOne, this.hOne, 0, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
		}
		if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && this != GameScreen.ObjFocus) || PaintInfoGameScreen.isLevelPoint)
		{
			this.paintName(g, 0);
		}
		int num = this.x;
		int num2 = this.y - this.hOne - 8;
		int num3 = 0;
		if (this.maxHp > 0)
		{
			if (this.hp > 0)
			{
				num3 = this.hp * 50 / this.maxHp;
				if (num3 <= 0)
				{
					num3 = 1;
				}
				else if (num3 > 50)
				{
					num3 = 50;
				}
			}
			g.setColor(8062494);
			g.fillRect(num - this.wOne / 2 + 10, num2, 50, 5, mGraphics.isTrue);
			g.setColor(16197705);
			g.fillRect(num - this.wOne / 2 + 10, num2, num3, 5, mGraphics.isTrue);
		}
	}

	// Token: 0x060003E9 RID: 1001 RVA: 0x0003685C File Offset: 0x00034A5C
	public void jum()
	{
		this.isjum = true;
		this.yjum = 0;
		this.vjum = 10;
		this.mjum = 5;
		this.range = 72;
	}

	// Token: 0x060003EA RID: 1002 RVA: 0x00036884 File Offset: 0x00034A84
	public virtual void paintNameStore(mGraphics g, int x, int y)
	{
	}

	// Token: 0x060003EB RID: 1003 RVA: 0x00036888 File Offset: 0x00034A88
	public void painthidePlayer(mGraphics g, int paintname)
	{
		if (!this.isTanHinh)
		{
			if (this.Canpaint())
			{
				if (this.Action == 4 && !this.isDongBang)
				{
					g.drawImage(MainObject.shadow, this.x + 1, this.y + 1, 3, mGraphics.isTrue);
					this.paintBuffFirst(g);
					AvMain.fraPlayerDie.drawFrame(0, this.x + 1, this.y - this.ysai + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					if (this.effAuto != null)
					{
						this.isDongBang = false;
						this.timeDongBang = mSystem.currentTimeMillis();
						GameScreen.addEffectEndKill(15, this.x, this.y);
						this.effAuto = null;
					}
					if (this.frameDie == 0)
					{
						g.drawImage(AvMain.imgEyeDie, this.x + 1, this.y - this.ysai + 5 - 24, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isTrue);
					}
				}
				else if (!this.checktanghinh())
				{
					if (this.idImageHenshin == -1 && this.idHorse == -1)
					{
						g.drawImage(MainObject.shadow, this.x + 1, this.y - this.ysai + 2, 3, mGraphics.isTrue);
					}
					this.paintBuffFirst(g);
					this.paintEffauto_Low(g, this.x, this.y);
					this.paintDataEff_Top(g, this.x, this.y);
					bool flag = (this.Direction == 0 || this.Direction == 2 || this.Direction == 3) && (((int)this.clazz == 3 && this.frame != 4) || ((int)this.clazz != 3 && this.frame != 5));
					int num = 0;
					if (this.idImageHenshin != -1)
					{
						MainImage imagePartMonster = ObjectData.getImagePartMonster(this.idImageHenshin);
						if (imagePartMonster.img != null)
						{
							int num2 = this.Action;
							if (num2 > this.mAction.Length - 1)
							{
								num2 = 0;
							}
							this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
							this.wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
							if (this.eye == 4 || this.eye == 2)
							{
								num2 = 3;
							}
							int y = this.mAction[num2][(this.Direction <= 2) ? this.Direction : 2][this.frame] * this.hOne;
							int x = this.mAction[num2][(this.Direction <= 2) ? this.Direction : 2][this.frame] / 3 * this.wOne;
							y = this.mAction[num2][(this.Direction <= 2) ? this.Direction : 2][this.frame] % 3 * this.hOne;
							g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.dy + this.dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
						}
					}
					else
					{
						if (flag)
						{
							try
							{
								this.paintWeaponhideplayer(g, num);
							}
							catch (Exception ex)
							{
							}
						}
						bool flag2 = false;
						for (int i = 0; i < MainObject.mTypePartPaintPlayer[this.Direction].Length; i++)
						{
							sbyte b = MainObject.mTypePartPaintPlayer[this.Direction][i];
							if (((int)b != 6 && (int)b != 4) || ((int)b == 6 && this.Direction == 1 && i == 7) || ((int)b == 6 && this.Direction != 1 && i == 0) || ((int)b == 4 && this.Direction != 1))
							{
								if (this.getTypeParthide(i) >= 0)
								{
									if ((int)this.typeMount == -1)
									{
										CRes.getCharPartInfo((int)b, this.getTypeParthide(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.yjum, this.Direction, this.frame);
									}
									else if (i != 1)
									{
										CRes.getCharPartInfo((int)b, this.getTypeParthide(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.dyMount - this.yjum, this.Direction, this.frame);
									}
									else
									{
										this.paintMount_Sau(g);
									}
								}
								else if (((int)b == 0 || (int)b == 1 || (int)b == 2 || (int)b == 4 || (int)b == 5) && !flag2)
								{
									flag2 = true;
									this.setReInfo();
								}
							}
						}
						if ((int)this.typeMount != -1)
						{
							this.paintMount_Truoc(g);
						}
						if (!flag)
						{
							try
							{
								this.paintWeaponhideplayer(g, num);
							}
							catch (Exception ex2)
							{
							}
						}
					}
				}
				else
				{
					for (int j = 0; j < MainObject.mTypePartPaintPlayer[this.Direction].Length; j++)
					{
						sbyte b2 = MainObject.mTypePartPaintPlayer[this.Direction][j];
						if ((int)b2 == 4 && this.getTypeParthide(j) >= 0)
						{
							if ((int)this.typeMount == -1)
							{
								CRes.getCharPartInfo((int)b2, this.getTypeParthide(j)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.yjum, this.Direction, this.frame);
							}
							else if (j != 1)
							{
								CRes.getCharPartInfo((int)b2, this.getTypeParthide(j)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.dyMount - this.yjum, this.Direction, this.frame);
							}
							else
							{
								this.paintMount_Sau(g);
							}
						}
					}
				}
				if (!this.checktanghinh())
				{
					this.paintDataEff_Bot(g, this.x, this.y);
					if (!this.useShip && this.isWater && this.dy == 0)
					{
						int num3 = 1;
						if (this.Direction == 2)
						{
							num3 += 2;
						}
						else if (this.Direction == 3)
						{
							num3 -= 2;
						}
						g.drawRegion(MainObject.water, 0, ((this.Action == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + num3, this.y - this.ysai - 2 + this.dyWater, 3, mGraphics.isTrue);
					}
				}
			}
			if (!this.checktanghinh())
			{
				if ((PaintInfoGameScreen.isLevelPoint || this != GameScreen.ObjFocus) && paintname != -1)
				{
					this.paintName(g, paintname);
				}
				this.paintBuffLast(g);
				this.paint_no(g);
				this.paintEffauto(g, this.x, this.y);
				if (this.hp > 0)
				{
					this.paintDongBang(g);
				}
			}
		}
	}

	// Token: 0x060003EC RID: 1004 RVA: 0x00037048 File Offset: 0x00035248
	public int getFrameLeg()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameLeg * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameLeg * 18;
		}
		return this.frame + 12 + (int)this.FrameLeg * 18;
	}

	// Token: 0x060003ED RID: 1005 RVA: 0x000370B0 File Offset: 0x000352B0
	public int getFrameBien()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameBienhinh * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameBienhinh * 18;
		}
		return this.frame + 12 + (int)this.FrameBienhinh * 18;
	}

	// Token: 0x060003EE RID: 1006 RVA: 0x00037118 File Offset: 0x00035318
	public int getFrameBody()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameBody * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameBody * 18;
		}
		return this.frame + 12 + (int)this.FrameBody * 18;
	}

	// Token: 0x060003EF RID: 1007 RVA: 0x00037180 File Offset: 0x00035380
	public int getFramePP()
	{
		if (this.Direction == 0)
		{
			return this.frame + this.FramePP * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + this.FramePP * 18;
		}
		return this.frame + 12 + this.FramePP * 18;
	}

	// Token: 0x060003F0 RID: 1008 RVA: 0x000371E4 File Offset: 0x000353E4
	public int getFrameWing_Wearing(int mframe)
	{
		return mframe + (int)this.FrameWing * 18;
	}

	// Token: 0x060003F1 RID: 1009 RVA: 0x000371F4 File Offset: 0x000353F4
	public int getFrameWing()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameWing * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameWing * 18;
		}
		return this.frame + 12 + (int)this.FrameWing * 18;
	}

	// Token: 0x060003F2 RID: 1010 RVA: 0x0003725C File Offset: 0x0003545C
	public int getFrameHair()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameHair * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameHair * 18;
		}
		return this.frame + 12 + (int)this.FrameHair * 18;
	}

	// Token: 0x060003F3 RID: 1011 RVA: 0x000372C4 File Offset: 0x000354C4
	public int getFrameHair_Wearing(int mframe)
	{
		return mframe + (int)this.FrameHair * 18;
	}

	// Token: 0x060003F4 RID: 1012 RVA: 0x000372D4 File Offset: 0x000354D4
	public int getFrameBody_Wearing(int mframe)
	{
		return mframe + (int)this.FrameBody * 18;
	}

	// Token: 0x060003F5 RID: 1013 RVA: 0x000372E4 File Offset: 0x000354E4
	public int getFrameLeg_Wearing(int mframe)
	{
		return mframe + (int)this.FrameLeg * 18;
	}

	// Token: 0x060003F6 RID: 1014 RVA: 0x000372F4 File Offset: 0x000354F4
	public int getFrameHorse()
	{
		if (this.Direction == 0)
		{
			return this.Fhorse + this.frameThuCuoi * 21;
		}
		if (this.Direction == 1)
		{
			return this.Fhorse + 7 + this.frameThuCuoi * 21;
		}
		return this.Fhorse + 14 + this.frameThuCuoi * 21;
	}

	// Token: 0x060003F7 RID: 1015 RVA: 0x00037350 File Offset: 0x00035550
	public int getFramePP_Wearing(int mframe)
	{
		return mframe + this.FramePP * 18;
	}

	// Token: 0x060003F8 RID: 1016 RVA: 0x00037360 File Offset: 0x00035560
	public int getFrameMatNa_Wearing(int mframe)
	{
		return mframe + (int)this.FrameMatNa * 18;
	}

	// Token: 0x060003F9 RID: 1017 RVA: 0x00037370 File Offset: 0x00035570
	public int getFrameWP_Wearing(int mframe)
	{
		return mframe + (int)(this.FrameWP * 18);
	}

	// Token: 0x060003FA RID: 1018 RVA: 0x00037380 File Offset: 0x00035580
	public int getFrameWP()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)(this.FrameWP * 18);
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)(this.FrameWP * 18);
		}
		return this.frame + 12 + (int)(this.FrameWP * 18);
	}

	// Token: 0x060003FB RID: 1019 RVA: 0x000373E4 File Offset: 0x000355E4
	public int getFrameMatNa()
	{
		if (this.Direction == 0)
		{
			return this.frame + (int)this.FrameMatNa * 18;
		}
		if (this.Direction == 1)
		{
			return this.Direction * 6 + this.frame + (int)this.FrameMatNa * 18;
		}
		return this.frame + 12 + (int)this.FrameMatNa * 18;
	}

	// Token: 0x060003FC RID: 1020 RVA: 0x0003744C File Offset: 0x0003564C
	public static DataSkillEff getEffMatNa(int id)
	{
		if (id == -1)
		{
			return null;
		}
		DataSkillEff dataSkillEff = (DataSkillEff)MainObject.ALL_EFF_MAT_NA.get(id + string.Empty);
		if (dataSkillEff == null)
		{
			dataSkillEff = new DataSkillEff(id);
			dataSkillEff.typRequestImg = 113;
			MainObject.ALL_EFF_MAT_NA.put(id + string.Empty, dataSkillEff);
			ImageIcon imgIcon = GameData.getImgIcon((short)(id + GameData.ID_START_SKILL), dataSkillEff.typRequestImg);
			dataSkillEff.timeRemove = (long)((int)(mSystem.currentTimeMillis() / 1000L));
		}
		else
		{
			dataSkillEff.timeRemove = GameCanvas.timeNow;
		}
		return dataSkillEff;
	}

	// Token: 0x060003FD RID: 1021 RVA: 0x000374EC File Offset: 0x000356EC
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = MainObject.ALL_EFF_MAT_NA.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				DataSkillEff dataSkillEff = (DataSkillEff)MainObject.ALL_EFF_MAT_NA.get(k);
				if ((GameCanvas.timeNow - dataSkillEff.timeRemove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					MainObject.ALL_EFF_MAT_NA.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060003FE RID: 1022 RVA: 0x00037594 File Offset: 0x00035794
	public void paintPlayer(mGraphics g, int paintname)
	{
		if (this.Action == 2 && this.idHorse != -1)
		{
			this.Fhorse = this.frame + 1;
		}
		if (!this.isTanHinh)
		{
			if (this.Canpaint())
			{
				if (this.Action == 4 && !this.isDongBang)
				{
					g.drawImage(MainObject.shadow, this.x + 1, this.y + 1, 3, mGraphics.isTrue);
					this.paintBuffFirst(g);
					AvMain.fraPlayerDie.drawFrame(0, this.x + 1, this.y - this.ysai + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
					if (this.effAuto != null)
					{
						this.isDongBang = false;
						this.timeDongBang = mSystem.currentTimeMillis();
						GameScreen.addEffectEndKill(15, this.x, this.y);
						this.effAuto = null;
					}
					if (this.frameDie == 0)
					{
						g.drawImage(AvMain.imgEyeDie, this.x + 1, this.y - this.ysai + 5 - 24, mGraphics.TOP | mGraphics.HCENTER, mGraphics.isTrue);
					}
				}
				else
				{
					if (!this.checktanghinh())
					{
						if (this.idImageHenshin == -1 && this.idHorse == -1)
						{
							g.drawImage(MainObject.shadow, this.x + 1, this.y - this.ysai + 2, 3, mGraphics.isTrue);
						}
						this.paintBuffFirst(g);
						this.paintEffauto_Low(g, this.x, this.y);
						this.paintDataEff_Top(g, this.x, this.y);
						bool flag = (this.Direction == 0 || this.Direction == 2 || this.Direction == 3) && (((int)this.clazz == 3 && this.frame != 4) || ((int)this.clazz != 3 && this.frame != 5));
						DataSkillEff effMatNa = MainObject.getEffMatNa((int)this.idWeaPon);
						if (GameCanvas.gameTick % 5 == 0 && effMatNa != null)
						{
							int num = effMatNa.listFrame.size() / 18;
							if (num == 0)
							{
								num = 1;
							}
							this.FrameWP = (byte)((int)(this.FrameWP + 1) % num);
						}
						DataSkillEff effMatNa2 = MainObject.getEffMatNa((int)this.idHorse);
						if (effMatNa2 != null)
						{
							effMatNa2.paintBottomHorse(g, this.x + this.xMount, this.y - this.ysai - this.dy + this.dyWater - this.yjum + this.yMount, this.getFrameHorse(), (this.Direction != 3) ? 0 : 2);
						}
						int num2 = 0;
						if (this.idImageHenshin != -1)
						{
							MainImage imagePartMonster = ObjectData.getImagePartMonster(this.idImageHenshin);
							if (imagePartMonster.img != null)
							{
								int num3 = this.Action;
								if (num3 > this.mAction.Length - 1)
								{
									num3 = 0;
								}
								this.hOne = mImage.getImageHeight(imagePartMonster.img.image) / 3;
								this.wOne = mImage.getImageWidth(imagePartMonster.img.image) / 2;
								if (this.eye == 4 || this.eye == 2)
								{
									num3 = 3;
								}
								int y = this.mAction[num3][(this.Direction <= 2) ? this.Direction : 2][this.frame] * this.hOne;
								int x = this.mAction[num3][(this.Direction <= 2) ? this.Direction : 2][this.frame] / 3 * this.wOne;
								y = this.mAction[num3][(this.Direction <= 2) ? this.Direction : 2][this.frame] % 3 * this.hOne;
								g.drawRegion(imagePartMonster.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x, this.y - this.dy + this.dyWater, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
							}
						}
						else
						{
							if (flag)
							{
								try
								{
									this.paintWeapon(g, num2);
									if (effMatNa != null && this.Action != 2)
									{
										effMatNa.paintBottomWeaPon(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWP(), (this.Direction != 3) ? 0 : 2);
										effMatNa.paintTopWeaPon(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWP(), (this.Direction != 3) ? 0 : 2);
									}
								}
								catch (Exception ex)
								{
								}
							}
							bool flag2 = false;
							DataSkillEff effMatNa3 = MainObject.getEffMatNa((int)this.idPhiPhong);
							DataSkillEff effMatNa4 = MainObject.getEffMatNa((int)this.idHair);
							DataSkillEff effMatNa5 = MainObject.getEffMatNa((int)this.idBody);
							DataSkillEff effMatNa6 = MainObject.getEffMatNa((int)this.idLeg);
							DataSkillEff effMatNa7 = MainObject.getEffMatNa((int)this.idBienhinh);
							if (GameCanvas.gameTick % 6 == 0 && effMatNa7 != null)
							{
								int num4 = effMatNa7.listFrame.size() / 18;
								if (num4 == 0)
								{
									num4 = 1;
								}
								this.FrameBienhinh = (sbyte)(((int)this.FrameBienhinh + 1) % num4);
							}
							if (GameCanvas.gameTick % 6 == 0 && effMatNa6 != null)
							{
								int num5 = effMatNa6.listFrame.size() / 18;
								if (num5 == 0)
								{
									num5 = 1;
								}
								this.FrameLeg = (sbyte)(((int)this.FrameLeg + 1) % num5);
							}
							if (GameCanvas.gameTick % 10 == 0 && effMatNa3 != null)
							{
								int num6 = effMatNa3.listFrame.size() / 18;
								if (num6 == 0)
								{
									num6 = 1;
								}
								this.FramePP = (int)((byte)((this.FramePP + 1) % num6));
							}
							if (GameCanvas.gameTick % 6 == 0 && effMatNa5 != null)
							{
								int num7 = effMatNa5.listFrame.size() / 18;
								if (num7 == 0)
								{
									num7 = 1;
								}
								this.FrameBody = (sbyte)(((int)this.FrameBody + 1) % num7);
							}
							if (GameCanvas.gameTick % 6 == 0 && effMatNa4 != null)
							{
								int num8 = effMatNa4.listFrame.size() / 18;
								if (num8 == 0)
								{
									num8 = 1;
								}
								this.FrameHair = (sbyte)(((int)this.FrameHair + 1) % num8);
							}
							DataSkillEff effMatNa8 = MainObject.getEffMatNa((int)this.idWing);
							if (GameCanvas.gameTick % 6 == 0 && effMatNa8 != null)
							{
								int num9 = effMatNa8.listFrame.size() / 18;
								if (num9 == 0)
								{
									num9 = 1;
								}
								this.FrameWing = (sbyte)(((int)this.FrameWing + 1) % num9);
							}
							if (this.Direction != 1 && effMatNa3 != null)
							{
								effMatNa3.paintBottomPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
							}
							DataSkillEff effMatNa9 = MainObject.getEffMatNa((int)this.idMatna);
							if (GameCanvas.gameTick % 5 == 0 && effMatNa9 != null)
							{
								int num10 = effMatNa9.listFrame.size() / 18;
								if (num10 == 0)
								{
									num10 = 1;
								}
								this.FrameMatNa = (sbyte)(((int)this.FrameMatNa + 1) % num10);
							}
							if (effMatNa7 != null && this.idBienhinh != -1)
							{
								effMatNa7.paintBottomAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameBody(), (this.Direction != 3) ? 0 : 2);
								effMatNa7.paintTopAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameBody(), (this.Direction != 3) ? 0 : 2);
							}
							for (int i = 0; i < MainObject.mTypePartPaintPlayer[this.Direction].Length; i++)
							{
								sbyte b = MainObject.mTypePartPaintPlayer[this.Direction][i];
								if ((int)b == -1)
								{
									if (effMatNa9 != null)
									{
										effMatNa9.paintBottom(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
									}
								}
								else
								{
									if (this.Direction == 1)
									{
										if (effMatNa3 != null)
										{
											effMatNa3.paintBottomPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
											effMatNa3.paintTopPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
										}
										if ((int)b == 2 && effMatNa9 != null)
										{
											effMatNa9.paintBottom(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
											effMatNa9.paintTop(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
										}
									}
									else if ((int)b == 4 && effMatNa9 != null && this.paintMatnaTruocNon)
									{
										effMatNa9.paintBottom(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
										effMatNa9.paintTop(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
									}
									if (((int)b != 6 && (int)b != 4) || ((int)b == 6 && this.Direction == 1 && i == 7) || ((int)b == 6 && this.Direction != 1 && i == 0) || ((int)b == 4 && this.Direction != 1))
									{
										if ((int)b == 6 && effMatNa8 != null && this.idWing != -1)
										{
											effMatNa8.paintBottomWing(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWing(), (this.Direction != 3) ? 0 : 2);
											effMatNa8.paintTopWing(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWing(), (this.Direction != 3) ? 0 : 2);
											goto IL_1344;
										}
										if (this.idBienhinh != -1 && effMatNa7 != null && ((int)b == 1 || (int)b == 0 || (int)b == 3 || (int)b == 5 || (int)b == 2))
										{
											goto IL_1344;
										}
										if ((int)b == 1 && this.idBody != -1 && effMatNa5 != null)
										{
											effMatNa5.paintBottomAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameBody(), (this.Direction != 3) ? 0 : 2);
											effMatNa5.paintTopAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameBody(), (this.Direction != 3) ? 0 : 2);
											goto IL_1344;
										}
										if ((int)b == 0 && this.idLeg != -1 && effMatNa6 != null)
										{
											effMatNa6.paintBottomAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameLeg(), (this.Direction != 3) ? 0 : 2);
											effMatNa6.paintTopAll(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameLeg(), (this.Direction != 3) ? 0 : 2);
											goto IL_1344;
										}
										if ((int)b == 5 && this.idHair != -1 && effMatNa4 != null)
										{
											effMatNa4.paintBottomHair(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameHair(), (this.Direction != 3) ? 0 : 2);
											effMatNa4.paintTopHair(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameHair(), (this.Direction != 3) ? 0 : 2);
											goto IL_1344;
										}
										if (this.getTypePart(i) >= 0)
										{
											if ((int)this.typeMount == -1)
											{
												if ((int)b == 6 && (this.Direction == 0 || this.Direction == 2 || this.Direction == 3))
												{
													CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.yjum, this.Direction, this.frame);
													if (effMatNa3 != null)
													{
														effMatNa3.paintBottomPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
														effMatNa3.paintTopPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
													}
												}
												else
												{
													CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.yjum, this.Direction, this.frame);
												}
											}
											else if (i != 1)
											{
												if ((int)b == 6 && (this.Direction == 0 || this.Direction == 2 || this.Direction == 3))
												{
													CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.dyMount - this.yjum, this.Direction, this.frame);
													if (effMatNa3 != null)
													{
														effMatNa3.paintBottomPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
														effMatNa3.paintTopPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
													}
												}
												else
												{
													CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.dyMount - this.yjum, this.Direction, this.frame);
												}
											}
											else
											{
												this.paintMount_Sau(g);
											}
										}
										else if (((int)b == 0 || (int)b == 1 || (int)b == 2 || (int)b == 4 || (int)b == 5) && !flag2)
										{
											flag2 = true;
											this.setReInfo();
										}
									}
									if ((int)b == 3 && effMatNa9 != null && !this.paintMatnaTruocNon && this.Direction != 1)
									{
										effMatNa9.paintBottom(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
										effMatNa9.paintTop(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameMatNa(), (this.Direction != 3) ? 0 : 2);
									}
								}
								IL_1344:;
							}
							if (this.Direction != 1 && effMatNa3 != null)
							{
								effMatNa3.paintTopPP(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater, this.getFramePP(), (this.Direction != 3) ? 0 : 2);
							}
							if ((int)this.typeMount != -1)
							{
								this.paintMount_Truoc(g);
							}
							if (!flag)
							{
								try
								{
									this.paintWeapon(g, num2);
									if (effMatNa != null && this.Action != 2)
									{
										effMatNa.paintBottomWeaPon(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWP(), (this.Direction != 3) ? 0 : 2);
										effMatNa.paintTopWeaPon(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, this.getFrameWP(), (this.Direction != 3) ? 0 : 2);
									}
								}
								catch (Exception ex2)
								{
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < MainObject.mTypePartPaintPlayer[this.Direction].Length; j++)
						{
							sbyte b2 = MainObject.mTypePartPaintPlayer[this.Direction][j];
							if ((int)b2 == 4 && this.getTypePart(j) >= 0)
							{
								if ((int)this.typeMount == -1)
								{
									CRes.getCharPartInfo((int)b2, this.getTypePart(j)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.yjum, this.Direction, this.frame);
								}
								else if (j != 1)
								{
									CRes.getCharPartInfo((int)b2, this.getTypePart(j)).paint(g, this.x, this.y - this.ysai - this.dy + this.dyWater - this.dyMount - this.yjum, this.Direction, this.frame);
								}
								else
								{
									this.paintMount_Sau(g);
								}
							}
						}
					}
					DataSkillEff effMatNa10 = MainObject.getEffMatNa((int)this.idHorse);
					if (effMatNa10 != null)
					{
						effMatNa10.paintTopHorse(g, this.x + this.xMount, this.y - this.ysai - this.dy + this.dyWater - this.yjum + this.yMount, this.getFrameHorse(), (this.Direction != 3) ? 0 : 2);
					}
				}
				if (!this.checktanghinh())
				{
					this.paintDataEff_Bot(g, this.x, this.y);
					if (!this.useShip && this.isWater && this.dy == 0)
					{
						int num11 = 1;
						if (this.Direction == 2)
						{
							num11 += 2;
						}
						else if (this.Direction == 3)
						{
							num11 -= 2;
						}
						g.drawRegion(MainObject.water, 0, ((this.Action == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + num11, this.y - this.ysai - 2 + this.dyWater, 3, mGraphics.isTrue);
					}
				}
			}
			if (!this.canpaintDataSkillEff())
			{
				this.paintDataEff_Top(g, this.x, this.y);
				this.paintDataEff_Bot(g, this.x, this.y);
			}
			if (!this.checktanghinh())
			{
				DataSkillEff effMatNa11 = MainObject.getEffMatNa((int)this.idName);
				if (effMatNa11 != null)
				{
					if (GameCanvas.gameTick % 5 == 0 && effMatNa11 != null)
					{
						int num12 = effMatNa11.listFrame.size();
						if (num12 == 0)
						{
							num12 = 1;
						}
						this.FrameName = (sbyte)(((int)this.FrameName + 1) % num12);
					}
					effMatNa11.paintBottomName(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, (int)this.FrameName, 0);
					effMatNa11.paintTopName(g, this.x, this.y + (((int)this.typeMount == -1) ? 0 : (-this.dyMount)) + this.dyWater - this.yjum, (int)this.FrameName, 0);
				}
			}
			if (!this.checktanghinh())
			{
				if ((PaintInfoGameScreen.isLevelPoint || this != GameScreen.ObjFocus) && paintname != -1)
				{
					this.paintName(g, paintname);
				}
				this.paintBuffLast(g);
				this.paint_no(g);
				this.paintEffauto(g, this.x, this.y);
				if (this.hp > 0)
				{
					this.paintDongBang(g);
				}
			}
		}
	}

	// Token: 0x060003FF RID: 1023 RVA: 0x00038E3C File Offset: 0x0003703C
	public bool canpaintDataSkillEff()
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.CanpaintByeffauto())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000400 RID: 1024 RVA: 0x00038E8C File Offset: 0x0003708C
	public bool checktanghinh()
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && dataSkillEff.isTanghinhbyEffauto())
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000401 RID: 1025 RVA: 0x00038EDC File Offset: 0x000370DC
	public void paintEffauto(mGraphics g, int xp, int yp)
	{
		if (!this.isMainChar() && (int)MainObject.hideEff == 1)
		{
			return;
		}
		for (int i = 0; i < this.vecEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
			if (effectAuto != null)
			{
				effectAuto.paint(g, xp, yp - this.yEffAuto);
			}
		}
	}

	// Token: 0x06000402 RID: 1026 RVA: 0x00038F48 File Offset: 0x00037148
	public void paintDataEff_Top(mGraphics g, int x, int y)
	{
		if (!this.isMainChar() && (int)MainObject.hideEff == 1)
		{
			return;
		}
		int num = this.vecDataSkillEff.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.paintTop(g, x, y);
				}
			}
		}
	}

	// Token: 0x06000403 RID: 1027 RVA: 0x00038FB4 File Offset: 0x000371B4
	public void paintDataEff_Bot(mGraphics g, int x, int y)
	{
		if (!this.isMainChar() && (int)MainObject.hideEff == 1)
		{
			return;
		}
		int num = this.vecDataSkillEff.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.paintBottom(g, x, y);
				}
			}
		}
	}

	// Token: 0x06000404 RID: 1028 RVA: 0x00039020 File Offset: 0x00037220
	public void paintEffauto_Low(mGraphics g, int xp, int yp)
	{
		if (!this.isMainChar() && (int)MainObject.hideEff == 1)
		{
			return;
		}
		for (int i = 0; i < this.veclowEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)this.veclowEffauto.elementAt(i);
			if (effectAuto != null)
			{
				effectAuto.paint(g, xp, yp - this.yEffAuto);
			}
		}
		for (int j = 0; j < this.veclowEffauto.size(); j++)
		{
			EffectAuto effectAuto2 = (EffectAuto)this.veclowEffauto.elementAt(j);
			if (effectAuto2 != null)
			{
				effectAuto2.update();
				if (effectAuto2.wantdestroy)
				{
					this.veclowEffauto.removeElement(effectAuto2);
				}
			}
		}
	}

	// Token: 0x06000405 RID: 1029 RVA: 0x000390DC File Offset: 0x000372DC
	public bool Canpaint()
	{
		int num = this.vecEffauto.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
				if (effectAuto != null && effectAuto.CanpaintByeffauto())
				{
					return false;
				}
			}
		}
		for (int j = 0; j < this.vecDataSkillEff.size(); j++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(j);
			if (dataSkillEff != null && dataSkillEff.CanpaintByeffauto())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000406 RID: 1030 RVA: 0x00039178 File Offset: 0x00037378
	public bool Canmove()
	{
		if (this.isSleep || this.isStun || this.isno || this.isDongBang)
		{
			return false;
		}
		int num = this.vecEffauto.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
				if (effectAuto != null && effectAuto.lockmoveByeffAuto())
				{
					return false;
				}
			}
		}
		if (this.veclowEffauto.size() > 0)
		{
			for (int j = 0; j < this.veclowEffauto.size(); j++)
			{
				EffectAuto effectAuto2 = (EffectAuto)this.veclowEffauto.elementAt(j);
				if (effectAuto2 != null && effectAuto2.lockmoveByeffAuto())
				{
					return false;
				}
			}
		}
		for (int k = 0; k < this.vecDataSkillEff.size(); k++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(k);
			if (dataSkillEff != null && dataSkillEff.lockmoveByeffAuto())
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06000407 RID: 1031 RVA: 0x0003929C File Offset: 0x0003749C
	public void updateEffauto()
	{
		for (int i = 0; i < this.vecEffauto.size(); i++)
		{
			EffectAuto effectAuto = (EffectAuto)this.vecEffauto.elementAt(i);
			if (effectAuto != null)
			{
				effectAuto.update();
				if (effectAuto.wantdestroy)
				{
					this.vecEffauto.removeElement(effectAuto);
				}
			}
		}
	}

	// Token: 0x06000408 RID: 1032 RVA: 0x000392FC File Offset: 0x000374FC
	public void paintDongBang(mGraphics g)
	{
		if (!this.isDongBang || this.Action == 4)
		{
			return;
		}
		if (this.isDongBang && this.effAuto != null)
		{
			this.effAuto.paint(g);
		}
	}

	// Token: 0x06000409 RID: 1033 RVA: 0x00039344 File Offset: 0x00037544
	public int getTypeParthide(int i)
	{
		switch (MainObject.mTypePartPaintPlayer[this.Direction][i])
		{
		case 0:
			return (int)this.clazz;
		case 1:
			return (int)this.clazz;
		case 2:
			return 0;
		case 3:
			return -1;
		case 4:
			return (int)this.clazz + 8;
		case 5:
			return (int)this.clazz;
		case 6:
			return -1;
		default:
			return -1;
		}
	}

	// Token: 0x0600040A RID: 1034 RVA: 0x000393B0 File Offset: 0x000375B0
	public int getTypePart(int i)
	{
		switch (MainObject.mTypePartPaintPlayer[this.Direction][i])
		{
		case 0:
			return (this.idPartFashion[1] == -1) ? this.leg : ((int)this.idPartFashion[1]);
		case 1:
			return (this.idPartFashion[0] == -1) ? this.body : ((int)this.idPartFashion[0]);
		case 2:
			if (this.idPartFashion.Length > 6)
			{
				return (this.idPartFashion[6] == -1) ? this.head : ((int)this.idPartFashion[6]);
			}
			return this.head;
		case 3:
			if (this.isHairNotHat())
			{
				return -1;
			}
			return (this.idPartFashion[2] == -1) ? this.hat : ((int)this.idPartFashion[2]);
		case 4:
			return this.eye;
		case 5:
			return (this.idPartFashion[5] == -1) ? this.hair : ((int)this.idPartFashion[5]);
		case 6:
			return (this.idPartFashion[4] == -1) ? this.wing : ((int)this.idPartFashion[4]);
		default:
			return -1;
		}
	}

	// Token: 0x0600040B RID: 1035 RVA: 0x000394EC File Offset: 0x000376EC
	public void setReInfo()
	{
		if ((GameCanvas.timeNow - this.timeRePlayerInfo) / 1000L > 60L)
		{
			GlobalService.gI().char_info((short)this.ID);
			this.timeRePlayerInfo = GameCanvas.timeNow;
		}
	}

	// Token: 0x0600040C RID: 1036 RVA: 0x00039528 File Offset: 0x00037728
	public void paintShowPlayer(mGraphics g, int x, int y, int dir)
	{
		int num = GameCanvas.gameTick / 6 % 2;
		DataSkillEff effMatNa = MainObject.getEffMatNa((int)this.idPhiPhong);
		DataSkillEff effMatNa2 = MainObject.getEffMatNa((int)this.idHair);
		DataSkillEff effMatNa3 = MainObject.getEffMatNa((int)this.idBody);
		DataSkillEff effMatNa4 = MainObject.getEffMatNa((int)this.idWing);
		DataSkillEff effMatNa5 = MainObject.getEffMatNa((int)this.idLeg);
		if (GameCanvas.gameTick % 6 == 0 && effMatNa4 != null)
		{
			int num2 = effMatNa4.listFrame.size() / 18;
			if (num2 == 0)
			{
				num2 = 1;
			}
			this.FrameWing = (sbyte)(((int)this.FrameWing + 1) % num2);
		}
		if (GameCanvas.gameTick % 10 == 0 && effMatNa != null)
		{
			int num3 = effMatNa.listFrame.size() / 18;
			if (num3 == 0)
			{
				num3 = 1;
			}
			this.FramePP = (int)((byte)((this.FramePP + 1) % num3));
		}
		if (effMatNa != null && this.wing == -1 && this.idPartFashion[4] == -1)
		{
			effMatNa.paintBottomPP(g, x, y, this.getFramePP_Wearing(num), 0);
			effMatNa.paintTopPP(g, x, y, this.getFramePP_Wearing(num), 0);
		}
		DataSkillEff effMatNa6 = MainObject.getEffMatNa((int)this.idMatna);
		DataSkillEff effMatNa7 = MainObject.getEffMatNa((int)this.idWeaPon);
		if (GameCanvas.gameTick % 5 == 0 && effMatNa6 != null)
		{
			int num4 = effMatNa6.listFrame.size() / 18;
			if (num4 == 0)
			{
				num4 = 1;
			}
			this.FrameMatNa = (sbyte)(((int)this.FrameMatNa + 1) % num4);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa2 != null)
		{
			int num5 = effMatNa2.listFrame.size() / 18;
			if (num5 == 0)
			{
				num5 = 1;
			}
			this.FrameHair = (sbyte)(((int)this.FrameHair + 1) % num5);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa3 != null)
		{
			int num6 = effMatNa3.listFrame.size() / 18;
			if (num6 == 0)
			{
				num6 = 1;
			}
			this.FrameBody = (sbyte)(((int)this.FrameBody + 1) % num6);
		}
		if (GameCanvas.gameTick % 6 == 0 && effMatNa5 != null)
		{
			int num7 = effMatNa5.listFrame.size() / 18;
			if (num7 == 0)
			{
				num7 = 1;
			}
			this.FrameLeg = (sbyte)(((int)this.FrameLeg + 1) % num7);
		}
		if (effMatNa7 != null)
		{
			effMatNa7.paintBottomWeaPon(g, x, y, this.getFrameWP_Wearing(num), 0);
			effMatNa7.paintTopWeaPon(g, x, y, this.getFrameWP_Wearing(num), 0);
		}
		g.drawImage(MainObject.shadow, x + 1, y + 2, 3, mGraphics.isTrue);
		int num8 = this.weaponType;
		if (num8 != -1 && CRes.loadImgWeaPone((int)this.clazz, num8, 0) != null)
		{
			WeaponInfo weaponInfo = CRes.loadImgWeaPone((int)this.clazz, num8, 0);
			if (weaponInfo.img != null)
			{
				g.drawRegion(weaponInfo.img, (int)weaponInfo.mRegion[dir][0], 0, (int)weaponInfo.mRegion[dir][1], weaponInfo.himg, 0, x + (int)weaponInfo.mPos[dir][num][0], y + (int)weaponInfo.mPos[dir][num][1], 0, mGraphics.isTrue);
			}
		}
		this.paintDataEff_Top(g, x, y);
		for (int i = 0; i < MainObject.mTypePartPaintPlayer[this.Direction].Length - 1; i++)
		{
			sbyte b = MainObject.mTypePartPaintPlayer[0][i];
			if ((int)b == -1 && effMatNa6 != null)
			{
				effMatNa6.paintBottom(g, x, y, this.getFrameMatNa_Wearing(num), 0);
			}
			if (effMatNa6 != null)
			{
				effMatNa6.paintBottom(g, x, y + 2, this.getFrameMatNa_Wearing(num), 0);
				effMatNa6.paintTop(g, x, y + 2, this.getFrameMatNa_Wearing(num), 0);
			}
			if ((int)b == 5 && this.idHair != -1 && effMatNa2 != null)
			{
				effMatNa2.paintBottomHair(g, x, y + 2, this.getFrameHair_Wearing(num), 0);
				effMatNa2.paintTopHair(g, x, y + 2, this.getFrameHair_Wearing(num), 0);
			}
			else if ((int)b == 1 && this.idBody != -1 && effMatNa3 != null)
			{
				effMatNa3.paintBottomAll(g, x, y + 2, this.getFrameBody_Wearing(num), 0);
				effMatNa3.paintTopAll(g, x, y + 2, this.getFrameBody_Wearing(num), 0);
			}
			else if ((int)b == 0 && this.idLeg != -1 && effMatNa5 != null)
			{
				effMatNa5.paintBottomAll(g, x, y + 2, this.getFrameLeg_Wearing(num), 0);
				effMatNa5.paintTopAll(g, x, y + 2, this.getFrameLeg_Wearing(num), 0);
			}
			else if ((int)b == 6 && this.idWing != -1 && effMatNa4 != null)
			{
				effMatNa4.paintBottomWing(g, x, y + 2, this.getFrameWing_Wearing(num), 0);
				effMatNa4.paintTopWing(g, x, y + 2, this.getFrameWing_Wearing(num), 0);
			}
			else if (this.getTypePart(i) > -1)
			{
				if ((int)b == 6 && (this.wing != -1 || this.idPartFashion[4] != -1))
				{
					CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, x, y, dir, num);
					if (effMatNa != null)
					{
						effMatNa.paintBottomPP(g, x, y, this.getFramePP_Wearing(num), 0);
						effMatNa.paintTopPP(g, x, y, this.getFramePP_Wearing(num), 0);
					}
				}
				else
				{
					CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, x, y, dir, num);
				}
			}
		}
		this.paintDataEff_Bot(g, x, y);
	}

	// Token: 0x0600040D RID: 1037 RVA: 0x00039A7C File Offset: 0x00037C7C
	public void paintShowHairPlayer(mGraphics g, int x, int y, int hairshow)
	{
		int dir = 0;
		int num = GameCanvas.gameTick / 6 % 2;
		g.drawImage(MainObject.shadow, x + 1, y + 2, 3, mGraphics.isFalse);
		int num2 = this.weaponType;
		if (num2 != -1 && CRes.loadImgWeaPone((int)this.clazz, num2, 0) != null)
		{
			WeaponInfo weaponInfo = CRes.loadImgWeaPone((int)this.clazz, num2, 0);
			if (weaponInfo.img != null)
			{
				g.drawRegion(weaponInfo.img, (int)weaponInfo.mRegion[this.Direction][0], 0, (int)weaponInfo.mRegion[this.Direction][1], weaponInfo.himg, 0, x + (int)weaponInfo.mPos[this.Direction][num][0], y + (int)weaponInfo.mPos[this.Direction][num][1], 0, mGraphics.isFalse);
			}
		}
		for (int i = 0; i < MainObject.mTypePartPaintPlayer[this.Direction].Length - 1; i++)
		{
			sbyte b = MainObject.mTypePartPaintPlayer[this.Direction][i];
			if ((int)b == 5)
			{
				if (hairshow != -1)
				{
					CRes.getCharPartInfo(5, hairshow).paint(g, x, y, dir, num);
				}
			}
			else if (this.getTypePart(i) > -1)
			{
				CRes.getCharPartInfo((int)b, this.getTypePart(i)).paint(g, x, y, dir, num);
			}
		}
	}

	// Token: 0x0600040E RID: 1038 RVA: 0x00039BD0 File Offset: 0x00037DD0
	public virtual void paintBigAvatar(mGraphics g, int x, int y)
	{
	}

	// Token: 0x0600040F RID: 1039 RVA: 0x00039BD4 File Offset: 0x00037DD4
	public virtual void paintName(mGraphics g, int id)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		string st = this.name;
		mFont mFont = mFont.tahoma_7_white;
		mFont = MainTabNew.setTextColor(id);
		bool flag = true;
		int num = 0;
		if ((int)this.typeSpec == 1)
		{
			if ((int)this.typePk > 0)
			{
				flag = false;
			}
			num = 5;
		}
		if (this.idName != -1)
		{
			flag = false;
		}
		int num2 = 18;
		if (PaintInfoGameScreen.isLevelPoint)
		{
			num2 = 12;
		}
		if (this.typeMonster == 7)
		{
			num2 += 8;
		}
		if (this.isObject && PaintInfoGameScreen.isLevelPoint)
		{
			num2 += 6;
		}
		if (flag)
		{
			mFont.drawString(g, st, this.x, this.y - this.ysai - this.dy + this.dyWater - ((!this.isDongBang) ? 0 : 5) - this.hOne - num2 - this.dyMount - this.yjum, 2, mGraphics.isFalse);
		}
		if ((int)this.typeObject == 0 && (int)this.typeSpec == 1 && flag && !this.iscuop)
		{
			num2 += 10;
			mFont.drawString(g, T.nhanban, this.x, this.y - this.ysai - this.dy + this.dyWater - ((!this.isDongBang) ? 0 : 5) - this.hOne - num2 - this.dyMount - this.yjum, 2, mGraphics.isFalse);
		}
		if ((int)this.typeObject == 2 && this.chat == null)
		{
			AvMain.fraQuest.drawFrame(this.typeNPC, this.x - 6, this.y - this.ysai - this.dy + this.dyWater - this.hOne - num2 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
		}
		int num3 = 0;
		if ((Player.party != null && this.isParty) || this.isShowHP || this.typeMonster == 7)
		{
			int num4 = 44;
			if ((int)this.typeObject == 2 || this.typeMonster == 7)
			{
				num4 = this.hOne + 5;
			}
			g.setColor(8062494);
			g.fillRect(this.x - 20, this.y - this.ysai - this.dy + this.dyWater - num4 - num2, 40, 3, mGraphics.isFalse);
			g.setColor(16197705);
			g.fillRect(this.x - 20, this.y - this.ysai - this.dy + this.dyWater - num4 - num2, 40 * this.hp / this.maxHp, 3, mGraphics.isFalse);
			num3 += 5;
		}
		if (this.myClan != null && (int)this.typeSpec != 1)
		{
			this.paintIconClan(g, this.x - 1, this.y - this.ysai - this.dy + this.dyWater - this.hOne - num2 - 8 - num3 - this.dyMount - this.yjum, 2);
			num3 += 16;
		}
		if ((int)this.typePk >= 0 && (int)this.typeObject == 0 && !this.isPkVantieu())
		{
			num3 += 59;
			if (mGraphics.zoomLevel < 3)
			{
				AvMain.fraPk.drawFrame((int)this.typePk * 3 + GameCanvas.gameTick / 3 % 3, this.x, this.y - this.dy + this.dyWater - this.ysai - num3 + 18 - num2 + num - this.dyMount - this.yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
			else
			{
				AvMain.fraPkArr[(int)this.typePk * 3 + GameCanvas.gameTick / 3 % 3].drawFrame(0, this.x, this.y - this.dy + this.dyWater - this.ysai - num3 + 18 - num2 + num - this.dyMount - this.yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
			}
		}
	}

	// Token: 0x06000410 RID: 1040 RVA: 0x0003A028 File Offset: 0x00038228
	public virtual void paintNameShow(mGraphics g, int x, int y, bool islevel)
	{
		string nameAndClan = this.getNameAndClan(" - ");
		if (this.myClan != null)
		{
			x += 16;
			this.paintIconClan(g, x - 8, y + 6, -1);
		}
		mFont.tahoma_7b_white.drawString(g, nameAndClan, x, y - this.dyMount - this.yjum, 0, mGraphics.isTrue);
	}

	// Token: 0x06000411 RID: 1041 RVA: 0x0003A084 File Offset: 0x00038284
	public virtual void paintNameFocus(mGraphics g)
	{
		if (GameScreen.infoGame.isMapThachdau())
		{
			return;
		}
		if (GameScreen.ObjFocus != null && !PaintInfoGameScreen.isLevelPoint)
		{
			MainObject objFocus = GameScreen.ObjFocus;
			int num = objFocus.x;
			int num2 = objFocus.y - objFocus.ysai - objFocus.dy + objFocus.dyWater - objFocus.hOne;
			int num3 = 18;
			bool flag = true;
			int num4 = 0;
			if ((int)this.typeSpec == 1)
			{
				if ((int)this.typePk > 0)
				{
					flag = false;
				}
				num4 = 5;
			}
			string st = objFocus.name;
			mFont mFont = mFont.tahoma_7b_white;
			if ((int)this.typeObject == 3)
			{
				mFont = MainTabNew.setTextColorName((int)this.colorName);
			}
			if ((int)this.typeObject == 2 && this.chat == null)
			{
				AvMain.fraQuest.drawFrame(this.typeNPC, num - 6, num2 - num3 - 18 - 4 + GameCanvas.gameTick / 2 % 4, 0, g);
			}
			if (this.idName == -1)
			{
				mFont.drawString(g, st, num, num2 - num3 - this.dyMount - ((!this.isDongBang) ? 0 : 5) - this.yjum, 2, mGraphics.isFalse);
			}
			int num5 = 0;
			if ((int)this.typeObject == 0 && (int)this.typeSpec == 1 && flag && !this.iscuop)
			{
				num3 += 10;
				num5 += 10;
				mFont.drawString(g, T.nhanban, num, num2 - num3 - this.dyMount - ((!this.isDongBang) ? 0 : 5) - this.yjum, 2, mGraphics.isFalse);
			}
			if (Player.party != null && objFocus.isParty)
			{
				num5 = 5;
			}
			if (this.myClan != null && (int)objFocus.typeSpec != 1)
			{
				this.paintIconClan(g, num, num2 - num3 - 8 - num5 - this.dyMount - this.yjum, 2);
				num5 += 16;
			}
			if ((int)objFocus.typePk >= 0 && (int)objFocus.typeObject == 0 && !this.isPkVantieu())
			{
				num5 += 20;
				if (mGraphics.zoomLevel < 3)
				{
					AvMain.fraPk.drawFrame((int)this.typePk * 3 + GameCanvas.gameTick / 3 % 3, num, num2 - num5 - this.dyMount - this.yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
				else
				{
					AvMain.fraPkArr[(int)this.typePk * 3 + GameCanvas.gameTick / 3 % 3].drawFrame(0, num, num2 - num5 + num4 - this.dyMount - this.yjum, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
				}
			}
		}
	}

	// Token: 0x06000412 RID: 1042 RVA: 0x0003A33C File Offset: 0x0003853C
	public static void updatefocus()
	{
		if (GameScreen.ObjFocus != null)
		{
			if (GameScreen.ObjFocus.maxHp > 0 && (!PaintInfoGameScreen.isLevelPoint || Main.isPC) && (int)GameScreen.ObjFocus.typeObject != 10)
			{
				long num = (long)GameScreen.ObjFocus.hp;
				long num2 = 10L;
				long num3 = num * num2;
				MainObject.framefocus = (sbyte)(num3 / (long)GameScreen.ObjFocus.maxHp);
				if ((int)MainObject.framefocus > 9)
				{
					MainObject.framefocus = 9;
				}
			}
			MainObject.framefocus = (sbyte)CRes.abs((int)MainObject.framefocus - 9);
			if ((int)GameScreen.ObjFocus.typeObject == 3 || (int)GameScreen.ObjFocus.typeObject == 4)
			{
				MainObject.framefocus = 0;
			}
		}
	}

	// Token: 0x06000413 RID: 1043 RVA: 0x0003A400 File Offset: 0x00038600
	public static void paintFocus(mGraphics g)
	{
		if (GameScreen.ObjFocus != null && (!PaintInfoGameScreen.isLevelPoint || Main.isPC) && (int)GameScreen.ObjFocus.typeObject != 10)
		{
			MainObject objFocus = GameScreen.ObjFocus;
			int num = 1;
			if ((int)objFocus.typeObject == 1)
			{
				if (!objFocus.canFocusMon)
				{
					return;
				}
				num = 4;
				if (objFocus.typeMonster == 3 || objFocus.typeMonster == 5 || objFocus.typeMonster == 10 || objFocus.typeMonster == 8)
				{
					num = 12;
				}
			}
			if (MainObject.Wfc == 0)
			{
				MainObject.Wfc = mImage.getImageWidth(MainObject.newfocus.image);
				MainObject.Hfc = mImage.getImageHeight(MainObject.newfocus.image) / 10;
			}
			g.drawRegion(MainObject.newfocus, 0, (int)MainObject.framefocus * MainObject.Hfc, MainObject.Wfc, MainObject.Hfc, 0, objFocus.x, objFocus.y - objFocus.hOne - objFocus.dy + objFocus.dyWater - num - GameCanvas.gameTick % 7 - objFocus.dyMount - objFocus.yjum, 3, mGraphics.isFalse);
			if ((Player.party != null && objFocus.isParty) || (objFocus.isShowHP && !Main.isPC))
			{
				int num2 = 64;
				if ((int)objFocus.typeObject == 2)
				{
					num2 = objFocus.hOne + 23;
				}
				g.setColor(8062494);
				g.fillRect(objFocus.x - 20, objFocus.y - num2 - objFocus.dyMount - objFocus.yjum, 40, 3, mGraphics.isFalse);
				g.setColor(16197705);
				g.fillRect(objFocus.x - 20, objFocus.y - num2 - objFocus.dyMount - objFocus.yjum, 40 * objFocus.hp / objFocus.maxHp, 3, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x06000414 RID: 1044 RVA: 0x0003A5F0 File Offset: 0x000387F0
	public static void paintHPQuai(mGraphics g, int x, int y, int wHp)
	{
		g.setColor(0);
		g.fillRect(x - 13, y - 3, 26, 5, mGraphics.isTrue);
		g.setColor(16777215);
		g.fillRect(x - 12, y - 2, 24, 3, mGraphics.isTrue);
		g.setColor(12724553);
		g.fillRect(x - 12, y - 2, wHp, 3, mGraphics.isTrue);
	}

	// Token: 0x06000415 RID: 1045 RVA: 0x0003A658 File Offset: 0x00038858
	public void updateDataEffect()
	{
		int num = this.vecDataSkillEff.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
				if (dataSkillEff != null)
				{
					dataSkillEff.update();
					if (dataSkillEff.wantDetroy)
					{
						this.vecDataSkillEff.removeElement(dataSkillEff);
					}
				}
			}
		}
	}

	// Token: 0x06000416 RID: 1046 RVA: 0x0003A6C0 File Offset: 0x000388C0
	public override void update()
	{
		this.x += this.vx;
		this.y += this.vy;
		if (this.isjum)
		{
			this.yjum += this.vjum;
			this.vjum += this.mjum;
			if (this.yjum > this.range)
			{
				this.yjum = this.range;
				this.vjum = -5;
				this.mjum = -2;
			}
			if (this.yjum <= 0)
			{
				this.yjum = 0;
				this.isjum = false;
			}
		}
		if (this.isMoveOut)
		{
			this.move_to_point();
		}
		this.updateDy();
		if (this.chat != null)
		{
			this.chat.updatePos(this.x, this.y - this.hOne - 30);
			if ((this != GameScreen.player || GameScreen.player.currentQuest == null) && this.chat.setOff())
			{
				this.chat = null;
			}
		}
		if (this.isTanHinh)
		{
			this.timeTanHinh++;
			if (this.timeTanHinh > 40)
			{
				this.timeTanHinh = 0;
				this.isTanHinh = false;
			}
		}
		for (int i = 0; i < this.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuff.elementAt(i);
			mainBuff.update();
			if (mainBuff.isRemove)
			{
				this.vecBuff.removeElement(mainBuff);
				i--;
			}
		}
		if (this.isSend)
		{
			this.timeGet++;
			if (this.timeGet > 40)
			{
				this.isSend = false;
				this.timeGet = 0;
			}
		}
		if (this.strChatPopup != null)
		{
			this.addChat(this.strChatPopup, true);
			this.strChatPopup = null;
		}
		if (this.myClan != null && this.myClan.isRemove)
		{
			this.myClan = null;
		}
		if (this.isSleep)
		{
			this.vx = 0;
			this.vy = 0;
			this.toX = this.x;
			this.toY = this.y;
			this.eye = 0;
			if (this.isDie || this.timeSleep - mSystem.currentTimeMillis() < 0L)
			{
				this.isSleep = false;
				this.timeSleep = mSystem.currentTimeMillis();
			}
		}
		if (this.isStun)
		{
			this.vx = 0;
			this.vy = 0;
			this.toX = this.x;
			this.toY = this.y;
			if (this.isDie || this.timeStun - mSystem.currentTimeMillis() < 0L)
			{
				this.isStun = false;
				this.timeStun = mSystem.currentTimeMillis();
			}
		}
		if (this.isDongBang)
		{
			this.vx = 0;
			this.vy = 0;
			this.toX = this.x;
			this.toY = this.y;
			if (this.effAuto == null)
			{
				this.effAuto = new EffectAuto(51, this.x, this.y, 0, 0, 0, 0);
			}
			if (this.effAuto != null)
			{
				this.effAuto.update();
			}
			if (this.isDie || this.timeDongBang - mSystem.currentTimeMillis() < 0L)
			{
				this.isDongBang = false;
				this.timeDongBang = mSystem.currentTimeMillis();
				GameScreen.addEffectEndKill(15, this.x, this.y);
				this.effAuto = null;
			}
		}
		if (this.isBinded)
		{
			this.vx = 0;
			this.vy = 0;
			this.toX = this.x;
			this.toY = this.y;
			if (this.isDie || this.timeBind - mSystem.currentTimeMillis() < 0L)
			{
				this.isBinded = false;
				this.timeBind = mSystem.currentTimeMillis();
			}
		}
		if (this.isno)
		{
			this.vx = 0;
			this.vy = 0;
			this.toX = this.x;
			this.toY = this.y;
			if (this.isDie || this.timeno - mSystem.currentTimeMillis() < 0L)
			{
				this.isno = false;
				this.timeno = mSystem.currentTimeMillis();
			}
		}
		if (this.isnoBoss84 && (this.isDie || (this.timenoBoss84 - mSystem.currentTimeMillis()) / 1000L <= 0L))
		{
			this.isnoBoss84 = false;
			this.timenoBoss84 = mSystem.currentTimeMillis();
		}
		if (this.isNPC() && this.Direction != 0)
		{
			this.Direction = 0;
		}
		if ((int)this.typeMount == -1 && this.dyMount != 0)
		{
			this.resetMount();
		}
		this.updateMount();
		this.updateEffauto();
		MainObject.updatefocus();
		this.updateEffectWeapon();
	}

	// Token: 0x06000417 RID: 1047 RVA: 0x0003ABB0 File Offset: 0x00038DB0
	public void updateActionPerson()
	{
		if (this.Action == 4)
		{
			if ((int)this.typeMount != -1)
			{
				this.typeMount = -1;
			}
			this.isDongBang = false;
			if (this.frameDie == 0)
			{
				if (CRes.random(20) == 0)
				{
					this.frameDie = 1;
				}
			}
			else if (CRes.random(3) == 0)
			{
				this.frameDie = 0;
			}
			this.isDongBang = false;
			this.effAuto = null;
			if (!GameCanvas.lowGraphic && CRes.random(50) == 0)
			{
				GameScreen.addEffectKill(69, this.ID, this.typeObject, this.ID, this.typeObject, 0, 0);
				if (CRes.random(10) == 0)
				{
					GameScreen.addEffectKill(69, this.ID, this.typeObject, this.ID, this.typeObject, 0, 0);
				}
			}
			return;
		}
		switch (this.Action)
		{
		case 0:
			this.f++;
			if (this.f > this.A_Stand.Length - 1)
			{
				this.f = 0;
			}
			this.frame = (int)this.A_Stand[this.f];
			this.Fhorse = this.frame;
			break;
		case 1:
			this.f++;
			if (this.idHorse != -1)
			{
				if (this.f > MainObject.horseMove.Length - 1)
				{
					this.f = 0;
				}
			}
			else if (this.f > this.A_Move.Length - 1)
			{
				this.f = 0;
			}
			if (this.vx == 0 && this.vy == 0 && this.posTransRoad == null)
			{
				this.Action = 0;
				this.frameLeg = CRes.random(4);
				this.f = 0;
			}
			if (this.idHorse != -1)
			{
				this.Fhorse = (int)MainObject.horseMove[this.f];
				this.frame = 3;
			}
			else
			{
				this.frame = (int)this.A_Move[this.f];
			}
			if (this.isMainChar() && this.idHorse == 114 && !this.isWater && GameCanvas.gameTick % 5 == 0)
			{
				GameScreen.addEffectEndKill_Direction(58, this.x, this.y + ((this.Direction != 2 && this.Direction != 3) ? 0 : 10), this.Direction, -1);
			}
			if (this.isFootSnow && !this.isWater && GameCanvas.gameTick % 5 == 0)
			{
				GameScreen.addEffectEndKill_Direction(56, this.x, this.y, this.Direction, -1);
			}
			break;
		case 2:
			if (this.PlashNow != null)
			{
				this.ListKillNow.updateEffSkill();
				this.PlashNow.update(this);
			}
			break;
		}
	}

	// Token: 0x06000418 RID: 1048 RVA: 0x0003AE9C File Offset: 0x0003909C
	public void updateDy()
	{
		if (this.dyKill > 0)
		{
			this.dy = this.dyKill;
			this.timeDyKill++;
			if (this.timeDyKill > 30)
			{
				this.dyKill = 30;
			}
		}
		else
		{
			if (this.dy > 0)
			{
				this.vDy -= 2;
				this.dy += this.vDy;
			}
			if (this.dy < 0)
			{
				this.dy = -this.dy;
				this.vDy = 0;
			}
			if (this.dy < 3)
			{
				this.dy = 0;
			}
			this.timeDyKill = 0;
		}
	}

	// Token: 0x06000419 RID: 1049 RVA: 0x0003AF50 File Offset: 0x00039150
	public void updateEye()
	{
		if (this.hp < this.hpEffect)
		{
			this.eye = 3;
		}
		else
		{
			if (this.eye == 3)
			{
				this.eye = this.EyeMain;
			}
			if (this.eye != -1)
			{
				this.timeEye++;
				if (this.eye < 3 || this.eye == 4 || this.eye == 5)
				{
					if (this.eye == 4 && this.timeEye > 2)
					{
						this.eye = 5;
					}
					if (this.eye == 2)
					{
						if (this.timeEye >= 8)
						{
							this.timeEye = 0;
							this.eye = this.EyeMain;
							if ((int)this.clazz < 2)
							{
								this.endEye = CRes.random(30, 80);
							}
							else
							{
								this.endEye = CRes.random(10, 60);
							}
						}
					}
					else if (this.timeEye >= 3)
					{
						this.timeEye = 0;
						this.eye = this.EyeMain;
						if ((int)this.clazz < 2)
						{
							this.endEye = CRes.random(30, 80);
						}
						else
						{
							this.endEye = CRes.random(10, 60);
						}
					}
				}
				else if (this.timeEye >= this.endEye)
				{
					this.timeEye = 0;
					this.eye = 0;
				}
			}
		}
	}

	// Token: 0x0600041A RID: 1050 RVA: 0x0003B0C4 File Offset: 0x000392C4
	public virtual void move_to_XY()
	{
		if (!this.Canmove() || this.isBinded)
		{
			this.toX = this.x;
			this.toY = this.y;
			return;
		}
		if (this.isMoveOut)
		{
			return;
		}
		if (CRes.abs(this.x - this.toX) > this.vMax + this.getVmount())
		{
			this.vy = 0;
			this.Action = 1;
			if (CRes.abs(this.x - this.toX) > this.vMax + this.getVmount())
			{
				if (this.x > this.toX)
				{
					this.vx = -(this.vMax + this.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 2;
				}
				else
				{
					this.vx = this.vMax + this.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 3;
				}
			}
			else
			{
				this.vx = this.toX - this.x;
			}
		}
		else if (CRes.abs(this.y - this.toY) > this.vMax + this.getVmount())
		{
			this.vx = 0;
			this.Action = 1;
			if (CRes.abs(this.y - this.toY) > this.vMax + this.getVmount())
			{
				if (this.y > this.toY)
				{
					this.vy = -(this.vMax + this.getVmount());
					this.PrevDir = this.Direction;
					this.Direction = 1;
				}
				else
				{
					this.vy = this.vMax + this.getVmount();
					this.PrevDir = this.Direction;
					this.Direction = 0;
				}
			}
			else
			{
				this.vy = this.toY - this.y;
			}
		}
		else
		{
			if (this.isDetonateInDest)
			{
				GameScreen.addEffectEndKill(43, this.x, this.y);
				LoadMap.timeVibrateScreen = 10;
				this.isStop = true;
			}
			this.vx = 0;
			this.vy = 0;
		}
	}

	// Token: 0x0600041B RID: 1051 RVA: 0x0003B2F4 File Offset: 0x000394F4
	public static MainObject get_Object(int ID, sbyte tem)
	{
		for (int i = GameScreen.Vecplayers.size() - 1; i >= 0; i--)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null)
			{
				if ((int)tem == 2 && mainObject.getIDnpc() == ID)
				{
					return mainObject;
				}
				if ((int)mainObject.typeObject == (int)tem && mainObject.ID == ID)
				{
					return mainObject;
				}
			}
		}
		return null;
	}

	// Token: 0x0600041C RID: 1052 RVA: 0x0003B368 File Offset: 0x00039568
	public static MainObject get_Item_Object(int ID, int typeItem)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if ((int)mainObject.typeObject == typeItem && mainObject.ID == ID)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600041D RID: 1053 RVA: 0x0003B3C0 File Offset: 0x000395C0
	public static MainObject get_Item_Object(int ID)
	{
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject.ID == ID)
			{
				return mainObject;
			}
		}
		return null;
	}

	// Token: 0x0600041E RID: 1054 RVA: 0x0003B408 File Offset: 0x00039608
	public static int getDistance(int x, int y, int x2, int y2)
	{
		return MainObject.getDistance(x - x2, y - y2);
	}

	// Token: 0x0600041F RID: 1055 RVA: 0x0003B418 File Offset: 0x00039618
	public static int getDistance(int x, int y)
	{
		return CRes.sqrt(x * x + y * y);
	}

	// Token: 0x06000420 RID: 1056 RVA: 0x0003B428 File Offset: 0x00039628
	public void setMove(bool isAutomove)
	{
		if (this.isMoveOut)
		{
			return;
		}
		int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
		if (tile == 2 && !this.isMountFly())
		{
			if (this.vy != 0)
			{
				if (this.vy > 0)
				{
					this.vy = this.vMax + this.getVmount() - 1;
				}
				else
				{
					this.vy = -(this.vMax + this.getVmount()) + 1;
				}
			}
			if (this.vx != 0)
			{
				if (this.vx > 0)
				{
					this.vx = this.vMax + this.getVmount() - 1;
				}
				else
				{
					this.vx = -(this.vMax + this.getVmount()) + 1;
				}
			}
			this.isWater = true;
			this.dyWater = 3;
		}
		else
		{
			this.isWater = false;
			this.dyWater = 0;
			if (tile == 1)
			{
				if (isAutomove)
				{
					this.setAutoMoveNear();
				}
				else
				{
					this.Action = 0;
					this.frameLeg = CRes.random(4);
					this.vx = 0;
					this.vy = 0;
				}
			}
			if (GameCanvas.loadmap.getTile(this.x, this.y) == 2 && !this.isMountFly())
			{
				this.isWater = true;
				this.dyWater = 3;
			}
		}
		if (this.vx == 0 && this.vy == 0)
		{
			int tile2 = GameCanvas.loadmap.getTile(this.x, this.y);
			if (tile2 == 1 || tile2 == -1)
			{
				int num = 24;
				int num2 = this.x * 1000;
				int num3 = this.y * 1000;
				int num4 = 0;
				bool flag;
				do
				{
					flag = false;
					int num5 = num2 + CRes.cos(num4) * num;
					int num6 = num3 + CRes.sin(num4) * num;
					if (num5 >= 0 && num6 >= 0)
					{
						int tile3 = GameCanvas.loadmap.getTile(num5 / 1000, num6 / 1000);
						if (tile3 == 0 || tile3 == 2)
						{
							this.x = num5 / 1000;
							this.y = num6 / 1000;
							this.resetAction();
							flag = true;
						}
					}
					num4 += 44;
					if (num4 >= 360)
					{
						num4 = 0;
						num += 24;
					}
				}
				while (!flag);
			}
		}
	}

	// Token: 0x06000421 RID: 1057 RVA: 0x0003B694 File Offset: 0x00039894
	public void setAutoMoveNear()
	{
		int num = GameCanvas.loadmap.getIndex(this.x + this.vx, this.y + this.vy);
		if (this.vy != 0)
		{
			if (num % GameCanvas.loadmap.mapW > 0 && (GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y + this.vy) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y + this.vy) == 2) && (GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx - LoadMap.wTile, this.y) == 2))
			{
				this.vx = -(this.vMax + this.getVmount());
				this.Direction = 2;
				this.vy = 0;
			}
			else if (num % GameCanvas.loadmap.mapW < GameCanvas.loadmap.mapW - 1 && (GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y + this.vy) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y + this.vy) == 2) && (GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx + LoadMap.wTile, this.y) == 2))
			{
				this.vx = this.vMax + this.getVmount();
				this.Direction = 3;
				this.vy = 0;
			}
			else
			{
				this.vy = 0;
			}
		}
		else if (this.vx != 0)
		{
			if ((GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy - LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(this.x, this.y + this.vy - LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x, this.y + this.vy - LoadMap.wTile) == 2))
			{
				this.vy = -(this.vMax + this.getVmount());
				this.Direction = 1;
				this.vx = 0;
			}
			else if ((GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy + LoadMap.wTile) == 2) && (GameCanvas.loadmap.getTile(this.x, this.y + this.vy + LoadMap.wTile) == 0 || GameCanvas.loadmap.getTile(this.x, this.y + this.vy + LoadMap.wTile) == 2))
			{
				this.vy = this.vMax + this.getVmount();
				this.Direction = 0;
				this.vx = 0;
			}
			else
			{
				this.vx = 0;
			}
		}
		if (this.vx == 0 && this.vy == 0)
		{
			this.Action = 0;
			this.frameLeg = CRes.random(4);
		}
	}

	// Token: 0x06000422 RID: 1058 RVA: 0x0003BAA4 File Offset: 0x00039CA4
	public void setSpeed(int max)
	{
		switch (this.Direction)
		{
		case 0:
			this.vy = max;
			this.vx = 0;
			break;
		case 1:
			this.vy = -max;
			this.vx = 0;
			break;
		case 2:
			this.vy = 0;
			this.vx = -max;
			break;
		case 3:
			this.vy = 0;
			this.vx = max;
			break;
		}
	}

	// Token: 0x06000423 RID: 1059 RVA: 0x0003BB24 File Offset: 0x00039D24
	public void setSpeedInDirection(int max)
	{
		int a = CRes.random_Am_0(3);
		if (CRes.abs(a) > 1)
		{
			max--;
		}
		switch (this.Direction)
		{
		case 0:
			this.vy = max;
			this.vx = a;
			break;
		case 1:
			this.vy = -max;
			this.vx = a;
			break;
		case 2:
			this.vy = a;
			this.vx = -max;
			break;
		case 3:
			this.vy = a;
			this.vx = max;
			break;
		}
		if (this.vx == 0 && CRes.random(3) == 0)
		{
			this.time = 0;
			this.Action = 0;
			this.vx = 0;
			this.vy = 0;
		}
		if (this.vx > 0)
		{
			this.Direction = 3;
		}
		else
		{
			this.Direction = 2;
		}
	}

	// Token: 0x06000424 RID: 1060 RVA: 0x0003BC0C File Offset: 0x00039E0C
	public bool setIsInScreen(int x, int y, int wOne, int hOne)
	{
		return x >= MainScreen.cameraMain.xCam - wOne && x <= MainScreen.cameraMain.xCam + GameCanvas.w + wOne && y >= MainScreen.cameraMain.yCam - hOne / 2 && y <= MainScreen.cameraMain.yCam + GameCanvas.h + hOne * 3 / 2;
	}

	// Token: 0x06000425 RID: 1061 RVA: 0x0003BC78 File Offset: 0x00039E78
	public static bool isInScreen(MainObject obj)
	{
		return obj.x >= MainScreen.cameraMain.xCam - obj.wOne && obj.x <= MainScreen.cameraMain.xCam + GameCanvas.w + obj.wOne && obj.y >= MainScreen.cameraMain.yCam - obj.hOne && obj.y <= MainScreen.cameraMain.yCam + GameCanvas.h + obj.hOne * 3 / 2;
	}

	// Token: 0x06000426 RID: 1062 RVA: 0x0003BD08 File Offset: 0x00039F08
	public virtual void Move_to_Focus_Person()
	{
		if (this.x == this.toX && this.y == this.toY)
		{
			return;
		}
		if (this.isMoveOut)
		{
			return;
		}
		if (this.iscuop)
		{
			int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
			if (tile == 1 || tile == -1)
			{
				this.isWater = false;
				this.dyWater = 0;
				this.vx = 0;
				this.vy = 0;
				this.x = this.toX;
				this.y = this.toY;
				this.timeFreeMove++;
				if (this.timeFreeMove >= 10)
				{
					this.timeFreeMove = 25;
				}
				GameScreen.addEffectEndKill(35, this.x, this.y - 20);
			}
		}
		if (CRes.abs(this.x - this.toX) > this.vMax + this.getVmount() || CRes.abs(this.y - this.toY) > this.vMax + this.getVmount())
		{
			this.move_to_XY_Normal();
		}
		else if (this.Action != 2 && this.Action != 3 && this.Action != 4)
		{
			this.xFire = this.x;
			this.yFire = this.y;
			this.toX = this.x;
			this.toY = this.y;
			this.vx = 0;
			this.vy = 0;
			this.Action = 0;
			this.frameLeg = CRes.random(4);
		}
	}

	// Token: 0x06000427 RID: 1063 RVA: 0x0003BEB8 File Offset: 0x0003A0B8
	public virtual void move_to_XY_Normal()
	{
		if (this.isMoveOut)
		{
			return;
		}
		if (this.isDirMove)
		{
			if (CRes.abs(this.x - this.toX) >= this.vMax + this.getVmount())
			{
				this.moveX();
			}
			else if (CRes.abs(this.y - this.toY) >= this.vMax + this.getVmount())
			{
				this.moveY();
			}
			else
			{
				this.vx = 0;
				this.vy = 0;
			}
		}
		else if (CRes.abs(this.y - this.toY) >= this.vMax + this.getVmount())
		{
			this.moveY();
		}
		else if (CRes.abs(this.x - this.toX) >= this.vMax + this.getVmount())
		{
			this.moveX();
		}
		else
		{
			this.vx = 0;
			this.vy = 0;
		}
	}

	// Token: 0x06000428 RID: 1064 RVA: 0x0003BFBC File Offset: 0x0003A1BC
	public virtual void moveX()
	{
		if (this.isMoveOut)
		{
			return;
		}
		this.vy = 0;
		this.Action = 1;
		if (CRes.abs(this.x - this.toX) >= this.vMax + this.getVmount())
		{
			if (this.x >= this.toX)
			{
				this.vx = -(this.vMax + this.getVmount());
				this.Direction = 2;
			}
			else
			{
				this.vx = this.vMax + this.getVmount();
				this.Direction = 3;
			}
		}
		else
		{
			this.vx = this.toX - this.x;
		}
	}

	// Token: 0x06000429 RID: 1065 RVA: 0x0003C06C File Offset: 0x0003A26C
	public virtual void moveY()
	{
		if (this.isMoveOut)
		{
			return;
		}
		this.vx = 0;
		this.Action = 1;
		if (CRes.abs(this.y - this.toY) >= this.vMax + this.getVmount())
		{
			if (this.y > this.toY)
			{
				this.vy = -(this.vMax + this.getVmount());
				this.Direction = 1;
			}
			else
			{
				this.vy = this.vMax + this.getVmount();
				this.Direction = 0;
			}
		}
		else
		{
			this.vy = this.toY - this.y;
		}
	}

	// Token: 0x0600042A RID: 1066 RVA: 0x0003C11C File Offset: 0x0003A31C
	public void setMove(int MonWater, int t)
	{
		if (this.isMoveOut || this.isBinded || this.isDongBang)
		{
			return;
		}
		if ((t == 1 || t == -1) && this.timeFreeMove < 12)
		{
			this.isWater = false;
			this.dyWater = 0;
			this.vx = 0;
			this.vy = 0;
			this.isDirMove = !this.isDirMove;
			this.timeFreeMove++;
			if (this.timeFreeMove >= 10)
			{
				this.timeFreeMove = 25;
			}
		}
		else
		{
			this.isWater = false;
			this.dyWater = 0;
			if (this.timeFreeMove > 0)
			{
				this.timeFreeMove--;
			}
			if (t == 2 && !this.isMountFly())
			{
				this.isWater = true;
				this.dyWater = 3;
				if (this.vy != 0)
				{
					if (this.vy > 0)
					{
						this.vy = this.vMax + this.getVmount() - MonWater;
					}
					else
					{
						this.vy = -(this.vMax + this.getVmount()) + MonWater;
					}
				}
				if (this.vx != 0)
				{
					if (this.vx > 0)
					{
						this.vx = this.vMax + this.getVmount() - MonWater;
					}
					else
					{
						this.vx = -(this.vMax + this.getVmount()) + MonWater;
					}
				}
			}
		}
	}

	// Token: 0x0600042B RID: 1067 RVA: 0x0003C290 File Offset: 0x0003A490
	public static void init()
	{
		for (int i = 0; i < MainObject.imgWeapone.Length; i++)
		{
			MainObject.imgWeapone[i] = new WeaponInfo[40][];
			for (int j = 0; j < MainObject.imgWeapone[i].Length; j++)
			{
				MainObject.imgWeapone[i][j] = new WeaponInfo[8];
			}
		}
	}

	// Token: 0x0600042C RID: 1068 RVA: 0x0003C2EC File Offset: 0x0003A4EC
	public void paintWeaponhideplayer(mGraphics g, int f)
	{
		int num = 0;
		if (num < 0 || num >= 5)
		{
			return;
		}
		int num2 = (int)this.clazz;
		int num3 = 0;
		int num4 = 0;
		if (this.Action != 2)
		{
			num4 = 0;
		}
		if (this.weapon_frame >= 0 && num >= 0)
		{
			WPSplashInfo wpsplashInfo = CRes.wpSplashInfos[num2][num][num4];
			if (wpsplashInfo == null)
			{
				wpsplashInfo = CRes.GetWPSplashInfo(num2, num, num4);
				return;
			}
			int num5 = 0;
			if (this.Action != 2 || this.weapon_frame < 4)
			{
				if (this.weapon_frame > 1)
				{
					this.weapon_frame = 0;
				}
				if (this.weapon_frame < 0)
				{
					this.weapon_frame = 0;
				}
				if (num5 != -1 && CRes.loadImgWeaPone(num2, num5, num3) != null)
				{
					WeaponInfo weaponInfo = CRes.loadImgWeaPone(num2, num5, num3);
					int num6 = this.frame;
					if (num6 > 2)
					{
						num6 = 2;
					}
					if (weaponInfo.img != null)
					{
						g.drawRegion(weaponInfo.img, (int)weaponInfo.mRegion[this.Direction][0], 0, (int)weaponInfo.mRegion[this.Direction][1], weaponInfo.himg, 0, this.x + (int)weaponInfo.mPos[this.Direction][num6][0], this.y - this.ysai + (int)weaponInfo.mPos[this.Direction][num6][1] - this.dy + this.dyWater - this.dyMount - this.yjum, 0, mGraphics.isTrue);
						this.paintEffectWeapon(g);
					}
				}
			}
			else if (this.weapon_frame < wpsplashInfo.P0_X[this.Direction].Length && wpsplashInfo.image != null)
			{
				g.drawRegion(wpsplashInfo.image, wpsplashInfo.P0_X[this.Direction][this.weapon_frame], wpsplashInfo.P0_Y[this.Direction][this.weapon_frame], wpsplashInfo.PF_W[this.Direction][this.weapon_frame], wpsplashInfo.PF_H[this.Direction][this.weapon_frame], 0, this.x + wpsplashInfo.PF_X[this.Direction][this.weapon_frame], f + this.y - this.ysai + wpsplashInfo.PF_Y[this.Direction][this.weapon_frame] - this.dy + this.dyWater - this.dyMount - this.yjum, 0, mGraphics.isTrue);
			}
			if (this.Action == 0 || this.Action == 1)
			{
				int num7 = 0;
				if (num7 > 1)
				{
					int num8 = num7 - 1;
					if (num8 > 3)
					{
						num8 = 3;
					}
					this.paintEffectVukhi(g, num8, wpsplashInfo, num2);
				}
			}
		}
	}

	// Token: 0x0600042D RID: 1069 RVA: 0x0003C5A8 File Offset: 0x0003A7A8
	public void paintWeapon(mGraphics g, int f)
	{
		int num = 0;
		if (num < 0 || num >= 5)
		{
			return;
		}
		int num2 = (int)this.clazz;
		int num3 = 0;
		int num4 = 0;
		if (this.Action != 2)
		{
			num4 = 0;
		}
		if (this.weapon_frame >= 0 && num >= 0)
		{
			WPSplashInfo wpsplashInfo = CRes.wpSplashInfos[num2][num][num4];
			if (wpsplashInfo == null)
			{
				wpsplashInfo = CRes.GetWPSplashInfo(num2, num, num4);
				return;
			}
			int num5 = this.weaponType;
			if (this.Action != 2 || this.weapon_frame < 4)
			{
				if (this.weapon_frame > 1)
				{
					this.weapon_frame = 0;
				}
				if (this.weapon_frame < 0)
				{
					this.weapon_frame = 0;
				}
				if (num5 != -1 && CRes.loadImgWeaPone(num2, num5, num3) != null)
				{
					WeaponInfo weaponInfo = CRes.loadImgWeaPone(num2, num5, num3);
					int num6 = this.frame;
					if (num6 > 2)
					{
						num6 = 2;
					}
					if (weaponInfo.img != null)
					{
						g.drawRegion(weaponInfo.img, (int)weaponInfo.mRegion[this.Direction][0], 0, (int)weaponInfo.mRegion[this.Direction][1], weaponInfo.himg, 0, this.x + (int)weaponInfo.mPos[this.Direction][num6][0], this.y - this.ysai + (int)weaponInfo.mPos[this.Direction][num6][1] - this.dy + this.dyWater - this.dyMount - this.yjum, 0, mGraphics.isTrue);
						this.paintEffectWeapon(g);
					}
				}
			}
			else if (this.weapon_frame < wpsplashInfo.P0_X[this.Direction].Length && wpsplashInfo.image != null)
			{
				g.drawRegion(wpsplashInfo.image, wpsplashInfo.P0_X[this.Direction][this.weapon_frame], wpsplashInfo.P0_Y[this.Direction][this.weapon_frame], wpsplashInfo.PF_W[this.Direction][this.weapon_frame], wpsplashInfo.PF_H[this.Direction][this.weapon_frame], 0, this.x + wpsplashInfo.PF_X[this.Direction][this.weapon_frame], f + this.y - this.ysai + wpsplashInfo.PF_Y[this.Direction][this.weapon_frame] - this.dy + this.dyWater - this.dyMount - this.yjum, 0, mGraphics.isTrue);
			}
			if (this.Action == 0 || this.Action == 1)
			{
				int num7 = 0;
				if (num7 > 1)
				{
					int num8 = num7 - 1;
					if (num8 > 3)
					{
						num8 = 3;
					}
					this.paintEffectVukhi(g, num8, wpsplashInfo, num2);
				}
			}
		}
	}

	// Token: 0x0600042E RID: 1070 RVA: 0x0003C868 File Offset: 0x0003AA68
	private void paintEffectVukhi(mGraphics g, int id, WPSplashInfo wp, int clazz)
	{
	}

	// Token: 0x0600042F RID: 1071 RVA: 0x0003C86C File Offset: 0x0003AA6C
	public void resetXY()
	{
		this.toX = this.x;
		this.toY = this.y;
		this.vx = 0;
		this.vy = 0;
	}

	// Token: 0x06000430 RID: 1072 RVA: 0x0003C8A0 File Offset: 0x0003AAA0
	public virtual void beginFire()
	{
		this.f = 0;
		this.Action = 2;
		this.fplash = 0;
		this.vx = 0;
		this.vy = 0;
	}

	// Token: 0x06000431 RID: 1073 RVA: 0x0003C8C8 File Offset: 0x0003AAC8
	public static void startDeadFly(MainMonster m, int attacker, int typeDie)
	{
		MainObject mainObject = MainObject.get_Object(attacker, 0);
		if (mainObject == null)
		{
			return;
		}
		int num = 5;
		int vyStyle = 0;
		if (m != null)
		{
			int num2 = 0;
			int num3 = 0;
			if (m.typeMonster != 7 && mainObject != null)
			{
				num2 = (m.x - mainObject.x) * 2;
				num3 = (m.y - mainObject.y) * 2;
				while (MainObject.getDistance(num2, num3) > 20)
				{
					num2 = num2 * 2 / 3;
					num3 = num3 * 2 / 3;
				}
				if (typeDie == 1)
				{
					num2 *= 2;
					num3 *= 2;
				}
				else if (typeDie == 2)
				{
					while (MainObject.getDistance(num2, num3) > 16)
					{
						num2 = num2 * 2 / 3;
						num3 = num3 * 2 / 3;
					}
					num = 20;
					vyStyle = 18;
				}
			}
			m.startDeadFly(num2, num3, num, vyStyle);
		}
	}

	// Token: 0x06000432 RID: 1074 RVA: 0x0003C998 File Offset: 0x0003AB98
	public virtual void GiaoTiep()
	{
	}

	// Token: 0x06000433 RID: 1075 RVA: 0x0003C99C File Offset: 0x0003AB9C
	public void addChat(string str, bool isStop)
	{
		if (this.chat == null)
		{
			this.chat = new PopupChat();
		}
		this.chat.setChat(str, isStop);
		this.chat.updatePos(this.x, this.y - this.hOne - 30);
	}

	// Token: 0x06000434 RID: 1076 RVA: 0x0003C9F0 File Offset: 0x0003ABF0
	public void resetAction()
	{
		this.vx = (this.vy = 0);
		this.toX = this.x;
		this.toY = this.y;
		if (this.Action != 2 && this.Action != 4)
		{
			this.Action = 0;
			this.weapon_frame = 0;
		}
	}

	// Token: 0x06000435 RID: 1077 RVA: 0x0003CA4C File Offset: 0x0003AC4C
	public void resetVx_vy()
	{
		this.vx = (this.vy = 0);
		if (this.Action == 1)
		{
			this.Action = 0;
		}
	}

	// Token: 0x06000436 RID: 1078 RVA: 0x0003CA7C File Offset: 0x0003AC7C
	public static void resetDirection(MainObject idFrom, MainObject idTo)
	{
		int num = idFrom.x - idTo.x;
		int num2 = idFrom.y - idTo.y;
		int direction;
		if (CRes.abs(num) > CRes.abs(num2))
		{
			if (num > 0)
			{
				direction = 2;
			}
			else
			{
				direction = 3;
			}
		}
		else if (num2 > 0)
		{
			direction = 1;
		}
		else
		{
			direction = 0;
		}
		idFrom.Direction = direction;
	}

	// Token: 0x06000437 RID: 1079 RVA: 0x0003CAE4 File Offset: 0x0003ACE4
	public void addnewBuff(int type, int time)
	{
		for (int i = 0; i < this.vecBuff.size(); i++)
		{
			MainBuff mainBuff = (MainBuff)this.vecBuff.elementAt(i);
			if (mainBuff != null && mainBuff.typeBuff == type)
			{
				mainBuff.settimebuff((long)time);
				return;
			}
		}
		MainBuff o = new MainBuff(type, time);
		this.vecBuff.addElement(o);
	}

	// Token: 0x06000438 RID: 1080 RVA: 0x0003CB50 File Offset: 0x0003AD50
	public void addBuff(int type, int time, int sub)
	{
		MainBuff mainBuff = MainBuff.getBuff(type, sub);
		if (mainBuff != null)
		{
			mainBuff.timeBegin = GameCanvas.timeNow;
			mainBuff.timeOff = time;
		}
		else
		{
			mainBuff = new MainBuff(type, time, sub);
			this.vecBuff.addElement(mainBuff);
		}
	}

	// Token: 0x06000439 RID: 1081 RVA: 0x0003CB98 File Offset: 0x0003AD98
	public void setEye(int eye)
	{
		this.eye = eye;
		this.timeEye = 0;
	}

	// Token: 0x0600043A RID: 1082 RVA: 0x0003CBA8 File Offset: 0x0003ADA8
	public int skillMonster()
	{
		return 0;
	}

	// Token: 0x0600043B RID: 1083 RVA: 0x0003CBAC File Offset: 0x0003ADAC
	public void startDie()
	{
	}

	// Token: 0x0600043C RID: 1084 RVA: 0x0003CBB0 File Offset: 0x0003ADB0
	public mVector vectorObjectNear()
	{
		mVector mVector = new mVector("MainObject vec");
		int num = 30;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if (mainObject != null && mainObject != GameScreen.player && mainObject != this && (int)mainObject.typeObject == 0)
			{
				int distance = MainObject.getDistance(this.x, this.y, mainObject.x, mainObject.y - mainObject.hOne / 2);
				if (distance <= num)
				{
					mVector.addElement(mainObject);
				}
			}
		}
		return mVector;
	}

	// Token: 0x0600043D RID: 1085 RVA: 0x0003CC58 File Offset: 0x0003AE58
	public void setVx_Vy_Item(int xto, int yto)
	{
		this.toX = xto;
		this.toY = yto;
		int num = this.toX - this.x;
		int num2 = this.toY - this.y;
		if (num2 == 0)
		{
			num2 = 1;
		}
		if (num == 0)
		{
			num = 1;
		}
		int num3 = MainObject.getDistance(num, num2) / (this.vMax + this.getVmount());
		if (num3 == 0)
		{
			num3 = 1;
		}
		this.vx = num / num3;
		this.vy = num2 / num3;
		if (CRes.abs(this.vx) > CRes.abs(num))
		{
			this.vx = num;
		}
		if (CRes.abs(this.vy) > CRes.abs(num2))
		{
			this.vy = num2;
		}
		this.timeHuyKill = num3;
	}

	// Token: 0x0600043E RID: 1086 RVA: 0x0003CD10 File Offset: 0x0003AF10
	public virtual bool isThacNuoc()
	{
		return false;
	}

	// Token: 0x0600043F RID: 1087 RVA: 0x0003CD14 File Offset: 0x0003AF14
	public virtual bool findOwner(MainObject owner)
	{
		return false;
	}

	// Token: 0x06000440 RID: 1088 RVA: 0x0003CD18 File Offset: 0x0003AF18
	public virtual bool isMonsterHouse()
	{
		return false;
	}

	// Token: 0x06000441 RID: 1089 RVA: 0x0003CD1C File Offset: 0x0003AF1C
	public virtual bool isItemBox()
	{
		return false;
	}

	// Token: 0x06000442 RID: 1090 RVA: 0x0003CD20 File Offset: 0x0003AF20
	public virtual bool isNPC()
	{
		return (int)this.isBot >= -100 && (int)this.isBot < -2;
	}

	// Token: 0x06000443 RID: 1091 RVA: 0x0003CD40 File Offset: 0x0003AF40
	public virtual int getIDnpc()
	{
		return this.ID;
	}

	// Token: 0x06000444 RID: 1092 RVA: 0x0003CD48 File Offset: 0x0003AF48
	public virtual bool canFocus()
	{
		return true;
	}

	// Token: 0x06000445 RID: 1093 RVA: 0x0003CD4C File Offset: 0x0003AF4C
	public virtual bool isNPC_server()
	{
		return false;
	}

	// Token: 0x06000446 RID: 1094 RVA: 0x0003CD50 File Offset: 0x0003AF50
	public void paint_no(mGraphics g)
	{
		if (this.isPaint_No)
		{
			this.frNo++;
			if (this.frNo > this.frameNo.Length - 1)
			{
				this.frNo = 0;
			}
			AvMain.fraPlayerNo.drawFrame(this.frameNo[this.frNo], this.x, this.y + 5, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x06000447 RID: 1095 RVA: 0x0003CDC4 File Offset: 0x0003AFC4
	public void move_to_point()
	{
		if (this.isMoveOut)
		{
			if (this.ID == GameScreen.player.ID)
			{
				GameCanvas.clearAll();
				this.posTransRoad = null;
			}
			this.vx = 0;
			this.vy = 0;
			bool flag = false;
			int num = this.yMoveOut - this.y >> 1;
			this.y += num;
			if (num <= 0)
			{
				this.y = this.yMoveOut;
				flag = true;
			}
			if (flag)
			{
				this.vx = 0;
				this.vy = 0;
				this.Action = 0;
				this.toX = this.x;
				this.toY = this.y;
				this.yMoveOut = this.y;
				this.yMoveOut = this.y;
				this.xStand = this.x;
				this.yStand = this.y;
				this.isMoveOut = false;
				return;
			}
			if (GameCanvas.loadmap.getTile(this.x, this.y) == 2 && !this.isMountFly())
			{
				this.isWater = true;
				this.dyWater = 3;
			}
			if (GameCanvas.gameTick % 2 == 0)
			{
				GameScreen.addEffectEndKill(9, this.x, this.y);
				GameScreen.addEffectEndKill(46, this.x, this.y - 2);
			}
		}
	}

	// Token: 0x06000448 RID: 1096 RVA: 0x0003CF18 File Offset: 0x0003B118
	public int getVmount()
	{
		if ((int)this.typeMount == -1)
		{
			return 0;
		}
		return (int)MountTemplate.speed[(int)this.typeMount];
	}

	// Token: 0x06000449 RID: 1097 RVA: 0x0003CF38 File Offset: 0x0003B138
	public bool isFramePaintMount_Truoc()
	{
		if ((int)this.typeMount == -1)
		{
			return false;
		}
		sbyte[] array = MountTemplate.FRAME_VE_TRUOC[(int)this.typeMount];
		for (int i = 0; i < array.Length; i++)
		{
			if ((int)this.frameMount == (int)array[i] && (int)this.frameMount != -1)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600044A RID: 1098 RVA: 0x0003CF98 File Offset: 0x0003B198
	public virtual void updateMount()
	{
		if ((int)this.typeMount == -1)
		{
			return;
		}
		DataSkillEff effMatNa = MainObject.getEffMatNa((int)this.idHorse);
		if (effMatNa != null && GameCanvas.gameTick % 5 == 0)
		{
			int num = effMatNa.listFrame.size() / 21;
			if (num == 0)
			{
				num = 1;
			}
			this.frameThuCuoi = (int)((sbyte)((this.frameThuCuoi + 1) % num));
		}
		if ((int)this.typeMount != -1)
		{
			if (effMatNa == null)
			{
				this.A_Move = MainObject.ArrMount;
			}
			if (this.Action == 0)
			{
				if (this.Direction == 2)
				{
					if (this.frame == 1)
					{
						this.frameMount = 1;
					}
					else
					{
						this.frameMount = 0;
					}
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][0];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][0];
					this.dyMount = (int)MountTemplate.DY_CHAR_STAND[(int)this.typeMount][0];
				}
				else if (this.Direction == 3)
				{
					if (this.frame == 1)
					{
						this.frameMount = 1;
					}
					else
					{
						this.frameMount = 0;
					}
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][2];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][2];
					this.dyMount = (int)MountTemplate.DY_CHAR_STAND[(int)this.typeMount][1];
				}
				else if (this.Direction == 1)
				{
					if (this.frame == 1)
					{
						this.frameMount = 11;
					}
					else
					{
						this.frameMount = 10;
					}
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][4];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][4];
					this.dyMount = (int)MountTemplate.DY_CHAR_STAND[(int)this.typeMount][2];
				}
				else
				{
					if (this.frame == 1)
					{
						this.frameMount = 6;
					}
					else
					{
						this.frameMount = 5;
					}
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][6];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][6];
					this.dyMount = (int)MountTemplate.DY_CHAR_STAND[(int)this.typeMount][3];
				}
			}
			else if (this.Action == 1)
			{
				this.fMount += 1;
				if (this.Direction == 2)
				{
					if ((int)this.fMount > MountTemplate.FRAME_MOVE_LR[(int)this.typeMount].Length - 1)
					{
						this.fMount = 0;
					}
					this.frameMount = MountTemplate.FRAME_MOVE_LR[(int)this.typeMount][(int)this.fMount];
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][1];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][1];
					if ((int)this.frameMount == 3)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][0];
					}
					else if ((int)this.frameMount == 2)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][1];
					}
					else
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][2];
					}
					if ((int)this.fMount == 4 && !this.isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, this.x + 19, this.y - 5, this.Direction, -1);
					}
				}
				else if (this.Direction == 3)
				{
					if ((int)this.fMount > MountTemplate.FRAME_MOVE_LR[(int)this.typeMount].Length - 1)
					{
						this.fMount = 0;
					}
					this.frameMount = MountTemplate.FRAME_MOVE_LR[(int)this.typeMount][(int)this.fMount];
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][3];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][3];
					if ((int)this.frameMount == 3)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][3];
					}
					else if ((int)this.frameMount == 2)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][4];
					}
					else
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][5];
					}
					if ((int)this.fMount == 4 && !this.isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, this.x - 11, this.y - 5, this.Direction, -1);
					}
				}
				else if (this.Direction == 1)
				{
					if ((int)this.fMount > MountTemplate.FRAME_MOVE_UP[(int)this.typeMount].Length - 1)
					{
						this.fMount = 0;
					}
					this.frameMount = MountTemplate.FRAME_MOVE_UP[(int)this.typeMount][(int)this.fMount];
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][5];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][5];
					if ((int)this.frameMount == 13)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][6];
					}
					else if ((int)this.frameMount == 12)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][7];
					}
					else
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][8];
					}
					if ((int)this.fMount == 4 && !this.isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, this.x - 14, this.y - 7, 3, -1);
						GameScreen.addEffectEndKill_Direction(55, this.x + 16, this.y - 7, 2, -1);
					}
				}
				else
				{
					if ((int)this.fMount > MountTemplate.FRAME_MOVE_DOWN[(int)this.typeMount].Length - 1)
					{
						this.fMount = 0;
					}
					this.frameMount = MountTemplate.FRAME_MOVE_DOWN[(int)this.typeMount][(int)this.fMount];
					this.xMount = (int)MountTemplate.dx[(int)this.typeMount][7];
					this.yMount = (int)MountTemplate.dy[(int)this.typeMount][7];
					if ((int)this.frameMount == 8)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][9];
					}
					else if ((int)this.frameMount == 7)
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][10];
					}
					else
					{
						this.dyMount = (int)MountTemplate.DY_CHAR_MOVE[(int)this.typeMount][11];
					}
					if ((int)this.fMount == 4 && !this.isMountFly())
					{
						GameScreen.addEffectEndKill_Direction(55, this.x - 15, this.y - 10, 3, -1);
						GameScreen.addEffectEndKill_Direction(55, this.x + 17, this.y - 10, 2, -1);
					}
				}
			}
		}
		else
		{
			this.resetMount();
		}
	}

	// Token: 0x0600044B RID: 1099 RVA: 0x0003D68C File Offset: 0x0003B88C
	public void resetMount()
	{
		this.A_Move = MainObject.ArrMount1;
		this.dyMount = 0;
	}

	// Token: 0x0600044C RID: 1100 RVA: 0x0003D6A0 File Offset: 0x0003B8A0
	public void paintMount_Truoc(mGraphics g)
	{
		if (this.idHorse != -1)
		{
			return;
		}
		if ((int)this.typeMount == -1)
		{
			return;
		}
		if (this.isDongBang)
		{
			return;
		}
		FrameImage frameImageMount = FrameImage.getFrameImageMount((short)this.typeMount, 3, 5, 0);
		if (frameImageMount != null && this.isFramePaintMount_Truoc())
		{
			frameImageMount.drawFrameNew((int)this.frameMount, this.x + this.xMount, this.y - this.ysai - this.dy + this.dyWater - this.yjum + this.yMount, (this.Direction <= 2) ? 0 : 2, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x0600044D RID: 1101 RVA: 0x0003D758 File Offset: 0x0003B958
	public void paintMount_Sau(mGraphics g)
	{
		if (this.idHorse != -1)
		{
			return;
		}
		if ((int)this.typeMount == -1)
		{
			return;
		}
		if (this.isDongBang)
		{
			return;
		}
		FrameImage frameImageMount = FrameImage.getFrameImageMount((short)this.typeMount, 3, 5, 0);
		if (frameImageMount != null && !this.isFramePaintMount_Truoc())
		{
			frameImageMount.drawFrameNew((int)this.frameMount, this.x + this.xMount, this.y - this.ysai - this.dy + this.dyWater - this.yjum + this.yMount, (this.Direction <= 2) ? 0 : 2, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x0600044E RID: 1102 RVA: 0x0003D810 File Offset: 0x0003BA10
	public void setArrayGemKham(short[][] array)
	{
		this.arrayGemKham = array;
		int num = (int)this.clazz;
		if (num == 3)
		{
			num = 2;
		}
		else if (num == 2)
		{
			num = 3;
		}
		this.slotGem = new sbyte[this.arrayGemKham[8 + num].Length];
		for (int i = 0; i < this.arrayGemKham.Length; i++)
		{
			for (int j = 0; j < this.arrayGemKham[i].Length; j++)
			{
				if (this.arrayGemKham[8 + num][j] >= 23 && this.arrayGemKham[8 + num][j] <= 27)
				{
					this.slotGem[j] = 0;
				}
				else if (this.arrayGemKham[8 + num][j] >= 28 && this.arrayGemKham[8 + num][j] <= 32)
				{
					this.slotGem[j] = 1;
				}
				else
				{
					this.slotGem[j] = -1;
				}
			}
		}
	}

	// Token: 0x0600044F RID: 1103 RVA: 0x0003D900 File Offset: 0x0003BB00
	private void paintEffectWeapon(mGraphics g)
	{
		if (this.weaponEff != null)
		{
			this.weaponEff.drawFrameEffectSkill((int)this.fweapon, this.x + this.dxEff, this.y - this.ysai + this.dyEff - this.dy + this.dyWater - this.dyMount - this.yjum, (int)this.transEff[this.Direction], mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
	}

	// Token: 0x06000450 RID: 1104 RVA: 0x0003D984 File Offset: 0x0003BB84
	private void updateEffectWeapon()
	{
		if (GameCanvas.gameTick % 2 == 0)
		{
			this.fweapon += 1;
		}
		if ((int)this.fweapon > 4)
		{
			this.fweapon = 0;
		}
		this.timeEff++;
		if (this.timeEff < (int)this.timeShow)
		{
			if ((int)this.slotGem[0] == -1)
			{
				if (this.weaponEff != null)
				{
					this.weaponEff = null;
				}
				if ((int)this.fweapon != 0)
				{
					this.fweapon = 0;
				}
			}
			else
			{
				this.weaponEff = MainObject.weaponEff_Gem[(int)this.slotGem[0]];
			}
		}
		else if (this.timeEff >= (int)this.timeShow * 2 && this.timeEff < (int)this.timeShow * 3)
		{
			if ((int)this.slotGem[1] == -1)
			{
				if (this.weaponEff != null)
				{
					this.weaponEff = null;
				}
				if ((int)this.fweapon != 0)
				{
					this.fweapon = 0;
				}
			}
			else
			{
				this.weaponEff = MainObject.weaponEff_Gem[(int)this.slotGem[1]];
			}
		}
		else if (this.timeEff >= (int)this.timeShow * 4 && this.timeEff < (int)this.timeShow * 5)
		{
			if ((int)this.slotGem[2] == -1)
			{
				if (this.weaponEff != null)
				{
					this.weaponEff = null;
				}
				if ((int)this.fweapon != 0)
				{
					this.fweapon = 0;
				}
			}
			else
			{
				this.weaponEff = MainObject.weaponEff_Gem[(int)this.slotGem[2]];
			}
		}
		else if (this.timeEff >= (int)this.timeShow * 6)
		{
			this.timeEff = 0;
			if (this.weaponEff != null)
			{
				this.weaponEff = null;
			}
			if ((int)this.fweapon != 0)
			{
				this.fweapon = 0;
			}
		}
		else
		{
			if (this.weaponEff != null)
			{
				this.weaponEff = null;
			}
			if ((int)this.fweapon != 0)
			{
				this.fweapon = 0;
			}
		}
		if ((int)this.slotGem[0] != -1 && this.weaponEff == MainObject.weaponEff_Gem[(int)this.slotGem[0]])
		{
			this.dxEff = (int)this.eff_dx[(int)this.slotGem[0]][this.Direction];
			if (this.frame == 1)
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[0]][this.Direction] + 1;
			}
			else
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[0]][this.Direction];
			}
		}
		if ((int)this.slotGem[1] != -1 && this.weaponEff == MainObject.weaponEff_Gem[(int)this.slotGem[1]])
		{
			this.dxEff = (int)this.eff_dx[(int)this.slotGem[1]][this.Direction];
			if (this.frame == 1)
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[1]][this.Direction] + 1;
			}
			else
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[1]][this.Direction];
			}
		}
		if ((int)this.slotGem[2] != -1 && this.weaponEff == MainObject.weaponEff_Gem[(int)this.slotGem[2]])
		{
			this.dxEff = (int)this.eff_dx[(int)this.slotGem[2]][this.Direction];
			if (this.frame == 1)
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[2]][this.Direction] + 1;
			}
			else
			{
				this.dyEff = (int)this.eff_dy[(int)this.slotGem[2]][this.Direction];
			}
		}
	}

	// Token: 0x06000451 RID: 1105 RVA: 0x0003DD58 File Offset: 0x0003BF58
	public virtual void updateoverHP_MP()
	{
		MainObject.countmp += 1;
		if ((int)MainObject.countmp > 10)
		{
			MainObject.countmp = 0;
		}
		if (this.mp < this.maxMp / 10)
		{
			this.overMP = true;
		}
		else
		{
			this.overMP = false;
		}
		if (this.hp < this.maxHp / 10 && this.hp > 0)
		{
			this.overHP = true;
		}
		else
		{
			this.overHP = false;
		}
	}

	// Token: 0x06000452 RID: 1106 RVA: 0x0003DDE0 File Offset: 0x0003BFE0
	public virtual void addEffectCharWearing(int idEffect, int idimage)
	{
	}

	// Token: 0x06000453 RID: 1107 RVA: 0x0003DDE4 File Offset: 0x0003BFE4
	public virtual void setNameStore(string name)
	{
	}

	// Token: 0x06000454 RID: 1108 RVA: 0x0003DDE8 File Offset: 0x0003BFE8
	public virtual void removeNameStore()
	{
	}

	// Token: 0x06000455 RID: 1109 RVA: 0x0003DDEC File Offset: 0x0003BFEC
	public virtual bool isSelling()
	{
		return false;
	}

	// Token: 0x06000456 RID: 1110 RVA: 0x0003DDF0 File Offset: 0x0003BFF0
	public void paintEffectCharWearing(mGraphics g)
	{
		if (this.vecEffectCharWearing.size() > 0)
		{
			for (int i = 0; i < this.vecEffectCharWearing.size(); i++)
			{
				EffectCharWearing effectCharWearing = (EffectCharWearing)this.vecEffectCharWearing.elementAt(i);
				if (effectCharWearing != null)
				{
					effectCharWearing.paint(g, this.x, this.y);
				}
			}
		}
	}

	// Token: 0x06000457 RID: 1111 RVA: 0x0003DE58 File Offset: 0x0003C058
	public void updateEffectCharWearing()
	{
		if (this.vecEffectCharWearing.size() > 0)
		{
			for (int i = 0; i < this.vecEffectCharWearing.size(); i++)
			{
				EffectCharWearing effectCharWearing = (EffectCharWearing)this.vecEffectCharWearing.elementAt(i);
				if (effectCharWearing != null)
				{
					effectCharWearing.update();
				}
			}
		}
	}

	// Token: 0x06000458 RID: 1112 RVA: 0x0003DEB0 File Offset: 0x0003C0B0
	public void removeEffectCharWearing(int typeEff)
	{
		int num = this.vecEffectCharWearing.size();
		if (num > 0)
		{
			for (int i = 0; i < num; i++)
			{
				EffectCharWearing effectCharWearing = (EffectCharWearing)this.vecEffectCharWearing.elementAt(i);
				if (effectCharWearing != null && (int)effectCharWearing.type == typeEff)
				{
					this.vecEffectCharWearing.removeElement(effectCharWearing);
				}
			}
		}
	}

	// Token: 0x06000459 RID: 1113 RVA: 0x0003DF14 File Offset: 0x0003C114
	public void removeAllEffCharWearing()
	{
		this.vecEffectCharWearing.removeAllElements();
	}

	// Token: 0x0600045A RID: 1114 RVA: 0x0003DF24 File Offset: 0x0003C124
	public virtual bool isMiNuong()
	{
		return false;
	}

	// Token: 0x0600045B RID: 1115 RVA: 0x0003DF28 File Offset: 0x0003C128
	public virtual void SetnameOwner(string name)
	{
	}

	// Token: 0x0600045C RID: 1116 RVA: 0x0003DF2C File Offset: 0x0003C12C
	public void addDataEff(int type, sbyte[] arr, int dxx, int dyy)
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && (int)dataSkillEff.idEff == type)
			{
				this.vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff o = new DataSkillEff(arr, (short)type, dxx, dyy);
		this.vecDataSkillEff.addElement(o);
	}

	// Token: 0x0600045D RID: 1117 RVA: 0x0003DFA0 File Offset: 0x0003C1A0
	public void addDataEff(int type, sbyte[] arr, int dxx, int dyy, long timelive, sbyte typemove)
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && (int)dataSkillEff.idEff == type)
			{
				this.vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff o = new DataSkillEff(arr, (short)type, dxx, dyy, timelive, typemove);
		this.vecDataSkillEff.addElement(o);
	}

	// Token: 0x0600045E RID: 1118 RVA: 0x0003E018 File Offset: 0x0003C218
	public void addDataEff2(int type, sbyte[] arr, int dxx, int dyy, long timelive, sbyte typemove)
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && (int)dataSkillEff.idEff == type)
			{
				this.vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
		DataSkillEff dataSkillEff2 = new DataSkillEff(arr, (short)type, dxx, dyy, timelive, typemove);
		dataSkillEff2.isremovebyTime = false;
		dataSkillEff2.isremovebyFrame = true;
		this.vecDataSkillEff.addElement(dataSkillEff2);
	}

	// Token: 0x0600045F RID: 1119 RVA: 0x0003E09C File Offset: 0x0003C29C
	public void removeDataSkillEff(int id)
	{
		for (int i = 0; i < this.vecDataSkillEff.size(); i++)
		{
			DataSkillEff dataSkillEff = (DataSkillEff)this.vecDataSkillEff.elementAt(i);
			if (dataSkillEff != null && (int)dataSkillEff.idEff == id)
			{
				this.vecDataSkillEff.removeElement(dataSkillEff);
			}
		}
	}

	// Token: 0x06000460 RID: 1120 RVA: 0x0003E0F8 File Offset: 0x0003C2F8
	public bool isHairNotHat()
	{
		if (Player.ID_HAIR_NO_HAT == null)
		{
			return false;
		}
		if (this.idPartFashion[2] != -1)
		{
			return false;
		}
		int num = Player.ID_HAIR_NO_HAT.Length;
		for (int i = 0; i < num; i++)
		{
			sbyte b = Player.ID_HAIR_NO_HAT[i];
			if ((int)b == this.hair)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06000461 RID: 1121 RVA: 0x0003E154 File Offset: 0x0003C354
	public int getDy()
	{
		return 0;
	}

	// Token: 0x06000462 RID: 1122 RVA: 0x0003E158 File Offset: 0x0003C358
	public int getHeight()
	{
		return this.hOne;
	}

	// Token: 0x06000463 RID: 1123 RVA: 0x0003E160 File Offset: 0x0003C360
	public int getDir()
	{
		return this.Direction;
	}

	// Token: 0x06000464 RID: 1124 RVA: 0x0003E168 File Offset: 0x0003C368
	public void addiconClan()
	{
	}

	// Token: 0x06000465 RID: 1125 RVA: 0x0003E16C File Offset: 0x0003C36C
	public virtual bool canNotMove()
	{
		return false;
	}

	// Token: 0x06000466 RID: 1126 RVA: 0x0003E170 File Offset: 0x0003C370
	public virtual bool canfire()
	{
		return false;
	}

	// Token: 0x0400052D RID: 1325
	public const sbyte DIR_UP = 1;

	// Token: 0x0400052E RID: 1326
	public const sbyte DIR_DOWN = 0;

	// Token: 0x0400052F RID: 1327
	public const sbyte DIR_LEFT = 2;

	// Token: 0x04000530 RID: 1328
	public const sbyte DIR_RIGHT = 3;

	// Token: 0x04000531 RID: 1329
	public const sbyte AC_STAND = 0;

	// Token: 0x04000532 RID: 1330
	public const sbyte AC_MOVE = 1;

	// Token: 0x04000533 RID: 1331
	public const sbyte AC_FIRE = 2;

	// Token: 0x04000534 RID: 1332
	public const sbyte AC_HIT = 3;

	// Token: 0x04000535 RID: 1333
	public const sbyte AC_DIE = 4;

	// Token: 0x04000536 RID: 1334
	public const sbyte CAT_PLAYER = 0;

	// Token: 0x04000537 RID: 1335
	public const sbyte CAT_MONSTER = 1;

	// Token: 0x04000538 RID: 1336
	public const sbyte CAT_NPC = 2;

	// Token: 0x04000539 RID: 1337
	public const sbyte CAT_ITEM = 3;

	// Token: 0x0400053A RID: 1338
	public const sbyte CAT_POTION = 4;

	// Token: 0x0400053B RID: 1339
	public const sbyte CAT_QUEST_ITEM = 5;

	// Token: 0x0400053C RID: 1340
	public const sbyte CAT_ITEM_TOC = 6;

	// Token: 0x0400053D RID: 1341
	public const sbyte CAT_MATERIAL = 7;

	// Token: 0x0400053E RID: 1342
	public const sbyte CAT_ICON_CLAN = 8;

	// Token: 0x0400053F RID: 1343
	public const sbyte CAT_PET = 9;

	// Token: 0x04000540 RID: 1344
	public const sbyte CAT_MOUNT = 10;

	// Token: 0x04000541 RID: 1345
	public const sbyte SPEC_NORMAL = 0;

	// Token: 0x04000542 RID: 1346
	public const sbyte SPEC_MONSTER = 1;

	// Token: 0x04000543 RID: 1347
	public const sbyte KIEMSI = 0;

	// Token: 0x04000544 RID: 1348
	public const sbyte SONGKIEM = 1;

	// Token: 0x04000545 RID: 1349
	public const sbyte PHAPSU = 2;

	// Token: 0x04000546 RID: 1350
	public const sbyte XATHU = 3;

	// Token: 0x04000547 RID: 1351
	public const sbyte TEM_ANIMAL = 0;

	// Token: 0x04000548 RID: 1352
	public const sbyte TEM_ITEM = 1;

	// Token: 0x04000549 RID: 1353
	public const sbyte TEM_ALL = -1;

	// Token: 0x0400054A RID: 1354
	public const sbyte TEM_NPC = 2;

	// Token: 0x0400054B RID: 1355
	public const sbyte TEM_PLAYER = 3;

	// Token: 0x0400054C RID: 1356
	public const sbyte MON_NOR = 0;

	// Token: 0x0400054D RID: 1357
	public const sbyte MON_BOSS = 1;

	// Token: 0x0400054E RID: 1358
	public const sbyte MON_CAPCHAR = 2;

	// Token: 0x0400054F RID: 1359
	public const sbyte MON_PHOBANG = 3;

	// Token: 0x04000550 RID: 1360
	public const sbyte BOSS_PHOBANG = 4;

	// Token: 0x04000551 RID: 1361
	public const sbyte CUCDA_BANGHOI = 5;

	// Token: 0x04000552 RID: 1362
	public const sbyte MON_NHANBANG = 6;

	// Token: 0x04000553 RID: 1363
	public const sbyte CHARMONSTER = -126;

	// Token: 0x04000554 RID: 1364
	public const sbyte MONSTERARENA = -125;

	// Token: 0x04000555 RID: 1365
	public const sbyte newMONSTER = 92;

	// Token: 0x04000556 RID: 1366
	public const sbyte isThucLui = 127;

	// Token: 0x04000557 RID: 1367
	public const sbyte TYPE_PK_THUONG_GIA = 11;

	// Token: 0x04000558 RID: 1368
	public const sbyte TYPE_PK_CUOP = 12;

	// Token: 0x04000559 RID: 1369
	public const sbyte TYPE_PK_HIEP_SY = 13;

	// Token: 0x0400055A RID: 1370
	public const sbyte CAN_FOCUS = 1;

	// Token: 0x0400055B RID: 1371
	public const sbyte CAN_NOT_FOCUS = 0;

	// Token: 0x0400055C RID: 1372
	public const sbyte CAN_FIRE = 1;

	// Token: 0x0400055D RID: 1373
	public const sbyte CAN_NOT_FIRE = 0;

	// Token: 0x0400055E RID: 1374
	public const sbyte NGUA_NAU = 0;

	// Token: 0x0400055F RID: 1375
	public const sbyte NGUA_TRANG = 1;

	// Token: 0x04000560 RID: 1376
	public const sbyte NGUA_CHIENGIAP = 2;

	// Token: 0x04000561 RID: 1377
	public const sbyte NGUA_DO = 3;

	// Token: 0x04000562 RID: 1378
	public const sbyte NGUA_DEN = 4;

	// Token: 0x04000563 RID: 1379
	public short idMatna = -1;

	// Token: 0x04000564 RID: 1380
	public long timedie;

	// Token: 0x04000565 RID: 1381
	public EffectAuto effAuto;

	// Token: 0x04000566 RID: 1382
	public int x;

	// Token: 0x04000567 RID: 1383
	public int y;

	// Token: 0x04000568 RID: 1384
	public int f;

	// Token: 0x04000569 RID: 1385
	public int vx;

	// Token: 0x0400056A RID: 1386
	public int vy;

	// Token: 0x0400056B RID: 1387
	public int wOne;

	// Token: 0x0400056C RID: 1388
	public int hOne;

	// Token: 0x0400056D RID: 1389
	public int toX;

	// Token: 0x0400056E RID: 1390
	public int toY;

	// Token: 0x0400056F RID: 1391
	public int wFocus;

	// Token: 0x04000570 RID: 1392
	public int vMax;

	// Token: 0x04000571 RID: 1393
	public int dy;

	// Token: 0x04000572 RID: 1394
	public int dx;

	// Token: 0x04000573 RID: 1395
	public int dyWater;

	// Token: 0x04000574 RID: 1396
	public int dyKill;

	// Token: 0x04000575 RID: 1397
	public int xFire;

	// Token: 0x04000576 RID: 1398
	public int yFire;

	// Token: 0x04000577 RID: 1399
	public int xsai;

	// Token: 0x04000578 RID: 1400
	public int ysai;

	// Token: 0x04000579 RID: 1401
	public int ySort;

	// Token: 0x0400057A RID: 1402
	public int yEffAuto;

	// Token: 0x0400057B RID: 1403
	private int timeDyKill;

	// Token: 0x0400057C RID: 1404
	private int vDy;

	// Token: 0x0400057D RID: 1405
	public int hp;

	// Token: 0x0400057E RID: 1406
	public int maxHp;

	// Token: 0x0400057F RID: 1407
	public int mp;

	// Token: 0x04000580 RID: 1408
	public int maxMp;

	// Token: 0x04000581 RID: 1409
	public int hpEffect;

	// Token: 0x04000582 RID: 1410
	public int yjum;

	// Token: 0x04000583 RID: 1411
	public int vjum;

	// Token: 0x04000584 RID: 1412
	public sbyte clazz;

	// Token: 0x04000585 RID: 1413
	public sbyte index;

	// Token: 0x04000586 RID: 1414
	public short Lv;

	// Token: 0x04000587 RID: 1415
	public short phantramLv;

	// Token: 0x04000588 RID: 1416
	public short countCharStand;

	// Token: 0x04000589 RID: 1417
	public bool overMP;

	// Token: 0x0400058A RID: 1418
	public bool overHP;

	// Token: 0x0400058B RID: 1419
	public static sbyte countmp;

	// Token: 0x0400058C RID: 1420
	public short idImageHenshin = -1;

	// Token: 0x0400058D RID: 1421
	public long gold;

	// Token: 0x0400058E RID: 1422
	public long coin;

	// Token: 0x0400058F RID: 1423
	public int hang;

	// Token: 0x04000590 RID: 1424
	public int idClanMoDa;

	// Token: 0x04000591 RID: 1425
	public int timeHuyKill;

	// Token: 0x04000592 RID: 1426
	public bool isTanHinh;

	// Token: 0x04000593 RID: 1427
	public bool isShowHP;

	// Token: 0x04000594 RID: 1428
	public bool isBinded;

	// Token: 0x04000595 RID: 1429
	public bool isDongBang;

	// Token: 0x04000596 RID: 1430
	public bool moveToBoss;

	// Token: 0x04000597 RID: 1431
	public bool isFootSnow;

	// Token: 0x04000598 RID: 1432
	public long timeBind;

	// Token: 0x04000599 RID: 1433
	public long timeSleep;

	// Token: 0x0400059A RID: 1434
	public long timeStun;

	// Token: 0x0400059B RID: 1435
	public long timeno;

	// Token: 0x0400059C RID: 1436
	public long timenoBoss84;

	// Token: 0x0400059D RID: 1437
	public long timeDongBang;

	// Token: 0x0400059E RID: 1438
	public int timeTanHinh;

	// Token: 0x0400059F RID: 1439
	public int timeStop;

	// Token: 0x040005A0 RID: 1440
	public int timeEye;

	// Token: 0x040005A1 RID: 1441
	public int EyeMain;

	// Token: 0x040005A2 RID: 1442
	public int endEye;

	// Token: 0x040005A3 RID: 1443
	public long timeRePlayerInfo;

	// Token: 0x040005A4 RID: 1444
	public int hat = 2;

	// Token: 0x040005A5 RID: 1445
	public int head = 1;

	// Token: 0x040005A6 RID: 1446
	public int body = 2;

	// Token: 0x040005A7 RID: 1447
	public int leg = 2;

	// Token: 0x040005A8 RID: 1448
	public int eye = 2;

	// Token: 0x040005A9 RID: 1449
	public int hair = 2;

	// Token: 0x040005AA RID: 1450
	public int wing = -1;

	// Token: 0x040005AB RID: 1451
	public int pet = -1;

	// Token: 0x040005AC RID: 1452
	public int frame;

	// Token: 0x040005AD RID: 1453
	public int frameLeg;

	// Token: 0x040005AE RID: 1454
	private sbyte[] A_Stand = new sbyte[]
	{
		0,
		0,
		0,
		0,
		0,
		0,
		0,
		1,
		1,
		1,
		1,
		1
	};

	// Token: 0x040005AF RID: 1455
	public sbyte[] A_Move = new sbyte[]
	{
		2,
		2,
		2,
		0,
		0,
		3,
		3,
		3,
		0,
		0
	};

	// Token: 0x040005B0 RID: 1456
	public static sbyte framefocus;

	// Token: 0x040005B1 RID: 1457
	public static int Wfc = 0;

	// Token: 0x040005B2 RID: 1458
	public static int Hfc = 0;

	// Token: 0x040005B3 RID: 1459
	public int xStand;

	// Token: 0x040005B4 RID: 1460
	public int yStand;

	// Token: 0x040005B5 RID: 1461
	public int countSendMove;

	// Token: 0x040005B6 RID: 1462
	public int xStopMove;

	// Token: 0x040005B7 RID: 1463
	public int yStopMove;

	// Token: 0x040005B8 RID: 1464
	private int frameDie;

	// Token: 0x040005B9 RID: 1465
	public int typeNPC;

	// Token: 0x040005BA RID: 1466
	public sbyte isPerson;

	// Token: 0x040005BB RID: 1467
	public bool isObject;

	// Token: 0x040005BC RID: 1468
	public static string[] strHelpNPC = null;

	// Token: 0x040005BD RID: 1469
	public static sbyte StepHelpServer = 0;

	// Token: 0x040005BE RID: 1470
	public sbyte colorName;

	// Token: 0x040005BF RID: 1471
	public int ID;

	// Token: 0x040005C0 RID: 1472
	public sbyte typeObject;

	// Token: 0x040005C1 RID: 1473
	public sbyte typePk = -1;

	// Token: 0x040005C2 RID: 1474
	public sbyte typeOnline;

	// Token: 0x040005C3 RID: 1475
	public sbyte typeBoss;

	// Token: 0x040005C4 RID: 1476
	public sbyte typeSpec;

	// Token: 0x040005C5 RID: 1477
	public int KillFire = -1;

	// Token: 0x040005C6 RID: 1478
	public short pointPk;

	// Token: 0x040005C7 RID: 1479
	public string name = string.Empty;

	// Token: 0x040005C8 RID: 1480
	public string nameGiaotiep = T.giaotiep;

	// Token: 0x040005C9 RID: 1481
	public string infoObject = string.Empty;

	// Token: 0x040005CA RID: 1482
	public string strChatPopup;

	// Token: 0x040005CB RID: 1483
	public int Action;

	// Token: 0x040005CC RID: 1484
	public int Direction;

	// Token: 0x040005CD RID: 1485
	public int PrevDir;

	// Token: 0x040005CE RID: 1486
	public int countAutoMove;

	// Token: 0x040005CF RID: 1487
	public int timeFreeMove;

	// Token: 0x040005D0 RID: 1488
	public bool isRemove;

	// Token: 0x040005D1 RID: 1489
	public bool isRemoveObjFocus;

	// Token: 0x040005D2 RID: 1490
	private bool isDirMove;

	// Token: 0x040005D3 RID: 1491
	public bool isStop;

	// Token: 0x040005D4 RID: 1492
	public bool iscuop;

	// Token: 0x040005D5 RID: 1493
	public short[] posTransRoad;

	// Token: 0x040005D6 RID: 1494
	public MainClan myClan;

	// Token: 0x040005D7 RID: 1495
	public int fplash;

	// Token: 0x040005D8 RID: 1496
	public int IDAttack;

	// Token: 0x040005D9 RID: 1497
	public mVector vecObjFocusSkill;

	// Token: 0x040005DA RID: 1498
	public int imageId;

	// Token: 0x040005DB RID: 1499
	public int IdBigAvatar;

	// Token: 0x040005DC RID: 1500
	public bool isRunAttack;

	// Token: 0x040005DD RID: 1501
	public bool isWater;

	// Token: 0x040005DE RID: 1502
	public bool isInfo;

	// Token: 0x040005DF RID: 1503
	public bool isParty;

	// Token: 0x040005E0 RID: 1504
	public long timeLoadInfo;

	// Token: 0x040005E1 RID: 1505
	public static mImage focus;

	// Token: 0x040005E2 RID: 1506
	public static mImage newfocus;

	// Token: 0x040005E3 RID: 1507
	public static mImage shadow;

	// Token: 0x040005E4 RID: 1508
	public static mImage shadow1;

	// Token: 0x040005E5 RID: 1509
	public static mImage water;

	// Token: 0x040005E6 RID: 1510
	public static mImage imgCapchar = null;

	// Token: 0x040005E7 RID: 1511
	public mVector vecBuff = new mVector("MainObject vecBuff");

	// Token: 0x040005E8 RID: 1512
	public SplashSkill PlashNow;

	// Token: 0x040005E9 RID: 1513
	public ListSkill ListKillNow;

	// Token: 0x040005EA RID: 1514
	public int typeMonster;

	// Token: 0x040005EB RID: 1515
	public bool isDie;

	// Token: 0x040005EC RID: 1516
	public PopupChat chat;

	// Token: 0x040005ED RID: 1517
	public bool ispaintArena;

	// Token: 0x040005EE RID: 1518
	public bool isjum;

	// Token: 0x040005EF RID: 1519
	public int timeStand;

	// Token: 0x040005F0 RID: 1520
	public int timeCapchar = -1;

	// Token: 0x040005F1 RID: 1521
	public Monster_Skill skillDefault;

	// Token: 0x040005F2 RID: 1522
	public static mVector vecCapchar = new mVector("MainObject vecCapchar");

	// Token: 0x040005F3 RID: 1523
	public static string strCapchar = string.Empty;

	// Token: 0x040005F4 RID: 1524
	public bool isMonPhoBangDie;

	// Token: 0x040005F5 RID: 1525
	public mVector vecEffauto = new mVector("MainObject VecEffauto");

	// Token: 0x040005F6 RID: 1526
	public mVector veclowEffauto = new mVector("Low VecEffauto");

	// Token: 0x040005F7 RID: 1527
	public mVector vecEffectCharWearing = new mVector("Effect CharWearing");

	// Token: 0x040005F8 RID: 1528
	public mVector vecDataSkillEff = new mVector("vec dataeff");

	// Token: 0x040005F9 RID: 1529
	public int coutEff;

	// Token: 0x040005FA RID: 1530
	public bool isSend;

	// Token: 0x040005FB RID: 1531
	public int timeGet;

	// Token: 0x040005FC RID: 1532
	public int timeReveice = 1500;

	// Token: 0x040005FD RID: 1533
	public sbyte numFrame;

	// Token: 0x040005FE RID: 1534
	public bool isDetonateInDest;

	// Token: 0x040005FF RID: 1535
	public bool isMove;

	// Token: 0x04000600 RID: 1536
	public bool isServerControl;

	// Token: 0x04000601 RID: 1537
	public short[] idPartFashion = new short[]
	{
		-1,
		-1,
		-1,
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x04000602 RID: 1538
	public static short[] idMaterialHopNguyenLieu;

	// Token: 0x04000603 RID: 1539
	public short markKiller;

	// Token: 0x04000604 RID: 1540
	public bool isPaint_No;

	// Token: 0x04000605 RID: 1541
	public bool isStun;

	// Token: 0x04000606 RID: 1542
	public bool isSleep;

	// Token: 0x04000607 RID: 1543
	public bool isno;

	// Token: 0x04000608 RID: 1544
	public bool isnoBoss84;

	// Token: 0x04000609 RID: 1545
	public sbyte isBot = -1;

	// Token: 0x0400060A RID: 1546
	public sbyte StepMovebocap = -1;

	// Token: 0x0400060B RID: 1547
	public bool Namearena;

	// Token: 0x0400060C RID: 1548
	public static sbyte hideEff = 0;

	// Token: 0x0400060D RID: 1549
	public bool useShip;

	// Token: 0x0400060E RID: 1550
	public bool canFocusMon;

	// Token: 0x0400060F RID: 1551
	public sbyte typefocus = 1;

	// Token: 0x04000610 RID: 1552
	public short idPhiPhong = -1;

	// Token: 0x04000611 RID: 1553
	public short idWeaPon = -1;

	// Token: 0x04000612 RID: 1554
	public short idHorse = -1;

	// Token: 0x04000613 RID: 1555
	public short idHair = -1;

	// Token: 0x04000614 RID: 1556
	public short idWing = -1;

	// Token: 0x04000615 RID: 1557
	public short idName = -1;

	// Token: 0x04000616 RID: 1558
	public short idBody = -1;

	// Token: 0x04000617 RID: 1559
	public short idLeg = -1;

	// Token: 0x04000618 RID: 1560
	public short idBienhinh = -1;

	// Token: 0x04000619 RID: 1561
	public sbyte typefire;

	// Token: 0x0400061A RID: 1562
	public EffectAuto matNa;

	// Token: 0x0400061B RID: 1563
	public static sbyte[] frameicon = new sbyte[]
	{
		0,
		1,
		2,
		1
	};

	// Token: 0x0400061C RID: 1564
	public sbyte frameClan;

	// Token: 0x0400061D RID: 1565
	public static sbyte[][] mTypePartPaintPlayer = new sbyte[][]
	{
		new sbyte[]
		{
			6,
			0,
			1,
			2,
			5,
			4,
			3,
			6
		},
		new sbyte[]
		{
			6,
			0,
			1,
			2,
			5,
			4,
			3,
			6
		},
		new sbyte[]
		{
			6,
			0,
			1,
			2,
			5,
			4,
			3,
			6
		},
		new sbyte[]
		{
			6,
			0,
			1,
			2,
			5,
			4,
			3,
			6
		}
	};

	// Token: 0x0400061E RID: 1566
	private int[][][] mAction = new int[][][]
	{
		new int[][]
		{
			new int[9],
			new int[9],
			new int[9]
		},
		new int[][]
		{
			new int[]
			{
				0,
				0,
				0,
				1,
				1,
				1,
				2,
				2,
				2
			},
			new int[]
			{
				1,
				1,
				1,
				0,
				0,
				0,
				2,
				2,
				2
			},
			new int[]
			{
				2,
				2,
				2,
				0,
				0,
				0,
				1,
				1,
				1
			}
		},
		new int[][]
		{
			new int[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3
			},
			new int[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3
			},
			new int[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3,
				3
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			}
		},
		new int[][]
		{
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			},
			new int[]
			{
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4,
				4
			}
		}
	};

	// Token: 0x0400061F RID: 1567
	private int mjum;

	// Token: 0x04000620 RID: 1568
	private int range;

	// Token: 0x04000621 RID: 1569
	public sbyte FrameBody;

	// Token: 0x04000622 RID: 1570
	public sbyte FrameLeg;

	// Token: 0x04000623 RID: 1571
	public sbyte FrameBienhinh;

	// Token: 0x04000624 RID: 1572
	public static mHashTable ALL_EFF_MAT_NA = new mHashTable();

	// Token: 0x04000625 RID: 1573
	public int FramePP;

	// Token: 0x04000626 RID: 1574
	public sbyte FrameHair;

	// Token: 0x04000627 RID: 1575
	public sbyte FrameWing;

	// Token: 0x04000628 RID: 1576
	public sbyte FrameName;

	// Token: 0x04000629 RID: 1577
	public int frameThuCuoi;

	// Token: 0x0400062A RID: 1578
	public int Fhorse;

	// Token: 0x0400062B RID: 1579
	public static sbyte[] horseMove = new sbyte[]
	{
		2,
		2,
		2,
		3,
		3,
		4,
		4,
		4
	};

	// Token: 0x0400062C RID: 1580
	public byte FrameWP;

	// Token: 0x0400062D RID: 1581
	public sbyte FrameMatNa;

	// Token: 0x0400062E RID: 1582
	public bool paintMatnaTruocNon = true;

	// Token: 0x0400062F RID: 1583
	public int time;

	// Token: 0x04000630 RID: 1584
	public int idLight;

	// Token: 0x04000631 RID: 1585
	public int weapon_frame;

	// Token: 0x04000632 RID: 1586
	public int weaponType = -1;

	// Token: 0x04000633 RID: 1587
	public static WeaponInfo[][][] imgWeapone = new WeaponInfo[4][][];

	// Token: 0x04000634 RID: 1588
	public static sbyte[] hwp = new sbyte[]
	{
		24,
		21,
		19,
		13
	};

	// Token: 0x04000635 RID: 1589
	public static sbyte[] fixY;

	// Token: 0x04000636 RID: 1590
	public int frNo;

	// Token: 0x04000637 RID: 1591
	public int[] frameNo = new int[]
	{
		0,
		0,
		0,
		1,
		1,
		1,
		2,
		2,
		2
	};

	// Token: 0x04000638 RID: 1592
	public bool isMoveOut;

	// Token: 0x04000639 RID: 1593
	public int xMoveOut;

	// Token: 0x0400063A RID: 1594
	public int yMoveOut;

	// Token: 0x0400063B RID: 1595
	public int dyMount;

	// Token: 0x0400063C RID: 1596
	public int xMount;

	// Token: 0x0400063D RID: 1597
	public int yMount;

	// Token: 0x0400063E RID: 1598
	public sbyte typeMount = -1;

	// Token: 0x0400063F RID: 1599
	public sbyte frameMount;

	// Token: 0x04000640 RID: 1600
	public sbyte fMount;

	// Token: 0x04000641 RID: 1601
	public bool ischar;

	// Token: 0x04000642 RID: 1602
	public static sbyte[] ArrMount;

	// Token: 0x04000643 RID: 1603
	public static sbyte[] ArrMount1;

	// Token: 0x04000644 RID: 1604
	public short[][] arrayGemKham = new short[12][];

	// Token: 0x04000645 RID: 1605
	public sbyte[] slotGem = new sbyte[]
	{
		-1,
		-1,
		-1
	};

	// Token: 0x04000646 RID: 1606
	public FrameImage weaponEff;

	// Token: 0x04000647 RID: 1607
	public static FrameImage[] weaponEff_Gem;

	// Token: 0x04000648 RID: 1608
	private int timeEff;

	// Token: 0x04000649 RID: 1609
	private int dxEff;

	// Token: 0x0400064A RID: 1610
	private int dyEff;

	// Token: 0x0400064B RID: 1611
	private sbyte fweapon;

	// Token: 0x0400064C RID: 1612
	private sbyte timeShow = 8;

	// Token: 0x0400064D RID: 1613
	private sbyte[] transEff = new sbyte[]
	{
		2,
		0,
		2,
		2
	};

	// Token: 0x0400064E RID: 1614
	private sbyte[][] eff_dx = new sbyte[][]
	{
		new sbyte[]
		{
			-2,
			4,
			2,
			-10
		},
		new sbyte[]
		{
			-2,
			4,
			2,
			-10
		}
	};

	// Token: 0x0400064F RID: 1615
	private sbyte[][] eff_dy = new sbyte[][]
	{
		new sbyte[]
		{
			6,
			5,
			5,
			2
		},
		new sbyte[]
		{
			6,
			5,
			5,
			2
		}
	};
}
