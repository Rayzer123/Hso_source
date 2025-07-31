using System;

// Token: 0x020000D6 RID: 214
public class MiniMapFull_Screen : MainScreen
{
	// Token: 0x060009F5 RID: 2549 RVA: 0x000A7CA8 File Offset: 0x000A5EA8
	public static MiniMapFull_Screen gI()
	{
		if (GameCanvas.fullMiniMap == null)
		{
			GameCanvas.fullMiniMap = new MiniMapFull_Screen();
		}
		return GameCanvas.fullMiniMap;
	}

	// Token: 0x060009F6 RID: 2550 RVA: 0x000A7CC4 File Offset: 0x000A5EC4
	public override void Show()
	{
		this.canShowMiniMap = true;
		this.lastScreen = GameCanvas.game;
		MiniMap.isAtMiniMap = false;
		if (Main.isWindowsPhone)
		{
			MiniMap.isStartMiniMap = false;
		}
		this.init();
		base.Show();
		if (this.maxX == this.LimitX && this.maxY == this.LimitY)
		{
			this.canShowMiniMap = false;
		}
	}

	// Token: 0x060009F7 RID: 2551 RVA: 0x000A7D30 File Offset: 0x000A5F30
	public void init()
	{
		this.cmdBack = new iCommand(T.back, -1, this);
		this.maxX = GameCanvas.minimap.maxX;
		this.maxY = GameCanvas.minimap.maxY;
		this.LimitX = GameCanvas.loadmap.mapW;
		this.LimitY = GameCanvas.loadmap.mapH;
		if (this.LimitX > GameCanvas.w - GameCanvas.hCommand)
		{
			this.LimitX = GameCanvas.w - GameCanvas.hCommand;
		}
		if (this.LimitY > GameCanvas.h - GameCanvas.hCommand)
		{
			this.LimitY = GameCanvas.h - GameCanvas.hCommand;
		}
		this.speedShowX = (this.LimitX - this.maxX) / 5;
		this.speedShowY = (this.LimitY - this.maxY) / 5;
		if (this.speedShowX <= 0)
		{
			this.speedShowX = 1;
		}
		if (this.speedShowY <= 0)
		{
			this.speedShowY = 1;
		}
		if (GameCanvas.isTouch)
		{
			this.wMini = 3;
			if (this.imgtest == null || LoadMap.get_Item().idMap != MiniMapFull_Screen.idMap)
			{
				if (this.imgtest != null && this.imgtest.image != null)
				{
					this.imgtest.image.texture = null;
					mSystem.gcc();
				}
				if (LoadMap.get_Item().idMap != MiniMapFull_Screen.idMap)
				{
					MiniMapFull_Screen.idMap = LoadMap.get_Item().idMap;
				}
				string text = string.Concat(new object[]
				{
					"minimapfull",
					MiniMapFull_Screen.idMap,
					"_",
					LoadMap.me.mapW,
					"_",
					LoadMap.me.mapH
				});
				this.imgtest = mImage.loadImageRMS(text);
				if (this.imgtest == null)
				{
					MiniMap.isAtMiniMap = false;
					MiniMap.CreateMiniMap(this.wMini, (!Main.isWindowsPhone) ? 0 : 1);
					if (this.imgtest != null && !Main.isWindowsPhone)
					{
						byte[] byteArray = mSystem.getByteArray(this.imgtest.image);
						Rms.saveRMS(text, ArrayCast.cast(byteArray));
					}
				}
			}
		}
		else
		{
			this.wMini = MiniMap.wMini;
			this.imgtest = MiniMap.imgMiniMap;
		}
		this.typeEnd = -1;
	}

	// Token: 0x060009F8 RID: 2552 RVA: 0x000A7F94 File Offset: 0x000A6194
	public override void commandPointer(int index, int subIndex)
	{
		if (index == -1)
		{
			if (!this.canShowMiniMap)
			{
				this.typeEnd = 2;
				return;
			}
			if ((int)this.typeEnd == 0)
			{
				this.typeEnd = 1;
			}
		}
	}

