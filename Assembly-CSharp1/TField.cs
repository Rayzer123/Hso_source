using System;

// Token: 0x0200001A RID: 26
public class TField : AvMain
{
	// Token: 0x060000BC RID: 188 RVA: 0x00004BB4 File Offset: 0x00002DB4
	public TField()
	{
		this.text = string.Empty;
		this.init();
		this.setheightText();
	}

	// Token: 0x060000BD RID: 189 RVA: 0x00004C5C File Offset: 0x00002E5C
	public TField(int x, int y)
	{
		this.text = string.Empty;
		this.x = x;
		this.y = y;
		this.init();
		this.setheightText();
	}

	// Token: 0x060000BE RID: 190 RVA: 0x00004D10 File Offset: 0x00002F10
	public TField(int x, int y, int width)
	{
		this.text = string.Empty;
		this.x = x;
		this.y = y;
		this.width = width;
		this.widthTouch = 0;
		this.init();
		this.setheightText();
	}

	// Token: 0x060000BF RID: 191 RVA: 0x00004DD4 File Offset: 0x00002FD4
	public TField(int x, int y, int width, int widthTouch)
	{
		this.text = string.Empty;
		this.x = x;
		this.y = y;
		this.width = width;
		this.widthTouch = widthTouch;
		this.init();
		this.setFocus(false);
		this.setheightText();
	}

	// Token: 0x060000C1 RID: 193 RVA: 0x00005264 File Offset: 0x00003464
	public override void commandPointer(int index, int subIndex)
	{
		if (index == 0)
		{
			if (this.isFocus)
			{
				this.clear();
			}
			if (this.isnewTF)
			{
				newinput.input.text = string.Empty;
			}
		}
	}

	// Token: 0x060000C2 RID: 194 RVA: 0x000052B0 File Offset: 0x000034B0
	public static bool setNormal(char ch)
	{
		return (ch >= '0' && ch <= '9') || (ch >= 'A' && ch <= 'Z') || (ch >= 'a' && ch <= 'z');
	}

	// Token: 0x060000C3 RID: 195 RVA: 0x000052E8 File Offset: 0x000034E8
	public static void setVendorTypeMode(int mode)
	{
		if (mode == TField.MOTO)
		{
			TField.print[0] = "0";
			TField.print[10] = " *";
			TField.print[11] = "#";
			TField.changeModeKey = 35;
		}
		else if (mode == TField.NOKIA)
		{
			TField.print[0] = " 0";
			TField.print[10] = "*";
			TField.print[11] = "#";
			TField.changeModeKey = 35;
		}
		else if (mode == TField.ORTHER)
		{
			TField.print[0] = "0";
			TField.print[10] = "*";
			TField.print[11] = " #";
			TField.changeModeKey = 42;
		}
	}

	// Token: 0x060000C4 RID: 196 RVA: 0x000053A8 File Offset: 0x000035A8
	public void init()
	{
		TField.CARET_HEIGHT = mFont.tahoma_7_black.getHeight() + 1;
		this.cmdClear = new iCommand(T.del, 0, this);
	}

	// Token: 0x060000C5 RID: 197 RVA: 0x000053D0 File Offset: 0x000035D0
	public bool isFocusedz()
	{
		return this.isFocus;
	}

	// Token: 0x060000C6 RID: 198 RVA: 0x000053D8 File Offset: 0x000035D8
	public void clearKeyWhenPutText(int keyCode)
	{
		if (keyCode != -8)
		{
			return;
		}
		if (this.timeDelayKyCode > 0)
		{
			return;
		}
		if (this.timeDelayKyCode <= 0)
		{
			this.timeDelayKyCode = 1;
		}
		this.clear();
	}

	// Token: 0x060000C7 RID: 199 RVA: 0x0000540C File Offset: 0x0000360C
	public iCommand setCmdClear()
	{
		TField.acClear = this.cmdClear.action;
		return this.cmdClear;
	}

	// Token: 0x060000C8 RID: 200 RVA: 0x00005424 File Offset: 0x00003624
	public void setheightText()
	{
		this.height = 20;
		if (GameCanvas.isTouch)
		{
			this.height = 28;
		}
	}

	// Token: 0x060000C9 RID: 201 RVA: 0x00005440 File Offset: 0x00003640
	public void clearAllText()
	{
		this.text = string.Empty;
		TouchScreenKeyboard.Clear();
		if (TField.kb != null)
		{
			TField.kb.text = string.Empty;
		}
		this.caretPos = 0;
		this.setOffset(0);
		this.setPasswordTest();
	}

	// Token: 0x060000CA RID: 202 RVA: 0x00005480 File Offset: 0x00003680
	public void setStringNull(string str)
	{
		this.strnull = str;
	}

	// Token: 0x060000CB RID: 203 RVA: 0x0000548C File Offset: 0x0000368C
	public void clear()
	{
		if (this.isnewTF)
		{
			if (this.caretPos > 0 && this.text.Length > 0 && this.caretPos <= this.text.Length)
			{
				this.text = this.text.Substring(0, this.caretPos - 1);
				this.caretPos--;
				this.setOffset(0);
				this.setPasswordTest();
				if (TField.kb != null)
				{
					TField.kb.text = this.text;
				}
			}
			return;
		}
		if (this.caretPos > 0 && this.text.Length > 0)
		{
			this.text = this.text.Substring(0, this.caretPos - 1);
			this.caretPos--;
			this.setOffset(0);
			this.setPasswordTest();
			if (TField.kb != null)
			{
				TField.kb.text = this.text;
			}
		}
	}

