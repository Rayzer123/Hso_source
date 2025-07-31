using System;

// Token: 0x02000090 RID: 144
public class ChatTextField : AvMain
{
	// Token: 0x060006F3 RID: 1779 RVA: 0x00069A04 File Offset: 0x00067C04
	protected ChatTextField()
	{
		this.tfChat = new TField();
		this.tfChat.isChangeFocus = false;
		this.tfChat.isnewTF = true;
		this.tfChat.setFocus(true);
		this.init();
		this.tfChat.x = (GameCanvas.w - this.tfChat.width) / 2;
		this.tfChat.setMaxTextLenght(70);
		newinput.input.characterLimit = 70;
		this.tfChat.setStringNull((!Main.isPC) ? T.chat : string.Empty);
		if (Main.isPC)
		{
			this.tfChat.range = 80;
			this.center = new iCommand(string.Empty, 1);
			this.tfChat.x += iCommand.wButtonCmd - 2;
			this.tfChat.paintedText = string.Empty;
			this.tfChat.width = GameCanvas.hw - iCommand.wButtonCmd / 2;
			this.tfChat.y = GameCanvas.h - this.tfChat.height - 4;
			this.tfChat.isChat = true;
			this.left = new iCommand(T.chat, 1, this);
		}
		this.cmdChat = new iCommand();
		this.cmdChat.actionChat = delegate(string str)
		{
			this.tfChat.justReturnFromTextBox = false;
			this.tfChat.setText(str);
			if (this.tfChat.getText().Length > 0)
			{
				if (!Main.isPC)
				{
					GlobalService.gI().chatPopup(this.tfChat.getText());
				}
				GameScreen.player.strChatPopup = this.tfChat.getText();
			}
			this.tfChat.setText(string.Empty);
			TField.isOpenTextBox = false;
			this.tfChat.isFocus = false;
			ChatTextField.isShow = false;
		};
	}

	// Token: 0x060006F5 RID: 1781 RVA: 0x00069B74 File Offset: 0x00067D74
	public static ChatTextField gI()
	{
		return (ChatTextField.instance != null) ? ChatTextField.instance : (ChatTextField.instance = new ChatTextField());
	}

	// Token: 0x060006F6 RID: 1782 RVA: 0x00069B98 File Offset: 0x00067D98
	public void setChat()
	{
		ChatTextField.isShow = !ChatTextField.isShow;
		if (ChatTextField.isShow)
		{
			newinput.input.text = string.Empty;
			this.tfChat.setPoiter();
		}
	}

	// Token: 0x060006F7 RID: 1783 RVA: 0x00069BCC File Offset: 0x00067DCC
	public void openKeyIphone()
	{
		if (!Main.isPC)
		{
			ipKeyboard.openKeyBoard("Chat", ipKeyboard.TEXT, string.Empty, this.cmdChat);
			this.tfChat.setFocusWithKb(true);
		}
	}

	// Token: 0x060006F8 RID: 1784 RVA: 0x00069C0C File Offset: 0x00067E0C
	public override void commandTab(int index, int subIndex)
	{
		if (index != 0)
		{
			if (index == 1)
			{
				this.sendChat();
			}
		}
		else
		{
			this.tfChat.setText(string.Empty);
			ChatTextField.isShow = false;
			if (Main.isPC)
			{
				this.tfChat.setFocus(true);
			}
		}
	}

	// Token: 0x060006F9 RID: 1785 RVA: 0x00069C6C File Offset: 0x00067E6C
	public override void commandPointer(int index, int subIndex)
	{
		if (index == 1)
		{
			this.sendChat();
		}
	}

	// Token: 0x060006FA RID: 1786 RVA: 0x00069C94 File Offset: 0x00067E94
	public void init()
	{
		this.tfChat.y = GameCanvas.h - iCommand.hButtonCmd - this.tfChat.height - 5;
		this.tfChat.width = GameCanvas.w - TField.xDu * 2 - 10;
	}

	// Token: 0x060006FB RID: 1787 RVA: 0x00069CE0 File Offset: 0x00067EE0
	public void keyPressed(int keyCode)
	{
		this.tfChat.keyPressed(keyCode);
	}

	// Token: 0x060006FC RID: 1788 RVA: 0x00069CF0 File Offset: 0x00067EF0
	public override void updatekey()
	{
		this.tfChat.update();
		if (!ChatTextField.isShow)
		{
			newinput.TYPE_INPUT = -1;
		}
		else
		{
			newinput.TYPE_INPUT = 0;
		}
		base.updatekey();
	}

	// Token: 0x060006FD RID: 1789 RVA: 0x00069D2C File Offset: 0x00067F2C
	public override void paint(mGraphics g)
	{
		base.paint(g);
		if (!TouchScreenKeyboard.visible)
		{
			this.tfChat.paint(g);
		}
	}

	// Token: 0x060006FE RID: 1790 RVA: 0x00069D4C File Offset: 0x00067F4C
	public override void updatePointer()
	{
		this.tfChat.updatePoiter();
		base.updatePointer();
	}

	// Token: 0x060006FF RID: 1791 RVA: 0x00069D60 File Offset: 0x00067F60
	public void sendChat()
	{
		this.tfChat.setText(newinput.input.text);
		if (this.tfChat.getText().Length > 0)
		{
			newinput.input.text = string.Empty;
			GameScreen.player.strChatPopup = this.tfChat.getText();
			GlobalService.gI().chatPopup(this.tfChat.getText());
			this.tfChat.setText(string.Empty);
		}
		if (GameCanvas.isTouch)
		{
			ChatTextField.isShow = false;
		}
	}

	// Token: 0x04000A3C RID: 2620
	public TField tfChat;

	// Token: 0x04000A3D RID: 2621
	public static ChatTextField instance;

	// Token: 0x04000A3E RID: 2622
	public static bool isShow;

	// Token: 0x04000A3F RID: 2623
	public iCommand cmdChat;
}
