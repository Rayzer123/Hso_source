using System;

// Token: 0x02000038 RID: 56
public class Effect_UpLv_Item
{
	// Token: 0x060002C7 RID: 711 RVA: 0x00026524 File Offset: 0x00024724
	public void paintUpgradeEffect(int x, int y, int upgrade, int w, mGraphics g, int lech)
	{
		if (upgrade <= 0)
		{
			return;
		}
		int num = 0;
		int num2 = (upgrade - 1) % 5;
		g.setColor(this.colorBorder[num2][6]);
		g.drawRect(x - w / 2 - lech, y - w / 2 - lech, w, w, mGraphics.isTrue);
		for (int i = num; i < this.size.Length; i++)
		{
			int num3 = x - w / 2 + this.upgradeEffectX(GameCanvas.gameTick * 1 - i * this.wnew, w);
			int num4 = y - w / 2 + this.upgradeEffectY(GameCanvas.gameTick * 1 - i * this.wnew, w);
			g.setColor(this.colorBorder[num2][i]);
			g.fillRect(num3 - this.size[i] / 2 - lech, num4 - this.size[i] / 2 - lech, this.size[i], this.size[i], mGraphics.isTrue);
		}
		if (upgrade >= 6 && upgrade < 11)
		{
			for (int j = num; j < this.size.Length; j++)
			{
				int num5 = x - w / 2 + this.upgradeEffectX((GameCanvas.gameTick - w * 2) * 1 - j * this.wnew, w);
				int num6 = y - w / 2 + this.upgradeEffectY((GameCanvas.gameTick - w * 2) * 1 - j * this.wnew, w);
				g.setColor(this.colorBorder[num2][j]);
				g.fillRect(num5 - this.size[j] / 2 - lech, num6 - this.size[j] / 2 - lech, this.size[j], this.size[j], mGraphics.isTrue);
			}
		}
		if (upgrade >= 11)
		{
			for (int k = num; k < this.size.Length; k++)
			{
				int num7 = x - w / 2 + this.upgradeEffectX((GameCanvas.gameTick - w * 13 / 10) * 1 - k * this.wnew, w);
				int num8 = y - w / 2 + this.upgradeEffectY((GameCanvas.gameTick - w * 13 / 10) * 1 - k * this.wnew, w);
				g.setColor(this.colorBorder[num2][k]);
				g.fillRect(num7 - this.size[k] / 2 - lech, num8 - this.size[k] / 2 - lech, this.size[k], this.size[k], mGraphics.isTrue);
			}
			for (int l = num; l < this.size.Length; l++)
			{
				int num9 = x - w / 2 + this.upgradeEffectX((GameCanvas.gameTick - w * 13 / 5) * 1 - l * this.wnew, w);
				int num10 = y - w / 2 + this.upgradeEffectY((GameCanvas.gameTick - w * 13 / 5) * 1 - l * this.wnew, w);
				g.setColor(this.colorBorder[num2][l]);
				g.fillRect(num9 - this.size[l] / 2 - lech, num10 - this.size[l] / 2 - lech, this.size[l], this.size[l], mGraphics.isTrue);
			}
		}
	}

	// Token: 0x060002C8 RID: 712 RVA: 0x00026870 File Offset: 0x00024A70
	public int upgradeEffectY(int tick, int w)
	{
		int num = tick % (4 * w);
		if (0 <= num && num < w)
		{
			return 0;
		}
		if (w <= num && num < w * 2)
		{
			return num % w;
		}
		if (w * 2 <= num && num < w * 3)
		{
			return w;
		}
		return w - num % w;
	}

	// Token: 0x060002C9 RID: 713 RVA: 0x000268C4 File Offset: 0x00024AC4
	public int upgradeEffectX(int tick, int w)
	{
		int num = tick % (4 * w);
		if (0 <= num && num < w)
		{
			return num % w;
		}
		if (w <= num && num < w * 2)
		{
			return w;
		}
		if (w * 2 <= num && num < w * 3)
		{
			return w - num % w;
		}
		return 0;
	}

	// Token: 0x04000377 RID: 887
	private int wnew = 1;

	// Token: 0x04000378 RID: 888
	private int[][] colorBorder = new int[][]
	{
		new int[]
		{
			16777215,
			16777215,
			15724527,
			15724527,
			12698049,
			12698049,
			10526880
		},
		new int[]
		{
			2679551,
			2679551,
			2672631,
			2672631,
			2663136,
			2663136,
			2528153
		},
		new int[]
		{
			16775936,
			16775936,
			15525376,
			15525376,
			12827395,
			12827395,
			11182595
		},
		new int[]
		{
			16353279,
			16353279,
			15303935,
			15303935,
			13008383,
			13008383,
			10842574
		},
		new int[]
		{
			16757058,
			16757058,
			16750903,
			16750903,
			16742429,
			16742429,
			13597998
		}
	};

	// Token: 0x04000379 RID: 889
	private int[] size = new int[]
	{
		1,
		1,
		1,
		1,
		1
	};
}
