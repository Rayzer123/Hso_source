using System;

// Token: 0x0200008B RID: 139
public class StoryScreen : MainScreen
{
	// Token: 0x060006CB RID: 1739 RVA: 0x00067D64 File Offset: 0x00065F64
	public static void setTypeStory()
	{
		if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv)
		{
			StoryScreen.mTypeStory = new int[3];
		}
		else
		{
			StoryScreen.mTypeStory = new int[2];
		}
	}

	// Token: 0x060006CC RID: 1740 RVA: 0x00067D98 File Offset: 0x00065F98
	public void setCmdnext()
	{
		if (this.cmdNext == null)
		{
			this.cmdNext = new iCommand(T.next, -1, this);
			this.cmdNext.caption = T.next;
			this.cmdNext.setPos(GameCanvas.hw, GameCanvas.h - iCommand.hButtonCmd, null, this.cmdNext.caption);
			this.center = this.cmdNext;
		}
	}

	// Token: 0x060006CD RID: 1741 RVA: 0x00067E08 File Offset: 0x00066008
	public void setContent()
	{
		this.setCmdnext();
		if (this.indexType >= StoryScreen.mTypeStory.Length)
		{
			GameCanvas.game.Show();
			GameCanvas.hLoad = GameCanvas.hh;
			this.indexType = 0;
			if (MainQuest.vecQuestList != null)
			{
				for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
				{
					MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
					mainQuest.beginQuest();
					GameScreen.player.Direction = 1;
				}
			}
			return;
		}
		int num = 220;
		if (num > GameCanvas.w)
		{
			num = GameCanvas.w - 10;
		}
		if (StoryScreen.mTypeStory[this.indexType] == 0)
		{
			this.strcontent = mFont.tahoma_7b_white.splitFontArray(T.story[this.indexType], num);
			this.maxH = 180 + this.strcontent.Length * GameCanvas.hText;
			this.speed = 1;
			if (this.strcontent.Length < 4)
			{
				this.speed = 2;
			}
		}
		else
		{
			this.run.startDialogChain(T.story[this.indexType], 0, GameCanvas.hw - num / 2, GameCanvas.hh, 220, mFont.tahoma_7b_white);
		}
		this.indexType++;
	}

	// Token: 0x060006CE RID: 1742 RVA: 0x00067F54 File Offset: 0x00066154
	public override void paint(mGraphics g)
	{
		g.setColor(0);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.setClip(0, GameCanvas.hh - 90, GameCanvas.w, 180);
		if (this.strcontent != null)
		{
			for (int i = 0; i < this.strcontent.Length; i++)
			{
				mFont.tahoma_7b_white.drawString(g, this.strcontent[i], GameCanvas.hw, GameCanvas.hh + 80 + i * GameCanvas.hText - this.ypaint, 2, mGraphics.isTrue);
			}
		}
		else if (this.run.dlgChainInfo != null)
		{
			this.run.paintText(g);
			GameCanvas.resetTrans(g);
			AvMain.Font3dWhite(g, T.next, GameCanvas.hw, GameCanvas.h - GameCanvas.hCommand / 2 - 4, 2);
		}
		base.paint(g);
	}

	// Token: 0x060006CF RID: 1743 RVA: 0x00068040 File Offset: 0x00066240
	public override void update()
	{
		if (this.strcontent != null)
		{
			this.ypaint += this.speed;
			if (this.ypaint > this.maxH)
			{
				this.strcontent = null;
				this.setContent();
				this.ypaint = 0;
			}
		}
		else if (this.run.dlgChainInfo != null)
		{
			this.run.updateDlg();
		}
	}

	// Token: 0x060006D0 RID: 1744 RVA: 0x000680B0 File Offset: 0x000662B0
	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			this.indexType = StoryScreen.mTypeStory.Length;
			this.setContent();
		}
	}

	// Token: 0x060006D1 RID: 1745 RVA: 0x000680E4 File Offset: 0x000662E4
	public override void updatekey()
	{
		if (GameCanvas.keyMyPressed[5])
		{
			this.indexType = StoryScreen.mTypeStory.Length;
			this.setContent();
			GameCanvas.clearKeyPressed(5);
		}
		if (this.run.dlgChainInfo != null)
		{
			if (GameCanvas.keyMyHold[5] && this.run.nextDlgStep())
			{
				this.run.dlgChainInfo = null;
				this.setContent();
				GameCanvas.clearKeyHold(5);
			}
			base.updatekey();
		}
	}

	// Token: 0x04000A06 RID: 2566
	private string[] strcontent;

	// Token: 0x04000A07 RID: 2567
	private int maxH;

	// Token: 0x04000A08 RID: 2568
	private int ypaint;

	// Token: 0x04000A09 RID: 2569
	private int indexType;

	// Token: 0x04000A0A RID: 2570
	private int speed;

	// Token: 0x04000A0B RID: 2571
	private RunWord run = new RunWord();

	// Token: 0x04000A0C RID: 2572
	public static int[] mTypeStory;

	// Token: 0x04000A0D RID: 2573
	private iCommand cmdNext;
}
