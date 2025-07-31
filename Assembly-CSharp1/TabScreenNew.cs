using System;

// Token: 0x0200008D RID: 141
public class TabScreenNew : MainScreen
{
	// Token: 0x060006D3 RID: 1747 RVA: 0x00068168 File Offset: 0x00066368
	public TabScreenNew()
	{
		TabScreenNew.cmdBack = new iCommand(T.close, 0, this);
		TabScreenNew.xback = GameCanvas.w - 20;
		TabScreenNew.yback = 17;
		if (Main.isPC || Main.isIpad)
		{
			TabScreenNew.xback = MainTabNew.gI().xTab + 210 + 2;
			TabScreenNew.yback = MainTabNew.gI().yTab + GameCanvas.h / 5 + 13;
		}
		if (GameCanvas.isTouch)
		{
			TabScreenNew.cmdBack.setPos(TabScreenNew.xback, TabScreenNew.yback, PaintInfoGameScreen.fraCloseMenu, string.Empty);
		}
	}

	// Token: 0x060006D5 RID: 1749 RVA: 0x00068224 File Offset: 0x00066424
	public void setCaptionCmd()
	{
		if (!GameCanvas.isTouch)
		{
			TabScreenNew.cmdBack.caption = T.close;
		}
	}

	// Token: 0x060006D6 RID: 1750 RVA: 0x00068240 File Offset: 0x00066440
	public override void Show()
	{
		mSystem.outloi("goi ham co truyen lastScreen");
	}

	// Token: 0x060006D7 RID: 1751 RVA: 0x0006824C File Offset: 0x0006644C
	public override void Show(MainScreen last)
	{
		TabScreenNew.timeRepaint = 10;
		if (GameScreen.help.setStep_Next(6, 2))
		{
			this.selectTab = 2;
		}
		if (GameCanvas.isTouch)
		{
			MainTabNew.Focus = MainTabNew.INFO;
			MainTabNew currentTab = this.getCurrentTab();
			currentTab.init();
			MainTabNew.timePaintInfo = 0;
			this.right = TabScreenNew.cmdBack;
		}
		else
		{
			MainTabNew.Focus = MainTabNew.TAB;
		}
		base.Show();
		GameCanvas.currentScreen.lastScreen = last;
	}

	// Token: 0x060006D8 RID: 1752 RVA: 0x000682CC File Offset: 0x000664CC
	public override void commandPointer(int index, int sub)
	{
		if (index == 0)
		{
			if (this.lastScreen == null || this.lastScreen == GameCanvas.currentScreen || GameCanvas.currentScreen == GameCanvas.AllInfo)
			{
				GameCanvas.game.Show();
			}
			else
			{
				this.lastScreen.Show(this.lastScreen.lastScreen);
			}
			if (GameScreen.help.setStep_Next(4, 9))
			{
				GameScreen.help.NextStep();
				GameScreen.help.setNext();
			}
		}
	}

	// Token: 0x060006D9 RID: 1753 RVA: 0x00068360 File Offset: 0x00066560
	public void addMoreTab(mVector t)
	{
		this.VecTabScreen.removeAllElements();
		this.VecTabScreen = t;
	}