	// Token: 0x060009F9 RID: 2553 RVA: 0x000A7FDC File Offset: 0x000A61DC
	public override void paint(mGraphics g)
	{
		this.lastScreen.paint(g);
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
		{
			GameCanvas.resetTrans(g);
			g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, 60, 1, mGraphics.isFalse);
		}
		if (GameCanvas.isTouch)
		{
			g.translate(GameCanvas.w - this.maxX * this.wMini, 0);
		}
		else
		{
			g.translate(GameCanvas.w - this.maxX * this.wMini - 3, GameCanvas.h - 23 - this.maxY * this.wMini);
		}
		g.setColor(7612434);
		g.fillRect(-3, -3, this.maxX * this.wMini + 6, this.maxY * this.wMini + 6, mGraphics.isFalse);
		g.setColor(16307052);
		g.fillRect(-2, -2, this.maxX * this.wMini + 4, this.maxY * this.wMini + 4, mGraphics.isFalse);
		g.setColor(4724752);
		g.fillRect(-1, -1, this.maxX * this.wMini + 2, this.maxY * this.wMini + 2, mGraphics.isFalse);
		g.setClip(0, 0, this.maxX * this.wMini, this.maxY * this.wMini);
		if (!MiniMap.isLoadMiniMapOk)
		{
			g.setColor(0);
			g.fillRect(-1, -1, this.maxX * this.wMini + 2, this.maxY * this.wMini + 2, mGraphics.isFalse);
			MsgDialog.fraWaiting.drawFrame(this.fWait % MsgDialog.fraWaiting.nFrame, (this.maxX * this.wMini + 2) / 2, (this.maxY * this.wMini + 4) / 2 - 5, 0, mGraphics.VCENTER | mGraphics.HCENTER, g);
			return;
		}
		if (MiniMap.isLoadMiniMapOk && !MiniMap.isAtMiniMap)
		{
			if (Main.isWindowsPhone)
			{
				ImageData imgData = MiniMap.getImgData((short)GameCanvas.loadmap.idMap, (short)(GameCanvas.loadmap.idMap + 1000), false);
				if (imgData != null && !imgData.isLoad && imgData.img != null)
				{
					g.drawImage(imgData.img, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isFalse);
				}
			}
			else if (this.imgtest != null)
			{
				g.drawImage(this.imgtest, 0, 0 + mGraphics.addYWhenOpenKeyBoard, 0, mGraphics.isFalse);
			}
			int num = this.wMini;
			for (int i = 0; i < LoadMap.vecPointChange.size(); i++)
			{
				Point point = (Point)LoadMap.vecPointChange.elementAt(i);
				g.setColor(6156031);
				switch (point.f)
				{
				case 0:
					g.fillRect(point.x * num / LoadMap.wTile - num, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isFalse);
					break;
				case 1:
					g.fillRect(point.x * num / LoadMap.wTile, point.y * num / LoadMap.wTile - 2 * num, num, num * 4, mGraphics.isFalse);
					break;
				case 2:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isFalse);
					break;
				case 3:
					g.fillRect(point.x * num / LoadMap.wTile - 2 * num, point.y * num / LoadMap.wTile, 4 * num, num, mGraphics.isFalse);
					break;
				}
			}
		}
		if ((int)LoadMap.typeMap == LoadMap.MAP_PHO_BANG)
		{
			for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
			{
				MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
				if ((int)mainObject.typeObject == 1)
				{
					AvMain.fraObjMiniMap.drawFrame(11, mainObject.x / LoadMap.wTile * this.wMini, mainObject.y / LoadMap.wTile * this.wMini, 0, 3, g);
				}
			}
		}
		for (int k = 0; k < MiniMap.vecNPC_Map.size(); k++)
		{
			NPCMini npcmini = (NPCMini)MiniMap.vecNPC_Map.elementAt(k);
			AvMain.fraObjMiniMap.drawFrame(npcmini.type + 4, npcmini.x / LoadMap.wTile * this.wMini, npcmini.y / LoadMap.wTile * this.wMini, 0, 3, g);
		}
		AvMain.fraObjMiniMap.drawFrame((GameScreen.player.Action != 4) ? GameScreen.player.Direction : 9, GameScreen.player.x / LoadMap.wTile * this.wMini, GameScreen.player.y / LoadMap.wTile * this.wMini, 0, 3, g);
		g.setColor(255);
		if (Player.party != null)
		{
			for (int l = 0; l < Player.party.vecPartys.size(); l++)
			{
				ObjectParty objectParty = (ObjectParty)Player.party.vecPartys.elementAt(l);
				if (objectParty.name.CompareTo(GameScreen.player.name) != 0 && objectParty.idMap == GameCanvas.loadmap.idMap)
				{
					AvMain.fraObjMiniMap.drawFrame(10, objectParty.x / LoadMap.wTile * this.wMini, objectParty.y / LoadMap.wTile * this.wMini, 0, 3, g);
				}
			}
		}
		if (MiniMap.pHelp != null && MiniMap.pHelp.frame == GameCanvas.loadmap.idMap)
		{
			int num2 = MiniMap.pHelp.x;
			int num3 = MiniMap.pHelp.y;
			if (num2 < this.miniCamera.xCam + 3)
			{
				num2 = this.miniCamera.xCam + 3;
			}
			if (num2 > this.miniCamera.xCam + this.maxX * this.wMini - 3)
			{
				num2 = this.miniCamera.xCam + this.maxX * this.wMini - 3;
			}
			if (num3 < this.miniCamera.yCam + 3)
			{
				num3 = this.miniCamera.yCam + 3;
			}
			if (num3 > this.miniCamera.yCam + this.maxY * this.wMini - 3)
			{
				num3 = this.miniCamera.yCam + this.maxY * this.wMini - 3;
			}
			WorldMapScreen.fraMyPos.drawFrame(GameCanvas.gameTick / 2 % WorldMapScreen.fraMyPos.nFrame, num2, num3, 0, 3, g);
		}
		GameCanvas.resetTrans(g);
		if (GameScreen.infoGame.isMapArena(GameCanvas.loadmap.idMap))
		{
			GameScreen.infoGame.paintSttArena(g, 10, 40, 20, 20);
		}
		GameScreen.infoGame.paintPos_minimap(g, GameCanvas.w, 0);
	}

	// Token: 0x060009FA RID: 2554 RVA: 0x000A8724 File Offset: 0x000A6924
	public override void update()
	{
		this.fWait++;
		if ((int)this.typeEnd == 2)
		{
			this.lastScreen.Show();
			MiniMap.isAtMiniMap = true;
			if (Main.isWindowsPhone)
			{
			}
		}
		else if ((int)this.typeEnd == 1)
		{
			if (this.maxX > GameCanvas.minimap.maxX)
			{
				this.maxX -= this.speedShowX * 2;
				if (this.maxX <= GameCanvas.minimap.maxX)
				{
					this.maxX = GameCanvas.minimap.maxX;
					this.typeEnd = 2;
				}
			}
			if (this.maxY > GameCanvas.minimap.maxY)
			{
				this.maxY -= this.speedShowY * 2;
				if (this.maxY <= GameCanvas.minimap.maxY)
				{
					this.maxY = GameCanvas.minimap.maxY;
					this.typeEnd = 2;
				}
			}
		}
		else
		{
			if (this.maxX < this.LimitX)
			{
				this.maxX += this.speedShowX;
				if (this.maxX >= this.LimitX)
				{
					this.maxX = this.LimitX;
					this.typeEnd = 0;
				}
			}
			if (this.maxY < this.LimitY)
			{
				this.maxY += this.speedShowY;
				if (this.maxY >= this.LimitY)
				{
					this.maxY = this.LimitY;
					this.typeEnd = 0;
				}
			}
		}
		this.lastScreen.update();
		for (int i = 0; i < GameCanvas.keyMyHold.Length; i++)
		{
			if (GameCanvas.keyMyHold[i])
			{
				this.cmdBack.perform();
				GameCanvas.clearKeyHold(i);
				break;
			}
		}
	}

	// Token: 0x060009FB RID: 2555 RVA: 0x000A8900 File Offset: 0x000A6B00
	public override void updatePointer()
	{
		if (GameCanvas.isPointerDown)
		{
			this.cmdBack.perform();
		}
	}

	// Token: 0x040011BB RID: 4539
	private int maxX;

	// Token: 0x040011BC RID: 4540
	private int maxY;

	// Token: 0x040011BD RID: 4541
	private int LimitX;

	// Token: 0x040011BE RID: 4542
	private int LimitY;

	// Token: 0x040011BF RID: 4543
	private int speedShowX;

	// Token: 0x040011C0 RID: 4544
	private int speedShowY;

	// Token: 0x040011C1 RID: 4545
	private int wMini;

	// Token: 0x040011C2 RID: 4546
	private Camera miniCamera = new Camera();

	// Token: 0x040011C3 RID: 4547
	private iCommand cmdBack;

	// Token: 0x040011C4 RID: 4548
	public static int idMap = -1;

	// Token: 0x040011C5 RID: 4549
	public mImage imgtest;

	// Token: 0x040011C6 RID: 4550
	private sbyte typeEnd = -1;

	// Token: 0x040011C7 RID: 4551
	public int fWait;

	// Token: 0x040011C8 RID: 4552
	private bool canShowMiniMap = true;
}
