using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using UnityEngine;

// Token: 0x02000024 RID: 36
public class Session_ME : ISession
{
	// Token: 0x06000183 RID: 387 RVA: 0x00009308 File Offset: 0x00007508
	public Session_ME()
	{
		Debug.Log("init Session_ME");
	}

	// Token: 0x06000185 RID: 389 RVA: 0x00009358 File Offset: 0x00007558
	public void clearSendingMessage()
	{
		Session_ME.sender.sendingMessage.Clear();
	}

	// Token: 0x06000186 RID: 390 RVA: 0x0000936C File Offset: 0x0000756C
	public static Session_ME gI()
	{
		return Session_ME.instance;
	}

	// Token: 0x06000187 RID: 391 RVA: 0x00009374 File Offset: 0x00007574
	public bool isConnected()
	{
		return Session_ME.connected;
	}

	// Token: 0x06000188 RID: 392 RVA: 0x0000937C File Offset: 0x0000757C
	public void setHandler(IMessageHandler msgHandler)
	{
		Session_ME.messageHandler = msgHandler;
	}

	// Token: 0x06000189 RID: 393 RVA: 0x00009384 File Offset: 0x00007584
	public void connect(string host, int port)
	{
		Debug.LogError(string.Concat(new object[]
		{
			"connect ...!",
			Session_ME.connected,
			"  ::  ",
			Session_ME.connecting
		}));
		if (Session_ME.connected || Session_ME.connecting)
		{
			return;
		}
		this.host = host;
		this.port = port;
		Session_ME.getKeyComplete = false;
		Session_ME.sc = null;
		Session_ME.initThread = new Thread(new ThreadStart(this.NetworkInit));
		Session_ME.initThread.Start();
	}

	// Token: 0x0600018A RID: 394 RVA: 0x0000941C File Offset: 0x0000761C
	private void NetworkInit()
	{
		Session_ME.isCancel = false;
		Session_ME.connecting = true;
		Thread.CurrentThread.Priority = System.Threading.ThreadPriority.Highest;
		Session_ME.connected = true;
		try
		{
			this.doConnect(this.host, this.port);
			Session_ME.messageHandler.onConnectOK();
		}
		catch (Exception)
		{
			if (Session_ME.messageHandler != null)
			{
				this.close();
				Session_ME.messageHandler.onConnectionFail();
			}
		}
	}

	// Token: 0x0600018B RID: 395 RVA: 0x000094A4 File Offset: 0x000076A4
	public void doConnect(string host, int port)
	{
		this.timeOut = (int)(mSystem.currentTimeMillis() / 1000L);
		Session_ME.sc = new TcpClient();
		Session_ME.sc.Connect(host, port);
		Session_ME.sc.ReceiveBufferSize = 128000;
		Session_ME.dataStream = Session_ME.sc.GetStream();
		Session_ME.dis = new BinaryReader(Session_ME.dataStream, new UTF8Encoding());
		Session_ME.dos = new BinaryWriter(Session_ME.dataStream, new UTF8Encoding());
		new Thread(new ThreadStart(Session_ME.sender.run)).Start();
		Session_ME.MessageCollector @object = new Session_ME.MessageCollector();
		Session_ME.collectorThread = new Thread(new ThreadStart(@object.run));
		Session_ME.collectorThread.Start();
		Session_ME.timeConnected = Session_ME.currentTimeMillis();
		Session_ME.connecting = false;
		Session_ME.doSendMessage(new Message(-40));
		this.timeOut = 0;
	}

	// Token: 0x0600018C RID: 396 RVA: 0x00009584 File Offset: 0x00007784
	public void sendMessage(Message message)
	{
		Session_ME.sender.AddMessage(message);
	}

