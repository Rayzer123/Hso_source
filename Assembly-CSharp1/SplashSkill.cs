using System;

// Token: 0x020000D2 RID: 210
public class SplashSkill
{
	// Token: 0x060009CF RID: 2511 RVA: 0x000A5978 File Offset: 0x000A3B78
	public void setPlash(int typeP)
	{
		this.typePlash = typeP;
		this.isSung = false;
		switch (this.typePlash)
		{
		case 0:
			this.min = 4;
			break;
		case 1:
			this.min = 6;
			break;
		case 2:
			this.min = 12;
			break;
		case 5:
			this.min = 8;
			break;
		case 6:
			this.min = 30;
			this.isSung = true;
			break;
		case 7:
			this.min = 16;
			break;
		case 8:
			this.min = 10;
			break;
		case 10:
			this.min = 22;
			this.isSung = true;
			break;
		case 11:
			this.min = 12;
			this.isSung = true;
			break;
		case 16:
			this.min = 6;
			this.isSung = true;
			break;
		}
	}

	// Token: 0x060009D0 RID: 2512 RVA: 0x000A5A84 File Offset: 0x000A3C84
	public void update(MainObject obj)
	{
		switch (this.typePlash)
		{
		case 3:
			if (obj.fplash < 2)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
			}
			else
			{
				obj.setEye(1);
				obj.weapon_frame = obj.fplash + 2;
				if (obj.fplash < 6)
				{
					obj.frame = 4;
				}
				else
				{
					obj.Action = 0;
					obj.frame = 0;
					obj.f = 0;
					obj.weapon_frame = 0;
				}
			}
			goto IL_47F;
		case 4:
			if (obj.fplash < 4)
			{
				obj.frame = 4;
				obj.weapon_frame = 4;
			}
			else
			{
				obj.setEye(1);
				obj.weapon_frame = obj.fplash;
				if (obj.fplash < 10)
				{
					obj.frame = 5;
				}
				else
				{
					obj.Action = 0;
					obj.frame = 0;
					obj.f = 0;
					obj.weapon_frame = 0;
				}
			}
			goto IL_47F;
		case 9:
			if (obj.fplash < 30)
			{
				obj.frame = 4;
				if ((int)obj.clazz == 3)
				{
					obj.frame = 5;
				}
				obj.weapon_frame = 4;
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			goto IL_47F;
		case 12:
			if (obj.fplash >= 30)
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			goto IL_47F;
		case 13:
			if (obj.fplash < 12)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
			}
			else if (obj.fplash < 30)
			{
				if (obj.fplash < 14)
				{
					obj.weapon_frame = obj.fplash - 8;
					obj.frame = 4;
				}
				else if (obj.fplash % 2 == 0)
				{
					obj.setEye(1);
					obj.weapon_frame = 4;
					obj.frame = 5;
				}
				else
				{
					obj.weapon_frame = 7;
					obj.frame = 4;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			goto IL_47F;
		case 14:
			if ((int)obj.clazz == 3)
			{
				if (obj.fplash < 2)
				{
					obj.frame = 5;
					obj.weapon_frame = 4;
				}
				else
				{
					obj.setEye(1);
					obj.weapon_frame = obj.fplash + 2;
					if (obj.fplash < 6)
					{
						obj.frame = 4;
					}
					else
					{
						obj.Action = 0;
						obj.frame = 0;
						obj.f = 0;
						obj.weapon_frame = 0;
					}
				}
			}
			else if (obj.fplash < 4)
			{
				obj.frame = 4;
				obj.weapon_frame = 4;
			}
			else
			{
				obj.setEye(1);
				obj.weapon_frame = obj.fplash;
				if (obj.fplash < 8)
				{
					obj.frame = 5;
				}
				else
				{
					obj.Action = 0;
					obj.frame = 0;
					obj.f = 0;
					obj.weapon_frame = 0;
				}
			}
			goto IL_47F;
		case 15:
			if (obj.fplash < 26)
			{
				obj.frame = 5;
				obj.weapon_frame = 4;
				if (obj.fplash >= 12)
				{
					obj.setEye(1);
				}
			}
			else if (obj.fplash < 30)
			{
				obj.weapon_frame = obj.fplash - 22;
				obj.frame = 4;
				if (obj.weapon_frame > 7)
				{
					obj.weapon_frame = 7;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
			goto IL_47F;
		}
		if (obj.fplash < this.min)
		{
			obj.frame = 4;
			if (this.isSung)
			{
				obj.frame = 5;
			}
			obj.weapon_frame = 4;
			if (obj.weapon_frame > 4)
			{
				obj.weapon_frame = 4;
			}
		}
		else
		{
			obj.setEye(1);
			obj.weapon_frame = obj.fplash - (this.min - 4);
			if (obj.fplash < this.min + 4)
			{
				obj.frame = 5;
				if (this.isSung)
				{
					obj.frame = 4;
				}
			}
			else
			{
				obj.Action = 0;
				obj.frame = 0;
				obj.f = 0;
				obj.weapon_frame = 0;
			}
		}
		IL_47F:
		obj.fplash++;
	}

	// Token: 0x04001161 RID: 4449
	public const sbyte PLASH_MIN_4 = 0;

	// Token: 0x04001162 RID: 4450
	public const sbyte PLASH_MIN_6 = 1;

	// Token: 0x04001163 RID: 4451
	public const sbyte PLASH_MIN_12 = 2;

	// Token: 0x04001164 RID: 4452
	public const sbyte PLASH_SUNG_0 = 3;

	// Token: 0x04001165 RID: 4453
	public const sbyte PLASH_2KIEM_LV2_LV4 = 4;

	// Token: 0x04001166 RID: 4454
	public const sbyte PLASH_MIN_8 = 5;

	// Token: 0x04001167 RID: 4455
	public const sbyte PLASH_SUNG_LASER = 6;

	// Token: 0x04001168 RID: 4456
	public const sbyte PLASH_MIN_16 = 7;

	// Token: 0x04001169 RID: 4457
	public const sbyte PLASH_MIN_10 = 8;

	// Token: 0x0400116A RID: 4458
	public const sbyte PLASH_BUFF = 9;

	// Token: 0x0400116B RID: 4459
	public const sbyte PLASH_SUNG_LV4 = 10;

	// Token: 0x0400116C RID: 4460
	public const sbyte PLASH_SUNG_MIN_8 = 11;

	// Token: 0x0400116D RID: 4461
	public const sbyte PLASH_KIEM_LV5 = 12;

	// Token: 0x0400116E RID: 4462
	public const sbyte PLASH_SUNG_BAODAN = 13;

	// Token: 0x0400116F RID: 4463
	public const sbyte PLASH_NULL = 14;

	// Token: 0x04001170 RID: 4464
	public const sbyte PLASH_SUNG_DAYDAN = 15;

	// Token: 0x04001171 RID: 4465
	public const sbyte PLASH_SUNG_MIN_6 = 16;

	// Token: 0x04001172 RID: 4466
	public int typePlash;

	// Token: 0x04001173 RID: 4467
	public int min;

	// Token: 0x04001174 RID: 4468
	private bool isSung;
}