	// Token: 0x060000CC RID: 204 RVA: 0x00005594 File Offset: 0x00003794
	public void clearAll()
	{
		if (this.caretPos > 0 && this.text.Length > 0)
		{
			this.text = this.text.Substring(0, this.text.Length - 1);
			this.caretPos--;
			this.setOffset();
			this.setPasswordTest();
			this.setFocusWithKb(true);
			if (TField.kb != null)
			{
				TField.kb.text = string.Empty;
			}
		}
	}

	// Token: 0x060000CD RID: 205 RVA: 0x00005618 File Offset: 0x00003818
	public void setOffset()
	{
		if (this.paintedText == null || mFont.tahoma_7_black == null)
		{
			return;
		}
		if (this.inputType == TField.INPUT_TYPE_PASSWORD)
		{
			this.paintedText = this.passwordText;
		}
		else
		{
			this.paintedText = this.text;
		}
		if (this.offsetX < 0 && mFont.tahoma_7_black.getWidth(this.paintedText) + this.offsetX < this.width - TField.TEXT_GAP_X - 13 - TField.typingModeAreaWidth)
		{
			this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_7_black.getWidth(this.paintedText);
		}
		if (this.offsetX + mFont.tahoma_7_black.getWidth(this.paintedText.Substring(0, this.caretPos)) <= 0)
		{
			this.offsetX = -mFont.tahoma_7_black.getWidth(this.paintedText.Substring(0, this.caretPos));
			this.offsetX += 40;
		}
		else if (this.offsetX + mFont.tahoma_7_black.getWidth(this.paintedText.Substring(0, this.caretPos)) >= this.width - 12 - TField.typingModeAreaWidth)
		{
			this.offsetX = this.width - 10 - TField.typingModeAreaWidth - mFont.tahoma_7_black.getWidth(this.paintedText.Substring(0, this.caretPos)) - 2 * TField.TEXT_GAP_X;
		}
		if (this.offsetX > 0)
		{
			this.offsetX = 0;
		}
	}

	// Token: 0x060000CE RID: 206 RVA: 0x000057B0 File Offset: 0x000039B0
	private void keyPressedAny(int keyCode)
	{
		string[] array;
		if (this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY)
		{
			array = TField.printA;
		}
		else
		{
			array = TField.print;
		}
		if (keyCode == TField.lastKey)
		{
			this.indexOfActiveChar = (this.indexOfActiveChar + 1) % array[keyCode - 48].Length;
			char c = array[keyCode - 48][this.indexOfActiveChar];
			if (TField.mode == 0)
			{
				c = char.ToLower(c);
			}
			else if (TField.mode == 1)
			{
				c = char.ToUpper(c);
			}
			else if (TField.mode == 2)
			{
				c = char.ToUpper(c);
			}
			else
			{
				c = array[keyCode - 48][array[keyCode - 48].Length - 1];
			}
			string str = this.text.Substring(0, this.caretPos - 1) + c;
			if (this.caretPos < this.text.Length)
			{
				str += this.text.Substring(this.caretPos, this.text.Length);
			}
			this.text = str;
			this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
			this.setPasswordTest();
		}
		else if (this.text.Length < this.maxTextLenght)
		{
			if (TField.mode == 1 && TField.lastKey != -1984)
			{
				TField.mode = 0;
			}
			this.indexOfActiveChar = 0;
			char c2 = array[keyCode - 48][this.indexOfActiveChar];
			if (TField.mode == 0)
			{
				c2 = char.ToLower(c2);
			}
			else if (TField.mode == 1)
			{
				c2 = char.ToUpper(c2);
			}
			else if (TField.mode == 2)
			{
				c2 = char.ToUpper(c2);
			}
			else
			{
				c2 = array[keyCode - 48][array[keyCode - 48].Length - 1];
			}
			string str2 = this.text.Substring(0, this.caretPos) + c2;
			if (this.caretPos < this.text.Length)
			{
				str2 += this.text.Substring(this.caretPos, this.text.Length);
			}
			this.text = str2;
			this.keyInActiveState = TField.MAX_TIME_TO_CONFIRM_KEY[TField.typeXpeed];
			this.caretPos++;
			this.setPasswordTest();
			this.setOffset();
		}
		TField.lastKey = keyCode;
	}

