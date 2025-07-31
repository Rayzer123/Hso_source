using System;

// Token: 0x020000CE RID: 206
public class LvSkill
{
	// Token: 0x060009B9 RID: 2489 RVA: 0x000A4784 File Offset: 0x000A2984
	public int getdelay()
	{
		if (GameScreen.player.timeCombo > 0)
		{
			return GameScreen.player.timeCombo;
		}
		return this.delay;
	}

	// Token: 0x060009BA RID: 2490 RVA: 0x000A47A8 File Offset: 0x000A29A8
	public string[] getinfo()
	{
		int num = 0;
		if (this.mpLost > 0)
		{
			num++;
		}
		if (this.timeBuff > 0)
		{
			num++;
		}
		if ((int)this.per_Sub_Eff > 0)
		{
			num++;
		}
		if (this.time_Sub_Eff > 0)
		{
			num++;
		}
		if (this.plus_Hp > 0)
		{
			num++;
		}
		if (this.plus_Mp > 0)
		{
			num++;
		}
		if (this.delay > 0)
		{
			num++;
		}
		string[] array = new string[num];
		num = 0;
		if (this.mpLost > 0)
		{
			array[num++] = T.nangluong + this.mpLost;
		}
		if (this.delay > 0)
		{
			array[num++] = T.delay + this.delay / 1000 + "s";
		}
		if (this.timeBuff > 0)
		{
			array[num++] = T.timebuff + this.timeBuff / 1000 + "s";
		}
		if ((int)this.per_Sub_Eff > 0)
		{
			array[num++] = T.hieuung + this.per_Sub_Eff;
		}
		if (this.time_Sub_Eff > 0)
		{
			array[num++] = T.timehieuung + (int)(this.time_Sub_Eff / 1000) + "s";
		}
		if (this.plus_Hp > 0)
		{
			array[num++] = T.tanghpdung + (int)(this.plus_Hp / 10) + "%";
		}
		if (this.plus_Mp > 0)
		{
			array[num++] = T.tangmpdung + (int)(this.plus_Mp / 10) + "%";
		}
		return array;
	}

	// Token: 0x040010DE RID: 4318
	public short mpLost;

	// Token: 0x040010DF RID: 4319
	public short time_Sub_Eff;

	// Token: 0x040010E0 RID: 4320
	public short plus_Hp;

	// Token: 0x040010E1 RID: 4321
	public short plus_Mp;

	// Token: 0x040010E2 RID: 4322
	public short LvRe;

	// Token: 0x040010E3 RID: 4323
	public short range_lan;

	// Token: 0x040010E4 RID: 4324
	public int delay;

	// Token: 0x040010E5 RID: 4325
	public int timeBuff;

	// Token: 0x040010E6 RID: 4326
	public sbyte per_Sub_Eff;

	// Token: 0x040010E7 RID: 4327
	public sbyte nTarget;

	// Token: 0x040010E8 RID: 4328
	public MainInfoItem[] minfo;
}
