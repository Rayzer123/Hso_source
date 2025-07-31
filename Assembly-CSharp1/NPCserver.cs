using System;

// Token: 0x02000066 RID: 102
public class NPCserver : MainObject
{
	// Token: 0x060004D4 RID: 1236 RVA: 0x00043F74 File Offset: 0x00042174
	public NPCserver(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
		this.idImage = (short)idNPC;
		this.x = (int)xNPC;
		this.y = (int)yNPC;
		this.dx = (int)dxNPC;
		this.dy = (int)dyNPC;
		this.nFrame = (int)nFrameNPC;
		this.name = nameNPC;
		this.nameGiaotiep = nameGiaoTiep;
		this.wBlock = (short)wBlockNPC;
		this.hBlock = (short)hBlockNPC;
		this.xBlock = xBlockNPC;
		this.yBlock = yBlockNPC;
		this.isStop = false;
		this.isRemove = false;
		string path = "npc_server" + this.idImage;
		this.imgSub = mImage.createImage(ImageData, 0, ImageData.Length, path);
		this.imgSubFrame = new FrameImage(this.imgSub, mImage.getImageWidth(this.imgSub.image), mImage.getImageHeight(this.imgSub.image) / this.nFrame);
		this.frameArray = frameArray;
		GameCanvas.loadmap.setBlockNPC_Server((int)(this.xBlock - 12), (int)this.yBlock, (int)this.wBlock, (int)this.hBlock);
		if ((int)this.idImage != (int)this.idnotFocus)
		{
			this.p = new Other_Players((int)this.idImage, 0, this.name, this.x, this.y);
			this.p.clazz = 1;
			this.p.Direction = 0;
			this.p.setInfo((int)wearing[12], (int)wearing[13], (int)wearing[14]);
			this.p.setWearingEquip(wearing);
			MiniMap.addNPCMini(new NPCMini((int)idNPC, this.x, this.y));
			this.setPlaySound();
			this.p.x = this.x + this.dx;
			this.p.y = this.y + this.dy;
			this.p.toX = this.p.x;
			this.p.toY = this.p.y;
			this.hOne = mImage.getImageHeight(this.imgSub.image) + this.p.hOne - 10;
			this.hp = 100;
			this.maxHp = 100;
			this.Lv = 1;
		}
	}

	// Token: 0x060004D5 RID: 1237 RVA: 0x000441CC File Offset: 0x000423CC
	public override void setInfo(sbyte idNPC, short xNPC, short yNPC, sbyte dxNPC, sbyte dyNPC, sbyte nFrameNPC, string nameGiaoTiep, string nameNPC, short xBlockNPC, short yBlockNPC, sbyte wBlockNPC, sbyte hBlockNPC, sbyte[] wearing, sbyte[] ImageData, sbyte[] frameArray)
	{
		this.p = null;
		this.imgSub = null;
		this.imgSubFrame = null;
		this.idImage = (short)idNPC;
		this.x = (int)xNPC;
		this.y = (int)yNPC;
		this.dx = (int)dxNPC;
		this.dy = (int)dyNPC;
		this.nFrame = (int)nFrameNPC;
		this.name = nameNPC;
		this.nameGiaotiep = nameGiaoTiep;
		this.wBlock = (short)wBlockNPC;
		this.hBlock = (short)hBlockNPC;
		this.xBlock = xBlockNPC;
		this.yBlock = yBlockNPC;
		this.isStop = false;
		this.isRemove = false;
		string path = "npc_server" + this.idImage;
		this.imgSub = mImage.createImage(ImageData, 0, ImageData.Length, path);
		this.imgSubFrame = new FrameImage(this.imgSub, mImage.getImageWidth(this.imgSub.image), mImage.getImageHeight(this.imgSub.image) / this.nFrame);
		this.frameArray = frameArray;
		GameCanvas.loadmap.setBlockNPC_Server((int)(this.xBlock - 12), (int)this.yBlock, (int)this.wBlock, (int)this.hBlock);
		if ((int)this.idImage != (int)this.idnotFocus)
		{
			this.p = new Other_Players((int)this.idImage, 0, this.name, this.x, this.y);
			this.p.clazz = 1;
			this.p.Direction = 0;
			this.p.setInfo((int)wearing[12], (int)wearing[13], (int)wearing[14]);
			this.p.setWearingEquip(wearing);
			MiniMap.addNPCMini(new NPCMini((int)idNPC, this.x, this.y));
			this.setPlaySound();
			this.p.x = this.x + this.dx;
			this.p.y = this.y + this.dy;
			this.p.toX = this.p.x;
			this.p.toY = this.p.y;
			this.hOne = mImage.getImageHeight(this.imgSub.image) + this.p.hOne - 10;
		}
	}