	// Token: 0x060000CF RID: 207 RVA: 0x00005A40 File Offset: 0x00003C40
	private void keyPressedAscii(int keyCode)
	{
		if (this.isnewTF)
		{
			this.text = newinput.input.text;
			if (this.text.Length < this.maxTextLenght && this.caretPos <= this.text.Length)
			{
				string str = this.text.Substring(0, this.caretPos) + (char)keyCode;
				if (this.caretPos < this.text.Length)
				{
					str += this.text.Substring(this.caretPos, this.text.Length - this.caretPos);
				}
				this.text = str;
				this.caretPos++;
				this.setPasswordTest();
				this.setOffset(0);
			}
			if (TField.kb != null)
			{
				TField.kb.text = this.text;
			}
			return;
		}
		if (!this.isFocus && Main.isPC)
		{
			return;
		}
		if ((this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY) && (keyCode < 48 || keyCode > 57) && (keyCode < 65 || keyCode > 90) && (keyCode < 97 || keyCode > 122))
		{
			return;
		}
		if (this.text.Length < this.maxTextLenght)
		{
			string str2 = this.text.Substring(0, this.caretPos) + (char)keyCode;
			if (this.caretPos < this.text.Length)
			{
				str2 += this.text.Substring(this.caretPos, this.text.Length - this.caretPos);
			}
			this.text = str2;
			this.caretPos++;
			this.setPasswordTest();
			this.setOffset(0);
		}
		if (TField.kb != null)
		{
			TField.kb.text = this.text;
		}
	}

	// Token: 0x060000D0 RID: 208 RVA: 0x00005C48 File Offset: 0x00003E48
	public static void setMode()
	{
		TField.mode++;
		if (TField.mode > 3)
		{
			TField.mode = 0;
		}
		TField.lastKey = TField.changeModeKey;
		TField.timeChangeMode = (long)(Environment.TickCount / 1000);
	}

	// Token: 0x060000D1 RID: 209 RVA: 0x00005C90 File Offset: 0x00003E90
	private void setDau()
	{
		this.timeDau = (long)(Environment.TickCount / 100);
		if (this.indexDau == -1)
		{
			for (int i = this.caretPos; i > 0; i--)
			{
				char c = this.text[i - 1];
				for (int j = 0; j < TField.printDau.Length; j++)
				{
					char c2 = TField.printDau[j];
					if (c == c2)
					{
						this.indexTemplate = j;
						this.indexCong = 0;
						this.indexDau = i - 1;
						return;
					}
				}
			}
			this.indexDau = -1;
		}
		else
		{
			this.indexCong++;
			if (this.indexCong >= 6)
			{
				this.indexCong = 0;
			}
			string str = this.text.Substring(0, this.indexDau);
			string str2 = this.text.Substring(this.indexDau + 1);
			string str3 = TField.printDau.Substring(this.indexTemplate + this.indexCong, 1);
			this.text = str + str3 + str2;
		}
	}

