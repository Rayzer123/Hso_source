using System;

// Token: 0x0200009A RID: 154
public class PopupChat : AvMain
{
	// Token: 0x0600077A RID: 1914 RVA: 0x00076A30 File Offset: 0x00074C30
	public void setChat(string strContent, bool isStop)
	{
		this.isStop = isStop;
		strContent = strContent.Trim();
		this.w = mFont.tahoma_7_black.getWidth(strContent);
		if (this.w > 100)
		{
			this.w = 100;
		}
		else if (this.w < 20)
		{
			this.w = 20;
		}
		this.dy = 8;
		this.name = strContent;
		this.strChat = mFont.tahoma_7_black.splitFontArray(strContent, this.w);
		this.h = this.strChat.Length * GameCanvas.hText;
		if (this.strChat.Length <= 2)
		{
			this.timeOff = 80;
		}
		else
		{
			this.timeOff = 140;
		}
	}

	// Token: 0x0600077B RID: 1915 RVA: 0x00076AEC File Offset: 0x00074CEC
	public override void paint(mGraphics g)
	{
		if (this.dy > 0)
		{
			this.dy -= 2;
		}
		this.paintPopup(g);
	}

	// Token: 0x0600077C RID: 1916 RVA: 0x00076B10 File Offset: 0x00074D10
	public void updatePos(int x, int y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x0600077D RID: 1917 RVA: 0x00076B20 File Offset: 0x00074D20
	public bool setOff()
	{
		this.timeOff--;
		return this.timeOff <= 0 && this.isStop;
	}

	// Token: 0x0600077E RID: 1918 RVA: 0x00076B58 File Offset: 0x00074D58
	public void paintPopup(mGraphics g)
	{
		try
		{
			int num = this.y - this.h + this.dy;
			int num2 = this.x - this.w / 2;
			g.setColor(this.color[0]);
			g.fillRect(num2 - 3, num, this.w + 6, this.h, mGraphics.isTrue);
			g.fillRect(num2, num - 3, this.w, this.h + 6, mGraphics.isTrue);
			g.setColor(this.color[1]);
			g.fillRect(num2, num - 2, this.w, this.h + 4, mGraphics.isTrue);
			g.fillRect(num2 - 2, num, this.w + 4, this.h, mGraphics.isTrue);
			g.drawRegion(PopupChat.mPopup[0], 0, 0, 3, 3, 0, num2 - 3, num - 3, 0, mGraphics.isTrue);
			g.drawRegion(PopupChat.mPopup[0], 0, 3, 3, 3, 0, num2 + this.w, num - 3, 0, mGraphics.isTrue);
			g.drawRegion(PopupChat.mPopup[0], 0, 9, 3, 3, 0, num2 - 3, num + this.h, 0, mGraphics.isTrue);
			g.drawRegion(PopupChat.mPopup[0], 0, 6, 3, 3, 0, num2 + this.w, num + this.h, 0, mGraphics.isTrue);
			if (this.indexpaint == 1)
			{
				g.drawRegion(PopupChat.mPopup[1], 0, 0, 7, 7, 3, num2 + this.w / 2 - 3, num - 9, 0, mGraphics.isTrue);
			}
			else
			{
				g.drawImage(PopupChat.mPopup[1], num2 + this.w / 2 - 3, num + this.h + 2, 0, mGraphics.isTrue);
			}
			if (this.strChat != null)
			{
				for (int i = 0; i < this.strChat.Length; i++)
				{
					mFont.tahoma_7_black.drawString(g, this.strChat[i], num2 + this.w / 2, num + 1 + i * GameCanvas.hText, 2, mGraphics.isTrue);
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000B6C RID: 2924
	private int x = GameCanvas.hw;

	// Token: 0x04000B6D RID: 2925
	private int y = GameCanvas.hh;

	// Token: 0x04000B6E RID: 2926
	private int dy;

	// Token: 0x04000B6F RID: 2927
	public int h;

	// Token: 0x04000B70 RID: 2928
	public int w;

	// Token: 0x04000B71 RID: 2929
	public int timeOff;

	// Token: 0x04000B72 RID: 2930
	public int indexpaint;

	// Token: 0x04000B73 RID: 2931
	public string[] strChat;

	// Token: 0x04000B74 RID: 2932
	public static mImage[] mPopup = new mImage[2];

	// Token: 0x04000B75 RID: 2933
	private bool isStop = true;

	// Token: 0x04000B76 RID: 2934
	public string name;

	// Token: 0x04000B77 RID: 2935
	private new int[] color = new int[]
	{
		3349556,
		16760428
	};
}
