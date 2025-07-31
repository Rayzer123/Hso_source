using System;

// Token: 0x0200007B RID: 123
public class Buy_Sell_Screen : MainScreen
{
	// Token: 0x06000590 RID: 1424 RVA: 0x0004FDBC File Offset: 0x0004DFBC
	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		this.Show(GameCanvas.currentScreen);
	}

	// Token: 0x06000591 RID: 1425 RVA: 0x0004FDD4 File Offset: 0x0004DFD4
	public override void Show(MainScreen screen)
	{
		this.lastScreen = screen;
		base.Show(screen.lastScreen);
		this.maintab.listContent = null;
	}

	// Token: 0x06000592 RID: 1426 RVA: 0x0004FDF8 File Offset: 0x0004DFF8
	public override void commandTab(int index, int subIndex)
	{
		switch (index)
		{
		case 6:
			GameCanvas.start_Left_Dialog(T.banmuongiaodich, new iCommand(T.buySell, 1, this));
			break;
		case 7:
			this.setItemBuySell();
			break;
		case 8:
			GlobalService.gI().Buy_Sell(6, string.Empty, 0, 0, 0);
			break;
		case 9:
			this.doMenu();
			break;
		}
		GameCanvas.clearKeyHold();
		base.commandTab(index, subIndex);
	}

	// Token: 0x06000593 RID: 1427 RVA: 0x0004FE7C File Offset: 0x0004E07C
	public override void commandMenu(int index, int sub)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				this.input.setinfo(T.nhapsotien, new iCommand(T.xacnhan, 0, this), true, T.buySell);
				GameCanvas.currentDialog = this.input;
			}
		}
		else
		{
			if ((int)this.typeLock == -1)
			{
				this.typeLock = 1;
				this.left = null;
				this.center = null;
			}
			else if ((int)this.typeLock == 0)
			{
				this.typeLock = 2;
				this.left = null;
				this.center = null;
			}
			GlobalService.gI().Buy_Sell(4, string.Empty, 0, 0, 0);
			MainTabNew.timePaintInfo = 0;
		}
	}

	// Token: 0x06000594 RID: 1428 RVA: 0x0004FF3C File Offset: 0x0004E13C
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
		{
			int num = 0;
			try
			{
				num = int.Parse(this.input.tfInput.getText());
			}
			catch (Exception ex)
			{
				num = 0;
			}
			if (num >= 0)
			{
				if ((long)num <= GameScreen.player.coin)
				{
					this.moneyBuySell[0] = num;
					GlobalService.gI().Buy_Sell(7, string.Empty, 0, 0, num);
					GameCanvas.end_Dialog();
				}
				else
				{
					GameCanvas.start_Ok_Dialog(T.giatrinhapsai);
				}
			}
			break;
		}
		case 1:
			GlobalService.gI().Buy_Sell(5, string.Empty, 0, 0, 0);
			GameCanvas.end_Dialog();
			break;
		case 2:
		{
			string text = this.inputChat.tfInput.getText();
			if (text == null || text.Length == 0)
			{
				return;
			}
			GlobalService.gI().Buy_Sell(9, text, 0, 0, 0);
			this.strchat[0] = text;
			this.inputChat.tfInput.setText(string.Empty);
			break;
		}
		case 3:
			this.inputChat.setinfo(T.trochuyenvoi + this.nameBuy, new iCommand(T.chat, 2, this), false, T.buySell);
			GameCanvas.currentDialog = this.inputChat;
			break;
		}
	}

	// Token: 0x06000595 RID: 1429 RVA: 0x000500A4 File Offset: 0x0004E2A4
	public void setinfoBuySell(string name)
	{
		GameScreen.player.resetVx_vy();
		this.cmdGiaodich = new iCommand(T.buySell, 6);
		this.cmdLock = new iCommand(T.khoa, 0);
		this.cmdChuyentien = new iCommand(T.chuyentien, 1);
		this.cmdchat = new iCommand(T.chat, 3, this);
		if (!GameCanvas.isTouch)
		{
			this.center = new iCommand(T.select, 7);
		}
		this.left = new iCommand(T.menu, 9);
		this.right = new iCommand(T.cancel, 8);
		this.wDia = (int)MainTabNew.wOneItem * 8;
		Buy_Sell_Screen.mRedSell = new int[9];
		for (int i = 0; i < Buy_Sell_Screen.mRedSell.Length; i++)
		{
			Buy_Sell_Screen.mRedSell[i] = -1;
		}
		Buy_Sell_Screen.mItemOther = new MainItem[2][];
		for (int j = 0; j < Buy_Sell_Screen.mItemOther.Length; j++)
		{
			Buy_Sell_Screen.mItemOther[j] = new MainItem[9];
		}
		this.moneyBuySell[0] = 0;
		this.moneyBuySell[1] = 0;
		this.input = new InputDialog();
		this.inputChat = new InputDialog();
		this.mchat[0] = null;
		this.mchat[1] = null;
		this.setmIdBuy(null);
		Buy_Sell_Screen.setmItemOther(null, 0, 0);
		this.nameBuy = name;
		this.idSelect = 0;
		this.idSelectBuy = 0;
		this.maxSize = Item.VecInvetoryPlayer.size();
		this.hDia = (int)MainTabNew.wOneItem * 9 + GameCanvas.hCommand / 2 + 2;
		this.xDia = GameCanvas.hw - this.wDia / 2;
		this.yDia = GameCanvas.hh - GameCanvas.hCommand / 2 - this.hDia / 2 + 2;
		if (this.yDia < 0)
		{
			this.hDia = (int)MainTabNew.wOneItem * 8 + 6;
			int num = iCommand.hButtonCmd;
			if (GameCanvas.isTouch)
			{
				num = 20;
			}
			this.yDia = GameCanvas.hh - this.hDia / 2 - num / 2;
			this.isSmall = true;
		}
		this.numw = (this.wDia - 6) / 32;
		this.numh = (this.hDia - 6) / 32;
		this.cameraDia.setAll(0, ((this.maxSize - 1) / 3 - 6 + 1) * (int)MainTabNew.wOneItem, 0, 0);
		this.list = new ListNew(this.xDia + (int)MainTabNew.wOneItem * 4 - (int)MainTabNew.wOneItem / 2, this.yDia + GameCanvas.hCommand + (int)MainTabNew.wOneItem - (int)MainTabNew.wOneItem / 2, (int)MainTabNew.wOneItem * 4, (int)MainTabNew.wOneItem * 6, 0, 0, this.cameraDia.yLimit);
		if (this.maxSize < 18)
		{
			this.maxSize = 18;
		}
		this.typeLock = -1;
		this.maintab = new MainTabNew();
		MainTabNew.timePaintInfo = 0;
		this.setPosCmd();
		if (GameCanvas.isTouch)
		{
			FrameImage fra = new FrameImage(PaintInfoGameScreen.imgOther[1], 25, 25);
			if (this.isSmall)
			{
				this.cmdchat.setPos(this.xDia + 15, this.yDia + GameCanvas.hCommand / 2 + 1, fra, string.Empty);
			}
			else
			{
				this.cmdchat.setPos(this.xDia + this.wDia - 25, this.yDia + 20, fra, string.Empty);
			}
		}
	}

	// Token: 0x06000596 RID: 1430 RVA: 0x00050404 File Offset: 0x0004E604
	public void setPosCmd()
	{
		if (GameCanvas.isTouch)
		{
			if (this.isSmall)
			{
				if (this.left != null && this.center != null && this.right != null)
				{
					this.center.setPos(GameCanvas.hw, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.center.caption);
					this.left.setPos(GameCanvas.hw - 66, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.left.caption);
					this.right.setPos(GameCanvas.hw + 66, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.right.caption);
				}
				else
				{
					if (this.left != null)
					{
						this.left.setPos(GameCanvas.hw - this.wDia / 4, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.left.caption);
					}
					if (this.center != null)
					{
						this.center.setPos(GameCanvas.hw, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.center.caption);
					}
					if (this.right != null)
					{
						this.right.setPos(GameCanvas.hw + this.wDia / 4, this.yDia + this.hDia + 10, PaintInfoGameScreen.fraButton2, this.right.caption);
					}
				}
			}
			else if (this.left != null && this.center != null && this.right != null)
			{
				this.center.setPos(GameCanvas.hw, this.yDia + this.hDia, null, this.center.caption);
				this.left.setPos(GameCanvas.hw - 80, this.yDia + this.hDia, null, this.left.caption);
				this.right.setPos(GameCanvas.hw + 80, this.yDia + this.hDia, null, this.right.caption);
			}
			else
			{
				if (this.left != null)
				{
					this.left.setPos(GameCanvas.hw - 50, this.yDia + this.hDia, null, this.left.caption);
				}
				if (this.center != null)
				{
					this.center.setPos(GameCanvas.hw, this.yDia + this.hDia, null, this.center.caption);
				}
				if (this.right != null)
				{
					this.right.setPos(GameCanvas.hw + 50, this.yDia + this.hDia, null, this.right.caption);
				}
			}
		}
	}

	// Token: 0x06000597 RID: 1431 RVA: 0x000506F4 File Offset: 0x0004E8F4
	public override void paint(mGraphics g)
	{
		if (this.lastScreen != null)
		{
			this.lastScreen.paint(g);
		}
		if (GameCanvas.currentScreen != this)
		{
			return;
		}
		GameCanvas.resetTrans(g);
		int num = this.yDia;
		int xp = this.xDia + (int)MainTabNew.wOneItem;
		AvMain.paintDialogNew(g, this.xDia, this.yDia, this.wDia, this.hDia, 0);
		if (!this.isSmall)
		{
			if (GameCanvas.lowGraphic)
			{
				MainTabNew.paintRectLowGraphic(g, GameCanvas.hw - 32, num + 8, 64, 14, 2);
			}
			else
			{
				for (int i = 0; i < 2; i++)
				{
					g.drawRegion(MainTabNew.imgTab[2], 0, 0, 32, 14, 0, GameCanvas.hw - 32 + i * 32, num + 8, 0, mGraphics.isTrue);
				}
			}
			mFont.tahoma_7b_white.drawString(g, T.buySell, GameCanvas.hw, num + 9, 2, mGraphics.isTrue);
			num = this.yDia + GameCanvas.hCommand;
		}
		if (GameCanvas.isTouch && (int)this.typeLock != 2)
		{
			this.cmdchat.paint(g, this.cmdchat.xCmd, this.cmdchat.yCmd);
		}
		this.paintBuySell(g, xp, num);
		GameCanvas.resetTrans(g);
		for (int j = 0; j < this.mchat.Length; j++)
		{
			if (this.mchat[j] != null)
			{
				this.mchat[j].paint(g);
			}
		}
		base.paint(g);
	}

	// Token: 0x06000598 RID: 1432 RVA: 0x0005087C File Offset: 0x0004EA7C
	public void paintBuySell(mGraphics g, int xp, int yp)
	{
		g.setColor(12298905);
		AvMain.paintRectNice(g, xp + (int)MainTabNew.wOneItem * 3, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * 3, (int)MainTabNew.wOneItem * 6, 2);
		AvMain.paintRectNice(g, xp, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * 3, (int)MainTabNew.wOneItem * 6, 1);
		g.drawRect(xp, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * 6, (int)MainTabNew.wOneItem * 6, mGraphics.isTrue);
		g.setColor(12298905);
		int num = 0;
		if (GameCanvas.isSmallScreen)
		{
			num = 2;
		}
		mFont.tahoma_7b_black.drawString(g, GameScreen.player.name, xp + ((!this.isSmall) ? 0 : 5), yp + (int)MainTabNew.wOneItem / 4, 0, mGraphics.isTrue);
		if (this.typeActionBuySell == 0)
		{
			mFont.tahoma_7b_red.drawString(g, "- Ok -", xp + (int)MainTabNew.wOneItem * 3, yp + (int)MainTabNew.wOneItem / 4, 2, mGraphics.isTrue);
		}
		mFont.tahoma_7b_black.drawString(g, this.nameBuy, xp, yp + (int)MainTabNew.wOneItem / 4 + (int)MainTabNew.wOneItem * 7 - num, 0, mGraphics.isTrue);
		if (this.typeActionBuySell == 1)
		{
			mFont.tahoma_7b_red.drawString(g, "- Ok -", xp + (int)MainTabNew.wOneItem * 3, yp + (int)MainTabNew.wOneItem / 4 + (int)MainTabNew.wOneItem * 7 - num, 2, mGraphics.isTrue);
		}
		if (this.moneyBuySell[0] > 0)
		{
			mFont.tahoma_7_black.drawString(g, this.moneyBuySell[0] + " $", xp + (int)MainTabNew.wOneItem * 6, yp + (int)MainTabNew.wOneItem / 4, 1, mGraphics.isTrue);
		}
		if (this.moneyBuySell[1] > 0)
		{
			mFont.tahoma_7_black.drawString(g, this.moneyBuySell[1] + " $", xp + (int)MainTabNew.wOneItem * 6, yp + (int)MainTabNew.wOneItem / 4 + (int)MainTabNew.wOneItem * 7 - num, 1, mGraphics.isTrue);
		}
		g.setClip(xp, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * 6, (int)MainTabNew.wOneItem * 6);
		g.translate(0, -this.cameraDia.yCam);
		if ((int)this.typeLock == -1 || (int)this.typeLock == 0)
		{
			for (int i = 0; i < Item.VecInvetoryPlayer.size(); i++)
			{
				MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(i);
				if (mainItem.ItemCatagory == 7)
				{
					MainItem material = Item.getMaterial(mainItem.Id);
					if (material != null)
					{
						material.paintItem(g, xp + (int)MainTabNew.wOneItem * 3 + (int)MainTabNew.wOneItem / 2 + i % 3 * (int)MainTabNew.wOneItem, yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem / 2 + i / 3 * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
					}
					else
					{
						Item.put_Material(mainItem.Id);
					}
				}
				else
				{
					mainItem.paintItem(g, xp + (int)MainTabNew.wOneItem * 3 + (int)MainTabNew.wOneItem / 2 + i % 3 * (int)MainTabNew.wOneItem, yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem / 2 + i / 3 * (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, 0, 0);
				}
				if ((int)mainItem.canTrade == 0)
				{
					g.drawRegion(AvMain.imgDelaySkill, 0, 0, (int)MainTabNew.wOneItem - 1, (int)MainTabNew.wOneItem - 1, 0, xp + (int)MainTabNew.wOneItem * 3 + (int)MainTabNew.wOneItem / 2 + i % 3 * (int)MainTabNew.wOneItem, yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem / 2 + i / 3 * (int)MainTabNew.wOneItem, 3, mGraphics.isTrue);
				}
			}
			g.setColor(14040109);
			for (int j = 0; j < Buy_Sell_Screen.mRedSell.Length; j++)
			{
				if (Buy_Sell_Screen.mRedSell[j] >= 0)
				{
					g.drawRect(xp + (int)MainTabNew.wOneItem * 3 + Buy_Sell_Screen.mRedSell[j] % 3 * (int)MainTabNew.wOneItem + 3, yp + (int)MainTabNew.wOneItem + Buy_Sell_Screen.mRedSell[j] / 3 * (int)MainTabNew.wOneItem + 3, (int)MainTabNew.wOneItem - 6, (int)MainTabNew.wOneItem - 6, mGraphics.isTrue);
				}
			}
		}
		g.setColor(12298905);
		g.drawRect(xp + (int)MainTabNew.wOneItem * 4, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * (this.maxSize / 3), mGraphics.isTrue);
		for (int k = 0; k < this.maxSize / 3 + 1; k++)
		{
			g.fillRect(xp + (int)MainTabNew.wOneItem * 3, yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem * k, (int)MainTabNew.wOneItem * 3, 1, mGraphics.isTrue);
		}
		g.setColor(16777215);
		if (!this.isINVEN_BUY && (int)this.typeLock < 1 && this.idSelect >= 0)
		{
			g.drawRect(xp + (int)MainTabNew.wOneItem * (3 + this.idSelect % 3) + 1, yp + (int)MainTabNew.wOneItem * (this.idSelect / 3 + 1) + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
		}
		GameCanvas.resetTrans(g);
		for (int l = 0; l < Buy_Sell_Screen.mItemOther[0].Length; l++)
		{
			int num2 = xp + (int)MainTabNew.wOneItem / 2 + l % 3 * (int)MainTabNew.wOneItem;
			int num3 = yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem / 2 + l / 3 * (int)MainTabNew.wOneItem;
			if (Buy_Sell_Screen.mItemOther[0][l] != null)
			{
				if (Buy_Sell_Screen.mItemOther[0][l].ItemCatagory == 7)
				{
					MainItem material2 = Item.getMaterial(Buy_Sell_Screen.mItemOther[0][l].Id);
					if (material2 != null)
					{
						if (Buy_Sell_Screen.mItemOther[0][l].content == null)
						{
							Buy_Sell_Screen.mItemOther[0][l].itemName = material2.itemName;
							Buy_Sell_Screen.mItemOther[0][l].mMoreContent(material2.content);
							Buy_Sell_Screen.mItemOther[0][l].content = material2.content;
						}
					}
					else
					{
						Item.put_Material(Buy_Sell_Screen.mItemOther[0][l].Id);
					}
					Buy_Sell_Screen.mItemOther[0][l].paintItem(g, num2, num3, (int)MainTabNew.wOneItem, 0, 0);
				}
				else
				{
					Buy_Sell_Screen.mItemOther[0][l].paintItem(g, num2, num3, (int)MainTabNew.wOneItem, 0, 0);
				}
			}
			if ((int)this.typeLock > 0)
			{
				g.setColor(14040109);
				g.drawRect(num2 - (int)MainTabNew.wOneItem / 2 + 1, num3 - (int)MainTabNew.wOneItem / 2 + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
			}
			num2 = xp + (int)MainTabNew.wOneItem / 2 + l % 3 * (int)MainTabNew.wOneItem;
			num3 = yp + (int)MainTabNew.wOneItem * 4 + (int)MainTabNew.wOneItem / 2 + l / 3 * (int)MainTabNew.wOneItem;
			if (Buy_Sell_Screen.mItemOther[1][l] != null)
			{
				if (Buy_Sell_Screen.mItemOther[1][l].ItemCatagory == 7)
				{
					MainItem material3 = Item.getMaterial(Buy_Sell_Screen.mItemOther[1][l].Id);
					if (material3 != null)
					{
						if (Buy_Sell_Screen.mItemOther[1][l].content == null)
						{
							Buy_Sell_Screen.mItemOther[1][l].itemName = material3.itemName;
							Buy_Sell_Screen.mItemOther[1][l].content = material3.content;
							Buy_Sell_Screen.mItemOther[1][l].mMoreContent(material3.content);
						}
					}
					else
					{
						Item.put_Material(Buy_Sell_Screen.mItemOther[1][l].Id);
					}
					Buy_Sell_Screen.mItemOther[1][l].paintItem(g, num2, num3, (int)MainTabNew.wOneItem, 0, 0);
				}
				else
				{
					Buy_Sell_Screen.mItemOther[1][l].paintItem(g, num2, num3, (int)MainTabNew.wOneItem, 0, 0);
				}
			}
			if ((int)this.typeLock == 0 || (int)this.typeLock == 2)
			{
				g.setColor(14040109);
				g.drawRect(num2 - (int)MainTabNew.wOneItem / 2 + 1, num3 - (int)MainTabNew.wOneItem / 2 + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
			}
		}
		g.setColor(12298905);
		for (int m = 0; m < 3; m++)
		{
			g.drawRect(xp, yp + (int)MainTabNew.wOneItem + (int)MainTabNew.wOneItem * 2 * m, (int)MainTabNew.wOneItem * (3 + ((m != 3) ? 0 : 3)), (int)MainTabNew.wOneItem, mGraphics.isTrue);
		}
		g.drawRect(xp + (int)MainTabNew.wOneItem, yp + (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem, (int)MainTabNew.wOneItem * 6, mGraphics.isTrue);
		g.setColor(0);
		g.fillRect(xp + (int)MainTabNew.wOneItem * 3, yp + (int)MainTabNew.wOneItem + 1, 1, (int)MainTabNew.wOneItem * 6 - 1, mGraphics.isTrue);
		g.fillRect(xp + 1, yp + (int)MainTabNew.wOneItem * 4, (int)MainTabNew.wOneItem * 3, 1, mGraphics.isTrue);
		g.setColor(16777215);
		if (this.isINVEN_BUY && this.idSelectBuy >= 0)
		{
			g.drawRect(xp + (int)MainTabNew.wOneItem * (this.idSelectBuy % 3) + 1, yp + (int)MainTabNew.wOneItem * (this.idSelectBuy / 3 + 4) + 1, (int)MainTabNew.wOneItem - 2, (int)MainTabNew.wOneItem - 2, mGraphics.isTrue);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && MainTabNew.timePaintInfo > MainTabNew.timeRequest)
		{
			g.translate(0, -this.cameraDia.yCam);
			this.maintab.paintContent(g, false);
		}
		GameCanvas.resetTrans(g);
	}

	// Token: 0x06000599 RID: 1433 RVA: 0x00051268 File Offset: 0x0004F468
	public void doMenu()
	{
		mVector mVector = new mVector("Buy_sell_scr menu");
		mVector.addElement(this.cmdChuyentien);
		mVector.addElement(this.cmdLock);
		if (!GameCanvas.isTouch)
		{
			mVector.addElement(this.cmdchat);
		}
		GameCanvas.menu2.startAt(mVector, 2, T.select, false, null);
	}

	// Token: 0x0600059A RID: 1434 RVA: 0x000512C4 File Offset: 0x0004F4C4
	public void setmIdBuy(MainItem item)
	{
		if (item == null)
		{
			for (int i = 0; i < Buy_Sell_Screen.mItemOther[0].Length; i++)
			{
				Buy_Sell_Screen.mItemOther[0][i] = null;
			}
		}
		else
		{
			for (int j = 0; j < Buy_Sell_Screen.mItemOther[0].Length; j++)
			{
				if (Buy_Sell_Screen.mItemOther[0][j] != null && Buy_Sell_Screen.mItemOther[0][j].ItemCatagory == item.ItemCatagory && Buy_Sell_Screen.mItemOther[0][j].Id == item.Id)
				{
					GlobalService.gI().Buy_Sell(3, string.Empty, (sbyte)item.ItemCatagory, (short)item.Id, 0);
					Buy_Sell_Screen.mItemOther[0][j] = null;
					Buy_Sell_Screen.mRedSell[j] = -1;
					return;
				}
			}
			for (int k = 0; k < Buy_Sell_Screen.mItemOther[0].Length; k++)
			{
				if (Buy_Sell_Screen.mItemOther[0][k] == null)
				{
					Buy_Sell_Screen.mItemOther[0][k] = item;
					GlobalService.gI().Buy_Sell(2, string.Empty, (sbyte)item.ItemCatagory, (short)item.Id, 0);
					Buy_Sell_Screen.mRedSell[k] = this.idSelect;
					return;
				}
			}
		}
	}

	// Token: 0x0600059B RID: 1435 RVA: 0x000513EC File Offset: 0x0004F5EC
	public override void update()
	{
		this.lastScreen.update();
		if (this.maintab.listContent != null)
		{
			this.maintab.listContent.moveCamera();
		}
		if (GameCanvas.isTouch)
		{
			this.list.moveCamera();
		}
		else
		{
			this.cameraDia.UpdateCamera();
		}
		for (int i = 0; i < this.mchat.Length; i++)
		{
			if (this.mchat[i] != null && this.mchat[i].setOff())
			{
				this.mchat[i] = null;
			}
		}
		for (int j = 0; j < this.strchat.Length; j++)
		{
			if (this.strchat[j] != null)
			{
				this.ChatBuySell((sbyte)j, this.strchat[j]);
				this.strchat[j] = null;
			}
		}
	}

	// Token: 0x0600059C RID: 1436 RVA: 0x000514CC File Offset: 0x0004F6CC
	public override void updatekey()
	{
		if ((int)this.typeLock >= 1)
		{
			this.isINVEN_BUY = true;
		}
		if (this.isINVEN_BUY)
		{
			int num = this.idSelectBuy;
			if (this.maintab.listContent != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					if (this.maintab.listContent.cmtoX > 0)
					{
						this.maintab.listContent.cmtoX -= GameCanvas.hText;
					}
					else
					{
						this.maintab.listContent.cmtoX = 0;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (this.maintab.listContent.cmtoX < this.maintab.listContent.cmxLim)
					{
						this.maintab.listContent.cmtoX += GameCanvas.hText;
					}
					else
					{
						this.maintab.listContent.cmtoX = this.maintab.listContent.cmxLim;
					}
					GameCanvas.clearKeyHold(8);
				}
			}
			else if (GameCanvas.keyMyHold[2])
			{
				this.idSelectBuy -= 3;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.idSelectBuy += 3;
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				this.idSelectBuy--;
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				if (this.idSelectBuy % 3 == 2 && (int)this.typeLock < 1)
				{
					this.isINVEN_BUY = false;
					MainTabNew.timePaintInfo = 0;
				}
				else
				{
					this.idSelectBuy++;
				}
				GameCanvas.clearKeyHold(6);
			}
			this.idSelectBuy = base.resetSelect(this.idSelectBuy, 8, false);
			if (this.idSelectBuy != num)
			{
				MainTabNew.timePaintInfo = 0;
				this.maintab.listContent = null;
			}
		}
		else
		{
			int num2 = this.idSelect;
			if (this.maintab.listContent != null)
			{
				if (GameCanvas.keyMyHold[2])
				{
					if (this.maintab.listContent.cmtoX > 0)
					{
						this.maintab.listContent.cmtoX -= GameCanvas.hText;
					}
					else
					{
						this.maintab.listContent.cmtoX = 0;
					}
					GameCanvas.clearKeyHold(2);
				}
				else if (GameCanvas.keyMyHold[8])
				{
					if (this.maintab.listContent.cmtoX < this.maintab.listContent.cmxLim)
					{
						this.maintab.listContent.cmtoX += GameCanvas.hText;
					}
					else
					{
						this.maintab.listContent.cmtoX = this.maintab.listContent.cmxLim;
					}
					GameCanvas.clearKeyHold(8);
				}
			}
			else if (GameCanvas.keyMyHold[2])
			{
				this.idSelect -= 3;
				GameCanvas.clearKeyHold(2);
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.idSelect += 3;
				GameCanvas.clearKeyHold(8);
			}
			if (GameCanvas.keyMyHold[4])
			{
				if (this.idSelect % 3 == 0)
				{
					this.isINVEN_BUY = true;
					MainTabNew.timePaintInfo = 0;
				}
				else
				{
					this.idSelect--;
				}
				GameCanvas.clearKeyHold(4);
			}
			else if (GameCanvas.keyMyHold[6])
			{
				this.idSelect++;
				GameCanvas.clearKeyHold(6);
			}
			if (!GameCanvas.isTouch)
			{
				this.idSelect = base.resetSelect(this.idSelect, Item.VecInvetoryPlayer.size() - 1, false);
			}
			if (this.idSelect < -1)
			{
				this.idSelect = -1;
			}
			else if (this.idSelect > Item.VecInvetoryPlayer.size() - 1)
			{
				this.idSelect = Item.VecInvetoryPlayer.size();
			}
			if (this.idSelect != num2 && this.idSelect >= 0)
			{
				this.cameraDia.moveCamera(0, (this.idSelect / 3 - 3) * (int)MainTabNew.wOneItem);
				MainTabNew.timePaintInfo = 0;
			}
		}
		int num3 = this.idSelect;
		if (this.isINVEN_BUY)
		{
			num3 = this.idSelectBuy;
		}
		MainItem item;
		if (!this.isINVEN_BUY)
		{
			item = (MainItem)Item.VecInvetoryPlayer.elementAt(num3);
		}
		else
		{
			item = Buy_Sell_Screen.mItemOther[1][num3];
		}
		this.updateContent(item);
		base.updatekey();
	}

	// Token: 0x0600059D RID: 1437 RVA: 0x0005196C File Offset: 0x0004FB6C
	public override void updatePointer()
	{
		int num = this.xDia + (int)MainTabNew.wOneItem;
		int num2 = this.yDia + (int)MainTabNew.wOneItem;
		if (!this.isSmall)
		{
			num2 += GameCanvas.hCommand;
		}
		bool flag = false;
		if (this.maintab.listContent != null && GameCanvas.isPoint(this.maintab.listContent.x, this.maintab.listContent.y, this.maintab.listContent.maxW, this.maintab.listContent.maxH))
		{
			this.maintab.listContent.update_Pos_UP_DOWN();
			flag = true;
		}
		if (!flag)
		{
			if (GameCanvas.isPointerMove)
			{
				MainTabNew.timePaintInfo = 0;
			}
			if (GameCanvas.isTouch)
			{
				this.list.update_Pos_UP_DOWN();
				this.cameraDia.yCam = this.list.cmx;
			}
			if ((int)this.typeLock < 1 && GameCanvas.isPointSelect(num + 3 * (int)MainTabNew.wOneItem, num2, 3 * (int)MainTabNew.wOneItem, 6 * (int)MainTabNew.wOneItem))
			{
				int num3 = (GameCanvas.px - (num + 3 * (int)MainTabNew.wOneItem)) / (int)MainTabNew.wOneItem + (this.cameraDia.yCam + GameCanvas.py - num2) / (int)MainTabNew.wOneItem * 3;
				int num4 = Item.VecInvetoryPlayer.size();
				if (this.isINVEN_BUY)
				{
					this.idSelect = -1;
				}
				this.isINVEN_BUY = false;
				if (num3 >= 0 && num3 < num4)
				{
					GameCanvas.isPointerSelect = false;
					if (num3 == this.idSelect)
					{
						this.setItemBuySell();
					}
					else
					{
						this.idSelect = num3;
						MainTabNew.timePaintInfo = 0;
						this.maintab.listContent = null;
					}
				}
				else
				{
					this.idSelect = -1;
					MainTabNew.timePaintInfo = 0;
					this.maintab.listContent = null;
				}
				GameCanvas.isPointerSelect = false;
			}
			else if (GameCanvas.isPointSelect(num, num2 + 3 * (int)MainTabNew.wOneItem, 3 * (int)MainTabNew.wOneItem, 3 * (int)MainTabNew.wOneItem))
			{
				int num5 = (GameCanvas.px - num) / (int)MainTabNew.wOneItem + (GameCanvas.py - (num2 + 3 * (int)MainTabNew.wOneItem)) / (int)MainTabNew.wOneItem * 3;
				int num6 = 9;
				if (!this.isINVEN_BUY)
				{
					MainTabNew.timePaintInfo = 0;
				}
				this.isINVEN_BUY = true;
				if (num5 >= 0 && num5 < num6)
				{
					GameCanvas.isPointerSelect = false;
					if (num5 != this.idSelectBuy)
					{
						this.idSelectBuy = num5;
						MainTabNew.timePaintInfo = 0;
					}
				}
				else
				{
					this.idSelectBuy = -1;
					MainTabNew.timePaintInfo = 0;
				}
				GameCanvas.isPointerSelect = false;
			}
		}
		if (GameCanvas.isTouch && (int)this.typeLock != 2)
		{
			this.cmdchat.updatePointer();
		}
		base.updatePointer();
	}

	// Token: 0x0600059E RID: 1438 RVA: 0x00051C34 File Offset: 0x0004FE34
	public static void setmItemOther(MainItem item, sbyte type, sbyte index)
	{
		if (item == null)
		{
			for (int i = 0; i < Buy_Sell_Screen.mItemOther.Length; i++)
			{
				Buy_Sell_Screen.mItemOther[1][i] = null;
			}
		}
		else if ((int)type == 3)
		{
			for (int j = 0; j < Buy_Sell_Screen.mItemOther[(int)index].Length; j++)
			{
				if (Buy_Sell_Screen.mItemOther[(int)index][j] != null && Buy_Sell_Screen.mItemOther[(int)index][j].ItemCatagory == item.ItemCatagory && Buy_Sell_Screen.mItemOther[(int)index][j].Id == item.Id)
				{
					Buy_Sell_Screen.mItemOther[(int)index][j] = null;
					if ((int)index == 0)
					{
						Buy_Sell_Screen.mRedSell[j] = -1;
					}
					return;
				}
			}
		}
		else if ((int)type == 2)
		{
			for (int k = 0; k < Buy_Sell_Screen.mItemOther[(int)index].Length; k++)
			{
				if (Buy_Sell_Screen.mItemOther[(int)index][k] == null)
				{
					Buy_Sell_Screen.mItemOther[(int)index][k] = item;
					return;
				}
			}
		}
	}

	// Token: 0x0600059F RID: 1439 RVA: 0x00051D34 File Offset: 0x0004FF34
	public void updateContent(MainItem item)
	{
		if (MainTabNew.timePaintInfo < MainTabNew.timeRequest + 2)
		{
			MainTabNew.timePaintInfo++;
			if (MainTabNew.timePaintInfo == MainTabNew.timeRequest)
			{
				this.setPaintInfo(item);
			}
		}
		if (this.maintab.mContent == null && item != null && item.ItemCatagory != 5)
		{
			if (item.mcontent == null)
			{
				if (item.timeupdateMore % 100 == 3)
				{
					if ((int)this.maintab.typeTab == (int)MainTabNew.INVENTORY)
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
				this.maintab.mContent = item.mcontent;
				this.maintab.mcolor = item.mColor;
				this.setYCon(item);
			}
		}
	}

	// Token: 0x060005A0 RID: 1440 RVA: 0x00051E28 File Offset: 0x00050028
	public void setPaintInfo(MainItem item)
	{
		this.maintab.mContent = null;
		this.maintab.mSubContent = null;
		this.maintab.mPlusContent = null;
		if (item == null)
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		if (item.setNameNull())
		{
			MainTabNew.timePaintInfo = 0;
			return;
		}
		this.maintab.wContent = item.sizeW;
		if (this.isINVEN_BUY)
		{
			this.maintab.xCon = this.xDia + (int)MainTabNew.wOneItem * 4 + 3;
			if (this.maintab.xCon + this.maintab.wContent > GameCanvas.w - 3)
			{
				this.maintab.xCon = GameCanvas.w - 3 - this.maintab.wContent;
			}
		}
		else
		{
			this.maintab.xCon = this.xDia + (int)MainTabNew.wOneItem * 4 - this.maintab.wContent - 3;
			if (this.maintab.xCon < 3)
			{
				this.maintab.xCon = 3;
			}
		}
		this.setYCon(item);
		this.maintab.name = item.itemName;
		this.maintab.mPlusContent = item.mPlusContent;
		this.maintab.mPlusColor = item.mPlusColor;
		this.maintab.colorName = item.colorNameItem;
	}

	// Token: 0x060005A1 RID: 1441 RVA: 0x00051F88 File Offset: 0x00050188
	public void setYCon(MainItem item)
	{
		int num = 1;
		this.maintab.mContent = item.mcontent;
		this.maintab.mcolor = item.mColor;
		if (item.mcontent != null)
		{
			num += this.maintab.mContent.Length;
		}
		if (item.mPlusContent != null)
		{
			num += item.mPlusContent.Length;
		}
		int num2 = this.idSelect;
		int num3 = 0;
		if (this.isINVEN_BUY)
		{
			num2 = this.idSelectBuy + 9;
			num3 = this.cameraDia.yCam;
		}
		this.maintab.yCon = (num2 / 3 + 1) * (int)MainTabNew.wOneItem - num * GameCanvas.hText + this.yDia + GameCanvas.hCommand + num3;
		if (this.maintab.yCon - this.cameraDia.yCam < 3)
		{
			this.maintab.yCon = 3 + this.cameraDia.yCam;
		}
		this.maintab.listContent = null;
		if ((num + 1) * GameCanvas.hText > MainTabNew.hMaxContent)
		{
			this.maintab.listContent = new ListNew(this.maintab.xCon, this.maintab.yCon, this.maintab.wContent, MainTabNew.hMaxContent, 0, 0, (num + 1) * GameCanvas.hText - MainTabNew.hMaxContent);
		}
	}

	// Token: 0x060005A2 RID: 1442 RVA: 0x000520E0 File Offset: 0x000502E0
	public void setItemBuySell()
	{
		MainItem mainItem = (MainItem)Item.VecInvetoryPlayer.elementAt(this.idSelect);
		if ((int)mainItem.canTrade == 0)
		{
			GameCanvas.start_Ok_Dialog(T.khongthetraodoi);
			return;
		}
		this.setmIdBuy(mainItem);
	}

	// Token: 0x060005A3 RID: 1443 RVA: 0x00052124 File Offset: 0x00050324
	public int tinhThue(int value)
	{
		int result = 0;
		if (value > 5000000)
		{
			result = (value - 5000000) * 30 / 100 + 1250000;
		}
		else if (value > 5000000)
		{
			result = (value - 5000000) * 30 / 100 + 1250000;
		}
		return result;
	}

	// Token: 0x060005A4 RID: 1444 RVA: 0x00052178 File Offset: 0x00050378
	public void ChatBuySell(sbyte index, string str)
	{
		if (str == null || str.Length == 0)
		{
			return;
		}
		if (this.mchat[(int)index] == null)
		{
			this.mchat[(int)index] = new PopupChat();
		}
		this.mchat[(int)index].setChat(str, true);
		int num = this.yDia;
		if (!this.isSmall)
		{
			num = this.yDia + GameCanvas.hCommand;
		}
		int num2 = this.xDia + (int)MainTabNew.wOneItem;
		if ((int)index == 0)
		{
			this.mchat[(int)index].indexpaint = 1;
			this.mchat[(int)index].updatePos(num2 + (int)MainTabNew.wOneItem, num + (int)MainTabNew.wOneItem + this.mchat[(int)index].h);
		}
		else
		{
			this.mchat[(int)index].updatePos(num2 + (int)MainTabNew.wOneItem, num + (int)MainTabNew.wOneItem * 7);
		}
	}

	// Token: 0x040007DA RID: 2010
	public const sbyte TYPE_BUY_MOI = 0;

	// Token: 0x040007DB RID: 2011
	public const sbyte TYPE_BUY_CHAPNHAN = 1;

	// Token: 0x040007DC RID: 2012
	public const sbyte TYPE_BUY_GOIITEM = 2;

	// Token: 0x040007DD RID: 2013
	public const sbyte TYPE_BUY_LAYITEM = 3;

	// Token: 0x040007DE RID: 2014
	public const sbyte TYPE_BUY_KHOA = 4;

	// Token: 0x040007DF RID: 2015
	public const sbyte TYPE_BUY_GIAODICH = 5;

	// Token: 0x040007E0 RID: 2016
	private int wDia;

	// Token: 0x040007E1 RID: 2017
	private int idSelect;

	// Token: 0x040007E2 RID: 2018
	private int idSelectBuy;

	// Token: 0x040007E3 RID: 2019
	private int maxSize;

	// Token: 0x040007E4 RID: 2020
	private int hDia;

	// Token: 0x040007E5 RID: 2021
	private int xDia;

	// Token: 0x040007E6 RID: 2022
	private int yDia;

	// Token: 0x040007E7 RID: 2023
	private int numw;

	// Token: 0x040007E8 RID: 2024
	private int numh;

	// Token: 0x040007E9 RID: 2025
	public string nameBuy = string.Empty;

	// Token: 0x040007EA RID: 2026
	public static int[] mRedSell;

	// Token: 0x040007EB RID: 2027
	public int typeActionBuySell = -1;

	// Token: 0x040007EC RID: 2028
	public int[] moneyBuySell = new int[2];

	// Token: 0x040007ED RID: 2029
	public static MainItem[][] mItemOther;

	// Token: 0x040007EE RID: 2030
	public sbyte typeLock = -1;

	// Token: 0x040007EF RID: 2031
	private bool isINVEN_BUY;

	// Token: 0x040007F0 RID: 2032
	public MainTabNew maintab;

	// Token: 0x040007F1 RID: 2033
	private int hItem;

	// Token: 0x040007F2 RID: 2034
	private Camera cameraDia = new Camera();

	// Token: 0x040007F3 RID: 2035
	public iCommand cmdGiaodich;

	// Token: 0x040007F4 RID: 2036
	public iCommand cmdLock;

	// Token: 0x040007F5 RID: 2037
	public iCommand cmdChuyentien;

	// Token: 0x040007F6 RID: 2038
	public iCommand cmdchat;

	// Token: 0x040007F7 RID: 2039
	private InputDialog input;

	// Token: 0x040007F8 RID: 2040
	private InputDialog inputChat;

	// Token: 0x040007F9 RID: 2041
	private ListNew list;

	// Token: 0x040007FA RID: 2042
	public PopupChat[] mchat = new PopupChat[2];

	// Token: 0x040007FB RID: 2043
	public string[] strchat = new string[2];

	// Token: 0x040007FC RID: 2044
	private bool isSmall;

	// Token: 0x040007FD RID: 2045
	private bool isTran;

	// Token: 0x040007FE RID: 2046
	private int yCamBegin;
}
