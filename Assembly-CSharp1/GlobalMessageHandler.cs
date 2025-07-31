using System;

// Token: 0x020000DC RID: 220
public class GlobalMessageHandler : Cmd_Message, IMessageHandler
{
	// Token: 0x06000A23 RID: 2595 RVA: 0x000AA340 File Offset: 0x000A8540
	public static GlobalMessageHandler gI()
	{
		if (GlobalMessageHandler.me == null)
		{
			GlobalMessageHandler.me = new GlobalMessageHandler();
		}
		return GlobalMessageHandler.me;
	}

	// Token: 0x06000A24 RID: 2596 RVA: 0x000AA35C File Offset: 0x000A855C
	public void setGameLogicHandler(GlobalLogicHandler gI)
	{
		this.globalLogicHandler = gI;
	}

	// Token: 0x06000A25 RID: 2597 RVA: 0x000AA368 File Offset: 0x000A8568
	public void onConnectOK()
	{
		this.globalLogicHandler.onConnectOK();
	}

	// Token: 0x06000A26 RID: 2598 RVA: 0x000AA378 File Offset: 0x000A8578
	public void onConnectionFail()
	{
		this.globalLogicHandler.onConnectFail();
	}

	// Token: 0x06000A27 RID: 2599 RVA: 0x000AA388 File Offset: 0x000A8588
	public void onDisconnected()
	{
		GlobalLogicHandler.onDisconnect();
	}

