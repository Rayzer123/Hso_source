using System;
using System.Collections.Generic;
using UnityEngine;

// Token: 0x02000019 RID: 25
public class ScaleGUI
{
	// Token: 0x060000B7 RID: 183 RVA: 0x00004A4C File Offset: 0x00002C4C
	public static void initScaleGUI()
	{
		ScaleGUI.WIDTH = (float)Screen.width;
		ScaleGUI.HEIGHT = (float)Screen.height;
		ScaleGUI.scaleScreen = false;
		if (Screen.width > 1200)
		{
		}
	}

	// Token: 0x060000B8 RID: 184 RVA: 0x00004A7C File Offset: 0x00002C7C
	public static void BeginGUI()
	{
		if (!ScaleGUI.scaleScreen)
		{
			return;
		}
		ScaleGUI.stack.Add(GUI.matrix);
		Matrix4x4 rhs = default(Matrix4x4);
		float num = (float)Screen.width;
		float num2 = (float)Screen.height;
		float num3 = num / num2;
		Vector3 zero = Vector3.zero;
		float d;
		if (num3 < ScaleGUI.WIDTH / ScaleGUI.HEIGHT)
		{
			d = (float)Screen.width / ScaleGUI.WIDTH;
		}
		else
		{
			d = (float)Screen.height / ScaleGUI.HEIGHT;
		}
		rhs.SetTRS(zero, Quaternion.identity, Vector3.one * d);
		GUI.matrix *= rhs;
	}

	// Token: 0x060000B9 RID: 185 RVA: 0x00004B28 File Offset: 0x00002D28
	public static void EndGUI()
	{
		if (!ScaleGUI.scaleScreen)
		{
			return;
		}
		GUI.matrix = ScaleGUI.stack[ScaleGUI.stack.Count - 1];
		ScaleGUI.stack.RemoveAt(ScaleGUI.stack.Count - 1);
	}

	// Token: 0x060000BA RID: 186 RVA: 0x00004B74 File Offset: 0x00002D74
	public static float scaleX(float x)
	{
		if (!ScaleGUI.scaleScreen)
		{
			return x;
		}
		x = x * ScaleGUI.WIDTH / (float)Screen.width;
		return x;
	}

	// Token: 0x060000BB RID: 187 RVA: 0x00004B94 File Offset: 0x00002D94
	public static float scaleY(float y)
	{
		if (!ScaleGUI.scaleScreen)
		{
			return y;
		}
		y = y * ScaleGUI.HEIGHT / (float)Screen.height;
		return y;
	}

	// Token: 0x04000084 RID: 132
	public static bool scaleScreen;

	// Token: 0x04000085 RID: 133
	public static float WIDTH;

	// Token: 0x04000086 RID: 134
	public static float HEIGHT;

	// Token: 0x04000087 RID: 135
	private static List<Matrix4x4> stack = new List<Matrix4x4>();
}
