using System;

// Token: 0x02000070 RID: 112
public class PetTool : Pet
{
	// Token: 0x06000538 RID: 1336 RVA: 0x0004988C File Offset: 0x00047A8C
	public PetTool()
	{
	}

	// Token: 0x06000539 RID: 1337 RVA: 0x00049894 File Offset: 0x00047A94
	public PetTool(short typePet, sbyte nFrame, sbyte imageId, sbyte typemove) : base(typePet, nFrame, imageId, typemove)
	{
	}

	// Token: 0x0600053A RID: 1338 RVA: 0x000498A4 File Offset: 0x00047AA4
	public PetTool(MainObject owner, short petType, sbyte nFrame, sbyte imageId, sbyte typemove) : base(petType, nFrame, imageId, typemove)
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
		this.isPetTool = true;
	}

	// Token: 0x0600053B RID: 1339 RVA: 0x00049984 File Offset: 0x00047B84
	public PetTool(short typePet, int id, sbyte frame, sbyte imageId, sbyte typemove) : base(typePet, frame, imageId, typemove)
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
		this.mAction = 0;
		this.state = 0;
		this.timeAutoAction = CRes.random(200, 250);
		this.MonWater = 3;
		this.limitAttack = 10;
		this.timeMaxMoveAttack = 0;
		this.isPetTool = true;
	}

	// Token: 0x0600053C RID: 1340 RVA: 0x00049A7C File Offset: 0x00047C7C
	public override void paint(mGraphics g)
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.imageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		if (mVector.size() == 0)
		{
			return;
		}
		try
		{
			DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
			if (dataEffect != null)
			{
				base.paintDataEff_Top(g, this.x, this.y);
				int action = (int)this.mAction;
				if ((int)this.state == 2 && this.isBeginAttack)
				{
					action = 3;
				}
				int num = 0;
				int action2 = this.Action;
				if (this.isFly())
				{
					num = 35;
					g.drawImage(MainObject.shadow, this.x, this.y - 6, 3, mGraphics.isFalse);
				}
				else
				{
					if (!this.isWater)
					{
						g.drawImage(MainObject.shadow, this.x, this.y, 3, mGraphics.isFalse);
					}
					if (this.isWater)
					{
						g.drawRegion(MainObject.water, 0, ((action2 == 0) ? 0 : 2) * 17 + GameCanvas.gameTick / 2 % 2 * 17, 28, 17, 0, this.x + 1 + this.xtam, this.y + this.dyWater - 4, 3, mGraphics.isFalse);
					}
				}
				MainImage imagePet = ObjectData.getImagePet((short)this.imageId);
				mVector mVector3 = (mVector)Pet.PET_DATA.get(string.Empty + this.imageId);
				if (mVector3 != null && imagePet != null && imagePet.img != null)
				{
					dataEffect.paintPet(g, dataEffect.getFrame(this.frame, action, this.huongY), this.x, this.y - num, this.flip, imagePet.img);
				}
				base.paintDataEff_Bot(g, this.x, this.y);
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600053D RID: 1341 RVA: 0x00049C94 File Offset: 0x00047E94
	public void doChangeFrmaeBoss()
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.imageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		if (mVector.size() > 0)
		{
			DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
			int action = (int)this.mAction;
			if ((int)this.state == 2 && this.isBeginAttack)
			{
				action = 3;
			}
			this.frame = (int)((sbyte)((this.frame + 1) % dataEffect.getAnim(action, this.huongY).frame.Length));
			if (this.maxAttack == 0)
			{
				this.maxAttack = dataEffect.getAnim(3, this.huongY).frame.Length;
			}
		}
	}

	// Token: 0x0600053E RID: 1342 RVA: 0x00049D5C File Offset: 0x00047F5C
	public override void update()
	{
		this.doChangeFrmaeBoss();
		try
		{
			base.update();
			int tile = GameCanvas.loadmap.getTile(this.x + this.vx, this.y + this.vy);
			base.setMove(this.MonWater, tile);
			if (this.owner != null)
			{
				if (MainObject.getDistance(this.x, this.y, this.toX, this.toY) <= 10)
				{
					this.wayPoint.removeElementAt(0);
				}
				this.xAnchor = this.owner.x;
				this.yAnchor = this.owner.y;
				this.ownerX = this.owner.x;
				this.ownerY = this.owner.y;
			}
			this.time++;
			switch (this.state)
			{
			case 0:
				this.roam();
				break;
			case 1:
				this.mAction = 2;
				this.follow();
				break;
			case 2:
				this.attack();
				break;
			case 3:
				this.mAction = 2;
				this.returnToPlayer();
				break;
			case 4:
				this.mAction = 0;
				base.waitForCommand();
				break;
			}
			if ((int)this.state != (int)this.preState)
			{
				this.preState = this.state;
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600053F RID: 1343 RVA: 0x00049EFC File Offset: 0x000480FC
	protected override void returnToPlayer()
	{
		this.vMax = this.owner.vMax;
		this.toX = this.owner.x;
		this.toY = this.owner.y;
		this.setHuong(this.toX, this.toY);
		this.move_to_XY();
		if (MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) < 40 && this.owner.Action != 2)
		{
			base.setState(0);
		}
	}

	// Token: 0x06000540 RID: 1344 RVA: 0x00049F90 File Offset: 0x00048190
	protected override void attack()
	{
		this.vMax = 12;
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(0);
			MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
			if (mainObject == null)
			{
				this.isRunAttack = false;
				base.setState(4);
				return;
			}
			if (MainObject.getDistance(this.x + this.vx, this.y + this.vy, mainObject.x, mainObject.y) > 30 && !this.isBeginAttack && mainObject.hp > 0)
			{
				this.toX = mainObject.x;
				this.toY = mainObject.y;
				this.setHuong(this.toX, this.toY);
				this.move_to_XY();
				this.mAction = 2;
			}
			else
			{
				this.isBeginAttack = true;
			}
			this.p1++;
			if (this.p1 > this.maxAttack && this.isBeginAttack)
			{
				try
				{
					this.setHuong(mainObject.x, mainObject.y);
					sbyte attackType = this.attackType;
					if (attackType != 11)
					{
						if (attackType == 12)
						{
							for (int i = 0; i < this.vecObjskill.size(); i++)
							{
								Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjskill.elementAt(i);
								if (object_Effect_Skill2 != null)
								{
									MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
									if (mainObject2 != null)
									{
										GameScreen.addEffectEndFromSv(57, 21, mainObject2.x, mainObject2.y);
										GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject2.x, mainObject2.y - mainObject2.hOne, 2, mainObject2.ID);
									}
								}
							}
						}
					}
					else
					{
						for (int j = 0; j < this.vecObjskill.size(); j++)
						{
							Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)this.vecObjskill.elementAt(j);
							if (object_Effect_Skill3 != null)
							{
								MainObject mainObject3 = MainObject.get_Object((int)object_Effect_Skill3.ID, object_Effect_Skill3.tem);
								if (mainObject3 != null)
								{
									GameScreen.startNewMagicBeam(15, this, mainObject3, this.x, this.y, -1 * object_Effect_Skill3.hpShow, 163, 163, 24);
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
				}
				this.p1 = 0;
				this.isBeginAttack = false;
				base.setState(4);
			}
		}
	}

	// Token: 0x06000541 RID: 1345 RVA: 0x0004A24C File Offset: 0x0004844C
	protected override void roam()
	{
		this.vMax = 1;
		if (this.Action == 1)
		{
			if (this.time > this.timeAutoAction || CRes.random(16) == 0 || MainObject.getDistance(this.x + this.vx, this.y + this.vy, this.xAnchor, this.yAnchor) >= this.limitMove)
			{
				this.time = 0;
				this.Action = 0;
				this.mAction = 0;
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
				this.mAction = 2;
				this.Direction = CRes.random(4);
				this.setSpeedInDirection(this.vMax);
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
			int distance = MainObject.getDistance(this.x, this.y, GameScreen.player.x, GameScreen.player.y);
			if (distance < 80 && distance > 40 && CRes.random(6) == 0)
			{
				base.setState(6);
			}
		}
	}

	// Token: 0x06000542 RID: 1346 RVA: 0x0004A424 File Offset: 0x00048624
	public new void setSpeedInDirection(int max)
	{
		int num = CRes.random_Am_0(3);
		if (CRes.abs(num) > 1)
		{
			max--;
		}
		switch (this.Direction)
		{
		case 0:
			this.vy = max;
			this.vx = num;
			break;
		case 1:
			this.vy = -max;
			this.vx = num;
			break;
		case 2:
			this.vy = num;
			this.vx = -max;
			break;
		case 3:
			this.vy = num;
			this.vx = max;
			break;
		}
		if (this.vx == 0 && CRes.random(3) == 0)
		{
			this.time = 0;
			this.Action = 0;
			this.vx = 0;
			this.vy = 0;
			this.mAction = 0;
		}
		if (this.vx > 0)
		{
			this.Direction = 3;
		}
		else
		{
			this.Direction = 2;
		}
		this.huongY = (int)((this.y <= this.toY) ? 0 : 1);
		this.flip = (int)((this.x - this.toX <= 0) ? 2 : 0);
		this.flip = 0;
		if (this.Direction == 3)
		{
			this.flip = 2;
		}
		else if (this.Direction != 2)
		{
			if (this.Direction == 0)
			{
				this.huongY = 0;
			}
			else if (this.Direction == 1)
			{
				this.huongY = 1;
			}
		}
	}

	// Token: 0x06000543 RID: 1347 RVA: 0x0004A5B0 File Offset: 0x000487B0
	protected override void follow()
	{
		this.vMax = this.owner.vMax;
		this.Action = 1;
		if (MainObject.getDistance(this.oldPosX, this.oldPosY, this.ownerX, this.ownerY) > 40)
		{
			Point o = new Point(this.ownerX, this.ownerY);
			this.oldPosX = this.ownerX;
			this.oldPosY = this.ownerY;
			this.wayPoint.addElement(o);
		}
		else if (MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) < 40)
		{
			this.wayPoint.removeAllElements();
			base.setState(4);
		}
		if (this.wayPoint.elementAt(0) != null)
		{
			this.toX = ((Point)this.wayPoint.elementAt(0)).x;
			this.toY = ((Point)this.wayPoint.elementAt(0)).y;
			this.setHuong(this.toX, this.toY);
			this.move_to_XY();
		}
	}

	// Token: 0x06000544 RID: 1348 RVA: 0x0004A6CC File Offset: 0x000488CC
	public void setHuong(int xto, int yto)
	{
		this.huongY = (int)((this.y <= yto) ? 0 : 1);
		this.flip = (int)((this.x - xto <= 0) ? 2 : 0);
		this.flip = 0;
		if (this.Direction == 3)
		{
			this.flip = 2;
		}
		else if (this.Direction != 2)
		{
			if (this.Direction == 0)
			{
				this.huongY = 0;
			}
			else if (this.Direction == 1)
			{
				this.huongY = 1;
			}
		}
	}

	// Token: 0x06000545 RID: 1349 RVA: 0x0004A76C File Offset: 0x0004896C
	public bool isFly()
	{
		mVector mVector = new mVector();
		mVector mVector2 = (mVector)Pet.PET_DATA.get(string.Empty + this.imageId);
		if (mVector2 != null)
		{
			mVector = mVector2;
		}
		DataEffect dataEffect = (DataEffect)mVector.elementAt(0);
		return dataEffect != null && (int)dataEffect.isFly <= -5;
	}

	// Token: 0x04000763 RID: 1891
	public const sbyte M_STAND = 0;

	// Token: 0x04000764 RID: 1892
	public const sbyte M_DEAD = 1;

	// Token: 0x04000765 RID: 1893
	public const sbyte M_WALK = 2;

	// Token: 0x04000766 RID: 1894
	public const sbyte M_ATTACK = 3;

	// Token: 0x04000767 RID: 1895
	public new sbyte mAction;

	// Token: 0x04000768 RID: 1896
	public int huongY;

	// Token: 0x04000769 RID: 1897
	public int flip;

	// Token: 0x0400076A RID: 1898
	public bool isBeginAttack;

	// Token: 0x0400076B RID: 1899
	private mImage imgp;

	// Token: 0x0400076C RID: 1900
	public int p1;

	// Token: 0x0400076D RID: 1901
	public int maxAttack;
}
