using System;

// Token: 0x0200004C RID: 76
public class MagicBeam : IArrow
{
	// Token: 0x06000359 RID: 857 RVA: 0x0002D6BC File Offset: 0x0002B8BC
	public override void setAngle(int angle)
	{
		this.arrow.setAngle(angle);
	}

	// Token: 0x0600035A RID: 858 RVA: 0x0002D6CC File Offset: 0x0002B8CC
	public void setEff(int tail, int end)
	{
		this.Efftail = tail;
		this.Effend = end;
	}

	// Token: 0x0600035B RID: 859 RVA: 0x0002D6DC File Offset: 0x0002B8DC
	public override void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
		this.arrow.set(type, x, y, owner.getDir(), target);
		this.type = type;
		this.owner = owner;
		this.effect = effect;
		if (type == 20)
		{
			type = 2;
		}
		this.hpLost = power;
		this.Efftail = -1;
		this.Effend = -1;
		this.power = power;
		this.wantDestroy = false;
		this.img = new FrameImage((int)effect);
		this.target = target;
	}

	// Token: 0x0600035C RID: 860 RVA: 0x0002D75C File Offset: 0x0002B95C
	public override void update()
	{
		this.arrow.updateAngle();
		this.x = this.arrow.x;
		this.y = this.arrow.y;
		if (this.Efftail != -1)
		{
			EffectEnd eff = new EffectEnd(57, this.Efftail, this.x, this.y);
			EffectManager.addHiEffect(eff);
		}
		if (this.arrow.isEnd)
		{
			this.onArrowTouchTarget();
		}
	}

	// Token: 0x0600035D RID: 861 RVA: 0x0002D7D8 File Offset: 0x0002B9D8
	public override void onArrowTouchTarget()
	{
		if (this.Effend != -1)
		{
			if (this.power < 0)
			{
				GameScreen.addEffectNum(string.Empty + this.power, this.target.x, this.target.y - this.target.hOne, 2, this.target.ID);
			}
			if (this.power > 0)
			{
				GameScreen.addEffectNum("+" + this.power, this.target.x, this.target.y - this.target.hOne, 0, this.target.ID);
			}
			GameScreen.addEffectEndFromSv(57, this.Effend, this.x, this.y);
		}
		this.wantDestroy = true;
	}

	// Token: 0x0600035E RID: 862 RVA: 0x0002D8BC File Offset: 0x0002BABC
	public override void paint(mGraphics g)
	{
		if (this.img != null)
		{
			this.img.drawFrameEffectSkill((int)this.fra, this.x, this.y, this.arrow.headTransform, 3, g);
		}
	}

	// Token: 0x0600035F RID: 863 RVA: 0x0002D900 File Offset: 0x0002BB00
	public override void SetEffFollow(int id)
	{
		this.idfollow = id;
	}

	// Token: 0x04000463 RID: 1123
	public int power;

	// Token: 0x04000464 RID: 1124
	public int type;

	// Token: 0x04000465 RID: 1125
	public short effect;

	// Token: 0x04000466 RID: 1126
	public int hpLost;

	// Token: 0x04000467 RID: 1127
	public int frame;

	// Token: 0x04000468 RID: 1128
	public int idfollow;

	// Token: 0x04000469 RID: 1129
	public int idend;

	// Token: 0x0400046A RID: 1130
	public int w;

	// Token: 0x0400046B RID: 1131
	public int h;

	// Token: 0x0400046C RID: 1132
	public int x;

	// Token: 0x0400046D RID: 1133
	public int y;

	// Token: 0x0400046E RID: 1134
	public int Efftail;

	// Token: 0x0400046F RID: 1135
	public int Effend;

	// Token: 0x04000470 RID: 1136
	private MainObject owner;

	// Token: 0x04000471 RID: 1137
	private MainObject target;

	// Token: 0x04000472 RID: 1138
	public MagicLogic arrow = new MagicLogic();

	// Token: 0x04000473 RID: 1139
	private sbyte fra;

	// Token: 0x04000474 RID: 1140
	private FrameImage img;
}
