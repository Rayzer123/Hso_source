using System;

// Token: 0x02000057 RID: 87
public class MainQuest : AvMain
{
	// Token: 0x0600046E RID: 1134 RVA: 0x0003E490 File Offset: 0x0003C690
	public MainQuest(int ID, bool isMain, string name, int idNpcFrom, string strDetailTalk, sbyte typeQuest, string strDetailHelp)
	{
		this.ID = ID;
		this.isMain = isMain;
		this.idNPC_From = idNpcFrom;
		this.idNPCChat = idNpcFrom;
		this.name = name;
		this.strDetailTalk = strDetailTalk;
		this.strDetailHelp = strDetailHelp;
		this.typeQuest = typeQuest;
		this.nhantra = 0;
		this.mstrTalk = mFont.split(strDetailTalk, ">");
	}

	// Token: 0x0600046F RID: 1135 RVA: 0x0003E4FC File Offset: 0x0003C6FC
	public MainQuest(int ID, bool isMain, string name, int idNpcTo, string strDetailTalk, string strDetailHelp)
	{
		this.ID = ID;
		this.isMain = isMain;
		this.idNPC_To = idNpcTo;
		this.idNPCChat = idNpcTo;
		this.name = name;
		this.strDetailTalk = strDetailTalk;
		this.strDetailHelp = strDetailHelp;
		this.mstrHelp = mFont.tahoma_7_white.splitFontArray(strDetailHelp, MainTabNew.wblack - 35);
		this.nhantra = 1;
		this.mstrTalk = mFont.split(strDetailTalk, ">");
	}

	// Token: 0x06000470 RID: 1136 RVA: 0x0003E578 File Offset: 0x0003C778
	public MainQuest(int ID, bool isMain, string name, string strDetailHelp, sbyte typeQuest, string strShortDetail, int idNpcTo, short[] mid, short[] mtotal, short[] mget, int typeItem_Monster)
	{
		this.ID = ID;
		this.isMain = isMain;
		this.idNPC_To = idNpcTo;
		this.idNPCChat = idNpcTo;
		this.name = name;
		this.typeQuest = typeQuest;
		this.strShortDetail = strShortDetail;
		this.strDetailHelp = strDetailHelp;
		this.mIdQuest = mid;
		this.mtotalQuest = mtotal;
		this.mQuestGot = mget;
	}

	// Token: 0x06000471 RID: 1137 RVA: 0x0003E5E0 File Offset: 0x0003C7E0
	public MainQuest(int ID, bool isMain, string name, string strDetailHelp, int idNpcTo, string strShortDetail)
	{
		this.ID = ID;
		this.isMain = isMain;
		this.name = name;
		this.strShortDetail = strShortDetail;
		this.strDetailHelp = strDetailHelp;
		this.idNPC_To = idNpcTo;
		this.idNPCChat = idNpcTo;
	}

