using System;

// Token: 0x020000D8 RID: 216
public class SaveImageRMS
{
	// Token: 0x06000A11 RID: 2577 RVA: 0x000AA114 File Offset: 0x000A8314
	public void run()
	{
		for (;;)
		{
			bool flag = false;
			while (SaveImageRMS.vecSaveCharPart.size() > 0)
			{
				flag = true;
				MainImageDataPartChar mainImageDataPartChar = (MainImageDataPartChar)SaveImageRMS.vecSaveCharPart.elementAt(0);
				try
				{
					CRes.saveRMS(string.Concat(new object[]
					{
						"img_data_char_",
						mainImageDataPartChar.type,
						"_",
						mainImageDataPartChar.id
					}), mainImageDataPartChar.getSaveData().toByteArray());
				}
				catch (Exception ex)
				{
				}
				SaveImageRMS.vecSaveCharPart.removeElementAt(0);
			}
			if (flag)
			{
				DataOutputStream dataOutputStream = new DataOutputStream();
				try
				{
					dataOutputStream.writeShort(GameCanvas.IndexCharPar);
					CRes.saveRMS("isIndexPart", dataOutputStream.toByteArray());
					dataOutputStream.close();
				}
				catch (Exception ex2)
				{
				}
			}
			if (SaveImageRMS.vecSaveImage.size() <= 0)
			{
				break;
			}
			try
			{
				idSaveImage idSaveImage = (idSaveImage)SaveImageRMS.vecSaveImage.elementAt(0);
				ObjectData.setToRms(idSaveImage.mbytImage, idSaveImage.id);
				SaveImageRMS.vecSaveImage.removeElementAt(0);
			}
			catch (Exception ex3)
			{
			}
		}
	}

	// Token: 0x06000A12 RID: 2578 RVA: 0x000AA288 File Offset: 0x000A8488
	public void start()
	{
	}

	// Token: 0x040011DA RID: 4570
	public static mVector vecSaveImage = new mVector("SaveImageRMS vecSaveImage");

	// Token: 0x040011DB RID: 4571
	public static mVector vecSaveCharPart = new mVector("SaveImageRMS vecSaveCharPart");
}
