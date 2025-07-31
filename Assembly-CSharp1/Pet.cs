using System;

// Token: 0x0200006D RID: 109
public class Pet : MainMonster
{
	// Token: 0x06000511 RID: 1297 RVA: 0x00046C78 File Offset: 0x00044E78
	public Pet()
	{
	}

	// Token: 0x06000512 RID: 1298 RVA: 0x00046D40 File Offset: 0x00044F40
	public Pet(short typePet, sbyte nFrame, sbyte imageId, sbyte typemove)
	{
		this.nFrame = (int)nFrame;
		this.type = typePet;
		this.imageId = imageId;
		this.isDoneAttack = false;
		this.ListKillNow = new ListSkill();
		this.typemove = typemove;
		this.setAnim();
	}

	// Token: 0x06000514 RID: 1300 RVA: 0x000476E0 File Offset: 0x000458E0
	public static Pet createPet(short type, int id, sbyte nFrame, sbyte imageId)
	{
		Pet result = null;
		sbyte b = Pet.mTypemove[(int)type];
		switch (b)
		{
		case 0:
			result = new PetWalk(type, id, nFrame, imageId, b);
			break;
		case 1:
		case 2:
			result = new PetFly(type, id, nFrame, imageId, b);
			break;
		case 3:
			result = new PetTool(type, id, nFrame, imageId, b);
			break;
		}
		return result;
	}

	// Token: 0x06000515 RID: 1301 RVA: 0x0004774C File Offset: 0x0004594C
	public static Pet createPet(MainObject owner, short type, sbyte nFrame, sbyte imageId)
	{
		Pet result = null;
		sbyte b = Pet.mTypemove[(int)type];
		switch (b)
		{
		case 0:
			result = new PetWalk(owner, type, nFrame, imageId, b);
			break;
		case 1:
		case 2:
			result = new PetFly(owner, type, nFrame, imageId, b);
			break;
		case 3:
			result = new PetTool(owner, type, nFrame, imageId, b);
			break;
		}
		return result;
	}

	// Token: 0x06000516 RID: 1302 RVA: 0x000477B8 File Offset: 0x000459B8
	public void setAnim()
	{
		switch (this.typemove)
		{
		case 0:
			this.mAction = Pet.mWoftAnimFrame;
			break;
		case 1:
			this.mAction = Pet.mBat;
			break;
		case 2:
			this.mAction = Pet.mOwl;
			break;
		}
	}

	// Token: 0x06000517 RID: 1303 RVA: 0x00047818 File Offset: 0x00045A18
	public void clearWayPoints()
	{
		this.wayPoint.removeAllElements();
	}

	// Token: 0x06000518 RID: 1304 RVA: 0x00047828 File Offset: 0x00045A28
	public void setState(sbyte state)
	{
		this.state = state;
	}

