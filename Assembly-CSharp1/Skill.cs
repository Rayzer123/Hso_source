using System;

// Token: 0x020000D1 RID: 209
public class Skill
{
	// Token: 0x060009C8 RID: 2504 RVA: 0x000A53C0 File Offset: 0x000A35C0
	public void setContent()
	{
	}

	// Token: 0x060009C9 RID: 2505 RVA: 0x000A53C4 File Offset: 0x000A35C4
	public void paint(mGraphics g, int x, int y, int achor)
	{
		MainImage imageSkill = ObjectData.getImageSkill((short)this.iconId);
		if (imageSkill.img != null)
		{
			g.drawImage(imageSkill.img, x, y, achor, mGraphics.isTrue);
		}
		else
		{
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, achor, mGraphics.isTrue);
		}
	}

	// Token: 0x060009CA RID: 2506 RVA: 0x000A5428 File Offset: 0x000A3628
	public void paintSmall(mGraphics g, int x, int y, int achor)
	{
		MainImage imageSkill = ObjectData.getImageSkill((short)this.iconId);
		if (imageSkill.img != null)
		{
			g.drawRegion(imageSkill.img, 1, 1, 18, 18, 0, x, y, achor, mGraphics.isFalse);
		}
		else
		{
			g.drawRegion(AvMain.imgLoadImg, 0, GameCanvas.gameTick % 12 * 16, 16, 16, 0, x, y, achor, mGraphics.isFalse);
		}
	}

	// Token: 0x060009CB RID: 2507 RVA: 0x000A5494 File Offset: 0x000A3694
	public string[] getContent()
	{
		if (this.mcontent == null)
		{
			if (GameScreen.player.Lv < this.lvMin)
			{
				string[] array = mFont.tahoma_7_white.splitFontArray(this.detail, (MainTabNew.longwidth <= 0) ? 126 : (MainTabNew.longwidth - 10));
				this.mcontent = new string[array.Length + 1];
				if (GameScreen.player.Lv < this.lvMin)
				{
					this.mcontent[0] = T.yeucau + T.level + this.lvMin;
				}
				for (int i = 1; i < this.mcontent.Length; i++)
				{
					this.mcontent[i] = array[i - 1];
				}
			}
			else
			{
				int num = Player.mCurentLvSkill[this.Id];
				if (num > 0)
				{
					num += Player.mPlusLvSkill[this.Id];
				}
				int num2 = num - 1;
				if (num2 < 0)
				{
					num2 = 0;
				}
				if (this.Id == 0 || num2 >= 15)
				{
					num2 = 0;
				}
				LvSkill lvSkill = this.mLvSkill[num2];
				string[] array2 = lvSkill.getinfo();
				string[] array3 = this.mInfoSkill(num2, Player.mCurentLvSkill[this.Id] == 0);
				int num3 = array2.Length + array3.Length + lvSkill.minfo.Length;
				this.mcontent = new string[num3];
				num3 = 0;
				for (int j = 0; j < array3.Length; j++)
				{
					this.mcontent[num3] = array3[j];
					num3++;
				}
				for (int k = 0; k < array2.Length; k++)
				{
					this.mcontent[num3] = array2[k];
					num3++;
				}
				for (int l = 0; l < lvSkill.minfo.Length; l++)
				{
					this.mcontent[num3] = Item.nameInfoItem[lvSkill.minfo[l].id] + ": " + Item.getPercent((int)Item.isPercentInfoItem[lvSkill.minfo[l].id], lvSkill.minfo[l].value);
					num3++;
				}
			}
		}
		return this.mcontent;
	}

	// Token: 0x060009CC RID: 2508 RVA: 0x000A56CC File Offset: 0x000A38CC
	public string[] mInfoSkill(int levelSkill, bool ischuahoc)
	{
		int num = 0;
		string[] array = mFont.tahoma_7_white.splitFontArray(this.detail, (MainTabNew.longwidth <= 0) ? 126 : (MainTabNew.longwidth - 10));
		num += array.Length + 1;
		if (ischuahoc)
		{
			num++;
		}
		else if (Player.mCurentLvSkill[this.Id] < 10 && this.Id != 0)
		{
			num++;
		}
		if ((int)this.typeSkill == 1)
		{
			num++;
		}
		if (this.mLvSkill[levelSkill].range_lan > 0)
		{
			num++;
		}
		string[] array2 = new string[num];
		num = 0;
		if (ischuahoc)
		{
			array2[num] = T.chuahoc;
			num++;
		}
		else if (Player.mCurentLvSkill[this.Id] < 10 && this.Id != 0)
		{
			array2[num] = T.nangcapyeucau + this.mLvSkill[levelSkill].LvRe;
			num++;
		}
		string text = "[" + T.kynang + T.active + "]";
		if ((int)this.typeSkill == 1)
		{
			text = "[" + T.kynang + T.buff + "]";
		}
		else if ((int)this.typeSkill == 2)
		{
			text = "[" + T.kynang + T.passive + "]";
		}
		array2[num] = text;
		num++;
		for (int i = 0; i < array.Length; i++)
		{
			array2[num] = array[i];
			num++;
		}
		if ((int)this.typeSkill == 1)
		{
			string text2 = T.tacdunglen + " : ";
			switch (this.typeBuff)
			{
			case 0:
				text2 += T.moinguoi;
				break;
			case 1:
				text2 += T.banthan;
				break;
			case 2:
				text2 += T.trongdoi;
				break;
			case 3:
				text2 += T.kethu;
				break;
			}
			array2[num++] = text2;
		}
		if (this.mLvSkill[levelSkill].range_lan > 0)
		{
			array2[num++] = T.phamvilan + this.mLvSkill[levelSkill].range_lan;
		}
		return array2;
	}

	// Token: 0x060009CD RID: 2509 RVA: 0x000A5930 File Offset: 0x000A3B30
	public static void resetContent()
	{
		for (int i = 0; i < TabSkillsNew.vecPaintSkill.size(); i++)
		{
			Skill skill = (Skill)TabSkillsNew.vecPaintSkill.elementAt(i);
			skill.mcontent = null;
		}
	}

	// Token: 0x0400114C RID: 4428
	public const sbyte ACTIVE = 0;

	// Token: 0x0400114D RID: 4429
	public const sbyte BUFF = 1;

	// Token: 0x0400114E RID: 4430
	public const sbyte PASSIVE = 2;

	// Token: 0x0400114F RID: 4431
	public const sbyte BUFF_ALL = 0;

	// Token: 0x04001150 RID: 4432
	public const sbyte BUFF_ME = 1;

	// Token: 0x04001151 RID: 4433
	public const sbyte BUFF_TEAM = 2;

	// Token: 0x04001152 RID: 4434
	public const sbyte BUFF_ENEMY = 3;

	// Token: 0x04001153 RID: 4435
	public static mHashTable hashImageSkill = new mHashTable();

	// Token: 0x04001154 RID: 4436
	public int Id;

	// Token: 0x04001155 RID: 4437
	public string name;

	// Token: 0x04001156 RID: 4438
	public string detail;

	// Token: 0x04001157 RID: 4439
	public sbyte typeSkill;

	// Token: 0x04001158 RID: 4440
	public sbyte iconId;

	// Token: 0x04001159 RID: 4441
	public sbyte typeBuff;

	// Token: 0x0400115A RID: 4442
	public sbyte subEff;

	// Token: 0x0400115B RID: 4443
	public short range;

	// Token: 0x0400115C RID: 4444
	public short lvMin;

	// Token: 0x0400115D RID: 4445
	public short performDur;

	// Token: 0x0400115E RID: 4446
	public LvSkill[] mLvSkill;

	// Token: 0x0400115F RID: 4447
	public string[] mcontent;

	// Token: 0x04001160 RID: 4448
	public sbyte typePaint;
}
