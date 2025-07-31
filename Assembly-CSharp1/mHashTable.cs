using System;
using System.Collections;

// Token: 0x0200001D RID: 29
public class mHashTable
{
	// Token: 0x060000FF RID: 255 RVA: 0x000071FC File Offset: 0x000053FC
	public object get(string k)
	{
		return this.h[k];
	}

	// Token: 0x06000100 RID: 256 RVA: 0x0000720C File Offset: 0x0000540C
	public void clear()
	{
		this.h.Clear();
	}

	// Token: 0x06000101 RID: 257 RVA: 0x0000721C File Offset: 0x0000541C
	public IDictionaryEnumerator GetEnumerator()
	{
		return this.h.GetEnumerator();
	}

	// Token: 0x06000102 RID: 258 RVA: 0x0000722C File Offset: 0x0000542C
	public int size()
	{
		return this.h.Count;
	}

	// Token: 0x06000103 RID: 259 RVA: 0x0000723C File Offset: 0x0000543C
	public void put(string k, object v)
	{
		if (this.h.ContainsKey(k))
		{
			this.h.Remove(k);
		}
		this.h.Add(k, v);
	}

	// Token: 0x06000104 RID: 260 RVA: 0x00007274 File Offset: 0x00005474
	public void remove(object k)
	{
		this.h.Remove(k);
	}

	// Token: 0x06000105 RID: 261 RVA: 0x00007284 File Offset: 0x00005484
	public void Remove(string key)
	{
		this.h.Remove(key);
	}

	// Token: 0x06000106 RID: 262 RVA: 0x00007294 File Offset: 0x00005494
	public bool containsKey(object key)
	{
		return this.h.ContainsKey(key);
	}

	// Token: 0x040000E6 RID: 230
	public Hashtable h = new Hashtable();
}