	// Token: 0x06000519 RID: 1305 RVA: 0x00047834 File Offset: 0x00045A34
	protected virtual void roam()
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
			if (this.owner.Action == 1)
			{
				if (MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > 40)
				{
					this.setState(1);
				}
				if (this.owner.Action == 0 && MainObject.getDistance(this.x, this.y, this.ownerX, this.ownerY) > this.limitMove * 2)
				{
					this.setState(3);
				}
			}
			else
			{
				int distance = MainObject.getDistance(this.x, this.y, GameScreen.player.x, GameScreen.player.y);
				if (distance < 80 && distance > 40 && CRes.random(6) == 0)
				{
					this.setState(6);
				}
			}
		}
	}

	// Token: 0x0600051A RID: 1306 RVA: 0x000479FC File Offset: 0x00045BFC
	protected void standStill()
	{
		this.vx = 0;
		this.vy = 0;
		this.Action = 4;
		if (this.owner != null && this.owner.Action == 0)
		{
			this.setState(0);
		}
	}

	// Token: 0x0600051B RID: 1307 RVA: 0x00047A38 File Offset: 0x00045C38
	protected virtual void follow()
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
			this.setState(4);
		}
		if (this.wayPoint.elementAt(0) != null)
		{
			this.toX = ((Point)this.wayPoint.elementAt(0)).x;
			this.toY = ((Point)this.wayPoint.elementAt(0)).y;
			this.move_to_XY();
		}
	}

	// Token: 0x0600051C RID: 1308 RVA: 0x00047B44 File Offset: 0x00045D44
	public override void move_to_XY()
	{
		base.move_to_XY();
		if ((int)this.state != 3 && (this.owner.Direction == 1 || this.owner.Direction == 0) && !this.isPetTool)
		{
			this.xtam += this.vatam;
			if (this.vatam > 0)
			{
				this.Direction = 3;
			}
			if (this.vatam < 0)
			{
				this.Direction = 2;
			}
			if ((this.xtam + this.vatam >= 48 && this.vatam > 0) || (this.xtam + this.vatam < -48 && this.vatam < 0))
			{
				this.vatam *= -1;
			}
		}
	}

	// Token: 0x0600051D RID: 1309 RVA: 0x00047C18 File Offset: 0x00045E18
	public void initAttackState(sbyte skillId)
	{
		try
		{
			this.attackType = skillId;
			this.isRunAttack = true;
			this.timeBeginMoveAttack = GameCanvas.timeNow;
			this.attackCount = 0;
			this.isSequenceAttack = false;
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x0600051E RID: 1310 RVA: 0x00047C74 File Offset: 0x00045E74
	protected virtual void attack()
	{
		if (this.isSequenceAttack)
		{
			if (this.attackCount == 3)
			{
				this.isDoneAttack = false;
				this.setState(4);
				this.attackCount = 0;
			}
		}
		else if (this.isDoneAttack)
		{
			this.isDoneAttack = false;
			this.setState(4);
		}
	}

	// Token: 0x0600051F RID: 1311 RVA: 0x00047CCC File Offset: 0x00045ECC
	protected virtual void returnToPlayer()
	{
		this.vMax = this.owner.vMax;
		this.toX = this.owner.x;
		this.toY = this.owner.y;
		this.move_to_XY();
		if (MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) < 40 && this.owner.Action != 2)
		{
			this.setState(0);
		}
	}

	// Token: 0x06000520 RID: 1312 RVA: 0x00047D50 File Offset: 0x00045F50
	protected void waitForCommand()
	{
		this.vx = 0;
		this.vy = 0;
		if ((int)this.typemove == 1 || (int)this.typemove == 2)
		{
			this.Action = 1;
		}
		else
		{
			this.Action = 0;
		}
		if (this.owner != null)
		{
			if (this.owner.Action == 0)
			{
				this.wayPoint.removeAllElements();
				this.setState(0);
			}
			else if (this.owner.Action == 1 && MainObject.getDistance(this.x, this.y, this.xAnchor, this.yAnchor) > 40)
			{
				this.wayPoint.removeAllElements();
				this.setState(1);
			}
		}
	}

	// Token: 0x06000521 RID: 1313 RVA: 0x00047E18 File Offset: 0x00046018
	public void addAttackEffect()
	{
		if (this.vecObjskill != null && this.vecObjskill.size() > 0)
		{
			switch (this.attackType)
			{
			case 0:
				GameScreen.addEffectEndKill(10, this.x, this.y);
				for (int i = 0; i < this.vecObjskill.size(); i++)
				{
					Object_Effect_Skill object_Effect_Skill = (Object_Effect_Skill)this.vecObjskill.elementAt(i);
					MainObject mainObject = MainObject.get_Object((int)object_Effect_Skill.ID, object_Effect_Skill.tem);
					if (mainObject != null && object_Effect_Skill.hpShow > 0)
					{
						GameScreen.addEffectNum("-" + object_Effect_Skill.hpShow, mainObject.x, mainObject.y - mainObject.hOne, 0, this.owner.ID);
					}
					mVector mVector = new mVector("Pet target");
					mVector.addElement(object_Effect_Skill);
					GameScreen.addEffectKill(89, this.owner.ID, this.owner.typeObject, mVector);
				}
				this.attackCount++;
				break;
			case 1:
				GameScreen.addEffectEndKill(51, this.x, this.y - 8);
				for (int j = 0; j < this.vecObjskill.size(); j++)
				{
					Object_Effect_Skill object_Effect_Skill2 = (Object_Effect_Skill)this.vecObjskill.elementAt(j);
					MainObject mainObject2 = MainObject.get_Object((int)object_Effect_Skill2.ID, object_Effect_Skill2.tem);
					if (mainObject2 != null && object_Effect_Skill2.hpShow > 0)
					{
						GameScreen.addEffectNum("-" + object_Effect_Skill2.hpShow, mainObject2.x, mainObject2.y - mainObject2.hOne, 0, this.owner.ID);
					}
					mVector mVector2 = new mVector("Pet target2");
					mVector2.addElement(object_Effect_Skill2);
					GameScreen.addEffectKill(92, this.owner.ID, this.owner.typeObject, mVector2);
				}
				this.attackCount++;
				break;
			case 2:
				GameScreen.addEffectKill(50, this.ID, 9, this.vecObjskill);
				this.attackCount++;
				break;
			case 3:
				GameScreen.addEffectKill(91, this.ID, this.typeObject, this.vecObjskill);
				this.attackCount++;
				break;
			case 4:
				GameScreen.addEffectKill(90, this.ID, this.typeObject, this.vecObjskill);
				this.attackCount++;
				break;
			case 5:
				GameScreen.addEffectKill(81, this.x, this.y - 20, 200, 0, 0);
				this.attackCount++;
				break;
			case 10:
				for (int k = 0; k < this.vecObjskill.size(); k++)
				{
					Object_Effect_Skill object_Effect_Skill3 = (Object_Effect_Skill)this.vecObjskill.elementAt(k);
					MainObject mainObject3 = MainObject.get_Object((int)object_Effect_Skill3.ID, object_Effect_Skill3.tem);
					if (mainObject3 != null && object_Effect_Skill3.hpShow > 0)
					{
						GameScreen.addEffectNum("-" + object_Effect_Skill3.hpShow, mainObject3.x, mainObject3.y - mainObject3.hOne, 0, this.owner.ID);
					}
				}
				break;
			}
		}
	}

	// Token: 0x06000522 RID: 1314 RVA: 0x000481A8 File Offset: 0x000463A8
	private void attract()
	{
		this.vMax = 3;
		this.Action = 1;
		this.toX = GameScreen.player.x;
		this.toY = GameScreen.player.y;
		this.move_to_XY();
		if (MainObject.getDistance(this.x, this.y, this.toX, this.toY) < 40)
		{
			this.setState(0);
		}
	}

	// Token: 0x06000523 RID: 1315 RVA: 0x00048214 File Offset: 0x00046414
	private void updatePetAction()
	{
		this.f++;
		if (this.f > this.mAction[this.Action][(this.Direction <= 2) ? this.Direction : 2].Length - 1)
		{
			this.f = 0;
			if (this.Action == 3 || this.Action == 2)
			{
				this.Action = 0;
				this.vx = 0;
				this.vy = 0;
				this.isDoneAttack = true;
			}
		}
	}

	// Token: 0x06000524 RID: 1316 RVA: 0x000482A0 File Offset: 0x000464A0
	public override void update()
	{
		try
		{
			base.update();
			this.updatePetAction();
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
			if (((int)this.typemove == 1 || (int)this.typemove == 2) && this.Action != 0 && this.yfly < 50)
			{
				this.yfly += 3;
			}
			switch (this.state)
			{
			case 0:
				this.roam();
				break;
			case 1:
				this.follow();
				break;
			case 2:
				this.attack();
				break;
			case 3:
				this.returnToPlayer();
				break;
			case 4:
				this.waitForCommand();
				break;
			case 6:
				this.attract();
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

	// Token: 0x06000525 RID: 1317 RVA: 0x00048470 File Offset: 0x00046670
	public override bool findOwner(MainObject ownerP)
	{
		return this.owner.Equals(ownerP);
	}

	// Token: 0x06000526 RID: 1318 RVA: 0x00048480 File Offset: 0x00046680
	public static void setDataPet(sbyte[] data, int id, int idImg)
	{
		DataEffect dataEffect = new DataEffect(data, idImg, true);
		dataEffect.name = "QUAI THU: " + id;
		mVector mVector = new mVector();
		mVector.addElement(dataEffect);
		Pet.PET_DATA.put(string.Empty + id, mVector);
	}

	// Token: 0x04000715 RID: 1813
	public const sbyte ROAM = 0;

	// Token: 0x04000716 RID: 1814
	public const sbyte FOLLOW = 1;

	// Token: 0x04000717 RID: 1815
	public const sbyte ATTACK = 2;

	// Token: 0x04000718 RID: 1816
	public const sbyte RETURN = 3;

	// Token: 0x04000719 RID: 1817
	public const sbyte WAIT = 4;

	// Token: 0x0400071A RID: 1818
	public const sbyte DEATH = 5;

	// Token: 0x0400071B RID: 1819
	public const sbyte ATTRACTION = 6;

	// Token: 0x0400071C RID: 1820
	public const sbyte ATTACK_OWL = 0;

	// Token: 0x0400071D RID: 1821
	public const sbyte ATTACK_BAT = 1;

	// Token: 0x0400071E RID: 1822
	public const sbyte ATTACK_MELEE = 2;

	// Token: 0x0400071F RID: 1823
	public const sbyte ATTACK_POISON_NOVA = 3;

	// Token: 0x04000720 RID: 1824
	public const sbyte ATTACK_ICE_NOVA = 4;

	// Token: 0x04000721 RID: 1825
	public const sbyte ATTACK_FIRE_BLAST = 5;

	// Token: 0x04000722 RID: 1826
	public const sbyte ATTACK_PET_EAGLE = 10;

	// Token: 0x04000723 RID: 1827
	public const sbyte ATTACK_TOOL_1 = 11;

	// Token: 0x04000724 RID: 1828
	public const sbyte ATTACK_TOOL_2 = 12;

	// Token: 0x04000725 RID: 1829
	public const sbyte TYPE_PET_OWL = 0;

	// Token: 0x04000726 RID: 1830
	public const sbyte TYPE_PET_BAT = 1;

	// Token: 0x04000727 RID: 1831
	public const sbyte TYPE_WALK = 2;

	// Token: 0x04000728 RID: 1832
	public const sbyte TYPE_PET_EAGLE = 3;

	// Token: 0x04000729 RID: 1833
	public const sbyte TYPE_PET_MONKEY = 4;

	// Token: 0x0400072A RID: 1834
	public const sbyte TYPE_MOVE_WALK = 0;

	// Token: 0x0400072B RID: 1835
	public const sbyte TYPE_MOVE_FLY = 1;

	// Token: 0x0400072C RID: 1836
	public const sbyte TYPE_MOVE_FLY_AND_MOVE = 2;

	// Token: 0x0400072D RID: 1837
	public const sbyte TYPE_MOVE_PET_TOOL = 3;

	// Token: 0x0400072E RID: 1838
	protected const sbyte DIS_TO_ATTRACT = 80;

	// Token: 0x0400072F RID: 1839
	protected const sbyte DIS_TO_FOLLOW = 40;

	// Token: 0x04000730 RID: 1840
	public static sbyte[][][] mCupidAnimFrame = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				2,
				2,
				2,
				2
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				3,
				3,
				4,
				4,
				5,
				5
			},
			new sbyte[]
			{
				2,
				2,
				3,
				3,
				4,
				4,
				5,
				5
			},
			new sbyte[]
			{
				2,
				2,
				3,
				3,
				4,
				4,
				5,
				5
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				4,
				4,
				4,
				4,
				5,
				5,
				5,
				5
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		}
	};

	// Token: 0x04000731 RID: 1841
	public static sbyte[][][] mElfAnimFrame = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				2,
				2,
				3,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		}
	};

	// Token: 0x04000732 RID: 1842
	public static sbyte[][][] mWoftAnimFrame = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				0,
				0,
				0,
				0,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			}
		}
	};

	// Token: 0x04000733 RID: 1843
	public static sbyte[][][] mEagle = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				5
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			}
		}
	};

	// Token: 0x04000734 RID: 1844
	public static sbyte[][][] mBat = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			}
		}
	};

	// Token: 0x04000735 RID: 1845
	public static sbyte[][][] mOwl = new sbyte[][][]
	{
		new sbyte[][]
		{
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			},
			new sbyte[]
			{
				1,
				1,
				1,
				1,
				1
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				5,
				2,
				2,
				2,
				3,
				3,
				3,
				4,
				4,
				3,
				3
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				5
			},
			new sbyte[]
			{
				5,
				5,
				5,
				5,
				5,
				5,
				5
			}
		},
		new sbyte[][]
		{
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			},
			new sbyte[]
			{
				6,
				6,
				6,
				6,
				6,
				6,
				6,
				6
			}
		}
	};

	// Token: 0x04000736 RID: 1846
	protected Point[] posArray = new Point[]
	{
		new Point(13 * LoadMap.wTile, 12 * LoadMap.wTile),
		new Point(11 * LoadMap.wTile, 21 * LoadMap.wTile),
		new Point(22 * LoadMap.wTile, 20 * LoadMap.wTile),
		new Point(23 * LoadMap.wTile, 16 * LoadMap.wTile),
		new Point(16 * LoadMap.wTile, 14 * LoadMap.wTile),
		new Point(13 * LoadMap.wTile, 22 * LoadMap.wTile)
	};

	// Token: 0x04000737 RID: 1847
	protected bool isSequenceAttack;

	// Token: 0x04000738 RID: 1848
	protected bool isDoneAttack;

	// Token: 0x04000739 RID: 1849
	protected short type;

	// Token: 0x0400073A RID: 1850
	protected new sbyte imageId;

	// Token: 0x0400073B RID: 1851
	protected sbyte state;

	// Token: 0x0400073C RID: 1852
	protected sbyte preState;

	// Token: 0x0400073D RID: 1853
	protected sbyte attackType;

	// Token: 0x0400073E RID: 1854
	protected int attackCount;

	// Token: 0x0400073F RID: 1855
	protected int oldPosX;

	// Token: 0x04000740 RID: 1856
	protected int oldPosY;

	// Token: 0x04000741 RID: 1857
	protected int ownerX;

	// Token: 0x04000742 RID: 1858
	protected int ownerY;

	// Token: 0x04000743 RID: 1859
	public int xtam;

	// Token: 0x04000744 RID: 1860
	public int vatam = 6;

	// Token: 0x04000745 RID: 1861
	public short yfly;

	// Token: 0x04000746 RID: 1862
	protected mVector wayPoint = new mVector("Pet wayPoint");

	// Token: 0x04000747 RID: 1863
	protected MainObject owner;

	// Token: 0x04000748 RID: 1864
	public sbyte typemove;

	// Token: 0x04000749 RID: 1865
	public static sbyte[] mTypemove = new sbyte[]
	{
		2,
		1,
		0,
		2,
		0,
		1
	};

	// Token: 0x0400074A RID: 1866
	public static mHashTable HashImagePet = new mHashTable();

	// Token: 0x0400074B RID: 1867
	public bool isPetTool;

	// Token: 0x0400074C RID: 1868
	public static mHashTable PET_DATA = new mHashTable();
}
