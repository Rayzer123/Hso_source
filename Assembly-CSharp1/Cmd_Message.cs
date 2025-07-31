using System;

// Token: 0x020000DF RID: 223
public class Cmd_Message
{
	// Token: 0x06000AEA RID: 2794 RVA: 0x000BDAF4 File Offset: 0x000BBCF4
	protected void writeInt(int in0)
	{
		try
		{
			this.m.writer().writeInt(in0);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x06000AEB RID: 2795 RVA: 0x000BDB50 File Offset: 0x000BBD50
	protected void writeByte(int by)
	{
		try
		{
			this.m.writer().writeByte(by);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x06000AEC RID: 2796 RVA: 0x000BDBAC File Offset: 0x000BBDAC
	protected void writeShort(int by)
	{
		try
		{
			this.m.writer().writeShort(by);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x06000AED RID: 2797 RVA: 0x000BDC08 File Offset: 0x000BBE08
	public void writeUTF(string str)
	{
		try
		{
			this.m.writer().writeUTF(str);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x06000AEE RID: 2798 RVA: 0x000BDC64 File Offset: 0x000BBE64
	protected void writeBoolean(bool boo)
	{
		try
		{
			this.m.writer().writeBoolean(boo);
		}
		catch (Exception ex)
		{
			Cout.Log(" Loi Tai !!! : " + ex.ToString());
		}
	}

	// Token: 0x06000AEF RID: 2799 RVA: 0x000BDCC0 File Offset: 0x000BBEC0
	public void setSession(ISession gi)
	{
		this.session = null;
		this.session = gi;
	}

	// Token: 0x06000AF0 RID: 2800 RVA: 0x000BDCD0 File Offset: 0x000BBED0
	public void send()
	{
		this.session.sendMessage(this.m);
		this.m.cleanup();
	}

	// Token: 0x06000AF1 RID: 2801 RVA: 0x000BDCF0 File Offset: 0x000BBEF0
	public void init(sbyte cmd)
	{
		this.m = new Message(cmd);
	}

	// Token: 0x04001203 RID: 4611
	public const sbyte MINI_GAME = -91;

	// Token: 0x04001204 RID: 4612
	public const sbyte NOKIA_PURCHASE_MESSAGE = -76;

	// Token: 0x04001205 RID: 4613
	public const sbyte GOOGLE_PURCHASE_MESSAGE = -75;

	// Token: 0x04001206 RID: 4614
	public const sbyte UPDATE_DATA = -57;

	// Token: 0x04001207 RID: 4615
	public const sbyte NAP_DIAMOND = -56;

	// Token: 0x04001208 RID: 4616
	public const sbyte CHECK_UPDATE_DATA = -54;

	// Token: 0x04001209 RID: 4617
	public const sbyte NAP_TIEN = -53;

	// Token: 0x0400120A RID: 4618
	public const sbyte LOAD_IMAGE_DATA_PART_CHAR = -52;

	// Token: 0x0400120B RID: 4619
	public const sbyte LOAD_IMAGE = -51;

	// Token: 0x0400120C RID: 4620
	public const sbyte NPC_BIG = -50;

	// Token: 0x0400120D RID: 4621
	public const sbyte LOAD_IMAGE_DATA_AUTO_EFF = -49;

	// Token: 0x0400120E RID: 4622
	public const sbyte NEW_NPC_INFO = -44;

	// Token: 0x0400120F RID: 4623
	public const sbyte DIALOG_MORE_OPTION_SERVER = -31;

	// Token: 0x04001210 RID: 4624
	public const sbyte DIALOG_SERVER = -32;

	// Token: 0x04001211 RID: 4625
	public const sbyte DYNAMIC_MENU = -30;

	// Token: 0x04001212 RID: 4626
	public const sbyte MONSTER_CAPCHAR = -28;

	// Token: 0x04001213 RID: 4627
	public const sbyte LOGIN = 1;

	// Token: 0x04001214 RID: 4628
	public const sbyte LOGIN_FAIL = 2;

	// Token: 0x04001215 RID: 4629
	public const sbyte MAIN_CHAR_INFO = 3;

	// Token: 0x04001216 RID: 4630
	public const sbyte OBJECT_MOVE = 4;

	// Token: 0x04001217 RID: 4631
	public const sbyte CHAR_INFO = 5;

	// Token: 0x04001218 RID: 4632
	public const sbyte FIRE_PK = 6;

	// Token: 0x04001219 RID: 4633
	public const sbyte MONSTER_INFO = 7;

	// Token: 0x0400121A RID: 4634
	public const sbyte PLAYER_EXIT = 8;

	// Token: 0x0400121B RID: 4635
	public const sbyte FIRE_MONSTER = 9;

	// Token: 0x0400121C RID: 4636
	public const sbyte MONSTER_FIRE = 10;

	// Token: 0x0400121D RID: 4637
	public const sbyte USE_ITEM = 11;

	// Token: 0x0400121E RID: 4638
	public const sbyte CHANGE_MAP = 12;

	// Token: 0x0400121F RID: 4639
	public const sbyte LIST_CHAR = 13;

	// Token: 0x04001220 RID: 4640
	public const sbyte SELECT_CHAR = 13;

	// Token: 0x04001221 RID: 4641
	public const sbyte CREATE_CHAR = 14;

	// Token: 0x04001222 RID: 4642
	public const sbyte CHAR_WEARING = 15;

	// Token: 0x04001223 RID: 4643
	public const sbyte CHAR_INVENTORY = 16;

	// Token: 0x04001224 RID: 4644
	public const sbyte DIE_MONSTER = 17;

	// Token: 0x04001225 RID: 4645
	public const sbyte DEL_ITEM = 18;

	// Token: 0x04001226 RID: 4646
	public const sbyte ITEM_DROP = 19;

	// Token: 0x04001227 RID: 4647
	public const sbyte GET_ITEM_MAP = 20;

	// Token: 0x04001228 RID: 4648
	public const sbyte ITEM_MORE_INFO = 21;

	// Token: 0x04001229 RID: 4649
	public const sbyte ADD_BASE_SKILL_POINT = 22;

	// Token: 0x0400122A RID: 4650
	public const sbyte NPC_INFO = 23;

	// Token: 0x0400122B RID: 4651
	public const sbyte BUY_ITEM = 24;

	// Token: 0x0400122C RID: 4652
	public const sbyte ITEM_TEMPLATE = 25;

	// Token: 0x0400122D RID: 4653
	public const sbyte CATALORY_MONSTER = 26;

	// Token: 0x0400122E RID: 4654
	public const sbyte CHAT_POPUP = 27;

	// Token: 0x0400122F RID: 4655
	public const sbyte GET_ITEM_TEM = 28;

	// Token: 0x04001230 RID: 4656
	public const sbyte LIST_SKILL = 29;

	// Token: 0x04001231 RID: 4657
	public const sbyte SET_EXP = 30;

	// Token: 0x04001232 RID: 4658
	public const sbyte GO_HOME = 31;

	// Token: 0x04001233 RID: 4659
	public const sbyte USE_POTION = 32;

	// Token: 0x04001234 RID: 4660
	public const sbyte LEVEL_UP = 33;

	// Token: 0x04001235 RID: 4661
	public const sbyte CHAT_TAB = 34;

	// Token: 0x04001236 RID: 4662
	public const sbyte FRIEND = 35;

	// Token: 0x04001237 RID: 4663
	public const sbyte BUY_SELL = 36;

	// Token: 0x04001238 RID: 4664
	public const sbyte INFO_FROM_SERVER = 37;

	// Token: 0x04001239 RID: 4665
	public const sbyte REGISTER = 39;

	// Token: 0x0400123A RID: 4666
	public const sbyte BUFF = 40;

	// Token: 0x0400123B RID: 4667
	public const sbyte DIE_PLAYER = 41;

	// Token: 0x0400123C RID: 4668
	public const sbyte PK = 42;

	// Token: 0x0400123D RID: 4669
	public const sbyte UPDATE_PET_CONTAINER = 44;

	// Token: 0x0400123E RID: 4670
	public const sbyte PET_EAT = 45;

	// Token: 0x0400123F RID: 4671
	public const sbyte PARTY = 48;

	// Token: 0x04001240 RID: 4672
	public const sbyte OTHER_PLAYER_INFO = 49;

	// Token: 0x04001241 RID: 4673
	public const sbyte EFF_PLUS_TIME = 50;

	// Token: 0x04001242 RID: 4674
	public const sbyte CHANGE_AREA = 51;

	// Token: 0x04001243 RID: 4675
	public const sbyte QUEST = 52;

	// Token: 0x04001244 RID: 4676
	public const sbyte INFO_EASY_SERVER = 53;

	// Token: 0x04001245 RID: 4677
	public const sbyte UPDATE_STATUS_AREA = 54;

	// Token: 0x04001246 RID: 4678
	public const sbyte SAVE_RMS = 55;

	// Token: 0x04001247 RID: 4679
	public const sbyte LIST_SERVER = 56;

	// Token: 0x04001248 RID: 4680
	public const sbyte LIST_PLAYER_PK = 57;

	// Token: 0x04001249 RID: 4681
	public const sbyte PLAYER_SUCKHOE = 59;

	// Token: 0x0400124A RID: 4682
	public const sbyte CHAT_NPC = 60;

	// Token: 0x0400124B RID: 4683
	public const sbyte NAME_SERVER = 61;

	// Token: 0x0400124C RID: 4684
	public const sbyte X2_XP = 62;

	// Token: 0x0400124D RID: 4685
	public const sbyte DELETE_RMS = 63;

	// Token: 0x0400124E RID: 4686
	public const sbyte HELP_FROM_SERVER = 64;

	// Token: 0x0400124F RID: 4687
	public const sbyte UPDATE_CHAR_CHEST = 65;

	// Token: 0x04001250 RID: 4688
	public const sbyte REBUILD_ITEM = 67;

	// Token: 0x04001251 RID: 4689
	public const sbyte THACH_DAU = 68;

	// Token: 0x04001252 RID: 4690
	public const sbyte CLAN = 69;

	// Token: 0x04001253 RID: 4691
	public const sbyte UPDATE_HP_NPC = 70;

	// Token: 0x04001254 RID: 4692
	public const sbyte CHAT_WORLD = 71;

	// Token: 0x04001255 RID: 4693
	public const sbyte REPLACE_PLUS_ITEM = 73;

	// Token: 0x04001256 RID: 4694
	public const sbyte SHOW_NUM_EFF = 74;

	// Token: 0x04001257 RID: 4695
	public const sbyte EFF_SERVER = 75;

	// Token: 0x04001258 RID: 4696
	public const sbyte EFF_WEATHER = 76;

	// Token: 0x04001259 RID: 4697
	public const sbyte REBUILD_WING = 77;

	// Token: 0x0400125A RID: 4698
	public const sbyte OPEN_BOX = 78;

	// Token: 0x0400125B RID: 4699
	public const sbyte PET_ATTACK = 84;

	// Token: 0x0400125C RID: 4700
	public const sbyte MONSTER_DETONATE = 85;

	// Token: 0x0400125D RID: 4701
	public const sbyte MONSTER_SKILL_INFO = 86;

	// Token: 0x0400125E RID: 4702
	public const sbyte PET_GAIN_XP = 87;

	// Token: 0x0400125F RID: 4703
	public const sbyte REMOVE_ACTOR = 90;

	// Token: 0x04001260 RID: 4704
	public const sbyte IN_APP_PURCHASE = -93;

	// Token: 0x04001261 RID: 4705
	public const sbyte USE_ITEM_ARENA = -92;

	// Token: 0x04001262 RID: 4706
	public const sbyte STATUS_ARENA = -94;

	// Token: 0x04001263 RID: 4707
	public const sbyte MARKKILLER = -95;

	// Token: 0x04001264 RID: 4708
	public const sbyte SERVER_ADD_NPC = -96;

	// Token: 0x04001265 RID: 4709
	public const sbyte USE_MOUNT = -97;

	// Token: 0x04001266 RID: 4710
	public const sbyte USE_SHIP = -98;

	// Token: 0x04001267 RID: 4711
	public const sbyte LAST_LOGIN = -99;

	// Token: 0x04001268 RID: 4712
	public const sbyte KHAM_NGOC = -100;

	// Token: 0x04001269 RID: 4713
	public const sbyte COMPETITION = -101;

	// Token: 0x0400126A RID: 4714
	public const sbyte MUA_BAN = -102;

	// Token: 0x0400126B RID: 4715
	public const sbyte INFO_MI_NUONG = -103;

	// Token: 0x0400126C RID: 4716
	public const sbyte UPDATE_INFO_CLAN_HOLD = -104;

	// Token: 0x0400126D RID: 4717
	public const sbyte HOP_RAC = -105;

	// Token: 0x0400126E RID: 4718
	public const sbyte GET_MATERITAL_TEMPLATE = -106;

	// Token: 0x0400126F RID: 4719
	public const sbyte USE_MATERIAL = -107;

	// Token: 0x04001270 RID: 4720
	public const sbyte FILL_REC_UPDATE_TIME = -108;

	// Token: 0x04001271 RID: 4721
	public const sbyte GET_NAP_STORE_APPLE = -109;

	// Token: 0x04001272 RID: 4722
	public ISession session = Session_ME.gI();

	// Token: 0x04001273 RID: 4723
	public Message m;
}
