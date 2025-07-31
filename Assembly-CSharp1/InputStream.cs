using System;

// Token: 0x0200000C RID: 12
public class InputStream : myReader
{
	// Token: 0x0600007F RID: 127 RVA: 0x000039A8 File Offset: 0x00001BA8
	public InputStream()
	{
	}

	// Token: 0x06000080 RID: 128 RVA: 0x000039B0 File Offset: 0x00001BB0
	public InputStream(sbyte[] data)
	{
		this.buffer = data;
	}

	// Token: 0x06000081 RID: 129 RVA: 0x000039C0 File Offset: 0x00001BC0
	public InputStream(string filename) : base(filename)
	{
	}
}
