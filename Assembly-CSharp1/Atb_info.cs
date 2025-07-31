using System;
using UnityEngine;

// Token: 0x0200003E RID: 62
public class Atb_info : MonoBehaviour
{
	// Token: 0x060002E1 RID: 737 RVA: 0x00026EBC File Offset: 0x000250BC
	public Atb_info(string info, int idcolor)
	{
		this.info = info;
		this.id_color = (sbyte)idcolor;
	}

	// Token: 0x040003AB RID: 939
	public string info;

	// Token: 0x040003AC RID: 940
	public sbyte id_color;
}