	// Token: 0x060004D6 RID: 1238 RVA: 0x00044404 File Offset: 0x00042604
	public override void paint(mGraphics g)
	{
		if (this.imgSubFrame != null)
		{
			this.imgSubFrame.drawFrame((int)this.frameArray[(int)this.f], this.x, this.y, 0, mGraphics.BOTTOM | mGraphics.HCENTER, g);
		}
		if (this.p != null)
		{
			this.p.paint(g);
			this.paintName(g, 2);
		}
	}

	// Token: 0x060004D7 RID: 1239 RVA: 0x00044470 File Offset: 0x00042670
	public override void paintName(mGraphics g, int id)
	{
		mFont mFont = mFont.tahoma_7_white;
		mFont = MainTabNew.setTextColor(id);
		mFont.drawString(g, this.nameGiaotiep, this.p.x, this.p.y - 70, 2, mGraphics.isFalse);
	}

	// Token: 0x060004D8 RID: 1240 RVA: 0x000444B8 File Offset: 0x000426B8
	public override void update()
	{
		this.f += 1;
		if ((int)this.f > this.frameArray.Length - 1)
		{
			this.f = 0;
		}
		if (this.strChatPopup != null)
		{
			base.addChat(this.strChatPopup, true);
			this.strChatPopup = null;
		}
		if (this.chat != null)
		{
			this.chat.updatePos(this.x, this.y - this.hOne - 30);
			if (this.chat.setOff())
			{
				this.chat = null;
			}
		}
		if (this.indexSound >= 0 && GameCanvas.gameTick % this.timePlaySound == 0 && MainObject.isInScreen(this))
		{
			if (this.indexSound == 44)
			{
				if (this.getCountPlayerINearMe() >= 5)
				{
					mSound.playSound(this.indexSound, mSound.volumeSound);
				}
			}
			else
			{
				mSound.playSound(this.indexSound, mSound.volumeSound);
			}
		}
	}

