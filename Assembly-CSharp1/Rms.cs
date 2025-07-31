using System;
using System.IO;
using System.Threading;
using UnityEngine;

// Token: 0x02000017 RID: 23
public class Rms
{
	// Token: 0x0600009C RID: 156 RVA: 0x00004144 File Offset: 0x00002344
	public static void saveRMS(string filename, sbyte[] data)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			Rms.__saveRMS(filename, data);
		}
		else
		{
			Rms._saveRMS(filename, data);
		}
	}

	// Token: 0x0600009D RID: 157 RVA: 0x00004180 File Offset: 0x00002380
	public static sbyte[] loadRMS(string filename)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			return Rms.__loadRMS(filename);
		}
		return Rms._loadRMS(filename);
	}

	// Token: 0x0600009E RID: 158 RVA: 0x000041B4 File Offset: 0x000023B4
	public static string loadRMSString(string fileName)
	{
		sbyte[] array = Rms.loadRMS(fileName);
		if (array == null)
		{
			return null;
		}
		DataInputStream dataInputStream = new DataInputStream(array);
		try
		{
			string result = dataInputStream.readUTF();
			dataInputStream.close();
			return result;
		}
		catch (Exception ex)
		{
			Cout.println(ex.StackTrace);
		}
		return null;
	}

	// Token: 0x0600009F RID: 159 RVA: 0x00004224 File Offset: 0x00002424
	public static byte[] convertSbyteToByte(sbyte[] var)
	{
		byte[] array = new byte[var.Length];
		for (int i = 0; i < var.Length; i++)
		{
			if ((int)var[i] > 0)
			{
				array[i] = (byte)var[i];
			}
			else
			{
				array[i] = (byte)((int)var[i] + 256);
			}
		}
		return array;
	}

	// Token: 0x060000A0 RID: 160 RVA: 0x00004274 File Offset: 0x00002474
	public static void saveRMSString(string filename, string data)
	{
		DataOutputStream dataOutputStream = new DataOutputStream();
		try
		{
			dataOutputStream.writeUTF(data);
			Rms.saveRMS(filename, dataOutputStream.toByteArray());
			dataOutputStream.close();
		}
		catch (Exception ex)
		{
			Cout.println(ex.StackTrace);
		}
	}

	// Token: 0x060000A1 RID: 161 RVA: 0x000042D4 File Offset: 0x000024D4
	private static void _saveRMS(string filename, sbyte[] data)
	{
		if (Rms.status != 0)
		{
			Debug.LogError("Cannot save RMS " + filename + " because current is saving " + Rms.filename);
			return;
		}
		Rms.filename = filename;
		Rms.data = data;
		Rms.status = 2;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Rms.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Debug.LogError("TOO LONG TO SAVE RMS " + filename);
		}
	}

	// Token: 0x060000A2 RID: 162 RVA: 0x00004360 File Offset: 0x00002560
	private static sbyte[] _loadRMS(string filename)
	{
		if (Rms.status != 0)
		{
			Debug.LogError("Cannot load RMS " + filename + " because current is loading " + Rms.filename);
			return null;
		}
		Rms.filename = filename;
		Rms.data = null;
		Rms.status = 3;
		int i;
		for (i = 0; i < 500; i++)
		{
			Thread.Sleep(5);
			if (Rms.status == 0)
			{
				break;
			}
		}
		if (i == 500)
		{
			Debug.LogError("TOO LONG TO LOAD RMS " + filename);
		}
		return Rms.data;
	}

	// Token: 0x060000A3 RID: 163 RVA: 0x000043F0 File Offset: 0x000025F0
	public static void update()
	{
		if (Rms.status == 2)
		{
			Rms.status = 1;
			Rms.__saveRMS(Rms.filename, Rms.data);
			Rms.status = 0;
		}
		else if (Rms.status == 3)
		{
			Rms.status = 1;
			Rms.data = Rms.__loadRMS(Rms.filename);
			Rms.status = 0;
		}
	}

	// Token: 0x060000A4 RID: 164 RVA: 0x00004450 File Offset: 0x00002650
	public static int loadRMSInt(string file)
	{
		sbyte[] array = Rms.loadRMS(file);
		return (array != null) ? ((int)array[0]) : -1;
	}

	// Token: 0x060000A5 RID: 165 RVA: 0x00004474 File Offset: 0x00002674
	public static void saveRMSInt(string file, int x)
	{
		try
		{
			Rms.saveRMS(file, new sbyte[]
			{
				(sbyte)x
			});
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000A6 RID: 166 RVA: 0x000044BC File Offset: 0x000026BC
	public static string GetiPhoneDocumentsPath()
	{
		return Application.persistentDataPath;
	}

	// Token: 0x060000A7 RID: 167 RVA: 0x000044C4 File Offset: 0x000026C4
	private static void __saveRMS(string filename, sbyte[] data)
	{
		string text = Rms.GetiPhoneDocumentsPath() + "/" + filename;
		FileStream fileStream = new FileStream(text, FileMode.Create);
		fileStream.Write(ArrayCast.cast(data), 0, data.Length);
		fileStream.Flush();
		fileStream.Close();
		Main.setBackupIcloud(text);
	}

	// Token: 0x060000A8 RID: 168 RVA: 0x0000450C File Offset: 0x0000270C
	private static sbyte[] __loadRMS(string filename)
	{
		sbyte[] result;
		try
		{
			FileStream fileStream = new FileStream(Rms.GetiPhoneDocumentsPath() + "/" + filename, FileMode.Open);
			byte[] array = new byte[fileStream.Length];
			fileStream.Read(array, 0, array.Length);
			fileStream.Close();
			sbyte[] array2 = ArrayCast.cast(array);
			result = ArrayCast.cast(array);
		}
		catch (Exception ex)
		{
			result = null;
		}
		return result;
	}

	// Token: 0x060000A9 RID: 169 RVA: 0x00004594 File Offset: 0x00002794
	public static void deleteAllRecord()
	{
		foreach (FileInfo fileInfo in new DirectoryInfo(Rms.GetiPhoneDocumentsPath() + "/").GetFiles())
		{
			fileInfo.Delete();
		}
	}

	// Token: 0x060000AA RID: 170 RVA: 0x000045DC File Offset: 0x000027DC
	public static string ByteArrayToString(byte[] ba)
	{
		string text = BitConverter.ToString(ba);
		return text.Replace("-", string.Empty);
	}

	// Token: 0x060000AB RID: 171 RVA: 0x00004600 File Offset: 0x00002800
	public static byte[] StringToByteArray(string hex)
	{
		int length = hex.Length;
		byte[] array = new byte[length / 2];
		for (int i = 0; i < length; i += 2)
		{
			array[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
		}
		return array;
	}

	// Token: 0x060000AC RID: 172 RVA: 0x00004644 File Offset: 0x00002844
	public static void deleteRecordByName(string path)
	{
		try
		{
			File.Delete(Rms.GetiPhoneDocumentsPath() + "/" + path);
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x060000AD RID: 173 RVA: 0x00004690 File Offset: 0x00002890
	public static void deleteRecordCompareToName()
	{
		try
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(Rms.GetiPhoneDocumentsPath() + "/");
			FileInfo[] files = directoryInfo.GetFiles();
			for (int i = 0; i < files.Length; i++)
			{
				if (CRes.CheckDelRMS(files[i].Name))
				{
					files[i].Delete();
				}
			}
		}
		catch (Exception ex)
		{
		}
	}

	// Token: 0x04000075 RID: 117
	private const int INTERVAL = 5;

	// Token: 0x04000076 RID: 118
	private const int MAXTIME = 500;

	// Token: 0x04000077 RID: 119
	public static int status;

	// Token: 0x04000078 RID: 120
	public static sbyte[] data;

	// Token: 0x04000079 RID: 121
	public static string filename;
}
