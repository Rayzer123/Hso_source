using System;
using System.Threading;
using UnityEngine;

// Token: 0x0200001E RID: 30
public class mSound
{
	// Token: 0x06000109 RID: 265 RVA: 0x00007414 File Offset: 0x00005614
	public static void stop()
	{
		for (int i = 0; i < mSound.player.Length; i++)
		{
			if (mSound.player[i] != null)
			{
				mSound.player[i].GetComponent<AudioSource>().Pause();
			}
		}
	}

	// Token: 0x0600010A RID: 266 RVA: 0x0000745C File Offset: 0x0000565C
	public static bool isPlayingz()
	{
		return false;
	}

	// Token: 0x0600010B RID: 267 RVA: 0x00007460 File Offset: 0x00005660
	public static void pauseCurMusic()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			if (i < mSound.l1 && mSound.isPlaying[i] == 1)
			{
				mSound.isPlaying[i] = 0;
				mSound.sTopSoundBG(i);
			}
		}
	}

	// Token: 0x0600010C RID: 268 RVA: 0x000074AC File Offset: 0x000056AC
	public static void init()
	{
		GameObject gameObject = new GameObject();
		gameObject.name = "Audio Player";
		gameObject.transform.position = Vector3.zero;
		gameObject.AddComponent<AudioListener>();
		mSound.SoundBGLoop = gameObject.AddComponent<AudioSource>();
	}

	// Token: 0x0600010D RID: 269 RVA: 0x000074EC File Offset: 0x000056EC
	public static void init(int[] musicID, int[] sID)
	{
		if (mSound.player != null || mSound.music != null)
		{
			return;
		}
		mSound.init();
		mSound.l1 = musicID.Length;
		mSound.player = new GameObject[musicID.Length + sID.Length];
		mSound.music = new AudioClip[musicID.Length + sID.Length];
		mSound.isPlaying = new int[musicID.Length + sID.Length];
		for (int i = 0; i < mSound.player.Length; i++)
		{
			string text = (i >= mSound.l1) ? ("/sound/" + (i - mSound.l1)) : ("/music/" + i);
			mSound.getAssetSoundFile(text, i);
		}
	}

	// Token: 0x0600010E RID: 270 RVA: 0x000075A4 File Offset: 0x000057A4
	public static void playSound(int id, int volume)
	{
		if (!mSound.isSound)
		{
			return;
		}
		mSound.play(id + mSound.l1, volume);
	}

	// Token: 0x0600010F RID: 271 RVA: 0x000075C0 File Offset: 0x000057C0
	public static void playSound1(int id, int volume)
	{
		mSound.play(id, volume);
	}

	// Token: 0x06000110 RID: 272 RVA: 0x000075CC File Offset: 0x000057CC
	public static void getAssetSoundFile(string fileName, int pos)
	{
		mSound.stop(pos);
		string filename = string.Empty;
		filename = Main.res + fileName;
		mSound.load(filename, pos);
	}

	// Token: 0x06000111 RID: 273 RVA: 0x000075F8 File Offset: 0x000057F8
	public static void stopSoundAll()
	{
		for (int i = 0; i < mSound.l1; i++)
		{
			mSound.stop(i);
		}
		mSystem.gcc();
	}

	// Token: 0x06000112 RID: 274 RVA: 0x00007628 File Offset: 0x00005828
	public static void stopAllz()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			mSound.sTopSoundBG(i);
		}
		for (int j = 0; j < mSound.l1; j++)
		{
			mSound.stop(j);
		}
	}

	// Token: 0x06000113 RID: 275 RVA: 0x00007670 File Offset: 0x00005870
	public static void stopAllBg()
	{
		for (int i = 0; i < mSound.music.Length; i++)
		{
			mSound.stop(i);
		}
		mSound.sTopSoundBG(0);
		mSound.sTopSoundRun();
		mSound.stopSoundNatural(0);
	}

	// Token: 0x06000114 RID: 276 RVA: 0x000076AC File Offset: 0x000058AC
	public static void update()
	{
	}

	// Token: 0x06000115 RID: 277 RVA: 0x000076B0 File Offset: 0x000058B0
	public static void stopMusic(int x)
	{
		if (GameCanvas.isPlaySound)
		{
			mSound.stop(x);
		}
	}

	// Token: 0x06000116 RID: 278 RVA: 0x000076C4 File Offset: 0x000058C4
	public static void play(int id, int volume)
	{
		if (mSound.isNotPlay)
		{
			return;
		}
		if (GameCanvas.isPlaySound)
		{
			mSound.start(volume, id);
		}
	}

	// Token: 0x06000117 RID: 279 RVA: 0x000076E4 File Offset: 0x000058E4
	public static void playSoundRun(int id, int volume)
	{
		if (GameCanvas.isPlaySound)
		{
			if (mSound.SoundRun == null)
			{
				return;
			}
			mSound.SoundRun.GetComponent<AudioSource>().loop = true;
			mSound.SoundRun.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundRun.GetComponent<AudioSource>().volume = (float)volume;
			mSound.SoundRun.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x06000118 RID: 280 RVA: 0x00007754 File Offset: 0x00005954
	public static void sTopSoundRun()
	{
		mSound.SoundRun.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000119 RID: 281 RVA: 0x00007768 File Offset: 0x00005968
	public static bool isPlayingSound()
	{
		return !(mSound.SoundRun == null) && mSound.SoundRun.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x0600011A RID: 282 RVA: 0x00007798 File Offset: 0x00005998
	public static int getMediaSoundFile(string fileName)
	{
		return -1;
	}

	// Token: 0x0600011B RID: 283 RVA: 0x0000779C File Offset: 0x0000599C
	public static void SetLoopSound(int id, int volume, int loop)
	{
	}

	// Token: 0x0600011C RID: 284 RVA: 0x000077A0 File Offset: 0x000059A0
	public static void UnSetLoopAll()
	{
	}

	// Token: 0x0600011D RID: 285 RVA: 0x000077A4 File Offset: 0x000059A4
	public static void playSoundNatural(int id, int volume, bool isLoop)
	{
		if (GameCanvas.isPlaySound)
		{
			if (mSound.SoundBGLoop == null)
			{
				return;
			}
			mSound.SoundWater.GetComponent<AudioSource>().loop = isLoop;
			mSound.SoundWater.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundWater.GetComponent<AudioSource>().volume = (float)volume;
			mSound.SoundWater.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x0600011E RID: 286 RVA: 0x00007814 File Offset: 0x00005A14
	public static void stopSoundNatural(int id)
	{
		mSound.SoundWater.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x0600011F RID: 287 RVA: 0x00007828 File Offset: 0x00005A28
	public static bool isPlayingSoundatural(int id)
	{
		return !(mSound.SoundWater == null) && mSound.SoundWater.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x06000120 RID: 288 RVA: 0x00007858 File Offset: 0x00005A58
	public static void playMus(int type, int vl, bool loop)
	{
		if (type < 0)
		{
			type = 0;
		}
		if (mSound.isNotPlay || !mSound.isMusic || mSound.isPlaying[type] == 1)
		{
			return;
		}
		mSound.pauseCurMusic();
		mSound.isPlaying[type] = 1;
		mSound.playSoundBGLoop(type, vl);
	}

	// Token: 0x06000121 RID: 289 RVA: 0x000078A8 File Offset: 0x00005AA8
	public static void playSoundBGLoop(int id, int volume)
	{
		if (GameCanvas.isPlaySound)
		{
			if (mSound.SoundBGLoop == null)
			{
				return;
			}
			if (mSound.isPlayingSoundBG(id))
			{
				return;
			}
			mSound.SoundBGLoop.GetComponent<AudioSource>().loop = true;
			mSound.SoundBGLoop.GetComponent<AudioSource>().clip = mSound.music[id];
			mSound.SoundBGLoop.GetComponent<AudioSource>().volume = (float)volume;
			mSound.SoundBGLoop.GetComponent<AudioSource>().Play();
		}
	}

	// Token: 0x06000122 RID: 290 RVA: 0x00007924 File Offset: 0x00005B24
	public static void sTopSoundBG(int id)
	{
		mSound.SoundBGLoop.GetComponent<AudioSource>().Stop();
	}

	// Token: 0x06000123 RID: 291 RVA: 0x00007938 File Offset: 0x00005B38
	public static bool isPlayingSoundBG(int id)
	{
		return !(mSound.SoundBGLoop == null) && mSound.SoundBGLoop.GetComponent<AudioSource>().isPlaying;
	}

	// Token: 0x06000124 RID: 292 RVA: 0x00007968 File Offset: 0x00005B68
	public static void load(string filename, int pos)
	{
		if (Main.isWindowsPhone)
		{
			mSound.__load(filename, pos);
			return;
		}
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			mSound.__load(filename, pos);
		}
		else
		{
			mSound._load(filename, pos);
		}
	}

	// Token: 0x06000125 RID: 293 RVA: 0x000079B4 File Offset: 0x00005BB4
	private static void _load(string filename, int pos)
	{
		if (mSound.status != 0)
		{
			Cout.LogError("CANNOT LOAD AUDIO " + filename + " WHEN LOADING " + mSound.filenametemp);
			return;
		}
		mSound.filenametemp = filename;
		mSound.postem = pos;
		mSound.status = 2;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (mSound.status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Cout.LogError("TOO LONG FOR LOAD AUDIO " + filename);
		}
		else
		{
			Cout.Log(string.Concat(new object[]
			{
				"Load Audio ",
				filename,
				" done in ",
				i * 5,
				"ms"
			}));
		}
	}

	// Token: 0x06000126 RID: 294 RVA: 0x00007A74 File Offset: 0x00005C74
	private static void __load(string filename, int pos)
	{
		mSound.music[pos] = (AudioClip)Resources.Load(filename, typeof(AudioClip));
		GameObject.Find("Main Camera").AddComponent<AudioSource>();
		mSound.player[pos] = GameObject.Find("Main Camera");
	}

	// Token: 0x06000127 RID: 295 RVA: 0x00007AC0 File Offset: 0x00005CC0
	public static void start(int volume, int pos)
	{
		if (Main.isWindowsPhone)
		{
			mSound.__start(volume, pos);
			return;
		}
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			mSound.__start(volume, pos);
		}
		else
		{
			mSound._start(volume, pos);
		}
	}

	// Token: 0x06000128 RID: 296 RVA: 0x00007B0C File Offset: 0x00005D0C
	public static void _start(int volume, int pos)
	{
		if (mSound.status != 0)
		{
			Debug.LogError("CANNOT START AUDIO WHEN STARTING");
			return;
		}
		mSound.volumetem = volume;
		mSound.postem = pos;
		mSound.status = 3;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (mSound.status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR START AUDIO");
		}
		else
		{
			Debug.Log("Start Audio done in " + i * 5 + "ms");
		}
	}

	// Token: 0x06000129 RID: 297 RVA: 0x00007B9C File Offset: 0x00005D9C
	public static void __start(int volume, int pos)
	{
		if (mSound.player[pos] == null)
		{
			return;
		}
		mSound.player[pos].GetComponent<AudioSource>().volume = (float)volume;
		mSound.player[pos].GetComponent<AudioSource>().PlayOneShot(mSound.music[pos], (float)volume);
	}

	// Token: 0x0600012A RID: 298 RVA: 0x00007BEC File Offset: 0x00005DEC
	public static void stop(int pos)
	{
		if (Thread.CurrentThread.Name == Main.mainThreadName)
		{
			mSound.__stop(pos);
		}
		else
		{
			mSound._stop(pos);
		}
	}

	// Token: 0x0600012B RID: 299 RVA: 0x00007C24 File Offset: 0x00005E24
	public static void _stop(int pos)
	{
		if (mSound.status != 0)
		{
			Debug.LogError("CANNOT STOP AUDIO WHEN STOPPING");
			return;
		}
		mSound.postem = pos;
		mSound.status = 4;
		int i;
		for (i = 0; i < 100; i++)
		{
			Thread.Sleep(5);
			if (mSound.status == 0)
			{
				break;
			}
		}
		if (i == 100)
		{
			Debug.LogError("TOO LONG FOR STOP AUDIO");
		}
		else
		{
			Debug.Log("Stop Audio done in " + i * 5 + "ms");
		}
	}

	// Token: 0x0600012C RID: 300 RVA: 0x00007CB0 File Offset: 0x00005EB0
	public static void __stop(int pos)
	{
		if (mSound.player[pos] != null)
		{
			mSound.player[pos].GetComponent<AudioSource>().Stop();
		}
	}

	// Token: 0x040000E7 RID: 231
	private const int INTERVAL = 5;

	// Token: 0x040000E8 RID: 232
	private const int MAXTIME = 100;

	// Token: 0x040000E9 RID: 233
	private const int MAX_VOLUME = 100;

	// Token: 0x040000EA RID: 234
	public const sbyte MUSIC_LANG = 0;

	// Token: 0x040000EB RID: 235
	public const sbyte MUSIC_THANHPHO = 1;

	// Token: 0x040000EC RID: 236
	public const sbyte MUSIC_THIENNHIEN = 2;

	// Token: 0x040000ED RID: 237
	public const sbyte MUSIC_HANGDONG = 3;

	// Token: 0x040000EE RID: 238
	public const sbyte MUSIC_DAMLAY = 4;

	// Token: 0x040000EF RID: 239
	public const sbyte MUSIC_GIOTHOI = 5;

	// Token: 0x040000F0 RID: 240
	public const sbyte MUSIC_BOSS = 6;

	// Token: 0x040000F1 RID: 241
	public const sbyte MUSIC_SUOIMA = 7;

	// Token: 0x040000F2 RID: 242
	public const sbyte MUSIC_SAMAC = 8;

	// Token: 0x040000F3 RID: 243
	public const sbyte MUSIC_PHOBANG = 9;

	// Token: 0x040000F4 RID: 244
	public const sbyte SOUND_2KIEM_LV1 = 0;

	// Token: 0x040000F5 RID: 245
	public const sbyte SOUND_SUNG_LV1 = 1;

	// Token: 0x040000F6 RID: 246
	public const sbyte SOUND_PS_LV1 = 2;

	// Token: 0x040000F7 RID: 247
	public const sbyte SOUND_KIEM_LV1 = 3;

	// Token: 0x040000F8 RID: 248
	public const sbyte SOUND_KIEM_LV2 = 4;

	// Token: 0x040000F9 RID: 249
	public const sbyte SOUND_KIEM_LV3 = 5;

	// Token: 0x040000FA RID: 250
	public const sbyte SOUND_KIEM_LV4 = 6;

	// Token: 0x040000FB RID: 251
	public const sbyte SOUND_2KIEM_LV2 = 7;

	// Token: 0x040000FC RID: 252
	public const sbyte SOUND_2KIEM_LV3_GAIDOC = 8;

	// Token: 0x040000FD RID: 253
	public const sbyte SOUND_2KIEM_LV3_PHANTHAN = 9;

	// Token: 0x040000FE RID: 254
	public const sbyte SOUND_2KIEM_LV4_5KIEM = 10;

	// Token: 0x040000FF RID: 255
	public const sbyte SOUND_2KIEM_LV5_MUADOC = 11;

	// Token: 0x04000100 RID: 256
	public const sbyte SOUND_PS_LV2 = 13;

	// Token: 0x04000101 RID: 257
	public const sbyte SOUND_PS_LV3 = 14;

	// Token: 0x04000102 RID: 258
	public const sbyte SOUND_PS_LV4 = 15;

	// Token: 0x04000103 RID: 259
	public const sbyte SOUND_PS_LV5 = 16;

	// Token: 0x04000104 RID: 260
	public const sbyte SOUND_SUNG_LV2_3VIEN = 12;

	// Token: 0x04000105 RID: 261
	public const sbyte SOUND_SUNG_LV2_DANDIEN = 17;

	// Token: 0x04000106 RID: 262
	public const sbyte SOUND_SUNG_LV3_TENLUA = 18;

	// Token: 0x04000107 RID: 263
	public const sbyte SOUND_SUNG_LV3_LASER = 19;

	// Token: 0x04000108 RID: 264
	public const sbyte SOUND_SUNG_LV4_BAODAN = 20;

	// Token: 0x04000109 RID: 265
	public const sbyte SOUND_SUNG_LV4_SET = 21;

	// Token: 0x0400010A RID: 266
	public const sbyte SOUND_SUNG_LV5_MUASET = 22;

	// Token: 0x0400010B RID: 267
	public const sbyte SOUND_SUNG_LV5_MUATENLUA = 23;

	// Token: 0x0400010C RID: 268
	public const sbyte SOUND_EFF_CUONGHOA1 = 24;

	// Token: 0x0400010D RID: 269
	public const sbyte SOUND_PET_SOI = 25;

	// Token: 0x0400010E RID: 270
	public const sbyte SOUND_EFF_CUONGHOA_OK = 26;

	// Token: 0x0400010F RID: 271
	public const sbyte SOUND_EFF_CUONGHOA_FAIL = 27;

	// Token: 0x04000110 RID: 272
	public const sbyte SOUND_EFF_COIN_GEM = 28;

	// Token: 0x04000111 RID: 273
	public const sbyte SOUND_EFF_SHOW_BOX = 29;

	// Token: 0x04000112 RID: 274
	public const sbyte SOUND_EFF_GONG_BUFF_NU = 30;

	// Token: 0x04000113 RID: 275
	public const sbyte SOUND_EFF_GONG_BUFF_NAM = 31;

	// Token: 0x04000114 RID: 276
	public const sbyte SOUND_EFF_THIENTHACHROI = 32;

	// Token: 0x04000115 RID: 277
	public const sbyte SOUND_EFF_BOSSXUATHIEN = 33;

	// Token: 0x04000116 RID: 278
	public const sbyte SOUND_EFF_BOSS_S_PHONG = 34;

	// Token: 0x04000117 RID: 279
	public const sbyte SOUND_EFF_BOSS_S_NUOC = 35;

	// Token: 0x04000118 RID: 280
	public const sbyte SOUND_EFF_BOSS_S_TOA = 36;

	// Token: 0x04000119 RID: 281
	public const sbyte SOUND_EFF_BOSS_S_LUA = 37;

	// Token: 0x0400011A RID: 282
	public const sbyte SOUND_EFF_BIDANH = 38;

	// Token: 0x0400011B RID: 283
	public const sbyte SOUND_EFF_GIAOTIEP = 39;

	// Token: 0x0400011C RID: 284
	public const sbyte SOUND_EFF_THAYDO = 40;

	// Token: 0x0400011D RID: 285
	public const sbyte SOUND_EFF_CLICK = 41;

	// Token: 0x0400011E RID: 286
	public const sbyte SOUND_EFF_MENU = 42;

	// Token: 0x0400011F RID: 287
	public const sbyte SOUND_EFF_THOREN = 43;

	// Token: 0x04000120 RID: 288
	public const sbyte SOUND_EFF_DAMDONG1 = 44;

	// Token: 0x04000121 RID: 289
	public const sbyte SOUND_EFF_TELE = 45;

	// Token: 0x04000122 RID: 290
	public const sbyte SOUND_EFF_BUOCCHAN = 46;

	// Token: 0x04000123 RID: 291
	public const sbyte SOUND_EFF_MEO = 47;

	// Token: 0x04000124 RID: 292
	public const sbyte SOUND_EFF_GA = 48;

	// Token: 0x04000125 RID: 293
	public const sbyte SOUND_EFF_ECH = 49;

	// Token: 0x04000126 RID: 294
	public const sbyte SOUND_EFF_ECH_TIEP_NUOC = 50;

	// Token: 0x04000127 RID: 295
	public const sbyte SOUND_EFF_PLAYERDINUOC = 51;

	// Token: 0x04000128 RID: 296
	public const sbyte SOUND_EFF_CHUOT = 52;

	// Token: 0x04000129 RID: 297
	public const sbyte SOUND_EFF_DUOCLUA = 53;

	// Token: 0x0400012A RID: 298
	public const sbyte SOUND_EFF_VOIPHUNNUOC = 54;

	// Token: 0x0400012B RID: 299
	public const sbyte SOUND_EFF_NUOCCHAY = 55;

	// Token: 0x0400012C RID: 300
	public const sbyte SOUND_EFF_GIOTNUOC = 56;

	// Token: 0x0400012D RID: 301
	public const sbyte SOUND_PET_BAN_TEN = 57;

	// Token: 0x0400012E RID: 302
	public const sbyte SOUND_EFF_CHAN_NGUA = 58;

	// Token: 0x0400012F RID: 303
	public static bool isEnableSound = true;

	// Token: 0x04000130 RID: 304
	public static int status;

	// Token: 0x04000131 RID: 305
	public static int postem;

	// Token: 0x04000132 RID: 306
	public static int timestart;

	// Token: 0x04000133 RID: 307
	private static string filenametemp;

	// Token: 0x04000134 RID: 308
	private static int volumetem;

	// Token: 0x04000135 RID: 309
	public static bool isSound = true;

	// Token: 0x04000136 RID: 310
	public static bool isNotPlay;

	// Token: 0x04000137 RID: 311
	public static bool stopAll;

	// Token: 0x04000138 RID: 312
	public static AudioSource SoundWater;

	// Token: 0x04000139 RID: 313
	public static AudioSource SoundRun;

	// Token: 0x0400013A RID: 314
	public static AudioSource SoundBGLoop;

	// Token: 0x0400013B RID: 315
	public static int volumeSound = 1;

	// Token: 0x0400013C RID: 316
	public static int volumeMusic = 2;

	// Token: 0x0400013D RID: 317
	public static int[] soundID;

	// Token: 0x0400013E RID: 318
	public static int CurMusic = -1;

	// Token: 0x0400013F RID: 319
	public static bool isMusic = true;

	// Token: 0x04000140 RID: 320
	public static int[] isPlaying;

	// Token: 0x04000141 RID: 321
	public static AudioClip[] music;

	// Token: 0x04000142 RID: 322
	public static GameObject[] player;

	// Token: 0x04000143 RID: 323
	public static string[] fileName = new string[]
	{
		"0",
		"1",
		"2",
		"3",
		"4",
		"5",
		"6",
		"7",
		"8",
		"9",
		"10",
		"11",
		"12",
		"13",
		"14",
		"15",
		"16",
		"17",
		"18",
		"19",
		"29",
		"21",
		"22",
		"23",
		"24",
		"25",
		"26",
		"27",
		"28",
		"29",
		"30",
		"31",
		"32",
		"33"
	};

	// Token: 0x04000144 RID: 324
	public static int l1;
}
