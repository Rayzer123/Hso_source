using System;

// Token: 0x02000081 RID: 129
public class List_Ip_Server_Screen : MainScreen
{
	// Token: 0x0600061F RID: 1567 RVA: 0x0005B5C4 File Offset: 0x000597C4
	public List_Ip_Server_Screen()
	{
		LogoScreen.getServerList(LogoScreen.strListserver, false);
		this.hItem = GameCanvas.hCommand;
		this.w = GameCanvas.w - 20;
		if (this.w > 180)
		{
			this.w = 180;
		}
		this.h = GameCanvas.listServer.GetLength(0) * this.hItem;
		int limX = 0;
		if (this.h > GameCanvas.h / 5 * 4)
		{
			limX = this.h - GameCanvas.h / 5 * 4;
			this.h = GameCanvas.h / 5 * 4;
		}
		this.x = GameCanvas.hw - this.w / 2;
		this.y = GameCanvas.hh - this.h / 2 + this.hItem / 2;
		this.vecChoice.removeAllElements();
		for (int i = 0; i < GameCanvas.listServer.GetLength(0); i++)
		{
			this.vecChoice.addElement(new iCommand(GameCanvas.listServer[i, 0], 0, i, this));
		}
		if (GameCanvas.isTouch)
		{
			this.idSelect = -1;
		}
		this.list = new MainList(this.x, this.y, this.w, this.h, this.hItem, GameCanvas.listServer.GetLength(0), limX, this.idSelect, this.vecChoice);
	}

	// Token: 0x06000620 RID: 1568 RVA: 0x0005B740 File Offset: 0x00059940
	public override void commandPointer(int index, int subIndex)
	{
		if (index == 0)
		{
			if (Session_ME.connected)
			{
				Session_ME.gI().close();
			}
			GameCanvas.IndexServer = (sbyte)subIndex;
			GameCanvas.login.Show();
			bool isVN_Eng = GameCanvas.isVN_Eng;
			GameCanvas.isVN_Eng = (GameCanvas.langServer[(int)GameCanvas.IndexServer] == 0);
			if (GameCanvas.isVN_Eng != isVN_Eng)
			{
				LogoScreen.setChangeLang();
				GameCanvas.start_Ok_Dialog(T.TchangSv);
			}
			if (GameCanvas.isVN_Eng)
			{
				LoginScreen.isPaintHotLine = true;
			}
			else if (IndoServer.isIndoSv)
			{
				LoginScreen.isPaintHotLine = false;
			}
			if (Usa_Server.isUsa_server)
			{
				LoginScreen.isPaintHotLine = false;
				if ((int)GameCanvas.IndexServer == 0)
				{
					GameCanvas.t = new TE();
				}
				else if ((int)GameCanvas.IndexServer == 1)
				{
					GameCanvas.t = new TSpain();
				}
				mSystem.doChangeMenuNapapple();
			}
			GameCanvas.login.checkLoginAgain(GameCanvas.IndexServer);
		}
	}

	// Token: 0x06000621 RID: 1569 RVA: 0x0005B834 File Offset: 0x00059A34
	public override void paint(mGraphics g)
	{
		BackGround.paint(g);
		BackGround.paintLight(g);
		base.paintFormList(g, this.x, this.y - this.hItem, this.w, this.h + this.hItem, T.listserver);
		g.setClip(this.x, this.y, this.w, this.h);
		g.translate(0, -this.list.cmx);
		if (this.idSelect > -1)
		{
			this.paintFocus(g);
		}
		for (int i = 0; i < this.vecChoice.size(); i++)
		{
			iCommand iCommand = (iCommand)this.vecChoice.elementAt(i);
			mFont.tahoma_7b_white.drawString(g, iCommand.caption, this.x + this.w / 2, this.y + this.hItem / 2 + i * this.hItem - 6, 2, mGraphics.isTrue);
			if (i < this.vecChoice.size() - 1)
			{
				g.setColor(AvMain.color[4]);
				g.fillRect(this.x + 8, this.y + (i + 1) * this.hItem - 1, this.w - 16, 1, mGraphics.isTrue);
			}
		}
		if ((int)PaintInfoGameScreen.paint18plush == 0)
		{
			g.drawImage(AvMain.img18Plus, 0, 0, 0, mGraphics.isFalse);
		}
		else if ((int)PaintInfoGameScreen.paint18plush == 1)
		{
			PaintInfoGameScreen.paintinfo18plush(g);
		}
	}

	// Token: 0x06000622 RID: 1570 RVA: 0x0005B9B8 File Offset: 0x00059BB8
	public void paintFocus(mGraphics g)
	{
		g.setColor(13088156);
		g.fillRect(this.x + 5, this.y + this.idSelect * this.hItem + this.hItem / 2 - 11, this.w - 10, 22, mGraphics.isFalse);
	}

	// Token: 0x06000623 RID: 1571 RVA: 0x0005BA10 File Offset: 0x00059C10
	public override void update()
	{
		this.list.updateMenu();
		this.idSelect = this.list.value;
		if (this.idSelect >= this.vecChoice.size())
		{
			this.idSelect = -1;
			this.list.value = -1;
		}
	}

	// Token: 0x040008C8 RID: 2248
	private int x;

	// Token: 0x040008C9 RID: 2249
	private int y;

	// Token: 0x040008CA RID: 2250
	private int w;

	// Token: 0x040008CB RID: 2251
	private int h;

	// Token: 0x040008CC RID: 2252
	private int idSelect;

	// Token: 0x040008CD RID: 2253
	private int hItem;

	// Token: 0x040008CE RID: 2254
	private MainList list;

	// Token: 0x040008CF RID: 2255
	private mVector vecChoice = new mVector("List_Ip_Server_Screen vecchoice");
}
