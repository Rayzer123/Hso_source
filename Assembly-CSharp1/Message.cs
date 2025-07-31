using System;

// Token: 0x02000023 RID: 35
public class Message
{
	// Token: 0x0600017B RID: 379 RVA: 0x0000927C File Offset: 0x0000747C
	public Message(int command)
	{
		this.command = (sbyte)command;
		this.dos = new myWriter();
	}

	// Token: 0x0600017C RID: 380 RVA: 0x00009298 File Offset: 0x00007498
	public Message()
	{
		this.dos = new myWriter();
	}

	// Token: 0x0600017D RID: 381 RVA: 0x000092AC File Offset: 0x000074AC
	public Message(sbyte command)
	{
		this.command = command;
		this.dos = new myWriter();
	}

	// Token: 0x0600017E RID: 382 RVA: 0x000092C8 File Offset: 0x000074C8
	public Message(sbyte command, sbyte[] data)
	{
		this.command = command;
		this.dis = new myReader(data);
	}

	// Token: 0x0600017F RID: 383 RVA: 0x000092E4 File Offset: 0x000074E4
	public sbyte[] getData()
	{
		return this.dos.getData();
	}

	// Token: 0x06000180 RID: 384 RVA: 0x000092F4 File Offset: 0x000074F4
	public myReader reader()
	{
		return this.dis;
	}

	// Token: 0x06000181 RID: 385 RVA: 0x000092FC File Offset: 0x000074FC
	public myWriter writer()
	{
		return this.dos;
	}

	// Token: 0x06000182 RID: 386 RVA: 0x00009304 File Offset: 0x00007504
	public void cleanup()
	{
	}

	// Token: 0x04000178 RID: 376
	public sbyte command;

	// Token: 0x04000179 RID: 377
	private myReader dis;

	// Token: 0x0400017A RID: 378
	private myWriter dos;
}
