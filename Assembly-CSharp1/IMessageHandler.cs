using System;

// Token: 0x020000D9 RID: 217
public interface IMessageHandler
{
	// Token: 0x06000A13 RID: 2579
	void onMessage(Message message);

	// Token: 0x06000A14 RID: 2580
	void onConnectionFail();

	// Token: 0x06000A15 RID: 2581
	void onDisconnected();

	// Token: 0x06000A16 RID: 2582
	void onConnectOK();
}
