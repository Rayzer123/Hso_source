using System;

// Token: 0x020000CA RID: 202
public class mVector2
{
	// Token: 0x06000995 RID: 2453 RVA: 0x000A330C File Offset: 0x000A150C
	public mVector2()
	{
		this.x = 0f;
		this.y = 0f;
	}

	// Token: 0x06000996 RID: 2454 RVA: 0x000A332C File Offset: 0x000A152C
	public mVector2(float x, float y)
	{
		this.x = x;
		this.y = y;
	}

	// Token: 0x06000997 RID: 2455 RVA: 0x000A3344 File Offset: 0x000A1544
	public void set(mVector2 v)
	{
		this.x = v.x;
		this.y = v.y;
	}

	// Token: 0x06000998 RID: 2456 RVA: 0x000A3360 File Offset: 0x000A1560
	public mVector2 substract(mVector2 v)
	{
		this.x -= v.x;
		this.y -= v.y;
		return this;
	}

	// Token: 0x06000999 RID: 2457 RVA: 0x000A338C File Offset: 0x000A158C
	public mVector2 add(mVector2 v)
	{
		this.x += v.x;
		this.y += v.y;
		return this;
	}

	// Token: 0x0600099A RID: 2458 RVA: 0x000A33B8 File Offset: 0x000A15B8
	public mVector2 add(float x, float y)
	{
		this.x += x;
		this.y += y;
		return this;
	}

	// Token: 0x0600099B RID: 2459 RVA: 0x000A33D8 File Offset: 0x000A15D8
	public mVector2 mul(mVector2 v)
	{
		this.x += v.x;
		this.y += v.y;
		return this;
	}

	// Token: 0x0600099C RID: 2460 RVA: 0x000A3404 File Offset: 0x000A1604
	public float length()
	{
		return CRes.sqrt(this.x * this.x + this.y * this.y);
	}

	// Token: 0x0600099D RID: 2461 RVA: 0x000A3434 File Offset: 0x000A1634
	public mVector2 normalize()
	{
		float num = this.length();
		if (num != 0f)
		{
			this.x /= num;
			this.y /= num;
		}
		return this;
	}

	// Token: 0x0600099E RID: 2462 RVA: 0x000A3478 File Offset: 0x000A1678
	public static float distance(mVector2 src, mVector2 dest)
	{
		float num = dest.x - src.x;
		float num2 = dest.y - src.y;
		return CRes.sqrt(num * num + num2 * num2);
	}

	// Token: 0x0600099F RID: 2463 RVA: 0x000A34B0 File Offset: 0x000A16B0
	public static mVector2 substract(mVector2 src, mVector2 dest)
	{
		float num = dest.x - src.x;
		float num2 = dest.y - src.y;
		return new mVector2(num, num2);
	}

	// Token: 0x040010C6 RID: 4294
	public float x;

	// Token: 0x040010C7 RID: 4295
	public float y;
}
