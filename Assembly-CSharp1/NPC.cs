using System;

// Token: 0x02000064 RID: 100
public class NPC : MainObject
{
	// Token: 0x060004C7 RID: 1223 RVA: 0x00043474 File Offset: 0x00041674
	public NPC(string name, string namegt, sbyte IDItem, sbyte IDImage, short x, short y, sbyte wBlock, sbyte hBlock, sbyte nFrame)
	{
		this.name = name;
		this.nameGiaotiep = namegt;
		this.ID = (int)IDItem;
		this.idImage = (short)IDImage;
		this.x = (int)(x + 12);
		this.y = (int)y;
		this.wBlock = (short)wBlock;
		this.hBlock = (short)hBlock;
		this.nFrame = (int)nFrame;
		this.hp = 100;
		this.maxHp = 100;
		this.ysai = 0;
		GameCanvas.loadmap.setBlockNPC((int)x, (int)(y - 24), (int)wBlock, (int)hBlock);
		this.setPlaySound();
	}

	// Token: 0x060004C8 RID: 1224 RVA: 0x00043518 File Offset: 0x00041718
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

	// Token: 0x060004C9 RID: 1225 RVA: 0x00043644 File Offset: 0x00041844
	public override void paint(mGraphics g)
	{
		if (this.idImage != -1)
		{
			MainImage imagePartNPC = ObjectData.getImagePartNPC(this.idImage);
			if (imagePartNPC.img != null)
			{
				if (this.wOne == 0)
				{
					this.hOne = mImage.getImageHeight(imagePartNPC.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imagePartNPC.img.image);
				}
				g.drawRegion(imagePartNPC.img, 0, GameCanvas.gameTick / 7 % this.nFrame * this.hOne, this.wOne, this.hOne, 0, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
			}
		}
		if (GameScreen.ObjFocus == null || (GameScreen.ObjFocus != null && this != GameScreen.ObjFocus) || PaintInfoGameScreen.isLevelPoint)
		{
			this.paintName(g, 0);
		}
	}

	// Token: 0x060004CA RID: 1226 RVA: 0x00043730 File Offset: 0x00041930
	public override void update()
	{
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
		if (this.isMonPhoBangDie && this.timeFreeMove < 70)
		{
			this.timeFreeMove++;
			if (CRes.random(3) == 1)
			{
				if (CRes.random(2) == 1)
				{
					LoadMap.timeVibrateScreen = 103;
				}
				int num = CRes.random(1, 3);
				for (int i = 0; i < num; i++)
				{
					int num2 = CRes.random_Am_0(25);
					int num3 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, this.x + num2, this.y + num3 - this.hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, this.x + num2, this.y + num3 - this.hOne / 2);
					}
				}
			}
			if (this.timeFreeMove >= 70)
			{
				for (int j = 0; j < 6; j++)
				{
					int num4 = CRes.random_Am_0(25);
					int num5 = CRes.random_Am_0(30);
					GameScreen.addEffectEndKill(36, this.x + num4, this.y + num5 - this.hOne / 2);
					if (CRes.random(3) == 1)
					{
						GameScreen.addEffectEndKill(9, this.x + num4, this.y + num5 - this.hOne / 2);
					}
				}
				GameScreen.addEffectKill(81, this.x, this.y - 20, 200, 0, 0);
				this.isRemove = true;
				this.isMonPhoBangDie = false;
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

	// Token: 0x060004CB RID: 1227 RVA: 0x00043970 File Offset: 0x00041B70
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

	// Token: 0x060004CC RID: 1228 RVA: 0x00043A54 File Offset: 0x00041C54
	public override void paintBigAvatar(mGraphics g, int x, int y)
	{
		MainImage imagePartNPC = ObjectData.getImagePartNPC((short)this.IdBigAvatar);
		if (imagePartNPC.img != null)
		{
			g.drawImage(imagePartNPC.img, x, y, mGraphics.BOTTOM | mGraphics.RIGHT, mGraphics.isFalse);
		}
	}

	// Token: 0x060004CD RID: 1229 RVA: 0x00043A98 File Offset: 0x00041C98
	public override bool isNPC()
	{
		return true;
	}

	// Token: 0x060004CE RID: 1230 RVA: 0x00043A9C File Offset: 0x00041C9C
	public override void GiaoTiep()
	{
		MainObject.resetDirection(GameScreen.player, this);
		if ((int)this.isPerson == 0)
		{
			GlobalService.gI().getlist_from_npc((sbyte)this.ID);
			return;
		}
		mVector mVector = new mVector("NPC menu");
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

	// Token: 0x060004CF RID: 1231 RVA: 0x00043B48 File Offset: 0x00041D48
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

	// Token: 0x060004D0 RID: 1232 RVA: 0x00043C60 File Offset: 0x00041E60
	public void NhiemVu()
	{
		mVector mVector = new mVector("NPC menu2");
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

	// Token: 0x060004D1 RID: 1233 RVA: 0x00043E68 File Offset: 0x00042068
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

	// Token: 0x060004D2 RID: 1234 RVA: 0x00043EE4 File Offset: 0x000420E4
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

	// Token: 0x040006C8 RID: 1736
	public short idImage;

	// Token: 0x040006C9 RID: 1737
	public short wBlock;

	// Token: 0x040006CA RID: 1738
	public short hBlock;

	// Token: 0x040006CB RID: 1739
	private int nFrame;

	// Token: 0x040006CC RID: 1740
	private int wAvatar;

	// Token: 0x040006CD RID: 1741
	private int hAvatar;

	// Token: 0x040006CE RID: 1742
	private int indexSound = -1;

	// Token: 0x040006CF RID: 1743
	private int timePlaySound = -1;
}
