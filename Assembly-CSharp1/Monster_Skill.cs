using System;

// Token: 0x020000D0 RID: 208
public class Monster_Skill
{
	// Token: 0x060009C3 RID: 2499 RVA: 0x000A4E48 File Offset: 0x000A3048
	public Monster_Skill(sbyte id)
	{
		switch (id)
		{
		case 0:
		case 2:
		case 4:
		case 6:
		case 8:
		case 10:
		case 12:
			this.typeSkill = 50;
			this.typeSub = (sbyte)((int)id / 2);
			this.nPlash = 1;
			break;
		case 1:
		case 3:
		case 5:
		case 7:
		case 9:
		case 11:
		case 13:
			this.typeSkill = 50;
			this.typeSub = (sbyte)((int)id / 2);
			this.nPlash = 2;
			break;
		case 14:
		case 16:
		case 18:
		case 20:
		case 22:
		case 24:
		case 26:
			this.typeSkill = 0;
			this.typeSub = (sbyte)(((int)id - 14) / 2);
			this.nPlash = 1;
			break;
		case 15:
		case 17:
		case 19:
		case 21:
		case 23:
		case 25:
		case 27:
			this.typeSkill = 0;
			this.typeSub = (sbyte)(((int)id - 14) / 2);
			this.nPlash = 2;
			break;
		case 28:
		case 30:
			this.typeSkill = 2;
			this.typeSub = (sbyte)(((int)id - 28) / 2);
			this.nPlash = 1;
			break;
		case 29:
		case 31:
			this.typeSkill = 2;
			this.typeSub = (sbyte)(((int)id - 28) / 2);
			this.nPlash = 2;
			break;
		case 32:
			this.typeSkill = 71;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 33:
			this.typeSkill = 72;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 34:
			this.typeSkill = 73;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 35:
			this.typeSkill = 74;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 36:
			this.typeSkill = 75;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 37:
			this.typeSkill = 76;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 38:
			this.typeSkill = 77;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 39:
			this.typeSkill = 14;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 40:
			this.typeSkill = 78;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 41:
			this.typeSkill = 79;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 44:
			this.typeSkill = 93;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 45:
			this.typeSkill = 94;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 46:
			this.typeSkill = 95;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 47:
			this.typeSkill = 96;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 48:
			this.typeSkill = 97;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 49:
			this.typeSkill = 98;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 50:
			this.typeSkill = 99;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 51:
			this.typeSkill = 100;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 54:
			this.typeSkill = 104;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 55:
			this.typeSkill = 105;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 56:
			this.typeSkill = 106;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 59:
			this.typeSkill = 108;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 61:
			this.typeSkill = 113;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 62:
			this.typeSkill = 114;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 63:
			this.typeSkill = 115;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 64:
			this.typeSkill = 124;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 65:
			this.typeSkill = 125;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		case 66:
			this.typeSkill = 126;
			this.typeSub = 0;
			this.nPlash = 1;
			break;
		}
		this.getRange((int)id);
	}

	// Token: 0x060009C5 RID: 2501 RVA: 0x000A5344 File Offset: 0x000A3544
	public void getRange(int id)
	{
		try
		{
			this.range = int.Parse(Monster_Skill.hashMonsterSkillInfo.get(string.Empty + id).ToString());
		}
		catch (Exception ex)
		{
			this.range = 40;
		}
	}

	// Token: 0x04001122 RID: 4386
	public const sbyte S_NEAR = 50;

	// Token: 0x04001123 RID: 4387
	public const sbyte S_FAR = 0;

	// Token: 0x04001124 RID: 4388
	public const sbyte S_BUFF = 2;

	// Token: 0x04001125 RID: 4389
	public const sbyte S_BOSS_CAY_1 = 71;

	// Token: 0x04001126 RID: 4390
	public const sbyte S_BOSS_CAY_2 = 72;

	// Token: 0x04001127 RID: 4391
	public const sbyte S_BOSS_ONG_1 = 73;

	// Token: 0x04001128 RID: 4392
	public const sbyte S_BOSS_ONG_2 = 74;

	// Token: 0x04001129 RID: 4393
	public const sbyte S_BOSS_CUA_1 = 75;

	// Token: 0x0400112A RID: 4394
	public const sbyte S_BOSS_CUA_2 = 76;

	// Token: 0x0400112B RID: 4395
	public const sbyte S_BOSS_SOI_1 = 77;

	// Token: 0x0400112C RID: 4396
	public const sbyte S_BOSS_SOI_2 = 14;

	// Token: 0x0400112D RID: 4397
	public const sbyte S_BOSS_NGUOIDA_1 = 78;

	// Token: 0x0400112E RID: 4398
	public const sbyte S_BOSS_NGUOIDA_2 = 79;

	// Token: 0x0400112F RID: 4399
	public const sbyte S_BOSS_DE_1 = 93;

	// Token: 0x04001130 RID: 4400
	public const sbyte S_BOSS_DE_2 = 94;

	// Token: 0x04001131 RID: 4401
	public const sbyte S_BOSS_NOEL_1 = 113;

	// Token: 0x04001132 RID: 4402
	public const sbyte S_BOSS_NOEL_2 = 114;

	// Token: 0x04001133 RID: 4403
	public const sbyte S_BOSS_NOEL_3 = 115;

	// Token: 0x04001134 RID: 4404
	public const sbyte S_BOSS_CHIEM_THANH = 124;

	// Token: 0x04001135 RID: 4405
	public const sbyte S_TRU_THANH_1 = 125;

	// Token: 0x04001136 RID: 4406
	public const sbyte S_TRU_THANH_2 = 126;

	// Token: 0x04001137 RID: 4407
	public const sbyte S_Tower1 = 95;

	// Token: 0x04001138 RID: 4408
	public const sbyte S_Tower2 = 96;

	// Token: 0x04001139 RID: 4409
	public const sbyte S_Tower3 = 97;

	// Token: 0x0400113A RID: 4410
	public const sbyte S_Tower4 = 98;

	// Token: 0x0400113B RID: 4411
	public const sbyte S_Medusa1 = 99;

	// Token: 0x0400113C RID: 4412
	public const sbyte S_Medusa2 = 100;

	// Token: 0x0400113D RID: 4413
	public const sbyte S_BOSS_34_Dam_Tung = 104;

	// Token: 0x0400113E RID: 4414
	public const sbyte S_BOSS_84 = 103;

	// Token: 0x0400113F RID: 4415
	public const sbyte S_BOSS_34_Laser = 105;

	// Token: 0x04001140 RID: 4416
	public const sbyte S_BOSS_34_Laser_Lan = 106;

	// Token: 0x04001141 RID: 4417
	public const sbyte S_BOSS_84_Ston_Drop_More = 108;

	// Token: 0x04001142 RID: 4418
	public const sbyte SUB_VATLY = 0;

	// Token: 0x04001143 RID: 4419
	public const sbyte SUB_BANG = 1;

	// Token: 0x04001144 RID: 4420
	public const sbyte SUB_LUA = 2;

	// Token: 0x04001145 RID: 4421
	public const sbyte SUB_DIEN = 3;

	// Token: 0x04001146 RID: 4422
	public const sbyte SUB_DOC = 4;

	// Token: 0x04001147 RID: 4423
	public sbyte typeSkill;

	// Token: 0x04001148 RID: 4424
	public sbyte typeSub;

	// Token: 0x04001149 RID: 4425
	public sbyte nPlash;

	// Token: 0x0400114A RID: 4426
	public int range;

	// Token: 0x0400114B RID: 4427
	public static mHashTable hashMonsterSkillInfo = new mHashTable();
}
