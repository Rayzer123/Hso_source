using System;

// Token: 0x020000DA RID: 218
public interface ISession
{
	// Token: 0x06000A17 RID: 2583
	bool isConnected();

	// Token: 0x06000A18 RID: 2584
	void setHandler(IMessageHandler messageHandler);

	// Token: 0x06000A19 RID: 2585
	void connect(string host, int port);

	// Token: 0x06000A1A RID: 2586
	void sendMessage(Message message);

	// Token: 0x06000A1B RID: 2587
	void close();
}