	// Token: 0x0600018D RID: 397 RVA: 0x00009594 File Offset: 0x00007794
	private static void doSendMessage(Message m)
	{
		sbyte[] data = m.getData();
		try
		{
			if (Session_ME.getKeyComplete)
			{
				sbyte value = Session_ME.writeKey(m.command);
				Session_ME.dos.Write(value);
			}
			else
			{
				Session_ME.dos.Write(m.command);
			}
			if (data != null)
			{
				int num = data.Length;
				if (Session_ME.getKeyComplete)
				{
					int num2 = (int)Session_ME.writeKey((sbyte)(num >> 8));
					Session_ME.dos.Write((sbyte)num2);
					int num3 = (int)Session_ME.writeKey((sbyte)(num & 255));
					Session_ME.dos.Write((sbyte)num3);
				}
				else
				{
					Session_ME.dos.Write((ushort)num);
				}
				if (Session_ME.getKeyComplete)
				{
					for (int i = 0; i < data.Length; i++)
					{
						sbyte value2 = Session_ME.writeKey(data[i]);
						Session_ME.dos.Write(value2);
					}
				}
				Session_ME.sendByteCount += 5 + data.Length;
			}
			else
			{
				if (Session_ME.getKeyComplete)
				{
					int num4 = 0;
					int num5 = (int)Session_ME.writeKey((sbyte)(num4 >> 8));
					Session_ME.dos.Write((sbyte)num5);
					int num6 = (int)Session_ME.writeKey((sbyte)(num4 & 255));
					Session_ME.dos.Write((sbyte)num6);
				}
				else
				{
					Session_ME.dos.Write(0);
				}
				Session_ME.sendByteCount += 5;
			}
			Session_ME.dos.Flush();
		}
		catch (Exception ex)
		{
			Debug.Log(ex.StackTrace);
		}
	}

