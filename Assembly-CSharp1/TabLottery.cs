using System;

// Token: 0x0200009F RID: 159
public class TabLottery : MainTabNew
{
	// Token: 0x060007A9 RID: 1961 RVA: 0x0007A8A0 File Offset: 0x00078AA0
	public TabLottery(string name, mVector rewards, sbyte type)
	{
		this.nameTab = name;
		this.endDraw = false;
		this.moveDone = true;
		this.moveCount = 0;
		this.velocity = 0f;
		this.acceleration = 1f;
		this.itemVel = 1f;
		this.selectIdx = -1;
		this.curSelectPointerIdx = -1;
		this.selectNumber = -1;
		this.vecRewardList = rewards;
		this.typeTab = MainTabNew.INVENTORY;
		TabLottery.waitForNewPlay = false;
		TabLottery.sectionType = type;
		this.xBegin = this.xTab + (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 3;
		this.yBegin = this.yTab + GameCanvas.h / 5 + (int)MainTabNew.wOneItem;
		this.maxw = (MainTabNew.wblack - 8) / 32;
		this.maxh = (MainTabNew.hblack - 8) / 32;
		this.fixPosArray = new mVector2[5];
		this.fixPosArray[0] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.fixPosArray[1] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.fixPosArray[2] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.fixPosArray[3] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.fixPosArray[4] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2), (float)(this.yBegin + MainTabNew.hblack / 2 - 52));
		this.posArray = new mVector2[5];
		this.posArray[0] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.posArray[1] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.posArray[2] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.posArray[3] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.posArray[4] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2), (float)(this.yBegin + MainTabNew.hblack / 2 - 52));
		this.objPosArray = new mVector2[5];
		this.objPosArray[0] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.objPosArray[1] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 - 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.objPosArray[2] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 32), (float)(this.yBegin + MainTabNew.hblack / 2 + 45));
		this.objPosArray[3] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2 + 52), (float)(this.yBegin + MainTabNew.hblack / 2 - 16));
		this.objPosArray[4] = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2), (float)(this.yBegin + MainTabNew.hblack / 2 - 52));
		this.rewardPos = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2), (float)(this.yBegin + MainTabNew.hblack / 2));
		TabLottery.cmdStartDraw = new iCommand(T.startdraw, 0, this);
		TabLottery.cmdGetItem = new iCommand(T.select, 1, this);
		TabLottery.cmdRepick = new iCommand(T.chonlai, 2, this);
		TabLottery.cmdContinue = new iCommand(T.choitiep, 4, this);
		TabLottery.cmdSelectGlass = new iCommand(T.select, 3, this);
		this.cmdBack = new iCommand(T.back, -1, this);
		if (GameCanvas.isTouch)
		{
			this.cmdBack.caption = T.close;
		}
		if (MainTabNew.longwidth > 0)
		{
			int num = MainTabNew.ylongwidth + this.hSmall;
			int xlongwidth = MainTabNew.xlongwidth;
			if (MainTabNew.is320)
			{
				TabLottery.cmdStartDraw.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, TabLottery.cmdStartDraw.caption);
				TabLottery.cmdGetItem.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 10, PaintInfoGameScreen.fraButton2, TabLottery.cmdGetItem.caption);
				TabLottery.cmdRepick.setPos(xlongwidth + MainTabNew.longwidth / 2 - 30, num - 10, PaintInfoGameScreen.fraButton2, TabLottery.cmdRepick.caption);
				TabLottery.cmdContinue.setPos(xlongwidth + MainTabNew.longwidth / 2 + 30, num - 10, PaintInfoGameScreen.fraButton2, TabLottery.cmdContinue.caption);
			}
			else
			{
				TabLottery.cmdStartDraw.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 15, null, TabLottery.cmdStartDraw.caption);
				TabLottery.cmdGetItem.setPos(xlongwidth + MainTabNew.longwidth / 2, num - 15, null, TabLottery.cmdGetItem.caption);
				TabLottery.cmdRepick.setPos(xlongwidth + MainTabNew.longwidth / 2 - 42, num - 15, null, TabLottery.cmdRepick.caption);
				TabLottery.cmdContinue.setPos(xlongwidth + MainTabNew.longwidth / 2 + 42, num - 15, null, TabLottery.cmdContinue.caption);
			}
		}
		else if (GameCanvas.isTouch)
		{
			TabLottery.cmdStartDraw.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, TabLottery.cmdStartDraw.caption);
			TabLottery.cmdGetItem.setPos(iCommand.wButtonCmd / 2 + 2, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, TabLottery.cmdGetItem.caption);
			TabLottery.cmdRepick.setPos(iCommand.wButtonCmd / 2 + 2 - 42, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, TabLottery.cmdRepick.caption);
			TabLottery.cmdContinue.setPos(iCommand.wButtonCmd / 2 + 2 + 42, GameCanvas.h - iCommand.hButtonCmd / 2 - 2, null, TabLottery.cmdContinue.caption);
		}
		this.init();
	}

	// Token: 0x060007AB RID: 1963 RVA: 0x0007AFE0 File Offset: 0x000791E0
	public static void changeSection(sbyte section)
	{
		TabLottery.sectionType = section;
		TabLottery.setCommand();
	}

	// Token: 0x060007AC RID: 1964 RVA: 0x0007AFF0 File Offset: 0x000791F0
	public static void setLuckyNumber(sbyte number)
	{
		TabLottery.luckyNumber = number;
	}

	// Token: 0x060007AD RID: 1965 RVA: 0x0007AFF8 File Offset: 0x000791F8
	private static void setCommand()
	{
		if (GameCanvas.isTouch)
		{
			TabLottery.vecListCmd.removeAllElements();
			if ((int)TabLottery.sectionType == 0)
			{
				TabLottery.vecListCmd.addElement(TabLottery.cmdGetItem);
			}
			else if (TabLottery.waitForNewPlay)
			{
				TabLottery.vecListCmd.addElement(TabLottery.cmdRepick);
				TabLottery.vecListCmd.addElement(TabLottery.cmdContinue);
			}
			else if (!TabLottery.beginDraw)
			{
				TabLottery.vecListCmd.addElement(TabLottery.cmdStartDraw);
			}
		}
	}

	// Token: 0x060007AE RID: 1966 RVA: 0x0007B084 File Offset: 0x00079284
	public new void init()
	{
		this.list = new ListNew(this.xBegin, this.yBegin, MainTabNew.wblack, MainTabNew.hblack, 0, 0, MainScreen.cameraSub.yLimit);
		TabLottery.setCommand();
		if (!GameCanvas.isTouch)
		{
			this.center = TabLottery.cmdGetItem;
			this.right = this.cmdBack;
		}
		this.vecEffEnd.removeAllElements();
		this.imgStarRebuild = mImage.createImage("/interface/rebuild.img");
	}

	// Token: 0x060007AF RID: 1967 RVA: 0x0007B100 File Offset: 0x00079300
	public override void paint(mGraphics g)
	{
		if ((int)TabLottery.sectionType == 0)
		{
			this.paintChooseRewardSection(g);
		}
		else if ((int)TabLottery.sectionType == 1)
		{
			this.paintDrawingSection(g);
		}
	}

	// Token: 0x060007B0 RID: 1968 RVA: 0x0007B138 File Offset: 0x00079338
	private void paintChooseRewardSection(mGraphics g)
	{
		try
		{
			GameCanvas.resetTrans(g);
			g.setClip(this.xBegin - (int)MainTabNew.wOne5, this.yBegin, MainTabNew.wblack + (int)MainTabNew.wOne5 * 2, MainTabNew.hblack - (int)MainTabNew.wOne5 / 2 + 1);
			g.translate(-MainScreen.cameraSub.xCam, -MainScreen.cameraSub.yCam);
			for (int i = 0; i < this.vecRewardList.size(); i++)
			{
				Item item = (Item)this.vecRewardList.elementAt(i);
				if (item != null)
				{
					if (item.ItemCatagory == 7)
					{
						MainItem material = Item.getMaterial(item.Id);
						if (material != null)
						{
							item.setinfo(material.itemName, material.imageId, 7, material.priceItem, material.priceType, material.content, (int)((short)material.value), material.typeMaterial, 1, material.canSell, material.canTrade);
							item.paintItem(g, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
							if (item.timeUse > 0)
							{
								g.drawRegion(AvMain.imgDelaySkill, 0, 0, (int)MainTabNew.wOneItem - 1, (int)MainTabNew.wOneItem - 1, 0, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, 3, mGraphics.isTrue);
							}
						}
						else
						{
							Item.put_Material(item.Id);
						}
					}
					else
					{
						item.paintItem(g, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
						if (item.timeUse > 0)
						{
							g.drawRegion(AvMain.imgDelaySkill, 0, 0, (int)MainTabNew.wOneItem - 1, (int)MainTabNew.wOneItem - 1, 0, this.xBegin + (int)MainTabNew.wOneItem / 2 + i % this.numW * (int)MainTabNew.wOneItem, this.yBegin + (int)MainTabNew.wOneItem / 2 + i / this.numW * (int)MainTabNew.wOneItem, 3, mGraphics.isTrue);
						}
					}
				}
			}
			g.setColor(MainTabNew.color[1]);
			g.drawRect(this.xBegin, this.yBegin, MainTabNew.wblack, (int)MainTabNew.wOneItem * this.numH, mGraphics.isTrue);
			for (int j = 0; j < this.numW / 2; j++)
			{
				g.drawRect(this.xBegin + (int)MainTabNew.wOneItem + j * (int)MainTabNew.wOneItem * 2, this.yBegin, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * this.numH, mGraphics.isTrue);
			}
			for (int k = 0; k < this.numH / 2; k++)
			{
				g.drawRect(this.xBegin, this.yBegin + (int)MainTabNew.wOneItem + k * (int)MainTabNew.wOneItem * 2, MainTabNew.wblack, (int)MainTabNew.wOneItem, mGraphics.isTrue);
			}
			if (this.itemIdSelect > -1 && (int)MainTabNew.Focus == (int)MainTabNew.INFO)
			{
				g.setColor(MainTabNew.color[2]);
				g.drawRect(this.xBegin + this.itemIdSelect % this.numW * (int)MainTabNew.wOneItem + 1, this.yBegin + this.itemIdSelect / this.numW * (int)MainTabNew.wOneItem + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
				g.setColor(MainTabNew.color[3]);
				g.drawRect(this.xBegin + this.itemIdSelect % this.numW * (int)MainTabNew.wOneItem, this.yBegin + this.itemIdSelect / this.numW * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, mGraphics.isTrue);
			}
			g.endClip();
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (int)MainTabNew.Focus == (int)MainTabNew.INFO && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
			{
				base.paintPopupContent(g, false);
				if (TabLottery.vecListCmd != null)
				{
					for (int l = 0; l < TabLottery.vecListCmd.size(); l++)
					{
						iCommand iCommand = (iCommand)TabLottery.vecListCmd.elementAt(l);
						iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060007B1 RID: 1969 RVA: 0x0007B640 File Offset: 0x00079840
	private void paintDrawingSection(mGraphics g)
	{
		try
		{
			g.fillRect(this.xBegin + 2, this.yBegin + 2, MainTabNew.wblack - 4, MainTabNew.hblack - 4, mGraphics.isTrue);
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, this.xBegin + 4, this.yBegin + 4, MainTabNew.wblack - 8, MainTabNew.hblack - 8, 4);
			}
			else
			{
				this.paintRect(g);
			}
			g.drawImage(this.imgStarRebuild, this.xBegin + MainTabNew.wblack / 2 - 54, this.yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isTrue);
			g.drawRegion(this.imgStarRebuild, 0, 0, 54, 105, 2, this.xBegin + MainTabNew.wblack / 2, this.yBegin + MainTabNew.hblack / 2 - 52, 0, mGraphics.isTrue);
			Item item = (Item)this.vecRewardList.elementAt(this.itemIdSelect);
			if (!TabLottery.isReady && item != null)
			{
				g.drawImage(AvMain.imgHotKey, (int)this.rewardPos.x, (int)this.rewardPos.y, 3, mGraphics.isTrue);
				item.paintItem(g, (int)this.rewardPos.x, (int)this.rewardPos.y, 20, 0, 0);
			}
			int i = 0;
			while (i < this.objPosArray.Length)
			{
				if (this.selectNumber == -1)
				{
					g.drawImage(AvMain.imgGlass, (int)this.objPosArray[i].x, (int)this.objPosArray[i].y, 3, mGraphics.isTrue);
					goto IL_2CC;
				}
				if (TabLottery.isWin)
				{
					if ((int)TabLottery.luckyNumber == i)
					{
						g.drawImage(AvMain.imgHotKey, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 3, mGraphics.isTrue);
						item.paintItem(g, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 20, 0, 0);
					}
					else
					{
						g.drawImage(AvMain.imgGlass, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 3, mGraphics.isTrue);
					}
					goto IL_2CC;
				}
				if ((int)TabLottery.luckyNumber == i)
				{
					g.drawImage(AvMain.imgHotKey, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 3, mGraphics.isTrue);
					item.paintItem(g, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 20, 0, 0);
					goto IL_2CC;
				}
				if (this.selectNumber != i)
				{
					g.drawImage(AvMain.imgGlass, (int)this.fixPosArray[i].x, (int)this.fixPosArray[i].y, 3, mGraphics.isTrue);
					goto IL_2CC;
				}
				IL_371:
				i++;
				continue;
				IL_2CC:
				if (!GameCanvas.isTouch && this.endDraw && this.curSelectPointerIdx > -1)
				{
					if (MainObject.Wfc == 0)
					{
						MainObject.Wfc = mImage.getImageWidth(MainObject.newfocus.image);
						MainObject.Hfc = mImage.getImageHeight(MainObject.newfocus.image) / 10;
					}
					g.drawRegion(MainObject.newfocus, 0, 0, MainObject.Wfc, MainObject.Hfc, 0, (int)this.fixPosArray[this.curSelectPointerIdx].x, (int)this.fixPosArray[this.curSelectPointerIdx].y - GameCanvas.gameTick % 5 - 10, 3, mGraphics.isTrue);
					goto IL_371;
				}
				goto IL_371;
			}
			for (int j = 0; j < this.vecEffEnd.size(); j++)
			{
				MainEffect mainEffect = (MainEffect)this.vecEffEnd.elementAt(j);
				mainEffect.paint(g);
			}
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && ((int)MainTabNew.Focus == (int)MainTabNew.INFO || MainTabNew.longwidth > 0) && TabLottery.vecListCmd != null)
			{
				for (int k = 0; k < TabLottery.vecListCmd.size(); k++)
				{
					iCommand iCommand = (iCommand)TabLottery.vecListCmd.elementAt(k);
					iCommand.paint(g, iCommand.xCmd, iCommand.yCmd);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060007B2 RID: 1970 RVA: 0x0007BAC0 File Offset: 0x00079CC0
	private void paintRect(mGraphics g)
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
						g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + (MainTabNew.wblack - 8) - 32, this.yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isTrue);
					}
					else
					{
						g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + (MainTabNew.wblack - 8) - 32, this.yBegin + 4 + j * 32, 0, mGraphics.isTrue);
					}
				}
				else if (j == this.maxh)
				{
					g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + i * 32, this.yBegin + 4 + MainTabNew.hblack - 8 - 32, 0, mGraphics.isTrue);
				}
				else
				{
					g.drawImage(MainTabNew.imgTab[this.indexPaint], this.xBegin + 4 + i * 32, this.yBegin + 4 + j * 32, 0, mGraphics.isTrue);
				}
			}
		}
	}

	// Token: 0x060007B3 RID: 1971 RVA: 0x0007BC24 File Offset: 0x00079E24
	public override void update()
	{
		try
		{
			if ((int)TabLottery.sectionType == 0)
			{
				if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
				{
					if (this.listContent != null)
					{
						this.listContent.moveCamera();
					}
					if (GameCanvas.isTouch)
					{
						this.list.moveCamera();
					}
					else
					{
						MainScreen.cameraSub.UpdateCamera();
					}
					mVector mVector = this.vecRewardList;
					if (mVector.size() == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						this.updateContent(mVector, this.itemIdSelect);
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
				}
			}
			else if ((int)TabLottery.sectionType == 1)
			{
				for (int i = 0; i < this.vecEffEnd.size(); i++)
				{
					MainEffect mainEffect = (MainEffect)this.vecEffEnd.elementAt(i);
					mainEffect.update();
					if (mainEffect.isStop)
					{
						this.vecEffEnd.removeElement(mainEffect);
					}
				}
				if (this.selectIdx > -1)
				{
					EffectEnd o = new EffectEnd(34, (int)this.fixPosArray[this.selectIdx].x, (int)this.fixPosArray[this.selectIdx].y);
					this.vecEffEnd.addElement(o);
					GlobalService.gI().request_LotteryItems(2, (sbyte)this.selectIdx);
					this.selectNumber = this.selectIdx;
					this.selectIdx = -1;
					this.endDraw = false;
					TabLottery.waitForNewPlay = true;
					TabLottery.setCommand();
				}
				if (!TabLottery.isReady)
				{
					mVector2 mVector2 = mVector2.substract(this.rewardPos, this.posArray[(int)TabLottery.luckyNumber]);
					mVector2.normalize();
					this.itemVel += 0.5f;
					this.rewardPos.add(mVector2.x * this.itemVel, mVector2.y * this.itemVel);
					if (this.atDestination(this.rewardPos, this.posArray[(int)TabLottery.luckyNumber]))
					{
						TabLottery.luckyNumber = -1;
						TabLottery.isReady = true;
					}
				}
				if (this.moveCount >= 30)
				{
					TabLottery.beginDraw = false;
				}
				if (TabLottery.beginDraw)
				{
					GameCanvas.isPointerSelect = false;
					if (this.moveDone)
					{
						int num = 0;
						if (this.moveCount > 16)
						{
							num = CRes.random(0, 2);
						}
						int num2;
						if (num == 0)
						{
							num2 = 2;
						}
						else
						{
							num2 = 4;
						}
						int j = 0;
						while (j < num2)
						{
							bool flag = false;
							int num3 = CRes.random(0, 5);
							for (int k = 0; k < this.ranIdx.Length; k++)
							{
								if (num3 == this.ranIdx[k])
								{
									flag = true;
								}
							}
							if (!flag)
							{
								this.ranIdx[j] = num3;
								j++;
							}
						}
						this.moveVec1 = mVector2.substract(this.objPosArray[this.ranIdx[0]], this.objPosArray[this.ranIdx[1]]);
						this.moveVec2 = mVector2.substract(this.objPosArray[this.ranIdx[1]], this.objPosArray[this.ranIdx[0]]);
						this.moveVec1.normalize();
						this.moveVec2.normalize();
						if (this.ranIdx[2] > -1 && this.ranIdx[3] > -1)
						{
							this.moveVec3 = mVector2.substract(this.objPosArray[this.ranIdx[2]], this.objPosArray[this.ranIdx[3]]);
							this.moveVec4 = mVector2.substract(this.objPosArray[this.ranIdx[3]], this.objPosArray[this.ranIdx[2]]);
							this.moveVec3.normalize();
							this.moveVec4.normalize();
						}
						this.moveDone = false;
						this.velocity = (float)((this.moveCount >= 16) ? 16 : this.moveCount);
					}
					else
					{
						if (this.velocity < 16f)
						{
							this.velocity += this.acceleration;
						}
						this.objPosArray[this.ranIdx[0]].add(this.moveVec1.x * this.velocity, this.moveVec1.y * this.velocity);
						this.objPosArray[this.ranIdx[1]].add(this.moveVec2.x * this.velocity, this.moveVec2.y * this.velocity);
						if (this.ranIdx[2] > -1 && this.ranIdx[3] > -1)
						{
							this.objPosArray[this.ranIdx[2]].add(this.moveVec3.x * this.velocity, this.moveVec3.y * this.velocity);
							this.objPosArray[this.ranIdx[3]].add(this.moveVec4.x * this.velocity, this.moveVec4.y * this.velocity);
						}
						if (this.atDestination(this.objPosArray[this.ranIdx[0]], this.posArray[this.ranIdx[1]]))
						{
							this.objPosArray[this.ranIdx[0]].set(this.posArray[this.ranIdx[1]]);
							this.objPosArray[this.ranIdx[1]].set(this.posArray[this.ranIdx[0]]);
							this.posArray[this.ranIdx[0]].set(this.objPosArray[this.ranIdx[0]]);
							this.posArray[this.ranIdx[1]].set(this.objPosArray[this.ranIdx[1]]);
							if (this.ranIdx[2] > -1 && this.ranIdx[3] > -1)
							{
								this.objPosArray[this.ranIdx[2]].set(this.posArray[this.ranIdx[3]]);
								this.objPosArray[this.ranIdx[3]].set(this.posArray[this.ranIdx[2]]);
								this.posArray[this.ranIdx[2]].set(this.objPosArray[this.ranIdx[2]]);
								this.posArray[this.ranIdx[3]].set(this.objPosArray[this.ranIdx[3]]);
							}
							if (this.moveCount == 29)
							{
								this.endDraw = true;
								this.curSelectPointerIdx = 0;
								if (!GameCanvas.isTouch)
								{
									this.center = TabLottery.cmdSelectGlass;
								}
							}
							this.moveDone = true;
							this.moveCount++;
							for (int l = 0; l < this.ranIdx.Length; l++)
							{
								this.ranIdx[l] = -1;
							}
						}
					}
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060007B4 RID: 1972 RVA: 0x0007C31C File Offset: 0x0007A51C
	private void updateContent(mVector vec, int idSelect)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				this.setPaintInfo();
			}
		}
		if (this.mContent == null && idSelect >= 0 && idSelect < vec.size())
		{
			Item item = (Item)vec.elementAt(idSelect);
			if (item.ItemCatagory != 5)
			{
				if (item.mcontent == null)
				{
					if (item.timeupdateMore % 100 == 3)
					{
						if ((int)this.typeTab == (int)MainTabNew.INVENTORY)
						{
							GlobalService.gI().Item_More_Info(0, (sbyte)item.Id);
						}
						item.timeupdateMore++;
					}
					else
					{
						item.timeupdateMore++;
					}
				}
				else
				{
					this.mContent = item.mcontent;
					this.mcolor = item.mColor;
					this.setYCon(item);
				}
			}
		}
	}

	// Token: 0x060007B5 RID: 1973 RVA: 0x0007C418 File Offset: 0x0007A618
	public new void setYCon(Item item)
	{
		int num = 0;
		if (MainScreen.cameraSub.yCam > 0)
		{
			num = MainScreen.cameraSub.yCam / (int)MainTabNew.wOneItem;
		}
		int num2 = 1;
		this.mContent = item.mcontent;
		this.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num2 += this.mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num2 += item.mPlusContent.Length;
		}
		if (this.itemIdSelect / this.numW < this.numHPaint / 2 + num)
		{
			this.yCon = this.yBegin + (this.itemIdSelect / this.numW + 1) * (int)MainTabNew.wOneItem + 2;
			if (this.yCon - MainScreen.cameraSub.yCam + (num2 + 1) * GameCanvas.hText > GameCanvas.h - (GameCanvas.hCommand - 5))
			{
				this.yCon = GameCanvas.h - (GameCanvas.hCommand - 5) - ((num2 + 1) * GameCanvas.hText - MainScreen.cameraSub.yCam);
			}
		}
		else
		{
			this.yCon = this.yBegin + this.itemIdSelect / this.numW * (int)MainTabNew.wOneItem - 7 - num2 * GameCanvas.hText - MainScreen.cameraSub.yCam;
			if (this.yCon - MainScreen.cameraSub.yCam < 6)
			{
				this.yCon = 6 + MainScreen.cameraSub.yCam;
			}
		}
		if ((num2 + 1) * GameCanvas.hText > MainTabNew.hMaxContent - this.hcmd)
		{
			this.listContent = new ListNew(this.xCon, this.yCon, this.wContent, MainTabNew.hMaxContent, 0, 0, (num2 + 1) * GameCanvas.hText - (MainTabNew.hMaxContent - this.hcmd));
		}
	}

	// Token: 0x060007B6 RID: 1974 RVA: 0x0007C5E0 File Offset: 0x0007A7E0
	public new void setPaintInfo()
	{
		mVector mVector = this.vecRewardList;
		this.mContent = null;
		this.mSubContent = null;
		this.mPlusContent = null;
		if (this.itemIdSelect >= mVector.size() || this.itemIdSelect < 0)
		{
			if (this.itemIdSelect > mVector.size() - 1)
			{
				this.itemIdSelect = mVector.size() - 1;
			}
			MainTabNew.timePaintInfo = 0;
			return;
		}
		Item item = (Item)mVector.elementAt(this.itemIdSelect);
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.ItemCatagory == 9)
		{
			MsgDialog.pet = (PetItem)item;
			this.isPet = true;
		}
		else
		{
			this.isPet = false;
		}
		this.name = item.itemName;
		this.colorName = item.colorNameItem;
		if (item.ItemCatagory == 3 || (int)this.typeTab == (int)MainTabNew.SHOP)
		{
			this.mPlusContent = item.mPlusContent;
			this.mPlusColor = item.mPlusColor;
		}
		this.listContent = null;
		if (MainTabNew.longwidth > 0)
		{
			int num = 1;
			this.mContent = item.mcontent;
			this.mcolor = item.mColor;
			if (item.mcontent != null)
			{
				num += this.mContent.Length;
			}
			if (item.mPlusContent != null)
			{
				num += item.mPlusContent.Length;
			}
			if (num * GameCanvas.hText > MainTabNew.hMaxContent)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, num * GameCanvas.hText - MainTabNew.hMaxContent);
			}
			else if (GameCanvas.isTouch)
			{
				this.listContent = new ListNew(MainTabNew.xlongwidth, MainTabNew.ylongwidth, MainTabNew.longwidth, MainTabNew.hMaxContent, 0, 0, 0);
			}
			return;
		}
		this.wContent = item.sizeW;
		this.setYCon(item);
		if (this.itemIdSelect % this.numW < 2)
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.itemIdSelect % this.numW * (int)MainTabNew.wOneItem;
		}
		else if (this.itemIdSelect % this.numW < 5)
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.itemIdSelect % this.numW * (int)MainTabNew.wOneItem - this.wContent / 2;
		}
		else
		{
			this.xCon = this.xBegin + (int)MainTabNew.wOneItem / 2 + this.itemIdSelect % this.numW * (int)MainTabNew.wOneItem - this.wContent;
		}
	}

	// Token: 0x060007B7 RID: 1975 RVA: 0x0007C888 File Offset: 0x0007AA88
	public new void backTab()
	{
		MainTabNew.Focus = MainTabNew.TAB;
		base.backTab();
	}

	// Token: 0x060007B8 RID: 1976 RVA: 0x0007C89C File Offset: 0x0007AA9C
	private bool atDestination(mVector2 location, mVector2 destination)
	{
		float num = mVector2.distance(location, destination);
		return num < 20f;
	}

	// Token: 0x060007B9 RID: 1977 RVA: 0x0007C8C0 File Offset: 0x0007AAC0
	public override void updatekey()
	{
		mVector mVector = this.vecRewardList;
		if ((int)MainTabNew.Focus == (int)MainTabNew.INFO)
		{
			int num = this.itemIdSelect;
			bool flag = false;
			if ((int)TabLottery.sectionType == 1)
			{
				if (this.endDraw)
				{
					if (GameCanvas.keyMyHold[4])
					{
						this.curSelectPointerIdx--;
						if (this.curSelectPointerIdx < 0)
						{
							this.curSelectPointerIdx = 4;
						}
						GameCanvas.clearKeyHold(4);
					}
					else if (GameCanvas.keyMyHold[6])
					{
						this.curSelectPointerIdx++;
						if (this.curSelectPointerIdx > 4)
						{
							this.curSelectPointerIdx = 0;
						}
						GameCanvas.clearKeyHold(6);
					}
				}
			}
			else
			{
				if (this.listContent != null)
				{
					if (GameCanvas.keyMyHold[2])
					{
						if (this.listContent.cmtoX > 0)
						{
							this.listContent.cmtoX -= GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = 0;
						}
						GameCanvas.clearKeyHold(2);
					}
					else if (GameCanvas.keyMyHold[8])
					{
						if (this.listContent.cmtoX < this.listContent.cmxLim)
						{
							this.listContent.cmtoX += GameCanvas.hText;
						}
						else
						{
							this.listContent.cmtoX = this.listContent.cmxLim;
						}
						GameCanvas.clearKeyHold(8);
					}
				}
				else if (GameCanvas.keyMyHold[2])
				{
					this.itemIdSelect -= this.numW;
					GameCanvas.clearKeyHold(2);
					flag = true;
				}
				else if (GameCanvas.keyMyHold[8])
				{
					this.itemIdSelect += this.numW;
					GameCanvas.clearKeyHold(8);
					flag = true;
				}
				if (GameCanvas.keyMyHold[4])
				{
					if (this.itemIdSelect % this.numW == 0)
					{
						MainTabNew.Focus = MainTabNew.TAB;
					}
					else
					{
						this.itemIdSelect--;
					}
					GameCanvas.clearKeyHold(4);
					flag = true;
				}
				else if (GameCanvas.keyMyHold[6])
				{
					this.itemIdSelect++;
					GameCanvas.clearKeyHold(6);
					flag = true;
				}
				if (flag)
				{
					this.listContent = null;
					this.itemIdSelect = base.resetSelect(this.itemIdSelect, mVector.size() - 1, false);
					if (GameCanvas.isTouch || (int)this.typeTab == (int)MainTabNew.INVENTORY || (int)this.typeTab == (int)MainTabNew.CHEST)
					{
					}
					TabScreenNew.timeRepaint = 10;
				}
				if (num != this.itemIdSelect)
				{
					MainScreen.cameraSub.moveCamera(0, (this.itemIdSelect / this.numW - 1) * (int)MainTabNew.wOneItem);
					MainTabNew.timePaintInfo = 0;
				}
			}
		}
		base.updatekey();
	}

	// Token: 0x060007BA RID: 1978 RVA: 0x0007CB88 File Offset: 0x0007AD88
	public override void updatePointer()
	{
		if ((int)TabLottery.sectionType == 1)
		{
			int imageWidth = mImage.getImageWidth(AvMain.imgGlass.image);
			int imageHeight = mImage.getImageHeight(AvMain.imgGlass.image);
			if (this.endDraw)
			{
				for (int i = 0; i < this.posArray.Length; i++)
				{
					if (GameCanvas.isPointSelect((int)this.fixPosArray[i].x - imageWidth / 2, (int)this.fixPosArray[i].y - imageHeight / 2, imageWidth, imageHeight))
					{
						this.selectIdx = i;
						GameCanvas.isPointerSelect = false;
						break;
					}
				}
			}
		}
		else if ((int)TabLottery.sectionType == 0)
		{
			bool flag = false;
			if (this.listContent != null && GameCanvas.isPoint(this.listContent.x, this.listContent.y, this.listContent.maxW, this.listContent.maxH))
			{
				this.listContent.update_Pos_UP_DOWN();
				flag = true;
			}
			if (GameCanvas.isTouch && !flag)
			{
				this.list.update_Pos_UP_DOWN();
				MainScreen.cameraSub.yCam = this.list.cmx;
			}
			if (GameCanvas.isPointSelect(this.xBegin, this.yBegin, this.numW * (int)MainTabNew.wOneItem, MainTabNew.hblack - (int)MainTabNew.wOne5 / 2) && !flag)
			{
				int num = (GameCanvas.px - this.xBegin) / (int)MainTabNew.wOneItem + (GameCanvas.py - this.yBegin + MainScreen.cameraSub.yCam) / (int)MainTabNew.wOneItem * this.numW;
				if (num >= 0 && num < this.vecRewardList.size())
				{
					GameCanvas.isPointerSelect = false;
					MainTabNew.timePaintInfo = 0;
					this.itemIdSelect = num;
					if ((int)MainTabNew.Focus != (int)MainTabNew.INFO)
					{
						MainTabNew.Focus = MainTabNew.INFO;
					}
				}
				else
				{
					MainTabNew.timePaintInfo = 0;
					this.itemIdSelect = -1;
				}
			}
		}
		if (TabLottery.vecListCmd != null && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && ((int)MainTabNew.Focus == (int)MainTabNew.INFO || MainTabNew.longwidth > 0))
		{
			for (int j = 0; j < TabLottery.vecListCmd.size(); j++)
			{
				iCommand iCommand = (iCommand)TabLottery.vecListCmd.elementAt(j);
				iCommand.updatePointer();
			}
		}
		base.updatePointer();
	}

	// Token: 0x060007BB RID: 1979 RVA: 0x0007CE0C File Offset: 0x0007B00C
	public override void commandTab(int index, int sub)
	{
		base.commandTab(index, sub);
	}

	// Token: 0x060007BC RID: 1980 RVA: 0x0007CE18 File Offset: 0x0007B018
	public override void commandPointer(int index, int subIndex)
	{
		switch (index + 1)
		{
		case 0:
			if (TabLottery.waitForNewPlay)
			{
				GameCanvas.game.Show();
			}
			else
			{
				this.backTab();
			}
			break;
		case 1:
			if (TabLottery.beginDraw || this.endDraw)
			{
				return;
			}
			TabLottery.beginDraw = true;
			this.moveCount = 0;
			this.velocity = 0f;
			if (!GameCanvas.isTouch)
			{
				this.center = null;
				this.right = null;
				this.left = null;
			}
			TabLottery.setCommand();
			break;
		case 2:
			if (!TabLottery.waitForNewPlay)
			{
				GlobalService.gI().request_LotteryItems(1, (sbyte)this.itemIdSelect);
				if (!GameCanvas.isTouch)
				{
					this.center = TabLottery.cmdStartDraw;
					this.right = null;
					this.left = null;
				}
			}
			break;
		case 3:
			GlobalService.gI().request_LotteryItems(0, 0);
			break;
		case 4:
			this.selectIdx = this.curSelectPointerIdx;
			if (!GameCanvas.isTouch)
			{
				this.center = TabLottery.cmdContinue;
				this.left = TabLottery.cmdRepick;
				this.cmdBack.caption = T.close;
				this.right = this.cmdBack;
			}
			break;
		case 5:
			GlobalService.gI().request_LotteryItems(1, (sbyte)this.itemIdSelect);
			if (!GameCanvas.isTouch)
			{
				this.center = TabLottery.cmdStartDraw;
				this.right = null;
				this.left = null;
			}
			TabLottery.waitForNewPlay = false;
			TabLottery.beginDraw = false;
			this.endDraw = false;
			this.moveDone = true;
			TabLottery.isWin = false;
			this.moveCount = 0;
			this.selectIdx = -1;
			this.curSelectPointerIdx = -1;
			this.selectNumber = -1;
			TabLottery.luckyNumber = -1;
			this.itemVel = 1f;
			this.rewardPos = new mVector2((float)(this.xBegin + MainTabNew.wblack / 2), (float)(this.yBegin + MainTabNew.hblack / 2));
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x04000BD2 RID: 3026
	public const sbyte SECTION_CHOOSE_REWARD = 0;

	// Token: 0x04000BD3 RID: 3027
	public const sbyte SECTION_LOTTERY_DRAWING = 1;

	// Token: 0x04000BD4 RID: 3028
	private const int AT_DESTINATION_LIMIT = 20;

	// Token: 0x04000BD5 RID: 3029
	private const int MAX_MOVE_COUNT = 30;

	// Token: 0x04000BD6 RID: 3030
	private const int MAX_VELO = 16;

	// Token: 0x04000BD7 RID: 3031
	private int maxw;

	// Token: 0x04000BD8 RID: 3032
	private int maxh;

	// Token: 0x04000BD9 RID: 3033
	private int indexPaint = 12;

	// Token: 0x04000BDA RID: 3034
	private int winfo = 140;

	// Token: 0x04000BDB RID: 3035
	private int numW = 6;

	// Token: 0x04000BDC RID: 3036
	private int numH = 6;

	// Token: 0x04000BDD RID: 3037
	private int numHPaint;

	// Token: 0x04000BDE RID: 3038
	private int maxSize = 60;

	// Token: 0x04000BDF RID: 3039
	private int hcmd;

	// Token: 0x04000BE0 RID: 3040
	private int moveCount;

	// Token: 0x04000BE1 RID: 3041
	private int selectIdx;

	// Token: 0x04000BE2 RID: 3042
	private int curSelectPointerIdx;

	// Token: 0x04000BE3 RID: 3043
	private int itemIdSelect;

	// Token: 0x04000BE4 RID: 3044
	public static bool isWin = false;

	// Token: 0x04000BE5 RID: 3045
	public static bool isReady = false;

	// Token: 0x04000BE6 RID: 3046
	private static bool waitForNewPlay = false;

	// Token: 0x04000BE7 RID: 3047
	private static bool beginDraw = false;

	// Token: 0x04000BE8 RID: 3048
	private bool endDraw;

	// Token: 0x04000BE9 RID: 3049
	private bool moveDone;

	// Token: 0x04000BEA RID: 3050
	private mVector2[] posArray;

	// Token: 0x04000BEB RID: 3051
	private mVector2[] objPosArray;

	// Token: 0x04000BEC RID: 3052
	private mVector2[] fixPosArray;

	// Token: 0x04000BED RID: 3053
	private mVector2 rewardPos;

	// Token: 0x04000BEE RID: 3054
	private static iCommand cmdStartDraw;

	// Token: 0x04000BEF RID: 3055
	private static iCommand cmdGetItem;

	// Token: 0x04000BF0 RID: 3056
	private static iCommand cmdRepick;

	// Token: 0x04000BF1 RID: 3057
	private static iCommand cmdContinue;

	// Token: 0x04000BF2 RID: 3058
	private static iCommand cmdSelectGlass;

	// Token: 0x04000BF3 RID: 3059
	private static mVector vecListCmd = new mVector("TabLottery vecListCmd");

	// Token: 0x04000BF4 RID: 3060
	private mVector vecEffEnd = new mVector("TabLottery vecEffEnd");

	// Token: 0x04000BF5 RID: 3061
	private mVector vecRewardList = new mVector("TabLottery vecRewardList");

	// Token: 0x04000BF6 RID: 3062
	private int[] ranIdx = new int[]
	{
		-1,
		-1,
		-1,
		-1
	};

	// Token: 0x04000BF7 RID: 3063
	private mVector2 moveVec1;

	// Token: 0x04000BF8 RID: 3064
	private mVector2 moveVec2;

	// Token: 0x04000BF9 RID: 3065
	private mVector2 moveVec3;

	// Token: 0x04000BFA RID: 3066
	private mVector2 moveVec4;

	// Token: 0x04000BFB RID: 3067
	private float velocity;

	// Token: 0x04000BFC RID: 3068
	private float acceleration;

	// Token: 0x04000BFD RID: 3069
	private float itemVel;

	// Token: 0x04000BFE RID: 3070
	private int test_posX;

	// Token: 0x04000BFF RID: 3071
	private int test_posY;

	// Token: 0x04000C00 RID: 3072
	private static sbyte sectionType = 0;

	// Token: 0x04000C01 RID: 3073
	private static sbyte luckyNumber = -1;

	// Token: 0x04000C02 RID: 3074
	private int selectNumber;

	// Token: 0x04000C03 RID: 3075
	private ListNew list;
}
