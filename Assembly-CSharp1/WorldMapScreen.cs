using System;

// Token: 0x0200008E RID: 142
public class WorldMapScreen : MainScreen
{
	// Token: 0x060006E1 RID: 1761 RVA: 0x00068A38 File Offset: 0x00066C38
	public WorldMapScreen()
	{
		this.x = (GameCanvas.w - 480) / 2;
		this.y = (GameCanvas.h - 320) / 2;
		if (this.x < 0)
		{
			this.x = 0;
		}
		if (this.y < 0)
		{
			this.y = 0;
		}
		this.cam.setAll(480 - GameCanvas.w, 320 - GameCanvas.h, 0, 0);
		this.xPoint = this.mPosPoint[1][0];
		this.yPoint = this.mPosPoint[1][1];
		this.cam.xCam = this.xPoint - GameCanvas.hw;
		this.cam.yCam = this.yPoint - GameCanvas.hh;
		if (this.cam.xCam < 0)
		{
			this.cam.xCam = 0;
		}
		if (this.cam.xCam > this.cam.xLimit)
		{
			this.cam.xCam = this.cam.xLimit;
		}
		if (this.cam.yCam < 0)
		{
			this.cam.yCam = 0;
		}
		if (this.cam.yCam > this.cam.yLimit)
		{
			this.cam.yCam = this.cam.yLimit;
		}
		this.cam.xTo = this.cam.xCam;
		this.cam.yTo = this.cam.yCam;
		iCommand iCommand = new iCommand(T.close, -1);
		if (!GameCanvas.isTouch)
		{
			this.left = new iCommand(T.select, 0);
		}
		else
		{
			iCommand.setPos(PaintInfoGameScreen.fraBack.frameWidth / 2, GameCanvas.h - PaintInfoGameScreen.fraBack.frameHeight / 2, PaintInfoGameScreen.fraBack, iCommand.caption);
		}
		this.right = iCommand;
	}

	// Token: 0x060006E3 RID: 1763 RVA: 0x00068E38 File Offset: 0x00067038
	public override void Show(MainScreen scr)
	{
		GameCanvas.start_Ok_Dialog(T.lockMap);
	}

	// Token: 0x060006E4 RID: 1764 RVA: 0x00068E44 File Offset: 0x00067044
	public override void Show()
	{
		mSystem.outloi("goi ham show kia");
		this.Show(GameCanvas.currentScreen);
	}

	// Token: 0x060006E5 RID: 1765 RVA: 0x00068E5C File Offset: 0x0006705C
	public void setPosPlayer(int index)
	{
	}

	// Token: 0x060006E6 RID: 1766 RVA: 0x00068E60 File Offset: 0x00067060
	public override void commandTab(int index, int sub)
	{
		if (index != -1)
		{
			if (index != 0)
			{
			}
		}
		else if (this.lastScreen == GameCanvas.AllInfo)
		{
			this.lastScreen.Show(this.lastScreen.lastScreen);
		}
		else
		{
			this.lastScreen.Show();
		}
		base.commandTab(index, sub);
	}

