using System;

// Token: 0x020000A3 RID: 163
public class TabRebuildItem : MainTabNew
{
	// Token: 0x060007DE RID: 2014 RVA: 0x00080E48 File Offset: 0x0007F048
	public TabRebuildItem(string name, sbyte type)
	{
		this.isTabHopNguyenLieu = false;
		this.imgStarRebuild = null;
		this.typeRebuild = type;
		this.typeTab = MainTabNew.REBUILD;
		this.nameTab = name;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.maxw = (MainTabNew.wblack - 8) / 32;
		this.maxh = (MainTabNew.hblack - 8) / 32;
		if (MainTabNew.longwidth > 0)
		{
			this.winfo = MainTabNew.longwidth;
			this.xinfo = MainTabNew.xlongwidth;
			this.yinfo = MainTabNew.ylongwidth + (int)MainTabNew.wOneItem / 2;
		}
		else
		{
			this.xinfo = this.xBegin + MainTabNew.wblack / 2 - this.winfo / 2;
			this.yinfo = this.yBegin + 4;
			if (this.yinfo > GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand)
			{
				this.yinfo = GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand;
			}
		}
		if (GameCanvas.isSmallScreen)
		{
			this.yinfo = GameCanvas.h - GameCanvas.hCommand - 150 - GameCanvas.hCommand;
		}
		this.cmdBack = new iCommand(T.back, -1, this);
		this.cmdView = new iCommand(T.info, 1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			this.posMaterial = mSystem.new_M_Int(6, 2);
			this.posMaterial[4][0] = this.xBegin + MainTabNew.wblack / 2;
			this.posMaterial[4][1] = this.yBegin + MainTabNew.hblack / 2 - 52;
			this.posMaterial[2][0] = this.xBegin + MainTabNew.wblack / 2 + 52;
			this.posMaterial[2][1] = this.yBegin + MainTabNew.hblack / 2 - 16;
			this.posMaterial[1][0] = this.xBegin + MainTabNew.wblack / 2 + 32;
			this.posMaterial[1][1] = this.yBegin + MainTabNew.hblack / 2 + 45;
			this.posMaterial[3][0] = this.xBegin + MainTabNew.wblack / 2 - 32;
			this.posMaterial[3][1] = this.yBegin + MainTabNew.hblack / 2 + 45;
			this.posMaterial[0][0] = this.xBegin + MainTabNew.wblack / 2 - 52;
			this.posMaterial[0][1] = this.yBegin + MainTabNew.hblack / 2 - 16;
			this.posMaterial[5][0] = this.xBegin + MainTabNew.wblack / 2;
			this.posMaterial[5][1] = this.yBegin + MainTabNew.hblack / 2;
			TabRebuildItem.isLucky = false;
			this.right = null;
			TabRebuildItem.isShow = false;
			this.cmdHoiDap = new iCommand(T.dapdo, 0, this);
			if (MainTabNew.longwidth > 0)
			{
				int num = MainTabNew.ylongwidth + this.hSmall;
				int xlongwidth = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					this.cmdHoiDap.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, this.cmdHoiDap.caption);
				}
				else
				{
					this.cmdHoiDap.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 15, null, this.cmdHoiDap.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				this.cmdHoiDap.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdHoiDap.caption);
				this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdView.caption);
			}
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS)
		{
			this.posMaterial = mSystem.new_M_Int(2, 2);
			this.posMaterial[1][0] = this.xBegin + MainTabNew.wblack / 2 + 52;
			this.posMaterial[1][1] = this.yBegin + MainTabNew.hblack / 2 - 16;
			this.posMaterial[0][0] = this.xBegin + MainTabNew.wblack / 2 - 52;
			this.posMaterial[0][1] = this.yBegin + MainTabNew.hblack / 2 - 16;
			this.cmdHoiReplace = new iCommand(T.replace, 3, this);
			if (MainTabNew.longwidth > 0)
			{
				int num2 = MainTabNew.ylongwidth + this.hSmall;
				int xlongwidth2 = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					this.cmdHoiReplace.setPos(xlongwidth2 + MainTabNew.longwidth / 2, num2 - 10, PaintInfoGameScreen.fraButton2, this.cmdHoiReplace.caption);
				}
				else
				{
					this.cmdHoiReplace.setPos(xlongwidth2 + MainTabNew.longwidth / 2, num2 - 15, null, this.cmdHoiReplace.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				this.cmdHoiReplace.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdHoiReplace.caption);
				this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdView.caption);
			}
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.posMaterial = mSystem.new_M_Int(7, 2);
			this.posMaterial[1][0] = this.xBegin + MainTabNew.wblack / 2;
			this.posMaterial[1][1] = this.yBegin + MainTabNew.hblack / 2 - 52;
			this.posMaterial[5][0] = this.xBegin + MainTabNew.wblack / 2 + 46;
			this.posMaterial[5][1] = this.yBegin + MainTabNew.hblack / 2 - 26;
			this.posMaterial[2][0] = this.xBegin + MainTabNew.wblack / 2 + 46;
			this.posMaterial[2][1] = this.yBegin + MainTabNew.hblack / 2 + 26;
			this.posMaterial[4][0] = this.xBegin + MainTabNew.wblack / 2;
			this.posMaterial[4][1] = this.yBegin + MainTabNew.hblack / 2 + 52;
			this.posMaterial[0][0] = this.xBegin + MainTabNew.wblack / 2 - 46;
			this.posMaterial[0][1] = this.yBegin + MainTabNew.hblack / 2 + 26;
			this.posMaterial[3][0] = this.xBegin + MainTabNew.wblack / 2 - 46;
			this.posMaterial[3][1] = this.yBegin + MainTabNew.hblack / 2 - 26;
			this.posMaterial[6][0] = this.xBegin + MainTabNew.wblack / 2;
			this.posMaterial[6][1] = this.yBegin + MainTabNew.hblack / 2;
			this.cmdHoiReWing = new iCommand(T.nangcap, 4, this);
			if (MainTabNew.longwidth > 0)
			{
				int num3 = MainTabNew.ylongwidth + this.hSmall;
				int xlongwidth3 = MainTabNew.xlongwidth;
				if (MainTabNew.is320)
				{
					this.cmdHoiReWing.setPos(xlongwidth3 + MainTabNew.longwidth / 2, num3 - 10, PaintInfoGameScreen.fraButton2, this.cmdHoiReWing.caption);
				}
				else
				{
					this.cmdHoiReWing.setPos(xlongwidth3 + MainTabNew.longwidth / 2, num3 - 15, null, this.cmdHoiReWing.caption);
				}
			}
			else if (GameCanvas.isTouch)
			{
				this.cmdHoiReWing.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdHoiReWing.caption);
				this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2 - 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, this.cmdView.caption);
			}
		}
		this.init();
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			this.imgStarRebuild = mImage.createImage("/interface/rebuild.img");
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.imgStarRebuild = mImage.createImage("/interface/rebuild2.img");
		}
	}

	// Token: 0x060007E0 RID: 2016 RVA: 0x00081890 File Offset: 0x0007FA90
	public new void setPaintInfo()
	{
		this.mContent = null;
		this.mSubContent = null;
		this.mPlusContent = null;
		if (TabRebuildItem.itemRe != null && TabRebuildItem.itemRe.itemName != null)
		{
			this.name = TabRebuildItem.itemRe.itemName;
		}
		this.listContent = null;
		if (TabRebuildItem.itemRe != null)
		{
			int num = 1;
			this.mContent = TabRebuildItem.itemRe.mcontent;
			this.moreInfoconten = TabRebuildItem.itemRe.moreContenGem;
			this.mPlusContent = TabRebuildItem.itemRe.mPlusContent;
			this.mPlusColor = TabRebuildItem.itemRe.mPlusColor;
			this.mcolor = TabRebuildItem.itemRe.mColor;
			this.colorName = TabRebuildItem.itemRe.colorNameItem;
			if (TabRebuildItem.itemRe.mcontent != null)
			{
				num += this.mContent.Length;
			}
			if (TabRebuildItem.itemRe.mPlusContent != null)
			{
				num += TabRebuildItem.itemRe.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent - 30)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - (MainTabNew.hMaxContent - 30));
			}
			else if (GameCanvas.isTouch)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
			return;
		}
	}

	// Token: 0x060007E1 RID: 2017 RVA: 0x00081A00 File Offset: 0x0007FC00
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			this.backTab();
			break;
		case 1:
			if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
			{
				if (this.isUPgradeMedal && TabRebuildItem.itemRe != null)
				{
					GlobalService.gI().Hop_rac(4, (short)TabRebuildItem.itemRe.Id, (sbyte)TabRebuildItem.itemRe.ItemCatagory);
					TabRebuildItem.vecGem.removeAllElements();
					return;
				}
				if (this.isCreate_medal)
				{
					GlobalService.gI().Hop_rac(3);
					TabRebuildItem.vecGem.removeAllElements();
				}
				else if (TabRebuildItem.vecGem.size() > 0)
				{
					MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(0);
					if (mainItem != null)
					{
						GlobalService.gI().Hop_rac(2, (short)mainItem.Id, (sbyte)mainItem.ItemCatagory);
						TabRebuildItem.vecGem.removeAllElements();
					}
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.bonguyenlieu);
				}
			}
			else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO)
			{
				int idG = -1;
				if (TabRebuildItem.itemRe != null && TabRebuildItem.vecGem.size() > 0)
				{
					MainItem mainItem2 = (MainItem)TabRebuildItem.vecGem.elementAt(0);
					if (mainItem2 != null)
					{
						idG = mainItem2.Id;
					}
					GlobalService.gI().KhamNgoc(TabRebuildItem.DUC_LO, TabRebuildItem.itemRe.Id, idG, -1, -1);
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.chuaboduclo);
				}
			}
			else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC)
			{
				if (TabRebuildItem.vecGem.size() > 0)
				{
					MainItem mainItem3 = (MainItem)TabRebuildItem.vecGem.elementAt(0);
					if (mainItem3 != null)
					{
						GlobalService.gI().KhamNgoc(TabRebuildItem.GHEP_NGOC, mainItem3.Id, -1, -1, -1);
					}
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.bongoc);
				}
			}
			else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC)
			{
				if (TabRebuildItem.itemRe != null && TabRebuildItem.vecGem.size() > 0)
				{
					int[] array = new int[]
					{
						-1,
						-1,
						-1
					};
					for (int i = 0; i < TabRebuildItem.vecGem.size(); i++)
					{
						MainItem mainItem4 = (MainItem)TabRebuildItem.vecGem.elementAt(i);
						if (mainItem4 != null)
						{
							array[i] = mainItem4.Id;
						}
					}
					GlobalService.gI().KhamNgoc(TabRebuildItem.KHAM_NGOC, TabRebuildItem.itemRe.Id, array[0], array[1], array[2]);
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.chuaboitem);
				}
			}
			else if (TabRebuildItem.itemRe != null)
			{
				string name = string.Empty;
				int num = 0;
				mVector mVector = new mVector("TabRebuildItem menu");
				if (TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin != 0)
				{
					mVector.addElement(new iCommand(T.coin, 2, 0, this));
					name = string.Concat(new string[]
					{
						T.dapbangxu,
						MainItem.getDotNumber((long)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin),
						" ",
						T.coin,
						"?"
					});
					num++;
				}
				if (TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold != 0)
				{
					mVector.addElement(new iCommand(T.gem, 2, 1, this));
					name = string.Concat(new object[]
					{
						T.dapbangxu,
						TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold,
						" ",
						T.gem,
						"?"
					});
					num++;
				}
				if (num == 2)
				{
					name = string.Concat(new object[]
					{
						T.hoidapxuluong,
						MainItem.getDotNumber((long)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin),
						" ",
						T.coin,
						T.hay,
						TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold,
						" ",
						T.gem,
						"?"
					});
				}
				GameCanvas.menu2.startAt_NPC(mVector, name, Menu2.IdNPCLast, 2, false, 0);
			}
			break;
		case 2:
			if (MainTabNew.longwidth == 0)
			{
				if ((TabRebuildItem.itemRe != null && ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC)) || (TabRebuildItem.itemPlus != null && TabRebuildItem.itemFree != null && (int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS) || ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING && TabRebuildItem.dataWing != null))
				{
					TabRebuildItem.isShow = !TabRebuildItem.isShow;
				}
				else
				{
					TabRebuildItem.isShow = false;
				}
				if (TabRebuildItem.isShow)
				{
					if (!GameCanvas.isTouch)
					{
						this.cmdView.caption = T.close;
					}
					else
					{
						this.cmdView.setPos(this.xinfo + this.winfo - 12, this.yinfo + 10, PaintInfoGameScreen.fraCloseMenu, string.Empty);
					}
				}
				else if (!GameCanvas.isTouch)
				{
					this.cmdView.caption = T.info;
				}
				else
				{
					this.cmdView.caption = T.info;
					this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, this.cmdView.caption);
				}
			}
			break;
		case 3:
			if (TabRebuildItem.itemRe != null)
			{
				GameCanvas.menu2.doCloseMenu();
				GlobalService.gI().Rebuild_Item(2, 0, (sbyte)subIndex);
				if (MainTabNew.longwidth == 0)
				{
					TabRebuildItem.isShow = false;
					if (!GameCanvas.isTouch)
					{
						this.cmdView.caption = T.info;
					}
					else
					{
						this.cmdView.caption = T.info;
						this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, this.cmdView.caption);
					}
				}
				GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			}
			break;
		case 4:
			if (TabRebuildItem.itemFree != null && TabRebuildItem.itemPlus != null)
			{
				GlobalService.gI().Replace_Item(1, 0);
				GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			}
			break;
		case 5:
		{
			mVector mVector2 = new mVector("TabRebuildItem menu2");
			string name2 = string.Empty;
			if (TabRebuildItem.itemWing == null)
			{
				name2 = string.Concat(new object[]
				{
					T.hoiTaoCanh,
					this.nameTab,
					"? ",
					T.phi,
					": ",
					MainItem.getDotNumber((long)TabRebuildItem.priceWing),
					" ",
					T.coin,
					", ",
					T.LVyeucau,
					TabRebuildItem.lvReWing,
					", ",
					T.timeyeucau,
					PaintInfoGameScreen.getStringTime(TabRebuildItem.timeUseWing),
					"."
				});
				mVector2.addElement(new iCommand(T.taoCanh, 5, 0, this));
			}
			else
			{
				name2 = string.Concat(new object[]
				{
					T.hoinangcapcanh,
					TabRebuildItem.nameWing,
					"? ",
					T.phi,
					": ",
					MainItem.getDotNumber((long)TabRebuildItem.priceWing),
					" ",
					T.coin,
					", ",
					T.LVyeucau,
					TabRebuildItem.lvReWing,
					", ",
					T.timeyeucau,
					PaintInfoGameScreen.getStringTime(TabRebuildItem.timeUseWing),
					"."
				});
				mVector2.addElement(new iCommand(T.nangcap, 6, 0, this));
			}
			GameCanvas.menu2.startAt_NPC(mVector2, name2, Menu2.IdNPCLast, 2, false, 0);
			break;
		}
		case 6:
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Rebuild_Wing(1, TabRebuildItem.isChetao, 0);
			break;
		case 7:
			GameCanvas.menu2.doCloseMenu();
			if (TabRebuildItem.itemWing != null)
			{
				GlobalService.gI().Rebuild_Wing(3, TabRebuildItem.isChetao, (short)TabRebuildItem.itemWing.Id);
			}
			break;
		case 8:
			GameCanvas.menu2.doCloseMenu();
			GlobalService.gI().Rebuild_Item(5, (short)TabRebuildItem.itemRe.Id, (sbyte)TabRebuildItem.itemRe.ItemCatagory);
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
				if (!GameCanvas.isTouch)
				{
					this.cmdView.caption = T.info;
				}
				else
				{
					this.cmdView.caption = T.info;
					this.cmdView.setPos(GameCanvas.w - iCommand.wButtonCmd / 2, GameCanvas.h - iCommand.hButtonCmd / 2, null, this.cmdView.caption);
				}
			}
			GameCanvas.start_Wait_Dialog(T.pleaseWait, new iCommand(T.close, -1));
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060007E2 RID: 2018 RVA: 0x00082374 File Offset: 0x00080574
	public override void init()
	{
		this.cmdView.caption = T.info;
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			this.initRebuild();
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS)
		{
			this.initReplace();
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.initReWing();
		}
	}

	// Token: 0x060007E3 RID: 2019 RVA: 0x0008242C File Offset: 0x0008062C
	private void initReplace()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			TabRebuildItem.isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (TabRebuildItem.itemPlus != null && TabRebuildItem.itemFree != null && !TabRebuildItem.resetItemReplace)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiReplace;
			}
			this.right = this.cmdBack;
		}
		else
		{
			this.vecListCmd.removeAllElements();
			if (!TabRebuildItem.resetItemReplace && TabRebuildItem.itemPlus != null && TabRebuildItem.itemFree != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					this.vecListCmd.addElement(this.cmdHoiReplace);
				}
				else
				{
					this.vecListCmd.addElement(this.cmdView);
					this.vecListCmd.addElement(this.cmdHoiReplace);
				}
			}
		}
		this.listContent = null;
		TabRebuildItem.vecEffRe.removeAllElements();
		TabRebuildItem.isBeginEff = 0;
		TabRebuildItem.isNextRebuild = -1;
		if (TabRebuildItem.resetItemReplace)
		{
			TabRebuildItem.itemFree = null;
			TabRebuildItem.itemPlus = null;
			TabRebuildItem.resetItemReplace = false;
		}
		if (TabRebuildItem.itemPlus == null && TabRebuildItem.itemFree == null)
		{
			GameCanvas.menu2.startAt_NPC(null, T.boitemreplace, Menu2.IdNPCLast, 2, false, 0);
		}
	}

	// Token: 0x060007E4 RID: 2020 RVA: 0x00082574 File Offset: 0x00080774
	private void initRebuild()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			TabRebuildItem.isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (TabRebuildItem.itemRe != null || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
			}
			this.right = this.cmdBack;
		}
		else
		{
			this.vecListCmd.removeAllElements();
			if (TabRebuildItem.itemRe != null)
			{
				if (MainTabNew.longwidth > 0)
				{
					this.vecListCmd.addElement(this.cmdHoiDap);
				}
				else
				{
					this.vecListCmd.addElement(this.cmdView);
					this.vecListCmd.addElement(this.cmdHoiDap);
				}
			}
			if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC)
			{
				this.vecListCmd.addElement(this.cmdHoiDap);
				this.cmdHoiDap.caption = T.hopngoc;
			}
			if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
			{
				this.vecListCmd.addElement(this.cmdHoiDap);
				this.cmdHoiDap.caption = T.hoprac;
			}
		}
		this.listContent = null;
		TabRebuildItem.vecEffRe.removeAllElements();
		TabRebuildItem.isBeginEff = 0;
		TabRebuildItem.isNextRebuild = 0;
		if (TabRebuildItem.itemRe == null && (int)this.typeRebuild != (int)TabRebuildItem.TYPE_GHEP_NGOC && (int)this.typeRebuild != (int)TabRebuildItem.TYPE_ANY)
		{
			string name = (!this.isTabHopNguyenLieu) ? T.bovatphamvao : T.hopNguyenLieu;
			GameCanvas.menu2.startAt_NPC(null, name, Menu2.IdNPCLast, 2, false, 0);
		}
	}

	// Token: 0x060007E5 RID: 2021 RVA: 0x00082734 File Offset: 0x00080934
	private void initReWing()
	{
		MainTabNew.timePaintInfo = 0;
		if (MainTabNew.longwidth > 0)
		{
			TabRebuildItem.isShow = true;
		}
		if (!GameCanvas.isTouch)
		{
			if (!TabRebuildItem.resetItemReplace && TabRebuildItem.dataWing != null)
			{
				this.left = this.cmdView;
				this.cmdHoiReWing.caption = T.nangcap;
				if (TabRebuildItem.itemWing == null)
				{
					this.cmdHoiReWing.caption = T.taoCanh;
				}
				this.center = this.cmdHoiReWing;
			}
			this.right = this.cmdBack;
		}
		else
		{
			this.vecListCmd.removeAllElements();
			if (!TabRebuildItem.resetItemReplace && TabRebuildItem.dataWing != null)
			{
				this.cmdHoiReWing.caption = T.nangcap;
				if (TabRebuildItem.itemWing == null)
				{
					this.cmdHoiReWing.caption = T.taoCanh;
				}
				if (MainTabNew.longwidth > 0)
				{
					this.vecListCmd.addElement(this.cmdHoiReWing);
				}
				else
				{
					this.vecListCmd.addElement(this.cmdView);
					this.vecListCmd.addElement(this.cmdHoiReWing);
				}
			}
		}
		this.listContent = null;
		TabRebuildItem.vecEffRe.removeAllElements();
		TabRebuildItem.isBeginEff = 0;
		TabRebuildItem.isNextRebuild = 0;
		if (TabRebuildItem.resetItemReplace)
		{
			TabRebuildItem.itemWing = null;
			TabRebuildItem.resetItemReplace = false;
		}
	}

	// Token: 0x060007E6 RID: 2022 RVA: 0x00082888 File Offset: 0x00080A88
	public new void backTab()
	{
		if (MainTabNew.longwidth == 0)
		{
			TabRebuildItem.isShow = false;
		}
		MainTabNew.timePaintInfo = 0;
		MainTabNew.Focus = MainTabNew.TAB;
		TabRebuildItem.vecEffRe.removeAllElements();
		base.backTab();
	}

	// Token: 0x060007E7 RID: 2023 RVA: 0x000828C8 File Offset: 0x00080AC8
	public override void paint(mGraphics g)
	{
		if ((int)TabRebuildItem.isBeginEff == 0 && !GameCanvas.isTouch && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			g.fillRect(this.xBegin + 2, this.yBegin + 2, MainTabNew.wblack - 4, MainTabNew.hblack - 4, mGraphics.isFalse);
		}
		if (GameCanvas.lowGraphic)
		{
			MainTabNew.paintRectLowGraphic(g, this.xBegin + 4, this.yBegin + 4, MainTabNew.wblack - 8, MainTabNew.hblack - 8, 4);
		}
		else
		{
			this.paintRect(g);
		}
		g.drawImage(this.imgStarRebuild, this.xBegin + MainTabNew.wblack / 2 - 54, this.yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isFalse);
		g.drawRegion(this.imgStarRebuild, 0, 0, 54, 105, 2, this.xBegin + MainTabNew.wblack / 2, this.yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isFalse);
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			this.paintAny(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO)
		{
			this.paintDucLo(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC)
		{
			this.paintGhepNgoc(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC)
		{
			this.paintKhamNgoc(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD)
		{
			this.paintRebuild(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS)
		{
			this.paintReplace(g);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.paintReWing(g);
		}
		for (int i = 0; i < TabRebuildItem.vecEffRe.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(i);
			mainEffect.paint(g);
		}
		if (TabRebuildItem.isShow || MainTabNew.longwidth > 0)
		{
			this.paintInfo(g, this.xinfo, this.yinfo);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && ((int)MainTabNew.Focus == (int)MainTabNew.INFO || MainTabNew.longwidth > 0) && this.vecListCmd != null)
		{
			for (int j = 0; j < this.vecListCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(j);
				iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
			}
		}
	}

	// Token: 0x060007E8 RID: 2024 RVA: 0x00082B80 File Offset: 0x00080D80
	private void paintReWing(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (i == 6)
			{
				if (TabRebuildItem.itemWing != null)
				{
					TabRebuildItem.itemWing.paintItem(g, this.posMaterial[6][0], this.posMaterial[6][1], 21, 1, 0);
					if ((int)TabRebuildItem.isBeginEff == 0)
					{
						mFont.tahoma_7_white.drawString(g, "Lv " + TabRebuildItem.itemWing.tier, this.posMaterial[6][0], this.posMaterial[6][1] - 22, 2, mGraphics.isFalse);
					}
				}
			}
			else if (TabRebuildItem.dataWing != null && i < TabRebuildItem.dataWing.Length && (int)TabRebuildItem.isBeginEff == 0)
			{
				MainItem material = Item.getMaterial((int)TabRebuildItem.dataWing[i].id);
				if (material != null)
				{
					material.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 0, 0);
					if (TabRebuildItem.numWingMaterialInven[i] >= (int)TabRebuildItem.dataWing[i].valueWing)
					{
						mFont.tahoma_7_white.drawString(g, string.Empty + TabRebuildItem.dataWing[i].valueWing, this.posMaterial[i][0], this.posMaterial[i][1] + 11, 2, mGraphics.isFalse);
					}
					else
					{
						mFont.tahoma_7_red.drawString(g, string.Empty + TabRebuildItem.dataWing[i].valueWing, this.posMaterial[i][0], this.posMaterial[i][1] + 11, 2, mGraphics.isFalse);
					}
				}
				else
				{
					Item.put_Material((int)TabRebuildItem.dataWing[i].id);
				}
			}
			g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060007E9 RID: 2025 RVA: 0x00082DC4 File Offset: 0x00080FC4
	public void paintAny(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if ((int)TabRebuildItem.isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (TabRebuildItem.itemRe != null && i == 5 && ((int)TabRebuildItem.isBeginEff != 5 || this.time > 15L))
				{
					if (TabRebuildItem.itemRe.ItemCatagory == 7)
					{
						MainItem material = Item.getMaterial(TabRebuildItem.itemRe.Id);
						if (material != null)
						{
							material.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
						}
						else
						{
							Item.put_Material(TabRebuildItem.itemRe.Id);
						}
					}
					else
					{
						TabRebuildItem.itemRe.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
					}
				}
				g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < TabRebuildItem.vecGem.size(); j++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(j);
			if (mainItem != null)
			{
				MainItem material2 = Item.getMaterial(mainItem.Id);
				if (material2 != null)
				{
					material2.paintItemNew(g, this.posMaterial[j][0], this.posMaterial[j][1], 21, 0, 0);
				}
				else
				{
					Item.put_Material(mainItem.Id);
				}
				if (!TabRebuildItem.numofGem[j].Equals(string.Empty))
				{
				}
			}
		}
	}

	// Token: 0x060007EA RID: 2026 RVA: 0x00082FBC File Offset: 0x000811BC
	public static void addGem(MainItem item)
	{
		TabRebuildItem.vecGem.addElement(item);
	}

	// Token: 0x060007EB RID: 2027 RVA: 0x00082FCC File Offset: 0x000811CC
	public static void removeKhamNgoc(Item item)
	{
		for (int i = 0; i < TabRebuildItem.vecGem.size(); i++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(i);
			if (mainItem != null && mainItem.Id == item.Id)
			{
				TabRebuildItem.vecGem.removeElement(mainItem);
			}
		}
	}

	// Token: 0x060007EC RID: 2028 RVA: 0x00083028 File Offset: 0x00081228
	public static bool isKham(Item item)
	{
		for (int i = 0; i < TabRebuildItem.vecGem.size(); i++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(i);
			if (mainItem != null && mainItem.Id == item.Id)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060007ED RID: 2029 RVA: 0x0008307C File Offset: 0x0008127C
	public void paintGhepNgoc(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if ((int)TabRebuildItem.isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (TabRebuildItem.itemRe != null && i == 5 && ((int)TabRebuildItem.isBeginEff != 5 || this.time > 15L))
				{
					MainItem material = Item.getMaterial(TabRebuildItem.itemRe.Id);
					if (material != null)
					{
						material.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
					}
					else
					{
						Item.put_Material(TabRebuildItem.itemRe.Id);
					}
				}
				g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < TabRebuildItem.vecGem.size(); j++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(j);
			if (mainItem != null)
			{
				mainItem.paintItemNew(g, this.posMaterial[j][0], this.posMaterial[j][1], 21, 0, 0);
			}
		}
	}

	// Token: 0x060007EE RID: 2030 RVA: 0x00083200 File Offset: 0x00081400
	public void updateAny()
	{
		if (TabRebuildItem.itemRe != null && (int)TabRebuildItem.countSetpaintinfo > 0)
		{
			this.setPaintInfo();
		}
		if ((int)TabRebuildItem.countSetpaintinfo > 0)
		{
			TabRebuildItem.countSetpaintinfo -= 1;
		}
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				sbyte b = TabRebuildItem.itemRe.tier;
				if ((int)b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < TabRebuildItem.dataRebuild[(int)b].mValue.Length; i++)
				{
					if ((int)TabRebuildItem.dataRebuild[(int)b].mValue[i] > 0)
					{
						TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
					}
				}
				if (TabRebuildItem.isLucky)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[4][0], this.posMaterial[4][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[5][0], this.posMaterial[5][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L && ((int)TabRebuildItem.isNextRebuild == 3 || (int)TabRebuildItem.isNextRebuild == 4))
				{
					TabRebuildItem.isBeginEff = TabRebuildItem.isNextRebuild;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[5][0], this.posMaterial[5][1] - 11);
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(11, this.posMaterial[5][0], this.posMaterial[5][1]);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
				this.ispaintitemRe = true;
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			if (TabRebuildItem.itemRe != null && (int)TabRebuildItem.itemRe.tier == 15)
			{
				TabRebuildItem.itemRe = null;
			}
			if (this.isTabHopNguyenLieu && TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.itemRe = null;
			}
			TabRebuildItem.isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
				if (TabRebuildItem.itemRe != null)
				{
					if (MainTabNew.longwidth > 0)
					{
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
					else
					{
						this.vecListCmd.addElement(this.cmdView);
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
				}
			}
		}
	}

	// Token: 0x060007EF RID: 2031 RVA: 0x000836A0 File Offset: 0x000818A0
	public void updateGhepngoc()
	{
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				for (int i = 0; i < TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue.Length; i++)
				{
					if ((int)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] > 0)
					{
						TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
					}
				}
				if (TabRebuildItem.isLucky)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[4][0], this.posMaterial[4][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[5][0], this.posMaterial[5][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L && ((int)TabRebuildItem.isNextRebuild == 3 || (int)TabRebuildItem.isNextRebuild == 4))
				{
					TabRebuildItem.isBeginEff = TabRebuildItem.isNextRebuild;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[5][0], this.posMaterial[5][1] - 11);
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(11, this.posMaterial[5][0], this.posMaterial[5][1]);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
				this.ispaintitemRe = true;
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			if ((int)TabRebuildItem.itemRe.tier == 15)
			{
				TabRebuildItem.itemRe = null;
			}
			if (this.isTabHopNguyenLieu && TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.itemRe = null;
			}
			TabRebuildItem.isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
				if (TabRebuildItem.itemRe != null)
				{
					if (MainTabNew.longwidth > 0)
					{
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
					else
					{
						this.vecListCmd.addElement(this.cmdView);
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
				}
			}
		}
	}

	// Token: 0x060007F0 RID: 2032 RVA: 0x00083AFC File Offset: 0x00081CFC
	public void paintKhamNgoc(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if ((int)TabRebuildItem.isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (TabRebuildItem.itemRe != null && i == 5 && ((int)TabRebuildItem.isBeginEff != 5 || this.time > 15L))
				{
					TabRebuildItem.itemRe.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < TabRebuildItem.vecGem.size(); j++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(j);
			if (mainItem != null)
			{
				mainItem.paintItemNew(g, this.posMaterial[j][0], this.posMaterial[j][1], 21, 0, 0);
			}
		}
	}

	// Token: 0x060007F1 RID: 2033 RVA: 0x00083C5C File Offset: 0x00081E5C
	public void paintDucLo(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if ((int)TabRebuildItem.isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (TabRebuildItem.itemRe != null && i == 5 && ((int)TabRebuildItem.isBeginEff != 5 || this.time > 15L))
				{
					TabRebuildItem.itemRe.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
				}
				g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
		}
		for (int j = 0; j < TabRebuildItem.vecGem.size(); j++)
		{
			MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(j);
			if (mainItem != null)
			{
				mainItem.paintItemNew(g, this.posMaterial[j][0], this.posMaterial[j][1], 21, 0, 0);
			}
		}
	}

	// Token: 0x060007F2 RID: 2034 RVA: 0x00083DBC File Offset: 0x00081FBC
	public void paintRebuild(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if ((int)TabRebuildItem.isBeginEff == 0 || i == 5)
			{
				if (GameCanvas.lowGraphic)
				{
					MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
				}
				else
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				}
				if (TabRebuildItem.itemRe != null)
				{
					if (this.isTabHopNguyenLieu)
					{
						if (i < 5)
						{
							TabRebuildItem.itemRe.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
						}
						else if (TabRebuildItem.itemRe.itemClone != null)
						{
							MainItem material = Item.getMaterial(TabRebuildItem.itemRe.itemClone.Id);
							if (material != null)
							{
								material.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
							}
							else
							{
								Item.put_Material(TabRebuildItem.itemRe.itemClone.Id);
							}
						}
					}
					else if (i < 5)
					{
						MainItem material2 = Item.getMaterial((int)TabRebuildItem.idMaterial[i]);
						if (material2 != null)
						{
							if (((int)material2.typeMaterial == 11 && TabRebuildItem.isLucky) || (i < 4 && (int)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] > 0))
							{
								if ((int)material2.typeMaterial == 11 && TabRebuildItem.isLucky && TabRebuildItem.itemDaMayMan != null)
								{
									TabRebuildItem.itemDaMayMan.paintItem_notnum(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 0, 0);
								}
								else
								{
									material2.paintItem_notnum(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 0, 0);
								}
							}
						}
						else
						{
							Item.put_Material((int)TabRebuildItem.idMaterial[i]);
						}
					}
					else if (i == 5)
					{
						if ((int)TabRebuildItem.isBeginEff != 5 || this.time > 15L)
						{
							TabRebuildItem.itemRe.paintItem(g, this.posMaterial[i][0], this.posMaterial[i][1], 21, 1, 0);
						}
						if ((int)TabRebuildItem.isBeginEff == 0)
						{
							mFont.tahoma_7_white.drawString(g, "Lv " + TabRebuildItem.itemRe.tier, this.posMaterial[i][0], this.posMaterial[i][1] - 22, 2, mGraphics.isFalse);
						}
					}
				}
				g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
				if (TabRebuildItem.itemRe != null)
				{
					if (i < 4 && (int)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] > TabRebuildItem.numMaterialInven[i])
					{
						g.drawImage(AvMain.imgHotKey2, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
					}
					else if (i == 5 && (int)TabRebuildItem.isBeginEff == 5 && (int)TabRebuildItem.isNextRebuild == 4)
					{
						g.drawImage(AvMain.imgHotKey2, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
					}
				}
			}
		}
	}

	// Token: 0x060007F3 RID: 2035 RVA: 0x00084134 File Offset: 0x00082334
	public void paintRect(mGraphics g)
	{
		for (int i = 0; i <= this.maxw; i++)
		{
			for (int j = 0; j <= this.maxh; j++)
			{
				this.indexPaint = 12;
				if (j == 0)
				{
					this.indexPaint = 12;
				}
				if (i == this.maxw)
				{
					if (j == this.maxh)
					{
						g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + (MainTabNew.wblack - 8) - 32, this.yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isFalse);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + (MainTabNew.wblack - 8) - 32, this.yBegin + 4 + j * 32, 0, mGraphics.isFalse);
					}
				}
				else if (j == this.maxh)
				{
					g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + i * 32, this.yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isFalse);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + i * 32, this.yBegin + 4 + j * 32, 0, mGraphics.isFalse);
				}
			}
		}
	}

	// Token: 0x060007F4 RID: 2036 RVA: 0x00084298 File Offset: 0x00082498
	public void paintInfo(mGraphics g, int x, int y)
	{
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			this.paintinfoAny(g, x, y);
			if ((TabRebuildItem.itemRe == null && this.isCreate_medal) || (TabRebuildItem.itemRe != null && this.isUPgradeMedal))
			{
				this.paintconTenAny(g, x, y - 10);
			}
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC)
		{
			this.paintinfoGhepNgoc(g, x, y);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC || (int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO)
		{
			this.paintinfoKhamNgoc(g, x, y);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD)
		{
			this.paintInfoRebuild(g, x, y);
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS)
		{
			if (!TabRebuildItem.resetItemReplace)
			{
				this.paintInfoReplace(g, x, y);
			}
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.paintInfoReWing(g, x, y);
		}
	}

	// Token: 0x060007F5 RID: 2037 RVA: 0x000843B4 File Offset: 0x000825B4
	private void paintInfoReWing(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.dataWing == null)
		{
			return;
		}
		int hText = GameCanvas.hText;
		if (MainTabNew.longwidth > 0)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - (int)MainTabNew.wOneItem / 4, MainTabNew.longwidth, TabRebuildItem.nameWing, 5);
			y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			base.paintFormList(g, x, y, this.winfo, 150, TabRebuildItem.nameWing);
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		mFont.tahoma_7_white.drawString(g, T.LVyeucau + TabRebuildItem.lvReWing, x, y, 0, mGraphics.isFalse);
		y += hText;
		mFont.tahoma_7_white.drawString(g, T.timeyeucau + PaintInfoGameScreen.getStringTime(TabRebuildItem.timeUseWing), x, y, 0, mGraphics.isFalse);
		y += hText;
		for (int i = 0; i < TabRebuildItem.dataWing.Length; i++)
		{
			MainItem material = Item.getMaterial((int)TabRebuildItem.dataWing[i].id);
			if (material != null)
			{
				mFont mFont = mFont.tahoma_7_white;
				if ((int)TabRebuildItem.dataWing[i].valueWing > TabRebuildItem.numWingMaterialInven[i])
				{
					mFont = mFont.tahoma_7_red;
				}
				if (material.itemName != null)
				{
					mFont.drawString(g, material.itemName, x + 4, y, 0, mGraphics.isFalse);
				}
				mFont.drawString(g, TabRebuildItem.dataWing[i].valueWing + "/" + TabRebuildItem.numWingMaterialInven[i], x + this.winfo / 2 + 10, y, 0, mGraphics.isFalse);
				y += hText;
			}
			else
			{
				Item.put_Material((int)TabRebuildItem.dataWing[i].id);
			}
		}
	}

	// Token: 0x060007F6 RID: 2038 RVA: 0x00084578 File Offset: 0x00082778
	public void paintinfoAny(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.itemRe == null)
		{
			return;
		}
		if (MainTabNew.longwidth > 0 && TabRebuildItem.itemRe.itemName != null)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - (int)MainTabNew.wOneItem / 4, MainTabNew.longwidth, TabRebuildItem.itemRe.itemName, TabRebuildItem.itemRe.colorNameItem);
			y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			if (TabRebuildItem.itemRe.itemName != null)
			{
				base.paintFormList(g, x, y, this.winfo, 150, TabRebuildItem.itemRe.itemName);
			}
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
	}

	// Token: 0x060007F7 RID: 2039 RVA: 0x0008463C File Offset: 0x0008283C
	public void paintconTenAny(mGraphics g, int x, int y)
	{
		try
		{
			int num = GameCanvas.hText - 2;
			if (MainTabNew.longwidth > 0)
			{
				y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
				x += 4;
			}
			else
			{
				if (TabRebuildItem.itemRe != null && TabRebuildItem.itemRe.itemName != null)
				{
					base.paintFormList(g, x, y, this.winfo, 150, TabRebuildItem.itemRe.itemName);
				}
				y += GameCanvas.hCommand + 2;
				x += 4;
			}
			y += num;
			GameCanvas.resetTrans(g);
			this.scr.setStyle(TabRebuildItem.vecGem.size() + 2, GameCanvas.hText + 2, x, y - GameCanvas.hText * 2, this.winfo, num * (TabRebuildItem.vecGem.size() + 1) * 2, true, 1);
			this.scr.setClip(g, x, y, this.winfo, num * (TabRebuildItem.vecGem.size() + 1) * 2);
			mFont.tahoma_7b_white.drawString(g, T.nguyenlieu, x, y, 0, mGraphics.isTrue);
			y += num;
			for (int i = 0; i < TabRebuildItem.vecGem.size(); i++)
			{
				MainItem mainItem = (MainItem)TabRebuildItem.vecGem.elementAt(i);
				if (mainItem != null)
				{
					MainItem material = Item.getMaterial(mainItem.Id);
					if (material != null)
					{
						mFont mFont = mFont.tahoma_7_green;
						if (material.itemName != null && !material.itemName.Equals(string.Empty))
						{
							MainTabNew.setTextColorName(material.colorNameItem).drawString(g, material.itemName, x + 4, y, 0, mGraphics.isTrue);
						}
						if ((int)TabRebuildItem.numColor[i] == 0)
						{
							mFont = mFont.tahoma_7_red;
						}
						y += num;
						mFont.tahoma_7_white.drawString(g, T.soluong + " ", x + 4, y, 0, mGraphics.isTrue);
						mFont.drawString(g, TabRebuildItem.numofGem[i], x + 50, y, 0, mGraphics.isTrue);
						y += num;
					}
					else
					{
						Item.put_Material(mainItem.Id);
					}
				}
			}
			GameCanvas.resetTrans(g);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060007F8 RID: 2040 RVA: 0x00084878 File Offset: 0x00082A78
	private void paintInfoReplace(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.itemPlus == null || TabRebuildItem.itemFree == null)
		{
			return;
		}
		int hText = GameCanvas.hText;
		if (MainTabNew.longwidth > 0)
		{
			mFont.tahoma_7b_white.drawString(g, T.replace, x + MainTabNew.longwidth / 2, y - (int)MainTabNew.wOneItem / 4, 2, mGraphics.isFalse);
			y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			base.paintFormList(g, x, y, this.winfo, 100, T.replace);
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		MainTabNew.setTextColor(TabRebuildItem.itemPlus.colorNameItem).drawString(g, TabRebuildItem.itemPlus.itemName, x, y, 0, mGraphics.isFalse);
		y += hText;
		MainTabNew.setTextColor(TabRebuildItem.itemFree.colorNameItem).drawString(g, TabRebuildItem.itemFree.itemName, x, y, 0, mGraphics.isFalse);
		y += hText;
		mFont.tahoma_7_white.drawString(g, T.plusnhanduoc, x, y, 0, mGraphics.isFalse);
		y += hText;
		mFont.tahoma_7b_white.drawString(g, (int)TabRebuildItem.itemPlus.tier - 2 + " > " + TabRebuildItem.itemPlus.tier, x, y, 0, mGraphics.isFalse);
	}

	// Token: 0x060007F9 RID: 2041 RVA: 0x000849D0 File Offset: 0x00082BD0
	public void paintinfoKhamNgoc(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.itemRe == null)
		{
			return;
		}
		base.paintContentNew(g, false);
	}

	// Token: 0x060007FA RID: 2042 RVA: 0x000849E8 File Offset: 0x00082BE8
	public void paintinfoGhepNgoc(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.itemRe == null)
		{
			return;
		}
		if (MainTabNew.longwidth > 0 && TabRebuildItem.itemRe.itemName != null)
		{
			MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - (int)MainTabNew.wOneItem / 4, MainTabNew.longwidth, TabRebuildItem.itemRe.itemName, TabRebuildItem.itemRe.colorNameItem);
			y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			if (TabRebuildItem.itemRe.itemName != null)
			{
				base.paintFormList(g, x, y, this.winfo, 150, TabRebuildItem.itemRe.itemName);
			}
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
	}

	// Token: 0x060007FB RID: 2043 RVA: 0x00084AAC File Offset: 0x00082CAC
	public void paintInfoRebuild(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.itemRe == null)
		{
			return;
		}
		int num = GameCanvas.hText - 2;
		if (MainTabNew.longwidth > 0)
		{
			if (TabRebuildItem.itemRe.itemName != null)
			{
				MainTabNew.paintNameItem(g, x + MainTabNew.longwidth / 2, y - (int)MainTabNew.wOneItem / 4, MainTabNew.longwidth, TabRebuildItem.itemRe.itemName, TabRebuildItem.itemRe.colorNameItem);
			}
			if ((int)TabRebuildItem.itemRe.tier >= 15)
			{
				return;
			}
			y += (int)MainTabNew.wOneItem - GameCanvas.hText + GameCanvas.hText / 4;
			x += 4;
		}
		else
		{
			base.paintFormList(g, x, y, this.winfo, 150, TabRebuildItem.itemRe.itemName);
			y += GameCanvas.hCommand + 2;
			x += 4;
		}
		if (!this.isTabHopNguyenLieu)
		{
			if ((int)TabRebuildItem.itemRe.tier < 15)
			{
				mFont.tahoma_7b_blue.drawString(g, string.Concat(new object[]
				{
					"+",
					TabRebuildItem.itemRe.tier,
					" > +",
					(int)TabRebuildItem.itemRe.tier + 1
				}), x, y, 0, mGraphics.isFalse);
			}
			y += num;
			mFont.tahoma_7b_white.drawString(g, T.nguyenlieu, x, y, 0, mGraphics.isFalse);
			y += num;
			for (int i = 0; i < TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue.Length; i++)
			{
				mFont mFont = mFont.tahoma_7_white;
				if ((int)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] > TabRebuildItem.numMaterialInven[i])
				{
					mFont = mFont.tahoma_7_red;
				}
				MainItem material = Item.getMaterial((int)TabRebuildItem.idMaterial[i]);
				if (material != null)
				{
					TabRebuildItem.mNameMaterial[i] = material.itemName;
				}
				else
				{
					Item.put_Material((int)TabRebuildItem.idMaterial[i]);
				}
				if (TabRebuildItem.mNameMaterial[i] != null)
				{
					mFont.drawString(g, TabRebuildItem.mNameMaterial[i], x + 4, y, 0, mGraphics.isFalse);
				}
				mFont.drawString(g, TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] + "/" + TabRebuildItem.numMaterialInven[i], x + this.winfo / 2 + 10, y, 0, mGraphics.isFalse);
				y += num;
			}
			mFont.tahoma_7b_white.drawString(g, T.tilemayman, x, y, 0, mGraphics.isFalse);
			y += num;
			mFont.tahoma_7_white.drawString(g, TabRebuildItem.tilemayman, x + 4, y, 0, mGraphics.isFalse);
			y += num;
			mFont.tahoma_7b_white.drawString(g, T.chiphi, x, y, 0, mGraphics.isFalse);
			y += num - 2;
			this.paintPrice(g, x, y);
			return;
		}
		if (TabRebuildItem.itemRe.itemClone == null)
		{
			return;
		}
		int width = mFont.tahoma_7b_blue.getWidth(TabRebuildItem.itemRe.infoHop[0]);
		string[] array = mFont.tahoma_7b_blue.splitFontArray(TabRebuildItem.itemRe.infoHop[0], (MainTabNew.longwidth != 0) ? MainTabNew.longwidth : ((this.maxw - 1) * 32));
		int num2 = array.Length;
		for (int j = 0; j < num2; j++)
		{
			mFont.tahoma_7b_blue.drawString(g, array[j], x, y, 0, mGraphics.isFalse);
			y += num;
		}
		mFont.tahoma_7b_white.drawString(g, T.chiphi, x, y, 0, mGraphics.isFalse);
		y += num - 2;
		mFont.tahoma_7_white.drawString(g, TabRebuildItem.itemRe.infoHop[1], x + 4, y, 0, mGraphics.isFalse);
	}

	// Token: 0x060007FC RID: 2044 RVA: 0x00084E64 File Offset: 0x00083064
	public void paintPrice(mGraphics g, int x, int y)
	{
		if (TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin == 0)
		{
			mFont.tahoma_7_white.drawString(g, TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold + " " + T.gem, x + 4, y, 0, mGraphics.isFalse);
			return;
		}
		if (TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold == 0)
		{
			mFont.tahoma_7_white.drawString(g, TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin + " " + T.coin, x + 4, y, 0, mGraphics.isFalse);
			return;
		}
		mFont.tahoma_7_white.drawString(g, string.Concat(new object[]
		{
			TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceCoin,
			" ",
			T.coin,
			T.hoac,
			TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].priceGold,
			" ",
			T.gem
		}), x + 4, y, 0, mGraphics.isFalse);
	}

	// Token: 0x060007FD RID: 2045 RVA: 0x00084FAC File Offset: 0x000831AC
	public void paintReplace(mGraphics g)
	{
		for (int i = 0; i < this.posMaterial.Length; i++)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, this.posMaterial[i][0] - 10, this.posMaterial[i][1] - 10, 20, 20, 2);
			}
			else
			{
				g.drawRegion(MainTabNew.imgTab[2], 0, 0, 20, 20, 0, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
			}
			if (TabRebuildItem.itemPlus != null && i == 0)
			{
				TabRebuildItem.itemPlus.paintItem(g, this.posMaterial[0][0], this.posMaterial[0][1], 21, 1, 0);
				if ((int)TabRebuildItem.isBeginEff == 0)
				{
					mFont.tahoma_7_white.drawString(g, "Lv " + TabRebuildItem.itemPlus.tier, this.posMaterial[0][0], this.posMaterial[0][1] - 22, 2, mGraphics.isFalse);
				}
			}
			if (TabRebuildItem.itemFree != null && i == 1)
			{
				TabRebuildItem.itemFree.paintItem(g, this.posMaterial[1][0], this.posMaterial[1][1], 21, 1, 0);
				if ((int)TabRebuildItem.isBeginEff == 0)
				{
					mFont.tahoma_7_white.drawString(g, "Lv " + TabRebuildItem.itemFree.tier, this.posMaterial[1][0], this.posMaterial[1][1] - 22, 2, mGraphics.isFalse);
				}
			}
			g.drawImage(AvMain.imgHotKey, this.posMaterial[i][0], this.posMaterial[i][1], 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060007FE RID: 2046 RVA: 0x00085158 File Offset: 0x00083358
	public override void updatekey()
	{
		if ((int)TabRebuildItem.isBeginEff != 0)
		{
			return;
		}
		if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
		{
			MainTabNew.Focus = MainTabNew.TAB;
			GameCanvas.clearKeyHold();
		}
		base.updatekey();
	}

	// Token: 0x060007FF RID: 2047 RVA: 0x00085194 File Offset: 0x00083394
	public override void update()
	{
		if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD)
		{
			this.updateRebuild();
			if (this.isTabHopNguyenLieu)
			{
				this.cmdHoiDap.caption = T.hopThanh;
				this.cmdHoiDap.indexMenu = 7;
			}
			else
			{
				this.cmdHoiDap.caption = T.dapdo;
				this.cmdHoiDap.indexMenu = 0;
			}
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REPLACE_PLUS)
		{
			this.updateReplace();
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_REBUILD_WING)
		{
			this.updateReWing();
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_KHAM_NGOC)
		{
			this.updateKhamNgoc();
			this.cmdHoiDap.caption = T.khamNgoc;
			this.cmdHoiDap.indexMenu = 0;
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_GHEP_NGOC)
		{
			this.updateGhepngoc();
			this.cmdHoiDap.caption = T.hopngoc;
			this.cmdHoiDap.indexMenu = 0;
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_DUC_LO)
		{
			this.updateDucLo();
			this.cmdHoiDap.caption = T.DucLo;
			this.cmdHoiDap.indexMenu = 0;
		}
		else if ((int)this.typeRebuild == (int)TabRebuildItem.TYPE_ANY)
		{
			ScrollResult scrollResult = this.scr.updateKey();
			if (scrollResult.isDowning || scrollResult.isFinish)
			{
			}
			if (scrollResult.isFinish || GameCanvas.isKeyPressed(5))
			{
			}
			this.scr.updatecm();
			this.updateAny();
			this.cmdHoiDap.caption = T.hoprac;
			this.cmdHoiDap.indexMenu = 0;
		}
		for (int i = 0; i < TabRebuildItem.vecEffRe.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)TabRebuildItem.vecEffRe.elementAt(i);
			mainEffect.update();
			if (mainEffect.isStop)
			{
				TabRebuildItem.vecEffRe.removeElement(mainEffect);
			}
		}
	}

	// Token: 0x06000800 RID: 2048 RVA: 0x000853AC File Offset: 0x000835AC
	private void updateReWing()
	{
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.dataWing != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				for (int i = 0; i < TabRebuildItem.dataWing.Length; i++)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[6][0], this.posMaterial[6][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[6][0], this.posMaterial[6][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L)
				{
					TabRebuildItem.isBeginEff = 3;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			if (TabRebuildItem.itemWing != null)
			{
				TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[6][0], this.posMaterial[6][1] - 11);
			}
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[6][0], this.posMaterial[6][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[6][0], this.posMaterial[6][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			MainItem mainItem = (MainItem)Item.getItemInventory(3, TabRebuildItem.idWingOk);
			if (mainItem != null)
			{
				TabRebuildItem.itemWing = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
			}
			else
			{
				TabRebuildItem.itemWing = null;
			}
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			TabRebuildItem.dataWing = null;
			TabRebuildItem.resetItemReplace = true;
			TabRebuildItem.isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
		}
	}

	// Token: 0x06000801 RID: 2049 RVA: 0x000856F8 File Offset: 0x000838F8
	private void updateReplace()
	{
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (TabRebuildItem.itemPlus == null || TabRebuildItem.itemFree == null)
			{
				TabRebuildItem.isBeginEff = 0;
				return;
			}
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEndRebuild(37, this.posMaterial[0][0], this.posMaterial[0][1], this.posMaterial[1][0], this.posMaterial[1][1], (int)TabRebuildItem.itemPlus.tier);
			this.timeShowReplace = (int)TabRebuildItem.itemPlus.tier * 120;
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (this.time == 10L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[1][0], this.posMaterial[1][1], 1200 + this.timeShowReplace);
				}
				if (GameCanvas.timeNow - this.time > (long)(2000 + this.timeShowReplace))
				{
					TabRebuildItem.vecEffRe.removeAllElements();
					TabRebuildItem.isBeginEff = 3;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
			if (TabRebuildItem.itemPlus != null)
			{
				MainItem mainItem = (MainItem)Item.getItemInventory(TabRebuildItem.itemPlus.ItemCatagory, (short)TabRebuildItem.itemPlus.Id);
				if (mainItem != null)
				{
					TabRebuildItem.itemPlus = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					TabRebuildItem.itemPlus = null;
				}
			}
			if (TabRebuildItem.itemFree != null)
			{
				MainItem mainItem2 = (MainItem)Item.getItemInventory(TabRebuildItem.itemFree.ItemCatagory, (short)TabRebuildItem.itemFree.Id);
				if (mainItem2 != null)
				{
					TabRebuildItem.itemFree = MainItem.MainItem_Item(mainItem2.Id, mainItem2.itemNameExcludeLv, mainItem2.imageId, mainItem2.tier, mainItem2.colorNameItem, mainItem2.classcharItem, mainItem2.ItemCatagory, mainItem2.mInfo, mainItem2.type_Only_Item, false, mainItem2.IdTem, mainItem2.priceItem, (short)mainItem2.LvItem, mainItem2.canSell, mainItem2.canTrade, mainItem2.timeUse, 0, 0);
				}
				else
				{
					TabRebuildItem.itemFree = null;
				}
			}
			TabRebuildItem.isBeginEff = 0;
			TabRebuildItem.resetItemReplace = true;
			this.vecListCmd.removeAllElements();
			TabRebuildItem.isShow = false;
			this.center = null;
			this.left = null;
		}
	}

	// Token: 0x06000802 RID: 2050 RVA: 0x00085A3C File Offset: 0x00083C3C
	public void updateKhamNgoc()
	{
		if (TabRebuildItem.itemRe != null && (int)TabRebuildItem.countSetpaintinfo > 0)
		{
			this.setPaintInfo();
		}
		if ((int)TabRebuildItem.countSetpaintinfo > 0)
		{
			TabRebuildItem.countSetpaintinfo -= 1;
		}
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				sbyte b = TabRebuildItem.itemRe.tier;
				if ((int)b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < TabRebuildItem.dataRebuild[(int)b].mValue.Length; i++)
				{
					if ((int)TabRebuildItem.dataRebuild[(int)b].mValue[i] > 0)
					{
						TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
					}
				}
				if (TabRebuildItem.isLucky)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[4][0], this.posMaterial[4][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[5][0], this.posMaterial[5][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L && ((int)TabRebuildItem.isNextRebuild == 3 || (int)TabRebuildItem.isNextRebuild == 4))
				{
					TabRebuildItem.isBeginEff = TabRebuildItem.isNextRebuild;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[5][0], this.posMaterial[5][1] - 11);
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(11, this.posMaterial[5][0], this.posMaterial[5][1]);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			MainItem mainItem = (MainItem)Item.getItemInventory(TabRebuildItem.itemRe.ItemCatagory, (short)TabRebuildItem.itemRe.Id);
			if (!this.isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					TabRebuildItem.itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					TabRebuildItem.itemRe = null;
				}
			}
			TabRebuildItem.tilemayman = TabRebuildItem.tilemaymanafter;
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
			}
			TabRebuildItem.countSetpaintinfo = 1;
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			if ((int)TabRebuildItem.itemRe.tier == 15)
			{
				TabRebuildItem.itemRe = null;
			}
			if (this.isTabHopNguyenLieu && TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.itemRe = null;
			}
			TabRebuildItem.isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
				if (TabRebuildItem.itemRe != null)
				{
					if (MainTabNew.longwidth > 0)
					{
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
					else
					{
						this.vecListCmd.addElement(this.cmdView);
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
				}
			}
		}
	}

	// Token: 0x06000803 RID: 2051 RVA: 0x00085F7C File Offset: 0x0008417C
	public void updateDucLo()
	{
		if (TabRebuildItem.itemRe != null && (int)TabRebuildItem.countSetpaintinfo > 0)
		{
			this.setPaintInfo();
		}
		if ((int)TabRebuildItem.countSetpaintinfo > 0)
		{
			TabRebuildItem.countSetpaintinfo -= 1;
		}
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				sbyte b = TabRebuildItem.itemRe.tier;
				if ((int)b > 14)
				{
					b = 14;
				}
				for (int i = 0; i < TabRebuildItem.dataRebuild[(int)b].mValue.Length; i++)
				{
					if ((int)TabRebuildItem.dataRebuild[(int)b].mValue[i] > 0)
					{
						TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
					}
				}
				if (TabRebuildItem.isLucky)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[4][0], this.posMaterial[4][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[5][0], this.posMaterial[5][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L && ((int)TabRebuildItem.isNextRebuild == 3 || (int)TabRebuildItem.isNextRebuild == 4))
				{
					TabRebuildItem.isBeginEff = TabRebuildItem.isNextRebuild;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[5][0], this.posMaterial[5][1] - 11);
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(11, this.posMaterial[5][0], this.posMaterial[5][1]);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			MainItem mainItem = (MainItem)Item.getItemInventory(TabRebuildItem.itemRe.ItemCatagory, (short)TabRebuildItem.itemRe.Id);
			if (!this.isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					TabRebuildItem.itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					TabRebuildItem.itemRe = null;
				}
			}
			TabRebuildItem.tilemayman = TabRebuildItem.tilemaymanafter;
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
			}
			TabRebuildItem.countSetpaintinfo = 1;
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			if ((int)TabRebuildItem.itemRe.tier == 15)
			{
				TabRebuildItem.itemRe = null;
			}
			if (this.isTabHopNguyenLieu && TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.itemRe = null;
			}
			TabRebuildItem.isBeginEff = 0;
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
				if (TabRebuildItem.itemRe != null)
				{
					if (MainTabNew.longwidth > 0)
					{
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
					else
					{
						this.vecListCmd.addElement(this.cmdView);
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
				}
			}
		}
	}

	// Token: 0x06000804 RID: 2052 RVA: 0x000864BC File Offset: 0x000846BC
	public void updateRebuild()
	{
		if ((int)TabRebuildItem.isBeginEff == 1)
		{
			if (MainTabNew.longwidth == 0)
			{
				TabRebuildItem.isShow = false;
			}
			GameCanvas.end_Dialog();
			if (!GameCanvas.isTouch)
			{
				this.left = null;
				this.center = null;
			}
			else
			{
				this.vecListCmd.removeAllElements();
			}
			if (TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.vecEffRe.removeAllElements();
				for (int i = 0; i < TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue.Length; i++)
				{
					if ((int)TabRebuildItem.dataRebuild[(int)TabRebuildItem.itemRe.tier].mValue[i] > 0)
					{
						TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[i][0], this.posMaterial[i][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
					}
				}
				if (TabRebuildItem.isLucky)
				{
					TabRebuildItem.addEffectEndRebuild(31, this.posMaterial[4][0], this.posMaterial[4][1], this.posMaterial[5][0], this.posMaterial[5][1], 1);
				}
			}
			TabRebuildItem.isBeginEff = 2;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 2)
		{
			if (this.time < 10L)
			{
				this.time += 1L;
				if (this.time == 10L)
				{
					mSound.playSound(24, mSound.volumeSound);
				}
			}
			else
			{
				if (GameCanvas.timeNow - this.time > 12000L)
				{
					this.time = GameCanvas.timeNow;
					this.addEffectRebuild(29, this.posMaterial[5][0], this.posMaterial[5][1], 12100);
				}
				if (GameCanvas.timeNow - this.time > 3700L && ((int)TabRebuildItem.isNextRebuild == 3 || (int)TabRebuildItem.isNextRebuild == 4))
				{
					TabRebuildItem.isBeginEff = TabRebuildItem.isNextRebuild;
					this.time = 0L;
				}
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 3)
		{
			mSound.playSound(26, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(32, this.posMaterial[5][0], this.posMaterial[5][1] - 11);
			TabRebuildItem.addEffectEnd_ReBuild_ss(33, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.addEffectEnd_ReBuild_ss(34, this.posMaterial[5][0], this.posMaterial[5][1]);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 4)
		{
			mSound.playSound(27, mSound.volumeSound);
			TabRebuildItem.vecEffRe.removeAllElements();
			TabRebuildItem.addEffectEnd_ReBuild_ss(11, this.posMaterial[5][0], this.posMaterial[5][1]);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			this.addEffectRebuild(69, this.posMaterial[5][0], this.posMaterial[5][1] - 11, 300);
			TabRebuildItem.isBeginEff = 5;
			this.time = 0L;
		}
		else if ((int)TabRebuildItem.isBeginEff == 5)
		{
			this.time += 1L;
			MainItem mainItem = (MainItem)Item.getItemInventory(TabRebuildItem.itemRe.ItemCatagory, (short)TabRebuildItem.itemRe.Id);
			if (!this.isTabHopNguyenLieu)
			{
				if (mainItem != null)
				{
					TabRebuildItem.itemRe = MainItem.MainItem_Item(mainItem.Id, mainItem.itemNameExcludeLv, mainItem.imageId, mainItem.tier, mainItem.colorNameItem, mainItem.classcharItem, mainItem.ItemCatagory, mainItem.mInfo, mainItem.type_Only_Item, false, mainItem.IdTem, mainItem.priceItem, (short)mainItem.LvItem, mainItem.canSell, mainItem.canTrade, mainItem.timeUse, 0, 0);
				}
				else
				{
					TabRebuildItem.itemRe = null;
				}
			}
			TabRebuildItem.tilemayman = TabRebuildItem.tilemaymanafter;
			if (TabRebuildItem.vecEffRe.size() == 0 || this.time >= 100L)
			{
				GameCanvas.menu2.startAt_NPC(null, TabRebuildItem.contentShow, Menu2.IdNPCLast, 2, false, 0);
				this.time = 0L;
				TabRebuildItem.isBeginEff = 6;
			}
		}
		else if ((int)TabRebuildItem.isBeginEff == 6)
		{
			if ((int)TabRebuildItem.itemRe.tier == 15)
			{
				TabRebuildItem.itemRe = null;
			}
			if (this.isTabHopNguyenLieu && TabRebuildItem.itemRe != null)
			{
				TabRebuildItem.itemRe = null;
			}
			TabRebuildItem.isBeginEff = 0;
			if (TabRebuildItem.isLucky)
			{
				this.checkAddIsLucky();
			}
			if (!GameCanvas.isTouch)
			{
				this.left = this.cmdView;
				this.center = this.cmdHoiDap;
				MainTabNew.Focus = MainTabNew.TAB;
			}
			else
			{
				this.vecListCmd.removeAllElements();
				if (TabRebuildItem.itemRe != null)
				{
					if (MainTabNew.longwidth > 0)
					{
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
					else
					{
						this.vecListCmd.addElement(this.cmdView);
						this.vecListCmd.addElement(this.cmdHoiDap);
					}
				}
			}
		}
	}

	// Token: 0x06000805 RID: 2053 RVA: 0x000869CC File Offset: 0x00084BCC
	public override void updatePointer()
	{
		if ((int)TabRebuildItem.isBeginEff != 0)
		{
			return;
		}
		if (this.vecListCmd != null && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && ((int)MainTabNew.Focus == (int)MainTabNew.INFO || MainTabNew.longwidth > 0))
		{
			for (int i = 0; i < this.vecListCmd.size(); i++)
			{
				iCommand iCommand = (iCommand)this.vecListCmd.elementAt(i);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x06000806 RID: 2054 RVA: 0x00086A6C File Offset: 0x00084C6C
	public static void addEffectEndRebuild(int type, int x, int y, int xTo, int yTo, int num)
	{
		EffectEnd o = new EffectEnd(type, x, y, xTo, yTo, num);
		TabRebuildItem.vecEffRe.addElement(o);
	}

	// Token: 0x06000807 RID: 2055 RVA: 0x00086A94 File Offset: 0x00084C94
	public static void addEffectEnd_ReBuild_ss(int type, int x, int y)
	{
		EffectEnd o = new EffectEnd(type, x, y);
		TabRebuildItem.vecEffRe.addElement(o);
	}

	// Token: 0x06000808 RID: 2056 RVA: 0x00086AB8 File Offset: 0x00084CB8
	public void addEffectRebuild(int type, int x, int y, int time)
	{
		EffectSkill o = new EffectSkill(type, x, y, time, 0, 0);
		TabRebuildItem.vecEffRe.addElement(o);
	}

	// Token: 0x06000809 RID: 2057 RVA: 0x00086AE0 File Offset: 0x00084CE0
	public void checkAddIsLucky()
	{
		for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
		{
			MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
			if (mainItem.ItemCatagory == 7 && (int)mainItem.typeMaterial == 11 && TabRebuildItem.itemDaMayMan != null && TabRebuildItem.itemDaMayMan.Id == mainItem.Id)
			{
				GlobalService.gI().Rebuild_Item(0, (short)mainItem.Id, (sbyte)mainItem.ItemCatagory);
				return;
			}
		}
		TabRebuildItem.isLucky = false;
	}

	// Token: 0x04000C3B RID: 3131
	private sbyte typeRebuild;

	// Token: 0x04000C3C RID: 3132
	public static sbyte TYPE_REBUILD = 0;

	// Token: 0x04000C3D RID: 3133
	public static sbyte TYPE_REPLACE_PLUS = 1;

	// Token: 0x04000C3E RID: 3134
	public static sbyte TYPE_REBUILD_WING = 2;

	// Token: 0x04000C3F RID: 3135
	public static sbyte TYPE_KHAM_NGOC = 3;

	// Token: 0x04000C40 RID: 3136
	public static sbyte TYPE_GHEP_NGOC = 4;

	// Token: 0x04000C41 RID: 3137
	public static sbyte TYPE_DUC_LO = 5;

	// Token: 0x04000C42 RID: 3138
	public static sbyte TYPE_ANY = 6;

	// Token: 0x04000C43 RID: 3139
	public static sbyte KHAM_NGOC = 0;

	// Token: 0x04000C44 RID: 3140
	public static sbyte GHEP_NGOC = 1;

	// Token: 0x04000C45 RID: 3141
	public static sbyte DUC_LO = 2;

	// Token: 0x04000C46 RID: 3142
	private int maxw;

	// Token: 0x04000C47 RID: 3143
	private int maxh;

	// Token: 0x04000C48 RID: 3144
	private int indexPaint = 12;

	// Token: 0x04000C49 RID: 3145
	private int winfo = 140;

	// Token: 0x04000C4A RID: 3146
	private int[][] posMaterial;

	// Token: 0x04000C4B RID: 3147
	public static string[] mNameMaterial;

	// Token: 0x04000C4C RID: 3148
	public static string[] numofGem = new string[]
	{
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty,
		string.Empty
	};

	// Token: 0x04000C4D RID: 3149
	public static sbyte[] numColor = new sbyte[5];

	// Token: 0x04000C4E RID: 3150
	private int xinfo;

	// Token: 0x04000C4F RID: 3151
	private int yinfo;

	// Token: 0x04000C50 RID: 3152
	public static DataRebuildItem[] dataRebuild;

	// Token: 0x04000C51 RID: 3153
	public static MainItem itemRe;

	// Token: 0x04000C52 RID: 3154
	public static MainItem itemPlus;

	// Token: 0x04000C53 RID: 3155
	public static MainItem itemFree;

	// Token: 0x04000C54 RID: 3156
	public static MainItem itemWing;

	// Token: 0x04000C55 RID: 3157
	public static int[] numMaterialInven;

	// Token: 0x04000C56 RID: 3158
	public static short[] idMaterial;

	// Token: 0x04000C57 RID: 3159
	public static int[] numWingMaterialInven;

	// Token: 0x04000C58 RID: 3160
	public static DataRebuildItem[] dataWing;

	// Token: 0x04000C59 RID: 3161
	public static int priceWing = 0;

	// Token: 0x04000C5A RID: 3162
	public static int timeUseWing;

	// Token: 0x04000C5B RID: 3163
	public static string nameWing = string.Empty;

	// Token: 0x04000C5C RID: 3164
	public static int isChetao = 0;

	// Token: 0x04000C5D RID: 3165
	public static short lvReWing = 0;

	// Token: 0x04000C5E RID: 3166
	public static short idWingOk = 0;

	// Token: 0x04000C5F RID: 3167
	public static string tilemayman = "test nao";

	// Token: 0x04000C60 RID: 3168
	public static string tilemaymanafter;

	// Token: 0x04000C61 RID: 3169
	public static sbyte isBeginEff = 0;

	// Token: 0x04000C62 RID: 3170
	public static sbyte isNextRebuild = 0;

	// Token: 0x04000C63 RID: 3171
	public static bool isLucky = false;

	// Token: 0x04000C64 RID: 3172
	public static bool isShow;

	// Token: 0x04000C65 RID: 3173
	private iCommand cmdHoiDap;

	// Token: 0x04000C66 RID: 3174
	private iCommand cmdView;

	// Token: 0x04000C67 RID: 3175
	private iCommand cmcloseInfo;

	// Token: 0x04000C68 RID: 3176
	private iCommand cmdHoiReplace;

	// Token: 0x04000C69 RID: 3177
	private iCommand cmdHoiReWing;

	// Token: 0x04000C6A RID: 3178
	private iCommand cmdHopThanh;

	// Token: 0x04000C6B RID: 3179
	public static mVector vecEffRe = new mVector("TabRebuildItem vecEffRe");

	// Token: 0x04000C6C RID: 3180
	public static string contentShow = string.Empty;

	// Token: 0x04000C6D RID: 3181
	private mVector vecListCmd = new mVector("TabRebuildItem vecListCmd");

	// Token: 0x04000C6E RID: 3182
	public static mVector vecGem = new mVector("TabRebuildItem vecGem");

	// Token: 0x04000C6F RID: 3183
	public static bool resetItemReplace = false;

	// Token: 0x04000C70 RID: 3184
	public sbyte typekham;

	// Token: 0x04000C71 RID: 3185
	public bool ispaintitemRe;

	// Token: 0x04000C72 RID: 3186
	public static Item itemDaMayMan = null;

	// Token: 0x04000C73 RID: 3187
	private Scroll scr = new Scroll();

	// Token: 0x04000C74 RID: 3188
	private int timeShowReplace;

	// Token: 0x04000C75 RID: 3189
	private long time;

	// Token: 0x04000C76 RID: 3190
	public static sbyte countSetpaintinfo = 0;
}
