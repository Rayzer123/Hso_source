using System;

// Token: 0x020000DD RID: 221
public class GlobalService : Cmd_Message
{
	// Token: 0x06000A2A RID: 2602 RVA: 0x000AACFC File Offset: 0x000A8EFC
	public static GlobalService gI()
	{
		if (GlobalService.instance == null)
		{
			GlobalService.instance = new GlobalService();
		}
		return GlobalService.instance;
	}

	// Token: 0x06000A2B RID: 2603 RVA: 0x000AAD18 File Offset: 0x000A8F18
	public void login(string user, string pass, string version, string clinePro, string pro, string agent, int id, sbyte area)
	{
		base.init(1);
		try
		{
			this.m.writer().writeUTF(user);
			this.m.writer().writeUTF(pass);
			this.m.writer().writeUTF(version);
			this.m.writer().writeUTF(clinePro);
			this.m.writer().writeUTF(pro);
			this.m.writer().writeUTF(agent);
			this.m.writer().writeByte(mGraphics.zoomLevel);
			this.m.writer().writeByte(GameCanvas.device);
			this.m.writer().writeInt(id);
			this.m.writer().writeByte(area);
			this.m.writer().writeByte((!Main.isPC) ? 0 : 1);
			this.m.writer().writeByte(GameCanvas.IndexRes);
			this.m.writer().writeByte(LoginScreen.indexInfoLogin);
			this.m.writer().writeByte(0);
			this.m.writer().writeShort(GameCanvas.IndexCharPar);
			this.m.writer().writeUTF(GameCanvas.stringPackageName);
			GlobalLogicHandler.isDisConect = false;
			GlobalLogicHandler.timeReconnect = 0L;
			GlobalLogicHandler.isMelogin = false;
			Main.isExit = false;
		}
		catch (Exception ex)
		{
		}
		base.send();
		if (id == -1)
		{
			GameCanvas.start_Wait_Dialog(T.dangdangnhap, new iCommand(T.close, 7));
			GameCanvas.countLogin = mSystem.currentTimeMillis();
		}
		else
		{
			GameCanvas.start_Wait_Dialog(T.dangketnoilai, new iCommand(T.close, 7));
		}
	}

	// Token: 0x06000A2C RID: 2604 RVA: 0x000AAEF4 File Offset: 0x000A90F4
	public void infoTranpost()
	{
	}

