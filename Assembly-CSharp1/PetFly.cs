using System;

// Token: 0x0200006E RID: 110
public class PetFly : Pet
{
	// Token: 0x06000527 RID: 1319 RVA: 0x000484D4 File Offset: 0x000466D4
	public PetFly(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove) : base(petType, nFrame, imageId, typemove)
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
		this.limitMove = 48;
		this.Direction = 0;
		this.vMax = 4;
		this.Action = 0;
		this.state = 0;
		this.timeAutoAction = CRes.random(200, 250);
		this.MonWater = 0;
		this.limitAttack = 10;
		this.timeMaxMoveAttack = 0;
		this.yfly = 50;
		if ((int)imageId == 3 || (int)imageId == 9)
		{
			this.dyshadow = 0;
		}
		else
		{
			this.dyshadow = 6;
		}
	}

	// Token: 0x06000528 RID: 1320 RVA: 0x000485F0 File Offset: 0x000467F0
	public PetFly(short typePet, int id, sbyte frame, sbyte imageId, sbyte typemove) : base(typePet, frame, imageId, typemove)
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
		this.limitMove = 48;
		this.Direction = 0;
		this.vMax = 4;
		this.Action = 0;
		this.state = 0;
		this.timeAutoAction = CRes.random(200, 250);
		this.MonWater = 3;
		this.limitAttack = 10;
		this.timeMaxMoveAttack = 0;
		this.yfly = 50;
		if ((int)imageId == 3 || (int)imageId == 9)
		{
			this.dyshadow = 0;
		}
		else
		{
			this.dyshadow = 6;
		}
	}

	// Token: 0x06000529 RID: 1321 RVA: 0x0004871C File Offset: 0x0004691C
	protected override void roam()
	{
		sbyte typemove = this.typemove;
		if (typemove != 1)
		{
			if (typemove == 2)
			{
				this.vMax = 1;
				if (this.Action == 1)
				{
					if ((this.time > this.timeAutoAction || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove) && this.yfly >= 50)
					{
						if (this.count > 20 && !this.isWater)
						{
							this.time = 0;
							this.vx = 0;
							this.vy = 0;
							this.Action = 0;
							this.count = 0;
						}
						if (this.count <= 20)
						{
							this.count++;
						}
					}
				}
				else if (this.Action == 0)
				{
					this.vx = 0;
					this.vy = 0;
					if (this.yfly >= 0)
					{
						this.yfly -= 5;
					}
					if (GameCanvas.gameTick % 30 == 0)
					{
						this.Direction = CRes.random(4);
					}
					if (this.time > this.timeAutoAction && this.yfly <= 0)
					{
						this.time = 0;
						base.setSpeedInDirection(this.vMax);
						this.Action = 1;
					}
				}
				if (this.owner != null)
				{
					if (this.owner.Action == 1)
					{
						if (MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > 40)
						{
							base.setState(1);
						}
					}
					else if (this.owner.Action == 0 && MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > this.limitMove * 2)
					{
						base.setState(3);
					}
				}
				else
				{
					int distance = MainObject.getDistance(this.x, this.y, GameScreen.player.x, GameScreen.player.y);
					if (distance < 80 && distance > 40 && CRes.random(6) == 0)
					{
						base.setState(6);
					}
				}
			}
		}
		else
		{
			this.vMax = 1;
			if (this.Action == 1)
			{
				if (this.time > this.timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove)
				{
					this.time = 0;
					this.Action = 0;
					this.vx = 0;
					this.vy = 0;
				}
			}
			else if (this.Action == 0)
			{
				this.vx = 0;
				this.vy = 0;
				if (this.time > this.timeAutoAction / 2 || CRes.random(12) == 0)
				{
					this.time = 0;
					this.Action = 1;
					this.Direction = CRes.random(4);
					base.setSpeedInDirection(this.vMax);
				}
			}
			if (this.owner != null)
			{
				if (this.owner.Action == 1 && MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > 40)
				{
					base.setState(1);
				}
				if (this.owner.Action == 0 && MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > this.limitMove * 2)
				{
					base.setState(3);
				}
			}
			else
			{
				int distance2 = MainObject.getDistance(this.x, this.y, GameScreen.player.x, GameScreen.player.y);
				if (distance2 < 80 && distance2 > 40 && CRes.random(6) == 0)
				{
					base.setState(6);
				}
			}
		}
	}

	// Token: 0x0600052A RID: 1322 RVA: 0x00048B2C File Offset: 0x00046D2C
	public override void paint(mGraphics g)
	{
		try
		{
			base.paintDataEff_Top(g, this.x, this.y);
			base.paintBuffFirst(g);
			if ((int)this.state == 1 && (this.Direction == 1 || this.Direction == 0))
			{
				this.Direction = this.PrevDir;
			}
			MainImage imagePet = ObjectData.getImagePet((short)this.imageId);
			if (imagePet.img != null)
			{
				if (this.wOne < 0)
				{
					this.hOne = mImage.getImageHeight(imagePet.img.image) / this.nFrame;
					this.wOne = mImage.getImageWidth(imagePet.img.image) / 2;
				}
				g.drawImage(MainObject.shadow, this.x + this.xtam, this.y - (int)this.dyshadow, 3, mGraphics.isFalse);
				if (this.isWater && this.yfly <= 0)
				{
					g.drawRegion(imagePet.img, this.xs, this.ys, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x + this.xtam, this.y + this.dyWater + 8, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
					g.drawRegion(MainObject.water, 0, ((this.Action == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + this.xtam, this.y + this.dyWater - 8, 3, mGraphics.isFalse);
				}
				else
				{
					g.drawRegion(imagePet.img, this.xs, this.ys, this.wOne, this.hOne, (this.Direction <= 2) ? 0 : 2, this.x + this.xtam, this.y - (int)this.yfly, mGraphics.BOTTOM | mGraphics.HCENTER, mGraphics.isFalse);
				}
			}
			base.paintBuffLast(g);
			base.paintDataEff_Bot(g, this.x, this.y);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600052B RID: 1323 RVA: 0x00048D80 File Offset: 0x00046F80
	protected override void attack()
	{
		this.vMax = 12;
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(this.attackCount);
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null || mainObject.hp <= 0)
			{
				this.isRunAttack = false;
				base.setState(4);
				return;
			}
			this.toX = mainObject.x;
			this.toY = mainObject.y;
			this.move_to_XY();
			if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) < 30)
			{
				if (this.yfly >= 15)
				{
					this.yfly -= 15;
				}
				this.f = 4;
				if (this.yfly <= 15)
				{
					base.addAttackEffect();
					base.setState(4);
				}
			}
			else if (this.yfly <= 50)
			{
				this.yfly += 5;
			}
		}
	}

	// Token: 0x0600052C RID: 1324 RVA: 0x00048EAC File Offset: 0x000470AC
	public override void update()
	{
		this.act = this.Action;
		if (this.act > this.mAction.Length - 1)
		{
			this.act = 0;
		}
		if (this.f > this.mAction[this.act][(this.Direction <= 2) ? this.Direction : 2].Length - 1)
		{
			this.f = 0;
		}
		this.fr = (int)this.mAction[this.act][(this.Direction <= 2) ? this.Direction : 2][this.f] / 3;
		this.xs = ((this.fr <= 1) ? this.fr : 1) * this.wOne;
		this.fr = (int)this.mAction[this.act][(this.Direction <= 2) ? this.Direction : 2][this.f];
		this.ys = this.fr % 3 * this.hOne;
		if (this.xs == -1)
		{
			this.xs = 0;
		}
		if (this.ys == -1)
		{
			this.ys = 0;
		}
		if (this.yfly <= 0)
		{
			this.xs = (this.ys = 0);
		}
		if (((this.vx < 0 && this.vy > 0) || (this.vx > 0 && this.vy > 0)) && (int)this.state == 0 && this.yfly >= 30)
		{
			this.f = 3;
			if (this.vx < 0)
			{
				this.vx = -3;
			}
			else
			{
				this.vx = 3;
			}
			if (this.vy < 0)
			{
				this.vy = -3;
			}
			else
			{
				this.vy = 3;
			}
		}
		base.update();
	}

	// Token: 0x0400074D RID: 1869
	public sbyte[] dypet = new sbyte[]
	{
		0,
		5,
		5
	};

	// Token: 0x0400074E RID: 1870
	public sbyte dyshadow;

	// Token: 0x0400074F RID: 1871
	private int xs;

	// Token: 0x04000750 RID: 1872
	private int ys;

	// Token: 0x04000751 RID: 1873
	private int act;

	// Token: 0x04000752 RID: 1874
	private int fr;
}
