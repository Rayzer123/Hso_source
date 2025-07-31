using System;
using System.IO;
using System.Net.Sockets;

// Token: 0x0200002A RID: 42
public class mSocket
{
	// Token: 0x0600020A RID: 522 RVA: 0x0000C8FC File Offset: 0x0000AAFC
	public mSocket(string host, int port)
	{
		try
		{
			this.s = new TcpClient();
			this.s.Connect(host, port);
		}
		catch (IOException ex)
		{
		}
	}

	// Token: 0x0600020B RID: 523 RVA: 0x0000C950 File Offset: 0x0000AB50
	public void close()
	{
		try
		{
			this.s.Close();
		}
		catch (IOException ex)
		{
		}
	}

	// Token: 0x0600020C RID: 524 RVA: 0x0000C990 File Offset: 0x0000AB90
	public void setKeepAlive(bool isAlive)
	{
	}

	// Token: 0x0600020D RID: 525 RVA: 0x0000C994 File Offset: 0x0000AB94
	public NetworkStream getOutputStream()
	{
		try
		{
			return this.s.GetStream();
		}
		catch (IOException ex)
		{
		}
		return null;
	}

	// Token: 0x0600020E RID: 526 RVA: 0x0000C9DC File Offset: 0x0000ABDC
	public NetworkStream getInputStream()
	{
		try
		{
			return this.s.GetStream();
		}
		catch (IOException ex)
		{
		}
		return null;
	}

	// Token: 0x040001CD RID: 461
	private TcpClient s;
}