	// Token: 0x06000473 RID: 1139 RVA: 0x0003E66C File Offset: 0x0003C86C
	public override void commandPointer(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				if (GameCanvas.menu2.runText != null && !GameCanvas.menu2.runText.nextDlgStep())
				{
					return;
				}
				MainObject mainObject = MainObject.get_Object(this.idNPCChat, 2);
				if (mainObject != null)
				{
					mainObject.chat = null;
				}
				string text = this.strDetailHelp;
				if (text == null)
				{
					text = "sai roi";
				}
				GameScreen.player.chat = null;
				if ((int)this.typeQuest == 3)
				{
					GlobalService.gI().quest((short)this.ID, (!this.isMain) ? 1 : 0, 1);
				}
				else
				{
					GameCanvas.start_Quest_Dialog(text, this.name, this.ID, this.nhantra, (!this.isMain) ? 1 : 0);
				}
				GameScreen.player.currentQuest = null;
				GameScreen.gI().center = null;
				GameCanvas.clearKeyHold();
				GameCanvas.isPointerSelect = false;
			}
		}
		else
		{
			if (GameCanvas.menu2.runText != null && !GameCanvas.menu2.runText.nextDlgStep())
			{
				return;
			}
			this.nextStep();
		}
	}

	// Token: 0x06000474 RID: 1140 RVA: 0x0003E7A0 File Offset: 0x0003C9A0
	public void beginQuest()
	{
		this.step = 0;
		GameScreen.player.currentQuest = this;
		this.nextStep();
	}

	// Token: 0x06000475 RID: 1141 RVA: 0x0003E7BC File Offset: 0x0003C9BC
	public void show_Info_Quest_Doing()
	{
		if (this.strShortDetail == null || MainObject.get_Object(this.idNPCChat, 2) == null)
		{
			return;
		}
		MainObject.get_Object(this.idNPCChat, 2).strChatPopup = this.strDetailHelp;
	}

	// Token: 0x06000476 RID: 1142 RVA: 0x0003E800 File Offset: 0x0003CA00
	public iCommand setCmd()
	{
		iCommand result;
		if (this.step < this.mstrTalk.Length - 1)
		{
			result = new iCommand(T.next, 0, this);
		}
		else
		{
			result = new iCommand(T.next, 1, this);
		}
		return result;
	}

	// Token: 0x06000477 RID: 1143 RVA: 0x0003E844 File Offset: 0x0003CA44
	public void nextStep()
	{
		if (MainObject.get_Object(this.idNPCChat, 2) == null)
		{
			GameScreen.player.currentQuest = null;
			return;
		}
		if (this.mstrTalk[this.step].Trim().StartsWith("0"))
		{
			MainObject.get_Object(this.idNPCChat, 2).chat = null;
			mVector mVector = new mVector("MainQuest menu");
			iCommand o = this.setCmd();
			mVector.addElement(o);
			GameCanvas.menu2.startAt_NPC(mVector, mSystem.substring(this.mstrTalk[this.step], 1, this.mstrTalk[this.step].Length), GameScreen.player.ID, 0, true, 0);
		}
		else
		{
			GameScreen.player.chat = null;
			mVector mVector2 = new mVector("MainQuest menu2");
			iCommand o2 = this.setCmd();
			mVector2.addElement(o2);
			GameCanvas.menu2.startAt_NPC(mVector2, mSystem.substring(this.mstrTalk[this.step], 1, this.mstrTalk[this.step].Length), this.idNPCChat, 2, true, 0);
		}
		this.step++;
	}

	// Token: 0x06000478 RID: 1144 RVA: 0x0003E968 File Offset: 0x0003CB68
	public static void updateQuestKillMonster(int idMonster)
	{
		MainMonster mainMonster = (MainMonster)MainObject.get_Object(idMonster, 1);
		if (mainMonster == null)
		{
			return;
		}
		string text = string.Empty;
		for (int i = 0; i < MainQuest.vecQuestDoing_Main.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(i);
			if ((int)mainQuest.typeQuest == 1)
			{
				for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
				{
					if ((int)mainQuest.mIdQuest[j] == mainMonster.catalogyMonster && mainQuest.mQuestGot[j] < mainQuest.mtotalQuest[j])
					{
						short[] array = mainQuest.mQuestGot;
						int num = j;
						array[num] += 1;
						if (text.Length > 0)
						{
							text += " , ";
						}
						string text2 = text;
						text = string.Concat(new object[]
						{
							text2,
							mainQuest.mQuestGot[j],
							"/",
							mainQuest.mtotalQuest[j]
						});
					}
				}
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Sub.size(); k++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(k);
			if ((int)mainQuest2.typeQuest == 1)
			{
				for (int l = 0; l < mainQuest2.mIdQuest.Length; l++)
				{
					if ((int)mainQuest2.mIdQuest[l] == mainMonster.catalogyMonster && mainQuest2.mQuestGot[l] < mainQuest2.mtotalQuest[l])
					{
						short[] array2 = mainQuest2.mQuestGot;
						int num2 = l;
						array2[num2] += 1;
						if (text.Length > 0)
						{
							text += " , ";
						}
						string text2 = text;
						text = string.Concat(new object[]
						{
							text2,
							mainQuest2.mQuestGot[l],
							"/",
							mainQuest2.mtotalQuest[l]
						});
					}
				}
			}
		}
		if (text.Length > 0)
		{
			text = T.giet + mainMonster.name + ": " + text;
			GameCanvas.addInfoChar(text);
		}
	}

	// Token: 0x06000479 RID: 1145 RVA: 0x0003EB9C File Offset: 0x0003CD9C
	public static void updateQuestGetItem(int idItem, string name)
	{
		string text = string.Empty;
		for (int i = 0; i < MainQuest.vecQuestDoing_Main.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(i);
			if ((int)mainQuest.typeQuest == 0)
			{
				for (int j = 0; j < mainQuest.mIdQuest.Length; j++)
				{
					if ((int)mainQuest.mIdQuest[j] == idItem && mainQuest.mQuestGot[j] < mainQuest.mtotalQuest[j])
					{
						short[] array = mainQuest.mQuestGot;
						int num = j;
						array[num] += 1;
						if (text.Length > 0)
						{
							text += " , ";
						}
						string text2 = text;
						text = string.Concat(new object[]
						{
							text2,
							mainQuest.mQuestGot[j],
							"/",
							mainQuest.mtotalQuest[j]
						});
					}
				}
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Sub.size(); k++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(k);
			if ((int)mainQuest2.typeQuest == 0)
			{
				for (int l = 0; l < mainQuest2.mIdQuest.Length; l++)
				{
					if ((int)mainQuest2.mIdQuest[l] == idItem && mainQuest2.mQuestGot[l] < mainQuest2.mtotalQuest[l])
					{
						short[] array2 = mainQuest2.mQuestGot;
						int num2 = l;
						array2[num2] += 1;
						if (text.Length > 0)
						{
							text += " , ";
						}
						string text2 = text;
						text = string.Concat(new object[]
						{
							text2,
							mainQuest2.mQuestGot[l],
							"/",
							mainQuest2.mtotalQuest[l]
						});
					}
				}
			}
		}
		if (text.Length > 0)
		{
			text = T.nhat + name + ": " + text;
			GameCanvas.addInfoChar(text);
		}
	}

	// Token: 0x04000653 RID: 1619
	public const int Q_NHAT_ITEM = 0;

	// Token: 0x04000654 RID: 1620
	public const int Q_KILL_MONSTER = 1;

	// Token: 0x04000655 RID: 1621
	public const int Q_CHUYEN_DO = 2;

	// Token: 0x04000656 RID: 1622
	public const int Q_TALK = 3;

	// Token: 0x04000657 RID: 1623
	public const int TYPE_ITEM = 0;

	// Token: 0x04000658 RID: 1624
	public const int TYPE_MONSTER = 1;

	// Token: 0x04000659 RID: 1625
	public const int NHAN = 0;

	// Token: 0x0400065A RID: 1626
	public const int TRA = 1;

	// Token: 0x0400065B RID: 1627
	public static mVector vecQuestList = new mVector("MainQuest vecQuestList");

	// Token: 0x0400065C RID: 1628
	public static mVector vecQuestFinish = new mVector("MainQuest vecQuestFinish");

	// Token: 0x0400065D RID: 1629
	public static mVector vecQuestDoing_Main = new mVector("MainQuest vecQuestDoing_Main");

	// Token: 0x0400065E RID: 1630
	public static mVector vecQuestDoing_Sub = new mVector("MainQuest vecQuestDoing_Sub");

	// Token: 0x0400065F RID: 1631
	public sbyte typeQuest;

	// Token: 0x04000660 RID: 1632
	public int ID;

	// Token: 0x04000661 RID: 1633
	public int idNPC_To;

	// Token: 0x04000662 RID: 1634
	public int idNPC_From;

	// Token: 0x04000663 RID: 1635
	public int idNPCChat;

	// Token: 0x04000664 RID: 1636
	public int nhantra;

	// Token: 0x04000665 RID: 1637
	public bool isComplete;

	// Token: 0x04000666 RID: 1638
	public bool isMain;

	// Token: 0x04000667 RID: 1639
	public string name;

	// Token: 0x04000668 RID: 1640
	public string strDetail;

	// Token: 0x04000669 RID: 1641
	public string strShortDetail;

	// Token: 0x0400066A RID: 1642
	public string[] mDetail;

	// Token: 0x0400066B RID: 1643
	public string[] mstrTalk;

	// Token: 0x0400066C RID: 1644
	public string[] mstrHelp;

	// Token: 0x0400066D RID: 1645
	public string strDetailTalk;

	// Token: 0x0400066E RID: 1646
	public string strDetailHelp;

	// Token: 0x0400066F RID: 1647
	public string strShowDialog;

	// Token: 0x04000670 RID: 1648
	public short[] mIdQuest;

	// Token: 0x04000671 RID: 1649
	public short[] mtotalQuest;

	// Token: 0x04000672 RID: 1650
	public short[] mQuestGot;

	// Token: 0x04000673 RID: 1651
	private int step;
}
