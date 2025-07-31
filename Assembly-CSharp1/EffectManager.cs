using System;

// Token: 0x020000B6 RID: 182
public class EffectManager : mVector
{
	// Token: 0x0600092C RID: 2348 RVA: 0x00096740 File Offset: 0x00094940
	public void updateAll()
	{
		for (int i = base.size() - 1; i >= 0; i--)
		{
			MainEffect mainEffect = (MainEffect)base.elementAt(i);
			if (mainEffect != null)
			{
				mainEffect.update();
				if (mainEffect.isRemove)
				{
					base.removeElementAt(i);
				}
			}
		}
	}

	// Token: 0x0600092D RID: 2349 RVA: 0x00096794 File Offset: 0x00094994
	public void paintAll(mGraphics g)
	{
		for (int i = 0; i < base.size(); i++)
		{
			MainEffect mainEffect = (MainEffect)base.elementAt(i);
			if (mainEffect != null && !mainEffect.isRemove)
			{
				mainEffect.paint(g);
			}
		}
	}

	// Token: 0x0600092E RID: 2350 RVA: 0x000967E0 File Offset: 0x000949E0
	public void reMoveAll()
	{
		for (int i = base.size() - 1; i >= 0; i--)
		{
			MainEffect mainEffect = (MainEffect)base.elementAt(i);
			if (mainEffect != null)
			{
				mainEffect.isRemove = true;
				base.removeElementAt(i);
			}
		}
	}

	// Token: 0x0600092F RID: 2351 RVA: 0x00096828 File Offset: 0x00094A28
	public static void addHiEffect(MainEffect eff)
	{
		EffectManager.hiEffects.addElement(eff);
	}

	// Token: 0x06000930 RID: 2352 RVA: 0x00096838 File Offset: 0x00094A38
	public static void addLowEffect(MainEffect eff)
	{
		EffectManager.lowEffects.addElement(eff);
	}

	// Token: 0x04000E14 RID: 3604
	public static EffectManager lowEffects = new EffectManager();

	// Token: 0x04000E15 RID: 3605
	public static EffectManager hiEffects = new EffectManager();
}
