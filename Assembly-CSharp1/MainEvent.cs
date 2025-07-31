using System;

// Token: 0x02000050 RID: 80
public class MainEvent : AvMain
{
	// Token: 0x0600036F RID: 879 RVA: 0x0002E33C File Offset: 0x0002C53C
	public MainEvent(int Obj, int Cmd, string name, string content)
	{
		this.IDObj = Obj;
		this.IDCmd = Cmd;
		this.nameEvent = name;
		this.contentEvent = content;
	}

	// Token: 0x06000370 RID: 880 RVA: 0x0002E364 File Offset: 0x0002C564
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 1:
			GlobalService.gI().Friend((sbyte)subIndex, this.nameEvent);
			this.isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 2:
			if (subIndex == 1)
			{
				GlobalService.gI().Party(2, this.nameEvent);
			}
			this.isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 3:
			if (subIndex == 1)
			{
				GlobalService.gI().Buy_Sell(1, this.nameEvent, 0, 0, 0);
			}
			this.isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 4:
			if (subIndex == 1)
			{
				GlobalService.gI().Thach_Dau(1, this.nameEvent);
			}
			else if (subIndex == 2)
			{
				GlobalService.gI().Re_Info_Other_Object(this.nameEvent, 1);
			}
			this.isRemove = true;
			GameCanvas.end_Dialog();
			break;
		case 5:
			if (subIndex == 1)
			{
				GlobalService.gI().Add_And_AnS_MemClan(11, this.nameEvent);
			}
			this.isRemove = true;
			GameCanvas.end_Dialog();
			break;
		}
	}

	// Token: 0x040004CB RID: 1227
	public const sbyte CHAT = 0;

	// Token: 0x040004CC RID: 1228
	public const sbyte KET_BAN = 1;

	// Token: 0x040004CD RID: 1229
	public const sbyte PARTY = 2;

	// Token: 0x040004CE RID: 1230
	public const sbyte BUY_SELL = 3;

	// Token: 0x040004CF RID: 1231
	public const sbyte THACH_DAU = 4;

	// Token: 0x040004D0 RID: 1232
	public const sbyte MOI_VAO_CLAN = 5;

	// Token: 0x040004D1 RID: 1233
	public int IDObj;

	// Token: 0x040004D2 RID: 1234
	public int IDCmd;

	// Token: 0x040004D3 RID: 1235
	public int isNew;

	// Token: 0x040004D4 RID: 1236
	public int numThachDau;

	// Token: 0x040004D5 RID: 1237
	public string nameEvent;

	// Token: 0x040004D6 RID: 1238
	public string contentEvent;

	// Token: 0x040004D7 RID: 1239
	public bool isRemove;
}
