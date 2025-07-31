using System;

// Token: 0x0200004E RID: 78
public class MainClan
{
	// Token: 0x06000368 RID: 872 RVA: 0x0002E1E4 File Offset: 0x0002C3E4
	public MainClan(int IdClan, short idicon, string shortname, sbyte chucvu)
	{
		this.IdClan = IdClan;
		this.IdIcon = idicon;
		this.shortName = shortname.ToUpper();
		this.chucvu = chucvu;
	}

	// Token: 0x06000369 RID: 873 RVA: 0x0002E21C File Offset: 0x0002C41C
	public void setInfoClan(string nameClan, short Lv, short ptlv, short hang, short numMem, short maxMem, string slogan, string noiquy, string nameBoss, long coin, int gold, MainThanhTichClan[] thanhtich)
	{
		this.name = nameClan;
		this.Lv = (int)Lv;
		this.ptLv = (int)ptlv;
		this.hang = (int)hang;
		this.numMem = (int)numMem;
		this.maxMem = (int)maxMem;
		this.slogan = slogan;
		this.noiquy = noiquy;
		this.nameThuLinh = nameBoss;
		this.coin = coin;
		this.gold = gold;
		this.mthanhtich = thanhtich;
	}

	// Token: 0x0600036A RID: 874 RVA: 0x0002E288 File Offset: 0x0002C488
	public bool setAddMem()
	{
		return (int)this.chucvu == 127 || (int)this.chucvu == 126;
	}

	// Token: 0x0600036B RID: 875 RVA: 0x0002E2AC File Offset: 0x0002C4AC
	public int getEffChucVu()
	{
		if ((int)this.chucvu == 127)
		{
			return 13;
		}
		if ((int)this.chucvu == 126)
		{
			return 7;
		}
		return -1;
	}

	// Token: 0x0600036C RID: 876 RVA: 0x0002E2DC File Offset: 0x0002C4DC
	public bool getChucNang()
	{
		return (int)this.chucvu == 127 || (int)this.chucvu == 126 || (int)this.chucvu == 125;
	}

	// Token: 0x0600036D RID: 877 RVA: 0x0002E30C File Offset: 0x0002C50C
	public static string getNameChucVu(sbyte chuc)
	{
		if ((int)chuc >= 121 && (int)chuc <= 127)
		{
			return T.mChucVuClan[127 - (int)chuc];
		}
		return string.Empty;
	}

	// Token: 0x04000499 RID: 1177
	public const sbyte THU_LINH = 127;

	// Token: 0x0400049A RID: 1178
	public const sbyte PHO_CHI_HUY = 126;

	// Token: 0x0400049B RID: 1179
	public const sbyte DAI_HIEP_SI = 125;

	// Token: 0x0400049C RID: 1180
	public const sbyte HIEP_SI_CAO_QUI = 124;

	// Token: 0x0400049D RID: 1181
	public const sbyte HIEP_SI_DANH_DU = 123;

	// Token: 0x0400049E RID: 1182
	public const sbyte THANH_VIEN_MOI = 122;

	// Token: 0x0400049F RID: 1183
	public const sbyte DA_ROI_CLAN = 121;

	// Token: 0x040004A0 RID: 1184
	public const sbyte XIN_GIA_NHAP = 0;

	// Token: 0x040004A1 RID: 1185
	public const sbyte TIM_CLAN_NAME = 1;

	// Token: 0x040004A2 RID: 1186
	public const sbyte THONG_BAO = 2;

	// Token: 0x040004A3 RID: 1187
	public const sbyte ACCEP_JOIN_CLAN = 3;

	// Token: 0x040004A4 RID: 1188
	public const sbyte PHONG_CAP = 4;

	// Token: 0x040004A5 RID: 1189
	public const sbyte HA_CAP = 5;

	// Token: 0x040004A6 RID: 1190
	public const sbyte GOP_XU = 6;

	// Token: 0x040004A7 RID: 1191
	public const sbyte GOP_NGOC = 7;

	// Token: 0x040004A8 RID: 1192
	public const sbyte NEXT_ICON_LIST = 8;

	// Token: 0x040004A9 RID: 1193
	public const sbyte INFO_CLAN = 9;

	// Token: 0x040004AA RID: 1194
	public const sbyte INVITE_CLAN = 10;

	// Token: 0x040004AB RID: 1195
	public const sbyte OK_INVITE_CLAN = 11;

	// Token: 0x040004AC RID: 1196
	public const sbyte DELETE_CLAN = 12;

	// Token: 0x040004AD RID: 1197
	public const sbyte MEMBER_LIST = 13;

	// Token: 0x040004AE RID: 1198
	public const sbyte MEMBER_DETAIL = 14;

	// Token: 0x040004AF RID: 1199
	public const sbyte CLAN_DETAIL = 15;

	// Token: 0x040004B0 RID: 1200
	public const sbyte CLAN_SLOGAN = 16;

	// Token: 0x040004B1 RID: 1201
	public const sbyte CLAN_NOIQUY = 17;

	// Token: 0x040004B2 RID: 1202
	public const sbyte REMOVE_MEM = 18;

	// Token: 0x040004B3 RID: 1203
	public const sbyte UPDATE_INFO_CLAN_OBJ = 19;

	// Token: 0x040004B4 RID: 1204
	public const sbyte ERROR_CREATE_NAME = 20;

	// Token: 0x040004B5 RID: 1205
	public const sbyte INVENTORY_CLAN = 21;

	// Token: 0x040004B6 RID: 1206
	public const sbyte X2_XP_CLAN = 22;

	// Token: 0x040004B7 RID: 1207
	public short IdIcon;

	// Token: 0x040004B8 RID: 1208
	public int IdClan;

	// Token: 0x040004B9 RID: 1209
	public string shortName;

	// Token: 0x040004BA RID: 1210
	public string name;

	// Token: 0x040004BB RID: 1211
	public string slogan;

	// Token: 0x040004BC RID: 1212
	public string nameThuLinh;

	// Token: 0x040004BD RID: 1213
	public string noiquy;

	// Token: 0x040004BE RID: 1214
	public int numMem;

	// Token: 0x040004BF RID: 1215
	public int maxMem;

	// Token: 0x040004C0 RID: 1216
	public int Lv;

	// Token: 0x040004C1 RID: 1217
	public int hang;

	// Token: 0x040004C2 RID: 1218
	public int gold;

	// Token: 0x040004C3 RID: 1219
	public int ptLv;

	// Token: 0x040004C4 RID: 1220
	public long coin;

	// Token: 0x040004C5 RID: 1221
	public sbyte frameClan;

	// Token: 0x040004C6 RID: 1222
	public sbyte chucvu;

	// Token: 0x040004C7 RID: 1223
	public sbyte typeX2;

	// Token: 0x040004C8 RID: 1224
	public short timeX2;

	// Token: 0x040004C9 RID: 1225
	public MainThanhTichClan[] mthanhtich;

	// Token: 0x040004CA RID: 1226
	public bool isRemove;
}
