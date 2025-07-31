using System;
using System.Collections;

// Token: 0x02000021 RID: 33
public class mVector
{
	// Token: 0x06000155 RID: 341 RVA: 0x000085FC File Offset: 0x000067FC
	public mVector()
	{
		this.a = new ArrayList();
		this.name = "EffectManager";
	}

	// Token: 0x06000156 RID: 342 RVA: 0x0000861C File Offset: 0x0000681C
	public mVector(string aa)
	{
		this.a = new ArrayList();
		this.name = aa;
	}

	// Token: 0x06000157 RID: 343 RVA: 0x00008638 File Offset: 0x00006838
	public mVector(ArrayList a)
	{
		this.a = a;
		this.name = "No Name";
	}

	// Token: 0x06000158 RID: 344 RVA: 0x00008654 File Offset: 0x00006854
	public void addElement(object o)
	{
		this.a.Add(o);
	}

	// Token: 0x06000159 RID: 345 RVA: 0x00008664 File Offset: 0x00006864
	public bool contains(object o)
	{
		return this.a.Contains(o);
	}

	// Token: 0x0600015A RID: 346 RVA: 0x0000867C File Offset: 0x0000687C
	public int size()
	{
		if (this.a == null)
		{
			return 0;
		}
		return this.a.Count;
	}

	// Token: 0x0600015B RID: 347 RVA: 0x00008698 File Offset: 0x00006898
	public object elementAt(int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			return this.a[index];
		}
		return null;
	}

	// Token: 0x0600015C RID: 348 RVA: 0x000086CC File Offset: 0x000068CC
	public void setElementAt(object obj, int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			this.a[index] = obj;
		}
	}

	// Token: 0x0600015D RID: 349 RVA: 0x000086F4 File Offset: 0x000068F4
	public int indexOf(object o)
	{
		return this.a.IndexOf(o);
	}

	// Token: 0x0600015E RID: 350 RVA: 0x00008704 File Offset: 0x00006904
	public void removeElementAt(int index)
	{
		if (index > -1 && index < this.a.Count)
		{
			this.a.RemoveAt(index);
		}
	}

	// Token: 0x0600015F RID: 351 RVA: 0x00008738 File Offset: 0x00006938
	public void removeElement(object o)
	{
		this.a.Remove(o);
	}

	// Token: 0x06000160 RID: 352 RVA: 0x00008748 File Offset: 0x00006948
	public void removeAllElements()
	{
		this.a.Clear();
	}

	// Token: 0x06000161 RID: 353 RVA: 0x00008758 File Offset: 0x00006958
	public void insertElementAt(object o, int i)
	{
		this.a.Insert(i, o);
	}

	// Token: 0x06000162 RID: 354 RVA: 0x00008768 File Offset: 0x00006968
	public object firstElement()
	{
		return this.a[0];
	}

	// Token: 0x06000163 RID: 355 RVA: 0x00008778 File Offset: 0x00006978
	public object lastElement()
	{
		return this.a[this.a.Count - 1];
	}

	// Token: 0x04000157 RID: 343
	private ArrayList a;

	// Token: 0x04000158 RID: 344
	private string name;
}
