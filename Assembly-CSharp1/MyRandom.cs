using System;

// Token: 0x02000010 RID: 16
public class MyRandom
{
	// Token: 0x0600008E RID: 142 RVA: 0x00003FC4 File Offset: 0x000021C4
	public MyRandom()
	{
		this.r = new Random();
	}

	// Token: 0x0600008F RID: 143 RVA: 0x00003FD8 File Offset: 0x000021D8
	public int nextInt()
	{
		return this.r.Next();
	}

	// Token: 0x06000090 RID: 144 RVA: 0x00003FE8 File Offset: 0x000021E8
	public int nextInt(int a)
	{
		return this.r.Next(a);
	}

	// Token: 0x06000091 RID: 145 RVA: 0x00003FF8 File Offset: 0x000021F8
	public int nextInt(int a, int b)
	{
		return this.r.Next(a, b);
	}

	// Token: 0x0400004F RID: 79
	public Random r;
}
