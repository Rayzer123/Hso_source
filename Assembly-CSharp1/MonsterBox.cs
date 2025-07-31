using System;

// Token: 0x0200005C RID: 92
public class MonsterBox : MainMonster
{
	// Token: 0x0600048C RID: 1164 RVA: 0x0003FBB0 File Offset: 0x0003DDB0
	public MonsterBox(int ID, int Monster, int typeMonster, string name, int x, int y, int maxHP, int lv)
	{
		this.typeObject = 1;
		this.typeMonster = typeMonster;
		this.ID = ID;
		this.catalogyMonster = Monster;
		this.xAnchor = x;
		this.yAnchor = y;
		this.x = x;
		this.y = y;
		this.name = name;
		this.maxHp = maxHP;
		this.hp = maxHP;
		this.Lv = (short)lv;
		this.MonWater = 1;
		this.Direction = 0;
		this.nFrame = 5;
		this.wOne = (this.hOne = -1);
		this.vMax = 3;
		this.limitMove = 60;
		this.timeAutoAction = CRes.random(50, 70);
		this.limitAttack = 50;
		this.xsai = 0;
		this.ysai = -2;
		this.timeLoadInfo = mSystem.currentTimeMillis();
	}

	// Token: 0x0600048D RID: 1165 RVA: 0x0003FC88 File Offset: 0x0003DE88
	public override void updateAction()
	{
	}

	// Token: 0x0600048E RID: 1166 RVA: 0x0003FC8C File Offset: 0x0003DE8C
	public override void update()
	{
		base.update();
		if (!this.isInfo)
		{
			long num = mSystem.currentTimeMillis();
			long num2 = num - this.timeLoadInfo;
			if (num2 >= 5000L)
			{
				this.timeLoadInfo = num;
				GlobalService.gI().monster_info((short)this.ID);
			}
		}
		base.setDie();
		this.updateAction();
	}

	// Token: 0x0600048F RID: 1167 RVA: 0x0003FCEC File Offset: 0x0003DEEC
	public override bool isItemBox()
	{
		return true;
	}

	// Token: 0x06000490 RID: 1168 RVA: 0x0003FCF0 File Offset: 0x0003DEF0
	public override void paint(mGraphics g)
	{
		if (this.isDie)
		{
			return;
		}
		MainImage imagePartMonster = ObjectData.getImagePartMonster((short)this.catalogyMonster);
		if (imagePartMonster != null && imagePartMonster.img != null)
		{
			g.drawImage(imagePartMonster.img, this.x, this.y, mGraphics.BOTTOM | mGraphics.HCENTER, false);
		}
	}

	// Token: 0x06000491 RID: 1169 RVA: 0x0003FD4C File Offset: 0x0003DF4C
	public override void move_to_XY()
	{
	}

	// Token: 0x06000492 RID: 1170 RVA: 0x0003FD50 File Offset: 0x0003DF50
	public override void move_to_XY_Normal()
	{
	}

	// Token: 0x06000493 RID: 1171 RVA: 0x0003FD54 File Offset: 0x0003DF54
	public override void moveX()
	{
	}

	// Token: 0x06000494 RID: 1172 RVA: 0x0003FD58 File Offset: 0x0003DF58
	public override void moveY()
	{
	}
}