	// Token: 0x060004D9 RID: 1241 RVA: 0x000445BC File Offset: 0x000427BC
	public override void paintAvatarFocus(mGraphics g, int x, int y)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC(this.idImage);
		if (imagePartNPC.img != null)
		{
			if (this.wAvatar <= 0)
			{
				if (this.wOne < 0)
				{
					this.hOne = mImage.getImageHeight(imagePartNPC.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imagePartNPC.img.image);
				}
				this.wAvatar = this.wOne;
				this.hAvatar = this.hOne;
				if (this.wAvatar > 26)
				{
					this.wAvatar = 26;
				}
				if (this.hAvatar > 26)
				{
					this.hAvatar = 26;
				}
			}
			g.drawRegion(imagePartNPC.img, this.wOne / 2 - this.wAvatar / 2, 0, this.wAvatar, this.hAvatar, 0, x, y, 3, mGraphics.isFalse);
		}
	}

	// Token: 0x060004DA RID: 1242 RVA: 0x000446A0 File Offset: 0x000428A0
	public override void paintBigAvatar(mGraphics g, int x, int y)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC((short)this.IdBigAvatar);
		if (imagePartNPC.img != null)
		{
			g.drawImage(imagePartNPC.img, x, y, mGraphics.BOTTOM | mGraphics.RIGHT, mGraphics.isFalse);
		}
	}

	// Token: 0x060004DB RID: 1243 RVA: 0x000446E4 File Offset: 0x000428E4
	public override bool canFocus()
	{
		return (int)this.idImage != (int)this.idnotFocus;
	}

	// Token: 0x060004DC RID: 1244 RVA: 0x000446F8 File Offset: 0x000428F8
	public override bool isNPC()
	{
		return (int)this.idImage != (int)this.idnotFocus;
	}

	// Token: 0x060004DD RID: 1245 RVA: 0x0004470C File Offset: 0x0004290C
	public override void paintNameFocus(mGraphics g)
	{
	}

	// Token: 0x060004DE RID: 1246 RVA: 0x00044710 File Offset: 0x00042910
	public override bool isNPC_server()
	{
		return true;
	}

	// Token: 0x060004DF RID: 1247 RVA: 0x00044714 File Offset: 0x00042914
	public override int getIDnpc()
	{
		return (int)this.idImage;
	}

	// Token: 0x060004E0 RID: 1248 RVA: 0x0004471C File Offset: 0x0004291C
	public override void GiaoTiep()
	{
		if (this.isNPC())
		{
			MainObject.resetDirection(GameScreen.player, this);
			if ((int)this.isPerson == 0)
			{
				GlobalService.gI().getlist_from_npc((sbyte)this.getIDnpc());
				return;
			}
			mVector mVector = new mVector("NPCserver menu");
			if (this.nameGiaotiep.Length > 0)
			{
				iCommand o = new iCommand(this.nameGiaotiep, 4, this);
				mVector.addElement(o);
			}
			if (this.checkNV())
			{
				iCommand o2 = new iCommand(T.quest, 5, this);
				mVector.addElement(o2);
			}
			GameCanvas.menu2.startAt_NPC(mVector, this.infoObject, this.ID, 2, false, 0);
			mSound.playSound(39, mSound.volumeSound);
		}
	}

	// Token: 0x060004E1 RID: 1249 RVA: 0x000447D4 File Offset: 0x000429D4
	public bool checkNV()
	{
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == this.ID)
			{
				return true;
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == this.ID)
			{
				return true;
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == this.ID)
			{
				return true;
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == this.ID)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060004E2 RID: 1250 RVA: 0x000448EC File Offset: 0x00042AEC
	public void NhiemVu()
	{
		mVector mVector = new mVector("NPCserver menu2");
		for (int i = 0; i < MainQuest.vecQuestList.size(); i++)
		{
			MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(i);
			if (mainQuest.idNPC_From == this.ID)
			{
				iCommand iCommand = new iCommand(mainQuest.name, 0, i, this);
				iCommand.setFraCaption(AvMain.fraQuest, 1, 1);
				mVector.addElement(iCommand);
			}
		}
		for (int j = 0; j < MainQuest.vecQuestFinish.size(); j++)
		{
			MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(j);
			if (mainQuest2.idNPC_To == this.ID)
			{
				iCommand iCommand2 = new iCommand(mainQuest2.name, 1, j, this);
				iCommand2.setFraCaption(AvMain.fraQuest, 1, 3);
				mVector.addElement(iCommand2);
			}
		}
		for (int k = 0; k < MainQuest.vecQuestDoing_Main.size(); k++)
		{
			MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(k);
			if (mainQuest3.idNPC_To == this.ID)
			{
				iCommand iCommand3 = new iCommand(mainQuest3.name, 2, k, this);
				iCommand3.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector.addElement(iCommand3);
			}
		}
		for (int l = 0; l < MainQuest.vecQuestDoing_Sub.size(); l++)
		{
			MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(l);
			if (mainQuest4.idNPC_To == this.ID)
			{
				iCommand iCommand4 = new iCommand(mainQuest4.name, 3, l, this);
				iCommand4.setFraCaption(AvMain.fraQuest, 1, 2);
				mVector.addElement(iCommand4);
			}
		}
		if (mVector.size() == 0)
		{
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.doCloseMenu();
		}
		else
		{
			GameCanvas.menu2.doCloseMenu();
			GameCanvas.clearKeyHold();
			GameCanvas.clearKeyPressed();
			GameCanvas.menu2.startAt(mVector, 2, T.quest, false, null);
		}
	}

	// Token: 0x060004E3 RID: 1251 RVA: 0x00044AF4 File Offset: 0x00042CF4
	public void setPlaySound()
	{
		int id = this.ID;
		switch (id + 5)
		{
		case 0:
			break;
		default:
			if (id != -21)
			{
				if (id != -20 && id != -36)
				{
					return;
				}
				goto IL_50;
			}
			break;
		case 2:
			goto IL_50;
		}
		this.indexSound = 43;
		this.timePlaySound = 150;
		return;
		IL_50:
		this.indexSound = 44;
		this.timePlaySound = 150;
	}

	// Token: 0x060004E4 RID: 1252 RVA: 0x00044B70 File Offset: 0x00042D70
	public int getCountPlayerINearMe()
	{
		int num = 0;
		for (int i = 0; i < GameScreen.Vecplayers.size(); i++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(i);
			if ((int)mainObject.typeObject == 0 && MainObject.getDistance(this.x, this.y, mainObject.x, mainObject.y) <= 120)
			{
				num++;
			}
		}
		return num;
	}

	// Token: 0x060004E5 RID: 1253 RVA: 0x00044BE0 File Offset: 0x00042DE0
	public override void commandPointer(int index, int subIndex)
	{
		switch (index)
		{
		case 0:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestList.size())
			{
				MainQuest mainQuest = (MainQuest)MainQuest.vecQuestList.elementAt(subIndex);
				mainQuest.beginQuest();
			}
			break;
		case 1:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestFinish.size())
			{
				MainQuest mainQuest2 = (MainQuest)MainQuest.vecQuestFinish.elementAt(subIndex);
				mainQuest2.beginQuest();
			}
			break;
		case 2:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Main.size())
			{
				MainQuest mainQuest3 = (MainQuest)MainQuest.vecQuestDoing_Main.elementAt(subIndex);
				mainQuest3.show_Info_Quest_Doing();
			}
			break;
		case 3:
			if (subIndex >= 0 && subIndex <= MainQuest.vecQuestDoing_Sub.size())
			{
				MainQuest mainQuest4 = (MainQuest)MainQuest.vecQuestDoing_Sub.elementAt(subIndex);
				mainQuest4.show_Info_Quest_Doing();
			}
			break;
		case 4:
			GlobalService.gI().getlist_from_npc((sbyte)this.ID);
			break;
		case 5:
			this.NhiemVu();
			break;
		}
		base.commandPointer(index, subIndex);
	}

	// Token: 0x040006D4 RID: 1748
	public short idImage;

	// Token: 0x040006D5 RID: 1749
	public short wBlock;

	// Token: 0x040006D6 RID: 1750
	public short hBlock;

	// Token: 0x040006D7 RID: 1751
	public short xBlock;

	// Token: 0x040006D8 RID: 1752
	public short yBlock;

	// Token: 0x040006D9 RID: 1753
	private int nFrame;

	// Token: 0x040006DA RID: 1754
	private int wAvatar;

	// Token: 0x040006DB RID: 1755
	private int hAvatar;

	// Token: 0x040006DC RID: 1756
	private int indexSound = -1;

	// Token: 0x040006DD RID: 1757
	private int timePlaySound = -1;

	// Token: 0x040006DE RID: 1758
	private new int dx;

	// Token: 0x040006DF RID: 1759
	private new int dy;

	// Token: 0x040006E0 RID: 1760
	private Other_Players p;

	// Token: 0x040006E1 RID: 1761
	private mImage imgSub;

	// Token: 0x040006E2 RID: 1762
	private FrameImage imgSubFrame;

	// Token: 0x040006E3 RID: 1763
	private sbyte idnotFocus = sbyte.MaxValue;

	// Token: 0x040006E4 RID: 1764
	private sbyte[] frameArray;

	// Token: 0x040006E5 RID: 1765
	private new sbyte f;
}
