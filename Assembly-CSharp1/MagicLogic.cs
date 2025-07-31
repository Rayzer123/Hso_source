using System;

// Token: 0x020000BC RID: 188
public class MagicLogic
{
	// Token: 0x06000958 RID: 2392 RVA: 0x00097648 File Offset: 0x00095848
	public void setAngle(int angle)
	{
		this.angle = angle;
		this.vx = (int)this.va * CRes.cos(angle) >> 10;
		this.vy = (int)this.va * CRes.sin(angle) >> 10;
	}

	// Token: 0x06000959 RID: 2393 RVA: 0x00097680 File Offset: 0x00095880
	public void set(int type, int x, int y, int dir, MainObject target)
	{
		this.x = x;
		this.y = y;
		this.target = target;
		switch (dir)
		{
		case 0:
			this.angle = 90;
			break;
		case 1:
			this.angle = 270;
			break;
		case 2:
			this.angle = 180;
			break;
		case 3:
			this.angle = 0;
			break;
		}
		if (type == 20)
		{
			type = 2;
		}
		this.va = 15360;
		this.z = 0;
		this.life = 0;
		this.vx = (int)this.va * CRes.cos(this.angle) >> 10;
		this.vy = (int)this.va * CRes.sin(this.angle) >> 10;
	}

	// Token: 0x0600095A RID: 2394 RVA: 0x00097754 File Offset: 0x00095954
	public void updateAngle()
	{
		if (this.target == null)
		{
			this.isEnd = true;
			return;
		}
		int num = this.target.x - this.x;
		int num2 = this.target.y - (this.target.hOne >> 1) - this.y;
		this.life++;
		if ((CRes.abs(num) < 16 && CRes.abs(num2) < 16) || this.life > 60)
		{
			this.isEnd = true;
			return;
		}
		int num3 = CRes.angle(num, num2);
		if (global::Math.abs(num3 - this.angle) < 90 || num * num + num2 * num2 > 4096)
		{
			if (global::Math.abs(num3 - this.angle) < 15)
			{
				this.angle = num3;
			}
			else if ((num3 - this.angle >= 0 && num3 - this.angle < 180) || num3 - this.angle < -180)
			{
				this.angle = CRes.fixangle(this.angle + 15);
			}
			else
			{
				this.angle = CRes.fixangle(this.angle - 15);
			}
		}
		if (!this.isSpeedUp && this.va < 8192)
		{
			this.va += 1024;
		}
		this.vx = (int)this.va * CRes.cos(this.angle) >> 10;
		this.vy = (int)this.va * CRes.sin(this.angle) >> 10;
		num += this.vx;
		int num4 = num >> 10;
		this.x += num4;
		num &= 1023;
		num2 += this.vy;
		int num5 = num2 >> 10;
		this.y += num5;
		num2 &= 1023;
		this.index = Arrow.findDirIndexFromAngle(CRes.angle(num4, -num5));
		this.headArrowFrame = (int)Arrow.FRAME[this.index];
		this.headTransform = Arrow.TRANSFORM[this.index];
	}

	// Token: 0x04000E3C RID: 3644
	public int angle;

	// Token: 0x04000E3D RID: 3645
	public int vx;

	// Token: 0x04000E3E RID: 3646
	public int vy;

	// Token: 0x04000E3F RID: 3647
	public short va;

	// Token: 0x04000E40 RID: 3648
	public int x;

	// Token: 0x04000E41 RID: 3649
	public int y;

	// Token: 0x04000E42 RID: 3650
	public int z;

	// Token: 0x04000E43 RID: 3651
	public int index;

	// Token: 0x04000E44 RID: 3652
	public MainObject target;

	// Token: 0x04000E45 RID: 3653
	private int life;

	// Token: 0x04000E46 RID: 3654
	public bool isSpeedUp;

	// Token: 0x04000E47 RID: 3655
	public int headArrowFrame;

	// Token: 0x04000E48 RID: 3656
	public int headTransform;

	// Token: 0x04000E49 RID: 3657
	public static short[] SPEED = new short[]
	{
		1,
		60,
		8,
		1,
		1,
		16,
		60,
		18
	};

	// Token: 0x04000E4A RID: 3658
	public bool isEnd;
}