	// Token: 0x060006E7 RID: 1767 RVA: 0x00068ECC File Offset: 0x000670CC
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x060006E8 RID: 1768 RVA: 0x00068EF4 File Offset: 0x000670F4
	public override void paint(mGraphics g)
	{
		g.setColor(5595238);
		g.fillRect(0, 0, GameCanvas.w, GameCanvas.h, mGraphics.isFalse);
		g.translate(-this.cam.xCam, -this.cam.yCam);
		g.drawImage(AvMain.imgWorldMap, this.x, this.y, 0, mGraphics.isFalse);
		if (this.timeSetPos == -1 && (!GameCanvas.isTouch || GameCanvas.isPointerDown || GameCanvas.isPointerMove))
		{
			mFont.tahoma_7b_black.drawString(g, WorldMapScreen.namePos[this.idPoint], this.cam.xCam + GameCanvas.w - 5, this.cam.yCam + 4, 1, mGraphics.isFalse);
			mFont.tahoma_7b_white.drawString(g, WorldMapScreen.namePos[this.idPoint], this.cam.xCam + GameCanvas.w - 4, this.cam.yCam + 5, 1, mGraphics.isFalse);
		}
		WorldMapScreen.fraMyPos.drawFrame(GameCanvas.gameTick / 2 % WorldMapScreen.fraMyPos.nFrame, this.x + this.xplayer - 1, this.y + this.yplayer - 1, 0, 3, g);
		if (!GameCanvas.isTouch)
		{
			g.drawImage(AvMain.imgSelect, this.x + this.xPoint, this.y + this.yPoint - this.dy, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
		}
		if (!GameCanvas.menu2.isShowMenu && GameCanvas.currentDialog == null)
		{
			if (GameCanvas.isTouch)
			{
				base.paint(g);
			}
			else
			{
				base.paintCmd_OnlyText(g);
			}
		}
	}

	// Token: 0x060006E9 RID: 1769 RVA: 0x000690BC File Offset: 0x000672BC
	public override void update()
	{
		this.updateKey();
		if (this.timeSetPos > 0)
		{
			this.timeSetPos--;
			if (this.timeSetPos == 1)
			{
				for (int i = 0; i < this.mPosPoint.Length; i++)
				{
					if (CRes.abs(this.mPosPoint[i][0] - this.xPoint) <= 6 && CRes.abs(this.mPosPoint[i][1] - this.yPoint) <= 6)
					{
						this.xPoint = this.mPosPoint[i][0];
						this.yPoint = this.mPosPoint[i][1];
						this.idPoint = i;
						this.timeSetPos = -1;
						break;
					}
				}
			}
		}
		if (this.timeSetPos < 0)
		{
			this.dy = GameCanvas.gameTick % 4;
		}
		else
		{
			this.dy = 0;
		}
		this.cam.UpdateCamera();
	}

	// Token: 0x060006EA RID: 1770 RVA: 0x000691AC File Offset: 0x000673AC
	public void updateKey()
	{
		if (GameCanvas.keyMyHold[4] || GameCanvas.keyMyHold[24])
		{
			if (this.xPoint > 10)
			{
				this.xPoint -= 5;
			}
			else
			{
				this.xPoint = 5;
			}
			this.timeSetPos = 3;
			if (this.cam.xLimit > 0)
			{
				this.cam.xTo -= 5;
			}
		}
		else if (GameCanvas.keyMyHold[6] || GameCanvas.keyMyHold[26])
		{
			if (this.xPoint < 470)
			{
				this.xPoint += 5;
			}
			else
			{
				this.xPoint = 475;
			}
			this.timeSetPos = 3;
			if (this.cam.xLimit > 0)
			{
				this.cam.xTo += 5;
			}
		}
		else if (GameCanvas.keyMyHold[2] || GameCanvas.keyMyHold[22])
		{
			if (this.yPoint > 10)
			{
				this.yPoint -= 5;
			}
			else
			{
				this.yPoint = 5;
			}
			this.timeSetPos = 3;
			if (this.cam.yLimit > 0)
			{
				this.cam.yTo -= 5;
			}
		}
		else if (GameCanvas.keyMyHold[8] || GameCanvas.keyMyHold[28])
		{
			if (this.yPoint < 315)
			{
				this.yPoint += 5;
			}
			else
			{
				this.yPoint = 320;
			}
			this.timeSetPos = 3;
			if (this.cam.yLimit > 0)
			{
				this.cam.yTo += 5;
			}
		}
		base.updatekey();
	}

	// Token: 0x060006EB RID: 1771 RVA: 0x00069388 File Offset: 0x00067588
	public override void updatePointer()
	{
		base.updatePointer();
		if (GameCanvas.isPointerMove)
		{
			if (!this.ismove)
			{
				this.beginx = GameCanvas.px;
				this.beginy = GameCanvas.py;
				this.xafter = this.cam.xCam;
				this.yafter = this.cam.yCam;
				this.ismove = true;
			}
			else
			{
				this.cam.xCam = this.xafter - (GameCanvas.px - this.beginx);
				this.cam.yCam = this.yafter - (GameCanvas.py - this.beginy);
				if (this.cam.xCam < 0)
				{
					this.cam.xCam = 0;
				}
				if (this.cam.xCam > this.cam.xLimit)
				{
					this.cam.xCam = this.cam.xLimit;
				}
				if (this.cam.yCam < 0)
				{
					this.cam.yCam = 0;
				}
				if (this.cam.yCam > this.cam.yLimit)
				{
					this.cam.yCam = this.cam.yLimit;
				}
				this.cam.xTo = this.cam.xCam;
				this.cam.yTo = this.cam.yCam;
			}
		}
		if (GameCanvas.isPointerRelease || !GameCanvas.isPointerMove)
		{
			this.ismove = false;
			this.beginx = 0;
			this.beginy = 0;
		}
		if (GameCanvas.isPointerDown || GameCanvas.isPointerMove)
		{
			this.xPoint = GameCanvas.px + this.cam.xCam - this.x;
			this.yPoint = GameCanvas.py + this.cam.yCam - this.y;
		}
		for (int i = 0; i < this.mPosPoint.Length; i++)
		{
			if (CRes.abs(this.mPosPoint[i][0] - this.xPoint) <= 8 && CRes.abs(this.mPosPoint[i][1] - this.yPoint) <= 8)
			{
				this.idPoint = i;
				this.timeSetPos = -1;
				return;
			}
		}
		this.timeSetPos = 3;
	}

	// Token: 0x04000A1A RID: 2586
	private int x;

	// Token: 0x04000A1B RID: 2587
	private int y;

	// Token: 0x04000A1C RID: 2588
	private int dy;

	// Token: 0x04000A1D RID: 2589
	private int timeSetPos;

	// Token: 0x04000A1E RID: 2590
	public static byte idMyPos = 5;

	// Token: 0x04000A1F RID: 2591
	public int xPoint;

	// Token: 0x04000A20 RID: 2592
	public int yPoint;

	// Token: 0x04000A21 RID: 2593
	public int idPoint;

	// Token: 0x04000A22 RID: 2594
	public int xplayer;

	// Token: 0x04000A23 RID: 2595
	public int yplayer;

	// Token: 0x04000A24 RID: 2596
	private int[][] mPosPoint = new int[][]
	{
		new int[]
		{
			222,
			263
		},
		new int[]
		{
			266,
			213
		},
		new int[]
		{
			266,
			213
		},
		new int[]
		{
			238,
			205
		},
		new int[]
		{
			225,
			197
		},
		new int[]
		{
			201,
			195
		},
		new int[]
		{
			201,
			195
		},
		new int[]
		{
			329,
			182
		},
		new int[]
		{
			317,
			161
		},
		new int[]
		{
			305,
			151
		},
		new int[]
		{
			305,
			151
		},
		new int[]
		{
			362,
			189
		},
		new int[]
		{
			387,
			195
		},
		new int[]
		{
			415,
			191
		},
		new int[]
		{
			415,
			191
		},
		new int[]
		{
			372,
			165
		},
		new int[]
		{
			386,
			148
		},
		new int[]
		{
			390,
			134
		},
		new int[]
		{
			345,
			161
		}
	};

	// Token: 0x04000A25 RID: 2597
	public static string[] namePos;

	// Token: 0x04000A26 RID: 2598
	public static FrameImage fraMyPos;

	// Token: 0x04000A27 RID: 2599
	private Camera cam = new Camera();

	// Token: 0x04000A28 RID: 2600
	private int beginx;

	// Token: 0x04000A29 RID: 2601
	private int beginy;

	// Token: 0x04000A2A RID: 2602
	private int xafter;

	// Token: 0x04000A2B RID: 2603
	private int yafter;

	// Token: 0x04000A2C RID: 2604
	private bool ismove;
}