	// Token: 0x06000A28 RID: 2600 RVA: 0x000AA390 File Offset: 0x000A8590
	public void onMessage(Message msg)
	{
		sbyte command = msg.command;
		switch (command + 108)
		{
		case 0:
			GameCanvas.readMessenge.onFillRec_Time(msg);
			break;
		case 2:
			GameCanvas.readMessenge.Material_Template(msg);
			break;
		case 3:
			GameCanvas.readMessenge.onHopRac(msg);
			break;
		case 4:
			GameCanvas.readMessenge.infoclanChiemthanh(msg);
			break;
		case 5:
			GameCanvas.readMessenge.MiNuongInfo(msg);
			break;
		case 6:
			GameCanvas.readMessenge.StoreInfo(msg);
			break;
		case 7:
			GameCanvas.readMessenge.ThachDau(msg);
			break;
		case 8:
			GameCanvas.readMessenge.khamNgoc(msg);
			break;
		case 9:
			GameCanvas.readMessenge.lastlogout(msg);
			break;
		case 10:
			GameCanvas.readMessenge.useShip(msg);
			break;
		case 11:
			GameCanvas.readMessenge.useMount(msg);
			break;
		case 12:
			GameCanvas.readMessenge.npcServer(msg);
			break;
		case 13:
			GameCanvas.readMessenge.updateMarkKiller(msg);
			break;
		case 14:
			GameCanvas.readMessenge.UpdateInfoArena(msg);
			break;
		case 15:
			Main.main.ClearTransaction();
			break;
		case 16:
			GameCanvas.readMessenge.useItemArena(msg);
			break;
		case 17:
			GameCanvas.readMessenge.receiveLotteryReward(msg);
			break;
		case 18:
		case -58:
			GameCanvas.readMessenge.remove_Actor(msg);
			break;
		case 32:
			TemMidlet.handleMessage(msg);
			break;
		case 33:
			TemMidlet.handleMessage(msg);
			break;
		case 51:
			GameCanvas.readMessenge.UpdateDataAndroid(msg);
			break;
		case 54:
			GameCanvas.readMessenge.SoSanhDataAndroid(msg);
			break;
		case 55:
			GameCanvas.readMessenge.nap_tien(msg);
			break;
		case 56:
			GameCanvas.readMessenge.loadImageDataCharPart(msg);
			break;
		case 57:
			GameCanvas.readMessenge.loadImage(msg);
			break;
		case 58:
			GameCanvas.readMessenge.npcBig(msg);
			break;
		case 59:
			GameCanvas.readMessenge.loadImageDataAutoEff(msg);
			break;
		case 64:
			GameCanvas.readMessenge.newNPCInfo(msg);
			break;
		case 76:
			GameCanvas.readMessenge.Dialog_server(msg);
			break;
		case 77:
			GameCanvas.readMessenge.Dialog_More_server(msg);
			break;
		case 78:
			GameCanvas.readMessenge.Dynamic_Menu(msg);
			break;
		case 109:
			GameCanvas.readMessenge.Login_Ok(msg);
			break;
		case 110:
			GameCanvas.readMessenge.Login_Fail(msg);
			break;
		case 111:
			GameCanvas.readMessenge.mainCharInfo(msg);
			break;
		case 112:
			GameCanvas.readMessenge.objectMove(msg);
			break;
		case 113:
			GameCanvas.readMessenge.charInfo(msg);
			break;
		case 114:
			GameCanvas.readMessenge.firePK(msg);
			break;
		case 115:
			GameCanvas.readMessenge.monsterInfo(msg);
			break;
		case 116:
			GameCanvas.readMessenge.playerExit(msg);
			break;
		case 117:
			GameCanvas.readMessenge.fireMonster(msg);
			break;
		case 118:
			GameCanvas.readMessenge.monsterFire(msg);
			break;
		case 120:
			GameCanvas.readMessenge.changeMap(msg);
			break;
		case 121:
			GameCanvas.readMessenge.listChar(msg);
			break;
		case 123:
			GameCanvas.readMessenge.charWearing(msg);
			break;
		case 124:
			GameCanvas.readMessenge.charInventory(msg);
			break;
		case 125:
			GameCanvas.readMessenge.dieMonster(msg);
			break;
		case 127:
			GameCanvas.readMessenge.ItemDrop(msg);
			break;
		case -128:
			GameCanvas.readMessenge.GetItemMap(msg);
			break;
		case -127:
			GameCanvas.readMessenge.Item_More_Info(msg);
			break;
		case -126:
			GameCanvas.readMessenge.onUpSkill(msg);
			break;
		case -125:
			GameCanvas.readMessenge.npcInfo(msg);
			break;
		case -123:
			GameCanvas.readMessenge.itemTemplate(msg);
			break;
		case -122:
			GameCanvas.readMessenge.catalogyMonster(msg);
			break;
		case -121:
			GameCanvas.readMessenge.chatPopup(msg);
			break;
		case -120:
			GameCanvas.readMessenge.get_Item_Tem(msg);
			break;
		case -119:
			GameCanvas.readMessenge.Skill_List(msg);
			break;
		case -118:
			GameCanvas.readMessenge.Set_XP(msg);
			break;
		case -117:
			GameCanvas.readMessenge.writeUserAccountInfoToRMS(msg);
			break;
		case -116:
			GameCanvas.readMessenge.use_Potion(msg);
			break;
		case -115:
			GameCanvas.readMessenge.Level_Up(msg);
			break;
		case -114:
			GameCanvas.readMessenge.chatTab(msg);
			break;
		case -113:
			GameCanvas.readMessenge.Friend(msg);
			break;
		case -112:
			GameCanvas.readMessenge.Buy_Sell(msg);
			break;
		case -111:
			GameCanvas.readMessenge.InfoServer_Download(msg);
			break;
		case -109:
			GameCanvas.readMessenge.Register(msg);
			break;
		case -108:
			GameCanvas.readMessenge.Buff(msg);
			break;
		case -107:
			GameCanvas.readMessenge.diePlayer(msg);
			break;
		case -106:
			GameCanvas.readMessenge.pk(msg);
			break;
		case -104:
			GameCanvas.readMessenge.UpdatePetContainer(msg);
			break;
		case -100:
			GameCanvas.readMessenge.Party(msg);
			break;
		case -99:
			GameCanvas.readMessenge.other_player_info(msg);
			break;
		case -98:
			GameCanvas.readMessenge.eff_plus_time(msg);
			break;
		case -97:
			GameCanvas.readMessenge.changeArea(msg);
			break;
		case -96:
			GameCanvas.readMessenge.onReceiveInfoQuest(msg);
			break;
		case -95:
			GameCanvas.readMessenge.InfoEasyFromServer(msg);
			break;
		case -94:
			GameCanvas.readMessenge.update_Status_Area(msg);
			break;
		case -93:
			GameCanvas.readMessenge.Save_RMS_Server(msg);
			break;
		case -92:
			GameCanvas.readMessenge.List_Serverz(msg);
			break;
		case -91:
			GameCanvas.readMessenge.List_Pk(msg);
			break;
		case -89:
			GameCanvas.readMessenge.suckhoe(msg);
			break;
		case -88:
			GameCanvas.readMessenge.chat_npc(msg);
			break;
		case -87:
			GameCanvas.readMessenge.name_server(msg);
			break;
		case -86:
			GameCanvas.readMessenge.x2_Xp(msg);
			break;
		case -85:
			GameCanvas.readMessenge.delete_rms(msg);
			break;
		case -84:
			GameCanvas.readMessenge.Help_From_Server(msg);
			break;
		case -83:
			GameCanvas.readMessenge.CharChest(msg);
			break;
		case -81:
			GameCanvas.readMessenge.Rebuild_Item(msg);
			break;
		case -80:
			GameCanvas.readMessenge.Thach_Dau(msg);
			break;
		case -79:
			GameCanvas.readMessenge.Clan(msg);
			break;
		case -78:
			GameCanvas.readMessenge.updateHpNPC(msg);
			break;
		case -75:
			GameCanvas.readMessenge.ReplacePlusItem(msg);
			break;
		case -74:
			GameCanvas.readMessenge.Num_Eff(msg);
			break;
		case -73:
			GameCanvas.readMessenge.EffFormServer(msg);
			break;
		case -72:
			GameCanvas.readMessenge.EffWeather(msg);
			break;
		case -71:
			GameCanvas.readMessenge.Rebuild_Wing(msg);
			break;
		case -70:
			GameCanvas.readMessenge.Open_Box(msg);
			break;
		case -64:
			GameCanvas.readMessenge.petAttack(msg);
			break;
		case -63:
			GameCanvas.readMessenge.monsterDetonate(msg);
			break;
		case -62:
			GameCanvas.readMessenge.monsterSkillInfo(msg);
			break;
		}
	}

	// Token: 0x040011E1 RID: 4577
	public GlobalLogicHandler globalLogicHandler = new GlobalLogicHandler();

	// Token: 0x040011E2 RID: 4578
	public static GlobalMessageHandler me;

	// Token: 0x040011E3 RID: 4579
	public IMiniGameMsgHandler miniGameMessageHandler;
}
