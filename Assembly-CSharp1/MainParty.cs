using System;

// Token: 0x02000056 RID: 86
public class MainParty
{
	// Token: 0x06000467 RID: 1127 RVA: 0x0003E174 File Offset: 0x0003C374
	public MainParty(string name, short Lv, int idMap, sbyte idarea)
	{
		this.nameMain = name;
		this.vecPartys.removeAllElements();
		this.isClear = false;
		this.addObjParty(name, Lv, idMap, idarea);
	}

	// Token: 0x06000468 RID: 1128 RVA: 0x0003E1BC File Offset: 0x0003C3BC
	public void addObjParty(string name, short Lv, int idMap, sbyte idarea)
	{
		ObjectParty objectParty = new ObjectParty(name, Lv, idMap, idarea);
		objectParty.maxhp = 10;
		objectParty.hp = 10;
		this.vecPartys.addElement(objectParty);
	}

	// Token: 0x06000469 RID: 1129 RVA: 0x0003E1F0 File Offset: 0x0003C3F0
	public void removeObj(string name)
	{
		for (int i = 0; i < this.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)this.vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(name) == 0)
			{
				objectParty.isRemove = true;
				break;
			}
		}
	}

	// Token: 0x0600046A RID: 1130 RVA: 0x0003E248 File Offset: 0x0003C448
	public void setPos(string name, int x, int y, int hp, int maxhp)
	{
		for (int i = 0; i < this.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)this.vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(name) == 0)
			{
				objectParty.x = x;
				objectParty.y = y;
				if (hp > maxhp)
				{
					hp = maxhp;
				}
				objectParty.hp = hp;
				objectParty.maxhp = maxhp;
				break;
			}
		}
	}

	// Token: 0x0600046B RID: 1131 RVA: 0x0003E2C4 File Offset: 0x0003C4C4
	public bool update()
	{
		if (this.isClear)
		{
			this.vecPartys.removeAllElements();
			return true;
		}
		for (int i = 0; i < this.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)this.vecPartys.elementAt(i);
			if (objectParty.isRemove)
			{
				this.vecPartys.removeElement(objectParty);
				i--;
			}
		}
		return false;
	}

	// Token: 0x0600046C RID: 1132 RVA: 0x0003E334 File Offset: 0x0003C534
	public void setIsParty()
	{
		for (int i = 0; i < this.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)this.vecPartys.elementAt(i);
			objectParty.ischeck = false;
		}
		for (int j = 0; j < GameScreen.Vecplayers.size(); j++)
		{
			MainObject mainObject = (MainObject)GameScreen.Vecplayers.elementAt(j);
			if ((int)mainObject.typeObject == 0 && mainObject != GameScreen.player)
			{
				mainObject.isParty = false;
				for (int k = 0; k < this.vecPartys.size(); k++)
				{
					ObjectParty objectParty2 = (ObjectParty)this.vecPartys.elementAt(k);
					if (!objectParty2.ischeck && objectParty2.name.CompareTo(mainObject.name) == 0)
					{
						mainObject.isParty = true;
						objectParty2.ischeck = true;
						break;
					}
				}
			}
		}
	}

	// Token: 0x0600046D RID: 1133 RVA: 0x0003E430 File Offset: 0x0003C630
	public void setObjParty(MainObject obj)
	{
		for (int i = 0; i < this.vecPartys.size(); i++)
		{
			ObjectParty objectParty = (ObjectParty)this.vecPartys.elementAt(i);
			if (objectParty.name.CompareTo(obj.name) == 0)
			{
				obj.isParty = true;
				break;
			}
		}
	}

	// Token: 0x04000650 RID: 1616
	public string nameMain;

	// Token: 0x04000651 RID: 1617
	public mVector vecPartys = new mVector("MainParty vecPartys");

	// Token: 0x04000652 RID: 1618
	public bool isClear;
}
