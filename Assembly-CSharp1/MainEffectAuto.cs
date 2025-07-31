using System;

// Token: 0x0200003A RID: 58
public class MainEffectAuto
{
	// Token: 0x060002D1 RID: 721 RVA: 0x000269EC File Offset: 0x00024BEC
	public MainEffectAuto(int id, sbyte[] datasv)
	{
		this.setEffAuto(id, datasv);
	}

	// Token: 0x060002D3 RID: 723 RVA: 0x00026A14 File Offset: 0x00024C14
	public void setEffAuto(int id, sbyte[] datasv)
	{
		try
		{
			DataInputStream dataInputStream;
			if (datasv != null)
			{
				dataInputStream = new DataInputStream(datasv);
			}
			else
			{
				dataInputStream = mImage.openFile("/eff_" + id);
			}
			int num = dataInputStream.readUnsignedByte();
			for (int i = 0; i < num; i++)
			{
				MainPartImage mainPartImage = new MainPartImage(dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte(), dataInputStream.readUnsignedByte());
				this.hashImage.put(string.Empty + mainPartImage.ID, mainPartImage);
			}
			short num2 = dataInputStream.readShort();
			this.mFrame = new MainFrameEff[(int)num2];
			for (int j = 0; j < (int)num2; j++)
			{
				sbyte b = dataInputStream.readByte();
				this.mFrame[j] = new MainFrameEff();
				this.mFrame[j].mpart = new Part[(int)b];
				for (int k = 0; k < (int)b; k++)
				{
					this.mFrame[j].mpart[k] = new Part();
					this.mFrame[j].mpart[k].x = dataInputStream.readShort();
					this.mFrame[j].mpart[k].y = dataInputStream.readShort();
					this.mFrame[j].mpart[k].idPartImage = dataInputStream.readByte();
				}
			}
			short num3 = dataInputStream.readShort();
			this.mRunFrame = new short[(int)num3];
			for (int l = 0; l < (int)num3; l++)
			{
				this.mRunFrame[l] = dataInputStream.readShort();
			}
			dataInputStream.readByte();
			dataInputStream.readByte();
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000397 RID: 919
	public static mHashTable hashTemEffAuto = new mHashTable();

	// Token: 0x04000398 RID: 920
	public mHashTable hashImage = new mHashTable();

	// Token: 0x04000399 RID: 921
	public MainFrameEff[] mFrame;

	// Token: 0x0400039A RID: 922
	public short[] mRunFrame;
}