	// Token: 0x06000A2D RID: 2605 RVA: 0x000AAEF8 File Offset: 0x000A90F8
	public void player_move(short x, short y)
	{
		base.init(4);
		try
		{
			this.m.writer().writeShort(x);
			this.m.writer().writeShort(y);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A2E RID: 2606 RVA: 0x000AAF5C File Offset: 0x000A915C
	public void char_info(short id)
	{
		base.init(5);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A2F RID: 2607 RVA: 0x000AAFB0 File Offset: 0x000A91B0
	public void requestInapPurchare(sbyte type, string reciep, sbyte index)
	{
		base.init(-93);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(reciep);
			this.m.writer().writeByte(index);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A30 RID: 2608 RVA: 0x000AB028 File Offset: 0x000A9228
	public void new_npc_info(short id)
	{
		base.init(-44);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A31 RID: 2609 RVA: 0x000AB07C File Offset: 0x000A927C
	public void monster_info(short id)
	{
		base.init(7);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A32 RID: 2610 RVA: 0x000AB0D0 File Offset: 0x000A92D0
	public void Ok_Change_Map()
	{
		base.init(12);
		try
		{
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A33 RID: 2611 RVA: 0x000AB114 File Offset: 0x000A9314
	public void fire_monster(mVector vec, sbyte typekill)
	{
		base.init(9);
		try
		{
			this.m.writer().writeByte(typekill);
			this.m.writer().writeByte(vec.size());
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				this.m.writer().writeShort(object_Effect_Skill.ID);
			}
			ListSkill.doSetTimeAtt();
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A34 RID: 2612 RVA: 0x000AB1BC File Offset: 0x000A93BC
	public void nap_tien(short type, string[] minfo)
	{
		base.init(-53);
		try
		{
			this.m.writer().writeShort(type);
			this.m.writer().writeByte(minfo.Length);
			for (int i = 0; i < minfo.Length; i++)
			{
				this.m.writer().writeUTF(minfo[i]);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A35 RID: 2613 RVA: 0x000AB24C File Offset: 0x000A944C
	public void load_image_data_part_char(sbyte type, short id)
	{
		if (GameCanvas.currentScreen != GameCanvas.selectChar || (int)TemMidlet.DIVICE == 0)
		{
			base.init(-52);
			try
			{
				this.m.writer().writeByte(type);
				this.m.writer().writeShort(id);
			}
			catch (Exception ex)
			{
			}
			base.send();
		}
	}

	// Token: 0x06000A36 RID: 2614 RVA: 0x000AB2CC File Offset: 0x000A94CC
	public void load_image_data_auto_eff(short id)
	{
		base.init(-49);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A37 RID: 2615 RVA: 0x000AB320 File Offset: 0x000A9520
	public void load_image(short id)
	{
		base.init(-51);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A38 RID: 2616 RVA: 0x000AB374 File Offset: 0x000A9574
	public void create_char(sbyte bytclass, string name, sbyte bythair, sbyte byteye, sbyte bythead, sbyte index)
	{
		base.init(14);
		try
		{
			this.m.writer().writeByte(bytclass);
			this.m.writer().writeUTF(name);
			this.m.writer().writeByte(bythair);
			this.m.writer().writeByte(byteye);
			this.m.writer().writeByte(bythead);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A39 RID: 2617 RVA: 0x000AB410 File Offset: 0x000A9610
	public void select_char(sbyte typeSelect, int charid)
	{
		base.init(13);
		try
		{
			this.m.writer().writeByte(typeSelect);
			this.m.writer().writeInt(charid);
		}
		catch (Exception ex)
		{
		}
		base.send();
		GameCanvas.start_Wait_Dialog(T.pleaseWait, null);
	}

	// Token: 0x06000A3A RID: 2618 RVA: 0x000AB480 File Offset: 0x000A9680
	public void getlist_from_npc(sbyte idnpc)
	{
		base.init(23);
		try
		{
			this.m.writer().writeByte(idnpc);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A3B RID: 2619 RVA: 0x000AB4D4 File Offset: 0x000A96D4
	public void buy_item(sbyte typebuy, short idbuy, short soluong)
	{
		base.init(24);
		try
		{
			this.m.writer().writeByte(typebuy);
			this.m.writer().writeShort(idbuy);
			this.m.writer().writeShort(soluong);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A3C RID: 2620 RVA: 0x000AB54C File Offset: 0x000A974C
	public void quest(short id, sbyte main_sub, sbyte type)
	{
		base.init(52);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(main_sub);
		}
		catch (Exception ex)
		{
		}
		base.send();
		if (GameScreen.help.setStep_Next(0, -5))
		{
			GameScreen.help.Next++;
			GameScreen.help.SaveStep(0, 0);
			GameScreen.help.setNext();
		}
		else if (GameScreen.help.setStep_Next(8, 10))
		{
			GameCanvas.end_Dialog();
			GameScreen.help.p = null;
			GameScreen.help.NextStep();
			GameScreen.help.setNext();
			GameScreen.help.SaveStep();
		}
	}

	// Token: 0x06000A3D RID: 2621 RVA: 0x000AB640 File Offset: 0x000A9840
	public void Dynamic_Menu(short idNPC, sbyte idMenu, sbyte index)
	{
		base.init(-30);
		try
		{
			this.m.writer().writeShort(idNPC);
			this.m.writer().writeByte(idMenu);
			this.m.writer().writeByte(index);
			Cout.LogError2(string.Concat(new object[]
			{
				" Dynamic_Menu------ ",
				idNPC,
				" id menu ",
				idMenu,
				": index: ",
				index
			}));
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A3E RID: 2622 RVA: 0x000AB6F8 File Offset: 0x000A98F8
	public void Item_More_Info(sbyte inVen_Wear, sbyte id)
	{
		mSystem.outz("yeu cau thaong tin");
		base.init(21);
		try
		{
			this.m.writer().writeByte(inVen_Wear);
			this.m.writer().writeByte(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A3F RID: 2623 RVA: 0x000AB768 File Offset: 0x000A9968
	public void Use_Item(sbyte id, sbyte index)
	{
		base.init(11);
		try
		{
			this.m.writer().writeByte(id);
			this.m.writer().writeByte(index);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A40 RID: 2624 RVA: 0x000AB7CC File Offset: 0x000A99CC
	public void Use_Potion(short id)
	{
		base.init(32);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A41 RID: 2625 RVA: 0x000AB820 File Offset: 0x000A9A20
	public void delete_Item(sbyte type, short id, sbyte typedelete)
	{
		base.init(18);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(typedelete);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A42 RID: 2626 RVA: 0x000AB898 File Offset: 0x000A9A98
	public void Get_Item_Map(short id, sbyte type)
	{
		base.init(20);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A43 RID: 2627 RVA: 0x000AB8FC File Offset: 0x000A9AFC
	public void Add_Base_Skill_Point(sbyte type, sbyte index, short value)
	{
		base.init(22);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(index);
			this.m.writer().writeShort(value);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A44 RID: 2628 RVA: 0x000AB974 File Offset: 0x000A9B74
	public void Add_Base_Skill_Point(sbyte type, sbyte index)
	{
		base.init(22);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(index);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A45 RID: 2629 RVA: 0x000AB9D8 File Offset: 0x000A9BD8
	public void getItemTem(short id)
	{
		base.init(28);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A46 RID: 2630 RVA: 0x000ABA2C File Offset: 0x000A9C2C
	public void gohome(sbyte type)
	{
		base.init(31);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A47 RID: 2631 RVA: 0x000ABA80 File Offset: 0x000A9C80
	public void chatPopup(string chat)
	{
		if (chat == null || chat.Trim().Length == 0)
		{
			return;
		}
		base.init(27);
		try
		{
			this.m.writer().writeUTF(chat);
		}
		catch (Exception ex)
		{
		}
		base.send();
		GameCanvas.msgchat.addNewChat(T.tinden, GameScreen.player.name + ": ", chat, ChatDetail.TYPE_SERVER, false);
	}

	// Token: 0x06000A48 RID: 2632 RVA: 0x000ABB14 File Offset: 0x000A9D14
	public void chatTab(string name, string chat)
	{
		if (name == null || chat == null)
		{
			return;
		}
		base.init(34);
		try
		{
			this.m.writer().writeUTF(name);
			this.m.writer().writeUTF(chat);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A49 RID: 2633 RVA: 0x000ABB88 File Offset: 0x000A9D88
	public void Friend(sbyte type, string name)
	{
		base.init(35);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4A RID: 2634 RVA: 0x000ABBEC File Offset: 0x000A9DEC
	public void Register(string user, string pass)
	{
		base.init(39);
		try
		{
			this.m.writer().writeUTF(user);
			this.m.writer().writeUTF(pass);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4B RID: 2635 RVA: 0x000ABC50 File Offset: 0x000A9E50
	public void Party(sbyte type, string name)
	{
		base.init(48);
		try
		{
			this.m.writer().writeByte(type);
			if ((int)type != 0 && (int)type != 5 && (int)type != 4)
			{
				this.m.writer().writeUTF(name);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4C RID: 2636 RVA: 0x000ABCCC File Offset: 0x000A9ECC
	public void Buy_Sell(sbyte type, string name, sbyte typeItem, short idItem, int money)
	{
		base.init(36);
		try
		{
			this.m.writer().writeByte(type);
			switch (type)
			{
			case 0:
			case 1:
				this.m.writer().writeUTF(name);
				break;
			case 2:
			case 3:
				this.m.writer().writeByte(typeItem);
				this.m.writer().writeShort(idItem);
				break;
			case 7:
				this.m.writer().writeInt(money);
				break;
			case 9:
				this.m.writer().writeUTF(name);
				break;
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4D RID: 2637 RVA: 0x000ABDC4 File Offset: 0x000A9FC4
	public void BuffMore(sbyte type, sbyte tem, mVector vec)
	{
		base.init(40);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(tem);
			this.m.writer().writeByte(vec.size());
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				this.m.writer().writeShort(object_Effect_Skill.ID);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4E RID: 2638 RVA: 0x000ABE78 File Offset: 0x000AA078
	public void fire_Pk(mVector vec, sbyte typekill)
	{
		base.init(6);
		try
		{
			this.m.writer().writeByte(typekill);
			this.m.writer().writeByte(vec.size());
			for (int i = 0; i < vec.size(); i++)
			{
				Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)vec.elementAt(i);
				this.m.writer().writeShort(object_Effect_Skill.ID);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A4F RID: 2639 RVA: 0x000ABF1C File Offset: 0x000AA11C
	public void set_Pk(sbyte pk)
	{
		base.init(42);
		try
		{
			this.m.writer().writeByte(pk);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A50 RID: 2640 RVA: 0x000ABF70 File Offset: 0x000AA170
	public void Re_Info_Other_Object(string name, sbyte type)
	{
		base.init(49);
		try
		{
			this.m.writer().writeUTF(name);
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A51 RID: 2641 RVA: 0x000ABFD4 File Offset: 0x000AA1D4
	public void Change_Area(sbyte area)
	{
		base.init(51);
		try
		{
			this.m.writer().writeByte(area);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A52 RID: 2642 RVA: 0x000AC028 File Offset: 0x000AA228
	public void Request_Area()
	{
		base.init(54);
		try
		{
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A53 RID: 2643 RVA: 0x000AC06C File Offset: 0x000AA26C
	public void Save_RMS_Server(sbyte type, sbyte id, sbyte[] mdata)
	{
		base.init(55);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(id);
			int num = 0;
			if (mdata != null)
			{
				num = mdata.Length;
			}
			this.m.writer().writeShort(num);
			for (int i = 0; i < num; i++)
			{
				this.m.writer().writeByte(mdata[i]);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A54 RID: 2644 RVA: 0x000AC114 File Offset: 0x000AA314
	public void set_Page(sbyte page)
	{
		base.init(56);
		try
		{
			this.m.writer().writeByte(page);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A55 RID: 2645 RVA: 0x000AC168 File Offset: 0x000AA368
	public void chat_npc(sbyte idnpc)
	{
		base.init(60);
		try
		{
			this.m.writer().writeByte(idnpc);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A56 RID: 2646 RVA: 0x000AC1BC File Offset: 0x000AA3BC
	public void Mon_Capchar(sbyte num)
	{
		base.init(-28);
		try
		{
			this.m.writer().writeByte(PaintInfoGameScreen.mValueHotKey[(int)num]);
			mSystem.outloi("so goi len" + num);
		}
		catch (Exception ex)
		{
		}
		base.send();
		int num2 = MainObject.vecCapchar.size();
		if (num2 == 5)
		{
			MainObject.vecCapchar.removeElementAt(0);
		}
		if (Main.isPC && TField.isQwerty)
		{
			MainObject.vecCapchar.addElement(string.Empty + PaintInfoGameScreen.mValueChar[(int)num]);
		}
		else
		{
			MainObject.vecCapchar.addElement(string.Empty + PaintInfoGameScreen.mValueHotKey[(int)num]);
		}
		MainObject.strCapchar = string.Empty;
		for (int i = 0; i < MainObject.vecCapchar.size(); i++)
		{
			MainObject.strCapchar += MainObject.vecCapchar.elementAt(i);
		}
	}

	// Token: 0x06000A57 RID: 2647 RVA: 0x000AC2E0 File Offset: 0x000AA4E0
	public void Update_Char_Chest(sbyte type, short id, sbyte tem, short num)
	{
		base.init(65);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(tem);
			this.m.writer().writeShort(num);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A58 RID: 2648 RVA: 0x000AC368 File Offset: 0x000AA568
	public void Update_Pet_Container(sbyte type, short id, sbyte tem, short num)
	{
		base.init(44);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(tem);
			this.m.writer().writeShort(num);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A59 RID: 2649 RVA: 0x000AC3F0 File Offset: 0x000AA5F0
	public void dialog_Server(short id, sbyte type, sbyte value)
	{
		base.init(-32);
		try
		{
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(value);
			Cout.LogWarning(string.Concat(new object[]
			{
				" thong tin : ",
				id,
				" type: ",
				type,
				" value: ",
				value
			}));
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5A RID: 2650 RVA: 0x000AC4A8 File Offset: 0x000AA6A8
	public void send_cmd_server(sbyte cmd)
	{
		base.init(cmd);
		try
		{
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5B RID: 2651 RVA: 0x000AC4EC File Offset: 0x000AA6EC
	public void Rebuild_Item(sbyte type, short id, sbyte tem)
	{
		base.init(67);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(tem);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5C RID: 2652 RVA: 0x000AC564 File Offset: 0x000AA764
	public void KhamNgoc(sbyte type, int idItem, int idG1, int idG2, int idG3)
	{
		base.init(-100);
		try
		{
			switch (type)
			{
			case 0:
				this.m.writer().writeByte(type);
				this.m.writer().writeShort(idItem);
				this.m.writer().writeShort(idG1);
				this.m.writer().writeShort(idG2);
				this.m.writer().writeShort(idG3);
				break;
			case 1:
				this.m.writer().writeByte(type);
				this.m.writer().writeShort(idItem);
				break;
			case 2:
				this.m.writer().writeByte(type);
				this.m.writer().writeShort(idItem);
				this.m.writer().writeShort(idG1);
				break;
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5D RID: 2653 RVA: 0x000AC680 File Offset: 0x000AA880
	public void Replace_Item(sbyte type, short id)
	{
		base.init(73);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			mSystem.outz("id goi=" + id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5E RID: 2654 RVA: 0x000AC6FC File Offset: 0x000AA8FC
	public void useMount(sbyte type)
	{
		base.init(-97);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A5F RID: 2655 RVA: 0x000AC750 File Offset: 0x000AA950
	public void Thach_Dau(sbyte type, string name)
	{
		base.init(68);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A60 RID: 2656 RVA: 0x000AC7B4 File Offset: 0x000AA9B4
	public void NextClan(sbyte type)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A61 RID: 2657 RVA: 0x000AC808 File Offset: 0x000AAA08
	public void InvenClan(sbyte type)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A62 RID: 2658 RVA: 0x000AC85C File Offset: 0x000AAA5C
	public void Add_And_AnS_MemClan(sbyte type, string name)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A63 RID: 2659 RVA: 0x000AC8C0 File Offset: 0x000AAAC0
	public void ChucNang_Clan(sbyte type, int id)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeInt(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A64 RID: 2660 RVA: 0x000AC924 File Offset: 0x000AAB24
	public void gop_Xu_Luong_Clan(sbyte type, int num)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeInt(num);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A65 RID: 2661 RVA: 0x000AC988 File Offset: 0x000AAB88
	public void info_Mem_Clan(sbyte type, string name)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A66 RID: 2662 RVA: 0x000AC9EC File Offset: 0x000AABEC
	public void PhongCap_Clan(sbyte type, sbyte chucvu, string str)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(chucvu);
			this.m.writer().writeUTF(str);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A67 RID: 2663 RVA: 0x000ACA64 File Offset: 0x000AAC64
	public void Delete_Mem_Clan(sbyte type, string name)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A68 RID: 2664 RVA: 0x000ACAC8 File Offset: 0x000AACC8
	public void Change_Slo_NoiQuy_Clan(sbyte type, string name)
	{
		base.init(69);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A69 RID: 2665 RVA: 0x000ACB2C File Offset: 0x000AAD2C
	public void Chat_World(string name)
	{
		base.init(71);
		try
		{
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6A RID: 2666 RVA: 0x000ACB80 File Offset: 0x000AAD80
	public void Rebuild_Wing(sbyte type, int wing, short id)
	{
		base.init(77);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeInt(wing);
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6B RID: 2667 RVA: 0x000ACBF8 File Offset: 0x000AADF8
	public void UpdateData()
	{
		base.init(-57);
		try
		{
			this.m.writer().writeByte((int)GameCanvas.IndexCharPar);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6C RID: 2668 RVA: 0x000ACC50 File Offset: 0x000AAE50
	public void Pet_Eat(short idpet, short iditem, sbyte cat, sbyte type)
	{
		base.init(45);
		try
		{
			this.m.writer().writeShort(idpet);
			this.m.writer().writeShort(iditem);
			this.m.writer().writeByte(cat);
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6D RID: 2669 RVA: 0x000ACCD8 File Offset: 0x000AAED8
	public void Update_Pet_Eat(sbyte type, short id)
	{
		base.init(44);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6E RID: 2670 RVA: 0x000ACD3C File Offset: 0x000AAF3C
	public void doPaymentNokia(string content)
	{
		base.init(-76);
		try
		{
			this.m.writer().writeUTF(content);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A6F RID: 2671 RVA: 0x000ACD90 File Offset: 0x000AAF90
	public void request_LotteryItems(sbyte step, sbyte idSelectedItem)
	{
		base.init(-91);
		try
		{
			this.m.writer().writeByte(step);
			if ((int)step == 1)
			{
				this.m.writer().writeByte(idSelectedItem);
			}
			else if ((int)step == 2)
			{
				this.m.writer().writeByte(idSelectedItem);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A70 RID: 2672 RVA: 0x000ACE1C File Offset: 0x000AB01C
	public void DoKhacItem(sbyte type, sbyte cat, short iditem)
	{
		base.init(-91);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeByte(cat);
			this.m.writer().writeShort(iditem);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A71 RID: 2673 RVA: 0x000ACE94 File Offset: 0x000AB094
	public void sendMoreServerInfo(short idNPC, short idMenu, mVector minfo)
	{
		base.init(-31);
		try
		{
			this.m.writer().writeShort(idNPC);
			this.m.writer().writeShort(idMenu);
			byte b = (byte)minfo.size();
			this.m.writer().writeByte((int)b);
			for (int i = 0; i < (int)b; i++)
			{
				string value = (string)minfo.elementAt(i);
				this.m.writer().writeUTF(value);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A72 RID: 2674 RVA: 0x000ACF44 File Offset: 0x000AB144
	public void sendMoreServerInfo(short idNPC, short idMenu, string[] minfo)
	{
		base.init(-31);
		try
		{
			this.m.writer().writeShort(idNPC);
			this.m.writer().writeShort(idMenu);
			byte b = (byte)minfo.Length;
			this.m.writer().writeByte((int)b);
			for (int i = 0; i < (int)b; i++)
			{
				this.m.writer().writeUTF(minfo[i]);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A73 RID: 2675 RVA: 0x000ACFE4 File Offset: 0x000AB1E4
	public void arena(sbyte step)
	{
		base.init(37);
		try
		{
			this.m.writer().writeByte(step);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A74 RID: 2676 RVA: 0x000AD038 File Offset: 0x000AB238
	public void doSendThachDau(sbyte type, string name)
	{
		base.init(-101);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeUTF(name);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A75 RID: 2677 RVA: 0x000AD09C File Offset: 0x000AB29C
	public void useShip(sbyte index)
	{
		base.init(-98);
		try
		{
			this.m.writer().writeByte(index);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A76 RID: 2678 RVA: 0x000AD0F0 File Offset: 0x000AB2F0
	public void do_Buy_Sell_Item(int type, mVector vec, string slogan, short idChar, int iditem, sbyte cat)
	{
		base.init(-102);
		try
		{
			this.m.writer().writeByte(type);
			switch (type)
			{
			case 0:
				this.m.writer().writeByte(vec.size());
				for (int i = 0; i < vec.size(); i++)
				{
					item_sell item_sell = (item_sell)vec.elementAt(i);
					if (item_sell != null)
					{
						this.m.writer().writeShort(item_sell.id);
						this.m.writer().writeInt(item_sell.price);
						this.m.writer().writeShort(item_sell.soluuong);
						this.m.writer().writeByte(item_sell.cat);
					}
				}
				this.m.writer().writeUTF(slogan);
				break;
			case 1:
				this.m.writer().writeShort(idChar);
				break;
			case 2:
				this.m.writer().writeShort(iditem);
				this.m.writer().writeShort(idChar);
				this.m.writer().writeByte(cat);
				break;
			case 5:
				this.m.writer().writeShort(idChar);
				this.m.writer().writeShort(iditem);
				break;
			}
			base.send();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000A77 RID: 2679 RVA: 0x000AD294 File Offset: 0x000AB494
	public void RequestInfo_MiNuong(sbyte type, short id)
	{
		base.init(-103);
		try
		{
			this.m.writer().writeByte(type);
			if (type == 0)
			{
				this.m.writer().writeShort(id);
			}
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A78 RID: 2680 RVA: 0x000AD310 File Offset: 0x000AB510
	public void RequestMaterialTemplate(short id)
	{
		base.init(-106);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A79 RID: 2681 RVA: 0x000AD364 File Offset: 0x000AB564
	public void Hop_rac(sbyte type, short id, sbyte tem)
	{
		base.init(-105);
		try
		{
			this.m.writer().writeByte(type);
			this.m.writer().writeShort(id);
			this.m.writer().writeByte(tem);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A7A RID: 2682 RVA: 0x000AD3DC File Offset: 0x000AB5DC
	public void Hop_rac(sbyte type)
	{
		base.init(-105);
		try
		{
			this.m.writer().writeByte(type);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A7B RID: 2683 RVA: 0x000AD430 File Offset: 0x000AB630
	public void doUseMaterial(short id)
	{
		base.init(-107);
		try
		{
			this.m.writer().writeShort(id);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A7C RID: 2684 RVA: 0x000AD484 File Offset: 0x000AB684
	public void doNapple(sbyte typeSandbox, string receipt, string productId)
	{
		base.init(-109);
		try
		{
			this.m.writer().writeByte(typeSandbox);
			this.m.writer().writeUTF(receipt);
			this.m.writer().writeUTF(productId);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x06000A7D RID: 2685 RVA: 0x000AD4FC File Offset: 0x000AB6FC
	public void doSendNewInapp(string productId, string token, string orderID)
	{
		base.init(-75);
		try
		{
			this.m.writer().writeUTF(productId);
			this.m.writer().writeUTF(token);
			this.m.writer().writeUTF(orderID);
		}
		catch (Exception ex)
		{
		}
		base.send();
	}

	// Token: 0x040011E4 RID: 4580
	protected static GlobalService instance;
}
