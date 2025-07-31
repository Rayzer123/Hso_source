using System;
using System.Collections;

// Token: 0x02000032 RID: 50
public class EffectAuto : MainItemMap
{
	// Token: 0x0600024A RID: 586 RVA: 0x0000E414 File Offset: 0x0000C614
	public EffectAuto(string key, string value)
	{
		this.TypeItem = 1;
		string[] array = mFont.split(value, ";");
		this.IDItem = short.Parse(array[0]);
		this.IDImage = short.Parse(array[1]);
		this.x = int.Parse(array[2]) * LoadMap.wTile;
		this.y = int.Parse(array[3]) * LoadMap.wTile;
		this.dx = int.Parse(array[4]);
		this.dy = int.Parse(array[5]);
		this.typeEffect = int.Parse(array[6]);
		this.valueEffect = int.Parse(array[7]);
		this.wOne = 70;
		this.hOne = 70;
		this.setDataEff(null);
	}

	// Token: 0x0600024B RID: 587 RVA: 0x0000E4E4 File Offset: 0x0000C6E4
	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff)
	{
		this.TypeItem = 1;
		this.IDItem = (short)id;
		this.IDImage = (short)id;
		this.x = x;
		this.y = y;
		this.dx = dx;
		this.dy = dy;
		this.typeEffect = typeeff;
		this.valueEffect = valueeff;
		this.wOne = 70;
		this.hOne = 70;
		this.dxx = 0;
		this.dyy = 0;
		this.setDataEff(null);
	}

	// Token: 0x0600024C RID: 588 RVA: 0x0000E578 File Offset: 0x0000C778
	public EffectAuto(int id, int x, int y, sbyte[] datasv)
	{
		this.typedata = 1;
		this.TypeItem = 3;
		this.IDItem = (short)id;
		this.IDImage = (short)id;
		this.x = x;
		this.y = y;
		this.wOne = 70;
		this.hOne = 70;
		this.dxx = 0;
		this.dyy = 0;
		this.setdataFromSV(datasv);
	}

	// Token: 0x0600024D RID: 589 RVA: 0x0000E5F4 File Offset: 0x0000C7F4
	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, long timelive, sbyte canmove, int dxx, int dyy)
	{
		this.typedata = 1;
		this.TypeItem = 2;
		this.IDItem = (short)id;
		this.IDImage = (short)id;
		this.x = x;
		this.y = y;
		this.dx = dx;
		this.dy = dy;
		this.typeEffect = typeeff;
		this.valueEffect = valueeff;
		this.wOne = 70;
		this.hOne = 70;
		this.timelive = timelive;
		this.Typemove = canmove;
		this.dxx = dxx;
		this.dyy = dyy;
		this.setdataFromSV(datasv);
	}

	// Token: 0x0600024E RID: 590 RVA: 0x0000E6A0 File Offset: 0x0000C8A0
	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv)
	{
		this.typedata = 1;
		this.TypeItem = 1;
		this.IDItem = (short)id;
		this.IDImage = (short)id;
		this.x = x;
		this.y = y;
		this.dx = dx;
		this.dy = dy;
		this.typeEffect = typeeff;
		this.valueEffect = valueeff;
		this.wOne = 70;
		this.hOne = 70;
		this.dxx = 0;
		this.dyy = 0;
		this.setdataFromSV(datasv);
	}

	// Token: 0x0600024F RID: 591 RVA: 0x0000E73C File Offset: 0x0000C93C
	public EffectAuto(int id, int x, int y, int dx, int dy, int typeeff, int valueeff, sbyte[] datasv, short loop)
	{
		this.typedata = 1;
		this.TypeItem = 1;
		this.IDItem = (short)id;
		this.IDImage = (short)id;
		this.x = x;
		this.y = y;
		this.dx = dx;
		this.dy = dy;
		this.typeEffect = typeeff;
		this.valueEffect = valueeff;
		this.wOne = 70;
		this.hOne = 70;
		this.dxx = 0;
		this.dyy = 0;
		this.Loop = loop;
		this.setdataFromSV(datasv);
	}

	// Token: 0x06000251 RID: 593 RVA: 0x0000E814 File Offset: 0x0000CA14
	public sbyte[] getdataFromRMS()
	{
		sbyte[] result = null;
		try
		{
			sbyte[] array = CRes.loadRMS("data_eff" + this.IDImage);
			if (array != null)
			{
				DataInputStream dataInputStream = new DataInputStream(array);
				result = new sbyte[(int)dataInputStream.readShort()];
				dataInputStream.read(ref result);
				dataInputStream.close();
			}
		}
		catch (Exception ex)
		{
		}
		return result;
	}

	// Token: 0x06000252 RID: 594 RVA: 0x0000E890 File Offset: 0x0000CA90
	public void setdataFromSV(sbyte[] datasv)
	{
		if (datasv != null && datasv.Length > 0)
		{
			this.eff = this.loadTemEff((int)this.IDImage, datasv);
			this.timeBegin = GameCanvas.timeNow;
			this.isPaint = true;
			this.isUpdate = true;
			this.setPlaySound();
		}
		else
		{
			DataEffAuto dataEffAuto = (DataEffAuto)EffectAuto.ALL_DATA_EFF_AUTO.get(string.Empty + this.IDImage);
			if (dataEffAuto == null)
			{
				sbyte[] array = this.getdataFromRMS();
				if (array != null && array.Length > 0)
				{
					dataEffAuto = new DataEffAuto((int)this.IDImage);
					dataEffAuto.setdata(array);
					EffectAuto.ALL_DATA_EFF_AUTO.put(this.IDImage + string.Empty, dataEffAuto);
					this.eff = this.loadTemEff((int)this.IDImage, dataEffAuto.data);
					this.timeBegin = GameCanvas.timeNow;
					this.isPaint = true;
					this.isUpdate = true;
					dataEffAuto.timeremove = (long)((int)(mSystem.currentTimeMillis() / 1000L));
					this.setPlaySound();
				}
				else
				{
					dataEffAuto = new DataEffAuto((int)this.IDImage);
					EffectAuto.ALL_DATA_EFF_AUTO.put(this.IDImage + string.Empty, dataEffAuto);
					ImageEffectAuto.setImage((int)this.IDImage);
					dataEffAuto.timeremove = (long)((int)(mSystem.currentTimeMillis() / 1000L));
				}
			}
			if (dataEffAuto != null && dataEffAuto.data != null && dataEffAuto.data.Length > 0)
			{
				this.eff = this.loadTemEff((int)this.IDImage, dataEffAuto.data);
				this.timeBegin = GameCanvas.timeNow;
				this.isPaint = true;
				this.isUpdate = true;
				this.setPlaySound();
			}
		}
	}

	// Token: 0x06000253 RID: 595 RVA: 0x0000EA4C File Offset: 0x0000CC4C
	public void paintMatna(mGraphics g)
	{
		try
		{
			if ((int)this.typedata == 1 && !this.isUpdate)
			{
				this.setdataFromSV(null);
			}
			else if (this.eff != null && this.isPaint)
			{
				int num = (int)this.eff.mRunFrame[this.f];
				int num2 = this.eff.mFrame[num].mpart.Length;
				for (int i = 0; i < num2; i++)
				{
					MainPartImage mainPartImage = (MainPartImage)this.eff.hashImage.get(string.Empty + this.eff.mFrame[num].mpart[i].idPartImage);
					mImage mImage = ImageEffectAuto.setImage((int)this.IDImage);
					if (mainPartImage != null && mImage != null && mImage.image != null)
					{
						g.drawRegion(mImage, (int)mainPartImage.x, (int)mainPartImage.y, (int)mainPartImage.w, (int)mainPartImage.h, 0, this.x + this.dx + (int)this.eff.mFrame[num].mpart[i].x, this.y + this.dy + (int)this.eff.mFrame[num].mpart[i].y, 0, mGraphics.isFalse);
					}
				}
			}
		}
		catch (Exception ex)
		{
			this.isPaint = false;
			this.isUpdate = false;
		}
	}

	// Token: 0x06000254 RID: 596 RVA: 0x0000EBDC File Offset: 0x0000CDDC
	public new void setDataEff(sbyte[] datasv)
	{
		this.eff = this.loadTemEff((int)this.IDImage, datasv);
		this.timeBegin = GameCanvas.timeNow;
		this.isPaint = true;
		this.isUpdate = true;
		this.setPlaySound();
	}

	// Token: 0x06000255 RID: 597 RVA: 0x0000EC1C File Offset: 0x0000CE1C
	public override void paint(mGraphics g)
	{
		if ((int)this.typedata == 1 && !this.isUpdate)
		{
			this.setdataFromSV(null);
			return;
		}
		if ((int)this.TypeItem == 3)
		{
			try
			{
				if (this.eff != null && this.isPaint)
				{
					int num = (int)this.eff.mRunFrame[this.f];
					int num2 = this.eff.mFrame[num].mpart.Length;
					for (int i = 0; i < num2; i++)
					{
						MainPartImage mainPartImage = (MainPartImage)this.eff.hashImage.get(string.Empty + this.eff.mFrame[num].mpart[i].idPartImage);
						mImage mImage = ImageEffectAuto.setImage((int)this.IDImage);
						if (mainPartImage != null && mImage != null && mImage.image != null)
						{
							g.drawRegion(mImage, (int)mainPartImage.x, (int)mainPartImage.y, (int)mainPartImage.w, (int)mainPartImage.h, 0, this.x + this.dx + (int)this.eff.mFrame[num].mpart[i].x, this.y + this.dy + (int)this.eff.mFrame[num].mpart[i].y, 0, mGraphics.isFalse);
						}
					}
				}
			}
			catch (Exception ex)
			{
				this.isPaint = false;
				this.isUpdate = false;
			}
			return;
		}
		if ((int)this.TypeItem == 4)
		{
			this.paintMatna(g);
			return;
		}
		if ((GameCanvas.lowGraphic || !this.isUpdate || (int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END) && !GameScreen.infoGame.isMapchienthanh())
		{
			return;
		}
		try
		{
			if (this.eff != null && this.isPaint)
			{
				int num3 = (int)this.eff.mRunFrame[this.f];
				int num4 = this.eff.mFrame[num3].mpart.Length;
				for (int j = 0; j < num4; j++)
				{
					MainPartImage mainPartImage2 = (MainPartImage)this.eff.hashImage.get(string.Empty + this.eff.mFrame[num3].mpart[j].idPartImage);
					mImage mImage2 = ImageEffectAuto.setImage((int)this.IDImage);
					if (mainPartImage2 != null && mImage2 != null && mImage2.image != null)
					{
						g.drawRegion(mImage2, (int)mainPartImage2.x, (int)mainPartImage2.y, (int)mainPartImage2.w, (int)mainPartImage2.h, 0, this.x + this.dx + (int)this.eff.mFrame[num3].mpart[j].x, this.y + this.dy + (int)this.eff.mFrame[num3].mpart[j].y, 0, mGraphics.isFalse);
					}
				}
			}
		}
		catch (Exception ex2)
		{
			this.isPaint = false;
			this.isUpdate = false;
		}
	}

	// Token: 0x06000256 RID: 598 RVA: 0x0000EF70 File Offset: 0x0000D170
	public void paint(mGraphics g, int xp, int yp)
	{
		if ((int)this.typedata == 1 && !this.isUpdate)
		{
			this.setdataFromSV(null);
			return;
		}
		if (GameCanvas.lowGraphic || !this.isUpdate || (int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END)
		{
			return;
		}
		try
		{
			if (this.eff != null && this.isPaint)
			{
				int num = (int)this.eff.mRunFrame[this.f];
				int num2 = this.eff.mFrame[num].mpart.Length;
				for (int i = 0; i < num2; i++)
				{
					MainPartImage mainPartImage = (MainPartImage)this.eff.hashImage.get(string.Empty + this.eff.mFrame[num].mpart[i].idPartImage);
					mImage mImage = ImageEffectAuto.setImage((int)this.IDImage);
					if (mainPartImage != null && mImage != null && mImage.image != null)
					{
						g.drawRegion(mImage, (int)mainPartImage.x, (int)mainPartImage.y, (int)mainPartImage.w, (int)mainPartImage.h, 0, xp + this.dx + (int)this.eff.mFrame[num].mpart[i].x + this.dxx, yp + this.dy + (int)this.eff.mFrame[num].mpart[i].y + this.dyy, 0, mGraphics.isFalse);
					}
				}
			}
		}
		catch (Exception ex)
		{
			mSystem.println(this.IDImage + " null img effect auto 2:" + ex.ToString());
			this.isPaint = false;
			this.isUpdate = false;
		}
	}

	// Token: 0x06000257 RID: 599 RVA: 0x0000F150 File Offset: 0x0000D350
	public bool lockmoveByeffAuto()
	{
		return this.timelive - mSystem.currentTimeMillis() > 0L && (int)this.Typemove == 1;
	}

	// Token: 0x06000258 RID: 600 RVA: 0x0000F180 File Offset: 0x0000D380
	public bool CanpaintByeffauto()
	{
		return this.timelive - mSystem.currentTimeMillis() > 0L && (int)this.Typemove == 2;
	}

	// Token: 0x06000259 RID: 601 RVA: 0x0000F1B0 File Offset: 0x0000D3B0
	public override void update()
	{
		if ((int)this.typedata == 1 && !this.isUpdate)
		{
			return;
		}
		try
		{
			if ((int)this.TypeItem == 3)
			{
				this.f++;
				if (this.f >= this.eff.mRunFrame.Length - 1)
				{
					this.f = 0;
					this.wantdestroy = true;
				}
				return;
			}
			if ((GameCanvas.lowGraphic || !this.isUpdate || (int)LoadMap.isShowEffAuto == (int)LoadMap.EFF_PHOBANG_END) && !GameScreen.infoGame.isMapchienthanh())
			{
				return;
			}
			if ((int)this.TypeItem == 2 && this.timelive - mSystem.currentTimeMillis() < 0L)
			{
				this.wantdestroy = true;
			}
			if (this.IDImage == 51)
			{
				this.f++;
				if (this.f >= this.eff.mRunFrame.Length - 1)
				{
					this.f = this.eff.mRunFrame.Length - 1;
				}
			}
			else if (this.f >= this.eff.mRunFrame.Length - 1)
			{
				switch (this.typeEffect)
				{
				case 0:
					this.nCountReplay++;
					this.isPaint = false;
					if (this.nCountReplay >= this.valueEffect)
					{
						this.nCountReplay = 0;
						this.isPaint = true;
						this.f = 0;
					}
					break;
				case 1:
					this.f = 0;
					break;
				case 2:
					this.isPaint = false;
					if (GameCanvas.gameTick % 5 == 0 && (GameCanvas.timeNow - this.timeBegin) / 1000L > (long)this.valueEffect)
					{
						this.timeBegin = GameCanvas.timeNow;
						this.f = 0;
						this.isPaint = true;
					}
					break;
				case 3:
					if (this.Loop > 0 && CRes.random(this.valueEffect) == 0)
					{
						this.Loop -= 1;
						this.f = 0;
					}
					else if (this.Loop <= 0)
					{
						this.wantdestroy = true;
						this.isPaint = false;
						this.isUpdate = false;
					}
					break;
				case 4:
					if (CRes.random(this.valueEffect) == 0)
					{
						this.f = 0;
						if (this.indexSound >= 0 && CRes.random(this.timePlaySound) == 0 && base.isInScreen())
						{
							mSound.playSound(this.indexSound, mSound.volumeSound);
						}
					}
					break;
				}
			}
			else
			{
				this.f++;
			}
		}
		catch (Exception ex)
		{
			mSystem.outz("eff=" + this.IDImage);
			this.isPaint = false;
			this.isUpdate = false;
		}
		this.setBeginSound();
	}

	// Token: 0x0600025A RID: 602 RVA: 0x0000F4C4 File Offset: 0x0000D6C4
	private void setBeginSound()
	{
		if (this.indexSound == 48)
		{
			if (CRes.random(this.timePlaySound) == 0 && base.isInScreen())
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
		}
		else if (this.indexSound == 49)
		{
			if (this.f == 35 || this.f == 43)
			{
				if (base.isInScreen())
				{
					mSound.playSound(49, mSound.volumeSound);
				}
			}
			else if (this.f == 125 && base.isInScreen())
			{
				mSound.playSound(50, mSound.volumeSound);
			}
		}
		else if (this.indexSound == 52)
		{
			if (this.f == 50 && base.isInScreen())
			{
				mSound.playSound(52, mSound.volumeSound);
			}
		}
		else if (this.indexSound == 54)
		{
			if (this.f % 5 == 0 && base.isInScreen() && (GameCanvas.timeNow - EffectAuto.timeSoundPHUNNUOC) / 100L > 48L)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
				EffectAuto.timeSoundPHUNNUOC = GameCanvas.timeNow;
			}
		}
		else if (this.indexSound == 53)
		{
			if (this.f % 5 == 0 && base.isInScreen() && (GameCanvas.timeNow - EffectAuto.timeSoundFIRE) / 100L > 68L && GameCanvas.currentScreen == GameCanvas.game)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
				EffectAuto.timeSoundFIRE = GameCanvas.timeNow;
			}
		}
		else if (this.indexSound == 55)
		{
			if (this.f % 5 == 0 && base.isInScreen() && (GameCanvas.timeNow - EffectAuto.timeSoundWATER) / 100L > 28L)
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
				EffectAuto.timeSoundWATER = GameCanvas.timeNow;
			}
		}
		else if (this.indexSound == 50)
		{
			if (this.f == 30 && base.isInScreen())
			{
				mSound.playSound(50, mSound.volumeSound);
			}
		}
		else if (this.indexSound == 56 && this.f % 5 == 0 && base.isInScreen() && (GameCanvas.timeNow - EffectAuto.timeSoundGIOTNUOC) / 100L > 48L)
		{
			mSound.playSound(this.indexSound, mSound.volumeSound);
			EffectAuto.timeSoundGIOTNUOC = GameCanvas.timeNow;
		}
	}

	// Token: 0x0600025B RID: 603 RVA: 0x0000F75C File Offset: 0x0000D95C
	public MainEffectAuto loadTemEff(int type, sbyte[] datasv)
	{
		MainEffectAuto mainEffectAuto = (MainEffectAuto)MainEffectAuto.hashTemEffAuto.get(string.Empty + type);
		if (mainEffectAuto == null)
		{
			mainEffectAuto = new MainEffectAuto(type, datasv);
			MainEffectAuto.hashTemEffAuto.put(type + string.Empty, mainEffectAuto);
		}
		return mainEffectAuto;
	}

	// Token: 0x0600025C RID: 604 RVA: 0x0000F7B4 File Offset: 0x0000D9B4
	public void setPlaySound()
	{
		switch (this.IDImage)
		{
		case 0:
		case 15:
		case 17:
		case 18:
		case 30:
		case 32:
			this.indexSound = 53;
			this.timePlaySound = 2;
			break;
		case 6:
			this.indexSound = 50;
			this.timePlaySound = 2;
			break;
		case 7:
			this.indexSound = 48;
			this.timePlaySound = 200;
			break;
		case 9:
		case 12:
			this.indexSound = 52;
			this.timePlaySound = 2;
			break;
		case 11:
			this.indexSound = 49;
			this.timePlaySound = 2;
			break;
		case 19:
		case 20:
		case 31:
			this.indexSound = 55;
			this.timePlaySound = 2;
			break;
		case 22:
			this.indexSound = 56;
			this.timePlaySound = 2;
			break;
		case 28:
			this.indexSound = 54;
			this.timePlaySound = 2;
			break;
		case 29:
			this.indexSound = 47;
			this.timePlaySound = 3;
			break;
		}
	}

	// Token: 0x0600025D RID: 605 RVA: 0x0000F914 File Offset: 0x0000DB14
	public static void SetRemove()
	{
		try
		{
			IDictionaryEnumerator enumerator = EffectAuto.ALL_DATA_EFF_AUTO.GetEnumerator();
			while (enumerator.MoveNext())
			{
				string k = enumerator.Key.ToString();
				DataEffAuto dataEffAuto = (DataEffAuto)EffectAuto.ALL_DATA_EFF_AUTO.get(k);
				if ((GameCanvas.timeNow - dataEffAuto.timeremove) / 1000L > (((int)TemMidlet.DIVICE != 0) ? 300L : 60L))
				{
					EffectAuto.ALL_DATA_EFF_AUTO.remove(k);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600025E RID: 606 RVA: 0x0000F9BC File Offset: 0x0000DBBC
	public void setidActor(int idac)
	{
		this.idActor = (short)idac;
	}

	// Token: 0x04000217 RID: 535
	private MainEffectAuto eff;

	// Token: 0x04000218 RID: 536
	private int nCountReplay;

	// Token: 0x04000219 RID: 537
	private bool isPaint = true;

	// Token: 0x0400021A RID: 538
	private bool isUpdate;

	// Token: 0x0400021B RID: 539
	private int typeEffect;

	// Token: 0x0400021C RID: 540
	private int valueEffect;

	// Token: 0x0400021D RID: 541
	private int f;

	// Token: 0x0400021E RID: 542
	private long timeBegin;

	// Token: 0x0400021F RID: 543
	public bool wantdestroy;

	// Token: 0x04000220 RID: 544
	private int indexSound = -1;

	// Token: 0x04000221 RID: 545
	private int timePlaySound = -1;

	// Token: 0x04000222 RID: 546
	public static long timeSoundFIRE = 0L;

	// Token: 0x04000223 RID: 547
	public static long timeSoundWATER = 0L;

	// Token: 0x04000224 RID: 548
	public static long timeSoundPHUNNUOC = 0L;

	// Token: 0x04000225 RID: 549
	public static long timeSoundGIOTNUOC = 0L;

	// Token: 0x04000226 RID: 550
	public static long lastTime;

	// Token: 0x04000227 RID: 551
	public long timelive;

	// Token: 0x04000228 RID: 552
	public short Loop;

	// Token: 0x04000229 RID: 553
	private sbyte typedata;

	// Token: 0x0400022A RID: 554
	public static mHashTable ALL_DATA_EFF_AUTO = new mHashTable();

	// Token: 0x0400022B RID: 555
	public int dxx;

	// Token: 0x0400022C RID: 556
	public int dyy;

	// Token: 0x0400022D RID: 557
	public sbyte Typemove;
}
