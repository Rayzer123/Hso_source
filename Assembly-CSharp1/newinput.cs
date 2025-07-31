using System;
using UnityEngine;
using UnityEngine.UI;

// Token: 0x020000CB RID: 203
public class newinput : MonoBehaviour
{
	// Token: 0x060009A1 RID: 2465 RVA: 0x000A34E8 File Offset: 0x000A16E8
	private void Start()
	{
		newinput.input = base.GetComponent<InputField>();
		newinput.TYPE_INPUT = -1;
	}

	// Token: 0x060009A2 RID: 2466 RVA: 0x000A34FC File Offset: 0x000A16FC
	private void Update()
	{
		if (newinput.TYPE_INPUT == 0)
		{
			if (ChatTextField.isShow)
			{
				newinput.input.Select();
				newinput.input.ActivateInputField();
			}
			else
			{
				newinput.input.DeactivateInputField();
			}
		}
		if (newinput.TYPE_INPUT == 1)
		{
			if (MsgChat.curentfocus != null && MsgChat.curentfocus.tfchat != null)
			{
				newinput.input.Select();
				newinput.input.ActivateInputField();
			}
			else
			{
				newinput.input.DeactivateInputField();
			}
		}
		if (newinput.TYPE_INPUT == 2)
		{
		}
	}

	// Token: 0x040010C8 RID: 4296
	public static InputField input;

	// Token: 0x040010C9 RID: 4297
	public static int TYPE_INPUT;
}