	// Token: 0x0600018E RID: 398 RVA: 0x00009724 File Offset: 0x00007924
	public static sbyte readKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curR;
		Session_ME.curR = b2 + 1;
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME.curR >= Session_ME.key.Length)
		{
			Session_ME.curR = (sbyte)((int)Session_ME.curR % (int)((sbyte)Session_ME.key.Length));
		}
		return result;
	}

	// Token: 0x0600018F RID: 399 RVA: 0x00009784 File Offset: 0x00007984
	public static sbyte writeKey(sbyte b)
	{
		sbyte[] array = Session_ME.key;
		sbyte b2 = Session_ME.curW;
		Session_ME.curW = b2 + 1;
		sbyte result = (sbyte)((array[(int)b2] & 255) ^ ((int)b & 255));
		if ((int)Session_ME.curW >= Session_ME.key.Length)
		{
			Session_ME.curW = (sbyte)((int)Session_ME.curW % (int)((sbyte)Session_ME.key.Length));
		}
		return result;
	}

	// Token: 0x06000190 RID: 400 RVA: 0x000097E4 File Offset: 0x000079E4
	public static void onRecieveMsg(Message msg)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			Session_ME.messageHandler.onMessage(msg);
		}
		else
		{
			Session_ME.recieveMsg.addElement(msg);
		}
	}

	// Token: 0x06000191 RID: 401 RVA: 0x00009828 File Offset: 0x00007A28
	public static void update()
	{
		if (Session_ME.gI().timeOut != 0 && mSystem.currentTimeMillis() / 1000L - (long)Session_ME.gI().timeOut > 10L)
		{
			GlobalLogicHandler.isDisconnect = true;
			Session_ME.gI().timeOut = 0;
			if (Session_ME.sc != null)
			{
				Session_ME.cleanNetwork();
			}
			return;
		}
		while (Session_ME.recieveMsg.size() > 0)
		{
			Message message = (Message)Session_ME.recieveMsg.elementAt(0);
			if (message == null)
			{
				Session_ME.recieveMsg.removeElementAt(0);
				return;
			}
			Session_ME.messageHandler.onMessage(message);
			Session_ME.recieveMsg.removeElementAt(0);
		}
	}

	// Token: 0x06000192 RID: 402 RVA: 0x000098D4 File Offset: 0x00007AD4
	public void close()
	{
		Session_ME.recieveMsg.removeAllElements();
		Session_ME.cleanNetwork();
	}

	// Token: 0x06000193 RID: 403 RVA: 0x000098E8 File Offset: 0x00007AE8
	private static void cleanNetwork()
	{
		Session_ME.key = null;
		Session_ME.curR = 0;
		Session_ME.curW = 0;
		try
		{
			Session_ME.connected = false;
			Session_ME.connecting = false;
			if (Session_ME.sc != null)
			{
				Session_ME.sc.Close();
				Session_ME.sc = null;
			}
			if (Session_ME.dataStream != null)
			{
				Session_ME.dataStream.Close();
				Session_ME.dataStream = null;
			}
			if (Session_ME.dos != null)
			{
				Session_ME.dos.Close();
				Session_ME.dos = null;
			}
			if (Session_ME.dis != null)
			{
				Session_ME.dis.Close();
				Session_ME.dis = null;
			}
			Session_ME.sendThread = null;
			Session_ME.collectorThread = null;
		}
		catch (Exception)
		{
		}
	}

	// Token: 0x06000194 RID: 404 RVA: 0x000099B0 File Offset: 0x00007BB0
	public static int currentTimeMillis()
	{
		return Environment.TickCount;
	}

	// Token: 0x06000195 RID: 405 RVA: 0x000099B8 File Offset: 0x00007BB8
	public static byte convertSbyteToByte(sbyte var)
	{
		if ((int)var > 0)
		{
			return (byte)var;
		}
		return (byte)((int)var + 256);
	}

	// Token: 0x06000196 RID: 406 RVA: 0x000099D0 File Offset: 0x00007BD0
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x0400017B RID: 379
	protected static Session_ME instance = new Session_ME();

	// Token: 0x0400017C RID: 380
	private static NetworkStream dataStream;

	// Token: 0x0400017D RID: 381
	private static BinaryReader dis;

	// Token: 0x0400017E RID: 382
	private static BinaryWriter dos;

	// Token: 0x0400017F RID: 383
	public static IMessageHandler messageHandler;

	// Token: 0x04000180 RID: 384
	private static TcpClient sc;

	// Token: 0x04000181 RID: 385
	public static bool connected;

	// Token: 0x04000182 RID: 386
	public static bool connecting;

	// Token: 0x04000183 RID: 387
	private static Session_ME.Sender sender = new Session_ME.Sender();

	// Token: 0x04000184 RID: 388
	public static Thread initThread;

	// Token: 0x04000185 RID: 389
	public static Thread collectorThread;

	// Token: 0x04000186 RID: 390
	public static Thread sendThread;

	// Token: 0x04000187 RID: 391
	public static int sendByteCount;

	// Token: 0x04000188 RID: 392
	public static int recvByteCount;

	// Token: 0x04000189 RID: 393
	private static bool getKeyComplete;

	// Token: 0x0400018A RID: 394
	public static sbyte[] key = null;

	// Token: 0x0400018B RID: 395
	private static sbyte curR;

	// Token: 0x0400018C RID: 396
	private static sbyte curW;

	// Token: 0x0400018D RID: 397
	private static int timeConnected;

	// Token: 0x0400018E RID: 398
	public static string strRecvByteCount = string.Empty;

	// Token: 0x0400018F RID: 399
	public static bool isCancel;

	// Token: 0x04000190 RID: 400
	private string host;

	// Token: 0x04000191 RID: 401
	private int port;

	// Token: 0x04000192 RID: 402
	public int timeOut;

	// Token: 0x04000193 RID: 403
	public static mVector recieveMsg = new mVector();

	// Token: 0x02000025 RID: 37
	public class Sender
	{
		// Token: 0x06000197 RID: 407 RVA: 0x00009A20 File Offset: 0x00007C20
		public Sender()
		{
			this.sendingMessage = new List<Message>();
		}

		// Token: 0x06000198 RID: 408 RVA: 0x00009A34 File Offset: 0x00007C34
		public void AddMessage(Message message)
		{
			this.sendingMessage.Add(message);
		}

		// Token: 0x06000199 RID: 409 RVA: 0x00009A44 File Offset: 0x00007C44
		public void run()
		{
			while (Session_ME.connected)
			{
				Message message = new Message();
				try
				{
					if (Session_ME.getKeyComplete)
					{
						while (this.sendingMessage.Count > 0)
						{
							Message m = this.sendingMessage[0];
							Session_ME.doSendMessage(m);
							this.sendingMessage.RemoveAt(0);
						}
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception ex)
					{
						Cout.LogError(ex.ToString());
					}
				}
				catch (Exception ex2)
				{
					Debug.Log("error send message! " + ex2.ToString());
				}
			}
		}

		// Token: 0x04000194 RID: 404
		public List<Message> sendingMessage;
	}

	// Token: 0x02000026 RID: 38
	private class MessageCollector
	{
		// Token: 0x0600019B RID: 411 RVA: 0x00009B20 File Offset: 0x00007D20
		public void run()
		{
			try
			{
				while (Session_ME.connected)
				{
					Message message = this.readMessage();
					if (message == null)
					{
						break;
					}
					try
					{
						if ((int)message.command == -40)
						{
							this.getKey(message);
						}
						else
						{
							Session_ME.onRecieveMsg(message);
						}
					}
					catch (Exception)
					{
						Cout.LogError2("LOI NHAN  MESS THU 1");
					}
					try
					{
						Thread.Sleep(5);
					}
					catch (Exception)
					{
						Cout.println("LOI NHAN  MESS THU 2");
					}
				}
			}
			catch (Exception ex)
			{
				Debug.Log("error read message!");
				Debug.Log(ex.Message.ToString());
			}
			if (Session_ME.connected)
			{
				Debug.Log("error read message!");
				if (Session_ME.messageHandler != null)
				{
					if (Session_ME.currentTimeMillis() - Session_ME.timeConnected > 500)
					{
						Session_ME.messageHandler.onDisconnected();
					}
					else
					{
						Session_ME.messageHandler.onConnectionFail();
					}
				}
				if (Session_ME.sc != null)
				{
					Session_ME.cleanNetwork();
				}
			}
		}

		// Token: 0x0600019C RID: 412 RVA: 0x00009C70 File Offset: 0x00007E70
		private void getKey(Message message)
		{
			try
			{
				sbyte b = message.reader().readSByte();
				Session_ME.key = new sbyte[(int)b];
				for (int i = 0; i < (int)b; i++)
				{
					Session_ME.key[i] = message.reader().readSByte();
				}
				for (int j = 0; j < Session_ME.key.Length - 1; j++)
				{
					sbyte[] key = Session_ME.key;
					int num = j + 1;
					key[num] = (sbyte)((int)key[num] ^ (int)Session_ME.key[j]);
				}
				Session_ME.getKeyComplete = true;
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x0600019D RID: 413 RVA: 0x00009D1C File Offset: 0x00007F1C
		private Message readMessage()
		{
			try
			{
				sbyte b = Session_ME.dis.ReadSByte();
				if (Session_ME.getKeyComplete)
				{
					b = Session_ME.readKey(b);
				}
				int num;
				if (Session_ME.getKeyComplete)
				{
					if ((int)b == -51 || (int)b == -52 || (int)b == -54 || (int)b == 126)
					{
						if ((int)b == 126)
						{
							b = Session_ME.dis.ReadSByte();
							b = Session_ME.readKey(b);
						}
						sbyte[] array = new sbyte[]
						{
							Session_ME.dis.ReadSByte(),
							Session_ME.dis.ReadSByte(),
							Session_ME.dis.ReadSByte(),
							Session_ME.dis.ReadSByte()
						};
						num = (((int)Session_ME.readKey(array[3]) & 255) | ((int)Session_ME.readKey(array[2]) & 255) << 8 | ((int)Session_ME.readKey(array[1]) & 255) << 16 | ((int)Session_ME.readKey(array[0]) & 255) << 24);
					}
					else
					{
						sbyte b2 = Session_ME.dis.ReadSByte();
						sbyte b3 = Session_ME.dis.ReadSByte();
						num = (((int)Session_ME.readKey(b2) & 255) << 8 | ((int)Session_ME.readKey(b3) & 255));
					}
				}
				else
				{
					sbyte b4 = Session_ME.dis.ReadSByte();
					sbyte b5 = Session_ME.dis.ReadSByte();
					num = (((int)b4 & 65280) | ((int)b5 & 255));
				}
				sbyte[] array2 = new sbyte[num];
				byte[] src = Session_ME.dis.ReadBytes(num);
				Buffer.BlockCopy(src, 0, array2, 0, num);
				Session_ME.recvByteCount += 5 + num;
				int num2 = Session_ME.recvByteCount + Session_ME.sendByteCount;
				Session_ME.strRecvByteCount = string.Concat(new object[]
				{
					num2 / 1024,
					".",
					num2 % 1024 / 102,
					"Kb"
				});
				if (Session_ME.getKeyComplete)
				{
					for (int i = 0; i < array2.Length; i++)
					{
						array2[i] = Session_ME.readKey(array2[i]);
					}
				}
				return new Message(b, array2);
			}
			catch (Exception ex)
			{
				Debug.Log(ex.StackTrace.ToString());
			}
			return null;
		}
	}
}
