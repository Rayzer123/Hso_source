using System;

// Token: 0x0200001C RID: 28
public class ipKeyboard
{
	// Token: 0x060000FC RID: 252 RVA: 0x0000711C File Offset: 0x0000531C
	public static void openKeyBoard(string caption, int type, string text, iCommand action)
	{
		ipKeyboard.act = action;
		TouchScreenKeyboardType t = (type != 0 && type != 2) ? TouchScreenKeyboardType.NumberPad : TouchScreenKeyboardType.ASCIICapable;
		TouchScreenKeyboard.hideInput = false;
		ipKeyboard.tk = TouchScreenKeyboard.Open(text, t, false, false, type == 2, false, caption);
	}

	// Token: 0x060000FD RID: 253 RVA: 0x00007160 File Offset: 0x00005360
	public static void update()
	{
		try
		{
			if (ipKeyboard.tk != null)
			{
				if (ipKeyboard.tk.done)
				{
					if (ipKeyboard.act != null)
					{
						ipKeyboard.act.perform(ipKeyboard.tk.text);
					}
					ipKeyboard.tk.text = string.Empty;
					ipKeyboard.tk = null;
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x040000E1 RID: 225
	private static TouchScreenKeyboard tk;

	// Token: 0x040000E2 RID: 226
	public static int TEXT;

	// Token: 0x040000E3 RID: 227
	public static int NUMBERIC = 1;

	// Token: 0x040000E4 RID: 228
	public static int PASS = 2;

	// Token: 0x040000E5 RID: 229
	private static iCommand act;
}