	// Token: 0x060006DA RID: 1754 RVA: 0x00068374 File Offset: 0x00066574
	public override void paint(mGraphics g)
	{
		if (Main.isPC || Main.isIpad)
		{
			GameScreen.gI().paint(g);
			GameCanvas.resetTrans(g);
			GameScreen.infoGame.paintInfoPlayer(g, 0, 0, !GameCanvas.isSmallScreen, mFont.tahoma_7_white);
		}
		MainTabNew currentTab = this.getCurrentTab();
		GameCanvas.resetTrans(g);
		MainTabNew.gI().paintTab(g, currentTab.nameTab, this.selectTab, this.VecTabScreen, currentTab.isClan);
		currentTab.paint(g);
		GameCanvas.resetTrans(g);
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && GameCanvas.currentScreen == this)
		{
			if (GameCanvas.isTouch)
			{
				base.paintCmd(g);
			}
			else if ((int)MainTabNew.Focus == (int)MainTabNew.TAB)
			{
				base.paintCmd_OnlyText(g);
			}
			else
			{
				currentTab.paintCmd_OnlyText(g);
			}
		}
		else
		{
			TabScreenNew.timeRepaint = 10;
		}
		if (GameScreen.help.Step >= 0 && !GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.subDialog == null && (int)currentTab.typeTab != (int)MainTabNew.INVENTORY)
		{
			GameScreen.help.itemTabHelp(g, null, currentTab.typeTab);
		}
	}

	// Token: 0x060006DB RID: 1755 RVA: 0x000684C8 File Offset: 0x000666C8
	public override void update()
	{
		if (this.lastScreen == GameCanvas.game)
		{
			this.lastScreen.update();
		}
		MainTabNew currentTab = this.getCurrentTab();
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null && GameCanvas.currentScreen == this)
		{
			currentTab.update();
		}
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null)
		{
			TabScreenNew.timeRepaint = 10;
		}
		else if (TabScreenNew.timeRepaint > 0)
		{
			TabScreenNew.timeRepaint--;
		}
	}

	// Token: 0x060006DC RID: 1756 RVA: 0x00068560 File Offset: 0x00066760
	private MainTabNew getCurrentTab()
	{
		return (MainTabNew)this.VecTabScreen.elementAt(this.selectTab);
	}

	// Token: 0x060006DD RID: 1757 RVA: 0x00068578 File Offset: 0x00066778
	public override void updatekey()
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null)
		{
			return;
		}
		if ((int)MainTabNew.Focus == (int)MainTabNew.TAB)
		{
			TabScreenNew.timeRepaint = 10;
			this.left = null;
			this.center = null;
			this.right = TabScreenNew.cmdBack;
			int num = this.selectTab;
			if (GameCanvas.keyMyHold[2])
			{
				this.selectTab--;
				GameCanvas.clearKeyHold();
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
			}
			else if (GameCanvas.keyMyHold[8])
			{
				this.selectTab++;
				GameCanvas.clearKeyHold();
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
			}
			else if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[6])
			{
				GameCanvas.clearKeyHold();
				GameCanvas.clearKeyPressed();
				this.SetInit();
			}
			this.selectTab = base.resetSelect(this.selectTab, this.VecTabScreen.size() - 1, true);
			if (num != this.selectTab)
			{
				MainScreen.cameraSub.yCam = 0;
			}
			MainTabNew currentTab = this.getCurrentTab();
			if ((int)currentTab.typeTab == (int)MainTabNew.CONFIG || (int)currentTab.typeTab == (int)MainTabNew.FUNCTION)
			{
				currentTab.init();
			}
			if (GameScreen.help.setStep_Next(3, 8))
			{
				if ((int)currentTab.typeTab == (int)MainTabNew.EQUIP)
				{
					currentTab.init();
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			else if (GameScreen.help.setStep_Next(7, 9))
			{
				if ((int)currentTab.typeTab == (int)MainTabNew.SKILLS)
				{
					currentTab.init();
					GameScreen.help.NextStep();
					GameScreen.help.setNext();
				}
			}
			else if (GameScreen.help.setStep_Next(9, 1) && (int)currentTab.typeTab == (int)MainTabNew.QUEST)
			{
				currentTab.init();
				GameScreen.help.Next++;
				GameScreen.help.setNext();
			}
			base.updatekey();
		}
		else
		{
			MainTabNew currentTab2 = this.getCurrentTab();
			if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
			{
				currentTab2.updatekey();
			}
		}
	}

	// Token: 0x060006DE RID: 1758 RVA: 0x000687FC File Offset: 0x000669FC
	public override void updatePointer()
	{
		if (GameCanvas.menu2.isShowMenu || GameCanvas.currentDialog != null || GameCanvas.subDialog != null)
		{
			return;
		}
		MainTabNew currentTab = this.getCurrentTab();
		if ((int)currentTab.typeTab == (int)MainTabNew.REBUILD && (int)TabRebuildItem.isBeginEff != 0)
		{
			return;
		}
		if (GameCanvas.isPointSelect(MainTabNew.gI().xTab, MainTabNew.gI().yTab + GameCanvas.h / 5, (int)MainTabNew.wOneItem + (int)MainTabNew.wOne5 * 2, (int)MainTabNew.wOneItem * this.VecTabScreen.size()))
		{
			int num = (GameCanvas.py - (MainTabNew.gI().yTab + GameCanvas.h / 5)) / (int)MainTabNew.wOneItem;
			num = base.resetSelect(num, this.VecTabScreen.size() - 1, false);
			if (num != this.selectTab)
			{
				if (TabRebuildItem.resetItemReplace)
				{
					TabRebuildItem.itemFree = null;
					TabRebuildItem.itemPlus = null;
					TabRebuildItem.itemWing = null;
					TabRebuildItem.resetItemReplace = false;
				}
				TabScreenNew.timeRepaint = 10;
				this.selectTab = num;
				this.SetInit();
				currentTab = this.getCurrentTab();
				if (GameScreen.help.setStep_Next(3, 8))
				{
					if ((int)currentTab.typeTab == (int)MainTabNew.EQUIP)
					{
						GameScreen.help.NextStep();
						GameScreen.help.setNext();
					}
				}
				else if (GameScreen.help.setStep_Next(7, 9))
				{
					if ((int)currentTab.typeTab == (int)MainTabNew.SKILLS)
					{
						GameScreen.help.NextStep();
						GameScreen.help.setNext();
					}
				}
				else if (GameScreen.help.setStep_Next(9, 1) && (int)currentTab.typeTab == (int)MainTabNew.QUEST)
				{
					GameScreen.help.Next++;
					GameScreen.help.setNext();
				}
				mSound.playSound(41, mSound.volumeSound);
			}
			GameCanvas.isPointerSelect = false;
		}
		currentTab.updatePointer();
		base.updatePointer();
	}

	// Token: 0x060006DF RID: 1759 RVA: 0x000689F0 File Offset: 0x00066BF0
	public void SetInit()
	{
		MainTabNew.Focus = MainTabNew.INFO;
		MainTabNew currentTab = this.getCurrentTab();
		currentTab.init();
	}

	// Token: 0x060006E0 RID: 1760 RVA: 0x00068A14 File Offset: 0x00066C14
	public override void keyPress(int keyCode)
	{
		MainTabNew currentTab = this.getCurrentTab();
		currentTab.keypress(keyCode);
		base.keyPress(keyCode);
	}

	// Token: 0x04000A11 RID: 2577
	public const int CMD_TAB_CLOSE = 0;

	// Token: 0x04000A12 RID: 2578
	public const int CMD_BACK_TAB = 1;

	// Token: 0x04000A13 RID: 2579
	public int selectTab;

	// Token: 0x04000A14 RID: 2580
	public mVector VecTabScreen = new mVector("TabScreenNew VecTabScreen");

	// Token: 0x04000A15 RID: 2581
	public static iCommand cmdTab;

	// Token: 0x04000A16 RID: 2582
	public static iCommand cmdBack;

	// Token: 0x04000A17 RID: 2583
	public static int timeRepaint;

	// Token: 0x04000A18 RID: 2584
	public static int xback;

	// Token: 0x04000A19 RID: 2585
	public static int yback;
}
