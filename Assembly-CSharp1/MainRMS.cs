using System;

// Token: 0x02000058 RID: 88
public class MainRMS
{
	// Token: 0x0600047C RID: 1148 RVA: 0x0003EDBC File Offset: 0x0003CFBC
	public static void RequietRMS()
	{
		GlobalService.gI().Save_RMS_Server(1, 0, null);
		MainRMS.setLoadRMS(0, null);
	}

	// Token: 0x0600047D RID: 1149 RVA: 0x0003EDD4 File Offset: 0x0003CFD4
	public static void setLoadRMS(sbyte id, sbyte[] mdata)
	{
		switch (id)
		{
		case 0:
			if (GameScreen.player != null)
			{
				TabSkillsNew.loadSkill(mdata);
			}
			break;
		case 1:
			GameScreen.help.LoadStep(mdata);
			GameCanvas.load.isLoadHelp = true;
			if (!GameCanvas.isVN_Eng && !IndoServer.isIndoSv && (GameScreen.help.Step > 0 || GameScreen.help.Next > -5))
			{
				GameScreen.isFinishHelp = true;
				GameCanvas.end_Dialog();
				Player.isLockKey = false;
			}
			break;
		case 2:
			GameScreen.help.loadBeginGame(mdata);
			MainRMS.isLoadBegin = true;
			mSystem.outz("ouuuuuuuuuuuuuuuuuuuu");
			break;
		case 3:
			if (mdata != null)
			{
				MainRMS.setLoadAuto(mdata);
			}
			break;
		case 4:
			if (mdata != null)
			{
				if (GameCanvas.isTouch)
				{
					PaintInfoGameScreen.isLevelPoint = ((int)mdata[0] == 1);
					PaintInfoGameScreen.setPosTouch();
				}
				if (mdata.Length > 1)
				{
					PaintInfoGameScreen.isShowInfoAuto = ((int)mdata[1] == 1);
				}
			}
			break;
		}
	}

	// Token: 0x0600047E RID: 1150 RVA: 0x0003EEE4 File Offset: 0x0003D0E4
	public static void setLoadAuto(sbyte[] data)
	{
		MainRMS.showAuto = string.Empty;
		bool flag = false;
		Player.isAutoHPMP = ((int)data[0] == 1);
		MsgDialog.mHPMP[0] = (int)data[1];
		MsgDialog.mHPMP[1] = (int)data[2];
		if (Player.isAutoHPMP && PaintInfoGameScreen.isShowInfoAuto)
		{
			flag = true;
			string text = MainRMS.showAuto;
			MainRMS.showAuto = string.Concat(new object[]
			{
				text,
				T.autoHP,
				"\n  +",
				T.mAuto[0],
				MsgDialog.mHPMP[0],
				"%\n  +",
				T.mAuto[1],
				MsgDialog.mHPMP[1],
				"%"
			});
		}
		bool flag2 = (int)data[3] == 1;
		if (flag2)
		{
			Player.autoItem = new AutoGetItem(data[4], data[5], data[6]);
		}
		if (flag2 && PaintInfoGameScreen.isShowInfoAuto)
		{
			if (flag)
			{
				MainRMS.showAuto += "\n";
			}
			else
			{
				flag = true;
			}
			string text = MainRMS.showAuto;
			MainRMS.showAuto = string.Concat(new string[]
			{
				text,
				T.autoItem,
				"\n  +",
				T.mAutoItem[0],
				": ",
				T.mValueAutoItem[0][(int)Player.autoItem.valueColorItem]
			});
			text = MainRMS.showAuto;
			MainRMS.showAuto = string.Concat(new string[]
			{
				text,
				"\n  +",
				T.mAutoItem[1],
				": ",
				T.mValueAutoItem[1][(int)Player.autoItem.isGetMoney]
			});
			text = MainRMS.showAuto;
			MainRMS.showAuto = string.Concat(new string[]
			{
				text,
				"\n  +",
				T.mAutoItem[2],
				": ",
				T.mValueAutoItem[2][(int)Player.autoItem.isGetPotion]
			});
		}
		Player.isAutoBuff = data[7];
		int num = (int)MsgDialog.MaxSkillBuff;
		if (data.Length - 7 >= num)
		{
			num -= CRes.abs(num - (data.Length - 7)) + 1;
		}
		for (int i = 0; i < num; i++)
		{
			MsgDialog.Autobuff[i][1] = (int)data[8 + i];
		}
		if ((int)Player.isAutoBuff == 1 && PaintInfoGameScreen.isShowInfoAuto)
		{
			if (flag)
			{
				MainRMS.showAuto += "\n";
			}
			MainRMS.showAuto += T.autoBuff;
			for (int j = 0; j < num; j++)
			{
				if (MsgDialog.Autobuff[j][1] == 1)
				{
					Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(MsgDialog.Autobuff[j][2]);
					MainRMS.showAuto = MainRMS.showAuto + "\n  " + skill.name;
				}
			}
		}
		if (MainRMS.showAuto.Length > 0 && MainRMS.isLoadShowAuto && GameCanvas.currentScreen == GameCanvas.game)
		{
			MainRMS.isLoadShowAuto = false;
			GameCanvas.start_Show_Dialog(T.autoFire + "\n  " + MainRMS.showAuto, T.auto);
		}
	}

	// Token: 0x0600047F RID: 1151 RVA: 0x0003F224 File Offset: 0x0003D424
	public static void setSaveAuto()
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeByte((!Player.isAutoHPMP) ? 0 : 1);
			dataOutputStream.writeByte(MsgDialog.mHPMP[0]);
			dataOutputStream.writeByte(MsgDialog.mHPMP[1]);
			dataOutputStream.writeByte((Player.autoItem != null) ? 1 : 0);
			if (Player.autoItem == null)
			{
				dataOutputStream.writeByte(0);
				dataOutputStream.writeByte(0);
				dataOutputStream.writeByte(0);
			}
			else
			{
				dataOutputStream.writeByte(Player.autoItem.valueColorItem);
				dataOutputStream.writeByte(Player.autoItem.isGetMoney);
				dataOutputStream.writeByte(Player.autoItem.isGetPotion);
			}
			dataOutputStream.writeByte(Player.isAutoBuff);
			for (int i = 0; i < (int)MsgDialog.MaxSkillBuff; i++)
			{
				dataOutputStream.writeByte(MsgDialog.Autobuff[i][1]);
			}
			CRes.saveRMSName(3, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000480 RID: 1152 RVA: 0x0003F340 File Offset: 0x0003D540
	public static void setSaveTouch()
	{
		sbyte[] data = new sbyte[]
		{
			(!PaintInfoGameScreen.isLevelPoint) ? 0 : 1,
			(!PaintInfoGameScreen.isShowInfoAuto) ? 0 : 1
		};
		try
		{
			CRes.saveRMSName(4, data);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000674 RID: 1652
	public const sbyte SKILL = 0;

	// Token: 0x04000675 RID: 1653
	public const sbyte HELP = 1;

	// Token: 0x04000676 RID: 1654
	public const sbyte BEGIN_GAME = 2;

	// Token: 0x04000677 RID: 1655
	public const sbyte AUTO = 3;

	// Token: 0x04000678 RID: 1656
	public const sbyte TOUCH = 4;

	// Token: 0x04000679 RID: 1657
	public static bool isLoadBegin;

	// Token: 0x0400067A RID: 1658
	public static bool isLoadShowAuto = true;

	// Token: 0x0400067B RID: 1659
	public static string showAuto = string.Empty;
}
