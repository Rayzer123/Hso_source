using System;

// Token: 0x02000013 RID: 19
public class TouchScreenKeyboard
{
	// Token: 0x06000098 RID: 152 RVA: 0x0000412C File Offset: 0x0000232C
	public static TouchScreenKeyboard Open(string text, TouchScreenKeyboardType t, bool b1, bool b2, bool type, bool b3, string caption)
	{
		return null;
	}

	// Token: 0x06000099 RID: 153 RVA: 0x00004130 File Offset: 0x00002330
	public static void Clear()
	{
	}

	// Token: 0x04000052 RID: 82
	public static bool hideInput;

	// Token: 0x04000053 RID: 83
	public static bool visible;

	// Token: 0x04000054 RID: 84
	public bool done;

	// Token: 0x04000055 RID: 85
	public bool active;

	// Token: 0x04000056 RID: 86
	public string text;
}
