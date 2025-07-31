using System;

// Token: 0x0200009B RID: 155
public class RunWord
{
	// Token: 0x06000780 RID: 1920 RVA: 0x00076D8C File Offset: 0x00074F8C
	public void startDialogChain(string dlgChain, int ActionType, int xFocus, int yFocus, int w, mFont f)
	{
		this.f = f;
		this.dlgActionType = ActionType;
		this.dlgFocusX = xFocus;
		this.dlgFocusY = yFocus;
		this.currentDlgStep = 0;
		this.dlgW = w;
		if (this.dlgW > GameCanvas.w - 10)
		{
			this.dlgW = GameCanvas.w - 10;
		}
		this.dlgChainInfo = f.splitFontArray(dlgChain, this.dlgW);
		this.dlgX = this.dlgFocusX;
		this.showDlg = true;
		this.dlgRunX = 0;
		this.dlgRunY = 0;
	}

	// Token: 0x06000781 RID: 1921 RVA: 0x00076E1C File Offset: 0x0007501C
	public bool checkDlgStep()
	{
		return this.dlgRunY >= this.dlgChainInfo.Length;
	}

	// Token: 0x06000782 RID: 1922 RVA: 0x00076E34 File Offset: 0x00075034
	public bool nextDlgStep()
	{
		if (this.dlgRunY < this.dlgChainInfo.Length)
		{
			this.dlgRunY = this.dlgChainInfo.Length;
			this.dlgRunX = 0;
			return false;
		}
		this.dlgRunX = (this.dlgRunY = 0);
		return true;
	}

	// Token: 0x06000783 RID: 1923 RVA: 0x00076E7C File Offset: 0x0007507C
	public void updateDlg()
	{
		if (this.showDlg && this.dlgRunY < this.dlgChainInfo.Length)
		{
			this.dlgRunX += 2;
			if (this.dlgRunX >= this.dlgChainInfo[this.dlgRunY].Length)
			{
				this.dlgRunX = 0;
				this.dlgRunY++;
			}
		}
	}

	// Token: 0x06000784 RID: 1924 RVA: 0x00076EE8 File Offset: 0x000750E8
	public void paintText(mGraphics g)
	{
		int num = this.dlgFocusY;
		for (int i = 0; i < this.dlgRunY; i++)
		{
			this.f.drawString(g, this.dlgChainInfo[i], this.dlgX, num + i * GameCanvas.hText, 0, mGraphics.isFalse);
		}
		if (this.dlgRunY < this.dlgChainInfo.Length)
		{
			this.f.drawString(g, mSystem.substring(this.dlgChainInfo[this.dlgRunY], 0, this.dlgRunX), this.dlgX, num + this.dlgRunY * GameCanvas.hText, 0, mGraphics.isFalse);
		}
	}

	// Token: 0x06000785 RID: 1925 RVA: 0x00076F90 File Offset: 0x00075190
	public void paintText(mGraphics g, int archor)
	{
		int num = this.dlgFocusY;
		if (archor == 2)
		{
			for (int i = 0; i < this.dlgRunY; i++)
			{
				this.f.drawString(g, this.dlgChainInfo[i], this.dlgX + this.dlgW / 2, num + i * GameCanvas.hText, 2, mGraphics.isFalse);
			}
			if (this.dlgRunY < this.dlgChainInfo.Length)
			{
				this.f.drawString(g, mSystem.substring(this.dlgChainInfo[this.dlgRunY], 0, this.dlgRunX), this.dlgX + this.dlgW / 2, num + this.dlgRunY * GameCanvas.hText, 2, mGraphics.isFalse);
			}
		}
		else
		{
			for (int j = 0; j < this.dlgRunY; j++)
			{
				this.f.drawString(g, this.dlgChainInfo[j], this.dlgX, num + j * GameCanvas.hText, 0, mGraphics.isFalse);
			}
			if (this.dlgRunY < this.dlgChainInfo.Length)
			{
				this.f.drawString(g, mSystem.substring(this.dlgChainInfo[this.dlgRunY], 0, this.dlgRunX), this.dlgX, num + this.dlgRunY * GameCanvas.hText, 0, mGraphics.isFalse);
			}
		}
	}

	// Token: 0x04000B78 RID: 2936
	public bool showDlg;

	// Token: 0x04000B79 RID: 2937
	public int nStepToShow;

	// Token: 0x04000B7A RID: 2938
	public int currentDlgStep;

	// Token: 0x04000B7B RID: 2939
	public int dlgActionType;

	// Token: 0x04000B7C RID: 2940
	public string[] dlgChainInfo;

	// Token: 0x04000B7D RID: 2941
	public int dlgFocusX;

	// Token: 0x04000B7E RID: 2942
	public int dlgFocusY;

	// Token: 0x04000B7F RID: 2943
	public int dlgRunX;

	// Token: 0x04000B80 RID: 2944
	public int dlgRunY;

	// Token: 0x04000B81 RID: 2945
	public int dlgW;

	// Token: 0x04000B82 RID: 2946
	public int dlgX;

	// Token: 0x04000B83 RID: 2947
	private mFont f;
}
