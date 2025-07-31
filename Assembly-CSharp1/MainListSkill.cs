using System;

// Token: 0x020000CF RID: 207
public class MainListSkill
{
	// Token: 0x060009BC RID: 2492 RVA: 0x000A4988 File Offset: 0x000A2B88
	// Note: this type is marked as 'beforefieldinit'.
	static MainListSkill()
	{
		int[][] array = new int[7][];
		int num = 0;
		int[] array2 = new int[25];
		array2[14] = 5;
		array2[21] = 9;
		array[num] = array2;
		int num2 = 1;
		int[] array3 = new int[25];
		array3[13] = 1;
		array3[14] = 6;
		array3[21] = 9;
		array[num2] = array3;
		int num3 = 2;
		int[] array4 = new int[25];
		array4[13] = 2;
		array4[14] = 7;
		array4[21] = 9;
		array[num3] = array4;
		int num4 = 3;
		int[] array5 = new int[25];
		array5[13] = 3;
		array5[14] = 8;
		array5[21] = 9;
		array[num4] = array5;
		array[4] = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			28,
			29,
			30,
			31
		};
		array[5] = new int[10];
		array[6] = new int[]
		{
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10,
			10
		};
		MainListSkill.mBuffAllClasses = array;
		MainListSkill.mRange = new int[]
		{
			200,
			60,
			200,
			50,
			200,
			110,
			110,
			70,
			100,
			200,
			200,
			200,
			200,
			200,
			110,
			60,
			30,
			110,
			110,
			110,
			110,
			110,
			75,
			60,
			110,
			100,
			120,
			110,
			160,
			140,
			120,
			70,
			60,
			100,
			110,
			50,
			60,
			110,
			110,
			110,
			110,
			60,
			110,
			110,
			60,
			120,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110,
			110
		};
		MainListSkill.mPlash = new int[]
		{
			0,
			0,
			0,
			0,
			0,
			5,
			7,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			7,
			0,
			0,
			0,
			16,
			16,
			1,
			5,
			1,
			1,
			11,
			2,
			5,
			4,
			10,
			7,
			0,
			0,
			0,
			12,
			7,
			14,
			1,
			5,
			0,
			5,
			6,
			1,
			7,
			7,
			1,
			9,
			1,
			7,
			2,
			13,
			11,
			5,
			10,
			10,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0,
			0
		};
		MainListSkill.mFramePlash = new int[]
		{
			5,
			5,
			5,
			5,
			5,
			11,
			15,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			15,
			5,
			5,
			5,
			9,
			9,
			9,
			11,
			9,
			9,
			11,
			5,
			5,
			9,
			5,
			5,
			5,
			5,
			5,
			5,
			15,
			5,
			9,
			11,
			5,
			11,
			11,
			9,
			15,
			15,
			9,
			5,
			9,
			15,
			15,
			11,
			11,
			11,
			20,
			20,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5,
			5
		};
	}

	// Token: 0x060009BD RID: 2493 RVA: 0x000A4B1C File Offset: 0x000A2D1C
	public static MainListSkill gI()
	{
		if (MainListSkill.me == null)
		{
			MainListSkill.me = new MainListSkill();
		}
		return MainListSkill.me;
	}

	// Token: 0x060009BE RID: 2494 RVA: 0x000A4B38 File Offset: 0x000A2D38
	public static void loadIndexEffKill()
	{
		MainListSkill.mEffectKill = new int[MainListSkill.mPlash.Length];
		MainListSkill.mEffectKill[5] = 11;
		MainListSkill.mEffectKill[6] = 12;
		MainListSkill.mEffectKill[14] = 20;
		MainListSkill.mEffectKill[15] = 21;
		MainListSkill.mEffectKill[18] = 22;
		MainListSkill.mEffectKill[19] = 23;
		MainListSkill.mEffectKill[20] = 25;
		MainListSkill.mEffectKill[21] = 26;
		MainListSkill.mEffectKill[22] = 27;
		MainListSkill.mEffectKill[23] = 28;
		MainListSkill.mEffectKill[24] = 31;
		MainListSkill.mEffectKill[27] = 34;
		MainListSkill.mEffectKill[31] = 38;
		MainListSkill.mEffectKill[34] = 40;
		MainListSkill.mEffectKill[35] = 38;
		MainListSkill.mEffectKill[36] = 46;
		MainListSkill.mEffectKill[37] = 47;
		MainListSkill.mEffectKill[39] = 49;
		MainListSkill.mEffectKill[40] = 51;
		MainListSkill.mEffectKill[41] = 52;
		MainListSkill.mEffectKill[42] = 53;
		MainListSkill.mEffectKill[43] = 54;
		MainListSkill.mEffectKill[44] = 55;
		MainListSkill.mEffectKill[45] = 57;
		MainListSkill.mEffectKill[46] = 59;
		MainListSkill.mEffectKill[47] = 60;
		MainListSkill.mEffectKill[48] = 61;
		MainListSkill.mEffectKill[49] = 62;
		MainListSkill.mEffectKill[50] = 82;
		MainListSkill.mEffectKill[51] = 64;
		MainListSkill.mEffectKill[52] = 65;
		MainListSkill.mEffectKill[53] = 66;
		MainListSkill.mEffectKill[54] = 110;
		MainListSkill.mEffectKill[55] = 112;
		MainListSkill.mEffectKill[56] = 109;
		MainListSkill.mEffectKill[57] = 111;
		MainListSkill.mEffectKill[58] = 0;
		MainListSkill.mEffectKill[59] = 0;
		MainListSkill.mEffectKill[60] = 0;
		MainListSkill.mEffectKill[61] = 0;
		MainListSkill.mEffectKill[62] = 119;
		MainListSkill.mEffectKill[63] = 118;
		MainListSkill.mEffectKill[64] = 116;
		MainListSkill.mEffectKill[65] = 117;
		MainListSkill.mEffectKill[66] = 123;
		MainListSkill.mEffectKill[67] = 122;
		MainListSkill.mEffectKill[68] = 120;
		MainListSkill.mEffectKill[69] = 121;
	}

	// Token: 0x060009BF RID: 2495 RVA: 0x000A4D30 File Offset: 0x000A2F30
	public static void setKill(int typeclass)
	{
		Player.mKillPlayer = new int[TabSkillsNew.vecPaintSkill.size()];
		for (int i = 0; i < Player.mKillPlayer.Length; i++)
		{
			Player.mKillPlayer[i] = MainListSkill.mSkillAllClasses[typeclass][i];
		}
	}

	// Token: 0x060009C0 RID: 2496 RVA: 0x000A4D7C File Offset: 0x000A2F7C
	public int setDirection(MainObject idFrom, MainObject idTo)
	{
		int num = idFrom.x - idTo.x;
		int num2 = idFrom.y - idTo.y;
		int result;
		if (CRes.abs(num) > CRes.abs(num2))
		{
			if (num > 0)
			{
				result = 2;
			}
			else
			{
				result = 3;
			}
		}
		else if (num2 > 0)
		{
			result = 1;
		}
		else
		{
			result = 0;
		}
		return result;
	}

	// Token: 0x060009C1 RID: 2497 RVA: 0x000A4DDC File Offset: 0x000A2FDC
	public static int getRange(int index)
	{
		Skill skillFormId = MainListSkill.getSkillFormId(index);
		if (skillFormId != null)
		{
			return (int)skillFormId.range;
		}
		return 50;
	}

	// Token: 0x060009C2 RID: 2498 RVA: 0x000A4E00 File Offset: 0x000A3000
	public static Skill getSkillFormId(int id)
	{
		for (int i = 0; i < TabSkillsNew.vecPaintSkill.size(); i++)
		{
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(i);
			if (skill.Id == id)
			{
				return skill;
			}
		}
		return null;
	}

	// Token: 0x040010E9 RID: 4329
	public const sbyte KILL_STONE_DROP_MORE = 5;

	// Token: 0x040010EA RID: 4330
	public const sbyte KILL_CRACK_EARTH = 6;

	// Token: 0x040010EB RID: 4331
	public const sbyte KILL_ARROW_RAIN = 14;

	// Token: 0x040010EC RID: 4332
	public const sbyte KILL_KIEM_LV1 = 15;

	// Token: 0x040010ED RID: 4333
	public const sbyte KILL_SUNG_LV2 = 18;

	// Token: 0x040010EE RID: 4334
	public const sbyte KILL_SUNG_LV3 = 19;

	// Token: 0x040010EF RID: 4335
	public const sbyte KILL_PS_LV2 = 20;

	// Token: 0x040010F0 RID: 4336
	public const sbyte KILL_KIEM_LV3 = 21;

	// Token: 0x040010F1 RID: 4337
	public const sbyte KILL_2KIEM_LV2 = 22;

	// Token: 0x040010F2 RID: 4338
	public const sbyte KILL_KIEM_LV2 = 23;

	// Token: 0x040010F3 RID: 4339
	public const sbyte KILL_SUNG_LV4 = 24;

	// Token: 0x040010F4 RID: 4340
	public const sbyte KILL_2KIEM_LV4 = 27;

	// Token: 0x040010F5 RID: 4341
	public const sbyte KILL_PS_LV1 = 31;

	// Token: 0x040010F6 RID: 4342
	public const sbyte KILL_2KIEM_LV5 = 34;

	// Token: 0x040010F7 RID: 4343
	public const sbyte KILL_NULL = 35;

	// Token: 0x040010F8 RID: 4344
	public const sbyte KILL_2KIEM_TRUNGDOC = 36;

	// Token: 0x040010F9 RID: 4345
	public const sbyte KILL_2KIEM_GAIDOC = 37;

	// Token: 0x040010FA RID: 4346
	public const sbyte KILL_PS_XUNGKICH = 39;

	// Token: 0x040010FB RID: 4347
	public const sbyte KILL_SUNG_LASER = 40;

	// Token: 0x040010FC RID: 4348
	public const sbyte KILL_KIEM_FIRE = 41;

	// Token: 0x040010FD RID: 4349
	public const sbyte KILL_KIEM_LV6 = 42;

	// Token: 0x040010FE RID: 4350
	public const sbyte KILL_KIEM_LV7 = 43;

	// Token: 0x040010FF RID: 4351
	public const sbyte KILL_2KIEM_CRI = 44;

	// Token: 0x04001100 RID: 4352
	public const sbyte KILL_BUFF = 45;

	// Token: 0x04001101 RID: 4353
	public const sbyte KILL_PS_CAU_NOILUC = 46;

	// Token: 0x04001102 RID: 4354
	public const sbyte KILL_PS_DONGDAT = 47;

	// Token: 0x04001103 RID: 4355
	public const sbyte KILL_PS_ICE_RAIN = 48;

	// Token: 0x04001104 RID: 4356
	public const sbyte KILL_SUNG_BAO_DAN = 49;

	// Token: 0x04001105 RID: 4357
	public const sbyte KILL_SUNG_SET_NEW = 50;

	// Token: 0x04001106 RID: 4358
	public const sbyte KILL_PS_ICE_UP = 51;

	// Token: 0x04001107 RID: 4359
	public const sbyte KILL_SUNG_RAIN_ROCKET = 52;

	// Token: 0x04001108 RID: 4360
	public const sbyte KILL_SUNG_RAIN_LIGHTNING = 53;

	// Token: 0x04001109 RID: 4361
	public const sbyte EFF_KIEMLON_NGU = 54;

	// Token: 0x0400110A RID: 4362
	public const sbyte EFF_KIEMNHO_TROI = 55;

	// Token: 0x0400110B RID: 4363
	public const sbyte EFF_PHAP_SU_BANG = 56;

	// Token: 0x0400110C RID: 4364
	public const sbyte EFF_SUNGNGU = 57;

	// Token: 0x0400110D RID: 4365
	public const sbyte EFF_CHIEN_BINH_BUFFDAME = 58;

	// Token: 0x0400110E RID: 4366
	public const sbyte EFF_THICH_KHACH_BUFFHP = 59;

	// Token: 0x0400110F RID: 4367
	public const sbyte EFF_XA_THU_BUFF_BUFFAMOR = 60;

	// Token: 0x04001110 RID: 4368
	public const sbyte EFF_PHAP_SU_BUFFGOLD = 61;

	// Token: 0x04001111 RID: 4369
	public const sbyte KILL_PHAP_SU_115 = 62;

	// Token: 0x04001112 RID: 4370
	public const sbyte KILL_SUNG_115 = 63;

	// Token: 0x04001113 RID: 4371
	public const sbyte KILL_BIG_SWORD_115 = 64;

	// Token: 0x04001114 RID: 4372
	public const sbyte KILL_SMALL_SWORD_115 = 65;

	// Token: 0x04001115 RID: 4373
	public const sbyte KILL_PHAP_SU_115_2 = 66;

	// Token: 0x04001116 RID: 4374
	public const sbyte KILL_SUNG_115_2 = 67;

	// Token: 0x04001117 RID: 4375
	public const sbyte KILL_BIG_SWORD_115_2 = 68;

	// Token: 0x04001118 RID: 4376
	public const sbyte KILL_SMALL_SWORD_115_2 = 69;

	// Token: 0x04001119 RID: 4377
	public static MainListSkill me;

	// Token: 0x0400111A RID: 4378
	private int typeKill;

	// Token: 0x0400111B RID: 4379
	private int maxSize;

	// Token: 0x0400111C RID: 4380
	public static int[][] mSkillAllClasses = new int[][]
	{
		new int[]
		{
			15,
			23,
			41,
			21,
			5,
			42,
			43,
			42,
			5,
			0,
			0,
			0,
			0,
			45,
			45,
			0,
			0,
			54,
			58,
			64,
			68
		},
		new int[]
		{
			15,
			44,
			36,
			22,
			37,
			27,
			34,
			27,
			14,
			0,
			0,
			0,
			0,
			45,
			45,
			0,
			0,
			55,
			60,
			65,
			69
		},
		new int[]
		{
			31,
			46,
			20,
			39,
			51,
			6,
			48,
			47,
			48,
			0,
			0,
			0,
			0,
			45,
			45,
			0,
			0,
			56,
			61,
			62,
			66
		},
		new int[]
		{
			31,
			19,
			18,
			24,
			40,
			49,
			50,
			52,
			53,
			0,
			0,
			0,
			0,
			45,
			45,
			0,
			0,
			57,
			59,
			63,
			67
		},
		new int[]
		{
			0,
			1,
			2,
			3,
			4,
			5,
			6,
			7,
			8,
			9,
			10,
			11,
			12,
			13,
			14,
			15,
			16,
			17,
			18,
			19,
			20,
			21,
			22,
			23,
			24,
			25,
			26,
			27,
			70,
			70,
			70,
			70
		},
		new int[10],
		new int[]
		{
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45,
			45
		}
	};

	// Token: 0x0400111D RID: 4381
	public static int[][] mBuffAllClasses;

	// Token: 0x0400111E RID: 4382
	public static int[] mRange;

	// Token: 0x0400111F RID: 4383
	public static int[] mPlash;

	// Token: 0x04001120 RID: 4384
	public static int[] mFramePlash;

	// Token: 0x04001121 RID: 4385
	public static int[] mEffectKill;
}
