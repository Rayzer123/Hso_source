using System;

// Token: 0x02000071 RID: 113
public class PetWalk : Pet
{
	// Token: 0x06000546 RID: 1350 RVA: 0x0004A7D0 File Offset: 0x000489D0
	public PetWalk(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove) : base(petType, nFrame, imageId, typemove)
	{
		this.owner = owner;
		this.typeObject = 9;
		this.ID = owner.ID;
		this.xAnchor = owner.x;
		this.yAnchor = owner.y;
		this.x = owner.x;
		this.y = owner.y;
		this.oldPosX = owner.x;
		this.oldPosY = owner.y;
		this.wOne = -1;
		this.hOne = -1;
		this.limitMove = 60;
		this.Direction = 0;
		this.vMax = 4;
		this.Action = 0;
		this.state = 0;
		this.timeAutoAction = CRes.random(50, 70);
		this.MonWater = 0;
		this.limitAttack = 30;
		this.timeMaxMoveAttack = 0;
	}

	// Token: 0x06000547 RID: 1351 RVA: 0x0004A8A4 File Offset: 0x00048AA4
	public PetWalk(short petType, int id, sbyte nFrame, sbyte imageId, sbyte typemove) : base(petType, nFrame, imageId, typemove)
	{
		this.owner = null;
		this.typeObject = 9;
		this.ID = id;
		int x = this.posArray[CRes.random(this.posArray.Length)].x;
		int y = this.posArray[CRes.random(this.posArray.Length)].y;
		this.xAnchor = x;
		this.yAnchor = y;
		this.x = x;
		this.y = y;
		this.oldPosX = x;
		this.oldPosY = y;
		this.wOne = -1;
		this.hOne = -1;
		this.limitMove = 120;
		this.Direction = 0;
		this.vMax = 4;
		this.Action = 0;
		this.state = 0;
		this.timeAutoAction = CRes.random(50, 70);
		this.MonWater = 3;
		this.limitAttack = 200;
		this.timeMaxMoveAttack = 0;
	}

	// Token: 0x06000548 RID: 1352 RVA: 0x0004A98C File Offset: 0x00048B8C
	public override void paint(mGraphics g)
	{
		try
		{
			base.paintDataEff_Top(g, this.x, this.y);
			base.paintBuffFirst(g);
			MainImage imagePet = ObjectData.getImagePet((short)this.imageId);
			if ((int)this.state == 1 && (this.Direction == 1 || this.Direction == 0))
			{
				this.Direction = this.PrevDir;
			}
			int num = this.Action;
			if (num > this.mAction.Length - 1)
			{
				num = 0;
			}
			if (this.f > this.mAction[num][(this.Direction <= 2) ? this.Direction : 2].Length - 1)
			{
				this.f = 0;
			}
			if (imagePet.img != null)
			{
				if (this.wOne < 0)
				{
					this.hOne = mImage.getImageHeight(imagePet.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imagePet.img.image) / 2;
				}
				int x = (int)this.mAction[num][(this.Direction <= 2) ? this.Direction : 2][this.f] / 3 * this.wOne;
				int y = (int)this.mAction[num][(this.Direction <= 2) ? this.Direction : 2][this.f] % 3 * this.hOne;
				if (this.isWater)
				{
					g.drawRegion(imagePet.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x + this.xtam, this.y + this.dyWater + 4, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					int num2 = 1;
					g.drawRegion(MainObject.water, 0, ((num == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + num2 + this.xtam, this.y + this.dyWater - 4, 3, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(imagePet.img, x, y, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x + this.xtam, this.y, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			base.paintBuffLast(g);
			base.paintDataEff_Bot(g, this.x, this.y);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x06000549 RID: 1353 RVA: 0x0004AC48 File Offset: 0x00048E48
	protected override void attack()
	{
		if (this.skillDefault == null)
		{
			this.skillDefault = new Monster_Skill(2);
		}
		this.vMax = 9;
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(this.attackCount);
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null)
			{
				this.isRunAttack = false;
				return;
			}
			if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) > this.limitAttack && mainObject.hp > 0)
			{
				this.toX = mainObject.x;
				this.toY = mainObject.y;
				this.move_to_XY();
			}
			else if (GameCanvas.timeNow - this.timeBeginMoveAttack > (long)this.timeMaxMoveAttack)
			{
				this.IDAttack = (int)object_Effect_Skill.ID;
				object_Effect_Skill.skillMonster = this.skillDefault;
				this.beginFire();
				base.addAttackEffect();
				this.timeMaxMoveAttack = 200;
				this.timeBeginMoveAttack = GameCanvas.timeNow;
				if ((int)this.attackType == 2)
				{
					if (this.attackCount >= this.vecObjskill.size() - 1)
					{
						this.isDoneAttack = false;
						base.setState(4);
						this.attackCount = 0;
					}
				}
				else if ((int)this.attackType == 5 && this.attackCount == 3)
				{
					this.isDoneAttack = false;
					base.setState(4);
					this.attackCount = 0;
				}
			}
		}
	}
}