	// Token: 0x060000D2 RID: 210 RVA: 0x00005DA8 File Offset: 0x00003FA8
	public bool keyPressed(int keyCode)
	{
		if (Main.isPC && keyCode == -8)
		{
			this.clearKeyWhenPutText(-8);
			return true;
		}
		if (keyCode == 8 || keyCode == -8 || keyCode == 204)
		{
			this.clear();
			return true;
		}
		if (!GameCanvas.isTouch && !GameCanvas.isBB && keyCode >= 65 && keyCode <= 122)
		{
			TField.isQwerty = true;
			TField.typingModeAreaWidth = 0;
			sbyte[] data = new sbyte[]
			{
				1
			};
			try
			{
				CRes.saveRMS("isQty", data);
			}
			catch (Exception ex)
			{
			}
		}
		if (TField.isQwerty && keyCode >= 32)
		{
			this.keyPressedAscii(keyCode);
			return false;
		}
		if (keyCode == TField.changeDau && this.inputType == TField.INPUT_TYPE_ANY)
		{
			this.setDau();
			return false;
		}
		if (keyCode == 42)
		{
			keyCode = 58;
		}
		if (keyCode == 35)
		{
			keyCode = 59;
		}
		if (keyCode >= 48 && keyCode <= 59)
		{
			if (this.inputType == TField.INPUT_TYPE_ANY || this.inputType == TField.INPUT_TYPE_PASSWORD || this.inputType == TField.INPUT_ALPHA_NUMBER_ONLY)
			{
				this.keyPressedAny(keyCode);
			}
			else if (this.inputType == TField.INPUT_TYPE_NUMERIC)
			{
				this.keyPressedAscii(keyCode);
				this.keyInActiveState = 1;
			}
		}
		else
		{
			this.indexOfActiveChar = 0;
			TField.lastKey = -1984;
			if (keyCode == 14 && !this.lockArrow)
			{
				if (this.caretPos > 0)
				{
					this.caretPos--;
					this.setOffset(0);
					this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else if (keyCode == 15 && !this.lockArrow)
			{
				if (this.caretPos < this.text.Length)
				{
					this.caretPos++;
					this.setOffset(0);
					this.showCaretCounter = TField.MAX_SHOW_CARET_COUNER;
					return false;
				}
			}
			else
			{
				if (keyCode == 19)
				{
					this.clear();
					return false;
				}
				TField.lastKey = keyCode;
			}
		}
		return true;
	}

	// Token: 0x060000D3 RID: 211 RVA: 0x00005FE4 File Offset: 0x000041E4
	public void setOffset(int index)
	{
		if (this.inputType == TField.INPUT_TYPE_PASSWORD)
		{
			this.paintedText = this.passwordText;
		}
		else
		{
			this.paintedText = this.text;
		}
		int num = mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(0, this.caretPos));
		if (index == -1)
		{
			if (num + this.offsetX < 15 && this.caretPos > 0 && this.caretPos < this.paintedText.Length)
			{
				this.offsetX += mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(this.caretPos, 1));
			}
		}
		else if (index == 1)
		{
			if (num + this.offsetX > this.width - 25 && this.caretPos < this.paintedText.Length && this.caretPos > 0)
			{
				this.offsetX -= mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(this.caretPos - 1, 1));
			}
		}
		else
		{
			this.offsetX = -(num - (this.width - 12));
		}
		if (this.offsetX > 0)
		{
			this.offsetX = 0;
		}
		else if (this.offsetX < 0)
		{
			int num2 = mFont.tahoma_8b_black.getWidth(this.paintedText) - (this.width - 12);
			if (this.offsetX < -num2)
			{
				this.offsetX = -num2;
			}
		}
	}

	// Token: 0x060000D4 RID: 212 RVA: 0x00006178 File Offset: 0x00004378
	public void paintByList(mGraphics g)
	{
		bool flag = this.isFocusedz();
		mFont mFont = mFont.tahoma_8b_black;
		int num = 0;
		if (this.inputType == TField.INPUT_TYPE_PASSWORD)
		{
			this.paintedText = this.passwordText;
			num = 3;
		}
		else
		{
			this.paintedText = this.text;
		}
		if (this.isnewTF)
		{
			this.paintedText = newinput.input.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		this.timeFocus++;
		if (flag)
		{
			int length = this.paintedText.Length;
			if (length > 0 && this.caretPos > 0)
			{
				if (this.isnewTF)
				{
					if (this.caretPos <= this.paintedText.Length)
					{
						string text = this.paintedText.Substring(0, this.caretPos) + "a";
						num2 = mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(0, this.caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
					}
				}
				else
				{
					num2 = mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(0, this.caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
				}
			}
		}
		AvMain.paintRectText(g, this.x, this.y, this.width, this.height + 2, flag);
		if (this.isnewTF)
		{
			g.setClip(this.x + 2, this.y + 2, this.width - 4, this.height - 3);
			int translateX = g.getTranslateX();
			int translateY = g.getTranslateY();
		}
		g.translate(-this.xCamText, 0);
		if (this.paintedText.Length == 0)
		{
			num = 0;
			this.paintedText = this.strnull;
			if (flag)
			{
				mFont = mFont.tahoma_8b_black;
			}
			else
			{
				mFont = mFont.tahoma_8b_brown;
			}
		}
		mFont.drawString(g, this.paintedText, this.x + 4 + this.offsetX + TField.TEXT_GAP_X, this.y + this.height / 2 - 5 + num, 0, mGraphics.isTrue);
		if (Main.isPC && flag && this.timeFocus % 60 > 12)
		{
			g.setColor(0);
			g.fillRect(this.x + 3 + num2 + this.offsetX + TField.TEXT_GAP_X, this.y + this.height / 2 - 7, 1, 14, mGraphics.isFalse);
		}
	}

	// Token: 0x060000D5 RID: 213 RVA: 0x00006410 File Offset: 0x00004610
	public new void paint(mGraphics g)
	{
		bool flag = this.isFocusedz();
		mFont mFont = mFont.tahoma_8b_black;
		int num = 0;
		if (this.inputType == TField.INPUT_TYPE_PASSWORD)
		{
			this.paintedText = this.passwordText;
			num = 3;
		}
		else
		{
			this.paintedText = this.text;
		}
		if (this.isnewTF)
		{
			this.paintedText = newinput.input.text;
		}
		int num2 = 0;
		g.setColor(12621920);
		this.timeFocus++;
		if (flag)
		{
			int length = this.paintedText.Length;
			if (length > 0 && this.caretPos > 0)
			{
				if (this.isnewTF)
				{
					if (this.caretPos <= this.paintedText.Length)
					{
						string text = this.paintedText.Substring(0, this.caretPos) + "a";
						num2 = mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(0, this.caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
					}
				}
				else
				{
					num2 = mFont.tahoma_8b_black.getWidth(this.paintedText.Substring(0, this.caretPos) + "a") - mFont.tahoma_8b_black.getWidth("a");
				}
			}
		}
		AvMain.paintRectText(g, this.x, this.y, this.width, this.height + 2, flag);
		g.setClip(this.x + 2, this.y + 2, this.width - 4, this.height - 3);
		int translateX = g.getTranslateX();
		int translateY = g.getTranslateY();
		g.translate(-this.xCamText, 0);
		if (this.paintedText.Length == 0)
		{
			num = 0;
			this.paintedText = this.strnull;
			if (flag)
			{
				mFont = mFont.tahoma_8b_black;
			}
			else
			{
				mFont = mFont.tahoma_8b_brown;
			}
		}
		mFont.drawString(g, this.paintedText, this.x + 4 + this.offsetX + TField.TEXT_GAP_X, this.y + this.height / 2 - 5 + num, 0, mGraphics.isTrue);
		if (Main.isPC && flag && this.timeFocus % 60 > 12)
		{
			g.setColor(0);
			g.fillRect(this.x + 3 + num2 + this.offsetX + TField.TEXT_GAP_X, this.y + this.height / 2 - 7, 1, 14, mGraphics.isFalse);
		}
		g.setClip(0, 0, GameCanvas.w, GameCanvas.h);
		GameCanvas.resetTrans(g);
		g.translate(translateX, translateY);
	}

	// Token: 0x060000D6 RID: 214 RVA: 0x000066C0 File Offset: 0x000048C0
	public string subString(string str, int index, int indexTo)
	{
		if (index >= 0 && indexTo > str.Length - 1)
		{
			return str.Substring(index);
		}
		if (index < 0 || index > str.Length - 1 || indexTo < 0 || indexTo > str.Length - 1)
		{
			return string.Empty;
		}
		string text = string.Empty;
		for (int i = index; i < indexTo; i++)
		{
			text += str[i];
		}
		return text;
	}

	// Token: 0x060000D7 RID: 215 RVA: 0x00006748 File Offset: 0x00004948
	private void setPasswordTest()
	{
		if (this.inputType == TField.INPUT_TYPE_PASSWORD)
		{
			this.passwordText = string.Empty;
			for (int i = 0; i < this.text.Length; i++)
			{
				this.passwordText += "*";
			}
			if (this.keyInActiveState > 0 && this.caretPos > 0)
			{
				this.passwordText = this.passwordText.Substring(0, this.caretPos - 1) + this.text[this.caretPos - 1] + this.passwordText.Substring(this.caretPos, this.passwordText.Length);
			}
		}
	}

	// Token: 0x060000D8 RID: 216 RVA: 0x00006810 File Offset: 0x00004A10
	public new void update()
	{
		if (Main.isPC)
		{
			if (this.timeDelayKyCode > 0)
			{
				this.timeDelayKyCode--;
			}
			if (this.timeDelayKyCode <= 0)
			{
				this.timeDelayKyCode = 0;
			}
		}
		if (TField.kb != null && TField.currentTField == this)
		{
			if (TField.kb.text.Length < 200)
			{
				this.setText(TField.kb.text);
			}
			if (TField.kb.done)
			{
				this.isFocus = false;
			}
		}
		this.counter++;
		if (this.keyInActiveState > 0)
		{
			this.keyInActiveState--;
			if (this.keyInActiveState == 0)
			{
				this.indexOfActiveChar = 0;
				if (TField.mode == 1 && TField.lastKey != TField.changeModeKey && this.isFocus)
				{
					TField.mode = 0;
				}
				TField.lastKey = -1984;
				this.setPasswordTest();
			}
		}
		if (this.showCaretCounter > 0)
		{
			this.showCaretCounter--;
		}
		this.setTextBox();
		if (this.indexDau != -1 && (long)(Environment.TickCount / 100) - this.timeDau > 5L)
		{
			this.indexDau = -1;
		}
		if (this.isNotUseChangeTextBox && !Main.isPC)
		{
			TField.isOpenTextBox = false;
			this.isFocus = false;
		}
	}

	// Token: 0x060000D9 RID: 217 RVA: 0x0000698C File Offset: 0x00004B8C
	public void setTextBox()
	{
		if (GameCanvas.isPointerSelect)
		{
			if (GameCanvas.isPoint(this.x, this.y, this.width - this.widthTouch, this.height))
			{
				this.setFocusWithKb(true);
				this.doChangeToTextBox();
				GameCanvas.isPointerSelect = false;
			}
			else if (this.isChat)
			{
				this.setText(string.Empty);
				ChatTextField.isShow = false;
			}
			else
			{
				if (this.isChangeFocus)
				{
					this.isFocus = false;
				}
				this.setFocus(false);
			}
		}
	}

	// Token: 0x060000DA RID: 218 RVA: 0x00006A20 File Offset: 0x00004C20
	public void updatepointerByList()
	{
		if (Main.isPC)
		{
			if (this.timeDelayKyCode > 0)
			{
				this.timeDelayKyCode--;
			}
			if (this.timeDelayKyCode <= 0)
			{
				this.timeDelayKyCode = 0;
			}
		}
		if (TField.kb != null && TField.currentTField == this)
		{
			if (TField.kb.text.Length < 40)
			{
				this.setText(TField.kb.text);
			}
			if (TField.kb.done)
			{
				this.isFocus = false;
			}
		}
		this.counter++;
		if (this.keyInActiveState > 0)
		{
			this.keyInActiveState--;
			if (this.keyInActiveState == 0)
			{
				this.indexOfActiveChar = 0;
				if (TField.mode == 1 && TField.lastKey != TField.changeModeKey && this.isFocus)
				{
					TField.mode = 0;
				}
				TField.lastKey = -1984;
				this.setPasswordTest();
			}
		}
		if (this.showCaretCounter > 0)
		{
			this.showCaretCounter--;
		}
		this.setTextBoxBylist();
		if (this.indexDau != -1 && (long)(Environment.TickCount / 100) - this.timeDau > 5L)
		{
			this.indexDau = -1;
		}
		if (this.isNotUseChangeTextBox && !Main.isPC)
		{
			TField.isOpenTextBox = false;
			this.isFocus = false;
		}
	}

	// Token: 0x060000DB RID: 219 RVA: 0x00006B98 File Offset: 0x00004D98
	public void setTextBoxBylist()
	{
		if (GameCanvas.isPointerSelect && !GameCanvas.isPoint(this.x, this.y, this.width - this.widthTouch, this.height))
		{
			if (this.isChat)
			{
				this.setText(string.Empty);
				ChatTextField.isShow = false;
			}
			else
			{
				if (this.isChangeFocus)
				{
					this.isFocus = false;
				}
				this.setFocus(false);
			}
		}
		this.setFocusWithKb(true);
		this.doChangeToTextBox();
		GameCanvas.isPointerSelect = false;
	}

	// Token: 0x060000DC RID: 220 RVA: 0x00006C28 File Offset: 0x00004E28
	public void setFocus(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			TField.mode = 0;
		}
		TField.lastKey = -1984;
		TField.timeChangeMode = (long)((int)(DateTime.Now.Ticks / 1000L));
		this.isFocus = isFocus;
		if (isFocus)
		{
			TField.currentTField = this;
			if (TField.kb != null)
			{
				TField.kb.text = TField.currentTField.text;
			}
		}
	}

	// Token: 0x060000DD RID: 221 RVA: 0x00006CA0 File Offset: 0x00004EA0
	public void setFocusWithKb(bool isFocus)
	{
		if (this.isFocus != isFocus)
		{
			TField.mode = 0;
		}
		TField.lastKey = -1984;
		TField.timeChangeMode = (long)((int)(DateTime.Now.Ticks / 1000L));
		this.isFocus = isFocus;
		if (isFocus)
		{
			TField.currentTField = this;
		}
		else if (TField.currentTField == this)
		{
			TField.currentTField = null;
		}
		if (TField.currentTField != null)
		{
			isFocus = true;
			TouchScreenKeyboard.hideInput = !TField.currentTField.showSubTextField;
			TouchScreenKeyboardType t = TouchScreenKeyboardType.ASCIICapable;
			if (this.inputType == TField.INPUT_TYPE_NUMERIC)
			{
				t = TouchScreenKeyboardType.NumberPad;
			}
			bool type = false;
			if (this.inputType == TField.INPUT_TYPE_PASSWORD)
			{
				type = true;
			}
			TField.kb = TouchScreenKeyboard.Open(TField.currentTField.text, t, false, false, type, false, TField.currentTField.name);
			if (TField.kb != null)
			{
				TField.kb.text = TField.currentTField.text;
			}
			Cout.LogWarning("SHOW KEYBOARD FOR " + TField.currentTField.text);
		}
	}

	// Token: 0x060000DE RID: 222 RVA: 0x00006DB0 File Offset: 0x00004FB0
	public string getText()
	{
		return this.text;
	}

	// Token: 0x060000DF RID: 223 RVA: 0x00006DB8 File Offset: 0x00004FB8
	public void clearKb()
	{
		if (TField.kb != null)
		{
			TField.kb.text = string.Empty;
		}
	}

	// Token: 0x060000E0 RID: 224 RVA: 0x00006DD4 File Offset: 0x00004FD4
	public void setText(string text)
	{
		if (text == null)
		{
			return;
		}
		TField.lastKey = -1984;
		this.keyInActiveState = 0;
		this.indexOfActiveChar = 0;
		this.text = text;
		this.paintedText = text;
		this.setPasswordTest();
		this.caretPos = text.Length;
		this.setOffset(0);
	}

	// Token: 0x060000E1 RID: 225 RVA: 0x00006E28 File Offset: 0x00005028
	public void insertText(string text)
	{
		this.text = this.text.Substring(0, this.caretPos) + text + this.text.Substring(this.caretPos);
		this.setPasswordTest();
		this.caretPos += text.Length;
		this.setOffset();
	}

	// Token: 0x060000E2 RID: 226 RVA: 0x00006E84 File Offset: 0x00005084
	public int getMaxTextLenght()
	{
		return this.maxTextLenght;
	}

	// Token: 0x060000E3 RID: 227 RVA: 0x00006E8C File Offset: 0x0000508C
	public void setMaxTextLenght(int maxTextLenght)
	{
		this.maxTextLenght = maxTextLenght;
	}

	// Token: 0x060000E4 RID: 228 RVA: 0x00006E98 File Offset: 0x00005098
	public int getIputType()
	{
		return this.inputType;
	}

	// Token: 0x060000E5 RID: 229 RVA: 0x00006EA0 File Offset: 0x000050A0
	public void setIputType(int iputType)
	{
		this.inputType = iputType;
	}

	// Token: 0x060000E6 RID: 230 RVA: 0x00006EAC File Offset: 0x000050AC
	public void perform(int idAction, object p)
	{
		if (idAction == 1000)
		{
			this.clear();
		}
	}

	// Token: 0x060000E7 RID: 231 RVA: 0x00006EDC File Offset: 0x000050DC
	public static int getHeight()
	{
		if (GameCanvas.isTouch)
		{
			return 28;
		}
		return 20;
	}

	// Token: 0x060000E8 RID: 232 RVA: 0x00006EF0 File Offset: 0x000050F0
	public void updatePoiter()
	{
	}

	// Token: 0x060000E9 RID: 233 RVA: 0x00006EF4 File Offset: 0x000050F4
	public void setPoiter()
	{
		TField.isOpenTextBox = true;
		GameCanvas.isPointerSelect = false;
		this.doChangeToTextBox();
	}

	// Token: 0x060000EA RID: 234 RVA: 0x00006F08 File Offset: 0x00005108
	public void doChangeToTextBox()
	{
		if (ChatTextField.isShow)
		{
			ChatTextField.gI().openKeyIphone();
		}
		else if (GameCanvas.subDialog != null && GameCanvas.subDialog == GameCanvas.msgchat)
		{
			GameCanvas.msgchat.openKeyIphone();
		}
	}

	// Token: 0x04000088 RID: 136
	public const sbyte KEY_LEFT = 14;

	// Token: 0x04000089 RID: 137
	public const sbyte KEY_RIGHT = 15;

	// Token: 0x0400008A RID: 138
	public const sbyte KEY_CLEAR = 19;

	// Token: 0x0400008B RID: 139
	public bool isCloseKey = true;

	// Token: 0x0400008C RID: 140
	public bool isFocus;

	// Token: 0x0400008D RID: 141
	public bool isnewTF;

	// Token: 0x0400008E RID: 142
	public int x;

	// Token: 0x0400008F RID: 143
	public int y;

	// Token: 0x04000090 RID: 144
	public int width;

	// Token: 0x04000091 RID: 145
	public int height;

	// Token: 0x04000092 RID: 146
	public int range;

	// Token: 0x04000093 RID: 147
	public int widthTouch;

	// Token: 0x04000094 RID: 148
	public bool lockArrow;

	// Token: 0x04000095 RID: 149
	public bool justReturnFromTextBox;

	// Token: 0x04000096 RID: 150
	public bool paintFocus = true;

	// Token: 0x04000097 RID: 151
	public static int typeXpeed = 2;

	// Token: 0x04000098 RID: 152
	private static readonly int[] MAX_TIME_TO_CONFIRM_KEY = new int[]
	{
		30,
		14,
		11,
		9,
		6,
		4,
		2
	};

	// Token: 0x04000099 RID: 153
	private static int CARET_HEIGHT = 0;

	// Token: 0x0400009A RID: 154
	private static readonly int CARET_WIDTH = 1;

	// Token: 0x0400009B RID: 155
	private static readonly int CARET_SHOWING_TIME = 5;

	// Token: 0x0400009C RID: 156
	private static readonly int TEXT_GAP_X = 4;

	// Token: 0x0400009D RID: 157
	private static readonly int MAX_SHOW_CARET_COUNER = 10;

	// Token: 0x0400009E RID: 158
	public static readonly int INPUT_TYPE_ANY = 0;

	// Token: 0x0400009F RID: 159
	public static readonly int INPUT_TYPE_NUMERIC = 1;

	// Token: 0x040000A0 RID: 160
	public static readonly int INPUT_TYPE_PASSWORD = 2;

	// Token: 0x040000A1 RID: 161
	public static readonly int INPUT_ALPHA_NUMBER_ONLY = 3;

	// Token: 0x040000A2 RID: 162
	private static string[] print = new string[]
	{
		" 0",
		".,@?!_1\"/$-():*+<=>;%&~#%^&*{}[];'/1",
		"abc2áàảãạâấầẩẫậăắằẳẵặ2",
		"def3đéèẻẽẹêếềểễệ3",
		"ghi4íìỉĩị4",
		"jkl5",
		"mno6óòỏõọôốồổỗộơớờởỡợ6",
		"pqrs7",
		"tuv8úùủũụưứừửữự8",
		"wxyz9ýỳỷỹỵ9",
		"*",
		"#"
	};

	// Token: 0x040000A3 RID: 163
	private static string[] printA = new string[]
	{
		"0",
		"1",
		"abc2",
		"def3",
		"ghi4",
		"jkl5",
		"mno6",
		"pqrs7",
		"tuv8",
		"wxyz9",
		"0",
		"0"
	};

	// Token: 0x040000A4 RID: 164
	private static string[] printBB = new string[]
	{
		" 0",
		"er1",
		"ty2",
		"ui3",
		"df4",
		"gh5",
		"jk6",
		"cv7",
		"bn8",
		"m9",
		"0",
		"0",
		"qw!",
		"as?",
		"zx",
		"op.",
		"l,"
	};

	// Token: 0x040000A5 RID: 165
	private string text = string.Empty;

	// Token: 0x040000A6 RID: 166
	private string passwordText = string.Empty;

	// Token: 0x040000A7 RID: 167
	public string paintedText = string.Empty;

	// Token: 0x040000A8 RID: 168
	public bool isChat;

	// Token: 0x040000A9 RID: 169
	public int caretPos;

	// Token: 0x040000AA RID: 170
	private int counter;

	// Token: 0x040000AB RID: 171
	private int maxTextLenght = 500;

	// Token: 0x040000AC RID: 172
	private int offsetX;

	// Token: 0x040000AD RID: 173
	private static int lastKey = -1984;

	// Token: 0x040000AE RID: 174
	private int keyInActiveState;

	// Token: 0x040000AF RID: 175
	private int indexOfActiveChar;

	// Token: 0x040000B0 RID: 176
	private int showCaretCounter = TField.MAX_SHOW_CARET_COUNER;

	// Token: 0x040000B1 RID: 177
	private int inputType = TField.INPUT_TYPE_ANY;

	// Token: 0x040000B2 RID: 178
	public static bool isQwerty = true;

	// Token: 0x040000B3 RID: 179
	public static int typingModeAreaWidth;

	// Token: 0x040000B4 RID: 180
	public static int mode = 0;

	// Token: 0x040000B5 RID: 181
	public static long timeChangeMode;

	// Token: 0x040000B6 RID: 182
	public static readonly string[] modeNotify = new string[]
	{
		"abc",
		"Abc",
		"ABC",
		"123"
	};

	// Token: 0x040000B7 RID: 183
	public static readonly int NOKIA = 0;

	// Token: 0x040000B8 RID: 184
	public static readonly int MOTO = 1;

	// Token: 0x040000B9 RID: 185
	public static readonly int ORTHER = 2;

	// Token: 0x040000BA RID: 186
	public static readonly int BB = 3;

	// Token: 0x040000BB RID: 187
	public static int changeModeKey = 11;

	// Token: 0x040000BC RID: 188
	public static readonly sbyte abc = 0;

	// Token: 0x040000BD RID: 189
	public static readonly sbyte Abc = 1;

	// Token: 0x040000BE RID: 190
	public static readonly sbyte ABC = 2;

	// Token: 0x040000BF RID: 191
	public static readonly sbyte number123 = 3;

	// Token: 0x040000C0 RID: 192
	public static TField currentTField;

	// Token: 0x040000C1 RID: 193
	public bool isTfield;

	// Token: 0x040000C2 RID: 194
	public bool isPaintMouse = true;

	// Token: 0x040000C3 RID: 195
	public string name = string.Empty;

	// Token: 0x040000C4 RID: 196
	public string title = string.Empty;

	// Token: 0x040000C5 RID: 197
	public string strnull;

	// Token: 0x040000C6 RID: 198
	public string strInfo;

	// Token: 0x040000C7 RID: 199
	private int xCamText;

	// Token: 0x040000C8 RID: 200
	public iCommand cmdClear;

	// Token: 0x040000C9 RID: 201
	public iCommand cmdDoneAction;

	// Token: 0x040000CA RID: 202
	public bool isNotUseChangeTextBox;

	// Token: 0x040000CB RID: 203
	private int timeDelayKyCode;

	// Token: 0x040000CC RID: 204
	public static IAction acClear;

	// Token: 0x040000CD RID: 205
	private int holdCount;

	// Token: 0x040000CE RID: 206
	public static int changeDau;

	// Token: 0x040000CF RID: 207
	private int indexDau = -1;

	// Token: 0x040000D0 RID: 208
	private int indexTemplate;

	// Token: 0x040000D1 RID: 209
	private int indexCong;

	// Token: 0x040000D2 RID: 210
	private long timeDau;

	// Token: 0x040000D3 RID: 211
	private static string printDau = "aáàảãạâấầẩẫậăắằẳẵặeéèẻẽẹêếềểễệiíìỉĩịoóòỏõọôốồổỗộơớờởỡợuúùủũụưứừửữựyýỳỷỹỵ";

	// Token: 0x040000D4 RID: 212
	public static bool isOpenTextBox = false;

	// Token: 0x040000D5 RID: 213
	private int timeFocus;

	// Token: 0x040000D6 RID: 214
	private int cout;

	// Token: 0x040000D7 RID: 215
	public int timePutKeyClearAll;

	// Token: 0x040000D8 RID: 216
	public int timeClearFirt;

	// Token: 0x040000D9 RID: 217
	public bool resetFc;

	// Token: 0x040000DA RID: 218
	public bool showSubTextField = true;

	// Token: 0x040000DB RID: 219
	public static TouchScreenKeyboard kb;

	// Token: 0x040000DC RID: 220
	public static int[][] BBKEY = new int[][]
	{
		new int[]
		{
			32,
			48
		},
		new int[]
		{
			49,
			69
		},
		new int[]
		{
			50,
			84
		},
		new int[]
		{
			51,
			85
		},
		new int[]
		{
			52,
			68
		},
		new int[]
		{
			53,
			71
		},
		new int[]
		{
			54,
			74
		},
		new int[]
		{
			55,
			67
		},
		new int[]
		{
			56,
			66
		},
		new int[]
		{
			57,
			77
		},
		new int[]
		{
			42,
			128
		},
		new int[]
		{
			35,
			137
		},
		new int[]
		{
			33,
			113
		},
		new int[]
		{
			63,
			97
		},
		new int[]
		{
			64,
			121,
			122
		},
		new int[]
		{
			46,
			111
		},
		new int[]
		{
			44,
			108
		}
	};

	// Token: 0x040000DD RID: 221
	public static int xDu;

	// Token: 0x040000DE RID: 222
	public bool isChangeFocus;
}
