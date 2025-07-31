using System;

// Token: 0x0200008F RID: 143
public class ChatDetail
{
	// Token: 0x060006EC RID: 1772 RVA: 0x000695D8 File Offset: 0x000677D8
	public ChatDetail(string name, sbyte type)
	{
		this.name = name;
		this.typeChat = type;
		if ((int)this.typeChat == (int)ChatDetail.TYPE_CHAT)
		{
			this.tfchat = new TField(GameCanvas.msgchat.xDia + 5, GameCanvas.msgchat.yDia + GameCanvas.msgchat.hDia - (TField.getHeight() + 5), GameCanvas.msgchat.wDia - 10);
			this.tfchat.isCloseKey = false;
		}
		else if ((int)this.typeChat == (int)ChatDetail.TYPE_ADDFRIEND)
		{
			this.friend = name;
			this.name = T.addFriend;
		}
		if (name.CompareTo(T.tabBangHoi) == 0 || name.CompareTo(T.tinden) == 0 || name.CompareTo(T.tabThuLinh) == 0)
		{
			this.typeColorChat = 1;
		}
		else
		{
			this.typeColorChat = 0;
		}
	}

	// Token: 0x060006EE RID: 1774 RVA: 0x000696EC File Offset: 0x000678EC
	public void addString(string str, string nametext)
	{
		if (str.Length > 0)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(str, GameCanvas.msgchat.wDia - GameCanvas.msgchat.wOne5 * 2 - 8);
			MainTextChat[] array2 = this.addChatNew(array, this.setColorText(nametext));
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					this.vecDetail.addElement(array2[i]);
				}
			}
			this.setLim();
			if (this.limY > 0 && GameCanvas.subDialog != null && GameCanvas.subDialog == GameCanvas.msgchat && MsgChat.curentfocus != null && MsgChat.curentfocus == this)
			{
				GameCanvas.msgchat.updateCameraNew(array.Length);
			}
			if (MsgChat.curentfocus != null && MsgChat.curentfocus != this && this.name.CompareTo(T.tinden) != 0)
			{
				this.isNew = true;
				this.timeNew = (sbyte)CRes.random(1, 11);
			}
		}
	}

	// Token: 0x060006EF RID: 1775 RVA: 0x000697F0 File Offset: 0x000679F0
	public void addStartChat(string nametext)
	{
		string text = string.Empty;
		if (this.tfchat != null)
		{
			text = newinput.input.text;
		}
		if (text.Length > 0)
		{
			string[] array = mFont.tahoma_7_white.splitFontArray(GameScreen.player.name + ": " + text, GameCanvas.msgchat.wDia - GameCanvas.msgchat.wOne5 * 2 - 8);
			MainTextChat[] array2 = this.addChatNew(array, this.setColorText(nametext));
			if (array2 != null)
			{
				for (int i = 0; i < array2.Length; i++)
				{
					this.vecDetail.addElement(array2[i]);
				}
			}
			this.setLim();
			if (MsgChat.curentfocus != null && MsgChat.curentfocus == this)
			{
				GameCanvas.msgchat.updateCameraNew(array.Length);
			}
			GlobalService.gI().chatTab(this.name, text);
		}
		if (this.tfchat != null)
		{
			this.tfchat.setText(string.Empty);
		}
	}

	// Token: 0x060006F0 RID: 1776 RVA: 0x000698EC File Offset: 0x00067AEC
	public void setLim()
	{
		this.limY = this.vecDetail.size() * GameCanvas.hText - (GameCanvas.msgchat.hDia - (int)MainTabNew.wOneItem - 10 - (((int)this.typeChat != (int)ChatDetail.TYPE_CHAT) ? 0 : (TField.getHeight() + 2)));
		if (this.limY < 0)
		{
			this.limY = 0;
		}
	}

	// Token: 0x060006F1 RID: 1777 RVA: 0x00069958 File Offset: 0x00067B58
	public MainTextChat[] addChatNew(string[] mstr, sbyte color)
	{
		if (mstr == null || mstr.Length == 0)
		{
			return null;
		}
		MainTextChat[] array = new MainTextChat[mstr.Length];
		for (int i = 0; i < mstr.Length; i++)
		{
			array[i] = new MainTextChat(mstr[i], color);
		}
		return array;
	}

	// Token: 0x060006F2 RID: 1778 RVA: 0x000699A0 File Offset: 0x00067BA0
	private sbyte setColorText(string name)
	{
		sbyte result;
		if ((int)this.typeColorChat == 1)
		{
			result = ((this.indexColor % 2 != 0) ? 5 : 0);
			this.indexColor++;
		}
		else if (name.CompareTo(GameScreen.player.name) == 0)
		{
			result = 5;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x04000A2D RID: 2605
	public const sbyte TYPE_TROCHUYEN = 0;

	// Token: 0x04000A2E RID: 2606
	public const sbyte TYPE_BANGHOI_NHOM = 1;

	// Token: 0x04000A2F RID: 2607
	public mVector vecDetail = new mVector("ChatDetail vecDetail");

	// Token: 0x04000A30 RID: 2608
	public string name;

	// Token: 0x04000A31 RID: 2609
	public string friend;

	// Token: 0x04000A32 RID: 2610
	public sbyte timeNew = -1;

	// Token: 0x04000A33 RID: 2611
	public bool isNew;

	// Token: 0x04000A34 RID: 2612
	public TField tfchat;

	// Token: 0x04000A35 RID: 2613
	public sbyte typeChat;

	// Token: 0x04000A36 RID: 2614
	public static sbyte TYPE_CHAT;

	// Token: 0x04000A37 RID: 2615
	public static sbyte TYPE_SERVER = 1;

	// Token: 0x04000A38 RID: 2616
	public static sbyte TYPE_ADDFRIEND = 2;

	// Token: 0x04000A39 RID: 2617
	public int limY;

	// Token: 0x04000A3A RID: 2618
	private int indexColor;

	// Token: 0x04000A3B RID: 2619
	private sbyte typeColorChat;
}
