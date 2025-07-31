using System;

// Token: 0x02000048 RID: 72
public class IArrow
{
	// Token: 0x0600032E RID: 814 RVA: 0x0002B55C File Offset: 0x0002975C
	public virtual void set(int type, int x, int y, int power, short effect, MainObject owner, MainObject target)
	{
	}

	// Token: 0x0600032F RID: 815 RVA: 0x0002B560 File Offset: 0x00029760
	public virtual void setAngle(int angle)
	{
	}

	// Token: 0x06000330 RID: 816 RVA: 0x0002B564 File Offset: 0x00029764
	public virtual void update()
	{
	}

	// Token: 0x06000331 RID: 817 RVA: 0x0002B568 File Offset: 0x00029768
	public virtual void paint(mGraphics g)
	{
	}

	// Token: 0x06000332 RID: 818 RVA: 0x0002B56C File Offset: 0x0002976C
	public virtual void SetEffFollow(int id)
	{
	}

	// Token: 0x06000333 RID: 819 RVA: 0x0002B570 File Offset: 0x00029770
	public virtual void onArrowTouchTarget()
	{
	}

	// Token: 0x0400040E RID: 1038
	public bool wantDestroy;
}
